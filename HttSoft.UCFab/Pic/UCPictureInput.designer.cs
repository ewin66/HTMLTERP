namespace HttSoft.UCFab
{
    partial class UCPictureInput
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
            this.groupTopRight = new DevExpress.XtraEditors.GroupControl();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbShowFileInfor = new System.Windows.Forms.Label();
            this.lbShowIndex = new System.Windows.Forms.Label();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCam = new System.Windows.Forms.Button();
            this.cmsMoreOP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiMoreOPCam = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiMoreOPDrap = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).BeginInit();
            this.picGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTopRight)).BeginInit();
            this.groupTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.cmsMoreOP.SuspendLayout();
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
            this.picGroup.Controls.Add(this.groupControl6);
            this.picGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGroup.Location = new System.Drawing.Point(0, 0);
            this.picGroup.Name = "picGroup";
            this.picGroup.Size = new System.Drawing.Size(503, 350);
            this.picGroup.TabIndex = 879;
            this.picGroup.Text = "图片资料";
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.picShow);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(463, 311);
            this.groupControl1.TabIndex = 295;
            // 
            // picShow
            // 
            this.picShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picShow.Location = new System.Drawing.Point(0, 0);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(463, 311);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShow.TabIndex = 0;
            this.picShow.TabStop = false;
            this.picShow.DoubleClick += new System.EventHandler(this.picShow_DoubleClick);
            // 
            // groupTopRight
            // 
            this.groupTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupTopRight.Controls.Add(this.btnPrev);
            this.groupTopRight.Controls.Add(this.lbTotalCount);
            this.groupTopRight.Controls.Add(this.btnNext);
            this.groupTopRight.Controls.Add(this.lbShowFileInfor);
            this.groupTopRight.Controls.Add(this.lbShowIndex);
            this.groupTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupTopRight.Location = new System.Drawing.Point(463, 0);
            this.groupTopRight.Name = "groupTopRight";
            this.groupTopRight.Size = new System.Drawing.Size(40, 311);
            this.groupTopRight.TabIndex = 0;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(3, 151);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(34, 35);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.BackColor = System.Drawing.Color.Orange;
            this.lbTotalCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTotalCount.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCount.ForeColor = System.Drawing.Color.White;
            this.lbTotalCount.Location = new System.Drawing.Point(3, 3);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(34, 33);
            this.lbTotalCount.TabIndex = 280;
            this.lbTotalCount.Text = "0";
            this.lbTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(3, 103);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 33);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbShowFileInfor
            // 
            this.lbShowFileInfor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbShowFileInfor.Location = new System.Drawing.Point(6, 199);
            this.lbShowFileInfor.Name = "lbShowFileInfor";
            this.lbShowFileInfor.Size = new System.Drawing.Size(21, 109);
            this.lbShowFileInfor.TabIndex = 279;
            this.lbShowFileInfor.Text = "文件描述";
            this.lbShowFileInfor.Visible = false;
            // 
            // lbShowIndex
            // 
            this.lbShowIndex.BackColor = System.Drawing.Color.DarkSalmon;
            this.lbShowIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbShowIndex.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowIndex.ForeColor = System.Drawing.Color.White;
            this.lbShowIndex.Location = new System.Drawing.Point(3, 56);
            this.lbShowIndex.Name = "lbShowIndex";
            this.lbShowIndex.Size = new System.Drawing.Size(34, 35);
            this.lbShowIndex.TabIndex = 278;
            this.lbShowIndex.Text = "0";
            this.lbShowIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupControl6
            // 
            this.groupControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl6.Controls.Add(this.btnDelete);
            this.groupControl6.Controls.Add(this.txtRemark);
            this.groupControl6.Controls.Add(this.btnUpdate);
            this.groupControl6.Controls.Add(this.label1);
            this.groupControl6.Controls.Add(this.btnInsert);
            this.groupControl6.Controls.Add(this.btnBrowse);
            this.groupControl6.Controls.Add(this.btnCam);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl6.Location = new System.Drawing.Point(0, 311);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(503, 39);
            this.groupControl6.TabIndex = 294;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(383, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 27);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "";
            this.txtRemark.Location = new System.Drawing.Point(42, 7);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Properties.Appearance.Options.UseFont = true;
            this.txtRemark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtRemark.Properties.MaxLength = 50;
            this.txtRemark.Size = new System.Drawing.Size(96, 25);
            this.txtRemark.TabIndex = 292;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SandyBrown;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(326, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 27);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 292;
            this.label1.Text = "文件";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Orange;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(267, 6);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(53, 27);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "增加";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.YellowGreen;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(144, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(55, 27);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCam
            // 
            this.btnCam.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCam.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCam.ForeColor = System.Drawing.Color.White;
            this.btnCam.Location = new System.Drawing.Point(205, 6);
            this.btnCam.Name = "btnCam";
            this.btnCam.Size = new System.Drawing.Size(56, 27);
            this.btnCam.TabIndex = 2;
            this.btnCam.Text = "截图";
            this.btnCam.UseVisualStyleBackColor = false;
            this.btnCam.Click += new System.EventHandler(this.btnCam_Click);
            // 
            // cmsMoreOP
            // 
            this.cmsMoreOP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiMoreOPCam,
            this.cmiMoreOPDrap});
            this.cmsMoreOP.Name = "cmsMoreOP";
            this.cmsMoreOP.Size = new System.Drawing.Size(101, 48);
            // 
            // cmiMoreOPCam
            // 
            this.cmiMoreOPCam.Name = "cmiMoreOPCam";
            this.cmiMoreOPCam.Size = new System.Drawing.Size(100, 22);
            this.cmiMoreOPCam.Text = "拍照";
            this.cmiMoreOPCam.Click += new System.EventHandler(this.cmiMoreOPCam_Click);
            // 
            // cmiMoreOPDrap
            // 
            this.cmiMoreOPDrap.Name = "cmiMoreOPDrap";
            this.cmiMoreOPDrap.Size = new System.Drawing.Size(100, 22);
            this.cmiMoreOPDrap.Text = "截图";
            this.cmiMoreOPDrap.Click += new System.EventHandler(this.cmiMoreOPDrap_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(146, 144);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPG文件|*.jpg|JPEG文件|*.jpeg|GIF文件|*.gif|BMP文件|*.bmp";
            // 
            // UCPictureInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picGroup);
            this.Name = "UCPictureInput";
            this.Size = new System.Drawing.Size(503, 350);
            this.Load += new System.EventHandler(this.UCPictureInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).EndInit();
            this.picGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTopRight)).EndInit();
            this.groupTopRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.cmsMoreOP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraEditors.GroupControl picGroup;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraEditors.GroupControl groupTopRight;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.Label lbShowIndex;
        private System.Windows.Forms.Label lbShowFileInfor;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.ContextMenuStrip cmsMoreOP;
        private System.Windows.Forms.ToolStripMenuItem cmiMoreOPCam;
        private System.Windows.Forms.ToolStripMenuItem cmiMoreOPDrap;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnCam;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}
