namespace CoTuongLAN
{
    partial class Cotuong_LAN
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cotuong_LAN));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.btnGui = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.timerRemainingTime = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLAN = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.lblOpponentRemainingTime = new System.Windows.Forms.Label();
            this.lblOpponentName = new System.Windows.Forms.Label();
            this.btnReady = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.btnSurrender = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblPheDuocDanh = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSoLuotDi = new System.Windows.Forms.Label();
            this.ptbBanCo = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_khungchat = new System.Windows.Forms.Label();
            this.label_nhom17 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label_khungchat);
            this.panel2.Controls.Add(this.lsvMessage);
            this.panel2.Controls.Add(this.btnGui);
            this.panel2.Controls.Add(this.txtChat);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panel2.Location = new System.Drawing.Point(905, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 472);
            this.panel2.TabIndex = 5;
            // 
            // lsvMessage
            // 
            this.lsvMessage.HideSelection = false;
            this.lsvMessage.Location = new System.Drawing.Point(6, 124);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(246, 311);
            this.lsvMessage.TabIndex = 7;
            this.lsvMessage.TileSize = new System.Drawing.Size(250, 15);
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.Tile;
            this.lsvMessage.SelectedIndexChanged += new System.EventHandler(this.btnReady_Click);
            // 
            // btnGui
            // 
            this.btnGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGui.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGui.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGui.Image = global::CoTuongLAN.Properties.Resources.Send;
            this.btnGui.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGui.Location = new System.Drawing.Point(193, 440);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(61, 25);
            this.btnGui.TabIndex = 2;
            this.btnGui.Text = "Gửi";
            this.btnGui.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGui.UseVisualStyleBackColor = false;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // txtChat
            // 
            this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtChat.Location = new System.Drawing.Point(6, 441);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(182, 27);
            this.txtChat.TabIndex = 1;
            // 
            // timerRemainingTime
            // 
            this.timerRemainingTime.Interval = 1000;
            this.timerRemainingTime.Tick += new System.EventHandler(this.RemainingTime_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnLAN);
            this.panel3.Controls.Add(this.txbIP);
            this.panel3.Location = new System.Drawing.Point(6, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 47);
            this.panel3.TabIndex = 12;
            // 
            // btnLAN
            // 
            this.btnLAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLAN.BackColor = System.Drawing.Color.LightGray;
            this.btnLAN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLAN.Image = global::CoTuongLAN.Properties.Resources.connect3;
            this.btnLAN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLAN.Location = new System.Drawing.Point(185, 10);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(50, 25);
            this.btnLAN.TabIndex = 6;
            this.btnLAN.Text = "LAN     ";
            this.btnLAN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLAN.UseVisualStyleBackColor = true;
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // txbIP
            // 
            this.txbIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbIP.Location = new System.Drawing.Point(3, 10);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(176, 27);
            this.txbIP.TabIndex = 5;
            this.txbIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOpponentRemainingTime
            // 
            this.lblOpponentRemainingTime.AutoSize = true;
            this.lblOpponentRemainingTime.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOpponentRemainingTime.Location = new System.Drawing.Point(162, 138);
            this.lblOpponentRemainingTime.Name = "lblOpponentRemainingTime";
            this.lblOpponentRemainingTime.Size = new System.Drawing.Size(89, 38);
            this.lblOpponentRemainingTime.TabIndex = 13;
            this.lblOpponentRemainingTime.Text = "00:00";
            // 
            // lblOpponentName
            // 
            this.lblOpponentName.AutoSize = true;
            this.lblOpponentName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOpponentName.Location = new System.Drawing.Point(10, 138);
            this.lblOpponentName.Name = "lblOpponentName";
            this.lblOpponentName.Size = new System.Drawing.Size(95, 32);
            this.lblOpponentName.TabIndex = 12;
            this.lblOpponentName.Text = "Đối thủ";
            // 
            // btnReady
            // 
            this.btnReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReady.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnReady.Location = new System.Drawing.Point(16, 272);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(235, 77);
            this.btnReady.TabIndex = 11;
            this.btnReady.Text = "Ván mới";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblName.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblName.Location = new System.Drawing.Point(10, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(153, 32);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Người chơi 1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTime.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblRemainingTime.Location = new System.Drawing.Point(162, 28);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(89, 38);
            this.lblRemainingTime.TabIndex = 9;
            this.lblRemainingTime.Text = "00:00";
            // 
            // btnSurrender
            // 
            this.btnSurrender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSurrender.BackColor = System.Drawing.Color.LightGray;
            this.btnSurrender.Enabled = false;
            this.btnSurrender.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSurrender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSurrender.Location = new System.Drawing.Point(16, 566);
            this.btnSurrender.Name = "btnSurrender";
            this.btnSurrender.Size = new System.Drawing.Size(235, 77);
            this.btnSurrender.TabIndex = 8;
            this.btnSurrender.Text = "Đầu hàng";
            this.btnSurrender.UseVisualStyleBackColor = true;
            this.btnSurrender.Click += new System.EventHandler(this.btnSurrender_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndo.BackColor = System.Drawing.Color.LightGray;
            this.btnUndo.Enabled = false;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUndo.Location = new System.Drawing.Point(16, 373);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(235, 77);
            this.btnUndo.TabIndex = 0;
            this.btnUndo.Text = "Xin đi lại";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblPheDuocDanh
            // 
            this.lblPheDuocDanh.AutoSize = true;
            this.lblPheDuocDanh.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPheDuocDanh.ForeColor = System.Drawing.Color.Black;
            this.lblPheDuocDanh.Location = new System.Drawing.Point(10, 87);
            this.lblPheDuocDanh.Name = "lblPheDuocDanh";
            this.lblPheDuocDanh.Size = new System.Drawing.Size(89, 32);
            this.lblPheDuocDanh.TabIndex = 0;
            this.lblPheDuocDanh.Text = "Lượt đi";
            this.lblPheDuocDanh.Visible = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewGame.BackColor = System.Drawing.Color.LightGray;
            this.btnNewGame.Enabled = false;
            this.btnNewGame.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNewGame.Location = new System.Drawing.Point(16, 471);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(235, 77);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "Cầu hòa";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(19, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số lượt đã đi:";
            // 
            // lblSoLuotDi
            // 
            this.lblSoLuotDi.AutoSize = true;
            this.lblSoLuotDi.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuotDi.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuotDi.Location = new System.Drawing.Point(181, 199);
            this.lblSoLuotDi.Name = "lblSoLuotDi";
            this.lblSoLuotDi.Size = new System.Drawing.Size(32, 38);
            this.lblSoLuotDi.TabIndex = 2;
            this.lblSoLuotDi.Text = "0";
            // 
            // ptbBanCo
            // 
            this.ptbBanCo.BackColor = System.Drawing.Color.Transparent;
            this.ptbBanCo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ptbBanCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbBanCo.Image = global::CoTuongLAN.Properties.Resources.BanCoTuong;
            this.ptbBanCo.InitialImage = null;
            this.ptbBanCo.Location = new System.Drawing.Point(292, 32);
            this.ptbBanCo.Name = "ptbBanCo";
            this.ptbBanCo.Size = new System.Drawing.Size(607, 662);
            this.ptbBanCo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbBanCo.TabIndex = 14;
            this.ptbBanCo.TabStop = false;
            this.ptbBanCo.Click += new System.EventHandler(this.ptbBanCo_Click);
            // 
            // background
            // 
            this.background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.background.Enabled = false;
            this.background.Image = global::CoTuongLAN.Properties.Resources.anhnen;
            this.background.ImageLocation = "";
            this.background.Location = new System.Drawing.Point(-1, 23);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(1182, 737);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 3;
            this.background.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSoLuotDi);
            this.panel1.Controls.Add(this.btnReady);
            this.panel1.Controls.Add(this.btnSurrender);
            this.panel1.Controls.Add(this.lblOpponentRemainingTime);
            this.panel1.Controls.Add(this.lblPheDuocDanh);
            this.panel1.Controls.Add(this.lblOpponentName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNewGame);
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblRemainingTime);
            this.panel1.Location = new System.Drawing.Point(12, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 662);
            this.panel1.TabIndex = 13;
            //this.DoubleBuffered = true;
            // 
            // label_khungchat
            // 
            this.label_khungchat.AutoSize = true;
            this.label_khungchat.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_khungchat.Location = new System.Drawing.Point(49, -1);
            this.label_khungchat.Name = "label_khungchat";
            this.label_khungchat.Size = new System.Drawing.Size(163, 41);
            this.label_khungchat.TabIndex = 8;
            this.label_khungchat.Text = "Trò chuyện";
            // 
            // label_nhom17
            // 
            this.label_nhom17.AutoSize = true;
            this.label_nhom17.BackColor = System.Drawing.Color.Transparent;
            this.label_nhom17.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nhom17.Location = new System.Drawing.Point(975, 32);
            this.label_nhom17.Name = "label_nhom17";
            this.label_nhom17.Size = new System.Drawing.Size(132, 38);
            this.label_nhom17.TabIndex = 15;
            this.label_nhom17.Text = "Nhóm 17";
            // 
            // Cotuong_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1178, 726);
            this.Controls.Add(this.label_nhom17);
            this.Controls.Add(this.ptbBanCo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.background);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Cotuong_LAN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Co Tuong (Online)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Timer timerRemainingTime;
        private System.Windows.Forms.ListView lsvMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLAN;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.Label lblOpponentRemainingTime;
        private System.Windows.Forms.Label lblOpponentName;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Button btnSurrender;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblPheDuocDanh;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSoLuotDi;
        private System.Windows.Forms.PictureBox ptbBanCo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_khungchat;
        private System.Windows.Forms.Label label_nhom17;
    }
}

