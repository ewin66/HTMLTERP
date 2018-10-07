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
    /// 功能：基类 单个进度表单
    /// 作者：Standy
    /// 日期：2015-5-15
    /// </summary>
    public partial class UCSOProcessOneBase : UCFabBase
    {
        public UCSOProcessOneBase()
        {
            InitializeComponent();
        }



        #region 属性


        /// <summary>
        /// 流程序号
        /// </summary>
        private int m_UCStepIndex = 0;
        /// <summary>
        /// 流程序号
        /// </summary>
        public int UCStepIndex
        {
            get
            {
                return m_UCStepIndex;
            }
            set
            {
                m_UCStepIndex = value;
            }
        }



        /// <summary>
        /// 当前订单是否包含此流程
        /// </summary>
        private bool m_UCStepIncludeFlag = false;
        /// <summary>
        /// 当前订单是否包含此流程
        /// </summary>
        public bool UCStepIncludeFlag
        {
            get
            {
                return m_UCStepIncludeFlag;
            }
            set
            {
                m_UCStepIncludeFlag = value;
            }
        }



        /// <summary>
        /// 站别ID
        /// </summary>
        private int m_UCStepID = 0;
        /// <summary>
        /// 站别ID
        /// </summary>
        public int UCStepID
        {
            set
            {
                m_UCStepID = value;
            }
            get
            {
                return m_UCStepID;
            }
        }



        /// <summary>
        /// 设置行值
        /// </summary>
        DataRow m_UCSettingDr;
        /// <summary>
        /// 设置行值
        /// </summary>
        public DataRow UCSettingDr
        {
            set
            {
                m_UCSettingDr = value;
            }
            get
            {
                return m_UCSettingDr;
            }
        }


        /// <summary>
        /// 数据源
        /// </summary>
        DataRow[] m_UCDataSource = new DataRow[] { };
        /// <summary>
        /// 数据源
        /// 数据源，列0/1/2/3/4:选择标志/BoxNo/卷号/数量/缸号
        /// </summary>
        public DataRow[] UCDataSource
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

        #endregion

        #region 虚方法

        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public virtual void UCAct()
        {
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void UCIni()
        {
        }

        #endregion

        #region 控件加载
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSOProcessOneBase_Load(object sender, EventArgs e)
        {
            try
            {
                //UCAct();
                UCIni();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }
        #endregion
    }
}
