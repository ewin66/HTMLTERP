using System;

namespace HttSoft.MLTERP.Sys
{
    ///// <summary>
    ///// 打样步骤
    ///// </summary>
    //public enum DesignStep
    //{
    //    接样 = 51,
    //    分样 = 52,
    //    重打 = 53,
    //    OK = 54,
    //    撤单 = 55,
    //}

    public enum WHStep
    {
        入库 = 801,
        出库 = 802,
        入库出库 = 803,

        安全库存提前预警 = 821,
        安全库存到达警示 = 822,
    }
}
