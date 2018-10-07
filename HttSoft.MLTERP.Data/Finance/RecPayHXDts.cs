using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_RecPayHXDts实体类
	/// 作者:周富春
	/// 创建日期:2012-5-22
	/// </summary>
	public sealed class RecPayHXDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public RecPayHXDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public RecPayHXDts(IDBTransAccess p_SqlCmd)
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
  
  		private string m_HXOPID = string.Empty ; 
  		public string HXOPID 
  		{ 
  			get 
  			{ 
  				return m_HXOPID ; 
  			}  
  			set 
  			{ 
  				m_HXOPID = value ; 
  			}  
  		} 
  
  		private string m_HXOPName = string.Empty ; 
  		public string HXOPName 
  		{ 
  			get 
  			{ 
  				return m_HXOPName ; 
  			}  
  			set 
  			{ 
  				m_HXOPName = value ; 
  			}  
  		} 
  
  		private int m_InvoiceOperationID = 0; 
  		public int InvoiceOperationID 
  		{ 
  			get 
  			{ 
  				return m_InvoiceOperationID ; 
  			}  
  			set 
  			{ 
  				m_InvoiceOperationID = value ; 
  			}  
  		} 
  
  		private string m_InvoiceNo = string.Empty ; 
  		public string InvoiceNo 
  		{ 
  			get 
  			{ 
  				return m_InvoiceNo ; 
  			}  
  			set 
  			{ 
  				m_InvoiceNo = value ; 
  			}  
  		} 
  
  		private DateTime m_HXDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime HXDate 
  		{ 
  			get 
  			{ 
  				return m_HXDate ; 
  			}  
  			set 
  			{ 
  				m_HXDate = value ; 
  			}  
  		} 
  
  		private decimal m_HXAmount = 0; 
  		public decimal HXAmount 
  		{ 
  			get 
  			{ 
  				return m_HXAmount ; 
  			}  
  			set 
  			{ 
  				m_HXAmount = value ; 
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
            string Sql="SELECT * FROM Finance_RecPayHXDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_RecPayHXDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_HXOPID=SysConvert.ToString(MasterTable.Rows[0]["HXOPID"]); 
  				m_HXOPName=SysConvert.ToString(MasterTable.Rows[0]["HXOPName"]); 
  				m_InvoiceOperationID=SysConvert.ToInt32(MasterTable.Rows[0]["InvoiceOperationID"]); 
  				m_InvoiceNo=SysConvert.ToString(MasterTable.Rows[0]["InvoiceNo"]); 
  				m_HXDate=SysConvert.ToDateTime(MasterTable.Rows[0]["HXDate"]); 
  				m_HXAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["HXAmount"]); 
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
