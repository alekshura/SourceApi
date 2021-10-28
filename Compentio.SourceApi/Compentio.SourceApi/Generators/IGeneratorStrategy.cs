using Compentio.SourceApi.Context;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using System.Threading.Tasks;

namespace Compentio.SourceApi.Generators
{
    interface IGeneratorStrategy
    {
        /// <summary>
        /// Generates controllers and POCO code
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Generated code</returns>
        Task<string> GenerateCode(IOpenApiFileContext context);
    }

    abstract class GeneratorStrategy : IGeneratorStrategy
    {
        public async Task<string> GenerateCode(IOpenApiFileContext context)
        {
            var settings = new CSharpControllerGeneratorSettings
            {
                ClassName = context.ClassName,
                CSharpGeneratorSettings =
                {
                    Namespace = context.Namespace
                },
                ControllerStyle = NSwag.CodeGeneration.CSharp.Models.CSharpControllerStyle.Abstract,
                GenerateClientClasses = true,
                GenerateDtoTypes = true,
                GenerateOptionalParameters = true,
                RouteNamingStrategy = NSwag.CodeGeneration.CSharp.Models.CSharpControllerRouteNamingStrategy.None,

            };

            var openApiDocument = await GetOpenApiDocumentAsync(context.FilePath);
            var generator = new CSharpControllerGenerator(openApiDocument, settings);
            return generator.GenerateFile();
        }

        protected abstract Task<OpenApiDocument> GetOpenApiDocumentAsync(string filePath);
    }
}
