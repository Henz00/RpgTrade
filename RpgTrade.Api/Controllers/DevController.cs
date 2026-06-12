using Microsoft.AspNetCore.Mvc;
using RpgTrade.Application.ItemGeneration;
using RpgTrade.Domain;
using RpgTrade.Infrastructure.Persistence;

namespace RpgTrade.Api.Controllers
{
    [ApiController]
    [Route("api/dev")]
    public class DevController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;

        [HttpPost("generate-items")]
        public async Task<IActionResult> GenerateItems([FromQuery] int count = 100)
        {
            if (count <= 0)
            {
                return BadRequest("Count must be greater than 0.");
            }

            if (count > 10_000)
            {
                return BadRequest("Count cannot be greater than 10,000.");
            }

            var random = new Random();
            var items = new List<Item>();

            for (int i = 0; i < count; i++)
            {
                var seed = random.Next(0, int.MaxValue);

                var generatedItem = ItemGenerator.Generate(seed, ItemRarity.Rare);

                var databaseItem = new Item
                {
                    Id = generatedItem.Id,
                    Name = generatedItem.Name,
                    Rarity = generatedItem.Rarity,
                    ItemLevel = generatedItem.ItemLevel,
                    BaseTypeId = generatedItem.BaseTypeId,

                    // Important:
                    // Do NOT set BaseType here.
                    // EF should only save the FK, not try to insert BaseType/ItemClass again.
                    Modifiers = generatedItem.Modifiers.Select(modifier => new ItemModifier
                    {
                        Id = modifier.Id,
                        ItemId = generatedItem.Id,
                        ModifierDefinitionId = modifier.ModifierDefinitionId,
                        Value = modifier.Value

                        // Important:
                        // Do NOT set Definition here.
                    }).ToList()
                };

                items.Add(databaseItem);
            }

            _dbContext.Items.AddRange(items);

            await _dbContext.SaveChangesAsync();

            return Ok(new
            {
                Message = $"Generated {count} items.",
                Count = count
            });
        }
    }
}