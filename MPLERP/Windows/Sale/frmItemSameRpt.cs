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
    public partial class frmItemSameRpt : frmAPBaseUIRpt
    {
        public frmItemSameRpt()
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
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                string sql="";
                if (txtSameType.Text.Trim() == "����")
                {
                    sql = "EXEC USP1_VendorSameRpt " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "���")
                {
                    sql = "EXEC USP1_VendorSameRpt2 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "����")
                {
                    sql = "EXEC USP1_VendorSameRpt3 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "����")
                {
                    sql = "EXEC USP1_VendorSameRpt4 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }

                if (txtSameType.Text.Trim() == "����")
                {
                    sql = "EXEC USP1_VendorSameRpt5 " + SysString.ToDBString(drpVendorID.EditValue.ToString());
                    DataTable dt = SysUtils.Fill(sql);
                    gridView1.GridControl.DataSource = dt;
                    gridView1.GridControl.Show();
                }
                
                  
                
               

            }
        }

        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_DYGL";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpVendorID);
        }

        /// <summary>
        /// ���ٲ�ѯ
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

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
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
                if (e.Column.FieldName == "SamePre")
                {
                    if (SysConvert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "SameQty")) > 0)
                    {
                        e.Appearance.BackColor = Color.Plum;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
    }
}