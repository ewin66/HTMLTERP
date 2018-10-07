using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Att_ItemTestForm实体类
	/// 作者:qiuchao
	/// 创建日期:2015/8/15
	/// </summary>
	public sealed class ItemTestForm : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ItemTestForm()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ItemTestForm(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Att_ItemTestForm";
		 
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
  
  		private DateTime m_RecDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime RecDate 
  		{ 
  			get 
  			{ 
  				return m_RecDate ; 
  			}  
  			set 
  			{ 
  				m_RecDate = value ; 
  			}  
  		} 
  
  		private string m_BGNo = string.Empty ; 
  		public string BGNo 
  		{ 
  			get 
  			{ 
  				return m_BGNo ; 
  			}  
  			set 
  			{ 
  				m_BGNo = value ; 
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
  
  		private string m_CheckComID = string.Empty ; 
  		public string CheckComID 
  		{ 
  			get 
  			{ 
  				return m_CheckComID ; 
  			}  
  			set 
  			{ 
  				m_CheckComID = value ; 
  			}  
  		} 
  
  		private string m_FormType = string.Empty ; 
  		public string FormType 
  		{ 
  			get 
  			{ 
  				return m_FormType ; 
  			}  
  			set 
  			{ 
  				m_FormType = value ; 
  			}  
  		} 
  
  		private string m_FormStatus = string.Empty ; 
  		public string FormStatus 
  		{ 
  			get 
  			{ 
  				return m_FormStatus ; 
  			}  
  			set 
  			{ 
  				m_FormStatus = value ; 
  			}  
  		} 
  
  		private decimal m_TestFee = 0; 
  		public decimal TestFee 
  		{ 
  			get 
  			{ 
  				return m_TestFee ; 
  			}  
  			set 
  			{ 
  				m_TestFee = value ; 
  			}  
  		} 
  
  		private string m_TestContext = string.Empty ; 
  		public string TestContext 
  		{ 
  			get 
  			{ 
  				return m_TestContext ; 
  			}  
  			set 
  			{ 
  				m_TestContext = value ; 
  			}  
  		} 
  
  		private string m_YBGNo = string.Empty ; 
  		public string YBGNo 
  		{ 
  			get 
  			{ 
  				return m_YBGNo ; 
  			}  
  			set 
  			{ 
  				m_YBGNo = value ; 
  			}  
  		} 
  
  		private string m_YCheckComID = string.Empty ; 
  		public string YCheckComID 
  		{ 
  			get 
  			{ 
  				return m_YCheckComID ; 
  			}  
  			set 
  			{ 
  				m_YCheckComID = value ; 
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
  
  		private string m_FormXZ = string.Empty ; 
  		public string FormXZ 
  		{ 
  			get 
  			{ 
  				return m_FormXZ ; 
  			}  
  			set 
  			{ 
  				m_FormXZ = value ; 
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
  
  		private decimal m_JSFree = 0; 
  		public decimal JSFree 
  		{ 
  			get 
  			{ 
  				return m_JSFree ; 
  			}  
  			set 
  			{ 
  				m_JSFree = value ; 
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
  
  		private string m_VendorID2 = string.Empty ; 
  		public string VendorID2 
  		{ 
  			get 
  			{ 
  				return m_VendorID2 ; 
  			}  
  			set 
  			{ 
  				m_VendorID2 = value ; 
  			}  
  		} 
  
  		private string m_VendorID3 = string.Empty ; 
  		public string VendorID3 
  		{ 
  			get 
  			{ 
  				return m_VendorID3 ; 
  			}  
  			set 
  			{ 
  				m_VendorID3 = value ; 
  			}  
  		} 
  
  		private string m_VendorID4 = string.Empty ; 
  		public string VendorID4 
  		{ 
  			get 
  			{ 
  				return m_VendorID4 ; 
  			}  
  			set 
  			{ 
  				m_VendorID4 = value ; 
  			}  
  		} 
  
  		private string m_BGType = string.Empty ; 
  		public string BGType 
  		{ 
  			get 
  			{ 
  				return m_BGType ; 
  			}  
  			set 
  			{ 
  				m_BGType = value ; 
  			}  
  		} 
  
  		private int m_DLoadID = 0; 
  		public int DLoadID 
  		{ 
  			get 
  			{ 
  				return m_DLoadID ; 
  			}  
  			set 
  			{ 
  				m_DLoadID = value ; 
  			}  
  		} 
  
  		private string m_HTNo = string.Empty ; 
  		public string HTNo 
  		{ 
  			get 
  			{ 
  				return m_HTNo ; 
  			}  
  			set 
  			{ 
  				m_HTNo = value ; 
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
  
  		private string m_Used = string.Empty ; 
  		public string Used 
  		{ 
  			get 
  			{ 
  				return m_Used ; 
  			}  
  			set 
  			{ 
  				m_Used = value ; 
  			}  
  		} 
  
  		private string m_KDForm = string.Empty ; 
  		public string KDForm 
  		{ 
  			get 
  			{ 
  				return m_KDForm ; 
  			}  
  			set 
  			{ 
  				m_KDForm = value ; 
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
  
  		private string m_ItemClass = string.Empty ; 
  		public string ItemClass 
  		{ 
  			get 
  			{ 
  				return m_ItemClass ; 
  			}  
  			set 
  			{ 
  				m_ItemClass = value ; 
  			}  
  		} 
  
  		private string m_FPNO = string.Empty ; 
  		public string FPNO 
  		{ 
  			get 
  			{ 
  				return m_FPNO ; 
  			}  
  			set 
  			{ 
  				m_FPNO = value ; 
  			}  
  		} 
  
  		private DateTime m_FPDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FPDate 
  		{ 
  			get 
  			{ 
  				return m_FPDate ; 
  			}  
  			set 
  			{ 
  				m_FPDate = value ; 
  			}  
  		} 
  
  		private string m_JYOPName = string.Empty ; 
  		public string JYOPName 
  		{ 
  			get 
  			{ 
  				return m_JYOPName ; 
  			}  
  			set 
  			{ 
  				m_JYOPName = value ; 
  			}  
  		} 
  
  		private string m_OrderQty = string.Empty ; 
  		public string OrderQty 
  		{ 
  			get 
  			{ 
  				return m_OrderQty ; 
  			}  
  			set 
  			{ 
  				m_OrderQty = value ; 
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
            string Sql="SELECT * FROM Att_ItemTestForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Att_ItemTestForm WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ShopID=SysConvert.ToString(MasterTable.Rows[0]["ShopID"]); 
  				m_FormDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FormDate"]); 
  				m_SendDate=SysConvert.ToDateTime(MasterTable.Rows[0]["SendDate"]); 
  				m_RecDate=SysConvert.ToDateTime(MasterTable.Rows[0]["RecDate"]); 
  				m_BGNo=SysConvert.ToString(MasterTable.Rows[0]["BGNo"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_GoodsCode=SysConvert.ToString(MasterTable.Rows[0]["GoodsCode"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_CheckComID=SysConvert.ToString(MasterTable.Rows[0]["CheckComID"]); 
  				m_FormType=SysConvert.ToString(MasterTable.Rows[0]["FormType"]); 
  				m_FormStatus=SysConvert.ToString(MasterTable.Rows[0]["FormStatus"]); 
  				m_TestFee=SysConvert.ToDecimal(MasterTable.Rows[0]["TestFee"]); 
  				m_TestContext=SysConvert.ToString(MasterTable.Rows[0]["TestContext"]); 
  				m_YBGNo=SysConvert.ToString(MasterTable.Rows[0]["YBGNo"]); 
  				m_YCheckComID=SysConvert.ToString(MasterTable.Rows[0]["YCheckComID"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_FormXZ=SysConvert.ToString(MasterTable.Rows[0]["FormXZ"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_JSFlag=SysConvert.ToInt32(MasterTable.Rows[0]["JSFlag"]); 
  				m_JSFree=SysConvert.ToDecimal(MasterTable.Rows[0]["JSFree"]); 
  				m_JSDate=SysConvert.ToDateTime(MasterTable.Rows[0]["JSDate"]); 
  				m_VendorID2=SysConvert.ToString(MasterTable.Rows[0]["VendorID2"]); 
  				m_VendorID3=SysConvert.ToString(MasterTable.Rows[0]["VendorID3"]); 
  				m_VendorID4=SysConvert.ToString(MasterTable.Rows[0]["VendorID4"]); 
  				m_BGType=SysConvert.ToString(MasterTable.Rows[0]["BGType"]); 
  				m_DLoadID=SysConvert.ToInt32(MasterTable.Rows[0]["DLoadID"]); 
  				m_HTNo=SysConvert.ToString(MasterTable.Rows[0]["HTNo"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_Used=SysConvert.ToString(MasterTable.Rows[0]["Used"]); 
  				m_KDForm=SysConvert.ToString(MasterTable.Rows[0]["KDForm"]); 
  				m_SaleOPID=SysConvert.ToString(MasterTable.Rows[0]["SaleOPID"]); 
  				m_ItemClass=SysConvert.ToString(MasterTable.Rows[0]["ItemClass"]); 
  				m_FPNO=SysConvert.ToString(MasterTable.Rows[0]["FPNO"]); 
  				m_FPDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FPDate"]); 
  				m_JYOPName=SysConvert.ToString(MasterTable.Rows[0]["JYOPName"]); 
  				m_OrderQty=SysConvert.ToString(MasterTable.Rows[0]["OrderQty"]); 
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
