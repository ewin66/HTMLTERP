using System;
using System.Collections.Generic;
using System.Text;

namespace HttSoft.MLTERP.Sys
{
    public enum FormNoControlEnum
    {
        #region  老生成单号

        报表流水号 =39,

        ///// <summary>
        ///// 销售
        ///// </summary>
        /////     
        
        //客户报价单号 = 41,
        //订单号 = 42,
        //采购单号 = 43,
        //染色单号 = 44,
        //织片管理=45,
        //加工单号=46,
        //色卡指示书=47,
        //倒筒单号=48,
       
        ///// <summary>
        ///// 采购
        ///// </summary>
        //到货通知单号=68,
        //缸版批复单号 = 67,

        //工务合同编号=48,

        //发货单号=51,
        //出货发票号=52,

        //退货单号=55,

        //计划单号=57,
        //领用申请单号=56,

        //加油单号=60,
        //产量登记单号=61,



        //付款申请=81,
        //进项对账单号=82,
        //发票号码=83,
        //销项对账单号 = 84,
        ///// <summary>
        ///// 生产管理
        ///// </summary>
        //车间产量单号=71,
        //生产通知单号=72,
        //生产工艺单号=73,
        //核价单号=74,

        #endregion

        #region 新生成单号
        产品编码=101,
        挂板借出单号=102,
        留样单号=103,
        调样单号=104,
        合同号=105,
        销售合同采购单号=106,
        挂板单号=107,
        挂板借出录入单号= 1003,

        打样指示单单号 = 282,
      

        结算单号 = 112,
        报价单号=113,
        发货单号=114,
        跟单单号=115,
        开匹单号 = 116,
        发货单送货单号=117,//发货单内的送货单号

        物流单号=121,
        快递单号=122,
        检验单号=123,
        成品检验单号=124,
        织造加工单号=125,
        印花加工单号=126,
        其他加工单号 = 127, 

        对账单号=131,
        发票单号=132,
        收付款单号=133,
        发票单号2 = 134,

        日报编号=141,
        资金计划表编号=142,


        码单箱号=260,


        样品报价单号=280,
        样品销售单号=281,

        短信输入单号=301,

        溢缺单号=302,

        打色指示单=314,

        异常管理单单号=401,

        #region 巨高添加 从 150 开始
        坯布采购单号=150,
        染布加工单号=151,
        //印花加工单号=152,
        日常费用登记单号=153,
        纱线采购单号=154,
        白坯织造加工单号=155,
        纱线入库单号=156,
        纱线出库单号=157,
        #endregion
        #endregion
        新打色单号 = 160,
        品质样管理 = 161,
        订单结算单号 = 162,
        生产通知单号=163,
        寄样编号=164,
        剪样单号=165,
        
    }


    /// <summary>
    /// 客户流水号单据枚举
    /// </summary>
    public enum EnumFNCV
    {
        /// <summary>
        /// 发货单送货单号
        /// </summary>
        发货单送货单号=1,
    }
}