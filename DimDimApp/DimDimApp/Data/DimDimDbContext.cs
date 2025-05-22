using Microsoft.EntityFrameworkCore;
using DimDimApp.Models;

namespace DimDimApp.Data
{
    public class DimDimDbContext(DbContextOptions<DimDimDbContext> options) : DbContext(options)
    {
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
