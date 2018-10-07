using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_Unit实体类
	/// 作者:qiuchao
	/// 创建日期:2014/6/27
	/// </summary>
	public sealed class Unit : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public Unit()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public Unit(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Enum_Unit";
		 
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
  
  		private string m_NameEN = string.Empty ; 
  		public string NameEN 
  		{ 
  			get 
  			{ 
  				return m_NameEN ; 
  			}  
  			set 
  			{ 
  				m_NameEN = value ; 
  			}  
  		} 
  
  		private string m_Formula = string.Empty ; 
  		public string Formula 
  		{ 
  			get 
  			{ 
  				return m_Formula ; 
  			}  
  			set 
  			{ 
  				m_Formula = value ; 
  			}  
  		} 
  
  		private string m_BaseUnit = string.Empty ; 
  		public string BaseUnit 
  		{ 
  			get 
  			{ 
  				return m_BaseUnit ; 
  			}  
  			set 
  			{ 
  				m_BaseUnit = value ; 
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
  
  		private string m_UnitQtyName = string.Empty ; 
  		public string UnitQtyName 
  		{ 
  			get 
  			{ 
  				return m_UnitQtyName ; 
  			}  
  			set 
  			{ 
  				m_UnitQtyName = value ; 
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
            string Sql="SELECT * FROM Enum_Unit WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_Unit WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_NameEN=SysConvert.ToString(MasterTable.Rows[0]["NameEN"]); 
  				m_Formula=SysConvert.ToString(MasterTable.Rows[0]["Formula"]); 
  				m_BaseUnit=SysConvert.ToString(MasterTable.Rows[0]["BaseUnit"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UnitQtyName=SysConvert.ToString(MasterTable.Rows[0]["UnitQtyName"]); 
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
