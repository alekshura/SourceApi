using Compentio.SourceApi.Context;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using System;
using System.Threading.Tasks;

namespace Compentio.SourceApi.Generators
{
    /// <summary>
    /// Open API code generation strategy. 
    /// Json or Yaml Opean API schema is used for code generation. 
    /// </summary>
    interface IGeneratorStrategy
    {
        /// <summary>
        /// Generates base controller with routes and DTO's and documentation
        /// </summary>
        /// <param name="context">Open API file</param>
        /// <returns>Generated and formatted code with execution result. See: <see cref="IResult"/></returns>
        Task<IResult> GenerateCode(IOpenApiFileContext context);
    }

    /// <inheritdoc />
    abstract class GeneratorStrategy : IGeneratorStrategy
    {
        /// <inheritdoc />
        public async Task<IResult> GenerateCode(IOpenApiFileContext context)
        {
            var settings = new CSharpControllerGeneratorSettings
            {
                ClassName = context.ClassName,
                CSharpGeneratorSettings =
                {
                    Namespace = context.Namespace,
                    SchemaType = NJsonSchema.SchemaType.OpenApi3,
                    GenerateDefaultValues = true,
                    GenerateDataAnnotations = false
                },
                ControllerStyle = NSwag.CodeGeneration.CSharp.Models.CSharpControllerStyle.Abstract,
                ControllerTarget = NSwag.CodeGeneration.CSharp.Models.CSharpControllerTarget.AspNetCore,
                GenerateOptionalParameters = true,
                GenerateModelValidationAttributes = true,
                RouteNamingStrategy = NSwag.CodeGeneration.CSharp.Models.CSharpControllerRouteNamingStrategy.None, 
                UseActionResultType = true
            };

            try
            {
                var openApiDocument = await GetOpenApiDocumentAsync(context.FilePath);
                var generator = new CSharpControllerGenerator(openApiDocument, settings);
                var code = generator.GenerateFile();
                return Result.Ok(code);
            }
            catch (Exception e)
            {
                return Result.Error(e);                
            }                         
        }

        /// <summary>
        /// Retreives Open API document for json or yaml schema definition
        /// </summary>
        /// <param name="filePath">Path to the file with Open API document</param>
        /// <returns></returns>
        protected abstract Task<OpenApiDocument> GetOpenApiDocumentAsync(string filePath);
    }
}
