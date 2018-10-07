using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// Ŀ�ģ�WO_TowelProductionPlanDtsStepProductsʵ����
	/// ����:zhp
	/// ��������:2016/9/21
	/// </summary>
	public sealed class TowelProductionPlanDtsStepProducts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public TowelProductionPlanDtsStepProducts()
		{
		     
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public TowelProductionPlanDtsStepProducts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region ����
		public static readonly string TableName = "WO_TowelProductionPlanDtsStepProducts";
		 
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
  
  		private int m_DtsID = 0; 
  		public int DtsID 
  		{ 
  			get 
  			{ 
  				return m_DtsID ; 
  			}  
  			set 
  			{ 
  				m_DtsID = value ; 
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
  
  		private string m_ProOPID = string.Empty ; 
  		public string ProOPID 
  		{ 
  			get 
  			{ 
  				return m_ProOPID ; 
  			}  
  			set 
  			{ 
  				m_ProOPID = value ; 
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
  
  		private decimal m_CQty = 0; 
  		public decimal CQty 
  		{ 
  			get 
  			{ 
  				return m_CQty ; 
  			}  
  			set 
  			{ 
  				m_CQty = value ; 
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
  
  		private string m_SeCha = string.Empty ; 
  		public string SeCha 
  		{ 
  			get 
  			{ 
  				return m_SeCha ; 
  			}  
  			set 
  			{ 
  				m_SeCha = value ; 
  			}  
  		} 
  
  		private string m_SeLaoDu = string.Empty ; 
  		public string SeLaoDu 
  		{ 
  			get 
  			{ 
  				return m_SeLaoDu ; 
  			}  
  			set 
  			{ 
  				m_SeLaoDu = value ; 
  			}  
  		} 
  
  		private string m_XiShuiXing = string.Empty ; 
  		public string XiShuiXing 
  		{ 
  			get 
  			{ 
  				return m_XiShuiXing ; 
  			}  
  			set 
  			{ 
  				m_XiShuiXing = value ; 
  			}  
  		} 
  
  		private string m_Conclusion = string.Empty ; 
  		public string Conclusion 
  		{ 
  			get 
  			{ 
  				return m_Conclusion ; 
  			}  
  			set 
  			{ 
  				m_Conclusion = value ; 
  			}  
  		} 
  
  		private decimal m_MLDefect = 0; 
  		public decimal MLDefect 
  		{ 
  			get 
  			{ 
  				return m_MLDefect ; 
  			}  
  			set 
  			{ 
  				m_MLDefect = value ; 
  			}  
  		} 
  
  		private decimal m_RSDefect = 0; 
  		public decimal RSDefect 
  		{ 
  			get 
  			{ 
  				return m_RSDefect ; 
  			}  
  			set 
  			{ 
  				m_RSDefect = value ; 
  			}  
  		} 
  
  		private decimal m_FRDefect = 0; 
  		public decimal FRDefect 
  		{ 
  			get 
  			{ 
  				return m_FRDefect ; 
  			}  
  			set 
  			{ 
  				m_FRDefect = value ; 
  			}  
  		} 
  
  		private decimal m_OtherDefect = 0; 
  		public decimal OtherDefect 
  		{ 
  			get 
  			{ 
  				return m_OtherDefect ; 
  			}  
  			set 
  			{ 
  				m_OtherDefect = value ; 
  			}  
  		} 
  
  		private DateTime m_WorkStartTime = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime WorkStartTime 
  		{ 
  			get 
  			{ 
  				return m_WorkStartTime ; 
  			}  
  			set 
  			{ 
  				m_WorkStartTime = value ; 
  			}  
  		} 
  
  		private decimal m_WorkingHours = 0; 
  		public decimal WorkingHours 
  		{ 
  			get 
  			{ 
  				return m_WorkingHours ; 
  			}  
  			set 
  			{ 
  				m_WorkingHours = value ; 
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
            string Sql="SELECT * FROM WO_TowelProductionPlanDtsStepProducts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// ��Code��ѯ
        /// </summary>
        /// <returns>��¼���ڻ�true�������ڷ���false</returns>
        /// <remarks>Code����Ψһ</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_TowelProductionPlanDtsStepProducts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_DtsID=SysConvert.ToInt32(MasterTable.Rows[0]["DtsID"]); 
  				m_SubSeq=SysConvert.ToInt32(MasterTable.Rows[0]["SubSeq"]); 
  				m_StepID=SysConvert.ToInt32(MasterTable.Rows[0]["StepID"]); 
  				m_CardNo=SysConvert.ToString(MasterTable.Rows[0]["CardNo"]); 
  				m_ProOPID=SysConvert.ToString(MasterTable.Rows[0]["ProOPID"]); 
  				m_Qty=SysConvert.ToDecimal(MasterTable.Rows[0]["Qty"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_RecQty=SysConvert.ToDecimal(MasterTable.Rows[0]["RecQty"]); 
  				m_CQty=SysConvert.ToDecimal(MasterTable.Rows[0]["CQty"]); 
  				m_JarNum=SysConvert.ToString(MasterTable.Rows[0]["JarNum"]); 
  				m_MWidth=SysConvert.ToString(MasterTable.Rows[0]["MWidth"]); 
  				m_MWeight=SysConvert.ToString(MasterTable.Rows[0]["MWeight"]); 
  				m_SeCha=SysConvert.ToString(MasterTable.Rows[0]["SeCha"]); 
  				m_SeLaoDu=SysConvert.ToString(MasterTable.Rows[0]["SeLaoDu"]); 
  				m_XiShuiXing=SysConvert.ToString(MasterTable.Rows[0]["XiShuiXing"]); 
  				m_Conclusion=SysConvert.ToString(MasterTable.Rows[0]["Conclusion"]); 
  				m_MLDefect=SysConvert.ToDecimal(MasterTable.Rows[0]["MLDefect"]); 
  				m_RSDefect=SysConvert.ToDecimal(MasterTable.Rows[0]["RSDefect"]); 
  				m_FRDefect=SysConvert.ToDecimal(MasterTable.Rows[0]["FRDefect"]); 
  				m_OtherDefect=SysConvert.ToDecimal(MasterTable.Rows[0]["OtherDefect"]); 
  				m_WorkStartTime=SysConvert.ToDateTime(MasterTable.Rows[0]["WorkStartTime"]); 
  				m_WorkingHours=SysConvert.ToDecimal(MasterTable.Rows[0]["WorkingHours"]); 
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
