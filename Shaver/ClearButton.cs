using System.Drawing;
using System.Windows.Forms;

namespace Shaver
{
    /// <summary>
    /// A clear keyboard button.
    /// </summary>
    class ClearButton : KeyboardButton
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
        /// Initializes a new instance of a clear keyboard button.
        /// </summary>
        public ClearButton() : base()
        {
            // Initialize icon size to 15.
            iconSize = 15;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw cross symbol.
            int height = iconSize;
            int width = (height / 3) * 2;
            e.Graphics.DrawLine(new Pen(TextColor, 5), (int)(Width / 2) - (int)(iconSize / 2), 
                (int)(Height / 2) - (int)(iconSize / 2), (int)(Width / 2) + (int)(iconSize / 2),
                (int)(Height / 2) + (int)(iconSize / 2));
            e.Graphics.DrawLine(new Pen(TextColor, 5), (int)(Width / 2) + (int)(iconSize / 2),
                (int)(Height / 2) - (int)(iconSize / 2), (int)(Width / 2) - (int)(iconSize / 2),
                (int)(Height / 2) + (int)(iconSize / 2));
        }
    }
}
