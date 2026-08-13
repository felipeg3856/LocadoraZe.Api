using LocadoraZe.Api.Models;
using Microsoft.EntityFrameworkCore;



namespace LocadoraZe.Api.Data
{
    public class AppDbcontext : DbContext
    {

        public AppDbcontext(DbContextOptions<AppDbcontext>
            options) : base(options)
        {
        }

        public DbSet<Patinetes> Patinetes { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Locacoes> Locacoes { get; set; }

    }
}

