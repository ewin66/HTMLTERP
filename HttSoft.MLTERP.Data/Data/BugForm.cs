using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_BugFormʵ����
	/// ����:�����
	/// ��������:2014/3/20
	/// </summary>
	public sealed class BugForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public BugForm()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public BugForm(IDBTransAccess p_SqlCmd)
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
  
  		private string m_ConFormNo = string.Empty ; 
  		public string ConFormNo 
  		{ 
  			get 
  			{ 
  				return m_ConFormNo ; 
  			}  
  			set 
  			{ 
  				m_ConFormNo = value ; 
  			}  
  		} 
  
  		private int m_BugType = 0; 
  		public int BugType 
  		{ 
  			get 
  			{ 
  				return m_BugType ; 
  			}  
  			set 
  			{ 
  				m_BugType = value ; 
  			}  
  		} 
  
  		private int m_Status = 0; 
  		public int Status 
  		{ 
  			get 
  			{ 
  				return m_Status ; 
  			}  
  			set 
  			{ 
  				m_Status = value ; 
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
  
  		private string m_AutoOPID = string.Empty ; 
  		public string AutoOPID 
  		{ 
  			get 
  			{ 
  				return m_AutoOPID ; 
  			}  
  			set 
  			{ 
  				m_AutoOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_AutoDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AutoDate 
  		{ 
  			get 
  			{ 
  				return m_AutoDate ; 
  			}  
  			set 
  			{ 
  				m_AutoDate = value ; 
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
            string Sql="SELECT * FROM Data_BugForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_BugForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_ConFormNo=SysConvert.ToString(MasterTable.Rows[0]["ConFormNo"]); 
  				m_BugType=SysConvert.ToInt32(MasterTable.Rows[0]["BugType"]); 
  				m_Status=SysConvert.ToInt32(MasterTable.Rows[0]["Status"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_AutoOPID=SysConvert.ToString(MasterTable.Rows[0]["AutoOPID"]); 
  				m_AutoDate=SysConvert.ToDateTime(MasterTable.Rows[0]["AutoDate"]); 
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
