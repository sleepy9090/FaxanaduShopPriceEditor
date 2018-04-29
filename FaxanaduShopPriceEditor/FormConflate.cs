using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * Author: Shawn M. Crawford [sleepy]
 * sleepy3d@gmail.com
 * 2018+
 */
namespace FaxanaduShopPriceEditor
{
    public partial class FormConflate : Form
    {
        string path;

        public FormConflate(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormConflate_Load(object sender, EventArgs e)
        {
            Backend backend = new Backend(path);

            setMaxTextboxLength();
            loadROMPrices();
        }

        private void setMaxTextboxLength()
        {
            // Max 65535
            textBox1.MaxLength = 0x5;
            textBox2.MaxLength = 0x5;
            textBox3.MaxLength = 0x5;
            textBox4.MaxLength = 0x5;
            textBox5.MaxLength = 0x5;
            textBox6.MaxLength = 0x5;
            textBox7.MaxLength = 0x5;
            textBox8.MaxLength = 0x5;
            textBox9.MaxLength = 0x5;
            textBox10.MaxLength = 0x8;
            textBox11.MaxLength = 0x8;
        }

        private void loadROMPrices()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPrice(0x32494);
            textBox2.Text = backend.getPrice(0x32497);
            textBox3.Text = backend.getPrice(0x3249A);
            textBox4.Text = backend.getPrice(0x3249D);
            textBox5.Text = backend.getPrice(0x324E9);
            textBox6.Text = backend.getROMText(0xD, 0x3445E, 0);
            textBox7.Text = backend.getROMText(0xC, 0x3446C, 0);
            textBox8.Text = backend.getROMText(0xE, 0x34479, 0);
            textBox9.Text = backend.getPrice(0x325F4);
            textBox10.Text = backend.getROMText(0xF, 0x346B3, 0);
            textBox11.Text = backend.getROMText(0x8, 0x346C3, 0);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Backend backend = new Backend(path);
                backend.setPrice(0x32494, textBox1.Text);
                backend.setPrice(0x32497, textBox2.Text);
                backend.setPrice(0x3249A, textBox3.Text);
                backend.setPrice(0x3249D, textBox4.Text);
                backend.setPrice(0x324E9, textBox5.Text);
                backend.updateROMText(0xD, textBox6.Text, 0x3445E, 0);
                backend.updateROMText(0xC, textBox7.Text, 0x3446C, 0);
                backend.updateROMText(0xE, textBox8.Text, 0x34479, 0);
                backend.setPrice(0x325F4, textBox9.Text);
                backend.updateROMText(0xF, textBox10.Text, 0x346B3, 0);
                backend.updateROMText(0x8, textBox11.Text, 0x346C3, 0);

                MessageBox.Show("ROM updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validateTextBox65535(object sender, KeyPressEventArgs e)
        {
            char keypress = e.KeyChar;
            if (char.IsDigit(keypress) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                // 
            }
            else
            {
                MessageBox.Show("This must be a numeric value, inclusive, between 0 and 65535.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                e.Handled = true;
            }
        }

        private void validateTextBox65535(object sender, KeyEventArgs e, TextBox textBox)
        {
            int value;

            if (int.TryParse(textBox.Text, out value))
            {
                if (value > 65535)
                {
                    textBox.Text = "65535";
                }
            }
            else
            {
                // Should not happen.
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox1);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox2);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox3);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox4);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox5);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox9);
        }
    }
}
