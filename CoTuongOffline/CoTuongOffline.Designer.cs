namespace CoTuongOffline
{
    partial class CoTuongOffline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoTuongOffline));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblPheDuocDanh = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSoLuotDi = new System.Windows.Forms.Label();
            this.ptrHelp = new System.Windows.Forms.PictureBox();
            this.ptrCamera = new System.Windows.Forms.PictureBox();
            this.ptrSound = new System.Windows.Forms.PictureBox();
            this.ptbBanCo = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.lblPheDuocDanh);
            this.panel1.Controls.Add(this.btnNewGame);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSoLuotDi);
            this.panel1.Location = new System.Drawing.Point(649, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 104);
            this.panel1.TabIndex = 6;
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUndo.Enabled = false;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUndo.Image = global::CoTuongOffline.Properties.Resources.Go_back_icon;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(76, 70);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(90, 27);
            this.btnUndo.TabIndex = 0;
            this.btnUndo.Text = "Hoàn tác";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblPheDuocDanh
            // 
            this.lblPheDuocDanh.AutoSize = true;
            this.lblPheDuocDanh.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPheDuocDanh.ForeColor = System.Drawing.Color.Black;
            this.lblPheDuocDanh.Location = new System.Drawing.Point(6, 6);
            this.lblPheDuocDanh.Name = "lblPheDuocDanh";
            this.lblPheDuocDanh.Size = new System.Drawing.Size(161, 25);
            this.lblPheDuocDanh.TabIndex = 0;
            this.lblPheDuocDanh.Text = "Phe nào được đi?";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNewGame.Enabled = false;
            this.btnNewGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNewGame.Image = global::CoTuongOffline.Properties.Resources.red_play_5121;
            this.btnNewGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewGame.Location = new System.Drawing.Point(172, 70);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(90, 27);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "Ván mới";
            this.btnNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số lượt đã đi:";
            // 
            // lblSoLuotDi
            // 
            this.lblSoLuotDi.AutoSize = true;
            this.lblSoLuotDi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuotDi.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSoLuotDi.Location = new System.Drawing.Point(81, 29);
            this.lblSoLuotDi.Name = "lblSoLuotDi";
            this.lblSoLuotDi.Size = new System.Drawing.Size(31, 30);
            this.lblSoLuotDi.TabIndex = 2;
            this.lblSoLuotDi.Text = "??";
            // 
            // ptrHelp
            // 
            this.ptrHelp.BackColor = System.Drawing.Color.Transparent;
            this.ptrHelp.Image = global::CoTuongOffline.Properties.Resources.help_icon;
            this.ptrHelp.Location = new System.Drawing.Point(807, 142);
            this.ptrHelp.Name = "ptrHelp";
            this.ptrHelp.Size = new System.Drawing.Size(26, 33);
            this.ptrHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrHelp.TabIndex = 18;
            this.ptrHelp.TabStop = false;
            this.ptrHelp.Click += new System.EventHandler(this.ptrHelp_Click);
            // 
            // ptrCamera
            // 
            this.ptrCamera.Image = global::CoTuongOffline.Properties.Resources.Camera;
            this.ptrCamera.Location = new System.Drawing.Point(885, 142);
            this.ptrCamera.Name = "ptrCamera";
            this.ptrCamera.Size = new System.Drawing.Size(26, 33);
            this.ptrCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrCamera.TabIndex = 17;
            this.ptrCamera.TabStop = false;
            this.ptrCamera.Click += new System.EventHandler(this.ptrCamera_Click);
            // 
            // ptrSound
            // 
            this.ptrSound.Image = global::CoTuongOffline.Properties.Resources.SoundOn;
            this.ptrSound.Location = new System.Drawing.Point(846, 142);
            this.ptrSound.Name = "ptrSound";
            this.ptrSound.Size = new System.Drawing.Size(26, 33);
            this.ptrSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrSound.TabIndex = 16;
            this.ptrSound.TabStop = false;
            this.ptrSound.Click += new System.EventHandler(this.ptrSound_Click);
            // 
            // ptbBanCo
            // 
            this.ptbBanCo.BackColor = System.Drawing.Color.Transparent;
            this.ptbBanCo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ptbBanCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbBanCo.Image = global::CoTuongOffline.Properties.Resources.BanCoTuong;
            this.ptbBanCo.InitialImage = null;
            this.ptbBanCo.Location = new System.Drawing.Point(34, 32);
            this.ptbBanCo.Name = "ptbBanCo";
            this.ptbBanCo.Size = new System.Drawing.Size(607, 662);
            this.ptbBanCo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbBanCo.TabIndex = 5;
            this.ptbBanCo.TabStop = false;
            this.ptbBanCo.Click += new System.EventHandler(this.ptbBanCo_Click);
            // 
            // background
            // 
            this.background.Enabled = false;
            this.background.Image = global::CoTuongOffline.Properties.Resources.tranh_thuy_mac;
            this.background.Location = new System.Drawing.Point(-1, -1);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(944, 729);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 4;
            this.background.TabStop = false;
            // 
            // CoTuongOffline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(942, 726);
            this.Controls.Add(this.ptrHelp);
            this.Controls.Add(this.ptrCamera);
            this.Controls.Add(this.ptrSound);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptbBanCo);
            this.Controls.Add(this.background);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CoTuongOffline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cờ tướng (Offline)";
            this.Load += new System.EventHandler(this.CoTuongOffline_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.PictureBox ptbBanCo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblPheDuocDanh;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSoLuotDi;
        private System.Windows.Forms.PictureBox ptrHelp;
        private System.Windows.Forms.PictureBox ptrCamera;
        private System.Windows.Forms.PictureBox ptrSound;
    }
}

