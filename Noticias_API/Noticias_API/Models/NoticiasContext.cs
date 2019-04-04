using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias_API.Models
{
    public class NoticiasContext: DbContext
    {
        public NoticiasContext(DbContextOptions opciones) : base(opciones)
        {

        }


        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Noticia> Noticias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Autor.Map(modelBuilder.Entity<Autor>());
            new Noticia.Map(modelBuilder.Entity<Noticia>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
