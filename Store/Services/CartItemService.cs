using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Helpers;
using Store.Models;

namespace Store.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly DataContext dataContext;
        private readonly IUser user;

        public CartItemService(DataContext dataContext, IUser user)
        {
            this.dataContext = dataContext;
            this.user = user;
        }
        public async Task<CartItem> AddToCart(CartItem cartItem)
        {

            if (!await dataContext.Products.AnyAsync(x => x.Id == cartItem.ProductId))
            {
                throw new Exception("Product is not added");
            }
            else
            {
                var exhistsCart = await dataContext.CartItem.FirstOrDefaultAsync(x => x.UserId == user.Id && x.ProductId == cartItem.ProductId);

                if (exhistsCart != null)
                {
                    exhistsCart.Quantity += cartItem.Quantity;

                }
                else
                {
                    cartItem.UserId = user.Id;
                    cartItem.IsCommited = false;

                    dataContext.CartItem.Add(cartItem);
                }
            }

            await dataContext.SaveChangesAsync();

            return cartItem;
        }




        public async Task<CartItem> CommitCart(CartItem cartItem)
        {
            cartItem.UserId = user.Id;

            cartItem.IsCommited = true;

            dataContext.CartItem.Add(cartItem);

            await dataContext.SaveChangesAsync();

            return cartItem;
        }

        public async Task<CartItem> DeleteCart(CartItem cartItem)
        {
            var cartItemToDelete = cartItem.CartItemId;

          

           

            return cartItem;
        }

        public async Task<ICollection<CartItem>> GetCartItems(CartItem cart)
        {
            return await dataContext.CartItem.Include(x => cart.CartItemId).ToListAsync();
        }
    }
}
