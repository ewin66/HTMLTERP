using System;

namespace HttSoft.MLTERP.Sys
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



}
