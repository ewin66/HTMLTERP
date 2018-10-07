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
namespace MLTERP
{
	/// <summary>
	/// 功能：客户资料查询
	/// 作者：陈加海
	/// 日期：2007.1.6
	/// </summary>
	public class frmVendorQuery2 : BaseForm
	{
		private DevExpress.XtraEditors.GroupControl groupControlDataList;
		private DevExpress.XtraGrid.GridControl gridControlDetail;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnVendorID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnVendorAttn;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnVendorName;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnVendorTypeID;
		private DevExpress.XtraEditors.GroupControl groupControlQuery;
		private DevExpress.XtraEditors.TextEdit txtQVendorNM;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton btnQuery;
		private DevExpress.XtraEditors.SimpleButton btnLoad;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmVendorQuery2()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendorQuery));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnVendorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVendorAttn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVendorTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.drpGridYesOrNo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.txtQVendorNM = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridYesOrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQVendorNM.Properties)).BeginInit();
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
            this.groupControlDataList.Location = new System.Drawing.Point(0, 43);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(520, 403);
            this.groupControlDataList.TabIndex = 15;
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
            this.drpGridYesOrNo});
            this.gridControlDetail.Size = new System.Drawing.Size(516, 383);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlDetail.DoubleClick += new System.EventHandler(this.btnLoad_Click);
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnVendorID,
            this.gridColumnVendorAttn,
            this.gridColumnVendorName,
            this.gridColumnVendorTypeID});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.btnLoad_Click);
            // 
            // gridColumnVendorID
            // 
            this.gridColumnVendorID.Caption = "客户编号";
            this.gridColumnVendorID.FieldName = "VendorID";
            this.gridColumnVendorID.Name = "gridColumnVendorID";
            this.gridColumnVendorID.Visible = true;
            this.gridColumnVendorID.VisibleIndex = 0;
            this.gridColumnVendorID.Width = 84;
            // 
            // gridColumnVendorAttn
            // 
            this.gridColumnVendorAttn.Caption = "客户简称";
            this.gridColumnVendorAttn.FieldName = "VendorAttn";
            this.gridColumnVendorAttn.Name = "gridColumnVendorAttn";
            this.gridColumnVendorAttn.Visible = true;
            this.gridColumnVendorAttn.VisibleIndex = 1;
            this.gridColumnVendorAttn.Width = 123;
            // 
            // gridColumnVendorName
            // 
            this.gridColumnVendorName.Caption = "客户名称";
            this.gridColumnVendorName.FieldName = "VendorName";
            this.gridColumnVendorName.Name = "gridColumnVendorName";
            this.gridColumnVendorName.Visible = true;
            this.gridColumnVendorName.VisibleIndex = 2;
            this.gridColumnVendorName.Width = 279;
            // 
            // gridColumnVendorTypeID
            // 
            this.gridColumnVendorTypeID.Caption = "客户类型";
            this.gridColumnVendorTypeID.FieldName = "VendorTypeID";
            this.gridColumnVendorTypeID.Name = "gridColumnVendorTypeID";
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
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.txtQVendorNM);
            this.groupControlQuery.Controls.Add(this.label1);
            this.groupControlQuery.Controls.Add(this.btnLoad);
            this.groupControlQuery.Controls.Add(this.btnQuery);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 0);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(520, 43);
            this.groupControlQuery.TabIndex = 14;
            this.groupControlQuery.Text = "查询";
            // 
            // txtQVendorNM
            // 
            this.txtQVendorNM.EditValue = "";
            this.txtQVendorNM.Location = new System.Drawing.Point(45, 16);
            this.txtQVendorNM.Name = "txtQVendorNM";
            this.txtQVendorNM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQVendorNM.Size = new System.Drawing.Size(240, 23);
            this.txtQVendorNM.TabIndex = 3;
            this.txtQVendorNM.EditValueChanged += new System.EventHandler(this.txtQVendorNM_EditValueChanged);
            this.txtQVendorNM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQVendorNM_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "客户";
            // 
            // btnLoad
            // 
            this.btnLoad.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnLoad.Location = new System.Drawing.Point(424, 16);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnQuery.Location = new System.Drawing.Point(320, 16);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // frmVendorQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(520, 446);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MDISubShowFlag = true;
            this.Name = "frmVendorQuery2";
            this.Text = "客户查询";
            this.Load += new System.EventHandler(this.frmVendorQuery_Load);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpGridYesOrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQVendorNM.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public string p_VendorID=string.Empty;
		public bool p_SelectFlag=false;
		public int[] p_VendorType= new int[0];
        public string p_Condition = string.Empty;

		#region 自定义事件
		string conditionstr=string.Empty;
		/// <summary>
		/// 获得查询条件
		/// </summary>
        private void GetCondition()
        {
            string outstr = string.Empty;
            outstr += " AND UseableFlag=1";
            if (txtQVendorNM.Text.Trim() != "")//查询
            {
                outstr += " AND (VendorName LIKE " + SysString.ToDBString("%" + txtQVendorNM.Text.Trim() + "%");
                outstr += " OR VendorID LIKE " + SysString.ToDBString("%" + txtQVendorNM.Text.Trim() + "%");
                outstr += " OR VendorAttn LIKE " + SysString.ToDBString("%" + txtQVendorNM.Text.Trim() + "%");
                outstr += ")";
            }
            if (p_VendorType.Length > 0)
            {
                outstr += " AND VendorID in(select VendorID from Data_VendorTypeDts where 1=1 ";
                outstr += " AND VendorTypeID IN(99";
                for (int i = 0; i < p_VendorType.Length; i++)
                {
                    outstr += "," + p_VendorType[i].ToString();
                }
                outstr += ")";
                outstr += ")";
            }
            if (p_Condition != "")
            {
                outstr += p_Condition;
            }
            outstr += " ORDER BY VendorID";
            conditionstr = outstr;
        }

		/// <summary>
		/// 绑定Grid数据
		/// </summary>
		private void BindGrid()
		{
			VendorRule rule = new VendorRule();
			gridView1.GridControl.DataSource=rule.RShow(conditionstr,ProcessGrid.GetQueryField(gridView1));
			gridView1.GridControl.Show();
		}
		#endregion

		/// <summary>
		/// 窗体加载
		/// </summary>
		private void frmVendorQuery_Load(object sender, System.EventArgs e)
		{
			try
			{
				ProcessGrid.BindGridColumn(gridView1,this.FormID);//绑定列				
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI
                ProcessGrid.SetGridReadOnly(gridView1, true);

                GetCondition();
				BindGrid();
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 客户名称改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtQVendorNM_EditValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.GetCondition();
				BindGrid();
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.GetCondition();
				BindGrid();
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

		/// <summary>
		/// 加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (gridView1.FocusedRowHandle >= 0)
                {

                    this.p_SelectFlag = true;
                    p_VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorID"));
                    this.Close();
                }
                else
                {
                    this.ShowMessage("没有检索到客户");
                }
			}
			catch(Exception E)
			{
				this.ShowMessage(E.Message);
			}
		}

        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQVendorNM_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//回车键
                {
                    btnLoad_Click(null, null);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
	}
}
