using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApp.Components.Forms;

namespace MinhaPrimeiraApp.Data
{
    public class PrimeiraAppContext : DbContext
    {
        public PrimeiraAppContext (DbContextOptions<PrimeiraAppContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; } = default!;
    }
}
