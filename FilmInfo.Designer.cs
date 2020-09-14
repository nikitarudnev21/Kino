namespace KinoRudnev
{
    partial class FilmInfo
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
            this.lblFilm = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPlacesCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFilm
            // 
            this.lblFilm.AutoSize = true;
            this.lblFilm.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblFilm.Location = new System.Drawing.Point(195, 128);
            this.lblFilm.Name = "lblFilm";
            this.lblFilm.Size = new System.Drawing.Size(20, 22);
            this.lblFilm.TabIndex = 0;
            this.lblFilm.Text = ".";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInfo.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblInfo.Location = new System.Drawing.Point(193, 65);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(259, 28);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Информация о сеансе";
            // 
            // lblPlacesCount
            // 
            this.lblPlacesCount.AutoSize = true;
            this.lblPlacesCount.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblPlacesCount.Location = new System.Drawing.Point(195, 171);
            this.lblPlacesCount.Name = "lblPlacesCount";
            this.lblPlacesCount.Size = new System.Drawing.Size(20, 22);
            this.lblPlacesCount.TabIndex = 2;
            this.lblPlacesCount.Text = ".";
            // 
            // FilmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(655, 536);
            this.Controls.Add(this.lblPlacesCount);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblFilm);
            this.Name = "FilmInfo";
            this.Text = "FilmInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilm;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPlacesCount;
    }
}