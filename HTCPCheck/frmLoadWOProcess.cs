using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTERP.Sys;
using HttSoft.WinUIBase;

namespace HTCPCheck
{
    public partial class frmLoadWOProcess : frmAPBaseLoad
    {
        public frmLoadWOProcess()
        {
            InitializeComponent();
        }

        #region  自定义属性
        public int OnlyOneFormNo = 0;//0 则允许加载多条记录，    1 只允许加载单个加工单

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

        private string  m_VendorID =string.Empty;
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

            if (chkReqDate.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtReqDateS.DateTime) + " AND " + SysString.ToDBString(txtReqDateE.DateTime);
            }

            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND DyeFactorty = " + SysString.ToDBString(drpQVendorID.EditValue.ToString());
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




            

            if(txtOrderFormNo.Text.Trim()!=string.Empty)
            {
                tempStr += " AND OrderFormNo LIKE " + SysString.ToDBString("%"+txtOrderFormNo.Text.Trim()+"%"); ;
            }
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//只查询未加载
                {
                    tempStr += m_NoLoadCondition;
                }
            }


            tempStr += " AND ProcessTypeID=" + SysString.ToDBString(m_ProcessTypeID);
            tempStr += " AND SubmitFlag=1";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            FabricProcessRule rule = new FabricProcessRule();
             
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
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
            this.HTDataTableName = "WO_FabricProcess";
            this.HTDataList = gridView1;
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtReqDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtReqDateE.DateTime = DateTime.Now.Date;
            gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
            if (m_ProcessTypeID == (int)EnumProcessType.染整加工单)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.染厂 }, true);
            }
            else if (m_ProcessTypeID == (int)EnumProcessType.印花加工单)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.加工户 }, true);
            }
            else if (m_ProcessTypeID == (int)EnumProcessType.织造加工单)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.织厂 }, true);
            }
            else if (m_ProcessTypeID == (int)EnumProcessType.其他加工单)
            {
                Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.其他加工厂 }, true);
            }
            if (m_NoLoadCondition != string.Empty)//如果有未加载语句则显示查询类型
            {
                drpQueryType.Visible = true;
            }
            txtVendorID.Text = m_VendorID;
            drpQVendorID.EditValue = m_VendorID;
            btnQuery_Click(null, null);
            

        }

        #endregion

        #region 自定义方法
        ///// <summary>
        ///// 获得实体
        ///// </summary>
        ///// <returns></returns>
        //private ItemBuyForm EntityGet()
        //{
        //    ItemBuyForm entity = new ItemBuyForm();
        //    entity.ID = HTDataID;      
        //    return entity;
        //}
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

        private void chkSelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            this.BaseFocusLabel.Focus();
            string FormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
            int SelectFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag"));
            if (OnlyOneFormNo == 1)//若是1 ，则只允许加载单个采购单
            {

                if (SelectFlag == 1)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1 && i != gridView1.FocusedRowHandle && FormNo != SysConvert.ToString(gridView1.GetRowCellValue(i, "FormNo")))
                        {
                            this.ShowMessage("只能加载同一单据数据，请重新选择！");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag", 0);
                            return;
                        }
                    }
                }
            }
        }

        
    }
}