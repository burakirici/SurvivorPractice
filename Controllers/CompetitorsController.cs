using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurvivorPractice.Data;
using SurvivorPractice.Entities;

namespace SurvivorPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorContext _survivorcontext;

        public CompetitorsController(SurvivorContext context)
        {
            _survivorcontext = context;
        }

        // GET: api/competitor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorEntity>>> GetCompetitors()
        {
            return await _survivorcontext.Competitors.Include(c => c.Category).ToListAsync();
        }

        // api/competitor/xxx (HttpGet by id)
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitorEntity>> GetCompetitor(int id)
        {
            var competitor = await _survivorcontext.Competitors.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

            if (competitor == null)
            {
                return NotFound();
            }

            return competitor;
        }

        // POST: api/competitor
        [HttpPost]
        public async Task<ActionResult<CompetitorEntity>> CreateCompetitor(CompetitorEntity competitor)
        {
            _survivorcontext.Competitors.Add(competitor);
            await _survivorcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);
        }

        // PUT: api/competitor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitor(int id, CompetitorEntity competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest();
            }

            _survivorcontext.Entry(competitor).State = EntityState.Modified;
            competitor.ModifyDate = DateTime.Now;

            try
            {
                await _survivorcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_survivorcontext.Competitors.Any(c => c.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/competitor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _survivorcontext.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound();
            }

            competitor.IsDeleted = true;
            competitor.ModifyDate = DateTime.Now;

            await _survivorcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}
