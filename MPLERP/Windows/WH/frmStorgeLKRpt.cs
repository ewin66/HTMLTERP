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
    /// ��汨��
    /// </summary>
    public partial class frmStorgeLKRpt : frmAPBaseUIRpt
    {
        public frmStorgeLKRpt()
        {
            InitializeComponent();
        }
        #region ȫ�ֱ���

        int iLKParamSet = 0;//����������
        #endregion

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtQSSN.Text.Trim() != "")
            {
                tempStr += " AND SSN LIKE " + SysString.ToDBString("%" + txtQSSN.Text.Trim() + "%");
            }
            if (txtQDSN.Text.Trim() != "")
            {
                tempStr += " AND DSN LIKE " + SysString.ToDBString("%" + txtQDSN.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }

            tempStr += " AND InDate <=" + SysString.ToDBString(DateTime.Now.Date.AddDays(-iLKParamSet).ToString("yyyy-MM-dd"));

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeRule rule = new StorgeRule();

            DataTable dt = new DataTable();
            dt = rule.LKRShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("LKDate", "'' LKDate").Replace("DeviationStatusName", "'' DeviationStatusName"));
            //dt.Columns.Add(new DataColumn("LKDate", typeof(string)));//����һ�б�����
            ProcDt(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

        }

        private void ProcDt(DataTable p_dt)
        {
            foreach (DataRow dr in p_dt.Rows)//������ֹ��
            {
                TimeSpan Day = System.DateTime.Now - SysConvert.ToDateTime(dr["InDate"]);
                double dDay = Day.TotalDays;

                Decimal Days = SysConvert.ToDecimal(SysConvert.ToDecimal(dDay), 2);
                dr["LKDate"] = Days.ToString();



                DateTime time1 = SysConvert.ToDateTime(dr["InDate"]);
                DateTime time2 = SysConvert.ToDateTime(DateTime.Now.Date);
                string DeviationStatusName = DeviationStatus.GetGridCellStatusName(time1, time2);

                dr["DeviationStatusName"] = DeviationStatusName.ToString();
            }
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;

            ParamSetRule rule = new ParamSetRule();
           // iLKParamSet = SysConvert.ToInt32(rule.RShowIntByCode((int)ParamSetEnum.��������));


            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);//�ͻ� 

            Common.BindWHType(drpQWHTypeID, false);
            Common.BindWH(drpQWHID, true);
            new ItemProcLookUp(drpQItemCode, new int[] { 1 }, true, true);//(int)ItemType.ɴ��


            DeviationStatus.ProcCondition("WH_Storge");
            DeviationStatus.ColorIniTextBox(groupControlSOColor);



            SetTabIndex(0, groupControlQuery);

        }

        #endregion


        /// <summary>
        /// ��ɫ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DateTime time1 = SysConvert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, "InDate"));
                DateTime time2 = SysConvert.ToDateTime(DateTime.Now.Date);
                e.Appearance.BackColor = DeviationStatus.GetGridRowBackColor(time1, time2);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #region ��ͼ����Դ
       
        #endregion


        #region ��ͼ
       
        #endregion



    }
}