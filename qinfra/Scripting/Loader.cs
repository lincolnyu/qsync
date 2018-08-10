using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace QInfra
{
    /*
     * ref: https://stackoverflow.com/questions/37526165/compiling-and-running-code-at-runtime-in-net-core-1-0
     */
    public class Loader
    {
        private string Wrap(string script)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("public class Program {");
            sb.AppendLine("public static void Main() {");
            sb.AppendLine(script);
            sb.AppendLine("}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public void Load(string script)
        {
            // Add the following referneces
            // System
            // System.Collections.Generic
            // System.Linq
            // System.Text
            // System.IO

            var refs = AppDomain.CurrentDomain.GetAssemblies().Select(x=>x.Location).Distinct()
                .Select(x=>MetadataReference.CreateFromFile(x));

            var compilation = CSharpCompilation.Create("output")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(refs)
                .AddSyntaxTrees(CSharpSyntaxTree.ParseText(Wrap(script)));
            
            using (var stream = new MemoryStream())
            {
                var r = compilation.Emit(stream);
                if (r.Success)
                {
                    Console.WriteLine("Compilation succeeded");
                    stream.Position = 0;
                    var t = AssemblyLoadContext.Default.LoadFromStream(stream);
                    t.GetType("Program").GetMethod("Main").Invoke(null, null);
                }
                else
                {
                    Console.WriteLine($"Compilation failed: ");
                    foreach (var d in r.Diagnostics)
                    {
                        Console.WriteLine(d);
                    }

                }
            }
        }
    }
}
