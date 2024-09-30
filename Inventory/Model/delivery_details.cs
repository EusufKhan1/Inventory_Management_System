using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class delivery_details
    {
        [Key]
        public int deliveryDetailsId { get; set; }
        public int deliveryId { get; set; }
        public string deliveryNo { get; set; }
        public int productId { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public string productUnit { get; set; }
        public decimal quantity { get; set; }
        public DateTime createDate { get; set; }
    }
}
