using JwtTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTest.Controllers
{
    [Route("api/canciones")]
    [ApiController]
    public class CancionesController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult<List<Cancion>> Get()
        {
            return new List<Cancion>() { 
                new Cancion(){ Id=1,Nombre="Joseando",Artista = "Sipo One",Pais="Mexico" },
                new Cancion(){ Id=1,Nombre="Eclipse",Artista = "Eptos One",Pais="Mexico" },
                new Cancion(){ Id=1,Nombre="Sirena",Artista = "Faruzfeat",Pais="Mexico" },
                new Cancion(){ Id=1,Nombre="Mama",Artista = "Kidd keo",Pais="España" },
            };

        }
    }
}
