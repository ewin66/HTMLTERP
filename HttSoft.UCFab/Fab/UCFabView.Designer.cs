namespace HttSoft.UCFab
{
    partial class UCFabView
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
            this.panGroupTopRight = new DevExpress.XtraEditors.PanelControl();
            this.radgOPType = new DevExpress.XtraEditors.RadioGroup();
            this.panGroupBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblInputInfo = new System.Windows.Forms.Label();
            this.panGroupTop = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgOPType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupBottom)).BeginInit();
            this.panGroupBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTop)).BeginInit();
            this.panGroupTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panGroupTopRight
            // 
            this.panGroupTopRight.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupTopRight.Appearance.Options.UseBackColor = true;
            this.panGroupTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroupTopRight.Location = new System.Drawing.Point(0, 0);
            this.panGroupTopRight.Name = "panGroupTopRight";
            this.panGroupTopRight.Size = new System.Drawing.Size(713, 366);
            this.panGroupTopRight.TabIndex = 274;
            this.panGroupTopRight.Text = "panelControl1";
            // 
            // radgOPType
            // 
            this.radgOPType.EditValue = 1;
            this.radgOPType.Location = new System.Drawing.Point(3, 2);
            this.radgOPType.Name = "radgOPType";
            this.radgOPType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radgOPType.Properties.Columns = 3;
            this.radgOPType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "横向模式"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "列表模式")});
            this.radgOPType.Size = new System.Drawing.Size(241, 22);
            this.radgOPType.TabIndex = 273;
            this.radgOPType.SelectedIndexChanged += new System.EventHandler(this.radgOPType_SelectedIndexChanged);
            // 
            // panGroupBottom
            // 
            this.panGroupBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupBottom.Appearance.Options.UseBackColor = true;
            this.panGroupBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupBottom.Controls.Add(this.lblInputInfo);
            this.panGroupBottom.Controls.Add(this.radgOPType);
            this.panGroupBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panGroupBottom.Location = new System.Drawing.Point(0, 366);
            this.panGroupBottom.Name = "panGroupBottom";
            this.panGroupBottom.Size = new System.Drawing.Size(713, 27);
            this.panGroupBottom.TabIndex = 275;
            this.panGroupBottom.Text = "panelControl1";
            // 
            // lblInputInfo
            // 
            this.lblInputInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputInfo.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.lblInputInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInputInfo.Location = new System.Drawing.Point(277, 4);
            this.lblInputInfo.Name = "lblInputInfo";
            this.lblInputInfo.Size = new System.Drawing.Size(433, 18);
            this.lblInputInfo.TabIndex = 274;
            this.lblInputInfo.Text = "0";
            this.lblInputInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblInputInfo.Visible = false;
            // 
            // panGroupTop
            // 
            this.panGroupTop.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupTop.Appearance.Options.UseBackColor = true;
            this.panGroupTop.AutoScroll = true;
            this.panGroupTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupTop.Controls.Add(this.panGroupTopRight);
            this.panGroupTop.Controls.Add(this.panGroupBottom);
            this.panGroupTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroupTop.Location = new System.Drawing.Point(0, 0);
            this.panGroupTop.Name = "panGroupTop";
            this.panGroupTop.Size = new System.Drawing.Size(713, 393);
            this.panGroupTop.TabIndex = 274;
            this.panGroupTop.Text = "panelControl1";
            // 
            // UCFabView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroupTop);
            this.Name = "UCFabView";
            this.Size = new System.Drawing.Size(713, 393);
            this.Load += new System.EventHandler(this.UCFabView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgOPType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupBottom)).EndInit();
            this.panGroupBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTop)).EndInit();
            this.panGroupTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGroupTopRight;
        private DevExpress.XtraEditors.RadioGroup radgOPType;
        private DevExpress.XtraEditors.PanelControl panGroupBottom;
        private DevExpress.XtraEditors.PanelControl panGroupTop;
        private System.Windows.Forms.Label lblInputInfo;
    }
}
