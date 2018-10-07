using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：BBS_InfoMain实体类
	/// 作者:章文强
	/// 创建日期:2012/7/21
	/// </summary>
	public sealed class InfoMain : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public InfoMain()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public InfoMain(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "BBS_InfoMain";
		 
  		private int m_DSYSID = 0; 
  		public int DSYSID 
  		{ 
  			get 
  			{ 
  				return m_DSYSID ; 
  			}  
  			set 
  			{ 
  				m_DSYSID = value ; 
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
  
  		private string m_DTitle = string.Empty ; 
  		public string DTitle 
  		{ 
  			get 
  			{ 
  				return m_DTitle ; 
  			}  
  			set 
  			{ 
  				m_DTitle = value ; 
  			}  
  		} 
  
  		private string m_DContext = string.Empty ; 
  		public string DContext 
  		{ 
  			get 
  			{ 
  				return m_DContext ; 
  			}  
  			set 
  			{ 
  				m_DContext = value ; 
  			}  
  		} 
  
  		private string m_DRemark = string.Empty ; 
  		public string DRemark 
  		{ 
  			get 
  			{ 
  				return m_DRemark ; 
  			}  
  			set 
  			{ 
  				m_DRemark = value ; 
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
  
  		private string m_SubmitOPID = string.Empty ; 
  		public string SubmitOPID 
  		{ 
  			get 
  			{ 
  				return m_SubmitOPID ; 
  			}  
  			set 
  			{ 
  				m_SubmitOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_SubmitTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SubmitTime 
  		{ 
  			get 
  			{ 
  				return m_SubmitTime ; 
  			}  
  			set 
  			{ 
  				m_SubmitTime = value ; 
  			}  
  		} 
  
  		private int m_CheckFlag = 0; 
  		public int CheckFlag 
  		{ 
  			get 
  			{ 
  				return m_CheckFlag ; 
  			}  
  			set 
  			{ 
  				m_CheckFlag = value ; 
  			}  
  		} 
  
  		private string m_CheckOPID = string.Empty ; 
  		public string CheckOPID 
  		{ 
  			get 
  			{ 
  				return m_CheckOPID ; 
  			}  
  			set 
  			{ 
  				m_CheckOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_CheckTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CheckTime 
  		{ 
  			get 
  			{ 
  				return m_CheckTime ; 
  			}  
  			set 
  			{ 
  				m_CheckTime = value ; 
  			}  
  		} 
  
  		private DateTime m_AddTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime AddTime 
  		{ 
  			get 
  			{ 
  				return m_AddTime ; 
  			}  
  			set 
  			{ 
  				m_AddTime = value ; 
  			}  
  		} 
  
  		private string m_AddOPID = string.Empty ; 
  		public string AddOPID 
  		{ 
  			get 
  			{ 
  				return m_AddOPID ; 
  			}  
  			set 
  			{ 
  				m_AddOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_LastTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime LastTime 
  		{ 
  			get 
  			{ 
  				return m_LastTime ; 
  			}  
  			set 
  			{ 
  				m_LastTime = value ; 
  			}  
  		} 
  
  		private string m_LastOPID = string.Empty ; 
  		public string LastOPID 
  		{ 
  			get 
  			{ 
  				return m_LastOPID ; 
  			}  
  			set 
  			{ 
  				m_LastOPID = value ; 
  			}  
  		} 
  
  		private int m_ShareFlag = 0; 
  		public int ShareFlag 
  		{ 
  			get 
  			{ 
  				return m_ShareFlag ; 
  			}  
  			set 
  			{ 
  				m_ShareFlag = value ; 
  			}  
  		} 
  
  		private int m_ViewNum = 0; 
  		public int ViewNum 
  		{ 
  			get 
  			{ 
  				return m_ViewNum ; 
  			}  
  			set 
  			{ 
  				m_ViewNum = value ; 
  			}  
  		} 
  
  		private int m_InfoType = 0; 
  		public int InfoType 
  		{ 
  			get 
  			{ 
  				return m_InfoType ; 
  			}  
  			set 
  			{ 
  				m_InfoType = value ; 
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
            string Sql="SELECT * FROM BBS_InfoMain WHERE "+ "DSYSID="+SysString.ToDBString(m_DSYSID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM BBS_InfoMain WHERE "+ "DSYSID="+SysString.ToDBString(m_DSYSID);
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
                m_DSYSID=SysConvert.ToInt32(MasterTable.Rows[0]["DSYSID"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_DTitle=SysConvert.ToString(MasterTable.Rows[0]["DTitle"]); 
  				m_DContext=SysConvert.ToString(MasterTable.Rows[0]["DContext"]); 
  				m_DRemark=SysConvert.ToString(MasterTable.Rows[0]["DRemark"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_SubmitOPID=SysConvert.ToString(MasterTable.Rows[0]["SubmitOPID"]); 
  				m_SubmitTime=SysConvert.ToDateTime(MasterTable.Rows[0]["SubmitTime"]); 
  				m_CheckFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CheckFlag"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckTime=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckTime"]); 
  				m_AddTime=SysConvert.ToDateTime(MasterTable.Rows[0]["AddTime"]); 
  				m_AddOPID=SysConvert.ToString(MasterTable.Rows[0]["AddOPID"]); 
  				m_LastTime=SysConvert.ToDateTime(MasterTable.Rows[0]["LastTime"]); 
  				m_LastOPID=SysConvert.ToString(MasterTable.Rows[0]["LastOPID"]); 
  				m_ShareFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ShareFlag"]); 
  				m_ViewNum=SysConvert.ToInt32(MasterTable.Rows[0]["ViewNum"]); 
  				m_InfoType=SysConvert.ToInt32(MasterTable.Rows[0]["InfoType"]); 
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
