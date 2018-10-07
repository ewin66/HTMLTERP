using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_Board实体类
	/// 作者:陈加海
	/// 创建日期:2006-11-09
	/// </summary>
	public sealed class Board : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Board()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Board(IDBTransAccess p_SqlCmd)
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
  
  		private string m_Title = string.Empty ; 
  		public string Title 
  		{ 
  			get 
  			{ 
  				return m_Title ; 
  			}  
  			set 
  			{ 
  				m_Title = value ; 
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
  
  		private DateTime m_SendDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SendDate 
  		{ 
  			get 
  			{ 
  				return m_SendDate ; 
  			}  
  			set 
  			{ 
  				m_SendDate = value ; 
  			}  
  		} 
  
  		private string m_SendOP = string.Empty ; 
  		public string SendOP 
  		{ 
  			get 
  			{ 
  				return m_SendOP ; 
  			}  
  			set 
  			{ 
  				m_SendOP = value ; 
  			}  
  		} 
  
  		private int m_IsShow = 0; 
  		public int IsShow 
  		{ 
  			get 
  			{ 
  				return m_IsShow ; 
  			}  
  			set 
  			{ 
  				m_IsShow = value ; 
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
            string Sql="SELECT * FROM Data_Board WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_Board WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"].ToString()); 
  				m_Title=SysConvert.ToString(MasterTable.Rows[0]["Title"].ToString()); 
  				m_Context=SysConvert.ToString(MasterTable.Rows[0]["Context"].ToString()); 
  				m_SendDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SendDate"].ToString()); 
  				m_SendOP=SysConvert.ToString(MasterTable.Rows[0]["SendOP"].ToString()); 
  				m_IsShow=SysConvert.ToInt32(MasterTable.Rows[0]["IsShow"].ToString()); 
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
