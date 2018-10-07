using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmMSGMain : frmAPBaseUIRpt
    {
        public frmMSGMain()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;

            if (txtFormNo.Text.Trim() != "")//��ѯ��
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtFormDateS.DateTime)+" AND "+SysString.ToDBString(txtFormDateE.DateTime);
            }

            if (chkSendDate.Checked)
            {
                tempStr += " AND SendTime BETWEEN "+SysString.ToDBString(txtSendDateS.DateTime)+" AND "+SysString.ToDBString(txtSendDateE.DateTime);
            }

            if (SysConvert.ToInt32(drpMSGSourceID.EditValue) != 0)
            {
                tempStr += " AND MSGSourceID="+SysString.ToDBString(SysConvert.ToInt32(drpMSGSourceID.EditValue));
            }

            if (txtSendPhone.Text.Trim() != "")
            {
                tempStr += " AND SendPhone LIKE "+SysString.ToDBString("%"+txtSendPhone.Text.Trim()+"%");
            }

            if (txtTargetPhone.Text.Trim() != "")
            {
                tempStr += " AND TargetPhone LIKE "+SysString.ToDBString("%"+txtTargetPhone.Text.Trim()+"%");
            }

            if (txtTaregtInfo.Text.Trim() != "")
            {
                tempStr += " AND TaregtInfo LIKE "+SysString.ToDBString("%"+txtTaregtInfo.Text.Trim()+"%");
            }
            
            tempStr += " ORDER BY FormNo DESC";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "SELECT * FROM UV1_SMS_MSGMain WHERE 1=1";
            sql += HTDataConditionStr;
            gridView1.GridControl.DataSource = SysUtils.Fill(sql);
            gridView1.GridControl.Show();
        }

        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "SMS_MSGMain";
            this.HTDataList = gridView1;
            Common.BindMSGSource(drpMSGSourceID, true);
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            txtSendDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtSendDateE.DateTime = DateTime.Now.Date;
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            btnQuery_Click(null, null);

        }

       

        #endregion

        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

      
        

    }
}