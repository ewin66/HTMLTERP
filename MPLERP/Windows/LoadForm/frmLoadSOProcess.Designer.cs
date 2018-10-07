namespace MLTERP
{
    partial class frmLoadSOProcess
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
            this.ucsoProcessView1 = new HttSoft.UCFab.UCSOProcessView();
            this.SuspendLayout();
            // 
            // ucsoProcessView1
            // 
            this.ucsoProcessView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucsoProcessView1.FormNo = "";
            this.ucsoProcessView1.Location = new System.Drawing.Point(0, 0);
            this.ucsoProcessView1.Name = "ucsoProcessView1";
            this.ucsoProcessView1.Size = new System.Drawing.Size(884, 596);
            this.ucsoProcessView1.TabIndex = 0;
            // 
            // frmLoadSOProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 596);
            this.Controls.Add(this.ucsoProcessView1);
            this.Name = "frmLoadSOProcess";
            this.Text = "订单进度";
            this.Load += new System.EventHandler(this.frmLoadSOProcess_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HttSoft.UCFab.UCSOProcessView ucsoProcessView1;
    }
}