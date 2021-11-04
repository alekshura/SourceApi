using Compentio.SourceApi.Context;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using System.Threading.Tasks;

namespace Compentio.SourceApi.Generators
{
    interface IGeneratorStrategy
    {
        /// <summary>
        /// Generates base controllers with routes and Dto's
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
                    Namespace = context.Namespace, 
                    //SchemaType = NJsonSchema.SchemaType.OpenApi3
                },
                ControllerStyle = NSwag.CodeGeneration.CSharp.Models.CSharpControllerStyle.Abstract,
                ControllerTarget = NSwag.CodeGeneration.CSharp.Models.CSharpControllerTarget.AspNetCore,
                GenerateOptionalParameters = true,
                RouteNamingStrategy = NSwag.CodeGeneration.CSharp.Models.CSharpControllerRouteNamingStrategy.None,
                

            };

            var openApiDocument = await GetOpenApiDocumentAsync(context.FilePath);
            var generator = new CSharpControllerGenerator(openApiDocument, settings);
            var code = generator.GenerateFile();
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot().NormalizeWhitespace();
            return root.ToFullString();
        }

        protected abstract Task<OpenApiDocument> GetOpenApiDocumentAsync(string filePath);
    }
}
