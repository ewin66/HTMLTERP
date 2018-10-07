using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.HTCPCheck.Data
{
	/// <summary>
	/// 目的：Chk_CheckOrderISN实体类
	/// 作者:周富春
	/// 创建日期:2015/11/17
	/// </summary>
	public sealed class CheckOrderISN : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckOrderISN()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOrderISN(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Chk_CheckOrderISN";
		 
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
  
  		private string m_DISN = string.Empty ; 
  		public string DISN 
  		{ 
  			get 
  			{ 
  				return m_DISN ; 
  			}  
  			set 
  			{ 
  				m_DISN = value ; 
  			}  
  		} 
  
  		private int m_StatusID = 0; 
  		public int StatusID 
  		{ 
  			get 
  			{ 
  				return m_StatusID ; 
  			}  
  			set 
  			{ 
  				m_StatusID = value ; 
  			}  
  		} 
  
  		private int m_InWHFlag = 0; 
  		public int InWHFlag 
  		{ 
  			get 
  			{ 
  				return m_InWHFlag ; 
  			}  
  			set 
  			{ 
  				m_InWHFlag = value ; 
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
  
  		private string m_ItemCode = string.Empty ; 
  		public string ItemCode 
  		{ 
  			get 
  			{ 
  				return m_ItemCode ; 
  			}  
  			set 
  			{ 
  				m_ItemCode = value ; 
  			}  
  		} 
  
  		private string m_ItemName = string.Empty ; 
  		public string ItemName 
  		{ 
  			get 
  			{ 
  				return m_ItemName ; 
  			}  
  			set 
  			{ 
  				m_ItemName = value ; 
  			}  
  		} 
  
  		private string m_ItemStd = string.Empty ; 
  		public string ItemStd 
  		{ 
  			get 
  			{ 
  				return m_ItemStd ; 
  			}  
  			set 
  			{ 
  				m_ItemStd = value ; 
  			}  
  		} 
  
  		private string m_ItemModel = string.Empty ; 
  		public string ItemModel 
  		{ 
  			get 
  			{ 
  				return m_ItemModel ; 
  			}  
  			set 
  			{ 
  				m_ItemModel = value ; 
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
  
  		private string m_VendorBatch = string.Empty ; 
  		public string VendorBatch 
  		{ 
  			get 
  			{ 
  				return m_VendorBatch ; 
  			}  
  			set 
  			{ 
  				m_VendorBatch = value ; 
  			}  
  		} 
  
  		private string m_JarNum = string.Empty ; 
  		public string JarNum 
  		{ 
  			get 
  			{ 
  				return m_JarNum ; 
  			}  
  			set 
  			{ 
  				m_JarNum = value ; 
  			}  
  		} 
  
  		private string m_ReelNo = string.Empty ; 
  		public string ReelNo 
  		{ 
  			get 
  			{ 
  				return m_ReelNo ; 
  			}  
  			set 
  			{ 
  				m_ReelNo = value ; 
  			}  
  		} 
  
  		private decimal m_YQty = 0; 
  		public decimal YQty 
  		{ 
  			get 
  			{ 
  				return m_YQty ; 
  			}  
  			set 
  			{ 
  				m_YQty = value ; 
  			}  
  		} 
  
  		private decimal m_ChkQty = 0; 
  		public decimal ChkQty 
  		{ 
  			get 
  			{ 
  				return m_ChkQty ; 
  			}  
  			set 
  			{ 
  				m_ChkQty = value ; 
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
  
  		private decimal m_KJQty = 0; 
  		public decimal KJQty 
  		{ 
  			get 
  			{ 
  				return m_KJQty ; 
  			}  
  			set 
  			{ 
  				m_KJQty = value ; 
  			}  
  		} 
  
  		private string m_ChkMWidth = string.Empty ; 
  		public string ChkMWidth 
  		{ 
  			get 
  			{ 
  				return m_ChkMWidth ; 
  			}  
  			set 
  			{ 
  				m_ChkMWidth = value ; 
  			}  
  		} 
  
  		private string m_ChkMWeight = string.Empty ; 
  		public string ChkMWeight 
  		{ 
  			get 
  			{ 
  				return m_ChkMWeight ; 
  			}  
  			set 
  			{ 
  				m_ChkMWeight = value ; 
  			}  
  		} 
  
  		private decimal m_ChkQtyKG = 0; 
  		public decimal ChkQtyKG 
  		{ 
  			get 
  			{ 
  				return m_ChkQtyKG ; 
  			}  
  			set 
  			{ 
  				m_ChkQtyKG = value ; 
  			}  
  		} 
  
  		private string m_FaultDesc = string.Empty ; 
  		public string FaultDesc 
  		{ 
  			get 
  			{ 
  				return m_FaultDesc ; 
  			}  
  			set 
  			{ 
  				m_FaultDesc = value ; 
  			}  
  		} 
  
  		private string m_ChkLevel = string.Empty ; 
  		public string ChkLevel 
  		{ 
  			get 
  			{ 
  				return m_ChkLevel ; 
  			}  
  			set 
  			{ 
  				m_ChkLevel = value ; 
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
            string Sql="SELECT * FROM Chk_CheckOrderISN WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Chk_CheckOrderISN WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DISN=SysConvert.ToString(MasterTable.Rows[0]["DISN"]); 
  				m_StatusID=SysConvert.ToInt32(MasterTable.Rows[0]["StatusID"]); 
  				m_InWHFlag=SysConvert.ToInt32(MasterTable.Rows[0]["InWHFlag"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_VendorBatch=SysConvert.ToString(MasterTable.Rows[0]["VendorBatch"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_ReelNo=SysConvert.ToString(MasterTable.Rows[0]["ReelNo"]); 
  				m_YQty=SysConvert.ToDecimal(MasterTable.Rows[0]["YQty"]); 
  				m_ChkQty=SysConvert.ToDecimal(MasterTable.Rows[0]["ChkQty"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_KJQty=SysConvert.ToDecimal(MasterTable.Rows[0]["KJQty"]); 
  				m_ChkMWidth=SysConvert.ToString(MasterTable.Rows[0]["ChkMWidth"]); 
  				m_ChkMWeight=SysConvert.ToString(MasterTable.Rows[0]["ChkMWeight"]); 
  				m_ChkQtyKG=SysConvert.ToDecimal(MasterTable.Rows[0]["ChkQtyKG"]); 
  				m_FaultDesc=SysConvert.ToString(MasterTable.Rows[0]["FaultDesc"]); 
  				m_ChkLevel=SysConvert.ToString(MasterTable.Rows[0]["ChkLevel"]); 
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
