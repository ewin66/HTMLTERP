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
///
///����÷ 2012 .05.02 ����
///  
namespace MLTERP
{
    public partial class frmGoodsPost2Edit : frmAPBaseUIFormEdit
    {
        public frmGoodsPost2Edit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("���������");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            GoodsPostRule rule = new GoodsPostRule();
            GoodsPost entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            GoodsPostRule rule = new GoodsPostRule();
            GoodsPost entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            GoodsPost entity = new GoodsPost();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtFormNo.Text = entity.FormNo.ToString(); 
  			txtMakeDate.DateTime = entity.MakeDate; 
  			txtPostCode.Text = entity.PostCode.ToString(); 
  			txtRecName.Text = entity.RecName.ToString(); 
  			txtRecPhone.Text = entity.RecPhone.ToString(); 
  			txtPostFee.Text = entity.PostFee.ToString();
            drpVendorID.EditValue = entity.VendorID;
  			txtRecAddress.Text = entity.RecAddress.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpJSFlag.EditValue = entity.JSFlag;
  			txtJSDate.DateTime = entity.JSDate; 
  			txtJSFee.Text = entity.JSFee.ToString(); 
  			txtJSRemark.Text = entity.JSRemark.ToString();
            drpPostComID.EditValue = entity.PostComID;
            txtFJR.Text = entity.FJR.ToString();
            txtPostType.Text = entity.PostType.ToString();
            drpGOFlag.EditValue = entity.GOFlag;
            txtFKType.Text = entity.SKType.ToString();
            txtJJVendor.Text = entity.JJVendor.ToString();
            if (!findFlag)
            {
              
            }
            string sql = "SELECT * FROM SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
            sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.��ݵ�);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                lbSendShow.Text = "�ѷ���";
            }
            else
            {
                lbSendShow.Text = "δ����";
            }
           
        }



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            GoodsPostRule rule = new GoodsPostRule();
            GoodsPost entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_GoodsPost";
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);
            new VendorProc(drpVendorID);
            Common.BindVendor(drpPostComID, new int[] { (int)EnumVendorType.��ݹ�˾ }, true);
            new VendorProc(drpPostComID);
            Common.BindCLS(txtPostType, "Att_GoodsPost", "PostType", true);
            Common.BindCLS(txtFKType, "Att_GoodsPost", "SKType", true);
            drpVendorID_EditValueChanged(null, null);
            txtPostType.EditValue = "�ĳ�";
            this.ToolBarItemAdd(32, "btnSend", "���Ͷ���", true, btnSend_Click, eShortcut.F9);
            this.ToolBarItemAdd(32, "btnCancelSend", "ȡ������", true, btnCancelSend_Click, eShortcut.F9);
            //
            drpVendorID_EditValueChanged(null, null);

        }

        /// <summary>
        /// ������ʼ��
        /// </summary>
        public override void IniInsertSet()
        {
            txtJSDate.DateTime = DateTime.Now.Date;
            txtMakeDate.DateTime = DateTime.Now.Date;
            txtFormNo_DoubleClick(null, null);
            txtFJR.Text = FParamConfig.LoginName;
            txtJJVendor.Text = "�����ؾ޸߷�֯Ʒ���޹�˾";
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GoodsPost EntityGet()
        {
            GoodsPost entity = new GoodsPost();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.FormNo = txtFormNo.Text.Trim();
            entity.MakeOPID = FParamConfig.LoginID;
            entity.MakeOPName = FParamConfig.LoginName;
  			entity.MakeDate = txtMakeDate.DateTime.Date;

            entity.PostComID = SysConvert.ToString(drpPostComID.EditValue);
  			entity.PostCode = txtPostCode.Text.Trim(); 
  			entity.RecName = txtRecName.Text.Trim(); 
  			entity.RecPhone = txtRecPhone.Text.Trim(); 
  			entity.PostFee = SysConvert.ToDecimal(txtPostFee.Text.Trim());
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.RecAddress = txtRecAddress.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.JSFlag = SysConvert.ToInt32(drpJSFlag.EditValue); 
  			entity.JSDate = txtJSDate.DateTime.Date; 
  			entity.JSFee = SysConvert.ToDecimal(txtJSFee.Text.Trim()); 
  			entity.JSRemark = txtJSRemark.Text.Trim();

            entity.GOFlag = SysConvert.ToInt32(drpGOFlag.EditValue);
            entity.PostType = txtPostType.Text.Trim();
            entity.SKType = txtFKType.Text.Trim();
            entity.FJR = txtFJR.Text.Trim();

            entity.JJVendor = txtJJVendor.Text.Trim();
            return entity;
        }
        #endregion

        #region ��������
        /// <summary>
        /// �õ��ջ���λ��ַ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {
                    string SHVendorID = SysConvert.ToString(drpVendorID.EditValue);
                    Common.BindVendorAddress(txtRecAddress, SHVendorID, true);
                    //Common.BindVendorHisAddress(txtRecAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                    string sql = "SELECT * FROM Data_Vendor WHERE 1=1 ";
                    sql += " AND VendorID=" + SysString.ToDBString(SHVendorID);
                    sql += " AND VendorTypeID IN (1,2)";//+ (int)EnumVendorType.�ͻ�;
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 1)
                    {
                        txtRecName.Text = dt.Rows[0]["Contact"].ToString();
                        txtRecPhone.Text = dt.Rows[0]["Tel"].ToString();

                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        /// <summary>
        /// ˫�����ɿ�ݵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            
                FormNoControlRule rule = new FormNoControlRule();
                txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��ݵ���);
            
        }
        #endregion

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

                if (txtRecPhone.Text.Trim() == "")
                {
                    this.ShowMessage("�������ռ��˺���������Ͷ���Ϣ��");
                    return;
                }
                if (txtRecPhone.Text.Trim().Length != 11)
                {
                    this.ShowMessage("��������ȷ���ռ��˺���������Ͷ���Ϣ��");
                    return;
                }
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��2))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                MSGMainRule rule = new MSGMainRule();
                MSGMain entity = new MSGMain();
                entity.FormDate = DateTime.Now;
                entity.InsertTime = DateTime.Now;
                entity.MSGSourceID = (int)EnumMSGSource.��ݵ�;
                entity.SendPhone = "13916054226";
                entity.TargetPhone = txtRecPhone.Text.Trim();
                entity.TaregtInfo = txtRecName.Text.Trim();
                entity.SendTime = DateTime.Now;
                string Context = "";
                Context += "�𾴵Ŀͻ������ã����Ŀ���Ѽĳ�����ݹ�˾��";
                Context +=Common.GetVendorNameByVendorID(drpPostComID.EditValue.ToString());
                Context += ",��ݵ��ţ�";
                Context += txtPostCode.Text.Trim();
                Context += "��ע����գ���������������021-51095188.   �Ϻ����ȷ�֯Ʒ���޹�˾";
                entity.Context = Context;
                entity.SendDesc = "��Դ����ݹ������ţ�" + txtFormNo.Text.Trim() + ",�ջ���λ��" + Common.GetVendorNameByVendorID(drpVendorID.EditValue.ToString());
                entity.SendInfo += ",�����ˣ�"+txtFJR.Text.Trim();
                entity.DID = HTDataID;
                rule.RAdd(entity);
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
                string sql = "SELECT * FROM SMS_MSGMain WHERE DID="+SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID="+SysString.ToDBString((int)EnumMSGSource.��ݵ�);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count ==0)
                {
                    this.ShowMessage("��Ϣ��δ���ͣ�");
                    return;
                }
                sql = "SELECT * FROM SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.��ݵ�);
                sql += " AND ISNULL(SendFlag,0)=1";
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    this.ShowMessage("��Ϣ�ѷ��͸��ͻ���ȡ����Ч��");
                    return;
                }

                sql = "DELETE SMS_MSGMain WHERE DID=" + SysString.ToDBString(HTDataID);
                sql += " AND MSGSourceID=" + SysString.ToDBString((int)EnumMSGSource.��ݵ�);
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

        /// <summary>
        /// ������ݹ�˾������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpPostComID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string PostVendorID = drpPostComID.EditValue.ToString();
                if (PostVendorID != string.Empty)
                {
                    string sql = "SELECT * FROM Data_Vendor WHERE 1=1 ";
                    sql += " AND VendorID=" + SysString.ToDBString(PostVendorID);
                    sql += " AND VendorTypeID=" + (int)EnumVendorType.��ݹ�˾;
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count == 1)
                    {
                        txtRecName.Text = dt.Rows[0]["Contact"].ToString();
                        txtRecPhone.Text = dt.Rows[0]["Tel"].ToString();

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