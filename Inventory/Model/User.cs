namespace Inventory.Model
{
    public class User
    {
        public int userId {  get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int isActive { get; set; } = 1;
        public DateTime createDate { get; set; }=DateTime.Now;
    }
}
