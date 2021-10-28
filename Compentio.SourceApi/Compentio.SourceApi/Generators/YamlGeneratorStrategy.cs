using NSwag;
using System.Threading.Tasks;

namespace Compentio.SourceApi.Generators
{
    class YamlGeneratorStrategy : GeneratorStrategy
    {
        protected override async Task<OpenApiDocument> GetOpenApiDocumentAsync(string filePath)
        {
            return await OpenApiYamlDocument.FromFileAsync(filePath);
        }
    }
}
