using DBOPERATION.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NewProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ProjDBContext _projdbContext;

       public CurrencyController(ProjDBContext dbContext)
       {
            _projdbContext = dbContext;
       }

        [HttpGet("GetAllDataUsingProperLinq")]
        public IActionResult GetActionResult()
        {
            var result = _projdbContext.Currencies.ToList();
            return Ok(result);
        }

        [HttpGet("GetAllDataUsingProperLinqAndAsync")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await _projdbContext.Currencies.ToListAsync();
            return Ok(result);
        }

        //[HttpGet("GetAllDataUsingSQLQuery")]
        //public IActionResult GetActionResult()
        //{
        //    var result = _projdbContext.Currencies.ToList();
        //    return Ok(result);
        //}

        [HttpGet("GetAllDataUsingSQLAndAsync")]
        public async Task<IActionResult> GetAllCurrenciesUsingSQL()
        {
            var result = await (from currencies in _projdbContext.Currencies
                                select currencies).ToListAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCurrenciesById([FromRoute] int id)
        {
            var result = await _projdbContext.Currencies.FindAsync(id);
            return Ok(result);
        }

        [HttpPost("GetAllRecordsByMultipleIDs")]
        public async Task<IActionResult> GetAllRecordsByIDs([FromBody] int[] ids)
        {
            var result = await _projdbContext.Currencies.Where(x => ids.Contains(x.Id)).ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetSelectedColumns")]
        public async Task<IActionResult> GetSelectedColumns()
        {
            var result = await _projdbContext.Currencies.Select(x => new Currency()
            {
                Id = x.Id,
                Title = x.Title,
            }).ToListAsync();
            return Ok(result);
        }
    }
}
