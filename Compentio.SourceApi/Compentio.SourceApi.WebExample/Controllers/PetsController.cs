using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compentio.SourceApi.WebExample.Controllers
{
    [ApiController]
    [Route("petstore")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PetsController : PetsControllerBase
    {
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public override Task<Pet> AddPet([FromBody] NewPet body)
        {
            throw new NotImplementedException();
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public override Task DeletePet(long id)
        {
            throw new NotImplementedException();
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public override Task<ICollection<Pet>> FindPets([FromQuery] IEnumerable<string> tags = null, [FromQuery] int? limit = null)
        {
            throw new NotImplementedException();
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public override Task<Pet> FindPetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
