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

            file = new WadFile(tbWadFile.Text);
            file.Read();

            int scrambledGraphics = 0;
            int scrambledSounds = 0;
            int scrambledLumps = 0;

            if (cbScrambleFlats.Checked) scrambledGraphics += file.ScrambleEntries(ref file.Flats);
            if (cbScrambleSprites.Checked) scrambledGraphics += file.ScrambleEntries(ref file.Sprites);
            if (cbScramblePatches.Checked) scrambledGraphics += file.ScrambleEntries(ref file.Patches);
            if (cbScrambleMiscGfx.Checked) scrambledGraphics += file.ScrambleEntries(ref file.MiscGraphics);
            if (cbScrambleAllGfx.Checked) scrambledGraphics += file.ScrambleEntries(ref file.AllGraphics);
            if (cbScrambleSounds.Checked) scrambledSounds += file.ScrambleEntries(ref file.Sounds);
            if (cbScrambleMusic.Checked) scrambledSounds += file.ScrambleEntries(ref file.Music);

            scrambledLumps = scrambledGraphics + scrambledSounds;

            string mbox = "Scrambed WAD successfully.\n";
            mbox += "Total scrambled lumps: " + scrambledLumps + "\n";
            mbox += "\tGraphics: " + scrambledGraphics + "\n";
            mbox += "\tSounds: " + scrambledSounds + "\n";

            MessageBox.Show(mbox, "WadScrambler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            file.WriteEntries();
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
    }
}
