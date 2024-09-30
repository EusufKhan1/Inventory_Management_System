using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class purchase_order
    {
        [Key]
        public int purId { get; set; }
        public string trnno { get; set; }
        public decimal totalAmt { get; set; }
        public decimal extraCarringCharge { get; set; }
        public DateTime bookingDate { get; set; }
        public decimal quantity { get; set; }
        public decimal specialDiscPer { get; set; }
        public decimal specialDisAmt { get; set; }
        public string purchsePrefix { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
        public decimal payment { get; set; }
        public List<purchase_order_details> Details { get; set; }
    }
}
