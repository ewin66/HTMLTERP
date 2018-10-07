using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_ShipmentDts实体类
	/// 作者:周富春
	/// 创建日期:2011/11/23
	/// </summary>
	public sealed class ShipmentDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ShipmentDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ShipmentDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private int m_YarnTypeID = 0; 
  		public int YarnTypeID 
  		{ 
  			get 
  			{ 
  				return m_YarnTypeID ; 
  			}  
  			set 
  			{ 
  				m_YarnTypeID = value ; 
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
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
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
  
  		private decimal m_SinglePrice = 0; 
  		public decimal SinglePrice 
  		{ 
  			get 
  			{ 
  				return m_SinglePrice ; 
  			}  
  			set 
  			{ 
  				m_SinglePrice = value ; 
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
  
  		private string m_DesignNo = string.Empty ; 
  		public string DesignNo 
  		{ 
  			get 
  			{ 
  				return m_DesignNo ; 
  			}  
  			set 
  			{ 
  				m_DesignNo = value ; 
  			}  
  		} 
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
  			}  
  		} 
  
  		private string m_YarnStatus = string.Empty ; 
  		public string YarnStatus 
  		{ 
  			get 
  			{ 
  				return m_YarnStatus ; 
  			}  
  			set 
  			{ 
  				m_YarnStatus = value ; 
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
  
  		private int m_IsShipmentFlag = 0; 
  		public int IsShipmentFlag 
  		{ 
  			get 
  			{ 
  				return m_IsShipmentFlag ; 
  			}  
  			set 
  			{ 
  				m_IsShipmentFlag = value ; 
  			}  
  		} 
  
  		private decimal m_ShipmentQty = 0; 
  		public decimal ShipmentQty 
  		{ 
  			get 
  			{ 
  				return m_ShipmentQty ; 
  			}  
  			set 
  			{ 
  				m_ShipmentQty = value ; 
  			}  
  		} 
  
  		private DateTime m_ShipmentDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ShipmentDate 
  		{ 
  			get 
  			{ 
  				return m_ShipmentDate ; 
  			}  
  			set 
  			{ 
  				m_ShipmentDate = value ; 
  			}  
  		} 
  
  		private string m_ShipmentFormNo = string.Empty ; 
  		public string ShipmentFormNo 
  		{ 
  			get 
  			{ 
  				return m_ShipmentFormNo ; 
  			}  
  			set 
  			{ 
  				m_ShipmentFormNo = value ; 
  			}  
  		} 
  
  		private string m_CompactCode = string.Empty ; 
  		public string CompactCode 
  		{ 
  			get 
  			{ 
  				return m_CompactCode ; 
  			}  
  			set 
  			{ 
  				m_CompactCode = value ; 
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
            string Sql="SELECT * FROM Sale_ShipmentDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_ShipmentDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_YarnTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["YarnTypeID"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_DesignNo=SysConvert.ToString(MasterTable.Rows[0]["DesignNo"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_YarnStatus=SysConvert.ToString(MasterTable.Rows[0]["YarnStatus"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_IsShipmentFlag=SysConvert.ToInt32(MasterTable.Rows[0]["IsShipmentFlag"]); 
  				m_ShipmentQty=SysConvert.ToDecimal(MasterTable.Rows[0]["ShipmentQty"]); 
  				m_ShipmentDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ShipmentDate"]); 
  				m_ShipmentFormNo=SysConvert.ToString(MasterTable.Rows[0]["ShipmentFormNo"]); 
  				m_CompactCode=SysConvert.ToString(MasterTable.Rows[0]["CompactCode"]); 
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
