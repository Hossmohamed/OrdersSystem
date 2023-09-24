using Microsoft.EntityFrameworkCore;

namespace OrderUpdate.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions option) : base(option)
        {

        }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<SubOrders> SubOrders { get; set; }
    }
}
