namespace MLTERP
{
    partial class frmTestReport
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestReport));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderFormNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnColorNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnColorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSaleOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTestOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSXShrinkageJX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSXShrinkageWX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnYTShrinkageJX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnYTShrinkageWX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubmitFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDelFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.txtFormNo = new DevExpress.XtraEditors.TextEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.lbVendor = new System.Windows.Forms.Label();
            this.drpSaleOPID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMakeDateE = new DevExpress.XtraEditors.DateEdit();
            this.txtMakeDateS = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.chkMakeDate = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpSaleOPID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMakeDate.Properties)).BeginInit();
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
            this.groupControlDataList.Text = "�����б�";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(2, 22);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(866, 341);
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
            this.gridColumnFormDate,
            this.gridColumnOrderFormNo,
            this.gridColumnItemCode,
            this.gridColumnItemName,
            this.gridColumnItemStd,
            this.gridColumnItemModel,
            this.gridColumnColorNum,
            this.gridColumnColorName,
            this.gridColumnSaleOPID,
            this.gridColumnTestOPID,
            this.gridColumnItemSource,
            this.gridColumnSXShrinkageJX,
            this.gridColumnSXShrinkageWX,
            this.gridColumnYTShrinkageJX,
            this.gridColumnYTShrinkageWX,
            this.gridColumnMakeOPID,
            this.gridColumnMakeOPName,
            this.gridColumnMakeDate,
            this.gridColumnCheckOPID,
            this.gridColumnCheckDate,
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
            this.gridColumnFormNo.Caption = "����";
            this.gridColumnFormNo.FieldName = "FormNo";
            this.gridColumnFormNo.Name = "gridColumnFormNo";
            this.gridColumnFormNo.Visible = true;
            this.gridColumnFormNo.VisibleIndex = 1;
            // 
            // gridColumnFormDate
            // 
            this.gridColumnFormDate.Caption = "��������";
            this.gridColumnFormDate.FieldName = "FormDate";
            this.gridColumnFormDate.Name = "gridColumnFormDate";
            this.gridColumnFormDate.Visible = true;
            this.gridColumnFormDate.VisibleIndex = 2;
            // 
            // gridColumnOrderFormNo
            // 
            this.gridColumnOrderFormNo.Caption = "��ͬ��";
            this.gridColumnOrderFormNo.FieldName = "OrderFormNo";
            this.gridColumnOrderFormNo.Name = "gridColumnOrderFormNo";
            this.gridColumnOrderFormNo.Visible = true;
            this.gridColumnOrderFormNo.VisibleIndex = 3;
            // 
            // gridColumnItemCode
            // 
            this.gridColumnItemCode.Caption = "��Ʒ����";
            this.gridColumnItemCode.FieldName = "ItemCode";
            this.gridColumnItemCode.Name = "gridColumnItemCode";
            this.gridColumnItemCode.Visible = true;
            this.gridColumnItemCode.VisibleIndex = 4;
            // 
            // gridColumnItemName
            // 
            this.gridColumnItemName.Caption = "�ɷ�";
            this.gridColumnItemName.FieldName = "ItemName";
            this.gridColumnItemName.Name = "gridColumnItemName";
            this.gridColumnItemName.Visible = true;
            this.gridColumnItemName.VisibleIndex = 5;
            // 
            // gridColumnItemStd
            // 
            this.gridColumnItemStd.Caption = "���";
            this.gridColumnItemStd.FieldName = "ItemStd";
            this.gridColumnItemStd.Name = "gridColumnItemStd";
            this.gridColumnItemStd.Visible = true;
            this.gridColumnItemStd.VisibleIndex = 6;
            // 
            // gridColumnItemModel
            // 
            this.gridColumnItemModel.Caption = "Ʒ��";
            this.gridColumnItemModel.FieldName = "ItemModel";
            this.gridColumnItemModel.Name = "gridColumnItemModel";
            this.gridColumnItemModel.Visible = true;
            this.gridColumnItemModel.VisibleIndex = 7;
            // 
            // gridColumnColorNum
            // 
            this.gridColumnColorNum.Caption = "ɫ��";
            this.gridColumnColorNum.FieldName = "ColorNum";
            this.gridColumnColorNum.Name = "gridColumnColorNum";
            this.gridColumnColorNum.Visible = true;
            this.gridColumnColorNum.VisibleIndex = 8;
            // 
            // gridColumnColorName
            // 
            this.gridColumnColorName.Caption = "��ɫ";
            this.gridColumnColorName.FieldName = "ColorName";
            this.gridColumnColorName.Name = "gridColumnColorName";
            this.gridColumnColorName.Visible = true;
            this.gridColumnColorName.VisibleIndex = 9;
            // 
            // gridColumnSaleOPID
            // 
            this.gridColumnSaleOPID.Caption = "ҵ��Ա";
            this.gridColumnSaleOPID.FieldName = "SaleOPID";
            this.gridColumnSaleOPID.Name = "gridColumnSaleOPID";
            this.gridColumnSaleOPID.Visible = true;
            this.gridColumnSaleOPID.VisibleIndex = 10;
            // 
            // gridColumnTestOPID
            // 
            this.gridColumnTestOPID.Caption = "����Ա";
            this.gridColumnTestOPID.FieldName = "TestOPID";
            this.gridColumnTestOPID.Name = "gridColumnTestOPID";
            this.gridColumnTestOPID.Visible = true;
            this.gridColumnTestOPID.VisibleIndex = 11;
            // 
            // gridColumnItemSource
            // 
            this.gridColumnItemSource.Caption = "������Դ";
            this.gridColumnItemSource.FieldName = "ItemSource";
            this.gridColumnItemSource.Name = "gridColumnItemSource";
            this.gridColumnItemSource.Visible = true;
            this.gridColumnItemSource.VisibleIndex = 12;
            // 
            // gridColumnSXShrinkageJX
            // 
            this.gridColumnSXShrinkageJX.Caption = "ˮϴ���ʾ���";
            this.gridColumnSXShrinkageJX.FieldName = "SXShrinkageJX";
            this.gridColumnSXShrinkageJX.Name = "gridColumnSXShrinkageJX";
            this.gridColumnSXShrinkageJX.Visible = true;
            this.gridColumnSXShrinkageJX.VisibleIndex = 13;
            // 
            // gridColumnSXShrinkageWX
            // 
            this.gridColumnSXShrinkageWX.Caption = "ˮϴ����γ��";
            this.gridColumnSXShrinkageWX.FieldName = "SXShrinkageWX";
            this.gridColumnSXShrinkageWX.Name = "gridColumnSXShrinkageWX";
            this.gridColumnSXShrinkageWX.Visible = true;
            this.gridColumnSXShrinkageWX.VisibleIndex = 14;
            // 
            // gridColumnYTShrinkageJX
            // 
            this.gridColumnYTShrinkageJX.Caption = "�������ʾ���";
            this.gridColumnYTShrinkageJX.FieldName = "YTShrinkageJX";
            this.gridColumnYTShrinkageJX.Name = "gridColumnYTShrinkageJX";
            this.gridColumnYTShrinkageJX.Visible = true;
            this.gridColumnYTShrinkageJX.VisibleIndex = 15;
            // 
            // gridColumnYTShrinkageWX
            // 
            this.gridColumnYTShrinkageWX.Caption = "��������γ��";
            this.gridColumnYTShrinkageWX.FieldName = "YTShrinkageWX";
            this.gridColumnYTShrinkageWX.Name = "gridColumnYTShrinkageWX";
            this.gridColumnYTShrinkageWX.Visible = true;
            this.gridColumnYTShrinkageWX.VisibleIndex = 16;
            // 
            // gridColumnMakeOPID
            // 
            this.gridColumnMakeOPID.Caption = "�Ƶ���ID";
            this.gridColumnMakeOPID.FieldName = "MakeOPID";
            this.gridColumnMakeOPID.Name = "gridColumnMakeOPID";
            this.gridColumnMakeOPID.Visible = true;
            this.gridColumnMakeOPID.VisibleIndex = 17;
            // 
            // gridColumnMakeOPName
            // 
            this.gridColumnMakeOPName.Caption = "�Ƶ���";
            this.gridColumnMakeOPName.FieldName = "MakeOPName";
            this.gridColumnMakeOPName.Name = "gridColumnMakeOPName";
            this.gridColumnMakeOPName.Visible = true;
            this.gridColumnMakeOPName.VisibleIndex = 18;
            // 
            // gridColumnMakeDate
            // 
            this.gridColumnMakeDate.Caption = "�Ƶ�����";
            this.gridColumnMakeDate.FieldName = "MakeDate";
            this.gridColumnMakeDate.Name = "gridColumnMakeDate";
            this.gridColumnMakeDate.Visible = true;
            this.gridColumnMakeDate.VisibleIndex = 19;
            // 
            // gridColumnCheckOPID
            // 
            this.gridColumnCheckOPID.Caption = "�����ID";
            this.gridColumnCheckOPID.FieldName = "CheckOPID";
            this.gridColumnCheckOPID.Name = "gridColumnCheckOPID";
            this.gridColumnCheckOPID.Visible = true;
            this.gridColumnCheckOPID.VisibleIndex = 20;
            // 
            // gridColumnCheckDate
            // 
            this.gridColumnCheckDate.Caption = "�������";
            this.gridColumnCheckDate.FieldName = "CheckDate";
            this.gridColumnCheckDate.Name = "gridColumnCheckDate";
            this.gridColumnCheckDate.Visible = true;
            this.gridColumnCheckDate.VisibleIndex = 21;
            // 
            // gridColumnSubmitFlag
            // 
            this.gridColumnSubmitFlag.Caption = "�ύ��ʶ";
            this.gridColumnSubmitFlag.FieldName = "SubmitFlag";
            this.gridColumnSubmitFlag.Name = "gridColumnSubmitFlag";
            this.gridColumnSubmitFlag.Visible = true;
            this.gridColumnSubmitFlag.VisibleIndex = 22;
            // 
            // gridColumnDelFlag
            // 
            this.gridColumnDelFlag.Caption = "ɾ����־";
            this.gridColumnDelFlag.FieldName = "DelFlag";
            this.gridColumnDelFlag.Name = "gridColumnDelFlag";
            this.gridColumnDelFlag.Visible = true;
            this.gridColumnDelFlag.VisibleIndex = 23;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.txtFormNo);
            this.groupControlQuery.Controls.Add(this.label25);
            this.groupControlQuery.Controls.Add(this.lbVendor);
            this.groupControlQuery.Controls.Add(this.drpSaleOPID);
            this.groupControlQuery.Controls.Add(this.txtMakeDateE);
            this.groupControlQuery.Controls.Add(this.txtMakeDateS);
            this.groupControlQuery.Controls.Add(this.label6);
            this.groupControlQuery.Controls.Add(this.chkMakeDate);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(870, 48);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "��ѯ����";
            // 
            // txtFormNo
            // 
            this.txtFormNo.EditValue = "";
            this.txtFormNo.Location = new System.Drawing.Point(71, 13);
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormNo.Size = new System.Drawing.Size(94, 22);
            this.txtFormNo.TabIndex = 858;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(17, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 16);
            this.label25.TabIndex = 859;
            this.label25.Text = "����";
            // 
            // lbVendor
            // 
            this.lbVendor.Location = new System.Drawing.Point(194, 16);
            this.lbVendor.Name = "lbVendor";
            this.lbVendor.Size = new System.Drawing.Size(47, 16);
            this.lbVendor.TabIndex = 857;
            this.lbVendor.Text = "ҵ��Ա";
            // 
            // drpSaleOPID
            // 
            this.drpSaleOPID.Location = new System.Drawing.Point(250, 13);
            this.drpSaleOPID.Name = "drpSaleOPID";
            this.drpSaleOPID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpSaleOPID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpSaleOPID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpSaleOPID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorID", "VendorID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorName", "VendorName")});
            this.drpSaleOPID.Properties.NullText = "";
            this.drpSaleOPID.Properties.ShowFooter = false;
            this.drpSaleOPID.Properties.ShowHeader = false;
            this.drpSaleOPID.Size = new System.Drawing.Size(106, 22);
            this.drpSaleOPID.TabIndex = 856;
            // 
            // txtMakeDateE
            // 
            this.txtMakeDateE.EditValue = "";
            this.txtMakeDateE.Location = new System.Drawing.Point(605, 13);
            this.txtMakeDateE.Name = "txtMakeDateE";
            this.txtMakeDateE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtMakeDateE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMakeDateE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMakeDateE.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateE.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateE.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtMakeDateE.Properties.ShowPopupShadow = false;
            this.txtMakeDateE.Size = new System.Drawing.Size(90, 22);
            this.txtMakeDateE.TabIndex = 854;
            // 
            // txtMakeDateS
            // 
            this.txtMakeDateS.EditValue = "";
            this.txtMakeDateS.Location = new System.Drawing.Point(458, 13);
            this.txtMakeDateS.Name = "txtMakeDateS";
            this.txtMakeDateS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtMakeDateS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMakeDateS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMakeDateS.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMakeDateS.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateS.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtMakeDateS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMakeDateS.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtMakeDateS.Properties.ShowPopupShadow = false;
            this.txtMakeDateS.Size = new System.Drawing.Size(90, 22);
            this.txtMakeDateS.TabIndex = 853;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(558, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 855;
            this.label6.Text = "��";
            // 
            // chkMakeDate
            // 
            this.chkMakeDate.EditValue = true;
            this.chkMakeDate.Location = new System.Drawing.Point(388, 15);
            this.chkMakeDate.Name = "chkMakeDate";
            this.chkMakeDate.Properties.Caption = "�Ƶ�����";
            this.chkMakeDate.Size = new System.Drawing.Size(72, 19);
            this.chkMakeDate.TabIndex = 852;
            // 
            // frmTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmTestReport";
            this.Text = "frmTestReport";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpSaleOPID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMakeDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderFormNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemStd; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemModel; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnColorNum; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnColorName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSaleOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnTestOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemSource; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSXShrinkageJX; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSXShrinkageWX; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnYTShrinkageJX; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnYTShrinkageWX; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubmitFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDelFlag; 
  		
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraEditors.TextEdit txtFormNo;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbVendor;
        private DevExpress.XtraEditors.LookUpEdit drpSaleOPID;
        private DevExpress.XtraEditors.DateEdit txtMakeDateE;
        private DevExpress.XtraEditors.DateEdit txtMakeDateS;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.CheckEdit chkMakeDate;
    }
}