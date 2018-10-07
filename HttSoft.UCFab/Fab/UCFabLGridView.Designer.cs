namespace HttSoft.UCFab
{
    partial class UCFabLGridView
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
            this.panGroup = new DevExpress.XtraEditors.PanelControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkGridSelectFlag = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblFocus = new System.Windows.Forms.Label();
            this.cMenuLoadFab = new System.Windows.Forms.ContextMenuStrip();
            this.cmiLoadFabKP = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).BeginInit();
            this.panGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGridSelectFlag)).BeginInit();
            this.cMenuLoadFab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panGroup
            // 
            this.panGroup.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroup.Appearance.Options.UseBackColor = true;
            this.panGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroup.Controls.Add(this.gridControlDetail);
            this.panGroup.Controls.Add(this.lblFocus);
            this.panGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroup.Location = new System.Drawing.Point(0, 0);
            this.panGroup.Name = "panGroup";
            this.panGroup.Size = new System.Drawing.Size(674, 334);
            this.panGroup.TabIndex = 270;
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkGridSelectFlag});
            this.gridControlDetail.Size = new System.Drawing.Size(674, 334);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlDetail.Click += new System.EventHandler(this.gridControlDetail_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "选择";
            this.gridColumn1.ColumnEdit = this.chkGridSelectFlag;
            this.gridColumn1.FieldName = "SelectFlag";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 71;
            // 
            // chkGridSelectFlag
            // 
            this.chkGridSelectFlag.AutoHeight = false;
            this.chkGridSelectFlag.Caption = "Check";
            this.chkGridSelectFlag.Name = "chkGridSelectFlag";
            this.chkGridSelectFlag.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkGridSelectFlag.ValueChecked = 1;
            this.chkGridSelectFlag.ValueUnchecked = 0;
            this.chkGridSelectFlag.CheckedChanged += new System.EventHandler(this.chkGridSelectFlag_CheckedChanged);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "条码";
            this.gridColumn2.FieldName = "BoxNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 128;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "卷号";
            this.gridColumn3.FieldName = "SubSeq";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "品名";
            this.gridColumn4.FieldName = "ItemModel";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 89;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "数量";
            this.gridColumn5.FieldName = "Qty";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 84;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "缸号";
            this.gridColumn6.FieldName = "JarNum";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 136;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "重量";
            this.gridColumn7.FieldName = "Weight";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "等级";
            this.gridColumn8.FieldName = "GoodsLevel";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // lblFocus
            // 
            this.lblFocus.AutoSize = true;
            this.lblFocus.Location = new System.Drawing.Point(401, 97);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(35, 12);
            this.lblFocus.TabIndex = 34;
            this.lblFocus.Text = "focus";
            // 
            // cMenuLoadFab
            // 
            this.cMenuLoadFab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiLoadFabKP});
            this.cMenuLoadFab.Name = "cMenuLoadFab";
            this.cMenuLoadFab.Size = new System.Drawing.Size(117, 26);
            this.cMenuLoadFab.Opening += new System.ComponentModel.CancelEventHandler(this.cMenuLoadFab_Opening);
            // 
            // cmiLoadFabKP
            // 
            this.cmiLoadFabKP.Name = "cmiLoadFabKP";
            this.cmiLoadFabKP.Size = new System.Drawing.Size(116, 22);
            this.cmiLoadFabKP.Text = "开匹(&K)";
            this.cmiLoadFabKP.Click += new System.EventHandler(this.cmiLoadFabKP_Click);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "码数";
            this.gridColumn9.FieldName = "Yard";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // UCFabLGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroup);
            this.Name = "UCFabLGridView";
            this.Size = new System.Drawing.Size(674, 334);
            this.Load += new System.EventHandler(this.UCFabLGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).EndInit();
            this.panGroup.ResumeLayout(false);
            this.panGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGridSelectFlag)).EndInit();
            this.cMenuLoadFab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGroup;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkGridSelectFlag;
        private System.Windows.Forms.Label lblFocus;
        private System.Windows.Forms.ContextMenuStrip cMenuLoadFab;
        private System.Windows.Forms.ToolStripMenuItem cmiLoadFabKP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}
