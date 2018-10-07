using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Dev_GBJCDts实体类
	/// 作者:shich
	/// 创建日期:2013-11-11
	/// </summary>
	public sealed class GBJCDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public GBJCDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public GBJCDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性

        public static readonly string TableName = "Dev_GBJCDts";

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

        private string m_JYVendorID = string.Empty;
        public string JYVendorID
        {
            get 
            { 
                return m_JYVendorID; 
            }
            set 
            { 
                m_JYVendorID = value; 
            }
        }

        private string m_JYVendorName = string.Empty;

        public string JYVendorName
        {
            get 
            { 
                return m_JYVendorName; 
            }
            set 
            { 
                m_JYVendorName = value; 
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
            string Sql="SELECT * FROM Dev_GBJCDts WHERE "+ "ID="+SysString.ToDBString(m_ID)+" AND MainID="+SysString.ToDBString(m_MainID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Dev_GBJCDts WHERE "+ "ID="+SysString.ToDBString(m_ID)+" AND MainID="+SysString.ToDBString(m_MainID);
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
                m_JYVendorID = SysConvert.ToString(MasterTable .Rows[0]["JYVendorID"]);
                m_JYVendorName = SysConvert.ToString(MasterTable.Rows[0]["JYVendorName"]);
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
