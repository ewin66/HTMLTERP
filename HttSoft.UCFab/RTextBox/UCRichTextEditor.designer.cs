namespace HttSoft.UCFab
{
    partial class UCRichTextEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCRichTextEditor));
            this.richTextBoxContent = new System.Windows.Forms.RichTextBox();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.btnFontSelect = new System.Windows.Forms.ToolStripButton();
            this.btnToSmall = new System.Windows.Forms.ToolStripButton();
            this.btnToLarge = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLeft = new System.Windows.Forms.ToolStripButton();
            this.btnCenter = new System.Windows.Forms.ToolStripButton();
            this.btnRight = new System.Windows.Forms.ToolStripButton();
            this.btnJust = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFontColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBullet = new System.Windows.Forms.ToolStripButton();
            this.toolStripTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxContent
            // 
            this.richTextBoxContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxContent.Location = new System.Drawing.Point(0, 39);
            this.richTextBoxContent.Name = "richTextBoxContent";
            this.richTextBoxContent.Size = new System.Drawing.Size(585, 420);
            this.richTextBoxContent.TabIndex = 0;
            this.richTextBoxContent.Text = "";
            // 
            // toolStripTools
            // 
            this.toolStripTools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFontSelect,
            this.btnToSmall,
            this.btnToLarge,
            this.toolStripSeparator2,
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.toolStripSeparator1,
            this.btnLeft,
            this.btnCenter,
            this.btnRight,
            this.btnJust,
            this.toolStripSeparator3,
            this.btnFontColor,
            this.toolStripSeparator4,
            this.btnBullet});
            this.toolStripTools.Location = new System.Drawing.Point(0, 0);
            this.toolStripTools.Name = "toolStripTools";
            this.toolStripTools.Size = new System.Drawing.Size(585, 39);
            this.toolStripTools.TabIndex = 1;
            this.toolStripTools.Text = "toolStrip1";
            // 
            // btnFontSelect
            // 
            this.btnFontSelect.AutoSize = false;
            this.btnFontSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnFontSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFontSelect.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnFontSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnFontSelect.Image")));
            this.btnFontSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFontSelect.Name = "btnFontSelect";
            this.btnFontSelect.Size = new System.Drawing.Size(33, 33);
            this.btnFontSelect.Text = "字体选择";
            this.btnFontSelect.Click += new System.EventHandler(this.btnFontSelect_Click);
            // 
            // btnToSmall
            // 
            this.btnToSmall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToSmall.Image = ((System.Drawing.Image)(resources.GetObject("btnToSmall.Image")));
            this.btnToSmall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToSmall.Name = "btnToSmall";
            this.btnToSmall.Size = new System.Drawing.Size(36, 36);
            this.btnToSmall.Text = "文字变小";
            this.btnToSmall.Click += new System.EventHandler(this.btnToSmall_Click);
            // 
            // btnToLarge
            // 
            this.btnToLarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToLarge.Image = ((System.Drawing.Image)(resources.GetObject("btnToLarge.Image")));
            this.btnToLarge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToLarge.Name = "btnToLarge";
            this.btnToLarge.Size = new System.Drawing.Size(36, 36);
            this.btnToLarge.Text = "文字变大";
            this.btnToLarge.Click += new System.EventHandler(this.btnToLarge_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnBold
            // 
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(36, 36);
            this.btnBold.Text = "粗体";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.AccessibleDescription = "btnItalic";
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(36, 36);
            this.btnItalic.Text = "斜体";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(36, 36);
            this.btnUnderline.Text = "划线";
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnLeft
            // 
            this.btnLeft.AutoSize = false;
            this.btnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(33, 33);
            this.btnLeft.Text = "左对齐";
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnCenter
            // 
            this.btnCenter.AutoSize = false;
            this.btnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCenter.Image = ((System.Drawing.Image)(resources.GetObject("btnCenter.Image")));
            this.btnCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(33, 33);
            this.btnCenter.Text = "居中对齐";
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // btnRight
            // 
            this.btnRight.AutoSize = false;
            this.btnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(33, 33);
            this.btnRight.Text = "右对齐";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnJust
            // 
            this.btnJust.AutoSize = false;
            this.btnJust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJust.Image = ((System.Drawing.Image)(resources.GetObject("btnJust.Image")));
            this.btnJust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJust.Name = "btnJust";
            this.btnJust.Size = new System.Drawing.Size(33, 33);
            this.btnJust.Text = "自适应";
            this.btnJust.Click += new System.EventHandler(this.btnJust_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnFontColor
            // 
            this.btnFontColor.AutoSize = false;
            this.btnFontColor.BackColor = System.Drawing.SystemColors.Control;
            this.btnFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFontColor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnFontColor.Image = ((System.Drawing.Image)(resources.GetObject("btnFontColor.Image")));
            this.btnFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFontColor.Name = "btnFontColor";
            this.btnFontColor.Size = new System.Drawing.Size(33, 33);
            this.btnFontColor.Text = "字体颜色";
            this.btnFontColor.Click += new System.EventHandler(this.btnFontColor_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // btnBullet
            // 
            this.btnBullet.AutoSize = false;
            this.btnBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBullet.Enabled = false;
            this.btnBullet.Image = ((System.Drawing.Image)(resources.GetObject("btnBullet.Image")));
            this.btnBullet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBullet.Name = "btnBullet";
            this.btnBullet.Size = new System.Drawing.Size(33, 33);
            this.btnBullet.Text = "项目列表";
            this.btnBullet.Click += new System.EventHandler(this.btnBullet_Click);
            // 
            // UCTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.richTextBoxContent);
            this.Controls.Add(this.toolStripTools);
            this.Name = "UCTextEditor";
            this.Size = new System.Drawing.Size(585, 459);
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxContent;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnLeft;
        private System.Windows.Forms.ToolStripButton btnCenter;
        private System.Windows.Forms.ToolStripButton btnRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnFontColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnJust;
        private System.Windows.Forms.ToolStripButton btnFontSelect;
        private System.Windows.Forms.ToolStripButton btnBullet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripButton btnToSmall;
        private System.Windows.Forms.ToolStripButton btnToLarge;
    }
}
