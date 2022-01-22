using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSLChallengeDotNet.Core.Dto.CartDTO;
using FSLChallengeDotNet.Core.Entities;
using FSLChallengeDotNet.Core.Guards;
using FSLChallengeDotNet.Core.Interfaces;

namespace FSLChallengeDotNet.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository _repository;

        public CartService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTotalOutput> GetTotal(GetTotalInput input)
        {
            GuardClauses.IsNotEmptyGuid(input.CartId);

            var cart = await _repository.GetByIdAsync<Cart>(input.CartId);

            GuardClauses.IsNotEmptyObject(cart);

            var cartItems = await _repository.ListAsync<CartItem>(x => x.CartId.Equals(cart.Id));
            cart.CartItems = cartItems;

            return GetTotalOutput.Instance(cart.GetTotal());
        }

        public async Task Add(AddItemInput input)
        {
            var cartItem = await GetCartItem(input.CartId, input.ItemId);

            if (cartItem == null)
            {
                await _repository.AddAsync(
                    new CartItem {
                        CartId = input.CartId,
                        ItemId = input.ItemId,
                        Quantity = 1
                    });
                return;
            }

            cartItem.Quantity++;
            await _repository.UpdateAsync(cartItem);
        }

        public async Task Remove(RemoveItemInput input)
        {
            var cartItem = await GetCartItem(input.CartId, input.ItemId);

            if (cartItem.Quantity == 1)
            {
                await _repository.DeleteAsync(cartItem);
                return;
            }

            cartItem.Quantity--;
            await _repository.UpdateAsync(cartItem);
        }

        private async Task<CartItem> GetCartItem(Guid cartId, Guid itemId)
        {
            GuardClauses.IsNotEmptyGuidArray(new List<Guid> { cartId, itemId });

            var cart = await _repository.GetByIdAsync<Cart>(cartId);
            var item = await _repository.GetByIdAsync<Item>(itemId);

            GuardClauses.IsNotEmptyObjectArray(new List<object> { cart, item });

            return cart.CartItems.FirstOrDefault(x => x.ItemId == item.Id);
        }
    }
}
