using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_ItemGBUPHis实体类
	/// 作者:章文强
	/// 创建日期:2012-5-31
	/// </summary>
	public sealed class ItemGBUPHis : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemGBUPHis()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemGBUPHis(IDBTransAccess p_SqlCmd)
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
  
  		private string m_GBCode = string.Empty ; 
  		public string GBCode 
  		{ 
  			get 
  			{ 
  				return m_GBCode ; 
  			}  
  			set 
  			{ 
  				m_GBCode = value ; 
  			}  
  		} 
  
  		private int m_GBStatusIDS = 0; 
  		public int GBStatusIDS 
  		{ 
  			get 
  			{ 
  				return m_GBStatusIDS ; 
  			}  
  			set 
  			{ 
  				m_GBStatusIDS = value ; 
  			}  
  		} 
  
  		private int m_GBStatusIDE = 0; 
  		public int GBStatusIDE 
  		{ 
  			get 
  			{ 
  				return m_GBStatusIDE ; 
  			}  
  			set 
  			{ 
  				m_GBStatusIDE = value ; 
  			}  
  		} 
  
  		private DateTime m_GDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime GDate 
  		{ 
  			get 
  			{ 
  				return m_GDate ; 
  			}  
  			set 
  			{ 
  				m_GDate = value ; 
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
  
  		private string m_UpOPID = string.Empty ; 
  		public string UpOPID 
  		{ 
  			get 
  			{ 
  				return m_UpOPID ; 
  			}  
  			set 
  			{ 
  				m_UpOPID = value ; 
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
            string Sql="SELECT * FROM Data_ItemGBUPHis WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_ItemGBUPHis WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_GBCode=SysConvert.ToString(MasterTable.Rows[0]["GBCode"]); 
  				m_GBStatusIDS=SysConvert.ToInt32(MasterTable.Rows[0]["GBStatusIDS"]); 
  				m_GBStatusIDE=SysConvert.ToInt32(MasterTable.Rows[0]["GBStatusIDE"]); 
  				m_GDate=SysConvert.ToDateTime(MasterTable.Rows[0]["GDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_UpOPID=SysConvert.ToString(MasterTable.Rows[0]["UpOPID"]); 
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
