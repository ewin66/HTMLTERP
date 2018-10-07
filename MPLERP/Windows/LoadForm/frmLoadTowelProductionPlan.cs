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
    public partial class frmLoadTowelProductionPlan : frmAPBaseLoad
    {
        public frmLoadTowelProductionPlan()
        {
            InitializeComponent();
        }

        #region  自定义属性
        /// <summary>
        /// 采购单明细ID
        /// </summary>
        private int[] m_ItemBuyID = new int[] { };
        public int[] ItemBuyID
        {
            get
            {
                return m_ItemBuyID;
            }
            set
            {
                m_ItemBuyID = value;
            }
        }

        private string m_VendorID = string.Empty;
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

        private int m_LoadType = 1; //默认为面料采购单
        public int LoadType
        {
            get
            {
                return m_LoadType;
            }
            set
            {
                m_LoadType = value;
            }
        }

        private int m_ProcessTypeID = 1; //默认为染整加工单
        public int ProcessTypeID
        {
            get
            {
                return m_ProcessTypeID;
            }
            set
            {
                m_ProcessTypeID = value;
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }


            if (!Common.CheckLookUpEditBlank(drpVendorID))
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }


            if (txtDtsSO.Text.Trim() != string.Empty)
            {
                tempStr += " AND DtsSO LIKE " + SysString.ToDBString("%" + txtDtsSO.Text.Trim() + "%"); ;
            }
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//只查询未加载
                {
                    tempStr += m_NoLoadCondition;
                }
            }


            tempStr += " AND SubmitFlag=1";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            //FabricProcessRule rule = new FabricProcessRule();
            //DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag").Replace("OrderStepName", "'' OrderStepName"));

            TowelProductionPlanRule rule = new TowelProductionPlanRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));


            gridView1.GridControl.DataSource = dt;
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
            this.HTDataTableName = "WO_TowelProductionPlan";
            this.HTDataList = gridView1;
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;

            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;

            DevMethod.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.内销客户 }, true);

            if (m_NoLoadCondition != string.Empty)//如果有未加载语句则显示查询类型
            {
                drpQueryType.Visible = true;
            }

            drpVendorID.EditValue = m_VendorID;
            btnQuery_Click(null, null);


        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private ItemBuyForm EntityGet()
        {
            ItemBuyForm entity = new ItemBuyForm();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region 加载染布加工单信息

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
            m_ItemBuyID = GetStorgeArray();
            if (m_ItemBuyID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_ItemBuyID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_ItemBuyID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_ItemBuyID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_ItemBuyID[i]));
            }
        }


        #endregion

        #region 其他方法
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