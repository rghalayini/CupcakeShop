using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Models
{
    public class Order : BaseEntity
    {

        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }
        //We store these details within the order to give the user more flexibilty 
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string OrderStatus { get; set; }
        //Tell Entity Framework link the two together. So when we load the order will auto load the items.
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
