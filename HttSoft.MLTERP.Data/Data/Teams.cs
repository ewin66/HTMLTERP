using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_Teamsʵ����
	/// ����:�˽ܿ�
	/// ��������:2009-9-11
	/// </summary>
	public sealed class Teams : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Teams()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public Teams(IDBTransAccess p_SqlCmd)
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
  
  		private string m_BaseShop = string.Empty ; 
  		public string BaseShop 
  		{ 
  			get 
  			{ 
  				return m_BaseShop ; 
  			}  
  			set 
  			{ 
  				m_BaseShop = value ; 
  			}  
  		} 
  
  		private string m_MakeOPID = string.Empty ; 
  		public string MakeOPID 
  		{ 
  			get 
  			{ 
  				return m_MakeOPID ; 
  			}  
  			set 
  			{ 
  				m_MakeOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_MakeDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MakeDate 
  		{ 
  			get 
  			{ 
  				return m_MakeDate ; 
  			}  
  			set 
  			{ 
  				m_MakeDate = value ; 
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
  
  		private DateTime m_AddTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AddTime 
  		{ 
  			get 
  			{ 
  				return m_AddTime ; 
  			}  
  			set 
  			{ 
  				m_AddTime = value ; 
  			}  
  		} 
  
  		private string m_AddOPID = string.Empty ; 
  		public string AddOPID 
  		{ 
  			get 
  			{ 
  				return m_AddOPID ; 
  			}  
  			set 
  			{ 
  				m_AddOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_UpdTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UpdTime 
  		{ 
  			get 
  			{ 
  				return m_UpdTime ; 
  			}  
  			set 
  			{ 
  				m_UpdTime = value ; 
  			}  
  		} 
  
  		private string m_UpdOPID = string.Empty ; 
  		public string UpdOPID 
  		{ 
  			get 
  			{ 
  				return m_UpdOPID ; 
  			}  
  			set 
  			{ 
  				m_UpdOPID = value ; 
  			}  
  		} 
  
  		private int m_SubmitFlag = 0; 
  		public int SubmitFlag 
  		{ 
  			get 
  			{ 
  				return m_SubmitFlag ; 
  			}  
  			set 
  			{ 
  				m_SubmitFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_SubmitTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SubmitTime 
  		{ 
  			get 
  			{ 
  				return m_SubmitTime ; 
  			}  
  			set 
  			{ 
  				m_SubmitTime = value ; 
  			}  
  		} 
  
  		private string m_SubmitOPID = string.Empty ; 
  		public string SubmitOPID 
  		{ 
  			get 
  			{ 
  				return m_SubmitOPID ; 
  			}  
  			set 
  			{ 
  				m_SubmitOPID = value ; 
  			}  
  		} 
  
  		private int m_AuditFlag = 0; 
  		public int AuditFlag 
  		{ 
  			get 
  			{ 
  				return m_AuditFlag ; 
  			}  
  			set 
  			{ 
  				m_AuditFlag = value ; 
  			}  
  		} 
  
  		private string m_AuditOPID = string.Empty ; 
  		public string AuditOPID 
  		{ 
  			get 
  			{ 
  				return m_AuditOPID ; 
  			}  
  			set 
  			{ 
  				m_AuditOPID = value ; 
  			}  
  		} 
  
  		private int m_ValidType = 0; 
  		public int ValidType 
  		{ 
  			get 
  			{ 
  				return m_ValidType ; 
  			}  
  			set 
  			{ 
  				m_ValidType = value ; 
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
            string Sql="SELECT * FROM Data_Teams WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_Teams WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
                //��ѯ������¼
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_BaseShop=SysConvert.ToString(MasterTable.Rows[0]["BaseShop"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_AddTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AddTime"]); 
  				m_AddOPID=SysConvert.ToString(MasterTable.Rows[0]["AddOPID"]); 
  				m_UpdTime=SysConvert.ToDateTime(MasterTable.Rows[0]["UpdTime"]); 
  				m_UpdOPID=SysConvert.ToString(MasterTable.Rows[0]["UpdOPID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_SubmitTime=SysConvert.ToDateTime(MasterTable.Rows[0]["SubmitTime"]); 
  				m_SubmitOPID=SysConvert.ToString(MasterTable.Rows[0]["SubmitOPID"]); 
  				m_AuditFlag=SysConvert.ToInt32(MasterTable.Rows[0]["AuditFlag"]); 
  				m_AuditOPID=SysConvert.ToString(MasterTable.Rows[0]["AuditOPID"]); 
  				m_ValidType=SysConvert.ToInt32(MasterTable.Rows[0]["ValidType"]); 
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