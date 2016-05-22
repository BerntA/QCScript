namespace QScript.GUI
{
    partial class InfoDialogForm
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
            this.buttonClose = new QScript.Controls.PixelAnimatedButton();
            this.labelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(220, 75);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 17);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Txt = "Ok";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelText
            // 
            this.labelText.Location = new System.Drawing.Point(12, 20);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(476, 57);
            this.labelText.TabIndex = 3;
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 100);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelText);
            this.Name = "InfoDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.labelText, 0);
            this.Controls.SetChildIndex(this.buttonClose, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PixelAnimatedButton buttonClose;
        private System.Windows.Forms.Label labelText;

    }
}