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
    /// 功能：录入码单 磁贴
    /// 作者：陈加海
    /// 日期：2014-3-31
    /// </summary>
    public partial class UCFabITile : UCFabBase
    {
        public UCFabITile()
        {
            InitializeComponent();
            UCIniLoad();
        }


        #region 临时静态变量，后续移动到全局变量，或配置数据库内
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//默认色系

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//偶数列色系 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//偶数列色系 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//选择色系
        #endregion

        #region 公共事件
        public UCFabRowIndexChanged UCControl_RowIndexChanged;
        #endregion
        #region 属性

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
                lblInfo4.Text = value;
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
        /// 磁贴X Y轴号
        /// </summary>
        string m_UCTileXY = "";
        /// <summary>
        /// 磁贴X Y轴号
        /// </summary>
        public string UCTileXY
        {
            get
            {
                return m_UCTileXY;
            }
            set
            {
                m_UCTileXY = value;
            }
        }

        /// <summary>
        /// 数据行
        /// </summary>
        DataRow m_DrSource;
        /// <summary>
        /// 数据行
        /// </summary>
        public DataRow DrSource
        {
            get
            {
                return m_DrSource;
            }
            set
            {
                m_DrSource = value;


                if (value != null)
                {
                    txtCode.Text = m_DrSource["SubSeq"].ToString();//卷号
                    txtQty.Text = m_DrSource["Qty"].ToString();//数量
                    lblInfo4.Text = m_DrSource["BoxNo"].ToString();//BoxNo

                    //lblInfo4.Text = m_UCTileXY.ToString() + " " + this.Location.Y.ToString();//临时用下
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
        /// 重新刷新数据
        /// </summary>
        public void UCBindData()
        {
            if (m_DrSource != null)
            {
                txtCode.Text = m_DrSource["SubSeq"].ToString();//卷号
                txtQty.Text = m_DrSource["Qty"].ToString();//数量
                lblInfo4.Text = m_DrSource["BoxNo"].ToString();//BoxNo
            }
        }
        
        #endregion

        #region 内部方法
        /// <summary>
        /// 控件颜色设定
        /// </summary>
        void ControlBackColorSet()
        {
            //if (this.UCChecked)//如果选中改变颜色
            //{
            //    panTile.Appearance.BackColor = UCSelectColor;
            //    panTile.Appearance.BackColor2 = UCSelectColor;
            //}
            //else//如果未选择，恢复颜色
            //{
            panTile.Appearance.BackColor = saveBackColor;
            panTile.Appearance.BackColor2 = saveBackColor2;
            //}
        }
        #endregion

        #region 全局变量
        Color saveBackColor = Color.White;
        Color saveBackColor2 = Color.White;


        #endregion


        #region 窗体加载
        private void UCFabITile_Load(object sender, EventArgs e)
        {
            try
            {

                this.panTile.Paint += new PaintEventHandler(ctlDisplay_Paint);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 初始化控件事件绑定
        /// </summary>
        void UCIniLoad()
        {
            try
            {
                //BindMouseClickEvent(new Control[] { lblInfo4, txtCode, txtQty, panTile, this });

                BindClickEvent(new Control[] { lblInfo4, txtCode, txtQty, panTile, this });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        ///// <summary>
        ///// 绑定鼠标点击
        ///// </summary>
        ///// <param name="p_Ctl"></param>
        //void BindMouseClickEvent(Control[] p_Ctl)
        //{
        //    for (int i = 0; i < p_Ctl.Length; i++)
        //    {
        //        p_Ctl[i].MouseClick += new System.Windows.Forms.MouseEventHandler(Control_MouseClick);
        //    }
        //}

        /// <summary>
        /// 绑定点击
        /// </summary>
        /// <param name="p_Ctl"></param>
        void BindClickEvent(Control[] p_Ctl)
        {
            for (int i = 0; i < p_Ctl.Length; i++)
            {
                p_Ctl[i].Click += new System.EventHandler(Control_Click);
            }
        }

        #endregion
        #region 录入值改变
        /// <summary>
        /// 卷号改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(txtCode.Text.Trim()) != 0)
                {
                    DrSource["SubSeq"] = SysConvert.ToInt32(txtCode.Text.Trim());
                }
                else
                {
                    DrSource["SubSeq"] = DBNull.Value;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 数量改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQty_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = 0;
                qty = SysConvert.ToDecimal(txtQty.Text.Trim());
                if (qty != 0)
                {
                    DrSource["Qty"] = qty;
                }
                else
                {
                    DrSource["Qty"] = DBNull.Value;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region 其它事件
        
        /// <summary>
        /// 控件点击改变父控件行值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ShowMessage(m_UCRowIndex.ToString());
                UCControl_RowIndexChanged(sender,m_UCRowIndex);//委托事件
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion




    }
}
