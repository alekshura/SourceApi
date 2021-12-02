using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Compentio.SourceApi.WebExample.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class StoreController : StoreControllerBase
    {
        /// <inheritdoc />
        public async override Task<IActionResult> DeleteOrder([BindRequired] long orderId)
        {
            // Implement your async code here
            return Accepted();
        }

        /// <inheritdoc />
        public async override Task<ActionResult<IDictionary<string, int>>> GetInventory()
        {
            // Implement your async code here
            return Ok();
        }

        /// <inheritdoc />
        public async override Task<ActionResult<Order>> GetOrderById([BindRequired] long orderId)
        {
            // Implement your async code here
            return Accepted();
        }

        /// <inheritdoc />
        public async override Task<ActionResult<Order>> PlaceOrder([BindRequired, FromBody] Order body)
        {
            // Implement your async code here
            return Accepted();
        }
    }
}
