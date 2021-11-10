using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.IO;
using System.Linq;

namespace Compentio.SourceApi.Context
{
    /// <summary>
    /// Contains one file Open API information
    /// </summary>
    interface IOpenApiFileContext
    {
        string FilePath { get; }
        /// <summary>
        /// Filename of generated POCO file. It is always has <code>*.cs</code> extension.
        /// </summary>
        string FileName { get; }
        /// <summary>
        /// Generated class name
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// Namespace of generated class. If configuration for in *.cproj file is defined it is used otherwise the 
        /// concatenation of main application namespace and directories of open api files locations.
        /// </summary>
        string Namespace { get; }
        /// <summary>
        /// File format. For Open API definition used yaml or json format
        /// </summary>
        OpenApiFileFormat FileFormat { get; }
        /// <summary>
        /// Configuration for single open API file gnerator processing
        /// </summary>
        IConfigurationContext Configuration { get; }
    }

    /// <inheritdoc />
    class OpenApiFileContext : IOpenApiFileContext
    {
        private readonly string _filePath;
        private readonly string _assemblyName;
        private readonly AnalyzerConfigOptions _options;
        private readonly IConfigurationContext _globalConfiguration;

        public OpenApiFileContext(string filePath, string assemblyName, AnalyzerConfigOptions options, IConfigurationContext globalConfiguration)
        {
            _filePath = filePath;
            _assemblyName = assemblyName;
            _options = options;
            _globalConfiguration = globalConfiguration;
        }

        /// <inheritdoc />
        public string FilePath => _filePath;

        /// <inheritdoc />
        public string ClassName => Path.GetFileNameWithoutExtension(_filePath);

        /// <inheritdoc />
        public string FileName => $"{ClassName}.cs";

        /// <inheritdoc />
        public string Namespace
        {
            get
            {
                if (!string.IsNullOrEmpty(Configuration.Namespace))
                {
                    return Configuration.Namespace;
                }

                var assemlyRootDirectory = _filePath.Split(new string[] { _assemblyName }, StringSplitOptions.RemoveEmptyEntries)[1];
                var namespaceName = string.Empty;
                foreach (var item in assemlyRootDirectory.Split(Path.DirectorySeparatorChar).Where(item => !string.IsNullOrWhiteSpace(item)))
                {
                    if (item != Path.GetFileName(_filePath))
                        namespaceName += $".{item}";
                }

                return $"{_assemblyName}{namespaceName}";
            }
        }

        /// <inheritdoc />
        public OpenApiFileFormat FileFormat
        {
            get 
            {
                var extension = Path.GetExtension(_filePath);
                return extension.Equals(".yaml", StringComparison.OrdinalIgnoreCase) ? OpenApiFileFormat.Yaml : OpenApiFileFormat.Json;
            }
        }

        /// <inheritdoc />
        public IConfigurationContext Configuration => new FileConfigurationContext(_options, _globalConfiguration);
    }
}
