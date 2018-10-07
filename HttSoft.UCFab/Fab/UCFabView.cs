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
    /// ���ܣ��鿴�����뵥�ؼ�  �ܿؼ�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-31
    /// </summary>
    public partial class UCFabView : UCFabBase
    {
        public UCFabView()
        {
            InitializeComponent();
        }

        #region ����

        /// <summary>
        /// ����ת��ģʽ
        /// </summary>
        private bool m_UCQtyConvertMode = false;
        /// <summary>
        /// ����ת��ģʽ
        /// ������û��ת��ģʽ����������ʾ�������޸�
        /// </summary>
        public bool UCQtyConvertMode
        {
            get
            {
                return m_UCQtyConvertMode;
            }
            set
            {
                m_UCQtyConvertMode = value;
            }
        }

        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ�굥λ
        /// </summary>
        private string m_UCQtyConvertModeInputUnit = string.Empty;
        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ�굥λ
        /// ���б����޸���ʾ��
        /// </summary>
        public string UCQtyConvertModeInputUnit
        {
            get
            {
                return m_UCQtyConvertModeInputUnit;
            }
            set
            {
                m_UCQtyConvertModeInputUnit = value;
            }
        }

        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ�굥λ
        /// </summary>
        private decimal m_UCQtyConvertModeInputConvertXS = 0;
        /// <summary>
        /// ����ת��ģʽ:ת��Ŀ��ϵ��
        /// ����ʾ��
        /// </summary>
        public decimal UCQtyConvertModeInputConvertXS
        {
            get
            {
                return m_UCQtyConvertModeInputConvertXS;
            }
            set
            {
                m_UCQtyConvertModeInputConvertXS = value;
            }
        }

        /// <summary>
        /// ���������ر�־
        /// </summary>
        private bool m_UCColumnISNHide = false;
        /// <summary>
        /// ���������ر�־
        /// ���������¼����뵥��ϸ����ʾ����
        /// </summary>
        public bool UCColumnISNHide
        {
            get
            {
                return m_UCColumnISNHide;
            }
            set
            {
                m_UCColumnISNHide = value;
            }
        }

        /// <summary>
        /// ����Դ
        /// </summary>
        DataTable m_UCDataSource = new DataTable();
        /// <summary>
        /// ����Դ
        /// ����Դ����0/1/2/3/4:ѡ���־/BoxNo/���/����/�׺�
        /// </summary>
        public DataTable UCDataSource
        {
            set
            {
                m_UCDataSource = value;
            }
            get
            {
                return m_UCDataSource;
            }
        }


        bool m_UCActFlag = false;//�Ƿ�ִ�й���־��δִ�еĸı�ֵ��ִ��

        #endregion



        #region �ⲿ���÷���
        ///// <summary>
        ///// ��ʼ������Դ�ṹ
        ///// </summary>
        //public void IniDataSourceStruct()
        //{
        //    m_UCDataSource.Columns.Add(new DataColumn("SelectFlag", typeof(int)));//ѡ��
        //    m_UCDataSource.Columns.Add(new DataColumn("BoxNo", typeof(string)));//����
        //    m_UCDataSource.Columns.Add(new DataColumn("SubSeq", typeof(string)));//���
        //    m_UCDataSource.Columns.Add(new DataColumn("Qty", typeof(decimal)));//����
        //    m_UCDataSource.Columns.Add(new DataColumn("JarNum", typeof(string)));//�׺�
        //    m_UCDataSource.Columns.Add(new DataColumn("ItemModel", typeof(string)));//Ʒ��
        //}


        /// <summary>
        /// ����ת��
        /// �����뵥��ӡ�ɶ�ά��ʽ
        /// </summary>
        /// <param name="dtSource">����Դ</param>
        /// <param name="p_ColCount">����</param>
        /// <returns>��0,2,4,6,...:ƥ�ţ���1,3,5,7,...:����</returns>
        public DataTable UCDataSourceVHori(DataTable dtSource, int p_ColCount)
        {
            DataTable outdt = new DataTable();
            outdt.Columns.Add(new DataColumn("ColTitle", typeof(string)));
            for (int i = 1; i <= p_ColCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));
            }
            //�������ϣ���ʼת������
            int rowIndex = 0;//ת�����к�
            int colIndex = 0;//ת�����к�
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                rowIndex = i / p_ColCount;
                colIndex = i % p_ColCount;

                if (colIndex == 0)//��һ�У����������
                {
                    DataRow dr = outdt.NewRow();
                    dr["ColTitle"] = "ƥ��";
                    outdt.Rows.Add(dr);
                    DataRow dr2 = outdt.NewRow();
                    dr2["ColTitle"] = "����";
                    outdt.Rows.Add(dr2);
                    DataRow dr3 = outdt.NewRow();
                    dr3["ColTitle"] = "����";
                    outdt.Rows.Add(dr2);
                    DataRow dr4 = outdt.NewRow();
                    dr4["ColTitle"] = "�ȼ�";
                    outdt.Rows.Add(dr4);
                }

                //��ʼ��ֵ
                outdt.Rows[rowIndex * 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//ƥ��
                outdt.Rows[rowIndex * 4 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//����
                outdt.Rows[rowIndex * 4 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//����
                outdt.Rows[rowIndex * 4 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["GoodsLevel"].ToString();//����

            }

            return outdt;
        }


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public void UCAct()
        {
            UCActView();
            m_UCActFlag = true;
        }





        #endregion

        #region �ڲ�����

        /// <summary>
        /// ��ѡ�ؼ�
        /// </summary>
        void UCActView()
        {
            //���ؽ��չʾ�ؼ�BEGIN
            RemoveUserCtl(panGroupTopRight);
            //panGroupTopRight.Controls.Clear();


            lblInputInfo.Visible = UCQtyConvertMode;
            if (UCQtyConvertMode)
            {
                lblInputInfo.Text = "ת����λ:" + UCQtyConvertModeInputUnit + "  ϵ��:" + UCQtyConvertModeInputConvertXS;
            }

            UCFabBaseViewCtl ucfbsc = CreateFabViewControl();
            ucfbsc.UCDataSource = m_UCDataSource;
            int colCount = UCFabParamSet.GetIntValueByID(6002);//�뵥��ʾ����ģʽ����
            if (colCount <= 0)
            {
                colCount = 10;
            }
            bool volumeNumberShow = SysConvert.ToBoolean(UCFabParamSet.GetIntValueByID(6024));//����Ƿ���ʾ
            ucfbsc.UCColumnCount = colCount;//10
            ucfbsc.Dock = DockStyle.Fill;
            ucfbsc.UCVolumeNumberShowFlag = volumeNumberShow;//����Ƿ���ʾ
            ucfbsc.UCQtyConvertMode = UCQtyConvertMode;
            ucfbsc.UCQtyConvertModeInputUnit = UCQtyConvertModeInputUnit;
            ucfbsc.UCQtyConvertModeInputConvertXS = UCQtyConvertModeInputConvertXS;
            ucfbsc.UCColumnISNHide = UCColumnISNHide;
            panGroupTopRight.Controls.Add(ucfbsc);
            ucfbsc.UCAct();
            //���ؽ��չʾ�ؼ�END
        }



        /// <summary>
        /// Ѱ�Ҽ����û��ؼ�
        /// </summary>
        /// <returns></returns>
        UCFabBaseViewCtl UCFindViewCtl()
        {
            foreach (Control ctl in panGroupTopRight.Controls)
            {
                if (ctl is UCFabBaseViewCtl)
                {
                    return (UCFabBaseViewCtl)ctl;
                }
            }
            return null;
        }





        /// <summary>
        /// ����ѡ�����ؼ�
        /// </summary>
        UCFabBaseViewCtl CreateFabViewControl()
        {
            UCFabBaseViewCtl ucfbvc;
            switch (radgOPType.SelectedIndex)
            {
                case 0://����
                    ucfbvc = new UCFabVHori();
                    break;
                case 1://GridView
                    ucfbvc = new UCFabVGridView();
                    break;
                default:
                    goto case 0;
            }
            ucfbvc.Name = "ucfbvc";
            return ucfbvc;
        }
        #endregion

        #region �ؼ��¼�
        /// <summary>
        /// �ؼ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabView_Load(object sender, EventArgs e)
        {
            try
            {
                int modelIndex = UCFabParamSet.GetIntValueByID(6001);//�뵥��ʾģʽĬ�����
                if (modelIndex > 0 && modelIndex < radgOPType.Properties.Items.Count)
                {
                    radgOPType.SelectedIndex = modelIndex;
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
        /// ����ģʽ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgOPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)//ִ�й��ټ���ִ�У�������ִ��
                {
                    UCActView();
                    panGroupTopRight.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


    }
}
