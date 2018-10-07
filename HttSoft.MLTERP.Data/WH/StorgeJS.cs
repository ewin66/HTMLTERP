using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_StorgeJS实体类
	/// 作者:陈加海
	/// 创建日期:2012-5-10
	/// </summary>
	public sealed class StorgeJS : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public StorgeJS()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public StorgeJS(IDBTransAccess p_SqlCmd)
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
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private DateTime m_JSDateS = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JSDateS 
  		{ 
  			get 
  			{ 
  				return m_JSDateS ; 
  			}  
  			set 
  			{ 
  				m_JSDateS = value ; 
  			}  
  		} 
  
  		private DateTime m_JSDateE = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JSDateE 
  		{ 
  			get 
  			{ 
  				return m_JSDateE ; 
  			}  
  			set 
  			{ 
  				m_JSDateE = value ; 
  			}  
  		} 
  
  		private int m_JSFlag = 0; 
  		public int JSFlag 
  		{ 
  			get 
  			{ 
  				return m_JSFlag ; 
  			}  
  			set 
  			{ 
  				m_JSFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_JSTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JSTime 
  		{ 
  			get 
  			{ 
  				return m_JSTime ; 
  			}  
  			set 
  			{ 
  				m_JSTime = value ; 
  			}  
  		} 
  
  		private string m_FormOPID = string.Empty ; 
  		public string FormOPID 
  		{ 
  			get 
  			{ 
  				return m_FormOPID ; 
  			}  
  			set 
  			{ 
  				m_FormOPID = value ; 
  			}  
  		} 
  
  		private string m_JSOPID = string.Empty ; 
  		public string JSOPID 
  		{ 
  			get 
  			{ 
  				return m_JSOPID ; 
  			}  
  			set 
  			{ 
  				m_JSOPID = value ; 
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
  
  		private int m_SubmitFlag = 0; 
  		public int SubmitFlag 
  		{ 
  			get 
  			{ 
  				return m_SubmitFlag ; 
  			}  
  			set 
  			{ 
  				m_SubmitFlag = value ; 
  			}  
  		} 
  
  		private int m_DelFlag = 0; 
  		public int DelFlag 
  		{ 
  			get 
  			{ 
  				return m_DelFlag ; 
  			}  
  			set 
  			{ 
  				m_DelFlag = value ; 
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
            string Sql="SELECT * FROM WH_StorgeJS WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_StorgeJS WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_JSDateS=SysConvert.ToDateTime(MasterTable.Rows[0]["JSDateS"]); 
  				m_JSDateE=SysConvert.ToDateTime(MasterTable.Rows[0]["JSDateE"]); 
  				m_JSFlag=SysConvert.ToInt32(MasterTable.Rows[0]["JSFlag"]); 
  				m_JSTime=SysConvert.ToDateTime(MasterTable.Rows[0]["JSTime"]); 
  				m_FormOPID=SysConvert.ToString(MasterTable.Rows[0]["FormOPID"]); 
  				m_JSOPID=SysConvert.ToString(MasterTable.Rows[0]["JSOPID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
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
