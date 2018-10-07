namespace HttSoft.UCFab
{
    partial class UCFabLTileSimpleGroup
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
            this.components = new System.ComponentModel.Container();
            this.panGroup = new DevExpress.XtraEditors.PanelControl();
            this.cMenuLoadFab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiLoadFabKP = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).BeginInit();
            this.cMenuLoadFab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panGroup
            // 
            this.panGroup.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroup.Appearance.Options.UseBackColor = true;
            this.panGroup.AutoScroll = true;
            this.panGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroup.Location = new System.Drawing.Point(0, 0);
            this.panGroup.Name = "panGroup";
            this.panGroup.Size = new System.Drawing.Size(813, 541);
            this.panGroup.TabIndex = 272;
            this.panGroup.Text = "panelControl1";
            // 
            // cMenuLoadFab
            // 
            this.cMenuLoadFab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiLoadFabKP});
            this.cMenuLoadFab.Name = "cMenuLoadFab";
            this.cMenuLoadFab.Size = new System.Drawing.Size(153, 48);
            this.cMenuLoadFab.Opening += new System.ComponentModel.CancelEventHandler(this.cMenuLoadFab_Opening);
            // 
            // cmiLoadFabKP
            // 
            this.cmiLoadFabKP.Name = "cmiLoadFabKP";
            this.cmiLoadFabKP.Size = new System.Drawing.Size(152, 22);
            this.cmiLoadFabKP.Text = "开匹(&K)";
            this.cmiLoadFabKP.Click += new System.EventHandler(this.cmiLoadFabKP_Click);
            // 
            // UCFabLTileSimpleGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGroup);
            this.Name = "UCFabLTileSimpleGroup";
            this.Size = new System.Drawing.Size(813, 541);
            ((System.ComponentModel.ISupportInitialize)(this.panGroup)).EndInit();
            this.cMenuLoadFab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGroup;
        private System.Windows.Forms.ContextMenuStrip cMenuLoadFab;
        private System.Windows.Forms.ToolStripMenuItem cmiLoadFabKP;
    }
}
