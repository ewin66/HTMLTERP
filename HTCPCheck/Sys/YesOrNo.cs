using System;

namespace HTCPCheck
{
	/// <summary>
	/// �ǻ��
	/// </summary>
	public enum YesOrNo
	{
		/// <summary>
		/// ��
		/// </summary>
		Yes=1,
		/// <summary>
		/// ��
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
    ///// �ֿ��������
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
        ��ⵥ = 1,
        ��ƥ = 2,
    }


}
