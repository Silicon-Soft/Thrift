using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thrift_Us.Models
{
    public class Product
    {
        [Key]
        
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public long Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [StringLength(50)]
        public string Condition { get; set; }
    
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime PostedOn { get; set; }


    }


}

