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
        public DbSet<customer> customer { get; set; }
        public DbSet<delivery_head> delivery_head { get; set; }
        public DbSet<delivery_details> delivery_details { get; set; }
        public DbSet<product_stock> product_stock { get; set; }
        public DbSet<purchase_order> purchase_order { get; set; }
        public DbSet <purchase_order_details> purchase_order_details { get; set; }
    }
}
