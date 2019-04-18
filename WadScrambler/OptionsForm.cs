using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WadScrambler
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            PopulateFields();
        }

        private void PopulateFields()
        {
            tbExcludeLumps.Text = Properties.Settings.Default.ExcludeLumps;
            numVertRandomRange.Value = Properties.Settings.Default.VertexRandomiseRange;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.ExcludeLumps = tbExcludeLumps.Text;
            Properties.Settings.Default.VertexRandomiseRange = (int)numVertRandomRange.Value;

            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
