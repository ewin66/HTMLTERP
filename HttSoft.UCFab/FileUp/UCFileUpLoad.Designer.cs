namespace HttSoft.UCFab
{
    partial class UCFileUpLoad
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFileUpLoad));
            this.groupControlBLeft = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.btnOpenFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteFlie = new DevExpress.XtraEditors.SimpleButton();
            this.btnFileUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnFileAdd = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.groupControlBottom = new DevExpress.XtraEditors.GroupControl();
            this.groupControlBRight = new DevExpress.XtraEditors.GroupControl();
            this.ucPictureView1 = new HttSoft.UCFab.UCPictureView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBLeft)).BeginInit();
            this.groupControlBLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBottom)).BeginInit();
            this.groupControlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBRight)).BeginInit();
            this.groupControlBRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlBLeft
            // 
            this.groupControlBLeft.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlBLeft.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlBLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlBLeft.Controls.Add(this.gridControl1);
            this.groupControlBLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlBLeft.Location = new System.Drawing.Point(0, 0);
            this.groupControlBLeft.Name = "groupControlBLeft";
            this.groupControlBLeft.Size = new System.Drawing.Size(733, 182);
            this.groupControlBLeft.TabIndex = 276;
            this.groupControlBLeft.Text = "数据列表";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(733, 182);
            this.gridControl1.TabIndex = 34;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChanged);
            this.gridView1.ColumnFilterChanged += new System.EventHandler(this.gridView1_ColumnFilterChanged);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "上传时间";
            this.gridColumn8.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "UploadTime";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 148;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "类型";
            this.gridColumn9.FieldName = "FileExe";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 83;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "文件名";
            this.gridColumn10.FieldName = "FileName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 194;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "ID";
            this.gridColumn11.FieldName = "ID";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "上传人";
            this.gridColumn7.FieldName = "UploadOPName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 104;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "文件大小(K)";
            this.gridColumn12.FieldName = "FileSize";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 99;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "备注";
            this.gridColumn13.FieldName = "Remark";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "文件说明";
            this.gridColumn1.FieldName = "FileTitle";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 171;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "上传人工号";
            this.gridColumn2.FieldName = "UploadOPID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // groupControl4
            // 
            this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl4.Controls.Add(this.btnOpenFile);
            this.groupControl4.Controls.Add(this.btnLoadFile);
            this.groupControl4.Controls.Add(this.btnDeleteFlie);
            this.groupControl4.Controls.Add(this.btnFileUpdate);
            this.groupControl4.Controls.Add(this.btnFileAdd);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(733, 36);
            this.groupControl4.TabIndex = 275;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnOpenFile.Location = new System.Drawing.Point(171, 7);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(43, 23);
            this.btnOpenFile.TabIndex = 274;
            this.btnOpenFile.Tag = "";
            this.btnOpenFile.Text = "打开";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnLoadFile.Location = new System.Drawing.Point(105, 7);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(43, 23);
            this.btnLoadFile.TabIndex = 273;
            this.btnLoadFile.Tag = "";
            this.btnLoadFile.Text = "下载";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnDeleteFlie
            // 
            this.btnDeleteFlie.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDeleteFlie.Location = new System.Drawing.Point(580, 7);
            this.btnDeleteFlie.Name = "btnDeleteFlie";
            this.btnDeleteFlie.Size = new System.Drawing.Size(43, 23);
            this.btnDeleteFlie.TabIndex = 271;
            this.btnDeleteFlie.Tag = "";
            this.btnDeleteFlie.Text = "删除";
            this.btnDeleteFlie.Click += new System.EventHandler(this.btnDeleteFlie_Click);
            // 
            // btnFileUpdate
            // 
            this.btnFileUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnFileUpdate.Location = new System.Drawing.Point(671, 7);
            this.btnFileUpdate.Name = "btnFileUpdate";
            this.btnFileUpdate.Size = new System.Drawing.Size(43, 23);
            this.btnFileUpdate.TabIndex = 270;
            this.btnFileUpdate.Tag = "";
            this.btnFileUpdate.Text = "修改";
            this.btnFileUpdate.Visible = false;
            this.btnFileUpdate.Click += new System.EventHandler(this.btnFileUpdate_Click);
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnFileAdd.Location = new System.Drawing.Point(11, 7);
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.Size = new System.Drawing.Size(43, 23);
            this.btnFileAdd.TabIndex = 269;
            this.btnFileAdd.Tag = "";
            this.btnFileAdd.Text = "添加";
            this.btnFileAdd.Click += new System.EventHandler(this.btnFileAdd_Click);
            // 
            // groupControlBottom
            // 
            this.groupControlBottom.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlBottom.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlBottom.Controls.Add(this.groupControlBLeft);
            this.groupControlBottom.Controls.Add(this.groupControlBRight);
            this.groupControlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlBottom.Location = new System.Drawing.Point(0, 36);
            this.groupControlBottom.Name = "groupControlBottom";
            this.groupControlBottom.Size = new System.Drawing.Size(733, 401);
            this.groupControlBottom.TabIndex = 277;
            // 
            // groupControlBRight
            // 
            this.groupControlBRight.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlBRight.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlBRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlBRight.Controls.Add(this.ucPictureView1);
            this.groupControlBRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControlBRight.Location = new System.Drawing.Point(0, 182);
            this.groupControlBRight.Name = "groupControlBRight";
            this.groupControlBRight.Size = new System.Drawing.Size(733, 219);
            this.groupControlBRight.TabIndex = 278;
            this.groupControlBRight.Visible = false;
            // 
            // ucPictureView1
            // 
            this.ucPictureView1.BackColor = System.Drawing.Color.White;
            this.ucPictureView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPictureView1.Location = new System.Drawing.Point(0, 0);
            this.ucPictureView1.Name = "ucPictureView1";
            this.ucPictureView1.Size = new System.Drawing.Size(733, 219);
            this.ucPictureView1.TabIndex = 0;
            this.ucPictureView1.UCDataID = 0;
            this.ucPictureView1.UCDataLstImage = ((System.Collections.Generic.List<System.Drawing.Image>)(resources.GetObject("ucPictureView1.UCDataLstImage")));
            this.ucPictureView1.UCDataLstSmallImage = ((System.Collections.Generic.List<System.Drawing.Image>)(resources.GetObject("ucPictureView1.UCDataLstSmallImage")));
            this.ucPictureView1.UCDataStyleNo = "";
            this.ucPictureView1.UCDBConnIndex = 1;
            this.ucPictureView1.UCDBMainIDFieldName = "";
            this.ucPictureView1.UCDBPicFieldName = "";
            this.ucPictureView1.UCDBRemarkFieldName = "";
            this.ucPictureView1.UCDBSmallPicFieldName = "";
            this.ucPictureView1.UCDBStyleNoFieldName = "";
            this.ucPictureView1.UCDBTableName = "";
            this.ucPictureView1.UCInputDBSaveType = 1;
            this.ucPictureView1.UCInputMainType = 1;
            this.ucPictureView1.UCInputPictureMultiFlag = true;
            this.ucPictureView1.UCReadOnly = false;
            this.ucPictureView1.UCUIBackColor = System.Drawing.Color.Empty;
            this.ucPictureView1.UCUIPicHeight = 50;
            this.ucPictureView1.UCUIPicWidth = 500;
            this.ucPictureView1.UCUISmallPicHeight = 50;
            this.ucPictureView1.UCUISmallPicWidth = 50;
            // 
            // UCFileUpLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlBottom);
            this.Controls.Add(this.groupControl4);
            this.Name = "UCFileUpLoad";
            this.Size = new System.Drawing.Size(733, 437);
            this.Load += new System.EventHandler(this.UCFileUpLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBLeft)).EndInit();
            this.groupControlBLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBottom)).EndInit();
            this.groupControlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBRight)).EndInit();
            this.groupControlBRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlBLeft;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.SimpleButton btnOpenFile;
        private DevExpress.XtraEditors.SimpleButton btnLoadFile;
        private DevExpress.XtraEditors.SimpleButton btnDeleteFlie;
        private DevExpress.XtraEditors.SimpleButton btnFileUpdate;
        private DevExpress.XtraEditors.SimpleButton btnFileAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private DevExpress.XtraEditors.GroupControl groupControlBottom;
        private DevExpress.XtraEditors.GroupControl groupControlBRight;
        private UCPictureView ucPictureView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
