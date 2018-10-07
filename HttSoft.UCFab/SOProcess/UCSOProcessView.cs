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
    /// 业务表单站别
    /// 陈加海
    /// 2014.4.18
    /// </summary>
    public enum EnumUCSaleProcedure
    {
        纱线采购单 = 1,
        坯布采购单 = 2,
        成品采购单 = 3,
        辅料采购单 = 4,//一般不进入进度
        染纱加工单 = 10,
        织胚加工单 = 11,
        染整加工单 = 12,
        印花加工单 = 13,
        复合加工单 = 14,
        后整理单 = 20,
        其它加工单 = 25,

    }


    /// <summary>
    /// 功能：单据处理进度显示
    ///    后续改进支持多模式，首先快速成型
    /// 作者：Standy
    /// 日期：2015-5-15
    /// </summary>
    public partial class UCSOProcessView : UCFabBase
    {
        public UCSOProcessView()
        {
            InitializeComponent();
        }
        #region 属性 (后续抽离到基类)
        /// <summary>
        /// 合同号
        /// </summary>
        private string m_FormNo = "";
        /// <summary>
        /// 合同号
        /// </summary>
        public string FormNo
        {
            get
            {
                return m_FormNo;
            }
            set
            {
                m_FormNo = value;
            }
        }

        public int FormDataID = 0;//数据ID
        #endregion

        #region 公共方法  (后续抽离到基类虚方法)
        /// <summary>
        /// 执行控件
        /// </summary>
        public void UCAct()
        {
            IniData();
            SetData();
        }
        #endregion

        #region 内部方法(开始赋值)
        /// <summary>
        /// 设置数据值
        /// </summary>
        void SetData()
        {
            ClearData();
            string sql = string.Empty;
            //订单信息设置
            sql = "SELECT FormNo,MAX(OrderDate) FormDate,SUM(Qty) Qty,SUM(TotalRecQty) ReceiveQty FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(FormNo);
            sql += " GROUP BY FormNo";
            DataTable dt = SysUtils.Fill(sql);
            ucsoProcessSOStandard1.UCDataSource = dt;
            ucsoProcessSOStandard1.UCAct();


            //采购流程设置
            sql = "SELECT FormNo,FormDate,SUM(Qty) Qty,SUM(TotalRecQty) ReceiveQty,MLType FROM UV1_Buy_ItemBuyFormDts WHERE DtsSO=" + SysString.ToDBString(FormNo);
            sql += " GROUP BY FormNo,FormDate,MLType";
            DataTable dtBuy = SysUtils.Fill(sql);
         
            //加工流程设置
            sql = "SELECT FormNo,FormDate,SUM(Qty) Qty,SUM(TotalRecQty) ReceiveQty,ProcessTypeID FROM UV1_WO_FabricProcessDts WHERE DtsSO=" + SysString.ToDBString(FormNo);
            sql += " GROUP BY FormNo,FormDate,ProcessTypeID";
            DataTable dtWO = SysUtils.Fill(sql);

          
            for (int i = 1; i <= 8; i++)
            {
                UCSOProcessOneStandard uspos=FindOneCtl(i);
                SetDataOne(uspos,dtBuy, dtWO);
            }
        }

        void SetDataOne(UCSOProcessOneStandard uspos,DataTable dtBuy, DataTable dtWO)
        {

            if (uspos.Visible)
            {
                switch (uspos.UCStepID)
                {
                    case (int)EnumUCSaleProcedure.纱线采购单:
                        uspos.UCDataSource = dtBuy.Select("MLType=3");
                        break;


                    case (int)EnumUCSaleProcedure.成品采购单:
                        uspos.UCDataSource = dtBuy.Select("MLType=1");
                        break;

                    case (int)EnumUCSaleProcedure.坯布采购单:
                        uspos.UCDataSource = dtBuy.Select("MLType=2");
                        break;
                    case (int)EnumUCSaleProcedure.辅料采购单:
                        uspos.UCDataSource = dtBuy.Select("MLType=5");

                        break;

                    case (int)EnumUCSaleProcedure.织胚加工单:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=2");
                        break;

                    case (int)EnumUCSaleProcedure.染整加工单:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=1");
                        break;

                    case (int)EnumUCSaleProcedure.印花加工单:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=3");
                        break;

                    case (int)EnumUCSaleProcedure.其它加工单:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=4");
                        break;
                }
                uspos.UCAct();
            }

            //for (int i = 0; i < dtBuy.Rows.Count; i++)//采购
            //{
            //    // 1/2/3/4/5：成品，坯布，纱线，色坯，辅料

            //}
            //for (int i = 0; i < dtWO.Rows.Count; i++)//加工
            //{
            //    //2：织造 1：染整 3：印花 4：其它


            //}
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        void ClearData()
        {
            for (int i = 1; i <= 6; i++)
            {
                UCSOProcessOneStandard ucpos = FindOneCtl(i);
                if (ucpos.Visible)
                {
                    ucpos.UCDataSource = null;
                }
            }
        }
        #endregion

        #region 内部方法(初始化配置信息)
        /// <summary>
        /// 初始化数据
        /// </summary>
        void IniData()
        {
            string sql=string.Empty;
            sql = "SELECT ID,Name FROM Enum_SaleProcedure WHERE ShowFlag=1 AND ID IN (SELECT SaleProcedureID FROM Sale_SaleOrderProcedureDts WHERE MainID=" + FormDataID + ") ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IniDataOneProcess(dt.Rows[i], i + 1);
            }
        }
        /// <summary>
        /// 初始化一个进度
        /// </summary>
        /// <param name="p_Dr"></param>
        void IniDataOneProcess(DataRow p_Dr,int p_StepIndex)
        {
            UCSOProcessOneStandard ucpos = FindOneCtl(p_StepIndex);
            ucpos.UCSettingDr=p_Dr;
            ucpos.UCStepIndex=p_StepIndex;
            ucpos.Visible = true;
        }

        /// <summary>
        /// 寻找控件
        /// </summary>
        /// <param name="p_StepIndex"></param>
        /// <returns></returns>
        UCSOProcessOneStandard FindOneCtl(int p_StepIndex)
        {
            foreach (Control ctl in panAll.Controls)
            {
                if (ctl is UCSOProcessOneStandard)
                {
                    if (ctl.Name == "ucsoProcessOneStandard" + p_StepIndex.ToString())
                    {
                        return (UCSOProcessOneStandard)ctl;
                    }
                }
            }
            return new UCSOProcessOneStandard();
            
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSOProcessView_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}
