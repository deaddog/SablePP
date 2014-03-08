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

        private ImageList imageList;

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

            imageList = new ImageList();
            imageList.Images.Add("error", EditorResources.error);
            imageList.Images.Add("warning", EditorResources.warning);
            imageList.Images.Add("message", EditorResources.info);

            this.SmallImageList = imageList;
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

        private void addError(object sender, ErrorEventArgs e)
        {
            CompilerError error = e.Error;

            ListViewItem item = new ListViewItem(
                new string[] {
                    "",
                    error.ErrorMessage,
                    error.Start.Line.ToString(),
                    error.Start.Character.ToString()
                },
                getImageKey(error.ErrorType)
            );
            this.Items.Add(item);
        }
        private void clearErrors(object sender, EventArgs e)
        {
            this.Items.Clear();
        }

        private string getImageKey(ErrorType type)
        {
            switch (type)
            {
                case ErrorType.Error: return "error";
                case ErrorType.Warning: return "warning";
                case ErrorType.Message: return "message";
                default: return null;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CodeTextBox"/> associated where errors should be located.
        /// </summary>
        [DefaultValue(null)]
        public CodeTextBox CodeTextBox
        {
            get { return this.codeTextBox; }
            set
            {
                if (!DesignMode)
                {
                    if (this.codeTextBox != null)
                    {
                        this.codeTextBox.ErrorAdded -= addError;
                        this.codeTextBox.ErrorsCleared -= clearErrors;
                    }
                    if (value != null)
                    {
                        value.ErrorAdded += addError;
                        value.ErrorsCleared += clearErrors;
                    }
                }
                this.codeTextBox = value;
            }
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
                    line > 0 && column > 0 && codeTextBox != null)
                {
                    var place = new FastColoredTextBoxNS.Place(column, line);

                    if (codeTextBox.Range.Contains(place))
                        codeTextBox.Selection.Start = place;
                    else
                        codeTextBox.GoEnd();

                    codeTextBox.DoSelectionVisible();
                }
            }

            base.OnSelectedIndexChanged(e);
        }
#pragma warning restore
    }
}
