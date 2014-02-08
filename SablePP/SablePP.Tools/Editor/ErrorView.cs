using SablePP.Tools.Error;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// A <see cref="ListView"/> capable of displaying error messages.
    /// </summary>
    public class ErrorView : ListView
    {
        private ColumnHeader iconHeader, descriptionHeader, lineHeader, columnHeader;
        private CodeTextBox codeTextBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorView"/> control.
        /// </summary>
        public ErrorView()
            : base()
        {
            this.FullRowSelect = true;
            this.MultiSelect = false;
            this.View = System.Windows.Forms.View.Details;

            iconHeader = new ColumnHeader()
            {
                Text = "",
                Width = 24
            };
            descriptionHeader = new ColumnHeader()
            {
                Text = "Description"
            };
            lineHeader = new ColumnHeader()
            {
                Text = "Line"
            };
            columnHeader = new ColumnHeader()
            {
                Text = "Column"
            };

            this.Columns.Add(iconHeader);
            this.Columns.Add(descriptionHeader);
            this.Columns.Add(lineHeader);
            this.Columns.Add(columnHeader);
        }
        private bool resizing = false;

#pragma warning disable 1591
        protected override void OnSizeChanged(EventArgs e)
        {
            if (!resizing)
            {
                resizing = true;
                int width = this.ClientRectangle.Width;

                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (this.Columns[i] != descriptionHeader)
                        width -= this.Columns[i].Width;
                }
                descriptionHeader.Width = width;
            }

            resizing = false;

            base.OnSizeChanged(e);
        }
#pragma warning restore

        /// <summary>
        /// Adds a <see cref="CompilerError"/> error to the <see cref="ErrorView"/>.
        /// </summary>
        /// <param name="error">The error that should be added to the <see cref="ErrorView"/>.</param>
        public void AddError(CompilerError error)
        {
            ListViewItem item = new ListViewItem(new string[] {
                "",
                error.ErrorMessage,
                error.Start.LineNumber.ToString(),
                error.Start.LinePosition.ToString()
            });
            this.Items.Add(item);
        }
        /// <summary>
        /// Clears all errors from the <see cref="ErrorView"/>.
        /// </summary>
        public void ClearErrors()
        {
            this.Items.Clear();
        }

        [DefaultValue(null)]
        /// <summary>
        /// Gets or sets the <see cref="CodeTextBox"/> associated where errors should be located.
        /// </summary>
        public CodeTextBox CodeTextBox
        {
            get { return this.codeTextBox; }
            set { this.codeTextBox = value; }
        }

#pragma warning disable 1591
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            var selected = this.SelectedItems.Count == 0 ? null : this.SelectedItems[0];

            if (selected != null)
            {
                int line, column;
                if (int.TryParse(selected.SubItems[lineHeader.Index].Text, out line) &&
                    int.TryParse(selected.SubItems[columnHeader.Index].Text, out column) &&
                    line > 0 && column > 0 && codeTextBox!=null)
                {
                    codeTextBox.Selection.Start = new FastColoredTextBoxNS.Place(column, line);
                    codeTextBox.DoSelectionVisible();
                }
            }

            base.OnSelectedIndexChanged(e);
        }
#pragma warning restore
    }
}
