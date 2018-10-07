using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Finance_CapPlanDtsʵ����
	/// ����:����ǿ
	/// ��������:2012/9/4
	/// </summary>
	public sealed class CapPlanDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CapPlanDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CapPlanDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
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
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Finance_CapPlanDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_CapPlanDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// �������SQL����ѯ������Ը�ֵ
        /// </summary>
        /// <param name="p_Sql">SQL���</param>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
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
                //��ѯ�����¼
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
