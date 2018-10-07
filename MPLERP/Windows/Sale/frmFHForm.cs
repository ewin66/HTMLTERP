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
    public partial class frmFHForm : frmAPBaseUIForm
    {
        public frmFHForm()
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
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (txtSendCode.Text.Trim() != "")//��ѯd
            {
                tempStr = " AND SendCode LIKE " + SysString.ToDBString("%" + txtSendCode.Text.Trim() + "%");
            }

            if ( SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID =" + SysString.ToDBString(drpQVendorID.EditValue.ToString());
            }

            if (ChkSendDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue)!="")
            {
                tempStr += " AND SaleOPID  =" + SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//���۶���ҵ��Աֻ�鿴�Լ��ĵĶ���
            {
                tempStr += " AND SaleOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE"+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if(txtColorNum.Text.Trim()!="")
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }
            if(SysConvert.ToInt32(drpFHTypeID.EditValue)!=0)
            {
                tempStr += " AND FHTypeID="+SysString.ToDBString(SysConvert.ToInt32(drpFHTypeID.EditValue));
            }
          
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FHFormRule rule = new FHFormRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SendName", "'' SendName"));
            proDatable(dt);
            //if (chkStatus.Checked)
            //{
            //    proDatable(dt);
            //}
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void proDatable(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToInt32(dr["DtsSendFlag"]) == (int)YesOrNo.Yes)
                {
                    dr["SendName"] = "�ѷ���";//GetFHStatus(dr["FormNo"].ToString(), dr["ItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString());
                }
                else
                {
                    dr["SendName"] = "δ����";
                }
            }
        }
        //private void proDatable(DataTable dt)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        dr["SendName"]=GetFHStatus(dr["FormNo"].ToString(),dr["ItemCode"].ToString(),dr["ColorNum"].ToString(),dr["ColorName"].ToString());
               
        //    }

        //}

        //private string GetFHStatus(string p_FormNo, string p_ItemCode, string p_ColorNum, string p_ColorName)
        //{
        //    string sql = "SELECT * FROM UV1_WH_IOFormDts WHERE DtsSO="+SysString.ToDBString(p_FormNo);
        //    sql += " AND ItemCode="+SysString.ToDBString(p_ItemCode);
        //    sql += " AND ColorNum="+SysString.ToDBString(p_ColorNum);
        //    sql += " AND ColorName="+SysString.ToDBString(p_ColorName);
        //    sql += " AND ISNULL(SubmitFlag,0)=1";
        //    sql += " AND SubType in (SELECT ID FROM Enum_FormList WHERE ParentID=12)";
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return "�ѷ���";
        //    }
        //    else
        //    {
        //        return "δ����";
        //    }
        //}

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FHFormRule rule = new FHFormRule();
            FHForm entity = EntityGet();
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
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            //Common.BindOP(drpSaleOPID, true);
            this.HTDataTableName = "Sale_FHForm";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;

            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//��֯�ṹ��ϵ����
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }

           // Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            DevMethod.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);//2015.4.8 CX�޸�
            Common.BindFHType(drpFHTypeID, true);
            txtQMakeDateS.DateTime = DateTime.Now.AddDays(-10).Date;
            txtQMakeDateE.DateTime = DateTime.Now;
            if (FHFormStatusProc.ColorIniFlag)
            {
                //FHFormStatusProc.ColorIniTextBox(new TextBox[] { txtColorStatus1, txtColorStatus2});
                ucStatusBarStand1.UCValueIni(FHFormStatusProc.ColorStatusName, FHFormStatusProc.ColorStatusColor);
                ucStatusBarStand1.UCAct();
            }

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FHForm EntityGet()
        {
            FHForm entity = new FHForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion



        #region �����¼�

        /// <summary>
        /// ��ɫ�仯 ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                base._HTDataDts_RowCellStyle(sender, e);
                if (e.Column.FieldName == "SendName")
                {
                    e.Appearance.BackColor = FHFormStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "SendName")));
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #endregion




    }
}