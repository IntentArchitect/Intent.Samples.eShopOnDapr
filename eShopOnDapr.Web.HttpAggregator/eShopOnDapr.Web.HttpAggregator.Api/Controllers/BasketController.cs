using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EShopOnDapr.Web.HttpAggregator.Application;
using EShopOnDapr.Web.HttpAggregator.Application.UpdateAll;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace EShopOnDapr.Web.HttpAggregator.Api.Controllers
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
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost]
        [ProducesResponseType(typeof(BasketData), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BasketData>> UpdateAll([FromBody] UpdateBasketRequest data, [FromHeader(Name = "auth")] string authorization, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateAllCommand { Data = data, Authorization = authorization }, cancellationToken);
            return Created(string.Empty, result);
        }
    }
}