using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgTrade.Api.Contracts.Items;
using RpgTrade.Infrastructure.Persistence;

namespace RpgTrade.Api.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetItems([FromQuery] int count = 0)
        {
            if (count <= 0)
            {
                return BadRequest("Count must be greater than 0.");
            }

            if (count > 200)
            {
                return BadRequest("Count cannot be greater than 200.");
            }

            var items = await _dbContext.Items
                .AsNoTracking()
                .Include(item => item.BaseType)
                    .ThenInclude(baseType => baseType.ItemClass)
                .Include(item => item.Modifiers)
                    .ThenInclude(modifier => modifier.Definition)
                .OrderBy(item => item.Name)
                .Take(count)
                .Select(item => new ItemDto {
                    Id = item.Id,
                    Name = item.Name,
                    Rarity = item.Rarity.ToString(),
                    ItemLevel = item.ItemLevel,
                    BaseType = item.BaseType.Name,
                    ItemClass = item.BaseType.ItemClass.Name,
                    Modifiers = item.Modifiers
                        .Select(modifier => new ItemModifierDto {
                            Name = modifier.Definition.Name,
                            Value = modifier.Value
                        })
                        .ToList()
                })
                .ToListAsync();

            return Ok(items);
        }
    }
}