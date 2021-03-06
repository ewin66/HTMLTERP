using System;
using System.Collections.Generic;
using System.Text;

namespace HttSoft.MLTERP.Sys
{
    /// <summary>
    /// 回填数据方法类型
    /// </summary>
    public enum EnumFillDataType
    {
        采购单制单标准回填方法 = 1,

        销售订单制单标准回填调样单方法 = 10,

        采购入库标准回填方法 = 100,   //只适用于成品面料采购
        坯布纱线采购回填方法 = 101,
        销售出库标准回填方法 = 102,

        销售出库仅回填销售订单方法 = 110,
        //调样入库标准回填方法 = 105,
        //调样销售出库标准回填方法 = 107,

        染布加工出库标准回填方法 = 108,
        染布加工入库标准回填方法 = 109,

        印花加工出库标准回填方法 = 110,
        印花加工入库标准回填方法 = 111,

        织造加工出库标准回填方法 = 112,
        织造加工入库标准回填方法 = 113,

        后整加工入库标准回填方法 = 114,
        后整加工出库标准回填方法 = 115,

        成品加工入库标准回填方法 = 116,


        //产品新方法统一200往下
        采购单入库标准回填方法 = 201,


        加工单入库标准回填方法 = 210,
        //加工单出库标准回填方法=211,
        销售出库回填销售出货数 = 213,
    }
}
