using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_SaleOrderInstruct实体类
	/// 作者:tanghao
	/// 创建日期:2015/5/22
	/// </summary>
	public sealed class SaleOrderInstruct : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrderInstruct()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SaleOrderInstruct(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_SaleOrderInstruct";
		 
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
  
  		private string m_FormNo = string.Empty ; 
  		public string FormNo 
  		{ 
  			get 
  			{ 
  				return m_FormNo ; 
  			}  
  			set 
  			{ 
  				m_FormNo = value ; 
  			}  
  		} 
  
  		private string m_OrderFormNo = string.Empty ; 
  		public string OrderFormNo 
  		{ 
  			get 
  			{ 
  				return m_OrderFormNo ; 
  			}  
  			set 
  			{ 
  				m_OrderFormNo = value ; 
  			}  
  		} 
  
  		private DateTime m_FormDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FormDate 
  		{ 
  			get 
  			{ 
  				return m_FormDate ; 
  			}  
  			set 
  			{ 
  				m_FormDate = value ; 
  			}  
  		} 
  
  		private DateTime m_ReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime ReqDate 
  		{ 
  			get 
  			{ 
  				return m_ReqDate ; 
  			}  
  			set 
  			{ 
  				m_ReqDate = value ; 
  			}  
  		} 
  
  		private string m_SaleOPID = string.Empty ; 
  		public string SaleOPID 
  		{ 
  			get 
  			{ 
  				return m_SaleOPID ; 
  			}  
  			set 
  			{ 
  				m_SaleOPID = value ; 
  			}  
  		} 
  
  		private string m_PBItemCode = string.Empty ; 
  		public string PBItemCode 
  		{ 
  			get 
  			{ 
  				return m_PBItemCode ; 
  			}  
  			set 
  			{ 
  				m_PBItemCode = value ; 
  			}  
  		} 
  
  		private string m_PBDensity = string.Empty ; 
  		public string PBDensity 
  		{ 
  			get 
  			{ 
  				return m_PBDensity ; 
  			}  
  			set 
  			{ 
  				m_PBDensity = value ; 
  			}  
  		} 
  
  		private string m_PBMWidth = string.Empty ; 
  		public string PBMWidth 
  		{ 
  			get 
  			{ 
  				return m_PBMWidth ; 
  			}  
  			set 
  			{ 
  				m_PBMWidth = value ; 
  			}  
  		} 
  
  		private string m_PBMWeight = string.Empty ; 
  		public string PBMWeight 
  		{ 
  			get 
  			{ 
  				return m_PBMWeight ; 
  			}  
  			set 
  			{ 
  				m_PBMWeight = value ; 
  			}  
  		} 
  
  		private string m_FactoryID2 = string.Empty ; 
  		public string FactoryID2 
  		{ 
  			get 
  			{ 
  				return m_FactoryID2 ; 
  			}  
  			set 
  			{ 
  				m_FactoryID2 = value ; 
  			}  
  		} 
  
  		private string m_CPItemCode = string.Empty ; 
  		public string CPItemCode 
  		{ 
  			get 
  			{ 
  				return m_CPItemCode ; 
  			}  
  			set 
  			{ 
  				m_CPItemCode = value ; 
  			}  
  		} 
  
  		private string m_CPDensity = string.Empty ; 
  		public string CPDensity 
  		{ 
  			get 
  			{ 
  				return m_CPDensity ; 
  			}  
  			set 
  			{ 
  				m_CPDensity = value ; 
  			}  
  		} 
  
  		private string m_CPMWidth = string.Empty ; 
  		public string CPMWidth 
  		{ 
  			get 
  			{ 
  				return m_CPMWidth ; 
  			}  
  			set 
  			{ 
  				m_CPMWidth = value ; 
  			}  
  		} 
  
  		private string m_CPMWeight = string.Empty ; 
  		public string CPMWeight 
  		{ 
  			get 
  			{ 
  				return m_CPMWeight ; 
  			}  
  			set 
  			{ 
  				m_CPMWeight = value ; 
  			}  
  		} 
  
  		private string m_FactoryID3 = string.Empty ; 
  		public string FactoryID3 
  		{ 
  			get 
  			{ 
  				return m_FactoryID3 ; 
  			}  
  			set 
  			{ 
  				m_FactoryID3 = value ; 
  			}  
  		} 
  
  		private string m_TecReq = string.Empty ; 
  		public string TecReq 
  		{ 
  			get 
  			{ 
  				return m_TecReq ; 
  			}  
  			set 
  			{ 
  				m_TecReq = value ; 
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
  
  		private decimal m_BCPSampleQty = 0; 
  		public decimal BCPSampleQty 
  		{ 
  			get 
  			{ 
  				return m_BCPSampleQty ; 
  			}  
  			set 
  			{ 
  				m_BCPSampleQty = value ; 
  			}  
  		} 
  
  		private decimal m_PBSampleQty = 0; 
  		public decimal PBSampleQty 
  		{ 
  			get 
  			{ 
  				return m_PBSampleQty ; 
  			}  
  			set 
  			{ 
  				m_PBSampleQty = value ; 
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
  
  		private string m_MakeOPName = string.Empty ; 
  		public string MakeOPName 
  		{ 
  			get 
  			{ 
  				return m_MakeOPName ; 
  			}  
  			set 
  			{ 
  				m_MakeOPName = value ; 
  			}  
  		} 
  
  		private DateTime m_MakeDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime MakeDate 
  		{ 
  			get 
  			{ 
  				return m_MakeDate ; 
  			}  
  			set 
  			{ 
  				m_MakeDate = value ; 
  			}  
  		} 
  
  		private int m_SubmitFlag = 0; 
  		public int SubmitFlag 
  		{ 
  			get 
  			{ 
  				return m_SubmitFlag ; 
  			}  
  			set 
  			{ 
  				m_SubmitFlag = value ; 
  			}  
  		} 
  
  		private string m_SubmitOPID = string.Empty ; 
  		public string SubmitOPID 
  		{ 
  			get 
  			{ 
  				return m_SubmitOPID ; 
  			}  
  			set 
  			{ 
  				m_SubmitOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_SubmitTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SubmitTime 
  		{ 
  			get 
  			{ 
  				return m_SubmitTime ; 
  			}  
  			set 
  			{ 
  				m_SubmitTime = value ; 
  			}  
  		} 
  
  		private int m_DelFlag = 0; 
  		public int DelFlag 
  		{ 
  			get 
  			{ 
  				return m_DelFlag ; 
  			}  
  			set 
  			{ 
  				m_DelFlag = value ; 
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
            string Sql="SELECT * FROM Sale_SaleOrderInstruct WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrderInstruct WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_PBItemCode=SysConvert.ToString(MasterTable.Rows[0]["PBItemCode"]); 
  				m_PBDensity=SysConvert.ToString(MasterTable.Rows[0]["PBDensity"]); 
  				m_PBMWidth=SysConvert.ToString(MasterTable.Rows[0]["PBMWidth"]); 
  				m_PBMWeight=SysConvert.ToString(MasterTable.Rows[0]["PBMWeight"]); 
  				m_FactoryID2=SysConvert.ToString(MasterTable.Rows[0]["FactoryID2"]); 
  				m_CPItemCode=SysConvert.ToString(MasterTable.Rows[0]["CPItemCode"]); 
  				m_CPDensity=SysConvert.ToString(MasterTable.Rows[0]["CPDensity"]); 
  				m_CPMWidth=SysConvert.ToString(MasterTable.Rows[0]["CPMWidth"]); 
  				m_CPMWeight=SysConvert.ToString(MasterTable.Rows[0]["CPMWeight"]); 
  				m_FactoryID3=SysConvert.ToString(MasterTable.Rows[0]["FactoryID3"]); 
  				m_TecReq=SysConvert.ToString(MasterTable.Rows[0]["TecReq"]); 
  				m_PBQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PBQty"]); 
  				m_BCPSampleQty=SysConvert.ToDecimal(MasterTable.Rows[0]["BCPSampleQty"]); 
  				m_PBSampleQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PBSampleQty"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_SubmitOPID=SysConvert.ToString(MasterTable.Rows[0]["SubmitOPID"]); 
  				m_SubmitTime=SysConvert.ToDateTime(MasterTable.Rows[0]["SubmitTime"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
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
