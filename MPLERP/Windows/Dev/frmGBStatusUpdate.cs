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
    public partial class frmGBStatusUpdate : frmAPBaseUIRpt
    {
        public frmGBStatusUpdate()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]
        
      

        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_LYGL";
            this.HTDataList = gridView1;
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            Common.BindGBStatus(drpGBStatusID, true);
            Common.BindGBStatus(drpGBStatusID2, true);
            Common.BindGBStatus(reDrpGBStatus, true);

        }


        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private LYGL EntityGet()
        {
            LYGL entity = new LYGL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

       

        /// <summary>
        /// ɨ��Ұ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGBCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtGBCode.Text.Trim() == "")
                    {
                        this.ShowMessage("��ɨ��Ұ�����");
                        txtGBCode.Focus();
                        return;
                    }
                    string sql = "SELECT GBStatusID FROM Data_ItemGB WHERE GBCode="+SysString.ToDBString(txtGBCode.Text.Trim());
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        drpGBStatusID.EditValue = SysConvert.ToInt32(dt.Rows[0][0]);
                        drpGBStatusID2.EditValue = SysConvert.ToInt32(dt.Rows[0][0]);

                       
                    }
                    else
                    {
                        this.ShowMessage("�Ұ����벻���ڣ�������ɨ��");
                        txtGBCode.Text = "";
                        txtGBCode.Focus();
                        return;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �޸ĹҰ�״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtGBCode.Text.Trim() == "")
                {
                    this.ShowMessage("��ɨ��Ұ�����");
                    txtGBCode.Focus();
                    return;
                }

                if (SysConvert.ToInt32(drpGBStatusID.EditValue) == 0)
                {
                    this.ShowMessage("��ѡ���޸ĺ�ĹҰ�״̬");
                    drpGBStatusID.Focus();
                    return;
                }

                if (SysConvert.ToInt32(drpGBStatusID2.EditValue) == 0)
                {
                    this.ShowMessage("��ѡ���޸�ǰ�ĹҰ�״̬");
                    drpGBStatusID2.Focus();
                    return;
                }
                if (SysConvert.ToInt32(drpGBStatusID.EditValue) == SysConvert.ToInt32(drpGBStatusID2.EditValue))
                {
                    this.ShowMessage("�޸�ǰ���޸ĺ�Ұ�״̬��ͬ��������ѡ���޸ĺ�Ұ�״̬");
                    drpGBStatusID.Focus();
                    return;
                }
                ItemGBUPHisRule rule = new ItemGBUPHisRule();
                ItemGBUPHis entity = GetEntity();
                rule.RAdd(entity);
                string sql = "UPDATE Data_ItemGB SET GBStatusID=" + SysString.ToDBString(entity.GBStatusIDE);
                sql += " WHERE GBCode=" + SysString.ToDBString(txtGBCode.Text.Trim());
                SysUtils.ExecuteNonQuery(sql);
                Bind();
                txtGBCode.Text = "";
                drpGBStatusID.EditValue = 0;
                drpGBStatusID2.EditValue = 0;

                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����ʷ����
        /// </summary>
        private void Bind()
        {
            string sql = "SELECT * FROM Data_ItemGBUPHis WHERE GBCode="+SysString.ToDBString(txtGBCode.Text.Trim());
            DataTable dt = SysUtils.Fill(sql);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private ItemGBUPHis GetEntity()
        {
            ItemGBUPHis entity = new ItemGBUPHis();
            entity.GBCode = txtGBCode.Text.Trim();
            entity.GBStatusIDS = SysConvert.ToInt32(drpGBStatusID2.EditValue);
            entity.GBStatusIDE = SysConvert.ToInt32(drpGBStatusID.EditValue);
            entity.GDate = DateTime.Now.Date;
            entity.UpOPID = FParamConfig.LoginID;
            return entity;
        }

     

    }
}