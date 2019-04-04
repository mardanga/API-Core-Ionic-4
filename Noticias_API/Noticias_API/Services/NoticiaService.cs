
using Microsoft.EntityFrameworkCore;
using Noticias_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias_API.Services
{
    public class NoticiaService
    {
        public readonly NoticiasContext _ctx;

        public NoticiaService(NoticiasContext ctx) {
            _ctx = ctx;
        }


        public List<Noticia> VerListadoTodasLasNoticias()
        {
            var NoticiasBuscada = _ctx.Noticias.Include(x => x.Autor).OrderByDescending(x => x.NoticiaID).ToList();
            return NoticiasBuscada;
        }

        public Noticia ObtenerPorID(int NoticiaID)
        {
            try
            {
                var NoticiasBuscada = _ctx.Noticias.Where(x => x.NoticiaID == NoticiaID).FirstOrDefault();
                var autor = _ctx.Autores.Where(x => x.AutorID == NoticiasBuscada.AutorID).FirstOrDefault();

                return NoticiasBuscada;
            }
            catch (Exception error)
            {
                return new Noticia();
            }
        }
        public bool Agregar(Noticia NoticiasAgregar)
        {
            try
            {
                _ctx.Noticias.Add(NoticiasAgregar);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }

        }


        public bool Editar(Noticia NoticiasEditar)
        {
            try
            {
                var Noticias = _ctx.Noticias.FirstOrDefault(x => x.NoticiaID == NoticiasEditar.NoticiaID);
                Noticias.Titulo = NoticiasEditar.Titulo;
                Noticias.Descripcion = NoticiasEditar.Descripcion;
                Noticias.Contenido = NoticiasEditar.Contenido;
                Noticias.Fecha = NoticiasEditar.Fecha;
                Noticias.AutorID = NoticiasEditar.AutorID;
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }

        }

        public bool Eliminar(int NoticiasID)
        {
            try
            {
                var NoticiasEliminar = _ctx.Noticias.FirstOrDefault(x => x.NoticiaID == NoticiasID);
                _ctx.Noticias.Remove(NoticiasEliminar);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return true;
            }
        }


        public List<Autor> ListadoDeAutores()
        {
            try
            {
                var autores = _ctx.Autores.ToList();

                return autores;
            }
            catch (Exception error)
            {
                return new List<Autor>();
            }
        }


    }
}
