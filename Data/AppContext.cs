using Microsoft.EntityFrameworkCore;
using Veiculos.Models;

namespace Veiculos.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Veiculo> Veiculo { get; set; }
    }
}
