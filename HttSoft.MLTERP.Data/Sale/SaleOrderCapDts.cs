using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Sale_SaleOrderCapDtsʵ����
	/// ����:����ǿ
	/// ��������:2012/7/30
	/// </summary>
	public sealed class SaleOrderCapDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrderCapDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public SaleOrderCapDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Sale_SaleOrderCapDts";
		 
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
  
  		private string m_CapName = string.Empty ; 
  		public string CapName 
  		{ 
  			get 
  			{ 
  				return m_CapName ; 
  			}  
  			set 
  			{ 
  				m_CapName = value ; 
  			}  
  		} 
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private int m_PayStepTypeID = 0; 
  		public int PayStepTypeID 
  		{ 
  			get 
  			{ 
  				return m_PayStepTypeID ; 
  			}  
  			set 
  			{ 
  				m_PayStepTypeID = value ; 
  			}  
  		} 
  
  		private decimal m_PayPer = 0; 
  		public decimal PayPer 
  		{ 
  			get 
  			{ 
  				return m_PayPer ; 
  			}  
  			set 
  			{ 
  				m_PayPer = value ; 
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
  
  		private DateTime m_PayLimitDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PayLimitDate 
  		{ 
  			get 
  			{ 
  				return m_PayLimitDate ; 
  			}  
  			set 
  			{ 
  				m_PayLimitDate = value ; 
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
            string Sql="SELECT * FROM Sale_SaleOrderCapDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrderCapDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CapName=SysConvert.ToString(MasterTable.Rows[0]["CapName"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_PayStepTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["PayStepTypeID"]); 
  				m_PayPer=SysConvert.ToDecimal(MasterTable.Rows[0]["PayPer"]); 
  				m_PayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["PayAmount"]); 
  				m_PayLimitDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PayLimitDate"]); 
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
