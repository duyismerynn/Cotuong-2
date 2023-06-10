namespace CoTuongOffline
{
    partial class Cotuong_Off
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cotuong_Off));
            this.lblPheDuocDanh = new System.Windows.Forms.Label();
            this.label_Soluotdi = new System.Windows.Forms.Label();
            this.lblSoLuotDi = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.ptbBanCo = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.label_nhom17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPheDuocDanh
            // 
            this.lblPheDuocDanh.AutoSize = true;
            this.lblPheDuocDanh.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPheDuocDanh.ForeColor = System.Drawing.Color.Black;
            this.lblPheDuocDanh.Location = new System.Drawing.Point(33, 326);
            this.lblPheDuocDanh.Name = "lblPheDuocDanh";
            this.lblPheDuocDanh.Size = new System.Drawing.Size(145, 32);
            this.lblPheDuocDanh.TabIndex = 0;
            this.lblPheDuocDanh.Text = "Tới lượt phe";
            // 
            // label_Soluotdi
            // 
            this.label_Soluotdi.AutoSize = true;
            this.label_Soluotdi.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label_Soluotdi.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_Soluotdi.Location = new System.Drawing.Point(32, 391);
            this.label_Soluotdi.Name = "label_Soluotdi";
            this.label_Soluotdi.Size = new System.Drawing.Size(136, 38);
            this.label_Soluotdi.TabIndex = 3;
            this.label_Soluotdi.Text = "Số lượt đi";
            this.label_Soluotdi.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblSoLuotDi
            // 
            this.lblSoLuotDi.AutoSize = true;
            this.lblSoLuotDi.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblSoLuotDi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuotDi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSoLuotDi.Location = new System.Drawing.Point(174, 392);
            this.lblSoLuotDi.Name = "lblSoLuotDi";
            this.lblSoLuotDi.Size = new System.Drawing.Size(32, 37);
            this.lblSoLuotDi.TabIndex = 2;
            this.lblSoLuotDi.Text = "0";
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnNewGame.Enabled = false;
            this.btnNewGame.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNewGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewGame.Location = new System.Drawing.Point(29, 610);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(236, 75);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "Ván mới";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUndo.Enabled = false;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUndo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUndo.Location = new System.Drawing.Point(29, 476);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(236, 75);
            this.btnUndo.TabIndex = 0;
            this.btnUndo.Text = "Hoàn tác";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // ptbBanCo
            // 
            this.ptbBanCo.BackColor = System.Drawing.Color.Transparent;
            this.ptbBanCo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ptbBanCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbBanCo.Image = global::CoTuongOffline.Properties.Resources.BanCoTuong;
            this.ptbBanCo.InitialImage = null;
            this.ptbBanCo.Location = new System.Drawing.Point(282, 23);
            this.ptbBanCo.Name = "ptbBanCo";
            this.ptbBanCo.Size = new System.Drawing.Size(607, 662);
            this.ptbBanCo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbBanCo.TabIndex = 5;
            this.ptbBanCo.TabStop = false;
            this.ptbBanCo.Click += new System.EventHandler(this.ptbBanCo_Click);
            // 
            // background
            // 
            this.background.BackgroundImage = global::CoTuongOffline.Properties.Resources.anhnen;
            this.background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.background.Enabled = false;
            this.background.Location = new System.Drawing.Point(-14, -9);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(1196, 737);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 4;
            this.background.TabStop = false;
            // 
            // label_nhom17
            // 
            this.label_nhom17.AutoSize = true;
            this.label_nhom17.BackColor = System.Drawing.Color.Transparent;
            this.label_nhom17.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nhom17.Location = new System.Drawing.Point(84, 23);
            this.label_nhom17.Name = "label_nhom17";
            this.label_nhom17.Size = new System.Drawing.Size(132, 38);
            this.label_nhom17.TabIndex = 6;
            this.label_nhom17.Text = "Nhóm 17";
            // 
            // Cotuong_Off
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1175, 704);
            this.Controls.Add(this.label_nhom17);
            this.Controls.Add(this.lblSoLuotDi);
            this.Controls.Add(this.label_Soluotdi);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.lblPheDuocDanh);
            this.Controls.Add(this.ptbBanCo);
            this.Controls.Add(this.background);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Cotuong_Off";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cờ tướng (Offline)";
            this.Load += new System.EventHandler(this.CoTuongOffline_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.PictureBox ptbBanCo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblPheDuocDanh;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label label_Soluotdi;
        private System.Windows.Forms.Label lblSoLuotDi;
        private System.Windows.Forms.Label label_nhom17;
    }
}

