using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_Receiving实体类
	/// 作者:陈加海
	/// 创建日期:2012-4-17
	/// </summary>
	public sealed class Receiving : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Receiving()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Receiving(IDBTransAccess p_SqlCmd)
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
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private string m_ReceiveUnit = string.Empty ; 
  		public string ReceiveUnit 
  		{ 
  			get 
  			{ 
  				return m_ReceiveUnit ; 
  			}  
  			set 
  			{ 
  				m_ReceiveUnit = value ; 
  			}  
  		} 
  
  		private decimal m_ReceiveAmount = 0; 
  		public decimal ReceiveAmount 
  		{ 
  			get 
  			{ 
  				return m_ReceiveAmount ; 
  			}  
  			set 
  			{ 
  				m_ReceiveAmount = value ; 
  			}  
  		} 
  
  		private string m_Currency = string.Empty ; 
  		public string Currency 
  		{ 
  			get 
  			{ 
  				return m_Currency ; 
  			}  
  			set 
  			{ 
  				m_Currency = value ; 
  			}  
  		} 
  
  		private decimal m_Rate = 0; 
  		public decimal Rate 
  		{ 
  			get 
  			{ 
  				return m_Rate ; 
  			}  
  			set 
  			{ 
  				m_Rate = value ; 
  			}  
  		} 
  
  		private string m_Handler = string.Empty ; 
  		public string Handler 
  		{ 
  			get 
  			{ 
  				return m_Handler ; 
  			}  
  			set 
  			{ 
  				m_Handler = value ; 
  			}  
  		} 
  
  		private DateTime m_ReceiveDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReceiveDate 
  		{ 
  			get 
  			{ 
  				return m_ReceiveDate ; 
  			}  
  			set 
  			{ 
  				m_ReceiveDate = value ; 
  			}  
  		} 
  
  		private string m_ReceiveBank = string.Empty ; 
  		public string ReceiveBank 
  		{ 
  			get 
  			{ 
  				return m_ReceiveBank ; 
  			}  
  			set 
  			{ 
  				m_ReceiveBank = value ; 
  			}  
  		} 
  
  		private decimal m_CutPayment = 0; 
  		public decimal CutPayment 
  		{ 
  			get 
  			{ 
  				return m_CutPayment ; 
  			}  
  			set 
  			{ 
  				m_CutPayment = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Finance_Receiving WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_Receiving WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_ReceiveUnit=SysConvert.ToString(MasterTable.Rows[0]["ReceiveUnit"]); 
  				m_ReceiveAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ReceiveAmount"]); 
  				m_Currency=SysConvert.ToString(MasterTable.Rows[0]["Currency"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_Handler=SysConvert.ToString(MasterTable.Rows[0]["Handler"]); 
  				m_ReceiveDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReceiveDate"]); 
  				m_ReceiveBank=SysConvert.ToString(MasterTable.Rows[0]["ReceiveBank"]); 
  				m_CutPayment=SysConvert.ToDecimal(MasterTable.Rows[0]["CutPayment"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
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
