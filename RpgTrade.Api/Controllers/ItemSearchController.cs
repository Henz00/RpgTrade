using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgTrade.Api.Contracts.Items;
using RpgTrade.Domain;
using RpgTrade.Infrastructure.Persistence;

namespace RpgTrade.Api.Controllers
{
    [ApiController]
    [Route("api/items/search")]


    public class ItemSearchController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;

        [HttpPost]
        public async Task<ActionResult<ItemSearchResponse>> SearchForItems([FromBody] ItemSearchRequest request, CancellationToken cancellationToken)
        {
            request.Page = Math.Max(1, request.Page);
            request.PageSize = Math.Clamp(request.PageSize, 1, 100);

            foreach (var filter in request.ModifierFilters)
            {
                if (filter.MinValue is not null && filter.MaxValue is not null && filter.MinValue > filter.MaxValue)
                {
                    return BadRequest("A modifier filter cannot have a min value greater than its max value.");
                }
            }

            var query = _dbContext.Items.AsNoTracking().AsQueryable();

            if (request.BaseTypeId is not null)
                query = query.Where(item => item.BaseType.Id == request.BaseTypeId);

            if (request.Rarity is not null)
                query = query.Where(item => item.Rarity == request.Rarity.Value);

            foreach (var filter in request.ModifierFilters)
            {
                query = query.Where(item =>
                    item.Modifiers.Any(modifier =>
                        modifier.ModifierDefinitionId == filter.ModifierDefinitionId &&
                        (filter.MinValue == null || modifier.Value >= filter.MinValue) &&
                        (filter.MaxValue == null || modifier.Value <= filter.MaxValue)
                    )
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query.OrderBy(item => item.Name).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).Select(item => new ItemSearchResultDto
            {
                Id = item.Id,
                Name = item.Name,
                Rarity = item.Rarity,
                BaseTypeId = item.BaseType.Id,
                BaseTypeName = item.BaseType.Name,
                ItemLevel = item.ItemLevel,
                Modifiers = item.Modifiers.Select(modifier => new ItemModifierDto
                {
                    ModifierDefinitionId = modifier.ModifierDefinitionId,
                    Name = modifier.Definition.Name,
                    Value = modifier.Value,
                }).ToList()
            }).ToListAsync(cancellationToken);

            var response = new ItemSearchResponse
            {
                Items = items,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };

            return Ok(response);
        }
    }
}
