using Microsoft.EntityFrameworkCore;
namespace Inventory.Model
{
    public class MyDbContex : DbContext
    {
        public MyDbContex(DbContextOptions<MyDbContex> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<item_master> item_master { get; set; }
        public DbSet<sales_booking> sales_booking { get; set; }
        public DbSet<sales_booking_details> sales_booking_details {  get; set; }
    }
}
