using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using vacancyApiNET8.Models;
using vacancyApiNET8.Models.DTOs;
using Microsoft.AspNetCore.Cors;



namespace vacancyApiNET8.Controllers
{
    [EnableCors("ReglasCors")]
    public class VacancyController : Controller
    {
        /*
            CRUD
                CREATE
                READ
                UPDATE
                DELETE
        */
        private readonly VacancyTrackerContext _dbContext;//el nombre de nuestro contexto

        public VacancyController(VacancyTrackerContext context)
        {
            this._dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody] VacancyInsertDTO entity)
        {
            try
            {
                //se inserta un status por default
                Status oStatus = new Status();
                oStatus.IdCatStatus = 1;
                oStatus.InsertUser = 1;// entity.IdUsuario;
                oStatus.IdNote = null;
                oStatus.InsertDate = DateOnly.FromDateTime(DateTime.Now);
                this._dbContext.Statuses.Add(oStatus);
                this._dbContext.SaveChanges();


                Vacancy oVacancy = new Vacancy();

                oVacancy.IdVacancy = entity.IdVacancy;
                oVacancy.IdUsuario = 1;//entity.IdUsuario;
                oVacancy.Title = entity.Title;
                oVacancy.VacancyLink = entity.VacancyLink;
                oVacancy.JobPositionName = entity.JobPositionName;
                oVacancy.JobDescription = entity.JobDescription;
                oVacancy.Company = entity.Company;
                oVacancy.RequiredSkill = entity.RequiredSkill;
                oVacancy.Salary = entity.Salary;
                oVacancy.IdCatContractType = entity.IdCatContractType;
                oVacancy.IdCatLanguage = entity.IdCatLanguage;
                oVacancy.IdCatCurrency = entity.IdCatCurrency;
                oVacancy.IdCatColor = entity.IdCatColor;
                //se asigna el id del status que se inserto
                oVacancy.IdStatus = oStatus.IdStatus;
                oVacancy.InsertUser = 1;
                oVacancy.InsertDate = DateOnly.FromDateTime(DateTime.Now);
                //oVacancy.IdNote = entity.IdNote;
                //oVacancy.IdCatColorNavigation = entity.IdCatColorNavigation;
                //oVacancy.IdCatCurrencyNavigation = entity.IdCatCurrencyNavigation;
                //oVacancy.IdNoteNavigation = entity.IdNoteNavigation;
                //oVacancy.IdStatusNavigation = entity.IdStatusNavigation;
                //oVacancy.IdUsuarioNavigation = entity.IdUsuarioNavigation;
                //oVacancy.Notes = entity.Notes;
                //oVacancy.IdCatContractTypeNavigation = entity.IdCatContractTypeNavigation;
                //oVacancy.IdCatLanguageNavigation = entity.IdCatLanguageNavigation;
                //oVacancy.IdUsuarioNavigation = entity.IdUsuarioNavigation;
                //oVacancy.IdCatContractTypeNavigation = entity.IdCatContractTypeNavigation;
                //oVacancy.IdCatLanguageNavigation = entity.IdCatLanguageNavigation;
                //oVacancy.IdUsuarioNavigation = entity.IdUsuarioNavigation;
                //oVacancy.IdCatContractTypeNavigation = entity.IdCatContractTypeNavigation;
                //oVacancy.IdCatLanguageNavigation = entity.IdCatLanguageNavigation;
                //oVacancy.IdUsuarioNavigation = entity.IdUsuarioNavigation;
                //oVacancy.IdCatContractTypeNavigation = entity.IdCatContractTypeNavigation;
                //oVacancy.IdCatLanguageNavigation = entity.IdCatLanguageNavigation;
                //oVacancy.IdUsuarioNavigation = entity.IdUsuarioNavigation;





                this._dbContext.Vacancies.Add(oVacancy);





                this._dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se guardo" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }

        [HttpGet]
        [Route("ReadList")]
        public async Task<IActionResult> ReadList()
        {
            try
            {
                var resultList = await this._dbContext.Vacancies.ToListAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", Response = resultList });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }

        [HttpGet]
        [Route("Read/{Id:int}")]
        public ActionResult Read(int IdVacancy)
        {
            Vacancy? oVacancy = new Vacancy();
            try
            {
                oVacancy = _dbContext.Vacancies.Find(IdVacancy);

                if (oVacancy == null)
                {
                    return BadRequest("Not found");
                }
                oVacancy = _dbContext.Vacancies.Where(p => p.IdVacancy == IdVacancy).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = oVacancy });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] Vacancy entity)
        {
            Vacancy? oVacancy = new Vacancy();
            try
            {
                oVacancy = this._dbContext.Vacancies.Find(entity.IdVacancy);

                if (oVacancy == null)
                {
                    return BadRequest("Not found");
                }

                //oArticulo.Descripcion = string.IsNullOrEmpty(entity.Descripcion) ? oArticulo.Descripcion : entity.Descripcion;
                //oArticulo.Precio = entity.Precio == 0 || entity.Precio == null ? oArticulo.Precio : entity.Precio;
                //oArticulo.Stock = entity.Stock == 0 || entity.Stock == null ? oArticulo.Stock : entity.Stock;

                this._dbContext.Vacancies.Update(oVacancy);
                this._dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Updated" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.ToString() });
            }
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var oVacancy = _dbContext.Vacancies.Find(id);

                if (oVacancy == null)
                    return NotFound(new { mensaje = "Article not found" });

                _dbContext.Vacancies.Remove(oVacancy);
                _dbContext.SaveChanges();

                return Ok(new { mensaje = "Article deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

    }
}
