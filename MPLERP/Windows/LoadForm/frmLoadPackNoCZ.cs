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
using DevExpress.XtraEditors.Controls;
using System.IO.Ports;


namespace MLTERP
{
    /// <summary>
    /// ϵͳ����¼���뵥��ϸ
    /// </summary>
    public partial class frmLoadPackNoCZ :BaseForm
    {
        public frmLoadPackNoCZ()
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

        private void BindGrid()
        {
            string sql = "Select * from WH_IOFormDtsPack where 1=1";
            sql += " AND DID=" + m_ID;
            DataTable dt = SysUtils.Fill(sql);

            Common.AddDtRow(dt, 150);

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOFormDtsPack[] GetEntityDts()
        {
            int Num = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {

                if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i,"Qty")) > 0)
                {
                    Num++;
                }
            }
            IOFormDtsPack[] entityDts = new IOFormDtsPack[Num];
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")) > 0)
                {
                    entityDts[index] = new IOFormDtsPack();
                    entityDts[index].ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    entityDts[index].SelectByID();
                    entityDts[index].MainID = m_MainID;
                    entityDts[index].Seq = m_Seq;
                    entityDts[index].DID = m_ID;
                    //entityDts[index].SubSeq = SysConvert.ToInt32(ucFabInput1.UCDataSource.Rows[i]["SubSeq"]); ;
                    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SubSeq")) != 0)
                    {
                        entityDts[index].SubSeq = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SubSeq"));
                    }
                    else
                    {
                        entityDts[index].SubSeq = i + 1;
                    }
                    entityDts[index].Qty = SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty"));
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
                ProcessGrid.BindGridColumn(gridView1, this.FormID);//����
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//������UI


              Common.BindReport(drpReport,this.FormID,false);

              drpReport.EditValue = Common.BindReport(drpReport, this.FormID, false);

                txtQty.Focus();//�۽���������

                BindGrid();


                comm.PortName = "COM2";
                comm.BaudRate = 2400;


                #region ע���ȡ����¼�
                //��ʼ���������������б��   
                string[] ports = SerialPort.GetPortNames();
                if (ports.Length <= 0)
                {
                    return;
                }
                Array.Sort(ports);
                comboPortName.Items.AddRange(ports);
                comboPortName.SelectedIndex = comboPortName.Items.Count > 0 ? 0 : -1;


                comboBaudrate.SelectedIndex = comboBaudrate.Items.IndexOf("9600");

                comboPortName.Text = "COM2";
                comboBaudrate.Text = "2400";

                //��ʼ��SerialPort����   
                comm.NewLine = "\r\n";
                comm.RtsEnable = true;//����ʵ������ɡ�   

                //����¼�ע��   
                comm.DataReceived += comm_DataReceived;
                OpenFalg = true;
                #endregion


                comm.PortName = "COM2";
                comm.BaudRate = 2400;

                buttonOpenClose_Click(null, null);

                timer1.Interval = 1000 * 3;
                timer1.Start();

               
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

               
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (SysConvert.ToDecimal(gridView1.GetRowCellValue(i, "Qty")) == 0 && SysConvert.ToDecimal(txtQty.Text.Trim())!=0)
                        {
                            decimal a = Math.Round(SysConvert.ToDecimal(txtQty.Text.Trim()),1, MidpointRounding.AwayFromZero);
                            gridView1.SetRowCellValue(i, "Qty", SysConvert.ToDecimal(a));
                            gridView1.SetRowCellValue(i, "SubSeq", SysConvert.ToInt32(txtSubSeq.Text.Trim()));
                            break;
                        }
                    }


                    IOFormDtsPackRule rule = new IOFormDtsPackRule();
                    IOFormDtsPack[] entityDts = GetEntityDts();
                    if (entityDts.Length <= 1)
                    {
                        rule.RSave(m_ID, m_MainID, m_Seq, entityDts, false);
                    }
                    else
                    {
                        rule.RSave(m_ID, m_MainID, m_Seq, entityDts, true);
                    }
                    //rule.RSave(m_ID, m_MainID, m_Seq, entityDts, m_UpdateFlag);

                    m_SaveFlag = true;
                    
                }
                else
                {

                }
               // this.ShowInfoMessage("����ɹ���");
                btnSave.BackColor = Color.Green;
                this.txtQty.Text = "";

                txtSubSeq.Text = "";
                this.txtQty.Focus();
                BindGrid();
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion



        ///// <summary>
        ///// �󶨱�������
        ///// </summary>
        //private  void BindReport(p_DrpID)
        //{
        //    if (FormID != 0)
        //    {
        //        string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where ";//WinListID = " +  FormID.ToString() + "
        //        if (this.RightFormID != 0)
        //        {
        //            sql += " WinListID=" + this.RightFormID;
        //        }
        //        else
        //        {
        //            sql += " WinListID=" + this.FormID;
        //        }
        //        sql += " AND HeadTypeID=" + this.FormListAID;
        //        sql += " AND SubTypeID=" + this.FormListBID;
        //        sql += " ORDER BY Seq";
        //        DataTable dt = SysUtils.Fill(sql);
        //        FCommon.LoadDropItemComb(p_DrpID, dt, "ID", "ReportName", true);
        //        //if (dt.Rows.Count > 0)
        //        //{
        //        //    p_DrpID.ed = 1;
        //        //}
        //    }
        //}

        private void btnPreReview_Click(object sender, EventArgs e)
        {
            try
            {

                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.Ԥ��);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            try
            {

                //base.btnDesign_Click(sender, e);
                btnPrintAbount((int)ReportPrintType.���);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrintAbount((int)ReportPrintType.��ӡ);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ��ӡ��������
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();


            string GBIDStr = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));


            if (GBIDStr == "")
            {
                this.ShowMessage("��ѡ����Ҫ��ӡ������");
                return false;
            }


            //DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            //if (ci.SelectedItem == null)
            //{
            //    this.ShowMessage("��ѡ�񱨱�ģ��");
            //    return false;
            //}
            //int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            int tempReportID = SysConvert.ToInt32(drpReport.EditValue);
            if (tempReportID == 1)
            {
                this.ShowMessage("��ѡ�񱨱�ģ��");
                return false;
            }



            //2012/9/18 CJH ���Դ������ݱ����
            string sql = "SELECT * FROM UV1_WH_IOFormDtsPack WHERE DtsPackID IN(" + GBIDStr + ")";
            DataTable dt = SysUtils.Fill(sql);
            dt.TableName = "Dts";
            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dt);
            //FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, new DataTable[] { dt });

        

            //2012/9/18CJH Ϊ�˲��Դ������ݱ��ӡ���������ע��
            //FastReportX.ReportRun(tempReportID, p_ReportPrintType, new string[] { "ID" }, new string[] { GBIDStr });
            return true;
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave_Click(null, null);
                    
                }
               

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void frmLoadPackNoCZ_Activated(object sender, EventArgs e)
        {
            txtQty.Focus();
        }










        #region ��ȡ�������
        private SerialPort comm = new SerialPort();
        private StringBuilder builder = new StringBuilder();//�������¼��������з����Ĵ��������嵽���档   
        private long received_count = 0;//���ռ���   
        private long send_count = 0;//���ͼ���   
        private bool Listening = false;//�Ƿ�û��ִ����invoke��ز���   
        private bool Closing = false;//�Ƿ����ڹرմ��ڣ�ִ��Application.DoEvents������ֹ�ٴ�invoke   
        private List<byte> buffer = new List<byte>(8192);//Ĭ�Ϸ���1ҳ�ڴ棬��ʼ�����Ʋ�������   
        private byte[] binary_data_1 = new byte[12];//AA 44 05 01 02 03 04 05 EA   
        bool showflag = false;
        bool OpenFalg = false;
        decimal ReadDate = 0m;
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!comm.IsOpen)
            {
                buttonOpenClose_Click(null, null);
            }
        }

        private static object locker = new Object();
        #region ��ȡ�¼�

        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (locker)
            {
                if (Closing) return;//������ڹرգ����Բ�����ֱ�ӷ��أ��������ɴ��ڼ����̵߳�һ��ѭ��   
                try
                {
                    


                    Listening = true;//���ñ�ǣ�˵�����Ѿ���ʼ�������ݣ�һ���Ҫʹ��ϵͳUI�ġ�   
                    int n = comm.BytesToRead;//�ȼ�¼����������ĳ��ԭ����Ϊ��ԭ�򣬲�������֮��ʱ�䳤�����治һ��   
                    byte[] buf = new byte[n];//����һ����ʱ����洢��ǰ���Ĵ�������   
                    received_count += n;//���ӽ��ռ���   
                    comm.Read(buf, 0, comm.BytesToRead);//��ȡ��������   


                    //�����Ҫ���Э�飬ֻҪ��չ���data_n_catched�Ϳ����ˡ���������Э��������£�����������ݱ�ţ����������ݽ���   
                    //��ţ�Э���Ż�����ǣ� ͷ+���+����+����+У��   
                    //</Э�����>   
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////   

                    SysFile.WriteFrameworkLog("A1 " +builder.ToString());

                    builder.Remove(0, builder.Length);//����ַ���������������   
                    //��ΪҪ����ui��Դ��������Ҫʹ��invoke��ʽͬ��ui��   
                    this.Invoke((EventHandler)(delegate
                    {
                        ////�ж��Ƿ�����ʾΪ16��ֹ   
                        //if (checkBoxHexView.Checked)
                        //{
                        //    //���ε�ƴ�ӳ�16�����ַ���   
                        //foreach (byte b in buf)
                        //{
                        //    builder.Append(b.ToString("X2") + " ");
                        //}
                        //}
                        //else
                        //{
                        ////ֱ�Ӱ�ASCII����ת�����ַ���   
                        SysFile.WriteFrameworkLog("A2 " + builder.ToString());

                        builder.Append(Encoding.ASCII.GetString(buf));
                        //}



                        SysFile.WriteFrameworkLog("A3 " + builder.ToString());


                        string Outstr = SysConvert.ToString(Encoding.ASCII.GetString(buf)).Substring(1, SysConvert.ToString(Encoding.ASCII.GetString(buf)).Length - 1);
                        //txtQty.Text = SysConvert.ToString(Encoding.ASCII.GetString(buf)).Substring(1, SysConvert.ToString(Encoding.ASCII.GetString(buf)).Length - 1);
                        //txtQty.Text = SysConvert.ToDecimal(SysConvert.ToDecimal(Outstr)+SysConvert.ToDecimal( 0.05), 1).ToString();
                        txtQty.Text =SysConvert.ToString( Math.Round(SysConvert.ToDecimal(Outstr), 1));

                        SysFile.WriteFrameworkLog("A4 " + builder.ToString());
                        try
                        {

                            
                        }
                        catch (Exception E)
                        {
                            this.ShowMessage(E.Message);
                        }
                        //SysConvert.ToString(SysConvert.ToDecimal(Convert.ToInt32(builder.ToString().Substring(15, 6), 16).ToString()) / 10m);//builder.ToString();//

                    }));
                }
                finally
                {
                    Listening = false;//�������ˣ�ui���Թرմ����ˡ�   
                }
            }
        }
        #endregion


        private void buttonOpenClose_Click(object sender, EventArgs e)
        {
            //txtLength.Properties.ReadOnly = true;

            //���ݵ�ǰ���ڶ������жϲ���   
            if (comm.IsOpen)
            {
                Closing = true;
                while (Listening) Application.DoEvents();
                //��ʱ�������رմ���   
                comm.Close();
            }
            else
            {
                //�ر�ʱ����������úö˿ڣ������ʺ��   
                //comm.PortName = "COM2";// comboPortName.Text;
                //comm.BaudRate = 2400;// int.Parse(comboBaudrate.Text);
                comm.PortName =  comboPortName.Text;
                comm.BaudRate = int.Parse(comboBaudrate.Text);
                try
                {
                    comm.Open();
                }
                catch (Exception ex)
                {
                    //�����쳣��Ϣ������һ���µ�comm����֮ǰ�Ĳ������ˡ�   
                    comm = new SerialPort();
                    //��ʵ�쳣��Ϣ���ͻ���   
                    MessageBox.Show(ex.Message);
                }
            }
            //���ð�ť��״̬   
            //buttonOpenClose.Text = comm.IsOpen ? "Close" : "Open";
            //buttonSend.Enabled = comm.IsOpen;
        }

        private void frmLoadPackNoCZ_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OpenFalg)
            {
                timer1.Stop();
                //���ݵ�ǰ���ڶ������жϲ���   
                if (comm.IsOpen)
                {
                    Closing = true;
                    while (Listening) Application.DoEvents();
                    //��ʱ�������رմ���   
                    comm.Close();
                }
                else
                {
                    //�ر�ʱ����������úö˿ڣ������ʺ��   
                    comm.PortName = comboPortName.Text;
                    comm.BaudRate = int.Parse(comboBaudrate.Text);
                    try
                    {
                        comm.Open();
                    }
                    catch (Exception ex)
                    {
                        //�����쳣��Ϣ������һ���µ�comm����֮ǰ�Ĳ������ˡ�   
                        comm = new SerialPort();
                        //��ʵ�쳣��Ϣ���ͻ���   
                        MessageBox.Show(ex.Message);
                    }
                }
                //���ð�ť��״̬   
                //buttonOpenClose.Text = comm.IsOpen ? "Close" : "Open";
                //buttonSend.Enabled = comm.IsOpen;
            }
        }





       





    }
}