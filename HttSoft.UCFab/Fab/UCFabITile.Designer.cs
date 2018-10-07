namespace HttSoft.UCFab
{
    partial class UCFabITile
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
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.panTile = new DevExpress.XtraEditors.PanelControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).BeginInit();
            this.panTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo4
            // 
            this.lblInfo4.Location = new System.Drawing.Point(8, 64);
            this.lblInfo4.Name = "lblInfo4";
            this.lblInfo4.Size = new System.Drawing.Size(85, 20);
            this.lblInfo4.TabIndex = 272;
            this.lblInfo4.Text = "1234567890";
            // 
            // panTile
            // 
            this.panTile.Appearance.BackColor = System.Drawing.Color.White;
            this.panTile.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panTile.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panTile.Appearance.Options.UseBackColor = true;
            this.panTile.Appearance.Options.UseBorderColor = true;
            this.panTile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panTile.Controls.Add(this.txtQty);
            this.panTile.Controls.Add(this.txtCode);
            this.panTile.Controls.Add(this.lblInfo4);
            this.panTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTile.Location = new System.Drawing.Point(0, 0);
            this.panTile.Name = "panTile";
            this.panTile.Size = new System.Drawing.Size(97, 85);
            this.panTile.TabIndex = 269;
            this.panTile.Text = "panelControl1";
            // 
            // txtQty
            // 
            this.txtQty.EditValue = "202.5";
            this.txtQty.Location = new System.Drawing.Point(7, 35);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.txtQty.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtQty.Properties.Appearance.Options.UseFont = true;
            this.txtQty.Properties.Appearance.Options.UseForeColor = true;
            this.txtQty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtQty.Size = new System.Drawing.Size(83, 24);
            this.txtQty.TabIndex = 274;
            this.txtQty.EditValueChanged += new System.EventHandler(this.txtQty_EditValueChanged);
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "10";
            this.txtCode.Location = new System.Drawing.Point(7, 5);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.txtCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtCode.Size = new System.Drawing.Size(83, 24);
            this.txtCode.TabIndex = 273;
            this.txtCode.EditValueChanged += new System.EventHandler(this.txtCode_EditValueChanged);
            // 
            // UCFabITile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panTile);
            this.Name = "UCFabITile";
            this.Size = new System.Drawing.Size(97, 85);
            this.Load += new System.EventHandler(this.UCFabITile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).EndInit();
            this.panTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfo4;
        private DevExpress.XtraEditors.PanelControl panTile;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.TextEdit txtCode;
    }
}
