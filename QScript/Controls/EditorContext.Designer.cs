namespace QScript.Controls
{
    partial class EditorContext
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
            this.tabEditor = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabEditor
            // 
            this.tabEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEditor.HotTrack = true;
            this.tabEditor.Location = new System.Drawing.Point(0, 0);
            this.tabEditor.Multiline = true;
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.SelectedIndex = 0;
            this.tabEditor.Size = new System.Drawing.Size(350, 350);
            this.tabEditor.TabIndex = 2;
            // 
            // EditorContext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tabEditor);
            this.DoubleBuffered = true;
            this.Name = "EditorContext";
            this.Size = new System.Drawing.Size(350, 350);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabEditor;
    }
}
