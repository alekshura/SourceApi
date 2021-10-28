using NSwag;
using System.Threading.Tasks;

namespace Compentio.SourceApi.Generators
{
    class JsonGeneratorStrategy : GeneratorStrategy
    {
        protected override async Task<OpenApiDocument> GetOpenApiDocumentAsync(string filePath)
        {
            return await OpenApiDocument.FromFileAsync(filePath);
        }
    }
}
