using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
	/// <summary>
	/// 目的：Data_WinListAttachFile实体类
	/// 作者:陈加海
	/// 创建日期:2014/4/23
	/// </summary>
	public sealed class WinListAttachFile : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WinListAttachFile()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WinListAttachFile(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private int m_WinListID = 0; 
  		public int WinListID 
  		{ 
  			get 
  			{ 
  				return m_WinListID ; 
  			}  
  			set 
  			{ 
  				m_WinListID = value ; 
  			}  
  		} 
  
  		private int m_HeadType = 0; 
  		public int HeadType 
  		{ 
  			get 
  			{ 
  				return m_HeadType ; 
  			}  
  			set 
  			{ 
  				m_HeadType = value ; 
  			}  
  		} 
  
  		private int m_SubType = 0; 
  		public int SubType 
  		{ 
  			get 
  			{ 
  				return m_SubType ; 
  			}  
  			set 
  			{ 
  				m_SubType = value ; 
  			}  
  		} 
  
  		private int m_HTDataID = 0; 
  		public int HTDataID 
  		{ 
  			get 
  			{ 
  				return m_HTDataID ; 
  			}  
  			set 
  			{ 
  				m_HTDataID = value ; 
  			}  
  		} 
  
  		private int m_HTDataSeq = 0; 
  		public int HTDataSeq 
  		{ 
  			get 
  			{ 
  				return m_HTDataSeq ; 
  			}  
  			set 
  			{ 
  				m_HTDataSeq = value ; 
  			}  
  		} 
  
  		private string m_FileProt1 = string.Empty ; 
  		public string FileProt1 
  		{ 
  			get 
  			{ 
  				return m_FileProt1 ; 
  			}  
  			set 
  			{ 
  				m_FileProt1 = value ; 
  			}  
  		} 
  
  		private string m_FileProt2 = string.Empty ; 
  		public string FileProt2 
  		{ 
  			get 
  			{ 
  				return m_FileProt2 ; 
  			}  
  			set 
  			{ 
  				m_FileProt2 = value ; 
  			}  
  		} 
  
  		private string m_FileProt3 = string.Empty ; 
  		public string FileProt3 
  		{ 
  			get 
  			{ 
  				return m_FileProt3 ; 
  			}  
  			set 
  			{ 
  				m_FileProt3 = value ; 
  			}  
  		} 
  
  		private string m_FileTitle = string.Empty ; 
  		public string FileTitle 
  		{ 
  			get 
  			{ 
  				return m_FileTitle ; 
  			}  
  			set 
  			{ 
  				m_FileTitle = value ; 
  			}  
  		} 
  
  		private string m_FileName = string.Empty ; 
  		public string FileName 
  		{ 
  			get 
  			{ 
  				return m_FileName ; 
  			}  
  			set 
  			{ 
  				m_FileName = value ; 
  			}  
  		} 
  
  		private byte[] m_FileContext = new byte[1]; 
  		public byte[] FileContext 
  		{ 
  			get 
  			{ 
  				return m_FileContext ; 
  			}  
  			set 
  			{ 
  				m_FileContext = value ; 
  			}  
  		} 
  
  		private int m_FileSize = 0; 
  		public int FileSize 
  		{ 
  			get 
  			{ 
  				return m_FileSize ; 
  			}  
  			set 
  			{ 
  				m_FileSize = value ; 
  			}  
  		} 
  
  		private DateTime m_UploadTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime UploadTime 
  		{ 
  			get 
  			{ 
  				return m_UploadTime ; 
  			}  
  			set 
  			{ 
  				m_UploadTime = value ; 
  			}  
  		} 
  
  		private string m_UploadOPID = string.Empty ; 
  		public string UploadOPID 
  		{ 
  			get 
  			{ 
  				return m_UploadOPID ; 
  			}  
  			set 
  			{ 
  				m_UploadOPID = value ; 
  			}  
  		} 
  
  		private string m_UploadOPName = string.Empty ; 
  		public string UploadOPName 
  		{ 
  			get 
  			{ 
  				return m_UploadOPName ; 
  			}  
  			set 
  			{ 
  				m_UploadOPName = value ; 
  			}  
  		} 
  
  		private int m_UploadLoginLogID = 0; 
  		public int UploadLoginLogID 
  		{ 
  			get 
  			{ 
  				return m_UploadLoginLogID ; 
  			}  
  			set 
  			{ 
  				m_UploadLoginLogID = value ; 
  			}  
  		} 
  
  		private string m_FileTypeName = string.Empty ; 
  		public string FileTypeName 
  		{ 
  			get 
  			{ 
  				return m_FileTypeName ; 
  			}  
  			set 
  			{ 
  				m_FileTypeName = value ; 
  			}  
  		} 
  
  		private string m_FileExe = string.Empty ; 
  		public string FileExe 
  		{ 
  			get 
  			{ 
  				return m_FileExe ; 
  			}  
  			set 
  			{ 
  				m_FileExe = value ; 
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
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_WinListAttachFile WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_WinListAttachFile WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按传入的SQL语句查询后给属性赋值
        /// </summary>
        /// <param name="p_Sql">SQL语句</param>
        /// <returns>记录存在回true，不存在返回false</returns>
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
                //查询主表记录
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_WinListID=SysConvert.ToInt32(MasterTable.Rows[0]["WinListID"]); 
  				m_HeadType=SysConvert.ToInt32(MasterTable.Rows[0]["HeadType"]); 
  				m_SubType=SysConvert.ToInt32(MasterTable.Rows[0]["SubType"]); 
  				m_HTDataID=SysConvert.ToInt32(MasterTable.Rows[0]["HTDataID"]); 
  				m_HTDataSeq=SysConvert.ToInt32(MasterTable.Rows[0]["HTDataSeq"]); 
  				m_FileProt1=SysConvert.ToString(MasterTable.Rows[0]["FileProt1"]); 
  				m_FileProt2=SysConvert.ToString(MasterTable.Rows[0]["FileProt2"]); 
  				m_FileProt3=SysConvert.ToString(MasterTable.Rows[0]["FileProt3"]); 
  				m_FileTitle=SysConvert.ToString(MasterTable.Rows[0]["FileTitle"]); 
  				m_FileName=SysConvert.ToString(MasterTable.Rows[0]["FileName"]); 
  				if(MasterTable.Rows[0]["FileContext"]!=DBNull.Value) 
  				{ 
  				 	m_FileContext=(byte[])(MasterTable.Rows[0]["FileContext"]); 
  				} 
  				m_FileSize=SysConvert.ToInt32(MasterTable.Rows[0]["FileSize"]); 
  				m_UploadTime=SysConvert.ToDateTime(MasterTable.Rows[0]["UploadTime"]); 
  				m_UploadOPID=SysConvert.ToString(MasterTable.Rows[0]["UploadOPID"]); 
  				m_UploadOPName=SysConvert.ToString(MasterTable.Rows[0]["UploadOPName"]); 
  				m_UploadLoginLogID=SysConvert.ToInt32(MasterTable.Rows[0]["UploadLoginLogID"]); 
  				m_FileTypeName=SysConvert.ToString(MasterTable.Rows[0]["FileTypeName"]); 
  				m_FileExe=SysConvert.ToString(MasterTable.Rows[0]["FileExe"]); 
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
