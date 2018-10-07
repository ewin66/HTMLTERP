namespace MLTERP
{
    partial class frmSaleProcedure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleProcedure));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnShowFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnJGUseFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnJGItemTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnJGWHIDDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnJGFormListID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPackCheckFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
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
            // groupControlDataList
            // 
            this.groupControlDataList.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlDataList.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlDataList.Controls.Add(this.gridControlDetail);
            this.groupControlDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDataList.Location = new System.Drawing.Point(0, 73);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(870, 365);
            this.groupControlDataList.TabIndex = 33;
            this.groupControlDataList.Text = "数据列表";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.EmbeddedNavigator.Name = "";
            this.gridControlDetail.Location = new System.Drawing.Point(4, 19);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.drpYesOrNo});
            this.gridControlDetail.Size = new System.Drawing.Size(862, 342);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnCode,
            this.gridColumnName,
            this.gridColumnShowFlag,
            this.gridColumnRemark,
            this.gridColumnJGUseFlag,
            this.gridColumnJGItemTypeID,
            this.gridColumnJGWHIDDefault,
            this.gridColumnJGFormListID,
            this.gridColumnPackCheckFlag,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "流程编号";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 1;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "流程名称";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 2;
            // 
            // gridColumnShowFlag
            // 
            this.gridColumnShowFlag.Caption = "显示标志";
            this.gridColumnShowFlag.ColumnEdit = this.drpYesOrNo;
            this.gridColumnShowFlag.FieldName = "ShowFlag";
            this.gridColumnShowFlag.Name = "gridColumnShowFlag";
            this.gridColumnShowFlag.Visible = true;
            this.gridColumnShowFlag.VisibleIndex = 3;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "备注";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 4;
            // 
            // gridColumnJGUseFlag
            // 
            this.gridColumnJGUseFlag.Caption = "加工扣料标志";
            this.gridColumnJGUseFlag.ColumnEdit = this.drpYesOrNo;
            this.gridColumnJGUseFlag.FieldName = "JGUseFlag";
            this.gridColumnJGUseFlag.Name = "gridColumnJGUseFlag";
            this.gridColumnJGUseFlag.Visible = true;
            this.gridColumnJGUseFlag.VisibleIndex = 5;
            // 
            // gridColumnJGItemTypeID
            // 
            this.gridColumnJGItemTypeID.Caption = "扣料物品类型ID";
            this.gridColumnJGItemTypeID.FieldName = "JGItemTypeID";
            this.gridColumnJGItemTypeID.Name = "gridColumnJGItemTypeID";
            this.gridColumnJGItemTypeID.Visible = true;
            this.gridColumnJGItemTypeID.VisibleIndex = 6;
            // 
            // gridColumnJGWHIDDefault
            // 
            this.gridColumnJGWHIDDefault.Caption = "扣料仓库ID";
            this.gridColumnJGWHIDDefault.FieldName = "JGWHIDDefault";
            this.gridColumnJGWHIDDefault.Name = "gridColumnJGWHIDDefault";
            this.gridColumnJGWHIDDefault.Visible = true;
            this.gridColumnJGWHIDDefault.VisibleIndex = 7;
            // 
            // gridColumnJGFormListID
            // 
            this.gridColumnJGFormListID.Caption = "扣料仓库单据ID";
            this.gridColumnJGFormListID.FieldName = "JGFormListID";
            this.gridColumnJGFormListID.Name = "gridColumnJGFormListID";
            this.gridColumnJGFormListID.Visible = true;
            this.gridColumnJGFormListID.VisibleIndex = 8;
            // 
            // gridColumnPackCheckFlag
            // 
            this.gridColumnPackCheckFlag.Caption = "验布标志";
            this.gridColumnPackCheckFlag.ColumnEdit = this.drpYesOrNo;
            this.gridColumnPackCheckFlag.FieldName = "PackCheckFlag";
            this.gridColumnPackCheckFlag.Name = "gridColumnPackCheckFlag";
            this.gridColumnPackCheckFlag.Visible = true;
            this.gridColumnPackCheckFlag.VisibleIndex = 9;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.label17);
            this.groupControlQuery.Controls.Add(this.txtName);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(870, 48);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "查询条件";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "扣料物品类型";
            this.gridColumn1.FieldName = "ItemType";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "扣料仓库";
            this.gridColumn2.FieldName = "WHNM";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "扣料仓库单据";
            this.gridColumn3.FieldName = "FormNM";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 12;
            // 
            // drpYesOrNo
            // 
            this.drpYesOrNo.AutoHeight = false;
            this.drpYesOrNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpYesOrNo.CycleOnDblClick = false;
            this.drpYesOrNo.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1)});
            this.drpYesOrNo.Name = "drpYesOrNo";
            this.drpYesOrNo.SmallImages = this.BaseIlYesOrNo;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 27;
            this.label17.Text = "流程名称";
            // 
            // txtName
            // 
            this.txtName.EditValue = "";
            this.txtName.Location = new System.Drawing.Point(81, 18);
            this.txtName.Name = "txtName";
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtName.Size = new System.Drawing.Size(160, 23);
            this.txtName.TabIndex = 26;
            // 
            // frmSaleProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmSaleProcedure";
            this.Text = "frmSaleProcedure";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnShowFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnJGUseFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnJGItemTypeID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnJGWHIDDefault; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnJGFormListID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPackCheckFlag; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpYesOrNo;
        private System.Windows.Forms.Label label17;
        private DevExpress.XtraEditors.TextEdit txtName;
    }
}