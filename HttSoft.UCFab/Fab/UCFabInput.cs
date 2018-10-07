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
    /// 功能：录入面料码单调用控件  总控件
    /// 作者：陈加海
    /// 日期：2014-3-28
    /// </summary>
    public partial class UCFabInput : UCFabBase
    {
        public UCFabInput()
        {
            InitializeComponent();
        }


        #region 属性

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
                //m_UCDataSource.ColumnChanged += new DataColumnChangeEventHandler(UCDataSourceOnColumnChanged);
            }
            get
            {
                PropProcVolumnNum(m_UCDataSource);
                return m_UCDataSource;
            }
        }



        bool m_UCActFlag = false;//是否执行过标志，未执行的改变值不执行

        ///// <summary>
        ///// 数据源列值改变
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="args"></param>
        //protected void UCDataSourceOnColumnChanged(Object sender, DataColumnChangeEventArgs args)
        //{
        //    if (args.Column.ColumnName == "SelectFlag")//选择列值改变的情况下绑定选择项
        //    {
        //        UCFabBaseSelectCtl ucfbsc = UCFindSelectCtl();
        //        if (ucfbsc != null)
        //        {
        //            m_UCDataSource.AcceptChanges();
        //            DataTable dt = UCSelectDataSource;//实际是重新执行已选数据
        //            //ucfbsc.UCAct();//后续如果选择项是多模式的情况下将重新处理调用
        //        }
        //    }
        //}


        /// <summary>
        /// 处理匹号
        /// 如果未输入的话
        /// </summary>
        /// <param name="p_Dt"></param>
        void PropProcVolumnNum(DataTable p_Dt)
        {
            DataRow[] drA = p_Dt.Select(" ISNULL(SubSeq,0)=0 AND (ISNULL(Qty,0)<>0 OR ISNULL(Weight,0)<>0 OR ISNULL(Yard,0)<>0)");//检索不包含匹号的内容
            if(drA.Length>0)
            {
                int maxSubSeq=0;

                DataRow[] drB = p_Dt.Select(" ISNULL(SubSeq,0)<>0"," SubSeq DESC");//获取最大匹号
                if (drB.Length > 0)
                {
                    maxSubSeq = SysConvert.ToInt32(drB[0]["SubSeq"]);
                }

                for (int i = 0; i < drA.Length; i++)
                {
                    maxSubSeq++;
                    drA[i]["SubSeq"] = maxSubSeq;
                }
            }
        }

        #endregion

        #region 全局变量
        #endregion


        #region 外部调用方法




        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public void UCAct()
        {
            UCActLoad();

            m_UCActFlag = true;
            //UCActSelect();
        }





        #endregion

        #region 内部方法
        /// <summary>
        /// 加载控件
        /// </summary>
        void UCActLoad()
        {    

            RemoveUserCtl(panGroupTopRight);
            //panGroupTopRight.Controls.Clear();
            //ClearControlDispose(cla);
            //加载录入控件BEGIN

            int colCount = UCFabParamSet.GetIntValueByID(6022);//码单编辑横向模式列数
            if (radgOPType.SelectedIndex == 2)
            {
                colCount = UCFabParamSet.GetIntValueByID(6023);//码单编辑磁贴模式每行磁贴数
            }
            if (colCount <= 0)
            {
                colCount = 8;
            }

            int inputNum = UCFabParamSet.GetIntValueByID(6025);//码单编辑横向模式格子数
            if (inputNum > 0)
            {
                drpInputNum.Text = inputNum.ToString();
            }

            bool volumeNumberShow = SysConvert.ToBoolean(UCFabParamSet.GetIntValueByID(6024));//卷号是否显示

            UCFabBaseInputCtl ucflbc = CreateFabLoadControl();
            ucflbc.UCDataSource = m_UCDataSource;
            ucflbc.UCColumnCount = colCount;// 10;
            ucflbc.UCInputCount = SysConvert.ToInt32(drpInputNum.Text);//录入格子数
            ucflbc.Dock = DockStyle.Fill;
            ucflbc.UCVolumeNumberShowFlag = volumeNumberShow;//卷号是否显示            

            panGroupTopRight.Controls.Add(ucflbc);

            ucflbc.UCAct();
            //加载录入控件END

        }

        ///// <summary>
        ///// 清空资源
        ///// </summary>
        ///// <param name="cla"></param>
        //void ClearControlDispose(ControlCollection cla)
        //{
        //    foreach (Control ctl in cla)
        //    {
        //        ctl.Dispose();
        //    }
        //}


        /// <summary>
        /// 寻找录入用户控件
        /// </summary>
        /// <returns></returns>
        UCFabBaseInputCtl UCFindInputCtl()
        {
            foreach (Control ctl in panGroupTopRight.Controls)
            {
                if (ctl is UCFabBaseInputCtl)
                {
                    return (UCFabBaseInputCtl)ctl;
                }
            }
            return null;
        }



        /// <summary>
        /// 创建录入控件
        /// </summary>
        UCFabBaseInputCtl CreateFabLoadControl()
        {
            UCFabBaseInputCtl ucfic;
            switch (radgOPType.SelectedIndex)
            {
                case 0:
                    ucfic = new UCFabIHori();
                    break;
                case 1:
                    ucfic = new UCFabIGridView();
                    break;
                case 2:
                    ucfic = new UCFabITileGroup();
                    break;
                default:
                    goto case 0;
            }
            ucfic.Name = "ucfic";
            return ucfic;
        }



        /// <summary>
        /// 处理批量录入控件数据源
        /// </summary>
        /// <param name="startIndex">开始位</param>
        /// <param name="fabCount">匹数</param>
        /// <param name="perQty">每匹数量</param>
        /// <returns>true/false 表格行数有没有改变</returns>
        bool ProBatchDataSource(int startIndex, int fabCount, decimal perQty)
        {
            bool AddFlag = false;
            int fabNo = 0;//卷号,当前已录入卷号
            if (m_UCDataSource.Rows.Count < startIndex + fabCount + 1)//如果行数不足,一般不会影响，事先判断好
            {
                UCFabCommon.AddDtRow(m_UCDataSource, startIndex + fabCount + 1);
                AddFlag = true;
            }
            //if (startIndex > 0)//获取上一卷号
            //{
            //    fabNo = SysConvert.ToInt32(m_UCDataSource.Rows[startIndex - 1]["SubSeq"]);
            //}

            //获取最大卷号
            DataRow[] drA = m_UCDataSource.Select("1=1", "SubSeq DESC");
            if (drA.Length > 0)
            {
                fabNo = SysConvert.ToInt32(drA[0]["SubSeq"]);
            }

            for (int i = startIndex; i < startIndex + fabCount; i++)//开始循环赋值
            {
                m_UCDataSource.Rows[i]["SubSeq"] = (fabNo + i - startIndex + 1).ToString();
                m_UCDataSource.Rows[i]["Qty"] = perQty;
            }

            return AddFlag;
            
        }
        #endregion


        #region 控件事件
        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabInput_Load(object sender, EventArgs e)
        {
            try
            {
                int modelIndex = UCFabParamSet.GetIntValueByID(6021);//码单显示模式默认序号
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
        /// 批量录入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputBatch_Click(object sender, EventArgs e)
        {
            try
            {
                int startIndex = 0;
                UCFabBaseInputCtl ctl = UCFindInputCtl();
                startIndex = ctl.UCCurrnetFocusIndex;

                UCFabInputBatchFrm frm = new UCFabInputBatchFrm();
                frm.ShowDialog();
                if (frm.UCOKFlag)//确定批量录入
                {
                    int fabCount = frm.UCFabCount;
                    decimal perQty = frm.UCFabPerQty;

                    bool addFlag=ProBatchDataSource(startIndex, fabCount, perQty);//处理批量录入数据源

                    if (addFlag)
                    {
                        ctl.UCAct();//重绘界面
                    }
                    else//没有重绘，则重新赋值即可
                    {
                        ctl.UCBind();//重绘界面
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 加载模式改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radgOPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)
                {
                    UCActLoad();
                    panGroupTopRight.Focus();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// 录入格子数量改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpInputNum_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_UCActFlag)
                {
                    UCFabBaseInputCtl ctl = UCFindInputCtl();
                    ctl.UCInputCount = SysConvert.ToInt32(drpInputNum.Text);
                    ctl.UCInputCountChanged();//调用方法
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
