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
        /// �ⲿ����
        /// </summary>
        public frmAPBaseTool ImportForm;

        private void frmWinListAttachFile_Load(object sender, EventArgs e)
        {
            try
            {
                if (ImportForm == null || ImportForm.FormID == 0 || ImportForm.HTDataID == 0)
                {
                    this.ShowMessage("�����رգ���ȷ�������ݴ��ڵ�������ļ�������");
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
                ucFileUpLoad1.UCMangerFlag = FParamConfig.LoginHTFlag;//����Ա��־
                ucFileUpLoad1.UCFileProt1 = ImportForm.Text.Replace("��ϸ", "");
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