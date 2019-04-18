namespace WadScrambler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbWadFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnScramble = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbScrambleMusic = new System.Windows.Forms.CheckBox();
            this.cbScrambleMiscGfx = new System.Windows.Forms.CheckBox();
            this.cbScrambleAllGfx = new System.Windows.Forms.CheckBox();
            this.cbScrambleSounds = new System.Windows.Forms.CheckBox();
            this.cbScramblePatches = new System.Windows.Forms.CheckBox();
            this.cbScrambleFlats = new System.Windows.Forms.CheckBox();
            this.cbScrambleSprites = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.llGithubUrl = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbWadFile
            // 
            this.tbWadFile.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWadFile.Location = new System.Drawing.Point(6, 19);
            this.tbWadFile.Name = "tbWadFile";
            this.tbWadFile.Size = new System.Drawing.Size(363, 23);
            this.tbWadFile.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(375, 18);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Select...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // openFile
            // 
            this.openFile.CheckPathExists = false;
            this.openFile.DefaultExt = "wad";
            this.openFile.Filter = "WAD files|*.wad";
            this.openFile.Title = "Select WAD file";
            // 
            // btnScramble
            // 
            this.btnScramble.Enabled = false;
            this.btnScramble.Location = new System.Drawing.Point(397, 227);
            this.btnScramble.Name = "btnScramble";
            this.btnScramble.Size = new System.Drawing.Size(75, 23);
            this.btnScramble.TabIndex = 3;
            this.btnScramble.Text = "Scramble";
            this.btnScramble.UseVisualStyleBackColor = true;
            this.btnScramble.Click += new System.EventHandler(this.btnScramble_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbWadFile);
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select WAD file path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbScrambleMusic);
            this.groupBox2.Controls.Add(this.cbScrambleMiscGfx);
            this.groupBox2.Controls.Add(this.cbScrambleAllGfx);
            this.groupBox2.Controls.Add(this.cbScrambleSounds);
            this.groupBox2.Controls.Add(this.cbScramblePatches);
            this.groupBox2.Controls.Add(this.cbScrambleFlats);
            this.groupBox2.Controls.Add(this.cbScrambleSprites);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 181);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scramble what?";
            // 
            // cbScrambleMusic
            // 
            this.cbScrambleMusic.AutoSize = true;
            this.cbScrambleMusic.Checked = true;
            this.cbScrambleMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScrambleMusic.Location = new System.Drawing.Point(7, 158);
            this.cbScrambleMusic.Name = "cbScrambleMusic";
            this.cbScrambleMusic.Size = new System.Drawing.Size(56, 17);
            this.cbScrambleMusic.TabIndex = 6;
            this.cbScrambleMusic.Text = "Music";
            this.cbScrambleMusic.UseVisualStyleBackColor = true;
            // 
            // cbScrambleMiscGfx
            // 
            this.cbScrambleMiscGfx.AutoSize = true;
            this.cbScrambleMiscGfx.Checked = true;
            this.cbScrambleMiscGfx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScrambleMiscGfx.Location = new System.Drawing.Point(7, 89);
            this.cbScrambleMiscGfx.Name = "cbScrambleMiscGfx";
            this.cbScrambleMiscGfx.Size = new System.Drawing.Size(167, 17);
            this.cbScrambleMiscGfx.TabIndex = 5;
            this.cbScrambleMiscGfx.Text = "Other graphics (menus, etc)";
            this.cbScrambleMiscGfx.UseVisualStyleBackColor = true;
            // 
            // cbScrambleAllGfx
            // 
            this.cbScrambleAllGfx.AutoSize = true;
            this.cbScrambleAllGfx.Location = new System.Drawing.Point(7, 112);
            this.cbScrambleAllGfx.Name = "cbScrambleAllGfx";
            this.cbScrambleAllGfx.Size = new System.Drawing.Size(86, 17);
            this.cbScrambleAllGfx.TabIndex = 4;
            this.cbScrambleAllGfx.Text = "All graphics";
            this.cbScrambleAllGfx.UseVisualStyleBackColor = true;
            // 
            // cbScrambleSounds
            // 
            this.cbScrambleSounds.AutoSize = true;
            this.cbScrambleSounds.Checked = true;
            this.cbScrambleSounds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScrambleSounds.Location = new System.Drawing.Point(7, 135);
            this.cbScrambleSounds.Name = "cbScrambleSounds";
            this.cbScrambleSounds.Size = new System.Drawing.Size(65, 17);
            this.cbScrambleSounds.TabIndex = 3;
            this.cbScrambleSounds.Text = "Sounds";
            this.cbScrambleSounds.UseVisualStyleBackColor = true;
            // 
            // cbScramblePatches
            // 
            this.cbScramblePatches.AutoSize = true;
            this.cbScramblePatches.Checked = true;
            this.cbScramblePatches.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScramblePatches.Location = new System.Drawing.Point(7, 66);
            this.cbScramblePatches.Name = "cbScramblePatches";
            this.cbScramblePatches.Size = new System.Drawing.Size(65, 17);
            this.cbScramblePatches.TabIndex = 2;
            this.cbScramblePatches.Text = "Patches";
            this.cbScramblePatches.UseVisualStyleBackColor = true;
            // 
            // cbScrambleFlats
            // 
            this.cbScrambleFlats.AutoSize = true;
            this.cbScrambleFlats.Checked = true;
            this.cbScrambleFlats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScrambleFlats.Location = new System.Drawing.Point(7, 43);
            this.cbScrambleFlats.Name = "cbScrambleFlats";
            this.cbScrambleFlats.Size = new System.Drawing.Size(50, 17);
            this.cbScrambleFlats.TabIndex = 1;
            this.cbScrambleFlats.Text = "Flats";
            this.cbScrambleFlats.UseVisualStyleBackColor = true;
            // 
            // cbScrambleSprites
            // 
            this.cbScrambleSprites.AutoSize = true;
            this.cbScrambleSprites.Checked = true;
            this.cbScrambleSprites.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScrambleSprites.Location = new System.Drawing.Point(7, 20);
            this.cbScrambleSprites.Name = "cbScrambleSprites";
            this.cbScrambleSprites.Size = new System.Drawing.Size(61, 17);
            this.cbScrambleSprites.TabIndex = 0;
            this.cbScrambleSprites.Text = "Sprites";
            this.cbScrambleSprites.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.llGithubUrl);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(196, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 150);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please read the included README before using this!\r\n\r\nRunning this tool on a WAD " +
    "file WILL cause\r\nirreversible damage, so back your shit up\r\n";
            // 
            // llGithubUrl
            // 
            this.llGithubUrl.AutoSize = true;
            this.llGithubUrl.Location = new System.Drawing.Point(6, 83);
            this.llGithubUrl.Name = "llGithubUrl";
            this.llGithubUrl.Size = new System.Drawing.Size(213, 13);
            this.llGithubUrl.TabIndex = 1;
            this.llGithubUrl.TabStop = true;
            this.llGithubUrl.Text = "https://github.com/csnxs/WadScrambler";
            this.llGithubUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 260);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnScramble);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WadScrambler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbWadFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnScramble;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbScrambleMiscGfx;
        private System.Windows.Forms.CheckBox cbScrambleAllGfx;
        private System.Windows.Forms.CheckBox cbScrambleSounds;
        private System.Windows.Forms.CheckBox cbScramblePatches;
        private System.Windows.Forms.CheckBox cbScrambleFlats;
        private System.Windows.Forms.CheckBox cbScrambleSprites;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbScrambleMusic;
        private System.Windows.Forms.LinkLabel llGithubUrl;
    }
}

