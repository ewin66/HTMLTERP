using System;

namespace HttSoft.MLTERP.Sys
{
    /// <summary>
    /// 对账类型
    /// </summary>
    public enum EnumDZType
    {
        采购 = 1,
        加工=2,
        销售=3,
        

    }

    /// <summary>
    /// 对账标志
    /// </summary>
    public enum EnumDZFlag
    {
        不对帐 = 0,
        对帐正 = 1,
        对帐负 = 2,
    }
}
