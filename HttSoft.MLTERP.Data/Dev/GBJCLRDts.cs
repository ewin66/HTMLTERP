using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Dev_GBJCLRDtsʵ����
	/// ����:shich
	/// ��������:2013-11-18
	/// </summary>
	public sealed class GBJCLRDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public GBJCLRDts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public GBJCLRDts(IDBTransAccess p_SqlCmd)
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
  
  		private string m_GBCode = string.Empty ; 
  		public string GBCode 
  		{ 
  			get 
  			{ 
  				return m_GBCode ; 
  			}  
  			set 
  			{ 
  				m_GBCode = value ; 
  			}  
  		}
        public static readonly string TableName = "Dev_GBJCLRDts";

  		private int m_GBStatusID = 0; 
  		public int GBStatusID 
  		{ 
  			get 
  			{ 
  				return m_GBStatusID ; 
  			}  
  			set 
  			{ 
  				m_GBStatusID = value ; 
  			}  
  		} 
  
  		private DateTime m_JCTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JCTime 
  		{ 
  			get 
  			{ 
  				return m_JCTime ; 
  			}  
  			set 
  			{ 
  				m_JCTime = value ; 
  			}  
  		} 
  
  		private DateTime m_GHTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime GHTime 
  		{ 
  			get 
  			{ 
  				return m_GHTime ; 
  			}  
  			set 
  			{ 
  				m_GHTime = value ; 
  			}  
  		} 
  
  		private string m_GHOPID = string.Empty ; 
  		public string GHOPID 
  		{ 
  			get 
  			{ 
  				return m_GHOPID ; 
  			}  
  			set 
  			{ 
  				m_GHOPID = value ; 
  			}  
  		} 
  
  		private int m_LYFlag = 0; 
  		public int LYFlag 
  		{ 
  			get 
  			{ 
  				return m_LYFlag ; 
  			}  
  			set 
  			{ 
  				m_LYFlag = value ; 
  			}  
  		} 
  
  		private string m_LYVendorID = string.Empty ; 
  		public string LYVendorID 
  		{ 
  			get 
  			{ 
  				return m_LYVendorID ; 
  			}  
  			set 
  			{ 
  				m_LYVendorID = value ; 
  			}  
  		} 
  
  		private string m_LYVendorName = string.Empty ; 
  		public string LYVendorName 
  		{ 
  			get 
  			{ 
  				return m_LYVendorName ; 
  			}  
  			set 
  			{ 
  				m_LYVendorName = value ; 
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
            string Sql="SELECT * FROM Dev_GBJCLRDts WHERE "+ "ID="+SysString.ToDBString(m_ID)+" AND MainID="+SysString.ToDBString(m_MainID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Dev_GBJCLRDts WHERE "+ "ID="+SysString.ToDBString(m_ID)+" AND MainID="+SysString.ToDBString(m_MainID);
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
  				m_GBCode=SysConvert.ToString(MasterTable.Rows[0]["GBCode"]); 
  				m_GBStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["GBStatusID"]); 
  				m_JCTime=SysConvert.ToDateTime(MasterTable.Rows[0]["JCTime"]); 
  				m_GHTime=SysConvert.ToDateTime(MasterTable.Rows[0]["GHTime"]); 
  				m_GHOPID=SysConvert.ToString(MasterTable.Rows[0]["GHOPID"]); 
  				m_LYFlag=SysConvert.ToInt32(MasterTable.Rows[0]["LYFlag"]); 
  				m_LYVendorID=SysConvert.ToString(MasterTable.Rows[0]["LYVendorID"]); 
  				m_LYVendorName=SysConvert.ToString(MasterTable.Rows[0]["LYVendorName"]); 
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
