using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_WOFollowStep实体类
	/// 作者:周富春
	/// 创建日期:2014/8/1
	/// </summary>
	public sealed class WOFollowStep : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WOFollowStep()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WOFollowStep(IDBTransAccess p_SqlCmd)
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
  
  		private int m_WOFollowTypeID = 0; 
  		public int WOFollowTypeID 
  		{ 
  			get 
  			{ 
  				return m_WOFollowTypeID ; 
  			}  
  			set 
  			{ 
  				m_WOFollowTypeID = value ; 
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
  
  		private string m_ColorStr = string.Empty ; 
  		public string ColorStr 
  		{ 
  			get 
  			{ 
  				return m_ColorStr ; 
  			}  
  			set 
  			{ 
  				m_ColorStr = value ; 
  			}  
  		} 
  
  		private int m_MainFlag = 0; 
  		public int MainFlag 
  		{ 
  			get 
  			{ 
  				return m_MainFlag ; 
  			}  
  			set 
  			{ 
  				m_MainFlag = value ; 
  			}  
  		} 
  
  		private int m_SubFlag = 0; 
  		public int SubFlag 
  		{ 
  			get 
  			{ 
  				return m_SubFlag ; 
  			}  
  			set 
  			{ 
  				m_SubFlag = value ; 
  			}  
  		} 
  
  		private int m_SubUpdateMainFlag = 0; 
  		public int SubUpdateMainFlag 
  		{ 
  			get 
  			{ 
  				return m_SubUpdateMainFlag ; 
  			}  
  			set 
  			{ 
  				m_SubUpdateMainFlag = value ; 
  			}  
  		} 
  
  		private int m_GnsUpdateSubFlag = 0; 
  		public int GnsUpdateSubFlag 
  		{ 
  			get 
  			{ 
  				return m_GnsUpdateSubFlag ; 
  			}  
  			set 
  			{ 
  				m_GnsUpdateSubFlag = value ; 
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
            string Sql="SELECT * FROM Enum_WOFollowStep WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_WOFollowStep WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_WOFollowTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WOFollowTypeID"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_ColorStr=SysConvert.ToString(MasterTable.Rows[0]["ColorStr"]); 
  				m_MainFlag=SysConvert.ToInt32(MasterTable.Rows[0]["MainFlag"]); 
  				m_SubFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubFlag"]); 
  				m_SubUpdateMainFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubUpdateMainFlag"]); 
  				m_GnsUpdateSubFlag=SysConvert.ToInt32(MasterTable.Rows[0]["GnsUpdateSubFlag"]); 
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
