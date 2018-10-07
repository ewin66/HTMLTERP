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
using DevExpress.XtraGrid.Views.Base;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ظ��ϲɹ���
    /// </summary>
    public partial class frmLoadAccesoryCompactWH : frmAPBaseLoad
    {
        public frmLoadAccesoryCompactWH()
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
            //
            if (txtQCompactNo.Text.Trim() != "")
            {
                tempStr += " AND CompactNo LIKE " + SysString.ToDBString("%" + txtQCompactNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (SysConvert.ToString(drpQSaleOPID.EditValue) != "")
            {
                tempStr += " AND SaleOPID = " + SysString.ToDBString(SysConvert.ToString(drpQSaleOPID.EditValue));
            }
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode = " + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQStyleNo.Text.Trim() != "")
            {
                tempStr += " AND StyleNo LIKE " + SysString.ToDBString("%" + txtQStyleNo.Text.Trim() + "%");
            }
            if (txtQSStyleNo.Text.Trim() != "")
            {
                tempStr += " AND SStyleNo LIKE " + SysString.ToDBString("%" + txtQSStyleNo.Text.Trim() + "%");
            }
            if (txtQDSN.Text.Trim() != "")
            {
                tempStr += " AND DSN LIKE " + SysString.ToDBString("%" + txtQDSN.Text.Trim() + "%");
            }
            if (txtQSSN.Text.Trim() != "")
            {
                tempStr += " AND SSN LIKE " + SysString.ToDBString("%" + txtQSSN.Text.Trim() + "%");
            }
            if (chkCompactDate.Checked)
            {
                tempStr += " AND CompactDate BETWEEN " + SysString.ToDBString(txtQCompactDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQCompactDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
           

        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Buy_AccesoryCompact";
            this.HTDataList = gridView1;

            txtQCompactDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQCompactDateE.DateTime = DateTime.Now.Date;

            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.���� }, true);//�ͻ� 
            Common.BindOPID(drpQSaleOPID, true);

            //new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.���� }, true, true);

            HTDataList.OptionsBehavior.ShowEditorOnMouseUp = false;

            ProcessGrid.SetGridEdit(HTDataList, "SelectFlag",true);

        }

        #endregion


        #region �����¼�
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQCode_EditValueChanged(object sender, EventArgs e)
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


        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();
            if (HTDataList.FocusedRowHandle >= 0)
            {
                HTLoadData.Clear();
                HTLoadDataSeq.Clear();
                //HTLoadData.Add(SysConvert.ToInt32(HTDataList.GetRowCellValue(HTDataList.FocusedRowHandle, "ID")));
                //HTLoadDataSeq.Add(SysConvert.ToInt32(HTDataList.GetRowCellValue(HTDataList.FocusedRowHandle, "Seq")));


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["SelectFlag"])) == 1)
                    {
                        HTLoadData.Add( SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID")) );
                        HTLoadDataSeq.Add(SysConvert.ToInt32(gridView1.GetRowCellValue(i, "Seq")) );
                    }
                }
            }
        }




    }
}