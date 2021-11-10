using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compentio.SourceApi.WebExample.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PetsController : PetsControllerBase
    {
        /// <inheritdoc />
        [OpenApiTag("pets")]
        public override Task<IActionResult> AddPet([BindRequired, FromBody] Pet body)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        [OpenApiTag("users")]
        public override Task<IActionResult> CreateUser([BindRequired, FromBody] User body)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<IActionResult> CreateUsersWithArrayInput([BindRequired, FromBody] IEnumerable<User> body)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<IActionResult> CreateUsersWithListInput([BindRequired, FromBody] IEnumerable<User> body)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("orders")]
        public override Task<IActionResult> DeleteOrder([BindRequired] long orderId)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("pets")]
        public override Task<IActionResult> DeletePet([BindRequired] long petId, [FromHeader] string api_key = null)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<IActionResult> DeleteUser([BindRequired] string username)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("pets")]
        public override Task<ActionResult<ICollection<Pet>>> FindPetsByStatus([BindRequired, FromQuery] IEnumerable<Anonymous> status)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("pets")]
        public override Task<ActionResult<ICollection<Pet>>> FindPetsByTags([BindRequired, FromQuery] IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }


        [OpenApiTag("users")]
        public override Task<ActionResult<IDictionary<string, int>>> GetInventory()
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("orders")]
        public override Task<ActionResult<Order>> GetOrderById([BindRequired] long orderId)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("pets")]
        public override Task<ActionResult<Pet>> GetPetById([BindRequired] long petId)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<ActionResult<User>> GetUserByName([BindRequired] string username)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<ActionResult<string>> LoginUser([BindRequired, FromQuery] string username, [BindRequired, FromQuery] string password)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<IActionResult> LogoutUser()
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("orders")]
        public override Task<ActionResult<Order>> PlaceOrder([BindRequired, FromBody] Order body)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("pets")]
        public override Task<IActionResult> UpdatePet([BindRequired, FromBody] Pet body)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("pets")]
        public override Task<IActionResult> UpdatePetWithForm([BindRequired] long petId, [FromBody] Body body = null)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<IActionResult> UpdateUser([BindRequired] string username, [BindRequired, FromBody] User body)
        {
            throw new NotImplementedException();
        }

        [OpenApiTag("users")]
        public override Task<ActionResult<ApiResponse>> UploadFile([BindRequired] long petId, string additionalMetadata = null, FileParameter file = null)
        {
            throw new NotImplementedException();
        }
    }
}
