using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shaver
{
    public partial class Form1 : Form
    {
        private bool keyboardShift;

        private Dictionary<Keys, LetterButton> letterKeyMappings;

        public Form1()
        {
            InitializeComponent();

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
            inputBox.Font = ShavianFontHelper.getFont(12);
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            //fonts.Dispose();
            //File.Delete(fontPath);
        }

        private void updateKeyboardShift()
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

        private void SetKeyboardShift(bool shift)
        {
            if (shift != keyboardShift)
            {
                keyboardShift = shift;
                updateKeyboardShift();
            }
        }

        private void toggleKeyboardShift()
        {
            SetKeyboardShift(!keyboardShift);
        }

        private void keyButton27_Click(object sender, EventArgs e)
        {
            toggleKeyboardShift();
        }

        private void LetterKey_Click(object sender, EventArgs e)
        {
            // Cast to letter button and append active character.
            LetterButton key = sender as LetterButton;
            if (key != null)
            {
                inputBox.AppendText(key.ActiveCharacter);
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
                inputBox.Text = inputBox.Text.Substring(0, inputBox.Text.Length - 2);
            }
            else if (e.KeyCode == Keys.Space)
            {
                // Append space.
                inputBox.Text += " ";
            }
            else
            {
                // Was letter key pressed?
                if (letterKeyMappings.ContainsKey(e.KeyCode))
                {
                    LetterKey_Click(letterKeyMappings[e.KeyCode], e);
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
        }
    }
}
