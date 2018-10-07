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
    public partial class frmCheckForm : frmAPBaseUIForm
    {
        public frmCheckForm()
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
            if (txtVendorID.Text.Trim() != "")
            {
                tempStr += " AND DVendorID LIKE " + SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }
            if (SysConvert.ToString(drpDHID.EditValue) != "")
            {
                tempStr += " AND DataDHID=" + SysString.ToDBString(SysConvert.ToString(drpDHID.EditValue));
            }
            if (txtFormCode.Text != "")
            {
                tempStr += " AND FormCode like" + SysString.ToDBString("%" + txtFormCode.Text.Trim() + "%");
            }
            if (txtDVendorName.Text.Trim() != "")
            {
                tempStr += " AND DVendorName LIKE " + SysString.ToDBString("%" + txtDVendorName.Text.Trim() + "%");
            }
            
            if (SysConvert.ToInt32(drpLevel.EditValue) != 0)
            {
                tempStr += " AND LevelID=" + SysString.ToDBString(SysConvert.ToInt32(drpLevel.EditValue));
            }
            if (ChkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime);
            }

            if (chkDYFlag.Checked)
            {

                tempStr += " AND ISNULL(DYFlag,0)=1";
            }
            tempStr += " AND ISNULL(FormTypeID,0)=" + this.FormListAID;

            tempStr += " Group BY ID,FormCode,FormDate,DataDHID,DVendorID,DRemark,SubmitName,Contact,InSaleOPName,VendorName,SubmitFlag,DVendorName";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {

            //Common.BindVendor(drpVendor, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);

            CheckFormRule rule = new CheckFormRule(); 
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("Num", "Count(Seq) Num"));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CheckFormRule rule = new CheckFormRule();
            CheckForm entity = EntityGet();
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
            this.HTDataTableName = "ADH_CheckForm";
            this.HTDataList = gridView1;

            txtQFormDateS.DateTime = SysConvert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            txtQFormDateE.DateTime = DateTime.Now.Date;

            Common.BindVendor(drpVendor, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            Common.BindDHID(drpDHID, this.FormListAID, false);
            Common.BindDH(drpDH, this.FormListAID, false);
            Common.BindOPID(drpSaleOPID, true);
            Common.BindADHLevel(drpLevel, true);
            new VendorProc(drpVendorID);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckForm EntityGet()
        {
            CheckForm entity = new CheckForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        private void txtFormCode_EditValueChanged(object sender, EventArgs e)
        {
            btnQuery_Click(null,null);
        }
        /// <summary>
        /// 颜色变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                //int WHFormTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "WHFormTypeID"));
                //e.Appearance.BackColor = InOutWHStatus.GetGridRowBackColor(WHFormTypeID);
                int posID = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "SubmitFlag"));
                if (posID == 0)
                {
                    e.Appearance.BackColor = txtInOutColor1.BackColor;
                }
                else if (posID == 1)
                {
                    e.Appearance.BackColor = txtInOutColor2.BackColor;
                }



            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

      
       

     
      
    }
}