namespace QScript.GUI
{
    partial class AnimationReversionToolWizard
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
            this.btnReverse = new QScript.Controls.PixelAnimatedButton();
            this.btnBrowseIn = new QScript.Controls.PixelAnimatedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseOut = new QScript.Controls.PixelAnimatedButton();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReverse
            // 
            this.btnReverse.BackColor = System.Drawing.Color.Transparent;
            this.btnReverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReverse.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReverse.ForeColor = System.Drawing.Color.White;
            this.btnReverse.Location = new System.Drawing.Point(413, 85);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(74, 25);
            this.btnReverse.TabIndex = 15;
            this.btnReverse.Txt = "Execute";
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnBrowseIn
            // 
            this.btnBrowseIn.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseIn.ForeColor = System.Drawing.Color.White;
            this.btnBrowseIn.Location = new System.Drawing.Point(278, 45);
            this.btnBrowseIn.Name = "btnBrowseIn";
            this.btnBrowseIn.Size = new System.Drawing.Size(103, 16);
            this.btnBrowseIn.TabIndex = 18;
            this.btnBrowseIn.Txt = "Browse...";
            this.btnBrowseIn.Click += new System.EventHandler(this.btnBrowseIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Input";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxInput
            // 
            this.textBoxInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxInput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.ForeColor = System.Drawing.Color.White;
            this.textBoxInput.Location = new System.Drawing.Point(12, 40);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(260, 21);
            this.textBoxInput.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Output";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseOut
            // 
            this.btnBrowseOut.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowseOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowseOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseOut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseOut.ForeColor = System.Drawing.Color.White;
            this.btnBrowseOut.Location = new System.Drawing.Point(281, 85);
            this.btnBrowseOut.Name = "btnBrowseOut";
            this.btnBrowseOut.Size = new System.Drawing.Size(103, 16);
            this.btnBrowseOut.TabIndex = 21;
            this.btnBrowseOut.Txt = "Browse...";
            this.btnBrowseOut.Click += new System.EventHandler(this.btnBrowseOut_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.textBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxOutput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutput.ForeColor = System.Drawing.Color.White;
            this.textBoxOutput.Location = new System.Drawing.Point(15, 80);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(260, 21);
            this.textBoxOutput.TabIndex = 20;
            // 
            // AnimationReversionToolWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 118);
            this.Controls.Add(this.btnBrowseOut);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.btnReverse);
            this.Name = "AnimationReversionToolWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reverse Animation (SMD)";
            this.Controls.SetChildIndex(this.btnReverse, 0);
            this.Controls.SetChildIndex(this.textBoxInput, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnBrowseIn, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBoxOutput, 0);
            this.Controls.SetChildIndex(this.btnBrowseOut, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.PixelAnimatedButton btnReverse;
        private Controls.PixelAnimatedButton btnBrowseIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label label2;
        private Controls.PixelAnimatedButton btnBrowseOut;
        private System.Windows.Forms.TextBox textBoxOutput;
    }
}