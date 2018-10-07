namespace HttSoft.UCFab
{
    partial class UCFabIGridView
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
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkGridSelectFlag = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSubSeq = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panGroup = new DevExpress.XtraEditors.PanelControl();
            this.lblFocus = new System.Windows.Forms.Label();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGridSelectFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).BeginInit();
            this.panGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "品名";
            this.gridColumn4.FieldName = "ItemModel";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Width = 89;
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkGridSelectFlag,
            this.txtQty,
            this.txtSubSeq});
            this.gridControlDetail.Size = new System.Drawing.Size(605, 440);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.gridColumn8,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn9});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "选择";
            this.gridColumn1.ColumnEdit = this.chkGridSelectFlag;
            this.gridColumn1.FieldName = "SelectFlag";
            this.gridColumn1.Name = "gridColumn1";
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
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "等级";
            this.gridColumn8.FieldName = "GoodsLevel";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "条码";
            this.gridColumn2.FieldName = "BoxNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "卷号";
            this.gridColumn3.ColumnEdit = this.txtSubSeq;
            this.gridColumn3.FieldName = "SubSeq";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 144;
            // 
            // txtSubSeq
            // 
            this.txtSubSeq.AutoHeight = false;
            this.txtSubSeq.Name = "txtSubSeq";
            this.txtSubSeq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubSeq_KeyDown);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "米数";
            this.gridColumn5.ColumnEdit = this.txtQty;
            this.gridColumn5.FieldName = "Qty";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 147;
            // 
            // txtQty
            // 
            this.txtQty.AutoHeight = false;
            this.txtQty.Name = "txtQty";
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "重量";
            this.gridColumn7.ColumnEdit = this.txtQty;
            this.gridColumn7.FieldName = "Weight";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "缸号";
            this.gridColumn6.FieldName = "JarNum";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Width = 136;
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
            this.panGroup.Size = new System.Drawing.Size(605, 440);
            this.panGroup.TabIndex = 271;
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
            // gridColumn9
            // 
            this.gridColumn9.Caption = "码数";
            this.gridColumn9.ColumnEdit = this.txtQty;
            this.gridColumn9.FieldName = "Yard";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // UCFabIGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroup);
            this.Name = "UCFabIGridView";
            this.Size = new System.Drawing.Size(605, 440);
            this.Load += new System.EventHandler(this.UCFabIGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGridSelectFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).EndInit();
            this.panGroup.ResumeLayout(false);
            this.panGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkGridSelectFlag;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.PanelControl panGroup;
        private System.Windows.Forms.Label lblFocus;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtSubSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}
