using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //return ok es q trae 1 json
            return Ok(await _context.Countries.ToListAsync()); //Trae todos los Countries en una lista
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            //return ok es q trae 1 json
            var country = await _context.Countries.FirstOrDefaultAsync(p => p.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country); //Trae todos los Countries en una lista
        }



        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            try
            {
                //actionresult es una respuesta de http
                _context.Countries.Add(country);

                //podria escribir solo _context.Add(country) porque sabe que country es de tipo Countries pero lo hago para guiarme, en el futuro it wont be like this

                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException db)
            {
                if (db.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("There is already a country with that name");
                }
                return BadRequest(db.Message);
            }
            catch (Exception e) 
            {
                if (e.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("There is already a country with that name");
                }
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            try
            {
                //actionresult es una respuesta de http
                _context.Countries.Update(country);

                //podria escribir solo _context.Update(country) porque sabe que country es de tipo Countries pero lo hago para guiarme, en el futuro it wont be like this

                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException db)
            {
                if (db.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("There is already a country with that name");
                }
                return BadRequest(db.Message);
            }
            catch (Exception e)
            {
                if (e.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("There is already a country with that name");
                }
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            //return ok es q trae 1 json
            var country = await _context.Countries.FirstOrDefaultAsync(p => p.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent(); //testing
        }
    }
}
