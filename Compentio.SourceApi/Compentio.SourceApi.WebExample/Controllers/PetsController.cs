using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public override Task<IActionResult> AddPet([BindRequired, FromBody] Pet body)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> DeletePet([BindRequired] long petId, [FromHeader] string api_key = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<ICollection<Pet>>> FindPetsByStatus([BindRequired, FromQuery] IEnumerable<Anonymous> status)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<ICollection<Pet>>> FindPetsByTags([BindRequired, FromQuery] IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<Pet>> GetPetById([BindRequired] long petId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> UpdatePet([BindRequired, FromBody] Pet body)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IActionResult> UpdatePetWithForm([BindRequired] long petId, [FromBody] Body body = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ActionResult<ApiResponse>> UploadFile([BindRequired] long petId, string additionalMetadata = null, FileParameter file = null)
        {
            throw new NotImplementedException();
        }
    }
}
