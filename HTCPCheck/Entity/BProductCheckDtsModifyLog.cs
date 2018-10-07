using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：WO_BProductCheckDtsModifyLog实体类
	/// 作者:陈加海
	/// 创建日期:2014/5/4
	/// </summary>
	public sealed class BProductCheckDtsModifyLog : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public BProductCheckDtsModifyLog()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public BProductCheckDtsModifyLog(IDBTransAccess p_SqlCmd)
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
  
  		private int m_ModifyID = 0; 
  		public int ModifyID 
  		{ 
  			get 
  			{ 
  				return m_ModifyID ; 
  			}  
  			set 
  			{ 
  				m_ModifyID = value ; 
  			}  
  		} 
  
  		private DateTime m_ModifyDay = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ModifyDay 
  		{ 
  			get 
  			{ 
  				return m_ModifyDay ; 
  			}  
  			set 
  			{ 
  				m_ModifyDay = value ; 
  			}  
  		} 
  
  		private string m_OldCompactNo = string.Empty ; 
  		public string OldCompactNo 
  		{ 
  			get 
  			{ 
  				return m_OldCompactNo ; 
  			}  
  			set 
  			{ 
  				m_OldCompactNo = value ; 
  			}  
  		} 
  
  		private string m_OldJarNum = string.Empty ; 
  		public string OldJarNum 
  		{ 
  			get 
  			{ 
  				return m_OldJarNum ; 
  			}  
  			set 
  			{ 
  				m_OldJarNum = value ; 
  			}  
  		} 
  
  		private int m_OldSeq = 0; 
  		public int OldSeq 
  		{ 
  			get 
  			{ 
  				return m_OldSeq ; 
  			}  
  			set 
  			{ 
  				m_OldSeq = value ; 
  			}  
  		} 
  
  		private string m_CompactNo = string.Empty ; 
  		public string CompactNo 
  		{ 
  			get 
  			{ 
  				return m_CompactNo ; 
  			}  
  			set 
  			{ 
  				m_CompactNo = value ; 
  			}  
  		} 
  
  		private string m_JarNum = string.Empty ; 
  		public string JarNum 
  		{ 
  			get 
  			{ 
  				return m_JarNum ; 
  			}  
  			set 
  			{ 
  				m_JarNum = value ; 
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
  
  		private int m_NewISNID = 0; 
  		public int NewISNID 
  		{ 
  			get 
  			{ 
  				return m_NewISNID ; 
  			}  
  			set 
  			{ 
  				m_NewISNID = value ; 
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
            string Sql="SELECT * FROM WO_BProductCheckDtsModifyLog WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_BProductCheckDtsModifyLog WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ModifyID=SysConvert.ToInt32(MasterTable.Rows[0]["ModifyID"]); 
  				m_ModifyDay=SysConvert.ToDateTime(MasterTable.Rows[0]["ModifyDay"]); 
  				m_OldCompactNo=SysConvert.ToString(MasterTable.Rows[0]["OldCompactNo"]); 
  				m_OldJarNum=SysConvert.ToString(MasterTable.Rows[0]["OldJarNum"]); 
  				m_OldSeq=SysConvert.ToInt32(MasterTable.Rows[0]["OldSeq"]); 
  				m_CompactNo=SysConvert.ToString(MasterTable.Rows[0]["CompactNo"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_NewISNID=SysConvert.ToInt32(MasterTable.Rows[0]["NewISNID"]); 
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
