using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Finance_Payʵ����
	/// ����:�¼Ӻ�
	/// ��������:2012-4-17
	/// </summary>
	public sealed class Pay : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Pay()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public Pay(IDBTransAccess p_SqlCmd)
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
  
  		private string m_PayUnitId = string.Empty ; 
  		public string PayUnitId 
  		{ 
  			get 
  			{ 
  				return m_PayUnitId ; 
  			}  
  			set 
  			{ 
  				m_PayUnitId = value ; 
  			}  
  		} 
  
  		private decimal m_PayAmount = 0; 
  		public decimal PayAmount 
  		{ 
  			get 
  			{ 
  				return m_PayAmount ; 
  			}  
  			set 
  			{ 
  				m_PayAmount = value ; 
  			}  
  		} 
  
  		private string m_MoneyType = string.Empty ; 
  		public string MoneyType 
  		{ 
  			get 
  			{ 
  				return m_MoneyType ; 
  			}  
  			set 
  			{ 
  				m_MoneyType = value ; 
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
  
  		private DateTime m_PayDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PayDate 
  		{ 
  			get 
  			{ 
  				return m_PayDate ; 
  			}  
  			set 
  			{ 
  				m_PayDate = value ; 
  			}  
  		} 
  
  		private string m_PayBank = string.Empty ; 
  		public string PayBank 
  		{ 
  			get 
  			{ 
  				return m_PayBank ; 
  			}  
  			set 
  			{ 
  				m_PayBank = value ; 
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
            string Sql="SELECT * FROM Finance_Pay WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_Pay WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_PayUnitId=SysConvert.ToString(MasterTable.Rows[0]["PayUnitId"]); 
  				m_PayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PayAmount"]); 
  				m_MoneyType=SysConvert.ToString(MasterTable.Rows[0]["MoneyType"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_Handler=SysConvert.ToString(MasterTable.Rows[0]["Handler"]); 
  				m_PayDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PayDate"]); 
  				m_PayBank=SysConvert.ToString(MasterTable.Rows[0]["PayBank"]); 
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
