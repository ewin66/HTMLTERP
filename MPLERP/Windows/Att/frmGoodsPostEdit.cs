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

///
namespace MLTERP
{
    public partial class frmGoodsPostEdit : frmAPBaseUISinEdit
    {
        public frmGoodsPostEdit()
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

            if (SysConvert.ToInt32(drpPostFormType.EditValue) == 0)
            {
                this.ShowMessage("��ѡ������Դ");
                drpPostFormType.Focus();
                return false;
            }

            if (SysConvert.ToString(drpVendorID.EditValue) == "")
            {
                this.ShowMessage("��ѡ���ջ���λ");
                drpVendorID.Focus();
                return false;
            }

            if (SysConvert.ToString(drpPostComID.EditValue) == "")
            {
                this.ShowMessage("��ѡ���ݹ�˾");
                drpPostComID.Focus();
                return false;
            }

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
            drpRecName.EditValue = entity.RecName.ToString();
            drpRecPhone.EditValue = entity.RecPhone.ToString(); 
  			txtPostFee.Text = entity.PostFee.ToString();
            drpVendorID.EditValue = entity.VendorID;
            drpRecAddress.EditValue = entity.RecAddress.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpJSFlag.EditValue = entity.JSFlag;
  			txtJSDate.DateTime = entity.JSDate; 
  			txtJSFee.Text = entity.JSFee.ToString(); 
  			txtJSRemark.Text = entity.JSRemark.ToString();
            drpPostComID.EditValue = entity.PostComID;
            drpPostComFirst.EditValue = entity.PostComFirst;
            txtFJR.Text = entity.FJR.ToString();
            txtPostType.Text = entity.PostType.ToString();
            drpGOFlag.EditValue = entity.GOFlag;
            txtFKType.Text = entity.SKType.ToString();
            drpJJVendor.EditValue = entity.JJVendor.ToString();

            drpPostFormType.EditValue =entity.PostFormType;
            txtContext.Text = entity.Context;
            txtConFormNo.Text = entity.ConFormNo;
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
            ProductCommon.FormNoCtlEditSet(txtFormNo, "Att_GoodsPost", "FormNo", 0, p_Flag);
            txtConFormNo.Properties.ReadOnly = true;
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Att_GoodsPost";
            
            Common.BindCLS(txtPostType, "Att_GoodsPost", "PostType", true);
            Common.BindCLS(txtFKType, "Att_GoodsPost", "SKType", true);
         //  drpVendorID_EditValueChanged(null, null);
            txtPostType.EditValue = "�ĳ�";
          //  this.ToolBarItemAdd(32, "btnSend", "���Ͷ���", true, btnSend_Click, eShortcut.F9);
           // this.ToolBarItemAdd(32, "btnCancelSend", "ȡ������", true, btnCancelSend_Click, eShortcut.F9);
            Common.BindPostFormType(drpPostFormType,true);
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
        }
        public override void IniRefreshData()
        {
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��Ӧ��, (int)EnumVendorType.֯��, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�����ӹ���, (int)EnumVendorType.���� }, true);
            new VendorProc(drpVendorID);
            Common.BindVendor(drpPostComID, new int[] { (int)EnumVendorType.��ݹ�˾ }, true);
            new VendorProc(drpPostComID);
            Common.BindVendor(drpPostComFirst, new int[] { (int)EnumVendorType.��ݹ�˾ }, true);
            new VendorProc(drpPostComFirst);
            Common.BindVendor(drpJJVendor, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��Ӧ��, (int)EnumVendorType.֯��, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�����ӹ���, (int)EnumVendorType.���� }, true);
            new VendorProc(drpJJVendor);
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
            entity.PostComFirst = SysConvert.ToString(drpPostComFirst.EditValue);
  			entity.PostCode = txtPostCode.Text.Trim(); 
  			entity.RecName = SysConvert.ToString(drpRecName.EditValue);
            entity.RecPhone = SysConvert.ToString(drpRecPhone.EditValue); 
  			entity.PostFee = SysConvert.ToDecimal(txtPostFee.Text.Trim());
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
            entity.RecAddress = SysConvert.ToString(drpRecAddress.EditValue);
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.JSFlag = SysConvert.ToInt32(drpJSFlag.EditValue); 
  			entity.JSDate = txtJSDate.DateTime.Date; 
  			entity.JSFee = SysConvert.ToDecimal(txtJSFee.Text.Trim()); 
  			entity.JSRemark = txtJSRemark.Text.Trim();

            entity.GOFlag = SysConvert.ToInt32(drpGOFlag.EditValue);
            entity.PostType = txtPostType.Text.Trim();
            entity.SKType = txtFKType.Text.Trim();
            entity.FJR = txtFJR.Text.Trim();

            entity.JJVendor = SysConvert.ToString(drpJJVendor.EditValue);

            entity.PostFormType = SysConvert.ToInt32(drpPostFormType.EditValue);
            entity.ConFormNo = txtConFormNo.Text.Trim();
            entity.Context = txtContext.Text.Trim();
            return entity;
        }
        #endregion

        #region ��������
        /// <summary>
        /// �õ��ջ���λ��ַ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        /// <summary>
        /// ˫�����ɿ�ݵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_DoubleClick(object sender, EventArgs e)
        {
            if (HTFormStatus == FormStatus.����)
            {
                //FormNoControlRule rule = new FormNoControlRule();
                //txtFormNo.Text = rule.RGetFormNo((int)FormNoControlEnum.��ݵ���);  
                ProductCommon.FormNoIniSet(txtFormNo, "Att_GoodsPost", "FormNo", 0);           
            }
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

                if (drpRecPhone.EditValue == "")
                {
                    this.ShowMessage("�������ռ��˺������������Ϣ��");
                    return;
                }
                if (drpRecPhone.EditValue.ToString().Length != 11)
                {
                    this.ShowMessage("��������ȷ���ռ��˺������������Ϣ��");
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
                entity.SendPhone = "***********";//���Ͷ��ź���
                entity.TargetPhone = SysConvert.ToString(drpRecPhone.EditValue);
                entity.TaregtInfo = SysConvert.ToString(drpRecName.EditValue);
                entity.SendTime = DateTime.Now;
                string Context = "";
                Context += "�𾴵Ŀͻ������ã����Ŀ���Ѽĳ�����ݹ�˾��";
                Context +=Common.GetVendorNameByVendorID(drpPostComID.EditValue.ToString());
                Context += ",��ݵ��ţ�";
                Context += txtPostCode.Text.Trim();
                Context += "��ע����գ��������������硣   �����ƺ��֯Ʒ���������޹�˾";
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
        /// ���ض�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConFormNo_DoubleClick(object sender, EventArgs e)
        {
             try
            {
                if (HTFormStatus == FormStatus.���� || HTFormStatus == FormStatus.�޸�)
                {
                    LoadSaleOrder();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void drpVendorID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
                {

                    Common.BindVendorContact(drpRecName, SysConvert.ToString(drpVendorID.EditValue), true);
                    Common.BindVendorAddress(drpRecAddress, SysConvert.ToString(drpVendorID.EditValue), true);
                   // Common.BindVendorHisAddress(drpRecAddress, SysConvert.ToString(drpVendorID.EditValue), true);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void LoadSaleOrder()
        {
            frmLoadOrder frm = new frmLoadOrder();
            frm.ShowDialog();
            string str = string.Empty;
            if (frm.OrderID != null && frm.OrderID.Length != 0)
            {
                for (int i = 0; i < frm.OrderID.Length; i++)
                {
                    if (str != string.Empty)
                    {
                        str += ",";
                    }
                    str += SysConvert.ToString(frm.OrderID[i]);
                }
                setItemNews(str);
            }
        }

        /// <summary>
        /// ���ض�������
        /// </summary>
        /// <param name="p_Str"></param>
        private void setItemNews(string p_Str)
        {
            string[] orderid = p_Str.Split(',');
            string sql = "SELECT FormNo,VendorID FROM  UV1_Sale_SaleOrderDts WHERE DtsID=" + SysString.ToDBString(SysConvert.ToInt32(orderid[0]));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count >0)
            {
               txtConFormNo.Text=SysConvert.ToString(dt.Rows[0]["FormNo"]);
               drpVendorID.EditValue = SysConvert.ToString(dt.Rows[0]["VendorID"]);
            }
        }

        private void drpRecName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToString(drpRecName.EditValue) != string.Empty)
                {
                    drpRecPhone.Text = Common.GetVendorContactTelByVendorContact(SysConvert.ToString(drpVendorID.EditValue), SysConvert.ToString(drpRecName.EditValue));
                    
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



    }
}