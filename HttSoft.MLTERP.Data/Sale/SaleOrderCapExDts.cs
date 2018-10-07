using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_SaleOrderCapExDts实体类
	/// 作者:章文强
	/// 创建日期:2012/7/30
	/// </summary>
	public sealed class SaleOrderCapExDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrderCapExDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderCapExDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_SaleOrderCapExDts";
		 
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
  
  		private string m_ExCapName = string.Empty ; 
  		public string ExCapName 
  		{ 
  			get 
  			{ 
  				return m_ExCapName ; 
  			}  
  			set 
  			{ 
  				m_ExCapName = value ; 
  			}  
  		} 
  
  		private string m_ExItemCode = string.Empty ; 
  		public string ExItemCode 
  		{ 
  			get 
  			{ 
  				return m_ExItemCode ; 
  			}  
  			set 
  			{ 
  				m_ExItemCode = value ; 
  			}  
  		} 
  
  		private int m_ExPayStepTypeID = 0; 
  		public int ExPayStepTypeID 
  		{ 
  			get 
  			{ 
  				return m_ExPayStepTypeID ; 
  			}  
  			set 
  			{ 
  				m_ExPayStepTypeID = value ; 
  			}  
  		} 
  
  		private decimal m_ExPayPer = 0; 
  		public decimal ExPayPer 
  		{ 
  			get 
  			{ 
  				return m_ExPayPer ; 
  			}  
  			set 
  			{ 
  				m_ExPayPer = value ; 
  			}  
  		} 
  
  		private decimal m_ExPayAmount = 0; 
  		public decimal ExPayAmount 
  		{ 
  			get 
  			{ 
  				return m_ExPayAmount ; 
  			}  
  			set 
  			{ 
  				m_ExPayAmount = value ; 
  			}  
  		} 
  
  		private DateTime m_ExPayLimitDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ExPayLimitDate 
  		{ 
  			get 
  			{ 
  				return m_ExPayLimitDate ; 
  			}  
  			set 
  			{ 
  				m_ExPayLimitDate = value ; 
  			}  
  		} 
  
  		private string m_ExRemark = string.Empty ; 
  		public string ExRemark 
  		{ 
  			get 
  			{ 
  				return m_ExRemark ; 
  			}  
  			set 
  			{ 
  				m_ExRemark = value ; 
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
            string Sql="SELECT * FROM Sale_SaleOrderCapExDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrderCapExDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ExCapName=SysConvert.ToString(MasterTable.Rows[0]["ExCapName"]); 
  				m_ExItemCode=SysConvert.ToString(MasterTable.Rows[0]["ExItemCode"]); 
  				m_ExPayStepTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ExPayStepTypeID"]); 
  				m_ExPayPer=SysConvert.ToDecimal(MasterTable.Rows[0]["ExPayPer"]); 
  				m_ExPayAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["ExPayAmount"]); 
  				m_ExPayLimitDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ExPayLimitDate"]); 
  				m_ExRemark=SysConvert.ToString(MasterTable.Rows[0]["ExRemark"]); 
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
