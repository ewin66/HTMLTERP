using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Dev_ColorCardDts实体类
	/// 作者:章文强
	/// 创建日期:2014/12/2
	/// </summary>
	public sealed class ColorCardDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public ColorCardDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public ColorCardDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Dev_ColorCardDts";
		 
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
  
  		private int m_ColorCardStatusID = 0; 
  		public int ColorCardStatusID 
  		{ 
  			get 
  			{ 
  				return m_ColorCardStatusID ; 
  			}  
  			set 
  			{ 
  				m_ColorCardStatusID = value ; 
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
  
  		private string m_Season = string.Empty ; 
  		public string Season 
  		{ 
  			get 
  			{ 
  				return m_Season ; 
  			}  
  			set 
  			{ 
  				m_Season = value ; 
  			}  
  		} 
  
  		private string m_DesignNO = string.Empty ; 
  		public string DesignNO 
  		{ 
  			get 
  			{ 
  				return m_DesignNO ; 
  			}  
  			set 
  			{ 
  				m_DesignNO = value ; 
  			}  
  		} 
  
  		private string m_VendorNO = string.Empty ; 
  		public string VendorNO 
  		{ 
  			get 
  			{ 
  				return m_VendorNO ; 
  			}  
  			set 
  			{ 
  				m_VendorNO = value ; 
  			}  
  		} 
  
  		private string m_DesignEdition = string.Empty ; 
  		public string DesignEdition 
  		{ 
  			get 
  			{ 
  				return m_DesignEdition ; 
  			}  
  			set 
  			{ 
  				m_DesignEdition = value ; 
  			}  
  		} 
  
  		private string m_OKEdition = string.Empty ; 
  		public string OKEdition 
  		{ 
  			get 
  			{ 
  				return m_OKEdition ; 
  			}  
  			set 
  			{ 
  				m_OKEdition = value ; 
  			}  
  		} 
  
  		private string m_FirstFinish = string.Empty ; 
  		public string FirstFinish 
  		{ 
  			get 
  			{ 
  				return m_FirstFinish ; 
  			}  
  			set 
  			{ 
  				m_FirstFinish = value ; 
  			}  
  		} 
  
  		private string m_FirstRemark = string.Empty ; 
  		public string FirstRemark 
  		{ 
  			get 
  			{ 
  				return m_FirstRemark ; 
  			}  
  			set 
  			{ 
  				m_FirstRemark = value ; 
  			}  
  		} 
  
  		private string m_SecondFinish = string.Empty ; 
  		public string SecondFinish 
  		{ 
  			get 
  			{ 
  				return m_SecondFinish ; 
  			}  
  			set 
  			{ 
  				m_SecondFinish = value ; 
  			}  
  		} 
  
  		private string m_SecondRemark = string.Empty ; 
  		public string SecondRemark 
  		{ 
  			get 
  			{ 
  				return m_SecondRemark ; 
  			}  
  			set 
  			{ 
  				m_SecondRemark = value ; 
  			}  
  		} 
  
  		private string m_ThirdFinish = string.Empty ; 
  		public string ThirdFinish 
  		{ 
  			get 
  			{ 
  				return m_ThirdFinish ; 
  			}  
  			set 
  			{ 
  				m_ThirdFinish = value ; 
  			}  
  		} 
  
  		private string m_ThirdRemark = string.Empty ; 
  		public string ThirdRemark 
  		{ 
  			get 
  			{ 
  				return m_ThirdRemark ; 
  			}  
  			set 
  			{ 
  				m_ThirdRemark = value ; 
  			}  
  		} 
  
  		private string m_FreeStr1 = string.Empty ; 
  		public string FreeStr1 
  		{ 
  			get 
  			{ 
  				return m_FreeStr1 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr1 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr2 = string.Empty ; 
  		public string FreeStr2 
  		{ 
  			get 
  			{ 
  				return m_FreeStr2 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr2 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr3 = string.Empty ; 
  		public string FreeStr3 
  		{ 
  			get 
  			{ 
  				return m_FreeStr3 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr3 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr4 = string.Empty ; 
  		public string FreeStr4 
  		{ 
  			get 
  			{ 
  				return m_FreeStr4 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr4 = value ; 
  			}  
  		} 
  
  		private string m_FreeStr5 = string.Empty ; 
  		public string FreeStr5 
  		{ 
  			get 
  			{ 
  				return m_FreeStr5 ; 
  			}  
  			set 
  			{ 
  				m_FreeStr5 = value ; 
  			}  
  		} 
  
  		private DateTime m_FreeDate1 = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FreeDate1 
  		{ 
  			get 
  			{ 
  				return m_FreeDate1 ; 
  			}  
  			set 
  			{ 
  				m_FreeDate1 = value ; 
  			}  
  		} 
  
  		private DateTime m_FreeDate2 = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FreeDate2 
  		{ 
  			get 
  			{ 
  				return m_FreeDate2 ; 
  			}  
  			set 
  			{ 
  				m_FreeDate2 = value ; 
  			}  
  		} 
  
  		private DateTime m_FreeDate3 = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FreeDate3 
  		{ 
  			get 
  			{ 
  				return m_FreeDate3 ; 
  			}  
  			set 
  			{ 
  				m_FreeDate3 = value ; 
  			}  
  		} 
  
  		private DateTime m_FreeDate4 = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FreeDate4 
  		{ 
  			get 
  			{ 
  				return m_FreeDate4 ; 
  			}  
  			set 
  			{ 
  				m_FreeDate4 = value ; 
  			}  
  		} 
  
  		private DateTime m_FreeDate5 = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FreeDate5 
  		{ 
  			get 
  			{ 
  				return m_FreeDate5 ; 
  			}  
  			set 
  			{ 
  				m_FreeDate5 = value ; 
  			}  
  		} 
  
  		private string m_DtsRemark = string.Empty ; 
  		public string DtsRemark 
  		{ 
  			get 
  			{ 
  				return m_DtsRemark ; 
  			}  
  			set 
  			{ 
  				m_DtsRemark = value ; 
  			}  
  		} 
  
  		private DateTime m_FinishDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime FinishDate 
  		{ 
  			get 
  			{ 
  				return m_FinishDate ; 
  			}  
  			set 
  			{ 
  				m_FinishDate = value ; 
  			}  
  		} 
  
  		private DateTime m_JYDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime JYDate 
  		{ 
  			get 
  			{ 
  				return m_JYDate ; 
  			}  
  			set 
  			{ 
  				m_JYDate = value ; 
  			}  
  		} 
  
  		private DateTime m_HGFinishDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime HGFinishDate 
  		{ 
  			get 
  			{ 
  				return m_HGFinishDate ; 
  			}  
  			set 
  			{ 
  				m_HGFinishDate = value ; 
  			}  
  		} 
  
  		private string m_HGBack = string.Empty ; 
  		public string HGBack 
  		{ 
  			get 
  			{ 
  				return m_HGBack ; 
  			}  
  			set 
  			{ 
  				m_HGBack = value ; 
  			}  
  		} 
  
  		private string m_FlowerNum = string.Empty ; 
  		public string FlowerNum 
  		{ 
  			get 
  			{ 
  				return m_FlowerNum ; 
  			}  
  			set 
  			{ 
  				m_FlowerNum = value ; 
  			}  
  		} 
  
  		private string m_ScrapSampleNo = string.Empty ; 
  		public string ScrapSampleNo 
  		{ 
  			get 
  			{ 
  				return m_ScrapSampleNo ; 
  			}  
  			set 
  			{ 
  				m_ScrapSampleNo = value ; 
  			}  
  		} 
  
  		private string m_MWidth2 = string.Empty ; 
  		public string MWidth2 
  		{ 
  			get 
  			{ 
  				return m_MWidth2 ; 
  			}  
  			set 
  			{ 
  				m_MWidth2 = value ; 
  			}  
  		} 
  
  		private string m_GYOPID = string.Empty ; 
  		public string GYOPID 
  		{ 
  			get 
  			{ 
  				return m_GYOPID ; 
  			}  
  			set 
  			{ 
  				m_GYOPID = value ; 
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
            string Sql="SELECT * FROM Dev_ColorCardDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Dev_ColorCardDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_ColorCardStatusID=SysConvert.ToInt32(MasterTable.Rows[0]["ColorCardStatusID"]); 
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
  				m_Season=SysConvert.ToString(MasterTable.Rows[0]["Season"]); 
  				m_DesignNO=SysConvert.ToString(MasterTable.Rows[0]["DesignNO"]); 
  				m_VendorNO=SysConvert.ToString(MasterTable.Rows[0]["VendorNO"]); 
  				m_DesignEdition=SysConvert.ToString(MasterTable.Rows[0]["DesignEdition"]); 
  				m_OKEdition=SysConvert.ToString(MasterTable.Rows[0]["OKEdition"]); 
  				m_FirstFinish=SysConvert.ToString(MasterTable.Rows[0]["FirstFinish"]); 
  				m_FirstRemark=SysConvert.ToString(MasterTable.Rows[0]["FirstRemark"]); 
  				m_SecondFinish=SysConvert.ToString(MasterTable.Rows[0]["SecondFinish"]); 
  				m_SecondRemark=SysConvert.ToString(MasterTable.Rows[0]["SecondRemark"]); 
  				m_ThirdFinish=SysConvert.ToString(MasterTable.Rows[0]["ThirdFinish"]); 
  				m_ThirdRemark=SysConvert.ToString(MasterTable.Rows[0]["ThirdRemark"]); 
  				m_FreeStr1=SysConvert.ToString(MasterTable.Rows[0]["FreeStr1"]); 
  				m_FreeStr2=SysConvert.ToString(MasterTable.Rows[0]["FreeStr2"]); 
  				m_FreeStr3=SysConvert.ToString(MasterTable.Rows[0]["FreeStr3"]); 
  				m_FreeStr4=SysConvert.ToString(MasterTable.Rows[0]["FreeStr4"]); 
  				m_FreeStr5=SysConvert.ToString(MasterTable.Rows[0]["FreeStr5"]); 
  				m_FreeDate1=SysConvert.ToDateTime(MasterTable.Rows[0]["FreeDate1"]); 
  				m_FreeDate2=SysConvert.ToDateTime(MasterTable.Rows[0]["FreeDate2"]); 
  				m_FreeDate3=SysConvert.ToDateTime(MasterTable.Rows[0]["FreeDate3"]); 
  				m_FreeDate4=SysConvert.ToDateTime(MasterTable.Rows[0]["FreeDate4"]); 
  				m_FreeDate5=SysConvert.ToDateTime(MasterTable.Rows[0]["FreeDate5"]); 
  				m_DtsRemark=SysConvert.ToString(MasterTable.Rows[0]["DtsRemark"]); 
  				m_FinishDate=SysConvert.ToDateTime(MasterTable.Rows[0]["FinishDate"]); 
  				m_JYDate=SysConvert.ToDateTime(MasterTable.Rows[0]["JYDate"]); 
  				m_HGFinishDate=SysConvert.ToDateTime(MasterTable.Rows[0]["HGFinishDate"]); 
  				m_HGBack=SysConvert.ToString(MasterTable.Rows[0]["HGBack"]); 
  				m_FlowerNum=SysConvert.ToString(MasterTable.Rows[0]["FlowerNum"]); 
  				m_ScrapSampleNo=SysConvert.ToString(MasterTable.Rows[0]["ScrapSampleNo"]); 
  				m_MWidth2=SysConvert.ToString(MasterTable.Rows[0]["MWidth2"]); 
  				m_GYOPID=SysConvert.ToString(MasterTable.Rows[0]["GYOPID"]); 
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
