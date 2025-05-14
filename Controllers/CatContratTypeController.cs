using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using vacancyApiNET8.Models;
using vacancyApiNET8.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using vacancyApiNET8.Interfaces;

namespace vacancyApiNET8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("ReglasCors")]
    public class CatContratTypeController : Controller, ICatContractType
    {
        /*
         CRUD
            CREATE
            READ
            UPDATE
            DELETE
        */
        private readonly VacancyTrackerContext _dbContext;//el nombre de nuestro contexto


        public CatContratTypeController(VacancyTrackerContext context)
        {
            this._dbContext = context;
        }

        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ReadList()
        {
            try
            {
                var resultList = await this._dbContext.CatContractTypes
                    .OrderBy(c => c.Notation)
                    .ToListAsync();
                
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", Response = resultList });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }
    }
}
