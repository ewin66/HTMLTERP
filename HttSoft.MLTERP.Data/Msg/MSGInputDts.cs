using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：SMS_MSGInputDts实体类
	/// 作者:章文强
	/// 创建日期:2012/7/11
	/// </summary>
	public sealed class MSGInputDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public MSGInputDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public MSGInputDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
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
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM SMS_MSGInputDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM SMS_MSGInputDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
