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
using DevExpress.XtraGrid.Views.Grid;

namespace MLTERP
{
    public partial class frmLoadOrder : frmAPBaseLoad
    {
        public frmLoadOrder()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 挂板ID
        /// </summary>
        private int[] m_OrderID = new int[] { };
        public int[] OrderID
        {
            get
            {
                return m_OrderID;
            }
            set
            {
                m_OrderID = value;
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


        /// <summary>
        /// 客户
        /// </summary>
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
        /// 验证厂码标识
        /// </summary>
        private int m_CheckFlag = 0;
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
        /// <summary>
        /// 额外加的条件
        /// </summary>
        private string m_ExtraCondition = string.Empty;
        public string ExtraCondition
        {
            get
            {
                return m_ExtraCondition;
            }
            set
            {
                m_ExtraCondition = value;
            }
        }
        /// <summary>
        /// 是否外购
        /// </summary>
        private string m_WaiGouStr = string.Empty;
        public string WaiGouStr
        {
            get
            {
                return m_WaiGouStr;
            }
            set
            {
                m_WaiGouStr = value;
            }
        }
        /// <summary>
        /// 验证合同号唯一性标识
        /// </summary>
        private int m_CheckFlag2 = 0;
        public int CheckFlag2
        {
            get
            {
                return m_CheckFlag2;
            }
            set
            {
                m_CheckFlag2 = value;
            }
        }
        private int m_FAID = 3;
        public int FAID
        {
            get
            {
                return m_FAID;
            }
            set
            {
                m_FAID = value;
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
                tempStr += " AND OrderDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if (chkReqDate.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtReqDateS.DateTime) + " AND " + SysString.ToDBString(txtReqDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (txtCustomerCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND CustomerCode LIKE " + SysString.ToDBString("%" + txtCustomerCode.Text.Trim() + "%");
            }

            if (SysConvert.ToString(drpOrderTypeID.EditValue) != string.Empty)
            {
                tempStr += " AND OrderTypeID=" + SysString.ToDBString(SysConvert.ToInt32(drpOrderTypeID.EditValue));
            }

            if (SysConvert.ToString(drpOrderLevelID.EditValue) != string.Empty)
            {
                tempStr += " AND OrderLevelID=" + SysString.ToDBString(SysConvert.ToInt32(drpOrderLevelID.EditValue));
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }

            if (txtMWeightS.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight>" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight<" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (txtMWidth.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWidth=" + SysString.ToDBString(txtMWidth.Text.Trim());
            }

            if (txtItemName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
            }

            if (txtVColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorNum LIKE " + SysString.ToDBString("%" + txtVColorNum.Text.Trim() + "%");
            }

            if (txtVColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorName LIKE " + SysString.ToDBString("%" + txtVColorName.Text.Trim() + "%");
            }
            //if (m_VendorID != "")
            //{
            //    tempStr += " AND VendorID =" + SysString.ToDBString(m_VendorID);
            //}
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//只查询未加载
                {
                    tempStr += m_NoLoadCondition;
                }
            }
            //if (FAID != 3)
            //{
            //    tempStr += " AND FAID =" + FAID;
            //}


            if (m_WaiGouStr != "")
            {
                tempStr += m_WaiGouStr;
            }

            tempStr += " AND SubmitFlag=1";

            tempStr += m_ExtraCondition;

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            SaleOrderRule rule = new SaleOrderRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
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
            this.HTDataTableName = "Sale_SaleOrder";
            this.HTDataList = gridView1;
            Common.BindOrderType(drpOrderTypeID, true);
            Common.BindOrderLevel(drpOrderLevelID, true);
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-2).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtReqDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtReqDateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);

            if (ProductParamSet.GetIntValueByID(5417) == (int)YesOrNo.Yes)//组织结构体系启用
            {
                chkOrderDate.Checked = false;
            }


            drpVendorID.EditValue = m_VendorID;

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

        #region 加载挂板信息

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
            if (m_CheckFlag2 == 0)
            {
                if (!CheckData())
                {
                    return;
                }
            }
            if (m_CheckFlag == 1 && !chkVendorID())
            {
                return;
            }
            m_OrderID = GetStorgeArray();
            if (m_OrderID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_OrderID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_OrderID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_OrderID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_OrderID[i]));
            }
        }

        private bool chkVendorID()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {

                for (int j = 0; j < gridView1.RowCount; j++)
                {
                    if (i != j && SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1 && SysConvert.ToInt32(gridView1.GetRowCellValue(j, "SelectFlag")) == 1)
                    {
                        if (SysConvert.ToString(gridView1.GetRowCellValue(i, "VendorCode")) != SysConvert.ToString(gridView1.GetRowCellValue(j, "VendorCode")))
                        {
                            this.ShowMessage("请选择同一厂码的数据进行加载");
                            return false;
                        }
                    }
                }

            }
            return true;
        }


        /// <summary>
        /// 判断加载的是不是同一合同的数据
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            if (!m_Double)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {

                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        if (i != j && SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1 && SysConvert.ToInt32(gridView1.GetRowCellValue(j, "SelectFlag")) == 1)
                        {
                            if (SysConvert.ToString(gridView1.GetRowCellValue(i, "FormNo")) != SysConvert.ToString(gridView1.GetRowCellValue(j, "FormNo")))
                            {
                                this.ShowMessage("请选择同一合同的数据进行加载");
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
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

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {


        }


    }
}