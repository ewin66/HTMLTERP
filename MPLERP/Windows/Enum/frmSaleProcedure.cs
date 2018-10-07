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
    public partial class frmSaleProcedure : frmAPBaseUISin
    {
        public frmSaleProcedure()
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

            if (txtName.Text.Trim() != string.Empty)
            {
                tempStr += " AND Name LIKE" + SysString.ToDBString(txtName.Text.Trim());
            }
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleProcedureRule rule = new SaleProcedureRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            SaleProcedureRule rule = new SaleProcedureRule();
            SaleProcedure entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Enum_SaleProcedure";
            this.HTDataList = gridView1;

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private SaleProcedure EntityGet()
        {
            SaleProcedure entity = new SaleProcedure();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}