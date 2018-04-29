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
    public partial class FormApolune : Form
    {
        string path;

        public FormApolune(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormApolune_Load(object sender, EventArgs e)
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
            textBox9.MaxLength = 0xF;
            textBox10.MaxLength = 0x8;
        }

        private void loadROMPrices()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPrice(0x3258F);
            textBox2.Text = backend.getPrice(0x32459);
            textBox3.Text = backend.getPrice(0x3245C);
            textBox4.Text = backend.getPrice(0x3244C);
            textBox5.Text = backend.getPrice(0x3244F);
            textBox6.Text = backend.getPrice(0x32452);
            textBox7.Text = backend.getPrice(0x32455);
            textBox8.Text = backend.getPrice(0x325B8);
            textBox9.Text = backend.getROMText(0xF, 0x346B3, 0);
            textBox10.Text = backend.getROMText(0x8, 0x346C3, 0);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Backend backend = new Backend(path);
                backend.setPrice(0x3258F, textBox1.Text);
                backend.setPrice(0x32459, textBox2.Text);
                backend.setPrice(0x3245C, textBox3.Text);
                backend.setPrice(0x3244C, textBox4.Text);
                backend.setPrice(0x3244F, textBox5.Text);
                backend.setPrice(0x32452, textBox6.Text);
                backend.setPrice(0x32455, textBox7.Text);
                backend.setPrice(0x325B8, textBox8.Text);
                backend.updateROMText(0xF, textBox9.Text, 0x346B3, 0);
                backend.updateROMText(0x8, textBox10.Text, 0x346C3, 0);

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
