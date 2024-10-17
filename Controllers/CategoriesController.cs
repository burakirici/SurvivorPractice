using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurvivorPractice.Data;
using SurvivorPractice.Entities;

namespace SurvivorPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly SurvivorContext _survivorcontext;

        public CategoriesController(SurvivorContext context)
        {
            _survivorcontext = context;
        }

        // api/category (GET)

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryEntity>>> GetCategory()
        {
            return await _survivorcontext.Categories.Include(c => c.Competitors).ToListAsync();
        }

        // api/category/xxx (GET)
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryEntity>> GetCategoryById(int id)
        {
            var category = await _survivorcontext.Categories.Include(c => c.Competitors).FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        // api/category/xxx (HttpPUT)
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, CategoryEntity category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            _survivorcontext.Entry(category).State = EntityState.Modified;
            category.ModifyDate = DateTime.UtcNow;

            try
            {
                await _survivorcontext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!_survivorcontext.Categories.Any(c => c.Id == id))
                {
                    return NotFound();
                }

                else 
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryById(int id)
        {
            var category = await _survivorcontext.Categories.FindAsync(id);
            if(category == null)
                return NotFound();

            category.IsDeleted = true;
            category.ModifyDate = DateTime.Now;

            await _survivorcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}
