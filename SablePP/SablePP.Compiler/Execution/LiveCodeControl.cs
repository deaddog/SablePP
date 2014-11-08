using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public partial class LiveCodeControl : UserControl
    {
        private CSharpCodeProvider provider;
        private CompilerParameters options;

        public LiveCodeControl()
        {
            InitializeComponent();

            Font consolas = new Font("Consolas", 10);
            if (consolas.Name == "Consolas")
                codeTextBox1.Font = consolas;
            else
                consolas.Dispose();

            provider = new CSharpCodeProvider();
            options = new CompilerParameters(new string[] { "System.Drawing.dll", "Microsoft.CSharp.dll", "System.Core.dll" })
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };

            //The two types used below are only used to reference their assembly
            options.ReferencedAssemblies.Add(typeof(SablePP.Tools.CompilationOptions).Assembly.Location);
            options.ReferencedAssemblies.Add(typeof(FastColoredTextBoxNS.TextStyle).Assembly.Location);
        }

        public void LoadCompiler(string location, string grammarNamespace)
        {
            CompilerResults results = provider.CompileAssemblyFromFile(options,
                location + "\\tokens.cs",
                location + "\\prods.cs",
                location + "\\analysis.cs",
                location + "\\parser.cs",
                location + "\\lexer.cs",
                location + "\\CompilerExecuter.cs");

            if (results.Errors.Count == 0)
            {
                var type = results.CompiledAssembly.GetType(grammarNamespace + ".CompilerExecuter");
                var constr = type.GetConstructor(System.Type.EmptyTypes);

                codeTextBox1.Executer = constr.Invoke(null) as SablePP.Tools.ICompilerExecuter;
            }
        }

        public void UnLoadCompiler()
        {
            codeTextBox1.Executer = null;
        }
    }
}
