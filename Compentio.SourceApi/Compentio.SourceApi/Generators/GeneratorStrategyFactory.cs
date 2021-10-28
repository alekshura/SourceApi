using Compentio.SourceApi.Context;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace Compentio.SourceApi.Generators
{
    /// <summary>
    /// Code generator strategy factory that returns proper processod that depends on mapper definition type: abstract class or interface
    /// </summary>
    internal static class GeneratorStrategyFactory
    {
        private readonly static Dictionary<OpenApiFileFormat, IGeneratorStrategy> _strategies = new()
        {
            { OpenApiFileFormat.Yaml, new JsonGeneratorStrategy()},
            { OpenApiFileFormat.Json, new YamlGeneratorStrategy() }
        };

        /// <summary>
        /// returns appropriate generator strategy based on mapper type kind <see cref="TypeKind"/>
        /// </summary>
        /// <param name="mapperMetadata"></param>
        /// <returns></returns>
        internal static IGeneratorStrategy GetStrategy(IOpenApiFileContext context)
        {
            if (!_strategies.ContainsKey(context.FileFormat))
            {
                return new JsonGeneratorStrategy();
            }

            return _strategies[context.FileFormat];
        }
    }
}
