using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WH_DBForm实体类
	/// 作者:陈加海
	/// 创建日期:2014/7/22
	/// </summary>
	public sealed class DBForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public DBForm()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public DBForm(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
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
  
  		private int m_FormListDBID = 0; 
  		public int FormListDBID 
  		{ 
  			get 
  			{ 
  				return m_FormListDBID ; 
  			}  
  			set 
  			{ 
  				m_FormListDBID = value ; 
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
  
  		private string m_WHID = string.Empty ; 
  		public string WHID 
  		{ 
  			get 
  			{ 
  				return m_WHID ; 
  			}  
  			set 
  			{ 
  				m_WHID = value ; 
  			}  
  		} 
  
  		private string m_TargetWHID = string.Empty ; 
  		public string TargetWHID 
  		{ 
  			get 
  			{ 
  				return m_TargetWHID ; 
  			}  
  			set 
  			{ 
  				m_TargetWHID = value ; 
  			}  
  		} 
  
  		private string m_TargetDtsSO = string.Empty ; 
  		public string TargetDtsSO 
  		{ 
  			get 
  			{ 
  				return m_TargetDtsSO ; 
  			}  
  			set 
  			{ 
  				m_TargetDtsSO = value ; 
  			}  
  		} 
  
  		private string m_OutWHFormNo = string.Empty ; 
  		public string OutWHFormNo 
  		{ 
  			get 
  			{ 
  				return m_OutWHFormNo ; 
  			}  
  			set 
  			{ 
  				m_OutWHFormNo = value ; 
  			}  
  		} 
  
  		private int m_OutWHFormID = 0; 
  		public int OutWHFormID 
  		{ 
  			get 
  			{ 
  				return m_OutWHFormID ; 
  			}  
  			set 
  			{ 
  				m_OutWHFormID = value ; 
  			}  
  		} 
  
  		private string m_InWHFormNo = string.Empty ; 
  		public string InWHFormNo 
  		{ 
  			get 
  			{ 
  				return m_InWHFormNo ; 
  			}  
  			set 
  			{ 
  				m_InWHFormNo = value ; 
  			}  
  		} 
  
  		private int m_InWHFormID = 0; 
  		public int InWHFormID 
  		{ 
  			get 
  			{ 
  				return m_InWHFormID ; 
  			}  
  			set 
  			{ 
  				m_InWHFormID = value ; 
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
  
  		private int m_TotalPieceQty = 0; 
  		public int TotalPieceQty 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM WH_DBForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WH_DBForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_FormListDBID=SysConvert.ToInt32(MasterTable.Rows[0]["FormListDBID"]); 
  				m_FormNo=SysConvert.ToString(MasterTable.Rows[0]["FormNo"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_WHID=SysConvert.ToString(MasterTable.Rows[0]["WHID"]); 
  				m_TargetWHID=SysConvert.ToString(MasterTable.Rows[0]["TargetWHID"]); 
  				m_TargetDtsSO=SysConvert.ToString(MasterTable.Rows[0]["TargetDtsSO"]); 
  				m_OutWHFormNo=SysConvert.ToString(MasterTable.Rows[0]["OutWHFormNo"]); 
  				m_OutWHFormID=SysConvert.ToInt32(MasterTable.Rows[0]["OutWHFormID"]); 
  				m_InWHFormNo=SysConvert.ToString(MasterTable.Rows[0]["InWHFormNo"]); 
  				m_InWHFormID=SysConvert.ToInt32(MasterTable.Rows[0]["InWHFormID"]); 
  				m_SubmitFlag=SysConvert.ToInt32(MasterTable.Rows[0]["SubmitFlag"]); 
  				m_SubmitOPID=SysConvert.ToString(MasterTable.Rows[0]["SubmitOPID"]); 
  				m_DelFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DelFlag"]); 
  				m_MakeOPID=SysConvert.ToString(MasterTable.Rows[0]["MakeOPID"]); 
  				m_MakeDate=SysConvert.ToDateTime(MasterTable.Rows[0]["MakeDate"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_CheckOPID=SysConvert.ToString(MasterTable.Rows[0]["CheckOPID"]); 
  				m_CheckDate=SysConvert.ToDateTime(MasterTable.Rows[0]["CheckDate"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_TotalPieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["TotalPieceQty"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
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
