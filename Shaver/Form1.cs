using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shaver
{
    public partial class Form1 : Form
    {
        private List<ShavianCharacter> typedText;

        private bool keyboardShift;

        private Dictionary<Keys, LetterButton> letterKeyMappings;

        /// <summary>
        /// Gets the typed text in the input editor as a string.
        /// </summary>
        private string TypedText
        {
            get
            {
                // Build text from characters.
                StringBuilder sb = new StringBuilder();
                foreach (ShavianCharacter character in typedText)
                {
                    sb.Append(character.Character);
                }
                return sb.ToString();
            }
        }

        private bool HasColorScheme()
        {
            return System.IO.File.Exists("theme.txt");
        }

        private Color GetSavedColorScheme()
        {
            var color = Color.FromArgb(255, 64, 64, 64);
            if (HasColorScheme())
            {
                var text = System.IO.File.ReadAllText("theme.txt");
                var components = text.Split(',');
                if (components.Length == 3)
                {
                    var success = true;
                    var converted = new int[3];
                    for (int i = 0; i < components.Length; i++)
                    {
                        success = success && int.TryParse(components[i], out converted[i]);
                    }
                    if (success)
                    {
                        color = Color.FromArgb(255, converted[0], converted[1], converted[2]);
                    }
                }
            }
            return color;
        }

        private Color Lighten(Color original, int amount)
        {
            int r = original.R;
            int g = original.G;
            int b = original.B;
            r += amount;
            g += amount;
            b += amount;
            if (r > 255)
            {
                r = 255;
            }
            if (r < 0)
            {
                r = 0;
            }
            if (g > 255)
            {
                g = 255;
            }
            if (g < 0)
            {
                g = 0;
            }
            if (b > 255)
            {
                b = 255;
            }
            if (b < 0)
            {
                b = 0;
            }
            return Color.FromArgb(original.A, r, g, b);
        }

        private void SetColorScheme(Color color)
        {
            Color txtc = (color.R + color.G + color.B) / 3 > 128 ? Color.Black : Color.White;
            foreach (Control c in Controls)
            {
                KeyboardButton kb = c as KeyboardButton;
                if (kb != null)
                {
                    kb.DefaultColor = color;
                    kb.MouseOverColor = Lighten(color, 25);
                    kb.MouseDownColor = Lighten(color, -25);
                    kb.TextColor = txtc;
                }
                TextBox tb = c as TextBox;
                if (tb != null)
                {
                    tb.BackColor = Lighten(color, -35);
                    tb.ForeColor = txtc;
                }
            }
            BackColor = Lighten(color, -10);
            System.IO.File.WriteAllText("theme.txt", color.R + "," + color.G + "," + color.B);
        }

        /// <summary>
        /// Performs a backspace operation.
        /// </summary>
        private void Backspace()
        {
            if (typedText.Count > 0)
            {
                typedText.RemoveAt(typedText.Count - 1);
                inputBox.Text = TypedText;
            }
        }

        /// <summary>
        /// Types the given text into the editor.
        /// </summary>
        /// <param name="text">The text to type.</param>
        private void TypeText(string text)
        {
            typedText.Add(new ShavianCharacter(text));
            inputBox.Text = TypedText;
        }

        public Form1()
        {
            InitializeComponent();

            // Initialize list.
            typedText = new List<ShavianCharacter>();

            // Initialize letter key mappings.
            letterKeyMappings = new Dictionary<Keys, LetterButton>()
            {
                {Keys.Q, keyButton1},
                {Keys.W, keyButton2},
                {Keys.E, keyButton3},
                {Keys.R, keyButton4},
                {Keys.T, keyButton5},
                {Keys.Y, keyButton6},
                {Keys.U, keyButton7},
                {Keys.I, keyButton8},
                {Keys.O, keyButton9},
                {Keys.P, keyButton10},
                {Keys.A, keyButton20},
                {Keys.S, keyButton19},
                {Keys.D, keyButton18},
                {Keys.F, keyButton17},
                {Keys.G, keyButton16},
                {Keys.H, keyButton15},
                {Keys.J, keyButton14},
                {Keys.K, keyButton13},
                {Keys.L, keyButton12},
                {Keys.Z, keyButton26},
                {Keys.X, keyButton25},
                {Keys.C, keyButton24},
                {Keys.V, keyButton23},
                {Keys.B, keyButton22},
                {Keys.N, keyButton21},
                {Keys.M, keyButton11},
            };

            // Shift defaults to off.
            keyboardShift = false;

            // Set Shavian font for input box.
            inputBox.Font = ShavianFontHelper.GetFont(12);
        }

        /// <summary>
        /// Updates the shifted status of every character on the keyboard.
        /// </summary>
        private void UpdateKeyboardShift()
        {
            foreach (Control control in this.Controls)
            {
                LetterButton key = control as LetterButton;
                if (key != null)
                {
                    key.ShiftActive = keyboardShift;
                }
            }
        }

        /// <summary>
        /// Sets the shifted status of every character on the keyboard.
        /// </summary>
        /// <param name="shift">The new shifted status.</param>
        private void SetKeyboardShift(bool shift)
        {
            if (shift != keyboardShift)
            {
                keyboardShift = shift;
                UpdateKeyboardShift();
            }
        }

        /// <summary>
        /// Toggles the shifted status of every character on the keyboard.
        /// </summary>
        private void toggleKeyboardShift()
        {
            SetKeyboardShift(!keyboardShift);
        }

        /// <summary>
        /// Moves the caret to the end of the input box.
        /// </summary>
        private void CaretToEnd()
        {
            if (inputBox.Text.Length > 0)
            {
                inputBox.SelectionStart = inputBox.Text.Length - 1;
            }
        }

        private void keyButton27_Click(object sender, EventArgs e)
        {
            // Shift on or off.
            toggleKeyboardShift();
        }

        private void LetterKey_Click(object sender, EventArgs e)
        {
            // Cast to letter button and append active character.
            LetterButton key = sender as LetterButton;
            if (key != null)
            {
                TypeText(key.ActiveCharacter);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Set shift if pressed.
            if (e.KeyCode == Keys.ShiftKey)
            {
                SetKeyboardShift(true);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                // Unset shift.
                SetKeyboardShift(false);
            }
            else if (e.KeyCode == Keys.Back)
            {
                // Do backspace.
                Backspace();
                CaretToEnd();
            }
            else if (e.KeyCode == Keys.Space)
            {
                // Append space.
                TypeText(" ");
                CaretToEnd();
            }
            else
            {
                // Was letter key pressed?
                if (letterKeyMappings.ContainsKey(e.KeyCode))
                {
                    LetterKey_Click(letterKeyMappings[e.KeyCode], e);
                    CaretToEnd();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add letter key click event to every letter key.
            foreach (Control control in this.Controls)
            {
                LetterButton key = control as LetterButton;
                if (key != null)
                {
                    key.Click += LetterKey_Click;
                }
            }

            // Load color scheme.
            SetColorScheme(GetSavedColorScheme());
        }

        private void copyButton1_Click(object sender, EventArgs e)
        {
            // Copy text to clipboard.
            Clipboard.SetText(TypedText);
        }

        private void colorSchemeButton1_Click(object sender, EventArgs e)
        {
            // Show color dialog to set UI color.
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SetColorScheme(dialog.Color);
            }
        }
    }
}
