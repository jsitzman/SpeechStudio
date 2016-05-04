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
            this.open_loading = new System.Windows.Forms.FolderBrowserDialog();
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
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.But_Outline.Name = "But_Outline";
            this.But_Outline.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(23, 23);
            // 
            // Playback
            // 
            this.Playback.Name = "Playback";
            this.Playback.Size = new System.Drawing.Size(23, 23);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer1.Size = new System.Drawing.Size(1651, 803);
            this.splitContainer1.SplitterDistance = 592;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer2.Size = new System.Drawing.Size(1651, 592);
            this.splitContainer2.SplitterDistance = 806;
            this.splitContainer2.SplitterWidth = 11;
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
            this.toolStrip2.Location = new System.Drawing.Point(0, 565);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(806, 27);
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
            this.Timer_Siles.Size = new System.Drawing.Size(44, 24);
            this.Timer_Siles.Text = "00:00";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(47, 24);
            this.toolStripLabel2.Text = "PAGE:";
            // 
            // Page_label
            // 
            this.Page_label.Name = "Page_label";
            this.Page_label.Size = new System.Drawing.Size(17, 24);
            this.Page_label.Text = "0";
            // 
            // pptStats
            // 
            this.pptStats.Name = "pptStats";
            this.pptStats.Size = new System.Drawing.Size(23, 24);
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
            this.pictureBoxPowerPointPic.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPowerPointPic.Name = "pictureBoxPowerPointPic";
            this.pictureBoxPowerPointPic.Size = new System.Drawing.Size(806, 592);
            this.pictureBoxPowerPointPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPowerPointPic.TabIndex = 0;
            this.pictureBoxPowerPointPic.TabStop = false;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.But_Start_Record,
            this.Time_Overall,
            this.kinectToggler});
            this.toolStrip3.Location = new System.Drawing.Point(0, 565);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(834, 27);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // But_Start_Record
            // 
            this.But_Start_Record.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_Start_Record.Image = global::SpeechStudio.Properties.Resources.Icons_Land_Play_Stop_Pause_Record_Pressed;
            this.But_Start_Record.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_Start_Record.Name = "But_Start_Record";
            this.But_Start_Record.Size = new System.Drawing.Size(24, 24);
            this.But_Start_Record.Text = "toolStripButton5";
            this.But_Start_Record.ToolTipText = "Start/Stop Recording";
            this.But_Start_Record.Click += new System.EventHandler(this.But_Start_Record_Click);
            // 
            // Time_Overall
            // 
            this.Time_Overall.Name = "Time_Overall";
            this.Time_Overall.Size = new System.Drawing.Size(44, 24);
            this.Time_Overall.Text = "00:00";
            // 
            // kinectToggler
            // 
            this.kinectToggler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kinectToggler.Image = ((System.Drawing.Image)(resources.GetObject("kinectToggler.Image")));
            this.kinectToggler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kinectToggler.Name = "kinectToggler";
            this.kinectToggler.Size = new System.Drawing.Size(24, 24);
            this.kinectToggler.Text = "kinectToggler";
            this.kinectToggler.ToolTipText = "Click to Enable Kinect";
            this.kinectToggler.Click += new System.EventHandler(this.kinectToggler_Click);
            // 
            // Time_Count_D
            // 
            this.Time_Count_D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Time_Count_D.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_Count_D.Location = new System.Drawing.Point(-3, 0);
            this.Time_Count_D.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Time_Count_D.Name = "Time_Count_D";
            this.Time_Count_D.Size = new System.Drawing.Size(81, 65);
            this.Time_Count_D.TabIndex = 2;
            // 
            // pvideo
            // 
            this.pvideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvideo.Location = new System.Drawing.Point(0, 0);
            this.pvideo.Margin = new System.Windows.Forms.Padding(4);
            this.pvideo.Name = "pvideo";
            this.pvideo.Size = new System.Drawing.Size(834, 592);
            this.pvideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pvideo.TabIndex = 0;
            this.pvideo.TabStop = false;
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.ItemHeight = 20;
            this.listBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.listBoxMessage.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(1651, 201);
            this.listBoxMessage.TabIndex = 1;
            this.listBoxMessage.SelectedIndexChanged += new System.EventHandler(this.listBoxMessage_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Powerpoint Files|*.pptx";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1651, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "New Project";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.loadToolStripMenuItem1.Text = "Load Project";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.S_But_Setting_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1651, 831);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
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
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog open_loading;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}