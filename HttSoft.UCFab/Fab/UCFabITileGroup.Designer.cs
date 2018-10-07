namespace HttSoft.UCFab
{
    partial class UCFabITileGroup
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
            this.panGroup = new DevExpress.XtraEditors.PanelControl();
            this.ucFabITile1 = new HttSoft.UCFab.UCFabITile();
            this.ucFabITile2 = new HttSoft.UCFab.UCFabITile();
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).BeginInit();
            this.panGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panGroup
            // 
            this.panGroup.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroup.Appearance.Options.UseBackColor = true;
            this.panGroup.AutoScroll = true;
            this.panGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroup.Controls.Add(this.ucFabITile2);
            this.panGroup.Controls.Add(this.ucFabITile1);
            this.panGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroup.Location = new System.Drawing.Point(0, 0);
            this.panGroup.Name = "panGroup";
            this.panGroup.Size = new System.Drawing.Size(713, 482);
            this.panGroup.TabIndex = 270;
            this.panGroup.Text = "panelControl1";
            // 
            // ucFabITile1
            // 
            this.ucFabITile1.DrSource = null;
            this.ucFabITile1.Location = new System.Drawing.Point(29, 25);
            this.ucFabITile1.Name = "ucFabITile1";
            this.ucFabITile1.Size = new System.Drawing.Size(159, 108);
            this.ucFabITile1.TabIndex = 0;
            this.ucFabITile1.UCBackColorIndex = 1;
            this.ucFabITile1.UCISN = "";
            // 
            // ucFabITile2
            // 
            this.ucFabITile2.DrSource = null;
            this.ucFabITile2.Location = new System.Drawing.Point(194, 25);
            this.ucFabITile2.Name = "ucFabITile2";
            this.ucFabITile2.Size = new System.Drawing.Size(159, 108);
            this.ucFabITile2.TabIndex = 1;
            this.ucFabITile2.UCBackColorIndex = 1;
            this.ucFabITile2.UCISN = "";
            // 
            // UCFabITileGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroup);
            this.Name = "UCFabITileGroup";
            this.Size = new System.Drawing.Size(713, 482);
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).EndInit();
            this.panGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGroup;
        private UCFabITile ucFabITile2;
        private UCFabITile ucFabITile1;
    }
}
