using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class product_stock
    {
        [Key]
        public int stock_id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public decimal stockQty { get; set; }
        public string lastUpdateBy { get; set; }
        public DateTime lastUpdateDate {  get; set; }
        
    }
}
