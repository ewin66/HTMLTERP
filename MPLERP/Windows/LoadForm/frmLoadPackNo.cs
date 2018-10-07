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
    /// 入库单细码保存
    /// 章文强
    /// 2014-4-5
    /// 
    /// 陈加海
    /// 2014-5-8
    /// </summary>
    public partial class frmLoadPackNo : BaseForm
    {
        public frmLoadPackNo()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 保存标志
        /// </summary>
        bool m_SaveFlag = false;
        /// <summary>
        /// 保存标志
        /// </summary>
        public bool SaveFlag
        {
            get
            {
                return m_SaveFlag;
            }
        }

        bool m_UpdateFlag = false;
        /// <summary>
        /// 修改标志
        /// </summary>
        public bool UpdateFlag
        {
            set
            {
                m_UpdateFlag = value;
            }
        }
        private int m_PackType;
        public int PackType
        {
            get
            {
                return m_PackType;
            }
            set
            {
                m_PackType = value;
            }
        }

        private int m_ID;
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private int m_MainID;
        public int MainID
        {
            get
            {
                return m_MainID;
            }
            set
            {
                m_MainID = value;
            }
        }

        private int m_Seq;
        public int Seq
        {
            get
            {
                return m_Seq;
            }
            set
            {
                m_Seq = value;
            }
        }


        private decimal m_Qty;
        public decimal Qty
        {
            get
            {
                return m_Qty;
            }
            set
            {
                m_Qty = value;
            }
        }
        #endregion
        #region 自定义方法
        /// <summary>
        /// 初始化录入控件
        /// </summary>
        void IniFabInput()
        {
            string sql = string.Empty;
            sql = "SELECT  ID,SubSeq,0 SelectFlag,BoxNo,Qty,Weight,Yard,GoodsLevel,'' ItemModel,'' JarNum FROM WH_IOFormDtsPack WHERE DID= " + SysString.ToDBString(ID);
            DataTable dt = SysUtils.Fill(sql);

            ucFabInput1.UCDataSource = dt;
            ucFabInput1.UCAct();

        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOFormDtsPack[] GetEntityDts()
        {
            int Num = 0;
            for (int i = 0; i < ucFabInput1.UCDataSource.Rows.Count; i++)
            {

                if (SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Qty"]) > 0 || SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Weight"]) > 0 || SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Yard"]) > 0)
                {
                    Num++;
                }
            }
            IOFormDtsPack[] entityDts = new IOFormDtsPack[Num];
            int index = 0;
            for (int i = 0; i < ucFabInput1.UCDataSource.Rows.Count; i++)
            {
                if (SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Qty"]) > 0 || SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Weight"]) > 0 || SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Yard"]) > 0)
                {
                    entityDts[index] = new IOFormDtsPack();
                    entityDts[index].ID = SysConvert.ToInt32(ucFabInput1.UCDataSource.Rows[i]["ID"]);
                    entityDts[index].SelectByID();
                    entityDts[index].MainID = m_MainID;
                    entityDts[index].Seq = m_Seq;
                    entityDts[index].DID = m_ID;
                    entityDts[index].SubSeq = SysConvert.ToInt32(ucFabInput1.UCDataSource.Rows[i]["SubSeq"]);
                    entityDts[index].Qty = SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Qty"]);
                    entityDts[index].Weight = SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Weight"]);
                    entityDts[index].Yard = SysConvert.ToDecimal(ucFabInput1.UCDataSource.Rows[i]["Yard"]);
                    entityDts[index].GoodsLevel = SysConvert.ToString(ucFabInput1.UCDataSource.Rows[i]["GoodsLevel"]);
                    index++;
                }
            }

            return entityDts;
        }

        #endregion

        #region 窗体事件
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                IniFabInput();

                if (m_PackType == (int)EnumPackType.仓库单据)
                {
                    string sql = "select * from WH_IOFormDts where ID=" + m_ID;
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        lblItemInfo.Text = " 产品编号:" + SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                        lblItemInfo.Text += " 色号:" + SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                        lblItemInfo.Text += " 缸号:" + SysConvert.ToString(dt.Rows[0]["JarNum"]);
                    }

                }



            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion


        #region 按钮事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Focus();
                if (m_PackType == (int)EnumPackType.仓库单据)
                {

                    IOFormDtsPackRule rule = new IOFormDtsPackRule();
                    IOFormDtsPack[] entityDts = GetEntityDts();
                    rule.RSave(m_ID, m_MainID, m_Seq, entityDts, m_UpdateFlag);

                    m_SaveFlag = true;
                }
                else
                {

                }
                this.ShowInfoMessage("保存成功！");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion









    }
}