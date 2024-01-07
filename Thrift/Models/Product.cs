namespace Thrift.Models
{
    public class Product
    {
       
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Condition { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public string UserId{ get; set;}
        public User? User { get; set; }


    }
    
}
