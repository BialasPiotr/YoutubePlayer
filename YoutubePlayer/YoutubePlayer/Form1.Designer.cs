namespace YoutubePlayer
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Videolink = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.video = new System.Windows.Forms.WebBrowser();
        
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paste link ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Videolink
            // 
            this.Videolink.Location = new System.Drawing.Point(12, 35);
            this.Videolink.Name = "Videolink";
            this.Videolink.Size = new System.Drawing.Size(651, 26);
            this.Videolink.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(669, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // video
            // 
            this.video.Location = new System.Drawing.Point(12, 97);
            this.video.MinimumSize = new System.Drawing.Size(20, 20);
            this.video.Name = "video";
            this.video.Size = new System.Drawing.Size(949, 460);
            this.video.TabIndex = 3;
            // 
           // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 578);
            this.Controls.Add(this.video);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Videolink);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "v";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Videolink;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser video;
        private System.Windows.Forms.Button buttonAddToPlaylist;
    }
}

