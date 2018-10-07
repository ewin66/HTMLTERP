using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_CompanyType实体类
	/// 作者:刘德苏
	/// 创建日期:2012/4/20
	/// </summary>
	public sealed class CompanyType : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CompanyType()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CompanyType(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Enum_CompanyType";
		 
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
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
  			}  
  		} 
  
  		private string m_Name = string.Empty ; 
  		public string Name 
  		{ 
  			get 
  			{ 
  				return m_Name ; 
  			}  
  			set 
  			{ 
  				m_Name = value ; 
  			}  
  		} 
  
  		private string m_OrganizeCode = string.Empty ; 
  		public string OrganizeCode 
  		{ 
  			get 
  			{ 
  				return m_OrganizeCode ; 
  			}  
  			set 
  			{ 
  				m_OrganizeCode = value ; 
  			}  
  		} 
  
  		private string m_Tel = string.Empty ; 
  		public string Tel 
  		{ 
  			get 
  			{ 
  				return m_Tel ; 
  			}  
  			set 
  			{ 
  				m_Tel = value ; 
  			}  
  		} 
  
  		private string m_Fax = string.Empty ; 
  		public string Fax 
  		{ 
  			get 
  			{ 
  				return m_Fax ; 
  			}  
  			set 
  			{ 
  				m_Fax = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
  			}  
  		} 
  
  		private string m_ZipCode = string.Empty ; 
  		public string ZipCode 
  		{ 
  			get 
  			{ 
  				return m_ZipCode ; 
  			}  
  			set 
  			{ 
  				m_ZipCode = value ; 
  			}  
  		} 
  
  		private string m_TaxCode = string.Empty ; 
  		public string TaxCode 
  		{ 
  			get 
  			{ 
  				return m_TaxCode ; 
  			}  
  			set 
  			{ 
  				m_TaxCode = value ; 
  			}  
  		} 
  
  		private string m_Bank = string.Empty ; 
  		public string Bank 
  		{ 
  			get 
  			{ 
  				return m_Bank ; 
  			}  
  			set 
  			{ 
  				m_Bank = value ; 
  			}  
  		} 
  
  		private string m_Account = string.Empty ; 
  		public string Account 
  		{ 
  			get 
  			{ 
  				return m_Account ; 
  			}  
  			set 
  			{ 
  				m_Account = value ; 
  			}  
  		} 
  
  		private string m_BasedCurrency = string.Empty ; 
  		public string BasedCurrency 
  		{ 
  			get 
  			{ 
  				return m_BasedCurrency ; 
  			}  
  			set 
  			{ 
  				m_BasedCurrency = value ; 
  			}  
  		} 
  
  		private string m_DealCurrency = string.Empty ; 
  		public string DealCurrency 
  		{ 
  			get 
  			{ 
  				return m_DealCurrency ; 
  			}  
  			set 
  			{ 
  				m_DealCurrency = value ; 
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
  
  		private int m_DelFlag = 0; 
  		public int DelFlag 
  		{ 
  			get 
  			{ 
  				return m_DelFlag ; 
  			}  
  			set 
  			{ 
  				m_DelFlag = value ; 
  			}  
  		} 
  
  		private string m_EnName = string.Empty ; 
  		public string EnName 
  		{ 
  			get 
  			{ 
  				return m_EnName ; 
  			}  
  			set 
  			{ 
  				m_EnName = value ; 
  			}  
  		} 
  
  		private string m_EnAddress = string.Empty ; 
  		public string EnAddress 
  		{ 
  			get 
  			{ 
  				return m_EnAddress ; 
  			}  
  			set 
  			{ 
  				m_EnAddress = value ; 
  			}  
  		} 
  
  		private string m_AllName = string.Empty ; 
  		public string AllName 
  		{ 
  			get 
  			{ 
  				return m_AllName ; 
  			}  
  			set 
  			{ 
  				m_AllName = value ; 
  			}  
  		} 
  
  		private byte[] m_Picture = new byte[1]; 
  		public byte[] Picture 
  		{ 
  			get 
  			{ 
  				return m_Picture ; 
  			}  
  			set 
  			{ 
  				m_Picture = value ; 
  			}  
  		} 
  
  		private string m_AddNo = string.Empty ; 
  		public string AddNo 
  		{ 
  			get 
  			{ 
  				return m_AddNo ; 
  			}  
  			set 
  			{ 
  				m_AddNo = value ; 
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
            string Sql="SELECT * FROM Enum_CompanyType WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_CompanyType WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_OrganizeCode=SysConvert.ToString(MasterTable.Rows[0]["OrganizeCode"]); 
  				m_Tel=SysConvert.ToString(MasterTable.Rows[0]["Tel"]); 
  				m_Fax=SysConvert.ToString(MasterTable.Rows[0]["Fax"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_ZipCode=SysConvert.ToString(MasterTable.Rows[0]["ZipCode"]); 
  				m_TaxCode=SysConvert.ToString(MasterTable.Rows[0]["TaxCode"]); 
  				m_Bank=SysConvert.ToString(MasterTable.Rows[0]["Bank"]); 
  				m_Account=SysConvert.ToString(MasterTable.Rows[0]["Account"]); 
  				m_BasedCurrency=SysConvert.ToString(MasterTable.Rows[0]["BasedCurrency"]); 
  				m_DealCurrency=SysConvert.ToString(MasterTable.Rows[0]["DealCurrency"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_EnName=SysConvert.ToString(MasterTable.Rows[0]["EnName"]); 
  				m_EnAddress=SysConvert.ToString(MasterTable.Rows[0]["EnAddress"]); 
  				m_AllName=SysConvert.ToString(MasterTable.Rows[0]["AllName"]); 
  				if(MasterTable.Rows[0]["Picture"]!=DBNull.Value) 
  				{ 
  				 	m_Picture=(byte[])(MasterTable.Rows[0]["Picture"]); 
  				} 
  				m_AddNo=SysConvert.ToString(MasterTable.Rows[0]["AddNo"]); 
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
