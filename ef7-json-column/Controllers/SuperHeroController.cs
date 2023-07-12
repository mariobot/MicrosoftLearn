using Ef7JsonColumns.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ef7JsonColumns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext dataContext;

        public SuperHeroController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHeroes(List<SuperHero> heroes)
        {

            this.dataContext.Heroes.AddRange(heroes);

            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.Heroes.ToListAsync());
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes(string city)
        {

            var heroes = await this.dataContext.Heroes.Include(x => x.Details).Where(x => x.Details.City.Contains(city)).ToListAsync();

            return Ok(heroes);
        }
    }
}
