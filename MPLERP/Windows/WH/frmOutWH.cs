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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmOutWH : frmAPBaseUIForm
    {
        public frmOutWH()
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
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND  ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtDtsOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND InOrderFormNo LIKE " + SysString.ToDBString("%" + txtDtsOrderFormNo.Text.Trim() + "%");
            }
            
            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtQFormDateS.DateTime)+" AND "+SysString.ToDBString(txtQFormDateE.DateTime);
            }

         

            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }


            if (txtQBoxNo.Text.Trim() != string.Empty)//条码查询
            {
                tempStr += " AND ID in(select MainID from WH_IOFormDtsPack where BoxNo =" + SysString.ToDBString(txtQBoxNo.Text.Trim()) + ")";
            }


            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }
            if (this.FormListAID != 0)
            {
                tempStr += " AND HeadType=" + this.FormListAID;
            }


            tempStr += Common.GetWHRightCondition();


            tempStr += " ORDER BY FormDate DESC,ID DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormRule rule = new IOFormRule();
            gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
            txtQFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQFormDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, this.FormListAID, true);
          
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户, (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpVendorID);
          
          

          //  this.ToolBarItemAdd(32, "btnScanOutWH", "扫描出库", true, btnScanOutWH_Click, eShortcut.F9);


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

      


        #region 扫描出库
        /// <summary>
        /// 扫描出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScanOutWH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.权限1))
                {
                    this.ShowMessage("没有此权限，请联系管理员");
                    return;
                }



            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void txtDtsOrderFormNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnQuery_Click(null, null);

                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }


    }
}