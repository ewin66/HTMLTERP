namespace MLTERP
{
    partial class frmCompanyType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyType));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrganizeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnZipCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTaxCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBasedCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDealCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDelFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAllName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.txtQName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQName.Properties)).BeginInit();
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
            this.gridColumnCode,
            this.gridColumnName,
            this.gridColumnOrganizeCode,
            this.gridColumnTel,
            this.gridColumnFax,
            this.gridColumnAddress,
            this.gridColumnZipCode,
            this.gridColumnTaxCode,
            this.gridColumnBank,
            this.gridColumnAccount,
            this.gridColumnBasedCurrency,
            this.gridColumnDealCurrency,
            this.gridColumnRemark,
            this.gridColumnDelFlag,
            this.gridColumnEnName,
            this.gridColumnEnAddress,
            this.gridColumnAllName});
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
            this.gridColumnCode.Caption = "����";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 1;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "����";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 2;
            // 
            // gridColumnOrganizeCode
            // 
            this.gridColumnOrganizeCode.Caption = "������";
            this.gridColumnOrganizeCode.FieldName = "OrganizeCode";
            this.gridColumnOrganizeCode.Name = "gridColumnOrganizeCode";
            this.gridColumnOrganizeCode.Visible = true;
            this.gridColumnOrganizeCode.VisibleIndex = 3;
            // 
            // gridColumnTel
            // 
            this.gridColumnTel.Caption = "�绰";
            this.gridColumnTel.FieldName = "Tel";
            this.gridColumnTel.Name = "gridColumnTel";
            this.gridColumnTel.Visible = true;
            this.gridColumnTel.VisibleIndex = 4;
            // 
            // gridColumnFax
            // 
            this.gridColumnFax.Caption = "����";
            this.gridColumnFax.FieldName = "Fax";
            this.gridColumnFax.Name = "gridColumnFax";
            this.gridColumnFax.Visible = true;
            this.gridColumnFax.VisibleIndex = 5;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "��ַ";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 6;
            // 
            // gridColumnZipCode
            // 
            this.gridColumnZipCode.Caption = "����";
            this.gridColumnZipCode.FieldName = "ZipCode";
            this.gridColumnZipCode.Name = "gridColumnZipCode";
            this.gridColumnZipCode.Visible = true;
            this.gridColumnZipCode.VisibleIndex = 7;
            // 
            // gridColumnTaxCode
            // 
            this.gridColumnTaxCode.Caption = "˰��";
            this.gridColumnTaxCode.FieldName = "TaxCode";
            this.gridColumnTaxCode.Name = "gridColumnTaxCode";
            this.gridColumnTaxCode.Visible = true;
            this.gridColumnTaxCode.VisibleIndex = 8;
            // 
            // gridColumnBank
            // 
            this.gridColumnBank.Caption = "����";
            this.gridColumnBank.FieldName = "Bank";
            this.gridColumnBank.Name = "gridColumnBank";
            this.gridColumnBank.Visible = true;
            this.gridColumnBank.VisibleIndex = 9;
            // 
            // gridColumnAccount
            // 
            this.gridColumnAccount.Caption = "�˺�";
            this.gridColumnAccount.FieldName = "Account";
            this.gridColumnAccount.Name = "gridColumnAccount";
            this.gridColumnAccount.Visible = true;
            this.gridColumnAccount.VisibleIndex = 10;
            // 
            // gridColumnBasedCurrency
            // 
            this.gridColumnBasedCurrency.Caption = "����";
            this.gridColumnBasedCurrency.FieldName = "BasedCurrency";
            this.gridColumnBasedCurrency.Name = "gridColumnBasedCurrency";
            this.gridColumnBasedCurrency.Visible = true;
            this.gridColumnBasedCurrency.VisibleIndex = 11;
            // 
            // gridColumnDealCurrency
            // 
            this.gridColumnDealCurrency.Caption = "���";
            this.gridColumnDealCurrency.FieldName = "DealCurrency";
            this.gridColumnDealCurrency.Name = "gridColumnDealCurrency";
            this.gridColumnDealCurrency.Visible = true;
            this.gridColumnDealCurrency.VisibleIndex = 12;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "��ע";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 13;
            // 
            // gridColumnDelFlag
            // 
            this.gridColumnDelFlag.Caption = "ɾ����־";
            this.gridColumnDelFlag.FieldName = "DelFlag";
            this.gridColumnDelFlag.Name = "gridColumnDelFlag";
            this.gridColumnDelFlag.Visible = true;
            this.gridColumnDelFlag.VisibleIndex = 14;
            // 
            // gridColumnEnName
            // 
            this.gridColumnEnName.Caption = "Ӣ������";
            this.gridColumnEnName.FieldName = "EnName";
            this.gridColumnEnName.Name = "gridColumnEnName";
            this.gridColumnEnName.Visible = true;
            this.gridColumnEnName.VisibleIndex = 15;
            // 
            // gridColumnEnAddress
            // 
            this.gridColumnEnAddress.Caption = "Ӣ�ĵ�ַ";
            this.gridColumnEnAddress.FieldName = "EnAddress";
            this.gridColumnEnAddress.Name = "gridColumnEnAddress";
            this.gridColumnEnAddress.Visible = true;
            this.gridColumnEnAddress.VisibleIndex = 16;
            // 
            // gridColumnAllName
            // 
            this.gridColumnAllName.Caption = "ȫ��";
            this.gridColumnAllName.FieldName = "AllName";
            this.gridColumnAllName.Name = "gridColumnAllName";
            this.gridColumnAllName.Visible = true;
            this.gridColumnAllName.VisibleIndex = 17;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.txtQName);
            this.groupControlQuery.Controls.Add(this.label2);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(870, 48);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "��ѯ����";
            // 
            // txtQName
            // 
            this.txtQName.EditValue = "";
            this.txtQName.Location = new System.Drawing.Point(65, 18);
            this.txtQName.Name = "txtQName";
            this.txtQName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQName.Size = new System.Drawing.Size(116, 23);
            this.txtQName.TabIndex = 10;
            this.txtQName.EditValueChanged += new System.EventHandler(this.txtQName_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "����";
            // 
            // frmCompanyType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmCompanyType";
            this.Text = "frmCompanyType";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtQName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrganizeCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnTel; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnFax; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnZipCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnTaxCode; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnBank; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnAccount; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnBasedCurrency; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDealCurrency; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDelFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnEnName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnEnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAllName; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraEditors.TextEdit txtQName;
        private System.Windows.Forms.Label label2;
    }
}