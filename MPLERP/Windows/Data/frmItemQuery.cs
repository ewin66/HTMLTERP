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

namespace MLTERP
{
	/// <summary>
	/// frmItemQuery 的摘要说明。
	/// </summary>
	public class frmItemQuery : BaseForm
	{
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnName;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnCode;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnID;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnParentID;
		private DevExpress.XtraEditors.GroupControl groupControlDataList;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraTreeList.TreeList treeList1;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemUnit;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemName;
		private DevExpress.XtraEditors.TextEdit txtQItemStd;
		private System.Windows.Forms.Label label9;
		private DevExpress.XtraEditors.TextEdit txtQItemName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtQItemCode;
		private DevExpress.XtraEditors.SimpleButton btnToExcel;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemAttnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.TextEdit txtQItemModel;
        private Label label15;
        private DevExpress.XtraEditors.TextEdit txtQItemAttnCode;
        private Label label4;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmItemQuery()
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

		
		#region 全局变量
		int SaveItemClassID=0;
		int SaveItemTypeID=0;

        private int m_ItemTypeThis = (int)HttSoft.MLTERP.Sys.EnumItemType.面料;//物品类型
		string conditionstr=string.Empty;
		#endregion

		#region 自定义方法
		/// <summary>
		/// 获得查询条件
		/// </summary>
		private void GetCondition()
		{
			string sql=string.Empty;
			if(txtQItemCode.Text.Trim()!=string.Empty)
			{				
				sql+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtQItemCode.Text.Trim()+"%");					
			}
			if(txtQItemName.Text.Trim()!=string.Empty)
			{
				string[] itemname=txtQItemName.Text.Trim().Split(' ');
				for(int i=0;i<itemname.Length;i++)
				{
					if(itemname[i]!=string.Empty)
					{
						sql+=" AND ItemName LIKE "+SysString.ToDBString("%"+itemname[i]+"%");
					}
				}
			}
			if(txtQItemStd.Text.Trim()!=string.Empty)
			{
				string[] itemstd=txtQItemStd.Text.Trim().Split(' ');
				for(int i=0;i<itemstd.Length;i++)
				{
					if(itemstd[i]!=string.Empty)
					{
						sql+=" AND ItemStd LIKE "+SysString.ToDBString("%"+itemstd[i]+"%");
					}
				}
			}

            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                sql += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQItemAttnCode.Text.Trim() != string.Empty)
            {
                sql += " AND ItemAttnCode LIKE " + SysString.ToDBString("%" + txtQItemAttnCode.Text.Trim() + "%");
            }

			conditionstr=sql;
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindGrid()
		{
			string cstr=" AND ItemTypeID="+SysString.ToDBString(SaveItemTypeID);
			if(SaveItemClassID!=0)
			{
				cstr+=" AND ItemClassID="+SysString.ToDBString(SaveItemClassID);
			}
			cstr+=conditionstr;
			ItemRule rule=new ItemRule();
            //gridView1.GridControl.DataSource = rule.RShowView(cstr + " ORDER BY ItemCode", ProcessGrid.GetQueryField(gridView1));
            //gridView1.GridControl.Show();
		}
		/// <summary>
		/// 绑定Grid数据
		/// </summary>
		private void BindTreeList()
		{			
			treeList1.Nodes.Clear();
			DataTable dt=this.GetTreeListTable();
			ProcessTreeList.BindTreeList(dt,treeList1,"ID","ParentID",7,true);
		}
		/// <summary>
		/// 组装TreeList表
		/// </summary>
		/// <returns></returns>
		private DataTable GetTreeListTable()
		{   
			string sql="SELECT ID,Code,Name FROM Enum_ItemType WHERE 1=1";
			if(m_ItemTypeThis!=0)
			{
				sql+=" AND ID="+SysString.ToDBString(m_ItemTypeThis);
			}

			DataTable dtitemtype=SysUtils.Fill(sql);
			for(int i=0;i<dtitemtype.Rows.Count;i++)//将dtitemtype表的ID替换掉
			{
				dtitemtype.Rows[i]["ID"]="800000"+dtitemtype.Rows[i]["ID"].ToString();
			}

			sql="SELECT ID,Code,Name,ParentID,ItemTypeID FROM Data_ItemClass WHERE 1=1";
			if(m_ItemTypeThis!=0)
			{
				sql+=" AND ItemTypeID="+SysString.ToDBString(m_ItemTypeThis);
			}
			DataTable dtitemclass=SysUtils.Fill(sql);
			for(int i=0;i<dtitemclass.Rows.Count;i++)//将dtitemclass中ParentID为0的ID替换掉
			{
				if(dtitemclass.Rows[i]["ParentID"].ToString()=="0")
				{
					for(int j=0;j<dtitemtype.Rows.Count;j++)
					{
						if("800000"+dtitemclass.Rows[i]["ItemTypeID"].ToString()==dtitemtype.Rows[j]["ID"].ToString())
						{
							dtitemclass.Rows[i]["ParentID"]=dtitemtype.Rows[j]["ID"];
						}
					}
				}
			}			

			for(int i=0;i<dtitemtype.Rows.Count;i++)
			{
				DataRow dr=dtitemclass.NewRow();
				dr["ID"]=dtitemtype.Rows[i]["ID"].ToString();
				dr["Code"]=dtitemtype.Rows[i]["Code"].ToString();
				dr["Name"]=dtitemtype.Rows[i]["Name"].ToString();
				dr["ParentID"]="0";

				dtitemclass.Rows.Add(dr);
			}

			return dtitemclass;
		}
		#endregion
		
		

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemQuery));
            this.treeListColumnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemAttnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpGridYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtQItemModel = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQItemAttnCode = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.btnToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.txtQItemCode = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQItemStd = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQItemName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gridColumnItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemAttnCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemName.Properties)).BeginInit();
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
            // treeListColumnName
            // 
            this.treeListColumnName.Caption = "名称";
            this.treeListColumnName.FieldName = "Name";
            this.treeListColumnName.MinWidth = 151;
            this.treeListColumnName.Name = "treeListColumnName";
            this.treeListColumnName.OptionsColumn.AllowEdit = false;
            this.treeListColumnName.OptionsColumn.ReadOnly = true;
            this.treeListColumnName.VisibleIndex = 0;
            this.treeListColumnName.Width = 151;
            // 
            // treeListColumnCode
            // 
            this.treeListColumnCode.Caption = "编码";
            this.treeListColumnCode.FieldName = "Code";
            this.treeListColumnCode.Format.FormatString = "d";
            this.treeListColumnCode.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.treeListColumnCode.MinWidth = 45;
            this.treeListColumnCode.Name = "treeListColumnCode";
            this.treeListColumnCode.OptionsColumn.AllowEdit = false;
            this.treeListColumnCode.OptionsColumn.ReadOnly = true;
            this.treeListColumnCode.Width = 81;
            // 
            // treeListColumnID
            // 
            this.treeListColumnID.Caption = "ID";
            this.treeListColumnID.FieldName = "ID";
            this.treeListColumnID.MinWidth = 45;
            this.treeListColumnID.Name = "treeListColumnID";
            this.treeListColumnID.OptionsColumn.AllowEdit = false;
            this.treeListColumnID.OptionsColumn.ReadOnly = true;
            this.treeListColumnID.Width = 109;
            // 
            // treeListColumnParentID
            // 
            this.treeListColumnParentID.Caption = "父节点";
            this.treeListColumnParentID.FieldName = "ParentID";
            this.treeListColumnParentID.Name = "treeListColumnParentID";
            this.treeListColumnParentID.OptionsColumn.AllowEdit = false;
            this.treeListColumnParentID.OptionsColumn.ReadOnly = true;
            this.treeListColumnParentID.Width = 49;
            // 
            // groupControlDataList
            // 
            this.groupControlDataList.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlDataList.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlDataList.Controls.Add(this.gridControlDetail);
            this.groupControlDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDataList.Location = new System.Drawing.Point(197, 56);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(727, 478);
            this.groupControlDataList.TabIndex = 275;
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
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.drpGridYesOrNo});
            this.gridControlDetail.Size = new System.Drawing.Size(719, 455);
            this.gridControlDetail.TabIndex = 34;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumnItemTypeID,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumnItemAttnCode,
            this.gridColumnRemark,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "物品编码";
            this.gridColumn1.FieldName = "ItemCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumnItemTypeID
            // 
            this.gridColumnItemTypeID.Caption = "物品类型";
            this.gridColumnItemTypeID.FieldName = "ItemTypeID";
            this.gridColumnItemTypeID.Name = "gridColumnItemTypeID";
            this.gridColumnItemTypeID.Visible = true;
            this.gridColumnItemTypeID.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "物品名称";
            this.gridColumn2.FieldName = "ItemName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "物品规格";
            this.gridColumn3.FieldName = "ItemStd";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumnItemAttnCode
            // 
            this.gridColumnItemAttnCode.Caption = "辅助编码";
            this.gridColumnItemAttnCode.FieldName = "ItemAttnCode";
            this.gridColumnItemAttnCode.Name = "gridColumnItemAttnCode";
            this.gridColumnItemAttnCode.Visible = true;
            this.gridColumnItemAttnCode.VisibleIndex = 5;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "备注";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "单位";
            this.gridColumn4.FieldName = "ItemUnit";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "季节";
            this.gridColumn5.FieldName = "ItemrSeason";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 66;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "类别";
            this.gridColumn6.FieldName = "ItemClassName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "品名";
            this.gridColumn7.FieldName = "ItemModel";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
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
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.treeList1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 56);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(197, 478);
            this.groupControl1.TabIndex = 274;
            this.groupControl1.Text = "数据列表";
            // 
            // treeList1
            // 
            this.treeList1.AllowDrop = true;
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnID,
            this.treeListColumnCode,
            this.treeListColumnName,
            this.treeListColumnParentID});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(4, 19);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            null,
            null,
            null,
            0}, -1, 0, 0, 7);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.AutoChangeParent = false;
            this.treeList1.OptionsBehavior.AutoNodeHeight = false;
            this.treeList1.OptionsBehavior.CanCloneNodesOnDrop = true;
            this.treeList1.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeList1.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.treeList1.OptionsBehavior.SmartMouseHover = false;
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.Size = new System.Drawing.Size(189, 455);
            this.treeList1.TabIndex = 33;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.txtQItemModel);
            this.groupControl2.Controls.Add(this.label15);
            this.groupControl2.Controls.Add(this.txtQItemAttnCode);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.btnToExcel);
            this.groupControl2.Controls.Add(this.txtQItemCode);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.txtQItemStd);
            this.groupControl2.Controls.Add(this.label9);
            this.groupControl2.Controls.Add(this.txtQItemName);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(924, 56);
            this.groupControl2.TabIndex = 277;
            this.groupControl2.Text = "数据列表";
            // 
            // txtQItemModel
            // 
            this.txtQItemModel.EditValue = "";
            this.txtQItemModel.Location = new System.Drawing.Point(692, 21);
            this.txtQItemModel.Name = "txtQItemModel";
            this.txtQItemModel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQItemModel.Properties.MaxLength = 50;
            this.txtQItemModel.Size = new System.Drawing.Size(70, 23);
            this.txtQItemModel.TabIndex = 5;
            this.txtQItemModel.EditValueChanged += new System.EventHandler(this.drpQ_EditValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(658, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 301;
            this.label15.Text = "品名";
            // 
            // txtQItemAttnCode
            // 
            this.txtQItemAttnCode.Location = new System.Drawing.Point(573, 22);
            this.txtQItemAttnCode.Name = "txtQItemAttnCode";
            this.txtQItemAttnCode.Size = new System.Drawing.Size(70, 21);
            this.txtQItemAttnCode.TabIndex = 4;
            this.txtQItemAttnCode.EditValueChanged += new System.EventHandler(this.drpQ_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 298;
            this.label4.Text = "辅助编码";
            // 
            // btnToExcel
            // 
            this.btnToExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnToExcel.Location = new System.Drawing.Point(788, 21);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnToExcel.TabIndex = 293;
            this.btnToExcel.Text = "转Excel";
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // txtQItemCode
            // 
            this.txtQItemCode.EditValue = "";
            this.txtQItemCode.Location = new System.Drawing.Point(55, 21);
            this.txtQItemCode.Name = "txtQItemCode";
            this.txtQItemCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQItemCode.Size = new System.Drawing.Size(88, 23);
            this.txtQItemCode.TabIndex = 1;
            this.txtQItemCode.EditValueChanged += new System.EventHandler(this.drpQ_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 291;
            this.label2.Text = "编码";
            // 
            // txtQItemStd
            // 
            this.txtQItemStd.EditValue = "";
            this.txtQItemStd.Location = new System.Drawing.Point(423, 21);
            this.txtQItemStd.Name = "txtQItemStd";
            this.txtQItemStd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQItemStd.Size = new System.Drawing.Size(88, 23);
            this.txtQItemStd.TabIndex = 3;
            this.txtQItemStd.EditValueChanged += new System.EventHandler(this.drpQ_EditValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(391, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 289;
            this.label9.Text = "规格";
            // 
            // txtQItemName
            // 
            this.txtQItemName.EditValue = "";
            this.txtQItemName.Location = new System.Drawing.Point(191, 21);
            this.txtQItemName.Name = "txtQItemName";
            this.txtQItemName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQItemName.Size = new System.Drawing.Size(184, 23);
            this.txtQItemName.TabIndex = 2;
            this.txtQItemName.EditValueChanged += new System.EventHandler(this.drpQ_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 287;
            this.label1.Text = "名称";
            // 
            // gridColumnItemCode
            // 
            this.gridColumnItemCode.Caption = "纱线编码";
            this.gridColumnItemCode.FieldName = "ItemCode";
            this.gridColumnItemCode.Name = "gridColumnItemCode";
            this.gridColumnItemCode.OptionsColumn.AllowEdit = false;
            this.gridColumnItemCode.OptionsColumn.ReadOnly = true;
            this.gridColumnItemCode.Visible = true;
            this.gridColumnItemCode.VisibleIndex = 0;
            this.gridColumnItemCode.Width = 90;
            // 
            // gridColumnItemUnit
            // 
            this.gridColumnItemUnit.Caption = "单位";
            this.gridColumnItemUnit.FieldName = "ItemUnit";
            this.gridColumnItemUnit.Name = "gridColumnItemUnit";
            this.gridColumnItemUnit.OptionsColumn.AllowEdit = false;
            this.gridColumnItemUnit.OptionsColumn.ReadOnly = true;
            this.gridColumnItemUnit.Visible = true;
            this.gridColumnItemUnit.VisibleIndex = 3;
            this.gridColumnItemUnit.Width = 61;
            // 
            // gridColumnItemStd
            // 
            this.gridColumnItemStd.Caption = "纱线支数";
            this.gridColumnItemStd.FieldName = "ItemStd";
            this.gridColumnItemStd.Name = "gridColumnItemStd";
            this.gridColumnItemStd.OptionsColumn.AllowEdit = false;
            this.gridColumnItemStd.OptionsColumn.ReadOnly = true;
            this.gridColumnItemStd.Visible = true;
            this.gridColumnItemStd.VisibleIndex = 2;
            this.gridColumnItemStd.Width = 90;
            // 
            // gridColumnItemName
            // 
            this.gridColumnItemName.Caption = "纱线成份";
            this.gridColumnItemName.FieldName = "ItemName";
            this.gridColumnItemName.Name = "gridColumnItemName";
            this.gridColumnItemName.OptionsColumn.AllowEdit = false;
            this.gridColumnItemName.OptionsColumn.ReadOnly = true;
            this.gridColumnItemName.Visible = true;
            this.gridColumnItemName.VisibleIndex = 1;
            this.gridColumnItemName.Width = 263;
            // 
            // frmItemQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(924, 534);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "frmItemQuery";
            this.Text = "纱种查询";
            this.Load += new System.EventHandler(this.frmItemQuery_Load);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemAttnCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQItemName.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// 转EXCEL
		/// </summary>
		private void btnToExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.ToExcel(gridView1);
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		private void frmItemQuery_Load(object sender, System.EventArgs e)
		{
			try
			{
				ProcessTreeList.BindTreeColumn(treeList1,this.FormID);//绑定列				
				ProcessTreeList.SetTreeColumnUI(treeList1);//设置列UI

				ProcessGrid.BindGridColumn(gridView1,this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI
			
					
				BindTreeList();
				BindGrid();
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		private void drpQ_EditValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.GetCondition();
				this.BindGrid();	
				//GridViewFocus(gridView1,new string[3]{"ItemCode","ItemName","ItemStd"},new string[3]{txtQItemCode.Text,txtQItemName.Text,txtQItemStd.Text});
				((Control)sender).Focus();
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 处理GridView聚焦行
		/// </summary>
		/// <param name="gridview">GridView</param>
		/// <param name="p_Fielda">字段名数组</param>
		/// <param name="p_Valuea">值数组</param>
		public static void GridViewFocus(DevExpress.XtraGrid.Views.Grid.GridView gridview,string[] p_Fielda,string[] p_Valuea)
		{
			if(p_Fielda.Length!=p_Valuea.Length || p_Fielda.Length<=0)//不满足条件，不聚焦行
			{
				return;
			}

			bool find=false;
			for(int i=0;i<gridview.RowCount;i++)
			{
				find=true;
				for(int j=0;j<p_Fielda.Length;j++)
				{
					string tempstr=SysConvert.ToString(gridview.GetRowCellValue(i,p_Fielda[j]));
					if(tempstr.Length<p_Valuea[j].Length)//发现长度太长则跳出内循环
					{
						find=false;
						break;
					}
					else
					{
						if(tempstr.Substring(0,p_Valuea[j].Length)!=p_Valuea[j])//发现不同则跳出内循环
						{
							find=false;
							break;
						}
					}
				}
				if(find)//找到
				{
					gridview.FocusedRowHandle=1;
					break;
				}
			}
		}

		#region treeList事件
		/// <summary>
		/// 焦点改变
		/// </summary>
		private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
		{
			try
			{
				if(treeList1.FocusedNode!=null)
				{
					int tempParentID=0;
					int ID=SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
					int ParentID=SysConvert.ToInt32(treeList1.FocusedNode.GetValue("ParentID"));
					while(ParentID!=0)
					{
						DataTable dt=GetTreeListTable();
						for(int i=0;i<dt.Rows.Count;i++)
						{
							if(SysConvert.ToInt32(dt.Rows[i]["ID"])==ParentID)
							{
								ParentID=SysConvert.ToInt32(dt.Rows[i]["ParentID"]);
								tempParentID=SysConvert.ToInt32(dt.Rows[i]["ID"]);
								break;
							}
						}
					}
					if(ID.ToString().Length>6)
					{
						SaveItemTypeID=SysConvert.ToInt32(ID.ToString().Substring(6));
					}
					else
					{
						SaveItemClassID=SysConvert.ToInt32(ID);
					}
					if(tempParentID!=0)
					{
						SaveItemTypeID=SysConvert.ToInt32(tempParentID.ToString().Substring(6));
					}
					else
					{
						SaveItemClassID=SysConvert.ToInt32(tempParentID);
					}

					BindGrid();
				}
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}
		#endregion

	
	}
}
