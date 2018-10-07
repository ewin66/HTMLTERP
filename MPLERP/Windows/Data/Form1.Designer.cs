namespace MLTERP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGet = new System.Windows.Forms.Button();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.txtSql = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSql.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseIlYesOrNo
            // 
            this.BaseIlYesOrNo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlYesOrNo.ImageStream")));
            this.BaseIlYesOrNo.Images.SetKeyName(0, "");
            this.BaseIlYesOrNo.Images.SetKeyName(1, "");
            this.BaseIlYesOrNo.Images.SetKeyName(2, "lock.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(3, "lock2.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(4, "tick.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(5, "button.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(6, "cross.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(7, "hammer.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(8, "hand.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(9, "hand2.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(10, "key.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(11, "mail add.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(12, "mail delete.ico");
            this.BaseIlYesOrNo.Images.SetKeyName(13, "mail send.ico");
            // 
            // BaseIlAll
            // 
            this.BaseIlAll.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlAll.ImageStream")));
            this.BaseIlAll.Images.SetKeyName(0, "");
            this.BaseIlAll.Images.SetKeyName(1, "");
            this.BaseIlAll.Images.SetKeyName(2, "");
            this.BaseIlAll.Images.SetKeyName(3, "");
            this.BaseIlAll.Images.SetKeyName(4, "");
            this.BaseIlAll.Images.SetKeyName(5, "");
            this.BaseIlAll.Images.SetKeyName(6, "");
            this.BaseIlAll.Images.SetKeyName(7, "");
            this.BaseIlAll.Images.SetKeyName(8, "");
            this.BaseIlAll.Images.SetKeyName(9, "");
            this.BaseIlAll.Images.SetKeyName(10, "");
            this.BaseIlAll.Images.SetKeyName(11, "");
            this.BaseIlAll.Images.SetKeyName(12, "");
            this.BaseIlAll.Images.SetKeyName(13, "");
            this.BaseIlAll.Images.SetKeyName(14, "");
            this.BaseIlAll.Images.SetKeyName(15, "");
            this.BaseIlAll.Images.SetKeyName(16, "");
            this.BaseIlAll.Images.SetKeyName(17, "");
            this.BaseIlAll.Images.SetKeyName(18, "");
            this.BaseIlAll.Images.SetKeyName(19, "");
            this.BaseIlAll.Images.SetKeyName(20, "");
            this.BaseIlAll.Images.SetKeyName(21, "");
            this.BaseIlAll.Images.SetKeyName(22, "");
            this.BaseIlAll.Images.SetKeyName(23, "");
            this.BaseIlAll.Images.SetKeyName(24, "");
            this.BaseIlAll.Images.SetKeyName(25, "");
            this.BaseIlAll.Images.SetKeyName(26, "");
            this.BaseIlAll.Images.SetKeyName(27, "");
            this.BaseIlAll.Images.SetKeyName(28, "");
            this.BaseIlAll.Images.SetKeyName(29, "");
            this.BaseIlAll.Images.SetKeyName(30, "");
            this.BaseIlAll.Images.SetKeyName(31, "");
            this.BaseIlAll.Images.SetKeyName(32, "");
            this.BaseIlAll.Images.SetKeyName(33, "");
            this.BaseIlAll.Images.SetKeyName(34, "");
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(118, 35);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "获取语句";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(12, 35);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(100, 21);
            this.txtTable.TabIndex = 2;
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSql.Location = new System.Drawing.Point(0, 62);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(761, 343);
            this.txtSql.TabIndex = 3;
            this.txtSql.UseOptimizedRendering = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 405);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.btnGet);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.btnGet, 0);
            this.Controls.SetChildIndex(this.txtTable, 0);
            this.Controls.SetChildIndex(this.txtSql, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSql.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtTable;
        private DevExpress.XtraEditors.MemoEdit txtSql;
    }
}