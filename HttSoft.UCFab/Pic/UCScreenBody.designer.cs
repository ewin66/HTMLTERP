namespace HttSoft.UCFab
{
    partial class UCScreenBody
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
            this.SuspendLayout();
            // 
            // ScreenBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 295);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenBody";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenBody";
            this.Load += new System.EventHandler(this.ScreenBody_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenBody_MouseUp);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScreenBody_MouseDoubleClick);
            this.DoubleClick += new System.EventHandler(this.ScreenBody_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenBody_MouseDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScreenBody_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenBody_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}