using System;
using System.Collections.Generic;
using System.Text;

namespace HttSoft.HTERP.Sys
{
    public enum EnumBoxStatus
    {

        未入库=1,
        入库=2,
        出库=3,
    }



    ///// <summary>
    ///// 仓库结算类型
    ///// </summary>
    public enum WHCalMethodFieldName
    {
        WHID = 1,
        SectionID = 2,
        SBitID = 3,
        ItemCode = 4,
        ColorNum = 5,
        ColorName = 6,
        JarNum = 7,
        VendorID = 8,
        MWidth = 9,
        MWeight = 10,
        GoodsCode = 11,
        GoodsLevel = 12,
        Batch = 13,
        VendorBatch = 14,
        Unit = 15,
        // Batch = 19,
        FabricTypeCode = 20,
        FabricType = 21,
        WHTypeID = 22,
        SizeName = 23,


    }


    /// <summary>
    /// 回填数据方法类型
    /// </summary>
    public enum EnumFillDataType
    {
        采购单制单标准回填方法 = 1,

        销售订单制单标准回填调样单方法 = 10,

        采购入库标准回填方法 = 100,   //只适用于成品面料采购
        //坯布纱线采购回填方法=101,
        销售出库标准回填方法 = 102,

        销售出库仅回填销售订单方法 = 110,
        //调样入库标准回填方法 = 105,
        //调样销售出库标准回填方法 = 107,

        //染布加工出库标准回填方法=108,
        //染布加工入库标准回填方法=109,

        //印花加工出库标准回填方法 = 110,
        //印花加工入库标准回填方法 = 111,

        //织造加工出库标准回填方法=112,
        //织造加工入库标准回填方法=113,



        //产品新方法统一200往下
        采购单入库标准回填方法 = 201,


        加工单入库标准回填方法 = 210,
        //加工单出库标准回填方法=211,
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
