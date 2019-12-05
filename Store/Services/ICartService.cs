using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface ICartItemService
    {
        Task<CartItem> AddToCart(CartItem cartItem);
        Task<CartItem> CommitCart(CartItem cartItem);
        Task<CartItem> DeleteCart(CartItem cartItem);
        Task<ICollection<CartItem>> GetCartItems(CartItem cartItem);
       

    }
}
