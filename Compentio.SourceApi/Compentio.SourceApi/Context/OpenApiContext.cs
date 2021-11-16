using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace Compentio.SourceApi.Context
{
     /// <summary>
     /// Contains for overall OpenApi files defined in application
     /// </summary>
    interface IOpenApiContext
    {
        /// <summary>
        /// Collection of Open API definitions files
        /// </summary>
        IEnumerable<IOpenApiFileContext> Context { get; }

        /// <summary>
        /// Global configuration for all Open Api files in context
        /// </summary>
        IConfigurationContext Configuration { get; }
    }

    /// <inheritdoc />
    class OpenApiContext : IOpenApiContext
    {
        private readonly GeneratorExecutionContext _generatorExecutionContext;
        private readonly IList<IOpenApiFileContext> _openApiFilesContext;
        private readonly IConfigurationContext _configurationContext;

        public static IOpenApiContext CreateFromExecutionContext(GeneratorExecutionContext generatorExecutionContext) => new OpenApiContext(generatorExecutionContext);

        private OpenApiContext(GeneratorExecutionContext generatorExecutionContext)
        {
            _generatorExecutionContext = generatorExecutionContext;
            _openApiFilesContext = new List<IOpenApiFileContext>();
            _configurationContext = new GlobalConfigurationContext(_generatorExecutionContext.AnalyzerConfigOptions.GlobalOptions);
            LoadOpenApiFiles(_openApiFilesContext);
        }

        /// <inheritdoc />
        public IEnumerable<IOpenApiFileContext> Context => _openApiFilesContext;

        /// <inheritdoc />
        public IConfigurationContext Configuration => _configurationContext;

        private void LoadOpenApiFiles(IList<IOpenApiFileContext> openApiFilesContext)
        {           
            foreach (var file in _generatorExecutionContext.AdditionalFiles.Where(file => IsOpenApiSchemeExtension(file.Path)))
            {
                var content = file.GetText()?.ToString();
                if (!string.IsNullOrEmpty(content))
                {
                    var fileContext = new OpenApiFileContext(file.Path, 
                        _generatorExecutionContext.Compilation?.AssemblyName, 
                        _generatorExecutionContext.AnalyzerConfigOptions.GetOptions(file),
                        _configurationContext);

                    openApiFilesContext.Add(fileContext);                    
                }
            }
        }

        private bool IsOpenApiSchemeExtension(string filePath)
        {
            return filePath.EndsWith(".json", System.StringComparison.InvariantCultureIgnoreCase) ||
                filePath.EndsWith(".yaml", System.StringComparison.InvariantCultureIgnoreCase) ||
                filePath.EndsWith(".yml", System.StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
