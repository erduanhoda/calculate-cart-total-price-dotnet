using System;
using System.Threading.Tasks;
using FSLChallengeDotNet.API.ResponseModels;
using FSLChallengeDotNet.Core.Dto.CartDTO;
using FSLChallengeDotNet.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSLChallengeDotNet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTotal(Guid id)
        {
            var total = await _cartService.GetTotal(GetTotalInput.Instance(id));
            return Ok(GetTotalResponse.Instance(total.Total));
        }
        
        [HttpPost("{cartId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(Guid cartId, Guid itemId)
        {
            await _cartService.Add(AddItemInput.Instance(cartId, itemId));
            return Ok();
        }

        [HttpDelete("{cartId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Remove(Guid cartId, Guid itemId)
        {
            await _cartService.Remove(RemoveItemInput.Instance(cartId, itemId));
            return Ok();
        }
    }
}




