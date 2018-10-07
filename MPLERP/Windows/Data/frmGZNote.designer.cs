namespace MLTERP
{
    partial class frmGZNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGZNote));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubmitFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumnDelFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.drpSaleOPID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtFormDateE = new DevExpress.XtraEditors.DateEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFormDateS = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.chkINDate = new DevExpress.XtraEditors.CheckEdit();
            this.txtFormNo = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpSaleOPID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormDateE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkINDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).BeginInit();
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
            this.groupControlDataList.Location = new System.Drawing.Point(0, 79);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(870, 359);
            this.groupControlDataList.TabIndex = 33;
            this.groupControlDataList.Text = "数据列表";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.EmbeddedNavigator.Name = "";
            this.gridControlDetail.Location = new System.Drawing.Point(2, 17);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.drpYesOrNo});
            this.gridControlDetail.Size = new System.Drawing.Size(866, 339);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnFormNo,
            this.gridColumnOPID,
            this.gridColumnOPName,
            this.gridColumnFormDate,
            this.gridColumnRemark,
            this.gridColumnSubmitFlag,
            this.gridColumnDelFlag});
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
            // gridColumnFormNo
            // 
            this.gridColumnFormNo.Caption = "报告编号";
            this.gridColumnFormNo.FieldName = "FormNo";
            this.gridColumnFormNo.Name = "gridColumnFormNo";
            this.gridColumnFormNo.Visible = true;
            this.gridColumnFormNo.VisibleIndex = 1;
            // 
            // gridColumnOPID
            // 
            this.gridColumnOPID.Caption = "员工编号";
            this.gridColumnOPID.FieldName = "OPID";
            this.gridColumnOPID.Name = "gridColumnOPID";
            this.gridColumnOPID.Visible = true;
            this.gridColumnOPID.VisibleIndex = 2;
            // 
            // gridColumnOPName
            // 
            this.gridColumnOPName.Caption = "员工";
            this.gridColumnOPName.FieldName = "OPName";
            this.gridColumnOPName.Name = "gridColumnOPName";
            this.gridColumnOPName.Visible = true;
            this.gridColumnOPName.VisibleIndex = 3;
            // 
            // gridColumnFormDate
            // 
            this.gridColumnFormDate.Caption = "日报时间";
            this.gridColumnFormDate.FieldName = "FormDate";
            this.gridColumnFormDate.Name = "gridColumnFormDate";
            this.gridColumnFormDate.Visible = true;
            this.gridColumnFormDate.VisibleIndex = 4;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "备注";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 5;
            // 
            // gridColumnSubmitFlag
            // 
            this.gridColumnSubmitFlag.Caption = "提交";
            this.gridColumnSubmitFlag.ColumnEdit = this.drpYesOrNo;
            this.gridColumnSubmitFlag.FieldName = "SubmitFlag";
            this.gridColumnSubmitFlag.Name = "gridColumnSubmitFlag";
            this.gridColumnSubmitFlag.Visible = true;
            this.gridColumnSubmitFlag.VisibleIndex = 6;
            // 
            // drpYesOrNo
            // 
            this.drpYesOrNo.AutoHeight = false;
            this.drpYesOrNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpYesOrNo.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1)});
            this.drpYesOrNo.Name = "drpYesOrNo";
            this.drpYesOrNo.SmallImages = this.BaseIlYesOrNo;
            // 
            // gridColumnDelFlag
            // 
            this.gridColumnDelFlag.FieldName = "DelFlag";
            this.gridColumnDelFlag.Name = "gridColumnDelFlag";
            this.gridColumnDelFlag.Visible = true;
            this.gridColumnDelFlag.VisibleIndex = 7;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.drpSaleOPID);
            this.groupControlQuery.Controls.Add(this.txtFormDateE);
            this.groupControlQuery.Controls.Add(this.label10);
            this.groupControlQuery.Controls.Add(this.txtFormDateS);
            this.groupControlQuery.Controls.Add(this.label6);
            this.groupControlQuery.Controls.Add(this.chkINDate);
            this.groupControlQuery.Controls.Add(this.txtFormNo);
            this.groupControlQuery.Controls.Add(this.label2);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(870, 54);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "查询条件";
            // 
            // drpSaleOPID
            // 
            this.drpSaleOPID.Location = new System.Drawing.Point(575, 19);
            this.drpSaleOPID.Name = "drpSaleOPID";
            this.drpSaleOPID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpSaleOPID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpSaleOPID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpSaleOPID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorName")});
            this.drpSaleOPID.Properties.NullText = "";
            this.drpSaleOPID.Properties.ShowFooter = false;
            this.drpSaleOPID.Properties.ShowHeader = false;
            this.drpSaleOPID.Size = new System.Drawing.Size(95, 23);
            this.drpSaleOPID.TabIndex = 754;
            this.drpSaleOPID.EditValueChanged += new System.EventHandler(this.txtFormNo_EditValueChanged);
            // 
            // txtFormDateE
            // 
            this.txtFormDateE.EditValue = "";
            this.txtFormDateE.Location = new System.Drawing.Point(416, 19);
            this.txtFormDateE.Name = "txtFormDateE";
            this.txtFormDateE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtFormDateE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormDateE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFormDateE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormDateE.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtFormDateE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFormDateE.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtFormDateE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFormDateE.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtFormDateE.Properties.ShowPopupShadow = false;
            this.txtFormDateE.Size = new System.Drawing.Size(90, 23);
            this.txtFormDateE.TabIndex = 753;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(538, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 751;
            this.label10.Text = "员工";
            // 
            // txtFormDateS
            // 
            this.txtFormDateS.EditValue = "";
            this.txtFormDateS.Location = new System.Drawing.Point(278, 20);
            this.txtFormDateS.Name = "txtFormDateS";
            this.txtFormDateS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtFormDateS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormDateS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFormDateS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormDateS.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtFormDateS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFormDateS.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtFormDateS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFormDateS.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtFormDateS.Properties.ShowPopupShadow = false;
            this.txtFormDateS.Size = new System.Drawing.Size(90, 23);
            this.txtFormDateS.TabIndex = 734;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(384, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 736;
            this.label6.Text = "至";
            // 
            // chkINDate
            // 
            this.chkINDate.EditValue = true;
            this.chkINDate.Location = new System.Drawing.Point(200, 21);
            this.chkINDate.Name = "chkINDate";
            this.chkINDate.Properties.Caption = "日报时间";
            this.chkINDate.Size = new System.Drawing.Size(72, 19);
            this.chkINDate.TabIndex = 737;
            this.chkINDate.CheckedChanged += new System.EventHandler(this.txtFormNo_EditValueChanged);
            // 
            // txtFormNo
            // 
            this.txtFormNo.EditValue = "";
            this.txtFormNo.Location = new System.Drawing.Point(79, 20);
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormNo.Size = new System.Drawing.Size(94, 23);
            this.txtFormNo.TabIndex = 732;
            this.txtFormNo.EditValueChanged += new System.EventHandler(this.txtFormNo_EditValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 733;
            this.label2.Text = "日报编号";
            // 
            // frmGZNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmGZNote";
            this.Text = "frmGZNote";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drpSaleOPID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormDateE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkINDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOPName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubmitFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDelFlag; 
  		
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpYesOrNo;
        private DevExpress.XtraEditors.TextEdit txtFormNo;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit txtFormDateS;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.CheckEdit chkINDate;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.DateEdit txtFormDateE;
        private DevExpress.XtraEditors.LookUpEdit drpSaleOPID;
    }
}