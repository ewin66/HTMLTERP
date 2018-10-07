namespace HttSoft.UCFab
{
    partial class UCFabITileFirstRow
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
            this.panTile = new DevExpress.XtraEditors.PanelControl();
            this.lblColIndex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).BeginInit();
            this.panTile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTile
            // 
            this.panTile.Appearance.BackColor = System.Drawing.Color.White;
            this.panTile.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panTile.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panTile.Appearance.Options.UseBackColor = true;
            this.panTile.Appearance.Options.UseBorderColor = true;
            this.panTile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panTile.Controls.Add(this.lblColIndex);
            this.panTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTile.Location = new System.Drawing.Point(0, 0);
            this.panTile.Name = "panTile";
            this.panTile.Size = new System.Drawing.Size(97, 27);
            this.panTile.TabIndex = 270;
            this.panTile.Text = "panelControl1";
            // 
            // lblColIndex
            // 
            this.lblColIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColIndex.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lblColIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblColIndex.Location = new System.Drawing.Point(1, 1);
            this.lblColIndex.Name = "lblColIndex";
            this.lblColIndex.Size = new System.Drawing.Size(95, 25);
            this.lblColIndex.TabIndex = 264;
            this.lblColIndex.Text = "1";
            this.lblColIndex.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCFabITileFirstRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panTile);
            this.Name = "UCFabITileFirstRow";
            this.Size = new System.Drawing.Size(97, 27);
            this.Load += new System.EventHandler(this.UCFabITileFirstRow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).EndInit();
            this.panTile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panTile;
        private System.Windows.Forms.Label lblColIndex;
    }
}
