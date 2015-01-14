﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.Analyzers.MaintainabilityRules;
using StyleCop.Analyzers.NamingRules;
using TestHelper;

namespace StyleCop.Analyzers.Test.NamingRules
{
    [TestClass]
    public class SA1311UnitTests : CodeFixVerifier
    {
        private const string DiagnosticId = SA1311StaticReadonlyFieldsMustBeginWithUpperCaseLetter.DiagnosticId;
        protected static readonly DiagnosticResult[] EmptyDiagnosticResults = { };

        [TestMethod]
        public async Task TestEmptySource()
        {
            var testCode = @"";
            await VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestStaticReadonlyFieldStartingWithLoweCase()
        {
            var testCode = @"public class Foo
{
    public static readonly string bar = ""baz"";
}";

            var expected = new[]
            {
                new DiagnosticResult
                {
                    Id = DiagnosticId,
                    Message = "Static readonly fields must begin with upper-case letter.",
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                        new[]
                        {
                            new DiagnosticResultLocation("Test0.cs", 3, 35)
                        }
                }
            };

            await VerifyCSharpDiagnosticAsync(testCode, expected, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestStaticReadonlyFieldStartingWithUpperCase()
        {
            var testCode = @"public class Foo
{
    public static readonly string Bar = ""baz"";
}";

            await VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestReadonlyFieldStartingWithLoweCase()
        {
            var testCode = @"public class Foo
{
    public readonly string bar = = ""baz"";
}";

            await VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        [TestMethod]
        public async Task TestStaticFieldStartingWithLoweCase()
        {
            var testCode = @"public class Foo
{
    public static string bar = = ""baz"";
}";

            await VerifyCSharpDiagnosticAsync(testCode, EmptyDiagnosticResults, CancellationToken.None);
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new SA1311StaticReadonlyFieldsMustBeginWithUpperCaseLetter();
        }
    }
}