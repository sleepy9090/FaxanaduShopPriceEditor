using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class FormEolis : Form
    {
        string path;

        public FormEolis(string romPath)
        {
            InitializeComponent();
            path = romPath;
        }

        private void FormEolis_Load(object sender, EventArgs e)
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
            textBox3.MaxLength = 0xD;
            textBox4.MaxLength = 0x5;
            textBox5.MaxLength = 0x5;
            textBox6.MaxLength = 0x5;
            textBox7.MaxLength = 0x5;
            textBox8.MaxLength = 0x5;
            textBox9.MaxLength = 0xB;
            textBox10.MaxLength = 0x5;
            textBox11.MaxLength = 0xC;
            textBox12.MaxLength = 0xC;
            textBox13.MaxLength = 0xD;
            textBox14.MaxLength = 0xD;
            textBox15.MaxLength = 0xE;
            textBox16.MaxLength = 0x5;
            textBox17.MaxLength = 0xE;
            textBox19.MaxLength = 0x6;
        }

        private void loadROMPrices()
        {
            Backend backend = new Backend(path);

            textBox1.Text = backend.getPrice(0x3258B);
            textBox2.Text = backend.getPrice(0x324B5);
            textBox3.Text = backend.getROMText(0xD, 0x343B7, 0); // Dialog 0x28 (Meat)
            textBox12.Text = backend.getROMText(0xC, 0x343C5, 0); // Dialog 0x28
            textBox13.Text = backend.getROMText(0xD, 0x343D2, 0); // Dialog 0x28
            textBox4.Text = backend.getPrice(0x3243F);
            textBox5.Text = backend.getPrice(0x32442);
            textBox6.Text = backend.getPrice(0x32445);
            textBox7.Text = backend.getPrice(0x32448);
            textBox8.Text = backend.getPrice(0x32116);
            textBox9.Text = backend.getROMText(0xB, 0x34656, 0); // Dialog 0x2F (Martial Arts)
            textBox14.Text = backend.getROMText(0xD, 0x34662, 0); // Dialog 0x2F
            textBox19.Text = backend.getROMText(0x6, 0x34670, 0); // Dialog 0x2F
            textBox15.Text = backend.getROMText(0xE, 0x34677, 0); // Dialog 0x2F
            textBox10.Text = backend.getPrice(0x32371);
            textBox11.Text = backend.getROMText(0xC, 0x345B6, 0); // Dialog 0x21 (Magic)
            textBox16.Text = backend.getROMText(0x5, 0x345C3, 0); // Dialog 0x21
            textBox17.Text = backend.getROMText(0xE, 0x345C9, 0); // Dialog 0x21
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try {
                Backend backend = new Backend(path);
                backend.setPrice(0x3258B, textBox1.Text);
                backend.setPrice(0x324B5, textBox2.Text);
                backend.updateROMText(0xD, textBox3.Text, 0x343B7, 0);
                backend.setPrice(0x3243F, textBox4.Text);
                backend.setPrice(0x32442, textBox5.Text);
                backend.setPrice(0x32445, textBox6.Text);
                backend.setPrice(0x32448, textBox7.Text);
                backend.setPrice(0x32116, textBox8.Text);
                backend.updateROMText(0xB, textBox9.Text, 0x34656, 0);
                backend.setPrice(0x32371, textBox10.Text);
                backend.updateROMText(0xD, textBox11.Text, 0x345B6, 0);
                backend.updateROMText(0xD, textBox12.Text, 0x343C5, 0);
                backend.updateROMText(0xD, textBox13.Text, 0x343D2, 0);
                backend.updateROMText(0xD, textBox14.Text, 0x34662, 0);
                backend.updateROMText(0xE, textBox15.Text, 0x34677, 0);
                backend.updateROMText(0x5, textBox16.Text, 0x345C3, 0);
                backend.updateROMText(0xE, textBox17.Text, 0x345C9, 0);
                backend.updateROMText(0x6, textBox19.Text, 0x34670, 0);
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextBox65535(sender, e);
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            validateTextBox65535(sender, e, textBox10);
        }
    }
}
