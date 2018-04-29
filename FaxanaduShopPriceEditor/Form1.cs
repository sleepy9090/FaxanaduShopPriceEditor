using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaxanaduShopPriceEditor
{
    public partial class Form1 : Form
    {
        string path;

        public Form1()
        {
            InitializeComponent();
            disableMenuItems();
        }

        private void buttonOpenROM_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "nes files (*.nes)|*.nes|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                textBoxAbsoluteFilename.Text = path;

                loadRom();
            }
        }

        private void loadRom()
        {
            enableMenuItems();
        }

        private void enableMenuItems()
        {
            eolisToolStripMenuItem.Enabled = true;
            apoluneToolStripMenuItem.Enabled = true;
            forpawToolStripMenuItem.Enabled = true;
            masconToolStripMenuItem.Enabled = true;
            victimToolStripMenuItem.Enabled = true;
            conflateToolStripMenuItem.Enabled = true;
            daybreakToolStripMenuItem.Enabled = true;
            dartmoorToolStripMenuItem.Enabled = true;
        }

        private void disableMenuItems()
        {
            eolisToolStripMenuItem.Enabled = false;
            apoluneToolStripMenuItem.Enabled = false;
            forpawToolStripMenuItem.Enabled = false;
            masconToolStripMenuItem.Enabled = false;
            victimToolStripMenuItem.Enabled = false;
            conflateToolStripMenuItem.Enabled = false;
            daybreakToolStripMenuItem.Enabled = false;
            dartmoorToolStripMenuItem.Enabled = false;
        }

        private void openROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonOpenROM_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eolisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEolis formEolis = new FormEolis(path);
            formEolis.ShowDialog();
        }

        private void apoluneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormApolune formApolune = new FormApolune(path);
            formApolune.ShowDialog();
        }

        private void forpawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormForepaw formForepaw = new FormForepaw(path);
            formForepaw.ShowDialog();
        }

        private void masconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMascon formMascon = new FormMascon(path);
            formMascon.ShowDialog();
        }

        private void victimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVictim formVictim = new FormVictim(path);
            formVictim.ShowDialog();
        }

        private void conflateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConflate formConflate = new FormConflate(path);
            formConflate.ShowDialog();
        }

        private void daybreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDaybreak formDaybreak = new FormDaybreak(path);
            formDaybreak.ShowDialog();
        }

        private void dartmoorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDartmoor formDartmoor = new FormDartmoor(path);
            formDartmoor.ShowDialog();
        }
    }
}
