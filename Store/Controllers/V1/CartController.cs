using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Contracts.V1;
using Store.Contracts.V1.Requests;
using Store.Contracts.V1.Responses;
using Store.Models;
using Store.Services;

namespace Store.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly ICartItemService cartService;
        private readonly IMapper mapper;

        public CartController(ICartItemService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }


        [HttpPost(ApiRoutes.Cart.AddToCart)]
        public async Task<IActionResult> AddToCart([FromBody]CartRequest cartRequest)
        {
            var newCart = mapper.Map<CartItem>(cartRequest);

            var cart = await cartService.AddToCart(newCart);

            var response = mapper.Map<CartResponse>(cart);

            return Ok(response);

        }

        [HttpGet(ApiRoutes.Cart.GetCartItems)]
        public async Task<IActionResult> GetCartItems([FromQuery] CartRequest cartRequest)
        {

        }
    }
}

