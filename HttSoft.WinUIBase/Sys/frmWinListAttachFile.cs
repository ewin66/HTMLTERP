using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraEditors.Controls;
using DevComponents.DotNetBar;

namespace HttSoft.WinUIBase
{
    public partial class frmWinListAttachFile : BaseForm
    {
        public frmWinListAttachFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 外部窗体
        /// </summary>
        public frmAPBaseTool ImportForm;

        private void frmWinListAttachFile_Load(object sender, EventArgs e)
        {
            try
            {
                if (ImportForm == null || ImportForm.FormID == 0 || ImportForm.HTDataID == 0)
                {
                    this.ShowMessage("即将关闭，请确保表单数据存在的情况打开文件管理窗口");
                    this.Close();
                    return;
                }

                ucFileUpLoad1.UCWinListID = ImportForm.FormID;
                ucFileUpLoad1.UCHeadType = ImportForm.FormListAID;
                ucFileUpLoad1.UCSubType = ImportForm.FormListBID;
                ucFileUpLoad1.UCHTDateID = ImportForm.HTDataID;
                ucFileUpLoad1.UCLoginLogID = FParamConfig.EntityLoginLogID;
                ucFileUpLoad1.UCUploadOPID = FParamConfig.LoginID;
                ucFileUpLoad1.UCUploadOPName = FParamConfig.LoginName;
                ucFileUpLoad1.UCMangerFlag = FParamConfig.LoginHTFlag;//管理员标志
                ucFileUpLoad1.UCFileProt1 = ImportForm.Text.Replace("明细", "");
                ucFileUpLoad1.UCFileProt2 = ImportForm.HTDataFormNo;
                ucFileUpLoad1.UCAct();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    }
}