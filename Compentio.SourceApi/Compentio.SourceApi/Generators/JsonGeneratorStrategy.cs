using NSwag;
using System.Threading.Tasks;

namespace Compentio.SourceApi.Generators
{
    /// <inheritdoc />
    class JsonGeneratorStrategy : GeneratorStrategy
    {
        /// <summary>
        /// Retreives Open API document for json schema definition
        /// </summary>
        /// <param name="filePath">Path to the json file with Open API document</param>
        /// <returns><see cref="OpenApiDocument"/></returns>
        protected override async Task<OpenApiDocument> GetOpenApiDocumentAsync(string filePath)
        {
            return await OpenApiDocument.FromFileAsync(filePath);
        }
    }
}
