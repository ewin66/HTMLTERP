using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：WO_FabricProcessAdd实体类
	/// 作者:章文强
	/// 创建日期:2014/12/2
	/// </summary>
	public sealed class FabricProcessAdd : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public FabricProcessAdd()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public FabricProcessAdd(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "WO_FabricProcessAdd";
		 
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
  
  		private string m_Signed = string.Empty ; 
  		public string Signed 
  		{ 
  			get 
  			{ 
  				return m_Signed ; 
  			}  
  			set 
  			{ 
  				m_Signed = value ; 
  			}  
  		} 
  
  		private string m_Desizing = string.Empty ; 
  		public string Desizing 
  		{ 
  			get 
  			{ 
  				return m_Desizing ; 
  			}  
  			set 
  			{ 
  				m_Desizing = value ; 
  			}  
  		} 
  
  		private string m_Mercerized = string.Empty ; 
  		public string Mercerized 
  		{ 
  			get 
  			{ 
  				return m_Mercerized ; 
  			}  
  			set 
  			{ 
  				m_Mercerized = value ; 
  			}  
  		} 
  
  		private string m_Reactive = string.Empty ; 
  		public string Reactive 
  		{ 
  			get 
  			{ 
  				return m_Reactive ; 
  			}  
  			set 
  			{ 
  				m_Reactive = value ; 
  			}  
  		} 
  
  		private string m_Pigment = string.Empty ; 
  		public string Pigment 
  		{ 
  			get 
  			{ 
  				return m_Pigment ; 
  			}  
  			set 
  			{ 
  				m_Pigment = value ; 
  			}  
  		} 
  
  		private string m_NonAzo = string.Empty ; 
  		public string NonAzo 
  		{ 
  			get 
  			{ 
  				return m_NonAzo ; 
  			}  
  			set 
  			{ 
  				m_NonAzo = value ; 
  			}  
  		} 
  
  		private string m_Softner = string.Empty ; 
  		public string Softner 
  		{ 
  			get 
  			{ 
  				return m_Softner ; 
  			}  
  			set 
  			{ 
  				m_Softner = value ; 
  			}  
  		} 
  
  		private string m_Stentering = string.Empty ; 
  		public string Stentering 
  		{ 
  			get 
  			{ 
  				return m_Stentering ; 
  			}  
  			set 
  			{ 
  				m_Stentering = value ; 
  			}  
  		} 
  
  		private string m_Sanfor = string.Empty ; 
  		public string Sanfor 
  		{ 
  			get 
  			{ 
  				return m_Sanfor ; 
  			}  
  			set 
  			{ 
  				m_Sanfor = value ; 
  			}  
  		} 
  
  		private string m_Waterwash = string.Empty ; 
  		public string Waterwash 
  		{ 
  			get 
  			{ 
  				return m_Waterwash ; 
  			}  
  			set 
  			{ 
  				m_Waterwash = value ; 
  			}  
  		} 
  
  		private string m_Airowash = string.Empty ; 
  		public string Airowash 
  		{ 
  			get 
  			{ 
  				return m_Airowash ; 
  			}  
  			set 
  			{ 
  				m_Airowash = value ; 
  			}  
  		} 
  
  		private string m_Carbonpeach = string.Empty ; 
  		public string Carbonpeach 
  		{ 
  			get 
  			{ 
  				return m_Carbonpeach ; 
  			}  
  			set 
  			{ 
  				m_Carbonpeach = value ; 
  			}  
  		} 
  
  		private string m_Moleskin = string.Empty ; 
  		public string Moleskin 
  		{ 
  			get 
  			{ 
  				return m_Moleskin ; 
  			}  
  			set 
  			{ 
  				m_Moleskin = value ; 
  			}  
  		} 
  
  		private string m_PHValue = string.Empty ; 
  		public string PHValue 
  		{ 
  			get 
  			{ 
  				return m_PHValue ; 
  			}  
  			set 
  			{ 
  				m_PHValue = value ; 
  			}  
  		} 
  
  		private string m_SL = string.Empty ; 
  		public string SL 
  		{ 
  			get 
  			{ 
  				return m_SL ; 
  			}  
  			set 
  			{ 
  				m_SL = value ; 
  			}  
  		} 
  
  		private string m_GC = string.Empty ; 
  		public string GC 
  		{ 
  			get 
  			{ 
  				return m_GC ; 
  			}  
  			set 
  			{ 
  				m_GC = value ; 
  			}  
  		} 
  
  		private string m_SC = string.Empty ; 
  		public string SC 
  		{ 
  			get 
  			{ 
  				return m_SC ; 
  			}  
  			set 
  			{ 
  				m_SC = value ; 
  			}  
  		} 
  
  		private string m_Light = string.Empty ; 
  		public string Light 
  		{ 
  			get 
  			{ 
  				return m_Light ; 
  			}  
  			set 
  			{ 
  				m_Light = value ; 
  			}  
  		} 
  
  		private string m_XSHZSLD = string.Empty ; 
  		public string XSHZSLD 
  		{ 
  			get 
  			{ 
  				return m_XSHZSLD ; 
  			}  
  			set 
  			{ 
  				m_XSHZSLD = value ; 
  			}  
  		} 
  
  		private string m_PillingMartindale = string.Empty ; 
  		public string PillingMartindale 
  		{ 
  			get 
  			{ 
  				return m_PillingMartindale ; 
  			}  
  			set 
  			{ 
  				m_PillingMartindale = value ; 
  			}  
  		} 
  
  		private string m_DSGY1 = string.Empty ; 
  		public string DSGY1 
  		{ 
  			get 
  			{ 
  				return m_DSGY1 ; 
  			}  
  			set 
  			{ 
  				m_DSGY1 = value ; 
  			}  
  		} 
  
  		private string m_DSGY2 = string.Empty ; 
  		public string DSGY2 
  		{ 
  			get 
  			{ 
  				return m_DSGY2 ; 
  			}  
  			set 
  			{ 
  				m_DSGY2 = value ; 
  			}  
  		} 
  
  		private string m_DSGY3 = string.Empty ; 
  		public string DSGY3 
  		{ 
  			get 
  			{ 
  				return m_DSGY3 ; 
  			}  
  			set 
  			{ 
  				m_DSGY3 = value ; 
  			}  
  		} 
  
  		private string m_DSGY4 = string.Empty ; 
  		public string DSGY4 
  		{ 
  			get 
  			{ 
  				return m_DSGY4 ; 
  			}  
  			set 
  			{ 
  				m_DSGY4 = value ; 
  			}  
  		} 
  
  		private string m_DSGY5 = string.Empty ; 
  		public string DSGY5 
  		{ 
  			get 
  			{ 
  				return m_DSGY5 ; 
  			}  
  			set 
  			{ 
  				m_DSGY5 = value ; 
  			}  
  		} 
  
  		private string m_DSGY6 = string.Empty ; 
  		public string DSGY6 
  		{ 
  			get 
  			{ 
  				return m_DSGY6 ; 
  			}  
  			set 
  			{ 
  				m_DSGY6 = value ; 
  			}  
  		} 
  
  		private string m_TensileStrength = string.Empty ; 
  		public string TensileStrength 
  		{ 
  			get 
  			{ 
  				return m_TensileStrength ; 
  			}  
  			set 
  			{ 
  				m_TensileStrength = value ; 
  			}  
  		} 
  
  		private string m_TearingStrength = string.Empty ; 
  		public string TearingStrength 
  		{ 
  			get 
  			{ 
  				return m_TearingStrength ; 
  			}  
  			set 
  			{ 
  				m_TearingStrength = value ; 
  			}  
  		} 
  
  		private string m_SeamSlippage = string.Empty ; 
  		public string SeamSlippage 
  		{ 
  			get 
  			{ 
  				return m_SeamSlippage ; 
  			}  
  			set 
  			{ 
  				m_SeamSlippage = value ; 
  			}  
  		} 
  
  		private string m_XSLD = string.Empty ; 
  		public string XSLD 
  		{ 
  			get 
  			{ 
  				return m_XSLD ; 
  			}  
  			set 
  			{ 
  				m_XSLD = value ; 
  			}  
  		} 
  
  		private string m_XDLD = string.Empty ; 
  		public string XDLD 
  		{ 
  			get 
  			{ 
  				return m_XDLD ; 
  			}  
  			set 
  			{ 
  				m_XDLD = value ; 
  			}  
  		} 
  
  		private string m_WX = string.Empty ; 
  		public string WX 
  		{ 
  			get 
  			{ 
  				return m_WX ; 
  			}  
  			set 
  			{ 
  				m_WX = value ; 
  			}  
  		} 
  
  		private string m_ShipmentSample = string.Empty ; 
  		public string ShipmentSample 
  		{ 
  			get 
  			{ 
  				return m_ShipmentSample ; 
  			}  
  			set 
  			{ 
  				m_ShipmentSample = value ; 
  			}  
  		} 
  
  		private string m_ApprovedLab = string.Empty ; 
  		public string ApprovedLab 
  		{ 
  			get 
  			{ 
  				return m_ApprovedLab ; 
  			}  
  			set 
  			{ 
  				m_ApprovedLab = value ; 
  			}  
  		} 
  
  		private string m_HandFeelSample = string.Empty ; 
  		public string HandFeelSample 
  		{ 
  			get 
  			{ 
  				return m_HandFeelSample ; 
  			}  
  			set 
  			{ 
  				m_HandFeelSample = value ; 
  			}  
  		} 
  
  		private string m_Smooth = string.Empty ; 
  		public string Smooth 
  		{ 
  			get 
  			{ 
  				return m_Smooth ; 
  			}  
  			set 
  			{ 
  				m_Smooth = value ; 
  			}  
  		} 
  
  		private string m_Rough = string.Empty ; 
  		public string Rough 
  		{ 
  			get 
  			{ 
  				return m_Rough ; 
  			}  
  			set 
  			{ 
  				m_Rough = value ; 
  			}  
  		} 
  
  		private string m_RolledOnTube = string.Empty ; 
  		public string RolledOnTube 
  		{ 
  			get 
  			{ 
  				return m_RolledOnTube ; 
  			}  
  			set 
  			{ 
  				m_RolledOnTube = value ; 
  			}  
  		} 
  
  		private string m_PolyBagWrapped = string.Empty ; 
  		public string PolyBagWrapped 
  		{ 
  			get 
  			{ 
  				return m_PolyBagWrapped ; 
  			}  
  			set 
  			{ 
  				m_PolyBagWrapped = value ; 
  			}  
  		} 
  
  		private string m_YardFolded = string.Empty ; 
  		public string YardFolded 
  		{ 
  			get 
  			{ 
  				return m_YardFolded ; 
  			}  
  			set 
  			{ 
  				m_YardFolded = value ; 
  			}  
  		} 
  
  		private string m_DoublePolyBagWrapped = string.Empty ; 
  		public string DoublePolyBagWrapped 
  		{ 
  			get 
  			{ 
  				return m_DoublePolyBagWrapped ; 
  			}  
  			set 
  			{ 
  				m_DoublePolyBagWrapped = value ; 
  			}  
  		} 
  
  		private string m_CartonPack = string.Empty ; 
  		public string CartonPack 
  		{ 
  			get 
  			{ 
  				return m_CartonPack ; 
  			}  
  			set 
  			{ 
  				m_CartonPack = value ; 
  			}  
  		} 
  
  		private string m_ForBales = string.Empty ; 
  		public string ForBales 
  		{ 
  			get 
  			{ 
  				return m_ForBales ; 
  			}  
  			set 
  			{ 
  				m_ForBales = value ; 
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
            string Sql="SELECT * FROM WO_FabricProcessAdd WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM WO_FabricProcessAdd WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_Signed=SysConvert.ToString(MasterTable.Rows[0]["Signed"]); 
  				m_Desizing=SysConvert.ToString(MasterTable.Rows[0]["Desizing"]); 
  				m_Mercerized=SysConvert.ToString(MasterTable.Rows[0]["Mercerized"]); 
  				m_Reactive=SysConvert.ToString(MasterTable.Rows[0]["Reactive"]); 
  				m_Pigment=SysConvert.ToString(MasterTable.Rows[0]["Pigment"]); 
  				m_NonAzo=SysConvert.ToString(MasterTable.Rows[0]["NonAzo"]); 
  				m_Softner=SysConvert.ToString(MasterTable.Rows[0]["Softner"]); 
  				m_Stentering=SysConvert.ToString(MasterTable.Rows[0]["Stentering"]); 
  				m_Sanfor=SysConvert.ToString(MasterTable.Rows[0]["Sanfor"]); 
  				m_Waterwash=SysConvert.ToString(MasterTable.Rows[0]["Waterwash"]); 
  				m_Airowash=SysConvert.ToString(MasterTable.Rows[0]["Airowash"]); 
  				m_Carbonpeach=SysConvert.ToString(MasterTable.Rows[0]["Carbonpeach"]); 
  				m_Moleskin=SysConvert.ToString(MasterTable.Rows[0]["Moleskin"]); 
  				m_PHValue=SysConvert.ToString(MasterTable.Rows[0]["PHValue"]); 
  				m_SL=SysConvert.ToString(MasterTable.Rows[0]["SL"]); 
  				m_GC=SysConvert.ToString(MasterTable.Rows[0]["GC"]); 
  				m_SC=SysConvert.ToString(MasterTable.Rows[0]["SC"]); 
  				m_Light=SysConvert.ToString(MasterTable.Rows[0]["Light"]); 
  				m_XSHZSLD=SysConvert.ToString(MasterTable.Rows[0]["XSHZSLD"]); 
  				m_PillingMartindale=SysConvert.ToString(MasterTable.Rows[0]["PillingMartindale"]); 
  				m_DSGY1=SysConvert.ToString(MasterTable.Rows[0]["DSGY1"]); 
  				m_DSGY2=SysConvert.ToString(MasterTable.Rows[0]["DSGY2"]); 
  				m_DSGY3=SysConvert.ToString(MasterTable.Rows[0]["DSGY3"]); 
  				m_DSGY4=SysConvert.ToString(MasterTable.Rows[0]["DSGY4"]); 
  				m_DSGY5=SysConvert.ToString(MasterTable.Rows[0]["DSGY5"]); 
  				m_DSGY6=SysConvert.ToString(MasterTable.Rows[0]["DSGY6"]); 
  				m_TensileStrength=SysConvert.ToString(MasterTable.Rows[0]["TensileStrength"]); 
  				m_TearingStrength=SysConvert.ToString(MasterTable.Rows[0]["TearingStrength"]); 
  				m_SeamSlippage=SysConvert.ToString(MasterTable.Rows[0]["SeamSlippage"]); 
  				m_XSLD=SysConvert.ToString(MasterTable.Rows[0]["XSLD"]); 
  				m_XDLD=SysConvert.ToString(MasterTable.Rows[0]["XDLD"]); 
  				m_WX=SysConvert.ToString(MasterTable.Rows[0]["WX"]); 
  				m_ShipmentSample=SysConvert.ToString(MasterTable.Rows[0]["ShipmentSample"]); 
  				m_ApprovedLab=SysConvert.ToString(MasterTable.Rows[0]["ApprovedLab"]); 
  				m_HandFeelSample=SysConvert.ToString(MasterTable.Rows[0]["HandFeelSample"]); 
  				m_Smooth=SysConvert.ToString(MasterTable.Rows[0]["Smooth"]); 
  				m_Rough=SysConvert.ToString(MasterTable.Rows[0]["Rough"]); 
  				m_RolledOnTube=SysConvert.ToString(MasterTable.Rows[0]["RolledOnTube"]); 
  				m_PolyBagWrapped=SysConvert.ToString(MasterTable.Rows[0]["PolyBagWrapped"]); 
  				m_YardFolded=SysConvert.ToString(MasterTable.Rows[0]["YardFolded"]); 
  				m_DoublePolyBagWrapped=SysConvert.ToString(MasterTable.Rows[0]["DoublePolyBagWrapped"]); 
  				m_CartonPack=SysConvert.ToString(MasterTable.Rows[0]["CartonPack"]); 
  				m_ForBales=SysConvert.ToString(MasterTable.Rows[0]["ForBales"]); 
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
