namespace HTCPCheck
{
    partial class frmProductCheckDesc
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
            this.groupControlMainten = new DevExpress.XtraEditors.GroupControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMainten)).BeginInit();
            this.groupControlMainten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlMainten
            // 
            this.groupControlMainten.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControlMainten.Appearance.Options.UseForeColor = true;
            this.groupControlMainten.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlMainten.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlMainten.Controls.Add(this.txtRemark);
            this.groupControlMainten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlMainten.Location = new System.Drawing.Point(0, 0);
            this.groupControlMainten.Name = "groupControlMainten";
            this.groupControlMainten.Size = new System.Drawing.Size(510, 336);
            this.groupControlMainten.TabIndex = 31;
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.EditValue = "1.原长：指上验布机前其它单位提供的此面料长度\r\n2.检验长度：指经过验布机器跑出来的米数";
            this.txtRemark.Location = new System.Drawing.Point(2, 17);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtRemark.Properties.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(506, 316);
            this.txtRemark.TabIndex = 12;
            // 
            // frmProductCheckDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 336);
            this.Controls.Add(this.groupControlMainten);
            this.Name = "frmProductCheckDesc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "验布描述";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMainten)).EndInit();
            this.groupControlMainten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlMainten;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
    }
}