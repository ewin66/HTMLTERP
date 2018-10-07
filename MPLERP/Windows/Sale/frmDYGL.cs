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
    public partial class frmDYGL : frmAPBaseUISin
    {
        public frmDYGL()
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

            if (txtShopID.Text.Trim() != string.Empty)
            {
                tempStr += " AND ShopID LIKE "+SysString.ToDBString("%"+txtShopID.Text.Trim()+"%");
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (txtVendorID.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE "+SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }

            if (txtSaleOPName.Text.Trim() != string.Empty)
            {
                tempStr+=" AND OPName LIKE "+SysString.ToDBString("%"+txtSaleOPName.Text.Trim()+"%");
            }

            if(SysConvert.ToString(drpDYStatusID.EditValue)!=string.Empty)
            {
                tempStr+=" AND DYStatusID="+SysString.ToDBString(SysConvert.ToInt32(drpDYStatusID.EditValue));
            }

            if(drpDYXZ.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DYXZ="+SysString.ToDBString(drpDYXZ.Text.Trim());
            }

            if (chkINDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime) + " AND " + SysString.ToDBString(txtQIndateE.DateTime);
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            DYGLRule rule = new DYGLRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            DYGLRule rule = new DYGLRule();
            DYGL entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_DYGL";
            this.HTDataList = gridView1;
            Common.BindCLS(drpDYXZ, "Sale_DYGL", "DYXZ", true);
            Common.BindDYStatus(drpDYStatusID, true);
            txtQIndateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQIndateE.DateTime = DateTime.Now.Date;
            if (GBDYStatusProc.ColorIniFlag)
            {
                GBDYStatusProc.ColorIniTextBox(new TextBox[] { txtColorStatus1, txtColorStatus2, txtColorStatus3});
            }
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

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private DYGL EntityGet()
        {
            DYGL entity = new DYGL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "DYName")
                {
                    e.Appearance.BackColor = GBDYStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "DYName")));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
    }
}