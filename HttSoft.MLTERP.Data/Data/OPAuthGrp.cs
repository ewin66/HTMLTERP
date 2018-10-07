using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_OPAuthGrp实体类
	/// 作者:周富春
	/// 创建日期:2009-7-16
	/// </summary>
	public sealed class OPAuthGrp : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OPAuthGrp()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OPAuthGrp(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
  		private string m_OPID = string.Empty ; 
  		public string OPID 
  		{ 
  			get 
  			{ 
  				return m_OPID ; 
  			}  
  			set 
  			{ 
  				m_OPID = value ; 
  			}  
  		} 
  
  		private int m_AuthGrpID = 0; 
  		public int AuthGrpID 
  		{ 
  			get 
  			{ 
  				return m_AuthGrpID ; 
  			}  
  			set 
  			{ 
  				m_AuthGrpID = value ; 
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
            string Sql="SELECT * FROM Data_OPAuthGrp WHERE "+ "OPID="+SysString.ToDBString(m_OPID)+" AND AuthGrpID="+SysString.ToDBString(m_AuthGrpID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_OPAuthGrp WHERE "+ "OPID="+SysString.ToDBString(m_OPID)+" AND AuthGrpID="+SysString.ToDBString(m_AuthGrpID);
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
                m_OPID=SysConvert.ToString(MasterTable.Rows[0]["OPID"]); 
  				m_AuthGrpID=SysConvert.ToInt32(MasterTable.Rows[0]["AuthGrpID"]); 
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
