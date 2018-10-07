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
    /// 功能：查看面料码单控件  总控件
    /// 作者：陈加海
    /// 日期：2014-3-31
    /// </summary>
    public partial class UCFabView : UCFabBase
    {
        public UCFabView()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 数量转换模式
        /// </summary>
        private bool m_UCQtyConvertMode = false;
        /// <summary>
        /// 数量转换模式
        /// 如果启用会把转换模式的数量列显示及标题修改
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
        /// 给列标题修改显示用
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
        /// 仅显示用
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


        bool m_UCActFlag = false;//是否执行过标志，未执行的改变值不执行

        #endregion



        #region 外部调用方法
        ///// <summary>
        ///// 初始化数据源结构
        ///// </summary>
        //public void IniDataSourceStruct()
        //{
        //    m_UCDataSource.Columns.Add(new DataColumn("SelectFlag", typeof(int)));//选择
        //    m_UCDataSource.Columns.Add(new DataColumn("BoxNo", typeof(string)));//条码
        //    m_UCDataSource.Columns.Add(new DataColumn("SubSeq", typeof(string)));//卷号
        //    m_UCDataSource.Columns.Add(new DataColumn("Qty", typeof(decimal)));//数量
        //    m_UCDataSource.Columns.Add(new DataColumn("JarNum", typeof(string)));//缸号
        //    m_UCDataSource.Columns.Add(new DataColumn("ItemModel", typeof(string)));//品名
        //}


        /// <summary>
        /// 数据转向
        /// 用于码单打印成二维格式
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="p_ColCount">列数</param>
        /// <returns>行0,2,4,6,...:匹号；行1,3,5,7,...:数量</returns>
        public DataTable UCDataSourceVHori(DataTable dtSource, int p_ColCount)
        {
            DataTable outdt = new DataTable();
            outdt.Columns.Add(new DataColumn("ColTitle", typeof(string)));
            for (int i = 1; i <= p_ColCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));
            }
            //列添加完毕，开始转换数据
            int rowIndex = 0;//转换后行号
            int colIndex = 0;//转换后列号
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                rowIndex = i / p_ColCount;
                colIndex = i % p_ColCount;

                if (colIndex == 0)//第一列，则添加两行
                {
                    DataRow dr = outdt.NewRow();
                    dr["ColTitle"] = "匹号";
                    outdt.Rows.Add(dr);
                    DataRow dr2 = outdt.NewRow();
                    dr2["ColTitle"] = "米数";
                    outdt.Rows.Add(dr2);
                    DataRow dr3 = outdt.NewRow();
                    dr3["ColTitle"] = "重量";
                    outdt.Rows.Add(dr2);
                    DataRow dr4 = outdt.NewRow();
                    dr4["ColTitle"] = "等级";
                    outdt.Rows.Add(dr4);
                }

                //开始赋值
                outdt.Rows[rowIndex * 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//匹号
                outdt.Rows[rowIndex * 4 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//米数
                outdt.Rows[rowIndex * 4 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//重量
                outdt.Rows[rowIndex * 4 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["GoodsLevel"].ToString();//重量

            }

            return outdt;
        }


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public void UCAct()
        {
            UCActView();
            m_UCActFlag = true;
        }





        #endregion

        #region 内部方法

        /// <summary>
        /// 已选控件
        /// </summary>
        void UCActView()
        {
            //加载结果展示控件BEGIN
            RemoveUserCtl(panGroupTopRight);
            //panGroupTopRight.Controls.Clear();


            lblInputInfo.Visible = UCQtyConvertMode;
            if (UCQtyConvertMode)
            {
                lblInputInfo.Text = "转换单位:" + UCQtyConvertModeInputUnit + "  系数:" + UCQtyConvertModeInputConvertXS;
            }

            UCFabBaseViewCtl ucfbsc = CreateFabViewControl();
            ucfbsc.UCDataSource = m_UCDataSource;
            int colCount = UCFabParamSet.GetIntValueByID(6002);//码单显示横向模式列数
            if (colCount <= 0)
            {
                colCount = 10;
            }
            bool volumeNumberShow = SysConvert.ToBoolean(UCFabParamSet.GetIntValueByID(6024));//卷号是否显示
            ucfbsc.UCColumnCount = colCount;//10
            ucfbsc.Dock = DockStyle.Fill;
            ucfbsc.UCVolumeNumberShowFlag = volumeNumberShow;//卷号是否显示
            ucfbsc.UCQtyConvertMode = UCQtyConvertMode;
            ucfbsc.UCQtyConvertModeInputUnit = UCQtyConvertModeInputUnit;
            ucfbsc.UCQtyConvertModeInputConvertXS = UCQtyConvertModeInputConvertXS;
            ucfbsc.UCColumnISNHide = UCColumnISNHide;
            panGroupTopRight.Controls.Add(ucfbsc);
            ucfbsc.UCAct();
            //加载结果展示控件END
        }



        /// <summary>
        /// 寻找加载用户控件
        /// </summary>
        /// <returns></returns>
        UCFabBaseViewCtl UCFindViewCtl()
        {
            foreach (Control ctl in panGroupTopRight.Controls)
            {
                if (ctl is UCFabBaseViewCtl)
                {
                    return (UCFabBaseViewCtl)ctl;
                }
            }
            return null;
        }





        /// <summary>
        /// 创建选择结果控件
        /// </summary>
        UCFabBaseViewCtl CreateFabViewControl()
        {
            UCFabBaseViewCtl ucfbvc;
            switch (radgOPType.SelectedIndex)
            {
                case 0://横向
                    ucfbvc = new UCFabVHori();
                    break;
                case 1://GridView
                    ucfbvc = new UCFabVGridView();
                    break;
                default:
                    goto case 0;
            }
            ucfbvc.Name = "ucfbvc";
            return ucfbvc;
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabView_Load(object sender, EventArgs e)
        {
            try
            {
                int modelIndex = UCFabParamSet.GetIntValueByID(6001);//码单显示模式默认序号
                if (modelIndex > 0 && modelIndex < radgOPType.Properties.Items.Count)
                {
                    radgOPType.SelectedIndex = modelIndex;
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
        /// 加载模式改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgOPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)//执行过再继续执行，避免多次执行
                {
                    UCActView();
                    panGroupTopRight.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


    }
}
