namespace MLTERP
{
    partial class frmCostRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostRegister));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubmitFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDelFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.txtQFormNo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMakeDateS = new DevExpress.XtraEditors.DateEdit();
            this.txtMakeDateE = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbMakeDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQFormNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties)).BeginInit();
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
            this.gridControlDetail.Location = new System.Drawing.Point(2, 17);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(866, 345);
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
            this.gridColumnCheckOPID,
            this.gridColumnCheckDate,
            this.gridColumnMakeOPID,
            this.gridColumnMakeOPName,
            this.gridColumnMakeDate,
            this.gridColumnSubmitFlag,
            this.gridColumnDelFlag,
            this.gridColumnRemark,
            this.gridColumnTotalAmount});
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
            this.gridColumnFormNo.Caption = "单号";
            this.gridColumnFormNo.FieldName = "FormNo";
            this.gridColumnFormNo.Name = "gridColumnFormNo";
            this.gridColumnFormNo.Visible = true;
            this.gridColumnFormNo.VisibleIndex = 1;
            // 
            // gridColumnCheckOPID
            // 
            this.gridColumnCheckOPID.Caption = "审核人ID";
            this.gridColumnCheckOPID.FieldName = "CheckOPID";
            this.gridColumnCheckOPID.Name = "gridColumnCheckOPID";
            this.gridColumnCheckOPID.Visible = true;
            this.gridColumnCheckOPID.VisibleIndex = 2;
            // 
            // gridColumnCheckDate
            // 
            this.gridColumnCheckDate.Caption = "审核日期";
            this.gridColumnCheckDate.FieldName = "CheckDate";
            this.gridColumnCheckDate.Name = "gridColumnCheckDate";
            this.gridColumnCheckDate.Visible = true;
            this.gridColumnCheckDate.VisibleIndex = 3;
            // 
            // gridColumnMakeOPID
            // 
            this.gridColumnMakeOPID.Caption = "制单人ID";
            this.gridColumnMakeOPID.FieldName = "MakeOPID";
            this.gridColumnMakeOPID.Name = "gridColumnMakeOPID";
            this.gridColumnMakeOPID.Visible = true;
            this.gridColumnMakeOPID.VisibleIndex = 4;
            // 
            // gridColumnMakeOPName
            // 
            this.gridColumnMakeOPName.Caption = "制单人";
            this.gridColumnMakeOPName.FieldName = "MakeOPName";
            this.gridColumnMakeOPName.Name = "gridColumnMakeOPName";
            this.gridColumnMakeOPName.Visible = true;
            this.gridColumnMakeOPName.VisibleIndex = 5;
            // 
            // gridColumnMakeDate
            // 
            this.gridColumnMakeDate.Caption = "制单日期";
            this.gridColumnMakeDate.FieldName = "MakeDate";
            this.gridColumnMakeDate.Name = "gridColumnMakeDate";
            this.gridColumnMakeDate.Visible = true;
            this.gridColumnMakeDate.VisibleIndex = 6;
            // 
            // gridColumnSubmitFlag
            // 
            this.gridColumnSubmitFlag.Caption = "提交标识";
            this.gridColumnSubmitFlag.FieldName = "SubmitFlag";
            this.gridColumnSubmitFlag.Name = "gridColumnSubmitFlag";
            this.gridColumnSubmitFlag.Visible = true;
            this.gridColumnSubmitFlag.VisibleIndex = 7;
            // 
            // gridColumnDelFlag
            // 
            this.gridColumnDelFlag.Caption = "删除标志";
            this.gridColumnDelFlag.FieldName = "DelFlag";
            this.gridColumnDelFlag.Name = "gridColumnDelFlag";
            this.gridColumnDelFlag.Visible = true;
            this.gridColumnDelFlag.VisibleIndex = 8;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "备注";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 9;
            // 
            // gridColumnTotalAmount
            // 
            this.gridColumnTotalAmount.Caption = "总金额";
            this.gridColumnTotalAmount.FieldName = "TotalAmount";
            this.gridColumnTotalAmount.Name = "gridColumnTotalAmount";
            this.gridColumnTotalAmount.Visible = true;
            this.gridColumnTotalAmount.VisibleIndex = 10;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.ckbMakeDate);
            this.groupControlQuery.Controls.Add(this.label2);
            this.groupControlQuery.Controls.Add(this.txtMakeDateE);
            this.groupControlQuery.Controls.Add(this.txtQFormNo);
            this.groupControlQuery.Controls.Add(this.label1);
            this.groupControlQuery.Controls.Add(this.txtMakeDateS);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(870, 48);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "查询条件";
            // 
            // txtQFormNo
            // 
            this.txtQFormNo.EditValue = "";
            this.txtQFormNo.Location = new System.Drawing.Point(57, 17);
            this.txtQFormNo.Name = "txtQFormNo";
            this.txtQFormNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQFormNo.Size = new System.Drawing.Size(99, 23);
            this.txtQFormNo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "单号";
            // 
            // txtMakeDateS
            // 
            this.txtMakeDateS.EditValue = "";
            this.txtMakeDateS.Location = new System.Drawing.Point(255, 17);
            this.txtMakeDateS.Name = "txtMakeDateS";
            this.txtMakeDateS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtMakeDateS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMakeDateS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateS.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateS.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateS.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtMakeDateS.Properties.ShowPopupShadow = false;
            this.txtMakeDateS.Size = new System.Drawing.Size(92, 23);
            this.txtMakeDateS.TabIndex = 14;
            // 
            // txtMakeDateE
            // 
            this.txtMakeDateE.EditValue = "";
            this.txtMakeDateE.Location = new System.Drawing.Point(376, 17);
            this.txtMakeDateE.Name = "txtMakeDateE";
            this.txtMakeDateE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtMakeDateE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMakeDateE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateE.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateE.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateE.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtMakeDateE.Properties.ShowPopupShadow = false;
            this.txtMakeDateE.Size = new System.Drawing.Size(92, 23);
            this.txtMakeDateE.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "至";
            // 
            // ckbMakeDate
            // 
            this.ckbMakeDate.AutoSize = true;
            this.ckbMakeDate.Checked = true;
            this.ckbMakeDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMakeDate.Location = new System.Drawing.Point(177, 20);
            this.ckbMakeDate.Name = "ckbMakeDate";
            this.ckbMakeDate.Size = new System.Drawing.Size(72, 16);
            this.ckbMakeDate.TabIndex = 29;
            this.ckbMakeDate.Text = "制单日期";
            this.ckbMakeDate.UseVisualStyleBackColor = true;
            // 
            // frmCostRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmCostRegister";
            this.Text = "frmCostRegister";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtQFormNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubmitFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDelFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalAmount; 
  		
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit txtMakeDateE;
        private DevExpress.XtraEditors.TextEdit txtQFormNo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit txtMakeDateS;
        private System.Windows.Forms.CheckBox ckbMakeDate;
    }
}