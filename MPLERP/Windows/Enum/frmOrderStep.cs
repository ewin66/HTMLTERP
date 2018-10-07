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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmOrderStep : frmAPBaseUISin
    {
        public frmOrderStep()
        {
            InitializeComponent();
        }

        #region  ����BarĬ�ϰ�ť
        /// <summary>
        /// ����BarĬ�ϰ�ť
        /// </summary>
        public override void ToolIniCreateBar()
        {
            this.ToolBarItemAdd(22, ToolButtonName.btnQuery.ToString(), "��ѯ", false, btnQuery_Click, eShortcut.F5);
            this.ToolBarItemAdd(22, ToolButtonName.btnQueryAdvance.ToString(), "�����ѯ", false, btnQueryAdvance_Click);
            this.ToolBarItemAdd(13, ToolButtonName.btnBrowse.ToString(), "���", false, btnBrowse_Click, eShortcut.CtrlB);
            this.ToolBarItemAdd(2, ToolButtonName.btnUpdate.ToString(), "�޸�", false, btnUpdate_Click, eShortcut.F2);
            this.ToolBarItemAdd(32, ToolButtonName.btnToExcel.ToString(), "�����б�", true, btnToExcel_Click, eShortcut.F9);
  
        }

       
        #endregion
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;

            if (txtName.Text.Trim() != "")
            {
                tempStr += " AND Name LIke " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }
            tempStr += " AND ShowFlag=1 ORDER BY Code";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            OrderStepRule rule = new OrderStepRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            OrderStepRule rule = new OrderStepRule();
            OrderStep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_OrderStep";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private OrderStep EntityGet()
        {
            OrderStep entity = new OrderStep();
            entity.ID = HTDataID;      
            return entity;
        }
        
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
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

        /// <summary>
        /// ��ÿһ�и���ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                string ColorStr = SysConvert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["ColorStr"]));
                e.Appearance.BackColor = Color.YellowGreen;
                string[] tempstr = ColorStr.Split(',');
                if (tempstr.Length == 3)//����Ϊ3
                {
                    e.Appearance.BackColor = Color.FromArgb(SysConvert.ToInt32(tempstr[0]), SysConvert.ToInt32(tempstr[1]), SysConvert.ToInt32(tempstr[2]));
                }
                else
                {
                    e.Appearance.BackColor = Color.FromName(ColorStr);
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion
    }
}