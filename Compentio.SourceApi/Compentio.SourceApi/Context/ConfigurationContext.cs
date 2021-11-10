using Microsoft.CodeAnalysis.Diagnostics;

namespace Compentio.SourceApi.Context
{

    interface IConfigurationContext
    {
        public string Namespace { get; }
        public bool GenerateOnlyContracts { get; }
    }

    class GlobalConfigurationContext : IConfigurationContext
    {
        private readonly AnalyzerConfigOptions _options;

        public GlobalConfigurationContext(AnalyzerConfigOptions options)
        {
            _options = options;
        }
        public string Namespace
        { 
            get
            {
                _options.TryGetValue("build_property.SourceApi_GeneratorNamespace", out var namespaceName);
                return namespaceName;
            }
        }

        public bool GenerateOnlyContracts
        {
            get
            {
                _options.TryGetValue("build_property.SourceApi_GenerateOnlyContracts", out var onlyContractsString);
                bool.TryParse(onlyContractsString, out var onlyContracts);                
                return onlyContracts;
            }
        }
    }

    class FileConfigurationContext : IConfigurationContext
    {
        private readonly AnalyzerConfigOptions _options;

        public FileConfigurationContext(AnalyzerConfigOptions options)
        {
            _options = options;
        }
        public string Namespace
        {
            get
            {
                _options.TryGetValue("build_metadata.AdditionalFiles.SourceApi_GeneratorNamespace", out var namespaceName);
                return namespaceName;
            }
        }

        public bool GenerateOnlyContracts
        {
            get
            {
                _options.TryGetValue("build_metadata.AdditionalFiles.SourceApi_GenerateOnlyContracts", out var onlyContractsString);
                bool.TryParse(onlyContractsString, out var onlyContracts);
                return onlyContracts;
            }
        }
    }
}
