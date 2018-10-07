using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemColorDtsHis实体类
	/// 作者:tanghao
	/// 创建日期:2015/5/27
	/// </summary>
	public sealed class ItemColorDtsHis : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemColorDtsHis()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemColorDtsHis(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_ItemColorDtsHis";
		 
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
  
  		private decimal m_BuyPrice = 0; 
  		public decimal BuyPrice 
  		{ 
  			get 
  			{ 
  				return m_BuyPrice ; 
  			}  
  			set 
  			{ 
  				m_BuyPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_BuyPriceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime BuyPriceDate 
  		{ 
  			get 
  			{ 
  				return m_BuyPriceDate ; 
  			}  
  			set 
  			{ 
  				m_BuyPriceDate = value ; 
  			}  
  		} 
  
  		private decimal m_SalePrice = 0; 
  		public decimal SalePrice 
  		{ 
  			get 
  			{ 
  				return m_SalePrice ; 
  			}  
  			set 
  			{ 
  				m_SalePrice = value ; 
  			}  
  		} 
  
  		private DateTime m_SalePriceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SalePriceDate 
  		{ 
  			get 
  			{ 
  				return m_SalePriceDate ; 
  			}  
  			set 
  			{ 
  				m_SalePriceDate = value ; 
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
  
  		private decimal m_DHPrice = 0; 
  		public decimal DHPrice 
  		{ 
  			get 
  			{ 
  				return m_DHPrice ; 
  			}  
  			set 
  			{ 
  				m_DHPrice = value ; 
  			}  
  		} 
  
  		private decimal m_XHPrice = 0; 
  		public decimal XHPrice 
  		{ 
  			get 
  			{ 
  				return m_XHPrice ; 
  			}  
  			set 
  			{ 
  				m_XHPrice = value ; 
  			}  
  		} 
  
  		private decimal m_YBPrice = 0; 
  		public decimal YBPrice 
  		{ 
  			get 
  			{ 
  				return m_YBPrice ; 
  			}  
  			set 
  			{ 
  				m_YBPrice = value ; 
  			}  
  		} 
  
  		private decimal m_PBPrice = 0; 
  		public decimal PBPrice 
  		{ 
  			get 
  			{ 
  				return m_PBPrice ; 
  			}  
  			set 
  			{ 
  				m_PBPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_PBPriceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PBPriceDate 
  		{ 
  			get 
  			{ 
  				return m_PBPriceDate ; 
  			}  
  			set 
  			{ 
  				m_PBPriceDate = value ; 
  			}  
  		} 
  
  		private decimal m_PBSalePrice = 0; 
  		public decimal PBSalePrice 
  		{ 
  			get 
  			{ 
  				return m_PBSalePrice ; 
  			}  
  			set 
  			{ 
  				m_PBSalePrice = value ; 
  			}  
  		} 
  
  		private DateTime m_PBSalePriceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PBSalePriceDate 
  		{ 
  			get 
  			{ 
  				return m_PBSalePriceDate ; 
  			}  
  			set 
  			{ 
  				m_PBSalePriceDate = value ; 
  			}  
  		} 
  
  		private string m_FreeStr1 = string.Empty ; 
  		public string FreeStr1 
  		{ 
  			get 
  			{ 
  				return m_FreeStr1 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr1 = value ; 
  			}  
  		} 
  
  		private string m_FreeNum1 = string.Empty ; 
  		public string FreeNum1 
  		{ 
  			get 
  			{ 
  				return m_FreeNum1 ; 
  			}  
  			set 
  			{ 
  				m_FreeNum1 = value ; 
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
  
  		private decimal m_ColorPrice = 0; 
  		public decimal ColorPrice 
  		{ 
  			get 
  			{ 
  				return m_ColorPrice ; 
  			}  
  			set 
  			{ 
  				m_ColorPrice = value ; 
  			}  
  		} 
  
  		private decimal m_ZLPrice = 0; 
  		public decimal ZLPrice 
  		{ 
  			get 
  			{ 
  				return m_ZLPrice ; 
  			}  
  			set 
  			{ 
  				m_ZLPrice = value ; 
  			}  
  		} 
  
  		private decimal m_TotalPriceUSB = 0; 
  		public decimal TotalPriceUSB 
  		{ 
  			get 
  			{ 
  				return m_TotalPriceUSB ; 
  			}  
  			set 
  			{ 
  				m_TotalPriceUSB = value ; 
  			}  
  		} 
  
  		private decimal m_ExchangeRate = 0; 
  		public decimal ExchangeRate 
  		{ 
  			get 
  			{ 
  				return m_ExchangeRate ; 
  			}  
  			set 
  			{ 
  				m_ExchangeRate = value ; 
  			}  
  		} 
  
  		private decimal m_TotalPriceRMB = 0; 
  		public decimal TotalPriceRMB 
  		{ 
  			get 
  			{ 
  				return m_TotalPriceRMB ; 
  			}  
  			set 
  			{ 
  				m_TotalPriceRMB = value ; 
  			}  
  		} 
  
  		private decimal m_CBPrice = 0; 
  		public decimal CBPrice 
  		{ 
  			get 
  			{ 
  				return m_CBPrice ; 
  			}  
  			set 
  			{ 
  				m_CBPrice = value ; 
  			}  
  		} 
  
  		private decimal m_JGPrice = 0; 
  		public decimal JGPrice 
  		{ 
  			get 
  			{ 
  				return m_JGPrice ; 
  			}  
  			set 
  			{ 
  				m_JGPrice = value ; 
  			}  
  		} 
  
  		private decimal m_TotalPrice = 0; 
  		public decimal TotalPrice 
  		{ 
  			get 
  			{ 
  				return m_TotalPrice ; 
  			}  
  			set 
  			{ 
  				m_TotalPrice = value ; 
  			}  
  		} 
  
  		private decimal m_RFPrice = 0; 
  		public decimal RFPrice 
  		{ 
  			get 
  			{ 
  				return m_RFPrice ; 
  			}  
  			set 
  			{ 
  				m_RFPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_ZXBJDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ZXBJDate 
  		{ 
  			get 
  			{ 
  				return m_ZXBJDate ; 
  			}  
  			set 
  			{ 
  				m_ZXBJDate = value ; 
  			}  
  		} 
  
  		private decimal m_Shrinkage = 0; 
  		public decimal Shrinkage 
  		{ 
  			get 
  			{ 
  				return m_Shrinkage ; 
  			}  
  			set 
  			{ 
  				m_Shrinkage = value ; 
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
            string Sql="SELECT * FROM Data_ItemColorDtsHis WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemColorDtsHis WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_BuyPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["BuyPrice"]); 
  				m_BuyPriceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["BuyPriceDate"]); 
  				m_SalePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SalePrice"]); 
  				m_SalePriceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SalePriceDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DHPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DHPrice"]); 
  				m_XHPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["XHPrice"]); 
  				m_YBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["YBPrice"]); 
  				m_PBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PBPrice"]); 
  				m_PBPriceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PBPriceDate"]); 
  				m_PBSalePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["PBSalePrice"]); 
  				m_PBSalePriceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PBSalePriceDate"]); 
  				m_FreeStr1=SysConvert.ToString(MasterTable.Rows[0]["FreeStr1"]); 
  				m_FreeNum1=SysConvert.ToString(MasterTable.Rows[0]["FreeNum1"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_ColorPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["ColorPrice"]); 
  				m_ZLPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["ZLPrice"]); 
  				m_TotalPriceUSB=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPriceUSB"]); 
  				m_ExchangeRate=SysConvert.ToDecimal(MasterTable.Rows[0]["ExchangeRate"]); 
  				m_TotalPriceRMB=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPriceRMB"]); 
  				m_CBPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["CBPrice"]); 
  				m_JGPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["JGPrice"]); 
  				m_TotalPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPrice"]); 
  				m_RFPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["RFPrice"]); 
  				m_ZXBJDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ZXBJDate"]); 
  				m_Shrinkage=SysConvert.ToDecimal(MasterTable.Rows[0]["Shrinkage"]); 
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
