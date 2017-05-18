using CGAP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CGAP_API 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>()
                .HasOne(p => p.Sala)
                .WithMany(s => s.Produtos)
                .HasForeignKey(p => p.SalaID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_Produto_Sala");

            builder.Entity<Sala>()
                .HasOne(s => s.Departamento)
                .WithMany(d => d.Salas)
                .HasForeignKey(s => s.DepartamentoID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_Sala_Departamento");

            builder.Entity<Usuario>()
                .HasOne(a => a.Departamento)
                .WithMany(d => d.Usuarios)
                .HasForeignKey(a => a.DepartamentoID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_Usuario_Departamento");

            builder.Entity<Usuario>()
                .HasOne(a => a.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(a => a.PerfilID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_Usuario_Perfil");

            base.OnModelCreating(builder);
        }

        public ApplicationDbContext() { }
        public DbSet<Produto> Products { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

    }
}
