using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sys_WindowMenu实体类
	/// 作者:周富春
	/// 创建日期:2012-4-24
	/// </summary>
	public sealed class WindowMenu : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WindowMenu()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WindowMenu(IDBTransAccess p_SqlCmd)
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
  
  		private string m_Name = string.Empty ; 
  		public string Name 
  		{ 
  			get 
  			{ 
  				return m_Name ; 
  			}  
  			set 
  			{ 
  				m_Name = value ; 
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
  
  		private int m_Sort = 0; 
  		public int Sort 
  		{ 
  			get 
  			{ 
  				return m_Sort ; 
  			}  
  			set 
  			{ 
  				m_Sort = value ; 
  			}  
  		} 
  
  		private int m_HttFlag = 0; 
  		public int HttFlag 
  		{ 
  			get 
  			{ 
  				return m_HttFlag ; 
  			}  
  			set 
  			{ 
  				m_HttFlag = value ; 
  			}  
  		} 
  
  		private int m_ShowFlag = 0; 
  		public int ShowFlag 
  		{ 
  			get 
  			{ 
  				return m_ShowFlag ; 
  			}  
  			set 
  			{ 
  				m_ShowFlag = value ; 
  			}  
  		} 
  
  		private int m_SystemTypeID = 0; 
  		public int SystemTypeID 
  		{ 
  			get 
  			{ 
  				return m_SystemTypeID ; 
  			}  
  			set 
  			{ 
  				m_SystemTypeID = value ; 
  			}  
  		} 
  
  		private string m_ShortCutChar = string.Empty ; 
  		public string ShortCutChar 
  		{ 
  			get 
  			{ 
  				return m_ShortCutChar ; 
  			}  
  			set 
  			{ 
  				m_ShortCutChar = value ; 
  			}  
  		} 
  
  		private int m_HeadTypeID = 0; 
  		public int HeadTypeID 
  		{ 
  			get 
  			{ 
  				return m_HeadTypeID ; 
  			}  
  			set 
  			{ 
  				m_HeadTypeID = value ; 
  			}  
  		} 
  
  		private int m_SubTypeID = 0; 
  		public int SubTypeID 
  		{ 
  			get 
  			{ 
  				return m_SubTypeID ; 
  			}  
  			set 
  			{ 
  				m_SubTypeID = value ; 
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
  
  		private int m_ModuleFlowID = 0; 
  		public int ModuleFlowID 
  		{ 
  			get 
  			{ 
  				return m_ModuleFlowID ; 
  			}  
  			set 
  			{ 
  				m_ModuleFlowID = value ; 
  			}  
  		} 
  
  		private int m_MenuTypeID = 0; 
  		public int MenuTypeID 
  		{ 
  			get 
  			{ 
  				return m_MenuTypeID ; 
  			}  
  			set 
  			{ 
  				m_MenuTypeID = value ; 
  			}  
  		} 
  
  		private int m_UseTypeID = 0; 
  		public int UseTypeID 
  		{ 
  			get 
  			{ 
  				return m_UseTypeID ; 
  			}  
  			set 
  			{ 
  				m_UseTypeID = value ; 
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
            string Sql="SELECT * FROM Sys_WindowMenu WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sys_WindowMenu WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_ParentID=SysConvert.ToInt32(MasterTable.Rows[0]["ParentID"]); 
  				m_Sort=SysConvert.ToInt32(MasterTable.Rows[0]["Sort"]); 
  				m_HttFlag=SysConvert.ToInt32(MasterTable.Rows[0]["HttFlag"]); 
  				m_ShowFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ShowFlag"]); 
  				m_SystemTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SystemTypeID"]); 
  				m_ShortCutChar=SysConvert.ToString(MasterTable.Rows[0]["ShortCutChar"]); 
  				m_HeadTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["HeadTypeID"]); 
  				m_SubTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SubTypeID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_AuditFlag=SysConvert.ToInt32(MasterTable.Rows[0]["AuditFlag"]); 
  				m_ModuleFlowID=SysConvert.ToInt32(MasterTable.Rows[0]["ModuleFlowID"]); 
  				m_MenuTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["MenuTypeID"]); 
  				m_UseTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["UseTypeID"]); 
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
