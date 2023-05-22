using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Data
{
    public class TransporteSeguroContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(
            "Server=(Localdb)\\mssqllocaldb;Database=TransporteSeguro;Trusted_Connection=True;");
        }

    }
}
