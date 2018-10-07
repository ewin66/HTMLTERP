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
    public partial class frmPackBoxRpt : frmAPBaseUIRpt
    {
        public frmPackBoxRpt()
        {
            InitializeComponent();//
        }


        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtBoxNo.Text.Trim() != "")
            {
                tempStr += " AND BoxNo LIKE " + SysString.ToDBString("%" + txtBoxNo.Text.Trim() + "%");
            }
            //if (chkItemDate.Checked)
            //{
            //    tempStr += " AND CreateTime BETWEEN " + SysString.ToDBString(txtCreateTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtCreateTimeE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            //}
            if (FormListAID != 0)
            {
                tempStr += " AND BoxStatusID=" + SysString.ToDBString(FormListAID);
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");//
            }

            tempStr += " AND BoxStatusID=" + this.FormListAID;
            tempStr += " AND (ISNULL(Qty,0)>0 OR ISNULL(Weight,0)>0 OR ISNULL(Yard,0)>0)";
            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            PackBoxRule rule = new PackBoxRule();
            DataTable dt = rule.RUShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_PackBox";
            this.HTDataList = gridView1;
            //txtCreateTimeS.DateTime = DateTime.Now.AddMonths(-3).Date;
            //txtCreateTimeE.DateTime = DateTime.Now.Date;
            txtBoxNo.Focus();
            btnQuery_Click(null, null);
            //gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            //if (FormListAID != 0)
            //{
            //    chkIn.Visible = false;
            //}
            //if (FormListAID != 0)
            //{
            //    drpUseable.Visible = false;
            //    drpUseableFlag.Visible = false;
            //}
            //if (PackBoxStatusProc.ColorIniFlag)
            //{
            //    PackBoxStatusProc.ColorIniTextBox(new TextBox[] { txtColorSOStatus1, txtColorSOStatus2, txtColorSOStatus3 });
            //}


        }

        #endregion

 




        private void txtBoxNo_KeyDown(object sender, KeyEventArgs e)
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

       
    }
}