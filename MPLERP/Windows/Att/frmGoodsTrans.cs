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
    public partial class frmGoodsTrans : frmAPBaseUIForm
    {
        public frmGoodsTrans()
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

            if (chkJSDate.Checked)
            {
                tempStr += " AND JSDate BETWEEN " + SysString.ToDBString(txtJSDateS.DateTime) + " AND " + SysString.ToDBString(txtJSDateE.DateTime);
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
      
            if (SysConvert.ToString(drpShopID.EditValue) != "")
            {
                tempStr += " AND ShopID = " + SysString.ToDBString(SysConvert.ToString(drpShopID.EditValue));
            }
            if (SysConvert.ToString(drpResive.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpResive.EditValue));
            }
            if (SysConvert.ToString(drpTransComID.EditValue) != "")
            {
                tempStr += " AND TransComID = " + SysString.ToDBString(SysConvert.ToString(drpTransComID.EditValue));
            }
            //if (chkJSFlag.Checked)
            //{
            //    tempStr += " AND JSFlag=1";
            //}
            //if (chkNOJSFlag.Checked)
            //{
            //    tempStr += " AND ISNULL(JSFlag,0)=0";
            //}
            //if (chkFHDFlag.Checked)
            //{
            //    tempStr += " AND FHDFlag=1";
            //}
            //if (chkYSFlag.Checked)
            //{
            //    tempStr += " AND YSFlag=1";
            //}
            if (txtSendNo.Text.Trim() != "")
            {
                tempStr += " AND SendNo LIKE "+SysString.ToDBString("%"+txtSendNo.Text.Trim()+"%");
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            GoodsTransRule rule = new GoodsTransRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();

           
        }

       

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            GoodsTransRule rule = new GoodsTransRule();
            GoodsTrans entity = EntityGet();
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
            this.HTDataTableName = "Att_GoodsTrans";
            this.HTDataList = gridView1;
           // this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            txtJSDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtJSDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpTransComID, new int[] { (int)EnumVendorType.快递公司 }, true);
            new VendorProc(drpTransComID);
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.工厂 }, true);
            new VendorProc(drpShopID);
            Common.BindVendor(drpResive, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpResive);
            txtFHDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFHDateE.DateTime = DateTime.Now.Date;


        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private GoodsTrans EntityGet()
        {
            GoodsTrans entity = new GoodsTrans();
            entity.ID = HTDataID;      
            return entity;
        }

        
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
       

        #endregion

        private void chkJSFlag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (chkJSFlag.Checked)
                {
                    chkNOJSFlag.Checked = false;
                }
                else
                {
                    chkNOJSFlag.Checked=true;
                }
                txtFormNo_EditValueChanged(null, null);
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void chkNOJSFlag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if(chkNOJSFlag.Checked)
                {
                    chkJSFlag.Checked=false;
                }
                else
                {
                    chkJSFlag.Checked=true;
                }
                txtFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

        

       

      
    }
}