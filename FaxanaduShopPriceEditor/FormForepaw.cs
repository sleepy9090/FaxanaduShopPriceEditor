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
    public partial class FormForepaw : Form
    {
        string path;

        public FormForepaw(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormForepaw_Load(object sender, EventArgs e)
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
            textBox4.MaxLength = 0xD;
            textBox5.MaxLength = 0xC;
            textBox6.MaxLength = 0xE;
            textBox7.MaxLength = 0x5;
            textBox8.MaxLength = 0x5;
            textBox9.MaxLength = 0x5;
            textBox10.MaxLength = 0x5;
            textBox11.MaxLength = 0x5;
            textBox12.MaxLength = 0x5;
            textBox13.MaxLength = 0xF;
            textBox14.MaxLength = 0x8;
        }

        private void loadROMPrices()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPrice(0x32593);
            textBox2.Text = backend.getPrice(0x32596);
            textBox3.Text = backend.getPrice(0x324C2);
            textBox4.Text = backend.getROMText(0xD, 0x343E0, 0);
            textBox5.Text = backend.getROMText(0xC, 0x343EE, 0);
            textBox6.Text = backend.getROMText(0xE, 0x343FB, 0);
            textBox7.Text = backend.getPrice(0x32460);
            textBox8.Text = backend.getPrice(0x32463);
            textBox9.Text = backend.getPrice(0x32466);
            textBox10.Text = backend.getPrice(0x32469);
            textBox11.Text = backend.getPrice(0x3246C);
            textBox12.Text = backend.getPrice(0x325C7);
            textBox13.Text = backend.getROMText(0xF, 0x346CC, 0);
            textBox14.Text = backend.getROMText(0x8, 0x346DC, 0);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Backend backend = new Backend(path);
                backend.setPrice(0x32593, textBox1.Text);
                backend.setPrice(0x32596, textBox2.Text);
                backend.setPrice(0x324C2, textBox3.Text);
                backend.updateROMText(0xD, textBox4.Text, 0x343E0, 0);
                backend.updateROMText(0xC, textBox5.Text, 0x343EE, 0);
                backend.updateROMText(0xE, textBox6.Text, 0x343FB, 0);
                backend.setPrice(0x32460, textBox7.Text);
                backend.setPrice(0x32463, textBox8.Text);
                backend.setPrice(0x32466, textBox9.Text);
                backend.setPrice(0x32469, textBox10.Text);
                backend.setPrice(0x3246C, textBox11.Text);
                backend.setPrice(0x325C7, textBox12.Text);
                backend.updateROMText(0xF, textBox13.Text, 0x346CC, 0);
                backend.updateROMText(0x8, textBox14.Text, 0x346DC, 0);

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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox7);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox8);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox9);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox10);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox11_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox11);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox12_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox12);
        }
    }
}
