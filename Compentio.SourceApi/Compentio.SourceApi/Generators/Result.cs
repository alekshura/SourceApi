using Compentio.SourceApi.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;


namespace Compentio.SourceApi.Generators
{
    /// <summary>
    /// Result of API code generation
    /// </summary>
    interface IResult
    {
        /// <summary>
        /// Formatted controller and DTO's code
        /// </summary>
        string GeneratedCode { get; }
        /// <summary>
        /// Success flag of code generation process
        /// </summary>
        bool IsSuccess { get; }
        /// <summary>
        /// Warning or error that appeared during code generation process
        /// </summary>
        DiagnosticInfo Diagnostic { get; }
    }

    /// <inheritdoc />
    internal class Result : IResult
    {
        private readonly string _code = string.Empty;
        private readonly DiagnosticInfo _diagnostics;

        private Result(string code)
        {
            _code = code;
        }
        private Result(Exception exception)
        {
            _diagnostics = new DiagnosticInfo
            {
                DiagnosticDescriptor = SourceApiDescriptor.UnexpectedError,
                Exception = exception
            };
        }
        internal static IResult Ok(string code)
        {
            return new Result(code);
        }
        internal static IResult Error(Exception exception)
        {
            return new Result(exception);
        }

        /// <inheritdoc />
        public string GeneratedCode => FormatCode(_code);

        /// <inheritdoc />
        public DiagnosticInfo Diagnostic => _diagnostics;

        /// <inheritdoc />
        public bool IsSuccess => _diagnostics is null;

        private string FormatCode(string code)
        {
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot().NormalizeWhitespace();
            return root.ToFullString();
        }
    }
}
