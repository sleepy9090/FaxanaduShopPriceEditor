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
    public partial class FormDartmoor : Form
    {
        string path;

        public FormDartmoor(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormDartmoor_Load(object sender, EventArgs e)
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
            textBox5.MaxLength = 0xD;
            textBox6.MaxLength = 0xC;
            textBox7.MaxLength = 0xE;
            textBox8.MaxLength = 0x5;
            textBox9.MaxLength = 0x18;
        }

        private void loadROMPrices()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPrice(0x325AF);
            textBox2.Text = backend.getPrice(0x324AB);
            textBox3.Text = backend.getPrice(0x324AE);
            textBox4.Text = backend.getPrice(0x32503);
            textBox5.Text = backend.getROMText(0xD, 0x344B2, 0);
            textBox6.Text = backend.getROMText(0xC, 0x344C0, 0);
            textBox7.Text = backend.getROMText(0xE, 0x344CD, 0);
            textBox8.Text = backend.getPrice(0x32603);
            textBox9.Text = backend.getROMText(0x18, 0x34730, 0);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Backend backend = new Backend(path);
                backend.setPrice(0x325AF, textBox1.Text);
                backend.setPrice(0x324AB, textBox2.Text);
                backend.setPrice(0x324AE, textBox3.Text);
                backend.setPrice(0x32503, textBox4.Text);
                backend.updateROMText(0xD, textBox5.Text, 0x344B2, 0);
                backend.updateROMText(0xC, textBox6.Text, 0x344C0, 0);
                backend.updateROMText(0xE, textBox7.Text, 0x344CD, 0);
                backend.setPrice(0x32603, textBox8.Text);
                backend.updateROMText(0x18, textBox9.Text, 0x34730, 0);

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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox8);
        }
    }
}
