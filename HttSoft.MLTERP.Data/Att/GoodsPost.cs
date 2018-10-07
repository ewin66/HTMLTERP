using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Att_GoodsPost实体类
	/// 作者:章文强
	/// 创建日期:2014/3/20
	/// </summary>
	public sealed class GoodsPost : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public GoodsPost()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public GoodsPost(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Att_GoodsPost";
		 
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
  
  		private string m_PostComID = string.Empty ; 
  		public string PostComID 
  		{ 
  			get 
  			{ 
  				return m_PostComID ; 
  			}  
  			set 
  			{ 
  				m_PostComID = value ; 
  			}  
  		} 
  
  		private string m_PostCode = string.Empty ; 
  		public string PostCode 
  		{ 
  			get 
  			{ 
  				return m_PostCode ; 
  			}  
  			set 
  			{ 
  				m_PostCode = value ; 
  			}  
  		} 
  
  		private string m_RecName = string.Empty ; 
  		public string RecName 
  		{ 
  			get 
  			{ 
  				return m_RecName ; 
  			}  
  			set 
  			{ 
  				m_RecName = value ; 
  			}  
  		} 
  
  		private string m_RecPhone = string.Empty ; 
  		public string RecPhone 
  		{ 
  			get 
  			{ 
  				return m_RecPhone ; 
  			}  
  			set 
  			{ 
  				m_RecPhone = value ; 
  			}  
  		} 
  
  		private decimal m_PostFee = 0; 
  		public decimal PostFee 
  		{ 
  			get 
  			{ 
  				return m_PostFee ; 
  			}  
  			set 
  			{ 
  				m_PostFee = value ; 
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
  
  		private string m_FJR = string.Empty ; 
  		public string FJR 
  		{ 
  			get 
  			{ 
  				return m_FJR ; 
  			}  
  			set 
  			{ 
  				m_FJR = value ; 
  			}  
  		} 
  
  		private string m_PostType = string.Empty ; 
  		public string PostType 
  		{ 
  			get 
  			{ 
  				return m_PostType ; 
  			}  
  			set 
  			{ 
  				m_PostType = value ; 
  			}  
  		} 
  
  		private int m_GOFlag = 0; 
  		public int GOFlag 
  		{ 
  			get 
  			{ 
  				return m_GOFlag ; 
  			}  
  			set 
  			{ 
  				m_GOFlag = value ; 
  			}  
  		} 
  
  		private string m_SKType = string.Empty ; 
  		public string SKType 
  		{ 
  			get 
  			{ 
  				return m_SKType ; 
  			}  
  			set 
  			{ 
  				m_SKType = value ; 
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
  
  		private string m_JJVendor = string.Empty ; 
  		public string JJVendor 
  		{ 
  			get 
  			{ 
  				return m_JJVendor ; 
  			}  
  			set 
  			{ 
  				m_JJVendor = value ; 
  			}  
  		} 
  
  		private string m_PostComFirst = string.Empty ; 
  		public string PostComFirst 
  		{ 
  			get 
  			{ 
  				return m_PostComFirst ; 
  			}  
  			set 
  			{ 
  				m_PostComFirst = value ; 
  			}  
  		} 
  
  		private string m_ConFormNo = string.Empty ; 
  		public string ConFormNo 
  		{ 
  			get 
  			{ 
  				return m_ConFormNo ; 
  			}  
  			set 
  			{ 
  				m_ConFormNo = value ; 
  			}  
  		} 
  
  		private int m_ConID = 0; 
  		public int ConID 
  		{ 
  			get 
  			{ 
  				return m_ConID ; 
  			}  
  			set 
  			{ 
  				m_ConID = value ; 
  			}  
  		} 
  
  		private string m_Context = string.Empty ; 
  		public string Context 
  		{ 
  			get 
  			{ 
  				return m_Context ; 
  			}  
  			set 
  			{ 
  				m_Context = value ; 
  			}  
  		} 
  
  		private int m_PostFormType = 0; 
  		public int PostFormType 
  		{ 
  			get 
  			{ 
  				return m_PostFormType ; 
  			}  
  			set 
  			{ 
  				m_PostFormType = value ; 
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
            string Sql="SELECT * FROM Att_GoodsPost WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Att_GoodsPost WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_PostComID=SysConvert.ToString(MasterTable.Rows[0]["PostComID"]); 
  				m_PostCode=SysConvert.ToString(MasterTable.Rows[0]["PostCode"]); 
  				m_RecName=SysConvert.ToString(MasterTable.Rows[0]["RecName"]); 
  				m_RecPhone=SysConvert.ToString(MasterTable.Rows[0]["RecPhone"]); 
  				m_PostFee=SysConvert.ToDecimal(MasterTable.Rows[0]["PostFee"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_RecAddress=SysConvert.ToString(MasterTable.Rows[0]["RecAddress"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_JSFlag=SysConvert.ToInt32(MasterTable.Rows[0]["JSFlag"]); 
  				m_JSDate=SysConvert.ToDateTime(MasterTable.Rows[0]["JSDate"]); 
  				m_JSFee=SysConvert.ToDecimal(MasterTable.Rows[0]["JSFee"]); 
  				m_JSRemark=SysConvert.ToString(MasterTable.Rows[0]["JSRemark"]); 
  				m_FJR=SysConvert.ToString(MasterTable.Rows[0]["FJR"]); 
  				m_PostType=SysConvert.ToString(MasterTable.Rows[0]["PostType"]); 
  				m_GOFlag=SysConvert.ToInt32(MasterTable.Rows[0]["GOFlag"]); 
  				m_SKType=SysConvert.ToString(MasterTable.Rows[0]["SKType"]); 
  				m_TotalPieceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalPieceQty"]); 
  				m_TotalQty=SysConvert.ToDecimal(MasterTable.Rows[0]["TotalQty"]); 
  				m_JJVendor=SysConvert.ToString(MasterTable.Rows[0]["JJVendor"]); 
  				m_PostComFirst=SysConvert.ToString(MasterTable.Rows[0]["PostComFirst"]); 
  				m_ConFormNo=SysConvert.ToString(MasterTable.Rows[0]["ConFormNo"]); 
  				m_ConID=SysConvert.ToInt32(MasterTable.Rows[0]["ConID"]); 
  				m_Context=SysConvert.ToString(MasterTable.Rows[0]["Context"]); 
  				m_PostFormType=SysConvert.ToInt32(MasterTable.Rows[0]["PostFormType"]); 
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
