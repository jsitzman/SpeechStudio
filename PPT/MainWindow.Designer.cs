namespace SpeechStudio
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.C:\dev482\csce482-speech\csce482-speech\SpeechStudio\Feedback_2\main_feedback.cs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.S_But_Setting = new System.Windows.Forms.ToolStripButton();
            this.But_Outline = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Playback = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.But_Previous = new System.Windows.Forms.ToolStripButton();
            this.But_Next = new System.Windows.Forms.ToolStripButton();
            this.Timer_Siles = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.Page_label = new System.Windows.Forms.ToolStripLabel();
            this.pptStats = new System.Windows.Forms.ToolStripButton();
            this.pptSelect = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxPowerPointPic = new System.Windows.Forms.PictureBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.But_Start_Record = new System.Windows.Forms.ToolStripButton();
            this.Time_Overall = new System.Windows.Forms.ToolStripLabel();
            this.kinectToggler = new System.Windows.Forms.ToolStripButton();
            this.Time_Count_D = new System.Windows.Forms.Label();
            this.pvideo = new System.Windows.Forms.PictureBox();
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPowerPointPic)).BeginInit();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvideo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.S_But_Setting,
            this.But_Outline,
            this.toolStripLabel1,
            this.Playback});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1238, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // S_But_Setting
            // 
            this.S_But_Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.S_But_Setting.Image = global::SpeechStudio.Properties.Resources._19721;
            this.S_But_Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.S_But_Setting.Name = "S_But_Setting";
            this.S_But_Setting.Size = new System.Drawing.Size(28, 28);
            this.S_But_Setting.Text = "toolStripButton1";
            this.S_But_Setting.ToolTipText = "Setup/Settings";
            this.S_But_Setting.Click += new System.EventHandler(this.S_But_Setting_Click);
            // 
            // But_Outline
            // 
            this.But_Outline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_Outline.Image = global::SpeechStudio.Properties.Resources.debug_outline_icon;
            this.But_Outline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_Outline.Name = "But_Outline";
            this.But_Outline.Size = new System.Drawing.Size(28, 28);
            this.But_Outline.Text = "toolStripButton1";
            this.But_Outline.ToolTipText = "Outline";
            this.But_Outline.Click += new System.EventHandler(this.But_Outline_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 28);
            // 
            // Playback
            // 
            this.Playback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Playback.Image = global::SpeechStudio.Properties.Resources.redo_grey_512;
            this.Playback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Playback.Name = "Playback";
            this.Playback.Size = new System.Drawing.Size(28, 28);
            this.Playback.Text = "toolStripButton1";
            this.Playback.ToolTipText = "playback";
            this.Playback.Click += new System.EventHandler(this.Playback_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxMessage);
            this.splitContainer1.Size = new System.Drawing.Size(1238, 620);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxPowerPointPic);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip3);
            this.splitContainer2.Panel2.Controls.Add(this.Time_Count_D);
            this.splitContainer2.Panel2.Controls.Add(this.pvideo);
            this.splitContainer2.Size = new System.Drawing.Size(1238, 458);
            this.splitContainer2.SplitterDistance = 605;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.But_Previous,
            this.But_Next,
            this.Timer_Siles,
            this.toolStripLabel2,
            this.Page_label,
            this.pptStats,
            this.pptSelect});
            this.toolStrip2.Location = new System.Drawing.Point(0, 431);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(605, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // But_Previous
            // 
            this.But_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_Previous.Image = global::SpeechStudio.Properties.Resources.Actions_go_previous_icon;
            this.But_Previous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_Previous.Name = "But_Previous";
            this.But_Previous.Size = new System.Drawing.Size(24, 24);
            this.But_Previous.Text = "toolStripButton3";
            this.But_Previous.ToolTipText = "Previous Slide";
            this.But_Previous.Click += new System.EventHandler(this.But_Previous_Click);
            // 
            // But_Next
            // 
            this.But_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_Next.Image = global::SpeechStudio.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_next;
            this.But_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_Next.Name = "But_Next";
            this.But_Next.Size = new System.Drawing.Size(24, 24);
            this.But_Next.Text = "toolStripButton4";
            this.But_Next.ToolTipText = "Next Slide";
            this.But_Next.Click += new System.EventHandler(this.But_Next_Click);
            // 
            // Timer_Siles
            // 
            this.Timer_Siles.Name = "Timer_Siles";
            this.Timer_Siles.Size = new System.Drawing.Size(34, 24);
            this.Timer_Siles.Text = "00:00";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 24);
            this.toolStripLabel2.Text = "PAGE:";
            // 
            // Page_label
            // 
            this.Page_label.Name = "Page_label";
            this.Page_label.Size = new System.Drawing.Size(13, 24);
            this.Page_label.Text = "0";
            // 
            // pptStats
            // 
            this.pptStats.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pptStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pptStats.Image = global::SpeechStudio.Properties.Resources.microsoft_powerpoint_icon;
            this.pptStats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pptStats.Name = "pptStats";
            this.pptStats.Size = new System.Drawing.Size(24, 24);
            this.pptStats.Text = "toolStripButton1";
            this.pptStats.ToolTipText = "PowerPoint Statistics Display";
            this.pptStats.Click += new System.EventHandler(this.pptStats_Click);
            // 
            // pptSelect
            // 
            this.pptSelect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pptSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pptSelect.Image = global::SpeechStudio.Properties.Resources.icon_pptx_256;
            this.pptSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pptSelect.Name = "pptSelect";
            this.pptSelect.Size = new System.Drawing.Size(24, 24);
            this.pptSelect.Text = "toolStripButton2";
            this.pptSelect.ToolTipText = "Change PowerPoint";
            this.pptSelect.Click += new System.EventHandler(this.pptSelect_Click);
            // 
            // pictureBoxPowerPointPic
            // 
            this.pictureBoxPowerPointPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPowerPointPic.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPowerPointPic.Name = "pictureBoxPowerPointPic";
            this.pictureBoxPowerPointPic.Size = new System.Drawing.Size(605, 458);
            this.pictureBoxPowerPointPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPowerPointPic.TabIndex = 0;
            this.pictureBoxPowerPointPic.TabStop = false;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.But_Start_Record,
            this.Time_Overall,
            this.kinectToggler});
            this.toolStrip3.Location = new System.Drawing.Point(0, 433);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(625, 25);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // But_Start_Record
            // 
            this.But_Start_Record.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_Start_Record.Image = global::SpeechStudio.Properties.Resources.Icons_Land_Play_Stop_Pause_Record_Pressed;
            this.But_Start_Record.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_Start_Record.Name = "But_Start_Record";
            this.But_Start_Record.Size = new System.Drawing.Size(23, 22);
            this.But_Start_Record.Text = "toolStripButton5";
            this.But_Start_Record.ToolTipText = "Start/Stop Capture";
            this.But_Start_Record.Click += new System.EventHandler(this.But_Start_Record_Click);
            // 
            // Time_Overall
            // 
            this.Time_Overall.Name = "Time_Overall";
            this.Time_Overall.Size = new System.Drawing.Size(34, 22);
            this.Time_Overall.Text = "00:00";
            // 
            // kinectToggler
            // 
            this.kinectToggler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kinectToggler.Image = ((System.Drawing.Image)(resources.GetObject("kinectToggler.Image")));
            this.kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kinectToggler.Name = "kinectToggler";
            this.kinectToggler.Size = new System.Drawing.Size(23, 22);
            this.kinectToggler.Text = "kinectToggler";
            this.kinectToggler.ToolTipText = "Click to Enable Kinect";
            this.kinectToggler.Click += new System.EventHandler(this.kinectToggler_Click);
            // 
            // Time_Count_D
            // 
            this.Time_Count_D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Time_Count_D.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_Count_D.Location = new System.Drawing.Point(-2, 0);
            this.Time_Count_D.Name = "Time_Count_D";
            this.Time_Count_D.Size = new System.Drawing.Size(61, 53);
            this.Time_Count_D.TabIndex = 2;
            // 
            // pvideo
            // 
            this.pvideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvideo.Location = new System.Drawing.Point(0, 0);
            this.pvideo.Name = "pvideo";
            this.pvideo.Size = new System.Drawing.Size(625, 458);
            this.pvideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pvideo.TabIndex = 0;
            this.pvideo.TabStop = false;
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.ItemHeight = 17;
            this.listBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(1238, 154);
            this.listBoxMessage.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Powerpoint Files|*.pptx";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.loadToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 675);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPowerPointPic)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvideo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton S_But_Setting;
        private System.Windows.Forms.ToolStripButton But_Outline;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton But_Previous;
        private System.Windows.Forms.ToolStripButton But_Next;
        private System.Windows.Forms.PictureBox pictureBoxPowerPointPic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Time_Count_D;
        private System.Windows.Forms.ToolStripLabel Timer_Siles;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel Page_label;
        private System.Windows.Forms.PictureBox pvideo;
        private System.Windows.Forms.ToolStripButton Playback;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton But_Start_Record;
        private System.Windows.Forms.ToolStripLabel Time_Overall;
        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.ToolStripButton pptSelect;
        private System.Windows.Forms.ToolStripButton pptStats;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton kinectToggler;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}