using NSwag;
using System.Threading.Tasks;

namespace Compentio.SourceApi.Generators
{
    /// <inheritdoc />
    class YamlGeneratorStrategy : GeneratorStrategy
    {
        /// <summary>
        /// Retreives Open API document for yaml schema definition
        /// </summary>
        /// <param name="filePath">Path to the yaml file with Open API document</param>
        /// <returns><see cref="OpenApiDocument"/></returns>
        protected override async Task<OpenApiDocument> GetOpenApiDocumentAsync(string filePath)
        {
            return await OpenApiYamlDocument.FromFileAsync(filePath);
        }
    }
}
