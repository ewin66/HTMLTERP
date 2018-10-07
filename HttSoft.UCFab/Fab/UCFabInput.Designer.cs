namespace HttSoft.UCFab
{
    partial class UCFabInput
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
            this.panGroupTop = new DevExpress.XtraEditors.PanelControl();
            this.panGroupBottom = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.drpInputNum = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnInputBatch = new DevExpress.XtraEditors.SimpleButton();
            this.radgOPType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTop)).BeginInit();
            this.panGroupTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupBottom)).BeginInit();
            this.panGroupBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgOPType.Properties)).BeginInit();
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
            this.panGroupTopRight.Size = new System.Drawing.Size(846, 529);
            this.panGroupTopRight.TabIndex = 274;
            this.panGroupTopRight.Text = "panelControl1";
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
            this.panGroupTop.Size = new System.Drawing.Size(846, 556);
            this.panGroupTop.TabIndex = 273;
            this.panGroupTop.Text = "panelControl1";
            // 
            // panGroupBottom
            // 
            this.panGroupBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupBottom.Appearance.Options.UseBackColor = true;
            this.panGroupBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupBottom.Controls.Add(this.label1);
            this.panGroupBottom.Controls.Add(this.drpInputNum);
            this.panGroupBottom.Controls.Add(this.btnInputBatch);
            this.panGroupBottom.Controls.Add(this.radgOPType);
            this.panGroupBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panGroupBottom.Location = new System.Drawing.Point(0, 529);
            this.panGroupBottom.Name = "panGroupBottom";
            this.panGroupBottom.Size = new System.Drawing.Size(846, 27);
            this.panGroupBottom.TabIndex = 275;
            this.panGroupBottom.Text = "panelControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 276;
            this.label1.Text = "录入格数";
            // 
            // drpInputNum
            // 
            this.drpInputNum.EditValue = "20";
            this.drpInputNum.Location = new System.Drawing.Point(316, 2);
            this.drpInputNum.Name = "drpInputNum";
            this.drpInputNum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpInputNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputNum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpInputNum.Properties.Items.AddRange(new object[] {
            "",
            "20",
            "50",
            "100",
            "150",
            "200",
            "250",
            "300",
            "400",
            "500"});
            this.drpInputNum.Properties.ShowPopupShadow = false;
            this.drpInputNum.Size = new System.Drawing.Size(78, 23);
            this.drpInputNum.TabIndex = 275;
            this.drpInputNum.ToolTip = "预留的录入格子数量";
            this.drpInputNum.EditValueChanged += new System.EventHandler(this.drpInputNum_EditValueChanged);
            // 
            // btnInputBatch
            // 
            this.btnInputBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInputBatch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnInputBatch.Location = new System.Drawing.Point(757, 2);
            this.btnInputBatch.Name = "btnInputBatch";
            this.btnInputBatch.Size = new System.Drawing.Size(76, 22);
            this.btnInputBatch.TabIndex = 274;
            this.btnInputBatch.Text = "批量录入";
            this.btnInputBatch.Click += new System.EventHandler(this.btnInputBatch_Click);
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
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "列表模式"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "磁贴模式")});
            this.radgOPType.Size = new System.Drawing.Size(250, 22);
            this.radgOPType.TabIndex = 273;
            this.radgOPType.SelectedIndexChanged += new System.EventHandler(this.radgOPType_SelectedIndexChanged);
            // 
            // UCFabInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroupTop);
            this.Name = "UCFabInput";
            this.Size = new System.Drawing.Size(846, 556);
            this.Load += new System.EventHandler(this.UCFabInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTop)).EndInit();
            this.panGroupTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panGroupBottom)).EndInit();
            this.panGroupBottom.ResumeLayout(false);
            this.panGroupBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgOPType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGroupTopRight;
        private DevExpress.XtraEditors.PanelControl panGroupTop;
        private DevExpress.XtraEditors.PanelControl panGroupBottom;
        private DevExpress.XtraEditors.RadioGroup radgOPType;
        private DevExpress.XtraEditors.SimpleButton btnInputBatch;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputNum;
        private System.Windows.Forms.Label label1;

    }
}
