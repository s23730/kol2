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
    [Route("api/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IDBService _serv;
        public AlbumsController(DBContext context)
        {
            _serv = new DBService(context);
        }
        [HttpGet]
        [Route("{idAlbum}")]
        public async Task<IActionResult> GetAlbum([FromRoute]int idAlbum)
        {
            return Ok(await _serv.GetAlbum(idAlbum));
        }
    }
}
