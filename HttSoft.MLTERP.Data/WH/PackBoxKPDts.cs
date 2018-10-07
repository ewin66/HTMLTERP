using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_PackBoxKPDts实体类
	/// 作者:XUSC
	/// 创建日期:2016/1/6
	/// </summary>
	public sealed class PackBoxKPDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public PackBoxKPDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PackBoxKPDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WH_PackBoxKPDts";
		 
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
  
  		private string m_BoxNo = string.Empty ; 
  		public string BoxNo 
  		{ 
  			get 
  			{ 
  				return m_BoxNo ; 
  			}  
  			set 
  			{ 
  				m_BoxNo = value ; 
  			}  
  		} 
  
  		private decimal m_SourceQty = 0; 
  		public decimal SourceQty 
  		{ 
  			get 
  			{ 
  				return m_SourceQty ; 
  			}  
  			set 
  			{ 
  				m_SourceQty = value ; 
  			}  
  		} 
  
  		private decimal m_Qty = 0; 
  		public decimal Qty 
  		{ 
  			get 
  			{ 
  				return m_Qty ; 
  			}  
  			set 
  			{ 
  				m_Qty = value ; 
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
  
  		private string m_ColorNO = string.Empty ; 
  		public string ColorNO 
  		{ 
  			get 
  			{ 
  				return m_ColorNO ; 
  			}  
  			set 
  			{ 
  				m_ColorNO = value ; 
  			}  
  		} 
  
  		private string m_ColorName = string.Empty ; 
  		public string ColorName 
  		{ 
  			get 
  			{ 
  				return m_ColorName ; 
  			}  
  			set 
  			{ 
  				m_ColorName = value ; 
  			}  
  		} 
  
  		private decimal m_SourceWeight = 0; 
  		public decimal SourceWeight 
  		{ 
  			get 
  			{ 
  				return m_SourceWeight ; 
  			}  
  			set 
  			{ 
  				m_SourceWeight = value ; 
  			}  
  		} 
  
  		private decimal m_Weight = 0; 
  		public decimal Weight 
  		{ 
  			get 
  			{ 
  				return m_Weight ; 
  			}  
  			set 
  			{ 
  				m_Weight = value ; 
  			}  
  		} 
  
  		private decimal m_SourceYard = 0; 
  		public decimal SourceYard 
  		{ 
  			get 
  			{ 
  				return m_SourceYard ; 
  			}  
  			set 
  			{ 
  				m_SourceYard = value ; 
  			}  
  		} 
  
  		private decimal m_Yard = 0; 
  		public decimal Yard 
  		{ 
  			get 
  			{ 
  				return m_Yard ; 
  			}  
  			set 
  			{ 
  				m_Yard = value ; 
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
            string Sql="SELECT * FROM WH_PackBoxKPDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_PackBoxKPDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_BoxNo=SysConvert.ToString(MasterTable.Rows[0]["BoxNo"]); 
  				m_SourceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["SourceQty"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ColorNO=SysConvert.ToString(MasterTable.Rows[0]["ColorNO"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_SourceWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["SourceWeight"]); 
  				m_Weight=SysConvert.ToDecimal(MasterTable.Rows[0]["Weight"]); 
  				m_SourceYard=SysConvert.ToDecimal(MasterTable.Rows[0]["SourceYard"]); 
  				m_Yard=SysConvert.ToDecimal(MasterTable.Rows[0]["Yard"]); 
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
