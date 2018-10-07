using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�SMS_MSGInputʵ����
	/// ����:����ǿ
	/// ��������:2012/7/11
	/// </summary>
	public sealed class MSGInput : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public MSGInput()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public MSGInput(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "SMS_MSGInput";
		 
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
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private DateTime m_InsertTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime InsertTime 
  		{ 
  			get 
  			{ 
  				return m_InsertTime ; 
  			}  
  			set 
  			{ 
  				m_InsertTime = value ; 
  			}  
  		} 
  
  		private int m_MSGSourceID = 0; 
  		public int MSGSourceID 
  		{ 
  			get 
  			{ 
  				return m_MSGSourceID ; 
  			}  
  			set 
  			{ 
  				m_MSGSourceID = value ; 
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
  
  		private string m_ReplaceRule = string.Empty ; 
  		public string ReplaceRule 
  		{ 
  			get 
  			{ 
  				return m_ReplaceRule ; 
  			}  
  			set 
  			{ 
  				m_ReplaceRule = value ; 
  			}  
  		} 
  
  		private string m_SendInfo = string.Empty ; 
  		public string SendInfo 
  		{ 
  			get 
  			{ 
  				return m_SendInfo ; 
  			}  
  			set 
  			{ 
  				m_SendInfo = value ; 
  			}  
  		} 
  
  		private string m_SendDesc = string.Empty ; 
  		public string SendDesc 
  		{ 
  			get 
  			{ 
  				return m_SendDesc ; 
  			}  
  			set 
  			{ 
  				m_SendDesc = value ; 
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
            string Sql="SELECT * FROM SMS_MSGInput WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM SMS_MSGInput WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_InsertTime=SysConvert.ToDateTime(MasterTable.Rows[0]["InsertTime"]); 
  				m_MSGSourceID=SysConvert.ToInt32(MasterTable.Rows[0]["MSGSourceID"]); 
  				m_Context=SysConvert.ToString(MasterTable.Rows[0]["Context"]); 
  				m_ReplaceRule=SysConvert.ToString(MasterTable.Rows[0]["ReplaceRule"]); 
  				m_SendInfo=SysConvert.ToString(MasterTable.Rows[0]["SendInfo"]); 
  				m_SendDesc=SysConvert.ToString(MasterTable.Rows[0]["SendDesc"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
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
