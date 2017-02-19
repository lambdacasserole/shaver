using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Shaver
{
    /// <summary>
    /// A shift button control.
    /// </summary>
    class ShiftButton : KeyboardButton
    {
        private int arrowSize;

        /// <summary>
        /// Gets or sets the arrow size on the button.
        /// </summary>
        public int ArrowSize
        {
            get
            {
                return arrowSize;
            }
            set
            {
                arrowSize = value;
                Refresh();
            }
        }

        /// <summary>
        /// Initializes a new instance of a shift button.
        /// </summary>
        public ShiftButton() : base()
        {
            arrowSize = 8;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Build shift arrow polygon.
            List<Point> polygon = new List<Point>();
            polygon.Add(new Point((Width / 2) - (arrowSize / 2), 
                (Height / 2) + (arrowSize / 2)));
            polygon.Add(new Point((Width / 2) + (arrowSize / 2), 
                (Height / 2) + (arrowSize / 2)));
            polygon.Add(new Point((Width / 2) + (arrowSize / 2), 
                (Height / 2) - (arrowSize / 2)));
            polygon.Add(new Point((Width / 2) + arrowSize, 
                (Height / 2) - (arrowSize / 2)));
            polygon.Add(new Point((Width / 2), 
                (Height / 2) - (int)(arrowSize * 1.5)));
            polygon.Add(new Point((Width / 2) - arrowSize, 
                (Height / 2) - (arrowSize / 2)));
            polygon.Add(new Point((Width / 2) - (arrowSize / 2), 
                (Height / 2) - (arrowSize / 2)));

            // Fill arrow polygon.
            e.Graphics.FillPolygon(new SolidBrush(TextColor), polygon.ToArray());

            // Fill rectangle below arrow.
            e.Graphics.FillRectangle(new SolidBrush(TextColor), 
                new Rectangle((Width / 2) - (arrowSize / 2), 
                (Height / 2) + (int)(arrowSize / 1.3), arrowSize, (arrowSize / 4)));
        }
    }
}
