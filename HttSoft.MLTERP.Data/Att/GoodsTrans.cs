using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Att_GoodsTrans实体类
	/// 作者:章文强
	/// 创建日期:2012/7/15
	/// </summary>
	public sealed class GoodsTrans : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public GoodsTrans()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public GoodsTrans(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Att_GoodsTrans";
		 
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
  
  		private string m_SendNo = string.Empty ; 
  		public string SendNo 
  		{ 
  			get 
  			{ 
  				return m_SendNo ; 
  			}  
  			set 
  			{ 
  				m_SendNo = value ; 
  			}  
  		} 
  
  		private string m_TransComID = string.Empty ; 
  		public string TransComID 
  		{ 
  			get 
  			{ 
  				return m_TransComID ; 
  			}  
  			set 
  			{ 
  				m_TransComID = value ; 
  			}  
  		} 
  
  		private decimal m_TransFee = 0; 
  		public decimal TransFee 
  		{ 
  			get 
  			{ 
  				return m_TransFee ; 
  			}  
  			set 
  			{ 
  				m_TransFee = value ; 
  			}  
  		} 
  
  		private decimal m_RLFee = 0; 
  		public decimal RLFee 
  		{ 
  			get 
  			{ 
  				return m_RLFee ; 
  			}  
  			set 
  			{ 
  				m_RLFee = value ; 
  			}  
  		} 
  
  		private string m_ShopID = string.Empty ; 
  		public string ShopID 
  		{ 
  			get 
  			{ 
  				return m_ShopID ; 
  			}  
  			set 
  			{ 
  				m_ShopID = value ; 
  			}  
  		} 
  
  		private decimal m_THFee = 0; 
  		public decimal THFee 
  		{ 
  			get 
  			{ 
  				return m_THFee ; 
  			}  
  			set 
  			{ 
  				m_THFee = value ; 
  			}  
  		} 
  
  		private string m_THAddress = string.Empty ; 
  		public string THAddress 
  		{ 
  			get 
  			{ 
  				return m_THAddress ; 
  			}  
  			set 
  			{ 
  				m_THAddress = value ; 
  			}  
  		} 
  
  		private string m_VendorID = string.Empty ; 
  		public string VendorID 
  		{ 
  			get 
  			{ 
  				return m_VendorID ; 
  			}  
  			set 
  			{ 
  				m_VendorID = value ; 
  			}  
  		} 
  
  		private string m_RecAddress = string.Empty ; 
  		public string RecAddress 
  		{ 
  			get 
  			{ 
  				return m_RecAddress ; 
  			}  
  			set 
  			{ 
  				m_RecAddress = value ; 
  			}  
  		} 
  
  		private int m_YSFlag = 0; 
  		public int YSFlag 
  		{ 
  			get 
  			{ 
  				return m_YSFlag ; 
  			}  
  			set 
  			{ 
  				m_YSFlag = value ; 
  			}  
  		} 
  
  		private decimal m_YSTime = 0; 
  		public decimal YSTime 
  		{ 
  			get 
  			{ 
  				return m_YSTime ; 
  			}  
  			set 
  			{ 
  				m_YSTime = value ; 
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
  
  		private int m_FLC = 0; 
  		public int FLC 
  		{ 
  			get 
  			{ 
  				return m_FLC ; 
  			}  
  			set 
  			{ 
  				m_FLC = value ; 
  			}  
  		} 
  
  		private int m_FDT = 0; 
  		public int FDT 
  		{ 
  			get 
  			{ 
  				return m_FDT ; 
  			}  
  			set 
  			{ 
  				m_FDT = value ; 
  			}  
  		} 
  
  		private string m_FSHSJD = string.Empty ; 
  		public string FSHSJD 
  		{ 
  			get 
  			{ 
  				return m_FSHSJD ; 
  			}  
  			set 
  			{ 
  				m_FSHSJD = value ; 
  			}  
  		} 
  
  		private decimal m_FHWZZ = 0; 
  		public decimal FHWZZ 
  		{ 
  			get 
  			{ 
  				return m_FHWZZ ; 
  			}  
  			set 
  			{ 
  				m_FHWZZ = value ; 
  			}  
  		} 
  
  		private int m_FDTJ = 0; 
  		public int FDTJ 
  		{ 
  			get 
  			{ 
  				return m_FDTJ ; 
  			}  
  			set 
  			{ 
  				m_FDTJ = value ; 
  			}  
  		} 
  
  		private int m_FHDFlag = 0; 
  		public int FHDFlag 
  		{ 
  			get 
  			{ 
  				return m_FHDFlag ; 
  			}  
  			set 
  			{ 
  				m_FHDFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_FHDDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FHDDate 
  		{ 
  			get 
  			{ 
  				return m_FHDDate ; 
  			}  
  			set 
  			{ 
  				m_FHDDate = value ; 
  			}  
  		} 
  
  		private int m_JSFlag = 0; 
  		public int JSFlag 
  		{ 
  			get 
  			{ 
  				return m_JSFlag ; 
  			}  
  			set 
  			{ 
  				m_JSFlag = value ; 
  			}  
  		} 
  
  		private DateTime m_JSDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JSDate 
  		{ 
  			get 
  			{ 
  				return m_JSDate ; 
  			}  
  			set 
  			{ 
  				m_JSDate = value ; 
  			}  
  		} 
  
  		private decimal m_JSFee = 0; 
  		public decimal JSFee 
  		{ 
  			get 
  			{ 
  				return m_JSFee ; 
  			}  
  			set 
  			{ 
  				m_JSFee = value ; 
  			}  
  		} 
  
  		private string m_JSRemark = string.Empty ; 
  		public string JSRemark 
  		{ 
  			get 
  			{ 
  				return m_JSRemark ; 
  			}  
  			set 
  			{ 
  				m_JSRemark = value ; 
  			}  
  		} 
  
  		private decimal m_OtherFee = 0; 
  		public decimal OtherFee 
  		{ 
  			get 
  			{ 
  				return m_OtherFee ; 
  			}  
  			set 
  			{ 
  				m_OtherFee = value ; 
  			}  
  		} 
  
  		private decimal m_TotalAmount = 0; 
  		public decimal TotalAmount 
  		{ 
  			get 
  			{ 
  				return m_TotalAmount ; 
  			}  
  			set 
  			{ 
  				m_TotalAmount = value ; 
  			}  
  		} 
  
  		private decimal m_TotalPieceQty = 0; 
  		public decimal TotalPieceQty 
  		{ 
  			get 
  			{ 
  				return m_TotalPieceQty ; 
  			}  
  			set 
  			{ 
  				m_TotalPieceQty = value ; 
  			}  
  		} 
  
  		private decimal m_TotalQty = 0; 
  		public decimal TotalQty 
  		{ 
  			get 
  			{ 
  				return m_TotalQty ; 
  			}  
  			set 
  			{ 
  				m_TotalQty = value ; 
  			}  
  		} 
  
  		private DateTime m_SJFHDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SJFHDate 
  		{ 
  			get 
  			{ 
  				return m_SJFHDate ; 
  			}  
  			set 
  			{ 
  				m_SJFHDate = value ; 
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
            string Sql="SELECT * FROM Att_GoodsTrans WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Att_GoodsTrans WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeOPName=SysConvert.ToString(MasterTable.Rows[0]["MakeOPName"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_SendNo=SysConvert.ToString(MasterTable.Rows[0]["SendNo"]); 
  				m_TransComID=SysConvert.ToString(MasterTable.Rows[0]["TransComID"]); 
  				m_TransFee=SysConvert.ToDecimal(MasterTable.Rows[0]["TransFee"]); 
  				m_RLFee=SysConvert.ToDecimal(MasterTable.Rows[0]["RLFee"]); 
  				m_ShopID=SysConvert.ToString(MasterTable.Rows[0]["ShopID"]); 
  				m_THFee=SysConvert.ToDecimal(MasterTable.Rows[0]["THFee"]); 
  				m_THAddress=SysConvert.ToString(MasterTable.Rows[0]["THAddress"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_RecAddress=SysConvert.ToString(MasterTable.Rows[0]["RecAddress"]); 
  				m_YSFlag=SysConvert.ToInt32(MasterTable.Rows[0]["YSFlag"]); 
  				m_YSTime=SysConvert.ToDecimal(MasterTable.Rows[0]["YSTime"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_FLC=SysConvert.ToInt32(MasterTable.Rows[0]["FLC"]); 
  				m_FDT=SysConvert.ToInt32(MasterTable.Rows[0]["FDT"]); 
  				m_FSHSJD=SysConvert.ToString(MasterTable.Rows[0]["FSHSJD"]); 
  				m_FHWZZ=SysConvert.ToDecimal(MasterTable.Rows[0]["FHWZZ"]); 
  				m_FDTJ=SysConvert.ToInt32(MasterTable.Rows[0]["FDTJ"]); 
  				m_FHDFlag=SysConvert.ToInt32(MasterTable.Rows[0]["FHDFlag"]); 
  				m_FHDDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FHDDate"]); 
  				m_JSFlag=SysConvert.ToInt32(MasterTable.Rows[0]["JSFlag"]); 
  				m_JSDate=SysConvert.ToDateTime(MasterTable.Rows[0]["JSDate"]); 
  				m_JSFee=SysConvert.ToDecimal(MasterTable.Rows[0]["JSFee"]); 
  				m_JSRemark=SysConvert.ToString(MasterTable.Rows[0]["JSRemark"]); 
  				m_OtherFee=SysConvert.ToDecimal(MasterTable.Rows[0]["OtherFee"]); 
  				m_TotalAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalAmount"]); 
  				m_TotalPieceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPieceQty"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_SJFHDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SJFHDate"]); 
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
