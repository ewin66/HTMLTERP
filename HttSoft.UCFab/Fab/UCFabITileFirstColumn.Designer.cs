namespace HttSoft.UCFab
{
    partial class UCFabITileFirstColumn
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
            this.label2 = new System.Windows.Forms.Label();
            this.panTile = new DevExpress.XtraEditors.PanelControl();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRowIndex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).BeginInit();
            this.panTile.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 266;
            this.label2.Text = "数量:";
            // 
            // panTile
            // 
            this.panTile.Appearance.BackColor = System.Drawing.Color.White;
            this.panTile.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panTile.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panTile.Appearance.Options.UseBackColor = true;
            this.panTile.Appearance.Options.UseBorderColor = true;
            this.panTile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panTile.Controls.Add(this.label6);
            this.panTile.Controls.Add(this.label2);
            this.panTile.Controls.Add(this.lblRowIndex);
            this.panTile.Controls.Add(this.label1);
            this.panTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTile.Location = new System.Drawing.Point(0, 0);
            this.panTile.Name = "panTile";
            this.panTile.Size = new System.Drawing.Size(46, 85);
            this.panTile.TabIndex = 270;
            this.panTile.Text = "panelControl1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 264;
            this.label6.Text = "卷号:";
            // 
            // lblRowIndex
            // 
            this.lblRowIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRowIndex.Location = new System.Drawing.Point(4, 3);
            this.lblRowIndex.Name = "lblRowIndex";
            this.lblRowIndex.Size = new System.Drawing.Size(40, 15);
            this.lblRowIndex.TabIndex = 267;
            this.lblRowIndex.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 265;
            this.label1.Text = "条码:";
            // 
            // UCFabITileFirstColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panTile);
            this.Name = "UCFabITileFirstColumn";
            this.Size = new System.Drawing.Size(46, 85);
            this.Load += new System.EventHandler(this.UCFabITileFirstColumn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).EndInit();
            this.panTile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PanelControl panTile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRowIndex;
    }
}
