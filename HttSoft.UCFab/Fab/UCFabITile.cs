using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{

    /// <summary>
    /// ���ܣ�¼���뵥 ����
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-31
    /// </summary>
    public partial class UCFabITile : UCFabBase
    {
        public UCFabITile()
        {
            InitializeComponent();
            UCIniLoad();
        }


        #region ��ʱ��̬�����������ƶ���ȫ�ֱ��������������ݿ���
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//Ĭ��ɫϵ

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//ż����ɫϵ 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//ż����ɫϵ 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//ѡ��ɫϵ
        #endregion

        #region �����¼�
        public UCFabRowIndexChanged UCControl_RowIndexChanged;
        #endregion
        #region ����

        /// <summary>
        /// �����
        /// </summary>
        string m_UCISN = string.Empty;
        /// <summary>
        /// �����
        /// </summary>
        public string UCISN
        {
            get
            {
                return m_UCISN;
            }
            set
            {
                m_UCISN = value;
                lblInfo4.Text = value;
            }
        }


        /// <summary>
        /// �������
        /// </summary>
        int m_UCRowIndex = 0;
        /// <summary>
        /// �������
        /// </summary>
        public int UCRowIndex
        {
            get
            {
                return m_UCRowIndex;
            }
            set
            {
                m_UCRowIndex = value;
            }
        }

        /// <summary>
        /// ����X Y���
        /// </summary>
        string m_UCTileXY = "";
        /// <summary>
        /// ����X Y���
        /// </summary>
        public string UCTileXY
        {
            get
            {
                return m_UCTileXY;
            }
            set
            {
                m_UCTileXY = value;
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        DataRow m_DrSource;
        /// <summary>
        /// ������
        /// </summary>
        public DataRow DrSource
        {
            get
            {
                return m_DrSource;
            }
            set
            {
                m_DrSource = value;


                if (value != null)
                {
                    txtCode.Text = m_DrSource["SubSeq"].ToString();//���
                    txtQty.Text = m_DrSource["Qty"].ToString();//����
                    lblInfo4.Text = m_DrSource["BoxNo"].ToString();//BoxNo

                    //lblInfo4.Text = m_UCTileXY.ToString() + " " + this.Location.Y.ToString();//��ʱ����
                }
            }

        }

        /// <summary>
        /// ���ÿؼ�����ɫϵ
        /// 1/2
        /// </summary>
        int m_UCBackColorIndex = 1;

        /// <summary>
        /// ���ÿؼ�����ɫϵ
        /// 1/2
        /// </summary>
        public int UCBackColorIndex
        {
            get
            {
                return m_UCBackColorIndex;
            }
            set
            {
                if (value == 1)
                {
                    panTile.Appearance.BackColor = UCBackColor;
                    panTile.Appearance.BackColor2 = UCBackColor2;
                    saveBackColor = UCBackColor;
                    saveBackColor2 = UCBackColor2;
                }
                else if (value == 2)
                {
                    panTile.Appearance.BackColor = UCBackColorS;
                    panTile.Appearance.BackColor2 = UCBackColorS2;
                    saveBackColor = UCBackColorS;
                    saveBackColor2 = UCBackColorS2;
                }
                m_UCBackColorIndex = value;
            }
        }



        #endregion


        #region �ⲿ���÷���

        /// <summary>
        /// ����ˢ������
        /// </summary>
        public void UCBindData()
        {
            if (m_DrSource != null)
            {
                txtCode.Text = m_DrSource["SubSeq"].ToString();//���
                txtQty.Text = m_DrSource["Qty"].ToString();//����
                lblInfo4.Text = m_DrSource["BoxNo"].ToString();//BoxNo
            }
        }
        
        #endregion

        #region �ڲ�����
        /// <summary>
        /// �ؼ���ɫ�趨
        /// </summary>
        void ControlBackColorSet()
        {
            //if (this.UCChecked)//���ѡ�иı���ɫ
            //{
            //    panTile.Appearance.BackColor = UCSelectColor;
            //    panTile.Appearance.BackColor2 = UCSelectColor;
            //}
            //else//���δѡ�񣬻ָ���ɫ
            //{
            panTile.Appearance.BackColor = saveBackColor;
            panTile.Appearance.BackColor2 = saveBackColor2;
            //}
        }
        #endregion

        #region ȫ�ֱ���
        Color saveBackColor = Color.White;
        Color saveBackColor2 = Color.White;


        #endregion


        #region �������
        private void UCFabITile_Load(object sender, EventArgs e)
        {
            try
            {

                this.panTile.Paint += new PaintEventHandler(ctlDisplay_Paint);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��ʼ���ؼ��¼���
        /// </summary>
        void UCIniLoad()
        {
            try
            {
                //BindMouseClickEvent(new Control[] { lblInfo4, txtCode, txtQty, panTile, this });

                BindClickEvent(new Control[] { lblInfo4, txtCode, txtQty, panTile, this });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        ///// <summary>
        ///// �������
        ///// </summary>
        ///// <param name="p_Ctl"></param>
        //void BindMouseClickEvent(Control[] p_Ctl)
        //{
        //    for (int i = 0; i < p_Ctl.Length; i++)
        //    {
        //        p_Ctl[i].MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
        //    }
        //}

        /// <summary>
        /// �󶨵��
        /// </summary>
        /// <param name="p_Ctl"></param>
        void BindClickEvent(Control[] p_Ctl)
        {
            for (int i = 0; i < p_Ctl.Length; i++)
            {
                p_Ctl[i].Click += new System.EventHandler(Control_Click);
            }
        }

        #endregion
        #region ¼��ֵ�ı�
        /// <summary>
        /// ��Ÿı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(txtCode.Text.Trim()) != 0)
                {
                    DrSource["SubSeq"] = SysConvert.ToInt32(txtCode.Text.Trim());
                }
                else
                {
                    DrSource["SubSeq"] = DBNull.Value;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �����ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQty_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = 0;
                qty = SysConvert.ToDecimal(txtQty.Text.Trim());
                if (qty != 0)
                {
                    DrSource["Qty"] = qty;
                }
                else
                {
                    DrSource["Qty"] = DBNull.Value;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region �����¼�
        
        /// <summary>
        /// �ؼ�����ı丸�ؼ���ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ShowMessage(m_UCRowIndex.ToString());
                UCControl_RowIndexChanged(sender,m_UCRowIndex);//ί���¼�
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion




    }
}
