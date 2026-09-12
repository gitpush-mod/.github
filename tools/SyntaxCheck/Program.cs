// Space Engineers mod script syntax checker.
//
// SE compiles a mod's Data/Scripts into a SINGLE assembly at load time, so one syntax
// error fails the entire mod, not just the offending file. This catches that class of
// break in CI, where Keen's proprietary Bin64 assemblies are not available.
//
// Deliberately syntax-only: CSharpSyntaxTree.ParseText resolves no references, so it
// reports parser/lexer diagnostics and nothing else. No CS0246 noise to filter.
// Semantic errors (an undeclared field, say) need the SE assemblies and are covered by
// the local full-build script instead.
//
// Parsed as C# 6 on purpose: that is what SE's in-game compiler accepts, so newer
// syntax is reported here rather than failing for players at world load.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

internal static class Program
{
    private static int Main(string[] args)
    {
        var root = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
        var opts = new CSharpParseOptions(LanguageVersion.CSharp6);

        var files = Directory
            .EnumerateFiles(root, "*.cs", SearchOption.AllDirectories)
            .Where(f => !IsIgnored(f, root))
            .OrderBy(f => f, StringComparer.Ordinal)
            .ToList();

        if (files.Count == 0)
        {
            Console.WriteLine("No .cs files found under " + root + " - nothing to check.");
            return 0;
        }

        var failures = new List<Diagnostic>();
        foreach (var file in files)
        {
            var tree = CSharpSyntaxTree.ParseText(File.ReadAllText(file), opts, file);
            failures.AddRange(tree.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error));
        }

        Console.WriteLine("Parsed " + files.Count + " file(s) as C# 6.");

        if (failures.Count == 0)
        {
            Console.WriteLine("No syntax errors.");
            return 0;
        }

        foreach (var d in failures.Take(50))
        {
            var pos = d.Location.GetLineSpan();
            var rel = Rel(pos.Path, root);
            var line = pos.StartLinePosition.Line + 1;
            var col = pos.StartLinePosition.Character + 1;
            Console.WriteLine("::error file=" + rel + ",line=" + line + ",col=" + col
                              + "::" + d.Id + ": " + d.GetMessage());
        }

        if (failures.Count > 50)
            Console.WriteLine("... and " + (failures.Count - 50) + " more.");

        Console.WriteLine("FAILED: " + failures.Count + " syntax error(s).");
        return 1;
    }

    // (char)92 rather than a backslash literal: this file has been mangled by a heredoc
    // twice, and an escaped backslash is exactly the corruption this tool exists to catch.
    private const char Backslash = (char)92;

    private static bool IsIgnored(string path, string root)
    {
        var p = path.Replace(Backslash, '/');
        return p.Contains("/obj/") || p.Contains("/bin/") || p.Contains("/.git/")
               || p.Contains("/.vs/") || p.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase);
    }

    private static string Rel(string path, string root)
    {
        var p = path.Replace(Backslash, '/');
        var r = root.Replace(Backslash, '/').TrimEnd('/') + "/";
        return p.StartsWith(r, StringComparison.OrdinalIgnoreCase) ? p.Substring(r.Length) : p;
    }
}
