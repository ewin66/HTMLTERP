using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_CompanyAccountʵ����
	/// ����:�˽ܿ�
	/// ��������:2009-4-16
	/// </summary>
	public sealed class CompanyAccount : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CompanyAccount()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public CompanyAccount(IDBTransAccess p_SqlCmd)
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
  
  		private int m_CompanyID = 0; 
  		public int CompanyID 
  		{ 
  			get 
  			{ 
  				return m_CompanyID ; 
  			}  
  			set 
  			{ 
  				m_CompanyID = value ; 
  			}  
  		} 
  
  		private string m_Bank = string.Empty ; 
  		public string Bank 
  		{ 
  			get 
  			{ 
  				return m_Bank ; 
  			}  
  			set 
  			{ 
  				m_Bank = value ; 
  			}  
  		} 
  
  		private string m_Account = string.Empty ; 
  		public string Account 
  		{ 
  			get 
  			{ 
  				return m_Account ; 
  			}  
  			set 
  			{ 
  				m_Account = value ; 
  			}  
  		} 
  
  		private string m_SwifCode = string.Empty ; 
  		public string SwifCode 
  		{ 
  			get 
  			{ 
  				return m_SwifCode ; 
  			}  
  			set 
  			{ 
  				m_SwifCode = value ; 
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
 
		#endregion
		
		/// <summary>
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_CompanyAccount WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_CompanyAccount WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CompanyID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyID"]); 
  				m_Bank=SysConvert.ToString(MasterTable.Rows[0]["Bank"]); 
  				m_Account=SysConvert.ToString(MasterTable.Rows[0]["Account"]); 
  				m_SwifCode=SysConvert.ToString(MasterTable.Rows[0]["SwifCode"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
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
