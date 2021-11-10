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
    public class UsersController : UsersControllerBase
    {
        /// <inheritdoc />
        public override Task<IActionResult> CreateUser([BindRequired, FromBody] User body)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> CreateUsersWithArrayInput([BindRequired, FromBody] IEnumerable<User> body)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> CreateUsersWithListInput([BindRequired, FromBody] IEnumerable<User> body)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> DeleteUser([BindRequired] string username)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<User>> GetUserByName([BindRequired] string username)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<string>> LoginUser([BindRequired, FromQuery] string username, [BindRequired, FromQuery] string password)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> LogoutUser()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> UpdateUser([BindRequired] string username, [BindRequired, FromBody] User body)
        {
            throw new NotImplementedException();
        }
    }
}
