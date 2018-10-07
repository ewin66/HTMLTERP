using System;

namespace HTCPCheck
{
	/// <summary>
	/// 是或否
	/// </summary>
	public enum YesOrNo
	{
		/// <summary>
		/// 是
		/// </summary>
		Yes=1,
		/// <summary>
		/// 否
		/// </summary>
		No=0



	}


	public class YesOrNoFunc
	{
		public static bool GetIntBool(int p_Flag)
		{
			if(p_Flag==(int)YesOrNo.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static int GetBoolInt(bool p_Flag)
		{
			if(p_Flag)
			{
				return (int)YesOrNo.Yes;
			}
			else
			{
				return (int)YesOrNo.No;
			}
		}

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

        // Batch = 19,
        FabricTypeCode = 20,
        FabricType = 21,
        WHTypeID = 22,
        SizeName = 23,


    }

    public enum PackBoxSourceType
    {
        入库单 = 1,
        开匹 = 2,
    }


}
