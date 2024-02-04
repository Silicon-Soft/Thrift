using Microsoft.AspNetCore.Identity;
using Thrift_Us.Models;


namespace Thrift_Us.ViewModel.Product
{
    public class ProductIndexViewModel
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
     
        public decimal RentalPrice { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ImagePath { get; set; }

        public string Condition { get; set; }
        public int CategoryId { get; set; }
        public Thrift_Us.Models.Category Category { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
