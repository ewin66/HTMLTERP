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
using DevExpress.XtraTreeList.Nodes;

namespace MLTERP
{
    /// <summary>
    /// ������֯�ṹ
    /// </summary>
    public partial class frmLoadStructure : frmAPBaseLoad
    {
        public frmLoadStructure()
        {
            InitializeComponent();
        }

        #region ����
       
        #endregion

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
           


        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Structure";
           
           
            BindTreeList();
        }

        /// <summary>
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
        }

        #endregion
          
        #region �Զ��巽��
       
        #endregion

        #region ���ؿ��
        

        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();
            TreeListNode node = treeList1.FocusedNode;
            if (node != null)
            {
                HTLoadData.Add(SysConvert.ToInt32(node.GetValue("ID")));
            }
            //m_StorgeID = GetStorgeArray();
            //if (m_StorgeID.Length == 0)
            //{
            //    this.ShowMessage("û��ѡ���κ�����");
            //    return;
            //}
            //else if (m_StorgeID.Length > 100)
            //{
            //    if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_StorgeID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
            //    {
            //        return;
            //    }
            //}

            //for (int i = 0; i < m_StorgeID.Length; i++)
            //{
            //    HTLoadData.Add(SysConvert.ToInt32(m_StorgeID[i]));
            //}
        }


        #endregion

    


        #region ���νṹ
        /// <summary>
        /// ��Grid����
        /// </summary>
        private void BindTreeList()
        {
            treeList1.Nodes.Clear();
            StructureRule rule = new StructureRule();
            //DataTable dt =rule.RShow(" ORDER BY ParentID,Code", ProcessTreeList.GetQueryField(treeList1));
            DataTable dt = SysUtils.Fill("EXEC USP1_Data_Stucture_Get");
            ProcessTreeList.BindTreeList(dt, treeList1, "ID", "ParentID", 7, true);
        }

       

        #endregion
        #region �����¼�
        /// <summary>
        /// ˫������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnLoad_Click(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion




    }
}