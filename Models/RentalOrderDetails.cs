namespace Thrift_Us.Models
{
    public class RentalOrderDetails
    {
        public int Id { get; set; }
        public int RentalOrderHeaderId { get; set; }
        public RentalOrderHeader RentalOrderHeader { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RentalPrice { get; set; }


    }
}
