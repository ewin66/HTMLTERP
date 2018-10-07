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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace MLTERP
{
	/// <summary>
	/// 功能：组织结构管理
	/// 作者：周富春
	/// 日期：2008-11-19
	/// </summary>
	public class frmStructure : BaseForm
	{
		private DevExpress.XtraEditors.GroupControl groupControlMainten;
		private DevExpress.XtraEditors.TextEdit txtID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.GroupControl groupControlDataList;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem btnUpdate;
		private DevExpress.XtraBars.BarButtonItem btnDelete;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtName;
		private DevExpress.XtraTreeList.TreeList treeList1;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnID;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnParentID;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItemInsertTop;
		private System.Windows.Forms.MenuItem menuItemUpdate;
		private System.Windows.Forms.MenuItem menuItemInsertSub;
		private System.Windows.Forms.MenuItem menuItemDelete;
		private System.Windows.Forms.MenuItem menuItemNodeInfo;
		private System.Windows.Forms.MenuItem menuItem6;
		private DevExpress.XtraBars.BarButtonItem btnSave;
		private DevExpress.XtraEditors.LookUpEdit drpParentID;
		private System.Windows.Forms.Label lblFormStatus;
		private DevExpress.XtraEditors.SplitterControl splitterControl1;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraEditors.SimpleButton btn2Insert;
		private DevExpress.XtraEditors.SimpleButton btn2Delete;
		private DevExpress.XtraEditors.SimpleButton btn2Query;
		private DevExpress.XtraEditors.TextEdit txt2QOPID;
		private System.Windows.Forms.Label label12;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkItemSelectFlag;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
		private DevExpress.XtraEditors.TextEdit txtCode;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.LookUpEdit drpWagesTypeID;
        private Label label4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit drpGridCompanyTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpYesOrNo;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 设置主管ToolStripMenuItem;
        private ToolStripMenuItem 取消主管ToolStripMenuItem;
        private ToolStripMenuItem 设置副主管ToolStripMenuItem;
        private ToolStripMenuItem 取消副主管ToolStripMenuItem;
        private Label lblInfo;
        private IContainer components;

		public frmStructure()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStructure));
            this.groupControlMainten = new DevExpress.XtraEditors.GroupControl();
            this.drpWagesTypeID = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormStatus = new System.Windows.Forms.Label();
            this.drpParentID = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItemNodeInfo = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItemUpdate = new System.Windows.Forms.MenuItem();
            this.menuItemInsertSub = new System.Windows.Forms.MenuItem();
            this.menuItemInsertTop = new System.Windows.Forms.MenuItem();
            this.menuItemDelete = new System.Windows.Forms.MenuItem();
            this.drpGridCompanyTypeID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置主管ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消主管ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置副主管ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消副主管ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.chkItemSelectFlag = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btn2Insert = new DevExpress.XtraEditors.SimpleButton();
            this.btn2Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn2Query = new DevExpress.XtraEditors.SimpleButton();
            this.txt2QOPID = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMainten)).BeginInit();
            this.groupControlMainten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpWagesTypeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridCompanyTypeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemSelectFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt2QOPID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
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
            this.groupControlMainten.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControlMainten.Appearance.Options.UseForeColor = true;
            this.groupControlMainten.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlMainten.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlMainten.Controls.Add(this.drpWagesTypeID);
            this.groupControlMainten.Controls.Add(this.label4);
            this.groupControlMainten.Controls.Add(this.txtCode);
            this.groupControlMainten.Controls.Add(this.label2);
            this.groupControlMainten.Controls.Add(this.lblFormStatus);
            this.groupControlMainten.Controls.Add(this.drpParentID);
            this.groupControlMainten.Controls.Add(this.label3);
            this.groupControlMainten.Controls.Add(this.txtName);
            this.groupControlMainten.Controls.Add(this.txtID);
            this.groupControlMainten.Controls.Add(this.label1);
            this.groupControlMainten.Controls.Add(this.label6);
            this.groupControlMainten.Location = new System.Drawing.Point(0, 25);
            this.groupControlMainten.Name = "groupControlMainten";
            this.groupControlMainten.Size = new System.Drawing.Size(1008, 45);
            this.groupControlMainten.TabIndex = 264;
            this.groupControlMainten.Text = "数据维护";
            // 
            // drpWagesTypeID
            // 
            this.drpWagesTypeID.Location = new System.Drawing.Point(463, 80);
            this.drpWagesTypeID.Name = "drpWagesTypeID";
            this.drpWagesTypeID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpWagesTypeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpWagesTypeID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpWagesTypeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSA"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSB")});
            this.drpWagesTypeID.Properties.NullText = "";
            this.drpWagesTypeID.Properties.ShowFooter = false;
            this.drpWagesTypeID.Properties.ShowHeader = false;
            this.drpWagesTypeID.Size = new System.Drawing.Size(97, 23);
            this.drpWagesTypeID.TabIndex = 276;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(394, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 277;
            this.label4.Text = "工资类型";
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "";
            this.txtCode.Location = new System.Drawing.Point(47, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCode.Properties.MaxLength = 100;
            this.txtCode.Size = new System.Drawing.Size(106, 23);
            this.txtCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 275;
            this.label2.Text = "编码";
            // 
            // lblFormStatus
            // 
            this.lblFormStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFormStatus.Location = new System.Drawing.Point(719, 17);
            this.lblFormStatus.Name = "lblFormStatus";
            this.lblFormStatus.Size = new System.Drawing.Size(240, 16);
            this.lblFormStatus.TabIndex = 273;
            this.lblFormStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // drpParentID
            // 
            this.drpParentID.Location = new System.Drawing.Point(414, 15);
            this.drpParentID.Name = "drpParentID";
            this.drpParentID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpParentID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.drpParentID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSA"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLSB")});
            this.drpParentID.Properties.NullText = "";
            this.drpParentID.Properties.ShowFooter = false;
            this.drpParentID.Properties.ShowHeader = false;
            this.drpParentID.Size = new System.Drawing.Size(129, 23);
            this.drpParentID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 271;
            this.label3.Text = "上级结构";
            // 
            // txtName
            // 
            this.txtName.EditValue = "";
            this.txtName.Location = new System.Drawing.Point(229, 16);
            this.txtName.Name = "txtName";
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtName.Properties.MaxLength = 100;
            this.txtName.Size = new System.Drawing.Size(106, 23);
            this.txtName.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.EditValue = "";
            this.txtID.Location = new System.Drawing.Point(721, 102);
            this.txtID.Name = "txtID";
            this.txtID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtID.Size = new System.Drawing.Size(80, 23);
            this.txtID.TabIndex = 263;
            this.txtID.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(681, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 264;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 259;
            this.label6.Text = "名称";
            // 
            // groupControlDataList
            // 
            this.groupControlDataList.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlDataList.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlDataList.Controls.Add(this.treeList1);
            this.groupControlDataList.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControlDataList.Location = new System.Drawing.Point(0, 0);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(320, 454);
            this.groupControlDataList.TabIndex = 265;
            this.groupControlDataList.Text = "数据列表";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.treeList1.ColumnPanelRowHeight = 22;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnID,
            this.treeListColumnParentID,
            this.treeListColumnName,
            this.treeListColumn1});
            this.treeList1.ContextMenu = this.contextMenu1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(2, 17);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AutoChangeParent = false;
            this.treeList1.OptionsBehavior.AutoNodeHeight = false;
            this.treeList1.OptionsBehavior.CanCloneNodesOnDrop = true;
            this.treeList1.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeList1.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.treeList1.OptionsBehavior.SmartMouseHover = false;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.drpGridCompanyTypeID});
            this.treeList1.Size = new System.Drawing.Size(316, 434);
            this.treeList1.TabIndex = 33;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeList1_DragDrop);
            this.treeList1.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.treeList1_NodeChanged);
            // 
            // treeListColumnID
            // 
            this.treeListColumnID.Caption = "ID";
            this.treeListColumnID.FieldName = "ID";
            this.treeListColumnID.MinWidth = 45;
            this.treeListColumnID.Name = "treeListColumnID";
            this.treeListColumnID.OptionsColumn.AllowEdit = false;
            this.treeListColumnID.OptionsColumn.AllowSize = false;
            this.treeListColumnID.OptionsColumn.ReadOnly = true;
            // 
            // treeListColumnParentID
            // 
            this.treeListColumnParentID.Caption = "父类型";
            this.treeListColumnParentID.FieldName = "ParentID";
            this.treeListColumnParentID.Name = "treeListColumnParentID";
            this.treeListColumnParentID.OptionsColumn.AllowEdit = false;
            this.treeListColumnParentID.OptionsColumn.ReadOnly = true;
            this.treeListColumnParentID.Width = 55;
            // 
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "部门";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.MinWidth = 81;
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.OptionsColumn.AllowEdit = false;
            this.treeListColumnName.OptionsColumn.ReadOnly = true;
            this.treeListColumnName.VisibleIndex = 0;
            this.treeListColumnName.Width = 214;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "编码";
            this.treeListColumn1.FieldName = "Code";
            this.treeListColumn1.MinWidth = 40;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn1.VisibleIndex = 1;
            this.treeListColumn1.Width = 41;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNodeInfo,
            this.menuItem6,
            this.menuItemUpdate,
            this.menuItemInsertSub,
            this.menuItemInsertTop,
            this.menuItemDelete});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItemNodeInfo
            // 
            this.menuItemNodeInfo.Index = 0;
            this.menuItemNodeInfo.Text = "类型：";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "-";
            // 
            // menuItemUpdate
            // 
            this.menuItemUpdate.Index = 2;
            this.menuItemUpdate.Text = "更新结构";
            this.menuItemUpdate.Click += new System.EventHandler(this.menuItemUpdate_Click);
            // 
            // menuItemInsertSub
            // 
            this.menuItemInsertSub.Index = 3;
            this.menuItemInsertSub.Text = "新增结构";
            this.menuItemInsertSub.Click += new System.EventHandler(this.menuItemInsertSub_Click);
            // 
            // menuItemInsertTop
            // 
            this.menuItemInsertTop.Index = 4;
            this.menuItemInsertTop.Text = "新增顶结构";
            this.menuItemInsertTop.Click += new System.EventHandler(this.menuItemInsertTop_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Index = 5;
            this.menuItemDelete.Text = "删除结构";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // drpGridCompanyTypeID
            // 
            this.drpGridCompanyTypeID.AutoHeight = false;
            this.drpGridCompanyTypeID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpGridCompanyTypeID.Name = "drpGridCompanyTypeID";
            this.drpGridCompanyTypeID.NullText = "";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnUpdate,
            this.btnDelete,
            this.barButtonItem1,
            this.barButtonItem2});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Custom 1";
            this.bar1.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Id = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInsert_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "更新";
            this.btnUpdate.Id = 1;
            this.btnUpdate.Name = "btnUpdate";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除";
            this.btnDelete.Id = 2;
            this.btnDelete.Name = "btnDelete";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // splitterControl1
            // 
            this.splitterControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitterControl1.Location = new System.Drawing.Point(320, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(4, 454);
            this.splitterControl1.TabIndex = 267;
            this.splitterControl1.TabStop = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(324, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.PaintStyleName = "PropertyView";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(684, 454);
            this.xtraTabControl1.TabIndex = 270;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupControl3);
            this.xtraTabPage2.Controls.Add(this.groupControl2);
            this.xtraTabPage2.Controls.Add(this.groupControl4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(682, 432);
            this.xtraTabPage2.Text = "管理部门员工";
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl3.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl3.Controls.Add(this.gridControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(312, 60);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(370, 372);
            this.groupControl3.TabIndex = 270;
            this.groupControl3.Text = "公司员工";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Name = "";
            this.gridControl2.Location = new System.Drawing.Point(2, 17);
            this.gridControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControl2.MainView = this.gridView3;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2,
            this.repositoryItemCheckEdit1});
            this.gridControl2.Size = new System.Drawing.Size(366, 352);
            this.gridControl2.TabIndex = 33;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView3.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView3.Appearance.Row.Options.UseTextOptions = true;
            this.gridView3.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView3.ColumnPanelRowHeight = 22;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView3.GridControl = this.gridControl2;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "编号";
            this.gridColumn4.FieldName = "OPID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 96;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "姓名";
            this.gridColumn5.FieldName = "OPName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 118;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "选择";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "SelectFlag";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 62;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
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
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(0, 60);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(312, 372);
            this.groupControl2.TabIndex = 269;
            this.groupControl2.Text = "部门员工";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(2, 17);
            this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.chkItemSelectFlag,
            this.drpYesOrNo});
            this.gridControl1.Size = new System.Drawing.Size(308, 352);
            this.gridControl1.TabIndex = 32;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置主管ToolStripMenuItem,
            this.取消主管ToolStripMenuItem,
            this.设置副主管ToolStripMenuItem,
            this.取消副主管ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);
            // 
            // 设置主管ToolStripMenuItem
            // 
            this.设置主管ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.设置主管ToolStripMenuItem.Name = "设置主管ToolStripMenuItem";
            this.设置主管ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.设置主管ToolStripMenuItem.Text = "设置主管";
            this.设置主管ToolStripMenuItem.Click += new System.EventHandler(this.设置主管ToolStripMenuItem_Click);
            // 
            // 取消主管ToolStripMenuItem
            // 
            this.取消主管ToolStripMenuItem.Name = "取消主管ToolStripMenuItem";
            this.取消主管ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.取消主管ToolStripMenuItem.Text = "取消主管";
            this.取消主管ToolStripMenuItem.Click += new System.EventHandler(this.取消主管ToolStripMenuItem_Click);
            // 
            // 设置副主管ToolStripMenuItem
            // 
            this.设置副主管ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.设置副主管ToolStripMenuItem.Name = "设置副主管ToolStripMenuItem";
            this.设置副主管ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.设置副主管ToolStripMenuItem.Text = "设置副主管";
            this.设置副主管ToolStripMenuItem.Click += new System.EventHandler(this.设置副主管ToolStripMenuItem_Click);
            // 
            // 取消副主管ToolStripMenuItem
            // 
            this.取消副主管ToolStripMenuItem.Name = "取消副主管ToolStripMenuItem";
            this.取消副主管ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.取消副主管ToolStripMenuItem.Text = "取消副主管";
            this.取消副主管ToolStripMenuItem.Click += new System.EventHandler(this.取消副主管ToolStripMenuItem_Click);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView2.Appearance.Row.Options.UseTextOptions = true;
            this.gridView2.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView2.ColumnPanelRowHeight = 22;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn7});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "OPID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 96;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.FieldName = "OPName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 118;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "主管";
            this.gridColumn3.ColumnEdit = this.drpYesOrNo;
            this.gridColumn3.FieldName = "LeaderFlag";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // drpYesOrNo
            // 
            this.drpYesOrNo.AutoHeight = false;
            this.drpYesOrNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpYesOrNo.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1)});
            this.drpYesOrNo.Name = "drpYesOrNo";
            this.drpYesOrNo.SmallImages = this.BaseIlYesOrNo;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "副主管";
            this.gridColumn7.ColumnEdit = this.drpYesOrNo;
            this.gridColumn7.FieldName = "LeaderAttnFlag";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
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
            // chkItemSelectFlag
            // 
            this.chkItemSelectFlag.AutoHeight = false;
            this.chkItemSelectFlag.Name = "chkItemSelectFlag";
            this.chkItemSelectFlag.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkItemSelectFlag.ValueChecked = 1;
            this.chkItemSelectFlag.ValueUnchecked = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.groupControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControl4.Appearance.Options.UseBackColor = true;
            this.groupControl4.Appearance.Options.UseForeColor = true;
            this.groupControl4.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl4.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl4.Controls.Add(this.lblInfo);
            this.groupControl4.Controls.Add(this.btn2Insert);
            this.groupControl4.Controls.Add(this.btn2Delete);
            this.groupControl4.Controls.Add(this.btn2Query);
            this.groupControl4.Controls.Add(this.txt2QOPID);
            this.groupControl4.Controls.Add(this.label12);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(682, 60);
            this.groupControl4.TabIndex = 271;
            this.groupControl4.Text = "查询条件";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(327, 24);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(29, 12);
            this.lblInfo.TabIndex = 690;
            this.lblInfo.Text = "test";
            this.lblInfo.Visible = false;
            // 
            // btn2Insert
            // 
            this.btn2Insert.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn2Insert.Location = new System.Drawing.Point(7, 21);
            this.btn2Insert.Name = "btn2Insert";
            this.btn2Insert.Size = new System.Drawing.Size(56, 23);
            this.btn2Insert.TabIndex = 473;
            this.btn2Insert.Text = "保存";
            this.btn2Insert.Click += new System.EventHandler(this.btn2Insert_Click);
            // 
            // btn2Delete
            // 
            this.btn2Delete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn2Delete.Location = new System.Drawing.Point(32, 83);
            this.btn2Delete.Name = "btn2Delete";
            this.btn2Delete.Size = new System.Drawing.Size(56, 23);
            this.btn2Delete.TabIndex = 472;
            this.btn2Delete.Text = "删除";
            this.btn2Delete.Click += new System.EventHandler(this.btn2Delete_Click);
            // 
            // btn2Query
            // 
            this.btn2Query.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn2Query.Location = new System.Drawing.Point(287, 109);
            this.btn2Query.Name = "btn2Query";
            this.btn2Query.Size = new System.Drawing.Size(56, 23);
            this.btn2Query.TabIndex = 471;
            this.btn2Query.Text = "查询";
            this.btn2Query.Click += new System.EventHandler(this.btn2Query_Click);
            // 
            // txt2QOPID
            // 
            this.txt2QOPID.EditValue = "";
            this.txt2QOPID.Location = new System.Drawing.Point(183, 109);
            this.txt2QOPID.Name = "txt2QOPID";
            this.txt2QOPID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txt2QOPID.Properties.MaxLength = 50;
            this.txt2QOPID.Size = new System.Drawing.Size(96, 23);
            this.txt2QOPID.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(135, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 262;
            this.label12.Text = "工号";
            // 
            // treeList2
            // 
            this.treeList2.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treeList2.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList2.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5});
            this.treeList2.ContextMenu = this.contextMenu1;
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList2.Location = new System.Drawing.Point(4, 19);
            this.treeList2.Name = "treeList2";
            this.treeList2.OptionsBehavior.AutoChangeParent = false;
            this.treeList2.OptionsBehavior.AutoNodeHeight = false;
            this.treeList2.OptionsBehavior.CanCloneNodesOnDrop = true;
            this.treeList2.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeList2.OptionsBehavior.DragNodes = true;
            this.treeList2.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeList2.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.treeList2.OptionsBehavior.SmartMouseHover = false;
            this.treeList2.OptionsView.AutoWidth = false;
            this.treeList2.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList2.OptionsView.ShowFocusedFrame = false;
            this.treeList2.Size = new System.Drawing.Size(312, 364);
            this.treeList2.TabIndex = 33;
            this.treeList2.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "ID";
            this.treeListColumn2.FieldName = "ID";
            this.treeListColumn2.MinWidth = 45;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.Width = 78;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "父类型";
            this.treeListColumn3.FieldName = "ParentID";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.ReadOnly = true;
            this.treeListColumn3.Width = 55;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "部门";
            this.treeListColumn4.FieldName = "Name";
            this.treeListColumn4.MinWidth = 81;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.OptionsColumn.ReadOnly = true;
            this.treeListColumn4.VisibleIndex = 1;
            this.treeListColumn4.Width = 189;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "编码";
            this.treeListColumn5.FieldName = "Code";
            this.treeListColumn5.MinWidth = 367;
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.VisibleIndex = 0;
            this.treeListColumn5.Width = 66;
            // 
            // frmStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1008, 454);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlMainten);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "frmStructure";
            this.Text = "组织结构";
            this.Load += new System.EventHandler(this.frmItemClass_Load);
            this.Closed += new System.EventHandler(this.frmItemClass_Closed);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.groupControlMainten, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMainten)).EndInit();
            this.groupControlMainten.ResumeLayout(false);
            this.groupControlMainten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpWagesTypeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridCompanyTypeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemSelectFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt2QOPID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
		#region 自定义方法

		int saveID=0;
		private string saveSubID="''";

		private enum NodeStatus
		{
			查询,新增顶类型,新增子类型,更新类型
		}
		private NodeStatus curNodeStatus=NodeStatus.查询;

		/// <summary>
		/// 设置控件状态
		/// </summary>
		private void NodeStatusSetUI()
		{
			switch(curNodeStatus)
			{
				case NodeStatus.查询:
					txtName.Text="";
					txtID.Text="";
					drpParentID.EditValue=null;
					this.lblFormStatus.Text="";
					btnSave.Enabled=false;
					break;
				case NodeStatus.新增顶类型:
					txtName.Text="";
					txtID.Text="";					
					drpParentID.EditValue=0;
					this.lblFormStatus.Text="新增顶部门";
					btnSave.Enabled=true;
					break;
				case NodeStatus.新增子类型:
					txtName.Text="";
					txtID.Text="";
					drpParentID.EditValue=SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
					this.lblFormStatus.Text="新增子部门";
					btnSave.Enabled=true;
					break;
				case NodeStatus.更新类型:
					txtName.Text=menuItemNodeInfo.Text=SysConvert.ToString(treeList1.FocusedNode.GetValue("Name"));
					txtID.Text=menuItemNodeInfo.Text=SysConvert.ToString(treeList1.FocusedNode.GetValue("ID"));
					drpParentID.EditValue=SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ParentID"));
                    drpWagesTypeID.EditValue = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("WagesTypeID"));
					txtCode.Text=SysConvert.ToString(treeList1.FocusedNode.GetValue("Code"));
                    //drpCompanyTypeID.EditValue = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("CompanyTypeID"));
					this.lblFormStatus.Text="更新部门";
					btnSave.Enabled=true;
					break;
			}			
		}



		/// <summary>
		/// 校验数据
		/// </summary>
		/// <returns></returns>
		private bool CheckCorrect()
		{
			if(txtName.Text.Trim()=="")
			{
				this.ShowMessage("请输入名称");
				txtName.Focus();
				return false;
			}
			return true;
		}
		/// <summary>
		/// 获得实体
		/// </summary>
		/// <returns></returns>
		private Structure GetEntity()
		{
			Structure entity=new Structure();
			entity.ID=SysConvert.ToInt32(txtID.Text.Trim());
			entity.Name=txtName.Text.Trim();
			entity.ParentID=SysConvert.ToInt32(drpParentID.EditValue);
            //entity.WagesTypeID = SysConvert.ToInt32(drpWagesTypeID.EditValue);
			entity.Code=txtCode.Text.Trim();
            //entity.CompanyTypeID = SysConvert.ToInt32(drpCompanyTypeID.EditValue);

			return entity;
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindGridItemType()
		{
			//ItemClassRule rule=new ItemClassRule();
			//gridView2.GridControl.DataSource=rule.RShowItemType("",ProcessGrid.GetQueryField(gridView2));
			//gridView2.GridControl.Show();
		}


		/// <summary>
		/// 绑定Grid数据
		/// </summary>
        private void BindTreeList()
        {
            treeList1.Nodes.Clear();
            StructureRule rule=new StructureRule();
            //DataTable dt =rule.RShow(" ORDER BY ParentID,Code", ProcessTreeList.GetQueryField(treeList1));
            DataTable dt = SysUtils.Fill("EXEC USP1_Data_Stucture_Get");
            ProcessTreeList.BindTreeList(dt, treeList1, "ID", "ParentID", 7, true);
        }
		#endregion

		#region 部门员工自定义方法
		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindGrid1()
		{
			
		}


		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindGrid2()
		{
            saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
            string sql = "SELECT * FROM UV1_Data_StructureMember WHERE StuctureID=" + SysString.ToDBString(saveID);
			gridView2.GridControl.DataSource=SysUtils.Fill(sql);
			gridView2.GridControl.Show();
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindGrid3()
		{
            saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
            string sql = string.Empty;
            sql += "SELECT 0 SelectFlag,OPName,OPID FROM Data_OP WHERE ";
            sql += " UseableFlag=1 AND DefaultFlag=0";
			if(txt2QOPID.Text.Trim()!=string.Empty)
			{
				sql+=" AND OPID LIKE "+SysString.ToDBString("%"+txt2QOPID.Text.Trim()+"%");
			}
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                dr["SelectFlag"] = CheckStructureMember(dr["OPID"].ToString(), saveID);
            }
            gridView3.GridControl.DataSource = dt;
			gridView3.GridControl.Show();
		}

        private int CheckStructureMember(string p_OPID, int p_saveID)
        {
            int submitFlag = 0;
            string sql = "SELECT * FROM Data_StructureMember WHERE OPID="+SysString.ToDBString(p_OPID);
            sql += " AND StuctureID="+SysString.ToDBString(p_saveID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                submitFlag = 1;
            }
            return submitFlag;
        }


		/// <summary>
		/// 取得选择数组
		/// </summary>
		/// <returns></returns>
		private string[] GetSelectArray(GridView p_View)
		{
			int index=0;
            DataTable dtSource = (DataTable)p_View.GridControl.DataSource;
            for (int i = 0; i < dtSource.Rows.Count; i++)
			{
				if(SysConvert.ToInt32(dtSource.Rows[i]["SelectFlag"])==1)
				{
					index++;
				}
			}
			string[] tempa=new string[index];
			index=0;
            for (int i = 0; i < dtSource.Rows.Count; i++)
			{
				if(SysConvert.ToInt32(dtSource.Rows[i]["SelectFlag"])==1)
				{
                    tempa[index] = SysConvert.ToString(dtSource.Rows[i]["OPID"]);
					index++;
				}
			}
			return tempa;
		}

		#endregion


		#region Form事件
		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmItemClass_Load(object sender, System.EventArgs e)
		{
			try
			{
				


				ProcessTreeList.BindTreeColumn(treeList1,this.FormID);//绑定列				
				//ProcessTreeList.SetTreeColumnUI(treeList1);//设置列UI

                ProcessGrid.BindGridColumn(gridView2, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView2, FormListAID, FormListBID);//设置列UI

                ProcessGrid.BindGridColumn(gridView3, this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView3, FormListAID, FormListBID);//设置列UI
				

				//this.gridViewBaseRowChangedA1+= new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
				//gridViewBindEventA1(gridView2);

                //Common.BindCompanyType(drpCompanyTypeID, true);

                //Common.BindCompanyType(drpGridCompanyTypeID, true);


				Common.BindStructure(drpParentID,true);
                //Common.BindWagesType(drpWagesTypeID, true);
				BindTreeList();

				if(!FCommon.RightCheck(this.FormID,this.FormListAID,this.FormListBID,RightSub.提交1))//管理组织结构
				{
					treeList1.ContextMenu=null;
					groupControlMainten.Visible=false;
					bar1.Visible=false;
				}
				if(!FCommon.RightCheck(this.FormID,this.FormListAID,this.FormListBID,RightSub.新增))//管理组织结构员工
				{
					xtraTabPage2.PageVisible=false;
				}

						
				gridView2.OptionsBehavior.ShowEditorOnMouseUp=false;				
				gridView3.OptionsBehavior.ShowEditorOnMouseUp=false;
				//BindGridItemType();
                BindGrid3();
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}
		/// <summary>
		/// 窗口关闭
		/// </summary>
		private void frmItemClass_Closed(object sender, System.EventArgs e)
		{
			try
			{
				this.Dispose();
			}
			catch(Exception E)
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
			//drpItemType.EditValue=SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
			//			txtName.Text=SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Name"]));
			//			txtRemark.Text=SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Remark"]));
		}
		#endregion

		#region 按钮事件
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if(!CheckCorrect())
				{
					return;
				}
				if(!FCommon.RightCheck(this.FormID,this.FormListAID,this.FormListBID,RightSub.新增))
				{
					this.ShowMessage("你没有管理权限");
					return;
				}
				StructureRule rule=new StructureRule();
				Structure entity=this.GetEntity();
				switch(curNodeStatus)
				{
					
					case NodeStatus.新增顶类型:						
						rule.RAdd(entity);						
						break;
					case NodeStatus.新增子类型:
						goto case NodeStatus.新增顶类型;
					case NodeStatus.更新类型:
						rule.RUpdate(entity);
						break;
				}	

				
				Common.BindStructure(drpParentID,true);
				BindTreeList();

				curNodeStatus=NodeStatus.查询;
				NodeStatusSetUI();
				
				
				ProcessTreeList.TreeListFocus(treeList1,new string[1]{"ID"},new string[1]{entity.ID.ToString()});
				//ProcessTreeList
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}
		#endregion

		
		#region 其它事件
		/// <summary>
		/// 物品类型改变
		/// </summary>
		private void drpItemType_EditValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				BindTreeList();
				//Common.BindItemClass(drpParentID,SysConvert.ToInt32(drpItemType.EditValue),true);
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}		
		#endregion


		#region Treelist右键菜单事件

		/// <summary>
		/// 设置右键菜单状态
		/// </summary>
		/// <param name="p_Type"></param>
		private void SetcontextMenu1Status(int p_Type)
		{
			menuItemInsertTop.Enabled=false;
			menuItemDelete.Enabled=false;
			menuItemUpdate.Enabled=false;
			menuItemInsertSub.Enabled=false;
			switch(p_Type)
			{
				case 1:
					menuItemInsertTop.Enabled=true;
					break;
				case 2://顶层类型
					menuItemInsertTop.Enabled=true;
					menuItemDelete.Enabled=true;
					menuItemUpdate.Enabled=true;
					menuItemInsertSub.Enabled=true;
					break;
				case 3://子类型
					//menuItemInsertTop.Enabled=true;
					menuItemDelete.Enabled=true;
					menuItemUpdate.Enabled=true;
					menuItemInsertSub.Enabled=true;
					break;
			}
		}

		/// <summary>
		/// 显示右键菜单
		/// </summary>
		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			try
			{
				if(treeList1.FocusedNode!=null)
				{
					menuItemNodeInfo.Text=SysConvert.ToString(treeList1.FocusedNode.GetValue("Name"));
					int parentid=SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ParentID"));
					if(parentid==0)//顶层类型
					{
						SetcontextMenu1Status(2);
					}
					else//子类型
					{
						SetcontextMenu1Status(3);
					}
					
				}
				else//没有任何类型，只能新增顶类型
				{
					menuItemNodeInfo.Text="";
					SetcontextMenu1Status(1);
				}
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}



		/// <summary>
		/// 更新类型
		/// </summary>
		private void menuItemUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
                saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                frmSetStructure frm = new frmSetStructure();
                frm.StructureTypeID = 3;
                frm.StructureID = saveID;
                frm.ShowDialog();
                curNodeStatus = NodeStatus.查询;
                NodeStatusSetUI();
                BindTreeList();


                ProcessTreeList.TreeListFocus(treeList1, new string[] { "ID" }, new string[] { saveID.ToString() });
				
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 新增子类型
		/// </summary>
		private void menuItemInsertSub_Click(object sender, System.EventArgs e)
		{
			try
			{
                saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                frmSetStructure frm = new frmSetStructure();
                frm.StructureTypeID = 2;
                frm.ParentID = saveID;
                frm.ShowDialog();
                curNodeStatus = NodeStatus.查询;
                NodeStatusSetUI();
                BindTreeList();
                ProcessTreeList.TreeListFocus(treeList1, new string[] { "ID" }, new string[] { frm.StructureID.ToString() });
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 新增顶类型
		/// </summary>
		private void menuItemInsertTop_Click(object sender, System.EventArgs e)
		{
			try
			{
                //curNodeStatus=NodeStatus.新增顶类型;
                //NodeStatusSetUI();
                frmSetStructure frm = new frmSetStructure();
                frm.StructureTypeID = 1;
                frm.ShowDialog();
                curNodeStatus = NodeStatus.查询;
                NodeStatusSetUI();
                BindTreeList();
                BindTreeList();
                ProcessTreeList.TreeListFocus(treeList1, new string[] { "ID" }, new string[] { frm.StructureID.ToString() });

			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 删除类型
		/// </summary>
		private void menuItemDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				txtID.Text=SysConvert.ToString(treeList1.FocusedNode.GetValue("ID"));
			
				if(DialogResult.Yes!=ShowConfirmMessage("删除为不可恢复操作，确认删除本条记录？"))
				{
					return;
				}
				StructureRule rule=new StructureRule();
				Structure entity=this.GetEntity();
				rule.RDelete(entity);
				BindTreeList();

				curNodeStatus=NodeStatus.查询;
				NodeStatusSetUI();

			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}
		#endregion

		
		#region treelist事件
		private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
		{
			try
			{					
				curNodeStatus=NodeStatus.查询;
				NodeStatusSetUI();

				if(treeList1.FocusedNode!=null)
				{
				
					saveID=SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
					DataTable dt=SysUtils.Fill("EXEC USP1_Data_Structure "+SysString.ToDBString(saveID));
					if(dt.Rows.Count!=0)
					{
						saveSubID=dt.Rows[0][0].ToString();
					}
					BindGrid1();
					BindGrid2();
					BindGrid3();
				}
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}


        /// <summary>
        /// 拖曳改变执行
        /// 
        /// 使用此方法是不得已的行为，因为DragDrop无法读取到拖曳后的父节点；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            try
            {
                //if (saveTreeDragFlag)//有拖曳动作才执行
                //{
                
                    DevExpress.XtraTreeList.TreeList treelist = (DevExpress.XtraTreeList.TreeList)sender;
                    TreeListNode node = treelist.FocusedNode;
                    if (node != null)
                    {
                        int curID = SysConvert.ToInt32(node.GetValue("ID"));
                        int parentID = 0;
                        if (node.ParentNode != null)
                        {
                            parentID = SysConvert.ToInt32(node.ParentNode.GetValue("ID"));
                        }


                        int factPID = -1;
                        for (int i = 0; i < treelist.Nodes.Count; i++)
                        {
                            factPID = FindNodeParentID(treelist.Nodes[i], node);//拖曳后的父结点
                            if (factPID != 0)
                            {
                                break;
                            }
                        }

                        if (factPID != -1)
                        {
                            StructureRule rule = new StructureRule();
                            rule.RUpdateParentID(curID, factPID);

                        }

                        lblInfo.Text = "C " + curID.ToString() + "   P " + parentID.ToString();
                        lblInfo.Text += "   F  " + factPID;
                    }
                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
            finally
            {
            }
        }

        ///// <summary>
        ///// 脱衣动作标识
        ///// </summary>
        //bool saveTreeDragFlag = false;
        /// <summary>
        /// 结构拖曳放下时
        /// (此事件没有什么作用，主要功能暂不使用，仅仅使用关键标识有拖曳动作标识)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                //saveTreeDragFlag = true;
                //DevExpress.XtraTreeList.TreeList treelist = (DevExpress.XtraTreeList.TreeList)sender;
                //TreeListNode node = treelist.FocusedNode;
                //int curID = SysConvert.ToInt32(node.GetValue("ID"));
                //int parentID = 0;
                //if (node.ParentNode != null)
                //{
                //    parentID = SysConvert.ToInt32(node.ParentNode.GetValue("ID"));
                //}
                ////StructureRule rule = new StructureRule();
                ////rule.RUpdateParentID(curID, parentID);
                ////this.ShowInfoMessage("Drop");


                //int factPID = -1;
                //for (int i = 0; i < treelist.Nodes.Count; i++)
                //{
                //    factPID = FindNodeParentID(treelist.Nodes[i], node);//拖曳后的父结点
                //    if (factPID != 0)
                //    {
                //        break;
                //    }
                //}

                //lblInfo.Text = "Drop C " + curID.ToString() + "   P " + parentID.ToString();
                //lblInfo.Text += "   F  " + factPID;
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        int FindNodeParentID(TreeListNode parentNode, TreeListNode curNode)
        {
            int outFactParentID = -1;
            for (int i = 0; i < parentNode.Nodes.Count; i++)
            {
                if (outFactParentID == -1)//没有才一直寻找到最后
                {
                    if (parentNode.Nodes[i] == curNode)
                    {
                        outFactParentID = SysConvert.ToInt32(parentNode.GetValue("ID"));
                        break;
                    }
                    else
                    {
                        outFactParentID = FindNodeParentID(parentNode.Nodes[i], curNode);
                    }
                }
            }
            return outFactParentID;
        }
        #endregion

        #region 部门员工按钮事件
        /// <summary>
        /// 查询
        /// </summary>
        private void btn2Query_Click(object sender, System.EventArgs e)
		{
			try
			{
				BindGrid3();
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 新增
		/// </summary>
		private void btn2Insert_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!FCommon.RightCheck(this.FormID,this.FormListAID,this.FormListBID,RightSub.新增))
				{
					this.ShowMessage("你没有管理权限");
					return;
				}
                saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
				string[] tempa= this.GetSelectArray(gridView3);
                //if(tempa.Length==0)
                //{
                //    this.ShowMessage("请选择工号");
                //    return;
                //}

				StructureRule rule=new StructureRule();
				rule.RAddStruectureOP(tempa,saveID);

				BindGrid1();
				BindGrid2();
				BindGrid3();

                ProcessTreeList.TreeListFocus(treeList1, new string[] { "ID" }, new string[] { saveID.ToString() });
				FCommon.AddDBLog(this.Text,"新增","ID:"+saveID,"");
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 删除
		/// </summary>
		private void btn2Delete_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!FCommon.RightCheck(this.FormID,this.FormListAID,this.FormListBID,RightSub.新增))
				{
					this.ShowMessage("你没有管理权限");
					return;
				}
				string[] tempa= this.GetSelectArray(gridView2);
				if(tempa.Length==0)
				{
					this.ShowMessage("请选择工号");
					return;
				}
				
				StructureRule rule=new StructureRule();
				rule.RDeleteStruectureOP(tempa,saveSubID);
				BindGrid1();
				BindGrid2();
				BindGrid3();
				FCommon.AddDBLog(this.Text,"删除","子ID:"+saveSubID,"");
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}		
		}
		#endregion

        #region 设置

        private void 设置主管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                string OPID = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle,"OPID"));
                string sql = "UPDATE Data_StructureMember SET LeaderFlag=1  WHERE StuctureID="+SysString.ToDBString(saveID);
                sql += " AND OPID="+SysString.ToDBString(OPID);
                SysUtils.ExecuteNonQuery(sql);
                BindGrid2();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void 取消主管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                string OPID = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OPID"));
                string sql = "UPDATE Data_StructureMember SET LeaderFlag=0  WHERE StuctureID=" + SysString.ToDBString(saveID);
                sql += " AND OPID=" + SysString.ToDBString(OPID);
                SysUtils.ExecuteNonQuery(sql);
                BindGrid2();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void 设置副主管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                string OPID = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OPID"));
                string sql = "UPDATE Data_StructureMember SET LeaderAttnFlag=1  WHERE StuctureID=" + SysString.ToDBString(saveID);
                sql += " AND OPID=" + SysString.ToDBString(OPID);
                SysUtils.ExecuteNonQuery(sql);
                BindGrid2();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void 取消副主管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                saveID = SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                string OPID = SysConvert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OPID"));
                string sql = "UPDATE Data_StructureMember SET LeaderAttnFlag=0  WHERE StuctureID=" + SysString.ToDBString(saveID);
                sql += " AND OPID=" + SysString.ToDBString(OPID);
                SysUtils.ExecuteNonQuery(sql);
                BindGrid2();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


    }
}
