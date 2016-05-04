namespace SpeechStudio
{
    partial class MainWindow
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.S_But_Setting = new System.Windows.Forms.ToolStripButton();
            this.But_Outline = new System.Windows.Forms.ToolStripButton();
            this.But_PowerPoint = new System.Windows.Forms.ToolStripButton();
            this.But_OpenPPT = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.But_Start_Record = new System.Windows.Forms.ToolStripButton();
            this.Time_Overall = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.But_Previous = new System.Windows.Forms.ToolStripButton();
            this.But_Next = new System.Windows.Forms.ToolStripButton();
            this.Timer_Siles = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.Page_label = new System.Windows.Forms.ToolStripLabel();
            this.pictureBoxPowerPointPic = new System.Windows.Forms.PictureBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pvideo = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvideo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.S_But_Setting,
            this.But_Outline,
            this.But_PowerPoint,
            this.But_OpenPPT,
            this.toolStripComboBox1,
            this.toolStripLabel1,
            this.But_Start_Record,
            this.Time_Overall});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
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
            // 
            // But_PowerPoint
            // 
            this.But_PowerPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_PowerPoint.Image = global::SpeechStudio.Properties.Resources.microsoft_powerpoint_icon;
            this.But_PowerPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_PowerPoint.Name = "But_PowerPoint";
            this.But_PowerPoint.Size = new System.Drawing.Size(28, 28);
            this.But_PowerPoint.Text = "toolStripButton2";
            this.But_PowerPoint.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // But_OpenPPT
            // 
            this.But_OpenPPT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_OpenPPT.Image = global::SpeechStudio.Properties.Resources.icon_pptx_256;
            this.But_OpenPPT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_OpenPPT.Name = "But_OpenPPT";
            this.But_OpenPPT.Size = new System.Drawing.Size(28, 28);
            this.But_OpenPPT.Text = "toolStripButton2";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 28);
            // 
            // But_Start_Record
            // 
            this.But_Start_Record.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.But_Start_Record.Image = global::SpeechStudio.Properties.Resources.Icons_Land_Play_Stop_Pause_Record_Pressed;
            this.But_Start_Record.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.But_Start_Record.Name = "But_Start_Record";
            this.But_Start_Record.Size = new System.Drawing.Size(28, 28);
            this.But_Start_Record.Text = "toolStripButton5";
            this.But_Start_Record.Click += new System.EventHandler(this.But_Start_Record_Click);
            // 
            // Time_Overall
            // 
            this.Time_Overall.Name = "Time_Overall";
            this.Time_Overall.Size = new System.Drawing.Size(44, 28);
            this.Time_Overall.Text = "00:00";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1238, 811);
            this.splitContainer1.SplitterDistance = 548;
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
            this.splitContainer2.Panel2.Controls.Add(this.pvideo);
            this.splitContainer2.Size = new System.Drawing.Size(1238, 548);
            this.splitContainer2.SplitterDistance = 594;
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
            this.Page_label});
            this.toolStrip2.Location = new System.Drawing.Point(0, 521);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(594, 27);
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
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 24);
            this.toolStripLabel2.Text = "PAGE:";
            // 
            // Page_label
            // 
            this.Page_label.Name = "Page_label";
            this.Page_label.Size = new System.Drawing.Size(17, 24);
            this.Page_label.Text = "0";
            // 
            // pictureBoxPowerPointPic
            // 
            this.pictureBoxPowerPointPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPowerPointPic.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPowerPointPic.Name = "pictureBoxPowerPointPic";
            this.pictureBoxPowerPointPic.Size = new System.Drawing.Size(594, 548);
            this.pictureBoxPowerPointPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPowerPointPic.TabIndex = 0;
            this.pictureBoxPowerPointPic.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listBoxMessage);
            this.splitContainer3.Size = new System.Drawing.Size(1238, 255);
            this.splitContainer3.SplitterDistance = 80;
            this.splitContainer3.SplitterWidth = 8;
            this.splitContainer3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 69);
            this.label1.TabIndex = 2;
            this.label1.Text = "No Guesture";
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.ItemHeight = 20;
            this.listBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(1238, 167);
            this.listBoxMessage.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Powerpoint Files|*.pptx";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // pvideo
            // 
            this.pvideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvideo.Location = new System.Drawing.Point(0, 0);
            this.pvideo.Name = "pvideo";
            this.pvideo.Size = new System.Drawing.Size(636, 548);
            this.pvideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pvideo.TabIndex = 0;
            this.pvideo.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 842);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPowerPointPic)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton S_But_Setting;
        private System.Windows.Forms.ToolStripButton But_Outline;
        private System.Windows.Forms.ToolStripButton But_PowerPoint;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton But_Previous;
        private System.Windows.Forms.ToolStripButton But_Next;
        private System.Windows.Forms.PictureBox pictureBoxPowerPointPic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.ToolStripButton But_OpenPPT;
        private System.Windows.Forms.ToolStripButton But_Start_Record;
        private System.Windows.Forms.ToolStripLabel Time_Overall;
        private System.Windows.Forms.ToolStripLabel Timer_Siles;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel Page_label;
        private System.Windows.Forms.PictureBox pvideo;
    }
}