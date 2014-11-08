using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Provides a set of methods for displaying a timed message using a <see cref="ToolStripStatusLabel"/>.
    /// </summary>
    public class MessageTimer : Component
    {
        private const int DEFAULT_MESSAGE_TIME = 3000;
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTimer"/> class.
        /// </summary>
        public MessageTimer()
            :base()
        {
            this.timer = new Timer();
            this.timer.Interval = DEFAULT_MESSAGE_TIME;
            this.timer.Tick += timer_Tick;
        }

        private int defaultMessageTime = DEFAULT_MESSAGE_TIME;
        /// <summary>
        /// Gets or sets the time (in milliseconds) that a message will be shown.
        /// </summary>
        [DefaultValue(DEFAULT_MESSAGE_TIME)]
        [Description("The time (in milliseconds) that a message will be shown.")]
        public int DefaultMessageTime
        {
            get { return defaultMessageTime; }
            set
            {
                if (value < 100)
                    value = 100;
                defaultMessageTime = value;
            }
        }

        /// <summary>
        /// Shows a message in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="text">The text message to display.</param>
        public void ShowMessage(string text)
        {
            ShowMessage(null, text, defaultMessageTime);
        }
        /// <summary>
        /// Shows a message in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="text">The text message to display.</param>
        /// <param name="duration">The time, in milliseconds, the message is displayed.</param>
        public void ShowMessage(string text, int duration)
        {
            ShowMessage(null, text, duration);
        }
        /// <summary>
        /// Shows a message and an image in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="image">The image to display.</param>
        /// <param name="text">The text message to display.</param>
        public void ShowMessage(Image image, string text)
        {
            ShowMessage(image, text, defaultMessageTime);
        }
        /// <summary>
        /// Shows a message and an image in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="image">The image to display.</param>
        /// <param name="text">The text message to display.</param>
        /// <param name="duration">The time, in milliseconds, the message is displayed.</param>
        public void ShowMessage(Image image, string text, int duration)
        {
            timer.Interval = duration;
            timer.Stop();
            timer.Start();

            label.Image = image;
            label.Text = text;
        }
        /// <summary>
        /// Shows a message and an icon in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The text message to display.</param>
        public void ShowMessage(MessageIcons icon, string text)
        {
            ShowMessage(icon, text, defaultMessageTime);
        }
        /// <summary>
        /// Shows a message and an icon in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The text message to display.</param>
        /// <param name="duration">The time, in milliseconds, the message is displayed.</param>
        public void ShowMessage(MessageIcons icon, string text, int duration)
        {
            Image iconImage;

            switch (icon)
            {
                case MessageIcons.Accept:
                    iconImage = EditorResources.accept; break;
                case MessageIcons.Error:
                    iconImage = EditorResources.error; break;
                case MessageIcons.Warning:
                    iconImage = EditorResources.warning; break;
                case MessageIcons.Working:
                    iconImage = EditorResources.working; break;
                default:
                    throw new ArgumentException("Unknown message icon.");
            }

            ShowMessage(iconImage, text, duration);
        }

        private ToolStripStatusLabel label = null;
        /// <summary>
        /// Gets or sets the <see cref="ToolStripStatusLabel"/> that is used to show the message.
        /// </summary>
        [DefaultValue(null)]
        [Description("The label that is used to show the message.")]
        public ToolStripStatusLabel Label
        {
            get { return this.label; }
            set { this.label = value; }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            label.Image = null;
            label.Text = "";
        }
    }
}
