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
    
    
    /// <summary>
    ///�շ��汨��
    /// </summary>
    public partial class frmInOutStorgeRpt : frmAPBaseUIRpt
    {
        public frmInOutStorgeRpt()
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
            //if (chkFormDate.Checked)
            //{
            //    tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            //}

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%"); ;
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtJH.Text.Trim() != "")
            {
                tempStr += " AND JHFormNo LIKE "+SysString.ToDBString("%"+txtJH.Text.Trim()+"%");
            }
            if (SysConvert.ToString(drpQWHID.EditValue)!="")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            if (SysConvert.ToString(drpQWHID.EditValue)=="")
            {
                this.ShowMessage("��ѡ��ֿ�");
                return;
            }
            string FormDateS = "2014-01-01";
            string FormDateE = "2222-01-01";
            if (chkFormDate.Checked)
            {
                FormDateS = txtFormDateS.DateTime.ToString("yyyy-MM-dd");
                FormDateE = txtFormDateE.DateTime.ToString("yyyy-MM-dd");
            }
            string sql = string.Empty;
            sql = "SELECT ID FROM WH_StorgeJS WHERE JSDateS=" + SysString.ToDBString(FormDateS) + " AND JSDateE=" + SysString.ToDBString(FormDateE);
            sql += " AND JSFlag=1";
            DataTable dtJS = SysUtils.Fill(sql);
           
            //string sql = "EXEC USP3_WH_InOutStorgeRpt " + SysString.ToDBString(FormDateS) + "," + SysString.ToDBString(FormDateE) + "," + SysString.ToDBString(HTDataConditionStr);
            //DataTable dt = SysUtils.Fill(sql);
            //gridView1.GridControl.DataSource = dt;
            //gridView1.GridControl.Show();

            DataTable dt;
            if (dtJS.Rows.Count != 0)//ͬ�������ڷ�Χ�н������ݣ�ֱ�ӷ��ʽ�������
            {
                StorgeJSDtsRule rule = new StorgeJSDtsRule();
                string conditionStr = " AND MainID=" + SysString.ToDBString(dtJS.Rows[0]["ID"].ToString());

                if (!Common.CheckLookUpEditBlank(drpQWHID))
                {
                    conditionStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
                }
                conditionStr += GetConditionStr();
                dt = rule.RShow(conditionStr, ProcessGrid.GetQueryField(gridView1));

                lblQueryDesc.Text = "�ÿ죬���ѯ�Ŀ��ǲֿ��������Ŷ������";
                Application.DoEvents();
            }
            else
            {
                lblQueryDesc.Text = "�������ϴ󣬲�ѯ�����������ĵȴ���";
                Application.DoEvents();
                int timeout = SystemConfiguration.DBTimeOut;
                SystemConfiguration.DBTimeOut = 100000;

                sql = "EXEC USP3_WH_InOutStorgeRpt " +SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue))+","+ SysString.ToDBString(FormDateS) + "," + SysString.ToDBString(FormDateE) + "," + SysString.ToDBString(HTDataConditionStr);
                dt = SysUtils.Fill(sql);
                SystemConfiguration.DBTimeOut = timeout;
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ��������ַ���
        /// </summary>
        /// <returns></returns>
        string GetConditionStr()
        {
            string tempStr = string.Empty;
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (txtJH.Text.Trim() != string.Empty)
            {
                tempStr += " AND JHFormNo LIKE " + SysString.ToDBString("%" + txtJH.Text.Trim() + "%");
            }
            return tempStr;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
         
            this.HTDataList = gridView1;
            txtFormDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            ProcessCtl.ProcControlEdit(new Control[] { drpQWHID }, true);
            if (this.FormListAID > 0)
            {
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                txtJH.Visible = false;
                txtColorName.Visible = false;
                txtColorNum.Visible = false;
                
                Common.BindWHByWHType(drpQWHID, this.FormListAID, true);
            }
            else
            {
                Common.BindWHByWHType(drpQWHID, new int[] { 1, 2, 3, 4, 6 }, true);
            }
            Common.BindAllWH(drpResWH, true);
        }

        #endregion

      
        
       

        
    }
}