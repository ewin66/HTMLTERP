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
    public partial class frmLoadDY : frmAPBaseLoad
    {
        public frmLoadDY()
        {
            InitializeComponent();
        }

        #region 调样单ID
        /// <summary>
        /// 调样单ID
        /// </summary>
        private int[] m_DYID;
        public int[] DYID
        {
            get
            {
                return m_DYID;
            }
            set
            {
                m_DYID = value;
            }
        }

        /// <summary>
        /// 客户
        /// </summary>
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

        /// <summary>
        /// 调样工厂
        /// </summary>
        private string m_VendorID2;
        public string VendorID2
        {
            get
            {
                return m_VendorID2;
            }
            set
            {
                m_VendorID2 = value;
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
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (txtShopID.Text.Trim() != string.Empty)
            {
                tempStr += " AND ShopID LIKE "+SysString.ToDBString("%"+txtShopID.Text.Trim()+"%");
            }

            if (txtDLCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND DLCode LIKE "+SysString.ToDBString("%"+txtDLCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }

            if (txtSaleOPName.Text.Trim() != string.Empty)
            {
                tempStr+=" AND OPName LIKE "+SysString.ToDBString("%"+txtSaleOPName.Text.Trim()+"%");
            }

            if(SysConvert.ToString(drpDYStatusID.EditValue)!=string.Empty)
            {
                tempStr+=" AND DYStatusID="+SysString.ToDBString(SysConvert.ToInt32(drpDYStatusID.EditValue));
            }

            if(drpDYXZ.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DYXZ="+SysString.ToDBString(drpDYXZ.Text.Trim());
            }
            if (m_VendorID2 != "")
            {
                tempStr += " AND VendorID2="+SysString.ToDBString(m_VendorID2);
            }
            if (chkINDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQIndateS.DateTime) + " AND " + SysString.ToDBString(txtQIndateE.DateTime);
            }
            if (drpQueryType.Visible)
            {
                if (drpQueryType.SelectedIndex == 0)//只查询未加载
                {
                    tempStr += m_NoLoadCondition;
                }
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            DYGLRule rule = new DYGLRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            gridView1.GridControl.Show();
        }

       

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Sale_DYGL";
            this.HTDataList = gridView1;
            Common.BindCLS(drpDYXZ, "Sale_DYGL", "DYXZ", true);
            Common.BindDYStatus(drpDYStatusID, true);
            txtQIndateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQIndateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.客户 }, true);
            new VendorProc(drpVendorID);
            drpVendorID.EditValue = m_VendorID;
            if (m_NoLoadCondition != string.Empty)//如果有未加载语句则显示查询类型
            {
                drpQueryType.Visible = true;
            }
            btnQuery_Click(null, null);
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

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private DYGL EntityGet()
        {
            DYGL entity = new DYGL();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        #region 加载调样单信息

        /// <summary>
        /// 获取选择的ID数组
        /// </summary>
        /// <returns></returns>
        private int[] GetDYArray()
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
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
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
            m_DYID = GetDYArray();
            if (m_DYID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_DYID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_DYID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_DYID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_DYID[i]));
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
                for(int i=0;i<gridView1.RowCount;i++)
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