using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Enum_OrderStep实体类
	/// 作者:周富春
	/// 创建日期:2014/10/17
	/// </summary>
	public sealed class OrderStep : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OrderStep()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OrderStep(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Enum_OrderStep";
		 
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
  
  		private string m_ColorStr = string.Empty ; 
  		public string ColorStr 
  		{ 
  			get 
  			{ 
  				return m_ColorStr ; 
  			}  
  			set 
  			{ 
  				m_ColorStr = value ; 
  			}  
  		} 
  
  		private int m_NextStepID = 0; 
  		public int NextStepID 
  		{ 
  			get 
  			{ 
  				return m_NextStepID ; 
  			}  
  			set 
  			{ 
  				m_NextStepID = value ; 
  			}  
  		} 
  
  		private int m_SaleProcedureID = 0; 
  		public int SaleProcedureID 
  		{ 
  			get 
  			{ 
  				return m_SaleProcedureID ; 
  			}  
  			set 
  			{ 
  				m_SaleProcedureID = value ; 
  			}  
  		} 
  
  		private int m_FormListID = 0; 
  		public int FormListID 
  		{ 
  			get 
  			{ 
  				return m_FormListID ; 
  			}  
  			set 
  			{ 
  				m_FormListID = value ; 
  			}  
  		} 
  
  		private int m_DZFlag = 0; 
  		public int DZFlag 
  		{ 
  			get 
  			{ 
  				return m_DZFlag ; 
  			}  
  			set 
  			{ 
  				m_DZFlag = value ; 
  			}  
  		} 
  
  		private int m_InvoiceFlag = 0; 
  		public int InvoiceFlag 
  		{ 
  			get 
  			{ 
  				return m_InvoiceFlag ; 
  			}  
  			set 
  			{ 
  				m_InvoiceFlag = value ; 
  			}  
  		} 
  
  		private int m_RecAmountFlag = 0; 
  		public int RecAmountFlag 
  		{ 
  			get 
  			{ 
  				return m_RecAmountFlag ; 
  			}  
  			set 
  			{ 
  				m_RecAmountFlag = value ; 
  			}  
  		} 
  
  		private int m_FinishFlag = 0; 
  		public int FinishFlag 
  		{ 
  			get 
  			{ 
  				return m_FinishFlag ; 
  			}  
  			set 
  			{ 
  				m_FinishFlag = value ; 
  			}  
  		} 
  
  		private int m_CancelFlag = 0; 
  		public int CancelFlag 
  		{ 
  			get 
  			{ 
  				return m_CancelFlag ; 
  			}  
  			set 
  			{ 
  				m_CancelFlag = value ; 
  			}  
  		} 
  
  		private int m_ShowFlag = 0; 
  		public int ShowFlag 
  		{ 
  			get 
  			{ 
  				return m_ShowFlag ; 
  			}  
  			set 
  			{ 
  				m_ShowFlag = value ; 
  			}  
  		} 
  
  		private int m_CheckItemFlag = 0; 
  		public int CheckItemFlag 
  		{ 
  			get 
  			{ 
  				return m_CheckItemFlag ; 
  			}  
  			set 
  			{ 
  				m_CheckItemFlag = value ; 
  			}  
  		} 
  
  		private int m_CheckColorFlag = 0; 
  		public int CheckColorFlag 
  		{ 
  			get 
  			{ 
  				return m_CheckColorFlag ; 
  			}  
  			set 
  			{ 
  				m_CheckColorFlag = value ; 
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
  
  		private int m_SaleProcedureID2 = 0; 
  		public int SaleProcedureID2 
  		{ 
  			get 
  			{ 
  				return m_SaleProcedureID2 ; 
  			}  
  			set 
  			{ 
  				m_SaleProcedureID2 = value ; 
  			}  
  		} 
  
  		private int m_FormListID2 = 0; 
  		public int FormListID2 
  		{ 
  			get 
  			{ 
  				return m_FormListID2 ; 
  			}  
  			set 
  			{ 
  				m_FormListID2 = value ; 
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
            string Sql="SELECT * FROM Enum_OrderStep WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Enum_OrderStep WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ColorStr=SysConvert.ToString(MasterTable.Rows[0]["ColorStr"]); 
  				m_NextStepID=SysConvert.ToInt32(MasterTable.Rows[0]["NextStepID"]); 
  				m_SaleProcedureID=SysConvert.ToInt32(MasterTable.Rows[0]["SaleProcedureID"]); 
  				m_FormListID=SysConvert.ToInt32(MasterTable.Rows[0]["FormListID"]); 
  				m_DZFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DZFlag"]); 
  				m_InvoiceFlag=SysConvert.ToInt32(MasterTable.Rows[0]["InvoiceFlag"]); 
  				m_RecAmountFlag=SysConvert.ToInt32(MasterTable.Rows[0]["RecAmountFlag"]); 
  				m_FinishFlag=SysConvert.ToInt32(MasterTable.Rows[0]["FinishFlag"]); 
  				m_CancelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CancelFlag"]); 
  				m_ShowFlag=SysConvert.ToInt32(MasterTable.Rows[0]["ShowFlag"]); 
  				m_CheckItemFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CheckItemFlag"]); 
  				m_CheckColorFlag=SysConvert.ToInt32(MasterTable.Rows[0]["CheckColorFlag"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_SaleProcedureID2=SysConvert.ToInt32(MasterTable.Rows[0]["SaleProcedureID2"]); 
  				m_FormListID2=SysConvert.ToInt32(MasterTable.Rows[0]["FormListID2"]); 
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
