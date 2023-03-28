using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework
{
    public class TimeOrganizatorDBContext : DbContext
    {
        public TimeOrganizatorDBContext(DbContextOptions<TimeOrganizatorDBContext> options) : base(options)
        {
        }
        public DbSet<AsignacionProyectoPorDia> AsignacionesProyectoPorDia { get; set; }
        public DbSet<AsignacionTipoProyectoPorDia> AsignacionesTipoProyectoPorDia { get; set; }
        public DbSet<DiaSemana> DiasSemana { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<PlanActividad> PlanesActividad { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TiempoReal> TiemposReales { get; set; }
        public DbSet<TipoActividad> TiposActividades { get; set; }
        public DbSet<TipoEstado> TiposEstados { get; set; }
        public DbSet<TipoProyecto> TiposProyecto { get; set; }
        public DbSet<TipoTiempo> TiposTiempo { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProyecto>()
                .HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoProyecto>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AsignacionTipoProyectoPorDia>()
                .HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AsignacionProyectoPorDia>()
                .HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Proyecto>()
                .HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Proyecto>()
                .HasOne(r => r.TipoProyecto)
                .WithMany()
                .HasForeignKey(r => r.TipoProyectoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoActividad>()
                .HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoProyecto>()
                .HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>()
                .HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlanActividad>()
                .HasOne(r => r.TipoActividad)
                .WithMany()
                .HasForeignKey(r => r.TipoActividadId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoTiempo>()
               .HasOne(r => r.TipoProyecto)
               .WithMany(tp => tp.TiposTiempo)
               .HasForeignKey(r => r.TipoProyectoId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>()
            .HasIndex(p => p.NombreUsuario)
            .IsUnique();

            modelBuilder.Entity<DiaSemana>()
            .HasIndex(p => p.Nombre)
            .IsUnique();
        }
    }
}
