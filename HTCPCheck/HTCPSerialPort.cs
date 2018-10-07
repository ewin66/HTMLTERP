using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HttSoft.Framework;

namespace HTCPCheck
{
    #region ����ģʽ������
    /// <summary>
    /// ����ģʽ������
    /// �¼Ӻ�
    /// 2014-5-8
    /// </summary>
    public class HTCPVirtual
    {
        frmChecking m_Frm = new frmChecking();

        int p_ReadIndex = 0;
        public int ReadMaxLen = 100;//�������������100M,����������Ҫ������ʱ���ó���


        decimal _ReadData = 0m;
        /// <summary>
        /// ��������
        /// </summary>
        public decimal ReadData
        {
            get
            {
                return _ReadData;
            }
            set
            {
                _ReadData = value;
                m_Frm.ReadData = value;
            }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="p_Frm"></param>
        public HTCPVirtual(frmChecking p_Frm)
        {
            m_Frm = p_Frm;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void ReadDataVirtual()
        {
            p_ReadIndex++;
            if (p_ReadIndex % 2 == 0)
            {
                if (ReadMaxLen > ReadData + 1m)
                {
                    ReadData = ReadData + 1m;//ÿ��ѭ����1M
                }
                else
                {
                    ReadData = ReadMaxLen;
                }
            }
            else
            {
                if (ReadMaxLen > ReadData + 0.8m)
                {
                    ReadData = ReadData + 0.8m;//ÿ��ѭ����0.8M �Ե���ʵ
                }
                else
                {
                    ReadData = ReadMaxLen;
                }
            }
        }


        /// <summary>
        /// ����ģʽ�ر�
        /// </summary>
        public void ReadCloseModeVirtual()
        {
            ReadData = 0;//��ն���
        }

    }
    #endregion

    #region ¼��ģʽ������
    /// <summary>
    /// ¼��ģʽ������
    /// �¼Ӻ�
    /// 2014-5-8
    /// </summary>
    public class HTCPInput
    {
        frmChecking m_Frm = new frmChecking();



        decimal _ReadData = 0m;
        /// <summary>
        /// ��������
        /// </summary>
        public decimal ReadData
        {
            get
            {
                return _ReadData;
            }
            set
            {
                _ReadData = value;
                m_Frm.ReadData = value;
            }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="p_Frm"></param>
        public HTCPInput(frmChecking p_Frm)
        {
            m_Frm = p_Frm;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void ReadDataInput()
        {
            frmKeyBoard frm = new frmKeyBoard();
            frm.ShowDialog();
            if (frm.InputStr != string.Empty)
            {
                ReadData = SysConvert.ToDecimal(frm.InputStr);
            }
        }


        /// <summary>
        /// ģʽ�ر�
        /// </summary>
        public void ReadCloseModeInput()
        {
            ReadData = 0;//��ն���
        }

    }
    #endregion


    #region ���ģʽ������
    /// <summary>
    /// ��������
    /// �¼Ӻ�
    /// 2014-5-8
    /// </summary>
    public class HTCPSerialPort
    {
        frmChecking m_Frm = new frmChecking();
        public HTCPSerialPort(frmChecking p_Frm)
        {
            m_Frm = p_Frm;
        }
        string Str1 = string.Empty;
        string Str2 = string.Empty;

        public string PortName = "COM1";//�˿�
        public int BroadRate = 19200;//������
        public int ComPortID = 1;//COM��

        private SerialPort comm = new SerialPort();
        private bool Listening = false;//�Ƿ�û��ִ����invoke��ز���   

        /// <summary>
        /// ���ģʽ����
        /// </summary>
        public void ReadStartModeMB()
        {
            //txtLength.Properties.ReadOnly = true;

            //���ݵ�ǰ���ڶ������жϲ���   
            if (comm.IsOpen)
            {
            }
            else
            {
                //�ر�ʱ����������úö˿ڣ������ʺ��   
                comm.PortName = PortName;
                comm.BaudRate = BroadRate;//int.Parse(comboBaudrate.Text);
                try
                {
                    comm.Open();
                }
                catch (Exception ex)
                {
                    //�����쳣��Ϣ������һ���µ�comm����֮ǰ�Ĳ������ˡ�   
                    comm = new SerialPort();
                    //��ʵ�쳣��Ϣ���ͻ���   
                    m_Frm.ShowMessage(ex.Message);
                }
            }
        }

        /// <summary>
        /// ���ģʽ�ر�
        /// </summary>
        public void ReadCloseModeMB()
        {
            //txtLength.Properties.ReadOnly = true;

            //���ݵ�ǰ���ڶ������жϲ���   
            if (comm.IsOpen)
            {
                //Closing = true;
                while (Listening) Application.DoEvents();
                //��ʱ�������رմ���   
                comm.Close();
            }
        }


        /// <summary>
        /// �������
        /// </summary>
        public void ReadDataMB()
        {

            //����һ����������¼�����˼����ֽ�   
            //int n = 0;
            ////16���Ʒ���   
            //if (checkBoxHexSend.Checked)
            //{
            //    //���ǲ��ܹ����ˡ����д����һЩ����������ģ�ֻ������õ���Ч��ʮ��������   
            MatchCollection mc = Regex.Matches("55AA02000001", @"(?i)[\da-f]{2}");
            List<byte> buf = new List<byte>();//��䵽�����ʱ�б���   
            //������ӵ��б���   
            foreach (Match m in mc)
            {
                buf.Add(byte.Parse(m.Value, System.Globalization.NumberStyles.HexNumber));
            }
            //ת���б�Ϊ�������   
            comm.Write(buf.ToArray(), 0, buf.Count);
        }





        /// <summary>
        /// ���ע��
        /// </summary>
        public void ReadDataRegisterMB()
        {
            #region ע���ȡ����¼�
            //��ʼ���������������б��   
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length <= 0)
            {
                return;
            }
            Array.Sort(ports);
            //comboPortName.Items.AddRange(ports);
            //comboPortName.SelectedIndex = comboPortName.Items.Count > 0 ? 0 : -1;


            //comboBaudrate.SelectedIndex = comboBaudrate.Items.IndexOf("19200");


            //��ʼ��SerialPort����   
            comm.NewLine = "\r\n";
            comm.RtsEnable = true;//����ʵ������ɡ�   

            //����¼�ע��   
            comm.DataReceived += comm_DataReceived;
            //OpenFalg = true;
            #endregion
        }

        #region ��ȡ�¼�
        private StringBuilder builder = new StringBuilder();//�������¼��������з����Ĵ��������嵽���档   
        private long received_count = 0;//���ռ���   
        //private long send_count = 0;//���ͼ���   
        //private bool Listening = false;//�Ƿ�û��ִ����invoke��ز���   
        //private bool Closing = false;//�Ƿ����ڹرմ��ڣ�ִ��Application.DoEvents������ֹ�ٴ�invoke   
        private List<byte> buffer = new List<byte>(8192);//Ĭ�Ϸ���1ҳ�ڴ棬��ʼ�����Ʋ�������   
        private byte[] binary_data_1 = new byte[12];//AA 44 05 01 02 03 04 05 EA   
        //bool showflag = false;
        //bool OpenFalg = false;

        decimal _ReadData = 0m;
        /// <summary>
        /// ����
        /// </summary>
        public decimal ReadData
        {
            get
            {
                return _ReadData;
            }
            set
            {
                _ReadData = value;
                m_Frm.ReadData = value;
            }
        }


        private static object locker = new Object();
        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            #region
            SysFile.WriteFrameworkLog("comm_DataReceived a" + builder.ToString());
            lock (locker)
            {
                //if (Closing) return;//������ڹرգ����Բ�����ֱ�ӷ��أ��������ɴ��ڼ����̵߳�һ��ѭ��   

                if (!m_Frm.saveReadStartFlag) return;//������ڹرգ����Բ�����ֱ�ӷ��أ��������ɴ��ڼ����̵߳�һ��ѭ��   


                try
                {
                    Listening = true;//���ñ�ǣ�˵�����Ѿ���ʼ�������ݣ�һ���Ҫʹ��ϵͳUI�ġ�   


                    SysFile.WriteFrameworkLog("comm_DataReceived b" + builder.ToString());
                    int n = comm.BytesToRead;//�ȼ�¼����������ĳ��ԭ����Ϊ��ԭ�򣬲�������֮��ʱ�䳤�����治һ��   
                    byte[] buf = new byte[n];//����һ����ʱ����洢��ǰ���Ĵ�������   
                    received_count += n;//���ӽ��ռ��� 
                    comm.Read(buf, 0, n);//��ȡ��������  
                    builder.Remove(0, builder.Length);//����ַ��������������� 
                    if (m_Frm.IsHandleCreated)
                    {

                        //��ΪҪ����ui��Դ��������Ҫʹ��invoke��ʽͬ��ui��   
                        m_Frm.Invoke((EventHandler)(delegate
                        {
                            //SysFile.WriteFrameworkLog("comm_DataReceived a" + builder.ToString());
                            ////�ж��Ƿ�����ʾΪ16��ֹ   
                            //if (false)//checkBoxHexView.Checked
                            //{
                            //    //���ε�ƴ�ӳ�16�����ַ���   
                            //foreach (byte b in buf)
                            //{
                            //    builder.Append(b.ToString("X2") + " ");
                            //}
                            //}
                            //else
                            //{
                            //    //ֱ�Ӱ�ASCII����ת�����ַ���   
                            builder.Append(Encoding.ASCII.GetString(buf));
                            //}



                            ////ֱ�Ӱ�ASCII����ת�����ַ���   
                            //builder.Append(Encoding.ASCII.GetString(buf));
                            //SysFile.WriteFrameworkLog("comm_DataReceived b " + builder.ToString());

                            //if (builder.Length >= 16)
                            //{

                            //    string tempData1 = builder.ToString().Substring(3, 2);
                            //    string tempData2 = builder.ToString().Substring(6, 2);
                            //    string tempData3 = builder.ToString().Substring(9, 2);
                            //    string tempData4 = builder.ToString().Substring(12, 2);

                            //    string tempData5 = builder.ToString().Substring(18, 2);
                            //    string tempData6 = builder.ToString().Substring(21, 2);

                            //    int Num1 = SysConvert.ToInt32(tempData1);
                            //    int Num2 = SysConvert.ToInt32(tempData2);
                            //    int Num3 = SysConvert.ToInt32(tempData3);
                            //    int Num4 = SysConvert.ToInt32(tempData4);
                            //    int Num5 = SysConvert.ToInt32(tempData5);
                            //    int Num6 = SysConvert.ToInt32(tempData6);

                            //    //int Num1 = Convert.ToInt32(tempData1, 16);
                            //    //int Num2 = Convert.ToInt32(tempData2, 16);
                            //    //int Num3 = Convert.ToInt32(tempData3, 16);
                            //    //int Num4 = Convert.ToInt32(tempData4, 16);

                            //    //int Num5 = Convert.ToInt32(tempData5, 16);
                            //    //int Num6 = Convert.ToInt32(tempData6, 16);



                            //  string  ReadDateStr = SysConvert.ToString(Num1) + SysConvert.ToString(Num2) + SysConvert.ToString(Num3) + SysConvert.ToString(Num4) + "." + SysConvert.ToString(Num5) + SysConvert.ToString(Num6);

                            //    ReadData = SysConvert.ToDecimal(ReadDateStr);

                            //    SysFile.WriteFrameworkLog("comm_DataReceived B4 " + ReadData.ToString());
                            //}

                            SysFile.WriteFrameworkLog("comm_DataReceived A " + builder.ToString());
                            SysFile.WriteFrameworkLog("comm_DataReceived B " + builder.ToString().Length);

                            string tempData = builder.ToString();
                            if (ComPortID == 1)//���
                            {
                                ReadData = SysConvert.ToDecimal(tempData.Substring(0, tempData.Length - 1));

                            }


                            if (ComPortID == 2)//����
                            {
                                if (builder.Length == 8)
                                {
                                    Str1 = tempData.Substring(2, tempData.Length - 2);
                                }
                                if (builder.Length == 6)
                                {
                                    Str2 = tempData.Substring(0, 2);
                                }

                                SysFile.WriteFrameworkLog("comm_DataReceived C " + Str1.ToString());
                                SysFile.WriteFrameworkLog("comm_DataReceived D " + Str2.ToString());
                                SysFile.WriteFrameworkLog("comm_DataReceived E " + (Str1 + Str2).ToString());

                                if (Str1 != "" && Str2 != "")
                                {
                                    ReadData = SysConvert.ToDecimal(Str1 + Str2);

                                    Str1 = "";
                                    Str2 = "";
                                }


                            }


                            //ReadData = SysConvert.ToDecimal(tempData.Substring(0, tempData.Length - 1));

                            SysFile.WriteFrameworkLog("comm_DataReceived F " + ReadData.ToString());


                        }));
                    }
                }
                finally
                {
                    Listening = false;//�������ˣ�ui���Թرմ����ˡ�   
                }
                //catch (Exception E)
                //{                
                //    m_Frm.ShowMessage(E.Message);
                //}


                //SysFile.WriteFrameworkLog("comm_DataReceived b" + builder.ToString());
                //string tempData = builder.ToString();
                //ReadData = SysConvert.ToDecimal(tempData.Substring(0, tempData.Length - 1));
                ////SysFile.WriteFile(tempData);
                ////׷�ӵ���ʽ��ӵ��ı���ĩ�ˣ������������   
                ////this.txGet.AppendText(builder.ToString());
                ////�޸Ľ��ռ���   
                ////labelGetCount.Text = "Get:" + received_count.ToString();




            #endregion
                #region
                //lock (locker)
                //{
                //    if (!m_Frm.saveReadStartFlag) return;//������ڹرգ����Բ�����ֱ�ӷ��أ��������ɴ��ڼ����̵߳�һ��ѭ��   
                //    try
                //    {
                //        Listening = true;//���ñ�ǣ�˵�����Ѿ���ʼ�������ݣ�һ���Ҫʹ��ϵͳUI�ġ�   
                //        int n = comm.BytesToRead;//�ȼ�¼����������ĳ��ԭ����Ϊ��ԭ�򣬲�������֮��ʱ�䳤�����治һ��   
                //        byte[] buf = new byte[n];//����һ����ʱ����洢��ǰ���Ĵ�������   
                //        received_count += n;//���ӽ��ռ���   
                //        comm.Read(buf, 0, comm.BytesToRead);//��ȡ��������   

                //        /////////////////////////////////////////////////////////////////////////////////////////////////////////////   
                //        //<Э�����>   
                //        bool data_1_catched = false;//�����¼�����Ƿ񲶻�   
                //        //1.��������   
                //        buffer.AddRange(buf);
                //        //2.�������ж�   
                //        while (buffer.Count >= 4)//����Ҫ����ͷ��2�ֽڣ�+���ȣ�1�ֽڣ�+У�飨1�ֽڣ�   
                //        {
                //            //�벻Ҫ����ʹ��>=����Ϊ>=�Ѿ���>,<,=һ�����Ƕ����������������ǽ�����>��=2������   
                //            //2.1 ��������ͷ   
                //            if (buffer[0] == 0xAA && buffer[1] == 0x44)
                //            {
                //                //2.2 ̽�⻺�������Ƿ���һ�����ݵ��ֽڣ�����������Ͳ��÷Ѿ�����������֤��   
                //                //ǰ���Ѿ��޶���ʣ�೤��>=4������������һ���ܷ��ʵ�buffer[2]�������   
                //                int len = buffer[2];//���ݳ���   
                //                //���������жϵ�һ���������Ƿ��㹻   
                //                //len�����ݶγ���,4���ֽ���while��ע�͵�3���ֳ���   
                //                if (buffer.Count < len + 4) break;//���ݲ�����ʱ��ʲô������   
                //                //����ȷ�����ݳ����㹻������ͷ��־�ҵ������ǿ�ʼ����У��   
                //                //2.3 У�����ݣ�ȷ��������ȷ   
                //                //���У�飬����ֽ����õ�У����   
                //                byte checksum = 0;
                //                for (int i = 0; i < len + 3; i++)//len+3��ʾУ��֮ǰ��λ��   
                //                {
                //                    checksum ^= buffer[i];
                //                }
                //                if (checksum != buffer[len + 3]) //�������У��ʧ�ܣ�������һ������   
                //                {
                //                    buffer.RemoveRange(0, len + 4);//�ӻ�����ɾ����������   
                //                    continue;//������һ��ѭ��   
                //                }
                //                //���ˣ��Ѿ����ҵ���һ���������ݡ����ǽ�����ֱ�ӷ��������ǻ�������һ�����   
                //                //����������õİ취�ǻ���һ�Σ��ô����������ĳ��ԭ�����ݶѻ��ڻ���buffer��   
                //                //�Ѿ��ܶ��ˣ�������Ҫѭ�����ҵ����һ�飬ֻ�����������ݣ������������Ѿ�������ʱ   
                //                //�ˣ��Ͳ�Ҫ�˷Ѹ���ʱ���ˣ���Ҳ�ǿ��ǵ�ϵͳ�����ܹ����͡�   
                //                buffer.CopyTo(0, binary_data_1, 0, len + 4);//����һ���������ݵ���������ݻ���   
                //                data_1_catched = true;
                //                buffer.RemoveRange(0, len + 4);//��ȷ����һ�����ݣ��ӻ������Ƴ����ݡ�   
                //            }
                //            else
                //            {
                //                //�����Ǻ���Ҫ�ģ�������ݿ�ʼ����ͷ����ɾ������   
                //                buffer.RemoveAt(0);
                //            }
                //        }
                //        //��������   
                //        if (data_1_catched)
                //        {
                //            //���ǵ����ݶ��Ƕ��ø�ʽ�ģ����Ե������ҵ�������������1����֪���̶�λ��һ������Щ���ݣ�����ֻҪ��ʾ�Ϳ�����   
                //            string data = binary_data_1[3].ToString("X2") + " " + binary_data_1[4].ToString("X2") + " " +
                //                binary_data_1[5].ToString("X2") + " " + binary_data_1[6].ToString("X2") + " " +
                //                binary_data_1[7].ToString("X2");
                //            //���½���   
                //            m_Frm.Invoke((EventHandler)(delegate { }));//buttonOpenClose.Text = data; 
                //        }

                //        //�����Ҫ���Э�飬ֻҪ��չ���data_n_catched�Ϳ����ˡ���������Э��������£�����������ݱ�ţ����������ݽ���   
                //        //��ţ�Э���Ż�����ǣ� ͷ+���+����+����+У��   
                //        //</Э�����>   
                //        /////////////////////////////////////////////////////////////////////////////////////////////////////////////   

                //        builder.Remove(0, builder.Length);//����ַ���������������   
                //        //��ΪҪ����ui��Դ��������Ҫʹ��invoke��ʽͬ��ui��   
                //        m_Frm.Invoke((EventHandler)(delegate
                //        {
                //            ////�ж��Ƿ�����ʾΪ16��ֹ   
                //            //if (checkBoxHexView.Checked)
                //            //{
                //            //    //���ε�ƴ�ӳ�16�����ַ���   
                //            foreach (byte b in buf)
                //            {
                //                builder.Append(b.ToString("X2") + " ");
                //            }
                //            //}
                //            //else
                //            //{
                //            //ֱ�Ӱ�ASCII����ת�����ַ���   
                //            //  builder.Append(Encoding.ASCII.GetString(buf));
                //            //}
                //            try
                //            {

                //                //if (!showflag)
                //                //{
                //                // MessageBox.Show(builder.ToString());

                //                //SysFile.WriteFrameworkLog(builder.ToString());
                //                //SysFile.WriteFrameworkLog(Environment.NewLine + builder.ToString().Length.ToString());
                //                if (builder.ToString().Length >= 23)
                //                {
                //                    //׷�ӵ���ʽ��ӵ��ı���ĩ�ˣ������������  
                //                    ReadData = SysConvert.ToDecimal(Convert.ToInt32(builder.ToString().Trim().Substring(15, 8).Replace(" ", ""), 16).ToString()) / 10m;
                //                    //if (ReadDate < 600m)
                //                    //{
                //                    //    decimal tz = 0m;// SysConvert.ToDecimal(txtTZQty.Text);
                //                    //    if (drpItemUnit.Text == "M")//������λ����
                //                    //    {
                //                    //        if (ReadDate > 0m)
                //                    //        {
                //                    //            txtItemM.Text = SysConvert.ToString(ReadDate + tz);
                //                    //            txtItemY.Text = SysConvert.ToDecimal(SysConvert.ToDecimal(ReadDate + tz) * 1.0936132983377m, 2).ToString();
                //                    //        }
                //                    //    }
                //                    //    if (drpItemUnit.Text == "Y")//������λ����
                //                    //    {
                //                    //        if (ReadDate > 0m)
                //                    //        {
                //                    //            txtItemM.Text = SysConvert.ToDecimal(SysConvert.ToDecimal(ReadDate + tz) * 0.9144m, 2).ToString();
                //                    //            txtItemY.Text = SysConvert.ToString(ReadDate + tz);
                //                    //        }
                //                    //    }
                //                    //}
                //                    //if (ReadDate == 0m)
                //                    //{
                //                    //    lblELength.Text = builder.ToString();
                //                    //}
                //                    //showflag = true;

                //                }
                //                //}
                //            }
                //            catch (Exception E)
                //            {
                //                m_Frm.ShowMessage(E.Message);
                //            }
                //            //SysConvert.ToString(SysConvert.ToDecimal(Convert.ToInt32(builder.ToString().Substring(15, 6), 16).ToString()) / 10m);//builder.ToString();//

                //        }));
                //    }
                //    finally
                //    {
                //        Listening = false;//�������ˣ�ui���Թرմ����ˡ�   
                //    }
                //}
                #endregion
            }
        #endregion

        }
    }
    #endregion

}
