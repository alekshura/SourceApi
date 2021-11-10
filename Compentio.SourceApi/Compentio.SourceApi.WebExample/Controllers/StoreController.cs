using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Compentio.SourceApi.WebExample.OpenApi;

namespace Compentio.SourceApi.WebExample.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class StoreController : StoreControllerBase
    {
        /// <inheritdoc />
        public override Task<IActionResult> DeleteOrder([BindRequired] long orderId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<IDictionary<string, int>>> GetInventory()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<Order>> GetOrderById([BindRequired] long orderId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<Order>> PlaceOrder([BindRequired, FromBody] Order body)
        {
            throw new NotImplementedException();
        }
    }
}
