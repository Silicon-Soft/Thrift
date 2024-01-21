using System.ComponentModel.DataAnnotations;
using Thrift_Us.Models;

namespace Thrift_Us.ViewModel
{
    public class CartOrderViewModel
    {
   
        public List<Cart> ListOfCart { get; set; }

        public OrderHeader OrderHeader { get; set; }





    }
}
