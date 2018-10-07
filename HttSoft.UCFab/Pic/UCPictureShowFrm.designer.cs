namespace HttSoft.UCFab
{
    partial class UCPictureShowFrm
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
            this.components = new System.ComponentModel.Container();
            this.groupControlTop = new DevExpress.XtraEditors.GroupControl();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControlBottom = new DevExpress.XtraEditors.GroupControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnPicBigger = new System.Windows.Forms.Button();
            this.btnPicSmaller = new System.Windows.Forms.Button();
            this.btnPicYuan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTop)).BeginInit();
            this.groupControlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBottom)).BeginInit();
            this.groupControlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlTop
            // 
            this.groupControlTop.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlTop.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlTop.AutoScroll = true;
            this.groupControlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlTop.Controls.Add(this.picSample);
            this.groupControlTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupControlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlTop.Location = new System.Drawing.Point(0, 0);
            this.groupControlTop.Margin = new System.Windows.Forms.Padding(0);
            this.groupControlTop.Name = "groupControlTop";
            this.groupControlTop.Size = new System.Drawing.Size(742, 543);
            this.groupControlTop.TabIndex = 33;
            // 
            // picSample
            // 
            this.picSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSample.ContextMenuStrip = this.contextMenuStrip1;
            this.picSample.Location = new System.Drawing.Point(0, 0);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(364, 375);
            this.picSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSample.TabIndex = 269;
            this.picSample.TabStop = false;
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
            // groupControlBottom
            // 
            this.groupControlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlBottom.Controls.Add(this.btnPicYuan);
            this.groupControlBottom.Controls.Add(this.btnPicBigger);
            this.groupControlBottom.Controls.Add(this.btnPicSmaller);
            this.groupControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControlBottom.Location = new System.Drawing.Point(0, 543);
            this.groupControlBottom.Name = "groupControlBottom";
            this.groupControlBottom.Size = new System.Drawing.Size(742, 35);
            this.groupControlBottom.TabIndex = 43;
            this.groupControlBottom.Text = "颜色标识";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(146, 144);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPG文件|*.jpg|GIF文件|*.gif";
            // 
            // btnPicBigger
            // 
            this.btnPicBigger.BackColor = System.Drawing.Color.YellowGreen;
            this.btnPicBigger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicBigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPicBigger.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPicBigger.ForeColor = System.Drawing.Color.Transparent;
            this.btnPicBigger.Location = new System.Drawing.Point(68, 3);
            this.btnPicBigger.Name = "btnPicBigger";
            this.btnPicBigger.Size = new System.Drawing.Size(66, 27);
            this.btnPicBigger.TabIndex = 270;
            this.btnPicBigger.Text = "放大";
            this.btnPicBigger.UseVisualStyleBackColor = false;
            this.btnPicBigger.Click += new System.EventHandler(this.btnPicBigger_Click);
            // 
            // btnPicSmaller
            // 
            this.btnPicSmaller.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPicSmaller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicSmaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPicSmaller.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPicSmaller.ForeColor = System.Drawing.Color.White;
            this.btnPicSmaller.Location = new System.Drawing.Point(152, 3);
            this.btnPicSmaller.Name = "btnPicSmaller";
            this.btnPicSmaller.Size = new System.Drawing.Size(65, 27);
            this.btnPicSmaller.TabIndex = 271;
            this.btnPicSmaller.Text = "缩小";
            this.btnPicSmaller.UseVisualStyleBackColor = false;
            this.btnPicSmaller.Click += new System.EventHandler(this.btnPicSmaller_Click);
            // 
            // btnPicYuan
            // 
            this.btnPicYuan.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPicYuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicYuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPicYuan.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPicYuan.ForeColor = System.Drawing.Color.White;
            this.btnPicYuan.Location = new System.Drawing.Point(237, 3);
            this.btnPicYuan.Name = "btnPicYuan";
            this.btnPicYuan.Size = new System.Drawing.Size(67, 27);
            this.btnPicYuan.TabIndex = 272;
            this.btnPicYuan.Text = "原始";
            this.btnPicYuan.UseVisualStyleBackColor = false;
            this.btnPicYuan.Click += new System.EventHandler(this.btnPicYuan_Click);
            // 
            // UCPictureShowFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 578);
            this.Controls.Add(this.groupControlTop);
            this.Controls.Add(this.groupControlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "UCPictureShowFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片查看";
            this.Load += new System.EventHandler(this.frmStylePic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTop)).EndInit();
            this.groupControlTop.ResumeLayout(false);
            this.groupControlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBottom)).EndInit();
            this.groupControlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlTop;
        private DevExpress.XtraEditors.GroupControl groupControlBottom;
        private System.Windows.Forms.PictureBox picSample;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmiDownload;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnPicYuan;
        private System.Windows.Forms.Button btnPicSmaller;
        private System.Windows.Forms.Button btnPicBigger;
    }
}