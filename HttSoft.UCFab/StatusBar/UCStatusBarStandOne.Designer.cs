namespace HttSoft.UCFab
{
    partial class UCStatusBarStandOne
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
            this.txtColorSOStatus1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorSOStatus1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtColorSOStatus1
            // 
            this.txtColorSOStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColorSOStatus1.EditValue = "333";
            this.txtColorSOStatus1.Location = new System.Drawing.Point(0, 0);
            this.txtColorSOStatus1.Name = "txtColorSOStatus1";
            this.txtColorSOStatus1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtColorSOStatus1.Properties.Appearance.Options.UseBackColor = true;
            this.txtColorSOStatus1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtColorSOStatus1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtColorSOStatus1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtColorSOStatus1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtColorSOStatus1.Properties.ReadOnly = true;
            this.txtColorSOStatus1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtColorSOStatus1.Size = new System.Drawing.Size(100, 31);
            this.txtColorSOStatus1.TabIndex = 242;
            // 
            // UCStatusBarStandOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtColorSOStatus1);
            this.Name = "UCStatusBarStandOne";
            this.Size = new System.Drawing.Size(100, 31);
            ((System.ComponentModel.ISupportInitialize)(this.txtColorSOStatus1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtColorSOStatus1;
    }
}
