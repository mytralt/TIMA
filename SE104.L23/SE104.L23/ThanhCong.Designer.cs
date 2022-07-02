namespace SE104.L23
{
    partial class ThanhCong
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
            this.ThongBao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_TraCuucd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThongBao
            // 
            this.ThongBao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ThongBao.Font = new System.Drawing.Font("Quicksand", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThongBao.ForeColor = System.Drawing.Color.White;
            this.ThongBao.Location = new System.Drawing.Point(5, 91);
            this.ThongBao.Name = "ThongBao";
            this.ThongBao.Size = new System.Drawing.Size(474, 41);
            this.ThongBao.TabIndex = 32;
            this.ThongBao.Text = "notice";
            this.ThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.label1.Font = new System.Drawing.Font("Quicksand", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(204)))), ((int)(((byte)(163)))));
            this.label1.Location = new System.Drawing.Point(5, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 41);
            this.label1.TabIndex = 33;
            this.label1.Text = "THÔNG BÁO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_TraCuucd
            // 
            this.btn_TraCuucd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.btn_TraCuucd.BackgroundImage = global::SE104.L23.Properties.Resources.btn_ok;
            this.btn_TraCuucd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TraCuucd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_TraCuucd.FlatAppearance.BorderSize = 0;
            this.btn_TraCuucd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TraCuucd.Location = new System.Drawing.Point(166, 158);
            this.btn_TraCuucd.Name = "btn_TraCuucd";
            this.btn_TraCuucd.Size = new System.Drawing.Size(159, 74);
            this.btn_TraCuucd.TabIndex = 24;
            this.btn_TraCuucd.TabStop = false;
            this.btn_TraCuucd.UseVisualStyleBackColor = false;
            // 
            // ThanhCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ThongBao);
            this.Controls.Add(this.btn_TraCuucd);
            this.Name = "ThanhCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ThanhCong";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TraCuucd;
        private System.Windows.Forms.Label ThongBao;
        private System.Windows.Forms.Label label1;
    }
}