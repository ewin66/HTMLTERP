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
    /// ��ⵥϸ�뱣��
    /// ����ǿ
    /// 2014-4-5
    /// 
    /// �¼Ӻ�
    /// 2014-5-8
    /// </summary>
    public partial class frmLoadPackNo : BaseForm
    {
        public frmLoadPackNo()
        {
            InitializeComponent();
        }

        #region ����

        /// <summary>
        /// �����־
        /// </summary>
        bool m_SaveFlag = false;
        /// <summary>
        /// �����־
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
        /// �޸ı�־
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
        #region �Զ��巽��
        /// <summary>
        /// ��ʼ��¼��ؼ�
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
        /// ���ʵ��
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

        #region �����¼�
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                IniFabInput();

                if (m_PackType == (int)EnumPackType.�ֿⵥ��)
                {
                    string sql = "select * from WH_IOFormDts where ID=" + m_ID;
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        lblItemInfo.Text = " ��Ʒ���:" + SysConvert.ToString(dt.Rows[0]["ItemCode"]);
                        lblItemInfo.Text += " ɫ��:" + SysConvert.ToString(dt.Rows[0]["ColorNum"]);
                        lblItemInfo.Text += " �׺�:" + SysConvert.ToString(dt.Rows[0]["JarNum"]);
                    }

                }



            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion


        #region ��ť�¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Focus();
                if (m_PackType == (int)EnumPackType.�ֿⵥ��)
                {

                    IOFormDtsPackRule rule = new IOFormDtsPackRule();
                    IOFormDtsPack[] entityDts = GetEntityDts();
                    rule.RSave(m_ID, m_MainID, m_Seq, entityDts, m_UpdateFlag);

                    m_SaveFlag = true;
                }
                else
                {

                }
                this.ShowInfoMessage("����ɹ���");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion









    }
}