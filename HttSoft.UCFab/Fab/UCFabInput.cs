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
    /// ���ܣ�¼�������뵥���ÿؼ�  �ܿؼ�
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-28
    /// </summary>
    public partial class UCFabInput : UCFabBase
    {
        public UCFabInput()
        {
            InitializeComponent();
        }


        #region ����

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
                //m_UCDataSource.ColumnChanged += new DataColumnChangeEventHandler(UCDataSourceOnColumnChanged);
            }
            get
            {
                PropProcVolumnNum(m_UCDataSource);
                return m_UCDataSource;
            }
        }



        bool m_UCActFlag = false;//�Ƿ�ִ�й���־��δִ�еĸı�ֵ��ִ��

        ///// <summary>
        ///// ����Դ��ֵ�ı�
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="args"></param>
        //protected void UCDataSourceOnColumnChanged(Object sender, DataColumnChangeEventArgs args)
        //{
        //    if (args.Column.ColumnName == "SelectFlag")//ѡ����ֵ�ı������°�ѡ����
        //    {
        //        UCFabBaseSelectCtl ucfbsc = UCFindSelectCtl();
        //        if (ucfbsc != null)
        //        {
        //            m_UCDataSource.AcceptChanges();
        //            DataTable dt = UCSelectDataSource;//ʵ��������ִ����ѡ����
        //            //ucfbsc.UCAct();//�������ѡ�����Ƕ�ģʽ������½����´������
        //        }
        //    }
        //}


        /// <summary>
        /// ����ƥ��
        /// ���δ����Ļ�
        /// </summary>
        /// <param name="p_Dt"></param>
        void PropProcVolumnNum(DataTable p_Dt)
        {
            DataRow[] drA = p_Dt.Select(" ISNULL(SubSeq,0)=0 AND (ISNULL(Qty,0)<>0 OR ISNULL(Weight,0)<>0 OR ISNULL(Yard,0)<>0)");//����������ƥ�ŵ�����
            if(drA.Length>0)
            {
                int maxSubSeq=0;

                DataRow[] drB = p_Dt.Select(" ISNULL(SubSeq,0)<>0"," SubSeq DESC");//��ȡ���ƥ��
                if (drB.Length > 0)
                {
                    maxSubSeq = SysConvert.ToInt32(drB[0]["SubSeq"]);
                }

                for (int i = 0; i < drA.Length; i++)
                {
                    maxSubSeq++;
                    drA[i]["SubSeq"] = maxSubSeq;
                }
            }
        }

        #endregion

        #region ȫ�ֱ���
        #endregion


        #region �ⲿ���÷���




        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public void UCAct()
        {
            UCActLoad();

            m_UCActFlag = true;
            //UCActSelect();
        }





        #endregion

        #region �ڲ�����
        /// <summary>
        /// ���ؿؼ�
        /// </summary>
        void UCActLoad()
        {    

            RemoveUserCtl(panGroupTopRight);
            //panGroupTopRight.Controls.Clear();
            //ClearControlDispose(cla);
            //����¼��ؼ�BEGIN

            int colCount = UCFabParamSet.GetIntValueByID(6022);//�뵥�༭����ģʽ����
            if (radgOPType.SelectedIndex == 2)
            {
                colCount = UCFabParamSet.GetIntValueByID(6023);//�뵥�༭����ģʽÿ�д�����
            }
            if (colCount <= 0)
            {
                colCount = 8;
            }

            int inputNum = UCFabParamSet.GetIntValueByID(6025);//�뵥�༭����ģʽ������
            if (inputNum > 0)
            {
                drpInputNum.Text = inputNum.ToString();
            }

            bool volumeNumberShow = SysConvert.ToBoolean(UCFabParamSet.GetIntValueByID(6024));//����Ƿ���ʾ

            UCFabBaseInputCtl ucflbc = CreateFabLoadControl();
            ucflbc.UCDataSource = m_UCDataSource;
            ucflbc.UCColumnCount = colCount;// 10;
            ucflbc.UCInputCount = SysConvert.ToInt32(drpInputNum.Text);//¼�������
            ucflbc.Dock = DockStyle.Fill;
            ucflbc.UCVolumeNumberShowFlag = volumeNumberShow;//����Ƿ���ʾ            

            panGroupTopRight.Controls.Add(ucflbc);

            ucflbc.UCAct();
            //����¼��ؼ�END

        }

        ///// <summary>
        ///// �����Դ
        ///// </summary>
        ///// <param name="cla"></param>
        //void ClearControlDispose(ControlCollection cla)
        //{
        //    foreach (Control ctl in cla)
        //    {
        //        ctl.Dispose();
        //    }
        //}


        /// <summary>
        /// Ѱ��¼���û��ؼ�
        /// </summary>
        /// <returns></returns>
        UCFabBaseInputCtl UCFindInputCtl()
        {
            foreach (Control ctl in panGroupTopRight.Controls)
            {
                if (ctl is UCFabBaseInputCtl)
                {
                    return (UCFabBaseInputCtl)ctl;
                }
            }
            return null;
        }



        /// <summary>
        /// ����¼��ؼ�
        /// </summary>
        UCFabBaseInputCtl CreateFabLoadControl()
        {
            UCFabBaseInputCtl ucfic;
            switch (radgOPType.SelectedIndex)
            {
                case 0:
                    ucfic = new UCFabIHori();
                    break;
                case 1:
                    ucfic = new UCFabIGridView();
                    break;
                case 2:
                    ucfic = new UCFabITileGroup();
                    break;
                default:
                    goto case 0;
            }
            ucfic.Name = "ucfic";
            return ucfic;
        }



        /// <summary>
        /// ��������¼��ؼ�����Դ
        /// </summary>
        /// <param name="startIndex">��ʼλ</param>
        /// <param name="fabCount">ƥ��</param>
        /// <param name="perQty">ÿƥ����</param>
        /// <returns>true/false ���������û�иı�</returns>
        bool ProBatchDataSource(int startIndex, int fabCount, decimal perQty)
        {
            bool AddFlag = false;
            int fabNo = 0;//���,��ǰ��¼����
            if (m_UCDataSource.Rows.Count < startIndex + fabCount + 1)//�����������,һ�㲻��Ӱ�죬�����жϺ�
            {
                UCFabCommon.AddDtRow(m_UCDataSource, startIndex + fabCount + 1);
                AddFlag = true;
            }
            //if (startIndex > 0)//��ȡ��һ���
            //{
            //    fabNo = SysConvert.ToInt32(m_UCDataSource.Rows[startIndex - 1]["SubSeq"]);
            //}

            //��ȡ�����
            DataRow[] drA = m_UCDataSource.Select("1=1", "SubSeq DESC");
            if (drA.Length > 0)
            {
                fabNo = SysConvert.ToInt32(drA[0]["SubSeq"]);
            }

            for (int i = startIndex; i < startIndex + fabCount; i++)//��ʼѭ����ֵ
            {
                m_UCDataSource.Rows[i]["SubSeq"] = (fabNo + i - startIndex + 1).ToString();
                m_UCDataSource.Rows[i]["Qty"] = perQty;
            }

            return AddFlag;
            
        }
        #endregion


        #region �ؼ��¼�
        /// <summary>
        /// �ؼ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabInput_Load(object sender, EventArgs e)
        {
            try
            {
                int modelIndex = UCFabParamSet.GetIntValueByID(6021);//�뵥��ʾģʽĬ�����
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
        /// ����¼�밴ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputBatch_Click(object sender, EventArgs e)
        {
            try
            {
                int startIndex = 0;
                UCFabBaseInputCtl ctl = UCFindInputCtl();
                startIndex = ctl.UCCurrnetFocusIndex;

                UCFabInputBatchFrm frm = new UCFabInputBatchFrm();
                frm.ShowDialog();
                if (frm.UCOKFlag)//ȷ������¼��
                {
                    int fabCount = frm.UCFabCount;
                    decimal perQty = frm.UCFabPerQty;

                    bool addFlag=ProBatchDataSource(startIndex, fabCount, perQty);//��������¼������Դ

                    if (addFlag)
                    {
                        ctl.UCAct();//�ػ����
                    }
                    else//û���ػ棬�����¸�ֵ����
                    {
                        ctl.UCBind();//�ػ����
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


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
        /// ¼����������ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpInputNum_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)
                {
                    UCFabBaseInputCtl ctl = UCFindInputCtl();
                    ctl.UCInputCount = SysConvert.ToInt32(drpInputNum.Text);
                    ctl.UCInputCountChanged();//���÷���
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
