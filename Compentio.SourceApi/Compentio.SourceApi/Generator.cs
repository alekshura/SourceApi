using Compentio.SourceApi.Context;
using Compentio.SourceApi.Generators;
using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics;

namespace Compentio.SourceApi
{
    /// <summary>
    /// Main controllers source generator
    /// </summary>
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Trace.WriteLine($"Start code generation.");

            var openApiContext = OpenApiContext.CreateFromExecutionContext(context);

            foreach (var openApiFileContext in openApiContext.Context)
            {
                var generatorStrategy = GeneratorStrategyFactory.GetStrategy(openApiFileContext);
                var code = generatorStrategy.GenerateCode(openApiFileContext).Result;
                context.AddSource(openApiFileContext.FileName, code);
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
//#if DEBUG
//            if (!Debugger.IsAttached)
//            {
//                Debugger.Launch();
//            }
//#endif
            Trace.WriteLine($"'{typeof(Generator).FullName}' initalized.");
        }
    }
}
