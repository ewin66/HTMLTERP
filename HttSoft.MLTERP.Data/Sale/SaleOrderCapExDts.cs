using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Sale_SaleOrderCapExDtsʵ����
	/// ����:����ǿ
	/// ��������:2012/7/30
	/// </summary>
	public sealed class SaleOrderCapExDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrderCapExDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public SaleOrderCapExDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "Sale_SaleOrderCapExDts";
		 
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
  
  		private string m_ExCapName = string.Empty ; 
  		public string ExCapName 
  		{ 
  			get 
  			{ 
  				return m_ExCapName ; 
  			}  
  			set 
  			{ 
  				m_ExCapName = value ; 
  			}  
  		} 
  
  		private string m_ExItemCode = string.Empty ; 
  		public string ExItemCode 
  		{ 
  			get 
  			{ 
  				return m_ExItemCode ; 
  			}  
  			set 
  			{ 
  				m_ExItemCode = value ; 
  			}  
  		} 
  
  		private int m_ExPayStepTypeID = 0; 
  		public int ExPayStepTypeID 
  		{ 
  			get 
  			{ 
  				return m_ExPayStepTypeID ; 
  			}  
  			set 
  			{ 
  				m_ExPayStepTypeID = value ; 
  			}  
  		} 
  
  		private decimal m_ExPayPer = 0; 
  		public decimal ExPayPer 
  		{ 
  			get 
  			{ 
  				return m_ExPayPer ; 
  			}  
  			set 
  			{ 
  				m_ExPayPer = value ; 
  			}  
  		} 
  
  		private decimal m_ExPayAmount = 0; 
  		public decimal ExPayAmount 
  		{ 
  			get 
  			{ 
  				return m_ExPayAmount ; 
  			}  
  			set 
  			{ 
  				m_ExPayAmount = value ; 
  			}  
  		} 
  
  		private DateTime m_ExPayLimitDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ExPayLimitDate 
  		{ 
  			get 
  			{ 
  				return m_ExPayLimitDate ; 
  			}  
  			set 
  			{ 
  				m_ExPayLimitDate = value ; 
  			}  
  		} 
  
  		private string m_ExRemark = string.Empty ; 
  		public string ExRemark 
  		{ 
  			get 
  			{ 
  				return m_ExRemark ; 
  			}  
  			set 
  			{ 
  				m_ExRemark = value ; 
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
            string Sql="SELECT * FROM Sale_SaleOrderCapExDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrderCapExDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ExCapName=SysConvert.ToString(MasterTable.Rows[0]["ExCapName"]); 
  				m_ExItemCode=SysConvert.ToString(MasterTable.Rows[0]["ExItemCode"]); 
  				m_ExPayStepTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ExPayStepTypeID"]); 
  				m_ExPayPer=SysConvert.ToDecimal(MasterTable.Rows[0]["ExPayPer"]); 
  				m_ExPayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ExPayAmount"]); 
  				m_ExPayLimitDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ExPayLimitDate"]); 
  				m_ExRemark=SysConvert.ToString(MasterTable.Rows[0]["ExRemark"]); 
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
