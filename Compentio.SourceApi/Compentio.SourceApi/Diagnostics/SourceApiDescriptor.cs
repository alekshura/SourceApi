using Microsoft.CodeAnalysis;

namespace Compentio.SourceApi.Diagnostics
{
    /// <summary>
    /// Source API generator diagnostics descriptors
    /// </summary>
    class SourceApiDescriptor
    {
        public static readonly DiagnosticDescriptor UnexpectedError =
         new("SAPI0099", "Unexpected error", "Unexpected error ocured with message: '{0}'", "Design", DiagnosticSeverity.Error, true,
             "Unexpected exception occured during code generation.");
    }
}
