namespace QScript.GUI
{
    partial class ProjectWizardForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProjectPath = new System.Windows.Forms.TextBox();
            this.buttonProjectPath = new QScript.Controls.PixelAnimatedButton();
            this.btnCreateProj = new QScript.Controls.PixelAnimatedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGameinfoPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStudiomdlPath = new System.Windows.Forms.TextBox();
            this.buttonGameinfoPath = new QScript.Controls.PixelAnimatedButton();
            this.buttonStudiomdlPath = new QScript.Controls.PixelAnimatedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProjectName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxProjectName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProjectName.ForeColor = System.Drawing.Color.White;
            this.textBoxProjectName.Location = new System.Drawing.Point(3, 42);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(260, 21);
            this.textBoxProjectName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Project Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProjectPath
            // 
            this.textBoxProjectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProjectPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxProjectPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProjectPath.ForeColor = System.Drawing.Color.White;
            this.textBoxProjectPath.Location = new System.Drawing.Point(3, 85);
            this.textBoxProjectPath.Name = "textBoxProjectPath";
            this.textBoxProjectPath.Size = new System.Drawing.Size(260, 21);
            this.textBoxProjectPath.TabIndex = 5;
            // 
            // buttonProjectPath
            // 
            this.buttonProjectPath.BackColor = System.Drawing.Color.Transparent;
            this.buttonProjectPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonProjectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProjectPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjectPath.ForeColor = System.Drawing.Color.White;
            this.buttonProjectPath.Location = new System.Drawing.Point(266, 88);
            this.buttonProjectPath.Name = "buttonProjectPath";
            this.buttonProjectPath.Size = new System.Drawing.Size(103, 16);
            this.buttonProjectPath.TabIndex = 6;
            this.buttonProjectPath.Txt = "Select Path...";
            this.buttonProjectPath.Click += new System.EventHandler(this.buttonProjectPath_Click);
            // 
            // btnCreateProj
            // 
            this.btnCreateProj.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateProj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateProj.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateProj.ForeColor = System.Drawing.Color.White;
            this.btnCreateProj.Location = new System.Drawing.Point(374, 175);
            this.btnCreateProj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateProj.Name = "btnCreateProj";
            this.btnCreateProj.Size = new System.Drawing.Size(130, 25);
            this.btnCreateProj.TabIndex = 7;
            this.btnCreateProj.Txt = "Create Project";
            this.btnCreateProj.Click += new System.EventHandler(this.btnCreateProj_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Gameinfo Path";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxGameinfoPath
            // 
            this.textBoxGameinfoPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxGameinfoPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGameinfoPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGameinfoPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGameinfoPath.ForeColor = System.Drawing.Color.White;
            this.textBoxGameinfoPath.Location = new System.Drawing.Point(3, 128);
            this.textBoxGameinfoPath.Name = "textBoxGameinfoPath";
            this.textBoxGameinfoPath.Size = new System.Drawing.Size(260, 21);
            this.textBoxGameinfoPath.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Studiomodel Path";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxStudiomdlPath
            // 
            this.textBoxStudiomdlPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxStudiomdlPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStudiomdlPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxStudiomdlPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStudiomdlPath.ForeColor = System.Drawing.Color.White;
            this.textBoxStudiomdlPath.Location = new System.Drawing.Point(3, 170);
            this.textBoxStudiomdlPath.Name = "textBoxStudiomdlPath";
            this.textBoxStudiomdlPath.Size = new System.Drawing.Size(260, 21);
            this.textBoxStudiomdlPath.TabIndex = 11;
            // 
            // buttonGameinfoPath
            // 
            this.buttonGameinfoPath.BackColor = System.Drawing.Color.Transparent;
            this.buttonGameinfoPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGameinfoPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGameinfoPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGameinfoPath.ForeColor = System.Drawing.Color.White;
            this.buttonGameinfoPath.Location = new System.Drawing.Point(266, 133);
            this.buttonGameinfoPath.Name = "buttonGameinfoPath";
            this.buttonGameinfoPath.Size = new System.Drawing.Size(103, 16);
            this.buttonGameinfoPath.TabIndex = 12;
            this.buttonGameinfoPath.Txt = "Select Path...";
            this.buttonGameinfoPath.Click += new System.EventHandler(this.buttonGameinfoPath_Click);
            // 
            // buttonStudiomdlPath
            // 
            this.buttonStudiomdlPath.BackColor = System.Drawing.Color.Transparent;
            this.buttonStudiomdlPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStudiomdlPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStudiomdlPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStudiomdlPath.ForeColor = System.Drawing.Color.White;
            this.buttonStudiomdlPath.Location = new System.Drawing.Point(266, 175);
            this.buttonStudiomdlPath.Name = "buttonStudiomdlPath";
            this.buttonStudiomdlPath.Size = new System.Drawing.Size(103, 16);
            this.buttonStudiomdlPath.TabIndex = 13;
            this.buttonStudiomdlPath.Txt = "Select Path...";
            this.buttonStudiomdlPath.Click += new System.EventHandler(this.buttonStudiomdlPath_Click);
            // 
            // ProjectWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(23)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(508, 205);
            this.Controls.Add(this.btnCreateProj);
            this.Controls.Add(this.buttonStudiomdlPath);
            this.Controls.Add(this.buttonGameinfoPath);
            this.Controls.Add(this.textBoxStudiomdlPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxGameinfoPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonProjectPath);
            this.Controls.Add(this.textBoxProjectPath);
            this.Controls.Add(this.textBoxProjectName);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Wizard";
            this.Controls.SetChildIndex(this.textBoxProjectName, 0);
            this.Controls.SetChildIndex(this.textBoxProjectPath, 0);
            this.Controls.SetChildIndex(this.buttonProjectPath, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBoxGameinfoPath, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBoxStudiomdlPath, 0);
            this.Controls.SetChildIndex(this.buttonGameinfoPath, 0);
            this.Controls.SetChildIndex(this.buttonStudiomdlPath, 0);
            this.Controls.SetChildIndex(this.btnCreateProj, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProjectPath;
        private Controls.PixelAnimatedButton buttonProjectPath;
        private Controls.PixelAnimatedButton btnCreateProj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGameinfoPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStudiomdlPath;
        private Controls.PixelAnimatedButton buttonGameinfoPath;
        private Controls.PixelAnimatedButton buttonStudiomdlPath;
    }
}