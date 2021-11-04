using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compentio.SourceApi.WebExample.Controllers
{
    [ApiController]
    [Route("petstore")]
    public class PetsController : PetsControllerBase
    {
        public override Task<Pet> AddPet([FromBody] NewPet body)
        {
            throw new NotImplementedException();
        }

        public override Task DeletePet(long id)
        {
            throw new NotImplementedException();
        }

        public override Task<ICollection<Pet>> FindPets([FromQuery] IEnumerable<string> tags = null, [FromQuery] int? limit = null)
        {
            throw new NotImplementedException();
        }

        public override Task<Pet> FindPetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
