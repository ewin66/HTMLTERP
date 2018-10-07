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
    public partial class frmReportManage2 : frmAPBaseUIForm
    {
        public frmReportManage2()
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
            if (!Common.CheckLookUpEditBlank(drpQParentID))
            {
                tempStr += "  AND ParentID = " + SysString.ToDBString(drpQParentID.EditValue.ToString());
            }
            if (!Common.CheckLookUpEditBlank(drpQWinListID))
            {
                tempStr += "  AND WinListID = " + SysString.ToDBString(drpQWinListID.EditValue.ToString());
            }
            if (txtQReportName.Text.Trim() != "")
            {
                tempStr += "  AND ReportName LIKE " + SysString.ToDBString("%" + txtQReportName.Text.Trim() + "%");
            }
            tempStr += " ORDER BY ParentID,WinListID ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ReportManageRule rule = new ReportManageRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ReportManageRule rule = new ReportManageRule();
            ReportManage entity = EntityGet();
            //FastReport.DeleteFile(entity.FileName);
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
            this.HTDataTableName = "Data_ReportManage";
            this.HTDataList = gridView1;
            Common.BindParentForm(drpQParentID, 0, true);
            drpQParentID_EditValueChanged(null, null);
            

        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ReportManage EntityGet()
        {
            ReportManage entity = new ReportManage();
            entity.ID = HTDataID;      
            return entity;
        }

        #endregion

        private void drpQParentID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Common.CheckLookUpEditBlank(drpQParentID))
                {
                    Common.BindWinList(drpQWinListID, SysConvert.ToInt32(drpQParentID.EditValue), true);
                }
                else
                {
                    Common.BindWinList(drpQWinListID, true);
                }
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        private void drpQWinListID_EditValueChanged(object sender, EventArgs e)
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

        private void txtQReportName_EditValueChanged(object sender, EventArgs e)
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
    }
}