using System;
using System.IO;
using System.Linq;

namespace Compentio.SourceApi.Context
{
    /// <summary>
    /// Contains one file OpenApi information
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
        /// Namespace of generated class. It is concatenation of main application namespaca and directories of configuration files.
        /// </summary>
        string Namespace { get; }
        /// <summary>
        /// File format. For Open API definition used yaml or json format
        /// </summary>
        OpenApiFileFormat FileFormat { get; }
    }

    /// <inheritdoc />
    class OpenApiFileContext : IOpenApiFileContext
    {
        private readonly string _filePath;
        private readonly string _assemblyName;

        public OpenApiFileContext(string filePath, string assemblyName)
        {
            _filePath = filePath;
            _assemblyName = assemblyName;
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
    }
}
