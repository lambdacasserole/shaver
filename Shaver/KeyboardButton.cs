using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shaver
{
    /// <summary>
    /// Represents a keyboard button.
    /// </summary>
    public abstract class KeyboardButton : Panel
    {
        private MouseState currentMouseState;
        
        private Color defaultColor;

        private Color mouseOverColor;

        private Color mouseDownColor;

        private Color textColor;

        /// <summary>
        /// Gets or sets the default background color of the control.
        /// </summary>
        public Color DefaultColor
        {
            get
            {
                return defaultColor;
            }
            set
            {
                defaultColor = value;
                Refresh(); // Redraw.
            }
        }

        /// <summary>
        /// Gets or sets the mouse over background color of the control.
        /// </summary>
        public Color MouseOverColor
        {
            get
            {
                return mouseOverColor;
            }
            set
            {
                mouseOverColor = value;
                Refresh(); // Redraw.
            }
        }

        /// <summary>
        /// Gets or sets the mouse down background color of the control.
        /// </summary>
        public Color MouseDownColor
        {
            get
            {
                return mouseDownColor;
            }
            set
            {
                mouseDownColor = value;
                Refresh(); // Redraw.
            }
        }

        /// <summary>
        /// Gets or sets the text color of the control.
        /// </summary>
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                Refresh(); // Redraw.
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
                Refresh(); // Redraw.
            }
        }

        /// <summary>
        /// Initializes a new instance of a keyboard button.
        /// </summary>
        public KeyboardButton() : base()
        {
            // Set default colours.
            defaultColor = Color.DimGray;
            mouseOverColor = Color.Silver;
            mouseDownColor = Color.Black;
            textColor = Color.White;
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
            base.OnMouseEnter(e);
            CurrentMouseState = MouseState.Over; // Change mouse state.
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            CurrentMouseState = MouseState.Out; // Change mouse state.
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            CurrentMouseState = MouseState.Down; // Change mouse state.
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CurrentMouseState = MouseState.Over; // Change mouse state.
        }
    }
}
