using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using HttSoft.Framework;
using HttSoft.MLTERP.Sys;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.FrameFunc;

namespace MLTERPSer
{
    /// <summary>
    /// WSYarn 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [Serializable]
    public class WSYarn : System.Web.Services.WebService
    {

        #region 测试
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string HelloWorld2()
        {
            int p_DHID = 0;
            string sql = "SELECT ID FROM ADH_DataDH ";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_DHID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
            }
            return p_DHID.ToString();
        }

        [WebMethod]
        public string HelloWorld3()
        {
            HttSoft.MLTERP.DataCtl.CheckFormRule rule = new HttSoft.MLTERP.DataCtl.CheckFormRule();
            int p_DHID = rule.RScan(0, "001", 1, "001", 2, System.DateTime.Now);

            return p_DHID.ToString();
        }

        #endregion



        #region 登录验证
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="p_DH"></param>
        /// <param name="p_VendorAttn"></param>
        /// <param name="p_DHID"></param>
        /// <param name="p_VendorID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public bool FrameCheckLogin(string p_DH, string p_VendorAttn, string p_SysVersion, out int p_DHID, out string p_VendorID, out string p_ErrorMsg)
        {
            bool outbool = false;
            p_ErrorMsg = string.Empty;
            p_DHID = 0;
            p_VendorID = string.Empty;
            try
            {
                string sql = string.Empty;
                sql = "SELECT AllowFlag FROM Sys_VersionPDA WHERE Version=" + SysString.ToDBString(p_SysVersion);
                DataTable dtVersion = SysUtils.Fill(sql);
                if (dtVersion.Rows.Count != 0)
                {
                    if (SysConvert.ToInt32(dtVersion.Rows[0]["AllowFlag"]) == 0)
                    {
                        p_ErrorMsg = "此版本不允许使用,请更新最新的程序";
                        return false;
                    }
                }
                else
                {
                    p_ErrorMsg = "没有找到此版本";
                    return false;
                }

                sql = "SELECT ID FROM ADH_DataDH WHERE ExName=" + SysString.ToDBString(p_DH);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    p_DHID = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                }
                else
                {
                    p_ErrorMsg = "没有找到展会";
                    return false;
                }

                sql = "SELECT VendorID FROM Data_Vendor WHERE VendorAttn=" + SysString.ToDBString(p_VendorAttn);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    p_VendorID = SysConvert.ToString(dt.Rows[0]["VendorID"]);
                }
                else
                {
                    p_ErrorMsg = "没有找到客户";
                    return false;
                }

                outbool = true;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outbool;
        }
        #endregion

        #region 基础资料数据读取

        /// <summary>
        /// 获得订货
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindDH(out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT ID,ExName FROM ADH_DataDH WHERE FinishFlag=0";
                DataTable dt = SysUtils.Fill(sql);
                SysFile.WriteFrameworkLog(sql);
                p_Ds.Tables.Add(dt);

                SysFile.WriteFrameworkLog(sql);
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }


        /// <summary>
        /// 获得订货客户
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindDHVendor(int p_DHID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT VendorID,VendorAttn,ID FROM Data_Vendor WHERE 1=1";
                sql += " AND VendorID in(select VendorID from Data_VendorTypeDts where  ISNULL(VendorTypeID,0)=1)";
                sql += " ORDER BY VendorAttn";// UseableFlag=1

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }


        /// <summary>
        /// 获得订货客户(TOP )
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindDHVendorTOP(int p_DHID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT TOP 10  VendorID,VendorAttn,ID FROM Data_Vendor WHERE 1=1 ";
                sql += " AND VendorID in(select VendorID from Data_VendorTypeDts where  ISNULL(VendorTypeID,0)=1)";
                sql += " ORDER BY ID DESC";//UseableFlag=1

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }


        /// <summary>
        /// 获得订货客户(先后)
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindDHVendorXH(int p_DHID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT VendorID,VendorAttn,ID FROM Data_Vendor WHERE 1=1";
                sql += " AND VendorID in(select VendorID from Data_VendorTypeDts where  ISNULL(VendorTypeID,0)=1)";
                sql += " ORDER BY ID DESC";//UseableFlag=1

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }

        /// <summary>
        /// 获得订货客户(查询)
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindDHVendorQuery(int p_DHID, string p_QueryCon, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT VendorID,VendorAttn,ID FROM Data_Vendor WHERE 1=1 ";
                sql += " AND VendorID in(select VendorID from Data_VendorTypeDts where  ISNULL(VendorTypeID,0)=1)";
                //sql += " AND ISNULL(VendorTypeID,0)=" + (int)EnumVendorType.客户;
                if (p_QueryCon != string.Empty)
                {
                    sql += " AND( VendorNameEn LIKE " + SysString.ToDBString("%" + p_QueryCon + "%");
                    sql += " OR VendorAttn LIKE " + SysString.ToDBString("%" + p_QueryCon + "%");
                    sql += ")";
                }
                sql += " ORDER BY ID DESC";//UseableFlag=1

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }
        #endregion



        #region 订货操作


        /// <summary>
        /// 扫描条形码
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int CheckFormScan(int p_ID, string p_Context, string p_VendorID, int p_DHID, out string p_ErrorMsg, out DataSet p_Ds, out DateTime o_Now)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();
            o_Now = DateTime.Now;
            try
            {
                if (p_Context != string.Empty)
                {
                    HttSoft.MLTERP.DataCtl.CheckFormRule rule = new HttSoft.MLTERP.DataCtl.CheckFormRule();
                    outi = rule.RScan(p_ID, p_Context, 1, p_VendorID, p_DHID, System.DateTime.Now);
                    p_Ds.Tables.Add(ChcekFormGetDataSource(p_ID));

                }
                else
                {
                    p_ErrorMsg = "请扫描条码";
                }

                o_Now = DateTime.Now;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }


        /// <summary>
        /// 扫描条形码
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int CheckFormScan2(int p_ID, string p_Context, int p_YPQty, string p_VendorID, int p_DHID, out string p_ErrorMsg, out DataSet p_Ds, out DateTime o_Now)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();
            o_Now = DateTime.Now;
            try
            {
                if (p_Context != string.Empty)
                {
                    HttSoft.MLTERP.DataCtl.CheckFormRule rule = new HttSoft.MLTERP.DataCtl.CheckFormRule();
                    outi = rule.RScan(p_ID, p_Context, p_YPQty, p_VendorID, p_DHID, System.DateTime.Now);
                    p_Ds.Tables.Add(ChcekFormGetDataSource(p_ID));

                }
                else
                {
                    p_ErrorMsg = "请扫描条码";
                }

                o_Now = DateTime.Now;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }


        /// <summary>
        /// 扫描条形码 确认完成
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int CheckFormScanOK(int p_ID, out string p_ErrorMsg)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            try
            {
                HttSoft.MLTERP.DataCtl.CheckFormRule rule = new HttSoft.MLTERP.DataCtl.CheckFormRule();
                outi = rule.RScanOK(p_ID);


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }



        /// <summary>
        /// 扫描条形码
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int CheckScan(int p_ID, string p_Context, int p_YPQty, string p_VendorID, int p_DHID, out string p_ErrorMsg, out DataSet p_Ds, out DateTime o_Now)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();
            o_Now = DateTime.Now;
            try
            {
                if (p_Context != string.Empty)
                {
                    HttSoft.MLTERP.DataCtl.CheckFormRule rule = new HttSoft.MLTERP.DataCtl.CheckFormRule();
                    outi = rule.RScan(p_ID, p_Context, p_YPQty, p_VendorID, p_DHID, System.DateTime.Now);
                    p_Ds.Tables.Add(ChcekFormGetDataSource(p_ID));

                }
                else
                {
                    p_ErrorMsg = "请扫描条码";
                }

                o_Now = DateTime.Now;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }



        /// <summary>
        /// 扫描条形码(撤销)
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet CheckFormScanCancel(int p_ID, string p_Context, out DateTime o_Now, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            o_Now = DateTime.Now;
            try
            {
                if (p_Context != string.Empty)
                {
                    HttSoft.MLTERP.DataCtl.CheckFormRule rule = new HttSoft.MLTERP.DataCtl.CheckFormRule();
                    rule.RScanCancel(p_ID, p_Context);
                    p_Ds.Tables.Add(ChcekFormGetDataSource(p_ID));

                }
                else
                {
                    HttSoft.MLTERP.DataCtl.CheckFormRule rule = new HttSoft.MLTERP.DataCtl.CheckFormRule();
                    rule.RScanCancel(p_ID, p_Context);
                    p_Ds.Tables.Add(ChcekFormGetDataSource(p_ID));
                    //p_ErrorMsg = "请扫描条码";
                }

                o_Now = DateTime.Now;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }



        /// <summary>
        /// 获得表单信息
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int CheckFormGetInfo(int p_ID, out string p_ErrorMsg, out DataSet p_Ds, out DateTime o_Now, out string o_FormCode)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();
            o_Now = DateTime.Now;
            o_FormCode = string.Empty;
            try
            {
                if (p_ID != 0)
                {
                    HttSoft.MLTERP.Data.CheckForm entity = new HttSoft.MLTERP.Data.CheckForm();
                    entity.ID = p_ID;
                    entity.SelectByID();
                    o_FormCode = entity.FormCode;
                    p_Ds.Tables.Add(ChcekFormGetDataSource(p_ID));

                }
                else
                {
                    p_ErrorMsg = "读取不到表单";
                }

                o_Now = DateTime.Now;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }


        /// <summary>
        /// 获得表单信息
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int CheckFormGetInfo2(int p_ID, out string p_ErrorMsg, out DataSet p_Ds, out DateTime o_Now, out string o_FormCode, out string o_FlagStr)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();
            o_Now = DateTime.Now;
            o_FormCode = string.Empty;
            o_FlagStr = string.Empty;
            try
            {
                if (p_ID != 0)
                {
                    HttSoft.MLTERP.Data.CheckForm entity = new HttSoft.MLTERP.Data.CheckForm();
                    entity.ID = p_ID;
                    entity.SelectByID();
                    o_FormCode = entity.FormCode;
                    if (entity.SubmitFlag == 0)
                    {
                        o_FlagStr = "进行中";
                    }
                    else
                    {
                        o_FlagStr = "已完成";
                    }
                    p_Ds.Tables.Add(ChcekFormGetDataSource(p_ID));

                }
                else
                {
                    p_ErrorMsg = "读取不到表单";
                }

                o_Now = DateTime.Now;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }


        /// <summary>
        /// 获得表单信息
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int CheckFormGetCurID(string p_VendorID, int p_DHID, out string p_ErrorMsg)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            try
            {
                string sql = string.Empty;
                sql = "SELECT ID FROM ADH_CheckForm WHERE DataDHID=" + SysString.ToDBString(p_DHID) + " AND DVendorID=" + SysString.ToDBString(p_VendorID);
                sql += " ORDER BY ID DESC";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outi = SysConvert.ToInt32(dt.Rows[0]["ID"]);
                }
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }


        /// <summary>
        /// 获得数据源
        /// </summary>
        /// <returns></returns>
        DataTable ChcekFormGetDataSource(int p_ID)
        {
            HttSoft.MLTERP.DataCtl.ParamSetRule prule = new HttSoft.MLTERP.DataCtl.ParamSetRule();
            string queryfiled = prule.RShowStrByID((int)ParamSetEnum.扫描查询SQL字段内容);
            if (queryfiled == string.Empty)
            {
                queryfiled = "A.ISN 条码,C.ItemStd 支数, C.ItemName 成份";
            }
            string sql = string.Empty;
            //sql = "SELECT " + queryfiled + " FROM ADH_CheckFormDts A,ADH_DataISN B,Data_Item C WHERE A.ISN=B.ISN ";

            //sql += " AND B.DItemCode=C.ItemCode AND A.MainID=" + SysString.ToDBString(p_ID) + " ORDER BY A.Seq DESC";

            sql = "SELECT " + queryfiled + " FROM UV1_ADH_CheckFormDts  WHERE 1=1";

            sql += " AND MainID=" + SysString.ToDBString(p_ID) + " ORDER BY Seq DESC";

            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 扫描条形码
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int ScanContext(string p_Context, out string p_ErrorMsg, out DataSet p_Ds, out DateTime o_Now)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();
            o_Now = DateTime.Now;
            try
            {
                if (p_Context != string.Empty)
                {
                    string sql = string.Empty;
                    sql = "SELECT ISN 条码,DStyleNo 款号,DColorName 颜色,DSize 尺码 FROM WO_ISNM WHERE ISN=" + SysString.ToDBString(p_Context);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        p_Ds.Tables.Add(dt);
                        sql = "INSERT INTO WO_ScanHis(ScanCode,ScanTime) VALUES(" + SysString.ToDBString(p_Context) + ",GetDate())";
                        SysUtils.ExecuteNonQuery(sql);
                        outi = 1;
                    }
                    else
                    {
                        p_ErrorMsg = "刷入的条码" + p_Context + "不存在";
                    }
                }
                else
                {
                    p_ErrorMsg = "请扫描条码";
                }

                o_Now = DateTime.Now;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }
        #endregion

        #region 订货报表


        /// <summary>
        /// 排名报表
        /// </summary>
        /// <param name="p_Context"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet ReportPM(int p_ZHID, string p_Context, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                if (p_ZHID != 0)
                {
                    HttSoft.MLTERP.DataCtl.ParamSetRule prule = new HttSoft.MLTERP.DataCtl.ParamSetRule();
                    string queryfiled = prule.RShowStrByID((int)ParamSetEnum.排名查询SQL字段内容);
                    if (queryfiled == string.Empty)
                    {
                        queryfiled = "TA.ISN 条码,TA.SQty 次数,C.ItemStd 支数, C.ItemName 成份 ";
                    }


                    string sql = string.Empty;
                    sql = "SELECT " + queryfiled + " FROM";//sql = "SELECT TA.ISN 条码,TA.SQty 次数,C.ItemStd 支数, C.ItemName 成份,C.ItemCode 编码 FROM";
                    sql += "(";
                    sql += " SELECT A.ISN,COUNT(A.MainID) SQty FROM ADH_CheckFormDts A,ADH_CheckForm B ";
                    sql += " WHERE A.MainID=B.ID AND B.DataDHID=" + p_ZHID;
                    if (p_Context != string.Empty)
                    {
                        sql += " AND A.ISN=" + SysString.ToDBString(p_Context);
                    }
                    sql += " GROUP BY A.ISN";
                    sql += ") AS TA,Data_ItemGB B,Data_Item C";
                    sql += "  WHERE  TA.ISN=B.GBCode ";
                    sql += " AND B.MainID=C.ID  ORDER BY TA.SQty DESC";

                    DataTable dt = SysUtils.Fill(sql);

                    p_Ds.Tables.Add(dt);
                }
                else
                {
                    p_ErrorMsg = "读取不到展会";
                }
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }
        #endregion

        #region 面料PDA程序

        #region 登录验证
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="p_DH"></param>
        /// <param name="p_VendorAttn"></param>
        /// <param name="p_DHID"></param>
        /// <param name="p_VendorID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public bool MLFrameCheckLogin(string p_OPID, string p_Password, string p_SysVersion, out string OPID, out string OPName, out string p_ErrorMsg)
        {

            bool outbool = false;
            p_ErrorMsg = string.Empty;
            OPID = "";
            OPName = "";
            try
            {

                string sql = string.Empty;
                //sql = "SELECT AllowFlag FROM Sys_VersionPDA WHERE Version=" + SysString.ToDBString(p_SysVersion);
                //DataTable dtVersion = SysUtils.Fill(sql);
                //if (dtVersion.Rows.Count != 0)
                //{
                //    if (SysConvert.ToInt32(dtVersion.Rows[0]["AllowFlag"]) == 0)
                //    {
                //        p_ErrorMsg = "此版本不允许使用,请更新最新的程序";
                //        return false;
                //    }
                //}
                //else
                //{
                //    p_ErrorMsg = "没有找到此版本";
                //    return false;
                //}

                sql = "SELECT OPID,OPName FROM Data_OP WHERE OPID=" + SysString.ToDBString(p_OPID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    OPID = p_OPID;

                    OPName = SysConvert.ToString(dt.Rows[0]["OPName"]);


                }
                else
                {
                    p_ErrorMsg = "用户名不存在,请重新输入";
                    return false;
                }


                sql = "SELECT * FROM Data_OP WHERE OPID=" + SysString.ToDBString(p_OPID);
                sql += " AND PassWord=" + SysString.ToDBString(p_Password);

                dt = SysUtils.Fill(sql);


                if (dt.Rows.Count == 0)
                {

                    p_ErrorMsg = "密码不正确,请重新输入";
                    return false;
                }
                else
                {
                    outbool = true;
                }

                outbool = true;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outbool;
        }


        [WebMethod]
        public bool MLWHAdd(string p_OPID, int p_SubType, out int intID, out string strFormNo, out string p_ErrorMsg)
        {

            bool outbool = false;
            p_ErrorMsg = string.Empty;
            intID = 0;
            strFormNo = "";
            try
            {


                //FormNoControlRule rulest=new FormNoControlRule();
                //IOFormRule rule = new IOFormRule();
                //IOForm entity = new IOForm();
                //entity.FormNo = rulest.RGetFormNo((int)FormNoControlEnum.面料入库单号);
                //entity.SubType = p_SubType;
                //entity.HeadType = 15;
                //if (p_SubType == 205)
                //{
                //    entity.HeadType = 198;
                //}
                //entity.FormDate = DateTime.Now.Date;
                //rule.RAdd(entity,p_SubType);

                //intID = entity.ID;
                //strFormNo = entity.FormNo;
                //outbool = true;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outbool;
        }
        [WebMethod]
        public bool MLWHAdd2(string p_OPID, int p_SubType, out int intID, out string strFormNo, out string p_ErrorMsg)
        {

            bool outbool = false;
            p_ErrorMsg = string.Empty;
            intID = 0;
            strFormNo = "";
            try
            {


                //FormNoControlRule rulest = new FormNoControlRule();
                //IOFormRule rule = new IOFormRule();
                //IOForm entity = new IOForm();
                //entity.FormNo = rulest.RGetFormNo((int)FormNoControlEnum.面料出库单号);
                //entity.SubType = p_SubType;
                //entity.HeadType = 16;
                //if (p_SubType == 206)
                //{
                //    entity.HeadType = 199;
                //}
                //entity.FormDate = DateTime.Now.Date;

                //rule.RAdd(entity, p_SubType);

                //intID = entity.ID;
                //strFormNo = entity.FormNo;
                //outbool = true;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outbool;
        }

        [WebMethod]
        public string MLSetPackNo(int p_ID, string p_PackNo, out string p_ErrorMsg)
        {
            string outstr = string.Empty;

            p_ErrorMsg = string.Empty;
            string sql = "";

            try
            {
                sql = "SELECT ISN FROM WO_FabricCheck WHERE ISN=" + SysString.ToDBString(p_PackNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_ErrorMsg + "不存在，请检查";
                    return outstr;
                }

                sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "已存在，请检查";
                    return outstr;
                }

                PckISNRule rule = new PckISNRule();
                PckISN entity = new PckISN();
                entity.MainID = p_ID;
                entity.PackNo = p_PackNo;
                entity.Seq = GetMaxSeq(p_PackNo);
                rule.RAdd(entity);


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outstr;
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_PackNo"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLSetPackNo2(int p_ID, string p_PackNo, string m_FormNo, int p_PackID, int p_SubType, out string p_ErrorMsg)
        {

            string outstr = string.Empty;
            outstr = p_ID.ToString();
            p_ErrorMsg = string.Empty;
            string sql = "";
            try
            {
                string ItemCode = string.Empty;
                string Lever = string.Empty;
                sql = "SELECT BoxNo,ItemCode,GoodsLevel FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "不存在，请检查";
                    return outstr;
                }
                else
                {
                    ItemCode = dt.Rows[0]["ItemCode"].ToString();
                    Lever = dt.Rows[0]["GoodsLevel"].ToString();
                }

                sql = "SELECT BoxNo FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "不处于入库状态，请检查";
                    return outstr;
                }

                ///已经做过出库单的数据
                sql = "SELECT BoxNo FROM WH_IOFormDtsPack WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                sql += " AND MainID in(select ID from WH_IOForm where SubType=" + SysString.ToDBString(p_SubType) + ")";
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "已扫描过，请检查";
                    return outstr;
                }



                sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "已存在，请检查";
                    return outstr;
                }

                if (p_ID != 0)
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = GetMaxSeq(p_PackNo);
                    rule.RAdd(entity);

                    //PckISNBag entityp = new PckISNBag();
                    //entityp.DISN = p_PackNo;
                    //entityp.MainID = entity.MainID;
                    //entityp.PackID = p_PackID;
                    //PckISNBagRule entityprule = new PckISNBagRule();
                    //entityprule.RAdd(entityp);

                    outstr = p_ID.ToString();
                }
                else//为0的情况下，自动产生一个ID为MainID
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = GetMaxSeq(p_PackNo);
                    rule.RAdd(entity);
                    entity.MainID = entity.ID;
                    rule.RUpdate(entity);

                    //PckISNBag entityp = new PckISNBag();
                    //entityp.DISN = p_PackNo;
                    //entityp.MainID = entity.MainID;
                    //entityp.PackID = p_PackID;
                    //PckISNBagRule entityprule = new PckISNBagRule();
                    //entityprule.RAdd(entityp);

                    outstr = entity.MainID.ToString();
                }


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;

        }

        [WebMethod]
        public string SetPackNo(int p_ID, string p_PackNo, string m_SaleID, int p_SubType, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            string outstr = string.Empty;
            string sql = "";
            sql = "SELECT BoxNo,ItemCode FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                p_ErrorMsg = "条码：" + p_PackNo + "不存在，请检查";
                return outstr;
            }
            sql = "SELECT BoxNo FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
            sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 0)
            {
                p_ErrorMsg = "条码：" + p_PackNo + "不处于入库状态，请检查";
                return outstr;
            }
            sql = "SELECT BoxNo FROM WH_IOFormDtsPack WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
            sql += " AND MainID in(select ID from WH_IOForm where SubType=" + SysString.ToDBString(p_SubType) + ")";
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                p_ErrorMsg = "条码：" + p_PackNo + "已扫描过，请检查";
                return outstr;
            }
            sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
            sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
            dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                p_ErrorMsg = "条码：" + p_PackNo + "已存在，请检查";
                return outstr;
            }

            if (p_ID != 0)
            {
                PckISNRule rule = new PckISNRule();
                PckISN entity = new PckISN();
                entity.MainID = p_ID;
                entity.PackNo = p_PackNo;
                entity.Seq = GetMaxSeq(p_ID);
                entity.Remark = m_SaleID.ToString();
                rule.RAdd(entity);
                outstr = p_ID.ToString();
            }
            else//为0的情况下，自动产生一个ID为MainID
            {
                PckISNRule rule = new PckISNRule();
                PckISN entity = new PckISN();
                entity.MainID = p_ID;
                entity.PackNo = p_PackNo;
                entity.Seq = GetMaxSeq(p_ID);
                entity.Remark = m_SaleID.ToString();
                rule.RAdd(entity);
                entity.MainID = entity.ID;
                rule.RUpdate(entity);
                outstr = entity.MainID.ToString();
            }
            return outstr;
        }
        /// <summary>
        /// 样品出库
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_PackNo"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLSetPackNo4(int p_ID, string p_PackNo, string m_FormNo, int p_PackID, int p_SubType, decimal p_Qty, out string p_ErrorMsg)
        {

            string outstr = string.Empty;
            outstr = p_ID.ToString();
            p_ErrorMsg = string.Empty;
            string sql = "";
            try
            {

                sql = "select * from WH_IOformDtsISN where ISN=" + SysString.ToDBString(p_PackNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "不存在，请检查";
                    return outstr;
                }

                sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "已扫描，请检查";
                    return outstr;
                }

                if (p_ID != 0)
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Qty = p_Qty;
                    //entity.Seq = GetMaxSeq(p_PackNo);
                    rule.RAdd(entity);



                    outstr = p_ID.ToString();
                }
                else//为0的情况下，自动产生一个ID为MainID
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Qty = p_Qty;
                    //entity.Seq = GetMaxSeq(p_PackNo);
                    rule.RAdd(entity);
                    entity.MainID = entity.ID;
                    rule.RUpdate(entity);


                    outstr = entity.MainID.ToString();
                }


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;

        }


        /// <summary>
        /// DTY领料出库
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_PackNo"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLSetPackNoLL(int p_ID, string p_PackNo, string m_FormNo, out string p_ErrorMsg)
        {

            string outstr = string.Empty;
            outstr = p_ID.ToString();
            p_ErrorMsg = string.Empty;
            string sql = "";
            try
            {
                string ItemCode = string.Empty;
                string Lever = string.Empty;
                sql = "SELECT BoxNo,ItemCode,GoodsLevel FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                sql += " AND WHID='01'";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "DTY条码：" + p_PackNo + "不存在，请检查";
                    return outstr;
                }
                else
                {
                    ItemCode = dt.Rows[0]["ItemCode"].ToString();
                    Lever = dt.Rows[0]["GoodsLevel"].ToString();
                }

                sql = "SELECT BoxNo FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "不处于入库状态，请检查";
                    return outstr;
                }


                sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "已存在，请检查";
                    return outstr;
                }

                if (p_ID != 0)
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = GetMaxSeq(p_PackNo);
                    rule.RAdd(entity);
                    outstr = p_ID.ToString();
                }
                else
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = 1;
                    rule.RAdd(entity);
                    outstr = entity.MainID.ToString();
                }


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;

        }

        /// <summary>
        /// 移库
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_PackNo"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLSetPackNo3(int p_ID, string p_PackNo, string p_SectionID, out string p_ErrorMsg)
        {

            string outstr = string.Empty;

            p_ErrorMsg = string.Empty;
            string sql = "";
            try
            {


                sql = "SELECT BoxNo,WHID,SectionID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "库存不存在，请检查";
                    return outstr;
                }

                string WHID = SysConvert.ToString(dt.Rows[0]["WHID"]);
                string SectionID = SysConvert.ToString(dt.Rows[0]["SectionID"]);

                sql = "SELECT WHID,SectionID FROM WH_Section WHERE WHISN=" + SysString.ToDBString(p_SectionID);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    if (WHID != SysConvert.ToString(dt.Rows[0][0]))
                    {
                        p_ErrorMsg = "不同仓库之间的产品不能进行移库！";
                        return outstr;
                    }
                    if (SectionID == SysConvert.ToString(dt.Rows[0][1]))
                    {
                        p_ErrorMsg = "该匹产品不需要进行移库";
                        return outstr;
                    }
                }


                if (p_ID == 0)
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = GetMaxSeq(p_PackNo);
                    rule.RAdd(entity);
                    outstr = entity.MainID.ToString();
                    //p_ErrorMsg = outstr;
                    //return p_ErrorMsg;
                }
                else//如果已经产生了MainID则
                {
                    sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                    dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        p_ErrorMsg = "条码：" + p_PackNo + "已存在，请检查";
                        return outstr;
                    }
                    else
                    {

                    }

                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = GetMaxSeq(p_PackNo);
                    rule.RAdd(entity);
                    outstr = p_ID.ToString();
                }


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;

        }
        /// <summary>
        /// 移库
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_PackNo"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string YKSetPackNo(int p_ID, string p_PackNo, string p_SBitID, out string p_ErrorMsg)
        {

            string outstr = string.Empty;

            p_ErrorMsg = string.Empty;
            string sql = "";
            try
            {
                sql = "SELECT BoxNo,WHID,SectionID,SBitID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                sql += " AND BoxStatusID=" + SysString.ToDBString((int)EnumBoxStatus.入库);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "库存不存在，请检查";
                    return outstr;
                }

                string WHID = SysConvert.ToString(dt.Rows[0]["WHID"]);
                string SectionID = SysConvert.ToString(dt.Rows[0]["SectionID"]);
                string SBitID = SysConvert.ToString(dt.Rows[0]["SBitID"]);
                sql = "SELECT WHID,SectionID,SBitID FROM WH_SBit WHERE SBitID=" + SysString.ToDBString(p_SBitID);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    //if (WHID != SysConvert.ToString(dt.Rows[0][0]))
                    //{
                    //    p_ErrorMsg = "不同仓库之间的产品不能进行移库！";
                    //    return outstr;
                    //}
                    if (SBitID == SysConvert.ToString(dt.Rows[0]["SBitID"]))
                    {
                        p_ErrorMsg = "该匹产品不需要进行移库";
                        return outstr;
                    }
                }
                if (p_ID == 0)
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = GetMaxSeq(p_ID);
                    rule.RAdd(entity);
                    outstr = entity.MainID.ToString();
                    //p_ErrorMsg = outstr;
                    //return p_ErrorMsg;
                }
                else//如果已经产生了MainID则
                {
                    sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                    dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        p_ErrorMsg = "条码：" + p_PackNo + "已存在，请检查";
                        return outstr;
                    }
                    else
                    {

                    }

                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = GetMaxSeq(p_ID);
                    rule.RAdd(entity);
                    outstr = p_ID.ToString();
                }
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;

        }

        private int GetMaxSeq(string p_ID)
        {
            int maxseq = 0;
            //string sql = "SELECT Max(Seq) Seq  FROM WH_PckISN WHERE MainID =" + SysString.ToDBString(p_ID);
            //DataTable dt = SysUtils.Fill(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    maxseq = SysConvert.ToInt32(dt.Rows[0][0]);
            //}
            //maxseq++;
            //string sql = "SELECT Seq FROM WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(p_ID);
            //DataTable dt = SysUtils.Fill(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    maxseq = SysConvert.ToInt32(dt.Rows[0][0]);
            //}
            //else
            //{
            //    throw new Exception("未找到检验信息：" + p_ID);

            //}
            return maxseq;
        }
        private int GetMaxSeq(int p_ID)
        {
            int maxseq = 0;
            string sql = "SELECT Max(Seq) Seq  FROM WH_PckISN WHERE MainID =" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                maxseq = SysConvert.ToInt32(dt.Rows[0][0]);
            }
            maxseq++;
            //string sql = "SELECT Seq FROM WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(p_ID);
            //DataTable dt = SysUtils.Fill(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    maxseq = SysConvert.ToInt32(dt.Rows[0][0]);
            //}
            //else
            //{
            //    throw new Exception("未找到检验信息：" + p_ID);

            //}
            return maxseq;
        }

        private int GetPDMaxSeq(int p_ID)
        {
            int maxseq = 0;
            //string sql = "SELECT MAX(Seq) Seq FROM WH_PDFormDts WHERE MainID=" + SysString.ToDBString(p_ID);
            //DataTable dt = SysUtils.Fill(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    maxseq = SysConvert.ToInt32(dt.Rows[0][0]) + 1;
            //}
            return maxseq;
        }

        /// <summary>
        /// 得到扫描条码数组
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <param name="p_Ds"></param>
        /// <returns></returns>
        [WebMethod]
        public int MLWHGetPackDts(int p_ID, out string p_ErrorMsg, out DataSet p_Ds)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();

            try
            {
                if (p_ID != 0)
                {


                    p_Ds.Tables.Add(ChcekFormGetPackISN(p_ID));

                }
                else
                {
                    p_ErrorMsg = "读取不到表单";

                }



            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }

        //SELECT DISTINCT TOP 5  MainID FROM WH_PckISN WHERE 1=1 ORDER BY MainID DESC

        /// <summary>
        /// 得到扫描条码数组
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <param name="p_Ds"></param>
        /// <returns></returns>
        [WebMethod]
        public int MLWHGetPackDts2(int p_ID, out string p_ErrorMsg, out DataSet p_Ds)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();

            try
            {
                if (p_ID != 0)
                {


                    p_Ds.Tables.Add(ChcekFormGetPackISN2(p_ID));

                }
                else
                {
                    p_ErrorMsg = "读取不到表单";
                }



            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }

        /// <summary>
        /// 得到扫描条码数组
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <param name="p_Ds"></param>
        /// <returns></returns>
        [WebMethod]
        public int WHGetPackDts(int p_ID, out string p_ErrorMsg, out DataSet p_Ds)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();

            try
            {
                if (p_ID != 0)
                {
                    string sql = "SELECT ItemModel 品名,Qty 米数,Weight 公斤数,Yard 码数,GoodsLevel 等级,Seq 序号,PackNo 条码 FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " ORDER BY Seq DESC";
                    DataTable dt = SysUtils.Fill(sql);
                    p_Ds.Tables.Add(dt);
                }
                else
                {
                    p_ErrorMsg = "读取不到表单";
                }



            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }

        /// <summary>
        /// 得到扫描条码数组--样品出库
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <param name="p_Ds"></param>
        /// <returns></returns>
        [WebMethod]
        public int MLWHGetPackDts4(int p_ID, out string p_ErrorMsg, out DataSet p_Ds)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();

            try
            {
                if (p_ID != 0)
                {


                    p_Ds.Tables.Add(ChcekFormGetPackISN4(p_ID));

                }
                else
                {
                    p_ErrorMsg = "读取不到表单";
                }



            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }

        /// <summary>
        /// 得到扫描的条码
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        private DataTable ChcekFormGetPackISN(int p_ID)
        {
            //string sql = "SELECT ItemCode 产品,Qty 数量,JSUnit 单位,Seq 序号 FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
            //string sql = "SELECT ItemCode 产品,SJQty 数量,JSUnit 单位,Seq 序号 FROM UV2_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
            string sql = "SELECT ItemName 产品,Qty 数量,Seq 序号 FROM UV2_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
            sql += " ORDER BY Seq DESC";
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 得到扫描的条码
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>DCMLMoveWHSubmit
        private DataTable ChcekFormGetPackISN2(int p_ID)
        {
            //string sql = "SELECT ItemCode 产品,Qty 数量,JSUnit 单位,Seq 序号 FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);  20150312 zhoufc
            //string sql = "SELECT ItemCode 产品,Qty 数量,Seq 序号 FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
            string sql = "SELECT ItemName 产品,Qty 数量,Seq 序号 FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
            sql += " ORDER BY Seq DESC";
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 得到扫描的条码--样品出库
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>DCMLMoveWHSubmit
        private DataTable ChcekFormGetPackISN4(int p_ID)
        {
            //string sql = "SELECT ItemCode 产品,Qty 数量,JSUnit 单位,Seq 序号 FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);  20150312 zhoufc
            string sql = "SELECT ISN 条码,ItemCode 产品,Qty 数量,Seq 序号 FROM UV1_WH_PckISNIOFormDtsISN WHERE MainID=" + SysString.ToDBString(p_ID);
            sql += " ORDER BY Seq DESC";
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 得到订单
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <param name="p_Ds"></param>
        /// <returns></returns>
        [WebMethod]
        public int MLGetSaleOrderDts(int p_ID, string p_VendorAttn, string p_FormNo, int p_NOFlag, int p_DateFlag, out string p_ErrorMsg, out DataSet p_Ds)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();

            try
            {
                if (p_VendorAttn != "")
                {


                    p_Ds.Tables.Add(ChcekFormGetSaleOrder(p_VendorAttn, p_FormNo, p_NOFlag, p_DateFlag));

                }
                else
                {
                    p_ErrorMsg = "读取不到表单";
                }



            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }


        /// <summary>
        /// 得到扫描的条码
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        private DataTable ChcekFormGetSaleOrder(string p_VendorAttn, string p_FormNo, int p_NOFlag, int p_DateFlag)
        {
            string sql = "SELECT FormNo AS 单号,MakeDate 日期,ItemCode AS 编码,ItemName 名称,PieceQty 匹数,ISNULL(ReceivedPieceQty,0) 已发货,ISNULL(PieceQty,0)-ISNULL(ReceivedPieceQty,0) 未发货 FROM UV1_Sale_SaleOrderDts WHERE VendorAttn=" + SysString.ToDBString(p_VendorAttn);
            if (p_NOFlag == 1)
            {
                sql += " AND ISNULL(PieceQty,0)>ISNULL(ReceivedPieceQty,0) ";
            }
            if (p_DateFlag == 1)
            {
                sql += " AND MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddMonths(-6).Date) + " AND " + SysString.ToDBString(DateTime.Now.Date);
            }
            sql += " ORDER BY MakeDate DESC";
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// 扫描取消
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_PackNo"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLDelPackNo(int p_ID, string p_PackNo, out string p_ErrorMsg)
        {

            string outstr = string.Empty;
            p_ErrorMsg = string.Empty;
            try
            {
                string sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 1)
                {
                    sql = "DELETE WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                    SysUtils.ExecuteNonQuery(sql);

                    //sql = "DELETE WH_PckISNBag WHERE MainID=" + SysString.ToDBString(p_ID);
                    //sql += " AND DISN=" + SysString.ToDBString(p_PackNo);
                    //SysUtils.ExecuteNonQuery(sql);
                }
                else
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "不存在，请检查";
                    return outstr;
                }


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;


        }



        /// <summary>
        /// 根据客户名得到客户ID
        /// </summary>
        /// <param name="p_VendorName"></param>
        /// <returns></returns>
        private string GetVendorID(string p_VendorName)
        {
            string sql = "SELECT VendorID FROM Data_Vendor WHERE VendorAttn=" + SysString.ToDBString(p_VendorName);
            sql += " OR VendorName=" + SysString.ToDBString(p_VendorName);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 根据客户名得到客户ID
        /// </summary>
        /// <param name="p_VendorName"></param>
        /// <returns></returns>
        private string GetVendorID2(string p_VendorName, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT VendorID FROM Data_Vendor WHERE VendorAttn=" + SysString.ToDBString(p_VendorName);
            sql += " OR VendorName=" + SysString.ToDBString(p_VendorName);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 验证区位
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <param name="p_SectionID"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLCheckSectionID(string p_WHID, string p_SectionID, out string p_ErrorMsg, out string p_WHStr)
        {

            string outstr = string.Empty;
            p_ErrorMsg = string.Empty;
            p_WHStr = string.Empty;
            try
            {

                //string sql = "SELECT WHNM,SectionID FROM UV1_WH_Section WHERE WHISN=" + SysString.ToDBString(p_SectionID);
                //sql += " AND SectionID="+SysString.ToDBString(p_SectionID);
                string sql = "SELECT SectionID FROM WH_Section WHERE WHID=" + SysString.ToDBString(p_WHID);
                sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    //p_ErrorMsg = "测试！";

                    p_ErrorMsg = "区条码：" + p_SectionID + "不存在，请检查";
                    p_ErrorMsg = sql;
                    return p_ErrorMsg;
                }
                p_WHStr = SysConvert.ToString(dt.Rows[0]["SectionID"]);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outstr;
        }

        /// <summary>
        /// 验证仓库
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLCheckWHID(string p_WHID, out string p_ErrorMsg)
        {

            string outstr = string.Empty;
            p_ErrorMsg = string.Empty;
            try
            {

                string sql = "SELECT ID FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "仓库：" + p_WHID + "不存在，请检查";
                }

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;

        }


        /// <summary>
        /// 验证仓库
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLGetSubTypeID(int p_WHType, out int p_SubType, out string p_SubTypeName, out string p_ErrorMsg)
        {

            string outstr = string.Empty;
            p_SubType = 0;
            p_SubTypeName = "";
            p_ErrorMsg = string.Empty;
            try
            {


                string sql = "SELECT * FROM Enum_WHPDA WHERE WHType=" + SysString.ToDBString(p_WHType);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "仓库类型未定义，请检查";
                    return outstr;
                }
                p_SubType = SysConvert.ToInt32(dt.Rows[0]["SubType"]);

                sql = "SELECT FormNM FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubType);
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "仓库类型不存在，请检查";
                    return outstr;
                }
                p_SubTypeName = SysConvert.ToString(dt.Rows[0][0]);






            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;

        }

        [WebMethod]
        public string MLWHGetFormNo(string p_OPID, int p_submitFlag, int p_whType, int p_DateFlag, out string p_ErrorMsg, out DataSet p_Ds)
        {
            string outstr = string.Empty;
            int outi = 0;
            p_ErrorMsg = string.Empty;
            p_Ds = new DataSet();

            try
            {

                p_Ds.Tables.Add(ChcekFormGetIOForm(p_OPID, p_submitFlag, p_whType, p_DateFlag));


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;
        }

        /// <summary>
        /// 得到扫描的条码
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        private DataTable ChcekFormGetIOForm(string p_OPID, int p_submitFlag, int p_whType, int p_DateFlag)
        {
            string sql = "SELECT ID,FormDate 日期,FormNo 单号,TotalQty 数量,SubmitFlag 状态 FROM UV1_WH_IOFormDts WHERE 1=1";
            sql += " AND SubType IN (201,202)";
            if (p_submitFlag == 0)
            {
                sql += " AND ISNULL(SubmitFlag,0)=0 ";
            }
            else
            {
                sql += " AND ISNULL(SubmitFlag,0)=1 ";
            }

            if (p_whType == 1)
            {
                sql += " AND ISNULL(SubType,0)=201 ";
            }
            else if (p_whType == 2)
            {
                sql += " AND ISNULL(SubType,0)=202 ";
            }

            if (p_DateFlag == 1)
            {
                sql += " AND FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.Date) + " AND " + SysString.ToDBString(DateTime.Now.Date);
            }

            sql += " ORDER BY ID DESC";
            DataTable dt = SysUtils.Fill(sql);

            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (SysConvert.ToInt32(dr["状态"]) == 1)
            //    {
            //        dr["状态"] = "提交";
            //    }
            //    else
            //    {
            //        dr["状态"] = "未提交";
            //    }
            //}

            return dt;
        }

        [WebMethod]
        public string MLCancelWHSubmit(int p_ID, out string p_ErrorMsg)
        {
            string outstr = string.Empty;

            p_ErrorMsg = string.Empty;


            try
            {

                IOFormRule rule = new IOFormRule();
                rule.RSubmit(p_ID, 0);


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;
        }


        [WebMethod]
        public bool MLFrameCheckPassWord(string p_OPID, string p_PWD, string p_SysVersion, out string OPID, out string OPName, out string p_ErrorMsg)
        {

            bool outbool = false;
            p_ErrorMsg = string.Empty;
            OPID = "";
            OPName = "";
            try
            {

                string sql = string.Empty;
                sql = "SELECT AllowFlag FROM Sys_VersionPDA WHERE Version=" + SysString.ToDBString(p_SysVersion);
                DataTable dtVersion = SysUtils.Fill(sql);
                if (dtVersion.Rows.Count != 0)
                {
                    if (SysConvert.ToInt32(dtVersion.Rows[0]["AllowFlag"]) == 0)
                    {
                        p_ErrorMsg = "此版本不允许使用,请更新最新的程序";
                        return false;
                    }
                }
                else
                {
                    p_ErrorMsg = "没有找到此版本";
                    return false;
                }

                sql = "SELECT OPID,OPName FROM Data_OP WHERE OPID=" + SysString.ToDBString(p_OPID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    OPID = p_OPID;

                    OPName = SysConvert.ToString(dt.Rows[0]["OPName"]);


                }
                else
                {
                    p_ErrorMsg = "用户名不存在,请重新输入";
                    return false;
                }


                sql = "SELECT * FROM Data_OP WHERE OPID=" + SysString.ToDBString(p_OPID);
                sql += " AND PassWord=" + SysString.ToDBString(p_PWD);

                dt = SysUtils.Fill(sql);


                if (dt.Rows.Count == 0)
                {

                    p_ErrorMsg = "密码不正确,请重新输入";
                    return false;
                }
                else
                {
                    outbool = true;
                }

                outbool = true;

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outbool;
        }
        #endregion


        #region PDA出入库
        [WebMethod]

        public string DCGetWHBySBitISN(string ISN, int p_SubType, out string p_WHID, out string p_SectionID, out string p_SBitID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            p_WHID = string.Empty;
            p_SectionID = string.Empty;
            p_SBitID = string.Empty;
            string p_Str = string.Empty;
            try
            {
                string sql = "SELECT * FROM  UV1_WH_SBit WHERE SBitISN=" + SysString.ToDBString(ISN);
                sql += " AND WHType IN (SELECT WHTypeID FROM Enum_FormList WHERE Code =" + SysString.ToDBString(p_SubType);
                sql += ")";
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    p_WHID = SysConvert.ToString(dt.Rows[0]["WHID"]);
                    p_SectionID = SysConvert.ToString(dt.Rows[0]["SectionID"]);
                    p_SBitID = SysConvert.ToString(dt.Rows[0]["SBitID"]);
                    p_Str = "库：" + SysConvert.ToString(dt.Rows[0]["WHNM"]);
                    p_Str += " 区：" + p_SectionID;
                    p_Str += " 位：" + p_SBitID;
                }
                else
                {
                    p_ErrorMsg = "没有找到该库位";
                }
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Str;
        }
        /// <summary>
        /// 获得登陆账号
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindOPID(int p_DHID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";

                sql += " ORDER BY OPID";// UseableFlag=1

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }
        /// <summary>
        /// 入库提交
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string DCMLInWHSubmit(int p_ID, string p_WHID, string p_SectionID, string p_SBitID, string p_OPName, string p_VendorAttn, int p_SubType, out int intSubmitFlag, out string p_ErrorMsg)
        {
            lock (this)
            {

                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                string outstr = string.Empty; ;

                intSubmitFlag = 0;
                try
                {
                    sqlTrans.OpenTrans();

                    p_ErrorMsg = string.Empty;

                    //判断是否扫描
                    string sql = "SELECT ID FROM UV2_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }

                    string DtsVendorID = "GY010";//默认俪森

                    //sql = "SELECT ItemCode,ColorNum,JSUnit,SUM(Qty) Qty,JarNum,GoodsLevel FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID); //20150312 zhoufc
                    //sql = "SELECT ItemCode,ColorNum,JSUnit,SUM(SJQty) Qty,JarNum,GoodsLevel FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql = "SELECT ItemCode,ColorNum,'M' Unit,SUM(Qty) Qty,JarNum,ItemModel,ItemName,ItemStd,ChkMWeight,ChkMWidth,ColorName FROM UV2_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,ColorNum,JarNum,ItemModel,ItemName,ItemStd,ChkMWeight,ChkMWidth,ColorName";

                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);
                        //IOentity.ID = p_ID;
                        //IOentity.SelectByID();
                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        //IOentity.WHID = p_WHID;
                        //IOentity.WHType = p_WHID;
                        //IOentity.WHID = GetWHIDByISN2(p_SectionID, sqlTrans);
                        //IOentity.WHType = GetWHIDByISN2(p_SectionID, sqlTrans);

                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);

                        IOentity.VendorID = DtsVendorID;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.MakeOPID = p_OPName;
                        //IOentity.SaleOPID = SaleOPID;
                        //IOentity.Indep = DepartmentID.ToString();
                        //IOentity.OutDep = DepartmentID.ToString();
                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "EIN";


                        sql = "SELECT * FROM UV2_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);

                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);


                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = p_WHID;
                            entitydts[i].SectionID = p_SectionID;
                            entitydts[i].SBitID = p_SBitID;

                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            entitydts[i].ItemModel = dt.Rows[i]["ItemModel"].ToString();
                            entitydts[i].ItemName = dt.Rows[i]["ItemName"].ToString();
                            entitydts[i].ItemStd = dt.Rows[i]["ItemStd"].ToString();
                            entitydts[i].MWeight = dt.Rows[i]["ChkMWeight"].ToString();
                            entitydts[i].MWidth = dt.Rows[i]["ChkMWidth"].ToString();
                            //entitydts[i].CPItemCode = entitydts[i].ItemCode;
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].Remark = "条码扫描自动入成品库";

                            //entitydts[i].DtsSO = dt.Rows[i]["CompactNo"].ToString();
                            //entitydts[i].DtsOrderFormNo = dt.Rows[i]["SO"].ToString();
                            entitydts[i].Unit = dt.Rows[i]["Unit"].ToString();
                            entitydts[i].DtsVendorID = DtsVendorID;
                            //entitydts[i].GoodsLevel = dt.Rows[i]["GoodsLevel"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                            entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            //entitydts[i].Unit = SysConvert.ToString(dt.Rows[i]["JSUnit"]);
                            //entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["YQty"]);

                            //DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString()) + " AND ISNULL(CompactNo,'')=" + SysString.ToDBString(dt.Rows[i]["CompactNo"].ToString()) + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString()) + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString()) + " AND ISNULL(SO,'')=" + SysString.ToDBString(dt.Rows[i]["SO"].ToString()) + " AND ISNULL(JSUnit,'')=" + SysString.ToDBString(dt.Rows[i]["JSUnit"].ToString()) + " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString()) + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString()));
                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString()) + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString()) + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString()));

                            entitydts[i].PieceQty = ISN.Length;

                            entitydts[i].PackFlag = 1;

                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();
                                //entity.Qty = SysConvert.ToDecimal(dr["Qty"]);//实际数量
                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);//实际数量  20150312 zhoufc
                                //entity.Unit = SysConvert.ToString(dr["JSUnit"]);
                                //entity.FMQty = SysConvert.ToDecimal(dr["FMQty"]);//放码数量
                                entity.Remark = "条码扫描入库";
                                List.Add(entity);
                                //string ISNsql = "UPDATE WO_BProductCheckDts SET SectionID=" + SysString.ToDBString(SectionID) + ",WHID=" + SysString.ToDBString(IOentity.WHID) + " WHERE DISN=" + SysString.ToDBString(dr["PackNo"].ToString());//条码已经入库
                                //sqlTrans.ExecuteNonQuery(ISNsql);
                                m++;
                            }


                        }

                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }

                        IOentity.TotalQty = TotalQty;

                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);

                        rule2.RSubmit(IOentity.ID, 2, sqlTrans);
                    }

                    //3更新条码状态（这步动作是在入库提交的时候处理）
                    //sql = "Update WO_BProductCheckDts Set InWHFlag=1 WHERE DISN IN(  select  PackNo FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID) + ")";
                    sql = "Update Chk_CheckOrderISN Set InWHFlag=1 WHERE DISN IN(  select  PackNo FROM UV2_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID) + ")";
                    sqlTrans.ExecuteNonQuery(sql);

                    sqlTrans.CommitTrans();


                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;

                    sqlTrans.RollbackTrans();
                }
                return outstr;
            }


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_SubTypeID"></param>
        /// <returns></returns>
        private int GetHeadTypeID(int p_SubTypeID)
        {
            string sql = "SELECT ParentID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_SubTypeID"></param>
        /// <returns></returns>
        private int GetHeadTypeID2(int p_SubTypeID, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT ParentID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 根据区条码找到仓库编号
        /// </summary>
        /// <param name="p_SectionID"></param>
        /// <returns></returns>
        private string GetWHIDByISN(string p_SectionID)
        {
            string sql = "SELECT WHID FROM UV1_WH_Section WHERE WHISN=" + SysString.ToDBString(p_SectionID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 根据区条码找到仓库编号
        /// </summary>
        /// <param name="p_SectionID"></param>
        /// <returns></returns>
        private string GetWHIDByISN2(string p_SectionID, IDBTransAccess sqlTrans)
        {
            //string sql = "SELECT WHID FROM UV1_WH_Section WHERE WHISN=" + SysString.ToDBString(p_SectionID);
            string sql = "SELECT WHID FROM WH_Section WHERE SectionID=" + SysString.ToDBString(p_SectionID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据区条码找到仓库编号
        /// </summary>
        /// <param name="p_SectionID"></param>
        /// <returns></returns>
        private string GetWHSectionByISN(string p_SectionID)
        {
            string sql = "SELECT SectionID FROM UV1_WH_Section WHERE WHISN=" + SysString.ToDBString(p_SectionID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据区条码找到仓库编号
        /// </summary>
        /// <param name="p_SectionID"></param>
        /// <returns></returns>
        private string GetWHSectionByISN2(string p_SectionID, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT SectionID FROM UV1_WH_Section WHERE WHISN=" + SysString.ToDBString(p_SectionID);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            else
            {
                return string.Empty;
            }
        }

        private int GetSubTypeID(string p_SubType)
        {
            string sql = "SELECT ID FROM Enum_FormList WHERE FormNM=" + SysString.ToDBString(p_SubType);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }


        public string GetItemNameByFabric(string p_ItemCode, IDBTransAccess sqlTrans)
        {
            string outstr = "";
            string sql = "SELECT DesCription FROM Data_Fabric WHERE Code = " + SysString.ToDBString(p_ItemCode);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }

        /// <summary>
        /// 出库提交
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]

        public string DCMLOutWHSubmit(int p_ID, string p_VendorName, string p_SectionID, string p_OPName, int p_SubType, string p_FormNo, out int intSubmitFlag, out string p_ErrorMsg)
        {
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                string outstr = string.Empty;
                intSubmitFlag = 0;
                try
                {
                    sqlTrans.OpenTrans();


                    p_ErrorMsg = string.Empty;

                    //p_FormNo 合同号和发货单号
                    //string[] DCompactNo = p_FormNo.Split(',');
                    string CompactNo = "";// DCompactNo[0];//合同号
                    string FHNo = "";// DCompactNo[1];//发货单号
                    string SaleOPID = string.Empty;
                    string DtsVendorID = string.Empty;
                    int DepartmentID = 0;
                    //if (p_SubType != 1612)
                    //{
                    //    if (DCompactNo.Length != 2)
                    //    {
                    //        p_ErrorMsg = "选择的发货单有问题，请检查" + p_FormNo;
                    //        return outstr;
                    //        //  throw new Exception("选择的发货单有问题，请检查" + p_FormNo);
                    //    }


                    //CompactNo = DCompactNo[0];//合同号
                    //FHNo = DCompactNo[1];//发货单号
                    //}


                    //判断是否扫描   UV1_WH_PackISN   UV1_WH_PackBox
                    //string sql = "SELECT ID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    string sql = "SELECT ID FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }
                    if (p_SubType != 1612)
                    {
                        //sql = "SELECT DISTINCT ItemCode FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(FHNo);
                        //DataTable dtItem = sqlTrans.Fill(sql);
                        //if (dtItem.Rows.Count <= 0)
                        //{
                        //    p_ErrorMsg = "发货单" + FHNo + "没有明细数据请检查";
                        //    return outstr;
                        //}


                        #region 校验扫描的是否为这个发货单的数据品种
                        ////sql = "SELECT ItemCode FROM UV1_WH_PackISN WHERE ItemCode NOT IN(SELECT ItemCode FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(FHNo) + " AND DtsOrderFormNo=" + SysString.ToDBString(CompactNo) + ") AND  MainID=" + SysString.ToDBString(p_ID);

                        //sql = "SELECT ItemCode FROM UV1_WH_PackISNPackBox WHERE ItemCode NOT IN(SELECT ItemCode FROM UV1_Sale_FHFormDts WHERE FormNo=" + SysString.ToDBString(FHNo) + " AND DtsOrderFormNo=" + SysString.ToDBString(CompactNo) + ") AND  MainID=" + SysString.ToDBString(p_ID);

                        //DataTable dtItemCheck = sqlTrans.Fill(sql);
                        //if (dtItemCheck.Rows.Count != 0)
                        //{
                        //    p_ErrorMsg = "扫描的数据中有发货单" + FHNo + "中没有的品种" + dtItemCheck.Rows[0]["ItemCode"].ToString() + "，请检查";
                        //    return outstr;
                        //}
                        #endregion

                        #region 校验是否是同一客户的同一业务员的货物

                        //sql = "SELECT SaleOPID,VendorID FROM Sale_SaleOrder WHERE FormNo IN(SELECT DISTINCT OrderFormNo FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID) + ")";
                        //DataTable dtCheck = sqlTrans.Fill(sql);
                        //if (dtCheck.Rows.Count == 1)
                        //{
                        //    SaleOPID = dtCheck.Rows[0]["SaleOPID"].ToString();
                        //    DtsVendorID = dtCheck.Rows[0]["VendorID"].ToString();

                        //    //sql = "SELECT Department FROM Data_OP WHERE OPID=" + SysString.ToDBString(SaleOPID);
                        //    //DataTable Department = sqlTrans.Fill(sql);
                        //    //if (Department.Rows.Count > 0)
                        //    //{
                        //    //    DepartmentID = SysConvert.ToInt32(Department.Rows[0]["Department"]);
                        //    //}
                        //    //else
                        //    //{
                        //    //    throw new Exception("业务员没有归入到部门，请检查，业务员编码：" + SaleOPID);
                        //    //}

                        //    //if (DepartmentID == 0)
                        //    //{
                        //    //    throw new Exception("业务员没有归入到部门，请检查，业务员编码：" + SaleOPID);
                        //    //}
                        //}
                        //else
                        //{
                        //    throw new Exception("没有明细数据，或者刷入的条码不是同一个客户的订单，请检查");
                        //}
                        #endregion
                    }
                    //sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,CompactNo,SO,ColorNum,ColorName,JSUnit,SUM(Weight) YQty,SUM(Qty) Qty,JarNum,DLever,WHID,SectionID,MF,KZ FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    //sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,CompactNo,SO,ColorNum,ColorName,JSUnit,JarNum,DLever,WHID,SectionID,MF,KZ";

                    sql = "SELECT ItemCode,ItemName,ItemStd,OrderFormNo,ColorNum,ColorName,SUM(Weight) Weight,SUM(Qty) Qty,JarNum,WHID,SectionID,MWidth,MWeight,Unit FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,ItemName,ItemStd,OrderFormNo,ColorNum,ColorName,JarNum,WHID,SectionID,MWidth,MWeight,Unit";
                    dt = sqlTrans.Fill(sql);




                    if (dt.Rows.Count > 0)
                    {

                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);

                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.VendorID = GetVendorID2(p_VendorName, sqlTrans);
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "条码扫描自动出库";
                        IOentity.VendorID = DtsVendorID;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.SaleOPID = SaleOPID;
                        IOentity.Indep = DepartmentID.ToString();
                        IOentity.OutDep = DepartmentID.ToString();

                        IOentity.Remark = p_FormNo;
                        //if (p_SubType == 1612)
                        //{
                        //    //IOentity.DBWHID = "CK008";
                        //    IOentity.SaleOPID = "JC007";
                        //    IOentity.Indep = "170";
                        //    IOentity.OutDep = "170";
                        //    IOentity.VendorID = "H017";
                        //}
                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);
                        //仓库从表
                        sql = "SELECT * FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);


                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                            entitydts[i].SBitID = "";


                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            entitydts[i].ItemName = dt.Rows[i]["ItemName"].ToString();
                            entitydts[i].ItemStd = dt.Rows[i]["ItemStd"].ToString();
                            //entitydts[i].ItemModel = dt.Rows[i]["ItemModel"].ToString();
                            //entitydts[i].CPItemCode = entitydts[i].ItemCode;

                            sql = "SELECT ItemModel FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(entitydts[i].ItemCode);
                            DataTable dtI = sqlTrans.Fill(sql);
                            if (dtI.Rows.Count != 0)
                            {
                                entitydts[i].ItemModel = SysConvert.ToString(dtI.Rows[0]["ItemModel"]);
                            }

                            entitydts[i].MWeight = SysConvert.ToString(dt.Rows[i]["MWeight"]);//克重
                            entitydts[i].MWidth = SysConvert.ToString(dt.Rows[i]["MWidth"]);//门幅
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                            entitydts[i].InSO = p_FormNo;
                            entitydts[i].DtsSO = dt.Rows[i]["OrderFormNo"].ToString();
                            entitydts[i].DtsOrderFormNo = dt.Rows[i]["OrderFormNo"].ToString();
                            //entitydts[i].DtsOrderFormNo = dt.Rows[i]["SO"].ToString();
                            //if (p_SubType == 1612)
                            //{
                            //    entitydts[i].InSO = "开发部";
                            //}
                            entitydts[i].InSO = CompactNo;//出库合同号
                            //entitydts[i].MaoTiao = FHNo;//发货单号

                            entitydts[i].Remark = "条码自动出库";

                            IOentity.WHID = dt.Rows[i]["WHID"].ToString();
                            IOentity.WHType = dt.Rows[i]["WHID"].ToString();

                            //entitydts[i].GoodsLevel = dt.Rows[i]["DLever"].ToString();
                            entitydts[i].Unit = dt.Rows[i]["Unit"].ToString();
                            entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["Weight"]);

                            #region 获取单价
                            //string CurrentUnit = string.Empty;
                            //decimal price = 0;// new WHLoadOutPrice().GetOutPrice(IOentity.SubType, entitydts[i], out CurrentUnit, sqlTrans);
                            //if (price != 0)
                            //{
                            //    entitydts[i].SinglePrice = price;
                            //    if (entitydts[i].Unit == "M")
                            //    {
                            //        entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Qty;
                            //    }
                            //    else if (entitydts[i].Unit == "Y")
                            //    {
                            //        entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Weight;
                            //    }
                            //    else
                            //    {
                            //        throw new Exception("出库单单位错误请检查");
                            //    }
                            //    if (CurrentUnit != string.Empty)
                            //    {
                            //        //entitydts[i].CurrentUnit = CurrentUnit;
                            //    }
                            //}
                            #endregion
                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString())
                                + " AND ISNULL(OrderFormNo,'')=" + SysString.ToDBString(dt.Rows[i]["OrderFormNo"].ToString())
                                + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString())
                                + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString())
                                ////+ " AND ISNULL(SO,'')=" + SysString.ToDBString(dt.Rows[i]["SO"].ToString()) 
                                + " AND ISNULL(Unit,'')=" + SysString.ToDBString(dt.Rows[i]["Unit"].ToString())
                                //+ " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString()) 
                                + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString())
                                + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString())
                                + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()));
                            entitydts[i].PieceQty = ISN.Length;


                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();
                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                                //entity.FactQty = SysConvert.ToDecimal(dr["Weight"]);
                                entity.FMQty = SysConvert.ToDecimal(dr["FMQty"]);//放码
                                entity.Remark = "条码扫描出库";
                                List.Add(entity);

                                m++;
                            }


                        }

                        SysFile.WriteFrameworkLog("A2" + sql.ToString());

                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }

                        IOentity.TotalQty = TotalQty;

                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);

                        //sql = "UPDATE WH_PckISNBag SET WHSaveID=" + IOentity.ID + " WHERE MainID=" + p_ID;
                        //sqlTrans.Fill(sql);

                        //rule2.RSubmit(IOentity.ID, 2, sqlTrans);
                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;
                    sqlTrans.RollbackTrans();
                }
                return outstr;

            }


        }

        [WebMethod]
        public string OutWHSubmit(int p_ID, string p_SaleID, string p_OPName, int p_SubType, out int intSubmitFlag, out string p_ErrorMsg)
        {
            string outstr = string.Empty;
            intSubmitFlag = 0;
            p_ErrorMsg = string.Empty;
            string sql = string.Empty;
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();
                    string WHID = string.Empty;
                    string SectionID = string.Empty;
                    string SBitID = string.Empty;
                    sql = "SELECT ID FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }
                    sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,OrderFormNo,ColorNum,ColorName,SUM(Weight) Weight,SUM(Qty) Qty,JarNum,WHID,SectionID,SBitID,MWidth,MWeight,Remark FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " AND ItemCode+ColorName+ColorNum+MWeight+MWidth NOT IN(SELECT ItemCode+ColorName+ColorNum+MWeight+MWidth FROM UV1_Sale_SaleOrderDts " + " WHERE ID = " + p_SaleID + " )";
                    sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,OrderFormNo,ColorNum,ColorName,JarNum,WHID,SectionID,SBitID,MWidth,MWeight,Remark";
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (p_ErrorMsg != string.Empty)
                            {
                                p_ErrorMsg += ",";
                            }
                            p_ErrorMsg += dr["ItemModel"].ToString();
                        }
                        p_ErrorMsg += "不属于该订单";
                        return outstr;
                    }
                    sql = "SELECT ItemCode,ItemName,ItemStd,OrderFormNo,ItemModel,ColorNum,ColorName,SUM(Weight) Weight,SUM(Qty) Qty,JarNum,WHID,SectionID,SBitID,MWidth,MWeight FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,OrderFormNo,ColorNum,ColorName,JarNum,WHID,SectionID,SBitID,MWidth,MWeight";
                    dt = sqlTrans.Fill(sql);
                    sql = "SELECT * FROM Sale_SaleOrder WHERE ID =" + p_SaleID;
                    DataTable dtSale = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);

                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.VendorID = dtSale.Rows[0]["VendorID"].ToString();
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "条码扫描自动出库";
                        IOentity.SaleOPID = dtSale.Rows[0]["SaleOPID"].ToString();
                        IOentity.Remark = dtSale.Rows[0]["FormNo"].ToString();
                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.SubType, sqlTrans);
                        //仓库从表
                        sql = "SELECT * FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);
                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                            entitydts[i].SBitID = dt.Rows[i]["SBitID"].ToString();
                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            entitydts[i].ItemName = dt.Rows[i]["ItemName"].ToString();
                            entitydts[i].ItemStd = dt.Rows[i]["ItemStd"].ToString();
                            entitydts[i].ItemModel = dt.Rows[i]["ItemModel"].ToString();
                            entitydts[i].MWeight = SysConvert.ToString(dt.Rows[i]["MWeight"]);//克重
                            entitydts[i].MWidth = SysConvert.ToString(dt.Rows[i]["MWidth"]);//门幅
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                            entitydts[i].DtsSO = dtSale.Rows[0]["FormNo"].ToString();
                            entitydts[i].DtsOrderFormNo = dtSale.Rows[0]["FormNo"].ToString();
                            entitydts[i].Remark = "条码自动出库";
                            //entitydts[i].Unit = dt.Rows[i]["Unit"].ToString();
                            entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["Weight"]);
                            sql = "SELECT SingPrice,Unit FROM UV1_Sale_SaleOrderDts WHERE ItemCode+ColorName+ColorNum+MWeight+MWidth =" + SysString.ToDBString(entitydts[i].ItemCode + entitydts[i].ColorName + entitydts[i].ColorNum + entitydts[i].MWeight + entitydts[i].MWidth);
                            sql += " AND ID =" + p_SaleID;
                            DataTable dtSingPrice = sqlTrans.Fill(sql);
                            if (dtSingPrice.Rows.Count > 0)
                            {
                                if (SysConvert.ToString(dt.Rows[0]["Unit"]) != string.Empty)
                                {
                                    if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/KG")
                                    {
                                        entitydts[i].SinglePrice = SysConvert.ToDecimal(dtSingPrice.Rows[0]["SingPrice"]);
                                        entitydts[i].Unit = SysConvert.ToString(dtSingPrice.Rows[0]["Unit"]);
                                        entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Weight;
                                    }
                                    if (SysConvert.ToString(dt.Rows[0]["Unit"]) == "RMB/M")
                                    {
                                        entitydts[i].SinglePrice = SysConvert.ToDecimal(dtSingPrice.Rows[0]["SingPrice"]);
                                        entitydts[i].Unit = SysConvert.ToString(dtSingPrice.Rows[0]["Unit"]);
                                        entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Qty;
                                    }
                                    //entitydts[i].SinglePrice = SysConvert.ToDecimal(dtSingPrice.Rows[0]["SingPrice"]);
                                    //entitydts[i].Amount = entitydts[i].Qty * entitydts[i].SinglePrice;
                                }
                            }
                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString())
                               + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString())
                               + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString())
                                   + " AND ISNULL(MWeight,'')=" + SysString.ToDBString(dt.Rows[i]["MWeight"].ToString())
                                       + " AND ISNULL(MWidth,'')=" + SysString.ToDBString(dt.Rows[i]["MWidth"].ToString())
                               + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString())
                               + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString())
                               + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()) + " AND ISNULL(SBitID,'')=" + SysString.ToDBString(dt.Rows[i]["SBitID"].ToString()));
                            entitydts[i].PieceQty = ISN.Length;
                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();
                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                                entity.Weight = SysConvert.ToDecimal(dr["Weight"]);
                                entity.GoodsLevel = SysConvert.ToString(dr["GoodsLevel"]);
                                //entity.FactQty = SysConvert.ToDecimal(dr["Weight"]);
                                // entity.FMQty = SysConvert.ToDecimal(dr["FMQty"]);//放码
                                entity.Remark = "条码扫描出库";
                                List.Add(entity);
                                m++;
                            }
                        }
                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }
                        IOentity.TotalQty = TotalQty;
                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);
                        rule2.RSubmit(IOentity.ID, (int)ConfirmFlag.已提交, sqlTrans);
                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception E)
                {
                    p_ErrorMsg = sql + E.Message;
                    sqlTrans.RollbackTrans();
                }
                return outstr;
            }
        }

        [WebMethod]
        public string OutWHSubmitByVendor(int p_ID, string p_VendorID, string p_OPName, int p_SubType, out int intSubmitFlag, out string p_ErrorMsg)
        {
            string outstr = string.Empty;
            intSubmitFlag = 0;
            p_ErrorMsg = string.Empty;
            string sql = string.Empty;
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                try
                {
                    sqlTrans.OpenTrans();
                    string WHID = string.Empty;
                    string SectionID = string.Empty;
                    string SBitID = string.Empty;
                    sql = "SELECT ID FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }
                    sql = "SELECT ItemCode,ItemName,ItemStd,OrderFormNo,ItemModel,ColorNum,ColorName,SUM(Weight) Weight,SUM(Qty) Qty,SUM(Yard) Yard,JarNum,WHID,SectionID,SBitID,MWidth,MWeight FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,OrderFormNo,ColorNum,ColorName,JarNum,WHID,SectionID,SBitID,MWidth,MWeight";
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);

                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.VendorID = p_VendorID;
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "条码扫描自动出库";
                        IOentity.SaleOPID = p_OPName;
                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.SubType, sqlTrans);
                        //仓库从表
                        sql = "SELECT * FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);
                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                            entitydts[i].SBitID = dt.Rows[i]["SBitID"].ToString();
                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            entitydts[i].ItemName = dt.Rows[i]["ItemName"].ToString();
                            entitydts[i].ItemStd = dt.Rows[i]["ItemStd"].ToString();
                            entitydts[i].ItemModel = dt.Rows[i]["ItemModel"].ToString();
                            entitydts[i].MWeight = SysConvert.ToString(dt.Rows[i]["MWeight"]);//克重
                            entitydts[i].MWidth = SysConvert.ToString(dt.Rows[i]["MWidth"]);//门幅
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                            entitydts[i].Remark = "条码自动出库";
                            entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["Weight"]);
                            entitydts[i].Yard = SysConvert.ToDecimal(dt.Rows[i]["Yard"]);
                            entitydts[i].InOrderFormNo = dt.Rows[i]["OrderFormNo"].ToString();
                            entitydts[i].DtsOrderFormNo = dt.Rows[i]["OrderFormNo"].ToString();
                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString())
                               + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString())
                               + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString())
                               + " AND ISNULL(OrderFormNo,'')=" + SysString.ToDBString(dt.Rows[i]["OrderFormNo"].ToString())
                               + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString())
                               + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString())
                               + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()) + " AND ISNULL(SBitID,'')=" + SysString.ToDBString(dt.Rows[i]["SBitID"].ToString()));
                            entitydts[i].PieceQty = ISN.Length;
                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();
                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                                entity.Weight = SysConvert.ToDecimal(dr["Weight"]);
                                entity.Yard = SysConvert.ToDecimal(dr["Yard"]);
                                entity.GoodsLevel = SysConvert.ToString(dr["GoodsLevel"]);
                                entity.Remark = "条码扫描出库";
                                List.Add(entity);
                                m++;
                            }
                        }
                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }
                        IOentity.TotalQty = TotalQty;
                        IOFormRule rule2 = new IOFormRule();
                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);
                        //rule2.RSubmit(IOentity.ID, (int)ConfirmFlag.已提交, sqlTrans);
                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception E)
                {
                    p_ErrorMsg = sql + E.Message;
                    sqlTrans.RollbackTrans();
                }
                return outstr;
            }
        }

        /// <summary>
        /// 出库提交----样品出库提交
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]

        public string DCMLOutWHSubmit4(int p_ID, string p_VendorName, string p_SectionID, string p_OPName, int p_SubType, string p_FormNo, DataTable p_dt, out int intSubmitFlag, out string p_ErrorMsg)
        {
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                string outstr = string.Empty;
                intSubmitFlag = 0;
                try
                {
                    sqlTrans.OpenTrans();


                    p_ErrorMsg = string.Empty;

                    //p_FormNo 合同号和发货单号
                    //string[] DCompactNo = p_FormNo.Split(',');
                    string CompactNo = "";// DCompactNo[0];//合同号
                    string FHNo = "";// DCompactNo[1];//发货单号
                    string SaleOPID = string.Empty;
                    string DtsVendorID = string.Empty;
                    int DepartmentID = 0;

                    string sql = "SELECT ID FROM UV1_WH_PckISNIOFormDtsISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }

                    ///扫描的条码有数据
                    if (p_dt.Rows.Count > 0)
                    {
                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);

                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.VendorID = GetVendorID2(p_VendorName, sqlTrans);
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "条码扫描自动出库";
                        IOentity.VendorID = DtsVendorID;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.SaleOPID = SaleOPID;
                        IOentity.Indep = DepartmentID.ToString();
                        IOentity.OutDep = DepartmentID.ToString();

                        IOentity.Remark = p_FormNo;

                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);
                        ////仓库从表
                        //sql = "SELECT * FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                        //DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[p_dt.Rows.Count - 1];
                        //ArrayList List = new ArrayList();


                        for (int i = 0; i < p_dt.Rows.Count - 1; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);

                            sql = "select * from WH_IOFormDtsISN where ISN=" + SysString.ToDBString(SysConvert.ToString(p_dt.Rows[i]["条码"]));
                            dt = SysUtils.Fill(sql);

                            if (dt.Rows.Count != 0)
                            {

                                entitydts[i].Seq = i + 1;
                                entitydts[i].WHID = dt.Rows[0]["WHID"].ToString();
                                entitydts[i].SectionID = dt.Rows[0]["SectionID"].ToString();
                                entitydts[i].SBitID = dt.Rows[0]["SBitID"].ToString();
                                entitydts[i].ItemCode = dt.Rows[0]["ItemCode"].ToString();
                                entitydts[i].ItemName = dt.Rows[0]["ItemName"].ToString();
                                entitydts[i].ItemStd = dt.Rows[0]["ItemStd"].ToString();
                                entitydts[i].ItemModel = dt.Rows[0]["ItemModel"].ToString();

                                //entitydts[i].MWeight = SysConvert.ToDecimal(dt.Rows[i]["MWeight"]);//克重
                                //entitydts[i].MWidth = SysConvert.ToDecimal(dt.Rows[i]["MWidth"]);//门幅
                                entitydts[i].ColorNum = dt.Rows[0]["ColorNum"].ToString();
                                entitydts[i].ColorName = dt.Rows[0]["ColorName"].ToString();
                                entitydts[i].JarNum = dt.Rows[0]["JarNum"].ToString();
                                entitydts[i].InSO = p_FormNo;
                                entitydts[i].InSO = CompactNo;//出库合同号

                                entitydts[i].Remark = "条码自动出库";

                                IOentity.WHID = dt.Rows[0]["WHID"].ToString();
                                IOentity.WHType = dt.Rows[0]["WHID"].ToString();

                                entitydts[i].Unit = dt.Rows[0]["Unit"].ToString();
                                entitydts[i].Qty = SysConvert.ToDecimal(p_dt.Rows[i]["数量"]);

                            }
                        }

                        SysFile.WriteFrameworkLog("A2" + sql.ToString());

                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }

                        IOentity.TotalQty = TotalQty;

                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, sqlTrans);


                    }

                    //sql = "UPDATE WH_PckISNBag SET WHSaveID=" + IOentity.ID + " WHERE MainID=" + p_ID;
                    //sqlTrans.Fill(sql);

                    //rule2.RSubmit(IOentity.ID, 2, sqlTrans);

                    sqlTrans.CommitTrans();
                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;
                    sqlTrans.RollbackTrans();
                }
                return outstr;

            }


        }

        private decimal GetSinglePrice(string p_FormNo, string p_ItemCode)
        {
            string sql = "SELECT SingPrice FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(p_FormNo);
            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToDecimal(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        private decimal GetSinglePrice2(string p_FormNo, string p_ItemCode, string p_GoodsLevel, IDBTransAccess sqlTrans)
        {
            string sql = "SELECT SingPrice FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(p_FormNo);
            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
            sql += " AND ISNULL(Lever,'')=" + SysString.ToDBString(p_GoodsLevel);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToDecimal(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }


        [WebMethod]
        public string DCMLSetPackNo(int p_ID, string p_PackNo, string p_ShopID, int p_SubType, out string strShopID, out string p_ErrorMsg)
        {
            string outstr = string.Empty;
            outstr = p_ID.ToString();
            p_ErrorMsg = string.Empty;
            strShopID = string.Empty;
            string sql = "";

            try
            {
                #region 可回修入库
                //if (p_SubType == 1507)//可回修入库
                //{
                //    sql = " SELECT DID,StatusID FROM UV1_WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(p_PackNo);
                //    DataTable dtm = SysUtils.Fill(sql);
                //    if (dtm.Rows.Count != 0)
                //    {
                //        if (SysConvert.ToInt32(dtm.Rows[0]["StatusID"]) == (int)EnumBoxStatus.出库)
                //        {
                //            //BProductCheckDts entitym = new BProductCheckDts();
                //            //entitym.ID = SysConvert.ToInt32(dtm.Rows[0]["DID"]);
                //            //entitym.SelectByID();
                //            //entitym.StatusID = (int)EnumBoxStatus.未入库;
                //            //BProductCheckDtsRule rulem = new BProductCheckDtsRule();
                //            //rulem.RUpdate(entitym);

                //            string sql1 = " SELECT ID FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_PackNo);
                //            DataTable dtPack = SysUtils.Fill(sql1);
                //            if (dtPack.Rows.Count != 0)
                //            {
                //                PackBox entityp = new PackBox();
                //                entityp.ID = SysConvert.ToInt32(dtPack.Rows[0]["ID"]);
                //                entityp.SelectByID();
                //                entityp.BoxStatusID = (int)EnumBoxStatus.未入库;
                //                PackBoxRule rulep = new PackBoxRule();
                //                rulep.RUpdate(entityp);
                //            }

                //        }
                //    }
                //}
                #endregion

                #region 期初入库
                if (p_SubType == 901 || p_SubType == 1107 || p_SubType == 1105)//成品期初入库，面料检验入库
                {
                    //sql = "SELECT ID FROM UV1_WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(p_PackNo) + " AND ISNULL(StatusID,0)>" + (int)EnumBoxStatus.未入库;
                    //DataTable dt = SysUtils.Fill(sql);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    p_ErrorMsg = "条码：" + p_PackNo + "已入库，请检查";
                    //    return outstr;
                    //}

                    //sql = "SELECT DISN,Seq FROM UV1_WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(p_PackNo);
                    //sql += " AND ISNULL(InWHFlag,0)=1";
                    //DataTable dtIn = SysUtils.Fill(sql);
                    //if (dtIn.Rows.Count != 0)
                    //{
                    //    p_ErrorMsg = "条码：" + p_PackNo + "已入库，请检查";
                    //    return outstr;
                    //}
                    sql = "SELECT ID FROM UV1_Chk_CheckOrderISN WHERE DISN=" + SysString.ToDBString(p_PackNo) + " AND ISNULL(StatusID,0)>" + (int)EnumBoxStatus.未入库;
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        p_ErrorMsg = "条码：" + p_PackNo + "已入库，请检查";
                        return outstr;
                    }

                    sql = "SELECT DISN,Seq FROM UV1_Chk_CheckOrderISN WHERE DISN=" + SysString.ToDBString(p_PackNo);
                    sql += " AND ISNULL(InWHFlag,0)=1";
                    DataTable dtIn = SysUtils.Fill(sql);
                    if (dtIn.Rows.Count != 0)
                    {
                        p_ErrorMsg = "条码：" + p_PackNo + "已入库，请检查";
                        return outstr;
                    }
                }
                #endregion

                #region OLD
                //if (p_SubType != 7777)//不是退货冲销的情况下检查
                //{
                //    sql = "SELECT ID FROM UV1_WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(p_PackNo) + " AND ISNULL(StatusID,0)>" + (int)EnumBoxStatus.未入库;
                //    DataTable dt = SysUtils.Fill(sql);
                //    if (dt.Rows.Count > 0)
                //    {
                //        p_ErrorMsg = "条码：" + p_PackNo + "已入库，请检查";
                //        return outstr;
                //    }

                //}
                //else//入库退货冲销的情况下
                //{

                //    sql = "SELECT ID FROM UV1_WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(p_PackNo) + " AND ISNULL(StatusID,0)=" + (int)EnumBoxStatus.入库;
                //    DataTable dt = SysUtils.Fill(sql);
                //    if (dt.Rows.Count <= 0)
                //    {
                //        p_ErrorMsg = "条码：" + p_PackNo + "不是入库状态无法退货冲销，请检查";
                //        return outstr;
                //    }
                //}
                #endregion


                sql = "SELECT DISN,Seq FROM UV1_Chk_CheckOrderISN WHERE DISN=" + SysString.ToDBString(p_PackNo);
                DataTable dtSeq = SysUtils.Fill(sql);
                if (dtSeq.Rows.Count == 0)
                {
                    p_ErrorMsg = "条码：" + p_PackNo + "不存在，请检查";
                    return outstr;
                }



                if (p_ID == 0)
                {
                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = SysConvert.ToInt32(dtSeq.Rows[0]["Seq"]);
                    rule.RAdd(entity);
                    entity.MainID = entity.ID;
                    rule.RUpdate(entity);
                    outstr = entity.MainID.ToString();
                    //p_ErrorMsg = outstr;
                    //return p_ErrorMsg;
                }
                else//如果已经产生了MainID则
                {
                    sql = "SELECT * FROM WH_PckISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " AND PackNo=" + SysString.ToDBString(p_PackNo);
                    DataTable dt = SysUtils.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        p_ErrorMsg = "条码：" + p_PackNo + "已存在，请检查";
                        return outstr;
                    }
                    else
                    {
                        //strShopID = shopID;
                    }

                    PckISNRule rule = new PckISNRule();
                    PckISN entity = new PckISN();
                    entity.MainID = p_ID;
                    entity.PackNo = p_PackNo;
                    entity.Seq = SysConvert.ToInt32(dtSeq.Rows[0]["Seq"]);
                    rule.RAdd(entity);
                    outstr = p_ID.ToString();
                }

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }

            return outstr;
        }

        /// <summary>
        /// 不保存数据删除表单
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_ErrorMsg"></param>
        /// <returns></returns>
        [WebMethod]
        public int DeleteWH(int p_ID, out string p_ErrorMsg)
        {
            int outi = 0;
            p_ErrorMsg = string.Empty;
            try
            {
                if (p_ID != 0)
                {

                    //string sql = "UPDATE WH_IOForm SET DelFlag=1 WHERE ID=" + SysString.ToDBString(p_ID);
                    //SysUtils.ExecuteNonQuery(sql);

                    //sql = "DELETE WH_IOFormDts WHERE MainID=" + SysString.ToDBString(p_ID);
                    //SysUtils.ExecuteNonQuery(sql);
                    string sql = "DELETE WH_PckISN WHERE MainID =" + SysString.ToDBString(p_ID);
                    SysUtils.Fill(sql);
                }
                else
                {
                    p_ErrorMsg = "读取不到表单";
                }



            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outi;
        }

        /// <summary>
        /// 移库提交
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]

        public string DCMLMoveWHSubmit(int p_ID, string p_VendorName, string p_SectionID, string p_OPName, int p_WHType, string p_FormNo, out int intSubmitFlag, out string p_ErrorMsg)
        {
            IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();

            string outstr = string.Empty;
            intSubmitFlag = 0;
            p_ErrorMsg = string.Empty;
            try
            {
                sqlTrans.OpenTrans();
                //判断是否扫描
                string sql = "SELECT ID FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "请扫描条码后提交";
                    return outstr;
                }


                sql = "SELECT ItemCode,ItemName,ItemStd,OrderFormNo,ColorNum,ColorName,SUM(Weight) Weight,SUM(Qty) Qty,JarNum,WHID,SectionID,MWidth,MWeight,Unit FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " GROUP BY ItemCode,ItemName,ItemStd,OrderFormNo,ColorNum,ColorName,JarNum,WHID,SectionID,MWidth,MWeight,Unit";
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {

                    //仓库主表
                    IOForm IOentity = new IOForm();
                    IOentity.ID = p_ID;
                    IOentity.SelectByID();

                    IOentity.FormDate = DateTime.Now.Date;
                    IOentity.SubType = 701;
                    IOentity.WHID = dt.Rows[0]["WHID"].ToString();
                    IOentity.WHType = dt.Rows[0]["WHID"].ToString();

                    //IOentity.VendorID = GetVendorID(p_VendorName);
                    IOentity.HeadType = GetHeadTypeID(IOentity.SubType);
                    IOentity.Remark = "条码扫描自动移库";


                    FormNoControlRule ruleno = new FormNoControlRule();
                    IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);


                    //仓库从表
                    sql = "SELECT * FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dtall = sqlTrans.Fill(sql);
                    IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                    ArrayList List = new ArrayList();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        entitydts[i] = new IOFormDts();


                        entitydts[i].Seq = i + 1;
                        entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                        entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                        entitydts[i].SBitID = "";


                        //entitydts[i].ToSectionID = GetWHSectionByISN(p_SectionID);
                        //entitydts[i].ToWHID = GetWHIDByISN(p_SectionID);

                        entitydts[i].ToSectionID = p_SectionID;
                        entitydts[i].ToWHID = GetWHIDByISN2(p_SectionID, sqlTrans);


                        entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                        entitydts[i].ItemName = dt.Rows[i]["ItemName"].ToString();
                        entitydts[i].ItemStd = dt.Rows[i]["ItemStd"].ToString();
                        //entitydts[i].ItemModel = dt.Rows[i]["ItemModel"].ToString();


                        entitydts[i].MWeight = SysConvert.ToString(dt.Rows[i]["MWeight"]);//克重
                        entitydts[i].MWidth = SysConvert.ToString(dt.Rows[i]["MWidth"]);//门幅
                        entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                        entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                        entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();

                        //entitydts[i].Batch = dt.Rows[i]["Batch"].ToString();
                        //entitydts[i].VendorBatch = dt.Rows[i]["VendorBatch"].ToString();                 
                        entitydts[i].DtsOrderFormNo = p_FormNo;
                        entitydts[i].Remark = "条码自动出库";

                        IOentity.WHID = dt.Rows[i]["WHID"].ToString();
                        IOentity.WHType = dt.Rows[i]["WHID"].ToString();

                        entitydts[i].Unit = dt.Rows[i]["Unit"].ToString();
                        entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["Weight"]);


                        DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString())
                                                       + " AND ISNULL(OrderFormNo,'')=" + SysString.ToDBString(dt.Rows[i]["OrderFormNo"].ToString())
                                                       + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString())
                                                       + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString())
                            ////+ " AND ISNULL(SO,'')=" + SysString.ToDBString(dt.Rows[i]["SO"].ToString()) 
                                                       + " AND ISNULL(Unit,'')=" + SysString.ToDBString(dt.Rows[i]["Unit"].ToString())
                            //+ " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString()) 
                                                       + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString())
                                                       + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString())
                                                       + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()));
                        entitydts[i].PieceQty = ISN.Length;

                        int m = 0;
                        foreach (DataRow dr in ISN)
                        {
                            IOFormDtsPack entity = new IOFormDtsPack();
                            entity.Seq = i + 1;
                            entity.SubSeq = m + 1;
                            entity.BoxNo = dr["PackNo"].ToString();
                            entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                            entity.Remark = "条码扫描移库";
                            List.Add(entity);
                            //string ISNsql = "UPDATE WO_FabricCheck SET Status=3 WHERE ISN=" + SysString.ToDBString(dr["PackNo"].ToString());//条码已经入库
                            //SysUtils.ExecuteNonQuery(ISNsql);
                            m++;
                        }


                    }



                    decimal TotalQty = 0;
                    for (int i = 0; i < entitydts.Length; i++)
                    {
                        TotalQty += entitydts[i].Qty;
                    }
                    IOentity.TotalQty = TotalQty;
                    IOFormRule rule2 = new IOFormRule();


                    rule2.RAdd(IOentity, entitydts, List, sqlTrans);

                    //rule2.RUpdate(IOentity, entitydts, List, sqlTrans);

                    //rule2.RSubmit(IOentity.ID, 2, sqlTrans);

                }

                sqlTrans.CommitTrans();
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
                sqlTrans.RollbackTrans();
            }


            return outstr;
        }
        /// <summary>
        /// 移库提交
        /// </summary>
        [WebMethod]
        public string YKWHSubmit(int p_ID, string p_SBitID, string p_OPName, int p_SubType, out int intSubmitFlag, out string p_ErrorMsg)
        {
            IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
            string outstr = string.Empty;
            intSubmitFlag = 0;
            p_ErrorMsg = string.Empty;
            string sql = string.Empty;
            try
            {
                sqlTrans.OpenTrans();
                sql = "SELECT ID FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                DataTable dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count == 0)
                {
                    p_ErrorMsg = "请扫描条码后提交";
                    return outstr;
                }
                sql = "SELECT * FROM WH_SBit WHERE SBitID =" + SysString.ToDBString(p_SBitID);
                DataTable dtSBit = sqlTrans.Fill(sql);
                sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,OrderFormNo,ColorNum,ColorName,SUM(Weight) Weight,SUM(Qty) Qty,JarNum,WHID,SectionID,SBitID,MWidth,MWeight FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                sql += " GROUP BY ItemCode,ItemName,ItemStd,ItemModel,OrderFormNo,ColorNum,ColorName,JarNum,WHID,SectionID,SBitID,MWidth,MWeight";
                dt = sqlTrans.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    IOForm IOentity = new IOForm();
                    //IOentity.ID = p_ID;
                    IOentity.SelectByID();
                    IOentity.FormDate = DateTime.Now.Date;
                    IOentity.SubType = p_SubType;
                    IOentity.HeadType = GetHeadTypeID(IOentity.SubType);
                    IOentity.MakeDate = DateTime.Now;
                    IOentity.MakeOPID = p_OPName;
                    IOentity.SaleOPID = p_OPName;
                    IOentity.Remark = "条码扫描自动移库";
                    FormNoControlRule ruleno = new FormNoControlRule();
                    IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.SubType, IOentity.WHID, sqlTrans);
                    sql = "SELECT * FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dtall = sqlTrans.Fill(sql);
                    IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                    ArrayList List = new ArrayList();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        entitydts[i] = new IOFormDts();
                        entitydts[i].Seq = i + 1;
                        entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                        entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                        entitydts[i].SBitID = dt.Rows[i]["SBitID"].ToString();
                        entitydts[i].ToWHID = SysConvert.ToString(dtSBit.Rows[0]["WHID"]);
                        entitydts[i].ToSectionID = SysConvert.ToString(dtSBit.Rows[0]["SectionID"]);
                        entitydts[i].ToSBitID = SysConvert.ToString(dtSBit.Rows[0]["SBitID"]);
                        entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                        entitydts[i].ItemName = dt.Rows[i]["ItemName"].ToString();
                        entitydts[i].ItemStd = dt.Rows[i]["ItemStd"].ToString();
                        entitydts[i].ItemModel = dt.Rows[i]["ItemModel"].ToString();


                        entitydts[i].MWeight = SysConvert.ToString(dt.Rows[i]["MWeight"]);//克重
                        entitydts[i].MWidth = SysConvert.ToString(dt.Rows[i]["MWidth"]);//门幅
                        entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                        entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                        entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                        entitydts[i].DtsOrderFormNo = dt.Rows[i]["OrderFormNo"].ToString();
                        entitydts[i].Remark = "条码自动移库";
                        //entitydts[i].Unit = dt.Rows[i]["Unit"].ToString();
                        entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                        entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["Weight"]);


                        DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString())
                                                       + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString())
                                                       + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString())
                                                       + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString())
                                                       + " AND ISNULL(MWeight,'')=" + SysString.ToDBString(dt.Rows[i]["MWeight"].ToString())
                                                       + " AND ISNULL(MWidth,'')=" + SysString.ToDBString(dt.Rows[i]["MWidth"].ToString())
                                                       + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString())
                                                       + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()) + " AND ISNULL(SBitID,'')=" + SysString.ToDBString(dt.Rows[i]["SBitID"].ToString()));
                        entitydts[i].PieceQty = ISN.Length;
                        int m = 0;
                        foreach (DataRow dr in ISN)
                        {
                            IOFormDtsPack entity = new IOFormDtsPack();
                            entity.Seq = i + 1;
                            entity.SubSeq = m + 1;
                            entity.BoxNo = dr["PackNo"].ToString();
                            entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                            entity.Weight = SysConvert.ToDecimal(dr["Weight"]);
                            entity.GoodsLevel = SysConvert.ToString(dr["GoodsLevel"]);
                            entity.Remark = "条码扫描移库";
                            List.Add(entity);
                            m++;
                        }
                    }
                    decimal TotalQty = 0;
                    decimal TotalWeight = 0;
                    for (int i = 0; i < entitydts.Length; i++)
                    {
                        TotalQty += entitydts[i].Qty;
                        TotalWeight += entitydts[i].Weight;
                    }
                    IOentity.TotalQty = TotalQty;
                    IOFormRule rule2 = new IOFormRule();
                    rule2.RAdd(IOentity, entitydts, List, sqlTrans);
                    rule2.RSubmit(IOentity.ID, 2, sqlTrans);
                }
                sqlTrans.CommitTrans();
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message + sql;
                sqlTrans.RollbackTrans();
            }
            return outstr;
        }


        /// <summary>
        /// 盘点提交--提供校验码单的差异
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]

        //public string DCMLCheckWHSubmit(int p_ID, string p_VendorName, string p_SectionID, string p_OPName, int p_SubType, string p_FormNo, out int intSubmitFlag, out string p_ErrorMsg)
        public string DCMLCheckWHSubmit(int p_ID, string p_WHID, string p_SectionID, string p_OPName, string p_VendorAttn, int p_SubType, out int intSubmitFlag, out string p_ErrorMsg)
        {
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                string outstr = string.Empty;
                intSubmitFlag = 0;
                try
                {
                    sqlTrans.OpenTrans();


                    p_ErrorMsg = string.Empty;

                    //p_FormNo 合同号和发货单号
                    //string[] DCompactNo = p_FormNo.Split(',');
                    string CompactNo = "";// DCompactNo[0];//合同号
                    string FHNo = "";// DCompactNo[1];//发货单号
                    string SaleOPID = string.Empty;
                    string DtsVendorID = string.Empty;
                    int DepartmentID = 0;


                    //判断是否扫描   UV1_WH_PackISN   UV1_WH_PackBox
                    //string sql = "SELECT ID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    string sql = "SELECT ID FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }

                    sql = "SELECT ItemCode,ItemName,ItemStd,OrderFormNo,ColorNum,ColorName,SUM(Weight) Weight,SUM(Qty) Qty,JarNum,WHID,SectionID,MWidth,MWeight,Unit FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,ItemName,ItemStd,OrderFormNo,ColorNum,ColorName,JarNum,WHID,SectionID,MWidth,MWeight,Unit";
                    dt = sqlTrans.Fill(sql);




                    if (dt.Rows.Count > 0)
                    {

                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);

                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        IOentity.SubmitOPID = p_OPName;
                        //IOentity.VendorID = GetVendorID2(p_VendorName, sqlTrans);
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "条码扫描自动出库";
                        IOentity.VendorID = DtsVendorID;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.SaleOPID = SaleOPID;
                        IOentity.Indep = DepartmentID.ToString();
                        IOentity.OutDep = DepartmentID.ToString();

                        IOentity.WHID = GetWHIDByISN2(p_SectionID, sqlTrans);



                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);
                        //仓库从表
                        sql = "SELECT * FROM UV1_WH_PackISNPackBox WHERE MainID=" + SysString.ToDBString(p_ID);
                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);


                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                            entitydts[i].SBitID = "";


                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            entitydts[i].ItemName = dt.Rows[i]["ItemName"].ToString();
                            entitydts[i].ItemStd = dt.Rows[i]["ItemStd"].ToString();
                            //entitydts[i].ItemModel = dt.Rows[i]["ItemModel"].ToString();
                            //entitydts[i].CPItemCode = entitydts[i].ItemCode;

                            entitydts[i].MWeight = SysConvert.ToString(dt.Rows[i]["MWeight"]);//克重
                            entitydts[i].MWidth = SysConvert.ToString(dt.Rows[i]["MWidth"]);//门幅
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();

                            entitydts[i].DtsSO = dt.Rows[i]["OrderFormNo"].ToString();
                            entitydts[i].DtsOrderFormNo = dt.Rows[i]["OrderFormNo"].ToString();
                            //entitydts[i].DtsOrderFormNo = dt.Rows[i]["SO"].ToString();
                            //if (p_SubType == 1612)
                            //{
                            //    entitydts[i].InSO = "开发部";
                            //}
                            entitydts[i].InSO = CompactNo;//出库合同号
                            //entitydts[i].MaoTiao = FHNo;//发货单号

                            entitydts[i].Remark = "条码自动出库";

                            IOentity.WHID = dt.Rows[i]["WHID"].ToString();
                            IOentity.WHType = dt.Rows[i]["WHID"].ToString();

                            //entitydts[i].GoodsLevel = dt.Rows[i]["DLever"].ToString();
                            entitydts[i].Unit = dt.Rows[i]["Unit"].ToString();
                            entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["Weight"]);


                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString())
                                + " AND ISNULL(OrderFormNo,'')=" + SysString.ToDBString(dt.Rows[i]["OrderFormNo"].ToString())
                                + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString())
                                + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString())
                                ////+ " AND ISNULL(SO,'')=" + SysString.ToDBString(dt.Rows[i]["SO"].ToString()) 
                                + " AND ISNULL(Unit,'')=" + SysString.ToDBString(dt.Rows[i]["Unit"].ToString())
                                //+ " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString()) 
                                + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString())
                                + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString())
                                + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()));
                            entitydts[i].PieceQty = ISN.Length;


                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();
                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                                //entity.FactQty = SysConvert.ToDecimal(dr["Weight"]);
                                entity.FMQty = SysConvert.ToDecimal(dr["FMQty"]);//放码
                                entity.Remark = "条码扫描出库";
                                List.Add(entity);

                                m++;
                            }


                        }

                        SysFile.WriteFrameworkLog("A2" + sql.ToString());

                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }

                        IOentity.TotalQty = TotalQty;

                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);

                        //rule2.RSubmit(IOentity.ID, 2, sqlTrans);
                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;
                    sqlTrans.RollbackTrans();
                }
                return outstr;

            }


        }


        #endregion

        #region 其他方法
        /// <summary>
        /// 获得订单
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindSaleOrder(string p_VendorAttn, int NoFlag, int DateFlag, string p_ScanCode, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT DISTINCT  FormNo FROM  UV1_Sale_SaleOrderDts WHERE VendorAttn=" + SysString.ToDBString(p_VendorAttn);
                //if (NoFlag == 1)
                //{
                //    sql += " AND ISNULL(PieceQty,0)>ISNULL(ReceivedPieceQty,0) "; 
                //}
                if (DateFlag == 1)
                {
                    sql += " AND OrderDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddMonths(-6).Date.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59");
                }
                sql += " AND SubmitFlag IN(1,2)";
                //sql += " AND ISNULL(FaHuoBiaoZhi,0)=0";
                //sql += " AND ISNULL(DtsSendFlag,0)=0";
                //string p_ItemCode = GetItemCode(p_ScanCode);
                //if (p_ItemCode != "")
                //{
                //    sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
                //}

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {

                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }

        /// <summary>
        /// 获得发货单
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindSaleFormNo(string p_VendorAttn, int NoFlag, int DateFlag, string p_ScanCode, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT DISTINCT DtsOrderFormNo+','+FormNo FormNo FROM  UV1_Sale_FHFormDts WHERE VendorAttn=" + SysString.ToDBString(p_VendorAttn);
                //if (NoFlag == 1)
                //{
                //    sql += " AND ISNULL(PieceQty,0)>ISNULL(ReceivedPieceQty,0) "; 
                //}
                if (DateFlag == 1)
                {
                    sql += " AND MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddMonths(-6).Date.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59");
                }
                sql += " AND SubmitFlag IN(1,2)";
                //sql += " AND ISNULL(FaHuoBiaoZhi,0)=0";
                sql += " AND ISNULL(DtsSendFlag,0)=0";
                //string p_ItemCode = GetItemCode(p_ScanCode);
                //if (p_ItemCode != "")
                //{
                //    sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
                //}

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {

                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }

        /// <summary>
        /// 获得染色订单
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindRSFormNo(string p_VendorAttn, int NoFlag, int DateFlag, string p_ScanCode, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT DISTINCT TOP 20 OrderFormNo+','+FormNo FormNo FROM  UV1_WO_FabricProcess WHERE VendorAttn=" + SysString.ToDBString(p_VendorAttn);

                if (DateFlag == 1)
                {
                    sql += " AND MakeDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddMonths(-6).Date.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59");
                }

                sql += " AND SubmitFlag=1";


                //sql += " ORDER BY ID DESC ";


                DataTable dt = SysUtils.Fill(sql);

                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {

                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }



        /// <summary>
        /// 获得订货客户
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindDHVendor2(string p_str, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT VendorID,VendorAttn,ID FROM Data_Vendor WHERE VendorID LIKE " + SysString.ToDBString("%" + p_str + "%");
                sql += " OR VendorName LIKE " + SysString.ToDBString("%" + p_str + "%");
                sql += " OR VendorAttn LIKE " + SysString.ToDBString("%" + p_str + "%");
                sql += " OR VendorNameSpell LIKE " + SysString.ToDBString("%" + p_str + "%");

                sql += " ORDER BY VendorAttn";

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }


        /// <summary>
        /// 获得仓库
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet BindDHWHID(string p_str, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT WHID,WHNM FROM WH_WH WHERE 1=1 AND IsUseable=1";

                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);

            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }

        #endregion

        #region  zhoufc
        /// <summary>
        /// 查询条码
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_PackNo"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string MLWHGetISNDts(string p_ISN, out string p_ErrorMsg, out string p_ISNDts)
        {

            string outstr = string.Empty;
            p_ErrorMsg = string.Empty;
            p_ISNDts = string.Empty;

            try
            {
                string sql = "SELECT * FROM WH_PackBox WHERE BoxNo=" + SysString.ToDBString(p_ISN);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    p_ISNDts = " " + Environment.NewLine;
                    p_ISNDts += "条码号：" + SysConvert.ToString(dt.Rows[0]["BoxNo"]) + Environment.NewLine;
                    p_ISNDts += "库：" + SysConvert.ToString(dt.Rows[0]["WHID"]) + Environment.NewLine;
                    p_ISNDts += "区：" + SysConvert.ToString(dt.Rows[0]["SectionID"]) + Environment.NewLine;
                    p_ISNDts += "编号：" + SysConvert.ToString(dt.Rows[0]["ItemCode"]) + Environment.NewLine;
                    p_ISNDts += "色号：" + SysConvert.ToString(dt.Rows[0]["ColorNum"]) + Environment.NewLine;
                    p_ISNDts += "颜色：" + SysConvert.ToString(dt.Rows[0]["ColorName"]) + Environment.NewLine;
                    p_ISNDts += "缸号：" + SysConvert.ToString(dt.Rows[0]["JarNum"]) + Environment.NewLine;
                    p_ISNDts += "数量：" + SysConvert.ToString(dt.Rows[0]["Qty"]) + Environment.NewLine;
                    p_ISNDts += "单位：" + SysConvert.ToString(dt.Rows[0]["Unit"]) + Environment.NewLine;


                }
                else
                {
                    p_ErrorMsg = "条码：" + p_ISN + "不存在，请检查";
                    return p_ErrorMsg;
                }


            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return outstr;


        }
        #endregion

        #endregion

        #region 获取当前包中第几匹
        /// <summary>
        /// 获得订货客户(TOP )
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public int GetCurrentPackBag(int p_SaveID, int p_PackID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            int Index = 0;
            try
            {

                string sql = "SELECT COUNT(DISN) DISN FROM WH_PckISNBag WHERE MainID=" + p_SaveID + " AND PackID=" + p_PackID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    Index = SysConvert.ToInt32(dt.Rows[0]["DISN"]);
                }
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return Index;
        }
        #endregion

        #region 一个条码离开仓库单据
        /// <summary>
        /// 一个条码离开仓库单据
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public int LeaveIOForm(string PackNo, int InOrOutFlag, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            int Index = 0;
            try
            {
                lock (this)
                {
                    IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                    string outstr = string.Empty;

                    try
                    {
                        sqlTrans.OpenTrans();


                        return 112;
                        string sql = string.Empty;
                        if (InOrOutFlag == 1)//入库
                        {
                            sql = "SELECT MainID,MainSeq,SubSeq,DtsID,Qty,FactQty FROM UV1_WH_IOFormDtsPack WHERE SubmitFlag IN(1,2) AND BoxNo=" + SysString.ToDBString(PackNo) + " AND HeadType=15";
                        }

                        if (InOrOutFlag == 2)//出库
                        {
                            sql = "SELECT MainID,MainSeq,SubSeq,DtsID,Qty,FactQty FROM UV1_WH_IOFormDtsPack WHERE SubmitFlag IN(1,2) AND BoxNo=" + SysString.ToDBString(PackNo) + " AND HeadType=16";
                        }

                        DataTable dt = sqlTrans.Fill(sql);
                        if (dt.Rows.Count == 1)
                        {
                            if (InOrOutFlag == 1)//入库
                            {
                                sql = "SELECT ID FROM WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(PackNo) + " AND StatusID=" + (int)EnumISNStatus.入库;
                            }
                            if (InOrOutFlag == 2)//出库
                            {
                                sql = "SELECT ID FROM WO_BProductCheckDts WHERE DISN=" + SysString.ToDBString(PackNo) + " AND StatusID=" + (int)EnumISNStatus.出库;
                            }

                            DataTable dtisn = sqlTrans.Fill(sql);
                            if (dtisn.Rows.Count == 1)
                            {
                                //1 处理条码状态
                                if (InOrOutFlag == 1)//入库
                                {
                                    sql = "UPDATE WO_BProductCheckDts SET StatusID=" + (int)EnumISNStatus.初始 + " WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(dtisn.Rows[0]["ID"]));
                                    sqlTrans.Fill(sql);

                                    sql = "DELETE FROM WH_PackBox WHERE BoxStatusID=" + (int)EnumISNStatus.入库 + " AND BoxNo=" + SysString.ToDBString(PackNo);
                                    sqlTrans.Fill(sql);
                                }
                                if (InOrOutFlag == 2)//出库
                                {
                                    sql = "UPDATE WO_BProductCheckDts SET StatusID=" + (int)EnumISNStatus.入库 + " WHERE ID=" + SysString.ToDBString(SysConvert.ToInt32(dtisn.Rows[0]["ID"]));
                                    sqlTrans.Fill(sql);

                                    sql = "UPDATE WH_PackBox SET BoxStatusID=" + (int)EnumISNStatus.入库 + " WHERE BoxNo=" + SysString.ToDBString(PackNo) + " AND BoxStatusID=" + (int)EnumISNStatus.出库;
                                    sqlTrans.Fill(sql);
                                }

                                //第二步删除仓库单据中的出入库信息

                                sql = "DELETE FROM WH_IOFormDtsPack WHERE MainID=" + SysString.ToDBString(dt.Rows[0]["MainID"].ToString()) + " AND Seq=" + SysString.ToDBString(dt.Rows[0]["MainSeq"].ToString()) + " AND SubSeq=" + SysString.ToDBString(dt.Rows[0]["SubSeq"].ToString()) + " AND BoxNo=" + SysString.ToDBString(PackNo);
                                sqlTrans.Fill(sql);
                                //第三步更新仓库单据丛表信息
                                IOFormDts entitydts = new IOFormDts(sqlTrans);
                                entitydts.ID = SysConvert.ToInt32(dt.Rows[0]["DtsID"]);
                                entitydts.SelectByID();
                                entitydts.PieceQty -= 1;
                                entitydts.Qty -= SysConvert.ToDecimal(dt.Rows[0]["Qty"]);
                                entitydts.Weight -= SysConvert.ToDecimal(dt.Rows[0]["FactQty"]);

                                if (entitydts.Unit == "Y" && InOrOutFlag == 2)
                                {
                                    entitydts.Amount = entitydts.Weight * entitydts.SinglePrice;
                                }
                                else
                                {
                                    entitydts.Amount = entitydts.Qty * entitydts.SinglePrice;
                                }
                                IOFormDtsRule ruledts = new IOFormDtsRule();
                                ruledts.RUpdate(entitydts, sqlTrans);
                                //第四步更新仓库库存信息

                                IOFormDts entitytemp = entitydts;
                                entitytemp.Qty = SysConvert.ToDecimal(dt.Rows[0]["Qty"]);
                                entitytemp.Weight = SysConvert.ToDecimal(dt.Rows[0]["FactQty"]);
                                entitytemp.PieceQty = 1;
                                IOForm entitym = new IOForm(sqlTrans);
                                entitym.ID = entitydts.MainID;
                                entitym.SelectByID();
                                entitym.SubmitFlag = (int)ConfirmFlag.未提交;
                                StorgeRule srule = new StorgeRule();
                                if (InOrOutFlag == 1)//入库
                                {
                                    srule.RSubmit((int)WHFormList.入库, entitym, entitytemp, (int)ConfirmFlag.未提交, sqlTrans);
                                }
                                if (InOrOutFlag == 2)//入库
                                {
                                    srule.RSubmit((int)WHFormList.出库, entitym, entitytemp, (int)ConfirmFlag.未提交, sqlTrans);
                                }

                                //第五步处理数据回填
                                sql = "SELECT FillDataTypeID,AuditFlag,WHQtyPosID,CheckQtyPer1,CheckQtyFrom,CheckQtyPer2,DZFlag,LoadFormTypeID,WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(entitym.SubType);
                                DataTable dtFormList = sqlTrans.Fill(sql);
                                //new WHFill().RFillDataType(entitym, new IOFormDts[] { entitytemp }, (int)ConfirmFlag.未提交, SysConvert.ToInt32(dtFormList.Rows[0]["FillDataTypeID"]), dtFormList.Rows[0], sqlTrans);//回填数据处理
                            }
                            else
                            {
                                p_ErrorMsg = "未找到对应状态的的条码信息：" + PackNo;

                                throw new Exception(p_ErrorMsg);
                            }

                        }
                        else
                        {
                            p_ErrorMsg = "未找到对应的条码信息：" + PackNo;

                            throw new Exception(p_ErrorMsg);
                        }

                        sqlTrans.CommitTrans();
                    }
                    catch (Exception E)
                    {
                        p_ErrorMsg = E.Message;
                        sqlTrans.RollbackTrans();
                    }
                }
                Index = 1;
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return Index;
        }
        #endregion

        #region 退货冲销入库
        /// <summary>
        /// 入库提交
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]
        public string DCMLInWHBackSubmit(int p_ID, string p_WHID, string p_SectionID, string p_OPName, string p_VendorAttn, int p_SubType, out int intSubmitFlag, out string p_ErrorMsg)
        {
            //    return "";
            lock (this)
            {

                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                string outstr = string.Empty; ;

                intSubmitFlag = 0;
                try
                {
                    sqlTrans.OpenTrans();

                    p_ErrorMsg = string.Empty;

                    //判断是否扫描
                    string sql = "SELECT ID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }

                    string SectionID = GetWHSectionByISN2(p_SectionID, sqlTrans);

                    string SaleOPID = string.Empty;
                    string DtsVendorID = string.Empty;
                    string DepartmentID = string.Empty;
                    sql = "SELECT SaleOPID,VendorID,FormNo FROM Sale_SaleOrder WHERE FormNo IN(SELECT DISTINCT CompactNo FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID) + ")";
                    DataTable dtCheck = sqlTrans.Fill(sql);
                    if (dtCheck.Rows.Count == 1)
                    {
                        SaleOPID = dtCheck.Rows[0]["SaleOPID"].ToString();
                        string sqlrc = "SELECT ShopID FROM WO_PackOrder WHERE ComSO=" + SysString.ToDBString(dtCheck.Rows[0]["FormNo"].ToString());
                        DataTable dtrc = sqlTrans.Fill(sqlrc);
                        if (dtrc.Rows.Count != 0)
                        {
                            DtsVendorID = dtrc.Rows[0]["ShopID"].ToString();
                        }

                        sql = "SELECT Department FROM Data_OP WHERE OPID=" + SysString.ToDBString(SaleOPID);
                        DataTable dtSaleOPID = sqlTrans.Fill(sql);
                        if (dtSaleOPID.Rows.Count > 0)
                        {
                            DepartmentID = SysConvert.ToString(dtSaleOPID.Rows[0]["Department"]);
                        }
                        else
                        {
                            throw new Exception("业务员没有归入到部门，请检查，业务员编码：" + SaleOPID);
                        }
                    }
                    else
                    {
                        throw new Exception("没有明细数据，或者刷入的条码不是同一个客户的订单，请检查");
                    }

                    sql = "SELECT ItemCode,CompactNo,SO,ColorNum,ColorName,JSUnit,SUM(FMQty) YQty,SUM(Qty) Qty,JarNum,DLever,WHID,SectionID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,CompactNo,SO,ColorNum,ColorName,JSUnit,JarNum,DLever,WHID,SectionID";
                    dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count > 0)
                    {
                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);
                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = 1513;
                        //IOentity.WHID = p_WHID;
                        //IOentity.WHType = p_WHID;
                        IOentity.WHID = dt.Rows[0]["WHID"].ToString();
                        IOentity.WHType = dt.Rows[0]["WHID"].ToString();
                        //IOentity.TuiHuoFlag = 1;//退货标志
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);

                        IOentity.VendorID = DtsVendorID;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.SaleOPID = SaleOPID;
                        IOentity.Indep = DepartmentID.ToString();
                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);
                        IOentity.Remark = "EIN";


                        sql = "SELECT * FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);

                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);


                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = dt.Rows[0]["WHID"].ToString();
                            entitydts[i].SectionID = dt.Rows[0]["SectionID"].ToString();
                            entitydts[i].SBitID = "";

                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            //entitydts[i].CPItemCode = entitydts[i].ItemCode;
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].Remark = "条码扫描自动入成品库";

                            entitydts[i].DtsSO = dt.Rows[i]["CompactNo"].ToString();
                            entitydts[i].DtsOrderFormNo = dt.Rows[i]["SO"].ToString();
                            entitydts[i].Unit = dt.Rows[i]["JSUnit"].ToString();
                            entitydts[i].DtsVendorID = DtsVendorID;
                            entitydts[i].GoodsLevel = dt.Rows[i]["DLever"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                            entitydts[i].Qty = 0m - SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            entitydts[i].Weight = 0m - SysConvert.ToDecimal(dt.Rows[i]["YQty"]);

                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString()) + " AND ISNULL(CompactNo,'')=" + SysString.ToDBString(dt.Rows[i]["CompactNo"].ToString()) + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString()) + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString()) + " AND ISNULL(SO,'')=" + SysString.ToDBString(dt.Rows[i]["SO"].ToString()) + " AND ISNULL(JSUnit,'')=" + SysString.ToDBString(dt.Rows[i]["JSUnit"].ToString()) + " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString()) + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString()) + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()) + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString()));
                            entitydts[i].PieceQty = 0 - ISN.Length;
                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();

                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                                entity.FactQty = SysConvert.ToDecimal(dr["FMQty"]);
                                entity.Remark = "条码扫描入库";
                                List.Add(entity);
                                m++;
                            }


                        }

                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }

                        IOentity.TotalQty = 0 - TotalQty;

                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);

                        rule2.RSubmit(IOentity.ID, 2, sqlTrans);
                    }
                    sqlTrans.CommitTrans();

                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;

                    sqlTrans.RollbackTrans();
                }
                return outstr;
            }
        }
        #endregion

        #region 获取SaveID
        /// <summary>
        /// 获取SaveID         
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet GetSaveID(out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            DataSet p_Ds = new DataSet();
            try
            {
                string sql = string.Empty;
                sql = "SELECT DISTINCT TOP 5  MainID FROM WH_PckISN WHERE 1=1 ORDER BY MainID DESC";
                DataTable dt = SysUtils.Fill(sql);
                p_Ds.Tables.Add(dt);
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return p_Ds;
        }

        /// <summary>
        /// 获取SaveID         
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public int GetPackCount(int SaveID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            int PackCount = 0;
            try
            {
                string sql = string.Empty;
                sql = "SELECT Count(ID)  MainID FROM WH_PckISN WHERE MainID=" + SaveID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    PackCount = SysConvert.ToInt32(dt.Rows[0]["MainID"]);
                }
            }
            catch (Exception E)
            {
                p_ErrorMsg = E.Message;
            }
            return PackCount;
        }
        #endregion

        #region 可回修染色出库
        /// <summary>
        /// 出库提交
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]

        public string DCMLOutWHSubmit2(int p_ID, string p_VendorName, string p_SectionID, string p_OPName, int p_SubType, string p_FormNo, out int intSubmitFlag, out string p_ErrorMsg)
        {
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                string outstr = string.Empty;
                intSubmitFlag = 0;
                try
                {
                    sqlTrans.OpenTrans();


                    p_ErrorMsg = string.Empty;

                    string[] DCompactNo = p_FormNo.Split(',');
                    string CompactNo = "";// DCompactNo[0];//合同号
                    string FHNo = "";// DCompactNo[1];//染色单号
                    string SaleOPID = string.Empty;
                    string DtsVendorID = string.Empty;
                    int DepartmentID = 0;

                    //判断是否扫描
                    string sql = "SELECT ID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }

                    sql = "SELECT ItemCode,CompactNo,SO,ColorNum,ColorName,JSUnit,SUM(Weight) YQty,SUM(Qty) Qty,JarNum,DLever,WHID,SectionID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,CompactNo,SO,ColorNum,ColorName,JSUnit,JarNum,DLever,WHID,SectionID";
                    dt = sqlTrans.Fill(sql);

                    if (dt.Rows.Count > 0)
                    {


                        CompactNo = dt.Rows[0]["CompactNo"].ToString();

                        #region 校验是否是同一客户的同一业务员的货物

                        sql = "SELECT SaleOPID,VendorID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(CompactNo);
                        DataTable dtCheck = sqlTrans.Fill(sql);
                        if (dtCheck.Rows.Count == 1)
                        {
                            SaleOPID = dtCheck.Rows[0]["SaleOPID"].ToString();
                            DtsVendorID = dtCheck.Rows[0]["VendorID"].ToString();

                            sql = "SELECT Department FROM Data_OP WHERE OPID=" + SysString.ToDBString(SaleOPID);
                            DataTable Department = sqlTrans.Fill(sql);
                            if (Department.Rows.Count > 0)
                            {
                                DepartmentID = SysConvert.ToInt32(Department.Rows[0]["Department"]);
                            }
                            else
                            {
                                throw new Exception("业务员没有归入到部门，请检查，业务员编码：" + SaleOPID);
                            }

                            if (DepartmentID == 0)
                            {
                                throw new Exception("业务员没有归入到部门，请检查，业务员编码：" + SaleOPID);
                            }
                        }
                        else
                        {
                            throw new Exception("出库订单号错误，" + CompactNo);
                        }
                        #endregion


                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);

                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.VendorID = GetVendorID2(p_VendorName, sqlTrans);
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "条码扫描自动出库";
                        IOentity.VendorID = DtsVendorID;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.SaleOPID = SaleOPID;
                        IOentity.Indep = DepartmentID.ToString();
                        IOentity.OutDep = DepartmentID.ToString();
                        if (p_SubType == 1612)
                        {
                            //IOentity.DBWHID = "CK008";
                            IOentity.SaleOPID = "JC007";
                            IOentity.Indep = "170";
                            IOentity.OutDep = "170";
                            IOentity.VendorID = "H017";
                        }
                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);
                        //仓库从表
                        sql = "SELECT * FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);


                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                            entitydts[i].SBitID = "";


                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            //entitydts[i].CPItemCode = entitydts[i].ItemCode;
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].InSO = p_FormNo;
                            entitydts[i].DtsSO = dt.Rows[i]["CompactNo"].ToString();
                            entitydts[i].DtsOrderFormNo = dt.Rows[i]["SO"].ToString();

                            entitydts[i].InSO = dt.Rows[i]["CompactNo"].ToString(); //出库合同号

                            //entitydts[i].MaoTiao = FHNo;//发货单号

                            entitydts[i].Remark = "条码自动出库";

                            IOentity.WHID = dt.Rows[i]["WHID"].ToString();
                            IOentity.WHType = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].Unit = dt.Rows[i]["JSUnit"].ToString();

                            entitydts[i].GoodsLevel = dt.Rows[i]["DLever"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                            entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["YQty"]);

                            #region 获取单价
                            string CurrentUnit = string.Empty;
                            decimal price = 0;// new WHLoadOutPrice().GetOutPrice(IOentity.SubType, entitydts[i], out CurrentUnit, sqlTrans);
                            if (price != 0)
                            {
                                entitydts[i].SinglePrice = price;
                                if (entitydts[i].Unit == "M")
                                {
                                    entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Qty;
                                }
                                else if (entitydts[i].Unit == "Y")
                                {
                                    entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Weight;
                                }
                                else
                                {
                                    throw new Exception("出库单单位错误请检查");
                                }
                                if (CurrentUnit != string.Empty)
                                {
                                    //entitydts[i].CurrentUnit = CurrentUnit;
                                }
                            }
                            //处理可回修出库的AB价格及对应的成本
                            //new WHLoadOutPrice().SETOutWHPrice(entitydts[i], sqlTrans);
                            #endregion
                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString()) + " AND ISNULL(CompactNo,'')=" + SysString.ToDBString(dt.Rows[i]["CompactNo"].ToString()) + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString()) + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString()) + " AND ISNULL(SO,'')=" + SysString.ToDBString(dt.Rows[i]["SO"].ToString()) + " AND ISNULL(JSUnit,'')=" + SysString.ToDBString(dt.Rows[i]["JSUnit"].ToString()) + " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString()) + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString()) + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString()) + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()));
                            entitydts[i].PieceQty = ISN.Length;


                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();
                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                                entity.FactQty = SysConvert.ToDecimal(dr["Weight"]);
                                entity.Remark = "条码扫描出库";
                                List.Add(entity);

                                m++;
                            }

                        }



                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }

                        IOentity.TotalQty = TotalQty;

                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);

                        //sql = "UPDATE WH_PckISNBag SET WHSaveID=" + IOentity.ID + " WHERE MainID=" + p_ID;
                        //sqlTrans.Fill(sql);

                        //rule2.RSubmit(IOentity.ID, 2, sqlTrans);
                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;
                    sqlTrans.RollbackTrans();
                }
                return outstr;

            }


        }



        private string GetPBItemCode(string p_ItemCode, IDBTransAccess sqlTrans)
        {
            string ItemCode = string.Empty;

            string sql = "SELECT FreeStr05 FROM Development_FabricTechnology WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = sqlTrans.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                ItemCode = dt.Rows[0]["FreeStr05"].ToString();
            }
            else
            {
                ItemCode = p_ItemCode;
            }

            return ItemCode;
        }
        #endregion

        #region 可回修调拨出库
        /// <summary>
        /// 出库提交
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]

        public string DCMLOutWHSubmit3(int p_ID, string p_VendorName, string p_SectionID, string p_OPName, int p_SubType, string p_FormNo, out int intSubmitFlag, out string p_ErrorMsg)
        {
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();
                string outstr = string.Empty;
                intSubmitFlag = 0;
                try
                {
                    sqlTrans.OpenTrans();


                    p_ErrorMsg = string.Empty;


                    string CompactNo = p_FormNo;
                    string SaleOPID = string.Empty;
                    string DtsVendorID = string.Empty;
                    int DepartmentID = 0;

                    //判断是否扫描
                    string sql = "SELECT ID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    DataTable dt = sqlTrans.Fill(sql);
                    if (dt.Rows.Count == 0)
                    {
                        p_ErrorMsg = "请扫描条码后提交";
                        return outstr;
                    }
                    if (p_SubType != 1612)
                    {




                        #region 获取业务员

                        sql = "SELECT SaleOPID,VendorID FROM Sale_SaleOrder WHERE FormNo IN(SELECT DISTINCT CompactNo FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID) + ")";
                        DataTable dtCheck = sqlTrans.Fill(sql);
                        if (dtCheck.Rows.Count > 0)
                        {
                            SaleOPID = dtCheck.Rows[0]["SaleOPID"].ToString();
                            DtsVendorID = dtCheck.Rows[0]["VendorID"].ToString();

                            sql = "SELECT Department FROM Data_OP WHERE OPID=" + SysString.ToDBString(SaleOPID);
                            DataTable Department = sqlTrans.Fill(sql);
                            if (Department.Rows.Count > 0)
                            {
                                DepartmentID = SysConvert.ToInt32(Department.Rows[0]["Department"]);
                            }
                            else
                            {
                                throw new Exception("业务员没有归入到部门，请检查，业务员编码：" + SaleOPID);
                            }

                            if (DepartmentID == 0)
                            {
                                throw new Exception("业务员没有归入到部门，请检查，业务员编码：" + SaleOPID);
                            }
                        }

                        #endregion
                    }
                    sql = "SELECT ItemCode,CompactNo,SO,ColorNum,ColorName,JSUnit,SUM(Weight) YQty,SUM(Qty) Qty,JarNum,DLever,WHID,SectionID FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                    sql += " GROUP BY ItemCode,CompactNo,SO,ColorNum,ColorName,JSUnit,JarNum,DLever,WHID,SectionID";
                    dt = sqlTrans.Fill(sql);

                    if (dt.Rows.Count > 0)
                    {

                        //仓库主表
                        IOForm IOentity = new IOForm(sqlTrans);

                        IOentity.FormDate = DateTime.Now.Date;
                        IOentity.SubType = p_SubType;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.VendorID = GetVendorID2(p_VendorName, sqlTrans);
                        IOentity.HeadType = GetHeadTypeID2(IOentity.SubType, sqlTrans);
                        IOentity.Remark = "条码扫描自动出库";
                        IOentity.VendorID = DtsVendorID;
                        IOentity.SubmitOPID = p_OPName;
                        IOentity.SaleOPID = SaleOPID;
                        IOentity.Indep = DepartmentID.ToString();
                        IOentity.OutDep = DepartmentID.ToString();

                        FormNoControlRule ruleno = new FormNoControlRule();
                        IOentity.FormNo = ruleno.RGetWHFormNo(IOentity.HeadType, IOentity.SubType, IOentity.WHID, sqlTrans);
                        //仓库从表
                        sql = "SELECT * FROM UV1_WH_PackISN WHERE MainID=" + SysString.ToDBString(p_ID);
                        DataTable dtall = sqlTrans.Fill(sql);
                        IOFormDts[] entitydts = new IOFormDts[dt.Rows.Count];
                        ArrayList List = new ArrayList();



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            entitydts[i] = new IOFormDts(sqlTrans);


                            entitydts[i].Seq = i + 1;
                            entitydts[i].WHID = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].SectionID = dt.Rows[i]["SectionID"].ToString();
                            entitydts[i].SBitID = "";


                            entitydts[i].ItemCode = dt.Rows[i]["ItemCode"].ToString();
                            //entitydts[i].CPItemCode = entitydts[i].ItemCode;
                            entitydts[i].ColorNum = dt.Rows[i]["ColorNum"].ToString();
                            entitydts[i].ColorName = dt.Rows[i]["ColorName"].ToString();
                            entitydts[i].InSO = p_FormNo;
                            entitydts[i].DtsSO = dt.Rows[i]["CompactNo"].ToString();
                            entitydts[i].DtsOrderFormNo = dt.Rows[i]["SO"].ToString();

                            entitydts[i].InSO = CompactNo;//出库合同号
                            //entitydts[i].MaoTiao = CompactNo;//发货单号

                            entitydts[i].Remark = "条码自动出库";

                            IOentity.WHID = dt.Rows[i]["WHID"].ToString();
                            IOentity.WHType = dt.Rows[i]["WHID"].ToString();
                            entitydts[i].Unit = dt.Rows[i]["JSUnit"].ToString();

                            entitydts[i].GoodsLevel = dt.Rows[i]["DLever"].ToString();
                            entitydts[i].JarNum = dt.Rows[i]["JarNum"].ToString();
                            entitydts[i].Qty = SysConvert.ToDecimal(dt.Rows[i]["Qty"]);
                            entitydts[i].Weight = SysConvert.ToDecimal(dt.Rows[i]["YQty"]);

                            #region 获取单价
                            string CurrentUnit = string.Empty;
                            decimal price = 0;// new WHLoadOutPrice().GetOutPrice(IOentity.SubType, entitydts[i], out CurrentUnit, sqlTrans);
                            if (price != 0)
                            {
                                entitydts[i].SinglePrice = price;
                                if (entitydts[i].Unit == "M")
                                {
                                    entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Qty;
                                }
                                else if (entitydts[i].Unit == "Y")
                                {
                                    entitydts[i].Amount = entitydts[i].SinglePrice * entitydts[i].Weight;
                                }
                                else
                                {
                                    throw new Exception("出库单单位错误请检查");
                                }
                                if (CurrentUnit != string.Empty)
                                {
                                    //entitydts[i].CurrentUnit = CurrentUnit;
                                }
                            }
                            bool BMFlag = false;
                            if (entitydts[i].WHID == "CK009")//可回修库
                            {
                                if (entitydts[i].DtsSO == entitydts[i].InSO)
                                {
                                    entitydts[i].VColorNum = "A";
                                    BMFlag = true;
                                }
                                else
                                {
                                    BMFlag = false;
                                }
                                string sqlrf = "SELECT RanFee,DepartmentID FROM UV1_Sale_OrderReview WHERE CompactNo=" + SysString.ToDBString(entitydts[i].InSO) + " AND (ProductNo=" + SysString.ToDBString(entitydts[i].ItemCode) + " OR PBItemCode=" + SysString.ToDBString(GetPBItemCode(entitydts[i].ItemCode, sqlTrans)) + ")";
                                DataTable dtrf = sqlTrans.Fill(sqlrf);
                                if (dtrf.Rows.Count != 0)
                                {
                                    //entitydts[i].PrintQty = SysConvert.ToDecimal(dtrf.Rows[0]["RanFee"]);

                                    int DepartMentID = SysConvert.ToInt32(dtrf.Rows[0]["DepartmentID"]);

                                    if (!BMFlag)//不是同一个部门
                                    {
                                        if (entitydts[i].DtsSO.IndexOf("PO") != -1)
                                        {
                                            sqlrf = "SELECT DepartmentID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(entitydts[i].DtsSO);// 
                                            DataTable dtdepart = sqlTrans.Fill(sqlrf);
                                            if (dtdepart.Rows.Count != 0)
                                            {

                                                if (DepartMentID == SysConvert.ToInt32(dtdepart.Rows[0]["DepartmentID"]))
                                                {
                                                    entitydts[i].VColorNum = "A";
                                                }
                                                else
                                                {
                                                    entitydts[i].VColorNum = "B";
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("订单号" + entitydts[i].DtsSO + "不存在，请检查！");
                                            }
                                        }
                                        else//不是PO号的
                                        {
                                            if (DepartMentID == 2)//外销
                                            {
                                                if (entitydts[i].DtsSO.Substring(0, 1) == "A" || entitydts[i].DtsSO.IndexOf("HXW") != -1)
                                                {
                                                    entitydts[i].VColorNum = "A";
                                                }
                                                else
                                                {
                                                    entitydts[i].VColorNum = "B";
                                                }
                                            }
                                            else//内销
                                            {
                                                if (entitydts[i].DtsSO.Substring(0, 1) == "A" || entitydts[i].DtsSO.IndexOf("HXN") == -1)
                                                {
                                                    entitydts[i].VColorNum = "B";
                                                }
                                                else
                                                {
                                                    entitydts[i].VColorNum = "A";
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception("合同号" + entitydts[i].InSO + " 还未确定染费，请检查");
                                }
                            }
                            #endregion
                            DataRow[] ISN = dtall.Select("ISNULL(ItemCode,'')=" + SysString.ToDBString(dt.Rows[i]["ItemCode"].ToString()) + " AND ISNULL(CompactNo,'')=" + SysString.ToDBString(dt.Rows[i]["CompactNo"].ToString()) + " AND ISNULL(ColorName,'')=" + SysString.ToDBString(dt.Rows[i]["ColorName"].ToString()) + " AND ISNULL(ColorNum,'')=" + SysString.ToDBString(dt.Rows[i]["ColorNum"].ToString()) + " AND ISNULL(SO,'')=" + SysString.ToDBString(dt.Rows[i]["SO"].ToString()) + " AND ISNULL(JSUnit,'')=" + SysString.ToDBString(dt.Rows[i]["JSUnit"].ToString()) + " AND ISNULL(DLever,'')=" + SysString.ToDBString(dt.Rows[i]["DLever"].ToString()) + " AND ISNULL(JarNum,'')=" + SysString.ToDBString(dt.Rows[i]["JarNum"].ToString()) + " AND ISNULL(SectionID,'')=" + SysString.ToDBString(dt.Rows[i]["SectionID"].ToString()) + " AND ISNULL(WHID,'')=" + SysString.ToDBString(dt.Rows[i]["WHID"].ToString()));
                            entitydts[i].PieceQty = ISN.Length;


                            int m = 0;
                            foreach (DataRow dr in ISN)
                            {
                                IOFormDtsPack entity = new IOFormDtsPack(sqlTrans);
                                entity.Seq = i + 1;
                                entity.SubSeq = m + 1;
                                entity.BoxNo = dr["PackNo"].ToString();
                                entity.Qty = SysConvert.ToDecimal(dr["Qty"]);
                                entity.FactQty = SysConvert.ToDecimal(dr["Weight"]);
                                entity.Remark = "条码扫描出库";
                                List.Add(entity);

                                m++;
                            }


                        }



                        decimal TotalQty = 0;
                        for (int i = 0; i < entitydts.Length; i++)
                        {
                            TotalQty += entitydts[i].Qty;
                        }

                        IOentity.TotalQty = TotalQty;

                        IOFormRule rule2 = new IOFormRule();

                        rule2.RAdd(IOentity, entitydts, List, sqlTrans);

                        //sql = "UPDATE WH_PckISNBag SET WHSaveID=" + IOentity.ID + " WHERE MainID=" + p_ID;
                        //sqlTrans.Fill(sql);

                        //rule2.RSubmit(IOentity.ID, 2, sqlTrans);
                    }
                    sqlTrans.CommitTrans();
                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;
                    sqlTrans.RollbackTrans();
                }
                return outstr;

            }


        }
        #endregion

        #region 判断订单号是否存在
        /// <summary>
        /// 判断订单号是否存在
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_dt"></param>
        /// <param name="p_ErrorMsg"></param>
        [WebMethod]

        public bool CheckCompactNo(string p_CompactNo, out string p_ErrorMsg)
        {
            bool find = false;
            lock (this)
            {
                IDBTransAccess sqlTrans = TransSysUtils.GetDBTransAccess();


                try
                {
                    sqlTrans.OpenTrans();


                    p_ErrorMsg = string.Empty;




                    //判断是否存在合同号

                    string sql = "SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_CompactNo) + " AND SubmitFlag=1";

                    DataTable dt = sqlTrans.Fill(sql);

                    if (dt.Rows.Count == 1)
                    {
                        find = true;

                    }

                    sqlTrans.CommitTrans();



                }
                catch (Exception E)
                {
                    p_ErrorMsg = E.Message;
                    sqlTrans.RollbackTrans();
                }

                return find;
            }


        }

        [WebMethod]
        public string GetSaleOrder(string p_FormNo, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            string ID = string.Empty;
            string sql = "SELECT ID FROM Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_FormNo);
            sql += " AND SubmitFlag =1";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                ID = SysConvert.ToString(dt.Rows[0]["ID"]);
            }
            else
            {
                p_ErrorMsg = "没有发现跟订单号。是否出入错误";
            }
            return ID;
        }

        [WebMethod]
        public string GetVendorName(string p_VendorID, out string p_ErrorMsg)
        {
            p_ErrorMsg = string.Empty;
            string VendorName = string.Empty;
            string sql = "SELECT * FROM Data_Vendor WHERE VendorID =" + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                VendorName = SysConvert.ToString(dt.Rows[0]["VendorName"]);
            }
            else
            {
                p_ErrorMsg = "没有找到对应的客户。请检查是否有出入";
            }
            return VendorName;
        }
        #endregion

    }
}
