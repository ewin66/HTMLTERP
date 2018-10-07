using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：BBS_InfoMainHis实体类
	/// 作者:章文强
	/// 创建日期:2012/7/21
	/// </summary>
	public sealed class InfoMainHis : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public InfoMainHis()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public InfoMainHis(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "BBS_InfoMainHis";
		 
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
  			}  
  		} 
  
  		private string m_OPContext = string.Empty ; 
  		public string OPContext 
  		{ 
  			get 
  			{ 
  				return m_OPContext ; 
  			}  
  			set 
  			{ 
  				m_OPContext = value ; 
  			}  
  		} 
  
  		private DateTime m_OPTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OPTime 
  		{ 
  			get 
  			{ 
  				return m_OPTime ; 
  			}  
  			set 
  			{ 
  				m_OPTime = value ; 
  			}  
  		} 
  
  		private string m_OP = string.Empty ; 
  		public string OP 
  		{ 
  			get 
  			{ 
  				return m_OP ; 
  			}  
  			set 
  			{ 
  				m_OP = value ; 
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
            string Sql="SELECT * FROM BBS_InfoMainHis WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM BBS_InfoMainHis WHERE "+ "MainID="+SysString.ToDBString(m_MainID)+" AND Seq="+SysString.ToDBString(m_Seq);
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
                m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_OPContext=SysConvert.ToString(MasterTable.Rows[0]["OPContext"]); 
  				m_OPTime=SysConvert.ToDateTime(MasterTable.Rows[0]["OPTime"]); 
  				m_OP=SysConvert.ToString(MasterTable.Rows[0]["OP"]); 
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
