using ERP.Src.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Src.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<NaturezaJuridica> NaturezasJuridicas { get; set; }
        public DbSet<TipoVinculoEmpresa> TiposVinculoEmpresa { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Regiao> Regioes { get; set; }

    }
}
