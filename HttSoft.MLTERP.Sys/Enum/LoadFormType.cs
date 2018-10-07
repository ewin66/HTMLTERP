using System;
using System.Collections.Generic;
using System.Text;

namespace HttSoft.MLTERP.Sys
{
    public enum LoadFormType
    {
        销售订单 = 1,
        采购单 = 2,       //面料采购单
        送货单 = 3,
        出入库单 = 4,
        调样单 = 5,

        坯布采购单 = 6,
        纱线采购单 = 7,
        染布加工单 = 8,
        印花加工单 = 9,
        白坯织造加工单 = 10,
        色坯采购单 = 11,
        辅料采购单 = 12,
        其他加工单 = 13,//后整加工
        复合加工单 = 14,
        坯布算料单 = 15,
        生产通知单 = 16,
        剪样发货单 = 17,
        检验指示单 = 18,
        产品 = 20,
        坯布 = 21,
        内销订单 = 23,
        外销订单 = 24,
        产品_颜色 = 25,
        半成品 = 26,
        原料 = 30,
        生产计划单 = 31,
    }
}
