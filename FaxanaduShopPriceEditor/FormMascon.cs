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
    public partial class FormMascon : Form
    {
        string path;

        public FormMascon(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormMascon_Load(object sender, EventArgs e)
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
            textBox8.MaxLength = 0xD;
            textBox9.MaxLength = 0xC;
            textBox10.MaxLength = 0xE;
            textBox11.MaxLength = 0x5;
            textBox12.MaxLength = 0x18;
            textBox13.MaxLength = 0x5;
            textBox14.MaxLength = 0x5;
            textBox15.MaxLength = 0x5;
            textBox16.MaxLength = 0x5;
        }

        private void loadROMPrices()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPrice(0x3259A);
            textBox2.Text = backend.getPrice(0x3259D);
            textBox3.Text = backend.getPrice(0x32470);
            textBox4.Text = backend.getPrice(0x32473);
            textBox5.Text = backend.getPrice(0x32476);
            textBox6.Text = backend.getPrice(0x32479);
            textBox7.Text = backend.getPrice(0x324CF);
            textBox8.Text = backend.getROMText(0xD, 0x3440A, 0);
            textBox9.Text = backend.getROMText(0xC, 0x34418, 0);
            textBox10.Text = backend.getROMText(0xE, 0x34425, 0);
            textBox11.Text = backend.getPrice(0x325D6);
            textBox12.Text = backend.getROMText(0x18, 0x346E5, 0);
            textBox13.Text = backend.getPrice(0x3247D);
            textBox14.Text = backend.getPrice(0x32480);
            textBox15.Text = backend.getPrice(0x32483);
            textBox16.Text = backend.getPrice(0x32486);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Backend backend = new Backend(path);
                backend.setPrice(0x3259A, textBox1.Text);
                backend.setPrice(0x3259D, textBox2.Text);
                backend.setPrice(0x32470, textBox3.Text);
                backend.setPrice(0x32473, textBox4.Text);
                backend.setPrice(0x32476, textBox5.Text);
                backend.setPrice(0x32479, textBox6.Text);
                backend.setPrice(0x324CF, textBox7.Text);
                backend.updateROMText(0xD, textBox8.Text, 0x3440A, 0);
                backend.updateROMText(0xC, textBox9.Text, 0x34418, 0);
                backend.updateROMText(0xE, textBox10.Text, 0x34425, 0);
                backend.setPrice(0x325D6, textBox11.Text);
                backend.updateROMText(0x8, textBox12.Text, 0x346E5, 0);
                backend.setPrice(0x3247D, textBox13.Text);
                backend.setPrice(0x32480, textBox14.Text);
                backend.setPrice(0x32483, textBox15.Text);
                backend.setPrice(0x32486, textBox16.Text);

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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox6);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox7);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox11_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox11);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox13_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox13);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox14);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox15_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox15);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox16_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox16);
        }
    }
}
