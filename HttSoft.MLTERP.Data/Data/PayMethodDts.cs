using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_PayMethodDts实体类
	/// 作者:章文强
	/// 创建日期:2012/7/30
	/// </summary>
	public sealed class PayMethodDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public PayMethodDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PayMethodDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Data_PayMethodDts";
		 
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
  
  		private decimal m_PayPer = 0; 
  		public decimal PayPer 
  		{ 
  			get 
  			{ 
  				return m_PayPer ; 
  			}  
  			set 
  			{ 
  				m_PayPer = value ; 
  			}  
  		} 
  
  		private int m_PayDateTypeInt = 0; 
  		public int PayDateTypeInt 
  		{ 
  			get 
  			{ 
  				return m_PayDateTypeInt ; 
  			}  
  			set 
  			{ 
  				m_PayDateTypeInt = value ; 
  			}  
  		} 
  
  		private int m_DelayDayNum = 0; 
  		public int DelayDayNum 
  		{ 
  			get 
  			{ 
  				return m_DelayDayNum ; 
  			}  
  			set 
  			{ 
  				m_DelayDayNum = value ; 
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
  
  		private int m_PayStepTypeID = 0; 
  		public int PayStepTypeID 
  		{ 
  			get 
  			{ 
  				return m_PayStepTypeID ; 
  			}  
  			set 
  			{ 
  				m_PayStepTypeID = value ; 
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
            string Sql="SELECT * FROM Data_PayMethodDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_PayMethodDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_PayPer=SysConvert.ToDecimal(MasterTable.Rows[0]["PayPer"]); 
  				m_PayDateTypeInt=SysConvert.ToInt32(MasterTable.Rows[0]["PayDateTypeInt"]); 
  				m_DelayDayNum=SysConvert.ToInt32(MasterTable.Rows[0]["DelayDayNum"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_PayStepTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["PayStepTypeID"]); 
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
