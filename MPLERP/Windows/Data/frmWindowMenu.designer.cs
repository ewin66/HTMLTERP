namespace MLTERP
{
    partial class frmWindowMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWindowMenu));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();            
            this.gridColumnWinListID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnParentID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnSort = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnHttFlag = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnShowFlag = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnSystemTypeID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnShortCutChar = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnHeadTypeID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnSubTypeID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnSubmitFlag = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnModuleFlowID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnMenuTypeID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			this.gridColumnUseTypeID = new DevExpress.XtraGrid.Columns.GridColumn(); 
  			
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.SuspendLayout();
           
            // 
            // groupControlDataList
            // 
            this.groupControlDataList.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlDataList.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlDataList.Controls.Add(this.gridControlDetail);
            this.groupControlDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDataList.Location = new System.Drawing.Point(0, 73);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(741, 365);
            this.groupControlDataList.TabIndex = 33;
            this.groupControlDataList.Text = "数据列表";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.EmbeddedNavigator.Name = "";
            this.gridControlDetail.Location = new System.Drawing.Point(3, 18);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(735, 344);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,this.gridColumnWinListID,this.gridColumnName,this.gridColumnParentID,this.gridColumnSort,this.gridColumnHttFlag,this.gridColumnShowFlag,this.gridColumnSystemTypeID,this.gridColumnShortCutChar,this.gridColumnHeadTypeID,this.gridColumnSubTypeID,this.gridColumnSubmitFlag,this.gridColumnModuleFlowID,this.gridColumnMenuTypeID,this.gridColumnUseTypeID});
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
  			//gridColumnWinListID 
  			// 
  			this.gridColumnWinListID.Caption=""; 
  			this.gridColumnWinListID.FieldName="WinListID"; 
  			this.gridColumnWinListID.Name="gridColumnWinListID"; 
  			this.gridColumnWinListID.Visible=true; 
  			this.gridColumnWinListID.VisibleIndex=1; 
  			// 
  			//gridColumnName 
  			// 
  			this.gridColumnName.Caption=""; 
  			this.gridColumnName.FieldName="Name"; 
  			this.gridColumnName.Name="gridColumnName"; 
  			this.gridColumnName.Visible=true; 
  			this.gridColumnName.VisibleIndex=2; 
  			// 
  			//gridColumnParentID 
  			// 
  			this.gridColumnParentID.Caption=""; 
  			this.gridColumnParentID.FieldName="ParentID"; 
  			this.gridColumnParentID.Name="gridColumnParentID"; 
  			this.gridColumnParentID.Visible=true; 
  			this.gridColumnParentID.VisibleIndex=3; 
  			// 
  			//gridColumnSort 
  			// 
  			this.gridColumnSort.Caption=""; 
  			this.gridColumnSort.FieldName="Sort"; 
  			this.gridColumnSort.Name="gridColumnSort"; 
  			this.gridColumnSort.Visible=true; 
  			this.gridColumnSort.VisibleIndex=4; 
  			// 
  			//gridColumnHttFlag 
  			// 
  			this.gridColumnHttFlag.Caption=""; 
  			this.gridColumnHttFlag.FieldName="HttFlag"; 
  			this.gridColumnHttFlag.Name="gridColumnHttFlag"; 
  			this.gridColumnHttFlag.Visible=true; 
  			this.gridColumnHttFlag.VisibleIndex=5; 
  			// 
  			//gridColumnShowFlag 
  			// 
  			this.gridColumnShowFlag.Caption=""; 
  			this.gridColumnShowFlag.FieldName="ShowFlag"; 
  			this.gridColumnShowFlag.Name="gridColumnShowFlag"; 
  			this.gridColumnShowFlag.Visible=true; 
  			this.gridColumnShowFlag.VisibleIndex=6; 
  			// 
  			//gridColumnSystemTypeID 
  			// 
  			this.gridColumnSystemTypeID.Caption=""; 
  			this.gridColumnSystemTypeID.FieldName="SystemTypeID"; 
  			this.gridColumnSystemTypeID.Name="gridColumnSystemTypeID"; 
  			this.gridColumnSystemTypeID.Visible=true; 
  			this.gridColumnSystemTypeID.VisibleIndex=7; 
  			// 
  			//gridColumnShortCutChar 
  			// 
  			this.gridColumnShortCutChar.Caption=""; 
  			this.gridColumnShortCutChar.FieldName="ShortCutChar"; 
  			this.gridColumnShortCutChar.Name="gridColumnShortCutChar"; 
  			this.gridColumnShortCutChar.Visible=true; 
  			this.gridColumnShortCutChar.VisibleIndex=8; 
  			// 
  			//gridColumnHeadTypeID 
  			// 
  			this.gridColumnHeadTypeID.Caption=""; 
  			this.gridColumnHeadTypeID.FieldName="HeadTypeID"; 
  			this.gridColumnHeadTypeID.Name="gridColumnHeadTypeID"; 
  			this.gridColumnHeadTypeID.Visible=true; 
  			this.gridColumnHeadTypeID.VisibleIndex=9; 
  			// 
  			//gridColumnSubTypeID 
  			// 
  			this.gridColumnSubTypeID.Caption=""; 
  			this.gridColumnSubTypeID.FieldName="SubTypeID"; 
  			this.gridColumnSubTypeID.Name="gridColumnSubTypeID"; 
  			this.gridColumnSubTypeID.Visible=true; 
  			this.gridColumnSubTypeID.VisibleIndex=10; 
  			// 
  			//gridColumnSubmitFlag 
  			// 
  			this.gridColumnSubmitFlag.Caption=""; 
  			this.gridColumnSubmitFlag.FieldName="SubmitFlag"; 
  			this.gridColumnSubmitFlag.Name="gridColumnSubmitFlag"; 
  			this.gridColumnSubmitFlag.Visible=true; 
  			this.gridColumnSubmitFlag.VisibleIndex=11; 
  			// 
  			//gridColumnModuleFlowID 
  			// 
  			this.gridColumnModuleFlowID.Caption=""; 
  			this.gridColumnModuleFlowID.FieldName="ModuleFlowID"; 
  			this.gridColumnModuleFlowID.Name="gridColumnModuleFlowID"; 
  			this.gridColumnModuleFlowID.Visible=true; 
  			this.gridColumnModuleFlowID.VisibleIndex=12; 
  			// 
  			//gridColumnMenuTypeID 
  			// 
  			this.gridColumnMenuTypeID.Caption=""; 
  			this.gridColumnMenuTypeID.FieldName="MenuTypeID"; 
  			this.gridColumnMenuTypeID.Name="gridColumnMenuTypeID"; 
  			this.gridColumnMenuTypeID.Visible=true; 
  			this.gridColumnMenuTypeID.VisibleIndex=13; 
  			// 
  			//gridColumnUseTypeID 
  			// 
  			this.gridColumnUseTypeID.Caption=""; 
  			this.gridColumnUseTypeID.FieldName="UseTypeID"; 
  			this.gridColumnUseTypeID.Name="gridColumnUseTypeID"; 
  			this.gridColumnUseTypeID.Visible=true; 
  			this.gridColumnUseTypeID.VisibleIndex=14; 
  			
           
            
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(741, 48);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "查询条件";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmWindowMenu";
            this.Text = "frmWindowMenu";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnWinListID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnParentID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSort; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnHttFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnShowFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSystemTypeID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnShortCutChar; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnHeadTypeID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubTypeID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubmitFlag; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnModuleFlowID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnMenuTypeID; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnUseTypeID; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
    }
}