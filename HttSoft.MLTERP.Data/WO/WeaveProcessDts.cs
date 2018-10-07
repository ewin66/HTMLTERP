using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_WeaveProcessDts实体类
	/// 作者:翟晓东
	/// 创建日期:2012/8/27
	/// </summary>
	public sealed class WeaveProcessDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WeaveProcessDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WeaveProcessDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_WeaveProcessDts";
		 
  		private int m_ID = 0; 
  		public int ID 
  		{ 
  			get 
  			{ 
  				return m_ID ; 
  			}  
  			set 
  			{ 
  				m_ID = value ; 
  			}  
  		} 
  
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
  			}  
  		} 
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_GoodsCode = string.Empty ; 
  		public string GoodsCode 
  		{ 
  			get 
  			{ 
  				return m_GoodsCode ; 
  			}  
  			set 
  			{ 
  				m_GoodsCode = value ; 
  			}  
  		} 
  
  		private string m_ColorNum = string.Empty ; 
  		public string ColorNum 
  		{ 
  			get 
  			{ 
  				return m_ColorNum ; 
  			}  
  			set 
  			{ 
  				m_ColorNum = value ; 
  			}  
  		} 
  
  		private string m_ColorName = string.Empty ; 
  		public string ColorName 
  		{ 
  			get 
  			{ 
  				return m_ColorName ; 
  			}  
  			set 
  			{ 
  				m_ColorName = value ; 
  			}  
  		} 
  
  		private decimal m_MWidth = 0; 
  		public decimal MWidth 
  		{ 
  			get 
  			{ 
  				return m_MWidth ; 
  			}  
  			set 
  			{ 
  				m_MWidth = value ; 
  			}  
  		} 
  
  		private decimal m_MWeight = 0; 
  		public decimal MWeight 
  		{ 
  			get 
  			{ 
  				return m_MWeight ; 
  			}  
  			set 
  			{ 
  				m_MWeight = value ; 
  			}  
  		} 
  
  		private string m_WeightUnit = string.Empty ; 
  		public string WeightUnit 
  		{ 
  			get 
  			{ 
  				return m_WeightUnit ; 
  			}  
  			set 
  			{ 
  				m_WeightUnit = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_VColorNum = string.Empty ; 
  		public string VColorNum 
  		{ 
  			get 
  			{ 
  				return m_VColorNum ; 
  			}  
  			set 
  			{ 
  				m_VColorNum = value ; 
  			}  
  		} 
  
  		private string m_VColorName = string.Empty ; 
  		public string VColorName 
  		{ 
  			get 
  			{ 
  				return m_VColorName ; 
  			}  
  			set 
  			{ 
  				m_VColorName = value ; 
  			}  
  		} 
  
  		private string m_VItemCode = string.Empty ; 
  		public string VItemCode 
  		{ 
  			get 
  			{ 
  				return m_VItemCode ; 
  			}  
  			set 
  			{ 
  				m_VItemCode = value ; 
  			}  
  		} 
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
  			}  
  		} 
  
  		private string m_Unit = string.Empty ; 
  		public string Unit 
  		{ 
  			get 
  			{ 
  				return m_Unit ; 
  			}  
  			set 
  			{ 
  				m_Unit = value ; 
  			}  
  		} 
  
  		private decimal m_SingPrice = 0; 
  		public decimal SingPrice 
  		{ 
  			get 
  			{ 
  				return m_SingPrice ; 
  			}  
  			set 
  			{ 
  				m_SingPrice = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
  			}  
  		} 
  
  		private DateTime m_ReceivedDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReceivedDate 
  		{ 
  			get 
  			{ 
  				return m_ReceivedDate ; 
  			}  
  			set 
  			{ 
  				m_ReceivedDate = value ; 
  			}  
  		} 
  
  		private decimal m_ReceivedQty = 0; 
  		public decimal ReceivedQty 
  		{ 
  			get 
  			{ 
  				return m_ReceivedQty ; 
  			}  
  			set 
  			{ 
  				m_ReceivedQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalRecQty = 0; 
  		public decimal TotalRecQty 
  		{ 
  			get 
  			{ 
  				return m_TotalRecQty ; 
  			}  
  			set 
  			{ 
  				m_TotalRecQty = value ; 
  			}  
  		} 
  
  		private decimal m_RemainQty = 0; 
  		public decimal RemainQty 
  		{ 
  			get 
  			{ 
  				return m_RemainQty ; 
  			}  
  			set 
  			{ 
  				m_RemainQty = value ; 
  			}  
  		} 
  
  		private decimal m_RemainRate = 0; 
  		public decimal RemainRate 
  		{ 
  			get 
  			{ 
  				return m_RemainRate ; 
  			}  
  			set 
  			{ 
  				m_RemainRate = value ; 
  			}  
  		} 
  
  		private DateTime m_DtsReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DtsReqDate 
  		{ 
  			get 
  			{ 
  				return m_DtsReqDate ; 
  			}  
  			set 
  			{ 
  				m_DtsReqDate = value ; 
  			}  
  		} 
  
  		private string m_Remark = string.Empty ; 
  		public string Remark 
  		{ 
  			get 
  			{ 
  				return m_Remark ; 
  			}  
  			set 
  			{ 
  				m_Remark = value ; 
  			}  
  		} 
  
  		private int m_OrderPreStatusID = 0; 
  		public int OrderPreStatusID 
  		{ 
  			get 
  			{ 
  				return m_OrderPreStatusID ; 
  			}  
  			set 
  			{ 
  				m_OrderPreStatusID = value ; 
  			}  
  		} 
  
  		private int m_OrderStatusID = 0; 
  		public int OrderStatusID 
  		{ 
  			get 
  			{ 
  				return m_OrderStatusID ; 
  			}  
  			set 
  			{ 
  				m_OrderStatusID = value ; 
  			}  
  		} 
  
  		private string m_DtsSO = string.Empty ; 
  		public string DtsSO 
  		{ 
  			get 
  			{ 
  				return m_DtsSO ; 
  			}  
  			set 
  			{ 
  				m_DtsSO = value ; 
  			}  
  		} 
  
  		private string m_DVendorID = string.Empty ; 
  		public string DVendorID 
  		{ 
  			get 
  			{ 
  				return m_DVendorID ; 
  			}  
  			set 
  			{ 
  				m_DVendorID = value ; 
  			}  
  		} 
  
  		private string m_JarNum = string.Empty ; 
  		public string JarNum 
  		{ 
  			get 
  			{ 
  				return m_JarNum ; 
  			}  
  			set 
  			{ 
  				m_JarNum = value ; 
  			}  
  		} 
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_WeaveProcessDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_WeaveProcessDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按传入的SQL语句查询后给属性赋值
        /// </summary>
        /// <param name="p_Sql">SQL语句</param>
        /// <returns>记录存在回true，不存在返回false</returns>
        protected override bool Select(string p_Sql)
        {
            DataTable MasterTable=new DataTable();
            if(!this.sqlTransFlag)
			{
				MasterTable=this.Fill(p_Sql);
			}
			else
			{
				MasterTable=sqlTrans.Fill(p_Sql);
			}
				
            if (MasterTable.Rows.Count>0)
            {
                //查询主表记录
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_SingPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SingPrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_ReceivedDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReceivedDate"]); 
  				m_ReceivedQty=SysConvert.ToDecimal(MasterTable.Rows[0]["ReceivedQty"]); 
  				m_TotalRecQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalRecQty"]); 
  				m_RemainQty=SysConvert.ToDecimal(MasterTable.Rows[0]["RemainQty"]); 
  				m_RemainRate=SysConvert.ToDecimal(MasterTable.Rows[0]["RemainRate"]); 
  				m_DtsReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["DtsReqDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_OrderPreStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderPreStatusID"]); 
  				m_OrderStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["OrderStatusID"]); 
  				m_DtsSO=SysConvert.ToString(MasterTable.Rows[0]["DtsSO"]); 
  				m_DVendorID=SysConvert.ToString(MasterTable.Rows[0]["DVendorID"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
                MasterTable.Dispose();
                return true;
            }
            else
            {
                MasterTable.Dispose();
                return false;
            }
        }
	}
}
