namespace MLTERP
{
    partial class frmLYForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLYForm));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnColorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnColorNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFormDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMakeOPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubmitFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDelFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpIte = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.txtweightto = new DevExpress.XtraEditors.TextEdit();
            this.txtweightfrom = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemStd = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrderDateE = new DevExpress.XtraEditors.DateEdit();
            this.txtOrderDateS = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.chkOrderDate = new DevExpress.XtraEditors.CheckEdit();
            this.txtFormNo = new DevExpress.XtraEditors.TextEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.drpItemClassID = new DevExpress.XtraEditors.LookUpEdit();
            this.label27 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpDtsItemClassID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpIte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtweightto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtweightfrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpItemClassID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpDtsItemClassID)).BeginInit();
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
            this.groupControlDataList.Location = new System.Drawing.Point(0, 75);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(1075, 363);
            this.groupControlDataList.TabIndex = 33;
            this.groupControlDataList.Text = "Êý¾ÝÁÐ±í";
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
            this.drpIte,
            this.drpDtsItemClassID});
            this.gridControlDetail.Size = new System.Drawing.Size(1071, 343);
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
            this.gridColumnItemCode,
            this.gridColumnItemModel,
            this.gridColumnItemStd,
            this.gridColumnItemName,
            this.gridColumnColorName,
            this.gridColumnColorNum,
            this.gridColumnMWidth,
            this.gridColumnMWeight,
            this.gridColumnQty,
            this.gridColumnFormDate,
            this.gridColumnMakeOPName,
            this.gridColumnPosition,
            this.gridColumnSubmitFlag,
            this.gridColumnDelFlag,
            this.gridColumn1});
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
            this.gridColumnFormNo.Caption = "ÁôÑùµ¥ºÅ";
            this.gridColumnFormNo.FieldName = "FormNo";
            this.gridColumnFormNo.Name = "gridColumnFormNo";
            this.gridColumnFormNo.Visible = true;
            this.gridColumnFormNo.VisibleIndex = 1;
            // 
            // gridColumnItemCode
            // 
            this.gridColumnItemCode.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemCode.AppearanceCell.Options.UseFont = true;
            this.gridColumnItemCode.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnItemCode.Caption = "ÃæÁÏ±àºÅ";
            this.gridColumnItemCode.FieldName = "ItemCode";
            this.gridColumnItemCode.Name = "gridColumnItemCode";
            this.gridColumnItemCode.Visible = true;
            this.gridColumnItemCode.VisibleIndex = 2;
            // 
            // gridColumnItemModel
            // 
            this.gridColumnItemModel.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemModel.AppearanceCell.Options.UseFont = true;
            this.gridColumnItemModel.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemModel.AppearanceHeader.Options.UseFont = true;
            this.gridColumnItemModel.Caption = "Æ·Ãû";
            this.gridColumnItemModel.FieldName = "ItemModel";
            this.gridColumnItemModel.Name = "gridColumnItemModel";
            this.gridColumnItemModel.Visible = true;
            this.gridColumnItemModel.VisibleIndex = 3;
            // 
            // gridColumnItemStd
            // 
            this.gridColumnItemStd.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemStd.AppearanceCell.Options.UseFont = true;
            this.gridColumnItemStd.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnItemStd.AppearanceHeader.Options.UseFont = true;
            this.gridColumnItemStd.Caption = "¹æ¸ñ";
            this.gridColumnItemStd.FieldName = "ItemStd";
            this.gridColumnItemStd.Name = "gridColumnItemStd";
            this.gridColumnItemStd.Visible = true;
            this.gridColumnItemStd.VisibleIndex = 4;
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
            this.gridColumnColorName.VisibleIndex = 6;
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
            this.gridColumnColorNum.VisibleIndex = 7;
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
            this.gridColumnMWidth.VisibleIndex = 8;
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
            this.gridColumnMWeight.VisibleIndex = 9;
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnQty.AppearanceCell.Options.UseFont = true;
            this.gridColumnQty.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnQty.AppearanceHeader.Options.UseFont = true;
            this.gridColumnQty.Caption = "ÖØÁ¿";
            this.gridColumnQty.FieldName = "Qty";
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.Visible = true;
            this.gridColumnQty.VisibleIndex = 10;
            // 
            // gridColumnFormDate
            // 
            this.gridColumnFormDate.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnFormDate.AppearanceCell.Options.UseFont = true;
            this.gridColumnFormDate.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnFormDate.AppearanceHeader.Options.UseFont = true;
            this.gridColumnFormDate.Caption = "ÁôÑùÈÕÆÚ";
            this.gridColumnFormDate.FieldName = "FormDate";
            this.gridColumnFormDate.Name = "gridColumnFormDate";
            this.gridColumnFormDate.Visible = true;
            this.gridColumnFormDate.VisibleIndex = 11;
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
            this.gridColumnMakeOPName.VisibleIndex = 12;
            // 
            // gridColumnPosition
            // 
            this.gridColumnPosition.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnPosition.AppearanceCell.Options.UseFont = true;
            this.gridColumnPosition.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnPosition.AppearanceHeader.Options.UseFont = true;
            this.gridColumnPosition.Caption = "Î»ÖÃ";
            this.gridColumnPosition.FieldName = "Position";
            this.gridColumnPosition.Name = "gridColumnPosition";
            this.gridColumnPosition.Visible = true;
            this.gridColumnPosition.VisibleIndex = 13;
            // 
            // gridColumnSubmitFlag
            // 
            this.gridColumnSubmitFlag.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSubmitFlag.AppearanceCell.Options.UseFont = true;
            this.gridColumnSubmitFlag.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSubmitFlag.AppearanceHeader.Options.UseFont = true;
            this.gridColumnSubmitFlag.Caption = "Ìá½»±êÖ¾";
            this.gridColumnSubmitFlag.FieldName = "SubmitFlag";
            this.gridColumnSubmitFlag.Name = "gridColumnSubmitFlag";
            this.gridColumnSubmitFlag.Visible = true;
            this.gridColumnSubmitFlag.VisibleIndex = 14;
            // 
            // gridColumnDelFlag
            // 
            this.gridColumnDelFlag.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnDelFlag.AppearanceCell.Options.UseFont = true;
            this.gridColumnDelFlag.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnDelFlag.AppearanceHeader.Options.UseFont = true;
            this.gridColumnDelFlag.Caption = "É¾³ý±êÖ¾";
            this.gridColumnDelFlag.FieldName = "DelFlag";
            this.gridColumnDelFlag.Name = "gridColumnDelFlag";
            this.gridColumnDelFlag.Visible = true;
            this.gridColumnDelFlag.VisibleIndex = 15;
            // 
            // drpIte
            // 
            this.drpIte.AutoHeight = false;
            this.drpIte.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpIte.Name = "drpIte";
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.drpItemClassID);
            this.groupControlQuery.Controls.Add(this.label27);
            this.groupControlQuery.Controls.Add(this.label4);
            this.groupControlQuery.Controls.Add(this.label3);
            this.groupControlQuery.Controls.Add(this.txtweightto);
            this.groupControlQuery.Controls.Add(this.txtweightfrom);
            this.groupControlQuery.Controls.Add(this.label2);
            this.groupControlQuery.Controls.Add(this.txtItemStd);
            this.groupControlQuery.Controls.Add(this.label1);
            this.groupControlQuery.Controls.Add(this.txtItemCode);
            this.groupControlQuery.Controls.Add(this.label7);
            this.groupControlQuery.Controls.Add(this.txtOrderDateE);
            this.groupControlQuery.Controls.Add(this.txtOrderDateS);
            this.groupControlQuery.Controls.Add(this.label6);
            this.groupControlQuery.Controls.Add(this.chkOrderDate);
            this.groupControlQuery.Controls.Add(this.txtFormNo);
            this.groupControlQuery.Controls.Add(this.label25);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(1075, 50);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "²éÑ¯Ìõ¼þ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(510, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 834;
            this.label3.Text = "¿ËÖØ";
            // 
            // txtweightto
            // 
            this.txtweightto.EditValue = "";
            this.txtweightto.Location = new System.Drawing.Point(637, 128);
            this.txtweightto.Name = "txtweightto";
            this.txtweightto.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtweightto.Properties.Appearance.Options.UseFont = true;
            this.txtweightto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtweightto.Size = new System.Drawing.Size(50, 25);
            this.txtweightto.TabIndex = 833;
            // 
            // txtweightfrom
            // 
            this.txtweightfrom.EditValue = "";
            this.txtweightfrom.Location = new System.Drawing.Point(559, 128);
            this.txtweightfrom.Name = "txtweightfrom";
            this.txtweightfrom.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtweightfrom.Properties.Appearance.Options.UseFont = true;
            this.txtweightfrom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtweightfrom.Size = new System.Drawing.Size(50, 25);
            this.txtweightfrom.TabIndex = 832;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(615, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 830;
            this.label2.Text = "ÖÁ";
            // 
            // txtItemStd
            // 
            this.txtItemStd.EditValue = "";
            this.txtItemStd.Location = new System.Drawing.Point(587, 14);
            this.txtItemStd.Name = "txtItemStd";
            this.txtItemStd.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemStd.Properties.Appearance.Options.UseFont = true;
            this.txtItemStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtItemStd.Size = new System.Drawing.Size(100, 25);
            this.txtItemStd.TabIndex = 826;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(523, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 827;
            this.label1.Text = "²úÆ·¹æ¸ñ";
            // 
            // txtItemCode
            // 
            this.txtItemCode.EditValue = "";
            this.txtItemCode.Location = new System.Drawing.Point(251, 15);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemCode.Properties.Appearance.Options.UseFont = true;
            this.txtItemCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtItemCode.Size = new System.Drawing.Size(100, 25);
            this.txtItemCode.TabIndex = 820;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(191, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 825;
            this.label7.Text = "²úÆ·±àÂë";
            // 
            // txtOrderDateE
            // 
            this.txtOrderDateE.EditValue = "";
            this.txtOrderDateE.Location = new System.Drawing.Point(903, 14);
            this.txtOrderDateE.Name = "txtOrderDateE";
            this.txtOrderDateE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtOrderDateE.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrderDateE.Properties.Appearance.Options.UseFont = true;
            this.txtOrderDateE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDateE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateE.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateE.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateE.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtOrderDateE.Properties.ShowPopupShadow = false;
            this.txtOrderDateE.Size = new System.Drawing.Size(90, 25);
            this.txtOrderDateE.TabIndex = 819;
            // 
            // txtOrderDateS
            // 
            this.txtOrderDateS.EditValue = "";
            this.txtOrderDateS.Location = new System.Drawing.Point(784, 14);
            this.txtOrderDateS.Name = "txtOrderDateS";
            this.txtOrderDateS.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtOrderDateS.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrderDateS.Properties.Appearance.Options.UseFont = true;
            this.txtOrderDateS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDateS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtOrderDateS.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateS.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.txtOrderDateS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtOrderDateS.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtOrderDateS.Properties.ShowPopupShadow = false;
            this.txtOrderDateS.Size = new System.Drawing.Size(90, 25);
            this.txtOrderDateS.TabIndex = 818;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(880, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 823;
            this.label6.Text = "ÖÁ";
            // 
            // chkOrderDate
            // 
            this.chkOrderDate.Location = new System.Drawing.Point(707, 16);
            this.chkOrderDate.Name = "chkOrderDate";
            this.chkOrderDate.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOrderDate.Properties.Appearance.Options.UseFont = true;
            this.chkOrderDate.Properties.Caption = "ÁôÑùÈÕÆÚ";
            this.chkOrderDate.Size = new System.Drawing.Size(72, 22);
            this.chkOrderDate.TabIndex = 824;
            // 
            // txtFormNo
            // 
            this.txtFormNo.EditValue = "";
            this.txtFormNo.Location = new System.Drawing.Point(83, 15);
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFormNo.Properties.Appearance.Options.UseFont = true;
            this.txtFormNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFormNo.Size = new System.Drawing.Size(95, 25);
            this.txtFormNo.TabIndex = 817;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(16, 18);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 16);
            this.label25.TabIndex = 822;
            this.label25.Text = "ÁôÑùµ¥ºÅ";
            // 
            // drpItemClassID
            // 
            this.drpItemClassID.Location = new System.Drawing.Point(425, 15);
            this.drpItemClassID.Name = "drpItemClassID";
            this.drpItemClassID.Properties.Appearance.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.drpItemClassID.Properties.Appearance.Options.UseFont = true;
            this.drpItemClassID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpItemClassID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpItemClassID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpItemClassID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorName")});
            this.drpItemClassID.Properties.NullText = "";
            this.drpItemClassID.Properties.ShowFooter = false;
            this.drpItemClassID.Properties.ShowHeader = false;
            this.drpItemClassID.Size = new System.Drawing.Size(92, 25);
            this.drpItemClassID.TabIndex = 837;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(363, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 17);
            this.label27.TabIndex = 836;
            this.label27.Text = "ÃæÁÏÀàÐÍ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(440, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 835;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "ÃæÁÏÀàÐÍ";
            this.gridColumn1.ColumnEdit = this.drpDtsItemClassID;
            this.gridColumn1.FieldName = "ItemClassID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 16;
            // 
            // drpDtsItemClassID
            // 
            this.drpDtsItemClassID.AutoHeight = false;
            this.drpDtsItemClassID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpDtsItemClassID.Name = "drpDtsItemClassID";
            // 
            // frmLYForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmLYForm";
            this.Text = "frmLYForm";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpIte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtweightto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtweightfrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDateS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpItemClassID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpDtsItemClassID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormNo; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemModel; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemStd; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnColorName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnColorNum; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMWidth; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMWeight; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnFormDate; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMakeOPName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPosition; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubmitFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDelFlag; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraEditors.TextEdit txtItemCode;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DateEdit txtOrderDateE;
        private DevExpress.XtraEditors.DateEdit txtOrderDateS;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.CheckEdit chkOrderDate;
        private DevExpress.XtraEditors.TextEdit txtFormNo;
        private System.Windows.Forms.Label label25;
        private DevExpress.XtraEditors.TextEdit txtItemStd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtweightto;
        private DevExpress.XtraEditors.TextEdit txtweightfrom;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit drpIte;
        private DevExpress.XtraEditors.LookUpEdit drpItemClassID;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit drpDtsItemClassID;
    }
}