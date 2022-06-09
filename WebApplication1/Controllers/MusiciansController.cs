using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/musicians")]
    public class MusiciansController : ControllerBase
    {
        private readonly IDBService _serv;
        public MusiciansController(DBContext context)
        {
            _serv = new DBService(context);
        }
        [HttpDelete]
        [Route("{idMusician}")]
        public async Task<IActionResult> DeleteMusician([FromRoute]int idMusician)
        {
            if(await _serv.DeleteMusician(idMusician))
            {
                return Ok("Muzyk zostal usuniety z bazdy danych.");
            }
            else
            {
                return BadRequest("Usuniecie muzyka z bazdy danych nie powiodlo sie.");
            }
        }
    }
}
