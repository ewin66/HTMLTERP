namespace HttSoft.UCFab
{
    partial class UCStatusBarStand
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
            this.lblHeadCaption = new System.Windows.Forms.Label();
            this.ucStatusBarStandOne1 = new HttSoft.UCFab.UCStatusBarStandOne();
            this.SuspendLayout();
            // 
            // lblHeadCaption
            // 
            this.lblHeadCaption.AutoSize = true;
            this.lblHeadCaption.Location = new System.Drawing.Point(1, 4);
            this.lblHeadCaption.Name = "lblHeadCaption";
            this.lblHeadCaption.Size = new System.Drawing.Size(29, 12);
            this.lblHeadCaption.TabIndex = 0;
            this.lblHeadCaption.Text = "进度";
            // 
            // ucStatusBarStandOne1
            // 
            this.ucStatusBarStandOne1.Location = new System.Drawing.Point(42, 2);
            this.ucStatusBarStandOne1.Name = "ucStatusBarStandOne1";
            this.ucStatusBarStandOne1.Size = new System.Drawing.Size(60, 16);
            this.ucStatusBarStandOne1.TabIndex = 1;
            this.ucStatusBarStandOne1.UCBackColor = System.Drawing.Color.White;
            this.ucStatusBarStandOne1.UCBorderColor = System.Drawing.Color.Blue;
            this.ucStatusBarStandOne1.UCContext = "";
            this.ucStatusBarStandOne1.UCContextHeight = 0;
            this.ucStatusBarStandOne1.UCContextWidth = 0;
            // 
            // UCStatusBarStand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucStatusBarStandOne1);
            this.Controls.Add(this.lblHeadCaption);
            this.Name = "UCStatusBarStand";
            this.Size = new System.Drawing.Size(841, 20);
            this.Load += new System.EventHandler(this.UCStatusBarStand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeadCaption;
        private UCStatusBarStandOne ucStatusBarStandOne1;
    }
}
