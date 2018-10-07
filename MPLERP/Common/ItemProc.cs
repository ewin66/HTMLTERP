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
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using System.Reflection;
using System.ComponentModel;

namespace MLTERP
{



    #region 物品编码处理基类
    /// <summary>
    /// 物品编码处理(待开发)
    /// </summary>
    public class ItemProcBase
    {
        private static DateTime ItemQueryTime = SystemConfiguration.DateTimeDefaultValue;//最新一次查询时间

        private static DateTime m_ItemUpdateTime = DateTime.Now;//最近一次更新时间
        public static DateTime ItemUpdateTime
        {
            get
            {
                return m_ItemUpdateTime;
            }
        }

        private static DataTable m_dtItem1 = new DataTable(), m_dtItem3 = new DataTable();//物品1、3数据表
        public static DataTable dtItem1
        {
            get
            {
                if (ItemQueryTime < ItemUpdateTime)//如果最新一次查询时间比最新一次更新时间早则初始化物品数据表
                {
                    dtItemIni();
                }
                return m_dtItem1;
            }
        }

        public static DataTable dtItem3
        {
            get
            {
                if (ItemQueryTime < ItemUpdateTime)//如果最新一次查询时间比最新一次更新时间早则初始化物品数据表
                {
                    dtItemIni();
                }
                return m_dtItem3;
            }
        }

        /// <summary>
        /// 物品初始化
        /// </summary>
        private static void dtItemIni()
        {
            string sql = "SELECT ItemCode,ItemName,ItemStd FROM Data_Item WHERE ItemTypeID=" + SysString.ToDBString((int)HttSoft.MLTERP.Sys.EnumItemType.面料);
            m_dtItem1 = SysUtils.Fill(sql);
            AddBlankRow(m_dtItem1);

            //sql = "SELECT ItemCode,ItemName,ItemStd FROM Data_Item WHERE ItemTypeID=" + SysString.ToDBString((int)ItemType.色卡);
            //m_dtItem3 = SysUtils.Fill(sql);
            //AddBlankRow(m_dtItem3);

            ItemQueryTime = DateTime.Now;//设置一下最新的查询时间
        }

        /// <summary>
        /// 增加空行
        /// </summary>
        private static void AddBlankRow(DataTable p_Dt)
        {
            DataRow dr = p_Dt.NewRow();
            p_Dt.Rows.Add(dr);
            //开始处理空行放在第一行
            for (int i = p_Dt.Rows.Count - 1; i > 0; i--)//循环每个记录
            {
                for (int j = 0; j < p_Dt.Columns.Count; j++)
                {
                    p_Dt.Rows[i][j] = p_Dt.Rows[i - 1][j];
                }
            }
            for (int j = 0; j < p_Dt.Columns.Count; j++)
            {
                p_Dt.Rows[0][j] = DBNull.Value;
            }
        }

        /// <summary>
        /// 获得物品类型数组
        /// </summary>
        /// <param name="p_CLSA"></param>
        /// <param name="p_CLSB"></param>
        /// <returns></returns>
        public static int[] GetItemTypeArray(string p_CLSA, string p_CLSB)
        {
            string sql = "SELECT ID FROM Enum_ItemType WHERE ID IN (";
            sql += "SELECT ItemTypeID FROM Data_ItemTypeForm WHERE CLSA=" + SysString.ToDBString(p_CLSA) + " AND CLSB=" + SysString.ToDBString(p_CLSB);
            sql += ")";
            sql += " ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            int[] itemInt = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                itemInt[i] = SysConvert.ToInt32(dt.Rows[i][0]);
            }
            return itemInt;
        }
    }
    #endregion

    #region 物品编码处理LookUpEdit

    /// <summary>
    /// 物品编码处理LookUpEdit
    /// </summary>
    public class ItemProcLookUp : BaseForm
    {
        private LookUpEdit m_Item;//类内参数

        private TextEdit m_ItemName;//类内参数
        private TextEdit m_ItemStd;//类内参数
        private TextEdit m_ItemAttnCode;//类内参数
        private TextEdit m_ItemModel;//类内参数
        // private TextEdit m_ItemCode;//类内参数
        int[] m_ItemType;//类内方法

        public ItemProcLookUp(LookUpEdit p_Item, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_Item, null, null, null, null, p_ItemType, p_ShowBlank, p_DoubleQuery);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Item"></param>
        /// <param name="p_ItemName"></param>
        /// <param name="p_ItemStd"></param>
        /// <param name="p_CLSA">表名</param>
        /// <param name="p_CLSB">字段名</param>
        /// <param name="p_ShowBlank"></param>
        /// <param name="p_DoubleQuery"></param>
        public ItemProcLookUp(LookUpEdit p_Item, TextEdit p_ItemName, TextEdit p_ItemStd, string p_CLSA, string p_CLSB, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_Item, p_ItemName, p_ItemStd, null, null, ItemProcBase.GetItemTypeArray(p_CLSA, p_CLSB), p_ShowBlank, p_DoubleQuery);
        }


        public ItemProcLookUp(LookUpEdit p_Item, TextEdit p_ItemName, TextEdit p_ItemStd, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_Item, p_ItemName, p_ItemStd, null, null, p_ItemType, p_ShowBlank, p_DoubleQuery);
        }

        public ItemProcLookUp(LookUpEdit p_Item, TextEdit p_ItemName, TextEdit p_ItemStd, TextEdit p_ItemModel, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_Item, p_ItemName, p_ItemStd, null, p_ItemModel, p_ItemType, p_ShowBlank, p_DoubleQuery);
        }

        public ItemProcLookUp(LookUpEdit p_Item, TextEdit p_ItemName, TextEdit p_ItemStd, TextEdit p_ItemAttnCode, TextEdit p_ItemModel, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_Item, p_ItemName, p_ItemStd, p_ItemAttnCode, p_ItemModel, p_ItemType, p_ShowBlank, p_DoubleQuery);
        }

        private void ClassIni(LookUpEdit p_Item, TextEdit p_ItemName, TextEdit p_ItemStd, TextEdit p_ItemAttnCode, TextEdit p_ItemModel, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            m_Item = p_Item;
            m_ItemType = p_ItemType;
            m_ItemName = p_ItemName;
            m_ItemStd = p_ItemStd;
            m_ItemAttnCode = p_ItemAttnCode;
            m_ItemModel = p_ItemModel;
            m_Item.Properties.NullText = "";

            string sql = "SELECT ItemCode+' '+ItemStd+' '+ItemName Item,ItemCode,ItemName,ItemStd,ItemAttnCode,ItemModel FROM Data_Item WHERE 1=1";
            if (p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }
            sql += " ORDER BY ItemCode";
            DataTable dt = SysUtils.Fill(sql);
            p_Item.Properties.ShowHeader = true;
            p_Item.Properties.ShowFooter = false;
            p_Item.Properties.TextEditStyle = TextEditStyles.Standard;
            FCommon.LookupEditColAdd(p_Item, new int[] { 50, 50, 200, 100, 50 }, new string[] { "ItemCode", "ItemStd", "ItemName", "ItemModel", "ItemAttnCode" }, new string[] { "物品编码", "物品规格", "物品名称", "物品品名", "辅助编码" }, new bool[] { true, true, true, true, false });

            FCommon.LoadDropLookUP(p_Item, dt, "Item", "ItemCode", p_ShowBlank);

            if (p_ItemName != null)//传入文本框名称
            {
                p_Item.EditValueChanged += new System.EventHandler(drpItem_EditValueChanged);
            }
            p_Item.KeyDown += new System.Windows.Forms.KeyEventHandler(drpItem_KeyDown);
            p_Item.KeyPress += new System.Windows.Forms.KeyPressEventHandler(drpItem_KeyPress);
            p_Item.Leave += new System.EventHandler(drpItem_Leave);
            p_Item.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
        }

        private void drpItem_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                string itemcode = SysConvert.ToString(m_Item.EditValue);
                string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(itemcode);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    m_ItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    m_ItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    if (m_ItemAttnCode != null)
                    {
                        m_ItemAttnCode.Text = dt.Rows[0]["ItemAttnCode"].ToString();
                    }
                    if (m_ItemModel != null)
                    {
                        m_ItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                    }
                }
                else
                {
                    m_ItemName.Text = "";
                    m_ItemStd.Text = "";
                    if (m_ItemAttnCode != null)
                    {
                        m_ItemAttnCode.Text = "";
                    }
                    if (m_ItemModel != null)
                    {
                        m_ItemModel.Text = "";
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        bool clearflag = false;
        private void drpItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 8)
                {
                    if (SysConvert.ToString(m_Item.Text) == "")
                    {
                        clearflag = true;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (SysConvert.ToString(m_Item.Text) == "")
                    {
                        clearflag = true;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        private void drpItem_Leave(object sender, System.EventArgs e)
        {
            if (clearflag)
            {
                m_Item.EditValue = "";
                clearflag = false;
            }
        }


        /// <summary>
        /// 双击带出纱线
        /// </summary>
        private void drpItem_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (!m_Item.Properties.ReadOnly)
                {
                    frmLoadItem frm = new frmLoadItem();
                    frm.FormID = this.GetFormIDByClassName("frmLoadItem");
                    frm.ItemTypeThis = m_ItemType;
                    frm.ShowDialog();
                    if (frm.SelectFlag)
                    {
                        m_Item.EditValue = frm.ItemCode;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }


    #endregion

    #region 物品编码处理ComBoxEdit
    /// <summary>
    /// 物品编码处理ComBoxEdit
    /// </summary>
    public class ItemProcCom : BaseForm
    {
        private ComboBoxEdit m_ItemCode;
        int[] m_ItemType;//类内方法
        public ItemProcCom(ComboBoxEdit p_ItemCode, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            m_ItemCode = p_ItemCode;

            m_ItemType = p_ItemType;

            string sql = "SELECT ItemCode,ItemName,ItemStd FROM Data_Item WHERE 1=1";
            if (p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_ItemCode, dt, "ItemCode", p_ShowBlank);


            if (p_DoubleQuery)
            {
                p_ItemCode.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
            }
        }


        /// <summary>
        /// 双击带出纱线
        /// </summary>
        private void drpItem_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (!m_ItemCode.Properties.ReadOnly)
                {
                    frmLoadItem frm = new frmLoadItem();
                    frm.FormID = this.GetFormIDByClassName("frmLoadItem");
                    frm.ItemTypeThis = m_ItemType;
                    frm.ShowDialog();
                    if (frm.SelectFlag)
                    {
                        m_ItemCode.EditValue = frm.ItemCode;
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }



    #endregion

    #region 物品编码处理Respon
    /// <summary>
    /// 物品编码处理Grid
    /// </summary>
    public class ItemProcRes1 : BaseForm
    {

        private ComboBoxEdit t_ItemCode = new ComboBoxEdit(), t_ItemName = new ComboBoxEdit(), t_ItemStd = new ComboBoxEdit();//类内参数

        Label m_FocusLabel;
        private RepositoryItemLookUpEdit m_ItemCode, m_ItemName, m_ItemStd;//类内参数
        int[] m_ItemType;//类内物品类型
        GridView m_View;//类内GridView
        string[] m_ItemFieldName;//类内字段数组
        public ItemProcRes1(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_ItemCode, RepositoryItemLookUpEdit p_ItemName, RepositoryItemLookUpEdit p_ItemStd, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            m_FocusLabel = p_FocusLabel;
            m_ItemCode = p_ItemCode;
            m_ItemName = p_ItemName;
            m_ItemStd = p_ItemStd;
            m_ItemType = p_ItemType;
            m_View = p_View;
            m_ItemFieldName = p_ItemFieldName;

            //new ItemProc(t_ItemCode,t_ItemName,t_ItemStd,p_ItemType,p_ShowBlank,p_DoubleQuery);

            string sql = "SELECT ItemCode,ItemName,ItemStd FROM Data_Item WHERE 1=1";
            if (p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }
            DataTable dt = SysUtils.Fill(sql);
            p_ItemCode.ShowHeader = false;
            p_ItemCode.ShowFooter = false;
            p_ItemCode.TextEditStyle = TextEditStyles.Standard;

            p_ItemName.ShowHeader = false;
            p_ItemName.ShowFooter = false;
            p_ItemName.TextEditStyle = TextEditStyles.Standard;

            p_ItemStd.ShowHeader = false;
            p_ItemStd.ShowFooter = false;
            p_ItemStd.TextEditStyle = TextEditStyles.Standard;

            FCommon.RepositoryLookupEditColAdd(p_ItemCode, new int[1] { 50 }, new string[1] { "ItemCode" }, new string[1] { "" }, new bool[1] { true });
            FCommon.LoadDropRepositoryLookUP(p_ItemCode, dt, "ItemCode", "ItemCode", p_ShowBlank);
            FCommon.RepositoryLookupEditColAdd(p_ItemName, new int[1] { 150 }, new string[1] { "ItemName" }, new string[1] { "" }, new bool[1] { true });
            FCommon.LoadDropRepositoryLookUP(p_ItemName, dt, "ItemName", "ItemName", p_ShowBlank);
            FCommon.RepositoryLookupEditColAdd(p_ItemStd, new int[1] { 50 }, new string[1] { "ItemStd" }, new string[1] { "" }, new bool[1] { true });
            FCommon.LoadDropRepositoryLookUP(p_ItemStd, dt, "ItemStd", "ItemStd", p_ShowBlank);

            p_ItemCode.Leave -= new System.EventHandler(drpQItemCode_SelectedIndexChanged);
            p_ItemCode.Leave += new System.EventHandler(drpQItemCode_SelectedIndexChanged);
            //p_ItemName.Leave += new System.EventHandler(drpQItemName_SelectedIndexChanged);
            //p_ItemStd.Leave += new System.EventHandler(drpQItemStd_SelectedIndexChanged);

            if (p_DoubleQuery)
            {
                p_ItemCode.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
                p_ItemName.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
                p_ItemStd.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
                p_ItemCode.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
                p_ItemName.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
                p_ItemStd.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
            }
        }
        public void Release()
        {
            m_ItemCode.Leave -= new System.EventHandler(drpQItemCode_SelectedIndexChanged);
            m_ItemCode.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
            m_ItemName.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
            m_ItemStd.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
        }



        private void drpQItemCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string tempv = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0]));
                t_ItemCode.Text = tempv;
                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], t_ItemName.Text);
                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], t_ItemStd.Text);
                if (m_ItemFieldName.Length >= 3)
                {
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], "KG");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQItemName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string tempv = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1]));
                t_ItemName.Text = tempv;
                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0], t_ItemCode.Text);
                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], t_ItemStd.Text);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQItemStd_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string tempv = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2]));
                t_ItemStd.Text = tempv;
                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0], t_ItemCode.Text);
                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], t_ItemName.Text);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 双击带出纱线
        /// </summary>
        private void drpItem_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (m_View.Columns[m_ItemFieldName[0]].OptionsColumn.AllowEdit)
                {
                    frmLoadItem frm = new frmLoadItem();
                    frm.FormID = this.GetFormIDByClassName("frmLoadItem");
                    frm.ItemTypeThis = m_ItemType;
                    frm.ShowDialog();
                    if (frm.SelectFlag)
                    {
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0], frm.ItemCode);
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], frm.ItemName);
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], frm.ItemStd);
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }



    #endregion

    public delegate void ItemProcEventPrice(int p_RowID);// 定义委托处理程序

    #region 物品编码处理ItemProcResLookUP
    /// <summary>
    /// 物品编码处理Grid
    /// </summary>
    public class ItemProcResLookUP : BaseForm
    {

        Label m_FocusLabel;
        private RepositoryItemLookUpEdit m_Item;//类内参数
        private RepositoryItemTextEdit m_ItemTxt;//类内参数
        private TextEdit m_TxtDefaultUnit;//类内默认单位
        int[] m_ItemType;//类内物品类型
        GridView m_View;//类内GridView
        string[] m_ItemFieldName;//类内字段数组
        string m_AttnItemCodeField;
        string m_ItemModelField;
        bool m_BWEditFlag = false;  //并网纱工艺界面操作标志
        string m_GYSJDSField;   //菁成工艺单带出原料 D数
        ItemProcEventPrice m_EventPrice;
        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, null, "", "", "", p_ShowBlank, p_DoubleQuery, false, "", null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string p_Connection, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_Connection, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, null, "", "", p_ShowBlank, p_DoubleQuery, false);
        }
        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, string p_CLSA, string p_CLSB, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, ItemProcBase.GetItemTypeArray(p_CLSA, p_CLSB), null, null, "", "", "", p_ShowBlank, p_DoubleQuery, false, "", null, null);
        }
        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, string p_AttnItemCodeField, string p_ItemModelField, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, null, "", p_ItemModelField, "", p_ShowBlank, p_DoubleQuery, false, "", null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, TextEdit p_TxtDefaultUnit, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, p_TxtDefaultUnit, "", "", "", p_ShowBlank, p_DoubleQuery, false, "", null, null);
        }
        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, p_EventPrice, null, "", "", "", p_ShowBlank, p_DoubleQuery, false, "", null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, TextEdit p_TxtDefaultUnit, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, p_EventPrice, p_TxtDefaultUnit, "", "", "", p_ShowBlank, p_DoubleQuery, false, "", null, null);
        }
        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, TextEdit p_TxtDefaultUnit, string p_AttnItemCodeField, bool p_ShowBlank, bool p_DoubleQuery, bool p_ML)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, p_EventPrice, p_TxtDefaultUnit, p_AttnItemCodeField, "", "", p_ShowBlank, p_DoubleQuery, p_ML, "", null, null);
        }


        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, TextEdit p_TxtDefaultUnit, bool p_ShowBlank, bool p_DoubleQuery, bool p_ML)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, p_TxtDefaultUnit, "", "", "", p_ShowBlank, p_DoubleQuery, p_ML, "", null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, null, "", "", "", p_ShowBlank, p_DoubleQuery, false, p_StrWhere, null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, string p_CLSA, string p_CLSB, bool p_ShowBlank, bool p_DoubleQuery, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, ItemProcBase.GetItemTypeArray(p_CLSA, p_CLSB), null, null, "", "", "", p_ShowBlank, p_DoubleQuery, false, p_StrWhere, null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, string p_AttnItemCodeField, string p_ItemModelField, bool p_ShowBlank, bool p_DoubleQuery, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, null, "", p_ItemModelField, "", p_ShowBlank, p_DoubleQuery, false, p_StrWhere, null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, TextEdit p_TxtDefaultUnit, bool p_ShowBlank, bool p_DoubleQuery, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, p_TxtDefaultUnit, "", "", "", p_ShowBlank, p_DoubleQuery, false, p_StrWhere, null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, bool p_ShowBlank, bool p_DoubleQuery, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, p_EventPrice, null, "", "", "", p_ShowBlank, p_DoubleQuery, false, p_StrWhere, null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, TextEdit p_TxtDefaultUnit, bool p_ShowBlank, bool p_DoubleQuery, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, p_EventPrice, p_TxtDefaultUnit, "", "", "", p_ShowBlank, p_DoubleQuery, false, p_StrWhere, null, null);
        }
        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, TextEdit p_TxtDefaultUnit, string p_AttnItemCodeField, bool p_ShowBlank, bool p_DoubleQuery, bool p_ML, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, p_EventPrice, p_TxtDefaultUnit, p_AttnItemCodeField, "", "", p_ShowBlank, p_DoubleQuery, p_ML, p_StrWhere, null, null);
        }

        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, string p_AttnItemCodeField, bool p_ShowBlank, bool p_DoubleQuery, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, null, p_AttnItemCodeField, "", "", p_ShowBlank, p_DoubleQuery, false, p_StrWhere, null, null);
        }
        public ItemProcResLookUP(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, TextEdit p_TxtDefaultUnit, bool p_ShowBlank, bool p_DoubleQuery, bool p_ML, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_Item, p_ItemTxt, p_ItemType, null, p_TxtDefaultUnit, "", "", "", p_ShowBlank, p_DoubleQuery, p_ML, p_StrWhere, null, null);
        }

        private void ClassIni(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, TextEdit p_TxtDefaultUnit, string p_AttnItemCodeField, string p_ItemModelField, string p_GYSJDSField, bool p_ShowBlank, bool p_DoubleQuery, bool p_ML, string p_StrWhere, EventHandler DDouble, EventHandler LLeave)
        {
            m_FocusLabel = p_FocusLabel;
            m_Item = p_Item;
            m_ItemType = p_ItemType;
            m_View = p_View;
            m_ItemFieldName = p_ItemFieldName;
            m_ItemTxt = p_ItemTxt;
            m_EventPrice = p_EventPrice;
            m_TxtDefaultUnit = p_TxtDefaultUnit;
            m_AttnItemCodeField = p_AttnItemCodeField;
            m_ItemModelField = p_ItemModelField;
            m_GYSJDSField = p_GYSJDSField;

            string sql = "SELECT ItemCode,ItemName,ItemStd,ItemModel FROM Data_Item WHERE 1=1";
            if (p_ItemType != null && p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }
            if (p_StrWhere != "")
            {
                sql += p_StrWhere;
            }
            sql += " ORDER BY ItemCode";
            DataTable dt = SysUtils.Fill(sql);
            p_Item.ShowHeader = true;
            p_Item.ShowFooter = false;
            p_Item.TextEditStyle = TextEditStyles.Standard;

            FCommon.RepositoryLookupEditColAdd(p_Item, new int[] { 80, 80, 80, 200 }, new string[] { "ItemCode", "ItemStd", "ItemName", "ItemModel" }, new string[] { "编码", "规格", "成分", "品名" }, new bool[] { true, true, true, true });
            FCommon.LoadDropRepositoryLookUP(p_Item, dt, "ItemCode", "ItemCode", p_ShowBlank);


            p_Item.ResetEvents();
            m_ItemTxt.ResetEvents();

            p_Item.EditValueChanged += new System.EventHandler(drpQItemCode_SelectedIndexChanged);
            //p_Item.Leave += new System.EventHandler(drpQItemCode_SelectedIndexChanged);

            p_Item.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
            m_ItemTxt.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
        }

        #region 移除控件事件
        void ClearEvent(RepositoryItemLookUpEdit control, string eventname)
        {

            if (control == null) return;
            if (string.IsNullOrEmpty(eventname)) return;

            BindingFlags mPropertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
            BindingFlags mFieldFlags = BindingFlags.Static | BindingFlags.NonPublic;
            Type controlType = typeof(RepositoryItemLookUpEdit);
            PropertyInfo propertyInfo = controlType.GetProperty("Events", mPropertyFlags);
            EventHandlerList eventHandlerList = (EventHandlerList)propertyInfo.GetValue(control, null);
            FieldInfo fieldInfo = (typeof(RepositoryItemLookUpEdit)).GetField("Event" + eventname, mFieldFlags);
            Delegate d = eventHandlerList[fieldInfo.GetValue(control)];

            if (d == null) return;
            EventInfo eventInfo = controlType.GetEvent(eventname);

            foreach (Delegate dx in d.GetInvocationList())
                eventInfo.RemoveEventHandler(control, dx);

        }
        void ClearEvent(RepositoryItemTextEdit control, string eventname)
        {

            if (control == null) return;
            if (string.IsNullOrEmpty(eventname)) return;

            BindingFlags mPropertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
            BindingFlags mFieldFlags = BindingFlags.Static | BindingFlags.NonPublic;
            Type controlType = typeof(RepositoryItemTextEdit);
            PropertyInfo propertyInfo = controlType.GetProperty("Events", mPropertyFlags);
            EventHandlerList eventHandlerList = (EventHandlerList)propertyInfo.GetValue(control, null);
            FieldInfo fieldInfo = (typeof(RepositoryItemTextEdit)).GetField("Event" + eventname, mFieldFlags);
            Delegate d = eventHandlerList[fieldInfo.GetValue(control)];

            if (d == null) return;
            EventInfo eventInfo = controlType.GetEvent(eventname);

            foreach (Delegate dx in d.GetInvocationList())
                eventInfo.RemoveEventHandler(control, dx);

        }
        #endregion
        private void ClassIni(Label p_FocusLabel, GridView p_View, string p_Connection, string[] p_ItemFieldName, RepositoryItemLookUpEdit p_Item, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, TextEdit p_TxtDefaultUnit, string p_AttnItemCodeField, string p_ItemModelField, bool p_ShowBlank, bool p_DoubleQuery, bool p_ML)
        {
            m_FocusLabel = p_FocusLabel;
            m_Item = p_Item;
            m_ItemType = p_ItemType;
            m_View = p_View;
            m_ItemFieldName = p_ItemFieldName;
            m_ItemTxt = p_ItemTxt;
            m_EventPrice = p_EventPrice;
            m_TxtDefaultUnit = p_TxtDefaultUnit;
            m_AttnItemCodeField = p_AttnItemCodeField;
            m_ItemModelField = p_ItemModelField;



            string sql = "SELECT ItemCode,ItemName,ItemStd FROM Data_Item WHERE 1=1";
            sql += " AND UseableFlag=1";
            if (p_ItemType != null && p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }
            sql += p_Connection;
            sql += " ORDER BY ItemModel";
            DataTable dt = SysUtils.Fill(sql);
            p_Item.ShowHeader = true;
            p_Item.ShowFooter = false;
            p_Item.TextEditStyle = TextEditStyles.Standard;

            FCommon.RepositoryLookupEditColAdd(p_Item, new int[] { 70, 200, 100 }, new string[] { "ItemStd", "ItemName", "ItemCode" }, new string[] { "物品规格", "物品名称", "物品编码" }, new bool[] { true, true, true });
            FCommon.LoadDropRepositoryLookUP(p_Item, dt, "ItemCode", "ItemCode", p_ShowBlank);


            p_Item.ResetEvents();
            m_ItemTxt.ResetEvents();


            p_Item.Leave += new System.EventHandler(drpQItemCode_SelectedIndexChanged);

            p_Item.Modified += new System.EventHandler(drpQItemCode_SelectedIndexChanged);



            p_Item.DoubleClick += new System.EventHandler(drpItem_DoubleClick);

            m_ItemTxt.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
        }





        private void drpQItemCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string itemcode = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0]));
                string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(itemcode);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], dt.Rows[0]["ItemName"].ToString());
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], dt.Rows[0]["ItemStd"].ToString());

                    if (m_ItemFieldName[3] == "Unit")
                    {
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], dt.Rows[0]["ItemUnit"].ToString());
                    }
                    if (m_ItemFieldName[3] == "BCPItemModel")
                    {
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], dt.Rows[0]["ItemModel"].ToString());
                    }

                    //if (m_ItemFieldName.Length >= 4)
                    //{
                    //    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], dt.Rows[0]["ItemUnit"].ToString());
                    //}

                    //

                    //if (m_ItemModelField != string.Empty)
                    //{
                    //    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemModelField, dt.Rows[0]["ItemModel"].ToString());
                    //}

                }
                else
                {
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], "");
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], "");
                    if (m_ItemFieldName.Length >= 4)
                    {
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], "");
                    }

                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }





        /// <summary>
        /// 双击带出纱线
        /// </summary>
        private void drpItem_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (m_View.Columns[m_ItemFieldName[0]].OptionsColumn.AllowEdit)
                {
                    frmLoadItem frm = new frmLoadItem();
                    frm.FormID = this.GetFormIDByClassName("frmLoadItem");
                    frm.ItemTypeThis = m_ItemType;

                    frm.ShowDialog();
                    if (frm.SelectFlag)
                    {
                        //解决菁诚弹出新增后编码没刷新问题（重新绑定）
                        string sql = "SELECT ItemCode,ItemName,ItemStd FROM Data_Item WHERE 1=1";
                        if (m_ItemType != null && m_ItemType.Length > 0)
                        {
                            sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(m_ItemType) + ")";
                        }

                        sql += " ORDER BY ItemCode";
                        DataTable dt = SysUtils.Fill(sql);
                        m_Item.ShowHeader = true;
                        m_Item.ShowFooter = false;
                        m_Item.TextEditStyle = TextEditStyles.Standard;

                        FCommon.RepositoryLookupEditColAdd(m_Item, new int[] { 50, 50, 200 }, new string[] { "ItemCode", "ItemStd", "ItemName" }, new string[] { "物品编码", "物品规格", "物品名称" }, new bool[] { true, true, true });
                        FCommon.LoadDropRepositoryLookUP(m_Item, dt, "ItemCode", "ItemCode", true);


                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0], frm.ItemCode);
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], frm.ItemName);
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], frm.ItemStd);
                        if (m_ItemFieldName.Length >= 4)
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], frm.ItemUnit);
                        }

                        if (m_ItemModelField != string.Empty)
                        {

                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemModelField, frm.ItemModel);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

    }





    #endregion

    #region 物品编码处理ItemProcResComBox
    /// <summary>
    /// 物品编码处理Grid
    /// </summary>
    public class ItemProcResComBox : BaseForm
    {

        Label m_FocusLabel;
        private RepositoryItemComboBox m_ItemDisplay;//类内参数
        private RepositoryItemComboBox m_ItemValue;//类内参数
        private RepositoryItemTextEdit m_ItemTxt;//类内参数
        private TextEdit m_TxtDefaultUnit;//类内默认单位
        int[] m_ItemType;//类内物品类型
        GridView m_View;//类内GridView
        string[] m_ItemFieldName;//类内字段数组
        string m_AttnItemCodeField;
        string m_ItemModelField;

        ItemProcEventPrice m_EventPrice;
        public ItemProcResComBox(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemComboBox p_ItemDisplay, RepositoryItemComboBox p_ItemValue, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, bool p_ShowBlank, bool p_DoubleQuery)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_ItemDisplay, p_ItemValue, p_ItemTxt, p_ItemType, null, null, "", "", p_ShowBlank, p_DoubleQuery, false, "");
        }
        private void ClassIni(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemComboBox p_ItemDisplay, RepositoryItemComboBox p_ItemValue, RepositoryItemTextEdit p_ItemTxt, int[] p_ItemType, ItemProcEventPrice p_EventPrice, TextEdit p_TxtDefaultUnit, string p_AttnItemCodeField, string p_ItemModelField, bool p_ShowBlank, bool p_DoubleQuery, bool p_ML, string p_StrWhere)
        {
            m_FocusLabel = p_FocusLabel;
            m_ItemDisplay = p_ItemDisplay;
            m_ItemValue = p_ItemValue;
            m_ItemType = p_ItemType;
            m_View = p_View;
            m_ItemFieldName = p_ItemFieldName;
            m_ItemTxt = p_ItemTxt;
            m_EventPrice = p_EventPrice;
            m_TxtDefaultUnit = p_TxtDefaultUnit;
            m_AttnItemCodeField = p_AttnItemCodeField;
            m_ItemModelField = p_ItemModelField;

            //new ItemProc(t_ItemCode,t_ItemName,t_ItemStd,p_ItemType,p_ShowBlank,p_DoubleQuery);

            string sql = "SELECT ItemCode,ItemName,ItemStd,ItemCode+' ' +ItemName+' '+ItemStd  Item FROM Data_Item WHERE 1=1";
            if (p_ItemType != null && p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }
            if (p_StrWhere != "")
            {
                sql += p_StrWhere;
            }
            sql += " ORDER BY ItemModel";
            DataTable dt = SysUtils.Fill(sql);
            //p_Item.ShowHeader = true;
            //p_Item.ShowFooter = false;
            p_ItemDisplay.TextEditStyle = TextEditStyles.Standard;

            //FCommon.RepositoryLookupEditColAdd(p_Item, new int[] { 70, 200, 100 }, new string[] { "ItemStd", "ItemName", "ItemCode" }, new string[] { "物品规格", "物品名称", "物品编码" }, new bool[] { true, true, true });
            FCommon.LoadDropRepositoryComb(p_ItemDisplay, dt, "Item", "ItemCode", p_ShowBlank);

            //FCommon.LoadDropRepositoryComb(p_ItemValue, dt, "ItemCode", "ItemCode", p_ShowBlank);

            if (p_ML)
            {
                p_ItemDisplay.Leave -= new System.EventHandler(drpQItemCodeML_SelectedIndexChanged);
                p_ItemDisplay.Leave += new System.EventHandler(drpQItemCodeML_SelectedIndexChanged);

                p_ItemDisplay.Modified -= new System.EventHandler(drpQItemCodeML_SelectedIndexChanged);
                p_ItemDisplay.Modified += new System.EventHandler(drpQItemCodeML_SelectedIndexChanged);


            }
            else
            {
                p_ItemDisplay.Leave -= new System.EventHandler(drpQItemCode_SelectedIndexChanged);
                p_ItemDisplay.Leave += new System.EventHandler(drpQItemCode_SelectedIndexChanged);

                p_ItemDisplay.Modified -= new System.EventHandler(drpQItemCode_SelectedIndexChanged);
                p_ItemDisplay.Modified += new System.EventHandler(drpQItemCode_SelectedIndexChanged);


            }

            if (p_DoubleQuery)
            {
                p_ItemDisplay.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
                m_ItemTxt.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);

                p_ItemDisplay.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
                m_ItemTxt.DoubleClick += new System.EventHandler(drpItem_DoubleClick);
            }
        }

        public void Release()
        {
            m_ItemDisplay.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
            m_ItemTxt.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
        }



        private void drpQItemCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string itemcode = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0]));
                //string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(itemcode);
                string sql = "SELECT * FROM Data_Item WHERE ItemCode+' '+ItemName+' '+ItemStd=" + SysString.ToDBString(itemcode);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], dt.Rows[0]["ItemName"].ToString());
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], dt.Rows[0]["ItemStd"].ToString());
                    if (m_ItemFieldName.Length >= 4)
                    {
                        if (m_TxtDefaultUnit != null)
                        {
                            if (m_TxtDefaultUnit.Text != string.Empty)
                            {
                                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], m_TxtDefaultUnit.Text);
                            }
                            else
                            {
                                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], dt.Rows[0]["ItemUnit"].ToString());
                            }
                        }
                        else
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], dt.Rows[0]["ItemUnit"].ToString());
                        }
                    }
                    if (m_EventPrice != null)
                    {
                        m_EventPrice(m_View.FocusedRowHandle);
                    }
                    if (m_AttnItemCodeField != string.Empty)
                    {
                        if (dt.Rows[0]["ItemAttnCode"].ToString() != string.Empty)
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_AttnItemCodeField, dt.Rows[0]["ItemAttnCode"].ToString());
                        }
                    }

                    if (m_ItemModelField != string.Empty)
                    {

                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemModelField, dt.Rows[0]["ItemModel"].ToString());
                        //if (dt.Rows[0]["ItemModel"].ToString() != string.Empty)
                        //{
                        //}
                    }
                }
                else
                {
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], "");
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], "");
                    if (m_ItemFieldName.Length >= 4)
                    {
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], "");
                    }
                    if (m_EventPrice != null)
                    {
                        m_EventPrice(m_View.FocusedRowHandle);
                    }
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQItemCodeML_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string itemcode = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0]));
                string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(itemcode);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], dt.Rows[0]["ItemName"].ToString());
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], dt.Rows[0]["ItemStd"].ToString());
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[4], dt.Rows[0]["ItemCW"].ToString());//财务分类
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[5], dt.Rows[0]["ItemrSeason"].ToString());//季节分类
                    if (m_ItemFieldName.Length >= 4)
                    {
                        if (m_TxtDefaultUnit != null)
                        {
                            if (m_TxtDefaultUnit.Text != string.Empty)
                            {
                                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], m_TxtDefaultUnit.Text);
                            }
                            else
                            {
                                m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], dt.Rows[0]["ItemUnit"].ToString());
                            }
                        }
                        else
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], dt.Rows[0]["ItemUnit"].ToString());
                        }
                    }
                    if (m_EventPrice != null)
                    {
                        m_EventPrice(m_View.FocusedRowHandle);
                    }
                    if (m_AttnItemCodeField != string.Empty)
                    {
                        if (dt.Rows[0]["ItemAttnCode"].ToString() != string.Empty)
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_AttnItemCodeField, dt.Rows[0]["ItemAttnCode"].ToString());
                        }
                    }

                    if (m_ItemModelField != string.Empty)
                    {

                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemModelField, dt.Rows[0]["ItemModel"].ToString());
                        //if (dt.Rows[0]["ItemModel"].ToString() != string.Empty)
                        //{
                        //}
                    }
                }
                else
                {
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], "");
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], "");
                    if (m_ItemFieldName.Length >= 4)
                    {
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], "");
                    }
                    if (m_EventPrice != null)
                    {
                        m_EventPrice(m_View.FocusedRowHandle);
                    }
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 双击带出纱线
        /// </summary>
        private void drpItem_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (m_View.Columns[m_ItemFieldName[0]].OptionsColumn.AllowEdit)
                {
                    frmLoadItem frm = new frmLoadItem();
                    frm.FormID = this.GetFormIDByClassName("frmLoadItem");
                    frm.ItemTypeThis = m_ItemType;
                    frm.ShowDialog();
                    if (frm.SelectFlag)
                    {
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[0], frm.ItemCode);
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[1], frm.ItemName);
                        m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[2], frm.ItemStd);
                        if (m_ItemFieldName.Length >= 4)
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemFieldName[3], frm.ItemUnit);
                        }

                        if (m_EventPrice != null)
                        {
                            m_EventPrice(m_View.FocusedRowHandle);
                        }
                        if (m_AttnItemCodeField != string.Empty)
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_AttnItemCodeField, frm.ItemAttnCode);
                        }

                        if (m_ItemModelField != string.Empty)
                        {
                            m_View.SetRowCellValue(m_View.FocusedRowHandle, m_ItemModelField, frm.ItemModel);
                        }


                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }



    #endregion

    #region 物品编码处理形态转换仓库

    /// <summary>
    /// 物品编码处理形态转换产量记录
    /// </summary>
    public class ItemProcIOForm : BaseForm
    {
        private ComboBoxEdit m_ItemCode, m_ItemName, m_ItemStd;//类内参数
        public ItemProcIOForm(ComboBoxEdit p_ItemCode, ComboBoxEdit p_ItemName, ComboBoxEdit p_ItemStd, int p_IOFormID, bool p_ShowBlank)
        {
            m_ItemCode = p_ItemCode;
            m_ItemName = p_ItemName;
            m_ItemStd = p_ItemStd;

            string sql = "SELECT ItemCode,ItemName,ItemStd FROM WH_IOFormDts WHERE IOFormID=" + SysString.ToDBString(p_IOFormID);
            DataTable dt = SysUtils.Fill(sql);
            FCommon.LoadDropComb(p_ItemCode, dt, "ItemCode", p_ShowBlank);
            FCommon.LoadDropComb(p_ItemName, dt, "ItemName", p_ShowBlank);
            FCommon.LoadDropComb(p_ItemStd, dt, "ItemStd", p_ShowBlank);

            p_ItemCode.SelectedIndexChanged += new System.EventHandler(drpQItemCode_SelectedIndexChanged);
            p_ItemName.SelectedIndexChanged += new System.EventHandler(drpQItemName_SelectedIndexChanged);
            p_ItemStd.SelectedIndexChanged += new System.EventHandler(drpQItemStd_SelectedIndexChanged);


        }

        private void drpQItemCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_ItemName.SelectedIndex = m_ItemCode.SelectedIndex;
                m_ItemStd.SelectedIndex = m_ItemCode.SelectedIndex;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQItemName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_ItemCode.SelectedIndex = m_ItemName.SelectedIndex;
                m_ItemStd.SelectedIndex = m_ItemName.SelectedIndex;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQItemStd_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_ItemCode.SelectedIndex = m_ItemStd.SelectedIndex;
                m_ItemName.SelectedIndex = m_ItemStd.SelectedIndex;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }

    #endregion


    #region 物品编码处理ItemProcResComBox 配色算料多选择
    /// <summary>
    /// 物品编码处理Grid
    /// </summary>
    public class ItemProcResComBoxFS : BaseForm
    {

        Label m_FocusLabel;
        private RepositoryItemComboBox m_ItemCode;//类内参数
        private RepositoryItemComboBox m_ItemName;//类内参数
        private RepositoryItemComboBox m_ItemStd;//类内参数
        private TextEdit m_TxtDefaultUnit;//类内默认单位
        int[] m_ItemType;//类内物品类型
        GridView m_View;//类内GridView
        string m_StrWhere = string.Empty;
        string[] m_ItemFieldName;//类内字段数组

        public ItemProcResComBoxFS(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemComboBox p_ItemCode, RepositoryItemComboBox p_ItemName, RepositoryItemComboBox p_ItemStd, int[] p_ItemType, bool p_ShowBlank, string p_StrWhere)
        {
            ClassIni(p_FocusLabel, p_View, p_ItemFieldName, p_ItemCode, p_ItemName, p_ItemStd, p_ItemType, false, p_StrWhere);
        }
        private void ClassIni(Label p_FocusLabel, GridView p_View, string[] p_ItemFieldName, RepositoryItemComboBox p_ItemCode, RepositoryItemComboBox p_ItemName, RepositoryItemComboBox p_ItemStd, int[] p_ItemType, bool p_ShowBlank, string p_StrWhere)
        {
            m_FocusLabel = p_FocusLabel;
            m_ItemCode = p_ItemCode;
            m_ItemName = p_ItemName;
            m_ItemStd = p_ItemStd;
            m_View = p_View;
            m_ItemFieldName = p_ItemFieldName;
            m_StrWhere = p_StrWhere;

            //new ItemProc(t_ItemCode,t_ItemName,t_ItemStd,p_ItemType,p_ShowBlank,p_DoubleQuery);

            string sql = "SELECT ItemCode,ItemName,ItemStd,ItemCode+' ' +ItemName+' '+ItemStd  Item FROM Data_Item WHERE 1=1";
            if (p_ItemType != null && p_ItemType.Length > 0)
            {
                sql += " AND ItemTypeID IN(" + Common.ConvertArrayIntToStr(p_ItemType) + ")";
            }
            if (p_StrWhere != "")
            {
                sql += p_StrWhere;
            }
            sql += " ORDER BY ItemCode";
            DataTable dt = SysUtils.Fill(sql);
            //p_Item.ShowHeader = true;
            //p_Item.ShowFooter = false;
            p_ItemCode.TextEditStyle = TextEditStyles.Standard;

            //FCommon.RepositoryLookupEditColAdd(p_Item, new int[] { 70, 200, 100 }, new string[] { "ItemStd", "ItemName", "ItemCode" }, new string[] { "物品规格", "物品名称", "物品编码" }, new bool[] { true, true, true });
            FCommon.LoadDropRepositoryComb(p_ItemCode, dt, "ItemCode", "ItemCode", p_ShowBlank);
            FCommon.LoadDropRepositoryComb(p_ItemName, dt, "ItemName", "ItemName", p_ShowBlank);
            FCommon.LoadDropRepositoryComb(p_ItemStd, dt, "ItemStd", "ItemStd", p_ShowBlank);

            //FCommon.LoadDropRepositoryComb(p_ItemValue, dt, "ItemCode", "ItemCode", p_ShowBlank);


            p_ItemCode.Leave -= new System.EventHandler(drpQItemCode_SelectedIndexChanged);
            p_ItemCode.Leave += new System.EventHandler(drpQItemCode_SelectedIndexChanged);

            p_ItemCode.Modified -= new System.EventHandler(drpQItemCode_SelectedIndexChanged);
            p_ItemCode.Modified += new System.EventHandler(drpQItemCode_SelectedIndexChanged);

            p_ItemName.Leave -= new System.EventHandler(drpQItemName_SelectedIndexChanged);
            p_ItemName.Leave += new System.EventHandler(drpQItemName_SelectedIndexChanged);
            p_ItemName.Modified -= new System.EventHandler(drpQItemName_SelectedIndexChanged);
            p_ItemName.Modified += new System.EventHandler(drpQItemName_SelectedIndexChanged);

            p_ItemStd.Leave -= new System.EventHandler(drpQItemStd_SelectedIndexChanged);
            p_ItemStd.Leave += new System.EventHandler(drpQItemStd_SelectedIndexChanged);
            p_ItemStd.Modified -= new System.EventHandler(drpQItemStd_SelectedIndexChanged);
            p_ItemStd.Modified += new System.EventHandler(drpQItemStd_SelectedIndexChanged);


        }

        public void Release()
        {
            //m_ItemDisplay.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
            //m_ItemTxt.DoubleClick -= new System.EventHandler(drpItem_DoubleClick);
        }



        private void drpQItemCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string fieldNamePre = m_View.FocusedColumn.FieldName.Substring(0, 1);
                string itemcode = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "1"));
                string sql = "SELECT * FROM Data_Item WHERE ItemCode=" + SysString.ToDBString(itemcode);
                if (m_StrWhere != "")
                {
                    sql += m_StrWhere;
                }
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "2", dt.Rows[0]["ItemName"].ToString());//m_ItemFieldName[1]
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "3", dt.Rows[0]["ItemStd"].ToString());//m_ItemFieldName[2]                   
                }
                else
                {
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "2", "");
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "3", "");
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQItemName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string fieldNamePre = m_View.FocusedColumn.FieldName.Substring(0, 1);
                string itemcode = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "2"));
                string sql = "SELECT * FROM Data_Item WHERE ItemName=" + SysString.ToDBString(itemcode);
                if (m_StrWhere != "")
                {
                    sql += m_StrWhere;
                }
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "1", dt.Rows[0]["ItemCode"].ToString());//m_ItemFieldName[1]
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "3", dt.Rows[0]["ItemStd"].ToString());//m_ItemFieldName[2]                   
                }
                else
                {
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "1", "");
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "3", "");
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void drpQItemStd_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_FocusLabel.Focus();
                string fieldNamePre = m_View.FocusedColumn.FieldName.Substring(0, 1);
                string itemcode = SysConvert.ToString(m_View.GetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "3"));
                string sql = "SELECT * FROM Data_Item WHERE ItemStd=" + SysString.ToDBString(itemcode);
                if (m_StrWhere != "")
                {
                    sql += m_StrWhere;
                }
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {

                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "1", dt.Rows[0]["ItemCode"].ToString());//m_ItemFieldName[1]
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "2", dt.Rows[0]["ItemName"].ToString());//m_ItemFieldName[2]                   
                }
                else
                {
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "1", "");
                    m_View.SetRowCellValue(m_View.FocusedRowHandle, fieldNamePre + "2", "");
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    }



    #endregion

}
