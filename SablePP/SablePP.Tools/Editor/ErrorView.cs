using SablePP.Tools.Error;
using System;
using System.Windows.Forms;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// A <see cref="ListView"/> capable of displaying error messages.
    /// </summary>
    public class ErrorView : ListView
    {
        private ColumnHeader iconHeader, descriptionHeader, lineHeader, columnHeader;

        public ErrorView()
            : base()
        {
            this.FullRowSelect = true;
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

        /// <summary>
        /// Adds a <see cref="CompilerError"/> error to the <see cref="ErrorView"/>.
        /// </summary>
        /// <param name="error">The error that should be added to the <see cref="ErrorView"/>.</param>
        public void AddError(CompilerError error)
        {
        }
        /// <summary>
        /// Clears all errors from the <see cref="ErrorView"/>.
        /// </summary>
        public void ClearErrors()
        {
            this.Items.Clear();
        }
    }
}
