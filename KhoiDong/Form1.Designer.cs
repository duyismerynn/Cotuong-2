namespace KhoiDong
{
    partial class KhoiDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhoiDong));
            this.radioOffline = new System.Windows.Forms.RadioButton();
            this.radioLAN = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.radioConnectPvp = new System.Windows.Forms.RadioButton();
            this.radioNewGamePvp = new System.Windows.Forms.RadioButton();
            this.btnGo = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioOffline
            // 
            this.radioOffline.AutoSize = true;
            this.radioOffline.Location = new System.Drawing.Point(27, 20);
            this.radioOffline.Name = "radioOffline";
            this.radioOffline.Size = new System.Drawing.Size(61, 17);
            this.radioOffline.TabIndex = 0;
            this.radioOffline.TabStop = true;
            this.radioOffline.Text = "Offline";
            this.radioOffline.UseVisualStyleBackColor = true;
            // 
            // radioLAN
            // 
            this.radioLAN.AutoSize = true;
            this.radioLAN.Location = new System.Drawing.Point(27, 48);
            this.radioLAN.Name = "radioLAN";
            this.radioLAN.Size = new System.Drawing.Size(45, 17);
            this.radioLAN.TabIndex = 1;
            this.radioLAN.TabStop = true;
            this.radioLAN.Text = "LAN";
            this.radioLAN.UseVisualStyleBackColor = true;
            this.radioLAN.CheckedChanged += new System.EventHandler(this.radioLAN_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbPlayerName);
            this.panel2.Controls.Add(this.radioConnectPvp);
            this.panel2.Controls.Add(this.radioNewGamePvp);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(27, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 122);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên người chơi:";
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(111, 17);
            this.tbPlayerName.MaxLength = 12;
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(142, 22);
            this.tbPlayerName.TabIndex = 2;
            // 
            // radioConnectPvp
            // 
            this.radioConnectPvp.AutoSize = true;
            this.radioConnectPvp.Location = new System.Drawing.Point(29, 80);
            this.radioConnectPvp.Name = "radioConnectPvp";
            this.radioConnectPvp.Size = new System.Drawing.Size(267, 17);
            this.radioConnectPvp.TabIndex = 1;
            this.radioConnectPvp.Text = "Kết nối vào một ván cờ tạo bởi người chơi khác";
            this.radioConnectPvp.UseVisualStyleBackColor = true;
            // 
            // radioNewGamePvp
            // 
            this.radioNewGamePvp.AutoSize = true;
            this.radioNewGamePvp.Checked = true;
            this.radioNewGamePvp.Location = new System.Drawing.Point(29, 50);
            this.radioNewGamePvp.Name = "radioNewGamePvp";
            this.radioNewGamePvp.Size = new System.Drawing.Size(86, 17);
            this.radioNewGamePvp.TabIndex = 0;
            this.radioNewGamePvp.TabStop = true;
            this.radioNewGamePvp.Text = "Tạo ván mới";
            this.radioNewGamePvp.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Image = global::KhoiDong.Properties.Resources.red_play_512;
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGo.Location = new System.Drawing.Point(151, 223);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(86, 27);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Bắt đầu";
            this.btnGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // KhoiDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 269);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radioLAN);
            this.Controls.Add(this.radioOffline);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KhoiDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Cờ Tướng";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioLAN;
        private System.Windows.Forms.RadioButton radioOffline;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.RadioButton radioConnectPvp;
        private System.Windows.Forms.RadioButton radioNewGamePvp;
        private System.Windows.Forms.Button btnGo;
    }
}

