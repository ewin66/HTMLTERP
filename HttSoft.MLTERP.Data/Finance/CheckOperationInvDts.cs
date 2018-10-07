using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Finance_CheckOperationInvDtsʵ����
	/// ����:����ǿ
	/// ��������:2012/7/30
	/// </summary>
	public sealed class CheckOperationInvDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckOperationInvDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CheckOperationInvDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Finance_CheckOperationInvDts";
		 
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
  
  		private string m_DInvoiceNo = string.Empty ; 
  		public string DInvoiceNo 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceNo ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceNo = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceQty = 0; 
  		public decimal DInvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceAmount = 0; 
  		public decimal DInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceAmount = value ; 
  			}  
  		} 
  
  		private DateTime m_DInvoiceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DInvoiceDate 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceDate ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceDate = value ; 
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
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Finance_CheckOperationInvDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_CheckOperationInvDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DInvoiceNo=SysConvert.ToString(MasterTable.Rows[0]["DInvoiceNo"]); 
  				m_DInvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceQty"]); 
  				m_DInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceAmount"]); 
  				m_DInvoiceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["DInvoiceDate"]); 
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
