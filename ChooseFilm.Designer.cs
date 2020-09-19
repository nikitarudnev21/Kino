namespace KinoRudnev
{
    partial class numericPlaces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(numericPlaces));
            this.btnChoosePlace = new System.Windows.Forms.Button();
            this.pbTenet = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFastFur = new System.Windows.Forms.PictureBox();
            this.pbTerminator = new System.Windows.Forms.PictureBox();
            this.pbDeadpool = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTenet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFastFur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerminator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeadpool)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoosePlace
            // 
            this.btnChoosePlace.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnChoosePlace.Location = new System.Drawing.Point(1073, 707);
            this.btnChoosePlace.Name = "btnChoosePlace";
            this.btnChoosePlace.Size = new System.Drawing.Size(160, 41);
            this.btnChoosePlace.TabIndex = 0;
            this.btnChoosePlace.Text = "Далее";
            this.btnChoosePlace.UseVisualStyleBackColor = true;
            // 
            // pbTenet
            // 
            this.pbTenet.Image = ((System.Drawing.Image)(resources.GetObject("pbTenet.Image")));
            this.pbTenet.Location = new System.Drawing.Point(32, 75);
            this.pbTenet.Name = "pbTenet";
            this.pbTenet.Size = new System.Drawing.Size(270, 287);
            this.pbTenet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTenet.TabIndex = 1;
            this.pbTenet.TabStop = false;
            this.pbTenet.Tag = "TENET";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 28.25F);
            this.label1.Location = new System.Drawing.Point(492, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 45);
            this.label1.TabIndex = 2;
            this.label1.Tag = "asdasd";
            this.label1.Text = "Выберите фильм";
            // 
            // pbFastFur
            // 
            this.pbFastFur.Image = ((System.Drawing.Image)(resources.GetObject("pbFastFur.Image")));
            this.pbFastFur.Location = new System.Drawing.Point(343, 75);
            this.pbFastFur.Name = "pbFastFur";
            this.pbFastFur.Size = new System.Drawing.Size(270, 287);
            this.pbFastFur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFastFur.TabIndex = 4;
            this.pbFastFur.TabStop = false;
            this.pbFastFur.Tag = "Furious 7";
            // 
            // pbTerminator
            // 
            this.pbTerminator.Image = ((System.Drawing.Image)(resources.GetObject("pbTerminator.Image")));
            this.pbTerminator.Location = new System.Drawing.Point(653, 75);
            this.pbTerminator.Name = "pbTerminator";
            this.pbTerminator.Size = new System.Drawing.Size(270, 287);
            this.pbTerminator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTerminator.TabIndex = 6;
            this.pbTerminator.TabStop = false;
            this.pbTerminator.Tag = "Terminator Gynesis";
            // 
            // pbDeadpool
            // 
            this.pbDeadpool.Image = ((System.Drawing.Image)(resources.GetObject("pbDeadpool.Image")));
            this.pbDeadpool.Location = new System.Drawing.Point(967, 75);
            this.pbDeadpool.Name = "pbDeadpool";
            this.pbDeadpool.Size = new System.Drawing.Size(270, 287);
            this.pbDeadpool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeadpool.TabIndex = 8;
            this.pbDeadpool.TabStop = false;
            this.pbDeadpool.Tag = "Deadpool 2";
            // 
            // numericPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 774);
            this.Controls.Add(this.pbDeadpool);
            this.Controls.Add(this.pbTerminator);
            this.Controls.Add(this.pbFastFur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTenet);
            this.Controls.Add(this.btnChoosePlace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "numericPlaces";
            this.Text = "Выберите фильм";
            ((System.ComponentModel.ISupportInitialize)(this.pbTenet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFastFur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerminator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeadpool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoosePlace;
        private System.Windows.Forms.PictureBox pbTenet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbFastFur;
        private System.Windows.Forms.PictureBox pbTerminator;
        private System.Windows.Forms.PictureBox pbDeadpool;
    }
}