using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Data
{
    public class TransporteSeguroContext: DbContext
    {
		public TransporteSeguroContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<ServiceType> ServiceTypes { get; set; }
		public DbSet<User> Users { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(
            "Server=(Localdb)\\mssqllocaldb;Database=TransporteSeguro;Trusted_Connection=True;");
        }

    }
}
