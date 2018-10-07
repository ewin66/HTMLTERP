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
    public partial class frmItemTestForm : frmAPBaseUIForm
    {
        public frmItemTestForm()
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo  LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtGoodsCode.Text != string.Empty)
            {
                tempStr += "AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%"); 
            }
            if (txtTestContext.Text != string.Empty)
            {
                tempStr += "AND TestContext LIKE " + SysString.ToDBString("%" + txtTestContext.Text.Trim() + "%"); 
            }
            if (txtColorNum.Text != string.Empty)
            {
                tempStr += "AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%"); 
            }
            if (txtItemCode.Text != string.Empty)
            {
                tempStr += "AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if (SysConvert.ToString(drpCheckComID.EditValue) != "")
            {
                tempStr += " AND CheckComID = " + SysString.ToDBString(SysConvert.ToString(drpCheckComID.EditValue));//
            }
            if (txtItemName.Text != string.Empty)
            {
                tempStr += "AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
            }
            if (chkJSTime.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
            if (chkJSFlag.Checked)
            {
                tempStr += " AND ISNULL(JSFlag,0)=1";
            }
            if (chkNOJSFlag.Checked)
            {
                tempStr += " AND ISNULL(JSFlag,0)=0";
            }
            if (chkUseFlag.Checked)
            {
                tempStr += " AND SendDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddYears(-1).Date) + " AND " + SysString.ToDBString(DateTime.Now.Date); ;
            }
            if (txtBGType.Text.Trim() != "")
            {
                tempStr += " AND BGType="+SysString.ToDBString(txtBGType.Text.Trim());
            }
            if (txtBGNo.Text.Trim() != "")
            {
                tempStr += " AND BGNo LIKE "+SysString.ToDBString("%"+txtBGNo.Text.Trim()+"%");
            }
            string csitem = GetCheckCSItem(chkLamp1);
            if (csitem != "")
            {
                string[] testcontext = csitem.Split(',');
               
                for (int i = 0; i < testcontext.Length; i++)
                {
                    tempStr += " AND TestContext LIKE " + SysString.ToDBString("%" + testcontext[i].ToString() + "%");
                }
               
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemTestFormRule rule = new ItemTestFormRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("UseFlag", "0 UseFlag").Replace("TestItemName","'' TestItemName"));
            AddUseFlag(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void AddUseFlag(DataTable p_dt)
        {
           
            foreach (DataRow dr in p_dt.Rows)
            {
                if (SysConvert.ToDateTime(dr["SendDate"]) < DateTime.Now.AddYears(-1).Date)
                {
                    dr["UseFlag"] = 0;
                }
                else
                {
                    dr["UseFlag"] = 1;
                }
                dr["TestItemName"] = GetTestItemName(SysConvert.ToString(dr["TestContext"]));
            }
        }

        private string GetTestItemName(string p_TestContext)
        {
            if (p_TestContext != "")
            {
                string[] TestContext = p_TestContext.Split(',');
                string TestItemName = "";
                for (int i = 0; i < TestContext.Length; i++)
                {
                    if (TestItemName != "")
                    {
                        TestItemName += ",";
                    }
                    TestItemName +=GetCSItem(SysConvert.ToInt32(TestContext[i]));
                   
                }
                return TestItemName;

            }
           
            return "";
            
        }

        private string GetCSItem(int p_CSID)
        {
            string sql = "SELECT Name FROM Data_CSBGItem WHERE ID="+SysString.ToDBString(p_CSID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            ItemTestFormRule rule = new ItemTestFormRule();
            ItemTestForm entity = EntityGet();
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
            this.HTDataTableName = "Att_ItemTestForm";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
            Common.BindVendor(drpCheckComID, new int[] { (int)EnumVendorType.检测机构 }, true);
            new VendorProc(drpCheckComID);
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindCSBGItem(chkLamp1, true);
            Common.BindCLS(txtBGType, "Attn_ItemTestForm", "BGType", true);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemTestForm EntityGet()
        {
            ItemTestForm entity = new ItemTestForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtGoodsCode_EditValueChanged(object sender, EventArgs e)
        {
            GetCondtion();
            BindGrid();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                DateTime SendDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, "SendDate"));
                string sql = "SELECT DATEDIFF(DAY," +SysString.ToDBString(SendDate)+","+SysString.ToDBString(DateTime.Now.Date)+") AS DateD";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    if (SysConvert.ToInt32(dt.Rows[0][0]) > 365)
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                }

                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void chkLamp1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                string outstr = string.Empty;
                string outValue = string.Empty;
                for (int i = 0; i < chkLamp1.ItemCount; i++)
                {
                    if (chkLamp1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        if (outstr != string.Empty)
                        {
                            outstr += ",";
                            outValue += ",";
                        }
                        outstr += chkLamp1.GetItemText(i).ToString();
                        outValue += chkLamp1.GetItemValue(i).ToString();
                    }
                }
                drpLamp1.EditValue = outstr;
              
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 获取测试内容
        /// </summary>
        /// <param name="p_CheckList"></param>
        /// <returns></returns>
        private string GetCheckCSItem(DevExpress.XtraEditors.CheckedListBoxControl p_CheckList)
        {
            string MLLB = string.Empty;
            for (int i = 0; i < p_CheckList.ItemCount; i++)
            {
                if (p_CheckList.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (MLLB == string.Empty)
                    {
                        MLLB += p_CheckList.GetItemValue(i).ToString();
                    }
                    else
                    {
                        MLLB += "," + p_CheckList.GetItemValue(i).ToString();
                    }

                }
            }
            return MLLB;
        }

        
    }
}