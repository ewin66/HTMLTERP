using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using System.Data;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
	/// <summary>
	/// 功能：报表管理
	/// 作者：陈加海
	/// 日期：2009-05-21
	/// </summary>
	public class frmReportManage : BaseForm
	{
        private DevExpress.XtraEditors.GroupControl groupControlMainten;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.GroupControl groupControlDataList;
		private DevExpress.XtraGrid.GridControl gridControlDetail;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
		
        private DevExpress.XtraEditors.LookUpEdit drpParentID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnWinListID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSeq;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnReportName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUrl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark;
        private DevExpress.XtraEditors.LookUpEdit drpWinListID;
        private DevExpress.XtraEditors.TextEdit txtReportName;
        private Label label3;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtQReportName;
        private DevExpress.XtraEditors.LookUpEdit drpQWinListID;
        private DevExpress.XtraEditors.LookUpEdit drpQParentID;
        private Label label4;
        private Label label5;
        private Label label7;
        private DevExpress.XtraEditors.TextEdit txtSeq;
        private Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFileName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnParentID;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSqlName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQueryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit drpReportSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit drpItemReport;
        private DevExpress.XtraTab.XtraTabControl xtraTabLock;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        //private DevExpress.XtraEditors.TextEdit txtFileExec;
        private Label label13;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.SimpleButton btnDeleteFile;
        private DevExpress.XtraEditors.TextEdit txtFilePath;
        private Label label10;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.TextEdit txtModelName;
        private OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.LookUpEdit drpReportModel;
        private Label label12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit drpReportModelType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.SimpleButton btnBrowseFile;
        private DevExpress.XtraEditors.TextEdit txtLocalFile;
        private Label label9;
        private DevExpress.XtraEditors.SimpleButton btnUp;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReportManage()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportManage));
            this.groupControlMainten = new DevExpress.XtraEditors.GroupControl();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowseFile = new DevExpress.XtraEditors.SimpleButton();
            this.txtLocalFile = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.drpReportModelType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.drpReportModel = new DevExpress.XtraEditors.LookUpEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSeq = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReportName = new DevExpress.XtraEditors.TextEdit();
            this.drpWinListID = new DevExpress.XtraEditors.LookUpEdit();
            this.drpParentID = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnParentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnWinListID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpGridYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.drpItemReport = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtQReportName = new DevExpress.XtraEditors.TextEdit();
            this.drpQWinListID = new DevExpress.XtraEditors.LookUpEdit();
            this.drpQParentID = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpReportSource = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnSqlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQueryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.xtraTabLock = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtModelName = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.txtFilePath = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDeleteFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.label13 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMainten)).BeginInit();
            this.groupControlMainten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpReportModelType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpReportModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpWinListID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpItemReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQReportName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpQWinListID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpQParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpReportSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabLock)).BeginInit();
            this.xtraTabLock.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
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
            // groupControlMainten
            // 
            this.groupControlMainten.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControlMainten.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControlMainten.Appearance.Options.UseBackColor = true;
            this.groupControlMainten.Appearance.Options.UseForeColor = true;
            this.groupControlMainten.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlMainten.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlMainten.Controls.Add(this.btnUp);
            this.groupControlMainten.Controls.Add(this.btnBrowseFile);
            this.groupControlMainten.Controls.Add(this.txtLocalFile);
            this.groupControlMainten.Controls.Add(this.label9);
            this.groupControlMainten.Controls.Add(this.drpReportModelType);
            this.groupControlMainten.Controls.Add(this.label2);
            this.groupControlMainten.Controls.Add(this.drpReportModel);
            this.groupControlMainten.Controls.Add(this.label12);
            this.groupControlMainten.Controls.Add(this.txtSeq);
            this.groupControlMainten.Controls.Add(this.label8);
            this.groupControlMainten.Controls.Add(this.txtRemark);
            this.groupControlMainten.Controls.Add(this.label3);
            this.groupControlMainten.Controls.Add(this.txtReportName);
            this.groupControlMainten.Controls.Add(this.drpWinListID);
            this.groupControlMainten.Controls.Add(this.drpParentID);
            this.groupControlMainten.Controls.Add(this.label1);
            this.groupControlMainten.Controls.Add(this.label11);
            this.groupControlMainten.Controls.Add(this.label6);
            this.groupControlMainten.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlMainten.Location = new System.Drawing.Point(0, 0);
            this.groupControlMainten.Name = "groupControlMainten";
            this.groupControlMainten.Size = new System.Drawing.Size(758, 114);
            this.groupControlMainten.TabIndex = 263;
            this.groupControlMainten.Text = "报表维护";
            // 
            // btnUp
            // 
            this.btnUp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnUp.Location = new System.Drawing.Point(620, 73);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 366;
            this.btnUp.Text = "上传";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnBrowseFile.Location = new System.Drawing.Point(530, 73);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFile.TabIndex = 365;
            this.btnBrowseFile.Text = "浏览";
            // 
            // txtLocalFile
            // 
            this.txtLocalFile.EditValue = "";
            this.txtLocalFile.Location = new System.Drawing.Point(73, 73);
            this.txtLocalFile.Name = "txtLocalFile";
            this.txtLocalFile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtLocalFile.Properties.MaxLength = 100;
            this.txtLocalFile.Size = new System.Drawing.Size(451, 23);
            this.txtLocalFile.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 363;
            this.label9.Text = "本地文件";
            // 
            // drpReportModelType
            // 
            this.drpReportModelType.EditValue = "模板";
            this.drpReportModelType.Location = new System.Drawing.Point(73, 44);
            this.drpReportModelType.Name = "drpReportModelType";
            this.drpReportModelType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpReportModelType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpReportModelType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpReportModelType.Properties.Items.AddRange(new object[] {
            "模板",
            "页面"});
            this.drpReportModelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpReportModelType.Size = new System.Drawing.Size(103, 23);
            this.drpReportModelType.TabIndex = 4;
            this.drpReportModelType.SelectedValueChanged += new System.EventHandler(this.drpReportModelType_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 283;
            this.label2.Text = "模板类型";
            // 
            // drpReportModel
            // 
            this.drpReportModel.Location = new System.Drawing.Point(246, 44);
            this.drpReportModel.Name = "drpReportModel";
            this.drpReportModel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpReportModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpReportModel.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpReportModel.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSA", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSB", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSDESC", "", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.drpReportModel.Properties.NullText = "";
            this.drpReportModel.Properties.ShowFooter = false;
            this.drpReportModel.Properties.ShowHeader = false;
            this.drpReportModel.Size = new System.Drawing.Size(278, 23);
            this.drpReportModel.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(186, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 281;
            this.label12.Text = "报表模板";
            // 
            // txtSeq
            // 
            this.txtSeq.EditValue = "";
            this.txtSeq.Location = new System.Drawing.Point(421, 17);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtSeq.Properties.MaxLength = 100;
            this.txtSeq.Size = new System.Drawing.Size(103, 23);
            this.txtSeq.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(360, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 274;
            this.label8.Text = "序号";
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "";
            this.txtRemark.Location = new System.Drawing.Point(603, 44);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtRemark.Properties.MaxLength = 100;
            this.txtRemark.Size = new System.Drawing.Size(103, 23);
            this.txtRemark.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(542, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 272;
            this.label3.Text = "备注";
            // 
            // txtReportName
            // 
            this.txtReportName.EditValue = "";
            this.txtReportName.Location = new System.Drawing.Point(603, 17);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtReportName.Properties.MaxLength = 100;
            this.txtReportName.Size = new System.Drawing.Size(103, 23);
            this.txtReportName.TabIndex = 3;
            // 
            // drpWinListID
            // 
            this.drpWinListID.Location = new System.Drawing.Point(246, 17);
            this.drpWinListID.Name = "drpWinListID";
            this.drpWinListID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpWinListID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpWinListID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpWinListID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSA", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSB", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSDESC", "", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.drpWinListID.Properties.NullText = "";
            this.drpWinListID.Properties.ShowFooter = false;
            this.drpWinListID.Properties.ShowHeader = false;
            this.drpWinListID.Size = new System.Drawing.Size(103, 23);
            this.drpWinListID.TabIndex = 1;
            // 
            // drpParentID
            // 
            this.drpParentID.Location = new System.Drawing.Point(73, 17);
            this.drpParentID.Name = "drpParentID";
            this.drpParentID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpParentID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpParentID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSA", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSB", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSDESC", "", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.drpParentID.Properties.NullText = "";
            this.drpParentID.Properties.ShowFooter = false;
            this.drpParentID.Properties.ShowHeader = false;
            this.drpParentID.Size = new System.Drawing.Size(103, 23);
            this.drpParentID.TabIndex = 0;
            this.drpParentID.EditValueChanged += new System.EventHandler(this.drpParentID_EditValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 264;
            this.label1.Text = "模块";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(186, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 262;
            this.label11.Text = "窗体";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(541, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 259;
            this.label6.Text = "报表名称";
            // 
            // groupControlDataList
            // 
            this.groupControlDataList.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControlDataList.Appearance.Options.UseBackColor = true;
            this.groupControlDataList.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlDataList.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlDataList.Controls.Add(this.gridControlDetail);
            this.groupControlDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDataList.Location = new System.Drawing.Point(0, 308);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(758, 151);
            this.groupControlDataList.TabIndex = 264;
            this.groupControlDataList.Text = "报表列表";
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
            this.drpGridYesOrNo});
            this.gridControlDetail.Size = new System.Drawing.Size(750, 128);
            this.gridControlDetail.TabIndex = 32;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnParentID,
            this.gridColumnWinListID,
            this.gridColumnName,
            this.gridColumnSeq,
            this.gridColumnReportName,
            this.gridColumnUrl,
            this.gridColumnFileName,
            this.gridColumnRemark,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn11});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnParentID
            // 
            this.gridColumnParentID.Caption = "ParentID";
            this.gridColumnParentID.FieldName = "ParentID";
            this.gridColumnParentID.Name = "gridColumnParentID";
            // 
            // gridColumnWinListID
            // 
            this.gridColumnWinListID.Caption = "窗体ID";
            this.gridColumnWinListID.FieldName = "WinListID";
            this.gridColumnWinListID.Name = "gridColumnWinListID";
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "窗体名称";
            this.gridColumnName.FieldName = "WinListName";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 0;
            this.gridColumnName.Width = 100;
            // 
            // gridColumnSeq
            // 
            this.gridColumnSeq.Caption = "序号";
            this.gridColumnSeq.FieldName = "Seq";
            this.gridColumnSeq.Name = "gridColumnSeq";
            this.gridColumnSeq.Visible = true;
            this.gridColumnSeq.VisibleIndex = 1;
            // 
            // gridColumnReportName
            // 
            this.gridColumnReportName.Caption = "报表名称";
            this.gridColumnReportName.FieldName = "ReportName";
            this.gridColumnReportName.Name = "gridColumnReportName";
            this.gridColumnReportName.Visible = true;
            this.gridColumnReportName.VisibleIndex = 2;
            this.gridColumnReportName.Width = 120;
            // 
            // gridColumnUrl
            // 
            this.gridColumnUrl.Caption = "报表路径";
            this.gridColumnUrl.FieldName = "Url";
            this.gridColumnUrl.Name = "gridColumnUrl";
            this.gridColumnUrl.Width = 200;
            // 
            // gridColumnFileName
            // 
            this.gridColumnFileName.Caption = "报表文件";
            this.gridColumnFileName.FieldName = "FileName";
            this.gridColumnFileName.Name = "gridColumnFileName";
            this.gridColumnFileName.Visible = true;
            this.gridColumnFileName.VisibleIndex = 3;
            this.gridColumnFileName.Width = 120;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "备注";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 4;
            this.gridColumnRemark.Width = 250;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "FileID";
            this.gridColumn5.FieldName = "FileID";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ModelID";
            this.gridColumn7.FieldName = "ModelID";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "ModelType";
            this.gridColumn11.FieldName = "ModelType";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // drpGridYesOrNo
            // 
            this.drpGridYesOrNo.AutoHeight = false;
            this.drpGridYesOrNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpGridYesOrNo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.drpGridYesOrNo.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("是", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("否", 0, 0)});
            this.drpGridYesOrNo.Name = "drpGridYesOrNo";
            this.drpGridYesOrNo.SmallImages = this.BaseIlYesOrNo;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // drpItemReport
            // 
            this.drpItemReport.AutoHeight = false;
            this.drpItemReport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpItemReport.Name = "drpItemReport";
            this.drpItemReport.NullText = "";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.txtQReportName);
            this.groupControl1.Controls.Add(this.drpQWinListID);
            this.groupControl1.Controls.Add(this.drpQParentID);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 254);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(758, 54);
            this.groupControl1.TabIndex = 263;
            this.groupControl1.Text = "报表查询";
            // 
            // txtQReportName
            // 
            this.txtQReportName.EditValue = "";
            this.txtQReportName.Location = new System.Drawing.Point(421, 21);
            this.txtQReportName.Name = "txtQReportName";
            this.txtQReportName.Properties.MaxLength = 100;
            this.txtQReportName.Size = new System.Drawing.Size(103, 21);
            this.txtQReportName.TabIndex = 10;
            this.txtQReportName.EditValueChanged += new System.EventHandler(this.txtQReportName_EditValueChanged);
            // 
            // drpQWinListID
            // 
            this.drpQWinListID.Location = new System.Drawing.Point(246, 21);
            this.drpQWinListID.Name = "drpQWinListID";
            this.drpQWinListID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpQWinListID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpQWinListID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpQWinListID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSA", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSB", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSDESC", "", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.drpQWinListID.Properties.NullText = "";
            this.drpQWinListID.Properties.ShowFooter = false;
            this.drpQWinListID.Properties.ShowHeader = false;
            this.drpQWinListID.Size = new System.Drawing.Size(103, 23);
            this.drpQWinListID.TabIndex = 9;
            this.drpQWinListID.EditValueChanged += new System.EventHandler(this.drpQWinListID_EditValueChanged);
            // 
            // drpQParentID
            // 
            this.drpQParentID.Location = new System.Drawing.Point(73, 21);
            this.drpQParentID.Name = "drpQParentID";
            this.drpQParentID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpQParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpQParentID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpQParentID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSA", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSB", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSDESC", "", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.drpQParentID.Properties.NullText = "";
            this.drpQParentID.Properties.ShowFooter = false;
            this.drpQParentID.Properties.ShowHeader = false;
            this.drpQParentID.Size = new System.Drawing.Size(103, 23);
            this.drpQParentID.TabIndex = 8;
            this.drpQParentID.EditValueChanged += new System.EventHandler(this.drpQParentID_EditValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 275;
            this.label4.Text = "模块";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(186, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 274;
            this.label5.Text = "窗体";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(360, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 273;
            this.label7.Text = "报表名称";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 114);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(758, 140);
            this.groupControl2.TabIndex = 265;
            this.groupControl2.Text = "报表数据源明细列表";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(4, 19);
            this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.drpReportSource});
            this.gridControl1.Size = new System.Drawing.Size(750, 117);
            this.gridControl1.TabIndex = 32;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumnSqlName,
            this.gridColumn4,
            this.gridColumnQueryName,
            this.gridColumn10});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "MainID";
            this.gridColumn1.FieldName = "MainID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Seq";
            this.gridColumn2.FieldName = "Seq";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "数据源类型";
            this.gridColumn3.ColumnEdit = this.drpReportSource;
            this.gridColumn3.FieldName = "DataSourceName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 100;
            // 
            // drpReportSource
            // 
            this.drpReportSource.AutoHeight = false;
            this.drpReportSource.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpReportSource.Name = "drpReportSource";
            // 
            // gridColumnSqlName
            // 
            this.gridColumnSqlName.Caption = "数据源名称";
            this.gridColumnSqlName.FieldName = "SqlName";
            this.gridColumnSqlName.Name = "gridColumnSqlName";
            this.gridColumnSqlName.Visible = true;
            this.gridColumnSqlName.VisibleIndex = 1;
            this.gridColumnSqlName.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "数据源SQL语句";
            this.gridColumn4.FieldName = "SqlStr";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 300;
            // 
            // gridColumnQueryName
            // 
            this.gridColumnQueryName.Caption = "查询关键字";
            this.gridColumnQueryName.FieldName = "QueryName";
            this.gridColumnQueryName.Name = "gridColumnQueryName";
            this.gridColumnQueryName.Visible = true;
            this.gridColumnQueryName.VisibleIndex = 3;
            this.gridColumnQueryName.Width = 100;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "备注";
            this.gridColumn10.FieldName = "Remark";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 150;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("是", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("否", 0, 0)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.BaseIlYesOrNo;
            // 
            // xtraTabLock
            // 
            this.xtraTabLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabLock.Location = new System.Drawing.Point(0, 0);
            this.xtraTabLock.Name = "xtraTabLock";
            this.xtraTabLock.PaintStyleName = "PropertyView";
            this.xtraTabLock.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabLock.Size = new System.Drawing.Size(760, 481);
            this.xtraTabLock.TabIndex = 267;
            this.xtraTabLock.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabLock.Text = "xtraTabControl1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl3);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(758, 459);
            this.xtraTabPage1.Text = "报表管理";
            // 
            // groupControl3
            // 
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.Controls.Add(this.groupControlDataList);
            this.groupControl3.Controls.Add(this.groupControl1);
            this.groupControl3.Controls.Add(this.groupControl2);
            this.groupControl3.Controls.Add(this.groupControlMainten);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(758, 459);
            this.groupControl3.TabIndex = 13;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupControl5);
            this.xtraTabPage2.Controls.Add(this.groupControl4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(758, 459);
            this.xtraTabPage2.Text = "模板管理";
            // 
            // groupControl5
            // 
            this.groupControl5.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControl5.Appearance.Options.UseBackColor = true;
            this.groupControl5.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl5.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl5.Controls.Add(this.gridControl2);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 91);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(758, 368);
            this.groupControl5.TabIndex = 265;
            this.groupControl5.Text = "模板列表";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Name = "";
            this.gridControl2.Location = new System.Drawing.Point(4, 19);
            this.gridControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControl2.MainView = this.gridView3;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2});
            this.gridControl2.Size = new System.Drawing.Size(750, 345);
            this.gridControl2.TabIndex = 32;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView3.GridControl = this.gridControl2;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ID";
            this.gridColumn6.FieldName = "ID";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "模板名称";
            this.gridColumn8.FieldName = "FileName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 300;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "上传时间";
            this.gridColumn9.FieldName = "UploadTime";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 120;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("是", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("否", 0, 0)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.SmallImages = this.BaseIlYesOrNo;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControl4.Appearance.Options.UseBackColor = true;
            this.groupControl4.Appearance.Options.UseForeColor = true;
            this.groupControl4.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl4.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl4.Controls.Add(this.txtModelName);
            this.groupControl4.Controls.Add(this.btnBrowse);
            this.groupControl4.Controls.Add(this.txtFilePath);
            this.groupControl4.Controls.Add(this.label10);
            this.groupControl4.Controls.Add(this.btnDeleteFile);
            this.groupControl4.Controls.Add(this.btnUpload);
            this.groupControl4.Controls.Add(this.label13);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(758, 91);
            this.groupControl4.TabIndex = 264;
            this.groupControl4.Text = "模板维护";
            // 
            // txtModelName
            // 
            this.txtModelName.EditValue = "";
            this.txtModelName.Location = new System.Drawing.Point(82, 22);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtModelName.Properties.MaxLength = 100;
            this.txtModelName.Size = new System.Drawing.Size(125, 23);
            this.txtModelName.TabIndex = 283;
            // 
            // btnBrowse
            // 
            this.btnBrowse.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnBrowse.Location = new System.Drawing.Point(600, 54);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 282;
            this.btnBrowse.Text = "浏览";
            // 
            // txtFilePath
            // 
            this.txtFilePath.EditValue = "";
            this.txtFilePath.Location = new System.Drawing.Point(82, 54);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtFilePath.Properties.MaxLength = 100;
            this.txtFilePath.Size = new System.Drawing.Size(512, 23);
            this.txtFilePath.TabIndex = 281;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(20, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 280;
            this.label10.Text = "模板文件";
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDeleteFile.Location = new System.Drawing.Point(319, 22);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFile.TabIndex = 279;
            this.btnDeleteFile.Text = "删除模板";
            // 
            // btnUpload
            // 
            this.btnUpload.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnUpload.Location = new System.Drawing.Point(224, 22);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 278;
            this.btnUpload.Text = "上传模板";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(20, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 273;
            this.label13.Text = "模板名称";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(275, 22);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.textEdit1.Properties.MaxLength = 100;
            this.textEdit1.Size = new System.Drawing.Size(341, 23);
            this.textEdit1.TabIndex = 281;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmReportManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(760, 481);
            this.Controls.Add(this.xtraTabLock);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "frmReportManage";
            this.Text = "报表管理";
            this.Load += new System.EventHandler(this.frmReportManage_Load);
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.xtraTabLock, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMainten)).EndInit();
            this.groupControlMainten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpReportModelType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpReportModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpWinListID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpItemReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQReportName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpQWinListID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpQParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpReportSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabLock)).EndInit();
            this.xtraTabLock.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtModelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region 全局变量
        string conditionstr = "";
        int saveID = 0;
        int saveFileID = 0;
        int saveModelFileID = 0;
        #endregion

        #region 自定义方法
        /// <summary>
		/// 校验数据
		/// </summary>
		/// <returns></returns>
        private bool CheckCorrect()
        {
            if (SysConvert.ToString(drpParentID.EditValue) == "")
            {
                this.ShowMessage("请选择模块");
                drpParentID.Focus();
                return false;
            }
            if (SysConvert.ToString(drpWinListID.EditValue) == "")
            {
                this.ShowMessage("请选择窗体");
                drpWinListID.Focus();
                return false;
            }
            if (txtReportName.Text.Trim() == "")
            {
                this.ShowMessage("请输入报表名称");
                txtReportName.Focus();
                return false;
            }
            if (drpReportModel.EditValue == null || drpReportModel.EditValue.ToString() == "")
            {
                ShowMessage("请选择报表使用的模板");
                return false;
            }
            return true;
        }

		/// <summary>
		/// 获得实体
		/// </summary>
		/// <returns></returns>
        private ReportManage GetEntity()
        {
            ReportManage entity = new ReportManage();
            entity.ID = saveID;
            entity.SelectByID();

            entity.ParentID = Convert.ToInt32(drpParentID.EditValue.ToString());
            entity.WinListID = Convert.ToInt32(drpWinListID.EditValue.ToString());
            entity.Seq = Convert.ToInt32(txtSeq.Text.Trim());
            entity.ReportName = txtReportName.Text.Trim();
            entity.Url = "\\Report\\";
            entity.ModelType = drpReportModelType.EditValue.ToString();
            entity.ModelID = Convert.ToInt32(drpReportModel.EditValue.ToString());
            entity.Remark = txtRemark.Text.Trim();
            entity.MUser = FParamConfig.LoginID;
            entity.MDate = DateTime.Now;
            if (saveFileID == 0)
            {
                //生成报表文件名
                FormNoControlRule rule = new FormNoControlRule();
                //entity.FileName = rule.RGetFormNo((int)FormList.报表流水号, "") + ".fr3";
            }

            return entity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ReportManageDts[] GetEntityDts()
        {
            int index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DataSourceName")) != "")
                {
                    index++;
                }
            }

            ReportManageDts[] entity = new ReportManageDts[index];
            index = 0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (SysConvert.ToString(gridView2.GetRowCellValue(i, "DataSourceName")) != "")
                {
                    entity[index] = new ReportManageDts();
                    entity[index].MainID = saveID;
                    entity[index].Seq = index + 1;
                    entity[index].SelectByID();

                    entity[index].DataSourceName = SysConvert.ToString(gridView2.GetRowCellValue(i, "DataSourceName"));
                    entity[index].SqlName = SysConvert.ToString(gridView2.GetRowCellValue(i, "SqlName"));
                    entity[index].SqlStr = SysConvert.ToString(gridView2.GetRowCellValue(i, "SqlStr"));
                    entity[index].QueryName = SysConvert.ToString(gridView2.GetRowCellValue(i, "QueryName"));
                    entity[index].Remark = SysConvert.ToString(gridView2.GetRowCellValue(i, "Remark"));

                    index++;
                }
            }

            return entity;
        }

        /// <summary>
        /// 报表文件实体
        /// </summary>
        private ReportFile GetEntityFile(string fileName)
        {
            ReportFile entity = new ReportFile();
            entity.ID = saveFileID;
            entity.SelectByID();
            entity.Context = HttSoft.WinUIBase.FastReport.ConvertToBinary(fileName);
            entity.FileName = drpWinListID.Text + ":" + txtReportName.Text.Trim();
            entity.UploadTime = DateTime.Now;
            return entity;
        }

        /// <summary>
        /// 报表模板
        /// </summary>
        private ReportFileModel GetEntityFileModel()
        {
            ReportFileModel entity = new ReportFileModel();
            entity.FileName = txtModelName.Text.Trim();
            entity.Context = HttSoft.WinUIBase.FastReport.ConvertToBinaryByPath(txtFilePath.Text.Trim());
            entity.UploadTime = DateTime.Now;
            return entity;
        }

        private void ClearAll()
        {
            drpParentID.EditValue = 0;
            drpWinListID.EditValue = 0;
            txtSeq.Text = "";
            txtReportName.Text = "";
            txtRemark.Text = "";

            ReportManageDtsRule rule = new ReportManageDtsRule();
            DataTable dt = rule.RShow(0);
            Common.AddDtRow(dt, 10);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }

		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindGrid()
		{
            ReportManageRule rule = new ReportManageRule();
            gridView1.GridControl.DataSource = rule.RShow(conditionstr, ProcessGrid.GetQueryField(gridView1));
			gridView1.GridControl.Show();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid2()
        {
            ReportManageDtsRule rule = new ReportManageDtsRule();
            DataTable dt = rule.RShow(saveID);
            Common.AddDtRow(dt, 10);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid3()
        {
            //ReportFileModelRule rule = new ReportFileModelRule();
            //gridView3.GridControl.DataSource = rule.RShow();
            //gridView3.GridControl.Show();
        }

        private void GetCondition()
        {
            string outstr = string.Empty;
            if (!Common.CheckLookUpEditBlank(drpQParentID))
            {
                outstr += " AND ParentID =" + SysString.ToDBString(SysConvert.ToInt32(drpQParentID.EditValue));
            }
            if (!Common.CheckLookUpEditBlank(drpQWinListID))
            {
                outstr += " AND WinListID =" + SysString.ToDBString(SysConvert.ToInt32(drpQWinListID.EditValue));
            }
            if (txtQReportName.Text.Trim() != "")
            {
                outstr += " AND ReportName like '%" + txtQReportName.Text.Trim() + "%' ";
            }
            outstr += " ORDER BY ParentID,WinListID,Seq";
            conditionstr = outstr;
        }
		#endregion

		#region 窗体加载
		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void frmReportManage_Load(object sender, System.EventArgs e)
        {
            try
            {
                ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI
                ProcessGrid.BindGridColumn(gridView2, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView2, this.FormListAID, this.FormListBID);//设置列UI

                this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
                gridViewBindEventA1(gridView1);
                this.gridViewBaseRowChangedA2 += new gridViewBaseRowChangedA(gridViewRowChanged3);//绑定GridView3事件
                gridViewBindEventA2(gridView3);

                //绑定模块
                Common.BindParentForm(drpQParentID, 0, true);
                Common.BindParentForm(drpParentID, 0, false);
                Common.BindReportSource(drpReportSource, true);

                //绑定报表模板
                Common.BindReportModel(drpReportModel, false);

                GetCondition();
                BindGrid();
                BindGrid2();
                BindGrid3();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

		/// <summary>
		/// 重新设置实体1
		/// </summary>
        private void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            saveID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            saveFileID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["FileID"]));
            drpParentID.EditValue = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ParentID"]));
            if (drpParentID.EditValue.ToString() != "" && drpParentID.EditValue.ToString() != "0")
            {
                Common.BindWinList(drpWinListID, Convert.ToInt32(drpParentID.EditValue.ToString()), false);
            }
            drpWinListID.EditValue = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WinListID"]));
            txtSeq.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Seq"]));
            txtReportName.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ReportName"]));
            drpReportModelType.EditValue = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ModelType"]));
            if (drpReportModelType.EditValue.ToString() == "模板")
            {
                //绑定报表模板
                Common.BindReportModel(drpReportModel, false);
            }
            else
            {
                //绑定报表
                Common.BindReport(drpReportModel, false);
            }
            drpReportModel.EditValue = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ModelID"]));
            txtRemark.Text = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Remark"]));

            BindGrid2();
        }

        /// <summary>
        /// 重新设置实体1
        /// </summary>
        private void gridViewRowChanged3(object sender)
        {
            ColumnView view = sender as ColumnView;
            saveModelFileID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            ReportFileModel reportFileModel = new ReportFileModel();
            reportFileModel.ID = saveModelFileID;
            reportFileModel.SelectByID();
            txtModelName.Text = reportFileModel.FileName;
        }
		#endregion

		#region 按钮事件
        ///// <summary>
        ///// 查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        GetCondition();
        //        BindGrid();
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        BaseFocusLabel.Focus();

        //        if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }
        //        if (!CheckCorrect())
        //        {
        //            return;
        //        }

        //        saveID = 0;
        //        saveFileID = 0;

        //        ReportManageRule rule = new ReportManageRule();
        //        ReportManage entity = this.GetEntity();
        //        ReportManageDts[] entityDts = this.GetEntityDts();

        //        //从数据库复制报表文件到本地
        //        if (drpReportModelType.EditValue.ToString() == "模板")
        //        {
        //            if (!FastReport.DownFileModel(entity.FileName, SysConvert.ToInt32(drpReportModel.EditValue.ToString())))
        //            {
        //                ShowMessage("模板文件不存在，请先上传模板");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (!FastReport.DownFile(entity.FileName, SysConvert.ToInt32(drpReportModel.EditValue.ToString())))
        //            {
        //                ShowMessage("模板文件不存在，请先上传模板");
        //                return;
        //            }
        //        }
        //        rule.RAdd(entity, entityDts);

        //        //把报表文件保存到数据库
        //        ReportFileRule reportFileRule = new ReportFileRule();
        //        ReportFile reportFile = this.GetEntityFile(entity.FileName);
        //        reportFileRule.RAdd(reportFile);

        //        saveID = entity.ID;
        //        saveFileID = reportFile.ID;
        //        string sql = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(saveFileID) + " WHERE ID=" + SysString.ToDBString(saveID);
        //        SysUtils.ExecuteNonQuery(sql);

        //        this.ShowInfoMessage("新增成功，模板文件" + entity.FileName + "生成成功！");

        //        BindGrid();
        //        ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { entity.ID.ToString() });

        //        FCommon.AddDBLog(this.Text, "新增", "ID:" + entity.ID.ToString(), entity.ID.ToString());
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 更新
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        BaseFocusLabel.Focus();

        //        if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }
        //        if (!CheckCorrect())
        //        {
        //            return;
        //        }

        //        ReportManageRule rule = new ReportManageRule();
        //        ReportManage entity = this.GetEntity();
        //        ReportManageDts[] entityDts = this.GetEntityDts();
        //        rule.RUpdate(entity, entityDts);

        //        //把报表文件保存到数据库
        //        ReportFileRule reportFileRule = new ReportFileRule();
        //        ReportFile reportFile = this.GetEntityFile(entity.FileName);
        //        if (saveFileID == 0)
        //        {
        //            reportFileRule.RAdd(reportFile);
        //            saveFileID = reportFile.ID;
        //            if (saveID != 0)
        //            {
        //                string sql = "UPDATE Data_ReportManage SET FileID=" + SysString.ToDBString(saveFileID) + " WHERE ID=" + SysString.ToDBString(saveID);
        //                SysUtils.ExecuteNonQuery(sql);
        //            }
        //        }
        //        else
        //        {
        //            reportFileRule.RUpdate(reportFile);
        //        }
        //        this.ShowInfoMessage("更新成功！");

        //        BindGrid();
        //        ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { entity.ID.ToString() });

        //        FCommon.AddDBLog(this.Text, "更新", "ID:" + entity.ID.ToString(), entity.ID.ToString());
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void btnUp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BaseFocusLabel.Focus();

        //        if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }
        //        if (txtLocalFile.Text.Trim() == "")
        //        {
        //            ShowMessage("请选择模板文件");
        //            return;
        //        }
        //        if (!SysFile.CheckFileExit(txtLocalFile.Text))
        //        {
        //            ShowMessage("模板文件没有找到" + Environment.NewLine + "路径：" + txtLocalFile.Text);
        //            return;
        //        }

        //        ReportManage entity = this.GetEntity();

        //        ReportFileRule reportFileRule = new ReportFileRule();
        //        ReportFile entityFile = new ReportFile();
        //        entityFile.ID = entity.FileID;
        //        entityFile.SelectByID();
        //        entityFile.Context = FastReport.ConvertToBinaryByPath(txtLocalFile.Text.Trim());
        //        reportFileRule.RUpdate(entityFile);

        //        this.ShowInfoMessage("上传成功！");
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }
        //        if(saveID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }
        //        if(DialogResult.Yes!=ShowConfirmMessage("删除为不可恢复操作，确认删除本条记录？"))
        //        {
        //            return;
        //        }
        //        //删除报表记录
        //        ReportManageRule rule = new ReportManageRule();
        //        ReportManage entity=this.GetEntity();
        //        rule.RDelete(entity);
        //        //删除报表文件
        //        ReportFileRule fileRule = new ReportFileRule();
        //        ReportFile file = this.GetEntityFile(entity.FileName);
        //        fileRule.RDelete(file);

        //        BindGrid();
				
        //        FCommon.AddDBLog(this.Text,"删除","ID:"+entity.ID.ToString(),entity.ID.ToString());
        //    }
        //    catch(Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 清空待新增
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))
        //        {
        //            this.ShowMessage("你没有此操作权限");
        //            return;
        //        }

        //        ClearAll();
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 设计
        ///// </summary>
        //private void btnToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        if (saveID == 0)
        //        {
        //            this.ShowMessage("请选择要操作的记录");
        //            return;
        //        }

        //        FastReport.ReportRun(saveID, (int)ReportPrintType.设计, new string[] { "1" }, new string[] { "1" });

        //        this.ShowInfoMessage("上传成功！");
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void btnUpload_Click(object sender, EventArgs e)
        //{
        //    if (txtModelName.Text.Trim() == "")
        //    {
        //        ShowMessage("请输入模板名称");
        //        return;
        //    }
        //    if (txtFilePath.Text.Trim() == "")
        //    {
        //        ShowMessage("请选择模板文件");
        //        return;
        //    }
        //    if (!SysFile.CheckFileExit(txtFilePath.Text))
        //    {
        //        ShowMessage("模板文件没有找到" + Environment.NewLine + "路径：" + txtFilePath.Text);
        //        return;
        //    }
        //    //把报表模板保存到数据库
        //    ReportFileModelRule reportFileRule = new ReportFileModelRule();
        //    ReportFileModel reportFile = this.GetEntityFileModel();
        //    //上传报表模板
        //    reportFileRule.RAdd(reportFile);
        //    saveModelFileID = reportFile.ID;
        //    this.ShowInfoMessage("上传成功！");

        //    Common.BindReportModel(drpReportModel, false);
        //    BindGrid3();
        //}

        //private void btnDeleteFile_Click(object sender, EventArgs e)
        //{
        //    if (saveModelFileID == 0)
        //    {
        //        ShowMessage("请选择要删除的模板");
        //        return;
        //    }

        //    //删除报表文件
        //    ReportFileModelRule fileRule = new ReportFileModelRule();
        //    ReportFileModel entity = new ReportFileModel();
        //    entity.ID = saveModelFileID;
        //    entity.SelectByID();
        //    fileRule.RDelete(entity);
        //    this.ShowInfoMessage("模板删除成功！");

        //    Common.BindReportModel(drpReportModel, false);
        //    BindGrid3();
        //}

        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        openFileDialog1.FileName = "";
        //        openFileDialog1.Filter = "(*.fr3)|*.fr3";
        //        openFileDialog1.ShowDialog();
        //        if (openFileDialog1.FileName != string.Empty)
        //        {
        //            txtFilePath.Text = openFileDialog1.FileName;
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

        //private void btnBrowseFile_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        openFileDialog1.FileName = "";
        //        openFileDialog1.Filter = "(*.fr3)|*.fr3";
        //        openFileDialog1.ShowDialog();
        //        if (openFileDialog1.FileName != string.Empty)
        //        {
        //            txtLocalFile.Text = openFileDialog1.FileName;
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}

		#endregion

        #region 其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        private void drpQParentID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //绑定模块
                if (drpQParentID.EditValue.ToString() == "" || drpQParentID.EditValue.ToString() == "0")
                {
                    Common.BindWinList(drpQWinListID, 1, true);
                }
                else
                {
                    Common.BindWinList(drpQWinListID, Convert.ToInt32(drpQParentID.EditValue.ToString()), true);
                }

                this.GetCondition();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpParentID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //绑定模块
                if (drpParentID.EditValue.ToString() == "" || drpParentID.EditValue.ToString() == "0")
                {
                    Common.BindWinList(drpWinListID, 1, true);
                }
                else
                {
                    Common.BindWinList(drpWinListID, Convert.ToInt32(drpParentID.EditValue.ToString()), false);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQWinListID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondition();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 快速查询
        /// </summary>
        private void txtQReportName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondition();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpReportModelType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (drpReportModelType.EditValue.ToString() == "模板")
            {
                //绑定报表模板
                Common.BindReportModel(drpReportModel, false);
            }
            else
            {
                //绑定报表
                Common.BindReport(drpReportModel, false);
            }
        }
        #endregion
    }
}
