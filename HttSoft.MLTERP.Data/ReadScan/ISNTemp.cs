using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_ISNTemp实体类
	/// 作者:Johnny
	/// 创建日期:2012/5/26
	/// </summary>
	public sealed class ISNTemp : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ISNTemp()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ISNTemp(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_ISNTemp";
		 
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
  
  		private string m_ISN = string.Empty ; 
  		public string ISN 
  		{ 
  			get 
  			{ 
  				return m_ISN ; 
  			}  
  			set 
  			{ 
  				m_ISN = value ; 
  			}  
  		} 
  
  		private int m_Status = 0; 
  		public int Status 
  		{ 
  			get 
  			{ 
  				return m_Status ; 
  			}  
  			set 
  			{ 
  				m_Status = value ; 
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
  
  		private DateTime m_ImportTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ImportTime 
  		{ 
  			get 
  			{ 
  				return m_ImportTime ; 
  			}  
  			set 
  			{ 
  				m_ImportTime = value ; 
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
            string Sql="SELECT * FROM WO_ISNTemp WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_ISNTemp WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ISN=SysConvert.ToString(MasterTable.Rows[0]["ISN"]); 
  				m_Status=SysConvert.ToInt32(MasterTable.Rows[0]["Status"]); 
  				m_Sort=SysConvert.ToInt32(MasterTable.Rows[0]["Sort"]); 
  				m_ImportTime=SysConvert.ToDateTime(MasterTable.Rows[0]["ImportTime"]); 
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
