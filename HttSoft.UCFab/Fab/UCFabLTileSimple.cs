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
    /// 功能：加载面料码单简单版磁贴模式
    /// 作者：陈加海
    /// 日期：2014-3-28
    /// </summary>
    public partial class UCFabLTileSimple : UCFabBase
    {
        public UCFabLTileSimple()
        {
            InitializeComponent();
        }


        #region 临时静态变量，后续移动到全局变量，或配置数据库内
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//默认色系

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//偶数列色系 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//偶数列色系 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//选择色系
        #endregion
        #region 属性
        /// <summary>
        /// 选择
        /// </summary>
        private bool m_UCChecked = false;
        /// <summary>
        /// 选择
        /// </summary>
        public bool UCChecked
        {
            get
            {
                return m_UCChecked;
            }
            set
            {
                if (m_UCChecked != value)
                {
                    m_UCChecked = value;

                    ControlBackColorSet();
                    object_CheckedChanged(this);//调用委托程序，返回选择值给Group控件
                }
            }
        }


        /// <summary>
        /// 磁贴序号
        /// </summary>
        int m_UCRowIndex = 0;
        /// <summary>
        /// 磁贴序号
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
        /// 条码号
        /// </summary>
        string m_UCISN = string.Empty;
        /// <summary>
        /// 条码号
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
                //lblInfo4.Text = value;
            }
        }

        /// <summary>
        /// 附加属性
        /// </summary>
        string[] m_UCAttachProt = new string[] { };
        /// <summary>
        /// 附加属性
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
                    lblInfo1.Text = value[0];//卷号
                    lblInfo2.Text = value[1];//数量
                    //lblInfo3.Text = value[2];//缸号
                }
            }

        }

        /// <summary>
        /// 设置控件背景色系
        /// 1/2
        /// </summary>
        int m_UCBackColorIndex = 1;

        /// <summary>
        /// 设置控件背景色系
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

        #region 外部调用方法
        /// <summary>
        /// 外部初始化值
        /// </summary>
        /// <param name="p_ISN">唯一条码号</param>
        /// <param name="p_AttachProt">附加属性数组</param>
        /// <param name="p_Checked">选择情况</param>
        /// <param name="p_UCIndex">控件背景色系，背景色系</param>
        public void IniValue(string p_ISN, string[] p_AttachProt, bool p_Checked, int p_UCIndex)
        {
            UCISN = p_ISN;
            UCAttachProt = p_AttachProt;
            UCChecked = p_Checked;
            UCBackColorIndex = p_UCIndex;
            ControlBackColorSet();
        }
        #endregion
        #region 内部方法
        /// <summary>
        /// 控件颜色设定
        /// </summary>
        void ControlBackColorSet()
        {
            if (this.UCChecked)//如果选中改变颜色
            {
                panTile.Appearance.BackColor = UCSelectColor;
                panTile.Appearance.BackColor2 = UCSelectColor;
            }
            else//如果未选择，恢复颜色
            {
                panTile.Appearance.BackColor = saveBackColor;
                panTile.Appearance.BackColor2 = saveBackColor2;
            }
        }
        #endregion

        #region 全局变量
        Color saveBackColor = Color.White;
        Color saveBackColor2 = Color.White;


        #endregion



        #region 公共事件
        public UCFabLTileCheckChanged object_CheckedChanged;//勾选改变


        public UCFabRowIndexChanged UCControl_RowIndexChanged;//行值改变
        #endregion


        #region 其它事件
        /// <summary>
        /// 选择/反选
        /// 不直接调用，非输入类控件右键也会执行此事件，带来困扰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlSelect_Click()
        {
            try
            {
                
                m_UCChecked = !m_UCChecked;

                ControlBackColorSet();
                object_CheckedChanged(this);//调用委托程序，返回选择值给Group控件
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 容器/Label 鼠标点击选中，右键屏蔽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panTile_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)//左键使用
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
        /// 鼠标点击改变行值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                UCControl_RowIndexChanged(sender,m_UCRowIndex);//委托事件
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

       
        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabLTileSimple_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblInfo1.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
                this.lblInfo2.MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
             
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


       

       
    }
}
