using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{

    /// <summary>
    /// ���ܣ����ز����� �� ���ز������б�ؼ�����
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-27
    /// </summary>
    public partial class UCFabLTile : UCFabBase
    {
        public UCFabLTile()
        {
            InitializeComponent();
        }
        #region ��ʱ��̬�����������ƶ���ȫ�ֱ��������������ݿ���
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//Ĭ��ɫϵ

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//ż����ɫϵ 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//ż����ɫϵ 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//ѡ��ɫϵ
        #endregion
        #region ����
        /// <summary>
        /// ѡ��
        /// </summary>
        private bool m_UCChecked = false;
        /// <summary>
        /// ѡ��
        /// </summary>
        public bool UCChecked
        {
            get
            {
                return m_UCChecked;
            }
            set
            {
                m_UCChecked = value;
                picShow.Visible = value;
                ControlBackColorSet();
                if (object_CheckedChanged != null)
                {
                    object_CheckedChanged(this);//����ί�г��򣬷���ѡ��ֵ��Group�ؼ�
                }
                //chkSelect.Checked = m_UCChecked;
            }
        }

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
        /// ��������
        /// </summary>
        string[] m_UCAttachProt = new string[] { };
        /// <summary>
        /// ��������
        /// </summary>
        public string[] UCAttachProt
        {
            get
            {
                return m_UCAttachProt;
            }
            set
            {
                m_UCAttachProt = value;

                if (value.Length >= 3)
                {
                    lblInfo1.Text = value[0];//���
                    lblInfo2.Text = value[1];//����
                    lblInfo3.Text = value[2];//�׺�
                    lblInfo5.Text = value[3];//����
                    lblInfo6.Text = value[4];//�ȼ�
                    lblInfo7.Text = value[5];//����
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

        #region �����¼�
        public UCFabRowIndexChanged UCControl_RowIndexChanged;
        #endregion

        #region �ⲿ���÷���
        /// <summary>
        /// �ⲿ��ʼ��ֵ
        /// </summary>
        /// <param name="p_ISN">Ψһ�����</param>
        /// <param name="p_AttachProt">������������</param>
        /// <param name="p_Checked">ѡ�����</param>
        /// <param name="p_UCIndex">�ؼ�����ɫϵ������ɫϵ</param>
        public void IniValue(string p_ISN, string[] p_AttachProt, bool p_Checked, int p_UCIndex)
        {
            UCISN = p_ISN;
            UCAttachProt = p_AttachProt;
            UCBackColorIndex = p_UCIndex;
            m_UCChecked = p_Checked;
            picShow.Visible = UCChecked;
            ControlBackColorSet();
        }
        #endregion
        #region �ڲ�����
        /// <summary>
        /// �ؼ���ɫ�趨
        /// </summary>
        void ControlBackColorSet()
        {
            if (this.UCChecked)//���ѡ�иı���ɫ
            {
                panTile.Appearance.BackColor = UCSelectColor;
                panTile.Appearance.BackColor2 = UCSelectColor;
            }
            else//���δѡ�񣬻ָ���ɫ
            {
                panTile.Appearance.BackColor = saveBackColor;
                panTile.Appearance.BackColor2 = saveBackColor2;
            }
        }
        #endregion

        #region ȫ�ֱ���
        Color saveBackColor = Color.White;
        Color saveBackColor2 = Color.White;


        public UCFabLTileCheckChanged object_CheckedChanged;
        #endregion

        #region �����¼�
        /// <summary>
        /// ѡ��ı� ���ô���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //m_UCChecked = chkSelect.Checked;

                ControlBackColorSet();
                object_CheckedChanged(this);//����ί�г��򣬷���ѡ��ֵ��Group�ؼ�
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabLTile_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblInfo1.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.lblInfo2.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.lblInfo3.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.lblInfo4.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.lblInfo5.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.lblInfo6.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.lblInfo7.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.label3.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.label5.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.label6.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.label7.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.label8.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.panTile.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);


                this.panTile.Paint += new PaintEventHandler(ctlDisplay_Paint);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #endregion


        #region �����¼�


        /// <summary>
        /// ѡ��/��ѡ
        /// ��ֱ�ӵ��ã���������ؼ��Ҽ�Ҳ��ִ�д��¼�����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlSelect_Click()
        {
            try
            {
                m_UCChecked = !m_UCChecked;
                picShow.Visible = UCChecked;
                ControlBackColorSet();
                object_CheckedChanged(this);//����ί�г��򣬷���ѡ��ֵ��Group�ؼ�
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ����/Label �����ѡ�У��Ҽ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panTile_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)//���ʹ��
                {
                    ControlSelect_Click();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ������ı���ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                UCControl_RowIndexChanged(sender, m_UCRowIndex);//ί���¼�
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion



    }
}
