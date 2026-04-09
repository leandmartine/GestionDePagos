using GestionDePagos.Entidades;
using GestionDePagos.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.EF
{
    public class ManagerContext : DbContext
    {
        public DbSet<Pago> Expenses { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<PagoUnico> PagoUnicos { get; set; }
        public DbSet<PagoCuotas> PagoCuotas { get; set; }
        public DbSet<Suscripcion> Suscripciones { get; set; }
        public DbSet<LimiteGasto> LimitesGasto { get; set; }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        public ManagerContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "SERVER=(localdb)\\mssqllocaldb; DATABASE=ExpenseManager; Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LimiteGasto>()
                .HasIndex(l => new { l.UsuarioId, l.CategoriaId })
                .IsUnique();

            modelBuilder.Entity<LimiteGasto>()
                .Property(l => l.MontoMaximo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<LimiteGasto>()
                .Property(l => l.ValorAlerta)
                .HasColumnType("decimal(18,2)");
        }
    }
}
