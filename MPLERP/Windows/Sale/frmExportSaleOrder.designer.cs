namespace MLTERP
{
    partial class frmExportSaleOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportSaleOrder));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCSFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCSTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCSOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCheckDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubmitFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVendorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderLevelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReqDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnContractDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrderStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpHQFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkFlag = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.txtVendorAttn = new DevExpress.XtraEditors.TextEdit();
            this.txtSaleOPName = new DevExpress.XtraEditors.TextEdit();
            this.lbVendor = new System.Windows.Forms.Label();
            this.txtMakeDateE = new DevExpress.XtraEditors.DateEdit();
            this.txtMakeDateS = new DevExpress.XtraEditors.DateEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.chkMakeDate = new DevExpress.XtraEditors.CheckEdit();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderDateE = new DevExpress.XtraEditors.DateEdit();
            this.txtOrderDateS = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.chkOrderDate = new DevExpress.XtraEditors.CheckEdit();
            this.txtFormNo = new DevExpress.XtraEditors.TextEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.groupControlColor = new DevExpress.XtraEditors.GroupControl();
            this.ucStatusBarStand1 = new HttSoft.UCFab.UCStatusBarStand();
            this.ucStatusBarStand2 = new HttSoft.UCFab.UCStatusBarStand();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateOrderStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGoodsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnColorNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnColorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnWeightUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVColorNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVColorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.restxtunit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtItemSalePrice = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.drpGridColorNum = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.drpGridColorName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpHQFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorAttn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaleOPName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMakeDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlColor)).BeginInit();
            this.groupControlColor.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restxtunit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridColorNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridColorName)).BeginInit();
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
            this.groupControlDataList.Location = new System.Drawing.Point(0, 115);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(814, 353);
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
            this.drpYesOrNo,
            this.drpHQFlag,
            this.chkFlag});
            this.gridControlDetail.Size = new System.Drawing.Size(810, 329);
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
            this.gridColumnMakeOPID,
            this.gridColumnMakeOPName,
            this.gridColumn32,
            this.gridColumn31,
            this.gridColumnMakeDate,
            this.gridColumnCSFlag,
            this.gridColumnCSTime,
            this.gridColumnCSOPID,
            this.gridColumnCheckOPID,
            this.gridColumnCheckDate,
            this.gridColumnSubmitFlag,
            this.gridColumnFormDate,
            this.gridColumnVendorID,
            this.gridColumnCustomerCode,
            this.gridColumnOrderTypeID,
            this.gridColumnOrderLevelID,
            this.gridColumnOrderDate,
            this.gridColumnReqDate,
            this.gridColumnRemark,
            this.gridColumnContractDesc,
            this.gridColumnTotalQty,
            this.gridColumnTotalAmount,
            this.gridColumnOrderStatusID,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn34,
            this.gridColumn40,
            this.gridColumn42,
            this.gridColumn51,
            this.gridColumn1});
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
            this.gridColumnFormNo.Caption = "¶©µ¥ºÅ";
            this.gridColumnFormNo.FieldName = "FormNo";
            this.gridColumnFormNo.Name = "gridColumnFormNo";
            this.gridColumnFormNo.Visible = true;
            this.gridColumnFormNo.VisibleIndex = 1;
            // 
            // gridColumnMakeOPID
            // 
            this.gridColumnMakeOPID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeOPID.AppearanceCell.Options.UseFont = true;
            this.gridColumnMakeOPID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMakeOPID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnMakeOPID.Caption = "ÖÆµ¥ÈË±àºÅ";
            this.gridColumnMakeOPID.FieldName = "MakeOPID";
            this.gridColumnMakeOPID.Name = "gridColumnMakeOPID";
            this.gridColumnMakeOPID.Visible = true;
            this.gridColumnMakeOPID.VisibleIndex = 2;
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
            this.gridColumnMakeOPName.VisibleIndex = 3;
            // 
            // gridColumn32
            // 
            this.gridColumn32.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn32.AppearanceCell.Options.UseFont = true;
            this.gridColumn32.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn32.AppearanceHeader.Options.UseFont = true;
            this.gridColumn32.Caption = "³·µ¥";
            this.gridColumn32.ColumnEdit = this.drpYesOrNo;
            this.gridColumn32.FieldName = "CancelFlag";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 4;
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
            // gridColumn31
            // 
            this.gridColumn31.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn31.AppearanceCell.Options.UseFont = true;
            this.gridColumn31.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn31.AppearanceHeader.Options.UseFont = true;
            this.gridColumn31.Caption = "³·µ¥Ô­Òò";
            this.gridColumn31.FieldName = "CancelReason";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 5;
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
            // gridColumnCSFlag
            // 
            this.gridColumnCSFlag.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCSFlag.AppearanceCell.Options.UseFont = true;
            this.gridColumnCSFlag.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCSFlag.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCSFlag.Caption = "³õÉó±êÖ¾";
            this.gridColumnCSFlag.FieldName = "CSFlag";
            this.gridColumnCSFlag.Name = "gridColumnCSFlag";
            this.gridColumnCSFlag.Visible = true;
            this.gridColumnCSFlag.VisibleIndex = 7;
            // 
            // gridColumnCSTime
            // 
            this.gridColumnCSTime.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCSTime.AppearanceCell.Options.UseFont = true;
            this.gridColumnCSTime.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCSTime.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCSTime.Caption = "³õÉóÊ±¼ä";
            this.gridColumnCSTime.FieldName = "CSTime";
            this.gridColumnCSTime.Name = "gridColumnCSTime";
            this.gridColumnCSTime.Visible = true;
            this.gridColumnCSTime.VisibleIndex = 8;
            // 
            // gridColumnCSOPID
            // 
            this.gridColumnCSOPID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCSOPID.AppearanceCell.Options.UseFont = true;
            this.gridColumnCSOPID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCSOPID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCSOPID.Caption = "³õÉóÈË";
            this.gridColumnCSOPID.FieldName = "CSOPID";
            this.gridColumnCSOPID.Name = "gridColumnCSOPID";
            this.gridColumnCSOPID.Visible = true;
            this.gridColumnCSOPID.VisibleIndex = 9;
            // 
            // gridColumnCheckOPID
            // 
            this.gridColumnCheckOPID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckOPID.AppearanceCell.Options.UseFont = true;
            this.gridColumnCheckOPID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckOPID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCheckOPID.Caption = "ÉóºËÈË±àºÅ";
            this.gridColumnCheckOPID.FieldName = "CheckOPID";
            this.gridColumnCheckOPID.Name = "gridColumnCheckOPID";
            this.gridColumnCheckOPID.Visible = true;
            this.gridColumnCheckOPID.VisibleIndex = 10;
            // 
            // gridColumnCheckDate
            // 
            this.gridColumnCheckDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnCheckDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCheckDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCheckDate.Caption = "ÉóºËÊ±¼ä";
            this.gridColumnCheckDate.FieldName = "CheckDate";
            this.gridColumnCheckDate.Name = "gridColumnCheckDate";
            this.gridColumnCheckDate.Visible = true;
            this.gridColumnCheckDate.VisibleIndex = 11;
            // 
            // gridColumnSubmitFlag
            // 
            this.gridColumnSubmitFlag.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSubmitFlag.AppearanceCell.Options.UseFont = true;
            this.gridColumnSubmitFlag.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSubmitFlag.AppearanceHeader.Options.UseFont = true;
            this.gridColumnSubmitFlag.Caption = "Ìá½»±êÖ¾";
            this.gridColumnSubmitFlag.ColumnEdit = this.drpYesOrNo;
            this.gridColumnSubmitFlag.FieldName = "SubmitFlag";
            this.gridColumnSubmitFlag.Name = "gridColumnSubmitFlag";
            this.gridColumnSubmitFlag.Visible = true;
            this.gridColumnSubmitFlag.VisibleIndex = 12;
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
            // gridColumnVendorID
            // 
            this.gridColumnVendorID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVendorID.AppearanceCell.Options.UseFont = true;
            this.gridColumnVendorID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVendorID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnVendorID.Caption = "¿Í»§±àºÅ";
            this.gridColumnVendorID.FieldName = "VendorID";
            this.gridColumnVendorID.Name = "gridColumnVendorID";
            this.gridColumnVendorID.Visible = true;
            this.gridColumnVendorID.VisibleIndex = 14;
            // 
            // gridColumnCustomerCode
            // 
            this.gridColumnCustomerCode.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCustomerCode.AppearanceCell.Options.UseFont = true;
            this.gridColumnCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCustomerCode.Caption = "¿Í»§¶©µ¥ºÅ";
            this.gridColumnCustomerCode.FieldName = "CustomerCode";
            this.gridColumnCustomerCode.Name = "gridColumnCustomerCode";
            this.gridColumnCustomerCode.Visible = true;
            this.gridColumnCustomerCode.VisibleIndex = 15;
            // 
            // gridColumnOrderTypeID
            // 
            this.gridColumnOrderTypeID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderTypeID.AppearanceCell.Options.UseFont = true;
            this.gridColumnOrderTypeID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderTypeID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnOrderTypeID.Caption = "¶©µ¥ÀàÐÍ±àºÅ";
            this.gridColumnOrderTypeID.FieldName = "OrderTypeID";
            this.gridColumnOrderTypeID.Name = "gridColumnOrderTypeID";
            this.gridColumnOrderTypeID.Visible = true;
            this.gridColumnOrderTypeID.VisibleIndex = 16;
            // 
            // gridColumnOrderLevelID
            // 
            this.gridColumnOrderLevelID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderLevelID.AppearanceCell.Options.UseFont = true;
            this.gridColumnOrderLevelID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderLevelID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnOrderLevelID.Caption = "¶©µ¥µÈ¼¶±àºÅ";
            this.gridColumnOrderLevelID.FieldName = "OrderLevelID";
            this.gridColumnOrderLevelID.Name = "gridColumnOrderLevelID";
            this.gridColumnOrderLevelID.Visible = true;
            this.gridColumnOrderLevelID.VisibleIndex = 17;
            // 
            // gridColumnOrderDate
            // 
            this.gridColumnOrderDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnOrderDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnOrderDate.Caption = "ÏÂµ¥ÈÕÆÚ";
            this.gridColumnOrderDate.FieldName = "OrderDate";
            this.gridColumnOrderDate.Name = "gridColumnOrderDate";
            this.gridColumnOrderDate.Visible = true;
            this.gridColumnOrderDate.VisibleIndex = 18;
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
            this.gridColumnReqDate.VisibleIndex = 19;
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
            this.gridColumnRemark.VisibleIndex = 20;
            // 
            // gridColumnContractDesc
            // 
            this.gridColumnContractDesc.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnContractDesc.AppearanceCell.Options.UseFont = true;
            this.gridColumnContractDesc.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnContractDesc.AppearanceHeader.Options.UseFont = true;
            this.gridColumnContractDesc.Caption = "ºÏÍ¬Ìõ¿îÐÅÏ¢";
            this.gridColumnContractDesc.FieldName = "ContractDesc";
            this.gridColumnContractDesc.Name = "gridColumnContractDesc";
            this.gridColumnContractDesc.Visible = true;
            this.gridColumnContractDesc.VisibleIndex = 21;
            // 
            // gridColumnTotalQty
            // 
            this.gridColumnTotalQty.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalQty.AppearanceCell.Options.UseFont = true;
            this.gridColumnTotalQty.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalQty.AppearanceHeader.Options.UseFont = true;
            this.gridColumnTotalQty.Caption = "×ÜÊýÁ¿";
            this.gridColumnTotalQty.FieldName = "TotalQty";
            this.gridColumnTotalQty.Name = "gridColumnTotalQty";
            this.gridColumnTotalQty.Visible = true;
            this.gridColumnTotalQty.VisibleIndex = 22;
            // 
            // gridColumnTotalAmount
            // 
            this.gridColumnTotalAmount.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalAmount.AppearanceCell.Options.UseFont = true;
            this.gridColumnTotalAmount.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTotalAmount.AppearanceHeader.Options.UseFont = true;
            this.gridColumnTotalAmount.Caption = "×Ü½ð¶î";
            this.gridColumnTotalAmount.FieldName = "TotalAmount";
            this.gridColumnTotalAmount.Name = "gridColumnTotalAmount";
            this.gridColumnTotalAmount.Visible = true;
            this.gridColumnTotalAmount.VisibleIndex = 23;
            // 
            // gridColumnOrderStatusID
            // 
            this.gridColumnOrderStatusID.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderStatusID.AppearanceCell.Options.UseFont = true;
            this.gridColumnOrderStatusID.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnOrderStatusID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnOrderStatusID.Caption = "½ø¶È×´Ì¬";
            this.gridColumnOrderStatusID.FieldName = "OrderStepID";
            this.gridColumnOrderStatusID.Name = "gridColumnOrderStatusID";
            this.gridColumnOrderStatusID.Visible = true;
            this.gridColumnOrderStatusID.VisibleIndex = 24;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn16.AppearanceCell.Options.UseFont = true;
            this.gridColumn16.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn16.AppearanceHeader.Options.UseFont = true;
            this.gridColumn16.Caption = "¿Í»§";
            this.gridColumn16.FieldName = "VendorAttn";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 25;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn17.AppearanceCell.Options.UseFont = true;
            this.gridColumn17.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn17.AppearanceHeader.Options.UseFont = true;
            this.gridColumn17.Caption = "¶©µ¥µÈ¼¶";
            this.gridColumn17.FieldName = "OrderLevelName";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 26;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn18.AppearanceCell.Options.UseFont = true;
            this.gridColumn18.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn18.AppearanceHeader.Options.UseFont = true;
            this.gridColumn18.Caption = "¶©µ¥ÀàÐÍ";
            this.gridColumn18.FieldName = "OrderTypeName";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 27;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn19.AppearanceCell.Options.UseFont = true;
            this.gridColumn19.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn19.AppearanceHeader.Options.UseFont = true;
            this.gridColumn19.Caption = "Õ¾±ð";
            this.gridColumn19.FieldName = "OrderStepName";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 28;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn20.AppearanceCell.Options.UseFont = true;
            this.gridColumn20.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn20.AppearanceHeader.Options.UseFont = true;
            this.gridColumn20.Caption = "×´Ì¬";
            this.gridColumn20.FieldName = "FormStatusName";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 29;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceCell.Options.UseFont = true;
            this.gridColumn26.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceHeader.Options.UseFont = true;
            this.gridColumn26.Caption = "¸¶¿î·½Ê½";
            this.gridColumn26.FieldName = "PayMethodName";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 30;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceCell.Options.UseFont = true;
            this.gridColumn27.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceHeader.Options.UseFont = true;
            this.gridColumn27.Caption = "ºÏÍ¬×´Ì¬±êÖ¾";
            this.gridColumn27.FieldName = "StatusFlag";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 31;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn28.AppearanceCell.Options.UseFont = true;
            this.gridColumn28.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn28.AppearanceHeader.Options.UseFont = true;
            this.gridColumn28.Caption = "ºÏÍ¬×´Ì¬";
            this.gridColumn28.FieldName = "StatusName";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 32;
            // 
            // gridColumn34
            // 
            this.gridColumn34.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn34.AppearanceCell.Options.UseFont = true;
            this.gridColumn34.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn34.AppearanceHeader.Options.UseFont = true;
            this.gridColumn34.Caption = "¸¶¿î·½Ê½";
            this.gridColumn34.FieldName = "FKFlag";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 33;
            // 
            // gridColumn40
            // 
            this.gridColumn40.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn40.AppearanceCell.Options.UseFont = true;
            this.gridColumn40.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn40.AppearanceHeader.Options.UseFont = true;
            this.gridColumn40.Caption = "Õ¾±ðID";
            this.gridColumn40.FieldName = "OrderStepID";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 34;
            // 
            // gridColumn42
            // 
            this.gridColumn42.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn42.AppearanceCell.Options.UseFont = true;
            this.gridColumn42.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn42.AppearanceHeader.Options.UseFont = true;
            this.gridColumn42.Caption = "ÒµÎñÔ±";
            this.gridColumn42.FieldName = "SaleOPName";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 35;
            // 
            // gridColumn51
            // 
            this.gridColumn51.Caption = "»ØÇ©±êÖ¾";
            this.gridColumn51.ColumnEdit = this.drpHQFlag;
            this.gridColumn51.FieldName = "HQFlag";
            this.gridColumn51.Name = "gridColumn51";
            this.gridColumn51.Visible = true;
            this.gridColumn51.VisibleIndex = 36;
            // 
            // drpHQFlag
            // 
            this.drpHQFlag.AutoHeight = false;
            this.drpHQFlag.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpHQFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1)});
            this.drpHQFlag.Name = "drpHQFlag";
            this.drpHQFlag.SmallImages = this.BaseIlYesOrNo;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "·¢»õ×´Ì¬";
            this.gridColumn1.FieldName = "FaHuoStatusName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 37;
            // 
            // chkFlag
            // 
            this.chkFlag.AutoHeight = false;
            this.chkFlag.Caption = "Check";
            this.chkFlag.Name = "chkFlag";
            this.chkFlag.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkFlag.ValueChecked = 1;
            this.chkFlag.ValueUnchecked = 0;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.txtVendorAttn);
            this.groupControlQuery.Controls.Add(this.txtSaleOPName);
            this.groupControlQuery.Controls.Add(this.lbVendor);
            this.groupControlQuery.Controls.Add(this.txtMakeDateE);
            this.groupControlQuery.Controls.Add(this.txtMakeDateS);
            this.groupControlQuery.Controls.Add(this.label19);
            this.groupControlQuery.Controls.Add(this.chkMakeDate);
            this.groupControlQuery.Controls.Add(this.txtCustomerCode);
            this.groupControlQuery.Controls.Add(this.label3);
            this.groupControlQuery.Controls.Add(this.label2);
            this.groupControlQuery.Controls.Add(this.txtOrderDateE);
            this.groupControlQuery.Controls.Add(this.txtOrderDateS);
            this.groupControlQuery.Controls.Add(this.label6);
            this.groupControlQuery.Controls.Add(this.chkOrderDate);
            this.groupControlQuery.Controls.Add(this.txtFormNo);
            this.groupControlQuery.Controls.Add(this.label25);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(1184, 90);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "²éÑ¯Ìõ¼þ";
            // 
            // txtVendorAttn
            // 
            this.txtVendorAttn.EditValue = "";
            this.txtVendorAttn.Location = new System.Drawing.Point(239, 25);
            this.txtVendorAttn.Name = "txtVendorAttn";
            this.txtVendorAttn.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVendorAttn.Properties.Appearance.Options.UseFont = true;
            this.txtVendorAttn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtVendorAttn.Size = new System.Drawing.Size(90, 26);
            this.txtVendorAttn.TabIndex = 847;
            this.txtVendorAttn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormNo_KeyDown);
            // 
            // txtSaleOPName
            // 
            this.txtSaleOPName.EditValue = "";
            this.txtSaleOPName.Location = new System.Drawing.Point(239, 58);
            this.txtSaleOPName.Name = "txtSaleOPName";
            this.txtSaleOPName.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSaleOPName.Properties.Appearance.Options.UseFont = true;
            this.txtSaleOPName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtSaleOPName.Size = new System.Drawing.Size(90, 26);
            this.txtSaleOPName.TabIndex = 846;
            this.txtSaleOPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormNo_KeyDown);
            // 
            // lbVendor
            // 
            this.lbVendor.Font = new System.Drawing.Font("ËÎÌå", 9F);
            this.lbVendor.Location = new System.Drawing.Point(188, 63);
            this.lbVendor.Name = "lbVendor";
            this.lbVendor.Size = new System.Drawing.Size(50, 16);
            this.lbVendor.TabIndex = 839;
            this.lbVendor.Text = "ÒµÎñÔ±";
            // 
            // txtMakeDateE
            // 
            this.txtMakeDateE.EditValue = "";
            this.txtMakeDateE.Location = new System.Drawing.Point(543, 60);
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
            this.txtMakeDateE.TabIndex = 3;
            // 
            // txtMakeDateS
            // 
            this.txtMakeDateS.EditValue = "";
            this.txtMakeDateS.Location = new System.Drawing.Point(417, 60);
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
            this.txtMakeDateS.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(517, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 16);
            this.label19.TabIndex = 834;
            this.label19.Text = "ÖÁ";
            // 
            // chkMakeDate
            // 
            this.chkMakeDate.Location = new System.Drawing.Point(343, 62);
            this.chkMakeDate.Name = "chkMakeDate";
            this.chkMakeDate.Properties.Caption = "ÖÆµ¥ÈÕÆÚ";
            this.chkMakeDate.Size = new System.Drawing.Size(72, 19);
            this.chkMakeDate.TabIndex = 1;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.EditValue = "";
            this.txtCustomerCode.Location = new System.Drawing.Point(80, 58);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCustomerCode.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCustomerCode.Size = new System.Drawing.Size(94, 26);
            this.txtCustomerCode.TabIndex = 11;
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormNo_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(26, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 803;
            this.label3.Text = "¿Íµ¥ºÅ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("ËÎÌå", 9F);
            this.label2.Location = new System.Drawing.Point(188, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 801;
            this.label2.Text = "¿Í»§";
            // 
            // txtOrderDateE
            // 
            this.txtOrderDateE.EditValue = "";
            this.txtOrderDateE.Location = new System.Drawing.Point(543, 25);
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
            this.txtOrderDateE.TabIndex = 34;
            // 
            // txtOrderDateS
            // 
            this.txtOrderDateS.EditValue = "";
            this.txtOrderDateS.Location = new System.Drawing.Point(417, 25);
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
            this.txtOrderDateS.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("ËÎÌå", 9F);
            this.label6.Location = new System.Drawing.Point(517, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 795;
            this.label6.Text = "ÖÁ";
            // 
            // chkOrderDate
            // 
            this.chkOrderDate.EditValue = true;
            this.chkOrderDate.Enabled = false;
            this.chkOrderDate.Location = new System.Drawing.Point(343, 29);
            this.chkOrderDate.Name = "chkOrderDate";
            this.chkOrderDate.Properties.Appearance.Font = new System.Drawing.Font("ËÎÌå", 9F);
            this.chkOrderDate.Properties.Appearance.Options.UseFont = true;
            this.chkOrderDate.Properties.Caption = "ÏÂµ¥ÈÕÆÚ";
            this.chkOrderDate.Size = new System.Drawing.Size(72, 19);
            this.chkOrderDate.TabIndex = 32;
            // 
            // txtFormNo
            // 
            this.txtFormNo.EditValue = "";
            this.txtFormNo.Location = new System.Drawing.Point(80, 25);
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFormNo.Properties.Appearance.Options.UseFont = true;
            this.txtFormNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormNo.Size = new System.Drawing.Size(94, 26);
            this.txtFormNo.TabIndex = 0;
            this.txtFormNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormNo_KeyDown);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(26, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 16);
            this.label25.TabIndex = 791;
            this.label25.Text = "ºÏÍ¬ºÅ";
            // 
            // lbCount
            // 
            this.lbCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCount.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbCount.Location = new System.Drawing.Point(1040, 6);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(141, 16);
            this.lbCount.TabIndex = 832;
            this.lbCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupControlColor
            // 
            this.groupControlColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlColor.Controls.Add(this.ucStatusBarStand1);
            this.groupControlColor.Controls.Add(this.ucStatusBarStand2);
            this.groupControlColor.Controls.Add(this.lbCount);
            this.groupControlColor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControlColor.Location = new System.Drawing.Point(0, 468);
            this.groupControlColor.Name = "groupControlColor";
            this.groupControlColor.Size = new System.Drawing.Size(1184, 29);
            this.groupControlColor.TabIndex = 53;
            this.groupControlColor.Text = "ÑÕÉ«±êÊ¶";
            // 
            // ucStatusBarStand1
            // 
            this.ucStatusBarStand1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucStatusBarStand1.BackColor = System.Drawing.Color.Lavender;
            this.ucStatusBarStand1.Location = new System.Drawing.Point(5, 5);
            this.ucStatusBarStand1.Name = "ucStatusBarStand1";
            this.ucStatusBarStand1.Size = new System.Drawing.Size(683, 19);
            this.ucStatusBarStand1.TabIndex = 833;
            this.ucStatusBarStand1.UCContextHeight = 16;
            this.ucStatusBarStand1.UCContextWidth = 60;
            this.ucStatusBarStand1.UCHeadCaption = "";
            this.ucStatusBarStand1.UCHeadCaptionVisible = true;
            this.ucStatusBarStand1.UCHeadCaptionWidth = 30;
            // 
            // ucStatusBarStand2
            // 
            this.ucStatusBarStand2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucStatusBarStand2.BackColor = System.Drawing.Color.Lavender;
            this.ucStatusBarStand2.Location = new System.Drawing.Point(694, 5);
            this.ucStatusBarStand2.Name = "ucStatusBarStand2";
            this.ucStatusBarStand2.Size = new System.Drawing.Size(360, 19);
            this.ucStatusBarStand2.TabIndex = 834;
            this.ucStatusBarStand2.UCContextHeight = 16;
            this.ucStatusBarStand2.UCContextWidth = 60;
            this.ucStatusBarStand2.UCHeadCaption = "×´Ì¬";
            this.ucStatusBarStand2.UCHeadCaptionVisible = true;
            this.ucStatusBarStand2.UCHeadCaptionWidth = 30;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateOrderStepToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // UpdateOrderStepToolStripMenuItem
            // 
            this.UpdateOrderStepToolStripMenuItem.Name = "UpdateOrderStepToolStripMenuItem";
            this.UpdateOrderStepToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.UpdateOrderStepToolStripMenuItem.Text = "ÐÞ¸ÄºÏÍ¬Õ¾±ð";
            this.UpdateOrderStepToolStripMenuItem.Click += new System.EventHandler(this.UpdateOrderStepToolStripMenuItem_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(809, 115);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 353);
            this.splitterControl1.TabIndex = 54;
            this.splitterControl1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(814, 115);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(370, 353);
            this.groupControl1.TabIndex = 55;
            this.groupControl1.Text = "Êý¾ÝÁÐ±í";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 22);
            this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControl1.MainView = this.gridView4;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.restxtunit,
            this.txtItemSalePrice,
            this.repositoryItemImageComboBox1,
            this.drpGridColorNum,
            this.drpGridColorName});
            this.gridControl1.Size = new System.Drawing.Size(366, 329);
            this.gridControl1.TabIndex = 33;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView4.ColumnPanelRowHeight = 22;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnItemCode,
            this.gridColumnGoodsCode,
            this.gridColumnColorNum,
            this.gridColumnColorName,
            this.gridColumnMWidth,
            this.gridColumnMWeight,
            this.gridColumnWeightUnit,
            this.gridColumnItemName,
            this.gridColumnVColorNum,
            this.gridColumnVColorName,
            this.gridColumnVItemCode,
            this.gridColumnQty,
            this.gridColumnUnit,
            this.gridColumnSingPrice,
            this.gridColumnAmount,
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
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn33,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn41,
            this.gridColumn43,
            this.gridColumn44,
            this.gridColumn2,
            this.gridColumn45,
            this.gridColumn46,
            this.gridColumn47,
            this.gridColumn48,
            this.gridColumn49});
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.RowAutoHeight = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.RowHeight = 22;
            this.gridView4.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView4_RowCellStyle);
            // 
            // gridColumnItemCode
            // 
            this.gridColumnItemCode.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemCode.AppearanceCell.Options.UseFont = true;
            this.gridColumnItemCode.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnItemCode.Caption = "²úÆ·±àºÅ";
            this.gridColumnItemCode.FieldName = "ItemCode";
            this.gridColumnItemCode.Name = "gridColumnItemCode";
            this.gridColumnItemCode.Visible = true;
            this.gridColumnItemCode.VisibleIndex = 0;
            // 
            // gridColumnGoodsCode
            // 
            this.gridColumnGoodsCode.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnGoodsCode.AppearanceCell.Options.UseFont = true;
            this.gridColumnGoodsCode.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnGoodsCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnGoodsCode.Caption = "ÉÌÆ·Âë";
            this.gridColumnGoodsCode.FieldName = "GoodsCode";
            this.gridColumnGoodsCode.Name = "gridColumnGoodsCode";
            // 
            // gridColumnColorNum
            // 
            this.gridColumnColorNum.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnColorNum.AppearanceCell.Options.UseFont = true;
            this.gridColumnColorNum.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnColorNum.AppearanceHeader.Options.UseFont = true;
            this.gridColumnColorNum.Caption = "É«ºÅ";
            this.gridColumnColorNum.FieldName = "ColorNum";
            this.gridColumnColorNum.Name = "gridColumnColorNum";
            this.gridColumnColorNum.Visible = true;
            this.gridColumnColorNum.VisibleIndex = 1;
            // 
            // gridColumnColorName
            // 
            this.gridColumnColorName.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnColorName.AppearanceCell.Options.UseFont = true;
            this.gridColumnColorName.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnColorName.AppearanceHeader.Options.UseFont = true;
            this.gridColumnColorName.Caption = "ÑÕÉ«";
            this.gridColumnColorName.FieldName = "ColorName";
            this.gridColumnColorName.Name = "gridColumnColorName";
            this.gridColumnColorName.Visible = true;
            this.gridColumnColorName.VisibleIndex = 2;
            // 
            // gridColumnMWidth
            // 
            this.gridColumnMWidth.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMWidth.AppearanceCell.Options.UseFont = true;
            this.gridColumnMWidth.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMWidth.AppearanceHeader.Options.UseFont = true;
            this.gridColumnMWidth.Caption = "ÃÅ·ù";
            this.gridColumnMWidth.FieldName = "MWidth";
            this.gridColumnMWidth.Name = "gridColumnMWidth";
            this.gridColumnMWidth.Visible = true;
            this.gridColumnMWidth.VisibleIndex = 3;
            // 
            // gridColumnMWeight
            // 
            this.gridColumnMWeight.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMWeight.AppearanceCell.Options.UseFont = true;
            this.gridColumnMWeight.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnMWeight.AppearanceHeader.Options.UseFont = true;
            this.gridColumnMWeight.Caption = "¿ËÖØ";
            this.gridColumnMWeight.FieldName = "MWeight";
            this.gridColumnMWeight.Name = "gridColumnMWeight";
            this.gridColumnMWeight.Visible = true;
            this.gridColumnMWeight.VisibleIndex = 4;
            // 
            // gridColumnWeightUnit
            // 
            this.gridColumnWeightUnit.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnWeightUnit.AppearanceCell.Options.UseFont = true;
            this.gridColumnWeightUnit.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnWeightUnit.AppearanceHeader.Options.UseFont = true;
            this.gridColumnWeightUnit.Caption = "¿ËÖØµ¥Î»";
            this.gridColumnWeightUnit.FieldName = "WeightUnit";
            this.gridColumnWeightUnit.Name = "gridColumnWeightUnit";
            // 
            // gridColumnItemName
            // 
            this.gridColumnItemName.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemName.AppearanceCell.Options.UseFont = true;
            this.gridColumnItemName.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemName.AppearanceHeader.Options.UseFont = true;
            this.gridColumnItemName.Caption = "³É·Ý";
            this.gridColumnItemName.FieldName = "ItemName";
            this.gridColumnItemName.Name = "gridColumnItemName";
            this.gridColumnItemName.Visible = true;
            this.gridColumnItemName.VisibleIndex = 5;
            // 
            // gridColumnVColorNum
            // 
            this.gridColumnVColorNum.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVColorNum.AppearanceCell.Options.UseFont = true;
            this.gridColumnVColorNum.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVColorNum.AppearanceHeader.Options.UseFont = true;
            this.gridColumnVColorNum.Caption = "¿ÍÉ«ºÅ";
            this.gridColumnVColorNum.FieldName = "VColorNum";
            this.gridColumnVColorNum.Name = "gridColumnVColorNum";
            // 
            // gridColumnVColorName
            // 
            this.gridColumnVColorName.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVColorName.AppearanceCell.Options.UseFont = true;
            this.gridColumnVColorName.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVColorName.AppearanceHeader.Options.UseFont = true;
            this.gridColumnVColorName.Caption = "¿ÍÉ«Ãû";
            this.gridColumnVColorName.FieldName = "VColorName";
            this.gridColumnVColorName.Name = "gridColumnVColorName";
            // 
            // gridColumnVItemCode
            // 
            this.gridColumnVItemCode.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVItemCode.AppearanceCell.Options.UseFont = true;
            this.gridColumnVItemCode.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnVItemCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnVItemCode.Caption = "¿Í²úÆ·±àÂë";
            this.gridColumnVItemCode.FieldName = "VItemCode";
            this.gridColumnVItemCode.Name = "gridColumnVItemCode";
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnQty.AppearanceCell.Options.UseFont = true;
            this.gridColumnQty.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnQty.AppearanceHeader.Options.UseFont = true;
            this.gridColumnQty.Caption = "ÊýÁ¿";
            this.gridColumnQty.FieldName = "Qty";
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.Visible = true;
            this.gridColumnQty.VisibleIndex = 7;
            // 
            // gridColumnUnit
            // 
            this.gridColumnUnit.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnUnit.AppearanceCell.Options.UseFont = true;
            this.gridColumnUnit.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnUnit.AppearanceHeader.Options.UseFont = true;
            this.gridColumnUnit.Caption = "µ¥Î»";
            this.gridColumnUnit.FieldName = "Unit";
            this.gridColumnUnit.Name = "gridColumnUnit";
            this.gridColumnUnit.Visible = true;
            this.gridColumnUnit.VisibleIndex = 8;
            // 
            // gridColumnSingPrice
            // 
            this.gridColumnSingPrice.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSingPrice.AppearanceCell.Options.UseFont = true;
            this.gridColumnSingPrice.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSingPrice.AppearanceHeader.Options.UseFont = true;
            this.gridColumnSingPrice.Caption = "µ¥¼Û";
            this.gridColumnSingPrice.FieldName = "SingPrice";
            this.gridColumnSingPrice.Name = "gridColumnSingPrice";
            this.gridColumnSingPrice.Visible = true;
            this.gridColumnSingPrice.VisibleIndex = 9;
            // 
            // gridColumnAmount
            // 
            this.gridColumnAmount.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnAmount.AppearanceCell.Options.UseFont = true;
            this.gridColumnAmount.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnAmount.AppearanceHeader.Options.UseFont = true;
            this.gridColumnAmount.Caption = "½ð¶î";
            this.gridColumnAmount.FieldName = "Amount";
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.Visible = true;
            this.gridColumnAmount.VisibleIndex = 10;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "ID";
            this.gridColumn3.FieldName = "ID";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "MainID";
            this.gridColumn4.FieldName = "MainID";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Seq";
            this.gridColumn5.FieldName = "Seq";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "½»ÆÚ";
            this.gridColumn6.FieldName = "DtsReqDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 11;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "±¸×¢";
            this.gridColumn7.FieldName = "Remark";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 12;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Æ·Ãû";
            this.gridColumn8.FieldName = "ItemModel";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 13;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.Caption = "¹æ¸ñ";
            this.gridColumn9.FieldName = "ItemStd";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.Caption = "Ð¡¸×·Ñ";
            this.gridColumn10.FieldName = "FAmount1";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 14;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "´òÑù·Ñ";
            this.gridColumn11.FieldName = "FAmount2";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 15;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn12.AppearanceCell.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.Caption = "ÖÆ°æ·Ñ";
            this.gridColumn12.FieldName = "FAmount3";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 16;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn13.AppearanceCell.Options.UseFont = true;
            this.gridColumn13.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn13.AppearanceHeader.Options.UseFont = true;
            this.gridColumn13.Caption = "ÉÏ»ú·Ñ";
            this.gridColumn13.FieldName = "FAmount4";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 17;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.Caption = "ÆäËû·ÑÓÃ";
            this.gridColumn14.FieldName = "FAmount5";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 18;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn15.AppearanceCell.Options.UseFont = true;
            this.gridColumn15.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn15.AppearanceHeader.Options.UseFont = true;
            this.gridColumn15.Caption = "Å÷²¼ËãÁÏ";
            this.gridColumn15.FieldName = "FabricCalcFlag";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 19;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn21.AppearanceCell.Options.UseFont = true;
            this.gridColumn21.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn21.AppearanceHeader.Options.UseFont = true;
            this.gridColumn21.Caption = "É´ÏßËãÁÏ";
            this.gridColumn21.FieldName = "YarnCalcFlag";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 20;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn22.AppearanceCell.Options.UseFont = true;
            this.gridColumn22.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn22.AppearanceHeader.Options.UseFont = true;
            this.gridColumn22.Caption = "ÏÂµ¥ÊýÁ¿";
            this.gridColumn22.FieldName = "InputQty";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 21;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn23.AppearanceCell.Options.UseFont = true;
            this.gridColumn23.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn23.AppearanceHeader.Options.UseFont = true;
            this.gridColumn23.Caption = "ÏÂµ¥µ¥Î»";
            this.gridColumn23.ColumnEdit = this.restxtunit;
            this.gridColumn23.FieldName = "InputUnit";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 22;
            // 
            // restxtunit
            // 
            this.restxtunit.AutoHeight = false;
            this.restxtunit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.restxtunit.Name = "restxtunit";
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn24.AppearanceCell.Options.UseFont = true;
            this.gridColumn24.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn24.AppearanceHeader.Options.UseFont = true;
            this.gridColumn24.Caption = "ÏÂµ¥µ¥¼Û";
            this.gridColumn24.FieldName = "InputSinglePrice";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 23;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn25.AppearanceCell.Options.UseFont = true;
            this.gridColumn25.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn25.AppearanceHeader.Options.UseFont = true;
            this.gridColumn25.Caption = "ÏÂµ¥½ð¶î";
            this.gridColumn25.FieldName = "InputAmount";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 24;
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn29.AppearanceCell.Options.UseFont = true;
            this.gridColumn29.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn29.AppearanceHeader.Options.UseFont = true;
            this.gridColumn29.Caption = "»»ËãÏµÊý";
            this.gridColumn29.FieldName = "InputConvertXS";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 25;
            // 
            // gridColumn30
            // 
            this.gridColumn30.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn30.AppearanceCell.Options.UseFont = true;
            this.gridColumn30.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn30.AppearanceHeader.Options.UseFont = true;
            this.gridColumn30.Caption = "¸´ºÏ²¼ËãÁÏ";
            this.gridColumn30.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn30.FieldName = "CompSiteCalFlag";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 26;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.BaseIlYesOrNo;
            // 
            // gridColumn33
            // 
            this.gridColumn33.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn33.AppearanceCell.Options.UseFont = true;
            this.gridColumn33.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn33.AppearanceHeader.Options.UseFont = true;
            this.gridColumn33.Caption = "Æ¥Êý";
            this.gridColumn33.FieldName = "PieceQty";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 27;
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn35.AppearanceCell.Options.UseFont = true;
            this.gridColumn35.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn35.AppearanceHeader.Options.UseFont = true;
            this.gridColumn35.Caption = "È«·ù";
            this.gridColumn35.FieldName = "AllMWidth";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 28;
            // 
            // gridColumn36
            // 
            this.gridColumn36.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn36.AppearanceCell.Options.UseFont = true;
            this.gridColumn36.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn36.AppearanceHeader.Options.UseFont = true;
            this.gridColumn36.Caption = "ÕëÐÍ";
            this.gridColumn36.FieldName = "Needle";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 29;
            // 
            // gridColumn37
            // 
            this.gridColumn37.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn37.AppearanceCell.Options.UseFont = true;
            this.gridColumn37.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn37.AppearanceHeader.Options.UseFont = true;
            this.gridColumn37.Caption = "·¢»õ·¶Î§";
            this.gridColumn37.FieldName = "OutRange";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 30;
            // 
            // gridColumn38
            // 
            this.gridColumn38.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn38.AppearanceCell.Options.UseFont = true;
            this.gridColumn38.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn38.AppearanceHeader.Options.UseFont = true;
            this.gridColumn38.Caption = "·ù¿í";
            this.gridColumn38.FieldName = "FK";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 31;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "ÉÏÏÞ";
            this.gridColumn39.FieldName = "MaxQty";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 32;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "ÏÂÏÞ";
            this.gridColumn41.FieldName = "MinQty";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 33;
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "¿îºÅ";
            this.gridColumn43.FieldName = "StyleNo";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 34;
            // 
            // gridColumn44
            // 
            this.gridColumn44.Caption = "½»ÆÚ£¨¿ÉÊäÈë£©";
            this.gridColumn44.FieldName = "ReqDateEdit";
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.Visible = true;
            this.gridColumn44.VisibleIndex = 35;
            // 
            // txtItemSalePrice
            // 
            this.txtItemSalePrice.AutoHeight = false;
            this.txtItemSalePrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtItemSalePrice.Name = "txtItemSalePrice";
            // 
            // drpGridColorNum
            // 
            this.drpGridColorNum.AutoHeight = false;
            this.drpGridColorNum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpGridColorNum.Name = "drpGridColorNum";
            // 
            // drpGridColorName
            // 
            this.drpGridColorName.AutoHeight = false;
            this.drpGridColorName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpGridColorName.Name = "drpGridColorName";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "¹«½ïÊý";
            this.gridColumn2.FieldName = "Weight";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 36;
            // 
            // gridColumn45
            // 
            this.gridColumn45.Caption = "ÂëÊý";
            this.gridColumn45.FieldName = "Yard";
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn45.Visible = true;
            this.gridColumn45.VisibleIndex = 37;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "Î´·¢Æ¥Êý";
            this.gridColumn46.FieldName = "NoFaPieceQty";
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 38;
            // 
            // gridColumn47
            // 
            this.gridColumn47.Caption = "Î´·¢Ã×Êý";
            this.gridColumn47.FieldName = "NoFaQty";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 39;
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "Î´·¢¹«½ïÊý";
            this.gridColumn48.FieldName = "NoFaWeight";
            this.gridColumn48.Name = "gridColumn48";
            this.gridColumn48.Visible = true;
            this.gridColumn48.VisibleIndex = 40;
            // 
            // gridColumn49
            // 
            this.gridColumn49.Caption = "Î´·¢ÂëÊý";
            this.gridColumn49.FieldName = "NoFaYard";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.Visible = true;
            this.gridColumn49.VisibleIndex = 41;
            // 
            // frmExportSaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 497);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControlColor);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmExportSaleOrder";
            this.Text = "frmSaleOrder";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlColor, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpHQFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtVendorAttn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaleOPName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMakeDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlColor)).EndInit();
            this.groupControlColor.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restxtunit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridColorNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridColorName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCSFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCSTime; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCSOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckOPID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCheckDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubmitFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnVendorID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCustomerCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderTypeID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderLevelID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnReqDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnContractDesc; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalAmount; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrderStatusID; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraEditors.TextEdit txtFormNo;
        private System.Windows.Forms.Label label25;
        private DevExpress.XtraEditors.DateEdit txtOrderDateE;
        private DevExpress.XtraEditors.DateEdit txtOrderDateS;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.CheckEdit chkOrderDate;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpYesOrNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.GroupControl groupControlColor;
        private System.Windows.Forms.Label lbCount;
        private DevExpress.XtraEditors.DateEdit txtMakeDateE;
        private DevExpress.XtraEditors.DateEdit txtMakeDateS;
        private System.Windows.Forms.Label label19;
        private DevExpress.XtraEditors.CheckEdit chkMakeDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem UpdateOrderStepToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private System.Windows.Forms.Label lbVendor;
        private HttSoft.UCFab.UCStatusBarStand ucStatusBarStand1;
        private HttSoft.UCFab.UCStatusBarStand ucStatusBarStand2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn51;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpHQFlag;
        private DevExpress.XtraEditors.TextEdit txtVendorAttn;
        private DevExpress.XtraEditors.TextEdit txtSaleOPName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkFlag;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGoodsCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnColorNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox drpGridColorNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnColorName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox drpGridColorName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMWidth;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnWeightUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVColorNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVColorName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox restxtunit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSingPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox txtItemSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAmount;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn49;
    }
}