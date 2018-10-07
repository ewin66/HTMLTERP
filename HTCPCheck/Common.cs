using System;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.HTERP.Sys;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using HttSoft.HTCPCheck.Data;
using HttSoft.HTCPCheck.DataCtl;
using System.Drawing;
using System.Drawing.Printing;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Text;
namespace HTCPCheck
{
    /// <summary>
    /// Ŀ��: ����Win Formͨ�÷���
    /// ����: �¼Ӻ�
    /// ��������: 2005.2.1
    /// </summary>
    public class Common
    {


        #region �󶨹�˾
        /// <summary>
        /// �󶨹�˾��
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindCompanyType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_CompanyType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨹�˾��
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindCompanyType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_CompanyType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        #endregion

        #region   ��
        /// <summary>
        /// �󶨷�������
        /// </summary>
        public static void BindSubTypeShipment(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindSubTypeShipment(p_DrpID, 0, p_ShowBlank);
        }
        /// <summary>
        /// �󶨷�������
        /// </summary>
        public static void BindSubTypeShipment(LookUpEdit p_DrpID, int p_ParnetID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND ISNULL(ShipmentFlag,0)=1";//����֪ͨ����־
            if (p_ParnetID != 0)
            {
                sql += " AND ParentID=" + SysString.ToDBString(p_ParnetID);
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        #endregion

        #region ��Ա�����
        /// <summary>
        /// ��ȫ��Ա��
        /// </summary>
        public static void BindOP(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }



        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindOP(LookUpEdit p_DrpID, int p_DepID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1 AND UseableFlag=1 AND isnull(DefaultFlag,0)<>1 ";
            sql += " AND OPID IN(SELECT OPID FROM Data_OPDep WHERE DepID=" + SysString.ToDBString(p_DepID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }

        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindOP(RepositoryItemLookUpEdit p_DrpID, int p_DepID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1 AND UseableFlag=1 AND isnull(DefaultFlag,0)<>1 ";
            sql += " AND OPID IN(SELECT OPID FROM Data_OPDep WHERE DepID=" + SysString.ToDBString(p_DepID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }


        /// <summary>
        /// ���˷�
        /// </summary>
        public static void BindWLAmount(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WLAmount WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOP(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1 AND UseableFlag=1 AND isnull(DefaultFlag,0)<>1 ";
            //sql += " AND OPID IN(SELECT OPID FROM Data_OPDep WHERE DepID=" + SysString.ToDBString(p_DepID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }


        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOPALL(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }

        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOPID(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "OPID", p_ShowBlank);
        }


        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOPID(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "OPID", p_ShowBlank);
        }



        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindOPID(LookUpEdit p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });

            string sql = "Select OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE OPID IN";
            sql += "(Select OPID FROM Data_OPDep WHERE DepID in";
            sql += "(Select DepID From Data_FOPDep WHERE CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName);
            sql += "))";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count <= 0)
            {
                sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
                sql += " AND UseableFlag=1 ";
                sql += " AND isnull(DefaultFlag,0)=0";
                dt = SysUtils.Fill(sql);
            }
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "OPID", p_ShowBlank);
        }

        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindOPID(RepositoryItemLookUpEdit p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });

            string sql = "Select OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE OPID IN";
            sql += "(Select OPID FROM Data_OPDep WHERE DepID in";
            sql += "(Select DepID From Data_FOPDep WHERE CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName);
            sql += "))";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count <= 0)
            {
                sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
                sql += " AND UseableFlag=1 ";
                sql += " AND isnull(DefaultFlag,0)=0";
                dt = SysUtils.Fill(sql);
            }
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "OPID", p_ShowBlank);

        }


        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOPID(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank, string p_condition)
        {
            //p_DrpID.auto
            p_DrpID.ShowHeader = true;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            sql += p_condition;
            if (p_condition.ToUpper().IndexOf("ORDER") == -1)//û����������������
            {
                sql += " ORDER BY OPID";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "OPID", p_ShowBlank);
        }

        /// <summary>
        /// ������Ա������Դ
        /// </summary>
        /// <returns></returns>
        public DataTable BindOPIDGetDataSource(string p_condition)
        {
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            sql += p_condition;
            if (p_condition.ToUpper().IndexOf("ORDER") == -1)//û����������������
            {
                sql += " ORDER BY OPID";
            }
            DataTable dt = SysUtils.Fill(sql);
            return dt;
        }

        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOPID(RepositoryItemLookUpEdit p_DrpID, DataTable p_Dt, bool p_ShowBlank, string p_condition)
        {
            //p_DrpID.auto
            p_DrpID.ShowHeader = true;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            //string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            //sql += " AND UseableFlag=1 ";
            //sql += " AND isnull(DefaultFlag,0)=0";
            //sql += p_condition;
            //if (p_condition.ToUpper().IndexOf("ORDER") == -1)//û����������������
            //{
            //    sql += " ORDER BY OPID";
            //}
            DataTable dt = FProcessDataTable.TableQuery(p_Dt, "1=1 " + p_condition);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "OPID", p_ShowBlank);
        }


        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOPID(LookUpEdit p_DrpID, bool p_ShowBlank, string p_condition)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            sql += p_condition;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "OPID", p_ShowBlank);
        }


        #endregion

        #region �ֿ�������
        ///// <summary>
        ///// �󶨲ֿ�--�ǼĿ��
        ///// </summary>
        //public static void BindWH(LookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT WHID,WHNM FROM WH_WH WHERE 1=1 AND IsUseable=1";
        //    sql += " AND isnull(ISJK,0)<>1";

        //    if (!FParamConfig.LoginHTFlag)
        //    {

        //        string sqlTemp = "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
        //        DataTable dtTemp = SysUtils.Fill(sqlTemp);
        //        if (dtTemp.Rows.Count != 0)
        //        {
        //            sql += " AND WHID IN ( ";
        //            sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
        //            sql += ") ";
        //        }
        //    }

        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        //}

        ///// <summary>
        ///// �󶨲ֿ�--�ǼĿ��
        ///// </summary>
        //public static void BindWH(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.ShowHeader = false;
        //    FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT WHID,WHNM FROM WH_WH WHERE 1=1 AND IsUseable=1";
        //    sql += " AND isnull(ISJK,0)<>1";

        //    if (!FParamConfig.LoginHTFlag)
        //    {

        //        string sqlTemp = "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
        //        DataTable dtTemp = SysUtils.Fill(sqlTemp);
        //        if (dtTemp.Rows.Count != 0)
        //        {
        //            sql += " AND WHID IN ( ";
        //            sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
        //            sql += ") ";
        //        }
        //    }

        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        //}
        /// <summary>
        /// �󶨲ֿ�--���е�
        /// </summary>
        public static void BindAllWH(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHNM FROM WH_WH WHERE 1=1 AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ� Ϊlookupedit��ֵ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindChackTask(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "FLOWID", "FLOWID" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT FLOWID,FLOWID FROM WH_WH WHERE 1=1 AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FLOWID", "FLOWID", p_ShowBlank);
        }



        /// <summary>
        /// �󶨲ֿ�--���е�
        /// </summary>
        public static void BindAllWH(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHNM FROM WH_WH WHERE 1=1 AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }
        public static string GetWHNMByWHID(string p_whid)
        {
            string sql = "SELECT WHNM FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_whid);
            DataTable dt = SysUtils.Fill(sql);
            string temp = dt.Rows[0]["WHNM"].ToString();
            return temp;
        }

        public static string GetWHIDByID(int p_ID)
        {
            string sql = "SELECT WHID FROM WH_WH WHERE ID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            string temp = string.Empty;
            if (dt.Rows.Count != 0)
            {
                temp = dt.Rows[0]["WHID"].ToString();
            }
            return temp;
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWH(LookUpEdit p_DrpID, int p_FormListAID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            if (p_FormListAID != 0)
            {
                sql += " AND WHTypeID IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�����
        /// </summary>
        public static void BindWHType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            //FCommon.LookupEditColAdd(p_DrpID,new int[2]{50,100},new string[2]{"ID","Name"},new string[2]{"",""},new bool[2]{false,true});
            string sql = "SELECT ID,Name FROM Enum_WHType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ��������
        /// </summary>
        public static void BindWHCalMethod(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHCalMethod";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�����λ��
        /// </summary>
        public static void BindWHPosMethod(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHPosMethod";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ��������
        /// </summary>
        public static void BindWHCalMethod(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_WHCalMethod";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByWHType(LookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            BindWHRight(p_DrpID, p_Type, p_ShowBlank);
            //p_DrpID.Properties.ShowHeader = false;
            //p_DrpID.Properties.ShowFooter = false;
            //FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            //string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            //sql += " AND WHTypeID=" + SysString.ToDBString(p_Type);
            //DataTable dt = SysUtils.Fill(sql);
            //FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByWHType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindWHRight(p_DrpID, 0, p_ShowBlank);
            //p_DrpID.Properties.ShowHeader = false;
            //p_DrpID.Properties.ShowFooter = false;
            //FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            //string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            //DataTable dt = SysUtils.Fill(sql);
            //FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHRightByWHType(LookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            //string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            //DataTable dt = SysUtils.Fill(sql);

            DataTable dt = GetRightWHList(p_Type);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);

            //FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByWHType(RepositoryItemLookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            BindWHRight(p_DrpID, p_Type, p_ShowBlank);
            //p_DrpID.ShowHeader = false;
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            //string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            //sql += " AND WHTypeID=" + SysString.ToDBString(p_Type);
            //DataTable dt = SysUtils.Fill(sql);
            //FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "WHID", "WHID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByWHType(RepositoryItemComboBox p_DrpID, int p_Type, bool p_ShowBlank)
        {
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            sql += " AND WHTypeID=" + SysString.ToDBString(p_Type);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWH(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindWHByWHType(p_DrpID, p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWH(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindWHByWHType(p_DrpID, 0, p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWH(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByFormList(LookUpEdit p_DrpID, int p_FormListAID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            if (p_FormListAID != 0)
            {
                sql += " AND WHTypeID IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";

            }
            if (!FParamConfig.LoginHTFlag && ParamConfig.WHIDRightFlag)
            {
                sql += " AND WHID IN ( ";
                sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
                sql += ") ";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ�(�����ڳ����ʱ�������ͺͲֿ�İ�)
        /// </summary>
        /// <param name="p_DrpID">Ҫ�󶨵Ŀؼ�</param>
        /// <param name="p_FormListAID">���常����</param>
        /// <param name="p_FormListBID">�����ͣ��ڳ����òֿ����ͣ�</param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWHByFormList(LookUpEdit p_DrpID, int p_FormListAID, int p_FormListBID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            if (p_FormListAID != 0)
            {
                if (p_FormListAID == 9)
                {
                    sql += " AND WHTypeID =" + SysString.ToDBString(p_FormListBID);
                }
                else
                {
                    sql += " AND WHTypeID IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";
                }


            }
            if (!FParamConfig.LoginHTFlag && ParamConfig.WHIDRightFlag)
            {
                sql += " AND WHID IN ( ";
                sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
                sql += ") ";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByFormList(RepositoryItemLookUpEdit p_DrpID, int p_FormListAID, bool p_ShowBlank)
        {

            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            if (p_FormListAID != 0)
            {
                if (p_FormListAID != 9)
                {
                    sql += " AND WHTypeID IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";
                }
            }
            if (!FParamConfig.LoginHTFlag && ParamConfig.WHIDRightFlag)
            {
                sql += " AND WHID IN ( ";
                sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
                sql += ") ";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "WHID", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHRightByFormList(LookUpEdit p_DrpID, int p_FormListAID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });

            DataTable dt = GetRightWHListByFormList(p_FormListAID);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHRightByFormList(RepositoryItemLookUpEdit p_DrpID, int p_FormListAID, bool p_ShowBlank)
        {

            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            DataTable dt = GetRightWHListByFormList(p_FormListAID);

            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲ֿ���
        /// </summary>
        public static void BindSection(RepositoryItemComboBox p_DrpID, string p_WHID, bool p_ShowBlank)
        {
            string sql = "SELECT SectionID FROM WH_Section WHERE 1=1";
            sql += " AND WHID=" + SysString.ToDBString(p_WHID);
            sql += " AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropItemComb(p_DrpID, dt, "SectionID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ���
        /// </summary>
        public static void BindSection(RepositoryItemLookUpEdit p_DrpID, string p_WHID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "SectionID", "SectionID" }, new string[2] { "", "" }, new bool[2] { false, true });

            string sql = "SELECT SectionID FROM WH_Section WHERE 1=1";
            sql += " AND WHID=" + SysString.ToDBString(p_WHID);
            sql += " AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "SectionID", "SectionID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ���
        /// </summary>
        public static void BindSection(LookUpEdit p_DrpID, string p_WHID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "SectionID", "SectionID" }, new string[2] { "", "" }, new bool[2] { false, true });

            string sql = "SELECT SectionID FROM WH_Section WHERE 1=1";
            sql += " AND WHID=" + SysString.ToDBString(p_WHID);
            sql += " AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "SectionID", "SectionID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ�λ
        /// </summary>
        public static void BindSBit(RepositoryItemLookUpEdit p_DrpID, string p_WHID, string p_SectionID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "SBitID", "SBitID" }, new string[2] { "", "" }, new bool[2] { false, true });

            string sql = "SELECT SBitID FROM WH_SBit WHERE 1=1";
            sql += " AND WHID=" + SysString.ToDBString(p_WHID);
            sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
            sql += " AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "SBitID", "SBitID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ�λ
        /// </summary>
        public static void BindSBit(RepositoryItemComboBox p_DrpID, string p_WHID, string p_SectionID, bool p_ShowBlank)
        {

            string sql = "SELECT SBitID FROM WH_SBit WHERE 1=1";

            sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
            sql += " and WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "SBitID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        /// <param name="p_Drp"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWHRight(RepositoryItemLookUpEdit p_Drp, int p_WHType, bool p_ShowBlank)
        {
            p_Drp.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_Drp, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            DataTable dt = GetRightWHList(p_WHType);
            FCommon.LoadDropRepositoryLookUP(p_Drp, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        /// <param name="p_Drp"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWHRight(LookUpEdit p_Drp, int p_WHType, bool p_ShowBlank)
        {
            p_Drp.Properties.ShowHeader = false;
            p_Drp.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_Drp, new int[2] { 50, 150 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            DataTable dt = GetRightWHList(p_WHType);
            FCommon.LoadDropLookUP(p_Drp, dt, "WHNM", "WHID", p_ShowBlank);
        }



        /// <summary>
        /// ��ȡ��Ȩ�޲ֿ��ַ���
        /// </summary>
        /// <param name="p_OPID">Ա��ID</param>
        /// <param name="p_WHType">�ֿ�����</param>
        /// <returns>����ѯ���ַ���</returns>
        public static string GetRightWHListStr(int p_WHType)
        {
            string outstr = string.Empty;

            DataTable dt = GetRightWHList(p_WHType);
            foreach (DataRow dr in dt.Rows)
            {
                if (outstr != "")
                {
                    outstr += ",";
                }
                outstr += SysString.ToDBString(dr["WHID"].ToString());
            }
            if (outstr == string.Empty)
            {
                outstr = "''";
            }
            return outstr;
        }


        /// <summary>
        /// �����Ȩ�޵Ĳֿ��б�
        /// </summary>
        /// <param name="p_WHType">�ֿ�����</param>
        /// <returns>DataTable</returns>
        public static DataTable GetRightWHList(int p_WHType)
        {
            string sql = "SELECT ID,WHID,WHID+' '+WHNM WHNM  FROM WH_WH WHERE ";
            sql += "  WHID IN ( SELECT WHID FROM WH_WH WHERE IsUseable=1";
            if (p_WHType != 0)
            {
                sql += "  AND WHType=" + p_WHType.ToString();
            }
            sql += "   )";
            if (!FParamConfig.LoginHTFlag && ParamConfig.WHIDRightFlag)
            {
                sql += " AND WHID IN ( ";
                sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
                sql += ") ";
            }
            return SysUtils.Fill(sql);
        }


        /// <summary>
        /// �����Ȩ�޵Ĳֿ��б�
        /// </summary>
        /// <param name="p_WHType">�ֿ�����</param>
        /// <returns>DataTable</returns>
        public static DataTable GetRightWHListByFormList(int p_FormListAID)
        {
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM  FROM WH_WH WHERE ";
            sql += "  WHID IN ( SELECT WHID FROM WH_WH WHERE IsUseable=1)";

            if (!FParamConfig.LoginHTFlag && ParamConfig.WHIDRightFlag)
            {
                sql += " AND WHID IN ( ";
                sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(ParamConfig.LoginID);
                sql += ") ";
            }
            if (p_FormListAID != 0)
            {
                sql += " AND WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";
            }
            return SysUtils.Fill(sql);
        }

        #endregion

        #region �󶨿ͻ����
        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindVendorType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_VendorType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindVendorType(LookUpEdit p_DrpID, int p_BaseTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_VendorType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            if (p_BaseTypeID != 0)
            {
                sql += " AND BaseType=" + SysString.ToDBString(p_BaseTypeID);
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(LookUpEdit p_DrpID, int p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, new int[] { p_VendorType }, p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(LookUpEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, p_VendorType, "", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(LookUpEdit p_DrpID, int[] p_VendorType, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 70, 230 }, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });

            FCommon.LoadDropLookUP(p_DrpID, BindVendorDataSource(p_VendorType, p_Condition), ParamConfig.BindVendorDisplayField, "VendorID", p_ShowBlank);
            p_DrpID.Tag = p_VendorType;
            //new LookUpClear(p_DrpID);
        }

        /// <summary>
        /// �󶨿ͻ��ͻ�(ͨ�������ͣ�
        /// </summary>
        public static void BindVendorByBaseType(LookUpEdit p_DrpID, int p_BaseType, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 70, 230 }, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });

            string sql = "SELECT VendorID,VendorAttn,VendorName,VendorID+' '+VendorAttn VendorAll FROM Data_Vendor WHERE 1=1 AND UseableFlag=1 ";
            sql += " AND VendorID IN ( SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(SELECT ID FROM Enum_VendorType WHERE BaseType=" + p_BaseType + " AND ISNULL(DelFlag,0)=0))";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "VendorAttn", "VendorID", p_ShowBlank);

        }

        /// <summary>
        /// ��ÿͻ�����
        /// </summary>
        /// <param name="p_CLSA">����</param>
        /// <param name="p_CLSB">С��</param>
        /// <returns></returns>
        private static int[] BindVendorGetVendorType(string p_CLSA, string p_CLSB)
        {
            string sql = "SELECT VendorTypeID FROM Data_VendorTypeForm WHERE CLSA=" + SysString.ToDBString(p_CLSA) + " AND CLSB=" + SysString.ToDBString(p_CLSB);
            DataTable dt = SysUtils.Fill(sql);
            int[] outint = new int[dt.Rows.Count];
            for (int i = 0; i < outint.Length; i++)
            {
                outint[i] = SysConvert.ToInt32(dt.Rows[i][0]);
            }
            return outint;
        }
        #endregion

        #region �󶨲���

        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDepartment(LookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "Code", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT Code,Name FROM Enum_Department WHERE 1=1 ";
            if (p_Type != 0)
            {
                sql += " AND ISNULL(DepartmentType,0) = " + p_Type;
            }
            sql += " ORDER BY Code ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }

        public static void BindVendorBaseType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Enum_VendorTypeBase WHERE 1=1 ";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        /// <param name="p_ShowTY">�Ƿ���ʾͣ��</param>
        public static void BindDepartment(LookUpEdit p_DrpID, bool p_ShowBlank, bool p_ShowTY, bool p_ShowCJ)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "Code", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT Code,Name FROM Enum_Department WHERE 1=1 ";
            if (p_ShowTY == false)
            {
                sql += " AND ISNULL(ValidType,0) = 0";
            }
            if (p_ShowCJ == true)
            {
                sql += " AND ISNULL(SCFlag,0) = 1";
            }
            sql += " ORDER BY Code ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDepartment(RepositoryItemLookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "Code", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT Code,Name FROM Enum_Department WHERE 1=1 ";
            if (p_Type != 0)
            {
                sql += " AND ISNULL(DepartmentType,0) = " + p_Type;
            }
            sql += " ORDER BY Code ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDepartment(LookUpEdit p_DrpID, bool p_ShowBlank, bool p_ShowCJ)
        {
            BindDepartment(p_DrpID, p_ShowBlank, false, p_ShowCJ);
        }



        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        /// <param name="p_ShowTY">�Ƿ���ʾͣ��</param>
        public static void BindDepartment(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank, bool p_ShowTY, bool p_ShowCJ)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "Code", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT Code,Name FROM Enum_Department WHERE 1=1";
            if (p_ShowTY == false)
            {
                sql += " AND ISNULL(ValidType,0) = 0";
            }
            if (p_ShowCJ == true)
            {
                sql += " AND ISNULL(SCFlag,0) = 1";
            }
            sql += " ORDER BY Code ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDepartment(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank, bool p_ShowCJ)
        {
            BindDepartment(p_DrpID, p_ShowBlank, false, p_ShowCJ);
        }
        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDepartment(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindDepartment(p_DrpID, p_ShowBlank, false, false);
        }
        public static string GetDepartmentName(string p_code)
        {
            string name = "";
            string sql = "SELECT * FROM Enum_Department ";
            sql += " WHERE Code=" + SysString.ToDBString(p_code);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["Name"].ToString();
            }
            return name;
        }
        #endregion

        #region �󶨸�λ

        /// <summary>
        /// �󶨸�λ
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDep(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Enum_Dep";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨸�λ
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDep(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Enum_Dep";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        #endregion

        #region ��ɴ�����͡���̬
        /// <summary>
        /// ��ɴ������
        /// </summary>
        public static void BindYarnType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_YarnType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ɴ������
        /// </summary>
        public static void BindYarnType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 60 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_YarnType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        #endregion

        #region �����

        /// <summary>
        /// ��ѡ������ö��
        /// </summary>
        public static void BindCLSList(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[4] { 0, 75, 75, 100 }, new string[4] { "ID", "CLSA", "CLSB", "CLSDESC" }, new string[4] { "", "", "", "" }, new bool[4] { false, false, false, true });
            string sql = "SELECT ID,CLSA,CLSB,CLSDESC FROM Data_CLSList";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "CLSDESC", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��CLS
        /// </summary>
        public static void BindCLS(ComboBoxEdit p_DrpID, string p_TableName, string p_FieldName, bool p_AllowEdit, bool p_ShowBlank)
        {
            if (p_AllowEdit)
            {
                p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                p_DrpID.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }


            FCommon.LoadDropComb(p_DrpID, BindCLSDataSource(p_TableName, p_FieldName), "CLSNM", p_ShowBlank);


            if (BindCLSDataSource(p_TableName, p_FieldName).Rows.Count == 1)//���ֻ��һ������
            {
                p_DrpID.EditValue = SysConvert.ToString(BindCLSDataSource(p_TableName, p_FieldName).Rows[0]["CLSNM"]);
            }
        }
        /// <summary>
        /// ��CLS
        /// </summary>
        public static void BindCLS(ComboBoxEdit p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, p_TableName, p_FieldName, true, p_ShowBlank);
        }
        /// <summary>
        /// ��CLS
        /// </summary>
        public static void BindCLS(RepositoryItemComboBox p_DrpID, string p_TableName, string p_FieldName, bool p_AllowEdit, bool p_ShowBlank)
        {
            if (p_AllowEdit)
            {
                p_DrpID.TextEditStyle = TextEditStyles.Standard;
            }
            else
            {
                p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            }
            FCommon.LoadDropRepositoryComb(p_DrpID, BindCLSDataSource(p_TableName, p_FieldName), "CLSNM", p_ShowBlank);

        }
        /// <summary>
        /// ��CLS
        /// </summary>
        public static void BindCLS(RepositoryItemComboBox p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, p_TableName, p_FieldName, true, p_ShowBlank);
        }



        /// <summary>
        /// ��CLS
        /// </summary>
        private static DataTable BindCLSDataSource(string p_TableName, string p_FieldName)
        {
            //string sql = string.Empty;
            //sql = "SELECT ID,CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT CLSListID FROM Data_CLSForm  WHERE 1=1";
            //sql += " AND CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName) + ")";
            //sql += " AND ISNULL(DelFlag,0)=0";
            //sql += " ORDER BY CLSIDC,CLSNM";
            //return SysUtils.Fill(sql);

            string sql = string.Empty;
            sql = "SELECT ID,CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT ID FROM Data_CLSList  WHERE 1=1";
            sql += " AND CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName) + ")";
            sql += " AND ISNULL(DelFlag,0)=0";
            sql += " ORDER BY CLSIDC,CLSNM";
            return SysUtils.Fill(sql);
        }


        /// <summary>
        /// ��CLS
        /// </summary>
        public static void BindCLS(CheckedListBoxControl p_CHK, string p_TableName, string p_FieldName)
        {
            string sql = string.Empty;
            sql = "SELECT CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT CLSListID FROM Data_CLSForm WHERE 1=1 ";
            sql += " AND CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName) + ")";
            sql += " ORDER BY CLSIDC,CLSNM";

            p_CHK.DataSource = SysUtils.Fill(sql);
            p_CHK.DisplayMember = "CLSNM";
            p_CHK.ValueMember = "CLSNM";
            p_CHK.Show();

        }


        /// <summary>
        /// ��ɫ��״̬
        /// </summary>
        public static void BindColorCardStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 60 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ColorCardStatus WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// ��ɫ�����
        /// </summary>
        public static void BindColorCode(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 60 }, new string[2] { "ItemCode", "ItemName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT ItemCode,ItemName FROM Data_Item WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "ItemName", "ItemCode", p_ShowBlank);
        }
        /// <summary>
        /// �󶨼�����λ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindUnit(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindRepositoryItemLookUpEdit(p_DrpID, "Enum_Unit", "NameEN", "Code", p_ShowBlank);
        }
        #endregion

        #region ��������

        /// <summary>
        /// ��������
        /// </summary>
        public static void BindDZType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Enum_DZType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        #endregion

        #region �󶨳���������ɫ��
        /// <summary>
        /// �󶨳�������
        /// </summary>
        public static void BindSizeNum(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindSizeNum(p_DrpID, "", p_ShowBlank);
        }
        /// <summary>
        /// �󶨳�������
        /// </summary>
        public static void BindSizeNum(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindSizeNum(p_DrpID, "", p_ShowBlank);
        }

        /// <summary>
        /// �󶨳�������
        /// </summary>
        public static void BindSizeNum(LookUpEdit p_DrpID, string p_Type, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SizeNum WHERE 1=1 ";
            if (p_Type != "")
            {
                sql += " AND " + p_Type + "=1";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨳�������
        /// </summary>
        public static void BindSizeNum(RepositoryItemLookUpEdit p_DrpID, string p_Type, bool p_ShowBlank)
        {
            //   FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            p_DrpID.ShowFooter = false;
            p_DrpID.ShowHeader = false;
            string sql = "SELECT ID,Name FROM Enum_SizeNum WHERE 1=1 ";
            if (p_Type != "")
            {
                sql += " AND " + p_Type + "=1";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲�Ʒ����
        /// </summary>
        /// <param name="p_Drp"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindItemCode(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ItemCode", "ItemName" }, new string[2] { "", "" }, new bool[2] { true, false });
            string sql = "SELECT ItemCode,ItemName FROM Data_Item WHERE 1=1 AND UseableFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ItemCode", "ItemName", p_ShowBlank);

        }
        /// <summary>
        /// �󶨳ɷ�
        /// </summary>
        /// <param name="p_Drp"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindItemName(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ItemCode", "ItemName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ItemCode,ItemName FROM Data_Item WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ItemName", "ItemCode", p_ShowBlank);

        }
        #endregion

        #region �󶨲�������


        /// <summary>
        ///  �󶨲�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindParamSetType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 30, 100 }, new string[] { "ID", "Name" }, new string[] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ParamSetType ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        #endregion

        #region �ֿ����

        /// <summary>
        /// �󶨳��������---Enum_WHQtyPos
        /// </summary>
        public static void BindWHQtyPos(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "ColorCaption" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,ColorCaption FROM Enum_WHQtyPos WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ColorCaption", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿⵥ������---Enum_WHFormType
        /// </summary>
        public static void BindWHFormType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHFormType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        /// <param name="p_Drp"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWHIDRight(RadioGroup p_Rad, int p_WHType, bool p_ShowBlank)
        {
            DataTable dt = GetRightWHList(p_WHType);
            p_Rad.Properties.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                p_Rad.Properties.Items.Add(new RadioGroupItem(dr["ID"].ToString(), dr["WHNM"].ToString()));
            }
        }

        /// <summary>
        /// �󶨲ֿⵥ��������̬---Enum_WHSpecialType
        /// </summary>
        public static void BindWHSpecialType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHSpecialType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ��������--- Enum_WHCaiWuType
        /// </summary>
        public static void BindWHCaiWuType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHCaiWuType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲ֿ�Ķ�������--- Enum_WHDZType
        /// </summary>
        public static void BindWHDZType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHDZType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }




        /// <summary>
        /// �󶨲ֿⵥ��������̬---Enum_FormNoControl
        /// </summary>
        public static void BindFormNoControlID(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 200 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormNoControl WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        /// <param name="p_Drp"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWHRight(RadioGroup p_Rad, int p_WHType, bool p_ShowBlank)
        {
            DataTable dt = GetRightWHList(p_WHType);
            p_Rad.Properties.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                p_Rad.Properties.Items.Add(new RadioGroupItem(dr["WHID"].ToString(), dr["WHNM"].ToString()));
            }
        }

        #endregion

        #region ��ȡֵ����

        /// <summary>
        /// ��Ⱦ�����㷽ʽ
        /// </summary>
        public static void BindSetmentType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SettlementType ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// ����Ա����Ż��Ա������
        /// </summary>
        /// <param name="p_OPID">Ա�����</param>
        /// <returns>Ա������</returns>
        public static string GetNameByOPID(string p_OPID)
        {
            string outstr = p_OPID;
            string sql = "SELECT OPName FROM Data_OP WHERE OPID=" + SysString.ToDBString(p_OPID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
            }
            return outstr;
        }
        /// <summary>
        /// ���ݱ��ֵõ�����
        /// </summary>
        /// <returns></returns>
        public static decimal GetRateByCurrencyID(int p_CurrencyID)
        {
            decimal outstr = 1;//����Ĭ����1
            string sql = "SELECT Rate FROM Data_Currency WHERE ID = " + p_CurrencyID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToDecimal(dt.Rows[0]["Rate"]);
            }
            return outstr;
        }
        /// <summary>
        /// ���ݲֿⵥ�������ͻ����Ʒ����
        /// </summary>
        /// <param name="p_HeadType">�ֿⵥ��������</param>
        /// <returns>��Ʒ����</returns>
        public static int[] GetItemTypeByFormListID(int p_FormListID)
        {
            int[] outint = new int[] { 0 };
            string sql = "SELECT ItemTypeID FROM Enum_WHType WHERE ID IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outint = new int[] { SysConvert.ToInt32(dt.Rows[0][0].ToString()) };
            }
            return outint;
        }

        #endregion

        #region ͨ�����ݰ�
        /// <summary>
        /// �����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_PreNum">��ǰ��</param>
        /// <param name="p_NextNum">������</param>
        /// <param name="p_ShowBlank"></param>
        public static void BindYear(ComboBoxEdit p_DrpID, int p_PreNum, int p_NextNum, bool p_ShowBlank)
        {
            ArrayList al = new ArrayList();
            int thisYear = DateTime.Now.Year;
            for (int i = thisYear + p_NextNum; i > thisYear - p_PreNum; i--)
            {
                al.Add(i.ToString());
            }
            FCommon.LoadDropComb(p_DrpID, al, p_ShowBlank);
        }


        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="iLength"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWTNum(ComboBoxEdit p_DrpID, int iLength, bool p_ShowBlank)
        {
            ArrayList al = new ArrayList();
            for (int i = 1; i <= iLength; i++)
            {
                al.Add(i.ToString());
            }
            FCommon.LoadDropComb(p_DrpID, al, p_ShowBlank);
        }


        /// <summary>
        /// ��ͼƬ����
        /// </summary>
        public static void BindUploadPicProp(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 30, 100, 100, 100 }, new string[] { "ID", "Name", "PicWidth", "PicHeight" }, new string[] { "���", "����", "ͼƬ���", "ͼƬ�߶�" });
            string sql = "SELECT ID,Name,PicWidth,PicHeight FROM Enum_UploadPicProp ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���ϴ��ļ�����
        /// </summary>
        public static void BindUploadFileType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 30, 100, 100, 100 }, new string[] { "ID", "Name", "CLSA", "CLSB" }, new string[] { "���", "����", "����", "С��" });
            string sql = "SELECT ID,Name,CLSA,CLSB FROM Enum_UploadFileType ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static string GetLetterByNumber(int p_Num)
        {
            string outstr = "A";
            switch (p_Num)
            {
                case 1:
                    outstr = "A";
                    break;
                case 2:
                    outstr = "B";
                    break;
                case 3:
                    outstr = "C";
                    break;
                case 4:
                    outstr = "D";
                    break;
                case 5:
                    outstr = "E";
                    break;
                case 6:
                    outstr = "F";
                    break;
                case 7:
                    outstr = "G";
                    break;
                case 8:
                    outstr = "H";
                    break;
                case 9:
                    outstr = "I";
                    break;
                case 10:
                    outstr = "J";
                    break;
                case 11:
                    outstr = "K";
                    break;
                case 12:
                    outstr = "L";
                    break;
                case 13:
                    outstr = "M";
                    break;
                case 14:
                    outstr = "N";
                    break;
                case 15:
                    outstr = "O";
                    break;
                case 16:
                    outstr = "P";
                    break;
                case 17:
                    outstr = "Q";
                    break;
                case 18:
                    outstr = "R";
                    break;
                case 19:
                    outstr = "S";
                    break;
                case 20:
                    outstr = "T";
                    break;
            }
            return outstr;
        }
        #endregion

        #region ��������

        /// <summary>
        /// ��ȡӪҵ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static bool IsSaleOPID(int p_ID, string p_Field, string p_Table)
        {
            string SaleOPID = "";
            string sql = "";
            sql = " SELECT " + p_Field + " FROM " + p_Table + " WHERE ID = " + p_ID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                SaleOPID = dt.Rows[0][p_Field].ToString();
            }
            if (SaleOPID == "" || SaleOPID == FParamConfig.LoginID)
            {
                return true;
            }
            return false;

        }



        /// <summary>
        ///����Ա��������
        /// </summary>
        /// <param name="sOPIP">Ա������</param>
        /// <returns></returns>
        public static string OPIDToDepartment(string sOPIP)
        {
            string sDepartment = "";
            try
            {
                string sql = "SELECT Department FROM Data_OP WHERE OPID=" + SysString.ToDBString(sOPIP.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    sDepartment = dt.Rows[0]["Department"].ToString();
                }
            }
            catch
            {

            }
            return sDepartment;
        }




        #endregion


        #region  ��������
        /// <summary>
        /// ����֯�ṹ
        /// </summary>
        public static void BindStructure(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Data_Structure";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ����֯�ṹ
        /// </summary>
        public static void BindOPStructure(LookUpEdit p_DrpID, int p_DepID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT OPID,OPName FROM UV1_Data_OPDep WHERE DepID=" + p_DepID;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }

        /// <summary>
        /// ���ϼ�����
        /// </summary>
        public static void BindSJDepartment(RepositoryItemLookUpEdit p_DrpID, string p_StrWhere, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "DepartmentID", "DepartmentName" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT DepartmentID,DepartmentName FROM Enum_ZZGXDts";
            sql += " WHERE 1=1";
            sql += p_StrWhere;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "DepartmentName", "DepartmentID", p_ShowBlank);
        }

        /// <summary>
        /// ���ϼ�����
        /// </summary>
        public static void BindSJDepartment(ComboBoxEdit p_DrpID, string p_StrWhere, bool p_ShowBlank)
        {
            string sql = "SELECT DepartmentID,DepartmentName,DepartmentID+'|'+(DepartmentName) Name FROM Enum_ZZGXDts";
            sql += " WHERE 1=1";
            sql += p_StrWhere;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        }

        /// <summary>
        /// ���ϼ�����
        /// </summary>
        public static void BindSJDepartment(RepositoryItemComboBox p_DrpID, string p_StrWhere, bool p_ShowBlank)
        {
            string sql = "SELECT DepartmentID,DepartmentName,DepartmentID+'|'+(DepartmentName) Name FROM Enum_ZZGXDts";
            sql += " WHERE 1=1";
            sql += p_StrWhere;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Name", p_ShowBlank);
        }


        /// <summary>
        /// ���ݿͻ������ÿͻ���ϵ��
        /// </summary>
        public static string GetVendorContactByVenorID(string p_VendorID)
        {
            string outstr = p_VendorID;
            string sql = "SELECT Contact FROM Data_Vendor WHERE VendorID = " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }

        /// <summary>
        /// ���ݿͻ������ÿͻ��绰
        /// </summary>
        public static string GetVendorTelByVenorID(string p_VendorID)
        {
            string outstr = p_VendorID;
            string sql = "SELECT Tel FROM Data_Vendor WHERE VendorID = " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }

        /// <summary>
        /// ���ݿͻ������ÿͻ��绰
        /// </summary>
        public static string GetVendorFaxByVenorID(string p_VendorID)
        {
            string outstr = p_VendorID;
            string sql = "SELECT Fax FROM Data_Vendor WHERE VendorID = " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }

        /// <summary>
        /// ���ݿͻ������ÿͻ���ַ
        /// </summary>
        public static string GetVendorAddressByVenorID(string p_VendorID)
        {
            string outstr = p_VendorID;
            string sql = "SELECT Address FROM Data_Vendor WHERE VendorID = " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }
        /// <summary>
        /// ���ݳ��ⵥ�Ż��Invoice����
        /// </summary>
        public static string GetInvoiceNoByCode(int p_Code)
        {
            string outstr = "";
            string sql = "SELECT DtsSO FROM WH_IOFormDts WHERE IOFormID = " + p_Code;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                sql = "SELECT InvoiceNo FROM Sale_Shipment WHERE SOID = " + SysString.ToDBString(SysConvert.ToString(dt.Rows[0][0]));
                DataTable dt1 = SysUtils.Fill(sql);
                if (dt1.Rows.Count != 0)
                {
                    outstr = SysConvert.ToString(dt1.Rows[0][0]);
                }
            }
            return outstr;
        }
        /// <summary>
        /// ����Ա����ŵõ�Ա������
        /// </summary>
        public static string GetOPName(string p_OPID)
        {

            string sql = "SELECT OPName FROM Data_OP WHERE OPID = " + SysString.ToDBString(p_OPID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return "";
        }
        #endregion

        #region Ӫҵ


        /// <summary>
        /// ��ɴ������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindSYStutas(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Status" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Status FROM Enum_SYStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Status", "ID", p_ShowBlank);
        }
        /// <summary>
        /// ��ɴ������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindSYStutas(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Status" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Status FROM Enum_SYStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Status", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��û��ұ�־
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetCSymbol(int p_ID)
        {
            string Symble = "";
            string sql = " SELECT Symbol FROM Data_Currency WHERE ID = " + p_ID.ToString();
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                Symble = dt.Rows[0]["Symbol"].ToString();
            }
            return Symble;
        }
        /// <summary>
        /// ��û���
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetCRate(int p_ID)
        {
            string Rate = "";
            string sql = " SELECT Rate FROM Data_Currency WHERE ID = " + p_ID.ToString();
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                Rate = dt.Rows[0]["Rate"].ToString();
            }
            return Rate;
        }

        /// <summary>
        /// ��û�������
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetCName(int p_ID)
        {
            string CName = "";
            string sql = " SELECT CName FROM Data_Currency WHERE ID = " + p_ID.ToString();
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                CName = dt.Rows[0]["CName"].ToString();
            }
            return CName;
        }

        /// <summary>
        /// ��û�������
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetCNameEN(int p_ID)
        {
            string CNameEN = "";
            string sql = " SELECT Name FROM Data_Currency WHERE ID = " + p_ID.ToString();
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                CNameEN = dt.Rows[0]["Name"].ToString();
            }
            return CNameEN;
        }

        /// <summary>
        /// �õ���������
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetPayTypeName(int p_ID)
        {
            string PayTypeName = "";
            string sql = " SELECT Name FROM Enum_VendorPayment WHERE ID = " + p_ID.ToString();
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                PayTypeName = dt.Rows[0]["Name"].ToString();
            }
            return PayTypeName;
        }
        /// <summary>
        /// �󶨱�֯��ʽ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindBZMethord(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_BZMethord ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// ����ɫ����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindPSType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_PSType ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        #endregion

        #region �ֿ�
        /// <summary>
        /// �󶨲ֿ�������
        /// </summary>
        public static void BindWHPicID(ComboBoxEdit p_DrpID, string p_WHID, bool p_ShowBlank)
        {
            //string sql = "SELECT WHID,WHPicID FROM WH_WHPic WHERE 1=1 ";
            //sql += " AND WHID=" + SysString.ToDBString(p_WHID);
            //DataTable dt = SysUtils.Fill(sql);
            //FCommon.LoadDropComb(p_DrpID, dt, "WHPicID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨱���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWHStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ��Ա�� �����������
        /// </summary>
        public static void BindOP(LookUpEdit p_DrpID, int[] p_OPDep, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });

            FCommon.LoadDropLookUP(p_DrpID, BindOPDataSource(p_OPDep), "OPName", "OPID", p_ShowBlank);
            p_DrpID.Tag = p_OPDep;
            //new LookUpClear(p_DrpID);
        }

        /// <summary>
        /// ��ð�Ա������Դ
        /// </summary>
        /// <param name="p_VendorType"></param>
        /// <returns></returns>
        private static DataTable BindOPDataSource(int[] p_OPDep)
        {
            string p_Str = string.Empty;
            p_Str += "0";
            for (int i = 0; i < p_OPDep.Length; i++)
            {
                if (p_Str != string.Empty)
                {
                    p_Str += ",";
                }
                p_Str += p_OPDep[i].ToString();
            }
            if (p_Str == string.Empty)
            {
                p_Str = "0";
            }
            string sql = "SELECT Distinct OPID,OPName FROM UV1_Data_OPDep WHERE 1=1 AND UseableFlag=1 ";
            sql += " AND DepID IN (" + p_Str + ")";
            return SysUtils.Fill(sql);
        }

        #endregion

        #region ����
        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindRecType(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_RecType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        }
        /// <summary>
        /// �󶨱ұ�
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindCurrency(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Data_Currency WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        }

        /// <summary>
        /// �󶨱ұ�
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindCurrency(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            string sql = "SELECT ID,Name FROM Data_Currency WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropItemComb(p_DrpID, dt, "Name", p_ShowBlank);

        }

        #endregion

        #region �ֿ⴦��

        /// <summary>
        /// ��ɴ��������״
        /// </summary>
        public static void BindWHQualityFlag(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHQuality WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ɴ��������ë
        /// </summary>
        public static void BindWHQualityFFlag(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FName Name FROM Enum_WHQuality WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲ֿ�����
        /// </summary>
        public static void BindWHType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WHType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨵�������
        /// </summary>
        public static void BindHeadType(LookUpEdit p_DrpID, int p_ParnetID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND ParentID=" + SysString.ToDBString(p_ParnetID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        public static void BindSubType(LookUpEdit p_DrpID, int p_ParnetID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";

            sql += " AND ParentID=" + SysString.ToDBString(p_ParnetID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        public static void BindWHSubType(LookUpEdit p_DrpID, string p_WHID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";

            sql += " AND WHTypeID=" + SysConvert.ToInt32(SysUtils.Fill("SELECT ID FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID)).Rows[0][0]);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶��˳��������
        /// </summary>
        public static void BindDZSubType(LookUpEdit p_DrpID, int p_DZTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND ISNULL(DZType,0)=" + SysString.ToDBString(p_DZTypeID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }
        /// <summary>
        /// ���������(�������ڳ���ⴰ������)
        /// </summary>
        /// <param name="p_DrpID">Ҫ�󶨵Ŀؼ�</param>
        /// <param name="p_ParnetID">����������</param>
        /// <param name="p_WHTypeID">�ֿ�����</param>
        /// <param name="p_ShowBlank"></param>
        public static void BindSubType(LookUpEdit p_DrpID, int p_ParnetID, int p_WHTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND ParentID=" + SysString.ToDBString(p_ParnetID);
            if (p_ParnetID == 9)    //�ڳ�����
            {
                sql += " AND WHTypeID=" + SysString.ToDBString(p_WHTypeID);
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        public static void BindSubType(LookUpEdit p_DrpID, int[] p_ParnetID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            string IDStr = string.Empty;
            for (int i = 0; i < p_ParnetID.Length; i++)
            {
                if (IDStr != "")
                {
                    IDStr += ",";
                }
                IDStr += p_ParnetID[i].ToString();
            }
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND ParentID IN(" + IDStr + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        public static void BindSubType(CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.DataSource = dt;
            p_DrpID.DisplayMember = "SubTypeNM";
            p_DrpID.ValueMember = "SubTypeID";
            p_DrpID.Show();
        }

        /// <summary>
        /// ���������
        /// </summary>
        public static void BindSubType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }



        /// <summary>
        /// �󶨻�����������
        /// </summary>
        public static void BindFillDataType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 250 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name+'--'+Remark Name FROM Enum_FillDataType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }






        #endregion

        #region �󶨿ͻ����
        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindVendorSaleOPID(ComboBoxEdit p_DrpID, string p_VendorID, bool p_ShowBlank)
        {
            string sql = " SELECT * FROM UV1_Data_VendorContract WHERE VendorID=" + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Contract", p_ShowBlank);
        }


        ///// <summary>
        ///// ��ð󶨿ͻ�����Դ(
        ///// </summary>
        ///// <param name="p_VendorType"></param>
        ///// <returns></returns>
        //private static DataTable BindVendorDataSource(int[] p_VendorType)
        //{
        //    return BindVendorDataSource(p_VendorType, "");
        //}
        /// <summary>
        /// ��ð󶨿ͻ�����Դ
        /// </summary>
        /// <param name="p_VendorType"></param>
        /// <returns></returns>
        private static DataTable BindVendorDataSource(int[] p_VendorType)
        {

            return BindVendorDataSource(p_VendorType, "");
        }

        /// <summary>
        /// ��ð󶨿ͻ�����Դ
        /// </summary>
        /// <param name="p_VendorType"></param>
        /// <returns></returns>
        private static DataTable BindVendorDataSource(int[] p_VendorType, string p_Condition)
        {
            string p_Str = string.Empty;
            p_Str += "0";
            for (int i = 0; i < p_VendorType.Length; i++)
            {
                if (SysConvert.ToInt32(p_VendorType[i]) != 0)
                {
                    if (p_Str != string.Empty)
                    {
                        p_Str += ",";
                    }
                    p_Str += p_VendorType[i].ToString();
                }
            }
            if (p_Str == string.Empty)
            {
                p_Str = "99";
            }
            string sql = "SELECT VendorID,VendorAttn,VendorName VendorAll FROM Data_Vendor WHERE 1=1 AND UseableFlag=1 ";
            sql += " AND VendorTypeID IN (" + p_Str + ")";

            if (p_Condition != string.Empty)
            {
                sql += p_Condition;
            }
            sql += " ORDER BY VendorID ";
            return SysUtils.Fill(sql);
        }
       
        #endregion

        #region ��������

        /// <summary>
        /// �󶨹�˾��
        /// </summary>
        public static void BindItemCode(LookUpEdit p_DrpID, string strWhere, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100, 70, 200, 0 }, new string[] { "ItemCode", "ItemStd", "ItemName", "ItemCode" }, new string[] { "��Ʒ����", "��Ʒ���", "��Ʒ����", "��Ʒ����" }, new bool[] { true, true, true, false });
            string sql = "SELECT ItemCode+' '+ItemName+' '+ItemStd Item,ItemCode,ItemName,ItemStd FROM Pro_SampleDependItemDts  WHERE 1=1";
            sql += strWhere;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Item", "ItemCode", p_ShowBlank);
        }


        /// <summary>
        /// �󶨵��ſ��Ʊ�
        /// </summary>
        public static void BindFormNoControl(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" });
            string sql = "SELECT ID,FormNm Name FROM Enum_FormNoControl ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ϵͳ����
        /// </summary>
        public static void BindSystemType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "ϵͳ���", "ϵͳ����" });
            string sql = "SELECT ID,Name FROM Enum_SystemType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }




        /// <summary>
        /// ��ɫ��״̬
        /// </summary>
        public static void BindColorCardStatus(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 60 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ColorCardStatus WHERE 1=1  ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ְλ
        /// </summary>
        public static void BindDuty(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_Duty WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ְλ
        /// </summary>
        public static void BindDuty(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            //			FCommon.LookupEditColAdd(p_DrpID,new int[2]{50,100},new string[2]{"ID","Name"},new string[2]{"",""},new bool[2]{false,true});
            string sql = "SELECT ID,Name FROM Data_Duty WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨸�����������
        /// </summary>
        public static void BindPayApplyType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_PayApplyType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨸�������
        /// </summary>
        public static void BindPayType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_PayType WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���տ�����
        /// </summary>
        public static void BindRecType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_RecType WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨺�ͬ����
        /// </summary>
        public static void BindVendorCompactType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_VendorCompactType WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ί�мӹ���������
        /// </summary>
        public static void BindColorPayType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ColorPayType WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ҵ�����
        /// </summary>
        public static void BindSaleGroup(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SaleGroup WHERE 1=1 AND ISNULL(DelFlag,0)=0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ��ҵ�����
        /// </summary>
        public static void BindSaleGroup(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT Name FROM Enum_SaleGroup WHERE 1=1 AND ISNULL(DelFlag,0)=0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        }

        /// <summary>
        /// ��ҵ�����
        /// </summary>
        public static void BindSaleGroup(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT Name FROM Enum_SaleGroup WHERE 1=1 AND ISNULL(DelFlag,0)=0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Name", p_ShowBlank);
        }


        /// <summary>
        /// ��ҵ�����(�����Լ���ҵ�����
        /// </summary>
        public static void BindSaleGroupOPID(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SaleGroup WHERE 1=1 ";
            if (!FParamConfig.LoginHTFlag)
            {
                sql += " AND ID IN(SELECT GroupID FROM Data_OPGroup WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID) + ")";
            }
            sql += " ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨴��/��ɴ
        /// </summary>
        public static void BindGoodsType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_GoodsType WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨴��/��ɴ
        /// </summary>
        public static void BindGoodsType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_GoodsType WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨴��/��ɴ
        /// </summary>
        public static void BindGoodsTypeByOPName(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = string.Empty;
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            if (ParamConfig.LoginID != "Y006" && ParamConfig.LoginID != "Y003")
            {
                sql = "SELECT ID,Name FROM Enum_GoodsType WHERE 1=1 ORDER BY ID";
            }
            else
            {
                sql = "SELECT ID,Name FROM Enum_GoodsType WHERE 1=1 AND BuyOPName=" + SysString.ToDBString(ParamConfig.LoginName) + " ORDER BY ID";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨶�����ʽ
        /// </summary>
        public static void BindSoMethod(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SoMethod WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ɴ������
        /// </summary>
        public static void BindYarnFormType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_YarnFormType WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindGoodsType(CheckedListBoxControl p_ChkList)
        {
            string sql = "SELECT ID,Name FROM Enum_GoodsType WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            p_ChkList.DataSource = dt;
            p_ChkList.DisplayMember = "Name";
            p_ChkList.ValueMember = "ID";
            p_ChkList.Show();
        }


        /// <summary>
        /// �󶨶�����������
        /// </summary>
        public static void BindSOCalType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SOCalType WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨱���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindCurrency(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "CName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,CName FROM Data_Currency WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "CName", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindCancelType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_CancelType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨼ӹ���ͬ����
        /// </summary>
        public static void BindColorCompactType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ColorCompactType WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }



        /// <summary>
        /// �󶨶����ӹ�����
        /// </summary>
        public static void BindSOProType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SOProType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���������õ�����
        /// </summary>
        public static void BindApplyUseType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ApplyUseType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶�������
        /// </summary>
        public static void BindSODep(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SODep WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        public static void BindInwhType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_InwhType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲�����ˮ��������/֧
        /// </summary>
        public static void BindInOutType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_InOutType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶�������������
        /// </summary>
        public static void BindSOVendorType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SOVendorType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨶�������ģʽ
        /// </summary>
        public static void BindSOInputType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SOInputType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        #endregion

        #region  Ӫҵ����
        /// <summary>
        /// ��Ӫҵ����
        /// </summary>
        public static void BindItemType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ItemType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static void BindItemType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ItemType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��Ӫҵ����
        /// </summary>
        public static void BindItemType(LookUpEdit p_DrpID, int p_ItemType, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ItemType WHERE ID=" + p_ItemType.ToString();
            //sql += " WHERE ID=" + p_ItemType.ToString();
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ����Ʒ����
        /// </summary>
        public static void BindItemClass(LookUpEdit p_DrpID, int p_ItemType, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_ItemClass";
            sql += " WHERE ItemTypeID=" + p_ItemType.ToString();
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }



        #region ������
        /// <summary>
        /// ��Ӫҵ����
        /// </summary>
        public static void BindOItemCode(LookUpEdit p_DrpID, int p_IOFormID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[1] { 100 }, new string[1] { "ItemCode" }, new string[1] { "" }, new bool[1] { true });
            string sql = "SELECT ItemCode FROM WH_IOFormDts WHERE IOFormID=" + SysString.ToDBString(p_IOFormID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ItemCode", "ItemCode", p_ShowBlank);
        }

        /// <summary>
        /// ��Ӫҵ����
        /// </summary>
        public static void BindOItemName(LookUpEdit p_DrpID, int p_IOFormID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[1] { 100 }, new string[1] { "ItemName" }, new string[1] { "" }, new bool[1] { true });
            string sql = "SELECT ItemName FROM WH_IOFormDts WHERE IOFormID=" + SysString.ToDBString(p_IOFormID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ItemName", "ItemName", p_ShowBlank);
        }

        /// <summary>
        /// ��Ӫҵ���
        /// </summary>
        public static void BindOItemStd(LookUpEdit p_DrpID, int p_IOFormID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[1] { 100 }, new string[1] { "ItemStd" }, new string[1] { "" }, new bool[1] { true });
            string sql = "SELECT ItemStd FROM WH_IOFormDts WHERE IOFormID=" + SysString.ToDBString(p_IOFormID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ItemStd", "ItemStd", p_ShowBlank);
        }

        #endregion



        /// <summary>
        /// �󶨳������ϸ
        /// </summary>
        public static void BindIOFormDts(LookUpEdit p_DrpID, int p_IOFormID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[10] { 0, 80, 200, 80, 50, 50, 80, 100, 50, 30 }, new string[10] { "Seq", "ItemCode", "ItemName", "ItemStd", "Qty", "VendorBatch", "ColorNum", "JarNum", "RecQty", "RecFlag" }, new string[10] { "Seq", "����", "����", "���", "����", "����", "ɫ��", "�׺�", "������", "��־" }, new bool[10] { false, true, true, true, true, true, true, true, true, true });
            string sql = "SELECT Seq,ItemCode,ItemCode+' '+ItemName+' '+ItemStd ItemName,ItemStd,Batch,VendorBatch,ColorNum,JarNum,Qty,RecQty,RecFlag FROM WH_IOFormDts WHERE IOFormID=" + SysString.ToDBString(p_IOFormID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ItemName", "Seq", p_ShowBlank);
            if (dt.Rows.Count != 0)
            {
                p_DrpID.EditValue = dt.Rows[0]["Seq"];
            }
        }

        /// <summary>
        /// �󶨶���״̬
        /// </summary>
        public static void BindSOStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 85 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SOStatus ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶���״̬
        /// </summary>
        public static void BindSOStatus(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 85 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SOStatus ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨷�Ʊ����
        /// </summary>
        public static void BindInvoiceType(LookUpEdit p_DrpID, int p_ParentID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 85 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_InvoiceType WHERE 1=1";
            sql += " AND ParentID=" + SysString.ToDBString(p_ParentID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ����ɴ���뵥
        /// </summary>
        public static void BindYarnApply(RepositoryItemLookUpEdit p_DrpID, int p_YarnCompactID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            //			FCommon.RepositoryLookupEditColAdd(p_DrpID,new int[8]{0,80,80,80},new string[8]{ID,"SOID","ApplyNo","ApplyDate"},new string[8]{"ID","������","���뵥��","��������"},new bool[8]{false,true,true,true});
            string sql = "SELECT ID,SOID,ApplyNo,ApplyDate FROM  Sale_YarnApply WHERE 1=1";
            sql += " AND ID IN (SELECT YarnApplyID FROM Sale_YarnCompactApplyDts WHERE YarnCompactID =" + p_YarnCompactID + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "SOID", "ID", p_ShowBlank);
        }
        #endregion

        #region �ͻ������

        /// <summary>
        /// �󶨿ͻ����ݶ�������
        /// </summary>
        public static void BindVendorByDZTypeID(LookUpEdit p_DrpID, int p_DZTypeID, bool p_ShowBlank)
        {
            string sql = "SELECT VendorTypeID1,VendorTypeID2,VendorTypeID3,VendorTypeID4,VendorTypeID5,VendorTypeID6,VendorTypeID7,VendorTypeID8 FROM Enum_DZType WHERE ID=" + p_DZTypeID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                ArrayList al = new ArrayList();
                for (int i = 1; i <= 8; i++)
                {
                    if (SysConvert.ToInt32(dt.Rows[0]["VendorTypeID" + i]) != 0)
                    {
                        al.Add(SysConvert.ToInt32(dt.Rows[0]["VendorTypeID" + i]));
                    }
                }
                int[] p_VendoType = new int[al.Count];
                for (int i = 0; i < al.Count; i++)
                {
                    p_VendoType[i] = SysConvert.ToInt32(al[i]);
                }
                BindVendor(p_DrpID, p_VendoType, p_ShowBlank);
            }
        }




        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(RepositoryItemLookUpEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 100, 200 }, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.LoadDropRepositoryLookUP(p_DrpID, BindVendorDataSource(p_VendorType), ParamConfig.BindVendorDisplayField, "VendorID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(RepositoryItemLookUpEdit p_DrpID, int p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, new int[] { p_VendorType }, p_ShowBlank);
        }
        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(ComboBoxEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LoadDropComb(p_DrpID, BindVendorDataSource(p_VendorType), "VendorID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�
        /// </summary>
        public static void BindVendorByFormListID(LookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorTypeByFormListID(p_SubTypeID), p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�
        /// </summary>
        public static void BindVendorByFormListID(RepositoryItemLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorTypeByFormListID(p_SubTypeID), p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�
        /// </summary>
        public static void BindVendorByFormListID(ComboBoxEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorTypeByFormListID(p_SubTypeID), p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�A
        /// </summary>
        public static void BindVendorAByFormListID(LookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorATypeByFormListID(p_SubTypeID), p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�A
        /// </summary>
        public static void BindVendorAByFormListID(RepositoryItemLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorATypeByFormListID(p_SubTypeID), p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�B
        /// </summary>
        public static void BindVendorBByFormListID(LookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorBTypeByFormListID(p_SubTypeID), p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�B
        /// </summary>
        public static void BindVendorBByFormListID(RepositoryItemLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorBTypeByFormListID(p_SubTypeID), p_ShowBlank);
        }

        /// <summary>
        /// ��ÿͻ������б���ݲֿⵥ������
        /// </summary>
        /// <param name="p_SubTypeID"></param>
        /// <returns></returns>
        public static int[] GetVendorTypeByFormListID(int p_SubTypeID)
        {
            int[] outint = new int[0];
            ArrayList al = new ArrayList();
            string sql = "SELECT VendorTypeID,VendorTypeID2,VendorTypeID3,VendorTypeID4,VendorTypeID5 FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
            DataTable dtTemp = SysUtils.Fill(sql);
            if (dtTemp.Rows.Count != 0)
            {
                al.Add(99);
                for (int i = 0; i < 5; i++)
                {
                    if (SysConvert.ToInt32(dtTemp.Rows[0][i]) != 0)
                    {
                        al.Add(SysConvert.ToInt32(dtTemp.Rows[0][i]));
                    }
                }
                outint = new int[al.Count];
                for (int i = 0; i < outint.Length; i++)
                {
                    outint[i] = SysConvert.ToInt32(al[i]);
                }
            }

            return outint;
        }


        /// <summary>
        /// ��ÿͻ������б���ݲֿⵥ������A
        /// </summary>
        /// <param name="p_SubTypeID"></param>
        /// <returns></returns>
        public static int[] GetVendorATypeByFormListID(int p_SubTypeID)
        {
            int[] outint = new int[0];
            ArrayList al = new ArrayList();
            string sql = "SELECT VendorATypeID,VendorATypeID2,VendorATypeID3 FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
            DataTable dtTemp = SysUtils.Fill(sql);
            if (dtTemp.Rows.Count != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (SysConvert.ToInt32(dtTemp.Rows[0][i]) != 0)
                    {
                        al.Add(SysConvert.ToInt32(dtTemp.Rows[0][i]));
                    }
                }
                outint = new int[al.Count];
                for (int i = 0; i < outint.Length; i++)
                {
                    outint[i] = SysConvert.ToInt32(al[i]);
                }
            }

            return outint;
        }

        /// <summary>
        /// ��ÿͻ������б���ݲֿⵥ������B
        /// </summary>
        /// <param name="p_SubTypeID"></param>
        /// <returns></returns>
        public static int[] GetVendorBTypeByFormListID(int p_SubTypeID)
        {
            int[] outint = new int[0];
            ArrayList al = new ArrayList();
            string sql = "SELECT VendorBTypeID,VendorBTypeID2,VendorBTypeID3 FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
            DataTable dtTemp = SysUtils.Fill(sql);
            if (dtTemp.Rows.Count != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (SysConvert.ToInt32(dtTemp.Rows[0][i]) != 0)
                    {
                        al.Add(SysConvert.ToInt32(dtTemp.Rows[0][i]));
                    }
                }
                outint = new int[al.Count];
                for (int i = 0; i < outint.Length; i++)
                {
                    outint[i] = SysConvert.ToInt32(al[i]);
                }
            }

            return outint;
        }



        ///// <summary>
        ///// �󶨲ֿⵥ�����Ϳͻ�
        ///// </summary>
        //public static void BindVendorByFormListID(LookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    p_DrpID.Properties.ShowFooter = false;
        //    p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 200 }, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    int TempVendorTypeID = 0;
        //    string sql = "SELECT VendorTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
        //    DataTable dtTemp = SysUtils.Fill(sql);
        //    if (dtTemp.Rows.Count != 0)
        //    {
        //        TempVendorTypeID = SysConvert.ToInt32(dtTemp.Rows[0][0]);
        //    }
        //    sql = "SELECT VendorID,VendorID+' '+VendorAttn VendorAttn FROM Data_Vendor WHERE 1=1 AND UseableFlag=1 ";
        //    if (TempVendorTypeID != 0)//�����˿ͻ�����
        //    {
        //        sql += " AND  (VendorTypeID IN (SELECT VendorTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID) + ")";
        //        sql += " OR VendorTypeID=0)";//VendorTypeID=0��ʾ�ͻ����ж����ɫ
        //    }
        //    else
        //    {
        //        sql += " AND 1=0";
        //    }
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "VendorAttn", "VendorID", p_ShowBlank);
        //}

        ///// <summary>
        ///// �󶨲ֿⵥ�����Ϳͻ�
        ///// </summary>
        //public static void BindVendorByFormListID(RepositoryItemLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        //{
        //    p_DrpID.ShowHeader = false;
        //    p_DrpID.ShowFooter = false;
        //    p_DrpID.TextEditStyle = TextEditStyles.Standard;
        //    FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 200 }, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "", "" }, new bool[2] { true, true });
        //    int TempVendorTypeID = 0;
        //    string sql = "SELECT VendorTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
        //    DataTable dtTemp = SysUtils.Fill(sql);
        //    if (dtTemp.Rows.Count != 0)
        //    {
        //        TempVendorTypeID = SysConvert.ToInt32(dtTemp.Rows[0][0]);
        //    }
        //    sql = "SELECT VendorID,VendorAttn FROM Data_Vendor WHERE 1=1 AND UseableFlag=1 ";
        //    if (TempVendorTypeID != 0)//�����˿ͻ�����
        //    {
        //        sql += " AND  (VendorTypeID IN (SELECT VendorTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID) + ")";
        //        sql += " OR VendorTypeID=0)";//VendorTypeID=0��ʾ�ͻ����ж����ɫ
        //    }
        //    else
        //    {
        //        sql += " AND 1=0";
        //    }
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "VendorID", "VendorID", p_ShowBlank);
        //}

        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindVendorType(LookUpEdit p_DrpID, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_VendorType ";
            sql += " WHERE  Code Like " + SysString.ToDBString(p_Condition + "%");
            sql += " AND ISNULL(DelFlag,0)=0";
            sql += " OR Code = '0'";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        ///// <summary>
        ///// �󶨸�������
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static void BindPaymentTypeID(LookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT ID,Name FROM Enum_VendorPayment ";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        //}

        ///// <summary>
        ///// ��ø�������
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static string GetPaymentTypeID(int p_ID)
        //{
        //    string str = "";
        //    string sql = "SELECT Name FROM Enum_VendorPayment WHERE ID=" + p_ID;
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        str += dt.Rows[0][0].ToString();
        //    }
        //    return str;
        //}
        ///// <summary>
        ///// ��ñ�֯��ʽ
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static string GetBZMethordByID(int p_ID)
        //{
        //    string str = "";
        //    string sql = "SELECT Name FROM Enum_BZMethord WHERE ID=" + p_ID;
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        str += dt.Rows[0][0].ToString();
        //    }
        //    return str;
        //}
        ///// <summary>
        ///// �����ɫ����
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static string GetPSTypeByID(int p_ID)
        //{
        //    string str = "";
        //    string sql = "SELECT Name FROM Enum_PSType WHERE ID=" + p_ID;
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        str += dt.Rows[0][0].ToString();
        //    }
        //    return str;
        //}
        ///// <summary>
        ///// �����븶������
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static void BindApplyPaymentTypeID(LookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT ID,Name FROM Enum_ApplyPaymentType ";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        //}

        /// <summary>
        /// �󶨿ͻ��ȼ�
        /// </summary>
        public static void BindVendorGrade(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "Name" }, new string[1] { "" }, new bool[1] { true });
            string sql = "SELECT ID,Name FROM Enum_VendorGrade ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindVendorType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            //			FCommon.LookupEditColAdd(p_DrpID,new int[2]{50,100},new string[2]{"ID","Name"},new string[2]{"",""},new bool[2]{false,true});
            string sql = "SELECT ID,Name FROM Enum_VendorType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        #endregion

        #region ����ת����Ӣ��
        /// <summary>
        /// ���Ӣ������
        /// </summary>
        public static string GetCtnQtyEng(Int64 num)
        {
            //			string qty=string.Empty;
            //			qty+=" SAY TOTAL PACKED IN ";
            //			qty+=GetIntEng(num);
            //
            //			qty=qty.Replace("##","#");
            //
            //			qty=qty.Replace("AND#AND","AND");
            //
            //			qty=qty.Replace("#"," ");
            //
            //			qty=qty.Replace("  "," ");
            //
            //			qty+=" ("+num+") CTNS ONLY";
            //
            //			return qty;

            return GetCtnQtyEng("CTNS", num);
        }
        /// <summary>
        /// ���Ӣ������
        /// </summary>
        public static string GetCtnQtyEng(string p_Unit, Int64 num)
        {
            string qty = string.Empty;
            qty += " SAY TOTAL PACKED IN ";
            qty += GetIntEng(num);

            qty = qty.Replace("##", "#");

            qty = qty.Replace("AND#AND", "AND");

            qty = qty.Replace("#", " ");

            qty = qty.Replace("  ", " ");

            qty += " (" + num + ") " + p_Unit + " ONLY";

            return qty;
        }
        private static string backthird = "";

        /// <summary>

        /// ����ֵת����Ӣ�ĸ�ʽ

        /// </summary>

        /// <param name="num">Ҫת������ֵ</param>

        /// <returns></returns>

        public static string GetEngNum(float num)
        {

            string engnumstring = "";

            //engnumstring+="TOTAL AMOUNT IN US DOLLARS ";

            string numstring = SysConvert.ToString(num);

            int index = numstring.IndexOf(".");

            if (index == -1)
            {

                engnumstring += GetIntEng(SysConvert.ToLong(num));

                if (engnumstring.EndsWith("-"))
                {

                    int intlength = engnumstring.Length;

                    engnumstring = engnumstring.Substring(0, intlength - 1);

                }

                engnumstring = engnumstring.Replace("##", "#");

                engnumstring = engnumstring.Replace("AND#AND", "AND");

                engnumstring = engnumstring.Replace("#", " ");

                engnumstring = engnumstring.Replace("  ", " ");

                if (!engnumstring.EndsWith(" SAND"))
                {

                    if (engnumstring.EndsWith(" AND"))
                    {

                        int intlength = engnumstring.Length;

                        engnumstring = engnumstring.Substring(0, intlength - 4);

                    }

                }

                if (!engnumstring.EndsWith("SAND "))
                {

                    if (engnumstring.EndsWith("AND "))
                    {

                        int intlength = engnumstring.Length;

                        engnumstring = engnumstring.Substring(0, intlength - 4);

                    }

                }

            }

            else
            {

                Int64 intpart = SysConvert.ToLong(numstring.Substring(0, index));

                int numlength = numstring.Length;

                int decpart = SysConvert.ToInt32(numstring.Substring(index + 1, numlength - index - 1));

                if (numlength - index - 1 == 1)
                {

                    decpart = decpart * 10;

                }

                engnumstring += GetIntEng(intpart);

                if (engnumstring.EndsWith("-"))
                {

                    int intlength = engnumstring.Length;

                    engnumstring = engnumstring.Substring(0, intlength - 1);

                }



                engnumstring += " AND CENTS ";

                int declength = (SysConvert.ToString(decpart)).Length;

                backthird = "";

                engnumstring += GetStringForLength(decpart, declength, false, false);

                if (engnumstring.EndsWith(" AND CENTS "))
                {

                    int intlength = engnumstring.Length;

                    engnumstring = engnumstring.Substring(0, intlength - 9);

                }



            }

            engnumstring = engnumstring.Replace("##", "#");

            engnumstring = engnumstring.Replace("AND#AND", "AND");

            engnumstring = engnumstring.Replace("#", " ");

            engnumstring = engnumstring.Replace("  ", " ");

            if (!engnumstring.EndsWith(" SAND"))
            {

                if (engnumstring.EndsWith(" AND"))
                {

                    int intlength = engnumstring.Length;

                    engnumstring = engnumstring.Substring(0, intlength - 4);

                }

            }

            if (!engnumstring.EndsWith("SAND "))
            {

                if (engnumstring.EndsWith("AND "))
                {

                    int intlength = engnumstring.Length;

                    engnumstring = engnumstring.Substring(0, intlength - 4);

                }

            }

            //engnumstring+=" ONLY";

            engnumstring = engnumstring.Replace("  ", " ");

            return engnumstring;

        }


        /// <summary>

        /// ������ת����Ӣ��

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string GetIntEng(Int64 num)
        {

            string inteng = "";

            string numstring = SysConvert.ToString(num);

            int length = numstring.Length;

            if (length <= 12)
            {

                switch (length)
                {

                    case 1:

                        inteng += GetOneEng(SysConvert.ToInt32(num), false, false);

                        break;

                    case 2:

                        inteng += GetTwoEng(SysConvert.ToInt32(num), false, false);

                        break;

                    case 3:

                        inteng += GetThreeEng(SysConvert.ToInt32(num), false, false);

                        break;

                    case 4:

                        inteng += GetFourEng(SysConvert.ToInt32(num), false, false);

                        break;

                    case 5:

                        goto case 4;

                    case 6:

                        goto case 4;

                    case 7:

                        inteng += GetSevenEng(SysConvert.ToInt32(num), false, false);

                        break;

                    case 8:

                        goto case 7;

                    case 9:

                        goto case 7;

                    case 10:

                        inteng += GetTenEng(SysConvert.ToLong(num), false, false);

                        break;

                    case 11:

                        goto case 10;

                    case 12:

                        goto case 10;

                }

            }

            return inteng;

        }

        /// <summary>

        /// ���ݳ�����ѡ����������м�λ����

        /// </summary>

        /// <param name="num"></param>

        /// <param name="length"></param>

        /// <returns></returns>

        private static string GetStringForLength(int num, int length, bool front, bool back)
        {

            string tempnumstring = "";

            switch (length)
            {

                case 1:

                    tempnumstring += GetOneEng(num, front, back);

                    break;

                case 2:

                    tempnumstring += GetTwoEng(num, front, back);

                    break;

                case 3:

                    tempnumstring += GetThreeEng(num, front, back);

                    break;

                case 4:

                    tempnumstring += GetFourEng(num, front, back);

                    break;

                case 5:

                    goto case 4;

                case 6:

                    goto case 4;

                case 7:

                    tempnumstring += GetSevenEng(num, front, back);

                    break;

                case 8:

                    goto case 7;

                case 9:

                    goto case 7;

            }

            return tempnumstring;

        }

        /// <summary>

        /// ��һλ���ַ����Ӣ��

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string GetOneEng(int num, bool front, bool back)
        {

            string oneeng = "";

            if (front && !back && backthird == "0")
            {

                oneeng += "AND ";

            }

            switch (num)
            {

                case 0:

                    break;

                case 1:

                    oneeng += "ONE";

                    break;

                case 2:

                    oneeng += "TWO";

                    break;

                case 3:

                    oneeng += "THREE";

                    break;

                case 4:

                    oneeng += "FOUR";

                    break;

                case 5:

                    oneeng += "FIVE";

                    break;

                case 6:

                    oneeng += "SIX";

                    break;

                case 7:

                    oneeng += "SEVEN";

                    break;

                case 8:

                    oneeng += "EIGHT";

                    break;

                case 9:

                    oneeng += "NINE";

                    break;

            }

            return oneeng;

        }


        /// <summary>

        /// ����λ���ַ����Ӣ��

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string GetTwoEng(int num, bool front, bool back)
        {

            string twoeng = "";

            if (front && !back && backthird == "0")
            {

                twoeng += "#AND";

            }

            string numstring = SysConvert.ToString(num);

            int first = SysConvert.ToInt32(numstring.Substring(0, 1));

            int second = SysConvert.ToInt32(numstring.Substring(1, 1));

            switch (num)
            {

                case 10:

                    twoeng += "#TEN";

                    break;

                case 11:

                    twoeng += "#ELEVEN";

                    break;

                case 12:

                    twoeng += "#TWELVE";

                    break;

                case 13:

                    twoeng += "#THIRTEEN";

                    break;

                case 14:

                    twoeng += "#FOURTEEN";

                    break;

                case 15:

                    twoeng += "#FIFTEEN";

                    break;

                case 16:

                    twoeng += "#SIXTEEN";

                    break;

                case 17:

                    twoeng += "#SEVENTEEN";

                    break;

                case 18:

                    twoeng += "#EIGHTEEN";

                    break;

                case 19:

                    twoeng += "#NINETEEN";

                    break;

                case 20:

                    twoeng += "#TWENTY";

                    break;

                case 30:

                    twoeng += "#THIRTY";

                    break;

                case 40:

                    twoeng += "#FORTY";

                    break;

                case 50:

                    twoeng += "#FIFTY";

                    break;

                case 60:

                    twoeng += "#SIXTY";

                    break;

                case 70:

                    twoeng += "#SEVENTY";

                    break;

                case 80:

                    twoeng += "#EIGHTY";

                    break;

                case 90:

                    twoeng += "#NINETY";

                    break;

            }

            if (num > 20)
            {

                if (second != 0)
                {

                    switch (first)
                    {

                        case 2:

                            twoeng += "#TWENTY-";

                            break;

                        case 3:

                            twoeng += "#THIRTY-";

                            break;

                        case 4:

                            twoeng += "#FORTY-";

                            break;

                        case 5:

                            twoeng += "#FIFTY-";

                            break;

                        case 6:

                            twoeng += "#SIXTY-";

                            break;

                        case 7:

                            twoeng += "#SEVENTY-";

                            break;

                        case 8:

                            twoeng += "#EIGHTY-";

                            break;

                        case 9:

                            twoeng += "#NINETY-";

                            break;

                    }

                    switch (second)
                    {

                        case 1:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 2:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 3:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 4:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 5:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 6:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 7:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 8:

                            twoeng += GetOneEng(second, true, back);

                            break;

                        case 9:

                            twoeng += GetOneEng(second, true, back);

                            break;

                    }

                }

            }

            return twoeng;

        }



        /// <summary>

        /// ����λ�������ַ����Ӣ��

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string GetThreeEng(int num, bool front, bool back)//bool front,
        {

            string threeeng = "";

            string numstring = SysConvert.ToString(num);

            int first = SysConvert.ToInt32(numstring.Substring(0, 1));

            int left = SysConvert.ToInt32(numstring.Substring(1, 2));

            int leftlength = (SysConvert.ToString(left)).Length;

            switch (first)
            {

                case 1:

                    threeeng += "#ONE HUNDRED#";

                    break;

                case 2:

                    threeeng += "#TWO HUNDRED#";

                    break;

                case 3:

                    threeeng += "#THREE HUNDRED#";

                    break;

                case 4:

                    threeeng += "#FOUR HUNDRED#";

                    break;

                case 5:

                    threeeng += "#FIVE HUNDRED#";

                    break;

                case 6:

                    threeeng += "#SIX HUNDRED#";

                    break;

                case 7:

                    threeeng += "#SEVEN HUNDRED#";

                    break;

                case 8:

                    threeeng += "#EIGHT HUNDRED#";

                    break;

                case 9:

                    threeeng += "#NINE HUNDRED#";

                    break;

            }

            if (first != 0)
            {

                threeeng += "AND#";

            }

            else
            {

                if (front && !back)
                {

                    threeeng += "AND#";

                }

            }

            threeeng += GetStringForLength(left, leftlength, true, back);

            return threeeng;

        }

        /// <summary>

        /// ����λ����λ��ת����Ӣ��

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string GetFourEng(int num, bool front, bool back)
        {

            string foureng = "";

            string numstring = SysConvert.ToString(num);

            int length = numstring.Length;

            if (length == 4)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 1));

                int left = SysConvert.ToInt32(numstring.Substring(1, 3));

                backthird = numstring.Substring(1, 1);

                int leftlength = (SysConvert.ToString(left)).Length;

                foureng += GetOneEng(first, front, true);

                foureng += "#THOUSAND ";

                //                 foureng=CheckAnd(foureng,num);

                foureng += GetStringForLength(left, leftlength, true, false);

            }

            if (length == 5)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 2));

                int left = SysConvert.ToInt32(numstring.Substring(2, 3));

                backthird = numstring.Substring(2, 1);

                int leftlength = (SysConvert.ToString(left)).Length;

                foureng += GetTwoEng(first, front, true);

                foureng += "#THOUSAND ";

                //                 foureng=CheckAnd(foureng,num);

                foureng += GetStringForLength(left, leftlength, true, false);

            }

            if (length == 6)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 3));

                int left = SysConvert.ToInt32(numstring.Substring(3, 3));

                backthird = numstring.Substring(3, 1);

                int leftlength = (SysConvert.ToString(left)).Length;

                foureng += GetThreeEng(first, front, true);

                foureng += "#THOUSAND ";

                //                 foureng=CheckAnd(foureng,num);

                foureng += GetStringForLength(left, leftlength, true, false);

            }

            return foureng;

        }



        /// <summary>

        /// ����λ����λ��ת����Ӣ��

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string GetSevenEng(int num, bool front, bool back)
        {

            string seveneng = "";

            string numstring = SysConvert.ToString(num);

            int length = numstring.Length;

            if (length == 7)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 1));

                int left = SysConvert.ToInt32(numstring.Substring(1, 6));

                int leftlength = (SysConvert.ToString(left)).Length;

                seveneng += GetOneEng(first, front, true);

                seveneng += "#MILLION#";

                //                 seveneng=CheckAnd(seveneng,num);

                seveneng += GetStringForLength(left, leftlength, true, back);

            }

            if (length == 8)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 2));

                int left = SysConvert.ToInt32(numstring.Substring(2, 6));

                int leftlength = (SysConvert.ToString(left)).Length;

                seveneng += GetTwoEng(first, front, true);

                seveneng += "#MILLION#";

                //                 seveneng=CheckAnd(seveneng,num);

                seveneng += GetStringForLength(left, leftlength, true, back);

            }

            if (length == 9)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 3));

                int left = SysConvert.ToInt32(numstring.Substring(3, 6));

                int leftlength = (SysConvert.ToString(left)).Length;

                seveneng += GetThreeEng(first, front, true);

                seveneng += "#MILLION#";

                //                 seveneng=CheckAnd(seveneng,num);

                seveneng += GetStringForLength(left, leftlength, true, back);

            }

            return seveneng;

        }



        /// <summary>

        /// ��ʮλ��ʮ��λ��ת����Ӣ��

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string GetTenEng(Int64 num, bool front, bool back)
        {

            string teneng = "";

            string numstring = SysConvert.ToString(num);

            int length = numstring.Length;

            if (length == 10)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 1));

                int left = SysConvert.ToInt32(numstring.Substring(1, 9));

                int leftlength = (SysConvert.ToString(left)).Length;

                teneng += GetOneEng(first, front, true);

                teneng += "#BILLION#";

                //                 teneng=CheckAnd(teneng,num);

                teneng += GetStringForLength(left, leftlength, true, back);

            }

            if (length == 11)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 2));

                int left = SysConvert.ToInt32(numstring.Substring(2, 9));

                int leftlength = (SysConvert.ToString(left)).Length;

                teneng += GetTwoEng(first, front, true);

                teneng += "#BILLION#";

                //                 teneng=CheckAnd(teneng,num);

                teneng += GetStringForLength(left, leftlength, true, back);

            }

            if (length == 12)
            {

                int first = SysConvert.ToInt32(numstring.Substring(0, 3));

                int left = SysConvert.ToInt32(numstring.Substring(3, 9));

                int leftlength = (SysConvert.ToString(left)).Length;

                teneng += GetThreeEng(first, front, true);

                teneng += "#BILLION#";

                //                 teneng=CheckAnd(teneng,num);

                teneng += GetStringForLength(left, leftlength, true, back);

            }

            return teneng;

        }

        /// <summary>

        /// ����Ƿ�Ҫ��AND,ֻ�����λ����

        /// </summary>

        /// <param name="num"></param>

        /// <returns></returns>

        private static string CheckAnd(string p_string, Int64 p_num)
        {

            int length = (SysConvert.ToString(p_num)).Length;

            string temp = (SysConvert.ToString(p_num)).Substring(length - 3, 1);

            if (temp == "0")
            {

                p_string += "AND#";

            }

            return p_string;

        }

        #endregion

        #region ����ת��������Ҵ�д
        public static string RMBToString(double r)
        {
            double r1;
            string s1 = "��Ҽ��������½��ƾ�";
            string s2 = "�ֽ�Ԫʰ��Ǫ��ʰ��Ǫ��ʰ��Ǫ��";
            string dx, s;
            r1 = r;
            dx = "";
            if (r1 < 0)
            {
                r1 *= -1;
                dx = "��";
            }
            s = String.Format("{0:f0}", r1 * 100);
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                dx = dx + s1.Substring(s[i] - '0', 1) + s2.Substring(len - i - 1, 1);
            }
            dx = StrTran(StrTran(StrTran(StrTran(StrTran(dx, "��Ǫ", "��"), "���", "��"), "��ʰ", "��"), "���", "��"), "���", "��");
            dx = StrTran(StrTran(StrTran(StrTran(StrTran(dx, "����", "��"), "����", "��"), "����", "��"), "����", "��"), "��Ԫ", "Ԫ");
            if (dx == "��")
                return "��Ԫ��";
            else
                return StrTran(StrTran(StrTran(dx, "����", "����"), "����", "��"), "����", "��");
        }

        private static string StrTran(string s, string oldv, string newv)
        {
            return s.Replace(oldv, newv);
        }

        #endregion

        #region ����ת��

        /// <summary>
        /// ��֤�Ƿ�ΪASCII��
        /// </summary>
        /// <param name="p_Char">Ҫ��֤���ַ�</param>
        /// <returns>���Ǳ�׼�ķ���-1�����򷵻ظ��ַ���ASCIIֵ</returns>
        public static int CheckASCII(string p_String, out string tempstr)
        {
            int ascNum = -1;
            tempstr = "";
            for (int i = 0; i < p_String.Length; i++)
            {
                string tempString = p_String.Substring(i, 1);
                tempstr = tempString;
                if (tempString != "?")
                {
                    byte[] temp = System.Text.Encoding.ASCII.GetBytes(tempString);
                    if (temp[0] >= 0 && temp[0] < 128 && temp[0] != 63)
                    {
                        ascNum = -1;
                    }
                    else
                    {
                        ascNum = temp[0];
                        return ascNum;
                    }
                }
                else
                {
                    ascNum = -1;
                }
            }
            return ascNum;
        }

        /// <summary>
        /// �ڵ�ǰ��λ����������һ��
        /// </summary>
        /// <param name="p_Dt">��</param>
        /// <param name="p_RowID">�к�</param>
        public static void DataTableAddRow(DataTable p_Dt, int p_RowID)
        {
            if (p_Dt == null || p_RowID == -1)
            {
            }
            DataRow dr = p_Dt.NewRow();
            if (p_RowID == p_Dt.Rows.Count - 1 || p_RowID < -1)//�������һ��
            {
                p_Dt.Rows.Add(dr);
            }
            else//
            {
                p_Dt.Rows.Add(dr);
                for (int i = p_Dt.Rows.Count - 1; i > p_RowID; i--)
                {
                    for (int j = 0; j < p_Dt.Columns.Count; j++)
                    {
                        p_Dt.Rows[i][j] = p_Dt.Rows[i - 1][j];
                    }
                }
                for (int j = 0; j < p_Dt.Columns.Count; j++)
                {
                    p_Dt.Rows[p_RowID + 1][j] = DBNull.Value;
                }
            }
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <returns>�ƶ�����к�</returns>
        public static int DataTableUpRow(DataTable p_Dt, int RowID)
        {
            int outint = RowID;
            if (RowID > 0)//�кŴ���0������
            {
                DataRow dr = p_Dt.NewRow();
                for (int j = 0; j < p_Dt.Columns.Count; j++)//������һ������
                {
                    dr[j] = p_Dt.Rows[RowID - 1][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//�ƶ�����һ��
                {
                    p_Dt.Rows[RowID - 1][j] = p_Dt.Rows[RowID][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//��һ�л��汣�浽����
                {
                    p_Dt.Rows[RowID][j] = dr[j];
                }
                outint--;
            }

            return outint;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>�ƶ�����к�</returns>
        public static int DataTableDownRow(DataTable p_Dt, int RowID)
        {
            int outint = RowID;
            if (RowID < p_Dt.Rows.Count - 1)//�к�С������в�����
            {
                DataRow dr = p_Dt.NewRow();
                for (int j = 0; j < p_Dt.Columns.Count; j++)//������һ������
                {
                    dr[j] = p_Dt.Rows[RowID + 1][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//�ƶ�����һ��
                {
                    p_Dt.Rows[RowID + 1][j] = p_Dt.Rows[RowID][j];
                }

                for (int j = 0; j < p_Dt.Columns.Count; j++)//��һ�л��汣�浽����
                {
                    p_Dt.Rows[RowID][j] = dr[j];
                }
                outint++;
            }
            return outint;
        }

        /// <summary>
        /// ��ò�ѯ�ַ���
        /// </summary>
        /// <param name="gridview"></param>
        /// <returns></returns>
        public static string GridGetQueryField(GridView gridview)
        {
            string outstr = string.Empty;
            for (int i = 0; i < gridview.Columns.Count; i++)
            {
                if (outstr != string.Empty)
                {
                    outstr += ",";
                }
                outstr += gridview.Columns[i].FieldName;
            }
            return outstr;
        }

        /// <summary>
        /// ���ñ�������Դ������������ҳ
        /// </summary>
        /// <param name="p_Dt">����Դ</param>
        /// <param name="p_PageSize">ÿҳ����</param>
        public static void SetReportDataSource(DataTable p_Dt, int p_PageSize)
        {
            int count = p_Dt.Rows.Count % p_PageSize;//ȡ��
            if (count != 0)
            {
                for (int i = count; i < p_PageSize; i++)
                {
                    p_Dt.Rows.Add(p_Dt.NewRow());
                }
            }
            else
            {
                AddDtRow(p_Dt, p_PageSize);
            }
        }

        /// <summary>
        /// ����DataTable��ָ��������
        /// </summary>��
        /// <param name="p_Dt">����</param>
        /// <param name="RowCount">����</param>
        public static void AddDtRow(DataTable p_Dt, int RowCount)
        {
            for (int i = p_Dt.Rows.Count; i < RowCount; i++)
            {
                p_Dt.Rows.Add(p_Dt.NewRow());
            }
        }

        /// <summary>
        /// ɾ��һ������Դ
        /// </summary>
        public static void DelDtRow(DataTable p_Dt, int RowID)
        {
            if (RowID > -1)
            {
                p_Dt.Rows.RemoveAt(RowID);
            }
        }

        /// <summary>
        /// ������һ������
        /// </summary>
        public static void CopyPreRowData(GridView p_GridView)
        {
            if (p_GridView.FocusedRowHandle >= 0 && p_GridView.FocusedRowHandle + 1 < p_GridView.RowCount)//�����㹻�Ÿ���
            {
                for (int i = 0; i < p_GridView.Columns.Count; i++)
                {
                    p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle + 1, p_GridView.Columns[i], p_GridView.GetRowCellValue(p_GridView.FocusedRowHandle, p_GridView.Columns[i]));
                }
            }
        }


        /// <summary>
        /// �õ����ؿ�ʼ��
        /// </summary>
        /// <returns></returns>
        public static int GetNewRow(GridView p_GridView, string sFiledName)
        {
            int outstr = 0;
            for (int i = 0; i < p_GridView.RowCount; i++)
            {
                if (SysConvert.ToString(p_GridView.GetRowCellValue(i, sFiledName)) == string.Empty)
                {
                    outstr = i;
                    break;
                }
            }
            return outstr;
        }

        /// <summary>
        /// ת��С����
        /// </summary>
        /// <param name="p_Num">���ִ�</param>
        /// <returns>ת��������ִ�</returns>
        public static string ConvertNum(string p_Num)
        {
            string outstr = p_Num;
            if (outstr.IndexOf('.') != -1)
            {
                while (outstr.Length > 1 && (outstr.Substring(outstr.Length - 1) == "0" || outstr.Substring(outstr.Length - 1) == "."))
                {
                    if (outstr.Substring(outstr.Length - 1) == ".")
                    {
                        outstr = outstr.Substring(0, outstr.Length - 1);
                        break;
                    }
                    else
                    {
                        outstr = outstr.Substring(0, outstr.Length - 1);
                    }

                }
            }
            return outstr;
        }


        /// <summary>
        /// �������ת���ַ�����Ĭ�ϵķ��ؿ�
        /// </summary>
        /// <param name="p_Dt">����</param>
        /// <returns></returns>
        public static string GetExcelDateStr(DateTime p_Dt)
        {
            if (p_Dt != SystemConfiguration.DateTimeDefaultValue)
            {
                return p_Dt.ToString("yyyy-MM-dd");
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// �������ת���ַ�����Ĭ�ϵķ��ؿ�
        /// </summary>
        /// <param name="p_Dt">����</param>
        /// <returns></returns>
        public static string GetExcelNumStr(decimal p_Num)
        {
            if (p_Num != SystemConfiguration.DecimalDefaultValue)
            {
                return p_Num.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region ���ݴ���


        /// <summary>
        /// ���ݿͻ������ÿͻ�����
        /// </summary>
        public static string GetSubTypeNameByID(string p_SubTypID)
        {
            string outstr = "";
            string sql = "SELECT FormNM FROM Enum_FormList WHERE ID = " + SysString.ToDBString(p_SubTypID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr += SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }


        /// <summary>
        /// ���ݿͻ������ÿͻ�����
        /// </summary>
        public static string GetVendorNameByVendorID(string p_VendorID)
        {
            string outstr = "";
            string sql = "SELECT VendorName FROM Data_Vendor WHERE VendorID= " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr += SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }





        /// <summary>
        /// ȡ�òֿ�ֵ
        /// </summary>
        /// <param name="p_WHID"></param>
        /// <returns></returns>
        public static int GetCStep(string p_SOID, int p_SOLine, int p_Seq, int p_ColorSeq)
        {
            int tempCStep = 0, temp = 0, maxtemp = 0;
            string sql = "SELECT C_STEP FROM WO_D WHERE SO=" + SysString.ToDBString(p_SOID);
            if (p_SOLine != 0)
            {
                sql += " AND SOLINE=" + SysString.ToDBString(p_SOLine) + " AND SEQ=" + SysString.ToDBString(p_Seq);
                sql += " AND ColorSeq=" + SysString.ToDBString(p_ColorSeq);
            }
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                maxtemp = SysConvert.ToInt32(dt.Rows[0]["C_STEP"].ToString());
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    temp = SysConvert.ToInt32(dt.Rows[i]["C_STEP"].ToString());
                    if (maxtemp < temp)
                    {
                        maxtemp = temp;
                    }
                }
            }
            tempCStep = maxtemp;
            return tempCStep;
        }
        /// <summary>
        /// ����Grid��Ԫ��С����ʽ
        /// </summary>
        /// <param name="view1">GridView</param>
        /// <param name="p_GridField">�ֶ���</param>
        /// <param name="p_Num">С��λ��</param>
        public static void SetGridValueStyle(GridView view1, string p_GridField, int p_Num)
        {
            double FinalValue = 0;
            for (int i = 0; i < view1.RowCount; i++)
            {
                //float temp=SysConvert.ToFloat(view1.GetRowCellValue(i,view1.Columns[p_GridField]));
                FinalValue = SysConvert.ToDouble(Math.Round(SysConvert.ToDecimal(view1.GetRowCellValue(i, view1.Columns[p_GridField])), p_Num));
                view1.SetRowCellValue(i, view1.Columns[p_GridField], FinalValue);
            }
        }
        #endregion

        #region ���õ��ݲ�����ť״̬(��ת��)
        /// <summary>
        /// ���õ��ݲ�����ť״̬(��ת��)
        /// </summary>
        /// <param name="p_Status"></param>
        /// <param name="p_StreamID"></param>
        /// <param name="p_Insert"></param>
        /// <param name="p_Cancel"></param>
        /// <param name="p_Save"></param>
        /// <param name="p_Delete"></param>
        /// <param name="p_Query"></param>
        /// <param name="p_Print"></param>
        public static void SetButtonStatusStream(FormStatus p_Status, string p_StreamID, SimpleButton p_Insert, SimpleButton p_Cancel, SimpleButton p_Save, SimpleButton p_Delete, SimpleButton p_Query, SimpleButton p_Print)
        {
            p_Insert.Enabled = false;
            p_Cancel.Enabled = false;
            p_Delete.Enabled = false;
            p_Query.Enabled = false;
            p_Print.Enabled = false;
            p_Save.Enabled = false;
            switch (p_Status)
            {
                case FormStatus.����:
                    p_Cancel.Enabled = true;
                    p_Save.Enabled = true;
                    break;
                case FormStatus.��ѯ:
                    p_Query.Enabled = true;
                    p_Insert.Enabled = true;
                    if (p_StreamID != string.Empty)
                    {
                        p_Delete.Enabled = true;
                        p_Print.Enabled = true;
                    }
                    break;
                case FormStatus.����:
                    goto case FormStatus.��ѯ;
            }
        }
        #endregion

        #region ���������� ����������(Excel)

        /// <summary>
        /// ����ճ��
        /// </summary>
        public static void ExcelContextCopyCancel(GridView p_View, int p_StartRow, int p_StartCol, int p_RowCount, string[,] p_ForeDate)
        {
            if (p_RowCount > 0)
            {
                for (int i = 0; i < p_RowCount; i++)
                {
                    for (int j = 0; j < p_ForeDate.Length / p_RowCount; j++)
                    {
                        string fname = string.Empty;
                        for (int tempi = 0; tempi < p_View.Columns.Count; tempi++)//�ҳ�������ǰ�е��ֶ���
                        {
                            if (p_View.Columns[tempi].VisibleIndex == j + p_StartCol)
                            {
                                fname = p_View.Columns[tempi].FieldName;
                                break;
                            }
                        }

                        if (fname != string.Empty)
                        {
                            if (p_View.Columns[fname].ColumnType == typeof(int) || p_View.Columns[fname].ColumnType == typeof(double)
                                || p_View.Columns[fname].ColumnType == typeof(float) || p_View.Columns[fname].ColumnType == typeof(decimal)
                                )//���������
                            {
                                if (p_ForeDate[i, j] != string.Empty)
                                {
                                    p_View.SetRowCellValue(i + p_StartRow, fname, p_ForeDate[i, j]);
                                }
                                else
                                {
                                    p_View.SetRowCellValue(i + p_StartRow, fname, DBNull.Value);
                                }
                            }
                            else
                            {
                                p_View.SetRowCellValue(i + p_StartRow, fname, p_ForeDate[i, j]);
                            }
                        }

                    }
                }
            }
        }

        /// <summary>
        /// ճ��EXCEL�����ݲ�����֮ǰ�������Ա�����
        /// </summary>
        /// <param name="p_View"></param>
        /// <param name="o_StartRow"></param>
        /// <param name="o_StartCol"></param>
        /// <param name="o_ForeDate"></param>
        public static void ExcelContextCopy(GridView p_View, out int o_StartRow, out int o_StartCol, out int o_RowCount, out string[,] o_ForeDate)
        {
            ExcelContextCopy(p_View, 0, 0, out o_StartRow, out o_StartCol, out o_RowCount, out o_ForeDate);
        }

        public static void ExcelContextCopy(GridView p_View, int p_MinRow, int p_MinCol, out int o_StartRow, out int o_StartCol, out int o_RowCount, out string[,] o_ForeDate)
        {
            int vi = 0;//�ɼ���
            for (int i = 0; i < p_View.Columns.Count; i++)
            {
                if (p_View.Columns[i].Visible)
                {
                    vi++;
                }
            }

            ExcelContextCopy(p_View, p_MinRow, p_MinCol, p_View.RowCount - 1, vi - 1, out o_StartRow, out o_StartCol, out o_RowCount, out o_ForeDate);
        }

        public static void ExcelContextCopy(GridView p_View, int p_MinRow, int p_MinCol, int p_MaxRow, int p_MaxCol, out int o_StartRow, out int o_StartCol, out int o_RowCount, out string[,] o_ForeDate)
        {
            string waitecontext = string.Empty;
            try
            {
                IDataObject dataObj = Clipboard.GetDataObject();
                object obj = dataObj.GetData(DataFormats.UnicodeText, true);
                waitecontext = obj.ToString();
            }
            catch
            {
            }
            int startrow = p_View.FocusedRowHandle;//��ʼ��
            int startcol = p_View.FocusedColumn.VisibleIndex;//��ʼ��


            int vi = 0;//�ɼ���
            for (int i = 0; i < p_View.Columns.Count; i++)
            {
                if (p_View.Columns[i].Visible)
                {
                    vi++;
                }
            }

            if (p_MinRow > startrow)//��ʼ��
            {
                startrow = p_MinRow;
            }
            if (p_MinCol > startcol)//��ʼ��
            {
                startcol = p_MinCol;
            }


            o_StartRow = startrow;
            o_StartCol = startcol;
            o_RowCount = 0;

            ArrayList preDataAl = new ArrayList();//ArrayList����
            if (waitecontext != string.Empty)//���������ݲ�Ϊ��
            {
                string[] waitRow = StringSplit(waitecontext, @"\r\n");//�������
                for (int i = 0; i < waitRow.Length; i++)
                {
                    if (i + startrow > p_MaxRow)//��ǰ�г��������
                    {
                        break;
                    }
                    string[] waitCol = waitRow[i].Split('\t');//�������
                    ArrayList preDataColAl = new ArrayList();//֮ǰ��������
                    for (int j = 0; j < waitCol.Length; j++)
                    {
                        if (j + startcol > p_MaxCol)//��ǰ�г��������
                        {
                            break;
                        }
                        string fname = string.Empty;
                        for (int tempi = 0; tempi < p_View.Columns.Count; tempi++)//�ҳ�������ǰ�е��ֶ���
                        {
                            if (p_View.Columns[tempi].VisibleIndex == j + startcol)
                            {
                                fname = p_View.Columns[tempi].FieldName;
                                break;
                            }
                        }

                        if (fname != string.Empty)
                        {
                            preDataColAl.Add(SysConvert.ToString(p_View.GetRowCellValue(i + startrow, fname)));
                            if (p_View.Columns[fname].ColumnType == typeof(int) || p_View.Columns[fname].ColumnType == typeof(double)
                                || p_View.Columns[fname].ColumnType == typeof(float) || p_View.Columns[fname].ColumnType == typeof(decimal)
                                )//���������
                            {
                                if (waitCol[j] != string.Empty)
                                {
                                    p_View.SetRowCellValue(i + startrow, fname, waitCol[j]);
                                }
                                else
                                {
                                    p_View.SetRowCellValue(i + startrow, fname, DBNull.Value);
                                }
                            }
                            else
                            {
                                p_View.SetRowCellValue(i + startrow, fname, waitCol[j]);
                            }
                        }
                    }

                    preDataAl.Add(preDataColAl);//֮ǰ������
                    o_RowCount = i + 1;
                }
            }

            if (preDataAl.Count != 0)//����֮ǰ������
            {
                o_ForeDate = new string[preDataAl.Count, ((ArrayList)preDataAl[0]).Count];//,((ArrayList)preDataAl[0]).Count];
                for (int i = 0; i < preDataAl.Count; i++)
                {
                    ArrayList rd = (ArrayList)preDataAl[i];
                    for (int j = 0; j < rd.Count; j++)
                    {
                        o_ForeDate[i, j] = rd[j].ToString();
                    }
                }
            }
            else
            {
                o_ForeDate = new string[0, 0];
            }
        }

        static string[] StringSplit(string p_Str, string p_CharStr)
        {
            ArrayList al = new ArrayList();
            while (p_Str.IndexOf("\r\n") != -1)//�ҵ���
            {
                al.Add(p_Str.Substring(0, p_Str.IndexOf("\r\n")));
                if (p_Str.Length > p_Str.IndexOf("\r\n") + 2)
                {
                    p_Str = p_Str.Substring(p_Str.IndexOf("\r\n") + 2);
                }
                else
                {
                    p_Str = string.Empty;
                }
            }
            if (p_Str != string.Empty)
            {
                al.Add(p_Str);
            }

            string[] tempa = new string[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                tempa[i] = al[i].ToString();
            }
            return tempa;
        }
        #endregion

        #region �ֿ⴦�����

        #region ����ֿ���λ����ʾ������
        public static void ProcHideSectionSbit(string p_WHID, DevExpress.XtraGrid.Views.Grid.GridView p_View)
        {
            ProcHideSectionSbit(p_WHID, p_View, "SectionID", "SBitID");
        }

        public static void ProcHideSectionSbit(string p_WHID, DevExpress.XtraGrid.Views.Grid.GridView p_View, string p_Sectionfn, string p_Sbitfn)
        {
            ProcHideSectionSbit(p_WHID, p_View, new string[1] { p_Sectionfn });
        }

        /// <summary>
        /// ������λ����ʾ������
        /// </summary>
        /// <param name="p_WHID"></param>
        public static void ProcHideSectionSbit(string p_WHID, DevExpress.XtraGrid.Views.Grid.GridView p_View, string[] p_Sectionfn)
        {
            string sql = "SELECT WHPosMethodID FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                int posmethod = SysConvert.ToInt32(dt.Rows[0][0].ToString());
                switch (posmethod)
                {
                   
                }
            }
        }

        #endregion
        #region ��òֿ���Ĭ��ֵ
        /// <summary>
        /// ���òֿ�����Ĭ��ֵ
        /// </summary>
        /// <param name="p_WHType"></param>
        /// <param name="p_WHID"></param>
        /// <param name="SectionID"></param>
        /// <returns></returns>
        private static string WHGetSectionID(int p_WHType, string p_WHID, string SectionID)
        {
            string outstr = SectionID;
            string sql = "SELECT WHPosMethodID FROM Enum_WHType WHERE ID=" + SysString.ToDBString(p_WHType);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                switch (SysConvert.ToInt32(dt.Rows[0]["WHPosMethodID"].ToString()))
                {
                   
                }
            }
            return outstr;
        }

        /// <summary>
        /// ���òֿ�λ��Ĭ��ֵ
        /// </summary>
        /// <param name="p_WHType"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_SectionID"></param>
        /// <param name="p_SBitID"></param>
        /// <returns></returns>
        private static string WHGetSBitID(int p_WHType, string p_WHID, string p_SectionID, string p_SBitID)
        {
            string outstr = p_SBitID;
            string sql = "SELECT WHPosMethodID FROM Enum_WHType WHERE ID=" + SysString.ToDBString(p_WHType);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                switch (SysConvert.ToInt32(dt.Rows[0]["WHPosMethodID"].ToString()))
                {
                   
                }
            }
            return outstr;
        }



        /// <summary>
        /// ���òֿ�����Ĭ��ֵ
        /// </summary>
        /// <param name="p_WHType"></param>
        /// <param name="p_WHID"></param>
        /// <param name="SectionID"></param>
        /// <returns></returns>
        public static string WHGetSectionID(string p_WHID, string SectionID)
        {
            string outstr = SectionID;
            string sql = "SELECT WHPosMethodID FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                switch (SysConvert.ToInt32(dt.Rows[0]["WHPosMethodID"].ToString()))
                {
                   
                }
            }
            return outstr;
        }

        /// <summary>
        /// ���òֿ�λ��Ĭ��ֵ
        /// </summary>
        /// <param name="p_WHType"></param>
        /// <param name="p_WHID"></param>
        /// <param name="p_SectionID"></param>
        /// <param name="p_SBitID"></param>
        /// <returns></returns>
        public static string WHGetSBitID(string p_WHID, string p_SectionID, string p_SBitID)
        {
            string outstr = p_SBitID;
            string sql = "SELECT WHPosMethodID FROM UV1_WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                switch (SysConvert.ToInt32(dt.Rows[0]["WHPosMethodID"].ToString()))
                {
                   
                }
            }
            return outstr;
        }

        #endregion

        #region ����
        /// <summary>
        /// ����FormListAID�õ����㵥��������⡢���⡢�̵㡢�ƿ⡢��̬ת�����ڳ����
        /// </summary>
        /// <param name="p_FormListAID">loginID</param>
        /// <returns></returns>
        public static int GetFormListTopTypeByFormListID(int p_FormListAID)
        {
            int outint = p_FormListAID;
            string sql = "SELECT ParentID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0]["ParentID"]) != 0)
                {
                    outint = SysConvert.ToInt32(dt.Rows[0]["ParentID"]);
                }
            }
            return outint;
        }

        /// <summary>
        /// ȡ�ô��������
        /// </summary>
        /// <returns></returns>
        public static string GetFormInfo(int p_FormListAID)
        {
            string tempFomrName = string.Empty;
            string sql = "SELECT FormNM FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                tempFomrName = SysConvert.ToString(dt.Rows[0]["FormNM"]);
            }
            return tempFomrName;
        }

        /// <summary>
        /// У���Ƿ���Ҫ����
        /// </summary>
        /// <param name="p_FormID">����ID</param>
        public static int[] CheckIsFreeForm(int p_FormID)
        {
            int[] isfreeform = new int[2];
            string sql = "SELECT SubType FROM WH_IOForm WHERE ID=" + SysString.ToDBString(p_FormID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                sql = "SELECT IsFreeForm,FreeFormID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(dt.Rows[0]["SubType"].ToString());
                dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    isfreeform[0] = SysConvert.ToInt32(dt.Rows[0]["IsFreeForm"].ToString());
                    isfreeform[1] = SysConvert.ToInt32(dt.Rows[0]["FreeFormID"].ToString());
                }
            }
            return isfreeform;
        }

        //		/// <summary>
        //		/// �����Ƿ���ϵͳ����Ա
        //		/// </summary>
        //		/// <param name="p_LoginID">loginID</param>
        //		/// <returns></returns>
        //		public static bool CheckAdmin(string p_LoginID)
        //		{
        //			string sql="SELECT DutyID FROM Data_OP WHERE OPID="+SysString.ToDBString(p_LoginID);
        //			DataTable dt=SysUtils.Fill(sql);
        //			if(SysConvert.ToInt32(dt.Rows[0]["DutyID"])==(int)OPDuty.ϵͳ����Ա)
        //			{
        //				return true;
        //			}
        //			return false;
        //		}

        //		/// <summary>
        //		/// �����Ƿ��ǲֿ����Ա
        //		/// </summary>
        //		/// <param name="p_LoginID">loginID</param>
        //		/// <returns></returns>
        //		public static bool CheckWHAdmin(string p_LoginID)
        //		{
        //			string sql="SELECT DutyID FROM Data_OP WHERE OPID="+SysString.ToDBString(p_LoginID);
        //			DataTable dt=SysUtils.Fill(sql);
        //			if(SysConvert.ToInt32(dt.Rows[0]["DutyID"])==(int)OPDuty.�ֿ����Ա)
        //			{
        //				return true;
        //			}
        //			return false;
        //		}

        /// <summary>
        /// ����FormListAID�õ��ֿ�����
        /// </summary>
        /// <param name="p_FormListAID">loginID</param>
        /// <returns></returns>
        public static int GetWHTypeByFormListID(int p_FormListBID)
        {
            int p_Type = 0;
            string sql = "SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListBID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                p_Type = SysConvert.ToInt32(dt.Rows[0]["WHTypeID"]);
            }
            return p_Type;
        }

        #endregion

        /// <summary>
        /// ����Grid�б༭״̬�޸ĵ���
        /// </summary>
        /// <param name="p_Grid">Grid</param>
        /// <param name="p_Flag">true/false:�༭/����</param>
        public static void SetGridModifyPrice(GridView p_Grid, string p_FieldName)
        {
            SetGridModifyPrice(p_Grid, new string[1] { p_FieldName });
        }

        /// <summary>
        /// ����Grid�б༭״̬�޸ĵ���
        /// </summary>
        /// <param name="p_Grid">Grid</param>
        /// <param name="p_Flag">true/false:�༭/����</param>
        public static void SetGridModifyPrice(GridView p_Grid, string[] p_FieldName)
        {
            for (int i = 0; i < p_FieldName.Length; i++)
            {
                p_Grid.Columns[p_FieldName[i]].OptionsColumn.ReadOnly = false;
                p_Grid.Columns[p_FieldName[i]].OptionsColumn.AllowEdit = true;
            }
        }

        /// <summary>
        /// ����Grid�б༭״̬�޸ĵ���
        /// </summary>
        /// <param name="p_Grid">Grid</param>
        /// <param name="p_Flag">true/false:�༭/����</param>
        public static void SetGridModifyPrice(GridView p_Grid, string[] p_FieldName, bool bReadOnly, bool bAllowEdit)
        {
            for (int i = 0; i < p_FieldName.Length; i++)
            {
                p_Grid.Columns[p_FieldName[i]].OptionsColumn.ReadOnly = bReadOnly;
                p_Grid.Columns[p_FieldName[i]].OptionsColumn.AllowEdit = bAllowEdit;
            }
        }
        #endregion

        #region Web�����ַ

        /// <summary>
        /// ���Web�����ַ
        /// </summary>
        /// <param name="p_ReportName">������</param>
        /// <param name="p_ReportUrl">���ر���Url</param>
        /// <param name="p_ServerUrl">����Server Url</param>
        public static void GetWebReportUrl(string p_ReportName, out string p_ReportUrl, out string p_ServerUrl)
        {
            p_ReportUrl = string.Empty;
            p_ServerUrl = string.Empty;

            string server = "";
            string url = "";
            //			if(FParamConfig.DBServer.ToUpper()=="LOCALHOST" || FParamConfig.DBServer.ToUpper().IndexOf("HTTSOFT")!=-1)
            //			{
            //				url=@"http://localhost/xnyerpweb/web/wincallrpt/"+p_ReportName;
            //				server=@"http://localhost/xnyerpweb/";
            //			}
            //			else
            //			{
            url = @"http://" + FParamConfig.DBServer + @"/xnyerpweb/web/wincallrpt/" + p_ReportName;
            server = @"http://" + FParamConfig.DBServer + @"/xnyerpweb/";
            //			}

            p_ReportUrl = url;
            p_ServerUrl = server;
        }
        #endregion

        #region �󶨴�ӡEXCEL�������͡�����Դ
        /// <summary>
        /// �󶨵�������ID
        /// </summary>
        public static void BindExcelTypeID(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ExcelType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ����������ID
        /// </summary>
        public static void BindExcelDataType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ExcelDataType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ��Excelģ��
        /// </summary>
        public static void BindExMain(RepositoryItemLookUpEdit p_DrpID, int p_ExcelTypeID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;

            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,ExcelName Name FROM Data_ExMain WHERE 1=1 AND ExcelTypeID=" + p_ExcelTypeID;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��Excelģ��
        /// </summary>
        public static void BindExMain(LookUpEdit p_DrpID, int p_ExcelTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;


            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,ExcelName Name FROM Data_ExMain WHERE 1=1 AND ExcelTypeID=" + p_ExcelTypeID;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ������Դ
        /// </summary>
        public static void BindExcelDataSource(LookUpEdit p_DrpID, int p_ID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_ExDataSource WHERE 1=1";
            sql += " AND ExcelTypeID = " + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        #endregion

        #region ��Ԥ������
        public static void BindWHAlarmType(LookUpEdit p_DrpID, int p_ItemType, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM WH_WHAlarm WHERE 1=1 AND ItemTypeID=" + p_ItemType;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static void BindWHAlarmType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM WH_WHAlarm WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static void BindJXType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM Enum_JXType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// ���ݲֿⵥ�������ͻ����Ʒ����
        /// </summary>
        /// <param name="p_HeadType">�ֿⵥ��������</param>
        /// <returns>��Ʒ����</returns>
        public static int[] GetItemTypeByWHTypeID(int p_WHTypeID)
        {
            int[] outint = new int[0];
            ArrayList al = new ArrayList();
            //string sql = "SELECT ItemTypeID,ItemTypeID2,ItemTypeID3,ItemTypeID4 FROM Enum_WHType WHERE ID=" + p_WHTypeID;
            string sql = "SELECT ItemTypeID FROM Enum_WHType WHERE ID=" + p_WHTypeID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                //for (int i = 0; i <= 3; i++)
                //{
                //    if (SysConvert.ToInt32(dt.Rows[0][i]) != 0)
                //    {
                //        al.Add(SysConvert.ToInt32(dt.Rows[0][i]));
                //    }
                //}
                al.Add(SysConvert.ToInt32(dt.Rows[0][0]));
                outint = new int[al.Count];
                for (int i = 0; i < outint.Length; i++)
                {
                    outint[i] = SysConvert.ToInt32(al[i]);
                }
            }

            return outint;
        }
        /// <summary>
        /// �󶨿ͻ�ҵ��Ա
        /// </summary>
        public static void BindVendorDuty(ComboBoxEdit p_DrpID, string p_VendorID, bool p_ShowBlank)
        {
            //			FCommon.LookupEditColAdd(p_DrpID,new int[2]{50,100},new string[2]{,"Name"},new string[2]{"",""},new bool[2]{false,true});
            string sql = "SELECT Contact FROM Data_Vendor WHERE 1=1 AND VendorID=" + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Contact", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ���ַ
        /// </summary>
        public static void BindVendorAddress(ComboBoxEdit p_DrpID, string p_VendorID, bool p_ShowBlank)
        {
            //			FCommon.LookupEditColAdd(p_DrpID,new int[2]{50,100},new string[2]{,"Name"},new string[2]{"",""},new bool[2]{false,true});
            string sql = "SELECT Address FROM Data_VendorAddress WHERE MainID IN (SELECT ID FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(p_VendorID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Address", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ���ַ
        /// </summary>
        public static void BindVendorHisAddress(ComboBoxEdit p_DrpID, string p_VendorID, bool p_ShowBlank)
        {

            string sql = "SELECT RecAddress FROM Att_GoodsPost WHERE VendorID=" + SysString.ToDBString(p_VendorID);
            sql += " AND RecAddress<>''";
            sql += " group by RecAddress";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "RecAddress", p_ShowBlank);
        }
        ///// <summary>
        ///// �󶨲ֿⵥ�����Ϳͻ�A
        ///// </summary>
        //public static void BindVendorAByFormListID(LookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        //{
        //    BindVendor(p_DrpID, GetVendorATypeByFormListID(p_SubTypeID), p_ShowBlank);
        //}

        ///// <summary>
        ///// ��ÿͻ������б���ݲֿⵥ������A
        ///// </summary>
        ///// <param name="p_SubTypeID"></param>
        ///// <returns></returns>
        //public static int[] GetVendorATypeByFormListID(int p_SubTypeID)
        //{
        //    int[] outint = new int[0];
        //    ArrayList al = new ArrayList();
        //    string sql = "SELECT VendorATypeID,VendorATypeID2,VendorATypeID3 FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_SubTypeID);
        //    DataTable dtTemp = SysUtils.Fill(sql);
        //    if (dtTemp.Rows.Count != 0)
        //    {
        //        for (int i = 0; i < 3; i++)
        //        {
        //            if (SysConvert.ToInt32(dtTemp.Rows[0][i]) != 0)
        //            {
        //                al.Add(SysConvert.ToInt32(dtTemp.Rows[0][i]));
        //            }
        //        }
        //        outint = new int[al.Count];
        //        for (int i = 0; i < outint.Length; i++)
        //        {
        //            outint[i] = SysConvert.ToInt32(al[i]);
        //        }
        //    }

        //    return outint;
        //}
        /// <summary>
        /// ��������ת��Ϊ��ѯ�ַ���
        /// </summary>
        /// <param name="p_Int"></param>
        /// <returns></returns>
        public static string ConvertArrayIntToStr(int[] p_Int)
        {
            string outstr = string.Empty;
            for (int i = 0; i < p_Int.Length; i++)
            {
                if (outstr != string.Empty)
                {
                    outstr += ",";
                }
                outstr += p_Int[i].ToString();
            }
            return outstr;
        }
        /// <summary>
        /// �ַ�������(�����֣�ת��Ϊ��ѯ�ַ���
        /// </summary>
        /// <param name="p_Int"></param>
        /// <returns></returns>
        public static string ConvertArrayIntToStr(string[] p_Str)
        {
            string outstr = string.Empty;
            for (int i = 0; i < p_Str.Length; i++)
            {
                if (outstr != string.Empty)
                {
                    outstr += ",";
                }
                outstr += p_Str[i].ToString();
            }
            return outstr;
        }
        /// <summary>
        /// �ַ�������(���֡���ĸ��ת��Ϊ��ѯ�ַ���
        /// </summary>
        /// <param name="p_Int"></param>
        /// <returns></returns>
        public static string ConvertArrayStringToStr(string[] p_Str)
        {
            string outstr = string.Empty;
            for (int i = 0; i < p_Str.Length; i++)
            {
                if (outstr != string.Empty)
                {
                    outstr += ",";
                }
                outstr += SysString.ToDBString(p_Str[i]);
            }
            return outstr;
        }
        ///// <summary>
        ///// �󶨲ֿⵥ�����Ϳͻ�A
        ///// </summary>
        //public static void BindVendorAByFormListID(RepositoryItemLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        //{
        //    BindVendor(p_DrpID, GetVendorATypeByFormListID(p_SubTypeID), p_ShowBlank);
        //}
        #endregion

        #region FastReport����
        /// <summary>
        /// �󶨲˵���Ŀ¼
        /// </summary>
        public static void BindParentForm(LookUpEdit p_DrpID, int parentID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "select * from Sys_WindowMenu where ParentID = " + parentID + " and HttFlag = 0 and ShowFlag = 1 order by Sort";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        ///// <summary>
        ///// ����Ŀ¼����
        ///// </summary>
        //public static void BindWinList(LookUpEdit p_DrpID, int parentID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "select Enum_WinList.ID,Enum_WinList.Name from Sys_WindowMenu " +
        //        "inner join Enum_WinList on Sys_WindowMenu.WinListID = Enum_WinList.ID where Sys_WindowMenu.ParentID = " + parentID +
        //        " and Sys_WindowMenu.HttFlag = 0 and Sys_WindowMenu.ShowFlag = 1 order by Sys_WindowMenu.Sort";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        //}

        /// <summary>
        /// ����Ŀ¼����
        /// </summary>
        public static void BindWinList(LookUpEdit p_DrpID, int parentID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "AllName" }, new string[2] { "����", "����" }, new bool[2] { false, true });

            string sql = "SELECT ID,Name AS AllName FROM UV1_Sys_WindowMenu WHERE (ParentID=" + parentID + " AND ISNULL(HttFlag,0) = 0) OR (ParentID IN(SELECT ID  FROM UV1_Sys_WindowMenu WHERE ParentID=" + parentID + "  AND ISNULL(HttFlag,0) = 0)   AND ISNULL(HttFlag,0) = 0)";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "AllName", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ����Ŀ¼����
        /// </summary>
        public static void BindWinList(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "AllName" }, new string[2] { "����", "����" }, new bool[2] { false, true });
            string sql = "select ID, " +
                         " CASE WHEN ISNULL(Name,'') <> '' THEN Name WHEN" +
                         " ISNULL(Name ,'') = '' THEN WinName END AS AllName " +
                         " from UV1_Sys_WindowMenu " +
                         " where ParentID <> 0" +
                         " and HttFlag = 0  order by Sort";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "AllName", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨱���
        /// </summary>
        public static int BindReport(LookUpEdit p_DrpID, int formID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "ReportName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,ReportName FROM dbo.Data_ReportManage where WinListID = " + formID + " order by Seq";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ReportName", "ID", p_ShowBlank);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["ID"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// �󶨱�������
        /// </summary>
        public static int BindReport(RepositoryItemLookUpEdit p_DrpID, int formID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where WinListID = " + formID + " order by Seq";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "ReportName", "ID", p_ShowBlank);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToInt32(dt.Rows[0]["ID"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// �󶨱�������
        /// </summary>
        public static void BindReport(DevComponents.DotNetBar.ComboBoxItem p_DrpID, int formID, bool p_ShowBlank)
        {
            string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where WinListID = " + formID + " order by Seq";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropDNBarComb(p_DrpID, dt, "ID", "ReportName", p_ShowBlank);
            if (dt.Rows.Count > 0)
            {
                if (p_ShowBlank)
                {
                    p_DrpID.SelectedIndex = 1;
                }
                else
                {
                    p_DrpID.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// �󶨱���ģ������
        /// </summary>
        public static void BindReportModel(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "FileName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT FileName,ID FROM dbo.Data_ReportFileModel  order by ID ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FileName", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨱���ģ������
        /// </summary>
        public static void BindReport(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FileName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT FileName,ID FROM dbo.Data_ReportFile order by ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FileName", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ȡ����·��
        /// </summary>
        public static string GetReportTemplate(int id)
        {
            string sql = "SELECT * FROM dbo.Data_ReportManage where ID = " + id;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Url"].ToString() + dt.Rows[0]["FileName"].ToString();
            }
            return "";
        }

        /// <summary>
        /// �󶨱�����������
        /// </summary>
        public static void BindReportSource(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "Code", "Name" }, new string[] { "����", "����" }, new bool[] { true, true });
            string sql = "select * from Enum_ReportSource order by ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        #endregion

        #region ����
        /// <summary>
        ///�󶨲��񵥾�����
        /// </summary>
        public static void BandCaiWuFormType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_CaiWuFormType WHERE 1=1 AND UseableFlag in (1,2) ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        ///�󶨲��񵥾�����
        /// </summary>
        public static void BandCaiWuFormPayType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_CaiWuFormType WHERE 1=1 AND UseableFlag in (1) ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        ///�󶨲��񵥾�����
        /// </summary>
        public static void BandCaiWuFormRecType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_CaiWuFormType WHERE 1=1 AND UseableFlag in (2) ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        ///��ȡҵ��Աĳ����ҵ����ϴν����ֹ����
        /// </summary>
        public static string GetJieSuanEndDate(string saleOPID, string currencyID)
        {
            string sql = "SELECT max(EDate) as EDate FROM CaiWu_SaleCost WHERE SaleOPID =" + SysString.ToDBString(saleOPID) +
                " AND CurrencyID=" + SysString.ToDBString(currencyID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["EDate"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///��ȡĳ����ҵ����ϱ��տ�����¼
        /// </summary>
        public static DataTable GetLastRecJieSuan(string currencyID)
        {
            string sql = "";
            if (currencyID != "")
            {
                sql = "SELECT * FROM CaiWu_RecJieSuan WHERE EDate = (SELECT max(EDate) as EDate FROM CaiWu_RecJieSuan WHERE CurrencyID=" + SysString.ToDBString(currencyID) + ")";
            }
            else
            {
                sql = "SELECT * FROM CaiWu_RecJieSuan WHERE EDate = (SELECT max(EDate) as EDate FROM CaiWu_RecJieSuan)";
            }

            return SysUtils.Fill(sql);
        }

        /// <summary>
        ///��ȡĳ����ҵ����ϱʸ�������¼
        /// </summary>
        public static DataTable GetLastPayJieSuan(string currencyID)
        {
            string sql = "";
            if (currencyID != "")
            {
                sql = "SELECT * FROM CaiWu_PayJieSuan WHERE EDate = (SELECT max(EDate) as EDate FROM CaiWu_PayJieSuan WHERE CurrencyID=" + SysString.ToDBString(currencyID) + ")";
            }
            else
            {
                sql = "SELECT * FROM CaiWu_PayJieSuan WHERE EDate = (SELECT max(EDate) as EDate FROM CaiWu_PayJieSuan)";
            }

            return SysUtils.Fill(sql);
        }

        /// <summary>
        ///��ȡĳ����ҵ����ϴν����ֹ����
        /// </summary>
        public static string GetPayJieSuanEndDate(string currencyID)
        {
            string sql = "SELECT max(EDate) as EDate FROM CaiWu_PayJieSuan WHERE CurrencyID=" + SysString.ToDBString(currencyID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["EDate"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///���ҵ��Աĳ����ҵ����ڵ�ǰ�����Ƿ��Ѿ������
        /// </summary>
        public static bool CheckJieSuanDate(DateTime dataTime, string saleOPID, string currencyID)
        {
            string sql = "SELECT * FROM CaiWu_SaleCost WHERE SaleOPID =" + SysString.ToDBString(saleOPID) +
                " AND CurrencyID=" + SysString.ToDBString(currencyID) + " AND " + dataTime + " BETWEEN SDate and EDate";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region �󶨿��ô�ӡ��
        public static void BindPrinterList(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//��ȡĬ�ϵĴ�ӡ���� 
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            //���б�����г����еĴ�ӡ��, 
            {
                p_DrpID.Properties.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)//��Ĭ�ϴ�ӡ����Ϊȱʡֵ 
                //��������� www.mscto.com
                {
                    p_DrpID.SelectedIndex = p_DrpID.Properties.Items.IndexOf(strPrinter);
                    prtdoc.PrinterSettings.PrinterName = strPrinter;
                }
            }
            p_DrpID.SelectedIndexChanged += new System.EventHandler(drpPrinter_SelectedIndexChanged);
        }
        private static void drpPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit p_DrpID = (ComboBoxEdit)sender;
            if (p_DrpID.SelectedText != string.Empty)
            {
                PrintDocument prtdoc = new PrintDocument();
                prtdoc.PrinterSettings.PrinterName = p_DrpID.SelectedText;
            }
        }
        #endregion

        #region �󶨽�������״̬
        /// <summary>
        /// �󶨽�������״̬
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDeliveryDataStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_DeliveryDataStatus";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨽�������״̬
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDeliveryDataStatus(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = true;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_DeliveryDataStatus";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        #endregion

        #region ȫ�ǰ��ת��
        /// <summary>
        /// תȫ�ǵĺ���(SBC case)
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <returns>ȫ���ַ���</returns>
        ///<remarks>
        ///ȫ�ǿո�Ϊ12288����ǿո�Ϊ32
        ///�����ַ����(33-126)��ȫ��(65281-65374)�Ķ�Ӧ��ϵ�ǣ������65248
        ///</remarks>
        public static string ToSBC(string input)
        {
            //���תȫ�ǣ�
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }


        /// <summary> ת��ǵĺ���(DBC case) </summary>
        /// <param name="input">�����ַ���</param>
        /// <returns>����ַ���</returns>
        ///<remarks>
        ///ȫ�ǿո�Ϊ12288����ǿո�Ϊ32
        ///�����ַ����(33-126)��ȫ��(65281-65374)�Ķ�Ӧ��ϵ�ǣ������65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region δ����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_CHK"></param>
        /// <returns></returns>
        public static string GetList(CheckedListBoxControl p_CHK)
        {
            string strBL = "";
            for (int i = 0; i < p_CHK.ItemCount; i++)
            {
                if (p_CHK.GetItemCheckState(i) == CheckState.Checked)
                {
                    if (strBL != "")//������Ϊ��
                    {
                        strBL += ",";
                    }
                    strBL += p_CHK.GetItemValue(i);
                }
            }
            return strBL;
        }

        /// <summary>
        /// ��ʾCheckedListBoxControl��
        /// </summary>
        /// <param name="strXZBL"></param>
        public static void SetList(string strXZBL, CheckedListBoxControl p_CHK)
        {
            for (int i = 0; i < p_CHK.ItemCount; i++)
            {
                p_CHK.SetItemCheckState(i, CheckState.Unchecked);
            }
            if (strXZBL != "")
            {
                string[] temppsbla = new string[] { };
                temppsbla = strXZBL.Split(',');
                for (int j = 0; j < temppsbla.Length; j++)
                {
                    for (int i = 0; i < p_CHK.ItemCount; i++)
                    {
                        if (temppsbla[j] == p_CHK.GetItemValue(i).ToString())
                        {
                            p_CHK.SetItemCheckState(i, CheckState.Checked);
                            break;
                        }
                    }
                }
            }
        }

        /// ִ��DataTable�еĲ�ѯ�����µ�DataTable
        /// </summary>
        /// <param name="dt">Դ����DataTable</param>
        /// <param name="condition">��ѯ����</param>
        /// <param name="sortstr">��������</param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition, string sortstr)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition, sortstr);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//���صĲ�ѯ���
        }

        /// <summary>
        /// ��װ���Ϲ�������
        /// </summary>
        /// <param name="ItemCode1"></param>
        /// <param name="ItemCode2"></param>
        /// <param name="ItemCode3"></param>
        /// <returns></returns>
        public static string GetItemCodeToStr(string ItemCode1, string ItemCode2, string ItemCode3)
        {
            string StrItemCode = "";
            if (ItemCode1 != "")
            {
                StrItemCode += "'" + ItemCode1 + "'";
            }
            if (ItemCode2 != "")
            {
                if (StrItemCode == "")
                {
                    StrItemCode += "'" + ItemCode2 + "'";
                }
                else
                {
                    StrItemCode += ",'" + ItemCode2 + "'";
                }
            }
            if (ItemCode3 != "")
            {
                if (StrItemCode == "")
                {
                    StrItemCode += "'" + ItemCode3 + "'";
                }
                else
                {
                    StrItemCode += ",'" + ItemCode3 + "'";
                }
            }
            return StrItemCode;
        }
        /// <summary>
        /// ��װԭ������
        /// </summary>
        /// <param name="ItemCode1"></param>
        /// <param name="ItemCode2"></param>
        /// <param name="ItemCode3"></param>
        /// <param name="ItemCode4"></param>
        /// <param name="ItemCode5"></param>
        /// <param name="ItemCode6"></param>
        /// <returns></returns>
        public static string GetItemCodeToStr(string ItemCode1, string ItemCode2, string ItemCode3, string ItemCode4, string ItemCode5, string ItemCode6)
        {
            string StrItemCode = "";
            if (ItemCode1 != "")
            {
                StrItemCode += "'" + ItemCode1 + "'";
            }
            if (ItemCode2 != "")
            {
                if (StrItemCode == "")
                {
                    StrItemCode += "'" + ItemCode2 + "'";
                }
                else
                {
                    StrItemCode += ",'" + ItemCode2 + "'";
                }
            }
            if (ItemCode3 != "")
            {
                if (StrItemCode == "")
                {
                    StrItemCode += "'" + ItemCode3 + "'";
                }
                else
                {
                    StrItemCode += ",'" + ItemCode3 + "'";
                }
            }
            if (ItemCode4 != "")
            {
                if (StrItemCode == "")
                {
                    StrItemCode += "'" + ItemCode4 + "'";
                }
                else
                {
                    StrItemCode += ",'" + ItemCode4 + "'";
                }
            }
            if (ItemCode5 != "")
            {
                if (StrItemCode == "")
                {
                    StrItemCode += "'" + ItemCode5 + "'";
                }
                else
                {
                    StrItemCode += ",'" + ItemCode5 + "'";
                }
            }
            if (ItemCode6 != "")
            {
                if (StrItemCode == "")
                {
                    StrItemCode += "'" + ItemCode6 + "'";
                }
                else
                {
                    StrItemCode += ",'" + ItemCode6 + "'";
                }
            }
            return StrItemCode;
        }

        /// <summary>
        /// ��ȡGridView���������ݼ�
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static DataTable PrintDataTable(GridView gridView)
        {
            DataTable dtin = new DataTable();
            try
            {

                string exportfile = string.Empty;
                string strSort = "";
                foreach (DevExpress.XtraGrid.Columns.GridColumnSortInfo gcsi in gridView.SortInfo)
                {
                    strSort += gcsi.Column.FieldName.ToString();
                    switch (gcsi.SortOrder.ToString())
                    {
                        case "Ascending":
                            strSort += " ASC,";
                            break;
                        case "Descending":
                            strSort += " DESC,";
                            break;
                    }
                }
                if (strSort != "")
                {
                    strSort = strSort.Remove(strSort.Length - 1, 1);
                }
                DataTable dt = (DataTable)gridView.GridControl.DataSource;
                DataRow[] Total = dt.Select(gridView.ActiveFilter.Expression, strSort);


                dtin = dt.Clone();
                foreach (DataRow dr in Total)
                {

                    dtin.ImportRow(dr);
                }

                return dtin;

            }
            catch (Exception E)
            {
                return dtin;
            }
        }

        public static DataTable PrintDataTable(GridView gridView, string FileName, string Value)
        {
            DataTable dtin = new DataTable();
            try
            {

                string exportfile = string.Empty;
                string strSort = string.Empty;
                foreach (DevExpress.XtraGrid.Columns.GridColumnSortInfo gcsi in gridView.SortInfo)
                {
                    strSort += gcsi.Column.FieldName.ToString();
                    switch (gcsi.SortOrder.ToString())
                    {
                        case "Ascending":
                            strSort += " ASC,";
                            break;
                        case "Descending":
                            strSort += " DESC,";
                            break;
                    }
                }
                if (strSort != "")
                {
                    strSort = strSort.Remove(strSort.Length - 1, 1);
                }
                DataTable dt = (DataTable)gridView.GridControl.DataSource;
                DataRow[] Total = dt.Select(gridView.ActiveFilter.Expression, strSort);
                dtin = dt.Clone();
                foreach (DataRow dr in Total)
                {
                    if (SysConvert.ToString(dr[FileName]) == Value)
                    {
                        dtin.ImportRow(dr);
                    }
                }
                return dtin;

            }
            catch (Exception E)
            {
                return dtin;
            }
        }
        /// <summary>
        /// ��λ������2λС����ʼ�ս�λ
        /// </summary>
        /// <param name="value">��ֵ</param>
        /// <param name="p_number">����λ��</param>
        /// <returns>��ֵ</returns>
        public static decimal GetNewNum(decimal p_value, int p_number)
        {
            #region ȡ�����ӵ�ֵ
            string lastvalue = "0.";
            for (int i = 1; i < p_number; i++)
            {
                lastvalue += "0";
            }
            lastvalue += "1";
            #endregion

            string temp = SysConvert.ToString(p_value);

            string[] value = temp.Split(new char[] { '.' });//�����������ֺ�С������

            if (value.Length > 1)//�Ƿ���С����
            {

                if (value[1].Length > p_number)//С�����ִ�����λ
                {

                    string tempA = value[1].Substring(p_number, value[1].Length - p_number);//ȡ��С������ȥ��ǰ��λ�󣬿�����Ƿ����0�������0ֱ��ʡ��
                    if (SysConvert.ToDecimal(tempA) < 1)
                        value[1] = value[1].Substring(0, p_number);
                    if (value[1].Length == 2)
                    {

                        value[1] = value[1].Substring(0, p_number);
                        decimal r_value = SysConvert.ToDecimal(value[0]) + SysConvert.ToDecimal("0." + value[1]);
                        return r_value;
                    }
                    else
                    {
                        value[1] = value[1].Substring(0, p_number);
                        value[1] = "0." + value[1];
                        decimal r_value = SysConvert.ToDecimal(value[0]) + SysConvert.ToDecimal(value[1]) + SysConvert.ToDecimal(lastvalue);
                        return r_value;
                    }

                }
                else
                {
                    return p_value;
                }
            }
            else
            {//������С������
                return p_value;
            }
        }
        #endregion

        #region  ���gridView��ʾ���ݵ�DataTable
        /// <summary>
        /// ���gridView��ʾ���ݵ�DataTable
        /// </summary>
        /// <param name="gridView1"></param>
        /// <returns>�����쳣���ؿձ�</returns>
        /// 2010-7-10
        public static DataTable GridViewToDataTable(DevExpress.XtraGrid.Views.Grid.GridView gridView1)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = (DataTable)gridView1.GridControl.DataSource;
                dt.DefaultView.RowFilter = gridView1.RowFilter;
                string strSort = string.Empty;
                foreach (DevExpress.XtraGrid.Columns.GridColumnSortInfo gcsi in gridView1.SortInfo)
                {
                    strSort += gcsi.Column.FieldName.ToString();
                    switch (gcsi.SortOrder.ToString())
                    {
                        case "Ascending":
                            strSort += " ASC,";
                            break;
                        case "Descending":
                            strSort += " DESC,";
                            break;
                    }
                }
                if (strSort != "")
                {
                    strSort = strSort.Remove(strSort.Length - 1, 1);
                }
                dt.DefaultView.Sort = strSort;
                dt = dt.DefaultView.ToTable();
                return dt;
            }
            catch (Exception E)
            {
                return dt;
            }
        }

        #endregion

        #region  ��õ�Ԫ���ֵ
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static string GetCellValue(DevExpress.XtraGrid.Views.Grid.GridView gridView, string p_FieldName)
        {
            string outStr = string.Empty;
            outStr = SysConvert.ToString(gridView.GetRowCellValue(gridView.FocusedRowHandle, p_FieldName));
            return outStr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="p_RowHandle"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static string GetCellValue(DevExpress.XtraGrid.Views.Grid.GridView gridView, int p_RowHandle, string p_FieldName)
        {
            string outStr = string.Empty;
            outStr = SysConvert.ToString(gridView.GetRowCellValue(p_RowHandle, p_FieldName));
            return outStr;
        }

        #endregion

        #region ������
        /// <summary>
        /// �����ݱ�Ĳ�ѯ
        /// </summary>
        /// <param name="dt">���ݱ�</param>
        /// <param name="strFilter">����</param>
        /// <returns></returns>
        public static DataTable TableQuery(DataTable dt, string strFilter)
        {
            DataTable table = new DataTable();
            if (dt != null)
            {
                table = dt.Clone();
                DataRow[] row = dt.Select(strFilter, "", DataViewRowState.CurrentRows);
                foreach (DataRow dr in row)
                {
                    table.ImportRow(dr);
                }
            }
            return table;
        }

        /// ���ַ���"0"�滻Ϊ""
        /// </summary>
        /// <param name="p_Value"></param>
        /// <returns></returns>
        public static string TrimZero(string p_Value)
        {
            if (p_Value != "0")
            {
                return p_Value;
            }
            return string.Empty;
        }

        public static string GetWHNM(string p_WHID)
        {
            string WHNM = string.Empty;
            if (p_WHID != "")
            {
                string sql = "SELECT WHNM FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);

                DataTable dt = SysUtils.Fill(sql);
                if (dt != null)
                {
                    WHNM = dt.Rows[0][0].ToString();
                }
            }
            return WHNM;
        }

        public static DateTime GetWorkDays(DateTime p_Date)
        {
            if (!CheckHoliday(p_Date))//���ǽڼ��գ�ֱ�ӷ���ԭֵ
            {
                return p_Date;
            }
            DateTime temp = p_Date.Date;

            while (CheckHoliday(temp))
            {
                temp = temp.AddDays(1);
                if (!CheckHoliday(temp) && temp.Month == p_Date.Month && temp.Year == p_Date.Year)
                {
                    return temp;
                }
                if (temp.Month > p_Date.Month || temp.Year > p_Date.Year)
                {
                    temp = p_Date.Date;
                    break;
                }
            }

            while (CheckHoliday(temp))
            {
                temp = temp.AddDays(-1);
                if (!CheckHoliday(temp) && temp.Month == p_Date.Month && temp.Year == p_Date.Year)
                {
                    return temp;
                }
            }
            return p_Date;
        }

        private static bool CheckHoliday(DateTime p_Date)
        {

            string sql = "SELECT FreeDate FROM Data_PlanHoliday WHERE FreeDate=" + SysString.ToDBString(p_Date.ToString("yyyy-MM-dd"));
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ����0417
        /// <summary>
        /// �󶨿ͻ���ˮ�ŵ���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFNCV(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM Enum_FNCV WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿�Ʊ����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindKPType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM Enum_KPType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���ո�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindRecPayType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM Enum_RecPayType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨵��ݺ���Դ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFormNoType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM Enum_FormNoType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static string GetWeightUnit(string p_ItemCode)
        {
            string sql = "SELECT WeightUnit FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
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
        /// �󶨳���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindVendorID(LookUpEdit p_DrpID, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100 }, new string[] { "VendorID" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT VendorID,VendorID FROM Data_Vendor WHERE 1=1 ";
            sql += p_Condition;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "VendorID", "VendorID", p_ShowBlank);
        }

        /// <summary>
        /// �����ϴ���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMLDL(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT Code,Name FROM Data_MLDL WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        /// <summary>
        /// �����ϴ���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMLDL(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 100 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT Code,Name FROM Data_MLDL WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// �����ϴ���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMLDL(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {

            string sql = "SELECT Code FROM Data_MLDL WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Code", p_ShowBlank);
        }
        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMLLB(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT Code,Name FROM Data_MLLB WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMLLB(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 100 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT Code,Name FROM Data_MLLB WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMLLB(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {

            string sql = "SELECT Code FROM Data_MLLB WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Code", p_ShowBlank);
        }

        ///// <summary>
        ///// �󶨳���
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static void BindVendorID(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        //{

        //    string sql = "SELECT VendorID FROM Data_Vendor WHERE 1=1 ";
        //    sql += " AND VendorID IN ( SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(" + SysString.ToDBString((int)EnumVendorType.���Ϲ�Ӧ��) + "))";
        //    //sql+="VendorTypeID=" + SysString.ToDBString((int)EnumVendorType.���Ϲ�Ӧ��);

        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropComb(p_DrpID, dt, "VendorID", p_ShowBlank);
        //}
        /// <summary>
        /// ����Ʒ����
        /// </summary>
        public static void BindItemClass(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_ItemClass";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindNeedle(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {

            string sql = "SELECT Name FROM Enum_Needle WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        }


        /// <summary>
        /// �󶨼���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindSeason(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, "Sale_QuotedPrice", "Season", p_ShowBlank);
        }

        /// <summary>
        /// ��ͼƬ����
        /// </summary>
        public static void BindPicNum(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_PicNum";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ����Ա
        /// </summary>
        public static void BindDOP(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE UseableFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindDVendorType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_VendorType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹Ұ�״̬
        /// </summary>
        public static void BindGBStatus(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_GBStatus WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹Ұ�״̬
        /// </summary>
        public static void BindGBStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_GBStatus WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨵���״̬
        /// </summary>
        public static void BindDYStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_DYStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨹Ұ�������
        /// </summary>
        public static void BindGBCode(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "GBCode" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,GBCode FROM  Dev_GBJCDts WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "GBCode", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶�������
        /// </summary>
        public static void BindOrderType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_OrderType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨶����ȼ�
        /// </summary>
        public static void BindOrderLevel(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_OrderLevel WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶���״̬
        /// </summary>
        public static void BindOrderStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_OrderStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶���״̬
        /// </summary>
        public static void BindOrderStatus2(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_OrderStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Name", p_ShowBlank);
        }

        /// <summary>
        /// �󶨸��ʽ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindPayMethod(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {

            string sql = "SELECT Name FROM Data_PayMethod WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        }

        public static void BindPayMethod(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_PayMethod WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹Ұ�״̬
        /// </summary>
        public static void BindPayDateType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_PayDateType WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨸���׶ζ���
        /// </summary>
        public static void BindPayStepType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_PayStepType WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨹Ұ�ɫ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindGBColorNum(ComboBoxEdit p_DrpID, int p_ID, bool p_ShowBlank)
        {

            string sql = "SELECT ColorNum FROM Data_ItemColorDts WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "ColorNum", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹Ұ�ɫ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindGBColorName(ComboBoxEdit p_DrpID, int p_ID, bool p_ShowBlank)
        {

            string sql = "SELECT ColorName FROM Data_ItemColorDts WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "ColorName", p_ShowBlank);
        }
        /// <summary>
        /// �󶨺�ͬ����
        /// </summary>
        public static void BindSOContext(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_SOContext WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨺�ͬ����
        /// </summary>
        /// <param name="p_DrpID">Ҫ�󶨵Ŀؼ�</param>
        /// <param name="SOContentType">�󶨺�ͬ���� ��:���ۣ��ɹ����ӹ�</param>
        /// <param name="p_ShowBlank"></param>
        public static void BindSOContext(LookUpEdit p_DrpID, string SOContentType, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_SOContext WHERE 1=1";
            sql += " AND Type=" + SysString.ToDBString(SOContentType);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹Ұ�ɫ��
        /// </summary>
        public static void BindGBColorNum(LookUpEdit p_DrpID, int p_ID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ColorNum", "ColorNum" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ColorNum,ColorNum FROM Data_SOContext WHERE MainID=" + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ColorNum", "ColorNum", p_ShowBlank);
        }

        /// <summary>
        /// �󶨼�����λ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindEnumUnit(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_Unit";
            sql += " WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Name", p_ShowBlank);
        }

        /// <summary>
        /// �󶨼�����λ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindEnumUnit(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {

            string sql = "SELECT ID,Name FROM Enum_Unit";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        }
        /// <summary>
        /// ��ԭ�ϱ���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindDtsItemCode(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT Code,Name FROM Data_MLYL";
            sql += " WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Code", p_ShowBlank);
        }

        /// <summary>
        /// ��ԭ�ϳɷ�
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindDtsItemName(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT Code,Name FROM Data_MLYL";
            sql += " WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Name", p_ShowBlank);
        }

        /// <summary>
        /// ��ԭ�ϳɷ�
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindItemName(RepositoryItemComboBox p_DrpID, string p_Name, bool p_ShowBlank)
        {
            string sql = "SELECT Code,Name FROM Data_MLYL";
            sql += " WHERE 1=1 AND Name LIKE " + SysString.ToDBString("%" + p_Name + "%");
            if (p_Name != "")
            {
                sql += " AND Name LIKE " + SysString.ToDBString("%" + p_Name + "%");
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Name", p_ShowBlank);
        }
        /// <summary>
        /// ���������
        /// </summary>
        public static void BindMLLB(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT Code,Name FROM Data_MLLB WHERE 1=1 AND UseableFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "Code";
            p_DrpID.DisplayMember = "Name";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
        }

        /// <summary>
        /// ��Ӫ����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindYXD(ComboBoxEdit p_DrpID, string p_VendorID, bool p_ShowBlank)
        {

            string sql = "SELECT ID,DtsAddress FROM UV1_Data_VendorDesDts WHERE 1=1";
            if (p_VendorID != "")
            {
                sql += " AND VendorID=" + SysString.ToDBString(p_VendorID);
            }
            sql += " AND DtsAddress<>''";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "DtsAddress", p_ShowBlank);
        }

        ///// <summary>
        /// �󶨲ֿ�
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindDefaultWH(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHNM FROM WH_WH WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        ///// <summary>
        /// �󶨷�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindCPType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_CPType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        ///// <summary>
        /// �����ۺ�ͬվ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindOrderStep(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_OrderStep WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        ///// <summary>
        /// �����ۺ�ͬվ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindOrderStep(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_OrderStep WHERE ID<>0 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        ///// <summary>
        ///// ��������������
        ///// </summary>
        //public static void BindFollow(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.ShowHeader = false;
        //    p_DrpID.ShowFooter = false;
        //    FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT ID,Name FROM Data_Follow WHERE 1=1 ORDER BY Sort";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        //}
        /// <summary>
        /// ��ϵͳ��׼��������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFormType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_BuyFormType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶�����Ϣ��Դ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMSGSource(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM SMS_MSGSource WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ���ش�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindLoadFormType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name+'--'+Remark Name FROM Enum_LoadFormType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �����ͻ���Դ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFHForType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_FHForType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";//��ѯδɾ����
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶��˷�ʽ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindCheckMethodType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM Enum_CheckMethodType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���ͻ�����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFHType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Name" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Name FROM Enum_FHType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindNum(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 150 }, new string[] { "Seq" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT ID,Seq FROM Data_Num WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Seq", "Seq", p_ShowBlank);
        }

        /// <summary>
        /// ��ʾ�ͻ�ȫ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_VendorTypeID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindVendor2(LookUpEdit p_DrpID, int p_VendorTypeID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "VendorID", "VendorName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT VendorID,VendorName FROM Data_Vendor WHERE 1=1";
            sql += " AND VendorID IN ( SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(" + SysString.ToDBString(p_VendorTypeID) + "))";
            //sql += " AND VendorTypeID=" + SysString.ToDBString(p_VendorTypeID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "VendorName", "VendorID", p_ShowBlank);
        }

        /// <summary>
        /// ���ݿͻ��ı�ŵõ��ͻ���ַ
        /// </summary>
        /// <param name="p_VendorID"></param>
        /// <returns></returns>
        public static string GetVendorAddress(string p_VendorID)
        {
            string sql = "SELECT Address FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                return SysConvert.ToString(dt.Rows[0][0]);
            }
            return string.Empty;
        }
        /// <summary>
        /// ���ݿͻ������ÿͻ�����
        /// </summary>
        public static string GetVenorNameByID(string p_VendorID)
        {
            string outstr = "";
            string sql = "SELECT VendorName FROM Data_Vendor WHERE VendorID = " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr += SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }

        /// <summary>
        /// ���ݿͻ������ÿͻ����
        /// </summary>
        public static string GetAttnVenorID(string p_VendorID)
        {
            string outstr = "";
            string sql = "SELECT VendorAttn FROM Data_Vendor WHERE VendorID = " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr += SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }
        /// <summary>
        /// �󶨲�����Ŀ
        /// </summary>
        public static void BindCSBGItem(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Data_CSBGItem WHERE 1=1 AND UseableFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "ID";
            p_DrpID.DisplayMember = "Name";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
        }

        /// <summary>
        /// �󶨲�����Ŀ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindCheckItem(RepositoryItemComboBox p_DrpID, string p_Outstr, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Data_CSBGItemDts";
            sql += " WHERE 1=1";
            if (p_Outstr != "")
            {
                sql += " AND MainID IN(" + p_Outstr + ") ORDER BY MainID";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Name", p_ShowBlank);
        }


        /// <summary>
        /// �󶨶��˱�־
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_VendorTypeID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindDZFlag(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_DZFlag WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨼��زֿ�����
        /// </summary>
        public static void BindTHWHLoad(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1 AND ParentID<>0";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "ID";
            p_DrpID.DisplayMember = "FormNM";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
        }

        /// <summary>
        /// ��������������
        /// </summary>
        public static void BindFollow(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_Follow WHERE 1=1 ORDER BY Sort";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_VendorTypeID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFollow(LookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_Follow WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static void BindItemSalePrice(RepositoryItemComboBox p_DrpID, string p_ItemCode, string p_GoodsCode, string p_ColorNum, string p_ColorName, bool p_ShowBlank)
        {
            string sql = "SELECT ID,SalePrice FROM Data_ItemColorDtsHis WHERE MainID IN (SELECT ID FROM  UV1_Data_ItemColorDts WHERE 1=1";
            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
            sql += " AND GoodsCode=" + SysString.ToDBString(p_GoodsCode);
            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
            sql += " )";
            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "SalePrice", p_ShowBlank);
        }

        public static void BindItemBuyPrice(RepositoryItemComboBox p_DrpID, string p_ItemCode, string p_GoodsCode, string p_ColorNum, string p_ColorName, bool p_ShowBlank)
        {
            string sql = "SELECT ID,BuyPrice FROM Data_ItemColorDtsHis WHERE MainID IN (SELECT ID FROM  UV1_Data_ItemColorDts WHERE 1=1";
            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
            sql += " AND GoodsCode=" + SysString.ToDBString(p_GoodsCode);
            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
            sql += " AND ColorName=" + SysString.ToDBString(p_ColorName);
            sql += " )";
            sql += " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "BuyPrice", p_ShowBlank);
        }

        /// <summary>
        /// �����۱�ǩ
        /// </summary>
        public static void BindInfoType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_InfoType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static void BindPayStepType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_PayStepType  WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        #endregion

        #region  �����䵥λ  ����÷��� 2012 .05.02
        public static void BindTransComID(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT TransComID FROM Att_GoodsTrans WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "TransComID", "ID", p_ShowBlank);
        }
        #endregion

        /// <summary>
        /// ��FastReport�����б�
        /// </summary>
        /// <param name="?"></param>
        /// <param name="FormListAID"></param>
        public static void BindFastReportList(LookUpEdit p_box, int p_WinListID, int p_Seq)
        {
            string sql = string.Empty;
            sql += " SELECT ID,ReportName FROM Data_ReportManage WHERE WinListID=" + p_WinListID;

            sql += " AND Seq=" + p_Seq;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LookupEditColAdd(p_box, new int[1] { 100 }, new string[1] { "ReportName" }, new string[1] { "" }, new bool[1] { true });

            FCommon.LoadDropLookUP(p_box, dt, "ReportName", "ID", false);

            if (dt.Rows.Count != 0)
            {
                p_box.EditValue = SysConvert.ToInt32(dt.Rows[0]["ID"]);

            }
        }


        /// <summary>
        /// �󶨱�������
        /// </summary>
        public static void BindFastReportList(RepositoryItemComboBox p_DrpID, int FormID, int FormAID, int FormBID)
        {
            if (FormID != 0)
            {
                string sql = "SELECT ReportName,ID FROM dbo.Data_ReportManage where ";//WinListID = " +  FormID.ToString() + "

                sql += " WinListID=" + FormID;
                sql += " AND HeadTypeID=" + FormAID;
                sql += " AND SubTypeID=" + FormBID;
                sql += " ORDER BY Seq";
                DataTable dt = SysUtils.Fill(sql);
                FCommon.LoadDropRepositoryComb(p_DrpID, dt, "ReportName", "ID", true);

            }
        }
        #region ��ʼ����˾����Ϣ
        public static void InitCompanyType()
        {
            string sql = "";
            sql += " SELECT ID FROM Enum_CompanyType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            //if (dt.Rows.Count != 1)
            //{
            //    throw new Exception("��˾����Ϣ������������ϵ����Ա");
            //}
            ParamConfig.CompanyType = SysConvert.ToInt32(dt.Rows[0]["ID"]);
        }
        /// <summary>
        /// У���Ƿ�޸߹�˾��½ 
        /// </summary>
        /// <returns></returns>
        public static bool IsJGCompany()
        {
          
            return false;
        }
        #endregion

        #region �޸�����ӷ���  2012-08-21
        ///// <summary>
        ///// �������Ͱ�
        ///// </summary>
        //public static void BindMLType(LookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 85 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT ID,Name FROM Enum_FacType ";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        //}
        ///// <summary>
        ///// �������Ͱ�
        ///// </summary>
        //public static void BindMLType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.ShowHeader = false;
        //    p_DrpID.ShowFooter = false;
        //    p_DrpID.TextEditStyle = TextEditStyles.Standard;
        //    FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
        //    string sql = "SELECT ID,Name FROM Enum_FacType ";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);

        //}

        /// <summary>
        /// ��CheckedListBoxControl
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_DataSource">����Դ</param>
        /// <param name="p_DisplayMember">��ʾֵ</param>
        /// <param name="p_ValueMember"></param>
        public static void BindCheckedListBoxControl(CheckedListBoxControl p_DrpID, DataTable p_DataSource, string p_DisplayMember, string p_ValueMember)
        {
            p_DrpID.DataSource = p_DataSource;
            p_DrpID.DisplayMember = p_DisplayMember;
            p_DrpID.ValueMember = p_ValueMember;
            p_DrpID.Show();
        }
        /// <summary>
        /// �󶨵�Դ��ѡ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName"></param>
        /// <param name="p_FieldName"></param>
        public static void BindLightSource(CheckedListBoxControl p_DrpID)
        {
            DataTable dt = BindCLSDataSource("WO_FabricProcess", "Lamp");
            BindCheckedListBoxControl(p_DrpID, dt, "CLSNM", "CLSNM");
        }

        /// <summary>
        /// ���ͬһ�ֿ������µĵ�һ���ֿ�ID
        /// </summary>
        /// <param name="p_WHTye"></param>
        /// <returns></returns>
        public static string GetFirstWHByType(int p_WHTye)
        {
            string RtnWH = string.Empty;
            string sql = "SELECT WHID FROM WH_WH WHERE 1=1 ";
            sql += " AND WHTypeID =" + p_WHTye.ToString();
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                RtnWH = SysConvert.ToString(dt.Rows[0][0]);
            }
            return RtnWH;
        }
        #endregion


        #region չ�����
        /// <summary>
        /// ��չ��
        /// </summary>
        public static void BindDHID(LookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "ID", "ExName" }, new string[] { "ID", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,ExName FROM ADH_DataDH WHERE 1=1";
            sql += " AND ISNULL(ExType,0)=" + p_Type;
            sql += " ORDER BY ID ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ExName", "ID", p_ShowBlank);
        }
        /// <summary>
        /// ��չ��
        /// </summary>
        public static void BindDH(RepositoryItemLookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {

            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "ID", "ExName" }, new string[] { "ID", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,ExName FROM ADH_DataDH WHERE 1=1 ";
            sql += " AND ISNULL(ExType,0)=" + p_Type;
            sql += " ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "ExName", "ID", p_ShowBlank);
        }
        #endregion

        #region ��ò�ѯ���������ַ���
        /// <summary>
        /// ��������ֶεĲ�ѯ����
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_BeginDate"></param>
        /// <param name="p_EndEdit"></param>
        /// <returns></returns>
        public static string GetDateQueryString(string p_FieldName, DateEdit p_BeginDate, DateEdit p_EndDate)
        {
            return " AND " + p_FieldName + " BETWEEN " + SysString.ToDBString(SysConvert.ToString(p_BeginDate.DateTime.Date)) + " AND " + SysString.ToDBString(SysConvert.ToString(p_EndDate.DateTime.Date) + " 23:59:59 ");
        }
        /// <summary>
        /// ����ֶε���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_Value"></param>
        /// <returns></returns>
        public static string GetFieldEqualString(string p_FieldName, object p_Value)
        {
            if (p_Value.ToString().Trim() != string.Empty)
            {
                return " AND " + p_FieldName + " = " + SysString.ToDBString(p_Value.ToString().Trim());
            }
            return string.Empty;
        }
        /// <summary>
        /// ����ֶε���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldEqualString(string p_FieldName, string p_Value)
        {
            if (p_Value.Trim() != string.Empty)
            {
                return " AND " + p_FieldName + " = " + SysString.ToDBString(p_Value.Trim());
            }
            return string.Empty;
        }
        /// <summary>
        /// ����ֶε���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldEqualString(string p_FieldName, TextEdit p_QueryEdit)
        {
            return GetFieldEqualString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶε���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldEqualString(string p_FieldName, ComboBoxEdit p_QueryEdit)
        {
            return GetFieldEqualString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶε���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldEqualString(string p_FieldName, LookUpEdit p_QueryEdit)
        {
            return GetFieldEqualString(p_FieldName, SysConvert.ToString(p_QueryEdit.EditValue));
        }
        /// <summary>
        /// ����ֶ�LIKEʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_Value"></param>
        /// <returns></returns>
        public static string GetFieldLikeString(string p_FieldName, object p_Value)
        {
            if (p_Value.ToString().Trim() != string.Empty)
            {
                return " AND " + p_FieldName + " LIKE " + SysString.ToDBString("%" + p_Value.ToString().Trim() + "%");
            }
            return string.Empty;
        }
        /// <summary>
        /// ����ֶ�LIKEʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldLikeString(string p_FieldName, TextEdit p_QueryEdit)
        {
            return GetFieldLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶ�LIKEʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldLikeString(string p_FieldName, ComboBoxEdit p_QueryEdit)
        {
            return GetFieldLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶ�LIKEʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldLikeString(string p_FieldName, LookUpEdit p_QueryEdit)
        {
            return GetFieldLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.EditValue));
        }
        /// <summary>
        /// ����ֶ�LIKE�����ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_Value"></param>
        /// <returns></returns>
        public static string GetFieldLeftLikeString(string p_FieldName, object p_Value)
        {
            if (p_Value.ToString().Trim() != string.Empty)
            {
                return " AND " + p_FieldName + " LIKE " + SysString.ToDBString("%" + p_Value.ToString());
            }
            return string.Empty;
        }
        /// <summary>
        /// ����ֶ�LIKE�����ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldLeftLikeString(string p_FieldName, TextEdit p_QueryEdit)
        {
            return GetFieldLeftLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶ�LIKE�����ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldLeftLikeString(string p_FieldName, ComboBoxEdit p_QueryEdit)
        {
            return GetFieldLeftLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶ�LIKE�����ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldLeftLikeString(string p_FieldName, LookUpEdit p_QueryEdit)
        {
            return GetFieldLeftLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.EditValue));
        }
        /// <summary>
        /// ����ֶ�LIKE�Ұ���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_Value"></param>
        /// <returns></returns>
        public static string GetFieldRightLikeString(string p_FieldName, object p_Value)
        {
            if (p_Value.ToString().Trim() != string.Empty)
            {
                return " AND " + p_FieldName + " LIKE " + SysConvert.ToString(p_Value.ToString().Trim() + "%");
            }
            return string.Empty;
        }
        /// <summary>
        /// ����ֶ�LIKE�Ұ���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldRightLikeString(string p_FieldName, TextEdit p_QueryEdit)
        {
            return GetFieldRightLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶ�LIKE�Ұ���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldRightLikeString(string p_FieldName, ComboBoxEdit p_QueryEdit)
        {
            return GetFieldRightLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.Text));
        }
        /// <summary>
        /// ����ֶ�LIKE�Ұ���ʱ�Ĳ�ѯ�ַ���(��AND����)
        /// </summary>
        /// <param name="p_FieldName"></param>
        /// <param name="p_QueryEdti"></param>
        /// <returns></returns>
        public static string GetFieldRightLikeString(string p_FieldName, LookUpEdit p_QueryEdit)
        {
            return GetFieldRightLikeString(p_FieldName, SysConvert.ToString(p_QueryEdit.EditValue));
        }
        #endregion

        #region ���GridView��ֵ
        /// <summary>
        /// ����ַ���
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static string GetCellValueString(GridView p_Grid, string p_FieldName)
        {
            return GetCellValueString(p_Grid, p_Grid.FocusedRowHandle, p_FieldName);
        }
        /// <summary>
        /// ����ַ���
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static string GetCellValueString(GridView p_Grid, int p_FocusedRowHandle, string p_FieldName)
        {
            return SysConvert.ToString(p_Grid.GetRowCellValue(p_FocusedRowHandle, p_FieldName));
        }
        /// <summary>
        /// �������ֵ
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static int GetCellValueInt(GridView p_Grid, string p_FieldName)
        {
            return GetCellValueInt(p_Grid, p_Grid.FocusedRowHandle, p_FieldName);
        }
        /// <summary>
        /// �������ֵ
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static int GetCellValueInt(GridView p_Grid, int p_FocusedRowHandle, string p_FieldName)
        {
            return SysConvert.ToInt32(p_Grid.GetRowCellValue(p_FocusedRowHandle, p_FieldName));
        }
        /// <summary>
        /// ��ø�����
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static decimal GetCellValueDecimal(GridView p_Grid, string p_FieldName)
        {
            return GetCellValueDecimal(p_Grid, p_Grid.FocusedRowHandle, p_FieldName);
        }
        /// <summary>
        /// ��ø�����
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static decimal GetCellValueDecimal(GridView p_Grid, int p_FocusedRowHandle, string p_FieldName)
        {
            return SysConvert.ToDecimal(p_Grid.GetRowCellValue(p_FocusedRowHandle, p_FieldName));
        }
        /// <summary>
        /// ��������ַ���
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static string GetCellValueDateString(GridView p_Grid, string p_FieldName)
        {
            return GetCellValueDateString(p_Grid, p_Grid.FocusedRowHandle, p_FieldName);
        }
        /// <summary>
        ///��������ַ���
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static string GetCellValueDateString(GridView p_Grid, int p_FocusedRowHandle, string p_FieldName)
        {
            return SysConvert.ToDateTime(p_Grid.GetRowCellValue(p_FocusedRowHandle, p_FieldName)).ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static DateTime GetCellValueDate(GridView p_Grid, string p_FieldName)
        {
            return GetCellValueDate(p_Grid, p_Grid.FocusedRowHandle, p_FieldName);
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="p_Grid"></param>
        /// <param name="p_FocusedRowHandle"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        public static DateTime GetCellValueDate(GridView p_Grid, int p_FocusedRowHandle, string p_FieldName)
        {
            return SysConvert.ToDateTime(p_Grid.GetRowCellValue(p_FocusedRowHandle, p_FieldName));
        }



        #endregion

        #region ����������Ϣ

        /// <summary>
        /// ����������
        /// </summary>
        public static void BindHolidayFlag(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "ID", "Name" }, new string[] { "ID", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Enum_HolidayFlag WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲������ֻ�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindDistMachineType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_DistMachineType  ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨻�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMachineClass(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_MachineClass  ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹���
        /// </summary>
        public static void BindBShopIndex(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 70, 70 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT ID,Name FROM DataWO_BShopIndex WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        ///  �󶨹�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindBaseStepType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100, 100 }, new string[] { "ID", "Name" }, new string[] { "���", "����" });
            string sql = "SELECT ID,Name FROM Enum_BaseStepType ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        ///  �󶨹���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindBWorkType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100, 100 }, new string[] { "WorkTypeCode", "Name" }, new string[] { "���", "����" });
            string sql = "SELECT WorkTypeCode,Name FROM DataWO_BWorkType ORDER BY WorkTypeCode";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "WorkTypeCode", p_ShowBlank);
        }


        /// <summary>
        /// �󶨻�����������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindBBaseStep(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100, 100 }, new string[] { "BaseStepID", "BaseStepName" }, new string[] { "���", "����" });
            string sql = "SELECT BaseStepID,BaseStepName FROM DataWO_BBaseStep ORDER BY BaseStepID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "BaseStepName", "BaseStepID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨻�����������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_Flag">�Ƿ����������</param>
        /// <param name="p_ShowBlank"></param>
        public static void BindBBaseStep(LookUpEdit p_DrpID, bool p_Flag, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100, 100 }, new string[] { "BaseStepID", "BaseStepName" }, new string[] { "���", "����" });
            string sql = "SELECT BaseStepID,BaseStepName FROM DataWO_BBaseStep WHERE 1=1";
            if (p_Flag)
            {
                sql += " AND BaseStepType = 1";
            }
            sql += " ORDER BY BaseStepID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "BaseStepName", "BaseStepID", p_ShowBlank);
        }


        /// <summary>
        ///   �󶨻�����������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_Flag"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindBBaseStep(RepositoryItemLookUpEdit p_DrpID, bool p_Flag, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 50 }, new string[2] { "BaseStepID", "BaseStepName" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT BaseStepID,BaseStepName FROM DataWO_BBaseStep WHERE 1=1";
            if (p_Flag)
            {
                sql += " AND BaseStepType = 1";
            }
            sql += " ORDER BY BaseStepID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "BaseStepName", "BaseStepID", p_ShowBlank);
        }


        /// <summary>
        ///  �󶨻�����������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        /// <param name="iType">����:1�ӹ����ݡ�2�ӹ�����</param>
        public static void BindBBaseStep(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 50 }, new string[2] { "BaseStepID", "BaseStepName" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT BaseStepID,BaseStepName FROM DataWO_BBaseStep ORDER BY BaseStepID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "BaseStepName", "BaseStepID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶���
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindStepActionName(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "StepWorkID", "StepWorkName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1 AND ISNULL(SampleTimeFlag,0)=1";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "StepWorkName", "StepWorkID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶���
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindStepActionName(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "StepWorkID", "StepWorkName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1 AND ISNULL(SampleTimeFlag,0)=1";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "StepWorkName", "StepWorkID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹����Ƴ�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_AttFlag">�Ƿ񸽼�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepWork(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "StepWorkID", "StepWorkName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1";//StepWorkID+' '+StepWorkName 

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "StepWorkName", "StepWorkID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹����Ƴ�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_AttFlag">�Ƿ񸽼�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepWork(LookUpEdit p_DrpID, string p_BaseStepID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "StepWorkID", "StepWorkName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1";//StepWorkID+' '+StepWorkName 
            sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "StepWorkName", "StepWorkID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨹����Ƴ�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_AttFlag">�Ƿ񸽼�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepWork(LookUpEdit p_DrpID, string p_BaseStepID, bool p_AttFlag, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "StepWorkID", "StepWorkName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1";//StepWorkID+' '+StepWorkName 
            sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            if (p_AttFlag)
            {
                sql += " AND AttFlag=1";
            }
            else
            {
                sql += " AND AttFlag=0";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "StepWorkName", "StepWorkID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹����Ƴ�
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_BaseStepID"></param>
        /// <param name="p_AttFlag"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWOStepWork(CheckedListBoxControl p_DrpID, string p_BaseStepID, bool p_AttFlag, bool p_ShowBlank)
        {
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1";//StepWorkID+' '+StepWorkName 
            sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            if (p_AttFlag)
            {
                sql += " AND AttFlag=1";
            }
            else
            {
                sql += " AND AttFlag=0";
            }
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.DataSource = dt;
            p_DrpID.DisplayMember = "StepWorkName";
            p_DrpID.ValueMember = "StepWorkID";
            p_DrpID.Show();

        }
        /// <summary>
        /// �󶨹����Ƴ�
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_BaseStepID"></param>
        /// <param name="p_AttFlag"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWOStepWork(CheckedListBoxControl p_DrpID, string p_BaseStepID, bool p_AttFlag, int p_FZFlag, bool p_ShowBlank)
        {
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1";//StepWorkID+' '+StepWorkName 
            sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            if (p_AttFlag)
            {
                sql += " AND AttFlag=1";
            }
            else
            {
                sql += " AND AttFlag=0";
            }
            if (p_FZFlag == 2)
            {
                sql += " AND BaseStepID='WK889'";
            }
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.DataSource = dt;
            p_DrpID.DisplayMember = "StepWorkName";
            p_DrpID.ValueMember = "StepWorkID";
            p_DrpID.Show();

        }
        /// <summary>
        /// �󶨹����Ƴ�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_AttFlag">�Ƿ񸽼�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepWork(LookUpEdit p_DrpID, string p_BaseStepID, bool p_AttFlag, bool p_SampleCalcFlag, bool p_SampleTimeFlag, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "StepWorkID", "StepWorkName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1";//StepWorkID+' '+StepWorkName 
            sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            if (p_AttFlag)
            {
                sql += " AND AttFlag=1";
            }
            else
            {
                sql += " AND AttFlag=0";
            }
            if (p_SampleCalcFlag)
            {
                sql += " AND SampleCalcFlag=1";
            }
            else
            {
                sql += " AND SampleCalcFlag=0";
            }
            if (p_SampleTimeFlag)
            {
                sql += " AND SampleTimeFlag=1";
            }
            else
            {
                sql += " AND SampleTimeFlag=0";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "StepWorkName", "StepWorkID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹����Ƴ�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_AttFlag">�Ƿ񸽼�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepWork(RepositoryItemLookUpEdit p_DrpID, string p_BaseStepID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 50 }, new string[2] { "StepWorkID", "StepWorkName" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT StepWorkID,StepWorkName FROM DataWO_BStepWork WHERE UseFlag=1";
            sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "StepWorkName", "StepWorkID", p_ShowBlank);

        }

        /// <summary>
        ///  �󶨹����Ƴ�
        /// </summary>
        public static void BindWOStepWork(RepositoryItemComboBox p_DrpID, string p_BaseStepID, bool p_ShowBlank, bool FlagIDorName)
        {
            p_DrpID.TextEditStyle = TextEditStyles.Standard;
            string sql = "";
            if (FlagIDorName)
            {
                sql = "SELECT StepWorkID AS Name FROM DataWO_BStepWork WHERE UseFlag=1";
            }
            else
            {
                sql = "SELECT StepWorkName AS Name FROM DataWO_BStepWork WHERE UseFlag=1";
            }
            sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropItemComb(p_DrpID, dt, "Name", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹��򳵼�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_ClassFlag">�ȼ�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepShop(LookUpEdit p_DrpID, string p_BaseStepID, int p_ClassFlag, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = true;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 120, 280 }, new string[2] { "ShopID", "ShopName" }, new string[2] { "���", "����" }, new bool[2] { true, true });
            string sql = "SELECT ShopID,ShopName FROM DataWO_BStepShop WHERE UseFlag=1";
            if (p_BaseStepID != string.Empty)
            {
                sql += " AND BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            }
            //if (p_ClassFlag != 0)
            //{
            //    sql += " AND ClassFlag=" + p_ClassFlag;
            //}
            sql += " ORDER BY ClassFlag,ShopID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ShopName", "ShopID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨹��򳵼�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepShop(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 80 }, new string[2] { "ShopID", "ShopName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ShopID,ShopName FROM DataWO_BStepShop WHERE UseFlag=1";
            sql += " ORDER BY ShopID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ShopName", "ShopID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨹��򳵼�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepShop(LookUpEdit p_DrpID, int p_ClassFlag, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 80 }, new string[2] { "ShopID", "ShopName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ShopID,ShopName FROM DataWO_BStepShop WHERE UseFlag=1";
            sql += " AND ClassFlag=" + p_ClassFlag;
            sql += " ORDER BY ShopID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ShopName", "ShopID", p_ShowBlank);
        }
        /// <summary>
        /// �󶨹��򳵼�
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStepShop(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 80 }, new string[2] { "ShopID", "ShopName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ShopID,ShopName FROM DataWO_BStepShop WHERE UseFlag=1";
            sql += " ORDER BY ShopID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "ShopName", "ShopID", p_ShowBlank);
        }


        /// <summary>
        /// ���ݹ����ó���
        /// </summary>
        /// <param name="p_BaseStep">����</param>
        /// <returns>����</returns>
        public static string WOGetShopByBaseStep(string p_BaseStepID)
        {
            return WOGetShopByBaseStep(p_BaseStepID, -1);
        }

        /// <summary>
        /// ���ݹ����ó���
        /// </summary>
        /// <param name="p_BaseStep">����</param>
        /// <returns>����</returns>
        public static string WOGetShopByBaseStep(string p_BaseStepID, int p_ShopIndexID)
        {
            string outstr = string.Empty;
            string sql = "SELECT ShopID FROM DataWO_BStepShop WHERE BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            if (p_ShopIndexID != -1 && p_ShopIndexID != 0)
            {
                sql += " AND BShopIndexID=" + p_ShopIndexID;
            }
            sql += " ORDER BY ShopID";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
            }
            return outstr;
        }


        /// <summary>
        /// ���ݹ�������һ����
        /// </summary>
        /// <param name="p_BaseStep">����</param>
        /// <returns>����</returns>
        public static string WOGetNextStepByBaseStep(string p_BaseStepID)
        {
            string outstr = string.Empty;
            string sql = "SELECT NBasestepID FROM DataWO_BFlowDts WHERE FlowID='NORMALROUTE' AND CBaseStepID=" + SysString.ToDBString(p_BaseStepID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
            }
            return outstr;
        }



        /// <summary>
        /// �����Ƴ̱�Ż���Ƴ�����
        /// </summary>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_StepWorkID">�Ƴ̱��</param>
        /// <returns>��������</returns>
        public static string WOGetNameByStepWorkID(string p_BaseStepID, string p_StepWorkID)
        {
            string outstr = p_StepWorkID;
            string sql = "SELECT StepWorkName FROM DataWO_BStepWork WHERE BaseStepID=" + SysString.ToDBString(p_BaseStepID);
            sql += " AND StepWorkID=" + SysString.ToDBString(p_StepWorkID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
            }
            return outstr;
        }


        /// <summary>
        /// ���ݹ����Ż�ù�������
        /// </summary>
        /// <param name="p_ShopID">������</param>
        /// <returns>��������</returns>
        public static string WOGetNameByStepID(string p_StepID)
        {
            string outstr = p_StepID;
            string sql = "SELECT BaseStepName FROM DataWO_BBaseStep WHERE BaseStepID=" + SysString.ToDBString(p_StepID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
            }
            return outstr;
        }


        /// <summary>
        /// ���ݳ����Ż�ó�������
        /// </summary>
        /// <param name="p_ShopID">������</param>
        /// <returns>��������</returns>
        public static string WOGetNameByStepShopID(string p_ShopID)
        {
            string outstr = p_ShopID;
            string sql = "SELECT ShopName FROM DataWO_BStepShop WHERE ShopID=" + SysString.ToDBString(p_ShopID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0][0].ToString();
            }
            return outstr;
        }


        /// <summary>
        /// ����ת��������
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOAllStreamType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 80 }, new string[2] { "StreamTypeID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StreamTypeID,Name FROM DataWO_StreamType WHERE  1=1 ";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "StreamTypeID", p_ShowBlank);
        }

        /// <summary>
        /// ����ת����
        /// </summary>
        public static void BindWOStreamID(ComboBoxEdit p_DrpID, string p_StepShopID, bool p_ShowBlank)
        {
            string sql = " SELECT StreamID FROM WO_ISNStream WHERE StatusFlag=0 AND CStepShopID=" + SysString.ToDBString(p_StepShopID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "StreamID", p_ShowBlank);
        }

        /// <summary>
        /// ����ת����(Ŀ��)
        /// </summary>
        public static void BindWOStreamIDTarget(ComboBoxEdit p_DrpID, string p_StepShopID, int[] p_ShopIndexID, bool p_ShowBlank)
        {
            string sql = string.Empty;
            string StepShopIDTemp = string.Empty;
            for (int i = 0; i < p_ShopIndexID.Length; i++)
            {
                if (i != 0)
                {
                    StepShopIDTemp += ",";
                }
                StepShopIDTemp += p_ShopIndexID[i].ToString();
            }

            sql = " SELECT StreamID FROM WO_ISNStream WHERE StatusFlag=0 AND NextStepShopID=" + SysString.ToDBString(p_StepShopID) + " AND BShopIndexID IN (" + StepShopIDTemp + ")";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "StreamID", p_ShowBlank);
        }
        /// <summary>
        /// ����ת����(Ŀ��)
        /// </summary>
        public static void BindWOStreamIDTarget(ComboBoxEdit p_DrpID, string p_StepShopID, int p_ShopIndexID, bool p_ShowBlank)
        {
            string sql = string.Empty;
            //if (p_ShopIndexID != -1)
            //{
            //    sql = " SELECT StreamID FROM WO_ISNStream WHERE StatusFlag=0 AND NextStepShopID=" + SysString.ToDBString(p_StepShopID) + " AND BShopIndexID=" + SysString.ToDBString(p_ShopIndexID);

            //}
            //else
            //{
            sql = " SELECT StreamID FROM WO_ISNStream WHERE StatusFlag=0 AND NextStepShopID=" + SysString.ToDBString(p_StepShopID);// +" AND BShopIndexID=" + SysString.ToDBString(p_ShopIndexID);

            //}
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "StreamID", p_ShowBlank);
        }


        /// <summary>
        /// ����ת��������
        /// </summary>
        /// <param name="p_DrpID">�ؼ�</param>
        /// <param name="p_BaseStepID">����</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindWOStreamType(LookUpEdit p_DrpID, string p_BaseStepID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 80 }, new string[2] { "StreamTypeID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT StreamTypeID,Name FROM DataWO_StreamType WHERE  BaseStepID=" + SysString.ToDBString(p_BaseStepID);

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "StreamTypeID", p_ShowBlank);
        }


        /// ����ת��������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindYieldStreamType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 50, 50 }, new string[] { "ID", "Name" }, new string[] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_YieldStreamType ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        #endregion
        /// <summary>
        /// ��ȡ�뵱ǰ����֮����������
        /// </summary>
        /// <param name="p_Date"></param>
        /// <returns></returns>
        public static int GetDateTimeSpanDays(DateTime p_Date)
        {
            TimeSpan sp = DateTime.Now.Date - p_Date.Date;
            return System.Math.Abs(sp.Days);
        }

        /// <summary>
        /// ��ȡ�뵱ǰ����֮��������������
        /// </summary>
        /// <param name="p_Date"></param>
        /// <returns></returns>
        public static int GetDateTimeSpanDaysZ(DateTime p_Date)
        {
            TimeSpan sp = DateTime.Now.Date - p_Date.Date;
            return sp.Days;
            //if (p_Date < DateTime.Now)
            //{
            //    return -sp.Days;
            //}
            //else
            //{
            //}

        }
        public static string GetTurnFlag(int p_ID)
        {
            string sql = "select Name from Enum_TurnFlag where ID= " + p_ID;
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// ����ת��־
        /// </summary>
        public static void BindTurnFlag(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindLookUpEdit(p_DrpID, "Enum_TurnFlag", "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// ����ת��־
        /// </summary>
        public static void BindTurnFlag(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.TextEditStyle = TextEditStyles.Standard;

            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });

            string sql = "SELECT Name,ID FROM Enum_TurnFlag WHERE 1=1";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��ѡ������ö��
        /// </summary>
        public static void BindBrand(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 70, 130 }, new string[2] { "BrandID", "BrandAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });
            string sql = "SELECT BrandID,BrandAttn FROM Data_Brand WHERE 1=1 ORDER BY BrandID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "BrandAttn", "BrandID", p_ShowBlank);
        }

        /// <summary>
        /// ��ѡ������ö��
        /// </summary>
        public static void BindBrand(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = true;
            p_DrpID.ShowFooter = false;

            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 70, 130 }, new string[2] { "BrandID", "BrandAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });
            string sql = "SELECT BrandID,BrandAttn FROM Data_Brand WHERE 1=1 ORDER BY BrandID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "BrandAttn", "BrandID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶������ͣ�ID��Valueֵ)
        /// </summary>
        public static void BindSOType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name,DefaultShow FROM Enum_SOType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);

            //if (dt.Rows.Count != 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        if (SysConvert.ToInt32(dr["DefaultShow"]) == (int)YesOrNo.Yes)
            //        {
            //            p_DrpID.EditValue = SysConvert.ToInt32(dr["ID"]);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// �󶨶�������(name��Valueֵ��
        /// </summary>
        public static void BindSOType2(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name,DefaultShow FROM Enum_SOType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Name", p_ShowBlank);

        }
        /// <summary>
        /// �������������ͣ�ID��Valueֵ)
        /// </summary>
        public static void BindProduceType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ProduceType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);

            //if (dt.Rows.Count != 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        if (SysConvert.ToInt32(dr["DefaultShow"]) == (int)YesOrNo.Yes)
            //        {
            //            p_DrpID.EditValue = SysConvert.ToInt32(dr["ID"]);
            //        }
            //    }
            //}
        }
        /// <summary>
        /// ����ɫӢ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindPSColor(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, "Data_FabricColorItem", "ColorName", p_ShowBlank);
        }


        public static void BindMachine(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = true;
            p_DrpID.Properties.ShowHeader = true;
            FCommon.LookupEditColAdd(p_DrpID, new int[6] { 10, 50, 80, 80, 80, 80 }, new string[6] { "ID", "Code", "MachineType", "Needie", "NeedleLen", "TolNeedle" }, new string[6] { "ID", "���", "����", "����", "���", "������" }, new bool[6] { false, true, true, true, true, true });
            string sql = "SELECT ID,Code,Code+MachineType MachineType,Needie,NeedleLen,TolNeedle FROM Data_MachineManage WHERE 1=1 ORDER BY MachineType";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Code", "ID", p_ShowBlank);

        }

        public static void BindMachine(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = true;
            p_DrpID.Properties.ShowHeader = true;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[6] { 10, 50, 80, 80, 80, 80 }, new string[6] { "ID", "Code", "MachineType", "Needie", "NeedleLen", "TolNeedle" }, new string[6] { "ID", "���", "����", "����", "���", "������" }, new bool[6] { false, true, true, true, true, true });
            string sql = "SELECT ID,Code,Code+MachineType MachineType,Needie,NeedleLen,TolNeedle FROM Data_MachineManage WHERE 1=1 ORDER BY MachineType";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Code", "ID", p_ShowBlank);

        }
        /// <summary>
        /// �󶨻�̨
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMachine(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            BindRepositoryItemComboBox(p_DrpID, "Data_MachineManage", "Code", true);
        }

        /// <summary>
        /// �������׺�
        /// </summary>
        public static void BindSCJarNum(RepositoryItemComboBox p_DrpID, string p_DtsSO, string p_ReViewCode, bool p_ShowBlank)
        {
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 30, 200 }, new string[2] { "Code", "Code" }, new string[2] { "", "�׺�" }, new bool[2] { false, true });
            string sql = "SELECT DISTINCT ItemCode,JarNum FROM UV1_WH_IOFormDts WHERE SubmitFlag=1 AND SubType IN(6004,6012,4005,4002) AND OrderCode=" + SysString.ToDBString(p_DtsSO) + " AND SSN=" + SysString.ToDBString(p_ReViewCode) + " AND JarNum<>''";
            DataTable dt = SysUtils.Fill(sql);

            sql = "SELECT DISTINCT ItemCode FROM UV1_WH_IOFormDts WHERE SubmitFlag=1 AND SubType IN(6004,6012,4005,4002) AND OrderCode=" + SysString.ToDBString(p_DtsSO) + " AND SSN=" + SysString.ToDBString(p_ReViewCode) + " AND JarNum<>''";
            DataTable dtitem = SysUtils.Fill(sql);
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("Code", typeof(string));

            sql = "SELECT DISTINCT JarNum FROM UV1_WH_IOFormDts WHERE SubmitFlag=1 AND SubType IN(6004,6012,4005,4002) AND OrderCode=" + SysString.ToDBString(p_DtsSO) + " AND SSN=" + SysString.ToDBString(p_ReViewCode) + " AND JarNum<>''";
            DataTable dtjar = SysUtils.Fill(sql);

            ArrayList list = new ArrayList();
            GetJarItem(dtitem, dt, list, dtjar.Rows.Count);

            for (int i = 0; i < list.Count; i++)
            {
                DataRow newrow = dtnew.NewRow();
                newrow["Code"] = list[i].ToString();
                dtnew.Rows.Add(newrow);
            }
            FCommon.LoadDropRepositoryComb(p_DrpID, dtnew, "Code", p_ShowBlank);
            //FCommon.LoadDropRepositoryLookUP(p_DrpID, dtnew, "Code",p_ShowBlank);
        }


        private static void GetJarItem(DataTable dtitem, DataTable p_JarItem, ArrayList Jar, int MaxJarCount)
        {
            int ItemCount = dtitem.Rows.Count;
            int JarCount = MaxJarCount;
            string[][] kind = new string[ItemCount][];
            for (int i = 0; i < ItemCount; i++)
            {
                DataRow[] Jaritem = p_JarItem.Select("ItemCode=" + SysString.ToDBString(dtitem.Rows[i]["ItemCode"].ToString()));

                kind[i] = new string[MaxJarCount];

                for (int j = 0; j < MaxJarCount; j++)
                {
                    if (j < Jaritem.Length)
                    {
                        kind[i][j] = Jaritem[j]["JarNum"].ToString();
                    }
                    else
                    {
                        kind[i][j] = "";
                    }
                }
            }

            //��ά�����Ѿ����ã���������ʼ��ϸ׺���
            switch (ItemCount)
            {
                case 1:
                    for (int a = 0; a < MaxJarCount; a++)
                    {
                        if (kind[0][a] != string.Empty)
                        {
                            Jar.Add(kind[0][a]);
                        }
                    }
                    break;
                case 2:
                    for (int a = 0; a < MaxJarCount; a++)
                    {
                        for (int b = 0; b < MaxJarCount; b++)
                        {
                            if (kind[0][a] != string.Empty && kind[1][b] != string.Empty)
                            {
                                Jar.Add(kind[0][a] + "+" + kind[1][b]);
                            }
                        }
                    }
                    break;
                case 3:
                    for (int a = 0; a < MaxJarCount; a++)
                    {
                        for (int b = 0; b < MaxJarCount; b++)
                        {
                            for (int c = 0; c < MaxJarCount; c++)
                            {
                                if (kind[0][a] != string.Empty && kind[1][b] != string.Empty && kind[2][c] != string.Empty)
                                {
                                    Jar.Add(kind[0][a] + "+" + kind[1][b] + "+" + kind[2][c]);
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    for (int a = 0; a < MaxJarCount; a++)
                    {
                        for (int b = 0; b < MaxJarCount; b++)
                        {
                            for (int c = 0; c < MaxJarCount; c++)
                            {
                                for (int d = 0; d < MaxJarCount; d++)
                                {
                                    if (kind[0][a] != string.Empty && kind[1][b] != string.Empty && kind[2][c] != string.Empty && kind[3][d] != string.Empty)
                                    {
                                        Jar.Add(kind[0][a] + "+" + kind[1][b] + "+" + kind[2][c] + "+" + kind[3][d]);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 5:
                    for (int a = 0; a < MaxJarCount; a++)
                    {
                        for (int b = 0; b < MaxJarCount; b++)
                        {
                            for (int c = 0; c < MaxJarCount; c++)
                            {
                                for (int d = 0; d < MaxJarCount; d++)
                                {
                                    for (int e = 0; e < MaxJarCount; e++)
                                    {
                                        if (kind[0][a] != string.Empty && kind[1][b] != string.Empty && kind[2][c] != string.Empty && kind[3][d] != string.Empty && kind[4][e] != string.Empty)
                                        {
                                            Jar.Add(kind[0][a] + "+" + kind[1][b] + "+" + kind[2][c] + "+" + kind[3][d] + "+" + kind[4][e]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 6:
                    for (int a = 0; a < MaxJarCount; a++)
                    {
                        for (int b = 0; b < MaxJarCount; b++)
                        {
                            for (int c = 0; c < MaxJarCount; c++)
                            {
                                for (int d = 0; d < MaxJarCount; d++)
                                {
                                    for (int e = 0; e < MaxJarCount; e++)
                                    {
                                        for (int f = 0; f < MaxJarCount; f++)
                                        {
                                            if (kind[0][a] != string.Empty && kind[1][b] != string.Empty && kind[2][c] != string.Empty && kind[3][d] != string.Empty && kind[4][e] != string.Empty && kind[5][f] != string.Empty)
                                            {
                                                Jar.Add(kind[0][a] + "+" + kind[1][b] + "+" + kind[2][c] + "+" + kind[3][d] + "+" + kind[4][e] + "+" + kind[5][f]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    for (int a = 0; a < MaxJarCount; a++)
                    {
                        for (int b = 0; b < MaxJarCount; b++)
                        {
                            for (int c = 0; c < MaxJarCount; c++)
                            {
                                for (int d = 0; d < MaxJarCount; d++)
                                {
                                    for (int e = 0; e < MaxJarCount; e++)
                                    {
                                        for (int f = 0; f < MaxJarCount; f++)
                                        {
                                            for (int g = 0; g < MaxJarCount; g++)
                                            {
                                                if (kind[0][a] != string.Empty && kind[1][b] != string.Empty && kind[2][c] != string.Empty && kind[3][d] != string.Empty && kind[4][e] != string.Empty && kind[5][f] != string.Empty && kind[6][g] != string.Empty)
                                                {
                                                    Jar.Add(kind[0][a] + "+" + kind[1][b] + "+" + kind[2][c] + "+" + kind[3][d] + "+" + kind[4][e] + "+" + kind[5][f] + "+" + kind[6][g]);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
            }
        }
        /// <summary>
        /// ���ַ��������һλ�Ƴ�
        /// </summary>
        /// <param name="p_Str"></param>
        /// <returns></returns>
        public static string RemoveLastChar(string p_Str)
        {
            if (string.IsNullOrEmpty(p_Str))
            {
                return p_Str;
            }
            return p_Str.Remove(p_Str.Length - 1, 1);
        }
        /// <summary>
        /// ��ú���ƴ������ĸ
        /// </summary>
        /// <param name="p_Value"></param>
        /// <returns></returns>
        public static string GetSpellCode(string p_Value)
        {
            int len = p_Value.Length - 1;
            string strRet = "";
            string temp = "";
            while (len >= 0)
            {

                string sub = p_Value.Substring(len, 1);
                if (sub.CompareTo("��") >= 0)
                {
                    temp = "Z";
                }
                else if (sub.CompareTo("Ѿ") >= 0)
                {
                    temp = "Y";
                }
                else if (sub.CompareTo("Ϧ") >= 0)
                {
                    temp = "X";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "W";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "T";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "S";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "R";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "Q";
                }
                else if (sub.CompareTo("�r") >= 0)
                {
                    temp = "P";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "O";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "N";
                }
                else if (sub.CompareTo("�`") >= 0)
                {
                    temp = "M";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "L";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "K";
                }
                else if (sub.CompareTo("آ") >= 0)
                {
                    temp = "J";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "H";
                }
                else if (sub.CompareTo("�") >= 0)
                {
                    temp = "G";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "F";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "E";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "D";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "C";
                }
                else if (sub.CompareTo("��") >= 0)
                {
                    temp = "B";
                }
                else if (sub.CompareTo("߹") >= 0)
                {
                    temp = "A";
                }
                else
                {
                    temp = sub.Trim();
                }

                if (temp == "(" || temp == ")")
                {
                    temp = "";
                }
                len = len - 1;
                strRet = temp + strRet;

            }
            return strRet.ToUpper();
        }
        /// <summary>
        /// ���ͻ�����ƴ������ĸ
        /// </summary>
        public static void SetVendorSpellCode()
        {
            string sql = string.Empty;
            sql += " SELECT VendorID,VendorAttn,VendorName FROM Data_Vendor  ";
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string VendorID = SysConvert.ToString(dr["VendorID"]);
                sql = " UPDATE Data_Vendor SET VendorAttnSpell=" + SysString.ToDBString(GetSpellCode(SysConvert.ToString(dr["VendorAttn"])));
                sql += " ," + "VendorNameSpell=" + SysString.ToDBString(GetSpellCode(SysConvert.ToString(dr["VendorName"])));
                sql += " WHERE VendorID=" + SysString.ToDBString(VendorID);
                SysUtils.ExecuteNonQuery(sql);
            }
        }

        ///// <summary>
        ///// �󶨿ͻ�����
        ///// </summary>
        //public static void BindVendorType(LookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT ID,Name FROM Enum_VendorType ";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        //}

        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindVendorType(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_VendorType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            //sql += " AND BaseType=" + BaseType;
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "ID";
            p_DrpID.DisplayMember = "Name";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
        }

        public static void BindVendorType2(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_VendorType2 WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "ID";
            p_DrpID.DisplayMember = "Name";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
        }

        /// <summary>
        /// ��Ա������
        /// </summary>
        public static void BindOPDepartment(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID ,Name FROM Enum_Department WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��Ա������
        /// </summary>
        public static void BindOPDepartment(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {

            p_DrpID.ShowFooter = false;
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT ID ,Name FROM Enum_Department WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);

        }



        public static void BindComm(LookUpEdit cp_lookupedit, string sp_TabelName, string sp_DisplayField, string sp_ValueField)
        {
            string st_str = string.Empty;
            cp_lookupedit.Properties.ShowFooter = false;
            cp_lookupedit.Properties.ShowHeader = false;
            st_str = "SELECT " + sp_DisplayField + "," + sp_ValueField + " FROM " + sp_TabelName;
            DataTable dt = SysUtils.Fill(st_str);
            FCommon.LookupEditColAdd(cp_lookupedit, new int[] { 0, 50 }, new string[] { sp_ValueField, sp_DisplayField }, new string[] { "", "" }, new bool[] { false, true });
            FCommon.LoadDropLookUP(cp_lookupedit, dt, sp_DisplayField, sp_ValueField, true);
        }

        /// <summary>
        /// ���ָ����̨ID��û�̨����
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetMachineName(string p_ID)
        {
            if (p_ID != string.Empty)
            {
                string sql = "SELECT MachineType From Data_MachineManage Where ID=" + p_ID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                return string.Empty;

            }
            return string.Empty;
        }
        /// <summary>
        /// ���ָ����̨ID��û�̨���
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetMachineCode(string p_ID)
        {
            if (p_ID != string.Empty)
            {
                string sql = "SELECT Code From Data_MachineManage Where ID=" + p_ID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                return string.Empty;

            }
            return string.Empty;
        }

        #region GridView�и�ʽ����
        /// <summary>
        /// ����Grid��ʽ
        /// </summary>
        /// <param name="p_View">gridView</param>
        /// <param name="p_HeadTypeID">������</param>
        /// <param name="p_SubTypeID">������</param>
        public static void SetGridColumnUI(GridView p_View, int p_HeadTypeID, int p_SubTypeID)
        {
            SetGridColumnUI("SYS", p_View, p_HeadTypeID, p_SubTypeID);
        }
        /// <summary>
        /// ����Grid��ʽ(����޷�����BandedGridView��˳������)
        /// </summary>
        /// <param name="p_UIOP">����������Ա����</param>
        /// <param name="p_View">gridView</param>
        /// <param name="p_HeadTypeID">������</param>
        /// <param name="p_SubTypeID">������</param>
        public static void SetGridColumnUI(string p_UIOP, GridView p_View, int p_HeadTypeID, int p_SubTypeID)
        {
            int formGridID = SysConvert.ToInt32(p_View.ViewCaption);
            if (formGridID == 0)//���û������formGridI�򷵻ز�����UI
            {
                return;
            }
            bool BandedGridViewFlag = false;//�Ƿ���BandedGridView��־
            if (p_View.GetType().Name == "BandedGridView")
            {
                BandedGridViewFlag = true;
            }
            string sql = string.Empty;

            //��ȡ��ϸ����
            sql = "SELECT * FROM Sys_FormGridUIDts WHERE OPID=" + SysString.ToDBString(p_UIOP) + " AND FormGridID=" + formGridID;
            sql += " AND HeadTypeID=" + p_HeadTypeID.ToString() + " AND SubTypeID=" + p_SubTypeID.ToString();
            sql += " ORDER BY Vindex";
            DataTable dt = SysUtils.Fill(sql);

            if (dt.Rows.Count != 0)//���ݿ��Ѵ���������
            {
                for (int i = 0; i < p_View.Columns.Count; i++)//����������
                {
                    p_View.Columns[i].Visible = false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)//�����ʾ
                {
                    string fn = dt.Rows[i]["FieldName"].ToString();
                    int vi = SysConvert.ToInt32(dt.Rows[i]["Vindex"].ToString());
                    if (p_View.Columns[fn] != null)//�ҵ���
                    {
                        if (SysConvert.ToInt32(dt.Rows[i]["ColSize"].ToString()) != 0)
                        {
                            p_View.Columns[fn].Width = SysConvert.ToInt32(dt.Rows[i]["ColSize"].ToString());
                        }
                        //��Ҫ���BandedGridView�޷�������˳�������
                        if (BandedGridViewFlag == true)
                        {
                            ((BandedGridView)p_View).Columns[fn].ColVIndex = vi;
                        }
                        else
                        {
                            p_View.Columns[fn].VisibleIndex = vi;
                        }
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.AllowEdit, SysConvert.ToInt32(dt.Rows[i]["AllowEdit"].ToString()));
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.AllowFilter, SysConvert.ToInt32(dt.Rows[i]["AllowFilter"].ToString()));
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.AllowMove, SysConvert.ToInt32(dt.Rows[i]["AllowMove"].ToString()));
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.AllowSize, SysConvert.ToInt32(dt.Rows[i]["AllowSize"].ToString()));
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.AllowSort, SysConvert.ToInt32(dt.Rows[i]["AllowSort"].ToString()));
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.CellTrim, SysConvert.ToInt32(dt.Rows[i]["CellTrim"].ToString()));
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.HeadTrim, SysConvert.ToInt32(dt.Rows[i]["HeadTrim"].ToString()));
                        ProcessGrid.SetColProeInt(p_View.Columns[fn], ProGridColType.ReadOnly, SysConvert.ToInt32(dt.Rows[i]["ReadOnly"].ToString()));
                        if (dt.Rows[i]["Title"].ToString() != "")//���ⲻΪ��
                        {
                            p_View.Columns[fn].Caption = dt.Rows[i]["Title"].ToString();
                        }

                        string[] tagstra = new string[FPageConst.GridTagLength] { dt.Rows[i]["FormEditName"].ToString(), dt.Rows[i]["ColEditFlag"].ToString(), dt.Rows[i]["HttFlag"].ToString() };//Tag���飺0,1:�༭�ؼ��ַ�,�б༭����,�Ƿ��̩����
                        p_View.Columns[fn].Tag = tagstra;

                        if (SysConvert.ToInt32(dt.Rows[i]["SummeryType"].ToString()) != 0)//�л���
                        {
                            p_View.Columns[fn].SummaryItem.SummaryType = ProcessGrid.GetSummeryTypeByInt(SysConvert.ToInt32(dt.Rows[i]["SummeryType"].ToString()));
                            p_View.Columns[fn].SummaryItem.FieldName = dt.Rows[i]["FieldName"].ToString();
                            p_View.Columns[fn].SummaryItem.DisplayFormat = dt.Rows[i]["SummeryFormat"].ToString();
                        }
                        else
                        {
                            p_View.Columns[fn].SummaryItem.SummaryType = ProcessGrid.GetSummeryTypeByInt(SysConvert.ToInt32(dt.Rows[i]["SummeryType"].ToString()));
                        }
                        if (dt.Rows[i]["GridEditName"].ToString() != "")//�б༭��
                        {
                            for (int j = 0; j < p_View.GridControl.RepositoryItems.Count; j++)
                            {
                                if (p_View.GridControl.RepositoryItems[j].Name == dt.Rows[i]["GridEditName"].ToString())
                                {
                                    p_View.Columns[fn].ColumnEdit = p_View.GridControl.RepositoryItems[j];
                                }
                            }
                        }
                        else
                        {
                            p_View.Columns[fn].ColumnEdit = null;
                        }

                        if (SysConvert.ToInt32(dt.Rows[i]["GroupType"].ToString()) != 0)//�з������
                        {
                            ProcessGrid.SetGroupType(p_View, dt.Rows[i]["FieldName"].ToString(), SysConvert.ToInt32(dt.Rows[i]["GroupType"].ToString()));
                            ProcessGrid.SetGroupFormat(p_View, dt.Rows[i]["FieldName"].ToString(), SysConvert.ToString(dt.Rows[i]["GroupFormat"].ToString()));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��GridView��FieldNameת��ΪList
        /// </summary>
        /// <param name="p_view"></param>
        /// <returns></returns>
        public static List<string> GetFieldNameList(GridView p_view)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < p_view.Columns.Count; i++)
            {
                list.Add(p_view.Columns[i].FieldName);
            }
            return list;
        }
        #endregion

        #region У��ؼ��Ƿ���ֵ
        /// <summary>
        /// У��LookUpEdit �ؼ�ֵ��Text�Ƿ�Ϊ��
        /// </summary>
        /// <param name="p_Drp">�ؼ�</param>
        /// <returns>true/false:��/�ǿ�</returns>
        public static bool CheckLookUpEditBlank(LookUpEdit p_Drp)
        {
            if (SysConvert.ToString(p_Drp.EditValue) == "" || p_Drp.Text == "")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// У��ֵ�Ƿ�Ϊ��
        /// </summary>
        /// <param name="p_Value"></param>
        /// <returns></returns>
        public static bool IsEmpty(string p_Value)
        {
            return string.IsNullOrEmpty(p_Value);
        }
        /// <summary>
        /// У��ֵ�Ƿ�Ϊ��
        /// </summary>
        /// <param name="p_Control"></param>
        /// <returns></returns>
        public static bool IsEmpty(TextEdit p_Control)
        {
            return IsEmpty(p_Control.Text);
        }
        /// <summary>
        /// У��ֵ�Ƿ�Ϊ��
        /// </summary>
        /// <param name="p_Control"></param>
        /// <returns></returns>
        public static bool IsEmpty(ComboBoxEdit p_Control)
        {
            return IsEmpty(p_Control.Text);
        }
        /// <summary>
        /// У��ֵ�Ƿ�Ϊ��
        /// </summary>
        /// <param name="p_Control"></param>
        /// <returns></returns>
        public static bool IsEmpty(LookUpEdit p_Control)
        {
            return CheckLookUpEditBlank(p_Control);
        }
        /// <summary>
        /// У��CheckEdit�Ƿ�ѡ��
        /// </summary>
        /// <param name="p_Control"></param>
        /// <returns>ѡ�з���false ���򷵻�true</returns>
        public static bool IsEmpty(CheckEdit p_Control)
        {
            return !p_Control.Checked;
        }
        #endregion

        #region �󶨴õ�
        /// <summary>
        /// �����дõ�
        /// </summary>
        public static void BindCDALL(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT ID,Name FROM Enum_CDKF WHERE 1=1";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
        /// <summary>
        /// �����дõ�
        /// </summary>
        public static void BindCDAll(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            //p_DrpID.Properties.ShowFooter = false;
            //p_DrpID.Properties.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT ID,Name FROM Enum_CDKF WHERE 1=1";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨴õ�����
        /// </summary>
        public static void BindCDTypeID(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT ID,Name FROM Enum_CDTypeID WHERE 1=1";

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        #endregion

        #region ���ؼ���ʼ��ֵ
        /// <summary>
        /// ��ʼ����ѯ���ڵķ�Χ
        /// </summary>
        /// <param name="p_QueryDateB">��ѯ��ʼ����</param>
        /// <param name="p_QueryDateE">��ѯ��ֹ����Ĭ��Ϊ����</param>
        /// <param name="p_QueryDayNum">��ѯ��ʼ���ڴӵ�����ǰ�Ƶ�����</param>
        public static void SetQueryDateRange(DateEdit p_QueryDateB, DateEdit p_QueryDateE, int p_QueryDayNum)
        {
            p_QueryDateB.DateTime = DateTime.Now.AddDays(0 - p_QueryDayNum);
            p_QueryDateE.DateTime = DateTime.Now;
        }
        /// <summary>
        /// ��ʼ����ѯ���ڵķ�Χ(ϵͳ���õ�Ĭ�Ϸ�Χ)
        /// </summary>
        /// <param name="p_QueryDateB">��ѯ��ʼ����</param>
        /// <param name="p_QueryDateE">��ѯ��ֹ����Ĭ��Ϊ����</param>
        public static void SetQueryDateRange(DateEdit p_QueryDateB, DateEdit p_QueryDateE)
        {
            SetQueryDateRange(p_QueryDateB, p_QueryDateE, FParamConfig.QueryDayNum);
        }
        /// <summary>
        /// ���������Զ���������
        /// </summary>
        /// <param name="p_FabricTypeCode"></param>
        /// <param name="p_FabricType"></param>
        public static void ProcFabricType(ComboBoxEdit p_FabricTypeCode, TextEdit p_FabricType, TextEdit p_FabricTypeEn)
        {
            BindFabricType(p_FabricTypeCode, true);
            //  p_FabricTypeCode.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;//ֻ׼��ѡ��
            p_FabricTypeCode.DoubleClick += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                      
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }
                );
            p_FabricTypeCode.EditValueChanged += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                        string sql = string.Empty;
                        sql += " SELECT Code,Name,NameEN FROM Enum_FabricType WHERE 1=1 ";
                        sql += string.Format(" AND Code={0}", SysString.ToDBString(p_FabricTypeCode.Text));
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            p_FabricType.Text = SysConvert.ToString(dt.Rows[0]["Name"]);
                            p_FabricTypeEn.Text = SysConvert.ToString(dt.Rows[0]["NameEN"]);
                        }
                        else
                        {
                            p_FabricTypeCode.Text = "";
                            p_FabricType.Text = "";
                            p_FabricTypeEn.Text = "";
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }
                );
        }
        /// <summary>
        /// ���������Զ���������
        /// </summary>
        /// <param name="p_FabricTypeCode"></param>
        /// <param name="p_FabricType"></param>
        public static void ProcFabricType(LookUpEdit p_FabricTypeCode, TextEdit p_FabricType, TextEdit p_FabricTypeEn)
        {
            BindFabricType(p_FabricTypeCode, true);
            //  p_FabricTypeCode.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;//ֻ׼��ѡ��
            p_FabricTypeCode.DoubleClick += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                         
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }
                );
            p_FabricTypeCode.EditValueChanged += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                        string sql = string.Empty;
                        sql += " SELECT Code,Name,NameEN FROM Enum_FabricType WHERE 1=1 ";
                        sql += string.Format(" AND Code={0}", SysString.ToDBString(p_FabricTypeCode.EditValue.ToString()));
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            p_FabricType.Text = SysConvert.ToString(dt.Rows[0]["Name"]);
                            p_FabricTypeEn.Text = SysConvert.ToString(dt.Rows[0]["NameEN"]);
                        }
                        else
                        {
                            p_FabricTypeCode.Text = "";
                            p_FabricType.Text = "";
                            p_FabricTypeEn.Text = "";
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }
                );
        }

        /// <summary>
        /// ���������Զ���������
        /// </summary>
        /// <param name="p_FabricTypeCode"></param>
        /// <param name="p_FabricType"></param>
        public static void ProcFabricType(ComboBoxEdit p_FabricTypeCode, TextEdit p_FabricType)
        {
            BindFabricType(p_FabricTypeCode, true);
            //  p_FabricTypeCode.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;//ֻ׼��ѡ��
            p_FabricTypeCode.DoubleClick += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    try
                    {
                       
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }
                );
            //p_FabricTypeCode.EditValueChanged += new EventHandler(
            //    delegate(object sender, EventArgs e)
            //    {
            //        try
            //        {
            //            string sql = string.Empty;
            //            sql += " SELECT Code,Name,NameEN FROM Enum_FabricType WHERE 1=1 ";
            //            sql += string.Format(" AND Code={0}", SysString.ToDBString(p_FabricTypeCode.Text));
            //            DataTable dt = SysUtils.Fill(sql);
            //            if (dt.Rows.Count != 0)
            //            {
            //                p_FabricType.Text = SysConvert.ToString(dt.Rows[0]["Name"]);
            //            }
            //            else
            //            {
            //                p_FabricTypeCode.Text = "";
            //                p_FabricType.Text = "";
            //            }
            //        }
            //        catch (Exception E)
            //        {
            //            MessageBox.Show(E.Message);
            //        }
            //    }
            //    );
        }

        /// <summary>
        /// �󶨲���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricType(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            BindRepositoryItemComboBox(p_DrpID, "Enum_FabricType", "Code", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲�����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricType(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            BindComboBoxEdit(p_DrpID, "Enum_FabricType", "Name", p_ShowBlank);
        }
        /// <summary>
        /// �󶨲�����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindRepositoryItemLookUpEdit(p_DrpID, "Enum_FabricType", "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲�����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindLookUpEdit(p_DrpID, "Enum_FabricType", "Name", "Code", p_ShowBlank);
        }
        #endregion

        #region ͨ�ð�
        /// <summary>
        /// ��LookUpEditͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName">��ѯ����</param>
        /// <param name="p_DisplayMember">��ʾ��Ա</param>
        /// <param name="p_ValueMember">ֵ��Ա</param>
        /// <param name="p_Condition">��ѯ����</param>
        /// <param name="p_ShowCode">�󶨵ı����Ƿ���ʾ</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ�հ�</param>
        /// <param name="p_ShowDefault">�Ƿ���ʾĬ��ѡ����(������Դ��Ҫ��DefaultShow�ֶ�,����ֵ��Ϊ1</param>
        public static void BindLookUpEdit(LookUpEdit p_DrpID, string p_TableName, string p_DisplayMember, string p_ValueMember, string p_Condition, bool p_ShowCode, bool p_ShowBlank, bool p_ShowDefault)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { p_ValueMember, p_DisplayMember }, new string[2] { "����", "����" }, new bool[2] { p_ShowCode, true });
            //FCommon.LookupEditColAdd(p_DrpID, new int[1] { p_DrpID.Width }, new string[1] { p_DisplayMember }, new string[1] { "����" }, new bool[1] { true });
            string fieldName = p_ValueMember + "," + p_DisplayMember;
            if (p_ShowDefault)
            {
                fieldName += ",DefaultShow";
            }
            string sql = "SELECT " + fieldName + " FROM " + p_TableName + " WHERE 1=1";
            sql += p_Condition;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, p_DisplayMember, p_ValueMember, p_ShowBlank);
            if (p_ShowDefault)
            {
                if (dt.Columns.Contains("DefaultShow"))
                {
                    DataRow[] Seldr = dt.Select("ISNULL(DefaultShow,0)=1");

                    if (Seldr.Length > 0)
                    {
                        p_DrpID.EditValue = SysConvert.ToInt32(Seldr[0][p_ValueMember].ToString());
                    }
                }
            }
        }
        /// <summary>
        /// ��LookUpEditͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName">��ѯ����</param>
        /// <param name="p_DisplayMember">��ʾ��Ա</param>
        /// <param name="p_ValueMember">ֵ��Ա</param>
        /// <param name="p_ShowCode">�Է�ʾ�󶨵ı��</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ�հ�</param>
        public static void BindLookUpEdit(LookUpEdit p_DrpID, string p_TableName, string p_DisplayMember, string p_ValueMember, bool p_ShowCode, bool p_ShowBlank)
        {
            BindLookUpEdit(p_DrpID, p_TableName, p_DisplayMember, p_ValueMember, string.Empty, p_ShowCode, p_ShowBlank, false);
        }

        /// <summary>
        /// ��LookUpEditͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName">��ѯ����</param>
        /// <param name="p_DisplayMember">��ʾ��Ա</param>
        /// <param name="p_ValueMember">ֵ��Ա</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ�հ�</param>
        public static void BindLookUpEdit(LookUpEdit p_DrpID, string p_TableName, string p_DisplayMember, string p_ValueMember, bool p_ShowBlank)
        {
            BindLookUpEdit(p_DrpID, p_TableName, p_DisplayMember, p_ValueMember, string.Empty, true, p_ShowBlank, false);
        }
        /// <summary>
        /// ��RepositoryItemLookUpEditͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName">��ѯ����</param>
        /// <param name="p_DisplayMember">��ʾ��Ա</param>
        /// <param name="p_ValueMember">ֵ��Ա</param>
        /// <param name="p_Condition">��ѯ����</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ�հ�</param>
        /// <param name="p_ShowDefault">�Ƿ���ʾĬ��ѡ����(������Դ��Ҫ��DefaultShow�ֶ�,����ֵ��Ϊ1</param>
        public static void BindRepositoryItemLookUpEdit(RepositoryItemLookUpEdit p_DrpID, string p_TableName, string p_DisplayMember, string p_ValueMember, string p_Condition, bool p_ShowBlank, bool p_ShowDefault)
        {
            p_DrpID.ShowFooter = true;
            p_DrpID.ShowHeader = true;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { p_ValueMember, p_DisplayMember }, new string[2] { "����", "����" }, new bool[2] { true, true });
            string sql = "SELECT " + p_ValueMember + "," + p_DisplayMember + " FROM " + p_TableName + " WHERE 1=1";
            sql += p_Condition;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, p_DisplayMember, p_ValueMember, p_ShowBlank);
            //if (p_ShowDefault)
            //{
            //    if (dt.Columns.Contains("DefaultShow"))
            //    {
            //        DataRow[] Seldr = dt.Select("ISNULL(DefaultShow,0)=1", "ID ASC");
            //        if (Seldr.Length > 0)
            //        {

            //            p_DrpID = Seldr[0][p_ValueMember].ToString();
            //        }
            //    }
            //}
        }
        /// <summary>
        /// ��RepositoryItemLookUpEditͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName">��ѯ����</param>
        /// <param name="p_DisplayMember">��ʾ��Ա</param>
        /// <param name="p_ValueMember">ֵ��Ա</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ�հ�</param>
        public static void BindRepositoryItemLookUpEdit(RepositoryItemLookUpEdit p_DrpID, string p_TableName, string p_DisplayMember, string p_ValueMember, bool p_ShowBlank)
        {
            BindRepositoryItemLookUpEdit(p_DrpID, p_TableName, p_DisplayMember, p_ValueMember, string.Empty, p_ShowBlank, false);
        }
        /// <summary>
        /// ��RepositoryItemComboBoxͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName">��ѯ����</param>
        /// <param name="p_DisplayMember">��ʾ��Ա</param>
        /// <param name="p_Condition">��ѯ����</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ�հ�</param>
        /// <param name="p_ShowDefault">�Ƿ���ʾĬ��ѡ����(������Դ��Ҫ��DefaultShow�ֶ�,����ֵ��Ϊ1</param>
        public static void BindRepositoryItemComboBox(RepositoryItemComboBox p_DrpID, string p_TableName, string p_DisplayMember, string p_Condition, bool p_ShowBlank, bool p_ShowDefault)
        {
            //p_DrpID.TextEditStyle = TextEditStyles.DisableTextEditor;
            string sql = string.Format("SELECT {0} FROM {1} WHERE 1=1 {2}", p_DisplayMember, p_TableName, p_Condition);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropItemComb(p_DrpID, dt, p_DisplayMember, p_ShowBlank);
            //if (p_ShowDefault)
            //{
            //    if (dt.Columns.Contains("DefaultShow"))
            //    {
            //        DataRow[] Seldr = dt.Select("ISNULL(DefaultShow,0)=1", "ID ASC");
            //        if (Seldr.Length > 0)
            //        {
            //            p_DrpID = Seldr[0][p_DisplayMember].ToString();
            //        }
            //    }
            //}
        }
        /// <summary>
        /// ��RepositoryItemComboBoxͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName"></param>
        /// <param name="p_DisplayMember"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindRepositoryItemComboBox(RepositoryItemComboBox p_DrpID, string p_TableName, string p_DisplayMember, bool p_ShowBlank)
        {
            BindRepositoryItemComboBox(p_DrpID, p_TableName, p_DisplayMember, string.Empty, p_ShowBlank, false);
        }
        /// <summary>
        /// ��ComboBoxEditͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName">��ѯ����</param>
        /// <param name="p_DisplayMember">��ʾ��Ա</param>
        /// <param name="p_Condition">��ѯ����</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ�հ�</param>
        /// <param name="p_ShowDefault">�Ƿ���ʾĬ��ѡ����(������Դ��Ҫ��DefaultShow�ֶ�,����ֵ��Ϊ1</param>
        public static void BindComboBoxEdit(ComboBoxEdit p_DrpID, string p_TableName, string p_DisplayMember, string p_Condition, bool p_ShowBlank, bool p_ShowDefault)
        {
            string sql = string.Format("SELECT {0} FROM {1} WHERE 1=1 {2}", p_DisplayMember, p_TableName, p_Condition);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, p_DisplayMember, p_ShowBlank);
            if (p_ShowDefault)
            {
                if (dt.Columns.Contains("DefaultShow"))
                {
                    DataRow[] Seldr = dt.Select("ISNULL(DefaultShow,0)=1", "ID ASC");
                    if (Seldr.Length > 0)
                    {

                        p_DrpID.EditValue = Seldr[0][p_DisplayMember].ToString();
                    }
                }
            }
        }
        /// <summary>
        ///  ��ComboBoxEditͨ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName"></param>
        /// <param name="p_DisplayMember"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindComboBoxEdit(ComboBoxEdit p_DrpID, string p_TableName, string p_DisplayMember, bool p_ShowBlank)
        {
            BindComboBoxEdit(p_DrpID, p_TableName, p_DisplayMember, string.Empty, p_ShowBlank, false);
        }
        #endregion


        #region ֯������Ԥ�żƻ�����
        /// <summary>
        ///GridView���ù̶��� 
        /// </summary>
        /// <param name="p_View"></param>
        /// <param name="p_ColumnName"></param>
        public static void SetGridColumnFixed(GridView p_View, string p_ColumnName)
        {
            SetGridColumnFixed(p_View, new string[] { p_ColumnName });
        }
        /// <summary>
        /// GridView���ù̶��� 
        /// </summary>
        /// <param name="p_View"></param>
        /// <param name="p_ColumnName"></param>
        public static void SetGridColumnFixed(GridView p_View, string[] p_ColumnName)
        {
            for (int i = p_ColumnName.Length - 1; i >= 0; i--)
            {
                p_View.Columns[p_ColumnName[i]].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
        }
        /// <summary>
        /// ���ù̶���
        /// </summary>
        /// <param name="p_view"></param>
        /// <param name="p_ID"></param>
        public static void SetColumnFixed(BandedGridView p_view, string[] p_str)
        {
            GridBand band = new GridBand();
            band.Name = "FixedBand";
            band.Caption = "�̶���";
            band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            if (p_str.Length != 0)
            {
                for (int i = 0; i < p_str.Length; i++)
                {
                    band.Columns.Add(p_view.Columns[p_str[i]]);
                }
                band.OptionsBand.AllowSize = true;
                p_view.Bands.Add(band);
            }

        }

        /// <summary>
        /// ��û�̨����
        /// </summary>
        /// <param name="p_MachineType">��̨����</param>
        /// <returns></returns>
        public static DataTable GetMachineByType(string[] p_MachineType)
        {
            string sql = string.Empty;
            sql = "SELECT * FROM Data_MachineManage WHERE UserFlag=1 ";
            string QueryStr = ConvertArrayStringToStr(p_MachineType);

            if (QueryStr != string.Empty)
            {
                sql += " AND MachineType IN (" + QueryStr + ")";
            }
            // sql += "AND ISNULL(Remark,'')=''";
            sql += "ORDER BY Code";
            return SysUtils.Fill(sql);
        }

        /// <summary>
        /// ����ָ�����͵����л�̨����Lable���� 2012--10-12 zhaixed
        /// </summary>
        /// <param name="p_GC">����GroupControl</param>
        /// <param name="p_MachineType">����</param>
        /// <param name="ScreenWidth">��Ļ���</param>
        public static void CreateShowMachine(DevExpress.XtraEditors.GroupControl p_GC, string[] p_MachineType, int ScreenWidth)
        {
            int BarWidth = 70;
            int BarHeight = 90;
            int BarTop = 13;
            int BarLeft = 5;
            int LblLeft = 3;
            int LblWidth = BarWidth - 2 * LblLeft;
            int ShowLblHeight = 20;
            int labHeight2 = 50;
            int ShowLblTop = 3;
            int ScreeWidht = ScreenWidth;
            int RowCount = ScreeWidht / (BarWidth + BarLeft);

            //Rectangle rec = System.Windows.Forms.Screen.GetBounds(frmWOSchedule2);
            DataTable dtMaData = GetMachineByType(p_MachineType);    //rule.AutoJarGetJarBase(p_MachineType);
            int CurRow = 0;
            int Index = 0;
            for (int i = 0; i < dtMaData.Rows.Count; i++)
            {
                if (i > 0 && (i % (RowCount - 1)) == 0)
                {
                    Index = 0;
                    CurRow++;
                }
                ProgressBarControl sectionBar = new ProgressBarControl();
                sectionBar.Tag = dtMaData.Rows[i]["Code"].ToString();// p_MaxWeight;
                sectionBar.Left = BarWidth * Index + (Index + 1) * BarLeft;
                sectionBar.Top = BarHeight * CurRow + (CurRow + 1) * BarTop;
                sectionBar.Width = BarWidth;
                sectionBar.Height = BarHeight;
                sectionBar.BorderStyle = BorderStyles.Style3D;
                sectionBar.BackColor = System.Drawing.Color.LawnGreen;
                sectionBar.Text = dtMaData.Rows[i]["Code"].ToString();

                Label Lb = new Label();
                Lb.Text = dtMaData.Rows[i]["Code"].ToString() + "|" + dtMaData.Rows[i]["DayOuty"].ToString() + "KG";
                Lb.Tag = "False";
                Lb.Top = ShowLblTop;        //3
                Lb.Left = LblLeft;          //3
                Lb.Width = LblWidth;        //BarWidth - 2 * LblLeft
                Lb.Height = ShowLblHeight;  //15
                Lb.AutoSize = true;
                sectionBar.Controls.Add(Lb);

                Label Lb2 = new Label();
                Lb2.Text = "0";
                Lb2.Tag = "True";
                Lb2.Top = 2 * ShowLblTop + ShowLblHeight;
                Lb2.Left = LblLeft;
                Lb2.Width = LblWidth;
                Lb2.ForeColor = Color.Red;
                Lb2.Height = labHeight2; // BarHeight - Lb2.Top;
                Lb2.Font = new Font("����", 24, FontStyle.Bold);
                Lb2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                sectionBar.Controls.Add(Lb2);

                Label lb3 = new Label();
                lb3.Text = "";
                lb3.Tag = "Date";
                lb3.Top = 2 * ShowLblTop + ShowLblHeight + labHeight2;
                lb3.Left = LblLeft;
                lb3.Width = LblWidth;
                //lb3.ForeColor = Color.Red;
                lb3.Height = BarHeight - lb3.Top;
                //lb3.Font=new Font("����",8);
                lb3.AutoSize = true;
                sectionBar.Controls.Add(lb3);
                //sectionBar.DoubleClick += new EventHandler(progressBarControl_DoubleClick);

                p_GC.Controls.Add(sectionBar);

                Index++;

            }
        }

        /// <summary>
        /// ����ÿ����̨��Ӧ�����������Ϣ 2012-10-12 zhaixd
        /// </summary>
        /// <param name="p_GC">��̨���ڵ�GroupControl</param>
        /// <param name="p_BeginDate">�ϻ�����</param>
        /// <param name="p_MachineType">����</param>
        /// <param name="ToolTips"></param>
        public static void RefreshMachine(DevExpress.XtraEditors.GroupControl p_GC, DateTime p_BeginDate, DateTime p_EndDate, string[] p_MachineType, Hashtable ToolTips)
        {
            string outstr = string.Empty;
            outstr += " AND CONVERT(CHAR(10),BeginDate,120) BETWEEN" + SysString.ToDBString(p_BeginDate.ToString("yyyy-MM-dd"));
            outstr += " AND " + SysString.ToDBString(p_EndDate.ToString("yyyy-MM-dd"));

            string MaType = ConvertArrayStringToStr(p_MachineType);
            if (MaType != string.Empty)
            {
                outstr += " AND MachineType IN(" + MaType + ") ";
            }
            outstr += " AND ISNULL(CancelFlag,0)=0 ";
            outstr += " AND ISNULL(FinishFlag,0)=0 ";
            string filedStr = "VendorAttn,ReviewNo,ProductNo,PZQty,SO,MachineType,MachineCode,BeginDate,EndDate";

            DataTable dt = new DataTable();
            if (dt.Rows.Count != 0)
            {
                foreach (Control cl in p_GC.Controls)
                {
                    if (cl is ProgressBarControl)
                    {
                        //int InfoCounts = 0;         //��¼ÿ����̨��Ԥ����Ϣ��
                        ProgressBarControl pc = (ProgressBarControl)cl;
                        foreach (Control lb in pc.Controls)
                        {
                            if (lb is Label)
                            {
                                Label Lab = (Label)lb;

                                if (Lab.Tag.ToString() == "True")
                                {

                                    DataRow[] MachineItems = dt.Select("MachineCode=" + SysString.ToDBString(pc.Tag.ToString()));
                                    Lab.Text = MachineItems.Length.ToString();

                                    if (ToolTips.Contains(pc.Tag.ToString()))
                                    {
                                        System.Windows.Forms.ToolTip tp = (System.Windows.Forms.ToolTip)ToolTips[pc.Tag.ToString()];
                                        tp.RemoveAll();
                                        tp.ToolTipIcon = ToolTipIcon.Info;
                                        tp.ToolTipTitle = "֯��Ԥ����ϸ��Ϣ";
                                        tp.AutomaticDelay = 20000;
                                        tp.InitialDelay = 1000;
                                        tp.ReshowDelay = 200;
                                        tp.ShowAlways = true;

                                        string MaInfor = GetMachineInfor(MachineItems);
                                        if (MaInfor != string.Empty)
                                        {
                                            tp.SetToolTip(Lab, MaInfor);
                                            ToolTips[pc.Tag.ToString()] = tp;
                                        }
                                    }
                                    else
                                    {
                                        System.Windows.Forms.ToolTip tp = new System.Windows.Forms.ToolTip();
                                        tp.ToolTipIcon = ToolTipIcon.Info;
                                        tp.ToolTipTitle = "֯��Ԥ����ϸ��Ϣ";
                                        tp.AutomaticDelay = 20000;
                                        tp.InitialDelay = 1000;
                                        tp.ReshowDelay = 500;
                                        tp.ShowAlways = true;
                                        string MaInfor = GetMachineInfor(MachineItems);
                                        if (MaInfor != string.Empty)
                                        {
                                            tp.SetToolTip(Lab, MaInfor);
                                            ToolTips.Add(pc.Tag.ToString(), tp);
                                        }
                                    }
                                    //break;
                                }
                                else if (Lab.Tag.ToString() == "Date")
                                {
                                    DataRow[] Maxdr = dt.Select("MachineCode=" + SysString.ToDBString(pc.Tag.ToString()), "EndDate desc");
                                    if (Maxdr.Length > 0)
                                    {
                                        string LastDate = SysConvert.ToDateTime(Maxdr[0]["EndDate"]).ToString("yyyy-MM-dd");
                                        Lab.Text = LastDate;
                                    }
                                    else
                                    {
                                        Lab.Text = "";
                                    }
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                foreach (Control cl in p_GC.Controls)
                {
                    if (cl is ProgressBarControl)
                    {
                        ProgressBarControl pc = (ProgressBarControl)cl;
                        foreach (Control lb in pc.Controls)
                        {
                            if (lb is Label)
                            {
                                Label Lab = (Label)lb;
                                if (Lab.Tag.ToString() == "True")
                                {
                                    Lab.Text = "0";
                                    if (ToolTips.Contains(pc.Tag.ToString()))
                                    {
                                        System.Windows.Forms.ToolTip tp = (System.Windows.Forms.ToolTip)ToolTips[pc.Tag.ToString()];
                                        tp.RemoveAll();
                                    }
                                    //break;
                                }
                                else if (Lab.Tag.ToString() == "Date")
                                {
                                    Lab.Text = "";
                                    break;
                                }
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// ��һ����̨�е�Ԥ����Ϣ���ܳ���������
        /// </summary>
        /// <param name="p_JarNumItems"></param>
        /// <returns></returns>
        public static string GetMachineInfor(DataRow[] p_MachineItems)
        {
            string MaInfor = string.Empty;
            decimal TotalQty = 0m;
            foreach (DataRow dr in p_MachineItems)
            {
                TotalQty += SysConvert.ToDecimal(dr["PZQty"]);
                MaInfor += "�ͻ���" + dr["VendorAttn"].ToString() + " ������:" + dr["SO"].ToString() + " ��Ʒ���:" + dr["ProductNo"].ToString() + " ��̨:" + dr["MachineCode"].ToString() + " ֯����:" + dr["PZQty"].ToString() + " �ϻ�ʱ��:" + SysConvert.ToDateTime(dr["BeginDate"]).ToString("yyyy-MM-dd") + " Ԥ�����ʱ��:" + SysConvert.ToDateTime(dr["EndDate"]).ToString("yyyy-MM-dd") + Environment.NewLine;
            }
            if (TotalQty != 0m)
            {
                MaInfor += "��֯������" + TotalQty.ToString();
            }
            return MaInfor;
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void progressBarControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //ProgressBarControl PC = (ProgressBarControl)sender;
                //string MachineCode = PC.Tag.ToString();
                //string sql = "SELECT MachineType FROM Data_MachineManage WHERE UserFlag=1";
                //sql += " AND Code=" + SysString.ToDBString(MachineCode);
                //DataTable dtma = SysUtils.Fill(sql);
                //string Machinetype = dtma.Rows[0][0].ToString();
                //frmLoadSaleOrderReview frm = new frmLoadSaleOrderReview();
                ////frm.LoadType = (int)EnumLoadSaleOrder.֯������Ԥ�żƻ���������;
                //frm.Conn = " AND MachineType=" + SysString.ToDBString(Machinetype);
                //frm.MachineType = Machinetype;
                //frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{

                //}
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// ���ƶ����͵����л�̨
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMachineByType(RepositoryItemLookUpEdit p_DrpID, string[] p_MachineType, bool p_ShowBlank)
        {
            p_DrpID.ShowFooter = true;
            p_DrpID.ShowHeader = true;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "Code", "MachineType" }, new string[2] { "����", "����" }, new bool[2] { true, true });
            string sql = "SELECT Code,MachineType FROM Data_MachineManage WHERE 1=1";
            string MaType = ConvertArrayStringToStr(p_MachineType);
            if (MaType != string.Empty)
            {
                sql += " AND MachineType IN(" + MaType + ")";
            }
            sql += " ORDER BY MachineType,Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Code", "Code", p_ShowBlank);
        }
        /// <summary>
        /// ���ƶ����͵����л�̨
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindMachineByType(LookUpEdit p_DrpID, string[] p_MachineType, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = true;
            p_DrpID.Properties.ShowHeader = true;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "Code", "MachineType" }, new string[2] { "����", "����" }, new bool[2] { true, true });
            string sql = "SELECT Code,MachineType FROM Data_MachineManage WHERE 1=1";
            string MaType = ConvertArrayStringToStr(p_MachineType);
            if (MaType != string.Empty)
            {
                sql += " AND MachineType IN(" + MaType + ")";
            }
            sql += " ORDER BY MachineType,Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Code", "Code", p_ShowBlank);
        }
        #endregion

        #region �ɹ��������

        public static string GetWHName(string p_WHID)
        {
            string str = string.Empty;
            string sql = "SELECT WHNM FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                str = SysConvert.ToString(dt.Rows[0][0]);
            }
            return str;

        }

        /// <summary>
        /// �󶨲ɹ�ָ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_TableName"></param>
        /// <param name="p_FieldName"></param>
        public static void BindCGZhiDing(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {

            BindCLS(p_DrpID, "Sale_OrderReviewItem", "CGZhiDing", p_ShowBlank);
        }

        //  /// <summary>
        ///// �����ȹ������ù̶���
        ///// </summary>
        ///// <param name="p_view"></param>
        ///// <param name="p_ID"></param>
        //public static void SetScheduleColumnFixed(BandedGridView p_view, int p_ID)
        //{
        //    GridBand band = new GridBand();
        //    band.Name = "FixedBand";
        //    band.Caption = "�̶���";
        //    band.Fixed = FixedStyle.Left;
        //    string sql = "";
        //    sql += " SELECT FixColumnName FROM Enum_BuyFormType WHERE ID=" + p_ID;
        //    DataTable dt = SysUtils.Fill(sql);
        //    string str = "";
        //    if (dt.Rows.Count != 0)
        //    {
        //        str = SysConvert.ToString(dt.Rows[0]["FixColumnName"]);

        //        string[] FixedColumns = str.Split(SystemConst.SpearateTokenComma.ToCharArray());
        //        for (int i = 0; i < FixedColumns.Length; i++)
        //        {
        //            band.Columns.Add(p_view.Columns[FixedColumns[i]]);

        //        }
        //        band.OptionsBand.AllowSize = true;
        //        p_view.Bands.Add(band);
        //    }

        //}

        #endregion

        /// <summary>
        /// �󶨶���֯������(��ѡ��Ĭ��ֵ)
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindZZType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindLookUpEdit(p_DrpID, "Enum_ZZType", "Name", "ID", " AND ISNULL(DelFlag,0)=0", false, true, false);    //��֯������
        }
        /// <summary>
        /// �󶨶���֯������(ѡ��Ĭ��ֵ)
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank">�󶨿���</param>
        /// <param name="p_ShowBlank">ѡ��Ĭ��ֵ����Ҫ��DefaultShow �ֶ�)</param>
        public static void BindZZType(LookUpEdit p_DrpID, bool p_ShowBlank, bool p_ShowDefault)
        {
            BindLookUpEdit(p_DrpID, "Enum_ZZType", "Name", "ID", " AND ISNULL(DelFlag,0)=0", false, true, p_ShowDefault);    //��֯������
        }
        /// <summary>
        /// �󶨶����������� ==����/����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindOrderSaleType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindLookUpEdit(p_DrpID, "Enum_SaleOrderType", "Name", "ID", " AND ISNULL(DelFlag,0)=0", false, true, false); //" AND ISNULL(DelFlag,0)=0", "Enum_SaleOrderType", "Name", "ID", true);    //��֯������
        }

        /// <summary>
        /// ���ƶ����ϵ���ɫ����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="ItemCode"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindColorSchemes(RepositoryItemLookUpEdit p_DrpID, string ItemCode, bool p_ShowBlank)
        {
            p_DrpID.ShowFooter = false;
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[3] { 50, 50, 50 }, new string[3] { "Code", "ColorNum", "ColorName" }, new string[3] { "���", "ɫ��", "ɫ��" }, new bool[3] { true, true, true });
            string sql = "SELECT * FROM Data_FabricColor WHERE 1=1";
            sql += " AND MainCode=" + SysString.ToDBString(ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Code", "Code", p_ShowBlank);

        }
        /// <summary>
        /// ���ƶ�������ɫ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="ItemCode"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricColorName(RepositoryItemComboBox p_DrpID, string ItemCode, bool p_ShowBlank)
        {
            // FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[3] { 50, 50, 50 }, new string[3] { "Code", "ColorNum", "ColorName" }, new string[3] { "���", "ɫ��", "ɫ��" }, new bool[3] { true, true, true });
            string sql = "SELECT * FROM Data_FabricColor WHERE 1=1";
            sql += " AND MainCode=" + SysString.ToDBString(ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropItemComb(p_DrpID, dt, "ColorName", p_ShowBlank);
        }


        public static void BindFlower(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            // FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[3] { 50, 50, 50 }, new string[3] { "Code", "ColorNum", "ColorName" }, new string[3] { "���", "ɫ��", "ɫ��" }, new bool[3] { true, true, true });
            string sql = "SELECT Freestr15 FROM Data_FlowerTypeContolDts WHERE 1=1";

            DataTable dt = SysUtils.Fill(sql);

            FCommon.LoadDropItemComb(p_DrpID, dt, "Freestr15", p_ShowBlank);
        }
        /// <summary>
        /// ���ƶ�����ɫ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="ItemCode"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricColorNum(RepositoryItemComboBox p_DrpID, string ItemCode, bool p_ShowBlank)
        {
            // FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[3] { 50, 50, 50 }, new string[3] { "Code", "ColorNum", "ColorName" }, new string[3] { "���", "ɫ��", "ɫ��" }, new bool[3] { true, true, true });
            string sql = "SELECT * FROM Data_FabricColor WHERE 1=1";
            sql += " AND MainCode=" + SysString.ToDBString(ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropItemComb(p_DrpID, dt, "ColorNum", p_ShowBlank);
        }


        /// <summary>
        ///  ��ȡGridView��ǰҪ��ֵ�������
        /// </summary>
        /// <param name="p_Grid">Ҫ���ҵ�GridView</param>
        /// <param name="p_FieldName">Ҫ�������ֶ�</param>
        /// <returns></returns>
        public static int checkRowSet(GridView p_Grid, string p_FieldName)
        {
            int index = 0;
            for (int i = 0; i < p_Grid.RowCount; i++)
            {
                if (SysConvert.ToString(p_Grid.GetRowCellValue(i, p_FieldName)) == string.Empty)
                {
                    index = i;
                    return index;
                }
            }
            return index;

        }

        /// <summary>
        /// �󶨳����ӹ�����
        /// </summary>
        public static void BindJGType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ProcessType WHERE 1=1";
            sql += " AND ISNULL(DelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        #region ���ŷ����ص�λ

        /// �󶨿��ص�λ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindReqGrammaturaUnit(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, "Sale_QuotedPrice", "ReqGrammaturaUnit", p_ShowBlank);
        }
        /// <summary>
        /// �󶨿��ص�λ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindReqGrammaturaUnit(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            BindCLS(p_DrpID, "Sale_QuotedPrice", "ReqGrammaturaUnit", p_ShowBlank);
        }

        /// <summary>
        /// �������ŷ���λ����ࡢҪ����������롢Ҫ���������ߡ�����쳤�ȵ�λ��Ҫ��б��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricLarghezzaUnit(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            BindRepositoryItemComboBox(p_DrpID, "Enum_FabricLarghezzaUnit", "NameEN", p_ShowBlank);
        }
        /// <summary>
        /// �������ŷ���λ����ࡢҪ����������롢Ҫ���������ߡ�����쳤�ȵ�λ��Ҫ��б��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricLarghezzaUnit(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {
            BindComboBoxEdit(p_DrpID, "Enum_FabricLarghezzaUnit", "NameEN", p_ShowBlank);
        }
        #endregion

        #region �����ݿ��ֶ�����ֵ
        /// <summary>
        /// �����ĳ�ֶθ�ֵ,��Ҫ�����Զ��ύ��
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_Field"></param>
        /// <param name="p_Value"></param>
        public static void SetFieldValue(string p_Condition, string p_TableName, string p_Field, object p_Value)
        {
            string sql = string.Empty;
            sql += " UPDATE " + p_TableName + " SET " + p_Field + " = " + SysString.ToDBString(p_Value.ToString());
            sql += " WHERE 1=1 ";
            sql += p_Condition;
            SysUtils.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// �����ĳ�ֶθ�ֵ,��Ҫ�����Զ��ύ��
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_Field"></param>
        /// <param name="p_Value"></param>
        public static void SetFieldValue(string p_Key, string p_KeyValue, string p_TableName, string p_Field, object p_Value)
        {
            string condition = " AND " + p_Key + " = " + SysString.ToDBString(p_KeyValue);
            SetFieldValue(condition, p_TableName, p_Field, p_Value);
        }
        /// <summary>
        /// �����ĳ�ֶθ�ֵ,��Ҫ�����Զ��ύ��
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_Field"></param>
        /// <param name="p_Value"></param>
        public static void SetFieldValue(int p_KeyValue, string p_TableName, string p_Field, object p_Value)
        {
            SetFieldValue("ID", p_KeyValue.ToString(), p_TableName, p_Field, p_Value);
        }
        /// <summary>
        /// �����ĳ�ֶθ�ֵ,��Ҫ�����Զ��ύ��
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_Field"></param>
        /// <param name="p_Value"></param>
        public static void SetDtsFieldValue(string p_MainID, string p_SeqValue, string p_TableName, string p_Field, object p_Value)
        {
            string condition = " AND MainID=" + p_MainID + " and Seq=" + p_SeqValue;
            SetFieldValue(condition, p_TableName, p_Field, p_Value);
        }


        #endregion


        #region ����GridView
        /// <summary>
        /// ����GridViewָ����ֻ�����ǿ��Ծ۽�
        /// </summary>
        /// <param name="p_grid"></param>
        /// <param name="p_FieldName"></param>
        public static void SetGridColumnReadonlyAllowEdit(GridView p_view, string[] p_FieldName, FormStatus p_FormStatus)
        {
            if (p_FormStatus == FormStatus.���� || p_FormStatus == FormStatus.�޸�)
            {
                for (int i = 0; i < p_FieldName.Length; i++)
                {
                    p_view.Columns[p_FieldName[i]].AppearanceCell.BackColor = SystemConst.GridColumnReadonlyBackColor;
                    p_view.Columns[p_FieldName[i]].OptionsColumn.ReadOnly = true;
                    p_view.Columns[p_FieldName[i]].OptionsColumn.AllowEdit = true;
                }
            }
        }
        /// <summary>
        /// ָ��GridView��ItemCode,ItemName,ItemStd��ֻ�����ǿ��Ծ۽�
        /// </summary>
        /// <param name="p_grid"></param>
        public static void SetGridColumnReadonlyAllowEdit(GridView p_grid, FormStatus p_FormStatus)
        {
            SetGridColumnReadonlyAllowEdit(p_grid, SystemConst.ItemCodeItemNameItemStdArray, p_FormStatus);
        }
        #endregion

        /// <summary>
        /// �󶨿ؼ���ֵ�ı��¼�����Ҫ���ڲ�ѯ�ؼ���ֵ�ı��Ƿ��Զ���ѯ��
        /// </summary>
        /// <param name="p_Control"></param>
        /// <param name="p_handler"></param>
        public static void BindEditValueChangedHandler(BaseEdit[] p_Control, EventHandler p_handler)
        {
            foreach (BaseEdit c in p_Control)
            {
                c.EditValueChanged += p_handler;
            }
        }

        /// <summary>
        /// ��DataTable��ָ���е��ַ���ƴ��Ϊ�����ַ����� DataTable��p_FieldName�������  1 2 3 ƴ�Ӻ�Ϊ1,2,3  
        /// </summary>
        /// <param name="p_dt"></param>
        /// <returns></returns>
        public static string GetConditionStrFromDataTable(DataTable p_dt, string p_FieldName)
        {
            string outstr = string.Empty;
            if (p_dt == null)
            {
                return SysString.ToDBString("");
            }
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                string str = SysConvert.ToString(p_dt.Rows[i][p_FieldName]);
                outstr += SysString.ToDBString(str);
                if (i != p_dt.Rows.Count - 1)
                {
                    outstr += SystemConst.SpearateTokenComma;
                }
            }
            if (outstr == string.Empty)
            {
                outstr = SysString.ToDBString("");
            }
            return outstr;
        }

        /// <summary>
        /// ��GridViewĳ����Ԫ������Ĭ��ֵ
        /// </summary>
        /// <param name="p_view"></param>
        /// <param name="p_ColumnFieldName"></param>
        /// <param name="p_DefaultValue"></param>
        public static void SetGridDefaultValue(GridView p_view, string p_ColumnFieldName, object p_DefaultValue)
        {
            SetGridDefaultValue(p_view, p_view.FocusedRowHandle, p_ColumnFieldName, p_DefaultValue);
        }
        /// <summary>
        /// ��GridViewĳ����Ԫ������Ĭ��ֵ
        /// </summary>
        /// <param name="p_view"></param>
        /// <param name="p_RowHandler"></param>
        /// <param name="p_ColumnFieldName"></param>
        /// <param name="p_DefaultValue"></param>
        public static void SetGridDefaultValue(GridView p_view, int p_RowHandler, string p_ColumnFieldName, object p_DefaultValue)
        {
            string value = GetCellValueString(p_view, p_RowHandler, p_ColumnFieldName);
            if (value == "" && p_view.FocusedColumn.FieldName != p_ColumnFieldName)
            {
                p_view.SetRowCellValue(p_RowHandler, p_ColumnFieldName, p_DefaultValue);
            }
        }

        /// <summary>
        /// ��������Ϣ
        /// </summary>
        public static void BindFabric(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            FCommon.LookupEditColAdd(p_DrpID, new int[3] { 50, 100, 120 }, new string[3] { "Code", "Name", "ComponentDescription" }, new string[3] { "����", "Ʒ��", "�ɷ�" }, new bool[3] { true, true, true });
            string sql = "SELECT ID,Code,Name,ComponentDescription,Code+' '+Name+' '+ComponentDescription Item FROM Data_Fabric WHERE 1=1";
            //sql += " AND ISNULL(DelFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Item", "Code", p_ShowBlank);
        }


        /// <summary>
        /// ���ɴ�߸��ϱ�־
        /// </summary>
        public static int GetItemFHFlag(string p_ItemCode)
        {
            int FHFlag = 0;
            string sql = "SELECT ID,BWFlag,FHFlag FROM Data_Item WHERE 1=1";
            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                FHFlag = SysConvert.ToInt32(dt.Rows[0]["FHFlag"]);
            }
            return FHFlag;
        }

        /// <summary>
        /// ���ɴ�߲�����־
        /// </summary>
        public static int GetItemBWFlag(string p_ItemCode)
        {
            int BWFlag = 0;
            string sql = "SELECT ID,BWFlag,FHFlag FROM Data_Item WHERE 1=1";
            sql += " AND ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count == 1)
            {
                BWFlag = SysConvert.ToInt32(dt.Rows[0]["BWFlag"]);
            }
            return BWFlag;
        }

        /// <summary>
        /// �󶨲�������
        /// </summary>
        public static void BindBWType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 80 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_BWType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨼���״̬
        /// </summary>
        public static void BindJYStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_JYStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨼���״̬
        /// </summary>
        public static void BindJYStatus(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_JYStatus WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static string ChangeArrayListToWhereInStr(ArrayList p_List)
        {
            StringBuilder str = new StringBuilder();
            foreach (string item in p_List)
            {
                if (str.Length <= 0)
                {
                    str.Append(SysString.ToDBString(item));
                }
                else
                {
                    str.Append("," + SysString.ToDBString(item));
                }
            }
            if (str.Length <= 0)
            {
                str.Append(SysString.ToDBString("-99999"));
            }

            return str.ToString();
        }

        #region

        /// <summary>
        /// ����֯
        /// </summary>
        public static void BindOrganization(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT Code,Name FROM Enum_Organization";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        /// <summary>
        /// �󶨾�γ������
        /// </summary>
        public static void BindLLType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT Code,Name FROM Enum_LLType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        /// <summary>
        /// �󶨾�˿��һ�ص�
        /// </summary>
        public static void BindLongitudeFirstCharacteristic(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT Code,Name FROM Enum_LongitudeFirstCharacteristic WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        /// <summary>
        /// �󶨾�˿�ڶ��ص�
        /// </summary>
        public static void BindLongitudeSecondCharacteristic(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT Code,Name FROM Enum_LongitudeSecondCharacteristic";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        /// <summary>
        /// ��γ˿�ص�
        /// </summary>
        public static void BindLatitudeCharacteristic(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT Code,Name FROM Enum_LatitudeCharacteristic";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        #endregion
        #region
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindWHIOType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM UV1_Enum_FormList WHERE ID IN ('4003','4007','1803','1303','4001','3012')";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        #endregion

        #region ��վ��
        /// <summary>
        /// ��ҵ�����
        /// </summary>
        public static void BindStep(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,DName AS Name FROM Enum_SOFlow WHERE 1=1 AND TurnFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }
#endregion



        /// <summary>
        /// ��������ͼƬ
        /// </summary>
        public static Image GetImageByISN(string p_ISN)
        {
            Image outstr = null;
            if (p_ISN != "")
            {
                string sql = "Select ItemImage From Data_Item where 1=1";
                sql += " AND ItemCode=" + SysString.ToDBString(p_ISN);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    if (SysConvert.ToString(dt.Rows[0][0]) != string.Empty)
                    {
                        //outstr = TemplatePic.ByteToImage((byte[])dt.Rows[0]["ItemImage"]);
                    }
                    else
                    {
                        outstr = null;
                    }
                }
            }

            return outstr;
        }


        /// <summary>
        /// ����������
        /// </summary>
        public static void BindDH(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {

            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "ID", "ExName" }, new string[] { "ID", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,ExName FROM ADH_DataDH WHERE 1=1 ORDER BY ID";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "ExName", "ID", p_ShowBlank);
        }




        public static void BindClassID(LookUpEdit p_DrpID, int p_ItemTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "ID", "Name" }, new string[] { "ID", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Data_ItemClass WHERE 1=1";
            sql += " AND ItemTypeID=" + p_ItemTypeID.ToString();
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        ///�ж϶����Ƿ�����޸�
        /// </summary>
        /// <param name="p_Date"></param>
        /// <returns></returns>
        public static bool GetSOModifyFlag(int p_ID)
        {

            bool check = true;

            string sqlcheck = "SELECT ID,FormNo FROM UV1_Sale_SaleOrderSumDts WHERE (CPWJFlag=1 OR GDWJFlag=1) AND FormNo IN(SELECT InSO FROM UV1_WH_IOFormDts WHERE ID=" + p_ID + ")";// SysString.ToDBString(entitydts[index].InSO);
            DataTable dtcheck = SysUtils.Fill(sqlcheck);

            if (dtcheck.Rows.Count > 0)
            {

                throw new Exception("����" + dtcheck.Rows[0]["FormNo"].ToString() + " �Ѿ����㲻�ܳ���");

                return false;
            }

            return check;

        }


        public static void BindSaleProcedure(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;

            FCommon.LookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "ID", "Name" }, new string[] { " ", " " }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SaleProcedure WHERE 1=1 AND ShowFlag=1 AND PackCheckFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

    }
}

