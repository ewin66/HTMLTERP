namespace MLTERP
{
    partial class frmJSVendorAmount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJSVendorAmount));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVendorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBPieceQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUpdateOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.label6 = new System.Windows.Forms.Label();
            this.drpVendorID = new DevExpress.XtraEditors.LookUpEdit();
            this.lbVendor = new System.Windows.Forms.Label();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpVendorID.Properties)).BeginInit();
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
            this.gridColumnVendorID,
            this.gridColumnBQty,
            this.gridColumnBPieceQty,
            this.gridColumnBAmount,
            this.gridColumnRemark,
            this.gridColumnUpdateOP,
            this.gridColumnUpdateDate,
            this.gridColumn1,
            this.gridColumn2});
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
            // gridColumnVendorID
            // 
            this.gridColumnVendorID.Caption = "客户编码";
            this.gridColumnVendorID.FieldName = "VendorID";
            this.gridColumnVendorID.Name = "gridColumnVendorID";
            this.gridColumnVendorID.Visible = true;
            this.gridColumnVendorID.VisibleIndex = 1;
            // 
            // gridColumnBQty
            // 
            this.gridColumnBQty.Caption = "期初数量";
            this.gridColumnBQty.FieldName = "BQty";
            this.gridColumnBQty.Name = "gridColumnBQty";
            this.gridColumnBQty.Visible = true;
            this.gridColumnBQty.VisibleIndex = 2;
            // 
            // gridColumnBPieceQty
            // 
            this.gridColumnBPieceQty.Caption = "期初件数";
            this.gridColumnBPieceQty.FieldName = "BPieceQty";
            this.gridColumnBPieceQty.Name = "gridColumnBPieceQty";
            this.gridColumnBPieceQty.Visible = true;
            this.gridColumnBPieceQty.VisibleIndex = 3;
            // 
            // gridColumnBAmount
            // 
            this.gridColumnBAmount.Caption = "期初金额";
            this.gridColumnBAmount.FieldName = "BAmount";
            this.gridColumnBAmount.Name = "gridColumnBAmount";
            this.gridColumnBAmount.Visible = true;
            this.gridColumnBAmount.VisibleIndex = 4;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "备注";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 5;
            // 
            // gridColumnUpdateOP
            // 
            this.gridColumnUpdateOP.Caption = "维护人";
            this.gridColumnUpdateOP.FieldName = "UpdateOP";
            this.gridColumnUpdateOP.Name = "gridColumnUpdateOP";
            this.gridColumnUpdateOP.Visible = true;
            this.gridColumnUpdateOP.VisibleIndex = 6;
            // 
            // gridColumnUpdateDate
            // 
            this.gridColumnUpdateDate.Caption = "维护时间";
            this.gridColumnUpdateDate.FieldName = "UpdateDate";
            this.gridColumnUpdateDate.Name = "gridColumnUpdateDate";
            this.gridColumnUpdateDate.Visible = true;
            this.gridColumnUpdateDate.VisibleIndex = 7;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "客户";
            this.gridColumn1.FieldName = "VendorName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.label6);
            this.groupControlQuery.Controls.Add(this.drpVendorID);
            this.groupControlQuery.Controls.Add(this.lbVendor);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(870, 48);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "查询条件";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 766;
            // 
            // drpVendorID
            // 
            this.drpVendorID.Location = new System.Drawing.Point(53, 18);
            this.drpVendorID.Name = "drpVendorID";
            this.drpVendorID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpVendorID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpVendorID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpVendorID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorName")});
            this.drpVendorID.Properties.NullText = "";
            this.drpVendorID.Properties.ShowFooter = false;
            this.drpVendorID.Properties.ShowHeader = false;
            this.drpVendorID.Size = new System.Drawing.Size(133, 23);
            this.drpVendorID.TabIndex = 764;
            // 
            // lbVendor
            // 
            this.lbVendor.AutoSize = true;
            this.lbVendor.Location = new System.Drawing.Point(18, 24);
            this.lbVendor.Name = "lbVendor";
            this.lbVendor.Size = new System.Drawing.Size(29, 12);
            this.lbVendor.TabIndex = 765;
            this.lbVendor.Text = "单位";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "客户";
            this.gridColumn2.FieldName = "VendorNameEN";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            // 
            // frmBVendorAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmJSVendorAmount";
            this.Text = "frmJSVendorAmount";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpVendorID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVendorID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnBQty; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnBPieceQty; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnBAmount; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnUpdateOP; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnUpdateDate; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit drpVendorID;
        private System.Windows.Forms.Label lbVendor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}