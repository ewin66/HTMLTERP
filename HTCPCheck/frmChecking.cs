using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraEditors;
using HttSoft.WinUIBase;
using HttSoft.HTCPCheck.DataCtl;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTERP.Sys;



namespace HTCPCheck
{
    public partial class frmChecking : BaseForm //Form // BaseForm
    {
        public frmChecking()
        {
            InitializeComponent();
        }
        //[DllImport("user32.dll")]
        //static extern bool LockWindowUpdate(IntPtr hWndLock);

        #region 属性
        /// <summary>
        /// 检验清单主表ID
        /// </summary>
        private int m_ID = 0;
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
        /// <summary>
        /// 检验清单明细表ID
        /// </summary>
        private int m_DtsID = 0;
        public int DtsID
        {
            get
            {
                return m_DtsID;
            }
            set
            {
                m_DtsID = value;
            }
        }
        /// <summary>
        /// 每匹布ID WO_CheckOrderISN.ID
        /// </summary>
        private int m_ISNID = 0;
        /// <summary>
        /// 每匹布ID WO_CheckOrderISN.ID
        /// </summary>
        public int ISNID
        {
            get
            {
                return m_ISNID;
            }
            set
            {
                m_ISNID = value;
            }
        }



        decimal _ReadData = 0m;
        /// <summary>
        /// 读数
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
                SetReadData(value);
            }
        }
        #endregion

        #region 读数相关
        /// <summary>
        /// 端口
        /// </summary>
        HTCPSerialPort htcpSerialPort;
        /// <summary>
        /// 虚拟
        /// </summary>
        HTCPVirtual htcpVirtual;

        /// <summary>
        /// 录入模式
        /// </summary>
        HTCPInput htcpInput;



        /// <summary>
        /// 开始读数
        /// </summary>
        public virtual void ReadStart()
        {
            if (!saveReadStartFlag)//如果未开始，则读数启动
            {
                if (WPOPMode == 0)//码表模式
                {

                    ReadDataRegisterMB();
                    ReadStartModeMB();
                    ReadDataActMB();//zhoufc
                    timerReadData.Enabled = true;
                }
                else if (WPOPMode == 1)//虚拟模式
                {
                    ReadStartModeVirtual();
                    timerReadData.Enabled = true;
                }
                else if (WPOPMode == 2)//录入模式
                {
                    ReadStartModeInput();
                    timerReadData.Enabled = false;
                }
                saveReadStartFlag = true;
            }
            ReadDataAct();
        }

        /// <summary>
        /// 读数
        /// </summary>
        public void ReadDataAct()
        {
            if (WPOPMode == 0)//码表模式
            {
                ReadDataActMB();
            }
            else if (WPOPMode == 1)//虚拟模式
            {
                ReadDataActVirtual();
            }
            else if (WPOPMode == 2)//录入模式
            {
                ReadDataActInput();
            }
        }

        /// <summary>
        /// 读数码表
        /// </summary>
        void ReadDataActMB()
        {
            htcpSerialPort.ReadDataMB();
        }

        /// <summary>
        /// 读数虚拟
        /// </summary>
        void ReadDataActVirtual()
        {
            if (!saveCDClickFlag)//虚拟模式读数点击疵点操作时不允许自动增长
            {
                htcpVirtual.ReadDataVirtual();
            }
        }

        /// <summary>
        /// 读数录入
        /// </summary>
        void ReadDataActInput()
        {
            if (!saveCDClickFlag)//虚拟模式读数点击疵点操作时不允许自动增长
            {
                htcpInput.ReadDataInput();
            }
        }

        /// <summary>
        /// 码表注册
        /// </summary>
        void ReadDataRegisterMB()
        {
            htcpSerialPort.ReadDataRegisterMB();
        }


        /// <summary>
        /// 关闭读数
        /// </summary>
        public virtual void ReadClose()
        {
            if (saveReadStartFlag)//如果开始，则读数关闭
            {
                //if (WPOPMode == 0)//码表模式
                //{
                //    htcpSerialPort.ReadCloseModeMB();
                //}
                if (WPOPMode == 1)//虚拟模式
                {
                    ReadCloseModeVirtual();
                }
                else if (WPOPMode == 2)//录入模式
                {
                    ReadCloseModeInput();
                }
                htcpSerialPort.ReadCloseModeMB();
            }

            saveReadStartFlag = false;
            timerReadData.Enabled = false;
        }
        /// <summary>
        /// 码表模式启动
        /// </summary>
        public virtual void ReadStartModeMB()
        {
            htcpSerialPort.ReadStartModeMB();
        }

        /// <summary>
        /// 录入模式启动
        /// </summary>
        public virtual void ReadStartModeInput()
        {
            //htcpInput.ReadStartModeMB();
        }

        /// <summary>
        /// 虚拟模式启动
        /// </summary>
        public virtual void ReadStartModeVirtual()
        {
            htcpVirtual.ReadDataVirtual();
        }

        /// <summary>
        /// 码表模式关闭
        /// </summary>
        public virtual void ReadCloseModeMB()
        {
            htcpSerialPort.ReadCloseModeMB();

        }

        /// <summary>
        /// 虚拟模式关闭
        /// </summary>
        public virtual void ReadCloseModeVirtual()
        {
            htcpVirtual.ReadCloseModeVirtual();
        }

        /// <summary>
        /// 录入模式关闭
        /// </summary>
        public virtual void ReadCloseModeInput()
        {
            htcpInput.ReadCloseModeInput();
        }

        /// <summary>
        /// 定时读数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerReadData_Tick(object sender, EventArgs e)
        {
            try
            {
                ReadDataAct();
            }
            catch (Exception E)
            {
                timerReadData.Enabled = false;//防止一直报错，停止循环执行
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 全局变量
        decimal Position = 0m;//疵点位置

        /// <summary>
        /// 点击的疵点按钮
        /// </summary>
        public Button saveBtnCDClick;
        /// <summary>
        /// 点击的疵点科目按钮
        /// </summary>
        public Button saveBtnCDItemClick;
        /// <summary>
        /// 疵点科目类型1/2/3:扣分/裁剪
        /// </summary>
        public int saveCDItemType = 0;

        /// <summary>
        /// 疵点按钮点击标志
        /// 用于模拟模式下，点击后不再自动读数，实际操作中一定是在停止状态下点击的
        /// </summary>
        public bool saveCDClickFlag = false;

        /// <summary>
        /// 开始读数标志
        /// 说明已经开启了
        /// </summary>
        public bool saveReadStartFlag = false;
        #endregion

        #region 校验方法
        /// <summary>
        /// 验布完成校验合法性
        /// </summary>
        /// <returns></returns>
        private bool FabricFinishCheckCorrect()
        {
            if (SysConvert.ToDecimal(lblQty.Text) == 0m)//如果是现码为0不能继续
            {
                this.ShowMessage("请输入检验长度");
                return false;
            }
            ReadStart();
            if (DialogResult.Yes != MessageBox.Show("布检验结束后，将开始下一匹，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                return false;
            }

            if (DtsID == 0)
            {
                this.ShowMessage("请从待检清单中进入");
                return false;
            }
            if (lblJarNum.Text == "")
            {
                this.ShowMessage("请输入缸号");
                return false;
            }
            if (SysConvert.ToDecimal(lblQty.Text) == 0m)
            {
                this.ShowMessage("数据异常未读取到码表数据");
                return false;
            }
            return true;
        }

        #endregion



        #region 设置按钮状态
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnPrint.BackgroundImage = global::HTCPCheck.Properties.Resources._7_单击;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnPrint.BackgroundImage = global::HTCPCheck.Properties.Resources._7_默认;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnClose.BackgroundImage = global::HTCPCheck.Properties.Resources._11__点击;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnClose.BackgroundImage = global::HTCPCheck.Properties.Resources._11默认;
        }
        /// <summary>
        /// 疵点删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricDtsFaultDelete_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnFabricDtsFaultDelete.BackgroundImage = global::HTCPCheck.Properties.Resources._5单击;
        }
        /// <summary>
        /// 疵点删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricDtsFaultDelete_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnFabricDtsFaultDelete.BackgroundImage = global::HTCPCheck.Properties.Resources._5_默认;
        }
        /// <summary>
        /// 此匹结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabicFinish_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnFabicFinish.BackgroundImage = global::HTCPCheck.Properties.Resources._4_单击;
        }
        /// <summary>
        /// 此匹结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabicFinish_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnFabicFinish.BackgroundImage = global::HTCPCheck.Properties.Resources._4_默认;
        }
        /// <summary>
        /// 继续上一匹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetLastFabric_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnGetLastFabric.BackgroundImage = global::HTCPCheck.Properties.Resources._4_单击;
        }
        /// <summary>
        /// 继续上一匹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetLastFabric_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnGetLastFabric.BackgroundImage = global::HTCPCheck.Properties.Resources._4_默认;
        }

        private void btnPrintMore_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnPrintMore.BackgroundImage = global::HTCPCheck.Properties.Resources._12_点击;
        }

        private void btnPrintMore_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnPrintMore.BackgroundImage = global::HTCPCheck.Properties.Resources._12_默认;
        }
        #endregion

        #region 其他事件

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {

            if (m.Msg == 0x0014) // 禁掉清除背景消息

                return;

            base.WndProc(ref m);

        }
        #endregion

        #region 窗体加载
        private void Checking_Load(object sender, EventArgs e)
        {

            #region 初始化码表及模拟模式类
            htcpSerialPort = new HTCPSerialPort(this);//码表模式
            SysIniFile ini = new SysIniFile(Application.StartupPath + @"\htcheckset.ini");
            string pn = ini.IniReadValue("MB", "PORTNAME");
            if (pn != string.Empty)
            {
                htcpSerialPort.PortName = pn;
            }
            string brate = ini.IniReadValue("MB", "BRATE");
            if (SysConvert.ToInt32(brate) != 0)
            {
                htcpSerialPort.BroadRate = SysConvert.ToInt32(brate);
            }


            htcpVirtual = new HTCPVirtual(this);//模拟模式
            htcpInput = new HTCPInput(this);//录入模式
            #endregion

            //timerReadData.Enabled = false;
            //saveReadStartFlag = true;


            #region 扣分补码按钮相关
            btn1P.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn2P.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn3P.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn4P.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn0P.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn05M.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn1M.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn2M.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btn3M.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);
            btnCDCancel.MouseUp += new MouseEventHandler(btnKFBM_MouseUp);

            btn1P.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn2P.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn3P.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn4P.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn0P.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn05M.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn1M.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn2M.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btn3M.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);
            btnCDCancel.MouseDown += new MouseEventHandler(btnKFBM_MouseDown);

            btn1P.Click += new EventHandler(btnKFBM_Click);
            btn2P.Click += new EventHandler(btnKFBM_Click);
            btn3P.Click += new EventHandler(btnKFBM_Click);
            btn4P.Click += new EventHandler(btnKFBM_Click);
            btn0P.Click += new EventHandler(btnKFBM_Click);
            btn05M.Click += new EventHandler(btnKFBM_Click);
            btn1M.Click += new EventHandler(btnKFBM_Click);
            btn2M.Click += new EventHandler(btnKFBM_Click);
            btn3M.Click += new EventHandler(btnKFBM_Click);
            btnCDCancel.Click += new EventHandler(btnCDCancel_Click);
            #endregion

            #region 弹出小键盘
            CheckKeyBoardCall(lblQty);
            CheckKeyBoardCall(lblQtyKG);
            CheckKeyBoardCall(lblJarNum);
            CheckKeyBoardCall(lblReelNo);
            CheckKeyBoardCall(lblKJQty);
            #endregion

            BindFastReportList(drpReportList, this.FormID);//待检清单

            //Common.BindReport(drpReportList, 1110,true);

            CreateCDList(pictureBox1);//绘制疵点项目

            CDInputSetCtlStatus(9);

            SetEntity(1);

            ReadStart();// = 0;//设置启动模式
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 下拉菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintMore_Click(object sender, EventArgs e)
        {
            try
            {
                cMenuMore.Show(btnPrintMore, new Point(0, btnPrintMore.Height));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);

            }
        }
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("请确认检验已经结束，如果已经结束可以退出，如果没有，请点击此匹结束", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
                ReadClose();
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 此卷结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabicFinish_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FabricFinishCheckCorrect())
                {
                    return;
                }

                CheckOrderISNFaultRule rule = new CheckOrderISNFaultRule();
                CheckOrderISN entityMain = EntityGet();

                int tempID = rule.RJYEnd(ISNID, entityMain, DtsID, SysConvert.ToDecimal(lblQty.Text), SysConvert.ToDecimal(lblQty.Text), SysConvert.ToInt32(lblReelNo.Text));
                ISNID = tempID;

                //if (chkAutoPrint.Checked)
                //{
                btnPrint_Click(null, null);//打印小票
                //}

                lblQty.Text = "0.00";

                ISNID = 0;
                BindGrid();
                SetEntity(2);


                btnCDCancel_Click(null, null);





            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 开剪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKJ_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CDInputCheck())
                {
                    return;
                }

                CheckOrderISN entity = EntityGet();
                if ((entity.StatusID != (int)EnumBoxStatus.未入库) && entity.ID > 0)//不是开匹的才计算
                {
                    this.ShowMessage("不是未入库的条码不能开剪");
                    return;
                }
                saveCDItemType = 3;//
                //txtJCYQty.Text = "";
                CDSave();

                lblKJQty.Text = "";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 疵点处理
        /// <summary>
        /// 创建疵点
        /// </summary>
        /// <param name="p_ParentControl"></param>
        public virtual void CreateCDList(Control p_ParentControl)
        {
            string sql = "SELECT ID,Code,Name FROM Chk_DefectManage WHERE ISNULL(UseableFlag,0)=1";
            DataTable dt = SysUtils.Fill(sql);

            int MaxWidth = p_ParentControl.Width;
            int ButtonWidth = 60;
            int ButtonHight = 40;
            int ButtonWGap = 6;
            int ButtonHGap = 6;
            //groupControl4

            int BXPoint = 14;
            int BYPoint = 14;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(66, 45);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.BackgroundImage = global::HTCPCheck.Properties.Resources._1_默认;
                btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                btn.FlatAppearance.BorderSize = 0;
                btn.UseVisualStyleBackColor = false;
                //btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
                btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
                //btn.BackColor = Color.Lavender;
                btn.Click += new EventHandler(btnCD_Click);
                btn.MouseDown += new MouseEventHandler(btnCD_MouseDown);
                btn.MouseUp += new MouseEventHandler(btnCD_MouseUp);

                btn.Tag = dt.Rows[i]["Code"].ToString();
                btn.Text = dt.Rows[i]["Code"].ToString() + dt.Rows[i]["Name"].ToString();

                btn.Font = new System.Drawing.Font("宋体", 12F, FontStyle.Bold);
                btn.Size = new Size(ButtonWidth, ButtonHight);
                p_ParentControl.Controls.Add(btn);
                btn.Location = new Point(BXPoint, BYPoint);

                if (BXPoint + ButtonWGap + ButtonWidth * 2 > MaxWidth)
                {
                    BXPoint = 14;
                    BYPoint += ButtonHGap + ButtonHight;
                }
                else
                {
                    BXPoint += ButtonWGap + ButtonWidth;
                }
            }

        }
        public void btnCD_Click(object sender, EventArgs e)
        {
            if (!CDInputCheck())
            {
                return;
            }
            Position = SysConvert.ToDecimal(lblQty.Text.Trim());

            lblPositionS.Text = SysConvert.ToString(Position);//记录疵点起始位置

            Button btn = sender as Button;

            ReadStart();//开始读数

            //if (btn.BackColor == System.Drawing.Color.Lavender)
            //{
            //    btn.BackColor = Color.GreenYellow;
            //}
            //else
            //{
            //    btn.BackColor = Color.Lavender;
            //}


            saveBtnCDClick = btn;
            CDInputSetCtlStatus(1);


        }
        public void btnCD_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._1_单击;
        }
        public void btnCD_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._1_默认;
        }


        /// <summary>
        /// 点击疵点检验录入项目
        /// </summary>
        /// <returns></returns>
        public bool CDInputCheck()
        {
            if (lblJarNum.Text == string.Empty)
            {
                this.ShowMessage("请输入缸号/批号");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 疵点操作设置控件状态
        /// </summary>
        /// <param name="p_OPType">操作类型1/2/3/4:1点击疵点/2取消疵点操作/3点击疵点科目</param>
        public void CDInputSetCtlStatus(int p_OPType)
        {
            switch (p_OPType)
            {
                case 1:
                    saveCDClickFlag = true;//点击标志
                    pictureBox1.Enabled = false;//设置不可继续操作

                    gcKFBM.Visible = true;
                    gcISNFault.Visible = false;

                    break;
                case 2://取消
                    saveCDClickFlag = false;//恢复状态
                    pictureBox1.Enabled = true;

                    saveBtnCDClick = null;//初始化

                    gcKFBM.Visible = false;
                    gcISNFault.Visible = true;

                    //if (saveBtnCDClick != null)
                    //{
                    //    saveBtnCDClick.BackColor = Color.Lavender;
                    //}
                    break;
                case 3:
                    //if (saveBtnCDItemClick != null)
                    //{
                    //    saveBtnCDItemClick.BackColor = Color.Pink;
                    //}
                    break;

                case 9://初始化
                    gcKFBM.Visible = false;
                    gcISNFault.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 疵点保存
        /// </summary>
        private void CDSave()
        {
            //ReadStart();
            CheckOrderISNFaultRule rule = new CheckOrderISNFaultRule();
            CheckOrderISN entityMain = EntityGet();
            CheckOrderISNFault entityDtsFault = EntityGetDtsFault();
            rule.RSaveFault(entityDtsFault, entityMain, m_ISNID, m_DtsID);

            btnCDCancel_Click(null, null);
            m_ISNID = entityDtsFault.MainID;
            BindGrid();
            SetEntity(1);

            lblPositionS.Text = "";
            lblPositionE.Text = "";


        }




        /// <summary>
        /// 扣分补码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKFBM_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._6_默认;
        }
        private void btnKFBM_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::HTCPCheck.Properties.Resources._6_单击;
        }
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKFBM_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CDInputCheck())
                {
                    return;
                }
                saveBtnCDItemClick = (Button)sender;
                CDInputSetCtlStatus(3);

                saveCDItemType = 1;
                CDSave();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 疵点操作取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCDCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CDInputSetCtlStatus(2);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        #endregion

        #region 设置数值 SetEntity
        /// <summary>
        /// 设置数值
        /// </summary>
        private void SetEntity(int p_Type)
        {
            if (p_Type == 1)//窗体加载初始化
            {
                string CompactInfo = string.Empty;
                CheckOrder entity = new CheckOrder();
                entity.ID = m_ID;
                entity.SelectByID();

                CheckOrderDts entityDts = new CheckOrderDts();
                entityDts.ID = m_DtsID;
                entityDts.SelectByID();

                CompactInfo += "产品编号:" + entity.ItemCode;
                CompactInfo += " 品名:" + entity.ItemModel;
                CompactInfo += " 色号:" + entityDts.ColorNum;
                CompactInfo += " 颜色:" + entityDts.ColorName;
                CompactInfo += " 缸号:" + entityDts.JarNum;

                lbShowCompactInfo.Text = CompactInfo;

                lblJarNum.Text = entityDts.JarNum;//缸号赋值
            }
        }
        #endregion

        #region 获取Entity
        /// <summary>
        /// 获得布实体
        /// </summary>
        /// <returns></returns>
        public CheckOrderISN EntityGet()
        {
            CheckOrderISN enity = new CheckOrderISN();
            enity.ID = ISNID;
            enity.SelectByID();

            CheckOrderDts entityp = new CheckOrderDts();//检验指示单明细表信息
            entityp.ID = DtsID;
            entityp.SelectByID();
            CheckOrder entityM = new CheckOrder();//检验指示单主表信息
            entityM.ID = entityp.MainID;
            entityM.SelectByID();

            enity.ItemCode = entityM.ItemCode;
            enity.ItemName = entityM.ItemName;
            enity.ItemStd = entityM.ItemStd;
            enity.ItemModel = entityM.ItemModel;
            enity.MWeight = entityM.MWeight;
            enity.MWidth = entityM.MWidth;

            enity.ColorNum = entityp.ColorNum;
            enity.ColorName = entityp.ColorName;
            enity.Batch = entityp.Batch;
            enity.VendorBatch = entityp.VendorBatch;
            //enity.JarNum = entityp.JarNum;
            enity.JarNum = lblJarNum.Text.Trim();
            enity.YQty = entityp.Qty;//原米数          
            if (SysConvert.ToDecimal(lblQty.Text.Trim()) != 0m)
            {
                enity.ChkQty = SysConvert.ToDecimal(lblQty.Text.Trim());
            }
            else
            {
                throw new Exception("数据异常，未读取到码表数据，请稍后重新点击");
            }
            enity.ChkMWeight = entityM.MWeight;//检验的克重
            enity.ChkMWidth = entityM.MWidth;//检验的门幅

            enity.CheckDate = DateTime.Now;
            enity.CheckOPID = FParamConfig.LoginID;
            //EndityGetSetValue(enity);//继承类附加属性 

            return enity;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CheckOrderISNFault EntityGetDtsFault()
        {
            //if (saveBtnCDClick == null)
            //{
            //    throw new Exception("请先选择疵点");
            //}
            //if (saveBtnCDItemClick== null)
            //{
            //    throw new Exception("请先选择疵点科目");
            //}

            CheckOrderISNFault entity = new CheckOrderISNFault();
            entity.MainID = ISNID;
            string sql = "SELECT ISNULL(MAX(Seq),0)+1 As MSEQ FROM Chk_CheckOrderISNFault WHERE MainID=" + entity.MainID.ToString();
            entity.Seq = SysConvert.ToInt32(SysUtils.Fill(sql).Rows[0][0].ToString());//找到最大的Seq
            if (saveBtnCDClick != null)
            {
                entity.FaultDes = saveBtnCDClick.Tag.ToString();
            }
            //if (saveBtnCDItemClick.BackColor != Color.GreenYellow)
            //{
            //    throw new Exception("请先选择疵点科目");
            //}
            if (saveCDItemType == 1)//扣分
            {
                entity.FaultType = 1;
                entity.Deduction = SysConvert.ToString(saveBtnCDItemClick.Tag);
            }
            else if (saveCDItemType == 2)//补码
            {
                entity.FaultType = 2;
                entity.Deduction = SysConvert.ToString(saveBtnCDItemClick.Tag);
            }
            else if (saveCDItemType == 3)//开裁
            {
                entity.FaultType = 3;
                entity.Deduction = SysConvert.ToString(lblKJQty.Text);
            }


            //if (txtKJMS.Text != string.Empty)//开剪米数
            //{
            //    p_Entity.DYM = SysConvert.ToDecimal(txtKJMS.Text);
            //}

            entity.PositionS = SysConvert.ToString(lblQty.Text.Trim());


            //EntityGetDtsFaultSetValue(entity);//继承类附加属性

            return entity;
        }
        /// <summary>
        /// 绑定疵点明细
        /// </summary>
        private void BindGrid()
        {
            CheckOrderISNFaultRule rule = new CheckOrderISNFaultRule();
            gridView1.GridControl.DataSource = rule.RShow(" AND MainID=" + ISNID, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }
        #endregion


        #region 公共方法
        /// <summary>
        /// 校验键盘调用
        /// </summary>
        /// <param name="p_Ctl"></param>
        public void CheckKeyBoardCall(Control p_Ctl)
        {
            try
            {
                p_Ctl.Click += new System.EventHandler(this.CheckKeyBoardCall_Click);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 录入缸号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckKeyBoardCall_Click(object sender, EventArgs e)
        {
            try
            {
                frmKeyBoard frm = new frmKeyBoard();
                frm.InputStr = ((Control)sender).Text;
                frm.ShowDialog();
                if (frm.InputStr != string.Empty)
                {
                    ((Control)sender).Text = frm.InputStr;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 打印等其他下拉菜单按钮
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                int tempReportID = SysConvert.ToInt32(drpReportList.EditValue);
                if (tempReportID == 0)
                {
                    this.ShowMessage("请选择报表模板");
                    return;
                }
                string sql = "SELECT * FROM Chk_CheckOrderISN WHERE ID=" + ISNID;
                DataTable dt = SysUtils.Fill(sql);


                dt.Columns.Add(new DataColumn("ERCode", typeof(Image)));
                foreach (DataRow dr in dt.Rows)
                {
                    string EWM1 = string.Empty;
                    string EWM2 = string.Empty;

                    //EWM1 = " C:" + dr["ItemCode"] + Environment.NewLine;
                    //EWM1 += " M:" + dr["ItemModel"] + Environment.NewLine;

                    EWM1 = SysConvert.ToString(dr["DISN"]);

                    string MSG = "";
                    dr["ERCode"] = HTERCode.HTERBarcode.Create(EWM1, 2, 0, "", out MSG);
                }



                dt.TableName = "Main";
                switch (btnPrint.Text)
                {
                    case "设计":
                        HttSoft.WinUIBase.FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.设计, dt);
                        break;
                    case "预览":
                        HttSoft.WinUIBase.FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.预览, dt);
                        break;
                    case "打印":
                        HttSoft.WinUIBase.FastReport.ReportRunTable(tempReportID, (int)ReportPrintType.打印, dt);
                        break;

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void cmiMorePrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Text = "打印";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void cmiMorePreview_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Text = "预览";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void cmiMorePrintDesign_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Text = "设计";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 码表读取模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiFactMode_Click(object sender, EventArgs e)
        {
            try
            {
                WPOPMode = 0;

                timerReadData.Enabled = false;
                lblModeType.Visible = true;
                lblModeType.Text = "码表读取模式";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 录入模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiInputMode_Click(object sender, EventArgs e)
        {
            try
            {
                WPOPMode = 2;

                timerReadData.Enabled = false;
                lblModeType.Visible = true;
                lblModeType.Text = "录入读数模式";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 模拟码表读取模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiVirtualMode_Click(object sender, EventArgs e)
        {
            try
            {
                WPOPMode = 1;

                timerReadData.Enabled = true;
                lblModeType.Visible = true;
                lblModeType.Text = "模拟码表读数模式";
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void cmiMoreSetting_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductCheckSetting frm = new frmProductCheckSetting();
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void cmiMoreDesc_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductCheckDesc frm = new frmProductCheckDesc();
                frm.Show();

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 绑定FastReport下拉列表
        /// </summary>
        /// <param name="?"></param>
        /// <param name="FormListAID"></param>
        public void BindFastReportList(LookUpEdit p_box, int p_WinListID)
        {
            string sql = string.Empty;
            sql += " SELECT ID,ReportName FROM Data_ReportManage WHERE WinListID=" + p_WinListID;
            DataTable dt = SysUtils.Fill(sql);

            FCommon.LookupEditColAdd(p_box, new int[1] { 50 }, new string[1] { "ReportName" }, new string[1] { "" }, new bool[1] { true });
            FCommon.LoadDropLookUP(p_box, dt, "ReportName", "ID", false);
            if (dt.Rows.Count != 0)
            {
                p_box.EditValue = SysConvert.ToInt32(dt.Rows[0]["ID"]);

            }
        }
        #endregion


        #region 码表读数相关
        /// <summary>
        /// 码表操作模式
        /// </summary>
        private int m_WPOPMode = 0;
        /// <summary>
        /// 码表操作模式
        /// 0/1:码表模式/虚拟模式
        /// </summary>
        public int WPOPMode
        {
            get
            {
                return m_WPOPMode;
            }
            set
            {
                m_WPOPMode = value;
                ReadClose();//改变模式先关闭后启动
                if (m_WPOPMode == 1 || m_WPOPMode == 0)//模拟模式开始启动
                {
                    ReadStart();
                }
            }
        }
        /// <summary>
        /// 读数设置
        /// </summary>
        private void SetReadData(decimal p_ReadData)
        {
            lblReadData.Text = p_ReadData.ToString();

            lblQty.Text = p_ReadData.ToString();
            //if (ComPortID == 1)//码表
            //{
            //    lblReadData.Text = p_ReadData.ToString();
            //}
            //if (ComPortID == 2)//称重
            //{
            //    lblReadData.Text = p_ReadData.ToString();
            //}
        }
        #endregion


    }
}
