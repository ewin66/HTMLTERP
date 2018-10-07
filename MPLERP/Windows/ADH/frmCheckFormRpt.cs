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
    public partial class frmCheckFormRpt : frmAPBaseUIRpt
    {
        public frmCheckFormRpt()
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

            if (chkDYFlag.Checked)
            {

                tempStr += " AND ISNULL(DYFlag,0)=1";
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }
            if ( txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            tempStr += " AND ISNULL(FormTypeID,0)=" + this.FormListAID;

            //tempStr += " Group BY ID,FormCode,FormDate,DataDHID,DVendorID,DRemark,SubmitName,Contact,InSaleOPName,VendorName,SubmitFlag,DVendorName";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {

            //Common.BindVendor(drpVendor, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);

            CheckFormRule rule = new CheckFormRule(); 
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            CheckFormRule rule = new CheckFormRule();
            CheckForm entity = EntityGet();
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
            this.HTDataTableName = "ADH_CheckForm";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendor, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            Common.BindDHID(drpDHID, this.FormListAID, false);
            Common.BindDH(drpDH, this.FormListAID, false);
            Common.BindOPID(drpSaleOPID, true);
            Common.BindADHLevel(drpLevel, true);
            new VendorProc(drpVendorID);
            btnQuery_Click(null, null);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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
        /// ��ɫ�仯
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