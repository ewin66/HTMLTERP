namespace MLTERP
{
    partial class frmWait
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWait));
            this.labMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labTimer = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(12, 52);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(143, 12);
            this.labMessage.TabIndex = 1;
            this.labMessage.Text = "正在处理数据，请稍后...";
            // 
            // labTimer
            // 
            this.labTimer.AutoSize = true;
            this.labTimer.Location = new System.Drawing.Point(147, 64);
            this.labTimer.Name = "labTimer";
            this.labTimer.Size = new System.Drawing.Size(0, 12);
            this.labTimer.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 21);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(239, 19);
            this.progressBar1.TabIndex = 3;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(265, 26);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(17, 12);
            this.lbProgress.TabIndex = 4;
            this.lbProgress.Text = "0%";
            // 
            // frmWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 91);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labTimer);
            this.Controls.Add(this.labMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWait";
            this.Text = "数据加载...";
            this.Load += new System.EventHandler(this.frmWait_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labTimer;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbProgress;
        private System.ComponentModel.BackgroundWorker worker;
    }
}