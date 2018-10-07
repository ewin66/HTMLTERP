using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_TowelProductionPlanDts实体类
	/// 作者:zhp
	/// 创建日期:2016/9/20
	/// </summary>
	public sealed class TowelProductionPlanDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public TowelProductionPlanDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public TowelProductionPlanDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_TowelProductionPlanDts";
		 
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
  
  		private int m_PieceQty = 0; 
  		public int PieceQty 
  		{ 
  			get 
  			{ 
  				return m_PieceQty ; 
  			}  
  			set 
  			{ 
  				m_PieceQty = value ; 
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
  
  		private string m_Unit = string.Empty ; 
  		public string Unit 
  		{ 
  			get 
  			{ 
  				return m_Unit ; 
  			}  
  			set 
  			{ 
  				m_Unit = value ; 
  			}  
  		} 
  
  		private decimal m_SinglePrice = 0; 
  		public decimal SinglePrice 
  		{ 
  			get 
  			{ 
  				return m_SinglePrice ; 
  			}  
  			set 
  			{ 
  				m_SinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_Amount = 0; 
  		public decimal Amount 
  		{ 
  			get 
  			{ 
  				return m_Amount ; 
  			}  
  			set 
  			{ 
  				m_Amount = value ; 
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
  
  		private string m_DtsSO = string.Empty ; 
  		public string DtsSO 
  		{ 
  			get 
  			{ 
  				return m_DtsSO ; 
  			}  
  			set 
  			{ 
  				m_DtsSO = value ; 
  			}  
  		} 
  
  		private int m_LoadDtsID = 0; 
  		public int LoadDtsID 
  		{ 
  			get 
  			{ 
  				return m_LoadDtsID ; 
  			}  
  			set 
  			{ 
  				m_LoadDtsID = value ; 
  			}  
  		} 
  
  		private int m_SubSeq = 0; 
  		public int SubSeq 
  		{ 
  			get 
  			{ 
  				return m_SubSeq ; 
  			}  
  			set 
  			{ 
  				m_SubSeq = value ; 
  			}  
  		} 
  
  		private string m_CardNo = string.Empty ; 
  		public string CardNo 
  		{ 
  			get 
  			{ 
  				return m_CardNo ; 
  			}  
  			set 
  			{ 
  				m_CardNo = value ; 
  			}  
  		} 
  
  		private DateTime m_CardTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime CardTime 
  		{ 
  			get 
  			{ 
  				return m_CardTime ; 
  			}  
  			set 
  			{ 
  				m_CardTime = value ; 
  			}  
  		} 
  
  		private decimal m_CardQty = 0; 
  		public decimal CardQty 
  		{ 
  			get 
  			{ 
  				return m_CardQty ; 
  			}  
  			set 
  			{ 
  				m_CardQty = value ; 
  			}  
  		} 
  
  		private int m_StepID = 0; 
  		public int StepID 
  		{ 
  			get 
  			{ 
  				return m_StepID ; 
  			}  
  			set 
  			{ 
  				m_StepID = value ; 
  			}  
  		} 
  
  		private string m_CardOPID = string.Empty ; 
  		public string CardOPID 
  		{ 
  			get 
  			{ 
  				return m_CardOPID ; 
  			}  
  			set 
  			{ 
  				m_CardOPID = value ; 
  			}  
  		} 
  
  		private string m_CardOPName = string.Empty ; 
  		public string CardOPName 
  		{ 
  			get 
  			{ 
  				return m_CardOPName ; 
  			}  
  			set 
  			{ 
  				m_CardOPName = value ; 
  			}  
  		} 
  
  		private int m_KBFlag = 0; 
  		public int KBFlag 
  		{ 
  			get 
  			{ 
  				return m_KBFlag ; 
  			}  
  			set 
  			{ 
  				m_KBFlag = value ; 
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
  
  		private decimal m_LLQty = 0; 
  		public decimal LLQty 
  		{ 
  			get 
  			{ 
  				return m_LLQty ; 
  			}  
  			set 
  			{ 
  				m_LLQty = value ; 
  			}  
  		} 
  
  		private string m_LLUnit = string.Empty ; 
  		public string LLUnit 
  		{ 
  			get 
  			{ 
  				return m_LLUnit ; 
  			}  
  			set 
  			{ 
  				m_LLUnit = value ; 
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
            string Sql="SELECT * FROM WO_TowelProductionPlanDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_TowelProductionPlanDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_PieceQty=SysConvert.ToInt32(MasterTable.Rows[0]["PieceQty"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_SinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SinglePrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_DtsSO=SysConvert.ToString(MasterTable.Rows[0]["DtsSO"]); 
  				m_LoadDtsID=SysConvert.ToInt32(MasterTable.Rows[0]["LoadDtsID"]); 
  				m_SubSeq=SysConvert.ToInt32(MasterTable.Rows[0]["SubSeq"]); 
  				m_CardNo=SysConvert.ToString(MasterTable.Rows[0]["CardNo"]); 
  				m_CardTime=SysConvert.ToDateTime(MasterTable.Rows[0]["CardTime"]); 
  				m_CardQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CardQty"]); 
  				m_StepID=SysConvert.ToInt32(MasterTable.Rows[0]["StepID"]); 
  				m_CardOPID=SysConvert.ToString(MasterTable.Rows[0]["CardOPID"]); 
  				m_CardOPName=SysConvert.ToString(MasterTable.Rows[0]["CardOPName"]); 
  				m_KBFlag=SysConvert.ToInt32(MasterTable.Rows[0]["KBFlag"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_LLQty=SysConvert.ToDecimal(MasterTable.Rows[0]["LLQty"]); 
  				m_LLUnit=SysConvert.ToString(MasterTable.Rows[0]["LLUnit"]); 
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
