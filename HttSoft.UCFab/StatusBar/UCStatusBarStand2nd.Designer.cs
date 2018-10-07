namespace HttSoft.UCFab
{
    partial class UCStatusBarStand2nd
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblColorSOStatus1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblColorSOStatus1
            // 
            this.lblColorSOStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblColorSOStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColorSOStatus1.Location = new System.Drawing.Point(0, 0);
            this.lblColorSOStatus1.Name = "lblColorSOStatus1";
            this.lblColorSOStatus1.Size = new System.Drawing.Size(100, 31);
            this.lblColorSOStatus1.TabIndex = 0;
            this.lblColorSOStatus1.Text = "lbl";
            this.lblColorSOStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCStatusBarStand2nd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblColorSOStatus1);
            this.Name = "UCStatusBarStand2nd";
            this.Size = new System.Drawing.Size(100, 31);
            this.Load += new System.EventHandler(this.UCStatusBarStand2nd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblColorSOStatus1;

    }
}
