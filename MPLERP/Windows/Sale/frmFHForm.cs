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


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (txtSendCode.Text.Trim() != "")//查询d
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
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//销售订单业务员只查看自己的的订单
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
        /// 绑定Grid
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
                    dr["SendName"] = "已发货";//GetFHStatus(dr["FormNo"].ToString(), dr["ItemCode"].ToString(), dr["ColorNum"].ToString(), dr["ColorName"].ToString());
                }
                else
                {
                    dr["SendName"] = "未发货";
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
        //        return "已发货";
        //    }
        //    else
        //    {
        //        return "未发货";
        //    }
        //}

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            FHFormRule rule = new FHFormRule();
            FHForm entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
            //Common.BindOP(drpSaleOPID, true);
            this.HTDataTableName = "Sale_FHForm";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;

            if (ProductParamSet.GetIntValueByID(5020) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                Common.BindOPID(drpSaleOPID, "Sale_SaleOrder", "SaleOPID", true);
            }
            else
            {
                Common.BindOPID(drpSaleOPID, true);
            }

           // Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            DevMethod.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);//2015.4.8 CX修改
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

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private FHForm EntityGet()
        {
            FHForm entity = new FHForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion



        #region 其它事件

        /// <summary>
        /// 颜色变化 方法重载
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