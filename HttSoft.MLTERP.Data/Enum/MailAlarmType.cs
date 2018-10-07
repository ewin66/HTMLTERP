using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Enum_MailAlarmTypeʵ����
	/// ����:�˽ܿ�
	/// ��������:2009-9-2
	/// </summary>
	public sealed class MailAlarmType : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public MailAlarmType()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public MailAlarmType(IDBTransAccess p_SqlCmd)
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
  
  		private string m_MailFileName = string.Empty ; 
  		public string MailFileName 
  		{ 
  			get 
  			{ 
  				return m_MailFileName ; 
  			}  
  			set 
  			{ 
  				m_MailFileName = value ; 
  			}  
  		} 
  
  		private string m_MailTitle = string.Empty ; 
  		public string MailTitle 
  		{ 
  			get 
  			{ 
  				return m_MailTitle ; 
  			}  
  			set 
  			{ 
  				m_MailTitle = value ; 
  			}  
  		} 
  
  		private DateTime m_MailExcuteTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MailExcuteTime 
  		{ 
  			get 
  			{ 
  				return m_MailExcuteTime ; 
  			}  
  			set 
  			{ 
  				m_MailExcuteTime = value ; 
  			}  
  		} 
  
  		private DateTime m_MailExcuteTime2 = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MailExcuteTime2 
  		{ 
  			get 
  			{ 
  				return m_MailExcuteTime2 ; 
  			}  
  			set 
  			{ 
  				m_MailExcuteTime2 = value ; 
  			}  
  		} 
  
  		private DateTime m_MailExcuteTime3 = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MailExcuteTime3 
  		{ 
  			get 
  			{ 
  				return m_MailExcuteTime3 ; 
  			}  
  			set 
  			{ 
  				m_MailExcuteTime3 = value ; 
  			}  
  		} 
  
  		private string m_AlarmCondition = string.Empty ; 
  		public string AlarmCondition 
  		{ 
  			get 
  			{ 
  				return m_AlarmCondition ; 
  			}  
  			set 
  			{ 
  				m_AlarmCondition = value ; 
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
 
		#endregion
		
		/// <summary>
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Enum_MailAlarmType WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_MailAlarmType WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_MailFileName=SysConvert.ToString(MasterTable.Rows[0]["MailFileName"]); 
  				m_MailTitle=SysConvert.ToString(MasterTable.Rows[0]["MailTitle"]); 
  				m_MailExcuteTime=SysConvert.ToDateTime(MasterTable.Rows[0]["MailExcuteTime"]); 
  				m_MailExcuteTime2=SysConvert.ToDateTime(MasterTable.Rows[0]["MailExcuteTime2"]); 
  				m_MailExcuteTime3=SysConvert.ToDateTime(MasterTable.Rows[0]["MailExcuteTime3"]); 
  				m_AlarmCondition=SysConvert.ToString(MasterTable.Rows[0]["AlarmCondition"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
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
