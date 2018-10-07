using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sys_FiledSet实体类
	/// 作者:周富春
	/// 创建日期:2014/10/14
	/// </summary>
	public sealed class FiledSet : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FiledSet()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FiledSet(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sys_FiledSet";
		 
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
  
  		private int m_FormID = 0; 
  		public int FormID 
  		{ 
  			get 
  			{ 
  				return m_FormID ; 
  			}  
  			set 
  			{ 
  				m_FormID = value ; 
  			}  
  		} 
  
  		private int m_FAID = 0; 
  		public int FAID 
  		{ 
  			get 
  			{ 
  				return m_FAID ; 
  			}  
  			set 
  			{ 
  				m_FAID = value ; 
  			}  
  		} 
  
  		private int m_FBID = 0; 
  		public int FBID 
  		{ 
  			get 
  			{ 
  				return m_FBID ; 
  			}  
  			set 
  			{ 
  				m_FBID = value ; 
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
  
  		private int m_Code = 0; 
  		public int Code 
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
  
  		private string m_FiledName = string.Empty ; 
  		public string FiledName 
  		{ 
  			get 
  			{ 
  				return m_FiledName ; 
  			}  
  			set 
  			{ 
  				m_FiledName = value ; 
  			}  
  		} 
  
  		private string m_FiledType = string.Empty ; 
  		public string FiledType 
  		{ 
  			get 
  			{ 
  				return m_FiledType ; 
  			}  
  			set 
  			{ 
  				m_FiledType = value ; 
  			}  
  		} 
  
  		private string m_BindType = string.Empty ; 
  		public string BindType 
  		{ 
  			get 
  			{ 
  				return m_BindType ; 
  			}  
  			set 
  			{ 
  				m_BindType = value ; 
  			}  
  		} 
  
  		private int m_Length = 0; 
  		public int Length 
  		{ 
  			get 
  			{ 
  				return m_Length ; 
  			}  
  			set 
  			{ 
  				m_Length = value ; 
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
  
  		private int m_UseableFlag = 0; 
  		public int UseableFlag 
  		{ 
  			get 
  			{ 
  				return m_UseableFlag ; 
  			}  
  			set 
  			{ 
  				m_UseableFlag = value ; 
  			}  
  		} 
  
  		private int m_UpDateFlag = 0; 
  		public int UpDateFlag 
  		{ 
  			get 
  			{ 
  				return m_UpDateFlag ; 
  			}  
  			set 
  			{ 
  				m_UpDateFlag = value ; 
  			}  
  		} 
  
  		private string m_MainTable = string.Empty ; 
  		public string MainTable 
  		{ 
  			get 
  			{ 
  				return m_MainTable ; 
  			}  
  			set 
  			{ 
  				m_MainTable = value ; 
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
            string Sql="SELECT * FROM Sys_FiledSet WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sys_FiledSet WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormID=SysConvert.ToInt32(MasterTable.Rows[0]["FormID"]); 
  				m_FAID=SysConvert.ToInt32(MasterTable.Rows[0]["FAID"]); 
  				m_FBID=SysConvert.ToInt32(MasterTable.Rows[0]["FBID"]); 
  				m_Sort=SysConvert.ToInt32(MasterTable.Rows[0]["Sort"]); 
  				m_Code=SysConvert.ToInt32(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_FiledName=SysConvert.ToString(MasterTable.Rows[0]["FiledName"]); 
  				m_FiledType=SysConvert.ToString(MasterTable.Rows[0]["FiledType"]); 
  				m_BindType=SysConvert.ToString(MasterTable.Rows[0]["BindType"]); 
  				m_Length=SysConvert.ToInt32(MasterTable.Rows[0]["Length"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UseableFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UseableFlag"]); 
  				m_UpDateFlag=SysConvert.ToInt32(MasterTable.Rows[0]["UpDateFlag"]); 
  				m_MainTable=SysConvert.ToString(MasterTable.Rows[0]["MainTable"]); 
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
