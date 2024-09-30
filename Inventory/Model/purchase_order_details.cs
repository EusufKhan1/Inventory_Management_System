using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class purchase_order_details
    {

        [Key]
        public int purDetailsId { get; set; }
        public int purId { get; set; }
        public string trnno { get; set; }
        public int productId { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public string productUnit { get; set; }
        public decimal quantity { get; set; }
        public decimal rate { get; set; }
        public decimal productDisPer { get; set; }
        public decimal productDisAmt { get; set; }
        public decimal lineAmt { get; set; }
        public DateTime createDate { get; set; }

    }
}
