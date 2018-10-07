using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemHis实体类
	/// 作者:陈加海
	/// 创建日期:2012-4-18
	/// </summary>
	public sealed class ItemHis : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemHis()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemHis(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private int m_ItemTypeID = 0; 
  		public int ItemTypeID 
  		{ 
  			get 
  			{ 
  				return m_ItemTypeID ; 
  			}  
  			set 
  			{ 
  				m_ItemTypeID = value ; 
  			}  
  		} 
  
  		private int m_ItemClassID = 0; 
  		public int ItemClassID 
  		{ 
  			get 
  			{ 
  				return m_ItemClassID ; 
  			}  
  			set 
  			{ 
  				m_ItemClassID = value ; 
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
  
  		private string m_ItemUnit = string.Empty ; 
  		public string ItemUnit 
  		{ 
  			get 
  			{ 
  				return m_ItemUnit ; 
  			}  
  			set 
  			{ 
  				m_ItemUnit = value ; 
  			}  
  		} 
  
  		private string m_ItemAttnCode = string.Empty ; 
  		public string ItemAttnCode 
  		{ 
  			get 
  			{ 
  				return m_ItemAttnCode ; 
  			}  
  			set 
  			{ 
  				m_ItemAttnCode = value ; 
  			}  
  		} 
  
  		private int m_IsDevide = 0; 
  		public int IsDevide 
  		{ 
  			get 
  			{ 
  				return m_IsDevide ; 
  			}  
  			set 
  			{ 
  				m_IsDevide = value ; 
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
  
  		private string m_ItemNameEn = string.Empty ; 
  		public string ItemNameEn 
  		{ 
  			get 
  			{ 
  				return m_ItemNameEn ; 
  			}  
  			set 
  			{ 
  				m_ItemNameEn = value ; 
  			}  
  		} 
  
  		private string m_ItemStdEn = string.Empty ; 
  		public string ItemStdEn 
  		{ 
  			get 
  			{ 
  				return m_ItemStdEn ; 
  			}  
  			set 
  			{ 
  				m_ItemStdEn = value ; 
  			}  
  		} 
  
  		private string m_BuyShopID = string.Empty ; 
  		public string BuyShopID 
  		{ 
  			get 
  			{ 
  				return m_BuyShopID ; 
  			}  
  			set 
  			{ 
  				m_BuyShopID = value ; 
  			}  
  		} 
  
  		private decimal m_BuyUnitPrice = 0; 
  		public decimal BuyUnitPrice 
  		{ 
  			get 
  			{ 
  				return m_BuyUnitPrice ; 
  			}  
  			set 
  			{ 
  				m_BuyUnitPrice = value ; 
  			}  
  		} 
  
  		private string m_MakeOPID = string.Empty ; 
  		public string MakeOPID 
  		{ 
  			get 
  			{ 
  				return m_MakeOPID ; 
  			}  
  			set 
  			{ 
  				m_MakeOPID = value ; 
  			}  
  		} 
  
  		private string m_ItemrSeason = string.Empty ; 
  		public string ItemrSeason 
  		{ 
  			get 
  			{ 
  				return m_ItemrSeason ; 
  			}  
  			set 
  			{ 
  				m_ItemrSeason = value ; 
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
  
  		private string m_ItemCW = string.Empty ; 
  		public string ItemCW 
  		{ 
  			get 
  			{ 
  				return m_ItemCW ; 
  			}  
  			set 
  			{ 
  				m_ItemCW = value ; 
  			}  
  		} 
  
  		private int m_NewFlag = 0; 
  		public int NewFlag 
  		{ 
  			get 
  			{ 
  				return m_NewFlag ; 
  			}  
  			set 
  			{ 
  				m_NewFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_CDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CDate 
  		{ 
  			get 
  			{ 
  				return m_CDate ; 
  			}  
  			set 
  			{ 
  				m_CDate = value ; 
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
            string Sql="SELECT * FROM Data_ItemHis WHERE "+ "ItemCode="+SysString.ToDBString(m_ItemCode)+" AND ItemName="+SysString.ToDBString(m_ItemName)+" AND ItemStd="+SysString.ToDBString(m_ItemStd)+" AND ItemModel="+SysString.ToDBString(m_ItemModel);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemHis WHERE "+ "ItemCode="+SysString.ToDBString(m_ItemCode)+" AND ItemName="+SysString.ToDBString(m_ItemName)+" AND ItemStd="+SysString.ToDBString(m_ItemStd)+" AND ItemModel="+SysString.ToDBString(m_ItemModel);
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
                m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ItemTypeID"]); 
  				m_ItemClassID=SysConvert.ToInt32(MasterTable.Rows[0]["ItemClassID"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemUnit=SysConvert.ToString(MasterTable.Rows[0]["ItemUnit"]); 
  				m_ItemAttnCode=SysConvert.ToString(MasterTable.Rows[0]["ItemAttnCode"]); 
  				m_IsDevide=SysConvert.ToInt32(MasterTable.Rows[0]["IsDevide"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ItemNameEn=SysConvert.ToString(MasterTable.Rows[0]["ItemNameEn"]); 
  				m_ItemStdEn=SysConvert.ToString(MasterTable.Rows[0]["ItemStdEn"]); 
  				m_BuyShopID=SysConvert.ToString(MasterTable.Rows[0]["BuyShopID"]); 
  				m_BuyUnitPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["BuyUnitPrice"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_ItemrSeason=SysConvert.ToString(MasterTable.Rows[0]["ItemrSeason"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ItemCW=SysConvert.ToString(MasterTable.Rows[0]["ItemCW"]); 
  				m_NewFlag=SysConvert.ToInt32(MasterTable.Rows[0]["NewFlag"]); 
  				m_CDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CDate"]); 
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
