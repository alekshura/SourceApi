using Compentio.SourceApi.Context;
using Compentio.SourceApi.Generators;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Compentio.SourceApi
{
    /// <summary>
    /// Main controllers source generator
    /// </summary>
    [Generator]
    public class Generator : ISourceGenerator
    {
        /// <inheritdoc />
        public void Execute(GeneratorExecutionContext context)
        {
            Trace.WriteLine($"Start generating your base controllers.");

            var openApiContext = OpenApiContext.CreateFromExecutionContext(context);

            foreach (var openApiFileContext in openApiContext.Context)
            {
                var generatorStrategy = GeneratorStrategyFactory.GetStrategy(openApiFileContext);
                var result = generatorStrategy.GenerateCode(openApiFileContext).Result;

                if (result.IsSuccess)
                {
                    context.AddSource(openApiFileContext.FileName, result.GeneratedCode);
                }
                else
                {
                    Trace.TraceError(result.Diagnostic.Message);
                    context.ReportDiagnostic(Diagnostic.Create(result.Diagnostic.DiagnosticDescriptor, null, result.Diagnostic.Message));
                }                
            }

            Trace.WriteLine($"Code generating ended succesfully.");
        }

        /// <inheritdoc />
        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
            Trace.WriteLine($"'{typeof(Generator).FullName}' initalized.");
        }
    }
}
