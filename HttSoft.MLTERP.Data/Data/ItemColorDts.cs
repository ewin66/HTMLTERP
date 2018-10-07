using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemColorDts实体类
	/// 作者:陈加海
	/// 创建日期:2012-4-18
	/// </summary>
	public sealed class ItemColorDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemColorDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemColorDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
        private string m_VendorID = string.Empty;
        public string VendorID
        {
            get
            {
                return m_VendorID;
            }
            set
            {
                m_VendorID = value;
            }
        }

        private decimal m_DyePrice = 0;
        public decimal DyePrice
        {
            get
            {
                return m_DyePrice;
            }
            set
            {
                m_DyePrice = value;
            }
        }

        private decimal m_RS = 0;
        public decimal RS
        {
            get
            {
                return m_RS;
            }
            set
            {
                m_RS = value;
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
            string Sql="SELECT * FROM Data_ItemColorDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemColorDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
                m_VendorID = SysConvert.ToString(MasterTable.Rows[0]["VendorID"]);
                m_DyePrice = SysConvert.ToDecimal(MasterTable.Rows[0]["DyePrice"]);
                m_RS = SysConvert.ToDecimal(MasterTable.Rows[0]["RS"]); 
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
