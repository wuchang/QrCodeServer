namespace c2.QrServer
{
    partial class Form1
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
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.cbxRunAsWindowService = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务名称:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(106, 35);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.ReadOnly = true;
            this.txtServerName.Size = new System.Drawing.Size(182, 21);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.Text = "QrServer";
            // 
            // cbxRunAsWindowService
            // 
            this.cbxRunAsWindowService.AutoSize = true;
            this.cbxRunAsWindowService.Location = new System.Drawing.Point(106, 72);
            this.cbxRunAsWindowService.Name = "cbxRunAsWindowService";
            this.cbxRunAsWindowService.Size = new System.Drawing.Size(132, 16);
            this.cbxRunAsWindowService.TabIndex = 2;
            this.cbxRunAsWindowService.Text = "以系统服务方式运行";
            this.cbxRunAsWindowService.UseVisualStyleBackColor = true;
            this.cbxRunAsWindowService.CheckedChanged += new System.EventHandler(this.cbxRunAsWindowService_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(106, 135);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(213, 135);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(106, 177);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(182, 23);
            this.btnInstall.TabIndex = 4;
            this.btnInstall.Text = "安装为Windows服务";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(106, 206);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(182, 23);
            this.btnUninstall.TabIndex = 4;
            this.btnUninstall.Text = "卸载Windows服务";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "状态:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(106, 106);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 12);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "未知";
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(320, 206);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(112, 23);
            this.btnDemo.TabIndex = 5;
            this.btnDemo.Text = "打开演示窗口";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 247);
            this.Controls.Add(this.btnDemo);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbxRunAsWindowService);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "二维码服务器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.CheckBox cbxRunAsWindowService;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDemo;
    }
}