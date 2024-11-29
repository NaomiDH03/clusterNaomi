using clusterNaomi.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace clusterNaomi.Api.Controllers
{
    [ApiController]
    [Route("api/stores")]
    public class StoresController : ControllerBase
    {
        private readonly DataContext dataContext;

        public StoresController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var stores = await dataContext.Stores
                .Include(s => s.Icecreams) // Incluir la relación con Icecreams
                .ToListAsync();

            return Ok(stores);
        }
        [HttpGet("id:int")] //Metodo get
        public async Task<ActionResult> GetAsync(int id)
        {
            var store = await dataContext.Stores
                .Include(s => s.Icecreams) // Incluir la relación con Icecreams
                .FirstOrDefaultAsync(x => x.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }
        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Store store)
        {
            dataContext.Stores.Add(store);
            await dataContext.SaveChangesAsync();
            return Ok(store);

        }
        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Store store)
        {
            dataContext.Stores.Update(store);
            await dataContext.SaveChangesAsync();
            return Ok(store);
        }
        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var afectedRows = await dataContext.Stores.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
