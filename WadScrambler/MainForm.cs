using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WadScrambler
{
    public partial class MainForm : Form
    {
        private WadFile file;

        public MainForm()
        {
            InitializeComponent();

            cbScrambleFlats.CheckedChanged += CheckScrambleButtonEventHandler;
            cbScrambleSprites.CheckedChanged += CheckScrambleButtonEventHandler;
            cbScramblePatches.CheckedChanged += CheckScrambleButtonEventHandler;
            cbScrambleMiscGfx.CheckedChanged += CheckScrambleButtonEventHandler;
            cbScrambleAllGfx.CheckedChanged += CheckScrambleButtonEventHandler;
            cbScrambleSounds.CheckedChanged += CheckScrambleButtonEventHandler;
            tbWadFile.TextChanged += CheckScrambleButtonEventHandler;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult res = openFile.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                tbWadFile.Text = openFile.FileName;
            }
        }

        private void btnScramble_Click(object sender, EventArgs e)
        {
            string filename = tbWadFile.Text;
            if (!File.Exists(filename))
            {
                MessageBox.Show("File " + filename + " does not exist.", "WadScrambler", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                file = new WadFile(tbWadFile.Text);
                file.Read();

                int scrambledSprites = 0;
                int scrambledFlats = 0;
                int scrambledPatches = 0;
                int scrambledMiscGfx = 0;
                int scrambledMusic = 0;

                int scrambledGraphics = 0;
                int scrambledSounds = 0;
                int scrambledLumps = 0;

                if (cbScrambleFlats.Checked) scrambledFlats += file.ScrambleEntries(ref file.Flats);
                if (cbScrambleSprites.Checked) scrambledSprites += file.ScrambleEntries(ref file.Sprites);
                if (cbScramblePatches.Checked) scrambledPatches += file.ScrambleEntries(ref file.Patches);
                if (cbScrambleMiscGfx.Checked) scrambledMiscGfx += file.ScrambleEntries(ref file.MiscGraphics);
                if (cbScrambleAllGfx.Checked) scrambledGraphics += file.ScrambleEntries(ref file.AllGraphics);
                if (cbScrambleSounds.Checked) scrambledSounds += file.ScrambleEntries(ref file.Sounds);
                if (cbScrambleMusic.Checked) scrambledMusic += file.ScrambleEntries(ref file.Music);

                scrambledGraphics += scrambledSprites + scrambledFlats + scrambledPatches + scrambledMiscGfx;
                scrambledLumps = scrambledGraphics + scrambledSounds;

                string mbox = "Scrambed WAD successfully.\n";
                mbox += "Total scrambled lumps: " + scrambledLumps + "\n";
                mbox += "\tTotal graphics: " + scrambledGraphics + "\n";
                mbox += "\tSprites: " + scrambledSprites + "\n";
                mbox += "\tFlats: " + scrambledFlats + "\n";
                mbox += "\tPatches: " + scrambledPatches + "\n";
                mbox += "\tMisc. graphics: " + scrambledMiscGfx + "\n";
                mbox += "\tSounds: " + scrambledSounds + "\n";
                mbox += "\tMusic: " + scrambledMusic + "\n";

                MessageBox.Show(mbox, "WadScrambler", MessageBoxButtons.OK, MessageBoxIcon.Information);

                file.WriteEntries();
            }
            catch (Exception ex)
            {
                string s = ex.GetType().Name + ": " + ex.Message + "\n";
                s += ex.StackTrace;

                MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckScrambleButton()
        {
            bool anyChecked = (
                    cbScrambleFlats.Checked ||
                    cbScrambleSprites.Checked ||
                    cbScramblePatches.Checked ||
                    cbScrambleMiscGfx.Checked ||
                    cbScrambleAllGfx.Checked ||
                    cbScrambleSounds.Checked
            );

            bool isText = !string.IsNullOrEmpty(tbWadFile.Text);

            btnScramble.Enabled = anyChecked && isText;
        }

        private void CheckScrambleButtonEventHandler(Object o, EventArgs a)
        {
            CheckScrambleButton();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llGithubUrl.Text);
        }
    }
}
