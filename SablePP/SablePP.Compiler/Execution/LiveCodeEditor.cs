using System;
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
        public LiveCodeEditor()
        {
            InitializeComponent();

            Font consolas = new Font("Consolas", 10);
            if (consolas.Name == "Consolas")
                codeTextBox1.Font = consolas;
            else
                consolas.Dispose();
        }
    }
}
