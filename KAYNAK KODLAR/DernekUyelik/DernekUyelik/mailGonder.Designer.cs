namespace DernekUyelik
{
    partial class mailGonder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mailGonder));
            this.label1 = new System.Windows.Forms.Label();
            this.mailListeView = new System.Windows.Forms.ListView();
            this.tc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adsoyad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uyeMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.icerik = new System.Windows.Forms.TextBox();
            this.kaydet = new System.Windows.Forms.Button();
            this.baslik = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mail Gönderilecekler Listesi";
            // 
            // mailListeView
            // 
            this.mailListeView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tc,
            this.adsoyad,
            this.uyeMail});
            this.mailListeView.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mailListeView.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mailListeView.ForeColor = System.Drawing.Color.Black;
            this.mailListeView.FullRowSelect = true;
            this.mailListeView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.mailListeView.HideSelection = false;
            this.mailListeView.HoverSelection = true;
            this.mailListeView.Location = new System.Drawing.Point(3, 54);
            this.mailListeView.Name = "mailListeView";
            this.mailListeView.Size = new System.Drawing.Size(289, 400);
            this.mailListeView.TabIndex = 4;
            this.mailListeView.UseCompatibleStateImageBehavior = false;
            this.mailListeView.View = System.Windows.Forms.View.Details;
            // 
            // tc
            // 
            this.tc.Text = "T.C.";
            this.tc.Width = 95;
            // 
            // adsoyad
            // 
            this.adsoyad.Text = "Ad Soyad";
            this.adsoyad.Width = 103;
            // 
            // uyeMail
            // 
            this.uyeMail.Text = "Mail";
            this.uyeMail.Width = 82;
            // 
            // icerik
            // 
            this.icerik.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.icerik.Location = new System.Drawing.Point(321, 119);
            this.icerik.Multiline = true;
            this.icerik.Name = "icerik";
            this.icerik.Size = new System.Drawing.Size(458, 283);
            this.icerik.TabIndex = 5;
            this.icerik.Text = resources.GetString("icerik.Text");
            // 
            // kaydet
            // 
            this.kaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(134)))), ((int)(((byte)(239)))));
            this.kaydet.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kaydet.ForeColor = System.Drawing.Color.White;
            this.kaydet.Location = new System.Drawing.Point(321, 407);
            this.kaydet.Name = "kaydet";
            this.kaydet.Size = new System.Drawing.Size(458, 47);
            this.kaydet.TabIndex = 27;
            this.kaydet.Text = "ÜYELERE MAİL GÖNDER";
            this.kaydet.UseVisualStyleBackColor = false;
            this.kaydet.Click += new System.EventHandler(this.kaydet_Click);
            // 
            // baslik
            // 
            this.baslik.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslik.Location = new System.Drawing.Point(321, 54);
            this.baslik.Name = "baslik";
            this.baslik.Size = new System.Drawing.Size(458, 36);
            this.baslik.TabIndex = 29;
            this.baslik.Text = "Sahaflar Derneği | Bilgilendirme";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(675, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 34);
            this.button2.TabIndex = 33;
            this.button2.Text = "Kapat";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mailGonder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.baslik);
            this.Controls.Add(this.kaydet);
            this.Controls.Add(this.icerik);
            this.Controls.Add(this.mailListeView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mailGonder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "mailGonder";
            this.Load += new System.EventHandler(this.mailGonder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader tc;
        private System.Windows.Forms.ColumnHeader adsoyad;
        private System.Windows.Forms.TextBox icerik;
        public System.Windows.Forms.ListView mailListeView;
        private System.Windows.Forms.Button kaydet;
        private System.Windows.Forms.ColumnHeader uyeMail;
        private System.Windows.Forms.TextBox baslik;
        private System.Windows.Forms.Button button2;
    }
}