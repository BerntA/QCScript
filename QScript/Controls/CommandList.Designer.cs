namespace QScript.Controls
{
    partial class CommandList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textSearch = new System.Windows.Forms.TextBox();
            this.itemList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textSearch
            // 
            this.textSearch.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.textSearch.Location = new System.Drawing.Point(0, 0);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(450, 20);
            this.textSearch.TabIndex = 0;
            // 
            // itemList
            // 
            this.itemList.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.itemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemList.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(0, 20);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(450, 130);
            this.itemList.TabIndex = 2;
            this.itemList.DoubleClick += new System.EventHandler(this.itemList_DoubleClick);
            // 
            // CommandList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.itemList);
            this.Controls.Add(this.textSearch);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "CommandList";
            this.Size = new System.Drawing.Size(450, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.ListBox itemList;
    }
}
