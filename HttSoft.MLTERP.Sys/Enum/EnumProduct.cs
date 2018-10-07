using System;
using System.Collections.Generic;
using System.Text;

//产品关键枚举
namespace HttSoft.MLTERP.Sys
{

    /// <summary>
    /// 业务表单站别
    /// 陈加海
    /// 2014.4.18
    /// </summary>
    public enum EnumSaleProcedure
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
        其它加工单 = 25,//改为后整加工

    }
}
