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
    /// <summary>
    /// ���ܣ��Ұ�������ѯ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-20
    /// ����������
    /// </summary>
    public partial class frmGBJCLR : frmAPBaseUIForm
    {
        public frmGBJCLR()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != "")//��ѯ��
            {
                tempStr = " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr = " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr = " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != "")
            {
                tempStr = " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != "")
            {
                tempStr = " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (this.chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (this.chkJCTime.Checked)
            {
                tempStr += " AND JCTime BETWEEN " + SysString.ToDBString(txtJCTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtJCTimeE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (this.chkGHTime.Checked)
            {
                tempStr += " AND GHTime BETWEEN " + SysString.ToDBString(txtGHTimeS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtGHTimeE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }
            if (SysConvert.ToString(drpLYVendorID.EditValue) != "")
            {
                tempStr += " AND LYVendorID = " + SysString.ToDBString(SysConvert.ToString(drpLYVendorID.EditValue));
            }
            if (SysConvert.ToString(drpSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID = " + SysString.ToDBString(SysConvert.ToString(drpSaleOPID.EditValue));
            }
            if (txtGBCode.Text.Trim() != "")
            {
                tempStr += " AND GBCode LIKE "+SysString.ToDBString("%"+txtGBCode.Text.Trim()+"%");
            }
            tempStr += " AND ISNULL(FormListID,0) = " + this.FormListAID; //2013.11.14 zjh
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            GBJCLRRule rule = new GBJCLRRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            GBJCLRRule rule = new GBJCLRRule();
            GBJCLR entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Dev_GBJCLR";
            this.HTDataList = gridView1;
            btnQuery_Click(null, null);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.�ͻ� }, true);//�ͻ�        
            new VendorProc(drpVendorID);
            Common.BindVendor(drpLYVendorID, new int[] { (int)EnumVendorType.����, (int)EnumVendorType.�ͻ� }, true);//�����ͻ�
            new VendorProc(drpLYVendorID);
            Common.BindDOP(drpSaleOPID, true);
            txtJCTimeS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtJCTimeE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddDays(-5).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            txtGHTimeS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtGHTimeE.DateTime = DateTime.Now.Date;
            this.chkMakeDate.Checked = true;
            if (ItemGBQuery.ColorIniFlag)
            {
                ItemGBQuery.ColorIniTextBox(new TextBox[] { txtColorSOStatus1, txtColorSOStatus2, txtColorSOStatus3, txtColorSOStatus4, txtColorSOStatus5 });
            }
            this.ToolBarItemAdd(32, "btnDY", "����", true, btnDY_Click, eShortcut.F9);

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GBJCLR EntityGet()
        {
            GBJCLR entity = new GBJCLR();
            entity.ID = HTDataID;      
            return entity;
        }

       

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "GBStatusName")
                {
                    e.Appearance.BackColor = ItemGBQuery.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "GBStatusName")));
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ����

        private void btnDY_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                frmDYGLEdit frm = new frmDYGLEdit();
                frm.LY = "�Ұ�����";
                frm.DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DtsID"));
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ������ط���

        /// <summary>
        /// ���ٲ�ѯ(ֵ�ı伴����)
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
        /// ���ٲ�ѯ(�س�������)
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

        //public override void btnToExcel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ToExcelSelectColumn(gridView1);
        //        FCommon.AddDBLog(this.Text, "�����б�", "", "");
        //    }
        //    catch (Exception E)
        //    {
        //        this.ShowMessage(E.Message);
        //    }
        //}



        #endregion


    }
}