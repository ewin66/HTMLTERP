using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：SMS_MSGMessage实体类
	/// 作者:shich
	/// 创建日期:2013-12-11
	/// </summary>
	public sealed class MSGMessage : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public MSGMessage()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public MSGMessage(IDBTransAccess p_SqlCmd)
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
  
  		private string m_MesPhone = string.Empty ; 
  		public string MesPhone 
  		{ 
  			get 
  			{ 
  				return m_MesPhone ; 
  			}  
  			set 
  			{ 
  				m_MesPhone = value ; 
  			}  
  		} 
  
  		private string m_MesMakeOPID = string.Empty ; 
  		public string MesMakeOPID 
  		{ 
  			get 
  			{ 
  				return m_MesMakeOPID ; 
  			}  
  			set 
  			{ 
  				m_MesMakeOPID = value ; 
  			}  
  		} 
  
  		private string m_TargetOPID = string.Empty ; 
  		public string TargetOPID 
  		{ 
  			get 
  			{ 
  				return m_TargetOPID ; 
  			}  
  			set 
  			{ 
  				m_TargetOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_MesTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MesTime 
  		{ 
  			get 
  			{ 
  				return m_MesTime ; 
  			}  
  			set 
  			{ 
  				m_MesTime = value ; 
  			}  
  		} 
  
  		private int m_MSID = 0; 
  		public int MSID 
  		{ 
  			get 
  			{ 
  				return m_MSID ; 
  			}  
  			set 
  			{ 
  				m_MSID = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM SMS_MSGMessage WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM SMS_MSGMessage WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Context=SysConvert.ToString(MasterTable.Rows[0]["Context"]); 
  				m_MesPhone=SysConvert.ToString(MasterTable.Rows[0]["MesPhone"]); 
  				m_MesMakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MesMakeOPID"]); 
  				m_TargetOPID=SysConvert.ToString(MasterTable.Rows[0]["TargetOPID"]); 
  				m_MesTime=SysConvert.ToDateTime(MasterTable.Rows[0]["MesTime"]); 
  				m_MSID=SysConvert.ToInt32(MasterTable.Rows[0]["MSID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
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
