using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：BBS_InfoMainAtt实体类
	/// 作者:章文强
	/// 创建日期:2012/7/21
	/// </summary>
	public sealed class InfoMainAtt : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public InfoMainAtt()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public InfoMainAtt(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "BBS_InfoMainAtt";
		 
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
  
  		private int m_FileTypeID = 0; 
  		public int FileTypeID 
  		{ 
  			get 
  			{ 
  				return m_FileTypeID ; 
  			}  
  			set 
  			{ 
  				m_FileTypeID = value ; 
  			}  
  		} 
  
  		private byte[] m_Context = new byte[1]; 
  		public byte[] Context 
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
  
  		private int m_EntityID = 0; 
  		public int EntityID 
  		{ 
  			get 
  			{ 
  				return m_EntityID ; 
  			}  
  			set 
  			{ 
  				m_EntityID = value ; 
  			}  
  		} 
  
  		private int m_EntitySeq = 0; 
  		public int EntitySeq 
  		{ 
  			get 
  			{ 
  				return m_EntitySeq ; 
  			}  
  			set 
  			{ 
  				m_EntitySeq = value ; 
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
  
  		private string m_FileExec = string.Empty ; 
  		public string FileExec 
  		{ 
  			get 
  			{ 
  				return m_FileExec ; 
  			}  
  			set 
  			{ 
  				m_FileExec = value ; 
  			}  
  		} 
  
  		private decimal m_FileLength = 0; 
  		public decimal FileLength 
  		{ 
  			get 
  			{ 
  				return m_FileLength ; 
  			}  
  			set 
  			{ 
  				m_FileLength = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM BBS_InfoMainAtt WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM BBS_InfoMainAtt WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_FileTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["FileTypeID"]); 
  				if(MasterTable.Rows[0]["Context"]!=DBNull.Value) 
  				{ 
  				 	m_Context=(byte[])(MasterTable.Rows[0]["Context"]); 
  				} 
  				m_EntityID=SysConvert.ToInt32(MasterTable.Rows[0]["EntityID"]); 
  				m_EntitySeq=SysConvert.ToInt32(MasterTable.Rows[0]["EntitySeq"]); 
  				m_FileName=SysConvert.ToString(MasterTable.Rows[0]["FileName"]); 
  				m_FileExec=SysConvert.ToString(MasterTable.Rows[0]["FileExec"]); 
  				m_FileLength=SysConvert.ToDecimal(MasterTable.Rows[0]["FileLength"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UploadTime=SysConvert.ToDateTime(MasterTable.Rows[0]["UploadTime"]); 
  				m_UploadOPID=SysConvert.ToString(MasterTable.Rows[0]["UploadOPID"]); 
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
