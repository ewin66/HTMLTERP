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
    public partial class frmLoadYQIOForm : frmAPBaseLoad
    {
        public frmLoadYQIOForm()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        private int[] m_DtsID = new int[] { };
        public int[] DtsID
        {
            get
            {
                return m_DtsID;
            }
            set
            {
                m_DtsID = value;
            }
        }

        /// <summary>
        /// 对账类型
        /// </summary>
        private int m_DZTypeID=0;
        public int DZTypeID
        {
            get
            {
                return m_DZTypeID;
            }
            set
            {
                m_DZTypeID = value;
            }
        }

        /// <summary>
        /// 对账
        /// </summary>
        private int m_DZFlag = 0;
        public int DZFlag
        {
            get
            {
                return m_DZFlag;
            }
            set
            {
                m_DZFlag = value;
            }
        }

        /// <summary>
        /// 开票
        /// </summary>
        private int m_InvoiceFlag = 0;
        public int InvoiceFlag
        {
            get
            {
                return m_InvoiceFlag;
            }
            set
            {
                m_InvoiceFlag = value;
            }
        }



        /// <summary>
        /// 退货查询条件
        /// </summary>
        private string  m_THConditionStr=string.Empty;
        public string THConditionStr
        {
            get
            {
                return m_THConditionStr;
            }
            set
            {
                m_THConditionStr = value;
            }
        }

        /// <summary>
        /// 出入库物品类型
        /// </summary>
        private int m_MLTypeID = 0;
        public int MLTypeID
        {
            get
            {
                return m_MLTypeID;
            }
            set
            {
                m_MLTypeID = value;
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
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (chkOrderDate.Checked&&m_InvoiceFlag!=1)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtOrderDateS.DateTime)+" AND "+SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue)!= string.Empty)
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }

            if (drpXZ.Text.Trim() != string.Empty)
            {
                tempStr += " AND XZ="+SysString.ToDBString(drpXZ.Text.Trim());
            }

            if (txtDM.Text.Trim() != string.Empty)
            {
                tempStr += " AND DM LIKE "+SysString.ToDBString("%"+txtDM.Text.Trim()+"%");
            }

            if(txtInvoiceNo.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND InvoiceNo LIKE "+SysString.ToDBString("%"+txtInvoiceNo.Text.Trim()+"%");
            }

            if(txtQDtsSO.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DtsSO LIKE "+SysString.ToDBString("%"+txtQDtsSO.Text.Trim()+"%");
            }

            if(txtItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if(txtGoodsCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND GoodsCode="+SysString.ToDBString(txtGoodsCode.Text.Trim());
            }

            if(txtColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if(txtColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if(txtVColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorNum LIKE "+SysString.ToDBString("%"+txtVColorNum.Text.Trim()+"%");
            }

            if(txtVColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorName LIKE "+SysString.ToDBString("%"+txtVColorName.Text.Trim()+"%");
            }

            if(txtVItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VItemCode LIKE "+SysString.ToDBString("%"+txtVItemCode.Text.Trim()+"%");
            }

            if(txtBatch.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND Batch="+SysString.ToDBString(txtBatch.Text.Trim());
            }

            if(txtJarNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND JarNum LIKE "+SysString.ToDBString("%"+txtJarNum.Text.Trim()+"%");
            }
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }

            if (chkDZDate.Checked && m_InvoiceFlag == 1)
            {
                tempStr += " AND DZTime BETWEEN "+SysString.ToDBString(txtDZDateS.DateTime)+" AND "+SysString.ToDBString(txtDZDateE.DateTime);
            }

            if (txtQty1.Text.Trim() != "")
            {
                tempStr += " AND Qty>="+SysString.ToDBString(SysConvert.ToDecimal(txtQty1.Text.Trim()));
            }
            if (txtQty2.Text.Trim() != "")
            {
                tempStr += " AND Qty<=" + SysString.ToDBString(SysConvert.ToDecimal(txtQty2.Text.Trim()));
            }

            tempStr += HTLoadConditionStr;
            tempStr += " AND ISNULL(DtsID,0)<>0";
            tempStr += " AND ISNULL(SubmitFlag,0)=1";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormRule rule = new IOFormRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag").Replace("DZFlagStr", "'' DZFlagStr").Replace("DZRemark", "'' DZRemark").Replace("NoDZQty", "0.00 NoDZQty").Replace("InvoiceFlagStr", "'' InvoiceFlagStr").Replace("InvoiceRemark", "'' InvoiceRemark"));
            if (m_DZFlag == 1)
            {
                SetDZGridView(dt);
            }
            if (m_InvoiceFlag == 1)
            {
                SetInvoiceGridView(dt);
            }
            SetWHQty(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void SetWHQty(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToInt32(dr["FormDZFlag"]) ==(int)EnumDZFlag.对帐负)
                {
                    dr["Qty"] = 0 - SysConvert.ToDecimal(dr["Qty"]);
                }
            }
        }

        private void SetInvoiceGridView(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToDecimal(dr["InvoiceQty"]) > 0)
                {
                    if (SysConvert.ToDecimal(dr["Qty"]) != SysConvert.ToDecimal(dr["InvoiceQty"]))
                    {
                        dr["InvoiceFlagStr"] = "已开票";
                        string sql = "SELECT FormNo,DInvoiceQty FROM UV1_Finance_InvoiceOperationDts WHERE DLOADDtsID=" + SysString.ToDBString(SysConvert.ToInt32(dr["DtsID"]));
                        sql += " AND SubmitFlag=1";
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count > 0)
                        {
                            string InvoiceRemark = "已开票单号为：";
                            decimal Qty = 0;
                            for (int i = 0; i < dto.Rows.Count; i++)
                            {
                                InvoiceRemark += SysConvert.ToString(dto.Rows[i][0]);
                                InvoiceRemark += "_";
                                Qty += SysConvert.ToDecimal(dto.Rows[i][1]);
                            }
                            InvoiceRemark += ",已开票数量合计为" + Qty.ToString(); ;

                            dr["InvoiceRemark"] = InvoiceRemark;
                        }
                    }
                }
                else
                {
                    if (SysConvert.ToDecimal(dr["Qty"]) !=0- SysConvert.ToDecimal(dr["InvoiceQty"]))
                    {
                        dr["InvoiceFlagStr"] = "已开票";
                        string sql = "SELECT FormNo,DInvoiceQty FROM UV1_Finance_InvoiceOperationDts WHERE DLOADDtsID=" + SysString.ToDBString(SysConvert.ToInt32(dr["DtsID"]));
                        sql += " AND SubmitFlag=1";
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count > 0)
                        {
                            string InvoiceRemark = "已开票单号为：";
                            decimal Qty = 0;
                            for (int i = 0; i < dto.Rows.Count; i++)
                            {
                                InvoiceRemark += SysConvert.ToString(dto.Rows[i][0]);
                                InvoiceRemark += "_";
                                Qty += SysConvert.ToDecimal(dto.Rows[i][1]);
                            }
                            InvoiceRemark += ",已开票数量合计为" + Qty.ToString(); ;

                            dr["InvoiceRemark"] = InvoiceRemark;
                        }
                    }
                }

            }
        }

        private void SetDZGridView(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToInt32(dr["DZFlag"]) == 1)
                {
                    dr["DZFlagStr"] = "已对账";
                    string sql = "SELECT FormNo,DCheckQty FROM UV1_Finance_CheckOperationDts WHERE DLOADDtsID=" + SysString.ToDBString(SysConvert.ToInt32(dr["DtsID"]));
                    sql += " AND SubmitFlag=1";
                    DataTable dto = SysUtils.Fill(sql);
                    if (dto.Rows.Count > 0)
                    {
                        string DZRemark = "已对账单号为：";
                        decimal Qty = 0;
                        for (int i = 0; i < dto.Rows.Count; i++)
                        {
                            DZRemark += SysConvert.ToString(dto.Rows[i][0]);
                            DZRemark += "_";
                            Qty += SysConvert.ToDecimal(dto.Rows[i][1]);
                        }
                        DZRemark += ",已对账数量合计为" + Qty.ToString(); ;

                        dr["DZRemark"] = DZRemark;
                    }
                }
               
            }
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.客户,(int)EnumVendorType.工厂 }, true);
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-6).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, this.FormListAID, true);
            
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            if (m_InvoiceFlag != 1)
            {
                chkDZDate.Visible = false;
                txtDZDateS.Visible = false;
                lbDZ.Visible = false;
                txtDZDateE.Visible = false;
               
            }
           
            txtDZDateS.DateTime = DateTime.Now.AddDays(-1).Date;
            txtDZDateE.DateTime = DateTime.Now.AddDays(1).Date;
            btnQuery_Click(null, null);

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
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

        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
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
            m_DtsID = GetStorgeArray();
            if (m_DtsID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_DtsID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_DtsID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_DtsID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_DtsID[i]));
            }
        }


        


        #endregion

        #region 其它事件

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
                SelectFlag_CheckedChanged(null, null);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                decimal Qty = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                    {
                        Qty += SysConvert.ToDecimal(gridView1.GetRowCellValue(i,"Qty"));
                    }
                }
                lbTotalQty.Text = Qty.ToString();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        




    }
}