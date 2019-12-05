using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public bool IsCommited { get; set; }



    }
}
