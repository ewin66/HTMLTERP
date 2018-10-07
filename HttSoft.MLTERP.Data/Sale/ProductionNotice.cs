using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_ProductionNotice实体类
	/// 作者:tanghao
	/// 创建日期:2015/5/27
	/// </summary>
	public sealed class ProductionNotice : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ProductionNotice()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionNotice(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_ProductionNotice";
		 
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
  
  		private DateTime m_OutDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime OutDate 
  		{ 
  			get 
  			{ 
  				return m_OutDate ; 
  			}  
  			set 
  			{ 
  				m_OutDate = value ; 
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
  
  		private string m_TrackOPID = string.Empty ; 
  		public string TrackOPID 
  		{ 
  			get 
  			{ 
  				return m_TrackOPID ; 
  			}  
  			set 
  			{ 
  				m_TrackOPID = value ; 
  			}  
  		} 
  
  		private string m_ProductionLeader = string.Empty ; 
  		public string ProductionLeader 
  		{ 
  			get 
  			{ 
  				return m_ProductionLeader ; 
  			}  
  			set 
  			{ 
  				m_ProductionLeader = value ; 
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
  
  		private string m_ZZRemark = string.Empty ; 
  		public string ZZRemark 
  		{ 
  			get 
  			{ 
  				return m_ZZRemark ; 
  			}  
  			set 
  			{ 
  				m_ZZRemark = value ; 
  			}  
  		} 
  
  		private string m_RSReamrk = string.Empty ; 
  		public string RSReamrk 
  		{ 
  			get 
  			{ 
  				return m_RSReamrk ; 
  			}  
  			set 
  			{ 
  				m_RSReamrk = value ; 
  			}  
  		} 
  
  		private string m_HZLRemark = string.Empty ; 
  		public string HZLRemark 
  		{ 
  			get 
  			{ 
  				return m_HZLRemark ; 
  			}  
  			set 
  			{ 
  				m_HZLRemark = value ; 
  			}  
  		} 
  
  		private string m_BZRemark = string.Empty ; 
  		public string BZRemark 
  		{ 
  			get 
  			{ 
  				return m_BZRemark ; 
  			}  
  			set 
  			{ 
  				m_BZRemark = value ; 
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
  
  		private int m_SOTypeID = 0; 
  		public int SOTypeID 
  		{ 
  			get 
  			{ 
  				return m_SOTypeID ; 
  			}  
  			set 
  			{ 
  				m_SOTypeID = value ; 
  			}  
  		} 
  
  		private string m_TrackOPID2 = string.Empty ; 
  		public string TrackOPID2 
  		{ 
  			get 
  			{ 
  				return m_TrackOPID2 ; 
  			}  
  			set 
  			{ 
  				m_TrackOPID2 = value ; 
  			}  
  		} 
  
  		private string m_TrackOPID3 = string.Empty ; 
  		public string TrackOPID3 
  		{ 
  			get 
  			{ 
  				return m_TrackOPID3 ; 
  			}  
  			set 
  			{ 
  				m_TrackOPID3 = value ; 
  			}  
  		} 
  
  		private int m_FormNoIndex = 0; 
  		public int FormNoIndex 
  		{ 
  			get 
  			{ 
  				return m_FormNoIndex ; 
  			}  
  			set 
  			{ 
  				m_FormNoIndex = value ; 
  			}  
  		} 
  
  		private string m_RSGDOPID = string.Empty ; 
  		public string RSGDOPID 
  		{ 
  			get 
  			{ 
  				return m_RSGDOPID ; 
  			}  
  			set 
  			{ 
  				m_RSGDOPID = value ; 
  			}  
  		} 
  
  		private string m_HZGDOPID = string.Empty ; 
  		public string HZGDOPID 
  		{ 
  			get 
  			{ 
  				return m_HZGDOPID ; 
  			}  
  			set 
  			{ 
  				m_HZGDOPID = value ; 
  			}  
  		} 
  
  		private string m_HZLRemark2 = string.Empty ; 
  		public string HZLRemark2 
  		{ 
  			get 
  			{ 
  				return m_HZLRemark2 ; 
  			}  
  			set 
  			{ 
  				m_HZLRemark2 = value ; 
  			}  
  		} 
  
  		private string m_HZLRemark3 = string.Empty ; 
  		public string HZLRemark3 
  		{ 
  			get 
  			{ 
  				return m_HZLRemark3 ; 
  			}  
  			set 
  			{ 
  				m_HZLRemark3 = value ; 
  			}  
  		} 
  
  		private string m_BZGDOPID = string.Empty ; 
  		public string BZGDOPID 
  		{ 
  			get 
  			{ 
  				return m_BZGDOPID ; 
  			}  
  			set 
  			{ 
  				m_BZGDOPID = value ; 
  			}  
  		} 
  
  		private string m_FactoryID = string.Empty ; 
  		public string FactoryID 
  		{ 
  			get 
  			{ 
  				return m_FactoryID ; 
  			}  
  			set 
  			{ 
  				m_FactoryID = value ; 
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
  
  		private string m_FactoryID4 = string.Empty ; 
  		public string FactoryID4 
  		{ 
  			get 
  			{ 
  				return m_FactoryID4 ; 
  			}  
  			set 
  			{ 
  				m_FactoryID4 = value ; 
  			}  
  		} 
  
  		private string m_FactoryID5 = string.Empty ; 
  		public string FactoryID5 
  		{ 
  			get 
  			{ 
  				return m_FactoryID5 ; 
  			}  
  			set 
  			{ 
  				m_FactoryID5 = value ; 
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
  
  		private string m_QtyReq = string.Empty ; 
  		public string QtyReq 
  		{ 
  			get 
  			{ 
  				return m_QtyReq ; 
  			}  
  			set 
  			{ 
  				m_QtyReq = value ; 
  			}  
  		} 
  
  		private string m_CheckStandard = string.Empty ; 
  		public string CheckStandard 
  		{ 
  			get 
  			{ 
  				return m_CheckStandard ; 
  			}  
  			set 
  			{ 
  				m_CheckStandard = value ; 
  			}  
  		} 
  
  		private string m_CheckReq = string.Empty ; 
  		public string CheckReq 
  		{ 
  			get 
  			{ 
  				return m_CheckReq ; 
  			}  
  			set 
  			{ 
  				m_CheckReq = value ; 
  			}  
  		} 
  
  		private string m_Address = string.Empty ; 
  		public string Address 
  		{ 
  			get 
  			{ 
  				return m_Address ; 
  			}  
  			set 
  			{ 
  				m_Address = value ; 
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
  
  		private DateTime m_XGDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime XGDate 
  		{ 
  			get 
  			{ 
  				return m_XGDate ; 
  			}  
  			set 
  			{ 
  				m_XGDate = value ; 
  			}  
  		} 
  
  		private string m_XGReason = string.Empty ; 
  		public string XGReason 
  		{ 
  			get 
  			{ 
  				return m_XGReason ; 
  			}  
  			set 
  			{ 
  				m_XGReason = value ; 
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
            string Sql="SELECT * FROM Sale_ProductionNotice WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_ProductionNotice WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_OutDate=SysConvert.ToDateTime(MasterTable.Rows[0]["OutDate"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_TrackOPID=SysConvert.ToString(MasterTable.Rows[0]["TrackOPID"]); 
  				m_ProductionLeader=SysConvert.ToString(MasterTable.Rows[0]["ProductionLeader"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_ZZRemark=SysConvert.ToString(MasterTable.Rows[0]["ZZRemark"]); 
  				m_RSReamrk=SysConvert.ToString(MasterTable.Rows[0]["RSReamrk"]); 
  				m_HZLRemark=SysConvert.ToString(MasterTable.Rows[0]["HZLRemark"]); 
  				m_BZRemark=SysConvert.ToString(MasterTable.Rows[0]["BZRemark"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_SOTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SOTypeID"]); 
  				m_TrackOPID2=SysConvert.ToString(MasterTable.Rows[0]["TrackOPID2"]); 
  				m_TrackOPID3=SysConvert.ToString(MasterTable.Rows[0]["TrackOPID3"]); 
  				m_FormNoIndex=SysConvert.ToInt32(MasterTable.Rows[0]["FormNoIndex"]); 
  				m_RSGDOPID=SysConvert.ToString(MasterTable.Rows[0]["RSGDOPID"]); 
  				m_HZGDOPID=SysConvert.ToString(MasterTable.Rows[0]["HZGDOPID"]); 
  				m_HZLRemark2=SysConvert.ToString(MasterTable.Rows[0]["HZLRemark2"]); 
  				m_HZLRemark3=SysConvert.ToString(MasterTable.Rows[0]["HZLRemark3"]); 
  				m_BZGDOPID=SysConvert.ToString(MasterTable.Rows[0]["BZGDOPID"]); 
  				m_FactoryID=SysConvert.ToString(MasterTable.Rows[0]["FactoryID"]); 
  				m_FactoryID2=SysConvert.ToString(MasterTable.Rows[0]["FactoryID2"]); 
  				m_FactoryID3=SysConvert.ToString(MasterTable.Rows[0]["FactoryID3"]); 
  				m_FactoryID4=SysConvert.ToString(MasterTable.Rows[0]["FactoryID4"]); 
  				m_FactoryID5=SysConvert.ToString(MasterTable.Rows[0]["FactoryID5"]); 
  				m_LightSource=SysConvert.ToString(MasterTable.Rows[0]["LightSource"]); 
  				m_QtyReq=SysConvert.ToString(MasterTable.Rows[0]["QtyReq"]); 
  				m_CheckStandard=SysConvert.ToString(MasterTable.Rows[0]["CheckStandard"]); 
  				m_CheckReq=SysConvert.ToString(MasterTable.Rows[0]["CheckReq"]); 
  				m_Address=SysConvert.ToString(MasterTable.Rows[0]["Address"]); 
  				m_PBItemCode=SysConvert.ToString(MasterTable.Rows[0]["PBItemCode"]); 
  				m_PBDensity=SysConvert.ToString(MasterTable.Rows[0]["PBDensity"]); 
  				m_PBMWidth=SysConvert.ToString(MasterTable.Rows[0]["PBMWidth"]); 
  				m_PBMWeight=SysConvert.ToString(MasterTable.Rows[0]["PBMWeight"]); 
  				m_CPItemCode=SysConvert.ToString(MasterTable.Rows[0]["CPItemCode"]); 
  				m_CPDensity=SysConvert.ToString(MasterTable.Rows[0]["CPDensity"]); 
  				m_CPMWidth=SysConvert.ToString(MasterTable.Rows[0]["CPMWidth"]); 
  				m_CPMWeight=SysConvert.ToString(MasterTable.Rows[0]["CPMWeight"]); 
  				m_XGDate=SysConvert.ToDateTime(MasterTable.Rows[0]["XGDate"]); 
  				m_XGReason=SysConvert.ToString(MasterTable.Rows[0]["XGReason"]); 
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
