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
    /// 加载复合布算料结果
    /// </summary>
    public partial class frmLoadSlaeOrderFabricCompSite : frmAPBaseLoad
    {
        public frmLoadSlaeOrderFabricCompSite()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 挂板ID
        /// </summary>
        private int[] m_ItemID = new int[] { };
        public int[] ItemID
        {
            get
            {
                return m_ItemID;
            }
            set
            {
                m_ItemID = value;
            }
        }
        private bool m_Double = false;
        public bool Double
        {
            get
            {
                return m_Double;
            }
            set
            {
                m_Double = value;
            }
        }

        private bool m_BuyFlag = false;
        public bool BuyFlag
        {
            get
            {
                return m_BuyFlag;
            }
            set
            {
                m_BuyFlag = value;
            }
        }

        private bool m_ProcessFlag = false;
        public bool ProcessFlag
        {
            get
            {
                return m_ProcessFlag;
            }
            set
            {
                m_ProcessFlag = value;
            }
        }


        /// <summary>
        /// 客户
        /// </summary>
        private string m_VendorID=string.Empty;
        public string VendorID
        {
            get
            {
                return m_VendorID;
            }
            set
            {
                m_VendorID = value;
            }
        }

        /// <summary>
        /// 验证厂码标识
        /// </summary>
        private int m_CheckFlag =0;
        public int CheckFlag
        {
            get
            {
                return m_CheckFlag;
            }
            set
            {
                m_CheckFlag = value;
            }
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        private int m_OrderType = 0;
        public int OrderType
        {
            get
            {
                return m_OrderType;
            }
            set
            {
                m_OrderType = value;
            }
        }


        /// <summary>
        /// 未加载SQL条件语句
        /// </summary>
        private string m_NoLoadCondition = string.Empty;
        public string NoLoadCondition
        {
            get
            {
                return m_NoLoadCondition;
            }
            set
            {
                m_NoLoadCondition = value;
            }
        }
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtCode.Text.Trim()+"%");
            }

            if (txtName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }

            if (txtStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtStd.Text.Trim() + "%");
            }

            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (chkMakeDate.Checked)
            {
                tempStr += " AND OrderDate BETWEEN "+SysString.ToDBString(txtMakeDateS.DateTime)+" AND "+SysString.ToDBString(txtMakeDateE.DateTime);
            }
            //if (BuyFlag)
            //{
            //    tempStr += " AND ProcedureID LIKE " + SysString.ToDBString("%" + SysConvert.ToString((int)EnumSaleProceduce.胚布采购) + "%");
            //}
            //if (ProcessFlag)
            //{
            //    tempStr += " AND ProcedureID LIKE " + SysString.ToDBString("%" + SysConvert.ToString((int)EnumSaleProceduce.织胚加工) + "%");
            //}
            if (chkNoLoad.Visible && chkNoLoad.Checked)
            {
                tempStr += m_NoLoadCondition;
            }
            tempStr += " AND SubmitFlag=1";
            tempStr += " ORDER BY FormNo";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleOrderTFabricCompSiteRule rule = new SaleOrderTFabricCompSiteRule();
            gridView1.GridControl.DataSource = rule.RShowView(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        
         /// <summary>
        /// 设置定位数据及状态
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_MLYL";
            this.HTDataList = gridView1;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            if (m_NoLoadCondition == "")
            {
                chkNoLoad.Visible = false;
            }
            btnQuery_Click(null, null);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private SaleOrder EntityGet()
        {
            SaleOrder entity = new SaleOrder();
            entity.ID = HTDataID;      
            return entity;
        }


        /// <summary>
        /// 快速查询
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

        #region 加载纱线信息

        /// <summary>
        /// 获取选择的ID数组
        /// </summary>
        /// <returns></returns>
        private int[] GetStorgeArray()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    index++;
                }
            }
            int[] tempstorge = new int[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                    index++;
                }
            }
            return tempstorge;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();

            m_ItemID = GetStorgeArray();
            if (m_ItemID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_ItemID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_ItemID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_ItemID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_ItemID[i]));
            }
        }

       

      

        #endregion

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (chkAll.Checked)
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 0);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void groupControlQuery_Paint(object sender, PaintEventArgs e)
        {

        }

      


    }
}