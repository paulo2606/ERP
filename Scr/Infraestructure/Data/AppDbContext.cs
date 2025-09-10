using ERP.Scr.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Scr.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresas> Empresas { get; set; }

        public DbSet<Login> Login { get; set; }
    }
}
