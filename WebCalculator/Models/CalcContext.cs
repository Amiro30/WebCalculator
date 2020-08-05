using Microsoft.EntityFrameworkCore;

namespace WebCalculator.Models
{
    public class CalcContext: DbContext
    {
        public CalcContext(DbContextOptions<CalcContext> options) :base (options)
        {

        }
        public DbSet<Operation> Transactions { get; set; }
    }
}
