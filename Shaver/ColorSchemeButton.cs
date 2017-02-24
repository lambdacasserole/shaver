using System.Drawing;
using System.Windows.Forms;

namespace Shaver
{
    /// <summary>
    /// A color scheme keyboard button control.
    /// </summary>
    class ColorSchemeButton : KeyboardButton
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
                Refresh(); // Redraw.
            }
        }

        /// <summary>
        /// Initializes a new instance of a color scheme button.
        /// </summary>
        public ColorSchemeButton() : base()
        {
            // Icon size should initially be 8.
            iconSize = 8;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw four colored circles icon.
            int x = Width / 2;
            int y = Height / 2;
            int s = IconSize / 4;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(new SolidBrush(Color.Red), x - IconSize - s, y - IconSize - s, IconSize, IconSize);
            e.Graphics.FillEllipse(new SolidBrush(Color.Orange), x + s, y - IconSize - s, IconSize, IconSize);
            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), x - IconSize - s, y + s, IconSize, IconSize);
            e.Graphics.FillEllipse(new SolidBrush(Color.Yellow), x + s, y + s, IconSize, IconSize);
        }
    }
}
