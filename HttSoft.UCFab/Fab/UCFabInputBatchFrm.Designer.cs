namespace HttSoft.UCFab
{
    partial class UCFabInputBatchFrm
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
            this.panGroupTopRight = new DevExpress.XtraEditors.PanelControl();
            this.txtPerQty = new DevExpress.XtraEditors.TextEdit();
            this.txtFabCount = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).BeginInit();
            this.panGroupTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFabCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panGroupTopRight
            // 
            this.panGroupTopRight.Appearance.BackColor = System.Drawing.Color.White;
            this.panGroupTopRight.Appearance.Options.UseBackColor = true;
            this.panGroupTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGroupTopRight.Controls.Add(this.btnCancel);
            this.panGroupTopRight.Controls.Add(this.btnOK);
            this.panGroupTopRight.Controls.Add(this.label6);
            this.panGroupTopRight.Controls.Add(this.label2);
            this.panGroupTopRight.Controls.Add(this.txtPerQty);
            this.panGroupTopRight.Controls.Add(this.txtFabCount);
            this.panGroupTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGroupTopRight.Location = new System.Drawing.Point(0, 0);
            this.panGroupTopRight.Name = "panGroupTopRight";
            this.panGroupTopRight.Size = new System.Drawing.Size(373, 216);
            this.panGroupTopRight.TabIndex = 275;
            this.panGroupTopRight.Text = "panelControl1";
            // 
            // txtPerQty
            // 
            this.txtPerQty.EditValue = "";
            this.txtPerQty.Location = new System.Drawing.Point(165, 78);
            this.txtPerQty.Name = "txtPerQty";
            this.txtPerQty.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txtPerQty.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtPerQty.Properties.Appearance.Options.UseFont = true;
            this.txtPerQty.Properties.Appearance.Options.UseForeColor = true;
            this.txtPerQty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPerQty.ShowToolTips = false;
            this.txtPerQty.Size = new System.Drawing.Size(83, 27);
            this.txtPerQty.TabIndex = 276;
            // 
            // txtFabCount
            // 
            this.txtFabCount.EditValue = "";
            this.txtFabCount.Location = new System.Drawing.Point(165, 39);
            this.txtFabCount.Name = "txtFabCount";
            this.txtFabCount.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txtFabCount.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtFabCount.Properties.Appearance.Options.UseFont = true;
            this.txtFabCount.Properties.Appearance.Options.UseForeColor = true;
            this.txtFabCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtFabCount.Size = new System.Drawing.Size(83, 27);
            this.txtFabCount.TabIndex = 275;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(72, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 277;
            this.label6.Text = "卷数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(72, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 278;
            this.label2.Text = "每卷数量:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnOK.Location = new System.Drawing.Point(165, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 22);
            this.btnOK.TabIndex = 279;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCancel.Location = new System.Drawing.Point(285, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.TabIndex = 280;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UCFabInputBatchFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 216);
            this.Controls.Add(this.panGroupTopRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UCFabInputBatchFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量录入";
            ((System.ComponentModel.ISupportInitialize)(this.panGroupTopRight)).EndInit();
            this.panGroupTopRight.ResumeLayout(false);
            this.panGroupTopRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFabCount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGroupTopRight;
        private DevExpress.XtraEditors.TextEdit txtPerQty;
        private DevExpress.XtraEditors.TextEdit txtFabCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}