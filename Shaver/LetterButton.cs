using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shaver
{
    public class LetterButton : KeyboardButton
    {
        private bool shiftActive;

        private string shiftCharacter;

        private string defaultCharacter;

        private bool shiftCharacterEnabled;

        public string DefaultCharacterName { get; set; }

        public string ShiftCharacterName { get; set; }

        /// <summary>
        /// Gets or sets whether or not this key has its shift character enabled.
        /// </summary>
        public Boolean ShiftCharacterEnabled
        {
            get
            {
                return shiftCharacterEnabled;
            }
            set
            {
                shiftCharacterEnabled = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets the name of the active character.
        /// </summary>
        public string ActiveCharacterName
        {
            get
            {
                return (ShiftActive && ShiftCharacterEnabled) ? ShiftCharacterName : DefaultCharacterName;
            }
        }

        /// <summary>
        /// Gets or sets whether or not shift is active for this key.
        /// </summary>
        public bool ShiftActive
        {
            get
            {
                return shiftActive;
            }
            set
            {
                shiftActive = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets the character displayed on this key when shift is active.
        /// </summary>
        public string ShiftCharacter
        {
            get
            {
                return shiftCharacter;
            }
            set
            {
                shiftCharacter = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets the default charcter displayed on this key.
        /// </summary>
        public string DefaultCharacter
        {
            get
            {
                return defaultCharacter;
            }
            set
            {
                defaultCharacter = value;
                Refresh();
            }
        }
        
        /// <summary>
        /// Gets the active character on this key.
        /// </summary>
        public string ActiveCharacter
        {
            get
            {
                return (ShiftActive && ShiftCharacterEnabled) ? ShiftCharacter : DefaultCharacter;
            }
        }

        /// <summary>
        /// Gets the inactive character on this key.
        /// </summary>
        public string InactiveCharacter
        {
            get
            {
                return (ShiftActive || !ShiftCharacterEnabled) ? DefaultCharacter : ShiftCharacter;
            }
        }

        public LetterButton()
        {
            DefaultCharacter = ShavianCharacterHelper.Oil;
            DefaultCharacterName = "Oil";
            ShiftCharacter = ShavianCharacterHelper.Out;
            ShiftCharacterName = "Out";
            ShiftCharacterEnabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Get font we'll be drawing with.
            Font font = ShavianFontHelper.getFont(14);
            Size stringSize = e.Graphics.MeasureString(ActiveCharacter, font).ToSize();
            Point centerPoint = new Point(Width / 2 - (stringSize.Width / 2), Height / 2 - (stringSize.Height / 2) - 5);
            e.Graphics.DrawString(ActiveCharacter, font, new SolidBrush(Color.White), centerPoint);

            // Draw shift character if there is one.
            if (ShiftCharacterEnabled)
            {
                Font shiftFont = ShavianFontHelper.getFont(10);
                Size shiftStringSize = e.Graphics.MeasureString(InactiveCharacter, shiftFont).ToSize();
                Point upperPoint = new Point(5, 0);
                e.Graphics.DrawString(InactiveCharacter, shiftFont, new SolidBrush(Color.Silver), upperPoint);
            }

            // Draw character name.
            Font nameFont = new Font("Arial", 8);
            Size shiftNameString = e.Graphics.MeasureString(ActiveCharacterName, nameFont).ToSize();
            Point lowerPoint = new Point(Width / 2 - (shiftNameString.Width / 2), Height - shiftNameString.Height - 5);
            e.Graphics.DrawString(ActiveCharacterName, nameFont, new SolidBrush(Color.White), lowerPoint);
        }
    }
}