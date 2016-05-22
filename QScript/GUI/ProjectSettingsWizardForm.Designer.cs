namespace QScript.GUI
{
    partial class ProjectSettingsWizardForm
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
            this.btnSave = new QScript.Controls.PixelAnimatedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGameinfoPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStudiomdlPath = new System.Windows.Forms.TextBox();
            this.btnBrowseGameinfoPath = new QScript.Controls.PixelAnimatedButton();
            this.btnBrowseStudiomdlPath = new QScript.Controls.PixelAnimatedButton();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(440, 90);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 25);
            this.btnSave.TabIndex = 15;
            this.btnSave.Txt = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Gameinfo Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxGameinfoPath
            // 
            this.textBoxGameinfoPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxGameinfoPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGameinfoPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGameinfoPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGameinfoPath.ForeColor = System.Drawing.Color.White;
            this.textBoxGameinfoPath.Location = new System.Drawing.Point(12, 39);
            this.textBoxGameinfoPath.Name = "textBoxGameinfoPath";
            this.textBoxGameinfoPath.Size = new System.Drawing.Size(260, 21);
            this.textBoxGameinfoPath.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Studiomodel Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxStudiomdlPath
            // 
            this.textBoxStudiomdlPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxStudiomdlPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStudiomdlPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxStudiomdlPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStudiomdlPath.ForeColor = System.Drawing.Color.White;
            this.textBoxStudiomdlPath.Location = new System.Drawing.Point(12, 81);
            this.textBoxStudiomdlPath.Name = "textBoxStudiomdlPath";
            this.textBoxStudiomdlPath.Size = new System.Drawing.Size(260, 21);
            this.textBoxStudiomdlPath.TabIndex = 19;
            // 
            // btnBrowseGameinfoPath
            // 
            this.btnBrowseGameinfoPath.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseGameinfoPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseGameinfoPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseGameinfoPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseGameinfoPath.ForeColor = System.Drawing.Color.White;
            this.btnBrowseGameinfoPath.Location = new System.Drawing.Point(278, 44);
            this.btnBrowseGameinfoPath.Name = "btnBrowseGameinfoPath";
            this.btnBrowseGameinfoPath.Size = new System.Drawing.Size(103, 16);
            this.btnBrowseGameinfoPath.TabIndex = 20;
            this.btnBrowseGameinfoPath.Txt = "Import...";
            this.btnBrowseGameinfoPath.Click += new System.EventHandler(this.btnBrowseGameinfoPath_Click);
            // 
            // btnBrowseStudiomdlPath
            // 
            this.btnBrowseStudiomdlPath.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseStudiomdlPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseStudiomdlPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseStudiomdlPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseStudiomdlPath.ForeColor = System.Drawing.Color.White;
            this.btnBrowseStudiomdlPath.Location = new System.Drawing.Point(278, 86);
            this.btnBrowseStudiomdlPath.Name = "btnBrowseStudiomdlPath";
            this.btnBrowseStudiomdlPath.Size = new System.Drawing.Size(103, 16);
            this.btnBrowseStudiomdlPath.TabIndex = 21;
            this.btnBrowseStudiomdlPath.Txt = "Import...";
            this.btnBrowseStudiomdlPath.Click += new System.EventHandler(this.btnBrowseStudiomdlPath_Click);
            // 
            // ProjectSettingsWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 120);
            this.Controls.Add(this.btnBrowseStudiomdlPath);
            this.Controls.Add(this.btnBrowseGameinfoPath);
            this.Controls.Add(this.textBoxStudiomdlPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGameinfoPath);
            this.Controls.Add(this.btnSave);
            this.Name = "ProjectSettingsWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Settings";
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.textBoxGameinfoPath, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBoxStudiomdlPath, 0);
            this.Controls.SetChildIndex(this.btnBrowseGameinfoPath, 0);
            this.Controls.SetChildIndex(this.btnBrowseStudiomdlPath, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.PixelAnimatedButton btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGameinfoPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStudiomdlPath;
        private Controls.PixelAnimatedButton btnBrowseGameinfoPath;
        private Controls.PixelAnimatedButton btnBrowseStudiomdlPath;
    }
}