namespace HttSoft.UCFab
{
    partial class UCFabVHori
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
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panGroup = new DevExpress.XtraEditors.PanelControl();
            this.lblFocus = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblFabQty = new System.Windows.Forms.Label();
            this.lblFabCount = new System.Windows.Forms.Label();
            this.lblFabWeight = new System.Windows.Forms.Label();
            this.lblFabYard = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).BeginInit();
            this.panGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(774, 366);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // panGroup
            // 
            this.panGroup.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroup.Appearance.Options.UseBackColor = true;
            this.panGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroup.Controls.Add(this.lblFocus);
            this.panGroup.Controls.Add(this.gridControlDetail);
            this.panGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroup.Location = new System.Drawing.Point(0, 0);
            this.panGroup.Name = "panGroup";
            this.panGroup.Size = new System.Drawing.Size(774, 366);
            this.panGroup.TabIndex = 273;
            // 
            // lblFocus
            // 
            this.lblFocus.AutoSize = true;
            this.lblFocus.Location = new System.Drawing.Point(138, 132);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(0, 12);
            this.lblFocus.TabIndex = 34;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblFabYard);
            this.panelControl1.Controls.Add(this.lblFabQty);
            this.panelControl1.Controls.Add(this.lblFabCount);
            this.panelControl1.Controls.Add(this.lblFabWeight);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 366);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(774, 27);
            this.panelControl1.TabIndex = 274;
            // 
            // lblFabQty
            // 
            this.lblFabQty.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.lblFabQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFabQty.Location = new System.Drawing.Point(138, 3);
            this.lblFabQty.Name = "lblFabQty";
            this.lblFabQty.Size = new System.Drawing.Size(117, 18);
            this.lblFabQty.TabIndex = 266;
            this.lblFabQty.Text = "202";
            this.lblFabQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFabCount
            // 
            this.lblFabCount.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.lblFabCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFabCount.Location = new System.Drawing.Point(37, 3);
            this.lblFabCount.Name = "lblFabCount";
            this.lblFabCount.Size = new System.Drawing.Size(95, 18);
            this.lblFabCount.TabIndex = 265;
            this.lblFabCount.Text = "1";
            this.lblFabCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFabWeight
            // 
            this.lblFabWeight.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.lblFabWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFabWeight.Location = new System.Drawing.Point(255, 3);
            this.lblFabWeight.Name = "lblFabWeight";
            this.lblFabWeight.Size = new System.Drawing.Size(117, 18);
            this.lblFabWeight.TabIndex = 266;
            this.lblFabWeight.Text = "202";
            this.lblFabWeight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFabYard
            // 
            this.lblFabYard.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.lblFabYard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFabYard.Location = new System.Drawing.Point(378, 3);
            this.lblFabYard.Name = "lblFabYard";
            this.lblFabYard.Size = new System.Drawing.Size(117, 18);
            this.lblFabYard.TabIndex = 267;
            this.lblFabYard.Text = "202";
            this.lblFabYard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCFabVHori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroup);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCFabVHori";
            this.Size = new System.Drawing.Size(774, 393);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).EndInit();
            this.panGroup.ResumeLayout(false);
            this.panGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panGroup;
        private System.Windows.Forms.Label lblFocus;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label lblFabQty;
        private System.Windows.Forms.Label lblFabCount;
        private System.Windows.Forms.Label lblFabWeight;
        private System.Windows.Forms.Label lblFabYard;
    }
}
