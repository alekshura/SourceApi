using Microsoft.CodeAnalysis.Diagnostics;

namespace Compentio.SourceApi.Context
{
    /// <summary>
    /// Configuration for Open API generators
    /// </summary>
    interface IConfigurationContext
    {
        /// <summary>
        /// Controllers and DTO's namespace
        /// </summary>
        public string Namespace { get; }
        /// <summary>
        /// Indicates when to generate only DTO's
        /// </summary>
        public bool GenerateOnlyContracts { get; }
    }

    /// <inheritdoc />
    abstract class ConfigurationContext : IConfigurationContext
    {
        protected readonly AnalyzerConfigOptions _options;
        protected const string BuldProperty = "build_property";
        protected const string BuldMetadata = "build_metadata";
        protected const string Name = "SourceApi";
        protected const string NamespaceParameterName = "GeneratorNamespace";
        protected const string GenerateOnlyContractsParameterName = "GenerateOnlyContracts";

        public ConfigurationContext(AnalyzerConfigOptions options)
        {
            _options = options;
        }

        /// <inheritdoc />
        public virtual string Namespace { get; }

        /// <inheritdoc />
        public virtual bool GenerateOnlyContracts { get; }

        protected bool GetBoolParameter(string key)
        {
            if (_options.TryGetValue(key, out var stringValue))
            {
                bool.TryParse(stringValue, out var boolValue);
                return boolValue;
            }

            return false;
        }

        protected string GetStringParameter(string key)
        {
            if (_options.TryGetValue(key, out var stringValue))
            {
                return stringValue;
            }

            return string.Empty;
        }
    }

    /// <inheritdoc />
    class GlobalConfigurationContext : ConfigurationContext
    {
        public GlobalConfigurationContext(AnalyzerConfigOptions options) : base(options)
        {
        }

        /// <inheritdoc />
        public override string Namespace => GetStringParameter($"{BuldProperty}.{Name}_{NamespaceParameterName}");
        
        /// <inheritdoc />
        public override bool GenerateOnlyContracts => GetBoolParameter($"{BuldProperty}.{Name}_{GenerateOnlyContractsParameterName}");
    }

    class FileConfigurationContext : ConfigurationContext
    {
        private readonly IConfigurationContext _globalConfiguration;

        public FileConfigurationContext(AnalyzerConfigOptions options, IConfigurationContext globalConfiguration) 
            : base(options)
        {
            _globalConfiguration = globalConfiguration;
        }

        /// <inheritdoc />
        public override string Namespace
        {
            get
            {
                var namespaceName = GetStringParameter($"{BuldMetadata}.AdditionalFiles.{Name}_{NamespaceParameterName}");

                if (string.IsNullOrWhiteSpace(namespaceName))
                {
                    return _globalConfiguration.Namespace;
                }

                return namespaceName;
            }
        }

        /// <inheritdoc />
        public override bool GenerateOnlyContracts
        {
            get
            {
                var onlyContracts = GetBoolParameter($"{BuldMetadata}.AdditionalFiles.{Name}_{GenerateOnlyContractsParameterName}");
                
                if (!onlyContracts)
                {
                    return _globalConfiguration.GenerateOnlyContracts;
                }
                
                return onlyContracts;
            }
        }
    }
}
