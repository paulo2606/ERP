using ERP.Src.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ERP.Src.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<CentroCusto> CentroCusto { get; set; }
        public DbSet<Categoria> Categoria { get; set; } 
        public DbSet<Login> Login { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<NaturezaJuridica> NaturezasJuridicas { get; set; }
        public DbSet<TipoVinculoEmpresa> TiposVinculoEmpresa { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<NivelAcesso> NiveisAcesso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresas>()
                .HasQueryFilter(e => !e.FlgInativo);

            modelBuilder.Entity<Empresas>()
                .Property(e => e.NumCnpj)
                .HasColumnType("numeric(14,0)");

            modelBuilder.Entity<Empresas>()
                .Property(e => e.NumDddTelefone)
                .HasColumnType("char(2)");

            modelBuilder.Entity<Empresas>()
                .Property(e => e.NumTelefone)
                .HasColumnType("char(10)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
