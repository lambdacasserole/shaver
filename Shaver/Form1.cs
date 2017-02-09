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

        public Form1()
        {
            InitializeComponent();
            keyboardShift = false;
            textBox1.Font = ShavianFontHelper.getFont(12);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\U00010450";
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            //fonts.Dispose();
            //File.Delete(fontPath);
        }

        private void keyButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text += ShavianCharacterHelper.Out;
        }

        private void updateKeyboardShift()
        {
            foreach (Control control in this.Controls)
            {
                KeyButton key = control as KeyButton;
                if (key != null)
                {
                    key.ShiftActive = keyboardShift;
                }
            }
        }

        private void setKeyboardShift(bool shift)
        {
            if (shift != keyboardShift)
            {
                keyboardShift = shift;
                updateKeyboardShift();
            }
        }

        private void toggleKeyboardShift()
        {
            setKeyboardShift(!keyboardShift);
        }

        private void keyButton27_Click(object sender, EventArgs e)
        {
            toggleKeyboardShift();
        }

        private void LetterKey_Click(object sender, EventArgs e)
        {
            KeyButton key = sender as KeyButton;
            textBox1.Text += key.ActiveCharacter;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                setKeyboardShift(true);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                setKeyboardShift(false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add letter key click event to every letter key.
            foreach (Control control in this.Controls)
            {
                KeyButton key = control as KeyButton;
                if (key != null)
                {
                    key.Click += LetterKey_Click;
                }
            }
        }
    }
}
