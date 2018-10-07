using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_ProductionPlan实体类
	/// 作者:qiuchao
	/// 创建日期:2015/6/30
	/// </summary>
	public sealed class ProductionPlan : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ProductionPlan()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionPlan(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_ProductionPlan";
		 
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
  
  		private string m_OrderFormQty = string.Empty ; 
  		public string OrderFormQty 
  		{ 
  			get 
  			{ 
  				return m_OrderFormQty ; 
  			}  
  			set 
  			{ 
  				m_OrderFormQty = value ; 
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
  
  		private string m_PBItemName = string.Empty ; 
  		public string PBItemName 
  		{ 
  			get 
  			{ 
  				return m_PBItemName ; 
  			}  
  			set 
  			{ 
  				m_PBItemName = value ; 
  			}  
  		} 
  
  		private string m_PBItemStd = string.Empty ; 
  		public string PBItemStd 
  		{ 
  			get 
  			{ 
  				return m_PBItemStd ; 
  			}  
  			set 
  			{ 
  				m_PBItemStd = value ; 
  			}  
  		} 
  
  		private string m_PBItemModel = string.Empty ; 
  		public string PBItemModel 
  		{ 
  			get 
  			{ 
  				return m_PBItemModel ; 
  			}  
  			set 
  			{ 
  				m_PBItemModel = value ; 
  			}  
  		} 
  
  		private string m_FactoryID1 = string.Empty ; 
  		public string FactoryID1 
  		{ 
  			get 
  			{ 
  				return m_FactoryID1 ; 
  			}  
  			set 
  			{ 
  				m_FactoryID1 = value ; 
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
  
  		private string m_LightSource = string.Empty ; 
  		public string LightSource 
  		{ 
  			get 
  			{ 
  				return m_LightSource ; 
  			}  
  			set 
  			{ 
  				m_LightSource = value ; 
  			}  
  		} 
  
  		private DateTime m_PBReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime PBReqDate 
  		{ 
  			get 
  			{ 
  				return m_PBReqDate ; 
  			}  
  			set 
  			{ 
  				m_PBReqDate = value ; 
  			}  
  		} 
  
  		private DateTime m_TGReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime TGReqDate 
  		{ 
  			get 
  			{ 
  				return m_TGReqDate ; 
  			}  
  			set 
  			{ 
  				m_TGReqDate = value ; 
  			}  
  		} 
  
  		private DateTime m_CPReqDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CPReqDate 
  		{ 
  			get 
  			{ 
  				return m_CPReqDate ; 
  			}  
  			set 
  			{ 
  				m_CPReqDate = value ; 
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
  
  		private string m_CheckOPID = string.Empty ; 
  		public string CheckOPID 
  		{ 
  			get 
  			{ 
  				return m_CheckOPID ; 
  			}  
  			set 
  			{ 
  				m_CheckOPID = value ; 
  			}  
  		} 
  
  		private DateTime m_CheckDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CheckDate 
  		{ 
  			get 
  			{ 
  				return m_CheckDate ; 
  			}  
  			set 
  			{ 
  				m_CheckDate = value ; 
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
  
  		private string m_CPItemName = string.Empty ; 
  		public string CPItemName 
  		{ 
  			get 
  			{ 
  				return m_CPItemName ; 
  			}  
  			set 
  			{ 
  				m_CPItemName = value ; 
  			}  
  		} 
  
  		private string m_CPItemModel = string.Empty ; 
  		public string CPItemModel 
  		{ 
  			get 
  			{ 
  				return m_CPItemModel ; 
  			}  
  			set 
  			{ 
  				m_CPItemModel = value ; 
  			}  
  		} 
  
  		private string m_CPItemStd = string.Empty ; 
  		public string CPItemStd 
  		{ 
  			get 
  			{ 
  				return m_CPItemStd ; 
  			}  
  			set 
  			{ 
  				m_CPItemStd = value ; 
  			}  
  		} 
  
  		private string m_GenDan = string.Empty ; 
  		public string GenDan 
  		{ 
  			get 
  			{ 
  				return m_GenDan ; 
  			}  
  			set 
  			{ 
  				m_GenDan = value ; 
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
  
  		private string m_Remark2 = string.Empty ; 
  		public string Remark2 
  		{ 
  			get 
  			{ 
  				return m_Remark2 ; 
  			}  
  			set 
  			{ 
  				m_Remark2 = value ; 
  			}  
  		} 
  
  		private string m_SO = string.Empty ; 
  		public string SO 
  		{ 
  			get 
  			{ 
  				return m_SO ; 
  			}  
  			set 
  			{ 
  				m_SO = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WO_ProductionPlan WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_ProductionPlan WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_OrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["OrderFormNo"]); 
  				m_OrderFormQty=SysConvert.ToString(MasterTable.Rows[0]["OrderFormQty"]); 
  				m_PBItemCode=SysConvert.ToString(MasterTable.Rows[0]["PBItemCode"]); 
  				m_PBItemName=SysConvert.ToString(MasterTable.Rows[0]["PBItemName"]); 
  				m_PBItemStd=SysConvert.ToString(MasterTable.Rows[0]["PBItemStd"]); 
  				m_PBItemModel=SysConvert.ToString(MasterTable.Rows[0]["PBItemModel"]); 
  				m_FactoryID1=SysConvert.ToString(MasterTable.Rows[0]["FactoryID1"]); 
  				m_PBMWeight=SysConvert.ToString(MasterTable.Rows[0]["PBMWeight"]); 
  				m_CPItemCode=SysConvert.ToString(MasterTable.Rows[0]["CPItemCode"]); 
  				m_CPDensity=SysConvert.ToString(MasterTable.Rows[0]["CPDensity"]); 
  				m_CPMWidth=SysConvert.ToString(MasterTable.Rows[0]["CPMWidth"]); 
  				m_CPMWeight=SysConvert.ToString(MasterTable.Rows[0]["CPMWeight"]); 
  				m_FactoryID2=SysConvert.ToString(MasterTable.Rows[0]["FactoryID2"]); 
  				m_LightSource=SysConvert.ToString(MasterTable.Rows[0]["LightSource"]); 
  				m_PBReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["PBReqDate"]); 
  				m_TGReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["TGReqDate"]); 
  				m_CPReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CPReqDate"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_PBMWidth=SysConvert.ToString(MasterTable.Rows[0]["PBMWidth"]); 
  				m_CPItemName=SysConvert.ToString(MasterTable.Rows[0]["CPItemName"]); 
  				m_CPItemModel=SysConvert.ToString(MasterTable.Rows[0]["CPItemModel"]); 
  				m_CPItemStd=SysConvert.ToString(MasterTable.Rows[0]["CPItemStd"]); 
  				m_GenDan=SysConvert.ToString(MasterTable.Rows[0]["GenDan"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Remark2=SysConvert.ToString(MasterTable.Rows[0]["Remark2"]); 
  				m_SO=SysConvert.ToString(MasterTable.Rows[0]["SO"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
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
