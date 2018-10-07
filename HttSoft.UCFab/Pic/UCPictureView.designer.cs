namespace HttSoft.UCFab
{
    partial class UCPictureView
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
            this.picGroup = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.groupTopRight = new DevExpress.XtraEditors.GroupControl();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.lbShowFileInfor = new System.Windows.Forms.Label();
            this.lbShowIndex = new System.Windows.Forms.Label();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).BeginInit();
            this.picGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTopRight)).BeginInit();
            this.groupTopRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGroup
            // 
            this.picGroup.Appearance.BackColor = System.Drawing.Color.White;
            this.picGroup.Appearance.ForeColor = System.Drawing.Color.Black;
            this.picGroup.Appearance.Options.UseBackColor = true;
            this.picGroup.Appearance.Options.UseForeColor = true;
            this.picGroup.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picGroup.AppearanceCaption.Options.UseForeColor = true;
            this.picGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picGroup.Controls.Add(this.groupControl1);
            this.picGroup.Controls.Add(this.groupTopRight);
            this.picGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGroup.Location = new System.Drawing.Point(0, 0);
            this.picGroup.Name = "picGroup";
            this.picGroup.Size = new System.Drawing.Size(501, 395);
            this.picGroup.TabIndex = 880;
            this.picGroup.Text = "图片资料";
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.picShow);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(461, 395);
            this.groupControl1.TabIndex = 295;
            // 
            // picShow
            // 
            this.picShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picShow.ContextMenuStrip = this.contextMenuStrip1;
            this.picShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picShow.Location = new System.Drawing.Point(0, 0);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(461, 395);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShow.TabIndex = 0;
            this.picShow.TabStop = false;
            this.picShow.DoubleClick += new System.EventHandler(this.picShow_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiDownload});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cmiDownload
            // 
            this.cmiDownload.Name = "cmiDownload";
            this.cmiDownload.Size = new System.Drawing.Size(124, 22);
            this.cmiDownload.Text = "下载图片";
            this.cmiDownload.Click += new System.EventHandler(this.cmiDownload_Click);
            // 
            // groupTopRight
            // 
            this.groupTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupTopRight.Controls.Add(this.lbTotalCount);
            this.groupTopRight.Controls.Add(this.lbShowFileInfor);
            this.groupTopRight.Controls.Add(this.lbShowIndex);
            this.groupTopRight.Controls.Add(this.btnPrev);
            this.groupTopRight.Controls.Add(this.btnNext);
            this.groupTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupTopRight.Location = new System.Drawing.Point(461, 0);
            this.groupTopRight.Name = "groupTopRight";
            this.groupTopRight.Size = new System.Drawing.Size(40, 395);
            this.groupTopRight.TabIndex = 0;
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotalCount.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCount.ForeColor = System.Drawing.Color.Red;
            this.lbTotalCount.Location = new System.Drawing.Point(3, 3);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(34, 33);
            this.lbTotalCount.TabIndex = 280;
            this.lbTotalCount.Text = "0";
            this.lbTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShowFileInfor
            // 
            this.lbShowFileInfor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbShowFileInfor.Location = new System.Drawing.Point(6, 179);
            this.lbShowFileInfor.Name = "lbShowFileInfor";
            this.lbShowFileInfor.Size = new System.Drawing.Size(21, 163);
            this.lbShowFileInfor.TabIndex = 279;
            this.lbShowFileInfor.Text = "文件描述";
            this.lbShowFileInfor.Visible = false;
            // 
            // lbShowIndex
            // 
            this.lbShowIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbShowIndex.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowIndex.ForeColor = System.Drawing.Color.Red;
            this.lbShowIndex.Location = new System.Drawing.Point(3, 45);
            this.lbShowIndex.Name = "lbShowIndex";
            this.lbShowIndex.Size = new System.Drawing.Size(34, 35);
            this.lbShowIndex.TabIndex = 278;
            this.lbShowIndex.Text = "0";
            this.lbShowIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrev
            // 
            this.btnPrev.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnPrev.Appearance.Options.UseFont = true;
            this.btnPrev.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnPrev.Location = new System.Drawing.Point(3, 142);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 23);
            this.btnPrev.TabIndex = 277;
            this.btnPrev.Tag = "";
            this.btnPrev.Text = "《";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnNext.Location = new System.Drawing.Point(3, 102);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 23);
            this.btnNext.TabIndex = 277;
            this.btnNext.Tag = "";
            this.btnNext.Text = "》";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPG文件|*.jpg|GIF文件|*.gif";
            // 
            // UCPictureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picGroup);
            this.Name = "UCPictureView";
            this.Size = new System.Drawing.Size(501, 395);
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).EndInit();
            this.picGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupTopRight)).EndInit();
            this.groupTopRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl picGroup;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox picShow;
        private DevExpress.XtraEditors.GroupControl groupTopRight;
        private System.Windows.Forms.Label lbShowFileInfor;
        private System.Windows.Forms.Label lbShowIndex;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmiDownload;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
