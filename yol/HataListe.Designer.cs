namespace yol
{
    partial class HataListe
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
            this.errorsList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // errorsList
            // 
            this.errorsList.FormattingEnabled = true;
            this.errorsList.Location = new System.Drawing.Point(3, 3);
            this.errorsList.Name = "errorsList";
            this.errorsList.Size = new System.Drawing.Size(120, 433);
            this.errorsList.TabIndex = 0;
            // 
            // HataListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 450);
            this.Controls.Add(this.errorsList);
            this.Name = "HataListe";
            this.Text = "HataListe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox errorsList;
    }
}