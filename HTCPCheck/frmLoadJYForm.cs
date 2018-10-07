using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Grid;
using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTCPCheck.Data;

namespace HTCPCheck
{
    public partial class frmLoadJYForm : frmAPBaseLoad
    {
        public frmLoadJYForm()
        {
            InitializeComponent();
        }

        #region 检验单明细ID
        /// <summary>
        /// 发货单明细ID
        /// </summary>
        private int[] m_JYFormID;
        public int[] JYFormID
        {
            get
            {
                return m_JYFormID;
            }
            set
            {
                m_JYFormID = value;
            }
        }

        private string m_VendorID;
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

        private bool m_WL=false;
        public bool WL
        {
            get
            {
                return m_WL;
            }
            set
            {
                m_WL = value;
            }
        }

        private int m_SourceID;
        public int SourceID
        {
            get
            {
                return m_SourceID;
            }
            set
            {
                m_SourceID = value;
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
            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE" + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtCompactNo.Text.Trim() != "")
            {
                tempStr += " AND CompactNo LIKE" + SysString.ToDBString("%" + txtCompactNo.Text.Trim() + "%");
            }
            if (txtSaleProcedureFormNo.Text.Trim() != "")
            {
                tempStr += " AND SaleProcedureFormNo LIKE" + SysString.ToDBString("%" + txtSaleProcedureFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToInt32(drpSaleProcedureID.EditValue) != 0)
            {
                tempStr += " AND SaleProcedureID =" + SysString.ToDBString(SysConvert.ToInt32(drpSaleProcedureID.EditValue));
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE" + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE" + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }
            if (txtColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE" + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }



            if (chkInDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQInDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQInDateE.DateTime.ToString("yyyy-MM-dd") + " 23:59:59");

            }
            tempStr += " AND ISNULL(SubmitFlag,0)<>0";
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            PackOrderRule rule = new PackOrderRule();
            gridView1.GridControl.DataSource=rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag","0 SelectFlag"));
            gridView1.GridControl.Show();
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
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//设置列UI
          //  Common.BindOP(drpSaleOPID, true);
            this.HTDataTableName = "Sale_FHForm";
            this.HTDataList = gridView1;
          //  Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            txtQInDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQInDateE.DateTime = DateTime.Now;
           // drpQVendorID.EditValue = m_VendorID;
            if (m_NoLoadCondition != string.Empty)//如果有未加载语句则显示查询类型
            {
                drpQueryType.Visible = true;
            }
            btnQuery_Click(null, null);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private PackOrder EntityGet()
        {
            PackOrder entity = new PackOrder();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region 快速查询
        private void txtSendCode_EditValueChanged(object sender, EventArgs e)
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

        private void drpQVendorID_EditValueChanged(object sender, EventArgs e)
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
        private void txtQSaleOPID_EditValueChanged(object sender, EventArgs e)
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

        #region 加载发货单信息

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
            m_JYFormID = GetStorgeArray();
            if (m_JYFormID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_JYFormID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_JYFormID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_JYFormID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_JYFormID[i]));
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

     
    }
}