namespace pacman09
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxPacman = new System.Windows.Forms.PictureBox();
            this.PBYem = new System.Windows.Forms.PictureBox();
            this.labelYem = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPacman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBYem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPacman
            // 
            this.pictureBoxPacman.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPacman.Image")));
            this.pictureBoxPacman.Location = new System.Drawing.Point(3, 21);
            this.pictureBoxPacman.Name = "pictureBoxPacman";
            this.pictureBoxPacman.Size = new System.Drawing.Size(98, 76);
            this.pictureBoxPacman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPacman.TabIndex = 1;
            this.pictureBoxPacman.TabStop = false;
            // 
            // PBYem
            // 
            this.PBYem.Image = global::pacman09.Properties.Resources.yem;
            this.PBYem.Location = new System.Drawing.Point(481, 72);
            this.PBYem.Name = "PBYem";
            this.PBYem.Size = new System.Drawing.Size(24, 25);
            this.PBYem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBYem.TabIndex = 2;
            this.PBYem.TabStop = false;
            // 
            // labelYem
            // 
            this.labelYem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelYem.Location = new System.Drawing.Point(260, 9);
            this.labelYem.Name = "labelYem";
            this.labelYem.Size = new System.Drawing.Size(209, 42);
            this.labelYem.TabIndex = 3;
            this.labelYem.Text = "Puan:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.PBYem);
            this.panel1.Controls.Add(this.pictureBoxPacman);
            this.panel1.Location = new System.Drawing.Point(55, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 270);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(679, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "İpucu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(777, 425);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelYem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PACMAN";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPacman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBYem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxPacman;
        private System.Windows.Forms.PictureBox PBYem;
        private System.Windows.Forms.Label labelYem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

