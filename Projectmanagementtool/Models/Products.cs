namespace Projectmanagementtool.Models
{
    public class Products
    {
        public Guid Id { get; set; }
            
        public string Product_Name { get; set; }
        public string Type { get; set; }
            
        public string Colour { get; set; }

        public decimal Price { get; set; }
    }
}
