using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_TowelProductionPlanDtsStep实体类
	/// 作者:zhp
	/// 创建日期:2016/9/7
	/// </summary>
	public sealed class TowelProductionPlanDtsStep : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public TowelProductionPlanDtsStep()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public TowelProductionPlanDtsStep(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_TowelProductionPlanDtsStep";
		 
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
  
  		private int m_DtsID = 0; 
  		public int DtsID 
  		{ 
  			get 
  			{ 
  				return m_DtsID ; 
  			}  
  			set 
  			{ 
  				m_DtsID = value ; 
  			}  
  		} 
  
  		private int m_SubSeq = 0; 
  		public int SubSeq 
  		{ 
  			get 
  			{ 
  				return m_SubSeq ; 
  			}  
  			set 
  			{ 
  				m_SubSeq = value ; 
  			}  
  		} 
  
  		private int m_StepID = 0; 
  		public int StepID 
  		{ 
  			get 
  			{ 
  				return m_StepID ; 
  			}  
  			set 
  			{ 
  				m_StepID = value ; 
  			}  
  		} 
  
  		private string m_CardNo = string.Empty ; 
  		public string CardNo 
  		{ 
  			get 
  			{ 
  				return m_CardNo ; 
  			}  
  			set 
  			{ 
  				m_CardNo = value ; 
  			}  
  		} 
  
  		private decimal m_RecQty = 0; 
  		public decimal RecQty 
  		{ 
  			get 
  			{ 
  				return m_RecQty ; 
  			}  
  			set 
  			{ 
  				m_RecQty = value ; 
  			}  
  		} 
  
  		private DateTime m_RecDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime RecDate 
  		{ 
  			get 
  			{ 
  				return m_RecDate ; 
  			}  
  			set 
  			{ 
  				m_RecDate = value ; 
  			}  
  		} 
  
  		private decimal m_ZPQty = 0; 
  		public decimal ZPQty 
  		{ 
  			get 
  			{ 
  				return m_ZPQty ; 
  			}  
  			set 
  			{ 
  				m_ZPQty = value ; 
  			}  
  		} 
  
  		private decimal m_CPQty = 0; 
  		public decimal CPQty 
  		{ 
  			get 
  			{ 
  				return m_CPQty ; 
  			}  
  			set 
  			{ 
  				m_CPQty = value ; 
  			}  
  		} 
  
  		private DateTime m_CompleteDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CompleteDate 
  		{ 
  			get 
  			{ 
  				return m_CompleteDate ; 
  			}  
  			set 
  			{ 
  				m_CompleteDate = value ; 
  			}  
  		} 
  
  		private string m_MakeOPID = string.Empty ; 
  		public string MakeOPID 
  		{ 
  			get 
  			{ 
  				return m_MakeOPID ; 
  			}  
  			set 
  			{ 
  				m_MakeOPID = value ; 
  			}  
  		} 
  
  		private string m_ProOPID = string.Empty ; 
  		public string ProOPID 
  		{ 
  			get 
  			{ 
  				return m_ProOPID ; 
  			}  
  			set 
  			{ 
  				m_ProOPID = value ; 
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
            string Sql="SELECT * FROM WO_TowelProductionPlanDtsStep WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_TowelProductionPlanDtsStep WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DtsID=SysConvert.ToInt32(MasterTable.Rows[0]["DtsID"]); 
  				m_SubSeq=SysConvert.ToInt32(MasterTable.Rows[0]["SubSeq"]); 
  				m_StepID=SysConvert.ToInt32(MasterTable.Rows[0]["StepID"]); 
  				m_CardNo=SysConvert.ToString(MasterTable.Rows[0]["CardNo"]); 
  				m_RecQty=SysConvert.ToDecimal(MasterTable.Rows[0]["RecQty"]); 
  				m_RecDate=SysConvert.ToDateTime(MasterTable.Rows[0]["RecDate"]); 
  				m_ZPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["ZPQty"]); 
  				m_CPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CPQty"]); 
  				m_CompleteDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CompleteDate"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_ProOPID=SysConvert.ToString(MasterTable.Rows[0]["ProOPID"]); 
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
