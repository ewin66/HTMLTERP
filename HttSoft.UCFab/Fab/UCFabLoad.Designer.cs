namespace HttSoft.UCFab
{
    partial class UCFabLoad
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
            this.panGroupTop = new DevExpress.XtraEditors.PanelControl();
            this.panGroupTopRight = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.panGroupTopLeft = new DevExpress.XtraEditors.PanelControl();
            this.panGroupBottom = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radgViewType = new DevExpress.XtraEditors.RadioGroup();
            this.radgOPType = new DevExpress.XtraEditors.RadioGroup();
            this.btnSelectFan = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTop)).BeginInit();
            this.panGroupTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupBottom)).BeginInit();
            this.panGroupBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radgViewType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgOPType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panGroupTop
            // 
            this.panGroupTop.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupTop.Appearance.Options.UseBackColor = true;
            this.panGroupTop.AutoScroll = true;
            this.panGroupTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupTop.Controls.Add(this.panGroupTopRight);
            this.panGroupTop.Controls.Add(this.splitterControl2);
            this.panGroupTop.Controls.Add(this.panGroupTopLeft);
            this.panGroupTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroupTop.Location = new System.Drawing.Point(0, 0);
            this.panGroupTop.Name = "panGroupTop";
            this.panGroupTop.Size = new System.Drawing.Size(810, 516);
            this.panGroupTop.TabIndex = 271;
            this.panGroupTop.Text = "panelControl1";
            // 
            // panGroupTopRight
            // 
            this.panGroupTopRight.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupTopRight.Appearance.Options.UseBackColor = true;
            this.panGroupTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroupTopRight.Location = new System.Drawing.Point(0, 0);
            this.panGroupTopRight.Name = "panGroupTopRight";
            this.panGroupTopRight.Size = new System.Drawing.Size(810, 366);
            this.panGroupTopRight.TabIndex = 274;
            this.panGroupTopRight.Text = "panelControl1";
            // 
            // splitterControl2
            // 
            this.splitterControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl2.Location = new System.Drawing.Point(0, 366);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(810, 4);
            this.splitterControl2.TabIndex = 24;
            this.splitterControl2.TabStop = false;
            // 
            // panGroupTopLeft
            // 
            this.panGroupTopLeft.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupTopLeft.Appearance.Options.UseBackColor = true;
            this.panGroupTopLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupTopLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panGroupTopLeft.Location = new System.Drawing.Point(0, 370);
            this.panGroupTopLeft.Name = "panGroupTopLeft";
            this.panGroupTopLeft.Size = new System.Drawing.Size(810, 146);
            this.panGroupTopLeft.TabIndex = 273;
            this.panGroupTopLeft.Text = "panelControl1";
            // 
            // panGroupBottom
            // 
            this.panGroupBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupBottom.Appearance.Options.UseBackColor = true;
            this.panGroupBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupBottom.Controls.Add(this.label2);
            this.panGroupBottom.Controls.Add(this.label1);
            this.panGroupBottom.Controls.Add(this.radgViewType);
            this.panGroupBottom.Controls.Add(this.radgOPType);
            this.panGroupBottom.Controls.Add(this.btnSelectFan);
            this.panGroupBottom.Controls.Add(this.btnSelectAll);
            this.panGroupBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panGroupBottom.Location = new System.Drawing.Point(0, 516);
            this.panGroupBottom.Name = "panGroupBottom";
            this.panGroupBottom.Size = new System.Drawing.Size(810, 27);
            this.panGroupBottom.TabIndex = 272;
            this.panGroupBottom.Text = "panelControl1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 276;
            this.label2.Text = "操作:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 275;
            this.label1.Text = "显示:";
            // 
            // radgViewType
            // 
            this.radgViewType.EditValue = 1;
            this.radgViewType.Location = new System.Drawing.Point(48, 2);
            this.radgViewType.Name = "radgViewType";
            this.radgViewType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radgViewType.Properties.Columns = 3;
            this.radgViewType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "横向模式"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "列表模式")});
            this.radgViewType.Size = new System.Drawing.Size(225, 22);
            this.radgViewType.TabIndex = 274;
            this.radgViewType.SelectedIndexChanged += new System.EventHandler(this.radgViewType_SelectedIndexChanged);
            // 
            // radgOPType
            // 
            this.radgOPType.EditValue = 1;
            this.radgOPType.Location = new System.Drawing.Point(444, 2);
            this.radgOPType.Name = "radgOPType";
            this.radgOPType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radgOPType.Properties.Columns = 3;
            this.radgOPType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "磁贴模式"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "列表模式"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "简洁模式")});
            this.radgOPType.Size = new System.Drawing.Size(270, 22);
            this.radgOPType.TabIndex = 273;
            this.radgOPType.SelectedIndexChanged += new System.EventHandler(this.radgOPType_SelectedIndexChanged);
            // 
            // btnSelectFan
            // 
            this.btnSelectFan.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSelectFan.Location = new System.Drawing.Point(767, 2);
            this.btnSelectFan.Name = "btnSelectFan";
            this.btnSelectFan.Size = new System.Drawing.Size(35, 22);
            this.btnSelectFan.TabIndex = 272;
            this.btnSelectFan.Text = "反选";
            this.btnSelectFan.Click += new System.EventHandler(this.btnSelectFan_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSelectAll.Location = new System.Drawing.Point(715, 2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(35, 22);
            this.btnSelectAll.TabIndex = 271;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // UCFabLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroupTop);
            this.Controls.Add(this.panGroupBottom);
            this.Name = "UCFabLoad";
            this.Size = new System.Drawing.Size(810, 543);
            this.Load += new System.EventHandler(this.UCFabLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTop)).EndInit();
            this.panGroupTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupBottom)).EndInit();
            this.panGroupBottom.ResumeLayout(false);
            this.panGroupBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radgViewType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgOPType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGroupTop;
        private DevExpress.XtraEditors.PanelControl panGroupBottom;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.PanelControl panGroupTopLeft;
        private DevExpress.XtraEditors.PanelControl panGroupTopRight;
        private DevExpress.XtraEditors.SimpleButton btnSelectFan;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.RadioGroup radgOPType;
        private DevExpress.XtraEditors.RadioGroup radgViewType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
