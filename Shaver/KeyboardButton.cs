using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shaver
{
    public class KeyboardButton : Panel
    {
        private MouseState currentMouseState;
        
        private Color defaultColor;

        private Color mouseOverColor;

        private Color mouseDownColor;

        public Color DefaultColor
        {
            get
            {
                return defaultColor;
            }
            set
            {
                defaultColor = value;
                Refresh();
            }
        }

        public Color MouseOverColor
        {
            get
            {
                return mouseOverColor;
            }
            set
            {
                mouseOverColor = value;
                Refresh();
            }
        }

        public Color MouseDownColor
        {
            get
            {
                return mouseDownColor;
            }
            set
            {
                mouseDownColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the current mouse state of the control.
        /// </summary>
        private MouseState CurrentMouseState
        {
            get
            {
                return currentMouseState;
            }
            set
            {
                currentMouseState = value;
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set appropriate background color.
            switch (currentMouseState)
            {
                case MouseState.Out:
                    e.Graphics.Clear(DefaultColor);
                    break;
                case MouseState.Over:
                    e.Graphics.Clear(MouseOverColor);
                    break;
                case MouseState.Down:
                    e.Graphics.Clear(MouseDownColor);
                    break;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            CurrentMouseState = MouseState.Over;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            CurrentMouseState = MouseState.Out;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            CurrentMouseState = MouseState.Down;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            CurrentMouseState = MouseState.Over;
            base.OnMouseUp(e);
        }
    }
}
