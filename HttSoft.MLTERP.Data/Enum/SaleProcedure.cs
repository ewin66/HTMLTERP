using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_SaleProcedure实体类
	/// 作者:chengtb
	/// 创建日期:2014-5-4
	/// </summary>
	public sealed class SaleProcedure : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleProcedure()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleProcedure(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Enum_SaleProcedure";
		 
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
  
  		private int m_JGUseFlag = 0; 
  		public int JGUseFlag 
  		{ 
  			get 
  			{ 
  				return m_JGUseFlag ; 
  			}  
  			set 
  			{ 
  				m_JGUseFlag = value ; 
  			}  
  		} 
  
  		private int m_JGItemTypeID = 0; 
  		public int JGItemTypeID 
  		{ 
  			get 
  			{ 
  				return m_JGItemTypeID ; 
  			}  
  			set 
  			{ 
  				m_JGItemTypeID = value ; 
  			}  
  		} 
  
  		private string m_JGWHIDDefault = string.Empty ; 
  		public string JGWHIDDefault 
  		{ 
  			get 
  			{ 
  				return m_JGWHIDDefault ; 
  			}  
  			set 
  			{ 
  				m_JGWHIDDefault = value ; 
  			}  
  		} 
  
  		private int m_JGFormListID = 0; 
  		public int JGFormListID 
  		{ 
  			get 
  			{ 
  				return m_JGFormListID ; 
  			}  
  			set 
  			{ 
  				m_JGFormListID = value ; 
  			}  
  		} 
  
  		private int m_PackCheckFlag = 0; 
  		public int PackCheckFlag 
  		{ 
  			get 
  			{ 
  				return m_PackCheckFlag ; 
  			}  
  			set 
  			{ 
  				m_PackCheckFlag = value ; 
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
            string Sql="SELECT * FROM Enum_SaleProcedure WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_SaleProcedure WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ShowFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ShowFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_JGUseFlag=SysConvert.ToInt32(MasterTable.Rows[0]["JGUseFlag"]); 
  				m_JGItemTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["JGItemTypeID"]); 
  				m_JGWHIDDefault=SysConvert.ToString(MasterTable.Rows[0]["JGWHIDDefault"]); 
  				m_JGFormListID=SysConvert.ToInt32(MasterTable.Rows[0]["JGFormListID"]); 
  				m_PackCheckFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PackCheckFlag"]); 
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
