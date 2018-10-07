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
    /// 功能：财务利润表
    /// 
    /// </summary>
    public partial class frmFinanceRpt2 : frmAPBaseUIRpt
    {
        public frmFinanceRpt2()
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
          

            //if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            //{
            //    tempStr += " AND DtsSaleOPID=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            //}

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }
         
           
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = "select ID,Name ItemClassName,0.0 AmountKG,0.0 AmountM,0.0 TotalAmount from Data_ItemClass where 1=1";
            sql += " AND ItemTypeID=1";//面料类
            DataTable dt = SysUtils.Fill(sql);

            ProcDataTable(dt);

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void ProcDataTable(DataTable p_dt)
        {
            string sql = "Select Sum(ISNULL(Amount,0)) Amount,Unit,ItemClassName from UV1_WH_IOFormDts where 1=1";
            sql += " AND ISNULL(SubmitFlag,0)=1";
            sql += HTDataConditionStr;
            sql += " Group By ItemClassName,Unit";
            DataTable dtA = SysUtils.Fill(sql);
            foreach (DataRow dr in p_dt.Rows)
            {
                if (dtA.Rows.Count != 0)
                {
                    for (int i = 0; i < dtA.Rows.Count; i++)
                    {
                        if (SysConvert.ToString(dr["ItemClassName"]) == SysConvert.ToString(dtA.Rows[i]["ItemClassName"]))
                        {
                            if (SysConvert.ToString(dtA.Rows[i]["Unit"]) == "KG")
                            {
                                dr["AmountKG"] = SysConvert.ToDecimal(dtA.Rows[i]["Amount"]);
                            }
                            if (SysConvert.ToString(dtA.Rows[i]["Unit"]) == "M")
                            {
                                dr["AmountM"] = SysConvert.ToDecimal(dtA.Rows[i]["Amount"]);
                            }
                        }
                    }
                }

                dr["TotalAmount"] = SysConvert.ToDecimal(dr["AmountKG"]) + SysConvert.ToDecimal(dr["AmountM"]);//合计金额
            }
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.供应商, (int)EnumVendorType.染厂, (int)EnumVendorType.加工户, (int)EnumVendorType.织厂, (int)EnumVendorType.其他加工厂 }, true);
            new VendorProc(drpVendorID);
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            int AID = 0;
            int BID = 0;
            if (this.FormListAID == (int)EnumWHType.原料仓库)
            {
                AID = 13;
                BID = 14;
            }
            else if (this.FormListAID == (int)EnumWHType.面料仓库)
            {
                AID = 11;
                BID = 12;
            }
            else if (this.FormListAID == (int)EnumWHType.坯布仓库)
            {
                AID = 15;
                BID = 16;
            }
            else if (this.FormListAID == (int)EnumWHType.辅料仓库)
            {
                AID = 17;
                BID = 18;
            }
            Common.BindSubType(drpSubType, new int[] {AID,BID}, true);
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            Common.BindOP(drpSaleOPID, true);
            btnQuery_Click(null, null);
            
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;      
            return entity;
        }


     

      
        
        #endregion

        

        #region 检索相关方法

        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
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


        /// <summary>
        /// 快速查询(值改变即检索)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //GetCondtion();
                //BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 快速查询(回车即检索)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetCondtion();
                    BindGrid();
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