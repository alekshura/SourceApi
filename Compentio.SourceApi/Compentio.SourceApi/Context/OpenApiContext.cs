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
    }

    /// <inheritdoc />
    class OpenApiContext : IOpenApiContext
    {
        private readonly GeneratorExecutionContext _generatorExecutionContext;
        private readonly IList<IOpenApiFileContext> _configFilesContext;       

        public static IOpenApiContext CreateFromExecutionContext(GeneratorExecutionContext generatorExecutionContext) => new OpenApiContext(generatorExecutionContext);

        private OpenApiContext(GeneratorExecutionContext generatorExecutionContext)
        {
            _generatorExecutionContext = generatorExecutionContext;
            _configFilesContext = new List<IOpenApiFileContext>();
            LoadOpenApiFiles(_configFilesContext);
        }

        /// <inheritdoc />
        public IEnumerable<IOpenApiFileContext> Context => _configFilesContext;

        private void LoadOpenApiFiles(IList<IOpenApiFileContext> openApiFilesContext)
        {
            foreach (var configFile in _generatorExecutionContext.AdditionalFiles.Where(file => file.Path.EndsWith(".json") || file.Path.EndsWith(".yaml")))
            {
                var content = configFile.GetText()?.ToString();
                if (!string.IsNullOrEmpty(content))
                {
                    var fileContext = new OpenApiFileContext(configFile.Path, _generatorExecutionContext.Compilation?.AssemblyName);
                    openApiFilesContext.Add(fileContext);                    
                }
            }
        }
    }
}
