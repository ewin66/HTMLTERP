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
    /// 加载组织结构
    /// </summary>
    public partial class frmLoadStructure : frmAPBaseLoad
    {
        public frmLoadStructure()
        {
            InitializeComponent();
        }

        #region 属性
       
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
           


        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Structure";
           
           
            BindTreeList();
        }

        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
        }

        #endregion
          
        #region 自定义方法
       
        #endregion

        #region 加载库存
        

        /// <summary>
        /// 加载数据
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
            //    this.ShowMessage("没有选择任何数据");
            //    return;
            //}
            //else if (m_StorgeID.Length > 100)
            //{
            //    if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_StorgeID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
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

    


        #region 树形结构
        /// <summary>
        /// 绑定Grid数据
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
        #region 其它事件
        /// <summary>
        /// 双击加载
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