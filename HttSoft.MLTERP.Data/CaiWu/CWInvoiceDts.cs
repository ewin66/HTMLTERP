using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�CaiWu_CWInvoiceDtsʵ����
	/// ����:������
	/// ��������:2011-11-4
	/// </summary>
	public sealed class CWInvoiceDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CWInvoiceDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CWInvoiceDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
  
  		private string m_DZCode = string.Empty ; 
  		public string DZCode 
  		{ 
  			get 
  			{ 
  				return m_DZCode ; 
  			}  
  			set 
  			{ 
  				m_DZCode = value ; 
  			}  
  		} 
  
  		private DateTime m_DZDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DZDate 
  		{ 
  			get 
  			{ 
  				return m_DZDate ; 
  			}  
  			set 
  			{ 
  				m_DZDate = value ; 
  			}  
  		} 
  
  		private decimal m_DZQty = 0; 
  		public decimal DZQty 
  		{ 
  			get 
  			{ 
  				return m_DZQty ; 
  			}  
  			set 
  			{ 
  				m_DZQty = value ; 
  			}  
  		} 
  
  		private decimal m_DZAmount = 0; 
  		public decimal DZAmount 
  		{ 
  			get 
  			{ 
  				return m_DZAmount ; 
  			}  
  			set 
  			{ 
  				m_DZAmount = value ; 
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
            string Sql="SELECT * FROM CaiWu_CWInvoiceDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM CaiWu_CWInvoiceDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_DZCode=SysConvert.ToString(MasterTable.Rows[0]["DZCode"]); 
  				m_DZDate=SysConvert.ToDateTime(MasterTable.Rows[0]["DZDate"]); 
  				m_DZQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DZQty"]); 
  				m_DZAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DZAmount"]); 
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
