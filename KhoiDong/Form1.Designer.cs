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
            this.btnGo = new System.Windows.Forms.Button();
            this.radioNewGamePvp = new System.Windows.Forms.RadioButton();
            this.radioConnectPvp = new System.Windows.Forms.RadioButton();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_mode = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioOffline
            // 
            this.radioOffline.AutoSize = true;
            this.radioOffline.BackColor = System.Drawing.Color.Transparent;
            this.radioOffline.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOffline.Location = new System.Drawing.Point(308, 45);
            this.radioOffline.Name = "radioOffline";
            this.radioOffline.Size = new System.Drawing.Size(122, 42);
            this.radioOffline.TabIndex = 0;
            this.radioOffline.TabStop = true;
            this.radioOffline.Text = "Offline";
            this.radioOffline.UseVisualStyleBackColor = false;
            this.radioOffline.CheckedChanged += new System.EventHandler(this.radioOffline_CheckedChanged);
            // 
            // radioLAN
            // 
            this.radioLAN.AutoSize = true;
            this.radioLAN.BackColor = System.Drawing.Color.Transparent;
            this.radioLAN.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLAN.Location = new System.Drawing.Point(471, 45);
            this.radioLAN.Name = "radioLAN";
            this.radioLAN.Size = new System.Drawing.Size(91, 42);
            this.radioLAN.TabIndex = 1;
            this.radioLAN.TabStop = true;
            this.radioLAN.Text = "LAN";
            this.radioLAN.UseVisualStyleBackColor = false;
            this.radioLAN.CheckedChanged += new System.EventHandler(this.radioLAN_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGo.Location = new System.Drawing.Point(22, 109);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(139, 164);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Bắt đầu";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // radioNewGamePvp
            // 
            this.radioNewGamePvp.AutoSize = true;
            this.radioNewGamePvp.Checked = true;
            this.radioNewGamePvp.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNewGamePvp.Location = new System.Drawing.Point(26, 98);
            this.radioNewGamePvp.Name = "radioNewGamePvp";
            this.radioNewGamePvp.Size = new System.Drawing.Size(171, 42);
            this.radioNewGamePvp.TabIndex = 0;
            this.radioNewGamePvp.TabStop = true;
            this.radioNewGamePvp.Text = "Tạo phòng";
            this.radioNewGamePvp.UseVisualStyleBackColor = true;
            this.radioNewGamePvp.CheckedChanged += new System.EventHandler(this.radioNewGamePvp_CheckedChanged);
            // 
            // radioConnectPvp
            // 
            this.radioConnectPvp.AutoSize = true;
            this.radioConnectPvp.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioConnectPvp.Location = new System.Drawing.Point(203, 98);
            this.radioConnectPvp.Name = "radioConnectPvp";
            this.radioConnectPvp.Size = new System.Drawing.Size(171, 42);
            this.radioConnectPvp.TabIndex = 1;
            this.radioConnectPvp.Text = "Vào phòng";
            this.radioConnectPvp.UseVisualStyleBackColor = true;
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlayerName.Location = new System.Drawing.Point(157, 27);
            this.tbPlayerName.MaxLength = 12;
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(152, 43);
            this.tbPlayerName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập tên";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbPlayerName);
            this.panel2.Controls.Add(this.radioConnectPvp);
            this.panel2.Controls.Add(this.radioNewGamePvp);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(167, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 161);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mode.Location = new System.Drawing.Point(24, 49);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(235, 38);
            this.label_mode.TabIndex = 11;
            this.label_mode.Text = "Chọn chế độ chơi";
            this.label_mode.Click += new System.EventHandler(this.label2_Click);
            // 
            // KhoiDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 301);
            this.Controls.Add(this.label_mode);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radioLAN);
            this.Controls.Add(this.radioOffline);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "KhoiDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cờ Tướng";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioLAN;
        private System.Windows.Forms.RadioButton radioOffline;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RadioButton radioNewGamePvp;
        private System.Windows.Forms.RadioButton radioConnectPvp;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_mode;
    }
}

