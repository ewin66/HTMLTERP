using System;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using System.Drawing.Printing;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;
using DevExpress.Data.Filtering;
using System.Reflection;
using Microsoft.International.Converters.PinYinConverter;//����ƴ�����

namespace MLTERP
{
    /// <summary>
    /// Ŀ��: ����Win Formͨ�÷���
    /// ����: �¼Ӻ�
    /// ��������: 2005.2.1
    /// </summary>
    public class Common
    {

        #region ��Ʒ��ذ�
        /// <summary>
        /// ȡ��������Ϣ����
        /// </summary>
        /// <returns>0/1/2/3:ItemCode/ItemName/ItemStd/ItemModel/MWidth/MWeight</returns>
        public static string[] GetItemArrayByCode(string p_ItemCode)
        {
            string[] outstrA = new string[] { };
            string sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel,MWidth,MWeight FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstrA = new string[6] { dt.Rows[0]["ItemCode"].ToString(), dt.Rows[0]["ItemName"].ToString(), dt.Rows[0]["ItemStd"].ToString() 
                ,dt.Rows[0]["ItemModel"].ToString(),dt.Rows[0]["MWidth"].ToString(),dt.Rows[0]["MWeight"].ToString()};
            }
            return outstrA;
        }

        ///// <summary>
        ///// ���ݳ�Ʒ���ϰ��������ϱ�ż����ϱ���
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_CPItemCode"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static void BindFabricItemByCPItemCode(RepositoryItemLookUpEdit p_DrpID,string p_CPItemCode, bool p_ShowBlank)
        //{
        //    p_DrpID.ShowHeader = false;
        //    p_DrpID.ShowFooter = false;
        //    FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 50, 50, 200, 100 }, new string[] { "ItemCode", "ItemStd", "ItemName", "ItemModel" }, new string[] { "", "", "", "" }, new bool[] { true, true, true, true });
        //    string sql = string.Empty;

        //    sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel FROM Data_Item WHERE 1=1 ";
        //    sql += " AND ItemCode IN(";
        //    sql += "  SELECT GreyFabItemCode FROM Data_Item WHERE ItemCode="+SysString.ToDBString(p_CPItemCode);
        //    sql += " UNION";
        //    sql += "  SELECT GreyFabItemCode FROM Data_ItemGreyFabReplace WHERE ItemCode=" + SysString.ToDBString(p_CPItemCode);
        //    sql+= ") ";
        //    sql+= " ORDER BY ItemCode";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "ItemCode", "ItemCode", p_ShowBlank);
        //}



        /// <summary>
        /// ���ݳ�Ʒ���ϰ��������ϱ�ż����ϱ���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_CPItemCode"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindFabricItemByCPItemCode(RepositoryItemComboBox p_DrpID, string p_CPItemCode, bool p_ShowBlank)
        {
            //p_DrpID.ShowHeader = false;
            //p_DrpID.ShowFooter = false;
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 50, 50, 200, 100 }, new string[] { "ItemCode", "ItemStd", "ItemName", "ItemModel" }, new string[] { "", "", "", "" }, new bool[] { true, true, true, true });
            string sql = string.Empty;

            sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel FROM Data_Item WHERE 1=1 ";
            sql += " AND ItemCode IN(";
            sql += "  SELECT GreyFabItemCode FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_CPItemCode);
            sql += " UNION";
            sql += "  SELECT GreyFabItemCode FROM Data_ItemGreyFabReplace WHERE ItemCode=" + SysString.ToDBString(p_CPItemCode);
            sql += ") ";
            sql += " ORDER BY ItemCode";
            DataTable dt = SysUtils.Fill(sql);
            //FCommon.LoadDropRepositoryComb(p_DrpID, dt, "ItemCode", "ItemCode", p_ShowBlank);
            FCommon.LoadDropItemComb(p_DrpID, dt, "ItemCode", p_ShowBlank);
        }


        /// <summary>
        /// ������Ʒ��š�ɫ�Ż��ɫ�������Ⱦ��ɫ��
        /// </summary>
        /// <param name="p_ItemCode">��Ʒ���</param>
        /// <param name="p_ColorNum">ɫ��</param>
        /// <returns>Ⱦ��ɫ��</returns>
        public static string GetDesignNoByItemAndColorNum(string p_ItemCode, string p_ColorNum)
        {
            string outstr = string.Empty;
            string sql = string.Empty;
            sql = "SELECT DesignNO FROM Dev_ColorCardDts WHERE ItemCode=" + SysString.ToDBString(p_ItemCode) + " AND ColorNum=" + SysString.ToDBString(p_ColorNum);

            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0]["DesignNO"].ToString();
            }

            return outstr;
        }

        /// <summary>
        /// ������Ʒ��Ż�ü����������㵥λ
        /// </summary>
        /// <param name="p_Unit"></param>
        public static void GetCalUnitAndPerMiQty(string p_ItemCode, out string o_UnitQtyName, out decimal o_PerMiQty)
        {
            o_UnitQtyName = string.Empty;
            o_PerMiQty = 0;

            string itemUnit = string.Empty;

            string sql = string.Empty;
            if (p_ItemCode != string.Empty)
            {
                sql = "SELECT ItemUnit,PerMiWeight FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);//������Ʒ��Ž���
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    itemUnit = dt.Rows[0]["ItemUnit"].ToString();
                    o_PerMiQty = SysConvert.ToDecimal(dt.Rows[0]["PerMiWeight"]);
                }
            }
            o_UnitQtyName = GetUnitQtyNam(itemUnit);//���ݵ�λ���ƻ��ÿ����������ʾ����

        }


        /// <summary>
        /// ���ݵ�λ���ƻ��ÿ����������ʾ����
        /// </summary>
        /// <param name="p_Unit"></param>
        public static string GetUnitQtyNam(string p_Unit)
        {
            string outstr = string.Empty;
            string sql = string.Empty;
            if (p_Unit != string.Empty)
            {
                sql = "SELECT UnitQtyName FROM Enum_Unit WHERE Name=" + SysString.ToDBString(p_Unit);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outstr = dt.Rows[0]["UnitQtyName"].ToString();
                }
            }
            if (outstr == string.Empty)
            {
                outstr = "ÿ������";
            }
            return outstr;
        }

        /// <summary>
        /// ������ָ���Ŀ������Ŀ
        /// </summary>
        public static void BindItemBaseCheckItem(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT Name FROM Data_ItemBaseCheckItem WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropItemComb(p_DrpID, dt, "Name", p_ShowBlank);
        }




        /// <summary>
        /// �������ӹ�����
        /// </summary>
        public static void BindWOOtherType(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Data_WOOtherType WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "ID";
            p_DrpID.DisplayMember = "Name";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
        }

        /// <summary>
        /// �������ӹ�����
        /// </summary>
        public static void BindWOOtherType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { " ", " " }, new bool[2] { false, true });

            string sql = "SELECT ID,Name FROM Data_WOOtherType WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ����Ʒ�������Ͷ����
        /// </summary>
        public static void BindItemBaseGYType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[] { 0, 50 }, new string[] { "ID", "Name" }, new string[] { "����", "����" }, new bool[] { true, true });

            string sql = "SELECT ID,Name FROM Data_ItemBaseGYType WHERE 1=1 AND DShowFlag=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �����̵���
        /// </summary>
        public static void BindSaleProcedure(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_SaleProcedure WHERE 1=1 AND ShowFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "ID";
            p_DrpID.DisplayMember = "Name";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
        }

        /// <summary>
        /// �����̵���
        /// </summary>
        public static void BindSaleProcedure(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { " ", " " }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SaleProcedure WHERE 1=1 AND ShowFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ������ģʽ
        /// </summary>
        public static void BindSaleFlowModule(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 0, 90, 400 }, new string[] { "ID", "Name", "ShowDesc" }, new string[] { " ", " ", "" }, new bool[] { false, true, true });
            string sql = "SELECT ID,Name,ShowDesc FROM Data_SaleFlowModule WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ��������ģʽID�����Ʒ����
        /// </summary>
        public static int GetSaleItemTypeByID(int p_ID)
        {
            int outstr = (int)EnumItemType.����;//Ĭ�ϳ�Ʒģʽ
            string sql = "SELECT SaleItemTypeID FROM Data_SaleFlowModule WHERE ID = " + SysString.ToDBString(p_ID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToInt32(dt.Rows[0][0]);
            }
            return outstr;
        }






        public static bool GetOrderFormNoFinishFlag()
        {
            bool outb = false;

            return outb;
        }


        /// <summary>
        /// �õ���֯�ṹ����
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public static string GetStructureName(int p_ID)
        {
            string outstr = "";
            string sql = " SELECT Name FROM Data_Structure WHERE ID = " + p_ID.ToString();
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = dt.Rows[0]["Name"].ToString();
            }
            return outstr;
        }



        /// <summary>
        /// �󶨼ӹ�����ö�ٱ�
        /// </summary>
        public static void BindWOFollowType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { " ", " " }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_WOFollowType WHERE 1=1 AND UseFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }



        /// <summary>
        /// �󶨲�ѯģʽ
        /// </summary>
        public static void BindQueryMethod(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_QueryMethods WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ���ύ
        /// </summary>
        public static void BindSubmitFlag(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 0, 90 }, new string[] { "ID", "Name" }, new string[] { " ", " " }, new bool[] { false, true });
            string sql = "SELECT ID,ConfirmName FROM Enum_ConfirmFlag WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "ConfirmName", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindSubmitFlag(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            string sql = "SELECT ID,ConfirmName FROM Enum_ConfirmFlag WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "ConfirmName", "ID", p_ShowBlank);
        }


        #endregion


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

        public static void BindGenDan(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            sql += " and SDuty = '����Ա'";
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

        // /// <summary>
        ///// �󶨶��Ž�����
        ///// </summary>
        //public static void BindPhone(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        //{

        //    string sql = "SELECT ID,Name FROM Data_MsgPhone WHERE 1=1";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        //}
        /// <summary>
        /// �󶨶��Ž�����
        /// </summary>
        public static void BindPhone(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {

            string sql = "SELECT ID,Name FROM Data_MsgPhone WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "Name", p_ShowBlank);
        }



        public static void BindBuyType(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = true;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_BuyType";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
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
        /// �󶨶�������
        /// </summary>
        public static void BindADHLevel(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_LevelType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ������Ա��
        /// </summary>
        public static void BindOPALL(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1 ";

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
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });

            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
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
            //FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.LookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }



        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindOPID(LookUpEdit p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            //FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.LookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });

            DataTable dt = BindOPIDDataSource(p_TableName, p_FieldName);
            FCommon.LoadDropLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }

        /// <summary>
        /// ��õ���Ա������Դ
        /// </summary>
        /// <param name="p_TableName"></param>
        /// <param name="p_FieldName"></param>
        /// <returns></returns>
        static DataTable BindOPIDDataSource(string p_TableName, string p_FieldName)
        {
            //string sql = "Select OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE OPID IN";
            //sql += "(Select OPID FROM Data_OPDep WHERE DepID in";
            //sql += "(Select DepID From Data_FOPDep WHERE CLSA=" + SysString.ToDBString(p_TableName) + " AND CLSB=" + SysString.ToDBString(p_FieldName);
            //sql += "))";;
            //sql += " AND UseableFlag=1 ";
            //sql += " AND isnull(DefaultFlag,0)=0";
            string sql = string.Empty;
            sql = "EXEC USP1_Data_Stucture_GetOP " + SysString.ToDBString(p_TableName) + "," + SysString.ToDBString(p_FieldName);
            DataTable dt = SysUtils.Fill(sql);

            return dt;
        }


        /// <summary>
        /// ��Ա��
        /// </summary>
        public static void BindOPID(RepositoryItemLookUpEdit p_DrpID, string p_TableName, string p_FieldName, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });

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
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);

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
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            sql += p_condition;
            if (p_condition.ToUpper().IndexOf("ORDER") == -1)//û����������������
            {
                sql += " ORDER BY OPID";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
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
            //FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            //string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            //sql += " AND UseableFlag=1 ";
            //sql += " AND isnull(DefaultFlag,0)=0";
            //sql += p_condition;
            //if (p_condition.ToUpper().IndexOf("ORDER") == -1)//û����������������
            //{
            //    sql += " ORDER BY OPID";
            //}
            DataTable dt = FProcessDataTable.TableQuery(p_Dt, "1=1 " + p_condition);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
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
            //FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "OPID", "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            FCommon.LookupEditColAdd(p_DrpID, new int[1] { 50 }, new string[1] { "OPName" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT OPID,OPName,OPID+' '+OPName Name FROM Data_OP WHERE 1=1 ";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            sql += p_condition;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "OPName", "OPID", p_ShowBlank);
        }


        #endregion

        #region �ֿ�������

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
        public static string GetWHTypeByWHID(string p_whid)
        {
            string sql = "SELECT WHType FROM WH_WH WHERE WHID=" + SysString.ToDBString(p_whid);
            DataTable dt = SysUtils.Fill(sql);
            string temp = dt.Rows[0]["WHType"].ToString();
            return temp;
        }

        /// <summary>
        /// ������Ʒ���Ͱ󶨲ֿ�
        /// </summary>
        public static void BindWHByItemType(LookUpEdit p_DrpID, int p_ItemTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            if (p_ItemTypeID != 0)
            {
                sql += " AND WHType IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID =" + SysString.ToDBString(p_ItemTypeID) + ")";
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
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
                sql += " AND WHType=" + SysString.ToDBString(p_FormListAID);
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
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
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByWHType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindWHRight(p_DrpID, 1, p_ShowBlank);

        }

        public static void BindWHByWHType(LookUpEdit p_DrpID, int[] p_whtype, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            string str = "";
            for (int i = 0; i < p_whtype.Length; i++)
            {
                if (str != "")
                {
                    str += ",";
                }
                str += p_whtype[i].ToString();
            }
            if (p_whtype.Length > 0)
            {
                sql += " AND WHType IN(" + str + ")";
            }
            else
            {
                sql += " and 1=0";
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
            }

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHRightByWHType(LookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });


            DataTable dt = GetRightWHList(p_Type);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByWHType(RepositoryItemLookUpEdit p_DrpID, int p_Type, bool p_ShowBlank)
        {
            BindWHRight(p_DrpID, p_Type, p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHByWHType(RepositoryItemComboBox p_DrpID, int p_Type, bool p_ShowBlank)
        {
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            sql += " AND WHTypeID=" + SysString.ToDBString(p_Type);

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
            }

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
        public static void BindWHBySubType(LookUpEdit p_DrpID, int p_FormListAID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            if (p_FormListAID != 0)
            {
                sql += " AND WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(p_FormListAID) + ")";
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
            }

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨲ֿ�
        /// </summary>
        public static void BindWHBySubType(RepositoryItemLookUpEdit p_DrpID, int p_FormListAID, bool p_ShowBlank)
        {

            p_DrpID.ShowHeader = false;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "WHID", "WHNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM FROM WH_WH WHERE 1=1";
            if (p_FormListAID != 0)
            {
                sql += " AND WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(p_FormListAID) + ")";
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
            }


            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "WHID", "WHID", p_ShowBlank);
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
                sql += " AND WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";
            }

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
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
                sql += " AND WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";
            }


            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
            }


            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "WHNM", "WHID", p_ShowBlank);
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
        public static void BindSection(ComboBoxEdit p_DrpID, string p_WHID, bool p_ShowBlank)
        {
            string sql = "SELECT SectionID FROM WH_Section WHERE 1=1";
            sql += " AND WHID=" + SysString.ToDBString(p_WHID);
            sql += " AND IsUseable=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "SectionID", p_ShowBlank);
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
        /// �󶨲ֿ�λ
        /// </summary>
        public static void BindSBit(ComboBoxEdit p_DrpID, string p_WHID, string p_SectionID, bool p_ShowBlank)
        {

            string sql = "SELECT SBitID FROM WH_SBit WHERE 1=1";

            sql += " AND SectionID=" + SysString.ToDBString(p_SectionID);
            sql += " and WHID=" + SysString.ToDBString(p_WHID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "SBitID", p_ShowBlank);
        }

        public static void BindSBit(RepositoryItemSearchLookUpEdit p_Drp, string p_FormList, bool p_ShowBlank)
        {
            string sql = "  SELECT  WHID,WHNM,SectionID,SBitID FROM UV1_WH_SBit WHERE  WHType=(SELECT WHTypeID FROM  Enum_FormList WHERE ID =" + p_FormList + ")";
            DataTable dt = SysUtils.Fill(sql);
            DevMethod.LoadRepositorySearch(p_Drp, dt, "SBitID", "SBitID", string.Empty);
            DevMethod.SetSLKGrid(p_Drp.View, new string[4] { "WHID", "WHNM", "SectionID", "SBitID" }, new string[4] { "�ֿ����", "�ֿ���", "��", "λ" }, new bool[4] { true, true, true, true });
        }
        public static void BindSBit(SearchLookUpEdit p_Drp, string p_FormList, bool p_ShowBlank)
        {
            string sql = "  SELECT WHID,WHNM,SectionID,SBitID FROM UV1_WH_SBit WHERE  WHType=(SELECT WHTypeID FROM  Enum_FormList WHERE ID =" + p_FormList + ")";
            DataTable dt = SysUtils.Fill(sql);
            DevMethod.LoadSearch(p_Drp, dt, "SBitID", "SBitID", string.Empty);
            DevMethod.SetSLKGrid(p_Drp.Properties.View, new string[4] { "WHID", "WHNM", "SectionID", "SBitID" }, new string[4] { "�ֿ����", "�ֿ���", "��", "λ" }, new bool[4] { true, true, true, true });
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
            string sql = "SELECT WHID,WHID+' '+WHNM WHNM  FROM WH_WH WHERE ";
            sql += "  WHID IN ( SELECT WHID FROM WH_WH WHERE IsUseable=1";
            if (p_WHType != 0)
            {
                sql += "  AND WHType=" + SysString.ToDBString(p_WHType.ToString());
            }
            sql += "   )";

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
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

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    sql += " AND WHID IN ( ";
                    sql += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    sql += ") ";
                }
            }
            if (p_FormListAID != 0)
            {
                sql += " AND WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListAID) + ")";
            }
            return SysUtils.Fill(sql);
        }


        /// <summary>
        /// ��òֿ�Ȩ�޲�ѯ�ַ���
        /// </summary>
        /// <returns>��ѯ�ַ���</returns>
        public static string GetWHRightCondition()
        {
            return GetWHRightCondition("WHID");
        }

        /// <summary>
        /// ��òֿ�Ȩ�޲�ѯ�ַ���
        /// </summary>
        /// <param name="p_WHFiledName">�ֿ��ֶ���</param>
        /// <returns>��ѯ�ַ���</returns>
        public static string GetWHRightCondition(string p_WHFiledName)
        {
            string outstr = string.Empty;

            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6420)))//�ֿ⿪�����Ȩ��У��Ž���
            {
                if (!FParamConfig.LoginHTFlag)
                {
                    outstr += " AND " + p_WHFiledName + " IN ( ";
                    outstr += "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                    outstr += ") ";
                }
            }
            return outstr;
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
            sql += " AND DShowFlag=1";
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
            if (p_BaseTypeID != 0)
            {
                sql += " AND BaseType=" + SysString.ToDBString(p_BaseTypeID);
            }
            sql += " AND DShowFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨿ͻ�����
        /// </summary>
        public static void BindVendorType(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, int p_BaseTypeID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_VendorType WHERE 1=1";
            if (p_BaseTypeID != 0)
            {
                sql += " AND BaseType=" + SysString.ToDBString(p_BaseTypeID);
            }
            sql += " AND DShowFlag=1";
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "ID";
            p_DrpID.DisplayMember = "Name";
            p_DrpID.DataSource = dt;
            p_DrpID.Show();
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
        public static void BindVendor(SearchLookUpEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, p_VendorType, "", p_ShowBlank);
        }
        public static void BindVendor(RepositoryItemSearchLookUpEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, p_VendorType, "", p_ShowBlank);
        }
        public static void BindVendorName(LookUpEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            BindVendor2(p_DrpID, p_VendorType, "", p_ShowBlank);
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

            FCommon.LoadDropLookUP(p_DrpID, BindVendorDataSource(p_VendorType, p_Condition), "VendorAll", "VendorID", p_ShowBlank);
            p_DrpID.Tag = p_VendorType;
            //new LookUpClear(p_DrpID);
        }
        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(SearchLookUpEdit p_DrpID, int[] p_VendorType, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            DevMethod.LoadSearch(p_DrpID, BindVendorDataSource(p_VendorType, p_Condition), "VendorID", "VendorAttn", string.Empty);
            DevMethod.SetSLKGrid(p_DrpID.Properties.View, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });
            p_DrpID.Tag = p_VendorType;

        }
        /// <summary>
        /// �󶨿ͻ� ����ͻ�����
        /// </summary>
        public static void BindVendor(RepositoryItemSearchLookUpEdit p_DrpID, int[] p_VendorType, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            DevMethod.LoadRepositorySearch(p_DrpID, BindVendorDataSource(p_VendorType, p_Condition), "VendorID", "VendorAttn", string.Empty);
            DevMethod.SetSLKGrid(p_DrpID.View, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });
            p_DrpID.Tag = p_VendorType;
        }
        public static void BindVendor2(LookUpEdit p_DrpID, int[] p_VendorType, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 70, 230 }, new string[2] { "VendorID", "VendorAll" }, new string[2] { "����", "ȫ��" }, new bool[2] { true, true });

            FCommon.LoadDropLookUP(p_DrpID, BindVendorDataSource2(p_VendorType, p_Condition), "VendorAll", "VendorID", p_ShowBlank);
            p_DrpID.Tag = p_VendorType;
            //new LookUpClear(p_DrpID);
        }
        public static void BindVendor2(SearchLookUpEdit p_DrpID, int[] p_VendorType, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            DevMethod.LoadSearch(p_DrpID, BindVendorDataSource2(p_VendorType, p_Condition), "VendorID", "VendorAttn", string.Empty);
            DevMethod.SetSLKGrid(p_DrpID.Properties.View, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });
            p_DrpID.Tag = p_VendorType;
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
        public static void BindDepartment(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindDepartment(p_DrpID, p_ShowBlank, false, false);
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

        /// <summary>
        /// �󶨸�λ
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindDep(LookUpEdit p_DrpID)
        {
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 50 }, new string[2] { "ID", "Name" }, new string[2] { "���", "����" }, new bool[] { false, true });
            string sql = "SELECT ID,Name FROM Data_Dep ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", true);
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
        public static void BindCLS(RepositoryItemComboBox p_DrpID, int p_Type, bool p_ShowBlank)
        {
            string sql = "SELECT ID,CLSNM FROM Data_CLS WHERE CLSListID=" + p_Type;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpID, dt, "CLSNM", p_ShowBlank);
        }




        /// <summary>
        /// ��CLS
        /// </summary>
        private static DataTable BindCLSDataSource(string p_TableName, string p_FieldName)
        {
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
            sql = "SELECT CLSNM FROM Data_CLS WHERE CLSListID IN(SELECT ID FROM Data_CLSList WHERE 1=1 ";
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




        ///// <summary>
        ///// �󶨲ֿⵥ��������̬---Enum_FormNoControl
        ///// </summary>
        //public static void BindFormNoControlID(LookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    p_DrpID.Properties.ShowHeader = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 200 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    string sql = "SELECT ID,FormNM FROM Enum_FormNoControl WHERE 1=1";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        //}
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
        public static string GetVendorContactTelByVendorContact(string p_VendorID, string p_Name)
        {
            string outstr = string.Empty;
            string sql = "SELECT Tel FROM Data_VendorContact WHERE 1=1";
            sql += " AND MainID=(select ID from Data_Vendor where VendorID = " + SysString.ToDBString(p_VendorID) + ")";
            sql += " AND Name=" + SysString.ToDBString(p_Name);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }


        /// <summary>
        /// ���ݿͻ������ÿͻ���ϵ������ ��
        /// </summary>
        public static string GetVendorContactEmailByVendorContact(string p_VendorID, string p_Name)
        {
            string outstr = string.Empty;
            string sql = "SELECT Email FROM Data_VendorContact WHERE 1=1";
            sql += " AND MainID=(select ID from Data_Vendor where VendorID = " + SysString.ToDBString(p_VendorID) + ")";
            sql += " AND Name=" + SysString.ToDBString(p_Name);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
        }
        /// <summary>
        /// ���ݿͻ������ÿͻ���ϵ�˴��� ��
        /// </summary>
        public static string GetVendorContactFAXByVendorContact(string p_VendorID, string p_Name)
        {
            string outstr = string.Empty;
            string sql = "SELECT FAX FROM Data_VendorContact WHERE 1=1";
            sql += " AND MainID=(select ID from Data_Vendor where VendorID = " + SysString.ToDBString(p_VendorID) + ")";
            sql += " AND Name=" + SysString.ToDBString(p_Name);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0][0]);
            }
            return outstr;
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
        /// ���ݿͻ������ÿͻ���ַ
        /// </summary>
        public static int GetPayMethodByVenorID(string p_VendorID)
        {
            int outstr = 0;
            string sql = "SELECT PayMethodFlag FROM Data_Vendor WHERE VendorID = " + SysString.ToDBString(p_VendorID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToInt32(dt.Rows[0][0]);
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
        /// ���������(����)
        /// </summary>
        public static void BindSubTypeDB(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormListDB WHERE 1=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNM", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���������
        /// </summary>
        public static void BindSubTypeByDZType(LookUpEdit p_DrpID, int p_DZType, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "FormNM" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,FormNM FROM Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND DZType=" + SysString.ToDBString(p_DZType);
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
        /// �󶨲ֿⵥ��������,�Ƕ�������
        /// </summary>
        public static void BindSubTypeNoTop(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 50, 200, 200 }, new string[] { "ID", "ParentFormNM", "FormNM" }, new string[] { "", "���ݴ���", "��������" }, new bool[] { false, true, true });
            string sql = "SELECT ID,ParentFormNM+'--'+FormNM FormNMAll,FormNM,ParentFormNM FROM UV1_Enum_FormList WHERE 1=1 AND IsShow=1 ";
            sql += " AND ParentID NOT IN(0,1,2,7,8,9,10) ORDER BY ParentID,Code";//������⡢���⡢�ڳ��ȶ�������
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNMAll", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲ֿⵥ��������,�Ƕ������ͣ�Ϊ������
        /// </summary>
        public static void BindSubTypeNoTopForDB(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 50, 200, 200 }, new string[] { "ID", "ParentFormNM", "FormNM" }, new string[] { "", "���ݴ���", "��������" }, new bool[] { false, true, true });
            string sql = "SELECT ID,ParentFormNM+'--'+FormNM FormNMAll,FormNM,ParentFormNM FROM UV1_Enum_FormList WHERE 1=1 AND DBFlag=1  ";
            sql += " AND ParentID NOT IN(0,1,2,7,8,9,10) ORDER BY ParentID,Code";//������⡢���⡢�ڳ��ȶ�������
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNMAll", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �����������Ͱ󶨲ֿⵥ��������
        /// </summary>
        public static void BindSubTypeByItemType(LookUpEdit p_DrpID, int p_ItemTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 50, 200, 200 }, new string[] { "ID", "ParentFormNM", "FormNM" }, new string[] { "", "���ݴ���", "��������" }, new bool[] { false, true, true });
            string sql = "SELECT ID,ParentFormNM+'--'+FormNM FormNMAll,FormNM,ParentFormNM FROM UV1_Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=" + p_ItemTypeID + ")";
            sql += " AND ParentID NOT IN(1,2,7,8,9,10)";//������⡢���⡢�ڳ��ȶ�������
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNMAll", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ���ݲֿ����Ͱ󶨲ֿⵥ��������
        /// </summary>
        public static void BindSubTypeByWHType(LookUpEdit p_DrpID, int p_WHTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = true;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 50, 200, 200 }, new string[] { "ID", "ParentFormNM", "FormNM" }, new string[] { "", "���ݴ���", "��������" }, new bool[] { false, true, true });
            string sql = "SELECT ID,ParentFormNM+'--'+FormNM FormNMAll,FormNM,ParentFormNM FROM UV1_Enum_FormList WHERE 1=1 AND IsShow=1";
            sql += " AND WHTypeID=" + p_WHTypeID;
            sql += " AND ParentID NOT IN(1,2,7,8,9,10)";//������⡢���⡢�ڳ��ȶ�������
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "FormNMAll", "ID", p_ShowBlank);
        }


        /// <summary>
        /// �󶨻�����������
        /// </summary>
        public static void BindFillDataType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 250 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name+'--'+Remark Name FROM Enum_FillDataType WHERE 1=1 AND DShowFlag=1";
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
            sql += " AND ( VendorTypeID IN (" + p_Str + ") OR ";
            sql += " VendorID IN(SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(" + p_Str + "))";
            sql += ")";
            //sql += " AND (VendorTypeID IN (" + p_Str + ")";//09.12.30   �޸İ󶨶������
            //sql += " OR VendorTypeID2 IN (" + p_Str + ")";
            //sql += " OR VendorTypeID3 IN (" + p_Str + ")";
            //sql += " )";

            if (p_Condition != string.Empty)
            {
                sql += p_Condition;
            }
            sql += " ORDER BY VendorID ";
            return SysUtils.Fill(sql);
        }

        private static DataTable BindVendorDataSource2(int[] p_VendorType, string p_Condition)
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
            sql += " AND ( VendorTypeID IN (" + p_Str + ") OR ";
            sql += " VendorID IN(SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(" + p_Str + "))";
            sql += ")";
            //sql += " AND (VendorTypeID IN (" + p_Str + ")";//09.12.30   �޸İ󶨶������
            //sql += " OR VendorTypeID2 IN (" + p_Str + ")";
            //sql += " OR VendorTypeID3 IN (" + p_Str + ")";
            //sql += " )";

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
        /// �󶨲�Ʒ��ɫ
        /// </summary>
        /// <param name="p_DrpColorName"></param>
        /// <param name="p_DrpColorNum"></param>
        /// <param name="p_ItemCode"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindItemColor(RepositoryItemComboBox p_DrpColorNum, RepositoryItemComboBox p_DrpColorName, string p_ItemCode, bool p_ShowBlank)
        {

            string sql = "SELECT ColorNum,ColorName FROM UV1_Data_ItemColorDts WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryComb(p_DrpColorNum, dt, "ColorNum", p_ShowBlank);
            FCommon.LoadDropRepositoryComb(p_DrpColorName, dt, "ColorName", p_ShowBlank);
        }


        /// <summary>
        /// �󶨲�Ʒ��ɫ
        /// </summary>
        /// <param name="p_DrpColorName"></param>
        /// <param name="p_DrpColorNum"></param>
        /// <param name="p_ItemCode"></param>
        /// <param name="p_ShowBlank"></param>
        public static string GetItemColorNameByColorNum(string p_ItemCode, string p_ColorNum)
        {
            string outstr = string.Empty;
            if (p_ItemCode != string.Empty && p_ColorNum != string.Empty)
            {
                string sql = "SELECT ColorNum,ColorName FROM UV1_Data_ItemColorDts WHERE ItemCode=" + SysString.ToDBString(p_ItemCode) + " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outstr = dt.Rows[0]["ColorName"].ToString();
                }
            }
            return outstr;
        }
        /// <summary>
        /// �󶨲�Ʒɫ��
        /// </summary>
        /// <param name="p_DrpColorName"></param>
        /// <param name="p_DrpColorNum"></param>
        /// <param name="p_ItemCode"></param>
        /// <param name="p_ShowBlank"></param>
        public static string GetItemColorNameByColorName(string p_ItemCode, string p_ColorName)
        {
            string outstr = string.Empty;
            if (p_ItemCode != string.Empty && p_ColorName != string.Empty)
            {
                string sql = "SELECT ColorNum,ColorName FROM UV1_Data_ItemColorDts WHERE ItemCode=" + SysString.ToDBString(p_ItemCode) + " AND ColorName=" + SysString.ToDBString(p_ColorName);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    outstr = dt.Rows[0]["ColorNum"].ToString();
                }
            }
            return outstr;
        }

        ///// <summary>
        ///// ���ݲ�Ʒ��ɫɫ���е�һ��ѡ���������һ��ѡ��
        ///// </summary>
        ///// <param name="p_ItemCode"></param>
        ///// <param name="p_ColorNum"></param>
        //public static string GetItemColorNameByColorNum(string p_ItemCode,string p_ColorNum)
        //{

        //    string outstr = string.Empty;
        //    string sql = "SELECT ColorNum,ColorName FROM UV1_Data_ItemColorDts WHERE ItemCode=" + SysString.ToDBString(p_ItemCode) + " AND ColorNum=" + SysString.ToDBString(p_ColorNum);
        //    DataTable dt = SysUtils.Fill(sql);
        //    if (dt.Rows.Count != 0)
        //    {
        //        outstr = SysConvert.ToString(dt.Rows[0]["ColorName"]);
        //    }
        //    return outstr;
        //}

        /// <summary>
        /// ���ݲ�Ʒ��ɫɫ���е�һ��ѡ���������һ��ѡ��
        /// </summary>
        /// <param name="p_ItemCode"></param>
        /// <param name="p_ColorNum"></param>
        public static string GetItemColorNumByColorName(string p_ItemCode, string p_ColorName)
        {

            string outstr = string.Empty;
            string sql = "SELECT ColorNum,ColorName FROM UV1_Data_ItemColorDts WHERE ItemCode=" + SysString.ToDBString(p_ItemCode) + " AND ColorName=" + SysString.ToDBString(p_ColorName);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0]["ColorNum"]);
            }
            return outstr;
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


        ///// <summary>
        ///// �󶨴��/��ɴ
        ///// </summary>
        //public static void BindGoodsTypeByOPName(LookUpEdit p_DrpID, bool p_ShowBlank)
        //{
        //    string sql = string.Empty;
        //    p_DrpID.Properties.ShowHeader = false;
        //    p_DrpID.Properties.ShowFooter = false;
        //    FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 1 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
        //    if (ParamConfig.LoginID != "Y006" && ParamConfig.LoginID != "Y003")
        //    {
        //        sql = "SELECT ID,Name FROM Enum_GoodsType WHERE 1=1 ORDER BY ID";
        //    }
        //    else
        //    {
        //        sql = "SELECT ID,Name FROM Enum_GoodsType WHERE 1=1 AND BuyOPName=" + SysString.ToDBString(ParamConfig.LoginName) + " ORDER BY ID";
        //    }
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        //}
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
        /// ����ȱ����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindYQType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_YQType WHERE 1=1";
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
        /// ������ģʽ��Ʒ����
        /// </summary>
        public static void BindItemType(LookUpEdit p_DrpID, int p_SaleFlowModuleFlag, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_ItemType WHERE 1=1 AND  SaleFlowModuleFlag=" + p_SaleFlowModuleFlag;

            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ����Ʒ����
        /// </summary>
        public static void BindItemClass(LookUpEdit p_DrpID, int p_ItemType, bool p_ShowBlank)
        {
            BindItemClass(p_DrpID, new int[] { p_ItemType }, p_ShowBlank);

        }

        /// <summary>
        /// ����Ʒ����
        /// </summary>
        public static void BindItemClass(LookUpEdit p_DrpID, int[] p_ItemTypeA, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_ItemClass";
            sql += " WHERE 1=1 ";
            string itemtypestr = "0";
            for (int i = 0; i < p_ItemTypeA.Length; i++)
            {
                itemtypestr += ",";
                itemtypestr += p_ItemTypeA[i];
            }
            sql += " AND ItemTypeID IN(" + itemtypestr + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        public static void BindItemClass(RepositoryItemLookUpEdit p_DrpID, int[] p_ItemTypeA, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_ItemClass";
            sql += " WHERE 1=1 ";
            string itemtypestr = "0";
            for (int i = 0; i < p_ItemTypeA.Length; i++)
            {
                itemtypestr += ",";
                itemtypestr += p_ItemTypeA[i];
            }
            sql += " AND ItemTypeID IN(" + itemtypestr + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
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
            FCommon.LoadDropRepositoryLookUP(p_DrpID, BindVendorDataSource(p_VendorType), "VendorAll", "VendorID", p_ShowBlank);
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
        public static void BindVendorByFormListID(SearchLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, GetVendorTypeByFormListID(p_SubTypeID), p_ShowBlank);
        }
        /// <summary>
        /// �󶨲ֿⵥ�����Ϳͻ�
        /// </summary>
        public static void BindVendorByFormListID(RepositoryItemSearchLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
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
        /// У��LookUpEdit �ؼ�ֵ��Text�Ƿ�Ϊ��
        /// </summary>
        /// <param name="p_Drp">�ؼ�</param>
        /// <returns>true/false:��/�ǿ�</returns>
        public static bool CheckLookUpEditBlank(LookUpEdit p_Drp)
        {
            if (SysConvert.ToString(p_Drp.EditValue) == "" || p_Drp.Text == "" || SysConvert.ToString(p_Drp.EditValue) == "<Null>")
            {
                return true;
            }
            return false;
        }
        public static bool CheckLookUpEditBlank(SearchLookUpEdit p_Drp)
        {
            if (SysConvert.ToString(p_Drp.EditValue) == "" || p_Drp.Text == "" || SysConvert.ToString(p_Drp.EditValue) == "<Null>")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// У��SearchLookUpEdit �ؼ�ֵ��Text�Ƿ�Ϊ��
        /// </summary>
        /// <param name="p_Drp">�ؼ�</param>
        /// <returns>true/false:��/�ǿ�</returns>
        public static bool CheckSearchLookUpEditBlank(SearchLookUpEdit p_Drp)
        {
            if (SysConvert.ToString(p_Drp.EditValue) == "" || p_Drp.Text == "" || SysConvert.ToString(p_Drp.EditValue) == "<Null>")
            {
                return true;
            }
            return false;
        }


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
                    case (int)WHPosMethod.��:
                        for (int i = 0; i < p_Sectionfn.Length; i++)//������
                        {
                            p_View.Columns[p_Sectionfn[i]].Visible = false;
                        }

                        break;

                    case (int)WHPosMethod.����:
                        for (int i = 0; i < p_Sectionfn.Length; i++)//��ʾ��
                        {
                            p_View.Columns[p_Sectionfn[i]].Visible = true;
                        }

                        break;

                    case (int)WHPosMethod.����λ:
                        for (int i = 0; i < p_Sectionfn.Length; i++)//��ʾ��
                        {
                            p_View.Columns[p_Sectionfn[i]].Visible = true;
                        }

                        break;
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
                    case (int)WHPosMethod.��:
                        sql = "SELECT SectionID FROM WH_Section WHERE WHID=" + SysString.ToDBString(p_WHID);
                        DataTable dt2 = SysUtils.Fill(sql);
                        if (dt2.Rows.Count != 0)
                        {
                            outstr = SysConvert.ToString(dt2.Rows[0]["SectionID"]);
                        }
                        break;
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
                    case (int)WHPosMethod.��:
                        sql = "SELECT SBitID FROM WH_SBit WHERE WHID=" + SysString.ToDBString(p_WHID) + " AND SBitID=" + SysString.ToDBString(p_SBitID);
                        DataTable dt2 = SysUtils.Fill(sql);
                        if (dt2.Rows.Count != 0)
                        {
                            outstr = SysConvert.ToString(dt2.Rows[0]["SBitID"]);
                        }
                        break;
                    case (int)WHPosMethod.����:
                        goto case (int)WHPosMethod.��;
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
                    case (int)WHPosMethod.��:
                        sql = "SELECT SectionID FROM WH_Section WHERE WHID=" + SysString.ToDBString(p_WHID);
                        DataTable dt2 = SysUtils.Fill(sql);
                        if (dt2.Rows.Count != 0)
                        {
                            outstr = SysConvert.ToString(dt2.Rows[0]["SectionID"]);
                        }
                        break;
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
                    case (int)WHPosMethod.��:
                        sql = "SELECT SBitID FROM WH_SBit WHERE WHID=" + SysString.ToDBString(p_WHID) + " AND SectionID=" + SysString.ToDBString(p_SectionID);
                        DataTable dt2 = SysUtils.Fill(sql);
                        if (dt2.Rows.Count != 0)
                        {
                            outstr = SysConvert.ToString(dt2.Rows[0]["SBitID"]);
                        }
                        break;
                    case (int)WHPosMethod.����:
                        goto case (int)WHPosMethod.��;
                }
            }
            return outstr;
        }

        #endregion

        #region ����
        /// <summary>
        /// ��������ID�õ�������ID
        /// </summary>
        /// <param name="p_FormListAID">loginID</param>
        /// <returns></returns>
        public static int GetFormListIDBySubTypeID(int p_FormListBID)
        {
            int outint = 0;
            string sql = "SELECT ParentID FROM Enum_FormList WHERE ID=" + SysString.ToDBString(p_FormListBID);
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

        /// <summary>
        /// ȡ�ô��������
        /// </summary>
        /// <returns></returns>
        public static string GetItemNameByCode(string p_itemCode)
        {
            string tempFomrName = string.Empty;
            string sql = "SELECT ItemName FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(p_itemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                tempFomrName = SysConvert.ToString(dt.Rows[0]["ItemName"]);
            }
            return tempFomrName;
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
        /// �󶨿ͻ���ϵ��
        /// </summary>
        public static void BindVendorContact(ComboBoxEdit p_DrpID, string p_VendorID, bool p_ShowBlank)
        {
            //			FCommon.LookupEditColAdd(p_DrpID,new int[2]{50,100},new string[2]{,"Name"},new string[2]{"",""},new bool[2]{false,true});
            string sql = "SELECT Name FROM Data_VendorContact WHERE MainID IN (SELECT ID FROM Data_Vendor WHERE VendorID=" + SysString.ToDBString(p_VendorID) + ")";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
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
        /// �ַ�������ת��Ϊ��ѯ�ַ���
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
            string sql = "select ID, " +
                         " CASE WHEN ISNULL(Name,'') <> '' THEN Name WHEN" +
                         " ISNULL(Name ,'') = '' THEN WinName END AS AllName " +
                         " from UV1_Sys_WindowMenu " +
                         " where ParentID = " + parentID +
                         " and ISNULL(HttFlag,0) = 0 " +
                //" and ISNULL(ShowFlag,0) <> 0 "+
                         " and HttFlag = 0 order by Sort";
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

        /// <summary>
        /// �󶨿ͻ�
        /// </summary>
        /// <param name="p_DrpID">�ؼ���</param>
        /// <param name="p_ShowBlank">�Ƿ���ʾ����</param>
        public static void BindVendorName(RepositoryItemLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.ShowHeader = true;
            p_DrpID.ShowFooter = false;
            FCommon.RepositoryLookupEditColAdd(p_DrpID, new int[2] { 30, 50 }, new string[2] { "VendorID", "VendorName" }, new string[2] { "���", "����" }, new bool[2] { false, true });
            string sql = "SELECT VendorID,VendorName FROM Data_Vendor";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropRepositoryLookUP(p_DrpID, dt, "VendorName", "VendorID", p_ShowBlank);
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
        public static void BindVendor(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, "", p_ShowBlank);
        }
        /// <summary>
        /// �󶨳���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindVendor(LookUpEdit p_DrpID, string p_Condition, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_DrpID, new int[] { 100 }, new string[] { "VendorAttn" }, new string[] { "" }, new bool[] { true });
            String sql = "SELECT VendorID,VendorAttn FROM Data_Vendor WHERE 1=1 ";
            sql += p_Condition;
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "VendorID", "VendorAttn", p_ShowBlank);
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

        /// <summary>
        /// �󶨳���
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindVendorID(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        {

            string sql = "SELECT VendorID FROM Data_Vendor WHERE VendorTypeID=" + SysString.ToDBString((int)EnumVendorType.����);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "VendorID", p_ShowBlank);
        }
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

            string sql = "SELECT Name FROM Enum_Season WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
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
        /// �󶨹Ұ�״̬
        /// </summary>
        public static void BindGBStatus2(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_GBStatus WHERE 1=1 ";
            sql += " AND ID=" + SysString.ToDBString((int)EnumGBStatus.���);
            sql += " OR ID=" + SysString.ToDBString((int)EnumGBStatus.�黹);
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
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨺�������
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindHZType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_HZType WHERE 1=1";
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




        ///// <summary>
        ///// �󶨸��ʽ
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static void BindPayMethod(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        //{

        //    string sql = "SELECT Name FROM Data_PayMethod WHERE 1=1 ";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        //}

        /// <summary>
        /// ���ʽ
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindPayMethod(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 300 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_PayMethod WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);

        }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindProductType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 300 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_ProductType WHERE 1=1";
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
        public static void BindSOContext(LookUpEdit p_DrpID, string p_Type, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Data_SOContext WHERE 1=1";
            sql += " and Type= " + SysString.ToDBString(p_Type);
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

        ///// <summary>
        ///// �󶨼�����λ
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static void BindEnumUnit(RepositoryItemComboBox p_DrpID, bool p_ShowBlank)
        //{
        //    string sql = "SELECT ID,Name FROM Enum_Unit";
        //    sql += " WHERE 1=1";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropRepositoryComb(p_DrpID, dt, "Name", p_ShowBlank);
        //}

        ///// <summary>
        ///// �󶨼�����λ
        ///// </summary>
        ///// <param name="p_DrpID"></param>
        ///// <param name="p_ShowBlank"></param>
        //public static void BindEnumUnit(ComboBoxEdit p_DrpID, bool p_ShowBlank)
        //{

        //    string sql = "SELECT ID,Name FROM Enum_Unit";
        //    DataTable dt = SysUtils.Fill(sql);
        //    FCommon.LoadDropComb(p_DrpID, dt, "Name", p_ShowBlank);
        //}
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
        /// ���������
        /// </summary>
        public static void BindPackBox(DevExpress.XtraEditors.CheckedListBoxControl p_DrpID, string p_Condition, bool p_ShowBlank)
        {
            string sql = "SELECT BoxNo,Qty FROM WH_PackBox WHERE 1=1 ";
            sql += p_Condition;
            DataTable dt = SysUtils.Fill(sql);
            p_DrpID.ValueMember = "BoxNo";
            p_DrpID.DisplayMember = "Qty";
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
        /// �����ۺ�ͬվ��
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindOrderStep(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_OrderStep WHERE ID<>0 AND ShowFlag=1 ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

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
            string sql = "SELECT ID,Name+'--'+Remark Name FROM Enum_LoadFormType WHERE 1=1 AND DShowFlag=1 ";
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

        public static void BindVendor2(LookUpEdit p_DrpID, int p_VendorTypeID, bool p_ShowBlank)
        {

            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 0, 100 }, new string[2] { "VendorID", "VendorName" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT VendorID,VendorName FROM Data_Vendor WHERE 1=1";
            sql += " AND VendorTypeID=" + SysString.ToDBString(p_VendorTypeID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "VendorName", "VendorID", p_ShowBlank);
        }
        public static void BindVendor2(SearchLookUpEdit p_DrpID, int p_VendorTypeID, bool p_ShowBlank)
        {
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            string sql = "SELECT VendorID,VendorAttn FROM Data_Vendor WHERE 1=1";
            sql += " AND VendorTypeID=" + SysString.ToDBString(p_VendorTypeID);
            DataTable dt = SysUtils.Fill(sql);
            DevMethod.LoadSearch(p_DrpID, dt, "VendorID", "VendorAttn", string.Empty);
            DevMethod.SetSLKGrid(p_DrpID.Properties.View, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "����", "���" }, new bool[2] { true, true });
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

        /// <summary>
        /// �󶨻�̨
        /// </summary>
        public static void BindMachine(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 100 }, new string[2] { "Code", "Machine" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT Code,Machine FROM Data_MachineManage";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Machine", "Code", p_ShowBlank);
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
            if (dt.Rows.Count != 0)
            {
                ParamConfig.CompanyType = SysConvert.ToInt32(dt.Rows[0]["ID"]);
            }
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

        #region ������
        /// <summary>
        /// �󶨱�����������
        /// </summary>
        public static void BindColorSampleType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT ID,Name FROM Enum_ColorSampleType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }



        /// <summary>
        /// ���쳣����
        /// </summary>
        public static void BindBugType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "Code", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT Code,Name FROM Enum_BugType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// ���쳣����
        /// </summary>
        public static void BindWOTypeType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "Code", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT Code,Name FROM Enum_WOType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }

        /// <summary>
        /// ��״̬
        /// </summary>
        public static void BindBugStatus(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "Code", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT Code,Name FROM Enum_BugStatus WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "Code", p_ShowBlank);
        }
        /// <summary>
        /// �󶨴�������
        /// </summary>
        public static void BindSampleType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            //p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            //p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 20 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SampleType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// �󶨶�������
        /// </summary>
        public static void BindSOType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            //p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            //p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 20, 20 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { false, true });
            string sql = "SELECT ID,Name FROM Enum_SOType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }

        /// <summary>
        /// ����Ʒ��������
        /// </summary>
        public static void BindPostFormType(LookUpEdit p_DrpID, bool p_ShowBlank)
        {
            p_DrpID.Properties.ShowHeader = false;
            p_DrpID.Properties.ShowFooter = false;
            p_DrpID.Properties.TextEditStyle = TextEditStyles.Standard;
            p_DrpID.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FCommon.LookupEditColAdd(p_DrpID, new int[2] { 50, 50 }, new string[2] { "ID", "Name" }, new string[2] { "", "" }, new bool[2] { true, true });
            string sql = "SELECT ID,Name FROM Enum_PostFormType WHERE 1=1 ";
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropLookUP(p_DrpID, dt, "Name", "ID", p_ShowBlank);
        }


        /// <summary>
        /// ����������Ż��������Ϣ
        /// </summary>
        public static string GetItemDesc(string p_ItemCode)
        {
            string ItemDesc = string.Empty;
            string sql = "SELECT * FROM  Data_Item WHERE ItemCode=" + SysString.ToDBString(p_ItemCode);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                ItemDesc = "Ʒ��:" + dt.Rows[0]["ItemModel"].ToString() + "  ���:" + dt.Rows[0]["ItemStd"].ToString() + "  �ɷ�:" + dt.Rows[0]["ItemName"].ToString() + "  �ŷ�:" + dt.Rows[0]["MWidth"].ToString() + "  ����:" + dt.Rows[0]["MWeight"].ToString();

            }

            return ItemDesc;
        }

        #endregion


        #region ��ȡĬ��ֵ
        /// <summary>
        /// ȡ�����¸��ʽ
        /// </summary>
        /// <returns></returns>
        public static int GetPayMethodByProcessType(int p_ProcessType)
        {
            int PayMethod = 0;
            string sql = "select DefaultPayMethodFlag from Enum_ProcessType where ID= " + p_ProcessType;
            sql += " AND ISNULL(DefaultPayMethodFlag,0)<>0";
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                PayMethod = SysConvert.ToInt32(dt.Rows[0]["DefaultPayMethodFlag"]);
            }
            return PayMethod;

        }


        /// <summary>
        /// �������ƻ�ð�����
        /// </summary>
        public static int GetBindTypeByName(string p_Name)
        {
            int outstr = 0;
            string sql = "SELECT BindType FROM Sys_FiledSet WHERE Name=" + SysString.ToDBString(p_Name);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToInt32(dt.Rows[0][0].ToString());
            }
            return outstr;
        }


        /// <summary>
        /// ȡ�����¸��ʽ
        /// </summary>
        /// <returns></returns>
        public static string GetCLSIDByCLSNM(string p_Name)
        {
            string outstr = string.Empty;
            string sql = "select CLSIDC from Data_CLS where CLSNM= " + SysString.ToDBString(p_Name);

            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                outstr = SysConvert.ToString(dt.Rows[0]["CLSIDC"]);
            }
            return outstr;

        }
        #endregion

        /// <summary>
        /// ���ø�����Ϣ
        /// </summary>
        /// <param name="gridView6"></param>
        /// <param name="dt"></param>
        public static void SetItemAdd(GridView gridView6, DataTable dt)
        {
            try
            {
                for (int i = 0; i < gridView6.RowCount; i++)
                {
                    string FiledName = SysConvert.ToString(gridView6.GetRowCellValue(i, "FiledName"));
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (SysConvert.ToString(dr["FiledName"]) == FiledName)
                        {
                            if (SysConvert.ToInt32(dr["MainID"]) > 0)
                            {
                                gridView6.SetRowCellValue(i, "MainID", SysConvert.ToInt32(dr["MainID"]));
                            }
                            if (SysConvert.ToInt32(dr["Seq"]) > 0)
                            {
                                gridView6.SetRowCellValue(i, "Seq", SysConvert.ToInt32(dr["Seq"]));
                            }
                            gridView6.SetRowCellValue(i, "Name", SysConvert.ToString(dr["Name"]));
                            gridView6.SetRowCellValue(i, "FiledName", SysConvert.ToString(dr["FiledName"]));
                            gridView6.SetRowCellValue(i, "Value", SysConvert.ToString(dr["Value"]));
                            if (SysConvert.ToInt32(dr["FiledSetID"]) > 0)
                            {
                                gridView6.SetRowCellValue(i, "FiledSetID", SysConvert.ToInt32(dr["FiledSetID"]));
                            }
                            gridView6.SetRowCellValue(i, "DRemark", SysConvert.ToString(dr["DRemark"]));
                            if (SysConvert.ToInt32(dr["FormID"]) > 0)
                            {
                                gridView6.SetRowCellValue(i, "FormID", SysConvert.ToInt32(dr["FormID"]));
                            }
                            if (SysConvert.ToInt32(dr["FormAID"]) > 0)
                            {
                                gridView6.SetRowCellValue(i, "FormAID", SysConvert.ToInt32(dr["FormAID"]));
                            }
                            if (SysConvert.ToInt32(dr["FormBID"]) > 0)
                            {
                                gridView6.SetRowCellValue(i, "FormBID", SysConvert.ToInt32(dr["FormBID"]));
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {

            }
        }

        /// <summary>
        /// ȡ���ַ����ұ�Nλ
        /// </summary>
        /// <param name="p_value"></param>
        /// <param name="p_len"></param>
        /// <returns></returns>
        public static string GetSubStringRight(string p_value, int p_len)
        {
            string outstr = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(p_value))
                {
                    return outstr;
                }
                if (p_value.Length <= p_len)
                {
                    outstr = p_value;
                }
                else
                {
                    outstr = p_value.Substring(p_value.Length - p_len, p_len);
                }
                return outstr;
            }
            catch
            {
                return outstr;
            }
        }

        public static void FilterLookup(object sender)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            GridView gridView = edit.Properties.View as GridView;
            System.Reflection.FieldInfo fi = gridView.GetType().GetField("extraFilter", BindingFlags.NonPublic | BindingFlags.Instance);
            CriteriaOperator[] cr = new CriteriaOperator[gridView.Columns.Count];
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                BinaryOperator op = new BinaryOperator(gridView.Columns[i].FieldName, "%" + edit.AutoSearchText + "%", BinaryOperatorType.Like);
                cr[i] = op;
            }
            string filterCondition = new GroupOperator(GroupOperatorType.Or, cr).ToString();
            fi.SetValue(gridView, filterCondition);

            MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(gridView, null);
        }
        public static void FilterLookup(object sender, string text)
        {
            RepositoryItemGridLookUpEdit edit = sender as RepositoryItemGridLookUpEdit;
            GridView gridView = edit.View as GridView;
            System.Reflection.FieldInfo fi = gridView.GetType().GetField("extraFilter", BindingFlags.NonPublic | BindingFlags.Instance);
            CriteriaOperator[] cr = new CriteriaOperator[gridView.Columns.Count];
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                BinaryOperator op = new BinaryOperator(gridView.Columns[i].FieldName, "%" + text + "%", BinaryOperatorType.Like);
                cr[i] = op;
            }
            string filterCondition = new GroupOperator(GroupOperatorType.Or, cr).ToString();
            fi.SetValue(gridView, filterCondition);

            MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(gridView, null);
        }
        #region ����תƴ��
        /// <summary> 
        /// ����ת��Ϊƴ��
        /// </summary> 
        /// <param name="str">����</param> 
        /// <returns>ȫƴ</returns> 
        public static string GetPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length - 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }
        /// <summary> 
        /// ����ת��Ϊƴ������ĸ
        /// </summary> 
        /// <param name="str">����</param> 
        /// <returns>����ĸ</returns> 
        public static string GetFirstPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }


        #endregion
    }
}

