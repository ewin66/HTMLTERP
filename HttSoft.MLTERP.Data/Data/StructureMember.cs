using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_StructureMember实体类
	/// 作者:章文强
	/// 创建日期:2014/6/4
	/// </summary>
	public sealed class StructureMember : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public StructureMember()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public StructureMember(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_StructureMember";
		 
  		private int m_StuctureID = 0; 
  		public int StuctureID 
  		{ 
  			get 
  			{ 
  				return m_StuctureID ; 
  			}  
  			set 
  			{ 
  				m_StuctureID = value ; 
  			}  
  		} 
  
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
  
  		private int m_LeaderFlag = 0; 
  		public int LeaderFlag 
  		{ 
  			get 
  			{ 
  				return m_LeaderFlag ; 
  			}  
  			set 
  			{ 
  				m_LeaderFlag = value ; 
  			}  
  		} 
  
  		private int m_LeaderAttnFlag = 0; 
  		public int LeaderAttnFlag 
  		{ 
  			get 
  			{ 
  				return m_LeaderAttnFlag ; 
  			}  
  			set 
  			{ 
  				m_LeaderAttnFlag = value ; 
  			}  
  		} 
  
  		private int m_DSort = 0; 
  		public int DSort 
  		{ 
  			get 
  			{ 
  				return m_DSort ; 
  			}  
  			set 
  			{ 
  				m_DSort = value ; 
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
            string Sql="SELECT * FROM Data_StructureMember WHERE "+ "StuctureID="+SysString.ToDBString(m_StuctureID)+" AND OPID="+SysString.ToDBString(m_OPID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_StructureMember WHERE "+ "StuctureID="+SysString.ToDBString(m_StuctureID)+" AND OPID="+SysString.ToDBString(m_OPID);
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
                m_StuctureID=SysConvert.ToInt32(MasterTable.Rows[0]["StuctureID"]); 
  				m_OPID=SysConvert.ToString(MasterTable.Rows[0]["OPID"]); 
  				m_LeaderFlag=SysConvert.ToInt32(MasterTable.Rows[0]["LeaderFlag"]); 
  				m_LeaderAttnFlag=SysConvert.ToInt32(MasterTable.Rows[0]["LeaderAttnFlag"]); 
  				m_DSort=SysConvert.ToInt32(MasterTable.Rows[0]["DSort"]); 
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
