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
    /// ���ܣ��������ϵ��ÿؼ�  �ܿؼ�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-28
    /// </summary>
    public partial class UCFabLoad : UCFabBase
    {
        public UCFabLoad()
        {
            InitializeComponent();
        }

        #region ȫ�ֱ���
        /// <summary>
        /// ��ƥ����¼�
        /// </summary>
        public UCFabSelectCancel UCEventKPClick;
        #endregion


        #region ����
        /// <summary>
        /// ����ƥ��־
        /// </summary>
        private bool m_UCAllowKPFlag = false;
        /// <summary>
        /// ����ƥ��־
        /// </summary>
        public bool UCAllowKPFlag
        {
            get
            {
                return m_UCAllowKPFlag;
            }
            set
            {
                m_UCAllowKPFlag = value;
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
                m_UCDataSource.ColumnChanged += new DataColumnChangeEventHandler(UCDataSourceOnColumnChanged);
            }
        }

        /// <summary>
        /// ����Դ��ֵ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void UCDataSourceOnColumnChanged(Object sender, DataColumnChangeEventArgs args)
        {
            if (args.Column.ColumnName == "SelectFlag")//ѡ����ֵ�ı������°�ѡ����
            {
                UCFabBaseSelectCtl ucfbsc = UCFindSelectCtl();
                if (ucfbsc != null)
                {
                    m_UCDataSource.AcceptChanges();
                    DataTable dt = UCSelectDataSource;//ʵ��������ִ����ѡ����
                    if (radgViewType.SelectedIndex == 0)
                    {
                        ucfbsc.UCAct();//�������ѡ�����Ƕ�ģʽ������½����´������
                    }
                }
            }
        }


        /// <summary>
        /// ѡ�������Դ
        /// </summary>
        DataTable m_UCSelecDataSource;
        /// <summary>
        /// ��ȡѡ�������Դ
        /// </summary>
        public DataTable UCSelectDataSource
        {
            get
            {
                if (m_UCSelecDataSource == null)
                {
                    m_UCSelecDataSource = m_UCDataSource.Clone();
                }
                else
                {
                    m_UCSelecDataSource.Rows.Clear();
                }

                DataRow[] drA = m_UCDataSource.Select("SelectFlag=1");//Ѱ��ѡ��Ĵ���
                for (int i = 0; i < drA.Length; i++)
                {
                    DataRow outdr = m_UCSelecDataSource.NewRow();
                    for (int j = 0; j < m_UCSelecDataSource.Columns.Count; j++)//ѭ������
                    {
                        outdr[j] = drA[i][j];
                    }
                    m_UCSelecDataSource.Rows.Add(outdr);
                }
                return m_UCSelecDataSource;
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
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public void UCAct()
        {
            UCActLoad();
            UCActSelect();

            m_UCActFlag = true;
        }



        /// <summary>
        /// ִ�п�ƥ�����»滭
        /// </summary>
        public void UCActKP(DataTable dtNew)
        {
            DataTable dtOld = m_UCDataSource.Copy();

            foreach (DataRow drNew in dtNew.Rows)
            {
                drNew["SelectFlag"] = 0;
            }

            string isnSelect = string.Empty;
            DataRow[] drOldA = dtOld.Select("SelectFlag=1");
            for (int i = 0; i < drOldA.Length; i++)
            {
                if (isnSelect != string.Empty)
                {
                    isnSelect += ",";
                }
                isnSelect += SysString.ToDBString(drOldA[i]["BoxNo"].ToString());
            }
            if (isnSelect != string.Empty)//�������ѡ
            {
                DataRow[] drA = dtNew.Select("BoxNo IN(" + isnSelect + ")");
                for (int i = 0; i < drA.Length; i++)//����ѡ����ı��־
                {
                    drA[i]["SelectFlag"] = 1;
                }
            }

            UCDataSource = dtNew;
            UCAct();
        }


       
        #endregion

        #region �ڲ�����
        /// <summary>
        /// ���ؿؼ�
        /// </summary>
        void UCActLoad()
        {
            int colCount = UCFabParamSet.GetIntValueByID(6012);//�뵥ѡ�����ģʽÿ�д�����
            if (colCount <= 0)
            {
                colCount = 5;
            }
            if (radgOPType.SelectedIndex == 2)//���ģʽ
            {
                colCount = UCFabParamSet.GetIntValueByID(6013);//�뵥ѡ����ģʽÿ�д�����
                if (colCount <= 0)
                {
                    colCount = 10;
                }
            }
            
            
            //����չʾ�ؼ�BEGIN
            RemoveUserCtl(panGroupTopRight);
            //panGroupTopRight.Controls.Clear();
            UCFabBaseLoadCtl ucflbc = CreateFabLoadControl();
            ucflbc.UCDataSource = m_UCDataSource;
            ucflbc.UCColumnCount = colCount;
            ucflbc.UCAllowKPFlag = UCAllowKPFlag;
            if (UCAllowKPFlag)
            {
                ucflbc.UCEventKPClick += new UCFabSelectCancel(UCEventKPClick);
            }
            ucflbc.Dock = DockStyle.Fill;
            panGroupTopRight.Controls.Add(ucflbc);

            ucflbc.UCAct();
            //����չʾ�ؼ�END
        }

        

        /// <summary>
        /// ��ѡ�ؼ�
        /// </summary>
        void UCActSelect()
        {
            int colCount = UCFabParamSet.GetIntValueByID(6002);//�뵥��ʾ����ģʽ����
            if (colCount <= 0)
            {
                colCount = 10;
            }
            //���ؽ��չʾ�ؼ�BEGIN
            panGroupTopLeft.Controls.Clear();
            UCFabBaseSelectCtl ucfbsc = CreateFabSelectControl();
            ucfbsc.UCDataSource = UCSelectDataSource;
            ucfbsc.UCColumnCount = colCount;// 10;
            ucfbsc.UCFabSelect_CancelOne += new UCFabSelectCancel(ucSelect_CancelOne);
            ucfbsc.Dock = DockStyle.Fill;
            panGroupTopLeft.Controls.Add(ucfbsc);
            ucfbsc.UCAct();
            //���ؽ��չʾ�ؼ�END
        }

        /// <summary>
        /// ȡ��һ���ѹ�ѡ�뵥
        /// </summary>
        /// <param name="p_ISN"></param>
        private void ucSelect_CancelOne(string p_ISN)
        {
            UCFabBaseLoadCtl uc = UCFindLoadCtl();
            if (uc != null)
            {
                uc.UCCancelOne(p_ISN);
            }
        }

        /// <summary>
        /// Ѱ�Ҽ����û��ؼ�
        /// </summary>
        /// <returns></returns>
        UCFabBaseLoadCtl UCFindLoadCtl()
        {
            foreach (Control ctl in panGroupTopRight.Controls)
            {
                if (ctl is UCFabBaseLoadCtl)
                {
                    return (UCFabBaseLoadCtl)ctl;
                }
            }
            return null;
        }


        /// <summary>
        /// Ѱ�Ҽ�����ѡ��ʾ�ؼ�
        /// </summary>
        /// <returns></returns>
        UCFabBaseSelectCtl UCFindSelectCtl()
        {
            foreach (Control ctl in panGroupTopLeft.Controls)
            {
                if (ctl is UCFabBaseSelectCtl)
                {
                    return (UCFabBaseSelectCtl)ctl;
                }
            }
            return null;
        }

        /// <summary>
        /// �������ؼ����ؼ�
        /// </summary>
        UCFabBaseLoadCtl CreateFabLoadControl()
        {
            UCFabBaseLoadCtl ucfbc;
            switch (radgOPType.SelectedIndex)
            {
                case 0:
                    ucfbc = new UCFabLTileGroup();
                    break;
                case 1:
                    ucfbc = new UCFabLGridView();
                    break;
                case 2:
                    ucfbc = new UCFabLTileSimpleGroup();
                    break;
                default:
                    goto case 0;
            }
            ucfbc.Name = "ucfblc";
            return ucfbc;
        }


        /// <summary>
        /// ����ѡ�����ؼ�
        /// </summary>
        UCFabBaseSelectCtl CreateFabSelectControl()
        {
            UCFabBaseSelectCtl ucfbsc;
            switch (radgViewType.SelectedIndex)
            {
                case 0:
                    ucfbsc = new UCFabSVHori();
                    break;               
                case 1:
                    ucfbsc = new UCFabSGridView();
                    break;               
                default:
                    goto case 0;
            }
            ucfbsc.Name = "ucfbsc";
            return ucfbsc;
        }
        #endregion

        #region ��ť�¼�
        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                UCFabBaseLoadCtl uc = UCFindLoadCtl();
                if (uc != null)
                {
                    uc.UCSelectAll();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��ѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFan_Click(object sender, EventArgs e)
        {
            try
            {
                UCFabBaseLoadCtl uc = UCFindLoadCtl();
                if (uc != null)
                {
                    uc.UCSelectFan();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �ؼ��¼�
        /// <summary>
        /// �ؼ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabLoad_Load(object sender, EventArgs e)
        {
            try
            {
                int vmodelIndex = UCFabParamSet.GetIntValueByID(6001);//�뵥��ʾģʽĬ�����
                if (vmodelIndex > 0 && vmodelIndex < radgViewType.Properties.Items.Count)
                {
                    radgViewType.SelectedIndex = vmodelIndex;
                }

                int modelIndex = UCFabParamSet.GetIntValueByID(6011);//�뵥ѡ��ģʽĬ�����
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
                if (m_UCActFlag)
                {
                    UCActLoad();
                    panGroupTopRight.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ��ʾģʽ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)
                {
                    UCActSelect();
                    panGroupTopLeft.Focus();
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
