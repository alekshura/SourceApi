using Compentio.SourceApi.Context;
using System.Collections.Generic;

namespace Compentio.SourceApi.Generators
{
    /// <summary>
    /// Code generator strategy factory that returns proper processor for yaml or json schema definitions
    /// </summary>
    internal static class GeneratorStrategyFactory
    {
        private readonly static Dictionary<OpenApiFileFormat, IGeneratorStrategy> _strategies = new()
        {
            { OpenApiFileFormat.Json, new JsonGeneratorStrategy()},
            { OpenApiFileFormat.Yaml, new YamlGeneratorStrategy() }
        };

        /// <summary>
        /// Returns appropriate generator strategy based on open API schema type: json or yaml: <see cref="OpenApiFileFormat"/>
        /// </summary>
        /// <param name="context">Open API file info. File extension used to return appropriate strategy: <see cref="OpenApiFileFormat"/></param>
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
