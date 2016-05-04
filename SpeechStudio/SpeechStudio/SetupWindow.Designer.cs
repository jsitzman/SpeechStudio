namespace SpeechStudio
{
    partial class SetupWindow
    {
        //Required designer variable.
        private System.ComponentModel.IContainer components = null;

        //Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        private void InitializeComponent()
        {
            this.But_Back = new System.Windows.Forms.Button();
            this.But_Comfirm = new System.Windows.Forms.Button();
            this.PPT_box = new System.Windows.Forms.TextBox();
            this.PPT_Label = new System.Windows.Forms.Label();
            this.PPT_Browse = new System.Windows.Forms.Button();
            this.ppt_open = new System.Windows.Forms.OpenFileDialog();
            this.Ch_Kinect = new System.Windows.Forms.CheckBox();
            this.Ch_Time = new System.Windows.Forms.CheckBox();
            this.Time_Label = new System.Windows.Forms.Label();
            this.out_box = new System.Windows.Forms.TextBox();
            this.Dir_Label = new System.Windows.Forms.Label();
            this.Dir_Browse = new System.Windows.Forms.Button();
            this.Output_Open = new System.Windows.Forms.FolderBrowserDialog();
            this.Proj_Label = new System.Windows.Forms.Label();
            this.Proj_Name = new System.Windows.Forms.TextBox();
            this.Time_Value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Time_Value)).BeginInit();
            this.SuspendLayout();
            // 
            // But_Back
            // 
            this.But_Back.Location = new System.Drawing.Point(436, 495);
            this.But_Back.Name = "But_Back";
            this.But_Back.Size = new System.Drawing.Size(108, 42);
            this.But_Back.TabIndex = 0;
            this.But_Back.Text = "Back";
            this.But_Back.UseVisualStyleBackColor = true;
            this.But_Back.Click += new System.EventHandler(this.But_Back_Click);
            // 
            // But_Comfirm
            // 
            this.But_Comfirm.Location = new System.Drawing.Point(262, 495);
            this.But_Comfirm.Name = "But_Comfirm";
            this.But_Comfirm.Size = new System.Drawing.Size(108, 42);
            this.But_Comfirm.TabIndex = 1;
            this.But_Comfirm.Text = "Continue";
            this.But_Comfirm.UseVisualStyleBackColor = true;
            this.But_Comfirm.Click += new System.EventHandler(this.But_Comfirm_Click);
            // 
            // PPT_box
            // 
            this.PPT_box.Location = new System.Drawing.Point(12, 33);
            this.PPT_box.Margin = new System.Windows.Forms.Padding(5);
            this.PPT_box.Name = "PPT_box";
            this.PPT_box.Size = new System.Drawing.Size(608, 31);
            this.PPT_box.TabIndex = 2;
            // 
            // PPT_Label
            // 
            this.PPT_Label.AutoSize = true;
            this.PPT_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPT_Label.Location = new System.Drawing.Point(14, 9);
            this.PPT_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PPT_Label.Name = "PPT_Label";
            this.PPT_Label.Size = new System.Drawing.Size(168, 25);
            this.PPT_Label.TabIndex = 3;
            this.PPT_Label.Text = "PowerPoint File:";
            // 
            // PPT_Browse
            // 
            this.PPT_Browse.Location = new System.Drawing.Point(628, 35);
            this.PPT_Browse.Name = "PPT_Browse";
            this.PPT_Browse.Size = new System.Drawing.Size(87, 27);
            this.PPT_Browse.TabIndex = 4;
            this.PPT_Browse.Text = "Browse";
            this.PPT_Browse.UseVisualStyleBackColor = true;
            this.PPT_Browse.Click += new System.EventHandler(this.PPT_Browse_Click);
            // 
            // ppt_open
            // 
            this.ppt_open.FileName = "openFileDialog1";
            this.ppt_open.Filter = "Powerpoint Files|*.pptx";
            // 
            // Ch_Kinect
            // 
            this.Ch_Kinect.AutoSize = true;
            this.Ch_Kinect.Location = new System.Drawing.Point(18, 443);
            this.Ch_Kinect.Name = "Ch_Kinect";
            this.Ch_Kinect.Size = new System.Drawing.Size(171, 29);
            this.Ch_Kinect.TabIndex = 10;
            this.Ch_Kinect.Text = "Enable Kinect";
            this.Ch_Kinect.UseVisualStyleBackColor = true;
            this.Ch_Kinect.CheckedChanged += new System.EventHandler(this.Ch_Kinect_CheckedChanged);
            // 
            // Ch_Time
            // 
            this.Ch_Time.AutoSize = true;
            this.Ch_Time.Location = new System.Drawing.Point(18, 349);
            this.Ch_Time.Name = "Ch_Time";
            this.Ch_Time.Size = new System.Drawing.Size(136, 29);
            this.Ch_Time.TabIndex = 11;
            this.Ch_Time.Text = "Time Limit";
            this.Ch_Time.UseVisualStyleBackColor = true;
            this.Ch_Time.CheckedChanged += new System.EventHandler(this.Ch_Time_CheckedChanged);
            // 
            // Time_Label
            // 
            this.Time_Label.AutoSize = true;
            this.Time_Label.Location = new System.Drawing.Point(257, 350);
            this.Time_Label.Name = "Time_Label";
            this.Time_Label.Size = new System.Drawing.Size(58, 25);
            this.Time_Label.TabIndex = 13;
            this.Time_Label.Text = "Mins";
            // 
            // out_box
            // 
            this.out_box.Location = new System.Drawing.Point(12, 162);
            this.out_box.Name = "out_box";
            this.out_box.Size = new System.Drawing.Size(608, 31);
            this.out_box.TabIndex = 14;
            // 
            // Dir_Label
            // 
            this.Dir_Label.AutoSize = true;
            this.Dir_Label.Location = new System.Drawing.Point(14, 134);
            this.Dir_Label.Name = "Dir_Label";
            this.Dir_Label.Size = new System.Drawing.Size(174, 25);
            this.Dir_Label.TabIndex = 15;
            this.Dir_Label.Text = "Output Directory:";
            // 
            // Dir_Browse
            // 
            this.Dir_Browse.Location = new System.Drawing.Point(628, 160);
            this.Dir_Browse.Name = "Dir_Browse";
            this.Dir_Browse.Size = new System.Drawing.Size(87, 27);
            this.Dir_Browse.TabIndex = 16;
            this.Dir_Browse.Text = "Browse";
            this.Dir_Browse.UseVisualStyleBackColor = true;
            this.Dir_Browse.Click += new System.EventHandler(this.But_output_Click);
            // 
            // Proj_Label
            // 
            this.Proj_Label.AutoSize = true;
            this.Proj_Label.Location = new System.Drawing.Point(14, 259);
            this.Proj_Label.Name = "Proj_Label";
            this.Proj_Label.Size = new System.Drawing.Size(141, 25);
            this.Proj_Label.TabIndex = 17;
            this.Proj_Label.Text = "Project Name";
            // 
            // Proj_Name
            // 
            this.Proj_Name.Location = new System.Drawing.Point(210, 253);
            this.Proj_Name.Name = "Proj_Name";
            this.Proj_Name.Size = new System.Drawing.Size(368, 31);
            this.Proj_Name.TabIndex = 18;
            // 
            // Time_Value
            // 
            this.Time_Value.Location = new System.Drawing.Point(131, 348);
            this.Time_Value.Name = "Time_Value";
            this.Time_Value.Size = new System.Drawing.Size(120, 31);
            this.Time_Value.TabIndex = 19;
            // 
            // SetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 555);
            this.Controls.Add(this.Time_Value);
            this.Controls.Add(this.Proj_Name);
            this.Controls.Add(this.Proj_Label);
            this.Controls.Add(this.Dir_Browse);
            this.Controls.Add(this.Dir_Label);
            this.Controls.Add(this.out_box);
            this.Controls.Add(this.Time_Label);
            this.Controls.Add(this.Ch_Time);
            this.Controls.Add(this.Ch_Kinect);
            this.Controls.Add(this.PPT_Browse);
            this.Controls.Add(this.PPT_Label);
            this.Controls.Add(this.PPT_box);
            this.Controls.Add(this.But_Comfirm);
            this.Controls.Add(this.But_Back);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.SetupWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Time_Value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button But_Back;
        private System.Windows.Forms.Button But_Comfirm;
        private System.Windows.Forms.TextBox PPT_box;
        private System.Windows.Forms.Label PPT_Label;
        private System.Windows.Forms.Button PPT_Browse;
        private System.Windows.Forms.OpenFileDialog ppt_open;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.TextBox Ol_Box;
        //private System.Windows.Forms.Button Browse2;
        //private System.Windows.Forms.OpenFileDialog Ol_Open;
        //private System.Windows.Forms.CheckBox PPT_check;
        //private System.Windows.Forms.CheckBox Ol_check;
        private System.Windows.Forms.CheckBox Ch_Kinect;
        private System.Windows.Forms.CheckBox Ch_Time;
        private System.Windows.Forms.Label Time_Label;
        private System.Windows.Forms.TextBox out_box;
        private System.Windows.Forms.Label Dir_Label;
        private System.Windows.Forms.Button Dir_Browse;
        private System.Windows.Forms.FolderBrowserDialog Output_Open;
        private System.Windows.Forms.Label Proj_Label;
        private System.Windows.Forms.TextBox Proj_Name;
        private System.Windows.Forms.NumericUpDown Time_Value;
    }
}