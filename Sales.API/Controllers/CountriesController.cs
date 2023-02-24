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
        public async Task<IActionResult> Get() 
        { 
            //return ok es q trae 1 json
            return Ok(await _context.Countries.ToListAsync()); //Trae todos los Countries en una lista
        }

        [HttpPut]
        public async Task<IActionResult> GetSelectedCountry(Country country)
        {
            //return ok es q trae 1 json
            return Ok(await _context.Countries.FirstOrDefaultAsync(p => p.Name == country.Name)); //Trae todos los Countries en una lista
        }



        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        { 
        //actionresult es una respuesta de http
            _context.Countries.Add(country);

            //podria escribir solo _context.Add(country) porque sabe que country es de tipo Countries pero lo hago para guiarme, en el futuro it wont be like this

            await _context.SaveChangesAsync();
            return Ok(country);
        }
    }
}
