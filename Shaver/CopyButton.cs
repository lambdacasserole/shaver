using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Shaver
{
    /// <summary>
    /// A copy keyboard button.
    /// </summary>
    class CopyButton : KeyboardButton
    {
        private int iconSize;

        /// <summary>
        /// Gets or sets the icon size on the button.
        /// </summary>
        public int IconSize
        {
            get
            {
                return iconSize;
            }
            set
            {
                iconSize = value;
                Refresh();
            }
        }

        /// <summary>
        /// Initializes a new instance of a shift button.
        /// </summary>
        public CopyButton() : base()
        {
            iconSize = 15;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw two pages copy symbol.
            int height = iconSize;
            int width = (height / 3) * 2;
            e.Graphics.DrawRectangle(new Pen(TextColor), (int)(Width / 2) - (int)(width / 1.5), 
                (int)(Height / 2) - (int)(height / 1.5), width, height);
            e.Graphics.FillRectangle(new SolidBrush(TextColor), (int)(Width / 2) - (int)(width / 4), 
                (int)(Height / 2) - (int)(height / 4), width, height);
        }
    }
}
