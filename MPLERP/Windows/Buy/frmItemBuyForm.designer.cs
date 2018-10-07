namespace MLTERP
{
    partial class frmItemBuyForm
    {
        /// <summary>
        /// ±ØÐèµÄÉè¼ÆÆ÷±äÁ¿¡£
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ÇåÀíËùÓÐÕýÔÚÊ¹ÓÃµÄ×ÊÔ´¡£
        /// </summary>
        /// <param name="disposing">Èç¹ûÓ¦ÊÍ·ÅÍÐ¹Ü×ÊÔ´£¬Îª true£»·ñÔòÎª false¡£</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ´°ÌåÉè¼ÆÆ÷Éú³ÉµÄ´úÂë

        /// <summary>
        /// Éè¼ÆÆ÷Ö§³ÖËùÐèµÄ·½·¨ - ²»Òª
        /// Ê¹ÓÃ´úÂë±à¼­Æ÷ÐÞ¸Ä´Ë·½·¨µÄÄÚÈÝ¡£
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemBuyForm));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCustomerStyleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubmitFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDelFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReqDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPayMethodID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReceivedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReceivedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalRecQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemainQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemainRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.label5 = new System.Windows.Forms.Label();
            this.drpSaleOPID = new DevExpress.XtraEditors.LookUpEdit();
            this.drpVendorID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtItemModel = new DevExpress.XtraEditors.TextEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.ucOrderInfo1 = new MLTERP.UCOrderInfo();
            this.txtDtsSO = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCSFlag = new DevExpress.XtraEditors.CheckEdit();
            this.chkSubmitFlag = new DevExpress.XtraEditors.CheckEdit();
            this.txtVColorName = new DevExpress.XtraEditors.TextEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVColorNum = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMWidth = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMWeightE = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMWeightS = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtColorName = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtColorNum = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGoodsCode = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendorID = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReqDateE = new DevExpress.XtraEditors.DateEdit();
            this.txtReqDateS = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.chkReqDate = new DevExpress.XtraEditors.CheckEdit();
            this.txtOrderDateE = new DevExpress.XtraEditors.DateEdit();
            this.txtOrderDateS = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.chkOrderDate = new DevExpress.XtraEditors.CheckEdit();
            this.txtFormNo = new DevExpress.XtraEditors.TextEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.groupControlColor = new DevExpress.XtraEditors.GroupControl();
            this.ucStatusBarStand1 = new HttSoft.UCFab.UCStatusBarStand();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpSaleOPID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpVendorID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtsSO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCSFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSubmitFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVColorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVColorNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMWeightE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMWeightS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateS.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReqDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlColor)).BeginInit();
            this.groupControlColor.SuspendLayout();
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
            this.groupControlDataList.Location = new System.Drawing.Point(0, 110);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(1118, 300);
            this.groupControlDataList.TabIndex = 33;
            this.groupControlDataList.Text = "Êý¾ÝÁÐ±í";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(2, 22);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.drpYesOrNo});
            this.gridControlDetail.Size = new System.Drawing.Size(1114, 276);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.ColumnPanelRowHeight = 22;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnFormNo,
            this.gridColumnOrderCode,
            this.gridColumnCustomerStyleNo,
            this.gridColumnMakeOPID,
            this.gridColumnMakeOPName,
            this.gridColumnMakeDate,
            this.gridColumn16,
            this.gridColumnCheckOPID,
            this.gridColumnCheckDate,
            this.gridColumnSubmitFlag,
            this.gridColumnDelFlag,
            this.gridColumnShopID,
            this.gridColumnFormDate,
            this.gridColumnReqDate,
            this.gridColumnTotalQty,
            this.gridColumnTotalAmount,
            this.gridColumnPayMethodID,
            this.gridColumnRemark,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumnReceivedQty,
            this.gridColumnReceivedDate,
            this.gridColumnTotalRecQty,
            this.gridColumnRemainQty,
            this.gridColumnRemainRate,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 22;
            // 
            // gridColumnID
            // 
            this.gridColumnID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnID.AppearanceCell.Options.UseFont = true;
            this.gridColumnID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            // 
            // gridColumnFormNo
            // 
            this.gridColumnFormNo.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnFormNo.AppearanceCell.Options.UseFont = true;
            this.gridColumnFormNo.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnFormNo.AppearanceHeader.Options.UseFont = true;
            this.gridColumnFormNo.Caption = "²É¹ºµ¥ºÅ";
            this.gridColumnFormNo.FieldName = "FormNo";
            this.gridColumnFormNo.Name = "gridColumnFormNo";
            this.gridColumnFormNo.Visible = true;
            this.gridColumnFormNo.VisibleIndex = 1;
            // 
            // gridColumnOrderCode
            // 
            this.gridColumnOrderCode.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderCode.AppearanceCell.Options.UseFont = true;
            this.gridColumnOrderCode.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnOrderCode.Caption = "¶©µ¥ºÅ";
            this.gridColumnOrderCode.FieldName = "DtsSO";
            this.gridColumnOrderCode.Name = "gridColumnOrderCode";
            this.gridColumnOrderCode.Visible = true;
            this.gridColumnOrderCode.VisibleIndex = 2;
            // 
            // gridColumnCustomerStyleNo
            // 
            this.gridColumnCustomerStyleNo.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCustomerStyleNo.AppearanceCell.Options.UseFont = true;
            this.gridColumnCustomerStyleNo.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCustomerStyleNo.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCustomerStyleNo.Caption = "¿Í»§¶©µ¥¿îºÅ";
            this.gridColumnCustomerStyleNo.FieldName = "CustomerStyleNo";
            this.gridColumnCustomerStyleNo.Name = "gridColumnCustomerStyleNo";
            this.gridColumnCustomerStyleNo.Visible = true;
            this.gridColumnCustomerStyleNo.VisibleIndex = 3;
            // 
            // gridColumnMakeOPID
            // 
            this.gridColumnMakeOPID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeOPID.AppearanceCell.Options.UseFont = true;
            this.gridColumnMakeOPID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeOPID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnMakeOPID.Caption = "ÖÆµ¥ÈËID";
            this.gridColumnMakeOPID.FieldName = "MakeOPID";
            this.gridColumnMakeOPID.Name = "gridColumnMakeOPID";
            this.gridColumnMakeOPID.Visible = true;
            this.gridColumnMakeOPID.VisibleIndex = 4;
            // 
            // gridColumnMakeOPName
            // 
            this.gridColumnMakeOPName.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeOPName.AppearanceCell.Options.UseFont = true;
            this.gridColumnMakeOPName.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeOPName.AppearanceHeader.Options.UseFont = true;
            this.gridColumnMakeOPName.Caption = "ÖÆµ¥ÈË";
            this.gridColumnMakeOPName.FieldName = "MakeOPName";
            this.gridColumnMakeOPName.Name = "gridColumnMakeOPName";
            this.gridColumnMakeOPName.Visible = true;
            this.gridColumnMakeOPName.VisibleIndex = 5;
            // 
            // gridColumnMakeDate
            // 
            this.gridColumnMakeDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnMakeDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnMakeDate.Caption = "ÖÆµ¥ÈÕÆÚ";
            this.gridColumnMakeDate.FieldName = "MakeDate";
            this.gridColumnMakeDate.Name = "gridColumnMakeDate";
            this.gridColumnMakeDate.Visible = true;
            this.gridColumnMakeDate.VisibleIndex = 6;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn16.AppearanceCell.Options.UseFont = true;
            this.gridColumn16.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn16.AppearanceHeader.Options.UseFont = true;
            this.gridColumn16.Caption = "¹©Ó¦ÉÌ";
            this.gridColumn16.FieldName = "VendorAttn";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 7;
            // 
            // gridColumnCheckOPID
            // 
            this.gridColumnCheckOPID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckOPID.AppearanceCell.Options.UseFont = true;
            this.gridColumnCheckOPID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckOPID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCheckOPID.Caption = "ÉóºËÈËID";
            this.gridColumnCheckOPID.FieldName = "CheckOPID";
            this.gridColumnCheckOPID.Name = "gridColumnCheckOPID";
            this.gridColumnCheckOPID.Visible = true;
            this.gridColumnCheckOPID.VisibleIndex = 8;
            // 
            // gridColumnCheckDate
            // 
            this.gridColumnCheckDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnCheckDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCheckDate.Caption = "ÉóºËÈÕÆÚ";
            this.gridColumnCheckDate.FieldName = "CheckDate";
            this.gridColumnCheckDate.Name = "gridColumnCheckDate";
            this.gridColumnCheckDate.Visible = true;
            this.gridColumnCheckDate.VisibleIndex = 9;
            // 
            // gridColumnSubmitFlag
            // 
            this.gridColumnSubmitFlag.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSubmitFlag.AppearanceCell.Options.UseFont = true;
            this.gridColumnSubmitFlag.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSubmitFlag.AppearanceHeader.Options.UseFont = true;
            this.gridColumnSubmitFlag.Caption = "Ìá½»±êÊ¶";
            this.gridColumnSubmitFlag.FieldName = "SubmitFlag";
            this.gridColumnSubmitFlag.Name = "gridColumnSubmitFlag";
            this.gridColumnSubmitFlag.Visible = true;
            this.gridColumnSubmitFlag.VisibleIndex = 10;
            // 
            // gridColumnDelFlag
            // 
            this.gridColumnDelFlag.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnDelFlag.AppearanceCell.Options.UseFont = true;
            this.gridColumnDelFlag.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnDelFlag.AppearanceHeader.Options.UseFont = true;
            this.gridColumnDelFlag.FieldName = "DelFlag";
            this.gridColumnDelFlag.Name = "gridColumnDelFlag";
            this.gridColumnDelFlag.Visible = true;
            this.gridColumnDelFlag.VisibleIndex = 11;
            // 
            // gridColumnShopID
            // 
            this.gridColumnShopID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnShopID.AppearanceCell.Options.UseFont = true;
            this.gridColumnShopID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnShopID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnShopID.Caption = "¹©Ó¦ÉÌ±àºÅ";
            this.gridColumnShopID.FieldName = "ShopID";
            this.gridColumnShopID.Name = "gridColumnShopID";
            this.gridColumnShopID.Visible = true;
            this.gridColumnShopID.VisibleIndex = 12;
            // 
            // gridColumnFormDate
            // 
            this.gridColumnFormDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnFormDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnFormDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnFormDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnFormDate.Caption = "µ¥¾ÝÈÕÆÚ";
            this.gridColumnFormDate.FieldName = "FormDate";
            this.gridColumnFormDate.Name = "gridColumnFormDate";
            this.gridColumnFormDate.Visible = true;
            this.gridColumnFormDate.VisibleIndex = 13;
            // 
            // gridColumnReqDate
            // 
            this.gridColumnReqDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnReqDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnReqDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnReqDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnReqDate.Caption = "ÒªÇó½»ÆÚ";
            this.gridColumnReqDate.FieldName = "ReqDate";
            this.gridColumnReqDate.Name = "gridColumnReqDate";
            this.gridColumnReqDate.Visible = true;
            this.gridColumnReqDate.VisibleIndex = 14;
            // 
            // gridColumnTotalQty
            // 
            this.gridColumnTotalQty.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalQty.AppearanceCell.Options.UseFont = true;
            this.gridColumnTotalQty.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalQty.AppearanceHeader.Options.UseFont = true;
            this.gridColumnTotalQty.Caption = "ºÏ¼ÆÊýÁ¿";
            this.gridColumnTotalQty.FieldName = "TotalQty";
            this.gridColumnTotalQty.Name = "gridColumnTotalQty";
            this.gridColumnTotalQty.Visible = true;
            this.gridColumnTotalQty.VisibleIndex = 15;
            // 
            // gridColumnTotalAmount
            // 
            this.gridColumnTotalAmount.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalAmount.AppearanceCell.Options.UseFont = true;
            this.gridColumnTotalAmount.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalAmount.AppearanceHeader.Options.UseFont = true;
            this.gridColumnTotalAmount.Caption = "ºÏ¼Æ½ð¶î";
            this.gridColumnTotalAmount.FieldName = "TotalAmount";
            this.gridColumnTotalAmount.Name = "gridColumnTotalAmount";
            this.gridColumnTotalAmount.Visible = true;
            this.gridColumnTotalAmount.VisibleIndex = 16;
            // 
            // gridColumnPayMethodID
            // 
            this.gridColumnPayMethodID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnPayMethodID.AppearanceCell.Options.UseFont = true;
            this.gridColumnPayMethodID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnPayMethodID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnPayMethodID.Caption = "¸¶¿î·½Ê½";
            this.gridColumnPayMethodID.FieldName = "PayMethodID";
            this.gridColumnPayMethodID.Name = "gridColumnPayMethodID";
            this.gridColumnPayMethodID.Visible = true;
            this.gridColumnPayMethodID.VisibleIndex = 17;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnRemark.AppearanceCell.Options.UseFont = true;
            this.gridColumnRemark.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnRemark.AppearanceHeader.Options.UseFont = true;
            this.gridColumnRemark.Caption = "±¸×¢";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 18;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "²úÆ·±àÂë";
            this.gridColumn1.FieldName = "ItemCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 19;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "ÉÌÆ·Âë";
            this.gridColumn2.FieldName = "GoodsCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 20;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "É«ºÅ";
            this.gridColumn3.FieldName = "ColorNum";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 21;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "ÑÕÉ«";
            this.gridColumn4.FieldName = "ColorName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 22;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "ÃÅ·ù";
            this.gridColumn5.FieldName = "MWidth";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 23;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "¿ËÖØ";
            this.gridColumn6.FieldName = "MWeight";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 24;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "¿ËÖØµ¥Î»";
            this.gridColumn7.FieldName = "WeightUnit";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 25;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "³É·Ö";
            this.gridColumn8.FieldName = "ItemName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 26;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.Caption = "¿ÍÉ«ºÅ";
            this.gridColumn9.FieldName = "VColorNum";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 27;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.Caption = "¿ÍÑÕÉ«";
            this.gridColumn10.FieldName = "VColorName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 28;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "¿Í²úÆ·±àºÅ";
            this.gridColumn11.FieldName = "VItemCode";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 29;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn12.AppearanceCell.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.Caption = "ÊýÁ¿";
            this.gridColumn12.FieldName = "Qty";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 30;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn13.AppearanceCell.Options.UseFont = true;
            this.gridColumn13.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn13.AppearanceHeader.Options.UseFont = true;
            this.gridColumn13.Caption = "¼ÆÁ¿µ¥Î»";
            this.gridColumn13.FieldName = "Unit";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 31;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.Caption = "µ¥¼Û";
            this.gridColumn14.FieldName = "SingPrice";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 32;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn15.AppearanceCell.Options.UseFont = true;
            this.gridColumn15.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn15.AppearanceHeader.Options.UseFont = true;
            this.gridColumn15.Caption = "½ð¶î";
            this.gridColumn15.FieldName = "Amount";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 33;
            // 
            // gridColumnReceivedQty
            // 
            this.gridColumnReceivedQty.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnReceivedQty.AppearanceCell.Options.UseFont = true;
            this.gridColumnReceivedQty.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnReceivedQty.AppearanceHeader.Options.UseFont = true;
            this.gridColumnReceivedQty.Caption = "Èë¿âÊýÁ¿";
            this.gridColumnReceivedQty.FieldName = "ReceivedQty";
            this.gridColumnReceivedQty.Name = "gridColumnReceivedQty";
            this.gridColumnReceivedQty.Visible = true;
            this.gridColumnReceivedQty.VisibleIndex = 34;
            // 
            // gridColumnReceivedDate
            // 
            this.gridColumnReceivedDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnReceivedDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnReceivedDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnReceivedDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnReceivedDate.Caption = "Èë¿âÈÕÆÚ";
            this.gridColumnReceivedDate.FieldName = "ReceivedDate";
            this.gridColumnReceivedDate.Name = "gridColumnReceivedDate";
            this.gridColumnReceivedDate.Visible = true;
            this.gridColumnReceivedDate.VisibleIndex = 35;
            // 
            // gridColumnTotalRecQty
            // 
            this.gridColumnTotalRecQty.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalRecQty.AppearanceCell.Options.UseFont = true;
            this.gridColumnTotalRecQty.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalRecQty.AppearanceHeader.Options.UseFont = true;
            this.gridColumnTotalRecQty.Caption = "ÀÛ¼ÆÈë¿âÊýÁ¿";
            this.gridColumnTotalRecQty.FieldName = "TotalRecQty";
            this.gridColumnTotalRecQty.Name = "gridColumnTotalRecQty";
            this.gridColumnTotalRecQty.Visible = true;
            this.gridColumnTotalRecQty.VisibleIndex = 36;
            // 
            // gridColumnRemainQty
            // 
            this.gridColumnRemainQty.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnRemainQty.AppearanceCell.Options.UseFont = true;
            this.gridColumnRemainQty.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnRemainQty.AppearanceHeader.Options.UseFont = true;
            this.gridColumnRemainQty.Caption = "Ç·ÊýÊýÁ¿";
            this.gridColumnRemainQty.FieldName = "RemainQty";
            this.gridColumnRemainQty.Name = "gridColumnRemainQty";
            this.gridColumnRemainQty.Visible = true;
            this.gridColumnRemainQty.VisibleIndex = 37;
            // 
            // gridColumnRemainRate
            // 
            this.gridColumnRemainRate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnRemainRate.AppearanceCell.Options.UseFont = true;
            this.gridColumnRemainRate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnRemainRate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnRemainRate.Caption = "Ç·Êý±ÈÀý";
            this.gridColumnRemainRate.DisplayFormat.FormatString = "0.0%";
            this.gridColumnRemainRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnRemainRate.FieldName = "RemainRate";
            this.gridColumnRemainRate.Name = "gridColumnRemainRate";
            this.gridColumnRemainRate.Visible = true;
            this.gridColumnRemainRate.VisibleIndex = 38;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn17.AppearanceCell.Options.UseFont = true;
            this.gridColumn17.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn17.AppearanceHeader.Options.UseFont = true;
            this.gridColumn17.Caption = "×´Ì¬";
            this.gridColumn17.FieldName = "FormStatusName";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 39;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn18.AppearanceCell.Options.UseFont = true;
            this.gridColumn18.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn18.AppearanceHeader.Options.UseFont = true;
            this.gridColumn18.Caption = "ºÏÍ¬½»ÆÚ";
            this.gridColumn18.FieldName = "OrderDate";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 40;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn19.AppearanceCell.Options.UseFont = true;
            this.gridColumn19.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn19.AppearanceHeader.Options.UseFont = true;
            this.gridColumn19.Caption = "¸¶¿î·½Ê½";
            this.gridColumn19.FieldName = "PayMethodName";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 41;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn20.AppearanceCell.Options.UseFont = true;
            this.gridColumn20.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn20.AppearanceHeader.Options.UseFont = true;
            this.gridColumn20.Caption = "×´Ì¬";
            this.gridColumn20.FieldName = "StatusName";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 42;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn21.AppearanceCell.Options.UseFont = true;
            this.gridColumn21.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn21.AppearanceHeader.Options.UseFont = true;
            this.gridColumn21.Caption = "×´Ì¬±êÖ¾";
            this.gridColumn21.FieldName = "StatusFlag";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 43;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn22.AppearanceCell.Options.UseFont = true;
            this.gridColumn22.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn22.AppearanceHeader.Options.UseFont = true;
            this.gridColumn22.Caption = "¸¶¿î·½Ê½";
            this.gridColumn22.FieldName = "FKFlag";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 44;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn23.AppearanceCell.Options.UseFont = true;
            this.gridColumn23.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn23.AppearanceHeader.Options.UseFont = true;
            this.gridColumn23.Caption = "±¨¸æµ¥ºÅ";
            this.gridColumn23.FieldName = "BGNo";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 45;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn24.AppearanceCell.Options.UseFont = true;
            this.gridColumn24.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn24.AppearanceHeader.Options.UseFont = true;
            this.gridColumn24.Caption = "¹æ¸ñ";
            this.gridColumn24.FieldName = "ItemStd";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 46;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn25.AppearanceCell.Options.UseFont = true;
            this.gridColumn25.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn25.AppearanceHeader.Options.UseFont = true;
            this.gridColumn25.Caption = "Æ·Ãû";
            this.gridColumn25.FieldName = "ItemModel";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 47;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceCell.Options.UseFont = true;
            this.gridColumn26.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceHeader.Options.UseFont = true;
            this.gridColumn26.Caption = "ÅúºÅ";
            this.gridColumn26.FieldName = "Batch";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 48;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceCell.Options.UseFont = true;
            this.gridColumn27.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceHeader.Options.UseFont = true;
            this.gridColumn27.Caption = "ÕëÐÍ";
            this.gridColumn27.FieldName = "Needle";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 49;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "¶©µ¥ÊýÁ¿";
            this.gridColumn28.FieldName = "OrderQty";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 50;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "¶©µ¥µ¥Î»";
            this.gridColumn29.FieldName = "OrderUnit";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 51;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "°ë³ÉÆ·±àÂë";
            this.gridColumn30.FieldName = "BCPItemCode";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 52;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "°ë³ÉÆ·Æ·Ãû";
            this.gridColumn31.FieldName = "BCPItemModel";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 53;
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
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.label5);
            this.groupControlQuery.Controls.Add(this.drpSaleOPID);
            this.groupControlQuery.Controls.Add(this.drpVendorID);
            this.groupControlQuery.Controls.Add(this.txtItemModel);
            this.groupControlQuery.Controls.Add(this.label17);
            this.groupControlQuery.Controls.Add(this.ucOrderInfo1);
            this.groupControlQuery.Controls.Add(this.txtDtsSO);
            this.groupControlQuery.Controls.Add(this.label4);
            this.groupControlQuery.Controls.Add(this.chkCSFlag);
            this.groupControlQuery.Controls.Add(this.chkSubmitFlag);
            this.groupControlQuery.Controls.Add(this.txtVColorName);
            this.groupControlQuery.Controls.Add(this.label16);
            this.groupControlQuery.Controls.Add(this.txtVColorNum);
            this.groupControlQuery.Controls.Add(this.label15);
            this.groupControlQuery.Controls.Add(this.txtItemName);
            this.groupControlQuery.Controls.Add(this.label14);
            this.groupControlQuery.Controls.Add(this.txtMWidth);
            this.groupControlQuery.Controls.Add(this.label13);
            this.groupControlQuery.Controls.Add(this.txtMWeightE);
            this.groupControlQuery.Controls.Add(this.label12);
            this.groupControlQuery.Controls.Add(this.txtMWeightS);
            this.groupControlQuery.Controls.Add(this.label11);
            this.groupControlQuery.Controls.Add(this.txtColorName);
            this.groupControlQuery.Controls.Add(this.label10);
            this.groupControlQuery.Controls.Add(this.txtColorNum);
            this.groupControlQuery.Controls.Add(this.label9);
            this.groupControlQuery.Controls.Add(this.txtGoodsCode);
            this.groupControlQuery.Controls.Add(this.label8);
            this.groupControlQuery.Controls.Add(this.txtItemCode);
            this.groupControlQuery.Controls.Add(this.label7);
            this.groupControlQuery.Controls.Add(this.label3);
            this.groupControlQuery.Controls.Add(this.txtVendorID);
            this.groupControlQuery.Controls.Add(this.label2);
            this.groupControlQuery.Controls.Add(this.txtReqDateE);
            this.groupControlQuery.Controls.Add(this.txtReqDateS);
            this.groupControlQuery.Controls.Add(this.label1);
            this.groupControlQuery.Controls.Add(this.chkReqDate);
            this.groupControlQuery.Controls.Add(this.txtOrderDateE);
            this.groupControlQuery.Controls.Add(this.txtOrderDateS);
            this.groupControlQuery.Controls.Add(this.label6);
            this.groupControlQuery.Controls.Add(this.chkOrderDate);
            this.groupControlQuery.Controls.Add(this.txtFormNo);
            this.groupControlQuery.Controls.Add(this.label25);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(1118, 85);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "²éÑ¯Ìõ¼þ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(517, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 863;
            this.label5.Text = "ÒµÎñÔ±";
            // 
            // drpSaleOPID
            // 
            this.drpSaleOPID.Location = new System.Drawing.Point(588, 50);
            this.drpSaleOPID.Name = "drpSaleOPID";
            this.drpSaleOPID.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.drpSaleOPID.Properties.Appearance.Options.UseFont = true;
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
            this.drpSaleOPID.Size = new System.Drawing.Size(98, 26);
            this.drpSaleOPID.TabIndex = 862;
            // 
            // drpVendorID
            // 
            this.drpVendorID.Location = new System.Drawing.Point(759, 20);
            this.drpVendorID.Name = "drpVendorID";
            this.drpVendorID.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.drpVendorID.Properties.Appearance.Options.UseFont = true;
            this.drpVendorID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpVendorID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpVendorID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpVendorID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorID", "VendorID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorName", "VendorName")});
            this.drpVendorID.Properties.NullText = "";
            this.drpVendorID.Properties.ShowFooter = false;
            this.drpVendorID.Properties.ShowHeader = false;
            this.drpVendorID.Size = new System.Drawing.Size(122, 26);
            this.drpVendorID.TabIndex = 857;
            // 
            // txtItemModel
            // 
            this.txtItemModel.EditValue = "";
            this.txtItemModel.Location = new System.Drawing.Point(80, 51);
            this.txtItemModel.Name = "txtItemModel";
            this.txtItemModel.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemModel.Properties.Appearance.Options.UseFont = true;
            this.txtItemModel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtItemModel.Size = new System.Drawing.Size(97, 26);
            this.txtItemModel.TabIndex = 855;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(8, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 15);
            this.label17.TabIndex = 856;
            this.label17.Text = "Æ·Ãû";
            // 
            // ucOrderInfo1
            // 
            this.ucOrderInfo1.Location = new System.Drawing.Point(530, 232);
            this.ucOrderInfo1.Name = "ucOrderInfo1";
            this.ucOrderInfo1.Size = new System.Drawing.Size(206, 68);
            this.ucOrderInfo1.TabIndex = 854;
            // 
            // txtDtsSO
            // 
            this.txtDtsSO.EditValue = "";
            this.txtDtsSO.Location = new System.Drawing.Point(947, 20);
            this.txtDtsSO.Name = "txtDtsSO";
            this.txtDtsSO.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDtsSO.Properties.Appearance.Options.UseFont = true;
            this.txtDtsSO.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDtsSO.Size = new System.Drawing.Size(100, 26);
            this.txtDtsSO.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(887, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 838;
            this.label4.Text = "¶©µ¥ºÅ";
            // 
            // chkCSFlag
            // 
            this.chkCSFlag.Location = new System.Drawing.Point(794, 160);
            this.chkCSFlag.Name = "chkCSFlag";
            this.chkCSFlag.Properties.Caption = "ÉóºË";
            this.chkCSFlag.Size = new System.Drawing.Size(72, 19);
            this.chkCSFlag.TabIndex = 18;
            // 
            // chkSubmitFlag
            // 
            this.chkSubmitFlag.Location = new System.Drawing.Point(922, 160);
            this.chkSubmitFlag.Name = "chkSubmitFlag";
            this.chkSubmitFlag.Properties.Caption = "Ìá½»";
            this.chkSubmitFlag.Size = new System.Drawing.Size(72, 19);
            this.chkSubmitFlag.TabIndex = 17;
            // 
            // txtVColorName
            // 
            this.txtVColorName.EditValue = "";
            this.txtVColorName.Location = new System.Drawing.Point(588, 233);
            this.txtVColorName.Name = "txtVColorName";
            this.txtVColorName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtVColorName.Size = new System.Drawing.Size(90, 22);
            this.txtVColorName.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(508, 238);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 16);
            this.label16.TabIndex = 834;
            this.label16.Text = "¿ÍÑÕÉ«";
            // 
            // txtVColorNum
            // 
            this.txtVColorNum.EditValue = "";
            this.txtVColorNum.Location = new System.Drawing.Point(396, 233);
            this.txtVColorNum.Name = "txtVColorNum";
            this.txtVColorNum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtVColorNum.Size = new System.Drawing.Size(90, 22);
            this.txtVColorNum.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(346, 238);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 16);
            this.label15.TabIndex = 832;
            this.label15.Text = "¿ÍÉ«ºÅ";
            // 
            // txtItemName
            // 
            this.txtItemName.EditValue = "";
            this.txtItemName.Location = new System.Drawing.Point(492, 231);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtItemName.Size = new System.Drawing.Size(90, 22);
            this.txtItemName.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(418, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 16);
            this.label14.TabIndex = 830;
            this.label14.Text = "³É·Ý";
            // 
            // txtMWidth
            // 
            this.txtMWidth.EditValue = "";
            this.txtMWidth.Location = new System.Drawing.Point(106, 205);
            this.txtMWidth.Name = "txtMWidth";
            this.txtMWidth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMWidth.Size = new System.Drawing.Size(97, 22);
            this.txtMWidth.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(34, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 16);
            this.label13.TabIndex = 828;
            this.label13.Text = "ÃÅ·ù";
            // 
            // txtMWeightE
            // 
            this.txtMWeightE.EditValue = "";
            this.txtMWeightE.Location = new System.Drawing.Point(701, 233);
            this.txtMWeightE.Name = "txtMWeightE";
            this.txtMWeightE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMWeightE.Size = new System.Drawing.Size(95, 22);
            this.txtMWeightE.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(652, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 826;
            this.label12.Text = "ÖÁ";
            // 
            // txtMWeightS
            // 
            this.txtMWeightS.EditValue = "";
            this.txtMWeightS.Location = new System.Drawing.Point(554, 232);
            this.txtMWeightS.Name = "txtMWeightS";
            this.txtMWeightS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtMWeightS.Size = new System.Drawing.Size(90, 22);
            this.txtMWeightS.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(487, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 824;
            this.label11.Text = "¿ËÖØ";
            // 
            // txtColorName
            // 
            this.txtColorName.EditValue = "";
            this.txtColorName.Location = new System.Drawing.Point(816, 231);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtColorName.Size = new System.Drawing.Size(100, 22);
            this.txtColorName.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(756, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 822;
            this.label10.Text = "ÑÕÉ«";
            // 
            // txtColorNum
            // 
            this.txtColorNum.EditValue = "";
            this.txtColorNum.Location = new System.Drawing.Point(639, 231);
            this.txtColorNum.Name = "txtColorNum";
            this.txtColorNum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtColorNum.Size = new System.Drawing.Size(90, 22);
            this.txtColorNum.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(600, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 820;
            this.label9.Text = "É«ºÅ";
            // 
            // txtGoodsCode
            // 
            this.txtGoodsCode.EditValue = "";
            this.txtGoodsCode.Location = new System.Drawing.Point(147, 238);
            this.txtGoodsCode.Name = "txtGoodsCode";
            this.txtGoodsCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtGoodsCode.Size = new System.Drawing.Size(90, 22);
            this.txtGoodsCode.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(67, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 818;
            this.label8.Text = "ÉÌÆ·Âë";
            // 
            // txtItemCode
            // 
            this.txtItemCode.EditValue = "";
            this.txtItemCode.Location = new System.Drawing.Point(588, 21);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemCode.Properties.Appearance.Options.UseFont = true;
            this.txtItemCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtItemCode.Size = new System.Drawing.Size(97, 26);
            this.txtItemCode.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(516, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 816;
            this.label7.Text = "²úÆ·±àÂë";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 815;
            this.label3.Text = "²É¹ºµ¥ºÅ";
            // 
            // txtVendorID
            // 
            this.txtVendorID.EditValue = "";
            this.txtVendorID.Location = new System.Drawing.Point(264, 176);
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtVendorID.Size = new System.Drawing.Size(90, 22);
            this.txtVendorID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(700, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 813;
            this.label2.Text = "¹©Ó¦ÉÌ";
            // 
            // txtReqDateE
            // 
            this.txtReqDateE.EditValue = "";
            this.txtReqDateE.Location = new System.Drawing.Point(411, 51);
            this.txtReqDateE.Name = "txtReqDateE";
            this.txtReqDateE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtReqDateE.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReqDateE.Properties.Appearance.Options.UseFont = true;
            this.txtReqDateE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtReqDateE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReqDateE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtReqDateE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReqDateE.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtReqDateE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtReqDateE.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtReqDateE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtReqDateE.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtReqDateE.Properties.ShowPopupShadow = false;
            this.txtReqDateE.Size = new System.Drawing.Size(90, 26);
            this.txtReqDateE.TabIndex = 4;
            // 
            // txtReqDateS
            // 
            this.txtReqDateS.EditValue = "";
            this.txtReqDateS.Location = new System.Drawing.Point(264, 49);
            this.txtReqDateS.Name = "txtReqDateS";
            this.txtReqDateS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtReqDateS.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReqDateS.Properties.Appearance.Options.UseFont = true;
            this.txtReqDateS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtReqDateS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReqDateS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtReqDateS.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReqDateS.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtReqDateS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtReqDateS.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtReqDateS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtReqDateS.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtReqDateS.Properties.ShowPopupShadow = false;
            this.txtReqDateS.Size = new System.Drawing.Size(90, 26);
            this.txtReqDateS.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(372, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 811;
            this.label1.Text = "ÖÁ";
            // 
            // chkReqDate
            // 
            this.chkReqDate.Location = new System.Drawing.Point(186, 51);
            this.chkReqDate.Name = "chkReqDate";
            this.chkReqDate.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkReqDate.Properties.Appearance.Options.UseFont = true;
            this.chkReqDate.Properties.Caption = "ÒªÇó½»ÆÚ";
            this.chkReqDate.Size = new System.Drawing.Size(72, 21);
            this.chkReqDate.TabIndex = 812;
            // 
            // txtOrderDateE
            // 
            this.txtOrderDateE.EditValue = "";
            this.txtOrderDateE.Location = new System.Drawing.Point(411, 21);
            this.txtOrderDateE.Name = "txtOrderDateE";
            this.txtOrderDateE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtOrderDateE.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrderDateE.Properties.Appearance.Options.UseFont = true;
            this.txtOrderDateE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDateE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDateE.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateE.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateE.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtOrderDateE.Properties.ShowPopupShadow = false;
            this.txtOrderDateE.Size = new System.Drawing.Size(90, 26);
            this.txtOrderDateE.TabIndex = 2;
            // 
            // txtOrderDateS
            // 
            this.txtOrderDateS.EditValue = "";
            this.txtOrderDateS.Location = new System.Drawing.Point(264, 21);
            this.txtOrderDateS.Name = "txtOrderDateS";
            this.txtOrderDateS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtOrderDateS.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrderDateS.Properties.Appearance.Options.UseFont = true;
            this.txtOrderDateS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDateS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateS.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDateS.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateS.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateS.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtOrderDateS.Properties.ShowPopupShadow = false;
            this.txtOrderDateS.Size = new System.Drawing.Size(90, 26);
            this.txtOrderDateS.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(372, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 807;
            this.label6.Text = "ÖÁ";
            // 
            // chkOrderDate
            // 
            this.chkOrderDate.EditValue = true;
            this.chkOrderDate.Location = new System.Drawing.Point(186, 22);
            this.chkOrderDate.Name = "chkOrderDate";
            this.chkOrderDate.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOrderDate.Properties.Appearance.Options.UseFont = true;
            this.chkOrderDate.Properties.Caption = "ÏÂµ¥ÈÕÆÚ";
            this.chkOrderDate.Size = new System.Drawing.Size(72, 21);
            this.chkOrderDate.TabIndex = 808;
            // 
            // txtFormNo
            // 
            this.txtFormNo.EditValue = "";
            this.txtFormNo.Location = new System.Drawing.Point(80, 22);
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFormNo.Properties.Appearance.Options.UseFont = true;
            this.txtFormNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormNo.Size = new System.Drawing.Size(97, 26);
            this.txtFormNo.TabIndex = 0;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(-111, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 16);
            this.label25.TabIndex = 803;
            this.label25.Text = "ºÏÍ¬ºÅ";
            // 
            // lbCount
            // 
            this.lbCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbCount.Location = new System.Drawing.Point(965, 5);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(141, 16);
            this.lbCount.TabIndex = 839;
            // 
            // groupControlColor
            // 
            this.groupControlColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlColor.Controls.Add(this.ucStatusBarStand1);
            this.groupControlColor.Controls.Add(this.lbCount);
            this.groupControlColor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControlColor.Location = new System.Drawing.Point(0, 410);
            this.groupControlColor.Name = "groupControlColor";
            this.groupControlColor.Size = new System.Drawing.Size(1118, 28);
            this.groupControlColor.TabIndex = 52;
            this.groupControlColor.Text = "ÑÕÉ«±êÊ¶";
            // 
            // ucStatusBarStand1
            // 
            this.ucStatusBarStand1.BackColor = System.Drawing.Color.Lavender;
            this.ucStatusBarStand1.Location = new System.Drawing.Point(8, 5);
            this.ucStatusBarStand1.Name = "ucStatusBarStand1";
            this.ucStatusBarStand1.Size = new System.Drawing.Size(405, 19);
            this.ucStatusBarStand1.TabIndex = 841;
            this.ucStatusBarStand1.UCContextHeight = 16;
            this.ucStatusBarStand1.UCContextWidth = 60;
            this.ucStatusBarStand1.UCHeadCaption = "×´Ì¬";
            this.ucStatusBarStand1.UCHeadCaptionVisible = true;
            this.ucStatusBarStand1.UCHeadCaptionWidth = 30;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "°ë³ÉÆ·ÃÅ·ù";
            this.gridColumn32.FieldName = "BCPMWidth";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 54;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "°ë³ÉÆ·¿ËÖØ";
            this.gridColumn33.FieldName = "BCPMWeight";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 55;
            // 
            // frmItemBuyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlColor);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmItemBuyForm";
            this.Text = "³ÉÆ·²É¹ºµ¥ÁÐ±í";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlColor, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpSaleOPID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpVendorID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtsSO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCSFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSubmitFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVColorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVColorNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMWeightE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMWeightS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateS.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReqDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlColor)).EndInit();
            this.groupControlColor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCustomerStyleNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubmitFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDelFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnShopID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReqDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalQty; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalAmount; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPayMethodID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtVendorID;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit txtReqDateE;
        private DevExpress.XtraEditors.DateEdit txtReqDateS;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit chkReqDate;
        private DevExpress.XtraEditors.DateEdit txtOrderDateE;
        private DevExpress.XtraEditors.DateEdit txtOrderDateS;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.CheckEdit chkOrderDate;
        private DevExpress.XtraEditors.TextEdit txtFormNo;
        private System.Windows.Forms.Label label25;
        private DevExpress.XtraEditors.TextEdit txtColorNum;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtGoodsCode;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtItemCode;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtMWeightE;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtMWeightS;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtColorName;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtVColorNum;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtMWidth;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.CheckEdit chkCSFlag;
        private DevExpress.XtraEditors.CheckEdit chkSubmitFlag;
        private DevExpress.XtraEditors.TextEdit txtVColorName;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.TextEdit txtDtsSO;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.GroupControl groupControlColor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReceivedQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReceivedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalRecQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemainQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemainRate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private System.Windows.Forms.Label lbCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpYesOrNo;
        private UCOrderInfo ucOrderInfo1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraEditors.TextEdit txtItemModel;
        private System.Windows.Forms.Label label17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraEditors.LookUpEdit drpVendorID;
        private HttSoft.UCFab.UCStatusBarStand ucStatusBarStand1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit drpSaleOPID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
    }
}