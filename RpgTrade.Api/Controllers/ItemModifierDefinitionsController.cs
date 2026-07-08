using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgTrade.Api.Contracts.Items;
using RpgTrade.Infrastructure.Persistence;

namespace RpgTrade.Api.Controllers
{
    [ApiController]
    [Route("api/item_modifiers")]
    public class ItemModifierDefinitionsController (AppDbContext dbContext): ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;
        [HttpGet]
        public async Task<IActionResult> GetAllModifiers()
        {   
            var modifiers = await _dbContext.ModifierDefinitions
                .AsNoTracking()
                .Select(modifier => new ItemSearchModifierDto
                {
                    ModifierDefinitionId = modifier.Id,
                    Name = modifier.Name
                })
                .OrderBy(m => m.Name)
                .ToListAsync();

            return Ok(modifiers);
                
        }
    }
}
