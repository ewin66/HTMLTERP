using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_FormListDB实体类
	/// 作者:陈加海
	/// 创建日期:2014/7/21
	/// </summary>
	public sealed class FormListDB : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FormListDB()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FormListDB(IDBTransAccess p_SqlCmd)
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
  
  		private string m_FormNM = string.Empty ; 
  		public string FormNM 
  		{ 
  			get 
  			{ 
  				return m_FormNM ; 
  			}  
  			set 
  			{ 
  				m_FormNM = value ; 
  			}  
  		} 
  
  		private int m_WHTypeID = 0; 
  		public int WHTypeID 
  		{ 
  			get 
  			{ 
  				return m_WHTypeID ; 
  			}  
  			set 
  			{ 
  				m_WHTypeID = value ; 
  			}  
  		} 
  
  		private string m_DefaultWHID = string.Empty ; 
  		public string DefaultWHID 
  		{ 
  			get 
  			{ 
  				return m_DefaultWHID ; 
  			}  
  			set 
  			{ 
  				m_DefaultWHID = value ; 
  			}  
  		} 
  
  		private int m_FormNoControlID = 0; 
  		public int FormNoControlID 
  		{ 
  			get 
  			{ 
  				return m_FormNoControlID ; 
  			}  
  			set 
  			{ 
  				m_FormNoControlID = value ; 
  			}  
  		} 
  
  		private int m_WHDBFlag = 0; 
  		public int WHDBFlag 
  		{ 
  			get 
  			{ 
  				return m_WHDBFlag ; 
  			}  
  			set 
  			{ 
  				m_WHDBFlag = value ; 
  			}  
  		} 
  
  		private int m_SODBFlag = 0; 
  		public int SODBFlag 
  		{ 
  			get 
  			{ 
  				return m_SODBFlag ; 
  			}  
  			set 
  			{ 
  				m_SODBFlag = value ; 
  			}  
  		} 
  
  		private int m_OutFormListID = 0; 
  		public int OutFormListID 
  		{ 
  			get 
  			{ 
  				return m_OutFormListID ; 
  			}  
  			set 
  			{ 
  				m_OutFormListID = value ; 
  			}  
  		} 
  
  		private int m_InFormListID = 0; 
  		public int InFormListID 
  		{ 
  			get 
  			{ 
  				return m_InFormListID ; 
  			}  
  			set 
  			{ 
  				m_InFormListID = value ; 
  			}  
  		} 
  
  		private int m_XMFlag = 0; 
  		public int XMFlag 
  		{ 
  			get 
  			{ 
  				return m_XMFlag ; 
  			}  
  			set 
  			{ 
  				m_XMFlag = value ; 
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
            string Sql="SELECT * FROM Enum_FormListDB WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_FormListDB WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNM=SysConvert.ToString(MasterTable.Rows[0]["FormNM"]); 
  				m_WHTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["WHTypeID"]); 
  				m_DefaultWHID=SysConvert.ToString(MasterTable.Rows[0]["DefaultWHID"]); 
  				m_FormNoControlID=SysConvert.ToInt32(MasterTable.Rows[0]["FormNoControlID"]); 
  				m_WHDBFlag=SysConvert.ToInt32(MasterTable.Rows[0]["WHDBFlag"]); 
  				m_SODBFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SODBFlag"]); 
  				m_OutFormListID=SysConvert.ToInt32(MasterTable.Rows[0]["OutFormListID"]); 
  				m_InFormListID=SysConvert.ToInt32(MasterTable.Rows[0]["InFormListID"]); 
  				m_XMFlag=SysConvert.ToInt32(MasterTable.Rows[0]["XMFlag"]); 
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
