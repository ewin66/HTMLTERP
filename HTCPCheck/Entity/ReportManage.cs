using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：Data_ReportManage实体类
	/// 作者:陈加海
	/// 创建日期:2011-11-9
	/// </summary>
	public sealed class ReportManage : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ReportManage()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ReportManage(IDBTransAccess p_SqlCmd)
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
  
  		private string m_ReportName = string.Empty ; 
  		public string ReportName 
  		{ 
  			get 
  			{ 
  				return m_ReportName ; 
  			}  
  			set 
  			{ 
  				m_ReportName = value ; 
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
  
  		private int m_FileID = 0; 
  		public int FileID 
  		{ 
  			get 
  			{ 
  				return m_FileID ; 
  			}  
  			set 
  			{ 
  				m_FileID = value ; 
  			}  
  		} 
  
  		private string m_ModelType = string.Empty ; 
  		public string ModelType 
  		{ 
  			get 
  			{ 
  				return m_ModelType ; 
  			}  
  			set 
  			{ 
  				m_ModelType = value ; 
  			}  
  		} 
  
  		private int m_ModelID = 0; 
  		public int ModelID 
  		{ 
  			get 
  			{ 
  				return m_ModelID ; 
  			}  
  			set 
  			{ 
  				m_ModelID = value ; 
  			}  
  		} 
  
  		private string m_Url = string.Empty ; 
  		public string Url 
  		{ 
  			get 
  			{ 
  				return m_Url ; 
  			}  
  			set 
  			{ 
  				m_Url = value ; 
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
  
  		private DateTime m_MDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MDate 
  		{ 
  			get 
  			{ 
  				return m_MDate ; 
  			}  
  			set 
  			{ 
  				m_MDate = value ; 
  			}  
  		} 
  
  		private string m_MUser = string.Empty ; 
  		public string MUser 
  		{ 
  			get 
  			{ 
  				return m_MUser ; 
  			}  
  			set 
  			{ 
  				m_MUser = value ; 
  			}  
  		} 
  
  		private int m_MenuID = 0; 
  		public int MenuID 
  		{ 
  			get 
  			{ 
  				return m_MenuID ; 
  			}  
  			set 
  			{ 
  				m_MenuID = value ; 
  			}  
  		} 
  
  		private int m_WinID = 0; 
  		public int WinID 
  		{ 
  			get 
  			{ 
  				return m_WinID ; 
  			}  
  			set 
  			{ 
  				m_WinID = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_ReportManage WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ReportManage WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ParentID=SysConvert.ToInt32(MasterTable.Rows[0]["ParentID"]); 
  				m_WinListID=SysConvert.ToInt32(MasterTable.Rows[0]["WinListID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_ReportName=SysConvert.ToString(MasterTable.Rows[0]["ReportName"]); 
  				m_FileName=SysConvert.ToString(MasterTable.Rows[0]["FileName"]); 
  				m_FileID=SysConvert.ToInt32(MasterTable.Rows[0]["FileID"]); 
  				m_ModelType=SysConvert.ToString(MasterTable.Rows[0]["ModelType"]); 
  				m_ModelID=SysConvert.ToInt32(MasterTable.Rows[0]["ModelID"]); 
  				m_Url=SysConvert.ToString(MasterTable.Rows[0]["Url"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_MDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MDate"]); 
  				m_MUser=SysConvert.ToString(MasterTable.Rows[0]["MUser"]); 
  				m_MenuID=SysConvert.ToInt32(MasterTable.Rows[0]["MenuID"]); 
  				m_WinID=SysConvert.ToInt32(MasterTable.Rows[0]["WinID"]); 
  				m_HeadTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["HeadTypeID"]); 
  				m_SubTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SubTypeID"]); 
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
