using System;
using System.Drawing;
using System.Data;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using System.Windows.Forms;

namespace MLTERP
{

	#region 采购部门单据颜色处理类
	/// <summary>
	/// 采购部门单据颜色处理类
	/// </summary>
	public class BuyDepStatusProc
	{
		private static bool m_ColorIniFlag=false;//颜色是否初始化标志
		public static bool ColorIniFlag
		{
			get
			{
				if(!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
				{
					ColorIniProc();
					m_ColorIniFlag=true;
				}
				return m_ColorIniFlag;
			}
		}

		private static int[] ColorStatusID;
		private static string[] ColorStatusName;
		private static Color[] ColorStatusColor;
		/// <summary>
		/// 初始化颜色
		/// </summary>
		private static void ColorIniProc()
		{
			string sql="SELECT ID,Name,ColorStr FROM Enum_BuyDepStatus WHERE ID<>0 ORDER BY Code";
			DataTable dt = SysUtils.Fill(sql);
			ColorStatusID = new int[dt.Rows.Count];
			ColorStatusName = new string[dt.Rows.Count];
			ColorStatusColor= new Color[dt.Rows.Count];
			for(int i=0;i<dt.Rows.Count;i++)
			{
				ColorStatusID[i]=SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
				ColorStatusName[i]=dt.Rows[i]["Name"].ToString();
				string[] tempstr=dt.Rows[i]["ColorStr"].ToString().Split(',');
				if(tempstr.Length==3)//长度为3
				{
					ColorStatusColor[i]=Color.FromArgb(SysConvert.ToInt32(tempstr[0]),SysConvert.ToInt32(tempstr[1]),SysConvert.ToInt32(tempstr[2]));
				}
				else
				{
					ColorStatusColor[i]=Color.White;
				}

			}			
		}

		/// <summary>
		/// 初始化控件颜色
		/// </summary>
		/// <param name="p_TxtColor"></param>
		public static void ColorIniTextBox(TextBox[] p_TxtColor)
		{
			for(int i=0;i<p_TxtColor.Length;i++)
			{
				if(ColorStatusID.Length>i)
				{
					p_TxtColor[i].Text=ColorStatusName[i];
					p_TxtColor[i].BackColor=ColorStatusColor[i];

				}
				else
				{
					p_TxtColor[i].Visible=false;
				}
			}
		}

		/// <summary>
		/// 处理状态名称
		/// </summary>
		/// <param name="p_Dt">数据表</param>
		public static void ProcYarnStatusName(DataTable p_Dt)
		{
			
			decimal qty;
            decimal inwhqty;
			DateTime dt1;
			DateTime dt2;
			string statusname=string.Empty;
			foreach(DataRow dr in p_Dt.Rows)
			{
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["InWHQty"]);
                dt1 = SysConvert.ToDateTime(dr["NeedDate"]);
                dt2 = SysConvert.ToDateTime(dr["InWHDate"]);


                if (inwhqty != 0 || dt2 != SystemConfiguration.DateTimeDefaultValue)//有数量则完成
				{
                    if (inwhqty < qty)
                    {
                        statusname = ColorStatusName[3];//部分完成
                    }
                    else
                    {
                        statusname = ColorStatusName[4];
                    }
				}
				else
				{
					DateTime chkTime=dt1;
                    //if(dt2!=SystemConfiguration.DateTimeDefaultValue)//有回复日期
                    //{
                    //    chkTime=dt2;
                    //}
				
					TimeSpan ts=DateTime.Now-chkTime;
					if(ts.Days>0)//已经延期
					{
						statusname = ColorStatusName[2];
					}
                    else if (ts.Days > 0 - 3)//预警
					{
						statusname = ColorStatusName[1];
					}
					else
					{
						statusname = ColorStatusName[0];
					}

                  
				}

                dr["YarnStatusName"] = statusname;
			}
		}



		/// <summary>
		/// 处理状态名称染色合同
		/// </summary>
		/// <param name="p_Dt">数据表</param>
		public static void ProcColorStatusName(DataTable p_Dt)
		{

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["InWHQty"]);
                dt1 = SysConvert.ToDateTime(dr["NeedDate"]);
                dt2 = SysConvert.ToDateTime(dr["InWHDate"]);


                if (inwhqty != 0 || dt2 != SystemConfiguration.DateTimeDefaultValue)//有数量则完成
                {
                    if (inwhqty < qty)
                    {
                        statusname = ColorStatusName[3];//部分完成
                    }
                    else
                    {
                        statusname = ColorStatusName[4];
                    }
                }
                else
                {
                    DateTime chkTime = dt1;
                    //if(dt2!=SystemConfiguration.DateTimeDefaultValue)//有回复日期
                    //{
                    //    chkTime=dt2;
                    //}

                    TimeSpan ts = DateTime.Now - chkTime;
                    if (ts.Days > 0)//已经延期
                    {
                        statusname = ColorStatusName[2];
                    }
                    else if (ts.Days > 0 - 3)//预警
                    {
                        statusname = ColorStatusName[1];
                    }
                    else
                    {
                        statusname = ColorStatusName[0];
                    }


                }

                dr["YarnStatusName"] = statusname;
            }
		}

        /// <summary>
        /// 处理状态名称加工单
        /// </summary>
        /// <param name="p_Dt">数据表</param>
        public static void ProcOthStatusName(DataTable p_Dt)
        {

            decimal qty;
            decimal inwhqty;
            DateTime dt1;
            DateTime dt2;
            string statusname = string.Empty;
            foreach (DataRow dr in p_Dt.Rows)
            {
                qty = SysConvert.ToDecimal(dr["Qty"]);
                inwhqty = SysConvert.ToDecimal(dr["InWHQty"]);
                dt1 = SysConvert.ToDateTime(dr["NeedDate"]);
                dt2 = SysConvert.ToDateTime(dr["InWHDate"]);


                if (inwhqty != 0 || dt2 != SystemConfiguration.DateTimeDefaultValue)//有数量则完成
                {
                    if (inwhqty < qty)
                    {
                        statusname = ColorStatusName[3];//部分完成
                    }
                    else
                    {
                        statusname = ColorStatusName[4];
                    }
                }
                else
                {
                    DateTime chkTime = dt1;
                    //if(dt2!=SystemConfiguration.DateTimeDefaultValue)//有回复日期
                    //{
                    //    chkTime=dt2;
                    //}

                    TimeSpan ts = DateTime.Now - chkTime;
                    if (ts.Days > 0)//已经延期
                    {
                        statusname = ColorStatusName[2];
                    }
                    else if (ts.Days > 0 - 3)//预警
                    {
                        statusname = ColorStatusName[1];
                    }
                    else
                    {
                        statusname = ColorStatusName[0];
                    }


                }

                dr["YarnStatusName"] = statusname;
            }
        }
		/// <summary>
		/// 设置Grid行颜色
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
        public static Color GetGridRowBackColor(DateTime p_Dt1, DateTime p_Dt2, decimal p_InWHQty, decimal p_Qty,int p_PreDateNum)
		{
            if (p_InWHQty != 0 || p_Dt2!=SystemConfiguration.DateTimeDefaultValue)//有数量则完成
			{
                if (p_InWHQty < p_Qty)
                {
                    return GetGridRowBackColor(4);//部分完成
                }
                else
                {
                    return GetGridRowBackColor(5);//全部完成
                }
			}
			else
			{
				DateTime chkTime=p_Dt1;
                //if(p_Dt2!=SystemConfiguration.DateTimeDefaultValue)//有要求日期
                //{
                //    chkTime=p_Dt2;
                //}
				
				TimeSpan ts=DateTime.Now-chkTime;
				if(ts.Days>0)//已经延期
				{
					return GetGridRowBackColor(3);
				}
                else if (ts.Days > 0 - p_PreDateNum)//预警
				{
					return GetGridRowBackColor(2);
				}

			}
			return GetGridRowBackColor(1);
		}
       
		/// <summary>
		/// 设置Grid行颜色
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
		public static Color GetGridRowBackColor(string p_StatusName)
		{
			for(int i=0;i<ColorStatusName.Length;i++)
			{
				if(p_StatusName==ColorStatusName[i])
				{
					return GetGridRowBackColor(ColorStatusID[i]);
				}
			}

			return GetGridRowBackColor(1);
		}

		/// <summary>
		/// 设置Grid行颜色
		/// </summary>
		public static Color GetGridRowBackColor(int p_ColorStatusID)
		{
			int findsort=-1;
			for(int i=0;i<ColorStatusID.Length;i++)
			{
				if(ColorStatusID[i]==p_ColorStatusID)
				{
					findsort=i;
					break;
				}
			}
			if(findsort!=-1)
			{
				return ColorStatusColor[findsort];
			}
			return Color.White;
		}
	}
	#endregion

	#region 使用情况颜色处理类
	/// <summary>
	/// 使用情况颜色处理类
	/// </summary>
	public class UseStatusProc
	{
		private static bool m_ColorIniFlag=false;//颜色是否初始化标志
		public static bool ColorIniFlag
		{
			get
			{
				if(!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
				{
					ColorIniProc();
					m_ColorIniFlag=true;
				}
				return m_ColorIniFlag;
			}
		}

		private static int[] ColorStatusID;
		private static string[] ColorStatusName;
		private static Color[] ColorStatusColor;
		/// <summary>
		/// 初始化颜色
		/// </summary>
		private static void ColorIniProc()
		{
			string sql="SELECT ID,Name,ColorStr FROM Enum_UseStatus WHERE ID<>0 ORDER BY Code";
			DataTable dt = SysUtils.Fill(sql);
			ColorStatusID = new int[dt.Rows.Count];
			ColorStatusName = new string[dt.Rows.Count];
			ColorStatusColor= new Color[dt.Rows.Count];
			for(int i=0;i<dt.Rows.Count;i++)
			{
				ColorStatusID[i]=SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
				ColorStatusName[i]=dt.Rows[i]["Name"].ToString();
				string[] tempstr=dt.Rows[i]["ColorStr"].ToString().Split(',');
				if(tempstr.Length==3)//长度为3
				{
					ColorStatusColor[i]=Color.FromArgb(SysConvert.ToInt32(tempstr[0]),SysConvert.ToInt32(tempstr[1]),SysConvert.ToInt32(tempstr[2]));
				}
				else
				{
					ColorStatusColor[i]=Color.White;
				}

			}			
		}

		/// <summary>
		/// 初始化控件颜色
		/// </summary>
		/// <param name="p_TxtColor"></param>
		public static void ColorIniTextBox(TextBox[] p_TxtColor)
		{
			for(int i=0;i<p_TxtColor.Length;i++)
			{
				if(ColorStatusID.Length>i)
				{
					p_TxtColor[i].Text=ColorStatusName[i];
					p_TxtColor[i].BackColor=ColorStatusColor[i];

				}
				else
				{
					p_TxtColor[i].Visible=false;
				}
			}
		}

		/// <summary>
		/// 处理使用状态名称(纱线订购合同)
		/// </summary>
		/// <param name="p_Dt">数据表</param>
		public static void ProcUseStatusName(DataTable p_Dt,string p_YarnFinishName,int p_MaxDayNum)
		{			
			decimal qty=0;
			decimal leaveqty=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DateTime dtInTime;
			DataTable dt;
			foreach(DataRow dr in p_Dt.Rows)
			{	
				if(p_YarnFinishName==dr["YarnStatusName"].ToString())//已经完成了才处理相关状态
				{
					dtInTime=DateTime.Now.Date;
					leaveqty=0;
					qty=SysConvert.ToDecimal(dr["HaveInQty"].ToString());//已入库
					sql="SELECT InDate,Qty FROM WH_Storge WHERE DtsSO="+SysString.ToDBString(dr["BuytNo"].ToString())+" AND ItemCode="+SysString.ToDBString(dr["ItemCode"].ToString());
					dt = SysUtils.Fill(sql);
					foreach(DataRow drStorge in dt.Rows)
					{
						dtInTime=SysConvert.ToDateTime(drStorge["InDate"]);
						leaveqty+=SysConvert.ToDecimal(drStorge["Qty"]);
					}

					dr["LeaveQty"]=leaveqty;

					if(leaveqty>=qty*0.1m)//库存剩余超过10%
					{
						if(dtInTime.AddDays(p_MaxDayNum)<=DateTime.Now.Date)//超过限制的天数了
						{
							statusname = ColorStatusName[1];
						}
						else//否则正常
						{							
							statusname = ColorStatusName[0];
						}
					}
					else//状态 已使用
					{
						statusname = ColorStatusName[2];
					}
				}
				else//正常
				{					
					statusname = ColorStatusName[0];
				}
			
				dr["UseStatusName"]=statusname;
			}
		}


		/// <summary>
		/// 处理使用状态名称(染色合同)
		/// </summary>
		/// <param name="p_Dt">数据表</param>
		public static void ProcColorUseStatusName(DataTable p_Dt,string p_YarnFinishName,int p_MaxDayNum)
		{			
			decimal qty=0;
			decimal leaveqty=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DateTime dtInTime;
			DataTable dt;
			foreach(DataRow dr in p_Dt.Rows)
			{	
				if(p_YarnFinishName==dr["YarnStatusName"].ToString())//已经完成了才处理相关状态
				{
					dtInTime=DateTime.Now.Date;
					leaveqty=0;
					qty=SysConvert.ToDecimal(dr["HaveInQty"].ToString());//已入库
					sql="SELECT InDate,Qty FROM WH_Storge WHERE DtsSO="+SysString.ToDBString(dr["CompactCode"].ToString())+" AND ItemCode="+SysString.ToDBString(dr["ItemCode"].ToString());
					sql+=" AND ColorName="+SysString.ToDBString(dr["ColorName"].ToString());
					dt = SysUtils.Fill(sql);
					foreach(DataRow drStorge in dt.Rows)
					{
						dtInTime=SysConvert.ToDateTime(drStorge["InDate"]);
						leaveqty+=SysConvert.ToDecimal(drStorge["Qty"]);
					}

					dr["LeaveQty"]=leaveqty;

					if(leaveqty>=qty*0.1m)//库存剩余超过10%
					{
						if(dtInTime.AddDays(p_MaxDayNum)<=DateTime.Now.Date)//超过限制的天数了
						{
							statusname = ColorStatusName[1];
						}
						else//否则正常
						{							
							statusname = ColorStatusName[0];
						}
					}
					else//状态 已使用
					{
						statusname = ColorStatusName[2];
					}
				}
				else//正常
				{					
					statusname = ColorStatusName[0];
				}
			
				dr["UseStatusName"]=statusname;
			}
		}


		/// <summary>
		/// 设置Grid行颜色
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
		public static Color GetGridRowBackColor(string p_StatusName)
		{
			for(int i=0;i<ColorStatusName.Length;i++)
			{
				if(p_StatusName==ColorStatusName[i])
				{
					return GetGridRowBackColor(ColorStatusID[i]);
				}
			}

			return GetGridRowBackColor(1);
		}

		/// <summary>
		/// 设置Grid行颜色
		/// </summary>
		public static Color GetGridRowBackColor(int p_ColorStatusID)
		{
			int findsort=-1;
			for(int i=0;i<ColorStatusID.Length;i++)
			{
				if(ColorStatusID[i]==p_ColorStatusID)
				{
					findsort=i;
					break;
				}
			}
			if(findsort!=-1)
			{
				return ColorStatusColor[findsort];
			}
			return Color.White;
		}
	}
	#endregion

	#region 销售合同颜色处理类
	/// <summary>
	/// 使用情况颜色处理类
	/// </summary>
	public class VCompactStatusProc
	{
		private static bool m_ColorIniFlag=false;//颜色是否初始化标志
		public static bool ColorIniFlag
		{
			get
			{
				if(!m_ColorIniFlag)//如果没有初始化则进行初始化颜色
				{
					ColorIniProc();
					m_ColorIniFlag=true;
				}
				return m_ColorIniFlag;
			}
		}

		private static int[] ColorStatusID;
		private static string[] ColorStatusName;
		private static Color[] ColorStatusColor;
		/// <summary>
		/// 初始化颜色
		/// </summary>
		private static void ColorIniProc()
		{
			string sql="SELECT ID,Name,ColorStr FROM Enum_VCompactStatus WHERE ID<>0 ORDER BY Code";
			DataTable dt = SysUtils.Fill(sql);
			ColorStatusID = new int[dt.Rows.Count];
			ColorStatusName = new string[dt.Rows.Count];
			ColorStatusColor= new Color[dt.Rows.Count];
			for(int i=0;i<dt.Rows.Count;i++)
			{
				ColorStatusID[i]=SysConvert.ToInt32(dt.Rows[i]["ID"].ToString());
				ColorStatusName[i]=dt.Rows[i]["Name"].ToString();
				string[] tempstr=dt.Rows[i]["ColorStr"].ToString().Split(',');
				if(tempstr.Length==3)//长度为3
				{
					ColorStatusColor[i]=Color.FromArgb(SysConvert.ToInt32(tempstr[0]),SysConvert.ToInt32(tempstr[1]),SysConvert.ToInt32(tempstr[2]));
				}
				else
				{
					ColorStatusColor[i]=Color.White;
				}

			}			
		}

		/// <summary>
		/// 初始化控件颜色
		/// </summary>
		/// <param name="p_TxtColor"></param>
		public static void ColorIniTextBox(TextBox[] p_TxtColor)
		{
			for(int i=0;i<p_TxtColor.Length;i++)
			{
				if(ColorStatusID.Length>i)
				{
					p_TxtColor[i].Text=ColorStatusName[i];
					p_TxtColor[i].BackColor=ColorStatusColor[i];

				}
				else
				{
					p_TxtColor[i].Visible=false;
				}
			}
		}

		/// <summary>
		/// 处理使用状态名称(纱线订购合同)
		/// </summary>
		/// <param name="p_Dt">数据表</param>
		public static void ProcUseStatusName(DataTable p_Dt)
		{			
			decimal qty=0;
			decimal saleQty=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DataTable dt;
			foreach(DataRow dr in p_Dt.Rows)
			{
				saleQty=0;
				qty=SysConvert.ToDecimal(dr["Qty"].ToString());//合同数量
				//sql="SELECT SUM(SaleQty) SaleQty FROM UV2_Sale_SODts WHERE SubmitFlag=1 AND SOID="+SysString.ToDBString(dr["SOID"].ToString());
                sql = "SELECT SUM(Qty) SaleQty FROM UV2_Sale_SODts WHERE SubmitFlag=1 AND SOID=" + SysString.ToDBString(dr["SOID"].ToString());
				dt = SysUtils.Fill(sql);
				saleQty=SysConvert.ToDecimal(dt.Rows[0][0]);

				dr["SaleQty"]=saleQty;

				if(saleQty>=qty*0.8m)//销售量超过80%
				{						
					statusname = ColorStatusName[1];
				}
				else//状态 
				{
					statusname = ColorStatusName[0];
				}
			
				dr["YarnStatusName"]=statusname;
			}
		}

		/// <summary>
		/// 处理使用状态名称(纱线订购合同)
		/// </summary>
		/// <param name="p_Dt">数据表</param>
		public static void ProcUseStatusNameMore(DataTable p_Dt,Label p_lblInfo)
		{			
			decimal qty=0;
			decimal saleQty=0,saleAmount=0;
			string sql=string.Empty;
			string statusname=string.Empty;
			DataTable dt;

			int i=0;
			foreach(DataRow dr in p_Dt.Rows)
			{
				i++;
				p_lblInfo.Text="数据处理中，共计 "+p_Dt.Rows.Count.ToString()+" 条数据，正在运算第 " +i.ToString()+" 条";
				Application.DoEvents();
				saleQty=0;
				qty=SysConvert.ToDecimal(dr["Qty"].ToString());//合同数量
				//sql="SELECT SUM(SaleQty) SaleQty FROM UV2_Sale_SODts WHERE SubmitFlag=1 AND SOID="+SysString.ToDBString(dr["SOID"].ToString());
				//CaiwuType 1/2/3:销售/采购/加工
				sql="SELECT SUM(CASE DZFlag WHEN 2 THEN 0-Qty ELSE Qty END) Qty,SUM(CASE DZFlag WHEN 2 THEN 0-Amount ELSE Amount END) Amount FROM UV1_WH_IOFormDts ";
				sql += "WHERE ConfirmFlag=1 AND CaiwuFlag=1";				
				sql+=" AND CaiwuType=1 AND DtsSO="+SysString.ToDBString(dr["SOID"].ToString());

				dt = SysUtils.Fill(sql);
				saleQty=SysConvert.ToDecimal(dt.Rows[0]["Qty"]);
				saleAmount=SysConvert.ToDecimal(dt.Rows[0]["Amount"]);//销售金额

				//采购金额

				dr["SaleQty"]=saleQty;
				dr["SaleAmount"]=saleAmount;

				dt=SysUtils.Fill("EXEC USP1_GetSaleCost "+SysString.ToDBString(dr["SOID"].ToString())+","+SysString.ToDBString(dr["CompactNo"].ToString())+","+SysString.ToDBString(dr["ItemCode"].ToString()));
				
				dr["BuyQty"]=SysConvert.ToDecimal(dt.Rows[0]["BuyQty"]);
				dr["BuyAmount"]=SysConvert.ToDecimal(dt.Rows[0]["BuyAmount"]);
				dr["MatchQty"]=SysConvert.ToDecimal(dt.Rows[0]["JgQty"]);
				dr["MatchAmount"]=SysConvert.ToDecimal(dt.Rows[0]["JgAmount"]);
				dr["WHQty"]=SysConvert.ToDecimal(dt.Rows[0]["WHQty"]);
				dr["WHAmount"]=SysConvert.ToDecimal(dt.Rows[0]["WHAmount"]);
				dr["UseQty"]=SysConvert.ToDecimal(dt.Rows[0]["UseQty"]);
				dr["UseAmount"]=SysConvert.ToDecimal(dt.Rows[0]["UseAmount"]);
				dr["ProfitAmount"]= saleAmount-SysConvert.ToDecimal(dt.Rows[0]["WHAmount"])-SysConvert.ToDecimal(dt.Rows[0]["JgAmount"])-SysConvert.ToDecimal(dt.Rows[0]["UseAmount"]);
				if(saleAmount!=0)
				{
					dr["ProfitPer"]= SysConvert.ToDecimal( 100*SysConvert.ToDecimal(dr["ProfitAmount"])/saleAmount,1);
				}
				

				if(saleQty>=qty*0.8m)//销售量超过80%
				{						
					statusname = ColorStatusName[1];
				}
				else//状态 
				{
					statusname = ColorStatusName[0];
				}
			
				dr["YarnStatusName"]=statusname;
			}
			p_lblInfo.Text="处理完成";
		}

		/// <summary>
		/// 设置Grid行颜色
		/// </summary>
		/// <param name="p_Dt1"></param>
		/// <param name="p_Dt2"></param>
		/// <param name="p_RecQty"></param>
		/// <returns></returns>
		public static Color GetGridRowBackColor(string p_StatusName)
		{
			for(int i=0;i<ColorStatusName.Length;i++)
			{
				if(p_StatusName==ColorStatusName[i])
				{
					return GetGridRowBackColor(ColorStatusID[i]);
				}
			}

			return GetGridRowBackColor(1);
		}

		/// <summary>
		/// 设置Grid行颜色
		/// </summary>
		public static Color GetGridRowBackColor(int p_ColorStatusID)
		{
			int findsort=-1;
			for(int i=0;i<ColorStatusID.Length;i++)
			{
				if(ColorStatusID[i]==p_ColorStatusID)
				{
					findsort=i;
					break;
				}
			}
			if(findsort!=-1)
			{
				return ColorStatusColor[findsort];
			}
			return Color.White;
		}
	}
	#endregion

}
