using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�Sale_SaleOrderFabricCompSiteʵ����
	/// ����:�¼Ӻ�
	/// ��������:2014/5/21
	/// </summary>
	public sealed class SaleOrderFabricCompSite : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SaleOrderFabricCompSite()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public SaleOrderFabricCompSite(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		 
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
  
  		private int m_ComTypeID = 0; 
  		public int ComTypeID 
  		{ 
  			get 
  			{ 
  				return m_ComTypeID ; 
  			}  
  			set 
  			{ 
  				m_ComTypeID = value ; 
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
  
  		private decimal m_RQty = 0; 
  		public decimal RQty 
  		{ 
  			get 
  			{ 
  				return m_RQty ; 
  			}  
  			set 
  			{ 
  				m_RQty = value ; 
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
  
  		private int m_DID = 0; 
  		public int DID 
  		{ 
  			get 
  			{ 
  				return m_DID ; 
  			}  
  			set 
  			{ 
  				m_DID = value ; 
  			}  
  		} 
  
  		private decimal m_SH = 0; 
  		public decimal SH 
  		{ 
  			get 
  			{ 
  				return m_SH ; 
  			}  
  			set 
  			{ 
  				m_SH = value ; 
  			}  
  		} 
  
  		private decimal m_SQty = 0; 
  		public decimal SQty 
  		{ 
  			get 
  			{ 
  				return m_SQty ; 
  			}  
  			set 
  			{ 
  				m_SQty = value ; 
  			}  
  		} 
  
  		private decimal m_BL = 0; 
  		public decimal BL 
  		{ 
  			get 
  			{ 
  				return m_BL ; 
  			}  
  			set 
  			{ 
  				m_BL = value ; 
  			}  
  		} 
 
		#endregion
		
		/// <summary>
        /// ��ID��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>IDΪ�ؼ���</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Sale_SaleOrderFabricCompSite WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Sale_SaleOrderFabricCompSite WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// �������SQL����ѯ������Ը�ֵ
        /// </summary>
        /// <param name="p_Sql">SQL���</param>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
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
                //��ѯ�����¼
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_ComTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["ComTypeID"]); 
  				m_ItemCode=SysConvert.ToString(MasterTable.Rows[0]["ItemCode"]); 
  				m_ItemName=SysConvert.ToString(MasterTable.Rows[0]["ItemName"]); 
  				m_ItemStd=SysConvert.ToString(MasterTable.Rows[0]["ItemStd"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Unit=SysConvert.ToString(MasterTable.Rows[0]["Unit"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_VendorID=SysConvert.ToString(MasterTable.Rows[0]["VendorID"]); 
  				m_ColorNum=SysConvert.ToString(MasterTable.Rows[0]["ColorNum"]); 
  				m_ColorName=SysConvert.ToString(MasterTable.Rows[0]["ColorName"]); 
  				m_SO=SysConvert.ToString(MasterTable.Rows[0]["SO"]); 
  				m_RQty=SysConvert.ToDecimal(MasterTable.Rows[0]["RQty"]); 
  				m_ItemModel=SysConvert.ToString(MasterTable.Rows[0]["ItemModel"]); 
  				m_DID=SysConvert.ToInt32(MasterTable.Rows[0]["DID"]); 
  				m_SH=SysConvert.ToDecimal(MasterTable.Rows[0]["SH"]); 
  				m_SQty=SysConvert.ToDecimal(MasterTable.Rows[0]["SQty"]); 
  				m_BL=SysConvert.ToDecimal(MasterTable.Rows[0]["BL"]); 
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
