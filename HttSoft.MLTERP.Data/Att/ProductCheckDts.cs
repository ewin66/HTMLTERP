using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Att_ProductCheckDts实体类
	/// 作者:cyj
	/// 创建日期:2013/3/4
	/// </summary>
	public sealed class ProductCheckDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ProductCheckDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ProductCheckDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Att_ProductCheckDts";
		 
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
  
  		private int m_PS = 0; 
  		public int PS 
  		{ 
  			get 
  			{ 
  				return m_PS ; 
  			}  
  			set 
  			{ 
  				m_PS = value ; 
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
  
  		private decimal m_RecQty = 0; 
  		public decimal RecQty 
  		{ 
  			get 
  			{ 
  				return m_RecQty ; 
  			}  
  			set 
  			{ 
  				m_RecQty = value ; 
  			}  
  		} 
  
  		private decimal m_CheckGQty = 0; 
  		public decimal CheckGQty 
  		{ 
  			get 
  			{ 
  				return m_CheckGQty ; 
  			}  
  			set 
  			{ 
  				m_CheckGQty = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQty = 0; 
  		public decimal CheckQty 
  		{ 
  			get 
  			{ 
  				return m_CheckQty ; 
  			}  
  			set 
  			{ 
  				m_CheckQty = value ; 
  			}  
  		} 
  
  		private decimal m_CheckCQty = 0; 
  		public decimal CheckCQty 
  		{ 
  			get 
  			{ 
  				return m_CheckCQty ; 
  			}  
  			set 
  			{ 
  				m_CheckCQty = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty1 = 0; 
  		public decimal CheckQQty1 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty1 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty1 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty2 = 0; 
  		public decimal CheckQQty2 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty2 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty2 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty3 = 0; 
  		public decimal CheckQQty3 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty3 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty3 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty4 = 0; 
  		public decimal CheckQQty4 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty4 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty4 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty5 = 0; 
  		public decimal CheckQQty5 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty5 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty5 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty6 = 0; 
  		public decimal CheckQQty6 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty6 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty6 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty7 = 0; 
  		public decimal CheckQQty7 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty7 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty7 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty8 = 0; 
  		public decimal CheckQQty8 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty8 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty8 = value ; 
  			}  
  		} 
  
  		private decimal m_CheckQQty9 = 0; 
  		public decimal CheckQQty9 
  		{ 
  			get 
  			{ 
  				return m_CheckQQty9 ; 
  			}  
  			set 
  			{ 
  				m_CheckQQty9 = value ; 
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
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Att_ProductCheckDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Att_ProductCheckDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_PS=SysConvert.ToInt32(MasterTable.Rows[0]["PS"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_VColorNum=SysConvert.ToString(MasterTable.Rows[0]["VColorNum"]); 
  				m_VColorName=SysConvert.ToString(MasterTable.Rows[0]["VColorName"]); 
  				m_VItemCode=SysConvert.ToString(MasterTable.Rows[0]["VItemCode"]); 
  				m_RecQty=SysConvert.ToDecimal(MasterTable.Rows[0]["RecQty"]); 
  				m_CheckGQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckGQty"]); 
  				m_CheckQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQty"]); 
  				m_CheckCQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckCQty"]); 
  				m_CheckQQty1=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty1"]); 
  				m_CheckQQty2=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty2"]); 
  				m_CheckQQty3=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty3"]); 
  				m_CheckQQty4=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty4"]); 
  				m_CheckQQty5=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty5"]); 
  				m_CheckQQty6=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty6"]); 
  				m_CheckQQty7=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty7"]); 
  				m_CheckQQty8=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty8"]); 
  				m_CheckQQty9=SysConvert.ToDecimal(MasterTable.Rows[0]["CheckQQty9"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_MWidth=SysConvert.ToDecimal(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToDecimal(MasterTable.Rows[0]["MWeight"]); 
  				m_WeightUnit=SysConvert.ToString(MasterTable.Rows[0]["WeightUnit"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
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
