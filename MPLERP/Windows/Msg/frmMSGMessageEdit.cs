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
using DevExpress.XtraEditors.Controls;
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmMSGMessageEdit : frmAPBaseUIFormEdit
    {
        public frmMSGMessageEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtMesPhone.Text.Trim() == "")
            //{
            //    this.ShowMessage("�������ֻ�����");
            //    txtMesPhone.Focus();
            //    return false;
            //}
            if (txtContext.Text.Trim() == "")
            {
                this.ShowMessage("�������������");
                txtContext.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// ��������ϸ
        /// </summary>
        public override void BindGridDts()
        {
            MSGMessageDtsRule rule = new MSGMessageDtsRule();
            DataTable dtDts = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            gridView1.GridControl.DataSource = dtDts;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            MSGMessageRule rule = new MSGMessageRule();
            MSGMessage entity = EntityGet();
            MSGMessageDts[] entitydts = EntityDtsGet();
            //entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RAdd(entity, entitydts);
            return entity.ID;       
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            MSGMessageRule rule = new MSGMessageRule();
            MSGMessage entity = EntityGet();
            MSGMessageDts[] entitydts = EntityDtsGet();
            //entity.SubmitFlag = this.HTSubmitFlagInsertGet();
            rule.RUpdate(entity, entitydts);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            MSGMessage entity = new MSGMessage();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtContext.Text = entity.Context.ToString(); 
            //txtMesPhone.Text = entity.MesPhone.ToString(); 
            //txtMesMakeOPID.Text = entity.MesMakeOPID.ToString(); 
  			txtTargetOPID.Text = entity.TargetOPID.ToString(); 
  			txtMesTime.DateTime = entity.MesTime; 
  			//txtMSID.Text = entity.MSID.ToString();

            string sql = "SELECT * FROM SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
            sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.�Զ���);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbSendShow.Text = "�ѷ���";
            }
            else
            {
                lbSendShow.Text = "δ����";
            }

            if (!findFlag)
            {
              
            }
            BindGridDts();
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            MSGMessageRule rule = new MSGMessageRule();
            MSGMessage entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
            ProcessCtl.ProcControlEdit(groupControlDataList, p_Flag);
        }

        /// <summary>
        /// �������ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniInsertSet()
        {      
            txtMesTime.DateTime = DateTime.Now.Date;
            txtTargetOPID.Text = FParamConfig.LoginName;
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "SMS_MSGMessage";
            this.HTDataDts = gridView1;
            Common.BindPhone(drpMakeOPIDDts, true);
            this.HTCheckDataField = new string[] { "MesMakeOPIDDts", "MesPhoneDts" };//������ϸУ�����¼���ֶ�
            this.ToolBarItemAdd(32, "btnSend", "���Ͷ���", true, btnSend_Click, eShortcut.F9);
            this.ToolBarItemAdd(32, "btnCancelSend", "ȡ������", true, btnCancelSend_Click, eShortcut.F9);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private MSGMessage EntityGet()
        {
            MSGMessage entity = new MSGMessage();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Context = txtContext.Text.Trim(); 
            //entity.MesPhone = txtMesPhone.Text.Trim(); 
            //entity.MesMakeOPID = txtMesMakeOPID.Text.Trim(); 
  			entity.TargetOPID = txtTargetOPID.Text.Trim(); 
  			entity.MesTime = txtMesTime.DateTime.Date; 
  			//entity.MSID = SysConvert.ToInt32(txtMSID.Text.Trim()); 
  			
            return entity;
        }
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private MSGMessageDts[] EntityDtsGet()
        {

            int index = GetDataCompleteNum();
            MSGMessageDts[] entitydts = new MSGMessageDts[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (CheckDataCompleteDts(i))
                {
                    if (CheckDataCompleteDts(i))
                    {
                        entitydts[index] = new MSGMessageDts();
                        entitydts[index].MainID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "MainID"));
                        if (entitydts[index].MainID == HTDataID && HTDataID != 0)//�Ѵ��ڱ�ʾ�޸�
                        {
                            entitydts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                            entitydts[index].SelectByID();
                        }
                        else//����
                        {
                            entitydts[index].MainID = HTDataID;
                            entitydts[index].Seq = i + 1;
                        }
                        entitydts[index].MesMakeOPIDDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "MesMakeOPIDDts"));
                        entitydts[index].MesPhoneDts = SysConvert.ToString(gridView1.GetRowCellValue(i, "MesPhoneDts"));
                        index++;
                    }
                }              
            }
            return entitydts;
        }


        #endregion

        //private void txtMesMakeOPID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string sql = "SELECT Phone FROM Data_MsgPhone WHERE Name =" + SysString.ToDBString(txtMesMakeOPID.Text.Trim());
        //        DataTable dt = new DataTable();
        //        dt = SysUtils.Fill(sql);
        //        if (dt.Rows.Count != 0)
        //        {
        //            txtMesPhone.Text = SysConvert.ToString(dt.Rows[0]["Phone"]);
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}


        #region ���ͺ�ȡ��
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTDataID == 0)
                {
                    this.ShowMessage("�뱣�����ݺ��Ͷ���Ϣ��");
                    return;
                }

                MSGMainRule rule = new MSGMainRule();
                MSGMain entity = new MSGMain();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    entity.FormDate = DateTime.Now;
                    entity.InsertTime = DateTime.Now;
                    entity.MSGSourceID = (int)EnumMSGSource.�Զ���;
                    entity.SendPhone = "13916054226";
                    entity.TaregtInfo = SysConvert.ToString(gridView1.GetRowCellValue(i, "MesMakeOPIDDts"));
                    entity.TargetPhone = SysConvert.ToString(gridView1.GetRowCellValue(i, "MesPhoneDts"));

                    //entity.TargetPhone = txtMesPhone.Text.Trim();
                    //entity.TaregtInfo = txtMesMakeOPID.Text.Trim();

                    entity.SendTime = DateTime.Now;

                    entity.Context = txtContext.Text.Trim();
                    entity.SendDesc = "��Դ���Զ��巢��";
                    entity.SendInfo += ",�����ˣ�" + txtTargetOPID.Text.Trim();
                    entity.DID = HTDataID;
                    rule.RAdd(entity);
                }

                this.ShowInfoMessage("���ͳɹ���");
                lbSendShow.Text = "�ѷ���";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnCancelSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��2))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                string sql = "SELECT * FROM SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.�Զ���);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    this.ShowMessage("��Ϣ��δ���ͣ�");
                    return;
                }
                sql = "SELECT * FROM SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.�Զ���);
                sql += " AND ISNULL(SendFlag,0)=1";
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    this.ShowMessage("��Ϣ�ѷ��͸��ͻ���ȡ����Ч��");
                    return;
                }

                sql = "DELETE SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.�Զ���);
                SysUtils.ExecuteNonQuery(sql);
                this.ShowMessage("ȡ���ɹ���");
                lbSendShow.Text = "δ����";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (e.Column.FieldName == "MesMakeOPIDDts")
                    {
                        string sql = "SELECT Phone FROM Data_MsgPhone WHERE Name =" + SysString.ToDBString(SysConvert.ToString(gridView1.GetRowCellValue(i, "MesMakeOPIDDts")));
                        DataTable dt = new DataTable();
                        dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            gridView1.SetRowCellValue(i, "MesPhoneDts", dt.Rows[0]["Phone"]);
                        }
                    }
                  
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }      
     
    }
}