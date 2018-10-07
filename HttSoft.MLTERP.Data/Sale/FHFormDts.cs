using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_FHFormDts实体类
	/// 作者:qiuchao
	/// 创建日期:2015/7/6
	/// </summary>
	public sealed class FHFormDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FHFormDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FHFormDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_FHFormDts";
		 
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
  
  		private string m_GoodsCode = string.Empty ; 
  		public string GoodsCode 
  		{ 
  			get 
  			{ 
  				return m_GoodsCode ; 
  			}  
  			set 
  			{ 
  				m_GoodsCode = value ; 
  			}  
  		} 
  
  		private string m_GoodsLevel = string.Empty ; 
  		public string GoodsLevel 
  		{ 
  			get 
  			{ 
  				return m_GoodsLevel ; 
  			}  
  			set 
  			{ 
  				m_GoodsLevel = value ; 
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
  
  		private string m_WeightUnit = string.Empty ; 
  		public string WeightUnit 
  		{ 
  			get 
  			{ 
  				return m_WeightUnit ; 
  			}  
  			set 
  			{ 
  				m_WeightUnit = value ; 
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
  
  		private string m_VColorNum = string.Empty ; 
  		public string VColorNum 
  		{ 
  			get 
  			{ 
  				return m_VColorNum ; 
  			}  
  			set 
  			{ 
  				m_VColorNum = value ; 
  			}  
  		} 
  
  		private string m_VColorName = string.Empty ; 
  		public string VColorName 
  		{ 
  			get 
  			{ 
  				return m_VColorName ; 
  			}  
  			set 
  			{ 
  				m_VColorName = value ; 
  			}  
  		} 
  
  		private string m_VItemCode = string.Empty ; 
  		public string VItemCode 
  		{ 
  			get 
  			{ 
  				return m_VItemCode ; 
  			}  
  			set 
  			{ 
  				m_VItemCode = value ; 
  			}  
  		} 
  
  		private decimal m_PieceQty = 0; 
  		public decimal PieceQty 
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
  
  		private decimal m_SingPrice = 0; 
  		public decimal SingPrice 
  		{ 
  			get 
  			{ 
  				return m_SingPrice ; 
  			}  
  			set 
  			{ 
  				m_SingPrice = value ; 
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
  
  		private string m_DtsOrderFormNo = string.Empty ; 
  		public string DtsOrderFormNo 
  		{ 
  			get 
  			{ 
  				return m_DtsOrderFormNo ; 
  			}  
  			set 
  			{ 
  				m_DtsOrderFormNo = value ; 
  			}  
  		} 
  
  		private string m_DtsDYFormNo = string.Empty ; 
  		public string DtsDYFormNo 
  		{ 
  			get 
  			{ 
  				return m_DtsDYFormNo ; 
  			}  
  			set 
  			{ 
  				m_DtsDYFormNo = value ; 
  			}  
  		} 
  
  		private int m_DtsSendFlag = 0; 
  		public int DtsSendFlag 
  		{ 
  			get 
  			{ 
  				return m_DtsSendFlag ; 
  			}  
  			set 
  			{ 
  				m_DtsSendFlag = value ; 
  			}  
  		} 
  
  		private decimal m_TotalSendQty = 0; 
  		public decimal TotalSendQty 
  		{ 
  			get 
  			{ 
  				return m_TotalSendQty ; 
  			}  
  			set 
  			{ 
  				m_TotalSendQty = value ; 
  			}  
  		} 
  
  		private DateTime m_SendDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SendDate 
  		{ 
  			get 
  			{ 
  				return m_SendDate ; 
  			}  
  			set 
  			{ 
  				m_SendDate = value ; 
  			}  
  		} 
  
  		private string m_PackDts = string.Empty ; 
  		public string PackDts 
  		{ 
  			get 
  			{ 
  				return m_PackDts ; 
  			}  
  			set 
  			{ 
  				m_PackDts = value ; 
  			}  
  		} 
  
  		private int m_FHFlag = 0; 
  		public int FHFlag 
  		{ 
  			get 
  			{ 
  				return m_FHFlag ; 
  			}  
  			set 
  			{ 
  				m_FHFlag = value ; 
  			}  
  		} 
  
  		private decimal m_DYPrice = 0; 
  		public decimal DYPrice 
  		{ 
  			get 
  			{ 
  				return m_DYPrice ; 
  			}  
  			set 
  			{ 
  				m_DYPrice = value ; 
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
  
  		private string m_SectionID = string.Empty ; 
  		public string SectionID 
  		{ 
  			get 
  			{ 
  				return m_SectionID ; 
  			}  
  			set 
  			{ 
  				m_SectionID = value ; 
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
  
  		private int m_PackFlag = 0; 
  		public int PackFlag 
  		{ 
  			get 
  			{ 
  				return m_PackFlag ; 
  			}  
  			set 
  			{ 
  				m_PackFlag = value ; 
  			}  
  		} 
  
  		private decimal m_InputQty = 0; 
  		public decimal InputQty 
  		{ 
  			get 
  			{ 
  				return m_InputQty ; 
  			}  
  			set 
  			{ 
  				m_InputQty = value ; 
  			}  
  		} 
  
  		private string m_InputUnit = string.Empty ; 
  		public string InputUnit 
  		{ 
  			get 
  			{ 
  				return m_InputUnit ; 
  			}  
  			set 
  			{ 
  				m_InputUnit = value ; 
  			}  
  		} 
  
  		private decimal m_InputSinglePrice = 0; 
  		public decimal InputSinglePrice 
  		{ 
  			get 
  			{ 
  				return m_InputSinglePrice ; 
  			}  
  			set 
  			{ 
  				m_InputSinglePrice = value ; 
  			}  
  		} 
  
  		private decimal m_InputAmount = 0; 
  		public decimal InputAmount 
  		{ 
  			get 
  			{ 
  				return m_InputAmount ; 
  			}  
  			set 
  			{ 
  				m_InputAmount = value ; 
  			}  
  		} 
  
  		private decimal m_InputConvertXS = 0; 
  		public decimal InputConvertXS 
  		{ 
  			get 
  			{ 
  				return m_InputConvertXS ; 
  			}  
  			set 
  			{ 
  				m_InputConvertXS = value ; 
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
            string Sql="SELECT * FROM Sale_FHFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_FHFormDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_GoodsLevel=SysConvert.ToString(MasterTable.Rows[0]["GoodsLevel"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_PieceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["PieceQty"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_SingPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["SingPrice"]); 
  				m_Amount=SysConvert.ToDecimal(MasterTable.Rows[0]["Amount"]); 
  				m_DtsOrderFormNo=SysConvert.ToString(MasterTable.Rows[0]["DtsOrderFormNo"]); 
  				m_DtsDYFormNo=SysConvert.ToString(MasterTable.Rows[0]["DtsDYFormNo"]); 
  				m_DtsSendFlag=SysConvert.ToInt32(MasterTable.Rows[0]["DtsSendFlag"]); 
  				m_TotalSendQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalSendQty"]); 
  				m_SendDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SendDate"]); 
  				m_PackDts=SysConvert.ToString(MasterTable.Rows[0]["PackDts"]); 
  				m_FHFlag=SysConvert.ToInt32(MasterTable.Rows[0]["FHFlag"]); 
  				m_DYPrice=SysConvert.ToDecimal(MasterTable.Rows[0]["DYPrice"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_SectionID=SysConvert.ToString(MasterTable.Rows[0]["SectionID"]); 
  				m_Batch=SysConvert.ToString(MasterTable.Rows[0]["Batch"]); 
  				m_PackFlag=SysConvert.ToInt32(MasterTable.Rows[0]["PackFlag"]); 
  				m_InputQty=SysConvert.ToDecimal(MasterTable.Rows[0]["InputQty"]); 
  				m_InputUnit=SysConvert.ToString(MasterTable.Rows[0]["InputUnit"]); 
  				m_InputSinglePrice=SysConvert.ToDecimal(MasterTable.Rows[0]["InputSinglePrice"]); 
  				m_InputAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["InputAmount"]); 
  				m_InputConvertXS=SysConvert.ToDecimal(MasterTable.Rows[0]["InputConvertXS"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
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
