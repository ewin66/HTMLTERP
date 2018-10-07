using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Buy_ItemBuyFollowDts实体类
	/// 作者:刘德苏
	/// 创建日期:2012/5/3
	/// </summary>
	public sealed class ItemBuyFollowDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemBuyFollowDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemBuyFollowDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Buy_ItemBuyFollowDts";
		 
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

        private int m_DLoadDtsID = 0;

        public int DLoadDtsID
        {
            get { return m_DLoadDtsID; }
            set { m_DLoadDtsID = value; }
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
  
  		private int m_ProcStepID = 0; 
  		public int ProcStepID 
  		{ 
  			get 
  			{ 
  				return m_ProcStepID ; 
  			}  
  			set 
  			{ 
  				m_ProcStepID = value ; 
  			}  
  		} 
  
  		private string m_CheckItem = string.Empty ; 
  		public string CheckItem 
  		{ 
  			get 
  			{ 
  				return m_CheckItem ; 
  			}  
  			set 
  			{ 
  				m_CheckItem = value ; 
  			}  
  		} 
  
  		private DateTime m_FinishTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FinishTime 
  		{ 
  			get 
  			{ 
  				return m_FinishTime ; 
  			}  
  			set 
  			{ 
  				m_FinishTime = value ; 
  			}  
  		} 
  
  		private DateTime m_FactTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FactTime 
  		{ 
  			get 
  			{ 
  				return m_FactTime ; 
  			}  
  			set 
  			{ 
  				m_FactTime = value ; 
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
            string Sql="SELECT * FROM Buy_ItemBuyFollowDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Buy_ItemBuyFollowDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]);
                m_DLoadDtsID = SysConvert.ToInt32(MasterTable.Rows[0]["DLoadDtsID"]);
  				m_ProcStepID=SysConvert.ToInt32(MasterTable.Rows[0]["ProcStepID"]); 
  				m_CheckItem=SysConvert.ToString(MasterTable.Rows[0]["CheckItem"]); 
  				m_FinishTime=SysConvert.ToDateTime(MasterTable.Rows[0]["FinishTime"]); 
  				m_FactTime=SysConvert.ToDateTime(MasterTable.Rows[0]["FactTime"]); 
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
