using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Sale_ProductionNoticeDts实体类
	/// 作者:章文强
	/// 创建日期:2014/12/3
	/// </summary>
	public sealed class ProductionNoticeDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ProductionNoticeDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductionNoticeDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Sale_ProductionNoticeDts";
		 
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
  
  		private string m_ConfirmSample = string.Empty ; 
  		public string ConfirmSample 
  		{ 
  			get 
  			{ 
  				return m_ConfirmSample ; 
  			}  
  			set 
  			{ 
  				m_ConfirmSample = value ; 
  			}  
  		} 
  
  		private decimal m_SOQty = 0; 
  		public decimal SOQty 
  		{ 
  			get 
  			{ 
  				return m_SOQty ; 
  			}  
  			set 
  			{ 
  				m_SOQty = value ; 
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
  
  		private decimal m_TPQty = 0; 
  		public decimal TPQty 
  		{ 
  			get 
  			{ 
  				return m_TPQty ; 
  			}  
  			set 
  			{ 
  				m_TPQty = value ; 
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
  
  		private string m_DRemark = string.Empty ; 
  		public string DRemark 
  		{ 
  			get 
  			{ 
  				return m_DRemark ; 
  			}  
  			set 
  			{ 
  				m_DRemark = value ; 
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
  
  		private string m_Flower = string.Empty ; 
  		public string Flower 
  		{ 
  			get 
  			{ 
  				return m_Flower ; 
  			}  
  			set 
  			{ 
  				m_Flower = value ; 
  			}  
  		} 
  
  		private int m_LoadID = 0; 
  		public int LoadID 
  		{ 
  			get 
  			{ 
  				return m_LoadID ; 
  			}  
  			set 
  			{ 
  				m_LoadID = value ; 
  			}  
  		} 
  
  		private decimal m_TBCPQty = 0; 
  		public decimal TBCPQty 
  		{ 
  			get 
  			{ 
  				return m_TBCPQty ; 
  			}  
  			set 
  			{ 
  				m_TBCPQty = value ; 
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
  
  		private string m_MaxQty = string.Empty ; 
  		public string MaxQty 
  		{ 
  			get 
  			{ 
  				return m_MaxQty ; 
  			}  
  			set 
  			{ 
  				m_MaxQty = value ; 
  			}  
  		} 
  
  		private string m_MainQty = string.Empty ; 
  		public string MainQty 
  		{ 
  			get 
  			{ 
  				return m_MainQty ; 
  			}  
  			set 
  			{ 
  				m_MainQty = value ; 
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
  
  		private string m_OutRange = string.Empty ; 
  		public string OutRange 
  		{ 
  			get 
  			{ 
  				return m_OutRange ; 
  			}  
  			set 
  			{ 
  				m_OutRange = value ; 
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
        private string m_Needle = string.Empty;
        public string Needle
        {
            get
            {
                return m_Needle;
            }
            set
            {
                m_Needle = value;
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
            string Sql="SELECT * FROM Sale_ProductionNoticeDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_ProductionNoticeDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_SO=SysConvert.ToString(MasterTable.Rows[0]["SO"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ConfirmSample=SysConvert.ToString(MasterTable.Rows[0]["ConfirmSample"]); 
  				m_SOQty=SysConvert.ToDecimal(MasterTable.Rows[0]["SOQty"]); 
  				m_CPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CPQty"]); 
  				m_TPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TPQty"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_DRemark=SysConvert.ToString(MasterTable.Rows[0]["DRemark"]); 
  				m_Shrinkage=SysConvert.ToDecimal(MasterTable.Rows[0]["Shrinkage"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_Flower=SysConvert.ToString(MasterTable.Rows[0]["Flower"]); 
  				m_LoadID=SysConvert.ToInt32(MasterTable.Rows[0]["LoadID"]); 
  				m_TBCPQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TBCPQty"]); 
  				m_FactoryID=SysConvert.ToString(MasterTable.Rows[0]["FactoryID"]); 
  				m_ReqDate=SysConvert.ToDateTime(MasterTable.Rows[0]["ReqDate"]); 
  				m_MaxQty=SysConvert.ToString(MasterTable.Rows[0]["MaxQty"]); 
  				m_MainQty=SysConvert.ToString(MasterTable.Rows[0]["MainQty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_OutRange=SysConvert.ToString(MasterTable.Rows[0]["OutRange"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]);
                m_Needle = SysConvert.ToString(MasterTable.Rows[0]["Needle"]); 
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
