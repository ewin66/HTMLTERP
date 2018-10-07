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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmKPEdit :BaseForm
    {
        public frmKPEdit()
        {
            InitializeComponent();
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

        private string m_ISN;
        public string ISN
        {
            get
            {
                return m_ISN;
            }
            set
            {               
                m_ISN = value;
                if (m_ISN != string.Empty)//赋值条码的情况同时进行ID赋值
                {
                    string sql = string.Empty;
                    sql = "SELECT ID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(m_ISN);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        m_ID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                    }
                }
            }
        }



        /// <summary>
        /// 开匹标志
        /// </summary>
        private bool m_KPFinishFlag = false;
        /// <summary>
        /// 开匹完成标志
        /// </summary>
        public bool KPFinishFlag
        {
            get
            {
                return m_KPFinishFlag;
            }
            set
            {
                m_KPFinishFlag = value;
            }
        }
      

     


        
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_ID == 0)
                {
                    this.ShowMessage("未找到此匹数据");
                    this.Close();
                }
                else
                {
                    PackBox entity = new PackBox();
                    entity.ID = m_ID;
                    entity.SelectByID();
                    lblInfo1.Text = entity.BoxNo;
                    lblInfo2.Text = entity.Qty.ToString();

                }
               
 
            }
            catch (Exception E)
            {
               
            }

        }

     

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {


                if (SysConvert.ToDecimal(txtQty.Text.Trim()) <= 0)
                {
                    this.ShowMessage("清输入数量");
                    return;
                }

                PackBox entity = new PackBox();
                entity.ID = m_ID;
                entity.SelectByID();

                if (entity.Qty < SysConvert.ToDecimal(txtQty.Text.Trim()))
                {
                    this.ShowMessage("需开匹的数量要小于原有数量");
                    return;
                }

                PackBoxKPRule rule = new PackBoxKPRule();
                rule.RAdd(m_ID,SysConvert.ToDecimal(txtQty.Text.Trim()),FParamConfig.LoginID);
                m_KPFinishFlag = true;
                this.ShowInfoMessage("开匹完成");
                this.Close();



            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }








    }
}