using clusterNaomi.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clusterNaomi.Api.Controllers
{
    [ApiController]
    [Route("api/icecreams")]
    public class IcecreamController : ControllerBase
    {
        private readonly DataContext dataContext;

        public IcecreamController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET api/icecreams
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var icecreams = await dataContext.Icecreams.ToListAsync();
            return Ok(icecreams);
        }

        // GET api/icecreams/{id}
        [HttpGet("id:int")]
        public async Task<ActionResult<Icecream>> GetAsync(int id)
        {
            var icecream = await dataContext.Icecreams.FirstOrDefaultAsync(x => x.Id == id);
            if (icecream == null)
            {
                return NotFound();
            }
            return Ok(icecream);
        }

        // POST api/icecreams
        [HttpPost]
        public async Task<IActionResult> PostAsync(Icecream icecream)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verifica que la tienda exista antes de agregar el helado
                    var store = await dataContext.Stores.FirstOrDefaultAsync(s => s.Id == icecream.StoreId);
                    if (store == null)
                    {
                        return BadRequest("La tienda asociada no existe.");
                    }

                    // Agrega el helado
                    dataContext.Icecreams.Add(icecream);
                    await dataContext.SaveChangesAsync();

                    // Usa el ID correcto en el CreatedAtAction
                    return CreatedAtAction(nameof(GetAsync), new { id = icecream.Id }, icecream);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                // Log de error
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }



        // PUT api/icecreams/{id}
        [HttpPut("id:int")]
        public async Task<IActionResult> PutAsync(int id, Icecream icecream)
        {
            if (id != icecream.Id)
            {
                return BadRequest("The ID does not match.");
            }

            dataContext.Icecreams.Update(icecream);
            await dataContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/icecreams/{id}
        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var icecream = await dataContext.Icecreams.FirstOrDefaultAsync(x => x.Id == id);
            if (icecream == null)
            {
                return NotFound();
            }

            dataContext.Icecreams.Remove(icecream);
            await dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
