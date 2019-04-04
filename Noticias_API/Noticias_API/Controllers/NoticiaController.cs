using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noticias_API.Models;
using Noticias_API.Services;

namespace Noticias_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {

        private NoticiaService _ns;

        public NoticiaController( NoticiaService noticiaSrv ) {

            _ns = noticiaSrv;
        }

        public IActionResult Prueba()
        {
            return Ok("Funciona");
        }


        [Route("VerNoticias")]
        [HttpGet]
        public IActionResult VerNoticias()
        {
            var resultado = _ns.VerListadoTodasLasNoticias();
            return Ok(resultado);
        }

        [Route("PorNoticiaID/{NoticiaID}")]
        [HttpGet]
        public IActionResult NoticiaPorID(int NoticiaID)
        {
            return Ok(_ns.ObtenerPorID(NoticiaID));
        }


        [Route("Agregar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Noticia NoticiaAgregar)
        {
            if (_ns.Agregar(NoticiaAgregar))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }





        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Noticia NoticiaEditar)
        {
            if (_ns.Editar(NoticiaEditar))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



        [Route("eliminar/{noticiaID}")]
        public IActionResult Eliminar(int noticiaID)
        {
            if (_ns.Eliminar(noticiaID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }



        [Route("listadoAutores")]
        public IActionResult ListadoAutores()
        {
            return Ok(_ns.ListadoDeAutores());
        }

    }
}