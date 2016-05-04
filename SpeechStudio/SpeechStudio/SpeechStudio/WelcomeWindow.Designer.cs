namespace SpeechStudio
{
    partial class WelcomeWindow
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
            this.But_New = new System.Windows.Forms.Button();
            this.But_Load = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // But_New
            // 
            this.But_New.Location = new System.Drawing.Point(55, 136);
            this.But_New.Margin = new System.Windows.Forms.Padding(2);
            this.But_New.Name = "But_New";
            this.But_New.Size = new System.Drawing.Size(83, 35);
            this.But_New.TabIndex = 0;
            this.But_New.Text = "New";
            this.But_New.UseVisualStyleBackColor = true;
            this.But_New.Click += new System.EventHandler(this.But_New_Click);
            // 
            // But_Load
            // 
            this.But_Load.Location = new System.Drawing.Point(185, 136);
            this.But_Load.Margin = new System.Windows.Forms.Padding(2);
            this.But_Load.Name = "But_Load";
            this.But_Load.Size = new System.Drawing.Size(82, 35);
            this.But_Load.TabIndex = 1;
            this.But_Load.Text = "Load";
            this.But_Load.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(70, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 66);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // WelcomeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 217);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.But_Load);
            this.Controls.Add(this.But_New);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WelcomeWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button But_New;
        private System.Windows.Forms.Button But_Load;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

