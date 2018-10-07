using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_ProductionPlanDts2实体类
	/// 作者:qiuchao
	/// 创建日期:2015/6/18
	/// </summary>
	public sealed class ProductionPlanDts2 : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ProductionPlanDts2()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionPlanDts2(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_ProductionPlanDts2";
		 
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
  
  		private string m_WagonNo = string.Empty ; 
  		public string WagonNo 
  		{ 
  			get 
  			{ 
  				return m_WagonNo ; 
  			}  
  			set 
  			{ 
  				m_WagonNo = value ; 
  			}  
  		} 
  
  		private DateTime m_PBFormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PBFormDate 
  		{ 
  			get 
  			{ 
  				return m_PBFormDate ; 
  			}  
  			set 
  			{ 
  				m_PBFormDate = value ; 
  			}  
  		} 
  
  		private int m_PBieceQty = 0; 
  		public int PBieceQty 
  		{ 
  			get 
  			{ 
  				return m_PBieceQty ; 
  			}  
  			set 
  			{ 
  				m_PBieceQty = value ; 
  			}  
  		} 
  
  		private decimal m_PBQty = 0; 
  		public decimal PBQty 
  		{ 
  			get 
  			{ 
  				return m_PBQty ; 
  			}  
  			set 
  			{ 
  				m_PBQty = value ; 
  			}  
  		} 
  
  		private DateTime m_CPFormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CPFormDate 
  		{ 
  			get 
  			{ 
  				return m_CPFormDate ; 
  			}  
  			set 
  			{ 
  				m_CPFormDate = value ; 
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
  
  		private decimal m_Shrinkage = 0; 
  		public decimal Shrinkage 
  		{ 
  			get 
  			{ 
  				return m_Shrinkage ; 
  			}  
  			set 
  			{ 
  				m_Shrinkage = value ; 
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
  
  		private string m_Batch = string.Empty ; 
  		public string Batch 
  		{ 
  			get 
  			{ 
  				return m_Batch ; 
  			}  
  			set 
  			{ 
  				m_Batch = value ; 
  			}  
  		} 
  
  		private string m_ColorNum = string.Empty ; 
  		public string ColorNum 
  		{ 
  			get 
  			{ 
  				return m_ColorNum ; 
  			}  
  			set 
  			{ 
  				m_ColorNum = value ; 
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
  
  		private string m_HuiXiu = string.Empty ; 
  		public string HuiXiu 
  		{ 
  			get 
  			{ 
  				return m_HuiXiu ; 
  			}  
  			set 
  			{ 
  				m_HuiXiu = value ; 
  			}  
  		} 
  
  		private string m_MWidth = string.Empty ; 
  		public string MWidth 
  		{ 
  			get 
  			{ 
  				return m_MWidth ; 
  			}  
  			set 
  			{ 
  				m_MWidth = value ; 
  			}  
  		} 
  
  		private string m_MWeight = string.Empty ; 
  		public string MWeight 
  		{ 
  			get 
  			{ 
  				return m_MWeight ; 
  			}  
  			set 
  			{ 
  				m_MWeight = value ; 
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
            string Sql="SELECT * FROM WO_ProductionPlanDts2 WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_ProductionPlanDts2 WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_WagonNo=SysConvert.ToString(MasterTable.Rows[0]["WagonNo"]); 
  				m_PBFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PBFormDate"]); 
  				m_PBieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PBieceQty"]); 
  				m_PBQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PBQty"]); 
  				m_CPFormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CPFormDate"]); 
  				m_CPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CPQty"]); 
  				m_Shrinkage=SysConvert.ToDecimal(MasterTable.Rows[0]["Shrinkage"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ZPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["ZPQty"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_HuiXiu=SysConvert.ToString(MasterTable.Rows[0]["HuiXiu"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
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
