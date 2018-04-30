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
            this.kesitisim1 = new System.Windows.Forms.Label();
            this.Kesitisim2 = new System.Windows.Forms.Label();
            this.Kesitisim0 = new System.Windows.Forms.Label();
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
            this.toolStrip1.Location = new System.Drawing.Point(315, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(179, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(23, 24);
            this.zoomInButton.Text = "+";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(23, 24);
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // beforeButton
            // 
            this.beforeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.beforeButton.Image = ((System.Drawing.Image)(resources.GetObject("beforeButton.Image")));
            this.beforeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.beforeButton.Name = "beforeButton";
            this.beforeButton.Size = new System.Drawing.Size(41, 24);
            this.beforeButton.Text = "Prev";
            this.beforeButton.Click += new System.EventHandler(this.beforeButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(44, 24);
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 24);
            this.toolStripButton1.Text = "Edit";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // KesitGoster0
            // 
            this.KesitGoster0.AutoScroll = true;
            this.KesitGoster0.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KesitGoster0.Location = new System.Drawing.Point(315, 43);
            this.KesitGoster0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KesitGoster0.Name = "KesitGoster0";
            this.KesitGoster0.Size = new System.Drawing.Size(933, 215);
            this.KesitGoster0.TabIndex = 1;
            this.KesitGoster0.Paint += new System.Windows.Forms.PaintEventHandler(this.KesitGoster0_Paint);
            // 
            // KesitGoster1
            // 
            this.KesitGoster1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KesitGoster1.Location = new System.Drawing.Point(315, 301);
            this.KesitGoster1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KesitGoster1.Name = "KesitGoster1";
            this.KesitGoster1.Size = new System.Drawing.Size(933, 215);
            this.KesitGoster1.TabIndex = 1;
            this.KesitGoster1.Paint += new System.Windows.Forms.PaintEventHandler(this.KesitGoster1_Paint);
            // 
            // KesitGoster2
            // 
            this.KesitGoster2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KesitGoster2.Location = new System.Drawing.Point(315, 559);
            this.KesitGoster2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KesitGoster2.Name = "KesitGoster2";
            this.KesitGoster2.Size = new System.Drawing.Size(933, 215);
            this.KesitGoster2.TabIndex = 1;
            this.KesitGoster2.Paint += new System.Windows.Forms.PaintEventHandler(this.KesitGoster2_Paint);
            // 
            // Hatalarlistbox
            // 
            this.Hatalarlistbox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Hatalarlistbox.DisplayMember = "baslangic";
            this.Hatalarlistbox.FormattingEnabled = true;
            this.Hatalarlistbox.ItemHeight = 16;
            this.Hatalarlistbox.Location = new System.Drawing.Point(15, 31);
            this.Hatalarlistbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Hatalarlistbox.Name = "Hatalarlistbox";
            this.Hatalarlistbox.Size = new System.Drawing.Size(265, 740);
            this.Hatalarlistbox.TabIndex = 2;
            this.Hatalarlistbox.ValueMember = "baslangic";
            this.Hatalarlistbox.SelectedIndexChanged += new System.EventHandler(this.Hatalarlistbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hatalar";
            // 
            // kesitisim1
            // 
            this.kesitisim1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kesitisim1.AutoSize = true;
            this.kesitisim1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kesitisim1.ForeColor = System.Drawing.Color.Red;
            this.kesitisim1.Location = new System.Drawing.Point(720, 260);
            this.kesitisim1.Name = "kesitisim1";
            this.kesitisim1.Size = new System.Drawing.Size(109, 39);
            this.kesitisim1.TabIndex = 0;
            this.kesitisim1.Text = "label2";
            // 
            // Kesitisim2
            // 
            this.Kesitisim2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Kesitisim2.AutoSize = true;
            this.Kesitisim2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesitisim2.ForeColor = System.Drawing.Color.Red;
            this.Kesitisim2.Location = new System.Drawing.Point(720, 518);
            this.Kesitisim2.Name = "Kesitisim2";
            this.Kesitisim2.Size = new System.Drawing.Size(109, 39);
            this.Kesitisim2.TabIndex = 0;
            this.Kesitisim2.Text = "label2";
            // 
            // Kesitisim0
            // 
            this.Kesitisim0.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Kesitisim0.AutoSize = true;
            this.Kesitisim0.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Kesitisim0.ForeColor = System.Drawing.Color.Red;
            this.Kesitisim0.Location = new System.Drawing.Point(720, 2);
            this.Kesitisim0.Name = "Kesitisim0";
            this.Kesitisim0.Size = new System.Drawing.Size(109, 39);
            this.Kesitisim0.TabIndex = 0;
            this.Kesitisim0.Text = "label2";
            // 
            // FormPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1312, 795);
            this.Controls.Add(this.Kesitisim2);
            this.Controls.Add(this.Kesitisim0);
            this.Controls.Add(this.kesitisim1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hatalarlistbox);
            this.Controls.Add(this.KesitGoster2);
            this.Controls.Add(this.KesitGoster1);
            this.Controls.Add(this.KesitGoster0);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Label kesitisim1;
        private System.Windows.Forms.Label Kesitisim2;
        private System.Windows.Forms.Label Kesitisim0;
    }
}