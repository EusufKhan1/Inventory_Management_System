using Microsoft.EntityFrameworkCore;
namespace Inventory.Model
{
    public class MyDbContex : DbContext
    {
        public MyDbContex(DbContextOptions<MyDbContex> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
