using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_WOFollowType实体类
	/// 作者:周富春
	/// 创建日期:2014/8/1
	/// </summary>
	public sealed class WOFollowType : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WOFollowType()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WOFollowType(IDBTransAccess p_SqlCmd)
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
  
  		private int m_UseFlag = 0; 
  		public int UseFlag 
  		{ 
  			get 
  			{ 
  				return m_UseFlag ; 
  			}  
  			set 
  			{ 
  				m_UseFlag = value ; 
  			}  
  		} 
  
  		private int m_SaleProcedureID = 0; 
  		public int SaleProcedureID 
  		{ 
  			get 
  			{ 
  				return m_SaleProcedureID ; 
  			}  
  			set 
  			{ 
  				m_SaleProcedureID = value ; 
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
  
  		private string m_QryTableName = string.Empty ; 
  		public string QryTableName 
  		{ 
  			get 
  			{ 
  				return m_QryTableName ; 
  			}  
  			set 
  			{ 
  				m_QryTableName = value ; 
  			}  
  		} 
  
  		private string m_QryIDFieldName = string.Empty ; 
  		public string QryIDFieldName 
  		{ 
  			get 
  			{ 
  				return m_QryIDFieldName ; 
  			}  
  			set 
  			{ 
  				m_QryIDFieldName = value ; 
  			}  
  		} 
  
  		private string m_QryFieldName = string.Empty ; 
  		public string QryFieldName 
  		{ 
  			get 
  			{ 
  				return m_QryFieldName ; 
  			}  
  			set 
  			{ 
  				m_QryFieldName = value ; 
  			}  
  		} 
  
  		private string m_QryShowCaption = string.Empty ; 
  		public string QryShowCaption 
  		{ 
  			get 
  			{ 
  				return m_QryShowCaption ; 
  			}  
  			set 
  			{ 
  				m_QryShowCaption = value ; 
  			}  
  		} 
  
  		private string m_QryOrderByFieldName = string.Empty ; 
  		public string QryOrderByFieldName 
  		{ 
  			get 
  			{ 
  				return m_QryOrderByFieldName ; 
  			}  
  			set 
  			{ 
  				m_QryOrderByFieldName = value ; 
  			}  
  		} 
  
  		private string m_QryWhereConFirst = string.Empty ; 
  		public string QryWhereConFirst 
  		{ 
  			get 
  			{ 
  				return m_QryWhereConFirst ; 
  			}  
  			set 
  			{ 
  				m_QryWhereConFirst = value ; 
  			}  
  		} 
  
  		private string m_UIImgUrl = string.Empty ; 
  		public string UIImgUrl 
  		{ 
  			get 
  			{ 
  				return m_UIImgUrl ; 
  			}  
  			set 
  			{ 
  				m_UIImgUrl = value ; 
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
            string Sql="SELECT * FROM Enum_WOFollowType WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_WOFollowType WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_UseFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UseFlag"]); 
  				m_SaleProcedureID=SysConvert.ToInt32(MasterTable.Rows[0]["SaleProcedureID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_QryTableName=SysConvert.ToString(MasterTable.Rows[0]["QryTableName"]); 
  				m_QryIDFieldName=SysConvert.ToString(MasterTable.Rows[0]["QryIDFieldName"]); 
  				m_QryFieldName=SysConvert.ToString(MasterTable.Rows[0]["QryFieldName"]); 
  				m_QryShowCaption=SysConvert.ToString(MasterTable.Rows[0]["QryShowCaption"]); 
  				m_QryOrderByFieldName=SysConvert.ToString(MasterTable.Rows[0]["QryOrderByFieldName"]); 
  				m_QryWhereConFirst=SysConvert.ToString(MasterTable.Rows[0]["QryWhereConFirst"]); 
  				m_UIImgUrl=SysConvert.ToString(MasterTable.Rows[0]["UIImgUrl"]); 
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
