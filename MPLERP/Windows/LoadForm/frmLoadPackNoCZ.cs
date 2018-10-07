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
    /// 系统出库录入码单明细
    /// </summary>
    public partial class frmLoadPackNoCZ :BaseForm
    {
        public frmLoadPackNoCZ()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 保存标志
        /// </summary>
        bool m_SaveFlag = false;
        /// <summary>
        /// 保存标志
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
        /// 修改标志
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
        #region 自定义方法

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
        /// 获得实体
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



        #region 窗体事件
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadPack_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessGrid.BindGridColumn(gridView1, this.FormID);//绑定列
                ProcessGrid.SetGridColumnUI(gridView1, this.FormListAID, this.FormListBID);//设置列UI


              Common.BindReport(drpReport,this.FormID,false);

              drpReport.EditValue = Common.BindReport(drpReport, this.FormID, false);

                txtQty.Focus();//聚焦称重数据

                BindGrid();


                comm.PortName = "COM2";
                comm.BaudRate = 2400;


                #region 注册读取码表事件
                //初始化下拉串口名称列表框   
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

                //初始化SerialPort对象   
                comm.NewLine = "\r\n";
                comm.RtsEnable = true;//根据实际情况吧。   

                //添加事件注册   
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


        #region 按钮事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Focus();
                if (m_PackType == (int)EnumPackType.仓库单据)
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
               // this.ShowInfoMessage("保存成功！");
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
        ///// 绑定报表名称
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
                btnPrintAbount((int)ReportPrintType.预览);
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
                btnPrintAbount((int)ReportPrintType.设计);
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
                btnPrintAbount((int)ReportPrintType.打印);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 打印共用条码
        /// </summary>
        /// <returns></returns>
        bool btnPrintAbount(int p_ReportPrintType)
        {
            this.BaseFocusLabel.Focus();


            string GBIDStr = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));


            if (GBIDStr == "")
            {
                this.ShowMessage("请选择需要打印的条码");
                return false;
            }


            //DevComponents.DotNetBar.ComboBoxItem ci = this.ToolBarCItemGet(-1, ToolButtonName.drpPrintFile.ToString());
            //if (ci.SelectedItem == null)
            //{
            //    this.ShowMessage("请选择报表模板");
            //    return false;
            //}
            //int tempReportID = SysConvert.ToInt32(((DevComponents.Editors.ComboItem)ci.SelectedItem).Tag);
            int tempReportID = SysConvert.ToInt32(drpReport.EditValue);
            if (tempReportID == 1)
            {
                this.ShowMessage("请选择报表模板");
                return false;
            }



            //2012/9/18 CJH 测试传入数据表代码
            string sql = "SELECT * FROM UV1_WH_IOFormDtsPack WHERE DtsPackID IN(" + GBIDStr + ")";
            DataTable dt = SysUtils.Fill(sql);
            dt.TableName = "Dts";
            FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, dt);
            //FastReportX.ReportRunTable(tempReportID, p_ReportPrintType, new DataTable[] { dt });

        

            //2012/9/18CJH 为了测试传入数据表打印报表而进行注释
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










        #region 读取码表数据
        private SerialPort comm = new SerialPort();
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。   
        private long received_count = 0;//接收计数   
        private long send_count = 0;//发送计数   
        private bool Listening = false;//是否没有执行完invoke相关操作   
        private bool Closing = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke   
        private List<byte> buffer = new List<byte>(8192);//默认分配1页内存，并始终限制不允许超过   
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
        #region 读取事件

        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (locker)
            {
                if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环   
                try
                {
                    


                    Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。   
                    int n = comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致   
                    byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据   
                    received_count += n;//增加接收计数   
                    comm.Read(buf, 0, comm.BytesToRead);//读取缓冲数据   


                    //如果需要别的协议，只要扩展这个data_n_catched就可以了。往往我们协议多的情况下，还会包含数据编号，给来的数据进行   
                    //编号，协议优化后就是： 头+编号+长度+数据+校验   
                    //</协议解析>   
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////   

                    SysFile.WriteFrameworkLog("A1 " +builder.ToString());

                    builder.Remove(0, builder.Length);//清除字符串构造器的内容   
                    //因为要访问ui资源，所以需要使用invoke方式同步ui。   
                    this.Invoke((EventHandler)(delegate
                    {
                        ////判断是否是显示为16禁止   
                        //if (checkBoxHexView.Checked)
                        //{
                        //    //依次的拼接出16进制字符串   
                        //foreach (byte b in buf)
                        //{
                        //    builder.Append(b.ToString("X2") + " ");
                        //}
                        //}
                        //else
                        //{
                        ////直接按ASCII规则转换成字符串   
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
                    Listening = false;//我用完了，ui可以关闭串口了。   
                }
            }
        }
        #endregion


        private void buttonOpenClose_Click(object sender, EventArgs e)
        {
            //txtLength.Properties.ReadOnly = true;

            //根据当前串口对象，来判断操作   
            if (comm.IsOpen)
            {
                Closing = true;
                while (Listening) Application.DoEvents();
                //打开时点击，则关闭串口   
                comm.Close();
            }
            else
            {
                //关闭时点击，则设置好端口，波特率后打开   
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
                    //捕获到异常信息，创建一个新的comm对象，之前的不能用了。   
                    comm = new SerialPort();
                    //现实异常信息给客户。   
                    MessageBox.Show(ex.Message);
                }
            }
            //设置按钮的状态   
            //buttonOpenClose.Text = comm.IsOpen ? "Close" : "Open";
            //buttonSend.Enabled = comm.IsOpen;
        }

        private void frmLoadPackNoCZ_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OpenFalg)
            {
                timer1.Stop();
                //根据当前串口对象，来判断操作   
                if (comm.IsOpen)
                {
                    Closing = true;
                    while (Listening) Application.DoEvents();
                    //打开时点击，则关闭串口   
                    comm.Close();
                }
                else
                {
                    //关闭时点击，则设置好端口，波特率后打开   
                    comm.PortName = comboPortName.Text;
                    comm.BaudRate = int.Parse(comboBaudrate.Text);
                    try
                    {
                        comm.Open();
                    }
                    catch (Exception ex)
                    {
                        //捕获到异常信息，创建一个新的comm对象，之前的不能用了。   
                        comm = new SerialPort();
                        //现实异常信息给客户。   
                        MessageBox.Show(ex.Message);
                    }
                }
                //设置按钮的状态   
                //buttonOpenClose.Text = comm.IsOpen ? "Close" : "Open";
                //buttonSend.Enabled = comm.IsOpen;
            }
        }





       





    }
}