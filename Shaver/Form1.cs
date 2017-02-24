using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Shaver
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The filename of the theme file.
        /// </summary>
        private const string ThemeFileName = "theme.txt";

        /// <summary>
        /// The current collection of typed characters in the editor.
        /// </summary>
        private List<ShavianCharacter> typedText;

        /// <summary>
        /// Whether or not shift is currently enabled for the keyboard.
        /// </summary>
        private bool keyboardShift;

        /// <summary>
        /// A dictionary of keyboard keys mapping to letter buttons.
        /// </summary>
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

        /// <summary>
        /// Returns true if a color scheme file exists for the application, otherwise returns false.
        /// </summary>
        /// <returns></returns>
        private bool HasColorScheme()
        {
            return File.Exists(ThemeFileName);
        }

        /// <summary>
        /// Gets the saved color scheme for the application, if it exists.
        /// </summary>
        /// <returns></returns>
        private Color GetSavedColorScheme()
        {
            var color = Color.FromArgb(255, 64, 64, 64); // Default color.

            // If we have a saved color scheme.
            if (HasColorScheme())
            {
                var text = File.ReadAllText(ThemeFileName);
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

        /// <summary>
        /// Lightens a color by an amount.
        /// </summary>
        /// <param name="original">The original color.</param>
        /// <param name="amount">The amount to ligten by.</param>
        /// <returns></returns>
        private Color Lighten(Color original, int amount)
        {
            return Color.FromArgb(
                original.A,
                Math.Min(Math.Max(original.R + amount, 0), 255),
                Math.Min(Math.Max(original.G + amount, 0), 255),
                Math.Min(Math.Max(original.B + amount, 0), 255));
        }

        /// <summary>
        /// Sets the color scheme of the keyboard.
        /// </summary>
        /// <param name="color">The base color of the new color scheme.</param>
        private void SetColorScheme(Color color)
        {
            // Decide on text color based on brightness.
            var textColor = (color.R + color.G + color.B) / 3 > 128 
                ? Color.Black : Color.White;

            // Loop through controls on form.
            foreach (var control in Controls)
            {
                // If it's a keybaord button.
                KeyboardButton keyboardButton = control as KeyboardButton;
                if (keyboardButton != null)
                {
                    keyboardButton.DefaultColor = color;
                    keyboardButton.MouseOverColor = Lighten(color, 25);
                    keyboardButton.MouseDownColor = Lighten(color, -25);
                    keyboardButton.TextColor = textColor;
                }

                // If it's a text box.
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    textBox.BackColor = Lighten(color, -35);
                    textBox.ForeColor = textColor;
                }
            }

            // Set form background color.
            BackColor = Lighten(color, -10); 

            // Save file.
            File.WriteAllText(ThemeFileName, color.R + "," + color.G + "," + color.B);
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
