using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemCodeFacDts实体类
	/// 作者:章文强
	/// 创建日期:2014/11/21
	/// </summary>
	public sealed class ItemCodeFacDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemCodeFacDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemCodeFacDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_ItemCodeFacDts";
		 
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
  
  		private string m_FacItemCode = string.Empty ; 
  		public string FacItemCode 
  		{ 
  			get 
  			{ 
  				return m_FacItemCode ; 
  			}  
  			set 
  			{ 
  				m_FacItemCode = value ; 
  			}  
  		} 
  
  		private string m_FactoryID = string.Empty ; 
  		public string FactoryID 
  		{ 
  			get 
  			{ 
  				return m_FactoryID ; 
  			}  
  			set 
  			{ 
  				m_FactoryID = value ; 
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
  
  		private decimal m_FacPrice = 0; 
  		public decimal FacPrice 
  		{ 
  			get 
  			{ 
  				return m_FacPrice ; 
  			}  
  			set 
  			{ 
  				m_FacPrice = value ; 
  			}  
  		} 
  
  		private DateTime m_FacPriceLimitDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FacPriceLimitDate 
  		{ 
  			get 
  			{ 
  				return m_FacPriceLimitDate ; 
  			}  
  			set 
  			{ 
  				m_FacPriceLimitDate = value ; 
  			}  
  		} 
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private string m_VendorID = string.Empty ; 
  		public string VendorID 
  		{ 
  			get 
  			{ 
  				return m_VendorID ; 
  			}  
  			set 
  			{ 
  				m_VendorID = value ; 
  			}  
  		} 
  
  		private string m_Price = string.Empty ; 
  		public string Price 
  		{ 
  			get 
  			{ 
  				return m_Price ; 
  			}  
  			set 
  			{ 
  				m_Price = value ; 
  			}  
  		} 
  
  		private string m_SH = string.Empty ; 
  		public string SH 
  		{ 
  			get 
  			{ 
  				return m_SH ; 
  			}  
  			set 
  			{ 
  				m_SH = value ; 
  			}  
  		} 
  
  		private string m_ReqDate = string.Empty ; 
  		public string ReqDate 
  		{ 
  			get 
  			{ 
  				return m_ReqDate ; 
  			}  
  			set 
  			{ 
  				m_ReqDate = value ; 
  			}  
  		} 
  
  		private string m_MinQty = string.Empty ; 
  		public string MinQty 
  		{ 
  			get 
  			{ 
  				return m_MinQty ; 
  			}  
  			set 
  			{ 
  				m_MinQty = value ; 
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
            string Sql="SELECT * FROM Data_ItemCodeFacDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemCodeFacDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FacItemCode=SysConvert.ToString(MasterTable.Rows[0]["FacItemCode"]); 
  				m_FactoryID=SysConvert.ToString(MasterTable.Rows[0]["FactoryID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_FacPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["FacPrice"]); 
  				m_FacPriceLimitDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FacPriceLimitDate"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_Price=SysConvert.ToString(MasterTable.Rows[0]["Price"]); 
  				m_SH=SysConvert.ToString(MasterTable.Rows[0]["SH"]); 
  				m_ReqDate=SysConvert.ToString(MasterTable.Rows[0]["ReqDate"]); 
  				m_MinQty=SysConvert.ToString(MasterTable.Rows[0]["MinQty"]); 
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
