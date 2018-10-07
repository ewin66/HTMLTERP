using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameCore;
using HttSoft.Framework;


namespace MLTERP
{
    public partial class frmWait : Form
    {
        public frmWait()
        {
            InitializeComponent();

            worker.WorkerReportsProgress = true;

            worker.WorkerSupportsCancellation = true;

            //��ʽ������ĵط�
            worker.DoWork += new DoWorkEventHandler(DoWork);

            //�������ʱҪ���ģ�������ʾ�ȵ�
            worker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);

            //�������ʱ���������
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
        }

        #region �������

        private string m_ConditionStr;
        public string ConditionStr
        {
            get
            {
                return m_ConditionStr;
            }
            set
            {
                m_ConditionStr = value;
            }
        }

        private string m_MakeDateS;
        public string MakeDateS
        {
            get
            {
                return m_MakeDateS;
            }
            set
            {
                m_MakeDateS = value;
            }
        }

        private string m_MakeDateE;
        public string MakeDateE
        {
            get
            {
                return m_MakeDateE;
            }
            set
            {
                m_MakeDateE = value;
            }
        }

        private DataTable m_Dt;
        public DataTable Dt
        {
            get
            {
                return m_Dt;
            }
            set
            {
                m_Dt = value;
            }
        }

        private int m_PDFlag=0;
        public int PDFlag
        {
            get
            {
                return m_PDFlag;
            }
            set
            {
                m_PDFlag = value;
            }
        }

        private int m_ItemTestFlag = 0;
        public int ItemTestFlag
        {
            get
            {
                return m_ItemTestFlag;
            }
            set
            {
                m_ItemTestFlag = value;
            }
        }
        #endregion


        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                this.progressBar1.Visible = true;
                worker.RunWorkerAsync();//��ʼ
               
                worker.CancelAsync();//����

               
                
            }
            catch (Exception E)
            {
                //
            }
        }

        private void getItemGZ()
        {
           
            m_Dt = SysUtils.Fill(m_ConditionStr);
            if (PDFlag == 1)
            {
                SetGridViewPD(m_Dt);
            }
            if (ItemTestFlag == 1)
            {
                SetGridViewItemTest(m_Dt);
            }
           
        }

        private void SetGridViewPD(DataTable p_dt)
        {
            foreach (DataRow dr in p_dt.Rows)
            {
                string sectionid = SysConvert.ToString(dr["SectionID"]);
                string itemcode = SysConvert.ToString(dr["ItemCode"]);
                string colornum = SysConvert.ToString(dr["ColorNum"]);
                string colorname = SysConvert.ToString(dr["ColorName"]);
                string sql = "SELECT ID FROM UV1_WH_IOFormDts WHERE SubType IN (SELECT ID FROM Enum_FormList WHERE ISNULL(CheckFlag,0)=1) ";
                sql += " AND ItemCode=" + SysString.ToDBString(itemcode);
                sql += " AND ColorNum=" + SysString.ToDBString(colornum);
                sql += " AND ColorName=" + SysString.ToDBString(colorname);
                sql += " AND ISNULL(SubmitFlag,0)=1 ";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    dr["PD"] = "���̿�";
                }
                else
                {
                    dr["PD"] = "δ�̿�";
                }
            }
        }

        private void SetGridViewItemTest(DataTable p_dt)
        {
            foreach (DataRow dr in p_dt.Rows)
            {
                string sql = "SELECT FormNo FROM Att_ItemTestForm WHERE ItemCode=" + SysString.ToDBString(dr["ItemCode"].ToString());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    string FormNoStr = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (FormNoStr != "")
                        {
                            FormNoStr += ",";
                        }
                        FormNoStr += SysConvert.ToString(dt.Rows[i][0]);
                    }
                    dr["ItemTest"] = FormNoStr;

                }

            }
        }
        //���� RunWorkerAsync ʱ����
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ComputeFibonacci(worker, e);
            getItemGZ();
            this.Close();
            //��ȡ�첽���������ֵ����ComputeFibonacci(worker, e)����ʱ���첽���̽���
        }

        //���� ReportProgress ʱ����
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            //���첽������ȵİٷֱȸ���������
        }

        //����̨��������ɡ���ȡ���������쳣ʱ����
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("��ɣ�");
            this.progressBar1.Visible = false;
        }

        private int ComputeFibonacci(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                //�ж�Ӧ�ó����Ƿ�ȡ����̨����
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    worker.ReportProgress(i);
                }

                System.Threading.Thread.Sleep(30);
                this.progressBar1.Maximum =100;
                this.progressBar1.Value =i;
                this.lbProgress.Text = i.ToString() + "%";
               
            }
           
            return -1;
        }


    }

}