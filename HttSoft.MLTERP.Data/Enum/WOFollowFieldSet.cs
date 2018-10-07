using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_WOFollowFieldSet实体类
	/// 作者:周富春
	/// 创建日期:2014/8/1
	/// </summary>
	public sealed class WOFollowFieldSet : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public WOFollowFieldSet()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WOFollowFieldSet(IDBTransAccess p_SqlCmd)
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
  
  		private int m_FTableType = 0; 
  		public int FTableType 
  		{ 
  			get 
  			{ 
  				return m_FTableType ; 
  			}  
  			set 
  			{ 
  				m_FTableType = value ; 
  			}  
  		} 
  
  		private int m_DFieldName = 0; 
  		public int DFieldName 
  		{ 
  			get 
  			{ 
  				return m_DFieldName ; 
  			}  
  			set 
  			{ 
  				m_DFieldName = value ; 
  			}  
  		} 
  
  		private string m_DCaption = string.Empty ; 
  		public string DCaption 
  		{ 
  			get 
  			{ 
  				return m_DCaption ; 
  			}  
  			set 
  			{ 
  				m_DCaption = value ; 
  			}  
  		} 
  
  		private int m_DShowFlag = 0; 
  		public int DShowFlag 
  		{ 
  			get 
  			{ 
  				return m_DShowFlag ; 
  			}  
  			set 
  			{ 
  				m_DShowFlag = value ; 
  			}  
  		} 
  
  		private string m_UpdateMainFieldName = string.Empty ; 
  		public string UpdateMainFieldName 
  		{ 
  			get 
  			{ 
  				return m_UpdateMainFieldName ; 
  			}  
  			set 
  			{ 
  				m_UpdateMainFieldName = value ; 
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
            string Sql="SELECT * FROM Enum_WOFollowFieldSet WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_WOFollowFieldSet WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FTableType=SysConvert.ToInt32(MasterTable.Rows[0]["FTableType"]); 
  				m_DFieldName=SysConvert.ToInt32(MasterTable.Rows[0]["DFieldName"]); 
  				m_DCaption=SysConvert.ToString(MasterTable.Rows[0]["DCaption"]); 
  				m_DShowFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DShowFlag"]); 
  				m_UpdateMainFieldName=SysConvert.ToString(MasterTable.Rows[0]["UpdateMainFieldName"]); 
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
