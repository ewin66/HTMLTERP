using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
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
    /// ��ԭ�ϼ���
    /// </summary>
    public partial class frmFormItemMoreLoad : frmAPBaseLoad
    {
        public frmFormItemMoreLoad()
        {
            FormID = 100000;

            InitializeComponent();
        }
         
        public DevExpress.XtraEditors.MemoEdit FormItemText;

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            tempStr += " AND TableID="+HTDataID+" ORDER BY SEQ";

            HTDataConditionStr = tempStr;
        }


        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FormItemMoreRule rule = new FormItemMoreRule();
            DataTable dt = rule.RShow(HTLoadConditionStr + HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            rule.RShowVal(dt, SysConvert.ToString(FormItemText.Tag));
            Common.AddDtRow(dt,30);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {
            if (gridView1.FocusedRowHandle != gridView1.RowCount - 1)
            {
                gridView1.FocusedRowHandle = gridView1.FocusedRowHandle + 1;
            }
            this.BaseFocusLabel.Focus();
            if (HTDataList.FocusedRowHandle >= 0)
            {
                HTLoadData.Clear();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(i, gridView1.Columns["ItemCode"])) !=string.Empty)
                    {
                        HTLoadData.Add(new string[] { SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemCode")), SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemName")), SysConvert.ToString(gridView1.GetRowCellValue(i, "ItemStd")) });
                    }
                }

                FormItemMoreRule rule = new FormItemMoreRule();
                string o_Txt, o_Val;
                rule.RConVal(HTLoadData, out o_Txt, out o_Val);
                if (FormItemText != null)
                {
                    FormItemText.Text = o_Txt;
                    FormItemText.Tag = o_Val;
                }
            }
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataList = gridView1;
            HTDataList.OptionsBehavior.ShowEditorOnMouseUp = false;

            new ItemProcResLookUP(BaseFocusLabel, gridView1, new string[] { "ItemCode", "ItemName", "ItemStd" }, drpGridItemCode, txtGridItemName, new int[] { 1 }, true, true);

            SetTabIndex(0, groupControlDataList);
        }
        /// <summary>
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "ItemCode" }, true);
            BindGrid();
        }
        #endregion
    }
}