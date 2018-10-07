using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_VDsignerʵ����
	/// ����:�¼Ӻ�
	/// ��������:2012-4-19
	/// </summary>
	public sealed class VDsigner : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public VDsigner()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public VDsigner(IDBTransAccess p_SqlCmd)
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
  
  		private string m_Older = string.Empty ; 
  		public string Older 
  		{ 
  			get 
  			{ 
  				return m_Older ; 
  			}  
  			set 
  			{ 
  				m_Older = value ; 
  			}  
  		} 
  
  		private string m_Tel = string.Empty ; 
  		public string Tel 
  		{ 
  			get 
  			{ 
  				return m_Tel ; 
  			}  
  			set 
  			{ 
  				m_Tel = value ; 
  			}  
  		} 
  
  		private string m_Mobile = string.Empty ; 
  		public string Mobile 
  		{ 
  			get 
  			{ 
  				return m_Mobile ; 
  			}  
  			set 
  			{ 
  				m_Mobile = value ; 
  			}  
  		} 
  
  		private string m_CompanyName = string.Empty ; 
  		public string CompanyName 
  		{ 
  			get 
  			{ 
  				return m_CompanyName ; 
  			}  
  			set 
  			{ 
  				m_CompanyName = value ; 
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
  
  		private string m_HHis = string.Empty ; 
  		public string HHis 
  		{ 
  			get 
  			{ 
  				return m_HHis ; 
  			}  
  			set 
  			{ 
  				m_HHis = value ; 
  			}  
  		} 
  
  		private int m_SendMSGFlag = 0; 
  		public int SendMSGFlag 
  		{ 
  			get 
  			{ 
  				return m_SendMSGFlag ; 
  			}  
  			set 
  			{ 
  				m_SendMSGFlag = value ; 
  			}  
  		} 
  
  		private int m_UseableFlag = 0; 
  		public int UseableFlag 
  		{ 
  			get 
  			{ 
  				return m_UseableFlag ; 
  			}  
  			set 
  			{ 
  				m_UseableFlag = value ; 
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
            string Sql="SELECT * FROM Data_VDsigner WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_VDsigner WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Older=SysConvert.ToString(MasterTable.Rows[0]["Older"]); 
  				m_Tel=SysConvert.ToString(MasterTable.Rows[0]["Tel"]); 
  				m_Mobile=SysConvert.ToString(MasterTable.Rows[0]["Mobile"]); 
  				m_CompanyName=SysConvert.ToString(MasterTable.Rows[0]["CompanyName"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_HHis=SysConvert.ToString(MasterTable.Rows[0]["HHis"]); 
  				m_SendMSGFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SendMSGFlag"]); 
  				m_UseableFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UseableFlag"]); 
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
