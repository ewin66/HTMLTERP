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
    /// 标准进度控件
    /// 陈加海
    /// 2014.4.18
    /// </summary>
    public partial class UCStatusBarStand : UCFabBase
    {
        public UCStatusBarStand()
        {
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// 进度标题显示与否
        /// </summary>
        private bool m_UCHeadCaptionVisible = true;
        /// <summary>
        /// 进度标题显示与否
        /// </summary>
        public bool UCHeadCaptionVisible
        {
            get
            {
                return m_UCHeadCaptionVisible;
            }
            set
            {
                m_UCHeadCaptionVisible = value;
            }
        }

        /// <summary>
        /// 进度标题显示宽度
        /// </summary>
        private int m_UCHeadCaptionWidth = 30;
        /// <summary>
        /// 进度标题显示宽度
        /// </summary>
        public int UCHeadCaptionWidth
        {
            get
            {
                return m_UCHeadCaptionWidth;
            }
            set
            {
                m_UCHeadCaptionWidth = value;
            }
        }

        /// <summary>
        /// 进度标题
        /// </summary>
        private string m_UCHeadCaption = string.Empty;
        /// <summary>
        /// 进度标题
        /// </summary>
        public string UCHeadCaption
        {
            get
            {
                return m_UCHeadCaption;
            }
            set
            {
                m_UCHeadCaption = value;
                if (value != string.Empty)
                {
                    lblHeadCaption.Text = value;
                }
            }
        }


        /// <summary>
        /// 数据源
        /// </summary>
        DataTable m_UCDataSource = new DataTable();
        /// <summary>
        /// 数据源
        /// 数据源，列0/1/2/:ID,Name,ColorStr
        /// </summary>
        public DataTable UCDataSource
        {
            set
            {
                m_UCDataSource = value;
            }
            get
            {
                return m_UCDataSource;
            }
        }


        /// <summary>
        /// 宽度
        /// </summary>
        private int m_UCContextWidth = 60;
        /// <summary>
        /// 宽度
        /// </summary>
        public int UCContextWidth
        {
            get
            {
                if (m_UCContextWidth != 0)
                {
                    return m_UCContextWidth;
                }
                else
                {
                    return 60;
                }
            }
            set
            {
                m_UCContextWidth = value;
                
            }
        }


        /// <summary>
        /// 高度
        /// </summary>
        private int m_UCContextHeight = 16;
        /// <summary>
        /// 高度
        /// </summary>
        public int UCContextHeight
        {
            get
            {
                if (m_UCContextHeight != 0)
                {
                    return m_UCContextHeight;
                }
                else
                {
                    return 16;
                }
            }
            set
            {
                m_UCContextHeight = value; 
               
                
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 初始化UI
        /// </summary>
        void IniUI()
        {
            if (this.Parent != null)
            {
                this.BackColor = this.Parent.BackColor;
            }
        }
        #endregion

        #region 外部调用方法
        /// <summary>
        /// 执行绘图
        /// </summary>
        public void UCAct()
        {
            CreateBar(UCDataSource);
        }

        /// <summary>
        /// 赋值方法
        /// </summary>
        /// <param name="ColorStatusName"></param>
        /// <param name="ColorStatusColor"></param>
        public void UCValueIni(string[] ColorStatusName,Color[] ColorStatusColor)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID",typeof(int)));
            dt.Columns.Add(new DataColumn("Name",typeof(string)));
            dt.Columns.Add(new DataColumn("ColorStr", typeof(string)));
            for (int i = 0; i < ColorStatusName.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = i + 1;
                dr["Name"] = ColorStatusName[i];

                ColorConverter cc = new ColorConverter();
                dr["ColorStr"] = cc.ConvertToString(ColorStatusColor[i]);

                dt.Rows.Add(dr);
            }
            m_UCDataSource = dt;
            
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 创建进度条
        /// </summary>
        /// <param name="dtSource">数据源，列0/1/2/:ID,Name,ColorStr</param>
        void CreateBar(DataTable dtSource)
        {

            foreach (Control ctl in this.Controls)
            {
                if (ctl is UCStatusBarStandOne)
                {
                    this.Controls.Remove(ctl);//移除控件
                }
            }

            int modeType = UCStatusBarParamSet.GetIntValueByID(7401);//进度条模式序号：0/1/2/:默认/标准/圆角矩形


            string bColorStr = UCStatusBarParamSet.GetStrValueByID(7402);//进度边框颜色，未设置使用默认色
            Color ucbColor = UCStatusBarParamSet.ConvertColorByStr(bColorStr);
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                UCStatusBarStandItemBase ucft = CreateBar(modeType, i);
                ucft.UCBackColor = UCFabCommon.ConvertColorByStr(dtSource.Rows[i][2].ToString());

                ucft.UCContext = dtSource.Rows[i][1].ToString();
                if (ucbColor != Color.White)
                {
                    ucft.UCBorderColor = ucbColor;
                }
                this.Controls.Add(ucft);

                Application.DoEvents();

            }
        }

        /// <summary>
        /// 创建进度条
        /// </summary>
        /// <param name="p_ModeType">模式</param>
        /// <param name="p_I">序号</param>
        /// <returns>返回Bar</returns>
        UCStatusBarStandItemBase CreateBar(int p_ModeType,int p_I)
        {
            UCStatusBarStandItemBase ucsib;
            switch (p_ModeType)
            {
                case 1:
                    ucsib = CreateBarOne(p_I);
                    break;
                case 2:
                    ucsib = CreateBar2nd(p_I);
                    break;
                default:
                    goto case 2;
            }
            return ucsib;
        }

        /// <summary>
        /// 创建一个进度条
        /// </summary>
        /// <param name="p_XIndex"></param>
        /// <returns></returns>
        UCStatusBarStandOne CreateBarOne(int p_XIndex)
        {
            int splitpixel = 0;//间隔像素
            UCStatusBarStandOne ucbo= new UCStatusBarStandOne();
            int p_FirstColumnWidth = UCHeadCaptionWidth + 2;
            int p_FirstRowHeight = 1;

            ucbo.Location = new System.Drawing.Point(p_XIndex * UCContextWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, splitpixel + p_FirstRowHeight);
            ucbo.Size = new System.Drawing.Size(UCContextWidth, UCContextHeight);
            ucbo.Name = "ucbo" + (10000  + p_XIndex);

            return ucbo;
        }


        /// <summary>
        /// 创建一个进度条(模式二)
        /// </summary>
        /// <param name="p_XIndex"></param>
        /// <returns></returns>
        UCStatusBarStand2nd CreateBar2nd(int p_XIndex)
        {
            int splitpixel = 2;//间隔像素
            UCStatusBarStand2nd ucbo = new UCStatusBarStand2nd();
            int p_FirstColumnWidth = UCHeadCaptionWidth + 2;
            int p_FirstRowHeight = 1;

            ucbo.Location = new System.Drawing.Point(p_XIndex * UCContextWidth + splitpixel * (p_XIndex + 1) + p_FirstColumnWidth, splitpixel + p_FirstRowHeight);
            ucbo.Size = new System.Drawing.Size(UCContextWidth, UCContextHeight);
            ucbo.Name = "ucbo" + (10000 + p_XIndex);

            return ucbo;
        }
        #endregion

        #region 控件加载事件
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCStatusBarStand_Load(object sender, EventArgs e)
        {
            try
            {
                IniUI();               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}
