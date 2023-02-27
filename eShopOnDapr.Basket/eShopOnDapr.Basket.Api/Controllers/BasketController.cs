using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EShopOnDapr.Basket.Application;
using EShopOnDapr.Basket.Application.Checkout;
using EShopOnDapr.Basket.Application.DeleteBasket;
using EShopOnDapr.Basket.Application.GetBasket;
using EShopOnDapr.Basket.Application.UpdateBasket;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace EShopOnDapr.Basket.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ISender _mediator;

        public BasketController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified CustomerBasket.</response>
        /// <response code="404">Can't find an CustomerBasket with the parameters provided.</response>
        [HttpGet]
        [ProducesResponseType(typeof(CustomerBasket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerBasket>> GetBasket(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBasketQuery(), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerBasket), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody] CustomerBasket value, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateBasketCommand { Value = value }, cancellationToken);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("checkout")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Checkout([FromBody] BasketCheckout basketCheckout, [FromHeader(Name = "X-Request-Id")] string requestId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CheckoutCommand { BasketCheckout = basketCheckout, RequestId = requestId }, cancellationToken);
            return Created(string.Empty, null);
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBasket(CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteBasketCommand(), cancellationToken);
            return Ok();
        }
    }
}