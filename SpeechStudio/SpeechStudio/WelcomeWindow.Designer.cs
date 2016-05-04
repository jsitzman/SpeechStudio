namespace SpeechStudio
{
    partial class WelcomeWindow
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
        //Required method for Designer support - do not modify
        //the contents of this method with the code editor.
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeWindow));
            this.But_New = new System.Windows.Forms.Button();
            this.But_Load = new System.Windows.Forms.Button();
            this.Background = new System.Windows.Forms.PictureBox();
            this.open_loading = new System.Windows.Forms.FolderBrowserDialog();
            this.But_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // But_New
            // 
            this.But_New.BackColor = System.Drawing.Color.BurlyWood;
            resources.ApplyResources(this.But_New, "But_New");
            this.But_New.ForeColor = System.Drawing.Color.White;
            this.But_New.Name = "But_New";
            this.But_New.UseVisualStyleBackColor = false;
            this.But_New.Click += new System.EventHandler(this.But_New_Click);
            // 
            // But_Load
            // 
            this.But_Load.BackColor = System.Drawing.Color.BurlyWood;
            resources.ApplyResources(this.But_Load, "But_Load");
            this.But_Load.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.But_Load.ForeColor = System.Drawing.Color.White;
            this.But_Load.Name = "But_Load";
            this.But_Load.UseVisualStyleBackColor = false;
            this.But_Load.Click += new System.EventHandler(this.But_Load_Click);
            // 
            // Background
            // 
            this.Background.Image = global::SpeechStudio.Properties.Resources.welcome_background;
            resources.ApplyResources(this.Background, "Background");
            this.Background.Name = "Background";
            this.Background.TabStop = false;
            // 
            // But_Exit
            // 
            this.But_Exit.BackColor = System.Drawing.Color.BurlyWood;
            resources.ApplyResources(this.But_Exit, "But_Exit");
            this.But_Exit.ForeColor = System.Drawing.Color.White;
            this.But_Exit.Name = "But_Exit";
            this.But_Exit.UseVisualStyleBackColor = false;
            this.But_Exit.Click += new System.EventHandler(this.But_Exit_Click);
            // 
            // WelcomeWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.But_Exit);
            this.Controls.Add(this.But_Load);
            this.Controls.Add(this.But_New);
            this.Controls.Add(this.Background);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WelcomeWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button But_New;
        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.FolderBrowserDialog open_loading;
        private System.Windows.Forms.Button But_Load;
        private System.Windows.Forms.Button But_Exit;
    }
}

