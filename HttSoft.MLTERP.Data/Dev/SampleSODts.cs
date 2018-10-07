using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Dev_SampleSODts实体类
	/// 作者:邱继中
	/// 创建日期:2014/6/9
	/// </summary>
	public sealed class SampleSODts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SampleSODts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SampleSODts(IDBTransAccess p_SqlCmd)
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
  
  		private decimal m_MWidth = 0; 
  		public decimal MWidth 
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
  
  		private decimal m_MWeight = 0; 
  		public decimal MWeight 
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
  
  		private string m_DesignNo = string.Empty ; 
  		public string DesignNo 
  		{ 
  			get 
  			{ 
  				return m_DesignNo ; 
  			}  
  			set 
  			{ 
  				m_DesignNo = value ; 
  			}  
  		} 
  
  		private string m_DesignType = string.Empty ; 
  		public string DesignType 
  		{ 
  			get 
  			{ 
  				return m_DesignType ; 
  			}  
  			set 
  			{ 
  				m_DesignType = value ; 
  			}  
  		} 
  
  		private string m_VendorItemCode = string.Empty ; 
  		public string VendorItemCode 
  		{ 
  			get 
  			{ 
  				return m_VendorItemCode ; 
  			}  
  			set 
  			{ 
  				m_VendorItemCode = value ; 
  			}  
  		} 
  
  		private string m_BFabirPZ = string.Empty ; 
  		public string BFabirPZ 
  		{ 
  			get 
  			{ 
  				return m_BFabirPZ ; 
  			}  
  			set 
  			{ 
  				m_BFabirPZ = value ; 
  			}  
  		} 
  
  		private string m_XHXPZ = string.Empty ; 
  		public string XHXPZ 
  		{ 
  			get 
  			{ 
  				return m_XHXPZ ; 
  			}  
  			set 
  			{ 
  				m_XHXPZ = value ; 
  			}  
  		} 
  
  		private string m_BFabricColor = string.Empty ; 
  		public string BFabricColor 
  		{ 
  			get 
  			{ 
  				return m_BFabricColor ; 
  			}  
  			set 
  			{ 
  				m_BFabricColor = value ; 
  			}  
  		} 
  
  		private string m_XHXColor = string.Empty ; 
  		public string XHXColor 
  		{ 
  			get 
  			{ 
  				return m_XHXColor ; 
  			}  
  			set 
  			{ 
  				m_XHXColor = value ; 
  			}  
  		} 
  
  		private string m_XHXType = string.Empty ; 
  		public string XHXType 
  		{ 
  			get 
  			{ 
  				return m_XHXType ; 
  			}  
  			set 
  			{ 
  				m_XHXType = value ; 
  			}  
  		} 
  
  		private decimal m_XHMWidth = 0; 
  		public decimal XHMWidth 
  		{ 
  			get 
  			{ 
  				return m_XHMWidth ; 
  			}  
  			set 
  			{ 
  				m_XHMWidth = value ; 
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
            string Sql="SELECT * FROM Dev_SampleSODts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Dev_SampleSODts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_DesignNo=SysConvert.ToString(MasterTable.Rows[0]["DesignNo"]); 
  				m_DesignType=SysConvert.ToString(MasterTable.Rows[0]["DesignType"]); 
  				m_VendorItemCode=SysConvert.ToString(MasterTable.Rows[0]["VendorItemCode"]); 
  				m_BFabirPZ=SysConvert.ToString(MasterTable.Rows[0]["BFabirPZ"]); 
  				m_XHXPZ=SysConvert.ToString(MasterTable.Rows[0]["XHXPZ"]); 
  				m_BFabricColor=SysConvert.ToString(MasterTable.Rows[0]["BFabricColor"]); 
  				m_XHXColor=SysConvert.ToString(MasterTable.Rows[0]["XHXColor"]); 
  				m_XHXType=SysConvert.ToString(MasterTable.Rows[0]["XHXType"]); 
  				m_XHMWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["XHMWidth"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
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
