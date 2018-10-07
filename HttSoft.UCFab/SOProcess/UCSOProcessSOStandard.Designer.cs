namespace HttSoft.UCFab
{
    partial class UCSOProcessSOStandard
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
            this.picMain = new System.Windows.Forms.PictureBox();
            this.panAll = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtReceiveQty = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalQty = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFormDate = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFormNo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAll)).BeginInit();
            this.panAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiveQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picMain.Location = new System.Drawing.Point(11, 82);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(276, 189);
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            // 
            // panAll
            // 
            this.panAll.Appearance.BackColor = System.Drawing.Color.White;
            this.panAll.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panAll.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panAll.Appearance.Options.UseBackColor = true;
            this.panAll.Appearance.Options.UseBorderColor = true;
            this.panAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panAll.Controls.Add(this.lblTitle);
            this.panAll.Controls.Add(this.txtReceiveQty);
            this.panAll.Controls.Add(this.label4);
            this.panAll.Controls.Add(this.txtTotalQty);
            this.panAll.Controls.Add(this.label3);
            this.panAll.Controls.Add(this.txtFormDate);
            this.panAll.Controls.Add(this.label2);
            this.panAll.Controls.Add(this.txtFormNo);
            this.panAll.Controls.Add(this.label1);
            this.panAll.Controls.Add(this.picMain);
            this.panAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAll.Location = new System.Drawing.Point(0, 0);
            this.panAll.Name = "panAll";
            this.panAll.Size = new System.Drawing.Size(299, 279);
            this.panAll.TabIndex = 272;
            this.panAll.Text = "panelControl1";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(1, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(297, 22);
            this.lblTitle.TabIndex = 309;
            this.lblTitle.Text = "销售订单";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtReceiveQty
            // 
            this.txtReceiveQty.EditValue = "";
            this.txtReceiveQty.Location = new System.Drawing.Point(204, 57);
            this.txtReceiveQty.Name = "txtReceiveQty";
            this.txtReceiveQty.Properties.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.txtReceiveQty.Properties.Appearance.Options.UseBackColor = true;
            this.txtReceiveQty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtReceiveQty.Properties.MaxLength = 50;
            this.txtReceiveQty.Properties.ReadOnly = true;
            this.txtReceiveQty.Size = new System.Drawing.Size(83, 19);
            this.txtReceiveQty.TabIndex = 308;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(154, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 307;
            this.label4.Text = "交货数";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.EditValue = "";
            this.txtTotalQty.Location = new System.Drawing.Point(57, 56);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Properties.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.txtTotalQty.Properties.Appearance.Options.UseBackColor = true;
            this.txtTotalQty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtTotalQty.Properties.MaxLength = 50;
            this.txtTotalQty.Properties.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(83, 19);
            this.txtTotalQty.TabIndex = 306;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 305;
            this.label3.Text = "下单数";
            // 
            // txtFormDate
            // 
            this.txtFormDate.EditValue = "";
            this.txtFormDate.Location = new System.Drawing.Point(204, 32);
            this.txtFormDate.Name = "txtFormDate";
            this.txtFormDate.Properties.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.txtFormDate.Properties.Appearance.Options.UseBackColor = true;
            this.txtFormDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFormDate.Properties.MaxLength = 50;
            this.txtFormDate.Properties.ReadOnly = true;
            this.txtFormDate.Size = new System.Drawing.Size(83, 19);
            this.txtFormDate.TabIndex = 304;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(154, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 303;
            this.label2.Text = "下单日";
            // 
            // txtFormNo
            // 
            this.txtFormNo.EditValue = "";
            this.txtFormNo.Location = new System.Drawing.Point(57, 31);
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Properties.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.txtFormNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtFormNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFormNo.Properties.MaxLength = 50;
            this.txtFormNo.Properties.ReadOnly = true;
            this.txtFormNo.Size = new System.Drawing.Size(83, 19);
            this.txtFormNo.TabIndex = 302;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 301;
            this.label1.Text = "订单号";
            // 
            // UCSOProcessSOStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panAll);
            this.Name = "UCSOProcessSOStandard";
            this.Size = new System.Drawing.Size(299, 279);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAll)).EndInit();
            this.panAll.ResumeLayout(false);
            this.panAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiveQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMain;
        private DevExpress.XtraEditors.PanelControl panAll;
        private DevExpress.XtraEditors.TextEdit txtReceiveQty;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtTotalQty;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtFormDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtFormNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
    }
}
