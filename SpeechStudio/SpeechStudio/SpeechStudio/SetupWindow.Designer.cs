namespace SpeechStudio
{
    partial class SetupWindow
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
            this.But_Cancel = new System.Windows.Forms.Button();
            this.But_Comfire = new System.Windows.Forms.Button();
            this.PPT_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.ppt_open = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.Ol_Box = new System.Windows.Forms.TextBox();
            this.Browse2 = new System.Windows.Forms.Button();
            this.Ol_Open = new System.Windows.Forms.OpenFileDialog();
            this.PPT_check = new System.Windows.Forms.CheckBox();
            this.Ol_check = new System.Windows.Forms.CheckBox();
            this.Ch_Kinect = new System.Windows.Forms.CheckBox();
            this.Ch_Time = new System.Windows.Forms.CheckBox();
            this.Time_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.out_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.But_output = new System.Windows.Forms.Button();
            this.Output_Open = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // But_Cancel
            // 
            this.But_Cancel.Location = new System.Drawing.Point(406, 623);
            this.But_Cancel.Name = "But_Cancel";
            this.But_Cancel.Size = new System.Drawing.Size(108, 42);
            this.But_Cancel.TabIndex = 0;
            this.But_Cancel.Text = "Cancel";
            this.But_Cancel.UseVisualStyleBackColor = true;
            this.But_Cancel.Click += new System.EventHandler(this.But_Cancel_Click);
            // 
            // But_Comfire
            // 
            this.But_Comfire.Location = new System.Drawing.Point(292, 623);
            this.But_Comfire.Name = "But_Comfire";
            this.But_Comfire.Size = new System.Drawing.Size(108, 42);
            this.But_Comfire.TabIndex = 1;
            this.But_Comfire.Text = "Comfire";
            this.But_Comfire.UseVisualStyleBackColor = true;
            this.But_Comfire.Click += new System.EventHandler(this.But_Comfire_Click);
            // 
            // PPT_box
            // 
            this.PPT_box.Location = new System.Drawing.Point(12, 110);
            this.PPT_box.Margin = new System.Windows.Forms.Padding(5);
            this.PPT_box.Name = "PPT_box";
            this.PPT_box.Size = new System.Drawing.Size(608, 27);
            this.PPT_box.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Powerpoint File";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(628, 108);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(87, 30);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // ppt_open
            // 
            this.ppt_open.FileName = "openFileDialog1";
            this.ppt_open.Filter = "Powerpoint Files|*.pptx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "OutLine";
            // 
            // Ol_Box
            // 
            this.Ol_Box.Location = new System.Drawing.Point(12, 178);
            this.Ol_Box.Name = "Ol_Box";
            this.Ol_Box.Size = new System.Drawing.Size(610, 27);
            this.Ol_Box.TabIndex = 6;
            // 
            // Browse2
            // 
            this.Browse2.Location = new System.Drawing.Point(628, 178);
            this.Browse2.Name = "Browse2";
            this.Browse2.Size = new System.Drawing.Size(87, 27);
            this.Browse2.TabIndex = 7;
            this.Browse2.Text = "Browse";
            this.Browse2.UseVisualStyleBackColor = true;
            this.Browse2.Click += new System.EventHandler(this.Browse2_Click);
            // 
            // Ol_Open
            // 
            this.Ol_Open.FileName = "openFileDialog1";
            // 
            // PPT_check
            // 
            this.PPT_check.AutoSize = true;
            this.PPT_check.Location = new System.Drawing.Point(146, 81);
            this.PPT_check.Name = "PPT_check";
            this.PPT_check.Size = new System.Drawing.Size(18, 17);
            this.PPT_check.TabIndex = 8;
            this.PPT_check.UseVisualStyleBackColor = true;
            this.PPT_check.CheckedChanged += new System.EventHandler(this.PPT_check_CheckedChanged);
            // 
            // Ol_check
            // 
            this.Ol_check.AutoSize = true;
            this.Ol_check.Location = new System.Drawing.Point(88, 152);
            this.Ol_check.Name = "Ol_check";
            this.Ol_check.Size = new System.Drawing.Size(18, 17);
            this.Ol_check.TabIndex = 9;
            this.Ol_check.UseVisualStyleBackColor = true;
            this.Ol_check.CheckedChanged += new System.EventHandler(this.Ol_check_CheckedChanged);
            // 
            // Ch_Kinect
            // 
            this.Ch_Kinect.AutoSize = true;
            this.Ch_Kinect.Location = new System.Drawing.Point(12, 229);
            this.Ch_Kinect.Name = "Ch_Kinect";
            this.Ch_Kinect.Size = new System.Drawing.Size(134, 24);
            this.Ch_Kinect.TabIndex = 10;
            this.Ch_Kinect.Text = "Enable Kinect";
            this.Ch_Kinect.UseVisualStyleBackColor = true;
            this.Ch_Kinect.CheckedChanged += new System.EventHandler(this.Ch_Kinect_CheckedChanged);
            // 
            // Ch_Time
            // 
            this.Ch_Time.AutoSize = true;
            this.Ch_Time.Location = new System.Drawing.Point(12, 260);
            this.Ch_Time.Name = "Ch_Time";
            this.Ch_Time.Size = new System.Drawing.Size(110, 24);
            this.Ch_Time.TabIndex = 11;
            this.Ch_Time.Text = "Time Limit";
            this.Ch_Time.UseVisualStyleBackColor = true;
            this.Ch_Time.CheckedChanged += new System.EventHandler(this.Ch_Time_CheckedChanged);
            // 
            // Time_box
            // 
            this.Time_box.Location = new System.Drawing.Point(128, 257);
            this.Time_box.Name = "Time_box";
            this.Time_box.Size = new System.Drawing.Size(100, 27);
            this.Time_box.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mins";
            // 
            // out_box
            // 
            this.out_box.Location = new System.Drawing.Point(12, 423);
            this.out_box.Name = "out_box";
            this.out_box.Size = new System.Drawing.Size(608, 27);
            this.out_box.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Output Directory:";
            // 
            // But_output
            // 
            this.But_output.Location = new System.Drawing.Point(627, 423);
            this.But_output.Name = "But_output";
            this.But_output.Size = new System.Drawing.Size(88, 27);
            this.But_output.TabIndex = 16;
            this.But_output.Text = "Browse";
            this.But_output.UseVisualStyleBackColor = true;
            this.But_output.Click += new System.EventHandler(this.But_output_Click);
            // 
            // SetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 677);
            this.Controls.Add(this.But_output);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.out_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Time_box);
            this.Controls.Add(this.Ch_Time);
            this.Controls.Add(this.Ch_Kinect);
            this.Controls.Add(this.Ol_check);
            this.Controls.Add(this.PPT_check);
            this.Controls.Add(this.Browse2);
            this.Controls.Add(this.Ol_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PPT_box);
            this.Controls.Add(this.But_Comfire);
            this.Controls.Add(this.But_Cancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupWindow";
            this.Text = "SetupWindow";
            this.Load += new System.EventHandler(this.SetupWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button But_Cancel;
        private System.Windows.Forms.Button But_Comfire;
        private System.Windows.Forms.TextBox PPT_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog ppt_open;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Ol_Box;
        private System.Windows.Forms.Button Browse2;
        private System.Windows.Forms.OpenFileDialog Ol_Open;
        private System.Windows.Forms.CheckBox PPT_check;
        private System.Windows.Forms.CheckBox Ol_check;
        private System.Windows.Forms.CheckBox Ch_Kinect;
        private System.Windows.Forms.CheckBox Ch_Time;
        private System.Windows.Forms.TextBox Time_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox out_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button But_output;
        private System.Windows.Forms.FolderBrowserDialog Output_Open;
    }
}