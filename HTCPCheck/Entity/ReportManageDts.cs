using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// Ŀ�ģ�Data_ReportManageDtsʵ����
	/// ����:�ܸ���
	/// ��������:2012/4/16
	/// </summary>
	public sealed class ReportManageDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ReportManageDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public ReportManageDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
  
  		private string m_DataSourceName = string.Empty ; 
  		public string DataSourceName 
  		{ 
  			get 
  			{ 
  				return m_DataSourceName ; 
  			}  
  			set 
  			{ 
  				m_DataSourceName = value ; 
  			}  
  		} 
  
  		private string m_SqlName = string.Empty ; 
  		public string SqlName 
  		{ 
  			get 
  			{ 
  				return m_SqlName ; 
  			}  
  			set 
  			{ 
  				m_SqlName = value ; 
  			}  
  		} 
  
  		private string m_SqlStr = string.Empty ; 
  		public string SqlStr 
  		{ 
  			get 
  			{ 
  				return m_SqlStr ; 
  			}  
  			set 
  			{ 
  				m_SqlStr = value ; 
  			}  
  		} 
  
  		private string m_QueryName = string.Empty ; 
  		public string QueryName 
  		{ 
  			get 
  			{ 
  				return m_QueryName ; 
  			}  
  			set 
  			{ 
  				m_QueryName = value ; 
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
  
  		private int m_SqlFlag = 0; 
  		public int SqlFlag 
  		{ 
  			get 
  			{ 
  				return m_SqlFlag ; 
  			}  
  			set 
  			{ 
  				m_SqlFlag = value ; 
  			}  
  		} 
  
  		private int m_SourceType = 0; 
  		public int SourceType 
  		{ 
  			get 
  			{ 
  				return m_SourceType ; 
  			}  
  			set 
  			{ 
  				m_SourceType = value ; 
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
            string Sql="SELECT * FROM Data_ReportManageDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ReportManageDts WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_DataSourceName=SysConvert.ToString(MasterTable.Rows[0]["DataSourceName"]); 
  				m_SqlName=SysConvert.ToString(MasterTable.Rows[0]["SqlName"]); 
  				m_SqlStr=SysConvert.ToString(MasterTable.Rows[0]["SqlStr"]); 
  				m_QueryName=SysConvert.ToString(MasterTable.Rows[0]["QueryName"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SqlFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SqlFlag"]); 
  				m_SourceType=SysConvert.ToInt32(MasterTable.Rows[0]["SourceType"]); 
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
