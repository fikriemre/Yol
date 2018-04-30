namespace yol
{
    partial class FormPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPopup));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beforeButton = new System.Windows.Forms.ToolStripButton();
            this.nextButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.KesitGoster0 = new System.Windows.Forms.Panel();
            this.KesitGoster1 = new System.Windows.Forms.Panel();
            this.KesitGoster2 = new System.Windows.Forms.Panel();
            this.Hatalarlistbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectionBackGround = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInButton,
            this.zoomOutButton,
            this.toolStripSeparator1,
            this.beforeButton,
            this.nextButton,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(545, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(155, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(23, 22);
            this.zoomInButton.Text = "+";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // beforeButton
            // 
            this.beforeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.beforeButton.Image = ((System.Drawing.Image)(resources.GetObject("beforeButton.Image")));
            this.beforeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.beforeButton.Name = "beforeButton";
            this.beforeButton.Size = new System.Drawing.Size(34, 22);
            this.beforeButton.Text = "Prev";
            this.beforeButton.Click += new System.EventHandler(this.beforeButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(35, 22);
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(31, 22);
            this.toolStripButton1.Text = "Edit";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // KesitGoster0
            // 
            this.KesitGoster0.AutoScroll = true;
            this.KesitGoster0.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KesitGoster0.Location = new System.Drawing.Point(236, 25);
            this.KesitGoster0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KesitGoster0.Name = "KesitGoster0";
            this.KesitGoster0.Size = new System.Drawing.Size(700, 175);
            this.KesitGoster0.TabIndex = 1;
            this.KesitGoster0.Paint += new System.Windows.Forms.PaintEventHandler(this.KesitGoster0_Paint);
            // 
            // KesitGoster1
            // 
            this.KesitGoster1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KesitGoster1.Location = new System.Drawing.Point(236, 240);
            this.KesitGoster1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KesitGoster1.Name = "KesitGoster1";
            this.KesitGoster1.Size = new System.Drawing.Size(700, 175);
            this.KesitGoster1.TabIndex = 1;
            this.KesitGoster1.Paint += new System.Windows.Forms.PaintEventHandler(this.KesitGoster1_Paint);
            // 
            // KesitGoster2
            // 
            this.KesitGoster2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KesitGoster2.Location = new System.Drawing.Point(236, 429);
            this.KesitGoster2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KesitGoster2.Name = "KesitGoster2";
            this.KesitGoster2.Size = new System.Drawing.Size(700, 175);
            this.KesitGoster2.TabIndex = 1;
            this.KesitGoster2.Paint += new System.Windows.Forms.PaintEventHandler(this.KesitGoster2_Paint);
            // 
            // Hatalarlistbox
            // 
            this.Hatalarlistbox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Hatalarlistbox.DisplayMember = "baslangic";
            this.Hatalarlistbox.FormattingEnabled = true;
            this.Hatalarlistbox.Location = new System.Drawing.Point(11, 25);
            this.Hatalarlistbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Hatalarlistbox.Name = "Hatalarlistbox";
            this.Hatalarlistbox.Size = new System.Drawing.Size(200, 576);
            this.Hatalarlistbox.TabIndex = 2;
            this.Hatalarlistbox.ValueMember = "baslangic";
            this.Hatalarlistbox.SelectedIndexChanged += new System.EventHandler(this.Hatalarlistbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hatalar";
            // 
            // SelectionBackGround
            // 
            this.SelectionBackGround.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.SelectionBackGround.Location = new System.Drawing.Point(227, 205);
            this.SelectionBackGround.Name = "SelectionBackGround";
            this.SelectionBackGround.Size = new System.Drawing.Size(720, 220);
            this.SelectionBackGround.TabIndex = 0;
            // 
            // FormPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(984, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hatalarlistbox);
            this.Controls.Add(this.KesitGoster2);
            this.Controls.Add(this.KesitGoster1);
            this.Controls.Add(this.KesitGoster0);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SelectionBackGround);
            this.Name = "FormPopup";
            this.Text = "FormPopup";
            this.Load += new System.EventHandler(this.FormPopup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPopup_Paint);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton nextButton;
        private System.Windows.Forms.ToolStripButton beforeButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel KesitGoster0;
        private System.Windows.Forms.Panel KesitGoster1;
        private System.Windows.Forms.Panel KesitGoster2;
        private System.Windows.Forms.ListBox Hatalarlistbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel SelectionBackGround;
    }
}