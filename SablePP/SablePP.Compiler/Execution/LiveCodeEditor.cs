using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public partial class LiveCodeEditor : Form
    {
        private const int POSITION_DISTANCE = 5;
        private const int SNAPPING_MARGIN = 10;
        private bool snapped = true;

        CSharpCodeProvider provider;
        CompilerParameters options;

        private Form parentForm;
        public Form ManagingForm
        {
            get { return parentForm; }
            set
            {
                if (!DesignMode)
                {
                    if (parentForm != null)
                    {
                        parentForm.LocationChanged -= updateBounds;
                        parentForm.SizeChanged -= updateBounds;
                    }
                    if (value != null)
                    {
                        value.LocationChanged += updateBounds;
                        value.SizeChanged += updateBounds;
                    }
                }

                this.parentForm = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (parentForm != null)
            {
                snapped = true;
                updateBounds(parentForm, EventArgs.Empty);
            }
        }

        void updateBounds(object sender, EventArgs e)
        {
            Form form = sender as Form;
            if (snapped)
            {
                doingStuff = true;

                this.DesktopBounds = new Rectangle(
                    form.DesktopLocation.X + POSITION_DISTANCE + form.Width,
                    form.DesktopLocation.Y,
                    this.Width,
                    form.Height
                    );

                doingStuff = false;
            }
        }

        private bool doingStuff = false;
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (parentForm == null)
                return;

            if (!doingStuff)
            {
                doingStuff = true;
                int diffX = this.DesktopLocation.X - (parentForm.DesktopLocation.X + parentForm.Width + POSITION_DISTANCE);
                int diffY = this.DesktopLocation.Y - parentForm.DesktopLocation.Y;
                if (diffX <= SNAPPING_MARGIN && diffX >= -SNAPPING_MARGIN && diffY <= SNAPPING_MARGIN && diffY >= -SNAPPING_MARGIN)
                {
                    this.DesktopLocation = new Point(
                        parentForm.DesktopLocation.X + parentForm.Width + POSITION_DISTANCE,
                        parentForm.DesktopLocation.Y);
                    snapped = true;
                }
                else
                    snapped = false;
                doingStuff = false;
            }
        }

        public LiveCodeEditor()
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

        private void codeTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.Hide();
            }
        }
        public void LoadCompiler(string grammarNamespace)
        {
        }
    }
}
