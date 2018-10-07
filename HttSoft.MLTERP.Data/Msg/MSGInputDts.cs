using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�SMS_MSGInputDtsʵ����
	/// ����:����ǿ
	/// ��������:2012/7/11
	/// </summary>
	public sealed class MSGInputDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public MSGInputDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public MSGInputDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "SMS_MSGInputDts";
		 
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
  
  		private string m_Context = string.Empty ; 
  		public string Context 
  		{ 
  			get 
  			{ 
  				return m_Context ; 
  			}  
  			set 
  			{ 
  				m_Context = value ; 
  			}  
  		} 
  
  		private string m_TargetPhone = string.Empty ; 
  		public string TargetPhone 
  		{ 
  			get 
  			{ 
  				return m_TargetPhone ; 
  			}  
  			set 
  			{ 
  				m_TargetPhone = value ; 
  			}  
  		} 
  
  		private string m_TaregtInfo = string.Empty ; 
  		public string TaregtInfo 
  		{ 
  			get 
  			{ 
  				return m_TaregtInfo ; 
  			}  
  			set 
  			{ 
  				m_TaregtInfo = value ; 
  			}  
  		} 
  
  		private string m_TargetDesc = string.Empty ; 
  		public string TargetDesc 
  		{ 
  			get 
  			{ 
  				return m_TargetDesc ; 
  			}  
  			set 
  			{ 
  				m_TargetDesc = value ; 
  			}  
  		} 
  
  		private DateTime m_SendTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SendTime 
  		{ 
  			get 
  			{ 
  				return m_SendTime ; 
  			}  
  			set 
  			{ 
  				m_SendTime = value ; 
  			}  
  		} 
  
  		private int m_SendFlag = 0; 
  		public int SendFlag 
  		{ 
  			get 
  			{ 
  				return m_SendFlag ; 
  			}  
  			set 
  			{ 
  				m_SendFlag = value ; 
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
            string Sql="SELECT * FROM SMS_MSGInputDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM SMS_MSGInputDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Context=SysConvert.ToString(MasterTable.Rows[0]["Context"]); 
  				m_TargetPhone=SysConvert.ToString(MasterTable.Rows[0]["TargetPhone"]); 
  				m_TaregtInfo=SysConvert.ToString(MasterTable.Rows[0]["TaregtInfo"]); 
  				m_TargetDesc=SysConvert.ToString(MasterTable.Rows[0]["TargetDesc"]); 
  				m_SendTime=SysConvert.ToDateTime(MasterTable.Rows[0]["SendTime"]); 
  				m_SendFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SendFlag"]); 
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
