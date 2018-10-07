using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using HttSoft.Framework;
using HttSoft.FrameFunc;

namespace HTERP
{
    public partial class MessageFormAlarm : BaseForm
    {
        private int heightMax, widthMax;
        /// <summary>
        /// 构造方法
        /// </summary>
        public MessageFormAlarm()
        {
            InitializeComponent();
        }
        private DataTable m_Msg = new DataTable();
        public DataTable Msg
        {
            set
            {
                m_Msg = value;
            }
        }
        private static MessageFormAlarm instance;
        private static object locker = new Object();
        /// <summary>
        /// 实例
        /// </summary>
        public static MessageFormAlarm Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new MessageFormAlarm();
                        }
                    }
                }
                return instance;
            }
        }

        #region 变量属性
        /// <summary>
        /// 消息窗体最大高度
        /// </summary>
        public int HeightMax
        {
            set { heightMax = value;
            this.Height = heightMax;
        }
            get { return heightMax; }
        }
        /// <summary>
        /// 消息窗体最大宽度
        /// </summary>
        public int WidthMax
        {
            set { widthMax = value;
            this.Width = widthMax;
        }
            get { return widthMax; }
        }
        #endregion
        /// <summary>
        /// 卷轴式显示
        /// </summary>
        public void ScrollShow()
        {
            //this.Width = widthMax;
            //this.Height = heightMax;
            this.Show();
          //  this.timerIn.Enabled = true;
        }

        private void ScrollUp()
        {
            this.Visible = true;
            if (Height < heightMax)
            {
             //   this.Height += 3;
                //this.Location = new Point(this.Location.X, this.Location.Y - 3);
            }
            else
            {
                //this.timerIn.Enabled = false;
            }
        }

        private void ScrollDown()
        {
            if (Height > 3)
            {
               // this.Height -= 3;
                //this.Location = new Point(this.Location.X, this.Location.Y + 3);
            }
            else
            {
                //this.timeOut.Enabled = false;
               // this.Close();
                this.Visible = false;
            }
        }

        private void timeOut_Tick(object sender, EventArgs e)
        {
           // ScrollDown();
        }

        private void timerIn_Tick(object sender, EventArgs e)
        {
            //ScrollUp();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //timeOut.Enabled = true;
            this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
            notifyIcon1.Visible = true;
            this.Hide();

        }
        /// <summary>
        /// 创建链接标签
        /// </summary>
        /// <param name="labText"></param>
        /// <param name="row"></param>
        private void CreateLinkLabel(string labText, string linkText, int row)
        {
            LinkLabel linklab = new LinkLabel();
            linklab.AccessibleName = "";
            linklab.Tag = linkText;
            linklab.Text = (row + 1).ToString() + "." + labText;
            linklab.ForeColor = Color.Red;
            linklab.AutoSize = false;
            linklab.Size = new Size(this.widthMax-30, 23);
            linklab.Location = new Point(8, 8 + (11 + 12) * row);
            linklab.AutoEllipsis = true;
     
            linklab.LinkBehavior = LinkBehavior.HoverUnderline;
            linklab.TextAlign = ContentAlignment.MiddleLeft;
            linklab.LinkClicked += new LinkLabelLinkClickedEventHandler(linkSearch_LinkClicked);
            panel1.Controls.Add(linklab);
            //pnlContent.Controls.Add();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            ShowMsg();
            Screen[] screens = Screen.AllScreens;
            Screen screen = screens[0];//获取屏幕变量
            this.Location = new Point(screen.WorkingArea.Width - widthMax - 20, screen.WorkingArea.Height-this.Height-5);//WorkingArea为Windows桌面的工作区
            notifyIcon1.Visible = true;    //显示托盘图标
        }

        private void linkSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //timeOut.Enabled = true;
                LinkLabel link = (LinkLabel)sender;
                if (link.Tag.ToString() != string.Empty)
                {
                    string[] linkinfor = ((string)link.Tag).Split(',');
                    MDIForm.ContextMenuOpenForm(FUISourceObject.GetResultArrayList(FUISourceObject.SourceForm, this),linkinfor[0].ToString(), SysConvert.ToInt32(linkinfor[1]), SysConvert.ToInt32(linkinfor[2]), linkinfor[3].ToString(), FormStatus.查询);
                    notifyIcon1.Visible = true;
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message);
            }
        }
        private void MessageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  FrameVariable.IsMsgOpen = false;
        }
        public void ReleaseData()
        {
        //    pnlContent.Controls.Clear();
            ShowMsg();

        }
        private void ShowMsg()
        {
            panel1.Controls.Clear();
            for (int i = 0; i < m_Msg.Rows.Count; i++)
            {
                CreateLinkLabel(m_Msg.Rows[i]["Name"].ToString(), m_Msg.Rows[i]["LinkName"].ToString(), i);
            }
        }

        private void MessageForm3_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                notifyIcon1.Visible = true;    //显示托盘图标
                this.Hide();    //隐藏窗口
            }

        }

        private void MessageForm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                notifyIcon1.Visible = true;
                this.Hide();
                return;
            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Focus();
            ReleaseData();
        }


    }
}