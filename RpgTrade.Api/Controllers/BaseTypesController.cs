using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgTrade.Api.Contracts.Items;
using RpgTrade.Infrastructure.Persistence;

namespace RpgTrade.Api.Controllers
{
    [ApiController]
    [Route("api/base_types")]
    public class BaseTypesController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;
        [HttpGet]
        public async Task<IActionResult> GetAllBaseTypes()
        {
            var basetypes = await _dbContext.BaseTypes
                .AsNoTracking()
                .Select(basetype => new BaseTypeDto
                {
                    Id = basetype.Id,
                    Name = basetype.Name
                })
                .OrderBy(basetype => basetype.Name)
                .ToListAsync();

            return Ok(basetypes);
        }
    }
}
