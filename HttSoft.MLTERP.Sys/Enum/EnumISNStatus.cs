using System;
using System.Collections.Generic;
using System.Text;

namespace HttSoft.MLTERP.Sys
{
    /// <summary>
    /// 条码操作状态状态
    /// </summary>
    public enum EnumISNStatus
    {
        无=1,
        入库=2,
        借出=3,
        归还=4,
        出库=5,
        丢失=6,
        初始=0,
    }

    /// <summary>
    /// 条码在库状态
    /// </summary>
    public enum EnumISNStatusS
    {
        不在库=1,
        在库=2,
    }
}
