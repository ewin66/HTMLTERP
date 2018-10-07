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
    /// 功能：付款对账/未对账功能
    /// 
    /// </summary>
    public partial class frmPayCheckRpt : frmAPBaseUIRpt
    {
        public frmPayCheckRpt()
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
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 已对账
        /// </summary>
        public override  void BindGrid()
        {
            string sql = "select * from UV1_WH_IOFormDts where 1=1";
            sql += " AND ISNULL(SubmitFlag,0)=1";
            sql += " AND DZFlag=1";
            sql += " AND FormDZFlag<>0";//对账正的数据
            sql += " AND FormDZType in(1,2)";// 加工、采购对账
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);


            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();


            BindGrid1();
        }

        /// <summary>
        /// 未对账
        /// </summary>
        private void BindGrid1()
        {
            string sql = "select * from UV1_WH_IOFormDts where 1=1";
            sql += " AND ISNULL(SubmitFlag,0)=1";
            sql += " AND DZFlag=0";
            sql += " AND FormDZFlag<>0";//对账正的数据
            sql += " AND FormDZType in(1,2)";// 加工、采购对账
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);


            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
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
            this.HTDataTableName = "WH_IOFormDts";
            this.HTDataList = gridView1;//列表格式设置
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };//列表格式设置
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpVendorID);
            txtQFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQFormDateE.DateTime = DateTime.Now.Date;
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

//导出列表方法重写        
        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {

                if (xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    //this.ToExcel(HTDataList);
                    this.ToExcelSelectColumn(gridView1);
                }
                if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    //this.ToExcel(gridView2);
                    this.ToExcelSelectColumn(gridView2);
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