using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_SaleGroupʵ����
	/// ����:�¼Ӻ�
	/// ��������:2011-11-5
	/// </summary>
	public sealed class Currency : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Currency()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public Currency(IDBTransAccess p_SqlCmd)
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
  
  		private string m_Name = string.Empty ; 
  		public string Name 
  		{ 
  			get 
  			{ 
  				return m_Name ; 
  			}  
  			set 
  			{ 
  				m_Name = value ; 
  			}  
  		} 
  
  		private string m_CName = string.Empty ; 
  		public string CName 
  		{ 
  			get 
  			{ 
  				return m_CName ; 
  			}  
  			set 
  			{ 
  				m_CName = value ; 
  			}  
  		} 
  
  		private string m_Symbol = string.Empty ; 
  		public string Symbol 
  		{ 
  			get 
  			{ 
  				return m_Symbol ; 
  			}  
  			set 
  			{ 
  				m_Symbol = value ; 
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
  
  		private DateTime m_RDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime RDate 
  		{ 
  			get 
  			{ 
  				return m_RDate ; 
  			}  
  			set 
  			{ 
  				m_RDate = value ; 
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
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
  			}  
  		} 
  
  		private string m_OPName = string.Empty ; 
  		public string OPName 
  		{ 
  			get 
  			{ 
  				return m_OPName ; 
  			}  
  			set 
  			{ 
  				m_OPName = value ; 
  			}  
  		} 
  
  		private string m_BaseName = string.Empty ; 
  		public string BaseName 
  		{ 
  			get 
  			{ 
  				return m_BaseName ; 
  			}  
  			set 
  			{ 
  				m_BaseName = value ; 
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
            string Sql="SELECT * FROM Data_Currency WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_Currency WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_CName=SysConvert.ToString(MasterTable.Rows[0]["CName"]); 
  				m_Symbol=SysConvert.ToString(MasterTable.Rows[0]["Symbol"]); 
  				m_Rate=SysConvert.ToDecimal(MasterTable.Rows[0]["Rate"]); 
  				m_RDate=SysConvert.ToDateTime(MasterTable.Rows[0]["RDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_OPName=SysConvert.ToString(MasterTable.Rows[0]["OPName"]); 
  				m_BaseName=SysConvert.ToString(MasterTable.Rows[0]["BaseName"]); 
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
