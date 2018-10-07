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
    /// 功能：码单查看  基类用户控件
    /// 作者：陈加海
    /// 日期：2014-3-29
    /// </summary>
    public partial class UCFabBaseViewCtl : UCFabBase
    {
        public UCFabBaseViewCtl()
        {
            InitializeComponent();
        }


        #region 属性
        /// <summary>
        /// 列数量;磁贴形式用到
        /// </summary>
        private int m_UCColumnCount = 4;
        /// <summary>
        /// 列数量;磁贴形式用到
        /// </summary>
        public int UCColumnCount
        {
            get
            {
                return m_UCColumnCount;
            }
            set
            {
                m_UCColumnCount = value;
            }
        }




        /// <summary>
        /// 卷号是否显示标志；横向模式用到
        /// </summary>
        private bool m_UCVolumeNumberShowFlag = true;
        /// <summary>
        /// 卷号是否显示标志；横向模式用到
        /// </summary>
        public bool UCVolumeNumberShowFlag
        {
            get
            {
                return m_UCVolumeNumberShowFlag;
            }
            set
            {
                m_UCVolumeNumberShowFlag = value;
            }
        }


        /// <summary>
        /// 数据源
        /// </summary>
        DataTable m_UCDataSource = new DataTable();
        /// <summary>
        /// 数据源
        /// 数据源，列0/1/2/3/4:选择标志/BoxNo/卷号/数量/缸号
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
        /// 数量转换模式
        /// </summary>
        private bool m_UCQtyConvertMode = false;
        /// <summary>
        /// 数量转换模式
        /// </summary>
        public bool UCQtyConvertMode
        {
            get
            {
                return m_UCQtyConvertMode;
            }
            set
            {
                m_UCQtyConvertMode = value;
            }
        }

        /// <summary>
        /// 数量转换模式:转换目标单位
        /// </summary>
        private string m_UCQtyConvertModeInputUnit = string.Empty;
        /// <summary>
        /// 数量转换模式:转换目标单位
        /// </summary>
        public string UCQtyConvertModeInputUnit
        {
            get
            {
                return m_UCQtyConvertModeInputUnit;
            }
            set
            {
                m_UCQtyConvertModeInputUnit = value;
            }
        }

        /// <summary>
        /// 数量转换模式:转换目标单位
        /// </summary>
        private decimal m_UCQtyConvertModeInputConvertXS = 0;
        /// <summary>
        /// 数量转换模式:转换目标系数
        /// </summary>
        public decimal UCQtyConvertModeInputConvertXS
        {
            get
            {
                return m_UCQtyConvertModeInputConvertXS;
            }
            set
            {
                m_UCQtyConvertModeInputConvertXS = value;
            }
        }


        /// <summary>
        /// 条码列隐藏标志
        /// </summary>
        private bool m_UCColumnISNHide = false;
        /// <summary>
        /// 条码列隐藏标志
        /// 如果发货是录入的码单明细则不显示条码
        /// </summary>
        public bool UCColumnISNHide
        {
            get
            {
                return m_UCColumnISNHide;
            }
            set
            {
                m_UCColumnISNHide = value;
            }
        }

        /// <summary>
        /// 条码列码数是否隐藏
        /// </summary>
        private bool m_UCColumnYard = false;
        /// <summary>
        /// 条码列码数是否隐藏
        /// </summary>
        public bool UCColumnYard
        {
            get
            {
                return m_UCColumnYard;
            }
            set
            {
                m_UCColumnYard = value;
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


      
        #endregion
    }
}
