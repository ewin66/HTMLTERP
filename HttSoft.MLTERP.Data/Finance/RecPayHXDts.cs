using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Finance_RecPayHXDtsʵ����
	/// ����:�ܸ���
	/// ��������:2012-5-22
	/// </summary>
	public sealed class RecPayHXDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public RecPayHXDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public RecPayHXDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Finance_RecPayHXDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_RecPayHXDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
