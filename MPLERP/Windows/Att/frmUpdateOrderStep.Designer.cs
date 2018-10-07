namespace MLTERP
{
    partial class frmUpdateOrderStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateOrderStep));
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.drpOrderStep = new DevExpress.XtraEditors.LookUpEdit();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpOrderStep.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseIlYesOrNo
            // 
            this.BaseIlYesOrNo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlYesOrNo.ImageStream")));
            this.BaseIlYesOrNo.Images.SetKeyName(0, "");
            this.BaseIlYesOrNo.Images.SetKeyName(1, "");
            // 
            // BaseIlAll
            // 
            this.BaseIlAll.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlAll.ImageStream")));
            this.BaseIlAll.Images.SetKeyName(0, "");
            this.BaseIlAll.Images.SetKeyName(1, "");
            this.BaseIlAll.Images.SetKeyName(2, "");
            this.BaseIlAll.Images.SetKeyName(3, "");
            this.BaseIlAll.Images.SetKeyName(4, "");
            this.BaseIlAll.Images.SetKeyName(5, "");
            this.BaseIlAll.Images.SetKeyName(6, "");
            this.BaseIlAll.Images.SetKeyName(7, "");
            this.BaseIlAll.Images.SetKeyName(8, "");
            this.BaseIlAll.Images.SetKeyName(9, "");
            this.BaseIlAll.Images.SetKeyName(10, "");
            this.BaseIlAll.Images.SetKeyName(11, "");
            this.BaseIlAll.Images.SetKeyName(12, "");
            this.BaseIlAll.Images.SetKeyName(13, "");
            this.BaseIlAll.Images.SetKeyName(14, "");
            this.BaseIlAll.Images.SetKeyName(15, "");
            this.BaseIlAll.Images.SetKeyName(16, "");
            this.BaseIlAll.Images.SetKeyName(17, "");
            this.BaseIlAll.Images.SetKeyName(18, "");
            this.BaseIlAll.Images.SetKeyName(19, "");
            this.BaseIlAll.Images.SetKeyName(20, "");
            this.BaseIlAll.Images.SetKeyName(21, "");
            this.BaseIlAll.Images.SetKeyName(22, "");
            this.BaseIlAll.Images.SetKeyName(23, "");
            this.BaseIlAll.Images.SetKeyName(24, "");
            this.BaseIlAll.Images.SetKeyName(25, "");
            this.BaseIlAll.Images.SetKeyName(26, "");
            this.BaseIlAll.Images.SetKeyName(27, "");
            this.BaseIlAll.Images.SetKeyName(28, "");
            this.BaseIlAll.Images.SetKeyName(29, "");
            this.BaseIlAll.Images.SetKeyName(30, "");
            this.BaseIlAll.Images.SetKeyName(31, "");
            this.BaseIlAll.Images.SetKeyName(32, "");
            this.BaseIlAll.Images.SetKeyName(33, "");
            this.BaseIlAll.Images.SetKeyName(34, "");
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlQuery.Controls.Add(this.drpOrderStep);
            this.groupControlQuery.Controls.Add(this.btnLoad);
            this.groupControlQuery.Controls.Add(this.label1);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 0);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(256, 49);
            this.groupControlQuery.TabIndex = 34;
            // 
            // drpOrderStep
            // 
            this.drpOrderStep.Location = new System.Drawing.Point(47, 13);
            this.drpOrderStep.Name = "drpOrderStep";
            this.drpOrderStep.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpOrderStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpOrderStep.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpOrderStep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorName")});
            this.drpOrderStep.Properties.NullText = "";
            this.drpOrderStep.Properties.ShowFooter = false;
            this.drpOrderStep.Properties.ShowHeader = false;
            this.drpOrderStep.Size = new System.Drawing.Size(117, 23);
            this.drpOrderStep.TabIndex = 269;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(185, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(49, 23);
            this.btnLoad.TabIndex = 268;
            this.btnLoad.Text = "确定";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 267;
            this.label1.Text = "站别";
            // 
            // frmUpdateOrderStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 49);
            this.Controls.Add(this.groupControlQuery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "frmUpdateOrderStep";
            this.Text = "修改销售合同站别";
            this.Load += new System.EventHandler(this.frmWait_Load);
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpOrderStep.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private DevExpress.XtraEditors.LookUpEdit drpOrderStep;
    }
}