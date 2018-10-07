namespace MLTERP
{
    partial class frmPicShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPicShow));
            this.ucPictureView1 = new HttSoft.UCFab.UCPictureView();
            this.SuspendLayout();
            // 
            // ucPictureView1
            // 
            this.ucPictureView1.BackColor = System.Drawing.Color.White;
            this.ucPictureView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPictureView1.Location = new System.Drawing.Point(0, 0);
            this.ucPictureView1.Name = "ucPictureView1";
            this.ucPictureView1.Size = new System.Drawing.Size(693, 475);
            this.ucPictureView1.TabIndex = 344;
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
            // frmPicShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 475);
            this.Controls.Add(this.ucPictureView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPicShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPicShow";
            this.Load += new System.EventHandler(this.frmPicShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HttSoft.UCFab.UCPictureView ucPictureView1;

    }
}