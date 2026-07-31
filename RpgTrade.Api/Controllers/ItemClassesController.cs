using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgTrade.Domain;
using RpgTrade.Infrastructure.Persistence;

namespace RpgTrade.Api.Controllers
{
    [ApiController]
    [Route("api/item_classes")]
    public class ItemClassesController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _appDbContext = dbContext;
        [HttpGet]
        public async Task<IActionResult> GetAllItemClasses()
        {
            var itemclasses = await _appDbContext.ItemClasses
                .AsNoTracking()
                .Select(itemclass => new ItemClass
                {
                    Id = itemclass.Id,
                    Name = itemclass.Name
                })
                .OrderBy(itemclass => itemclass.Name)
                .ToListAsync();

            return Ok(itemclasses);
        }
    }
}
