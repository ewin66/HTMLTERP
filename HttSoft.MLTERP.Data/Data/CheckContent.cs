using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_CheckContent实体类
	/// 作者:潘杰俊
	/// 创建日期:2009-7-10
	/// </summary>
	public sealed class CheckContent : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckContent()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckContent(IDBTransAccess p_SqlCmd)
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
  
  		private int m_CompanyTypeID = 0; 
  		public int CompanyTypeID 
  		{ 
  			get 
  			{ 
  				return m_CompanyTypeID ; 
  			}  
  			set 
  			{ 
  				m_CompanyTypeID = value ; 
  			}  
  		} 
  
  		private string m_Content = string.Empty ; 
  		public string Content 
  		{ 
  			get 
  			{ 
  				return m_Content ; 
  			}  
  			set 
  			{ 
  				m_Content = value ; 
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
  
  		private int m_ParentID = 0; 
  		public int ParentID 
  		{ 
  			get 
  			{ 
  				return m_ParentID ; 
  			}  
  			set 
  			{ 
  				m_ParentID = value ; 
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
  
  		private int m_SubmitTime = 0; 
  		public int SubmitTime 
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
  
  		private int m_SubmitOPID = 0; 
  		public int SubmitOPID 
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
  
  		private int m_AuditFlag = 0; 
  		public int AuditFlag 
  		{ 
  			get 
  			{ 
  				return m_AuditFlag ; 
  			}  
  			set 
  			{ 
  				m_AuditFlag = value ; 
  			}  
  		} 
  
  		private int m_AuditOPID = 0; 
  		public int AuditOPID 
  		{ 
  			get 
  			{ 
  				return m_AuditOPID ; 
  			}  
  			set 
  			{ 
  				m_AuditOPID = value ; 
  			}  
  		} 
  
  		private int m_AddTime = 0; 
  		public int AddTime 
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
  
  		private int m_AddOPID = 0; 
  		public int AddOPID 
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
  
  		private int m_UpdTime = 0; 
  		public int UpdTime 
  		{ 
  			get 
  			{ 
  				return m_UpdTime ; 
  			}  
  			set 
  			{ 
  				m_UpdTime = value ; 
  			}  
  		} 
  
  		private int m_UpdOPID = 0; 
  		public int UpdOPID 
  		{ 
  			get 
  			{ 
  				return m_UpdOPID ; 
  			}  
  			set 
  			{ 
  				m_UpdOPID = value ; 
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
            string Sql="SELECT * FROM Data_CheckContent WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_CheckContent WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_CompanyTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["CompanyTypeID"]); 
  				m_Content=SysConvert.ToString(MasterTable.Rows[0]["Content"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ParentID=SysConvert.ToInt32(MasterTable.Rows[0]["ParentID"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_SubmitTime=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitTime"]); 
  				m_SubmitOPID=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitOPID"]); 
  				m_AuditFlag=SysConvert.ToInt32(MasterTable.Rows[0]["AuditFlag"]); 
  				m_AuditOPID=SysConvert.ToInt32(MasterTable.Rows[0]["AuditOPID"]); 
  				m_AddTime=SysConvert.ToInt32(MasterTable.Rows[0]["AddTime"]); 
  				m_AddOPID=SysConvert.ToInt32(MasterTable.Rows[0]["AddOPID"]); 
  				m_UpdTime=SysConvert.ToInt32(MasterTable.Rows[0]["UpdTime"]); 
  				m_UpdOPID=SysConvert.ToInt32(MasterTable.Rows[0]["UpdOPID"]); 
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
