namespace QScript.GUI
{
    partial class VMTGeneratorToolWizard
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxShaderList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.checkListParams = new System.Windows.Forms.CheckedListBox();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupVTFFiles = new System.Windows.Forms.GroupBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGenerate = new QScript.Controls.PixelAnimatedButton();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.richTextFile = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextLog = new System.Windows.Forms.RichTextBox();
            this.timUpdate = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTexturePath = new System.Windows.Forms.TextBox();
            this.groupParameters.SuspendLayout();
            this.groupVTFFiles.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxShaderList
            // 
            this.comboBoxShaderList.BackColor = System.Drawing.Color.Silver;
            this.comboBoxShaderList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxShaderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShaderList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxShaderList.FormattingEnabled = true;
            this.comboBoxShaderList.Location = new System.Drawing.Point(12, 38);
            this.comboBoxShaderList.MaxDropDownItems = 5;
            this.comboBoxShaderList.Name = "comboBoxShaderList";
            this.comboBoxShaderList.Size = new System.Drawing.Size(138, 21);
            this.comboBoxShaderList.TabIndex = 2;
            this.comboBoxShaderList.SelectedIndexChanged += new System.EventHandler(this.comboBoxShaderList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Shader";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupParameters
            // 
            this.groupParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupParameters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupParameters.Controls.Add(this.checkListParams);
            this.groupParameters.ForeColor = System.Drawing.Color.White;
            this.groupParameters.Location = new System.Drawing.Point(196, 22);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(200, 438);
            this.groupParameters.TabIndex = 19;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Parameters";
            // 
            // checkListParams
            // 
            this.checkListParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkListParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.checkListParams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkListParams.CheckOnClick = true;
            this.checkListParams.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkListParams.ForeColor = System.Drawing.SystemColors.Info;
            this.checkListParams.FormattingEnabled = true;
            this.checkListParams.Location = new System.Drawing.Point(6, 16);
            this.checkListParams.Name = "checkListParams";
            this.checkListParams.Size = new System.Drawing.Size(188, 420);
            this.checkListParams.TabIndex = 0;
            this.checkListParams.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListParams_ItemCheck);
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPrefix.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPrefix.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrefix.ForeColor = System.Drawing.Color.White;
            this.textBoxPrefix.Location = new System.Drawing.Point(12, 85);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(138, 21);
            this.textBoxPrefix.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "File Name Prefix";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupVTFFiles
            // 
            this.groupVTFFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupVTFFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupVTFFiles.Controls.Add(this.listBoxFiles);
            this.groupVTFFiles.Controls.Add(this.btnBrowse);
            this.groupVTFFiles.ForeColor = System.Drawing.Color.White;
            this.groupVTFFiles.Location = new System.Drawing.Point(12, 123);
            this.groupVTFFiles.Name = "groupVTFFiles";
            this.groupVTFFiles.Size = new System.Drawing.Size(178, 337);
            this.groupVTFFiles.TabIndex = 22;
            this.groupVTFFiles.TabStop = false;
            this.groupVTFFiles.Text = "VTF Files";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.listBoxFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxFiles.ForeColor = System.Drawing.Color.White;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(6, 19);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.ScrollAlwaysVisible = true;
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Size = new System.Drawing.Size(166, 286);
            this.listBoxFiles.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.ForeColor = System.Drawing.Color.Black;
            this.btnBrowse.Location = new System.Drawing.Point(46, 308);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(665, 442);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(85, 24);
            this.btnGenerate.TabIndex = 16;
            this.btnGenerate.Txt = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.richTextFile);
            this.groupBoxFile.ForeColor = System.Drawing.Color.White;
            this.groupBoxFile.Location = new System.Drawing.Point(402, 22);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(348, 245);
            this.groupBoxFile.TabIndex = 23;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "Script";
            // 
            // richTextFile
            // 
            this.richTextFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextFile.DetectUrls = false;
            this.richTextFile.Location = new System.Drawing.Point(6, 16);
            this.richTextFile.Name = "richTextFile";
            this.richTextFile.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextFile.Size = new System.Drawing.Size(336, 223);
            this.richTextFile.TabIndex = 0;
            this.richTextFile.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextLog);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(402, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 155);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // richTextLog
            // 
            this.richTextLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextLog.DetectUrls = false;
            this.richTextLog.Location = new System.Drawing.Point(6, 19);
            this.richTextLog.Name = "richTextLog";
            this.richTextLog.ReadOnly = true;
            this.richTextLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextLog.Size = new System.Drawing.Size(336, 130);
            this.richTextLog.TabIndex = 0;
            this.richTextLog.Text = "";
            // 
            // timUpdate
            // 
            this.timUpdate.Interval = 150;
            this.timUpdate.Tick += new System.EventHandler(this.timUpdate_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Texture Path";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTexturePath
            // 
            this.textBoxTexturePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxTexturePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTexturePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTexturePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTexturePath.ForeColor = System.Drawing.Color.White;
            this.textBoxTexturePath.Location = new System.Drawing.Point(408, 450);
            this.textBoxTexturePath.Name = "textBoxTexturePath";
            this.textBoxTexturePath.Size = new System.Drawing.Size(231, 21);
            this.textBoxTexturePath.TabIndex = 25;
            // 
            // VMTGeneratorToolWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 472);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTexturePath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFile);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupVTFFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.groupParameters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxShaderList);
            this.Name = "VMTGeneratorToolWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VMT Generator";
            this.Controls.SetChildIndex(this.comboBoxShaderList, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupParameters, 0);
            this.Controls.SetChildIndex(this.textBoxPrefix, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupVTFFiles, 0);
            this.Controls.SetChildIndex(this.btnGenerate, 0);
            this.Controls.SetChildIndex(this.groupBoxFile, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.textBoxTexturePath, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.groupParameters.ResumeLayout(false);
            this.groupVTFFiles.ResumeLayout(false);
            this.groupBoxFile.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxShaderList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupParameters;
        private System.Windows.Forms.CheckedListBox checkListParams;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupVTFFiles;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ListBox listBoxFiles;
        private Controls.PixelAnimatedButton btnGenerate;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.RichTextBox richTextFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextLog;
        private System.Windows.Forms.Timer timUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTexturePath;
    }
}