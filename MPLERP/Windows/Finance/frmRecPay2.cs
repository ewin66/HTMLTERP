using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmRecPay2 : frmAPBaseUIForm
    {
        public frmRecPay2()
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
           
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }

            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }
            if (this.FormListAID != 0)
            {
                tempStr += " AND RecPayTypeID=" + this.FormListAID;
            }
            if(SysConvert.ToInt32(drpRecPayType.EditValue)!=0)
            {
                tempStr += " AND RecPayTypeID=" + SysConvert.ToInt32(drpRecPayType.EditValue);

            }
            //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��2))
            //{
            //    tempStr += " AND RecPayTypeID=" + SysString.ToDBString((int)EnumRecPayType.�տ�);
            //}
            //if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��3))
            //{
            //    tempStr += " AND RecPayTypeID=" + SysString.ToDBString((int)EnumRecPayType.����);
            //}

            if (txtHTNo.Text.Trim() != "")
            {
                tempStr += " AND HTNo LIKE "+SysString.ToDBString("%"+txtHTNo.Text.Trim()+"%");
            }

            if (txtHTGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND HTGoodsCode LIKE "+SysString.ToDBString("%"+txtHTGoodsCode.Text.Trim()+"%");
            }

          
            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID IN (SELECT VendorID FROM Data_Vendor WHERE InSaleOP=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue)) + " )";
            }
            tempStr += " ORDER BY MakeDate DESC ";
           
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            RecPayRule rule = new RecPayRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("VFormNo", "'' VFormNo"));
            foreach (DataRow dr in dt.Rows)
            {
                dr["VFormNo"] = GetVFormNo(dr["HTNo"].ToString());
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private string GetVFormNo(string p_FormNo)
        {
            string VFormNo = "";
            string FormNoStr = "";
            string[] FormNo = p_FormNo.Split(' ');
            if(FormNo.Length>0)
            {
                for (int i = 0; i < FormNo.Length; i++)
                {
                    if (FormNoStr != string.Empty)
                    {
                        FormNoStr += ",";
                    }
                    FormNoStr +=SysString.ToDBString(FormNo[i]);
                }
                string sql = "SELECT CustomerCode FROM Sale_SaleOrder WHERE FormNo IN ("+FormNoStr+")";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        VFormNo += SysConvert.ToString(dt.Rows[i][0])+" ";
                    }
                }
            }
            return VFormNo;

        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            RecPayRule rule = new RecPayRule();
            RecPay entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            //ProcessGrid.BindGridColumn(gridView1, this.FormID);
            //ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);
       
     
            this.HTDataTableName = "Finance_RecPay";
            this.HTDataList = gridView1;

            Common.BindRecPayType(drpRecPayType, true);
            Common.BindOP(drpSaleOPID, true);


            if (this.FormListAID == (int)EnumRecPayType.�տ�)
            {
                drpRecPayType.EditValue = (int)EnumRecPayType.�տ�;
                drpRecPayType.Properties.ReadOnly = true;
                DevMethod.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            }
            else if (this.FormListAID == (int)EnumRecPayType.����)
            {
                drpRecPayType.EditValue = (int)EnumRecPayType.����;
                drpRecPayType.Properties.ReadOnly = true;
                DevMethod.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
            }
            else
            {
                DevMethod.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.����, (int)EnumVendorType.������, (int)EnumVendorType.��ݹ�˾, (int)EnumVendorType.������˾, (int)EnumVendorType.��Ӧ�� }, true);
            }
        
            //new VendorProc(drpQVendorID);
   

            txtQMakeDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQMakeDateE.DateTime = DateTime.Now;

        }

        

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private RecPay EntityGet()
        {
            RecPay entity = new RecPay();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region ���ٲ�ѯ
        private void txtMakeOPName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}