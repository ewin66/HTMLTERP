using System;

namespace HttSoft.HTERP.Sys
{

    /// <summary>
    /// 加工单性质
    /// </summary>
    public enum EnumProcessType
    {
        染整加工单 = 1,
        织造加工单 = 2,
        印花加工单 = 3,
        其他加工单 = 4,
        染纱加工单 = 5,


    }


    /// <summary>
    /// 采购物品性质
    /// </summary>
    public enum EnumMLType
    {
        成品 = 1,
        白坯 = 2,
        纱线 = 3,
        色坯 = 4,
        辅料 = 5,
    }


	/// <summary>
	/// 功能：客户类型
	/// 作者：陈加海
	/// 日期：2006-11-29
	/// </summary>
	public enum EnumVendorType
	{
        全部 = 0,
        客户 = 1,
        其他加工厂 = 2,
        物流公司 = 3,
        检测机构 = 4,
        快递公司 = 5,
        供应商 = 6,
        染厂 = 7,
        织厂 = 8,
        加工户 = 9,
        工厂 = 10,
        展会客户 = 11,
        
	}


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
        其它加工单 = 25,

    }
}
