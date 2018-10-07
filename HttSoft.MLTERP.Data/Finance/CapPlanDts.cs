using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_CapPlanDts实体类
	/// 作者:章文强
	/// 创建日期:2012/9/4
	/// </summary>
	public sealed class CapPlanDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CapPlanDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CapPlanDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_CapPlanDts";
		 
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
  
  		private decimal m_InvoiceAmount = 0; 
  		public decimal InvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_InvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_InvoiceAmount = value ; 
  			}  
  		} 
  
  		private decimal m_NoInvoiceAmount = 0; 
  		public decimal NoInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_NoInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_NoInvoiceAmount = value ; 
  			}  
  		} 
  
  		private decimal m_TotalNeedPay = 0; 
  		public decimal TotalNeedPay 
  		{ 
  			get 
  			{ 
  				return m_TotalNeedPay ; 
  			}  
  			set 
  			{ 
  				m_TotalNeedPay = value ; 
  			}  
  		} 
  
  		private decimal m_PlanInvoiceAmount = 0; 
  		public decimal PlanInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_PlanInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_PlanInvoiceAmount = value ; 
  			}  
  		} 
  
  		private decimal m_PlanRecAmount = 0; 
  		public decimal PlanRecAmount 
  		{ 
  			get 
  			{ 
  				return m_PlanRecAmount ; 
  			}  
  			set 
  			{ 
  				m_PlanRecAmount = value ; 
  			}  
  		} 
  
  		private decimal m_PlanLeaveAmount = 0; 
  		public decimal PlanLeaveAmount 
  		{ 
  			get 
  			{ 
  				return m_PlanLeaveAmount ; 
  			}  
  			set 
  			{ 
  				m_PlanLeaveAmount = value ; 
  			}  
  		} 
  
  		private decimal m_PlanSaleAmount = 0; 
  		public decimal PlanSaleAmount 
  		{ 
  			get 
  			{ 
  				return m_PlanSaleAmount ; 
  			}  
  			set 
  			{ 
  				m_PlanSaleAmount = value ; 
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
  
  		private decimal m_NoInvoiceQty = 0; 
  		public decimal NoInvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_NoInvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_NoInvoiceQty = value ; 
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
            string Sql="SELECT * FROM Finance_CapPlanDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_CapPlanDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_InvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["InvoiceAmount"]); 
  				m_NoInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["NoInvoiceAmount"]); 
  				m_TotalNeedPay=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalNeedPay"]); 
  				m_PlanInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PlanInvoiceAmount"]); 
  				m_PlanRecAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PlanRecAmount"]); 
  				m_PlanLeaveAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PlanLeaveAmount"]); 
  				m_PlanSaleAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PlanSaleAmount"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_NoInvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["NoInvoiceQty"]); 
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
