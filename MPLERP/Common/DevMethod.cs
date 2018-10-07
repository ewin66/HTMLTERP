using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Popup;
using System.Windows.Forms;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace MLTERP
{
    /// <summary>
    /// DevExpress 13.2.8方法
    /// </summary>
    public class DevMethod
    {
        #region 绑定Data_Item
        /// <summary>
        ///绑定Data_Item，显示物品信息
        /// </summary>
        /// <param name="p_DrpID">SearchLookUpEdit控件</param>
        public static void BindItem(SearchLookUpEdit p_DrpID, int[] p_ItemType)
        {
            string sql = "SELECT  ItemCode,ItemName,ItemStd FROM Data_Item WHERE 1=1";
            if (p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }

            sql += " ORDER BY ItemCode";
            DataTable dt = SysUtils.Fill(sql);
            LoadSearch(p_DrpID, dt, "ItemCode", "ItemCode", string.Empty);
            SetSLKGrid(p_DrpID.Properties.View, new string[3] { "ItemCode", "ItemName", "ItemStd" }, new string[3] { "物品编码", "物品名称", "物品规格" }, new bool[3] { true, true, true });
        }


        /// <summary>
        ///绑定Data_Item，显示物品信息
        /// </summary>
        /// <param name="p_DrpID">SearchLookUpEdit控件</param>
        public static void BindItemCode(SearchLookUpEdit p_DrpID, int p_ItemType)
        {
            string sql = "SELECT  ItemCode,ItemName,ItemStd,ItemCode+' '+ItemName+' '+ItemStd+' '+VendorAttn  as Item FROM UV1_Data_Item WHERE 1=1";
            sql += " AND ItemTypeID =" + SysString.ToDBString(p_ItemType);


            sql += " ORDER BY ItemCode";
            DataTable dt = SysUtils.Fill(sql);
            LoadSearch(p_DrpID, dt, "ItemCode", "Item", string.Empty);
            SetSLKGrid(p_DrpID.Properties.View, new string[4] { "ItemCode", "ItemName", "ItemStd", "Item" }, new string[4] { "物品编码", "物品名称", "物品规格", "供应商" }, new bool[4] { true, true, true, false });
        }

        #endregion

        #region 绑定客户
        /// <summary>
        /// 绑定仓库单据类型客户
        /// </summary>
        public static void BindVendorByFormListID(SearchLookUpEdit p_DrpID, int p_SubTypeID, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, Common.GetVendorTypeByFormListID(p_SubTypeID), p_ShowBlank);
        }
        #endregion

        #region  绑定员工
        /// <summary>
        /// 绑定全部员工
        /// </summary>
        public static void BindAllOP(RepositoryItemSearchLookUpEdit p_DrpID)
        {
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            LoadRepositorySearch(p_DrpID, dt, "OPID", "OPName", string.Empty);
            SetSLKGrid(p_DrpID.View, new string[2] { "OPID", "OPName" }, new string[2] { "员工编号", "员工姓名" }, new bool[2] { true, true });
        }



        /// <summary>
        /// 绑定全部业务员
        /// </summary>
        public static void BindAllOP(SearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            LoadSearch(p_DrpID, dt, "OPID", "OPName", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "OPID", "OPName" }, new string[2] { "员工编码", "姓名" }, new bool[2] { true, true });

        }

        /// <summary>
        /// 绑定 部门
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindOPDep(SearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_Dep WHERE 1=1";
            //sql += " AND UseableFlag=1 ";
            //sql += " AND isnull(DefaultFlag,0)=0";
            DataTable dt = SysUtils.Fill(sql);
            LoadSearch(p_DrpID, dt, "ID", "Name", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "ID", "Name" }, new string[2] { "部门编号", "部门" }, new bool[2] { true, true });

        }


        /// <summary>
        /// 绑定业务员
        /// </summary>
        public static void BindOP(SearchLookUpEdit p_DrpID, int p_OPType, bool p_ShowBlank)
        {
            BindOP(p_DrpID, new int[] { p_OPType }, p_ShowBlank);

        }

        /// <summary>
        /// 绑定业务员
        /// </summary>
        public static void BindOP2(SearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            LoadSearch(p_DrpID, BindOPDataSource2(), "OPID", "OPName", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "OPID", "OPName" }, new string[2] { "员工编码", "姓名" }, new bool[2] { true, true });

        }


        /// <summary>
        /// 获得绑定业务员数据源
        /// </summary>
        /// <param name="p_VendorType"></param>
        /// <returns></returns>
        private static DataTable BindOPDataSource2()
        {
            string p_Str = string.Empty;
            p_Str += "0";
            //for (int i = 0; i < p_OPType.Length; i++)
            //{
            //    if (SysConvert.ToInt32(p_OPType[i]) != 0)
            //    {
            //        if (p_Str != string.Empty)
            //        {
            //            p_Str += ",";
            //        }
            //        p_Str += p_OPType[i].ToString();
            //    }
            //}

            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";
            sql += " AND UseableFlag=1 ";
            //sql += " AND isnull(DefaultFlag,0)=0";
            //sql += " AND OPID IN(SELECT OPID FROM Data_OPDep WHERE DepID in(" + SysString.ToDBString(p_Str) + "))";
            //sql += " AND OPID IN(SELECT OPID FROM Data_OPDep WHERE DepID in(" + p_Str + "))";

            //根据这两句 查在这个权限组里的是否有改人
            //select * from Data_OPAuthGrp
            //select * from Data_AuthGrp  

            sql += " ORDER BY OPID ";
            return SysUtils.Fill(sql);
        }

        /// <summary>
        /// 绑定业务员
        /// </summary>
        public static void BindOP(SearchLookUpEdit p_DrpID, int[] p_OPType, bool p_ShowBlank)
        {
            LoadSearch(p_DrpID, BindOPDataSource(p_OPType), "OPID", "OPName", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "OPID", "OPName" }, new string[2] { "员工编码", "姓名" }, new bool[2] { true, true });

        }

        public static void BindOP2(RepositoryItemSearchLookUpEdit p_DrpID)
        {
            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            sql += " AND isnull(DepID,0)=5";//操作工人

            DataTable dt = SysUtils.Fill(sql);
            LoadRepositorySearch(p_DrpID, dt, "OPID", "OPName", string.Empty);
            SetSLKGrid(p_DrpID.View, new string[2] { "OPID", "OPName" }, new string[2] { "员工编号", "员工姓名" }, new bool[2] { true, true });
        }


        /// <summary>
        /// 获得绑定业务员数据源
        /// </summary>
        /// <param name="p_VendorType"></param>
        /// <returns></returns>
        private static DataTable BindOPDataSource(int[] p_OPType)
        {
            string p_Str = string.Empty;
            p_Str += "0";
            for (int i = 0; i < p_OPType.Length; i++)
            {
                if (SysConvert.ToInt32(p_OPType[i]) != 0)
                {
                    if (p_Str != string.Empty)
                    {
                        p_Str += ",";
                    }
                    p_Str += p_OPType[i].ToString();
                }
            }

            string sql = "SELECT OPID,OPName FROM Data_OP WHERE 1=1";
            sql += " AND UseableFlag=1 ";
            sql += " AND isnull(DefaultFlag,0)=0";
            //sql += " AND OPID IN(SELECT OPID FROM Data_OPDep WHERE DepID in(" + SysString.ToDBString(p_Str) + "))";
            sql += " AND OPID IN(SELECT OPID FROM Data_OPDep WHERE DepID in(" + p_Str + "))";
            sql += " ORDER BY OPID ";
            return SysUtils.Fill(sql);
        }

        #endregion

    

     

        #region 绑定部门
        /// <summary>
        /// 绑定部门
        /// </summary>
        public static void BindDepartment(SearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT Code,Name FROM Enum_Department WHERE 1=1 ";
            //if (p_ShowTY == false)
            //{
            //    sql += " AND ISNULL(ValidType,0) = 0";
            //}
            //if (p_ShowCJ == true)
            //{
            //    sql += " AND ISNULL(SCFlag,0) = 1";
            //}
            sql += " ORDER BY Code ";
            DataTable dt = SysUtils.Fill(sql);

            LoadSearch(p_DrpID, dt, "Code", "Name", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "Code", "Name" }, new string[2] { "部门编码", "部门名称" }, new bool[2] { true, true });

        }

      

        #endregion

        #region 绑定岗位
        /// <summary>
        /// 绑定岗位
        /// </summary>
        public static void BindDep(SearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Enum_Dep";
            DataTable dt = SysUtils.Fill(sql);

            LoadSearch(p_DrpID, dt, "ID", "Name", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "ID", "Name" }, new string[2] { "岗位ID", "岗位名称" }, new bool[2] { true, true });

        }
        #endregion

        #region 绑定职务
        /// <summary>
        /// 绑定职务
        /// </summary>
        public static void BindDuty(SearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ID,Name FROM Data_Duty WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);

            LoadSearch(p_DrpID, dt, "ID", "Name", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "ID", "Name" }, new string[2] { "职务ID", "职务名称" }, new bool[2] { true, true });

        }
        #endregion

        #region 绑定仓库
        /// <summary>
        /// 绑定仓库类型
        /// </summary>
        /// <param name="p_DrpID"></param>
        public static void BindWHType(SearchLookUpEdit p_DrpID)
        {
            string sql = "Select ID,Name FROM Enum_WHType WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            LoadSearch(p_DrpID, dt, "ID", "Name", string.Empty);
            SetSLKGrid(p_DrpID.Properties.View, new string[2] { "ID", "Name" }, new string[2] { "ID", "仓库类型" }, new bool[2] { false, true });
        }
        #endregion

        #region 绑定国别
        public static void BindCountry(SearchLookUpEdit p_DrpID)
        {
            string sql = "Select Code,CompanyName,CompanyNameEn FROM Data_CompanyList WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            LoadSearch(p_DrpID, dt, "CompanyName", "CompanyNameEn", string.Empty);
            SetSLKGrid(p_DrpID.Properties.View, new string[] { "CompanyName", "CompanyNameEn" }, new string[] { "国家", "国家英文" }, new bool[] { true, true });
        }

        /// <summary>
        ///  绑定国家
        /// </summary>
        /// <param name="p_DrpID">RepositoryItemSearchLookUpEdit控件</param>
        public static void BindRCountry(RepositoryItemSearchLookUpEdit p_DrpID)
        {
            string sql = "Select CompanyName,CompanyName FROM Data_CompanyList WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            LoadRepositorySearch(p_DrpID, dt, "CompanyName", "CompanyName", string.Empty);
            SetSLKGrid(p_DrpID.View, new string[2] { "CompanyName", "CompanyName" }, new string[2] { "国家", "国家" }, new bool[2] { false, true });
        }

        public static void BindRepCountry(RepositoryItemSearchLookUpEdit p_DrpID)
        {
            string sql = "Select Code,CompanyName FROM Data_CompanyList WHERE 1=1";
            DataTable dt = SysUtils.Fill(sql);
            LoadRepositorySearch(p_DrpID, dt, "Code", "CompanyName", string.Empty);

            SetSLKGrid(p_DrpID.View, new string[2] { "Code", "CompanyName" }, new string[2] { "编码", "国家" }, new bool[2] { false, true });
        }
        #endregion

        #region SearchLookUpEdit绑定客户方法
        /// <summary>
        /// 绑定客户根据对账类型
        /// </summary>
        public static void BindVendorByDZTypeID(SearchLookUpEdit p_DrpID, int p_DZTypeID, bool p_ShowBlank)
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
        /// 绑定客户 多个客户类型
        /// </summary>
        public static void BindVendor(SearchLookUpEdit p_DrpID, int p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, new int[] { p_VendorType }, p_ShowBlank);
        }

        /// <summary>
        /// 绑定客户 多个客户类型
        /// </summary>
        public static void BindVendor(SearchLookUpEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, p_VendorType, "", p_ShowBlank);
        }


        /// <summary>
        /// 绑定客户 多个客户类型
        /// </summary>
        public static void BindVendor(SearchLookUpEdit p_DrpID, int[] p_VendorType, string p_Condition, bool p_ShowBlank)
        {

            LoadSearch(p_DrpID, BindVendorDataSource(p_VendorType, p_Condition), "VendorID", "VendorAttn", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.Properties.View, new string[3] { "VendorID", "VendorAttn", "VendorNameEn" }, new string[3] { "客户编码", "客户简称", "客户简写" }, new bool[3] { true, true, true });

        }



        /// <summary>
        /// 获得绑定客户数据源
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
            string sql = "SELECT VendorID,VendorAttn,VendorNameEn FROM Data_Vendor WHERE 1=1 AND UseableFlag=1 ";
            sql += " AND ( VendorTypeID IN (" + p_Str + ") OR ";
            sql += " VendorID IN(SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(" + p_Str + "))";
            sql += ")";

            if (p_Condition != string.Empty)
            {
                sql += p_Condition;
            }
            sql += " ORDER BY VendorID ";
            return SysUtils.Fill(sql);
        }

        #endregion



        #region RepositoryItemSearchLookUpEdit绑定客户方法
        /// <summary>
        /// 绑定客户 多个客户类型
        /// </summary>
        public static void BindVendor(RepositoryItemSearchLookUpEdit p_DrpID, int p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, new int[] { p_VendorType }, p_ShowBlank);
        }

        /// <summary>
        /// 绑定客户 多个客户类型
        /// </summary>
        public static void BindVendor(RepositoryItemSearchLookUpEdit p_DrpID, int[] p_VendorType, bool p_ShowBlank)
        {
            BindVendor(p_DrpID, p_VendorType, "", p_ShowBlank);
        }


        /// <summary>
        /// 绑定客户 多个客户类型
        /// </summary>
        public static void BindVendor(RepositoryItemSearchLookUpEdit p_DrpID, int[] p_VendorType, string p_Condition, bool p_ShowBlank)
        {

            LoadRepositorySearch(p_DrpID, BindVendorDataSource(p_VendorType, p_Condition), "VendorID", "VendorAttn", string.Empty); //new int[2] { 20, 20 },
            SetSLKGrid(p_DrpID.View, new string[2] { "VendorID", "VendorAttn" }, new string[2] { "客户编码", "客户简称" }, new bool[2] { true, true });

        }

        #endregion

        #region 绑定产品ItemTypeID为1，绑定坯布TtemTypeID为4

        /// <summary>
        /// 绑定产品
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindItem(RepositoryItemSearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ItemModel,ItemName,ItemStd,ItemCode FROM Data_Item Where ItemTypeID = 1";
            DataTable dt = SysUtils.Fill(sql);
            LoadRepositorySearch(p_DrpID, dt, "ItemCode", "ItemCode", string.Empty);
            SetSLKGrid(p_DrpID.View, new string[4] { "ItemModel", "ItemName", "ItemStd", "ItemCode" }, new string[4] { "品名", "成分", "规格", "编号" }, new bool[4] { true, true, true, true });
        }

        /// <summary>
        /// 绑定坯布
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindItemPB(RepositoryItemSearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ItemCode,ItemModel,ItemStd,ItemName FROM Data_Item Where ItemTypeID = 4";
            DataTable dt = SysUtils.Fill(sql);
            LoadRepositorySearch(p_DrpID, dt, "ItemCode", "ItemCode", string.Empty);
            SetSLKGrid(p_DrpID.View, new string[4] { "ItemCode", "ItemModel", "ItemStd", "ItemName" }, new string[4] { "坯布编号", "坯布品名", "坯布规格", "坯布成分" }, new bool[4] { true, true, true, true });
        }
        /// <summary>
        /// 绑定半成品
        /// </summary>
        /// <param name="p_DrpID"></param>
        /// <param name="p_ShowBlank"></param>
        public static void BindItemBCP(RepositoryItemSearchLookUpEdit p_DrpID, bool p_ShowBlank)
        {
            string sql = "SELECT ItemCode,ItemModel,ItemStd,ItemName FROM Data_Item Where ItemTypeID = 5";
            DataTable dt = SysUtils.Fill(sql);
            LoadRepositorySearch(p_DrpID, dt, "ItemCode", "ItemCode", string.Empty);
            SetSLKGrid(p_DrpID.View, new string[4] { "ItemCode", "ItemModel", "ItemStd", "ItemName" }, new string[4] { "坯布编号", "坯布品名", "坯布规格", "坯布成分" }, new bool[4] { true, true, true, true });
        }
        #endregion
        #region  SearchLookUpEdit、RepositoryItemSearchLookUpEdit绑定基本方法
        /// <summary>
        /// 设置SearchLookUpEdit基本属性
        /// </summary>
        /// <param name="p_DrpID">SearchLookUpEdit控件</param>
        /// <param name="p_dt">数据源DataTable</param>
        /// <param name="p_ValueMember">ValueMember</param>
        /// <param name="p_DisplayMember">DisplayMember</param>
        /// <param name="p_NullText">控件值为空时显示的文字</param>
        public static void LoadSearch(SearchLookUpEdit p_DrpID, DataTable p_dt, string p_ValueMember, string p_DisplayMember, string p_NullText)
        {
            p_DrpID.Properties.DataSource = p_dt;
            p_DrpID.Properties.ValueMember = p_ValueMember;
            p_DrpID.Properties.DisplayMember = p_DisplayMember;
            p_DrpID.Properties.NullText = p_NullText;
            p_DrpID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            p_DrpID.Properties.PopulateViewColumns();
            //p_DrpID.Properties.PopupFormSize = new Size(300, 300);
            p_DrpID.Popup += new System.EventHandler(p_DrpID_Popup);
        }


        /// <summary>
        /// 设置RepositoryItemSearchLookUpEdit基本属性
        /// </summary>
        /// <param name="p_DrpID">RepositoryItemSearchLookUpEdit控件</param>
        /// <param name="p_dt">数据源DataTable</param>
        /// <param name="p_ValueMember">ValueMember</param>
        /// <param name="p_DisplayMember">DisplayMember</param>
        /// <param name="p_NullText">控件值为空时显示的文字</param>
        public static void LoadRepositorySearch(RepositoryItemSearchLookUpEdit p_DrpID, DataTable p_dt, string p_ValueMember, string p_DisplayMember, string p_NullText)
        {
            p_DrpID.DataSource = p_dt;
            p_DrpID.ValueMember = p_ValueMember;
            p_DrpID.DisplayMember = p_DisplayMember;
            p_DrpID.NullText = p_NullText;
            p_DrpID.PopulateViewColumns();
            p_DrpID.Popup += new System.EventHandler(p_DrpID_Popup);
        }

        /// <summary>
        /// 动态创建SearchLookUpEdit自带GridView的列
        /// </summary>
        /// <param name="p_GridView">SearchLookUpEdit自带的GridView</param>
        /// <param name="p_ColWidth">列宽的一维数组</param>
        /// <param name="p_FieldName">列FieldName的一维数组</param>
        /// <param name="p_Caption">列Caption的一维数组</param>
        /// <param name="p_ColVisible">设置列是否可见的一维数组</param>
        public static void SLKCreateGrid(GridView p_GridView, int[] p_ColWidth, string[] p_FieldName, string[] p_Caption, bool[] p_ColVisible)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
            p_GridView.Columns.Clear();
            for (int i = 0; i < p_FieldName.Length; i++)
            {
                column.Caption = p_Caption[i];
                column.FieldName = p_FieldName[i];
                column.Width = p_ColWidth[i];
                column.VisibleIndex = i + 1;
                column.Visible = p_ColVisible[i];
                p_GridView.Columns.Add(column);
            }
        }


        /// <summary>
        /// 设置控件中的GridView
        /// </summary>
        /// <param name="p_GridView">GridView</param>
        /// <param name="p_FieldName">列FieldName</param>
        /// <param name="p_Caption">列标题</param>
        /// <param name="p_ColVisible">是否可见</param>
        public static void SetSLKGrid(GridView p_GridView, string[] p_FieldName, string[] p_Caption, bool[] p_ColVisible)
        {
            //for (int i = 0; i < p_GridView.Columns.Count; i++)
            //{
            //    p_GridView.Columns[i].VisibleIndex = -1;
            //}
            for (int i = 0; i < p_FieldName.Length; i++)
            {
                p_GridView.Columns[p_FieldName[i]].Caption = p_Caption[i];
                p_GridView.Columns[p_FieldName[i]].VisibleIndex = i + 1;
                p_GridView.Columns[p_FieldName[i]].Visible = p_ColVisible[i];
                p_GridView.Columns[p_FieldName[i]].OptionsColumn.AllowMove = false;
            }
            p_GridView.BestFitColumns();
        }


        /// <summary>
        /// 设置控件中的GridView
        /// </summary>
        /// <param name="p_GridView">GridView</param>
        /// <param name="p_FieldName">列FieldName</param>
        /// <param name="p_Caption">列标题</param>
        /// <param name="p_ColVisible">是否可见</param>
        public static void SetSLKGrid(GridView p_GridView, int[] p_ColWidth, string[] p_FieldName, string[] p_Caption, bool[] p_ColVisible)
        {
            for (int i = 0; i < p_FieldName.Length; i++)
            {
                p_GridView.Columns[p_FieldName[i]].Caption = p_Caption[i];
                p_GridView.Columns[p_FieldName[i]].Width = p_ColWidth[i];
                p_GridView.Columns[p_FieldName[i]].VisibleIndex = i + 1;
                p_GridView.Columns[p_FieldName[i]].Visible = p_ColVisible[i];
                p_GridView.BestFitColumns();
                p_GridView.Columns[p_FieldName[i]].OptionsColumn.AllowMove = false;
                //p_GridView.CanDragColumn(p_GridView.Columns[p_FieldName[i]]);
            }
            //p_DrpID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }


        /// <summary>
        /// 重写SearchLookUpEdit自带GridView中按钮的显示文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void p_DrpID_Popup(object sender, EventArgs e)
        {
            DevExpress.Utils.Win.IPopupControl control = sender as DevExpress.Utils.Win.IPopupControl;
            DevExpress.XtraEditors.Popup.PopupBaseForm Form = control.PopupWindow as DevExpress.XtraEditors.Popup.PopupBaseForm;
            LayoutControlItem btFindLCI = GetFindControlLayoutItem(Form, "btFind");
            btFindLCI.Control.Text = "查询";

            LayoutControlItem btClearLCI = GetFindControlLayoutItem(Form, "btClear");
            btClearLCI.Control.Text = "清除";
        }

        /// <summary>
        /// 遍历得到SearchLookUpEdit自带GridView中的按钮
        /// </summary>
        /// <param name="Form"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static LayoutControlItem GetFindControlLayoutItem(PopupBaseForm Form, string strName)
        {
            if (Form != null)
            {
                foreach (Control FormC in Form.Controls)
                {
                    if (FormC is SearchEditLookUpPopup)
                    {
                        SearchEditLookUpPopup SearchPopup = FormC as SearchEditLookUpPopup;
                        foreach (Control SearchPopupC in SearchPopup.Controls)
                        {
                            if (SearchPopupC is LayoutControl)
                            {
                                LayoutControl FormLayout = SearchPopupC as LayoutControl;
                                Control Button = FormLayout.GetControlByName(strName);
                                if (Button != null)
                                {
                                    return FormLayout.GetItemByControl(Button);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        #endregion

    }


    public class ShowProgress
    {
        RepositoryItemProgressBar ProgressBar;  //进度条控件
        GridView m_GridView;     //显示进度条的gridView
        string m_ProgressField;   //显示进度条的字段
        string m_MaxinumField;  //进度条Maxinum取值字段

        #region  GridView单元格进度条
        /// <summary>
        /// GridView单元格显示进度条
        /// </summary>
        /// <param name="gridView">gridView</param>
        /// <param name="ProgressField">显示进度条的字段</param>
        /// <param name="MaxinumField">进度条Maxinum取值字段</param>
        public ShowProgress(GridView gridView, string ProgressField, string MaxinumField)
        {
            m_GridView = gridView;
            m_ProgressField = ProgressField;
            m_MaxinumField = MaxinumField;

            ProgressBar = new RepositoryItemProgressBar { Minimum = 0, Maximum = 100, ShowTitle = true, EndColor = Color.Red, PercentView = false };
            ProgressBar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D; //设置进度条格式

            gridView.GridControl.RepositoryItems.Add(ProgressBar);   //为gridView增加控件ProgressBar
            gridView.Columns[ProgressField].ColumnEdit = ProgressBar;   //将控件ProgressBar绑定到gridView列上

            gridView.Columns[ProgressField].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; //单元格文字居中显示

            gridView.CustomRowCellEdit += new CustomRowCellEditEventHandler(gridView_CustomRowCellEdit);    //gridView事件
            gridView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);  //gridView事件,设置单元格显示文字
            gridView.RowCellStyle += new RowCellStyleEventHandler(gridView_RowCellStyle);
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == m_ProgressField)
                {
                    int RecQty = SysConvert.ToInt32(m_GridView.GetRowCellValue(e.RowHandle, m_ProgressField));
                    int Qty = SysConvert.ToInt32(m_GridView.GetRowCellValue(e.RowHandle, m_MaxinumField));
                    ProgressBar.Maximum = Qty;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "异常");
            }
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == m_ProgressField)
            {
                decimal RecQty = SysConvert.ToDecimal(m_GridView.GetRowCellValue(e.RowHandle, m_ProgressField));
                decimal Qty = SysConvert.ToDecimal(m_GridView.GetRowCellValue(e.RowHandle, m_MaxinumField));
                if (RecQty > 0)
                { e.DisplayText = string.Format("{0}/{1}", RecQty, Qty); }
                else
                { e.DisplayText = ""; }
            }
        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == m_ProgressField)
            {
                decimal RecQty = SysConvert.ToDecimal(m_GridView.GetRowCellValue(e.RowHandle, m_ProgressField));
                decimal Qty = SysConvert.ToDecimal(m_GridView.GetRowCellValue(e.RowHandle, m_MaxinumField));
                if (RecQty >= Qty)
                { e.Appearance.BackColor = Color.Red; }
            }
        }


        #endregion
    }

}
