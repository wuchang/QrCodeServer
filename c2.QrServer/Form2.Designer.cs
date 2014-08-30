namespace c2.QrServer
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnGetQr = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址：";
            // 
            // txtServerAddr
            // 
            this.txtServerAddr.Location = new System.Drawing.Point(95, 32);
            this.txtServerAddr.Name = "txtServerAddr";
            this.txtServerAddr.Size = new System.Drawing.Size(230, 21);
            this.txtServerAddr.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "二维码内容：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(95, 59);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(230, 118);
            this.txtContent.TabIndex = 1;
            // 
            // btnGetQr
            // 
            this.btnGetQr.Location = new System.Drawing.Point(95, 183);
            this.btnGetQr.Name = "btnGetQr";
            this.btnGetQr.Size = new System.Drawing.Size(113, 32);
            this.btnGetQr.TabIndex = 2;
            this.btnGetQr.Text = "获取二维码";
            this.btnGetQr.UseVisualStyleBackColor = true;
            this.btnGetQr.Click += new System.EventHandler(this.btnGetQr_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(352, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 237);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 298);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGetQr);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtServerAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnGetQr;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}