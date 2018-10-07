using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HttSoft.Framework;
namespace HttSoft.UCFab
{

    /// <summary>
    /// 功能：图片编辑控件
    /// 作者：陈加海、朱小涛
    /// 日期：2014-4-2
    /// </summary>
    public partial class UCPictureInput : UCFabBase
    {
        public UCPictureInput()
        {
            InitializeComponent();
        }




        #region 属性


        #region 调用配置属性
        int m_UCInputMainType = 1;
        /// <summary>
        /// 控件输入主类型
        /// 1:包含和数据库关联模式
        /// 2:仅操作图片模式；和数据库交互由调用处执行
        /// </summary>
        public int UCInputMainType
        {
            get
            {
                return m_UCInputMainType;
            }
            set
            {
                m_UCInputMainType = value;
            }
        }


        bool m_UCInputPictureMultiFlag = true;
        /// <summary>
        /// 控件录入是多图模式/单图模式
        /// 如果是单图模式则大部分按钮隐藏
        /// </summary>
        public bool UCInputPictureMultiFlag
        {
            get
            {
                return m_UCInputPictureMultiFlag;
            }
            set
            {
                m_UCInputPictureMultiFlag = value;
            }
        }

        /// <summary>
        /// 控件数据存储类型
        /// 1:存储在同一数据表内
        /// 2:存储在额外独立的数据表内
        /// </summary>
        int m_UCInputDBSaveTypee = 1;
        /// <summary>
        /// 控件数据存储类型
        /// 1:存储在同一数据表内;      同一数据库原则上存储一张图片，如果是两张的放两个控件即可
        /// 2:存储在额外独立的数据表内
        /// </summary>
        public int UCInputDBSaveType
        {
            get
            {
                return m_UCInputDBSaveTypee;
            }
            set
            {
                m_UCInputDBSaveTypee = value;
            }
        }

        

        /// <summary>
        /// 控件只读状态
        /// 如果是true，表示不可编辑
        /// </summary>
        bool m_UCReadOnly = false;
        public bool UCReadOnly
        {
            get
            {
                return m_UCReadOnly;
            }
            set
            {
                m_UCReadOnly = value;
                IniUIReadOnly();
            }
        }
        #endregion

        #region 调用配置属性数据库相关
        /// <summary>
        /// 图片数据库链接索引
        /// 1/2/3:第一、第二、第三数据库
        /// </summary>
        private int m_UCDBConnIndex = 1;
        /// <summary>
        ///  图片数据库链接索引
        /// 1/2/3:第一、第二、第三数据库
        /// </summary>
        public int UCDBConnIndex
        {
            set { m_UCDBConnIndex = value; }
            get
            {
                return m_UCDBConnIndex;
            }
        }


        /// <summary>
        /// 图片保存表名
        /// </summary>
        private string m_UCDBTableName = "";

        /// <summary>
        /// 图片保存表名
        /// </summary>
        public string UCDBTableName
        {
            get { return m_UCDBTableName; }
            set { m_UCDBTableName = value; }
        }

        /// <summary>
        /// 图片保存字段名
        /// </summary>
        private string m_UCDBPicFieldName = "";
        /// <summary>
        /// 图片保存字段名
        /// </summary>
        public string UCDBPicFieldName
        {
            get { return m_UCDBPicFieldName; }
            set { m_UCDBPicFieldName = value; }
        }

        /// <summary>
        /// 小图片保存字段名
        /// </summary>
        private string m_UCDBSmallPicFieldName = "";
        /// <summary>
        /// 小图片保存字段名
        /// </summary>
        public string UCDBSmallPicFieldName
        {
            get { return m_UCDBSmallPicFieldName; }
            set { m_UCDBSmallPicFieldName = value; }
        }

        /// <summary>
        /// 图片描述字段名
        /// </summary>
        private string m_UCDBRemarkFieldName = "";
        /// <summary>
        /// 图片描述字段名
        /// </summary>
        public string UCDBRemarkFieldName
        {
            get { return m_UCDBRemarkFieldName; }
            set { m_UCDBRemarkFieldName = value; }
        }

        /// <summary>
        /// 图片款号字段
        /// 或存储其它关键检索字段
        /// </summary>
        private string m_UCDBStyleNoFieldName = "";

        /// <summary>
        /// 图片款号字段
        /// 或存储其它关键检索字段
        /// </summary>
        public string UCDBStyleNoFieldName
        {
            get { return m_UCDBStyleNoFieldName; }
            set { m_UCDBStyleNoFieldName = value; }
        }

        /// <summary>
        /// 单据ID字段名,不在同一数据库内使用
        /// </summary>
        private string m_UCDBMainIDFieldName = "MainID";

        /// <summary>
        /// 单据ID字段名,不在同一数据库内使用
        /// </summary>
        public string UCDBMainIDFieldName
        {
            get { return m_UCDBMainIDFieldName; }
            set { m_UCDBMainIDFieldName = value; }
        }
        #endregion

        #region 辅助UI属性

        /// <summary>
        /// 控件显示标题
        /// </summary>
        private string m_UCUITitle = "图片资料";
        /// <summary>
        /// 控件显示标题
        /// </summary>
        public string UCUITitle
        {
            set
            {
                m_UCUITitle = value;
                picGroup.Text = value;
            }
        }


        private Color m_UCUIBackColor;
        /// <summary>
        /// 控件背景色
        /// </summary>
        public Color UCUIBackColor
        {
            set
            {
                m_UCUIBackColor = value;
                picGroup.BackColor = value;
            }
            get 
            {
                return m_UCUIBackColor;
            }
        }


        /// <summary>
        /// 图片压缩后宽度
        /// </summary>
        int m_UCUIPicWidth = 500;
        /// <summary>
        /// 图片压缩后宽度
        /// </summary>
        public int UCUIPicWidth
        {
            get
            {
                return m_UCUIPicWidth;
            }
            set
            {
                m_UCUIPicWidth = value;
            }
        }

        /// <summary>
        /// 图片压缩后高度
        /// </summary>
        int m_UCUIPicHeight = 50;
        /// <summary>
        /// 图片压缩后高度
        /// </summary>
        public int UCUIPicHeight
        {
            get
            {
                return m_UCUIPicHeight;
            }
            set
            {
                m_UCUIPicHeight = value;
            }
        }

        /// <summary>
        /// 小图压缩后宽度
        /// </summary>
        int m_UCUISmallPicWidth = 50;
        /// <summary>
        /// 小图压缩后宽度
        /// </summary>
        public int UCUISmallPicWidth
        {
            get
            {
                return m_UCUISmallPicWidth;
            }
            set
            {
                m_UCUISmallPicWidth = value;
            }
        }

        /// <summary>
        /// 小图压缩后高度
        /// </summary>
        int m_UCUISmallPicHeight = 50;
        /// <summary>
        /// 小图压缩后高度
        /// </summary>
        public int UCUISmallPicHeight
        {
            get
            {
                return m_UCUISmallPicHeight;
            }
            set
            {
                m_UCUISmallPicHeight = value;
            }
        }
        #endregion

        #region 数据属性
        /// <summary>
        /// 单据数据ID
        /// </summary>
        private int m_UCDataID = 0;
        public int UCDataID
        {
            get
            {
                return m_UCDataID;
            }
            set
            {
                m_UCDataID = value;
            }
        }


        /// <summary>
        /// 单据数据 图片款号 或其它关键检索值
        /// </summary>
        private string m_UCDataStyleNo = "";

        /// <summary>
        /// 单据数据 图片款号 或其它关键检索值
        /// </summary>
        public string UCDataStyleNo
        {
            get { return m_UCDataStyleNo; }
            set { m_UCDataStyleNo = value; }
        }


        /// <summary>
        /// 大图图片
        /// </summary>
        List<Image> m_UCDataLstImage = new List<Image>();//
        /// <summary>
        ///大图图片
        /// </summary>
        public List<Image> UCDataLstImage
        {
            get
            {
                try
                {
                    if (UCInputMainType == 2)//图片直接操作模式
                    {
                        InsertDefaultOne();
                    }
                }
                catch (Exception E)
                {
                    this.ShowMessage(E.Message);
                }
                return m_UCDataLstImage;
            }
            set
            {
                m_UCDataLstImage = value;
                if (m_UCDataLstImage.Count > 0)
                {
                    LoadImage();
                }
            }
        }


        ///// <summary>
        ///// 大图图片数据
        ///// </summary>
        //List<byte[]> m_UCDataLstImageData = new List<byte[]>();//
        ///// <summary>
        /////大图图片数据
        ///// </summary>
        //public List<byte[]> UCDataLstImageData
        //{
        //    get
        //    {
        //        InsertDefaultOne();
        //        m_UCDataLstImageData.Clear();
        //        for (int i = 0; i < UCDataLstImage.Count; i++)
        //        {
        //            m_UCDataLstImageData.Add(UCTemplatePic.ImageToByte(UCDataLstImage[i]));
        //        }
        //        return m_UCDataLstImageData;
        //    }
        //    set
        //    {
        //        m_UCDataLstImageData = value;

        //        UCDataLstImage.Clear();
        //        for (int i = 0; i < m_UCDataLstImageData.Count; i++)
        //        {
        //            UCDataLstImage.Add(UCTemplatePic.ByteToImage(m_UCDataLstImageData[i]));
        //        }
        //    }
        //}

        /// <summary>
        ///小图数据
        /// </summary>
        List<Image> m_UCDataLstSmallImage = new List<Image>();//
        /// <summary>
        ///小图数据
        /// </summary>
        public List<Image> UCDataLstSmallImage
        {
            get
            {
                try
                {
                    if (m_UCDataLstSmallImage.Count != UCDataLstImage.Count)
                    {
                        m_UCDataLstSmallImage.Clear();

                        for (int i = 0; i < UCDataLstImage.Count; i++)
                        {
                            m_UCDataLstSmallImage.Add(UCTemplatePic.ZoomImage(UCDataLstImage[i], UCUISmallPicWidth, UCUISmallPicHeight));
                        }
                    }
                }
                catch (Exception E)
                {
                    this.ShowMessage(E.Message);
                }
                return m_UCDataLstSmallImage;
            }
            set
            {
                m_UCDataLstSmallImage = value;
            }
        }

        ///// <summary>
        ///// 小图图片数据
        ///// </summary>
        //List<byte[]> m_UCDataLstSmallImageData = new List<byte[]>();//
        ///// <summary>
        ///// 小图图片数据
        ///// </summary>
        //public List<byte[]> UCDataLstSmallImageData
        //{
        //    get
        //    {
        //        InsertDefaultOne();
        //        m_UCDataLstSmallImageData.Clear();
        //        for (int i = 0; i < UCDataLstSmallImage.Count; i++)
        //        {
        //            m_UCDataLstSmallImageData.Add(UCTemplatePic.ImageToByte(UCDataLstSmallImage[i]));
        //        }
        //        return m_UCDataLstSmallImageData;
        //    }
        //    set
        //    {
        //        m_UCDataLstSmallImageData = value;

        //        UCDataLstSmallImage.Clear();
        //        for (int i = 0; i < m_UCDataLstSmallImageData.Count; i++)
        //        {
        //            UCDataLstSmallImage.Add(UCTemplatePic.ByteToImage(m_UCDataLstSmallImageData[i]));
        //        }
        //    }
        //}

        #endregion


        

        //List<Image> lstImage = new List<Image>();//

        #endregion

        #region 全局变量
        /// <summary>
        /// 保存的ID数组
        /// </summary>
        List<int> saveIDs = new List<int>();
        /// <summary>
        /// 图片索引
        /// </summary>
        int saveImageIndex = -1;
        #endregion


        #region 自定义方法

        /// <summary>
        /// 校验数据录入是否符合规则
        /// </summary>
        /// <returns></returns>
        bool CheckCorrect()
        {
            if (UCDBTableName == string.Empty)
            {
                MessageBox.Show("初始化错误，没有图片表名");
                return false;
            }
            if (UCDBPicFieldName == string.Empty)
            {
                MessageBox.Show("初始化错误，没有图片字段");
                return false;
            }

            return true;
        }
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        private void SetButtonStatus()
        {
            if (saveImageIndex == 0)
            {
                btnPrev.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
            }

            if (m_UCDataLstImage.Count <= 1 || saveImageIndex == m_UCDataLstImage.Count - 1)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }

            lbShowIndex.Text = SysConvert.ToInt32(saveImageIndex + 1).ToString();
            lbTotalCount.Text = m_UCDataLstImage.Count.ToString();
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <returns>返回ID</returns>
        int  InsertImage()
        {
            int outI = 0;
            if (UCInputMainType == 1)//数据库交互模式
            {
                string sql = "";
                switch (UCInputDBSaveType)
                {
                    case 1://存储在同一张表内,依旧使用Update方法
                        sql = "UPDATE " + UCDBTableName + " SET " + UCDBPicFieldName + "=@" + UCDBPicFieldName;
                        if (UCDBSmallPicFieldName != string.Empty)
                        {
                            sql += "," + UCDBSmallPicFieldName + "=@" + UCDBSmallPicFieldName;
                        }
                        if (UCDBRemarkFieldName != string.Empty)
                        {
                            sql += "," + UCDBRemarkFieldName;
                            sql += "=" + SysString.ToDBString(txtRemark.Text.Trim());
                        }
                        if (UCDBMainIDFieldName != string.Empty)
                        {
                            sql += "," + UCDBMainIDFieldName + "=" + UCDataID;
                        }
                        if (UCDBStyleNoFieldName != string.Empty)
                        {
                            sql += "," + UCDBStyleNoFieldName + "=" + SysString.ToDBString(UCDataStyleNo);
                        }
                        sql += " WHERE ID=" + UCDataID;
                        outI = UCDataID;
                        break;
                    case 2://存储在独立的数据表内

                        sql = "SELECT MAX(ID) ID FROM " + UCDBTableName;
                        DataTable dt = PicFill(sql);
                        if (dt.Rows.Count != 0)
                        {
                            outI = SysConvert.ToInt32(dt.Rows[0]["ID"]) + 1;
                        }


                        sql = "INSERT INTO " + UCDBTableName + " (ID," + UCDBPicFieldName;
                        if (UCDBSmallPicFieldName != "")
                        {
                            sql += "," + UCDBSmallPicFieldName;
                        }
                        if (UCDBRemarkFieldName != string.Empty)
                        {
                            sql += "," + UCDBRemarkFieldName;
                        }
                        sql += "," + UCDBMainIDFieldName;
                        if (UCDBStyleNoFieldName != string.Empty)
                        {
                            sql += "," + UCDBStyleNoFieldName;
                        }
                        sql += ") VALUES(";
                        sql += outI.ToString()+",";//ID                        
                        sql += @"@" + UCDBPicFieldName;
                        if (UCDBSmallPicFieldName != "")
                        {
                            sql += "," + @"@" + UCDBSmallPicFieldName;
                        }
                        if (UCDBRemarkFieldName != string.Empty)
                        {
                            sql += "," + SysString.ToDBString(txtRemark.Text.Trim());
                        }
                        sql += "," + SysString.ToDBString(UCDataID.ToString());
                        if (UCDBStyleNoFieldName != string.Empty)
                        {
                            sql += "," + SysString.ToDBString(UCDataStyleNo);
                        }
                        sql += ")";
                        break;
                }
            
                int len = 1;
                if (UCDBSmallPicFieldName != string.Empty)
                {
                    len = 2;
                }
                object[,] obja = new object[2, len];
                obja[0, 0] = "@" + UCDBPicFieldName;
                obja[1, 0] = UCTemplatePic.ImageToByte(UCTemplatePic.ZoomImage(picShow.Image, UCUIPicWidth, UCUIPicHeight));
                if (UCDBSmallPicFieldName != string.Empty)
                {
                    obja[0, 1] = "@" + UCDBSmallPicFieldName;
                    obja[1, 1] = UCTemplatePic.ImageToByte(UCTemplatePic.ZoomImage(picShow.Image, UCUISmallPicWidth, UCUISmallPicHeight));
                }
                PicExecuteNonQuery(sql, obja);//SysUtils.ExecuteNonQuery
            }
            else if (UCInputMainType == 2)//仅是图片交互模式
            {
                //代码待补充
                m_UCDataLstImage.Add(UCTemplatePic.ZoomImage(picShow.Image, UCUIPicWidth, UCUIPicHeight));

                m_UCDataLstSmallImage.Add(UCTemplatePic.ZoomImage(picShow.Image, UCUISmallPicWidth, UCUISmallPicHeight));
            }

            return outI;
        }
        /// <summary>
        /// 修改图片
        /// </summary>
        void UpdateImage()
        {
            if (UCInputMainType == 1)//数据库交互模式
            {
                string sql = "";

                switch (UCInputDBSaveType)
                {
                    case 1://存储在同一张表内
                        sql = "UPDATE " + UCDBTableName + " SET " + UCDBPicFieldName + "=@" + UCDBPicFieldName;
                        if (UCDBSmallPicFieldName != string.Empty)
                        {
                            sql += "," + UCDBSmallPicFieldName + "=@" + UCDBSmallPicFieldName;
                        }
                        if (UCDBRemarkFieldName != string.Empty)
                        {
                            sql += "," + UCDBRemarkFieldName;
                            sql += "=" + SysString.ToDBString(txtRemark.Text.Trim());
                        }
                        if (UCDBMainIDFieldName != string.Empty)
                        {
                            sql += "," + UCDBMainIDFieldName + "=" + UCDataID;
                        }
                        if (UCDBStyleNoFieldName != string.Empty)
                        {
                            sql += "," + UCDBStyleNoFieldName + "=" + SysString.ToDBString(UCDataStyleNo);
                        }
                        sql += " WHERE ID=" + UCDataID;

                        break;
                    case 2://存储在独立的数据表内
                        sql = "UPDATE " + UCDBTableName + " SET " + UCDBPicFieldName + "=@" + UCDBPicFieldName;
                        if (UCDBSmallPicFieldName != string.Empty)
                        {
                            sql += "," + UCDBSmallPicFieldName + "=@" + UCDBSmallPicFieldName;
                        }
                        if (UCDBRemarkFieldName != string.Empty)
                        {
                            sql += "," + UCDBRemarkFieldName;
                            sql += "=" + SysString.ToDBString(txtRemark.Text.Trim());
                        }
                        if (UCDBMainIDFieldName != string.Empty)
                        {
                            sql += "," + UCDBMainIDFieldName + "=" + UCDataID;
                        }
                        if (UCDBStyleNoFieldName != string.Empty)
                        {
                            sql += "," + UCDBStyleNoFieldName + "=" + SysString.ToDBString(UCDataStyleNo);
                        }
                        sql += " WHERE ID=" + saveIDs[saveImageIndex];

                        break;
                }

                int len = 1;
                if (UCDBSmallPicFieldName != string.Empty)
                {
                    len = 2;
                }
                object[,] obja = new object[2, len];
                obja[0, 0] = "@" + UCDBPicFieldName;
                obja[1, 0] = UCTemplatePic.ImageToByte(UCTemplatePic.ZoomImage(picShow.Image, UCUIPicWidth, UCUIPicHeight));
                if (UCDBSmallPicFieldName != string.Empty)
                {
                    obja[0, 1] = "@" + UCDBSmallPicFieldName;
                    obja[1, 1] = UCTemplatePic.ImageToByte(UCTemplatePic.ZoomImage(picShow.Image, UCUISmallPicWidth, UCUISmallPicHeight));
                }
                PicExecuteNonQuery(sql, obja);//SysUtils.ExecuteNonQuery
            }
            else if (UCInputMainType == 2)//仅是图片交互模式
            {
                //代码待补充
                if (m_UCDataLstImage.Count > 0)
                {
                    if (m_UCDataLstImage.Count > saveImageIndex)
                    {
                        m_UCDataLstImage[saveImageIndex] = UCTemplatePic.ZoomImage(picShow.Image, UCUIPicWidth, UCUIPicHeight);
                    }
                    if (m_UCDataLstSmallImage.Count > saveImageIndex)
                    {
                        m_UCDataLstSmallImage[saveImageIndex] = UCTemplatePic.ZoomImage(picShow.Image, UCUISmallPicWidth, UCUISmallPicHeight);
                    }
                }
                else
                {
                    InsertImage();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="p_Sql"></param>
        /// <param name="obj"></param>
        private void PicExecuteNonQuery(string p_Sql, object[,] obj)
        {
            switch (UCDBConnIndex)
            {
                case 1:
                    SysUtils.ExecuteNonQuery(p_Sql, obj);
                    break;

                case 2:
                    SysUtilsSecond.ExecuteNonQuery(p_Sql, obj);
                    break;

                case 3:
                    SysUtilsThird.ExecuteNonQuery(p_Sql, obj);
                    break;

                case 4:
                    SysUtilsFourth.ExecuteNonQuery(p_Sql, obj);
                    break;
            }
        }
        /// <summary>
        /// 查询语句
        /// </summary>
        /// <param name="p_Sql"></param>
        /// <returns></returns>
        private DataTable PicFill(string p_Sql)
        {
            DataTable dt = new DataTable();
            switch (UCDBConnIndex)
            {
                case 1:
                    dt = SysUtils.Fill(p_Sql);
                    break;

                case 2:
                    dt = SysUtilsSecond.Fill(p_Sql);
                    break;

                case 3:
                    dt = SysUtilsThird.Fill(p_Sql);
                    break;

                case 4:
                    dt = SysUtilsFourth.Fill(p_Sql);
                    break;
            }

            return dt;
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        void LoadImage()
        {

           
            if (UCInputMainType == 1)//数据库交互模式
            {

                m_UCDataLstImage.Clear();
                if (UCDBSmallPicFieldName != string.Empty)
                {
                    m_UCDataLstSmallImage.Clear();
                }
                saveIDs.Clear();
                saveImageIndex = -1;
                picShow.Image = null;


                string sql = string.Empty;
                switch (UCInputDBSaveType)
                {
                    case 1://存储在同一张表内

                        sql = "SELECT ID," + UCDBPicFieldName;
                        if (UCDBSmallPicFieldName != string.Empty)
                        {
                            sql += "," + UCDBSmallPicFieldName;
                        }
                        if (UCDBRemarkFieldName != string.Empty)
                        {
                            sql += "," + UCDBRemarkFieldName;
                        }
                        sql += " FROM " + UCDBTableName + " WHERE ID=" + UCDataID;             
                        break;
                    case 2://存储在独立的数据表内
                        sql = "SELECT ID," + UCDBPicFieldName;
                        if (UCDBSmallPicFieldName != string.Empty)
                        {
                            sql += "," + UCDBSmallPicFieldName;
                        }
                        if (UCDBRemarkFieldName != string.Empty)
                        {
                            sql += "," + UCDBRemarkFieldName;
                        }
                        sql += " FROM " + UCDBTableName + " WHERE " + UCDBMainIDFieldName + "=" + UCDataID;
                
                        break;
                }


                if (sql != string.Empty)
                {
                    DataTable dt = PicFill(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        m_UCDataLstImage.Add(UCTemplatePic.ByteToImage(dr[UCDBPicFieldName] as byte[]));
                        if (UCDBSmallPicFieldName != string.Empty)
                        {
                            m_UCDataLstSmallImage.Add(UCTemplatePic.ByteToImage(dr[UCDBSmallPicFieldName] as byte[]));
                        }
                        saveIDs.Add(SysConvert.ToInt32(dr["ID"]));
                    }
                    if (dt.Rows.Count > 0)
                    {
                        saveImageIndex = 0;
                        picShow.Image = m_UCDataLstImage[saveImageIndex];
                    }
                    else
                    {
                        picShow.Image = null;
                    }
                }               
            }
            else if (UCInputMainType == 2)//仅是图片交互模式
            {
                picShow.Image = null;
                //代码待补充
                if (m_UCDataLstImage.Count > 0)
                {
                    saveImageIndex = 0;
                    picShow.Image = m_UCDataLstImage[saveImageIndex];
                }
            }

            SetButtonStatus();
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        bool DeleteImage(int p_DelIndex)
        {
            bool outb = false;

            if (UCInputMainType == 1)//数据库交互模式
            {
                if (saveIDs.Count > p_DelIndex)
                {
                    string sql = string.Empty;
                    switch (UCInputDBSaveType)
                    {
                        case 1://存储在同一张表内
                            sql = "UPDATE " + UCDBTableName + " SET ";
                            sql += "  " + UCDBPicFieldName + "=null";
                            if (UCDBSmallPicFieldName != string.Empty)
                            {
                                sql += "," + UCDBSmallPicFieldName + "=null";
                            }
                            if (UCDBRemarkFieldName != string.Empty)
                            {
                                sql += "," + UCDBRemarkFieldName + "=''";
                            }
                            sql += " WHERE ID=" + UCDataID;
                            break;
                        case 2://存储在独立的数据表内
                            sql = "DELETE FROM " + UCDBTableName + " WHERE ID=" + saveIDs[p_DelIndex];
                            break;
                    }


                    if (sql != string.Empty)
                    {
                        PicFill(sql);
                        outb = true;
                    }
                }
            }
            else if (UCInputMainType == 2)//仅是图片交互模式
            {
                //代码待补充
                if (m_UCDataLstImage.Count > 0)
                {
                    if (m_UCDataLstImage.Count > saveImageIndex)
                    {
                        m_UCDataLstImage.Remove(UCDataLstImage[saveImageIndex]);
                    }
                    if (m_UCDataLstSmallImage.Count > saveImageIndex)
                    {
                        m_UCDataLstSmallImage.Remove(UCDataLstSmallImage[saveImageIndex]);
                    }
                    outb = true;
                }
            }

            return outb;
        }

        /// <summary>
        /// 插入一条默认记录
        /// 一般用于图片取得默认图片用
        /// </summary>
        void InsertDefaultOne()
        {
            if (m_UCDataLstImage.Count == 0)
            {
                if (picShow.Image != null)
                {
                    btnInsert_Click(null,null);
                }
            }
        }
        #endregion

        #region 初始化方法
        /// <summary>
        /// 初始化UI
        /// </summary>
        public void UCAct()
        {
            try
            {
                IniUIReadOnly();
                IniUIInputMulti();
                LoadImage();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 只读属性设置
        /// </summary>
        void IniUIReadOnly()
        {
            btnBrowse.Enabled = !UCReadOnly;
            btnInsert.Enabled = !UCReadOnly;
            btnUpdate.Enabled = !UCReadOnly;
            btnDelete.Enabled = !UCReadOnly;
        }

        /// <summary>
        /// 录入单图/多图模式
        /// </summary>
        void IniUIInputMulti()
        {
           
            if (UCInputMainType == 1)//录入和数据库交互模式
            {
                if (UCInputPictureMultiFlag)//多图模式
                {
                }
                else//单图模式
                {
                    groupTopRight.Visible = false;
                    btnInsert.Visible = false;
                    btnUpdate.Text = "保存";
                    btnCam.Visible = true;
                }

            }
            else if (UCInputMainType == 2)//录入图片模式
            {
                if (UCInputPictureMultiFlag)//多图模式
                {
                }
                else//单图模式
                {
                    groupTopRight.Visible = false;
                    btnInsert.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Text = "清除";
                    btnCam.Visible = true;
                }

            }
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 控件加载事件
        /// 用不着
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCPictureInput_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {
            }
        }

        #endregion


        #region 按钮事件

        /// <summary>
        /// 图片浏览校验
        /// </summary>
        /// <returns></returns>
        bool CheckImageBrowse()
        {
            if (UCInputMainType == 1)//数据库操作模式
            {
                if (!CheckCorrect())
                {
                    return false;
                }
                if (UCDataID == 0)
                {
                    MessageBox.Show("请先保存单据数据");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 图片浏览保存
        /// </summary>
        /// <returns></returns>
        void ImageBrowseSave()
        {
            if (UCInputMainType == 2)
            {
                if (!UCInputPictureMultiFlag)
                {
                    btnUpdate_Click(null, null);
                }
            }
        }

        /// <summary>
        /// 浏览事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                if (!CheckImageBrowse())//校验图片浏览
                {
                    return;
                }
               

                openFileDialog.Filter = "JPG文件(*.jpg)|*.jpg|GIF文件(*.gif)|*.gif|BMP文件(*.bmp)|*.bmp|全部文件(*.*)|*.*";
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filenamerount = openFileDialog.FileName;
                    Image img = Image.FromFile(filenamerount);
                    FileInfo myFile = new FileInfo(filenamerount);
                    txtRemark.Text = myFile.Name.Split(new char[] { '.' }).Length > 0 ? myFile.Name.Split(new char[] { '.' })[0] : myFile.Name;
                    txtRemark.Tag = "";
                    picShow.Image = img;

                    ImageBrowseSave();//图片浏览保存
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (UCInputMainType == 1)//数据库交互模式
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    if (UCDataID == 0)
                    {
                        MessageBox.Show("请先保存单据数据");
                        return;
                    }
                }
                else if (UCInputMainType == 2)//仅是图片交互模式
                {
                }
                //保存新增
                int insertID = InsertImage();

                saveIDs.Add(insertID);

                if (UCInputMainType == 1)//数据库交互模式
                {
                    m_UCDataLstImage.Add(picShow.Image);
                }
                saveImageIndex++;

                SetButtonStatus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UCInputMainType == 1)//数据库交互模式
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                }
                UpdateImage();

                if (UCInputMainType == 1)//数据库交互模式
                {
                    //保存修改
                    if (saveImageIndex >= 0)
                    {
                        m_UCDataLstImage[saveImageIndex] = picShow.Image;
                    }
                    else
                    {
                        btnInsert_Click(null, null);
                    }
                }

                SetButtonStatus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
       



    
        /// <summary>
        /// 删除图片数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UCInputMainType == 1)//数据库交互模式
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    if (UCDataID == 0)
                    {
                        MessageBox.Show("请先保存单据数据");
                        return;
                    }
                }

                if (saveImageIndex >= 0)//有图片索引
                {

                    if (DialogResult.Yes != MessageBox.Show("是否删除此图片？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }

                    if (DeleteImage(saveImageIndex))//删除图片如果成功，重新加载
                    {
                        LoadImage();
                        SetButtonStatus();
                    }                    
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }




        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picShow_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (saveImageIndex >= 0)
                {
                    UCPictureShowFrm frm = new UCPictureShowFrm();
                    frm.img = UCDataLstImage[saveImageIndex];
                    //frm.PicIndex = listView1.FocusedItem.Index;
                    frm.ShowDialog();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
      
        /// <summary>
        /// 下一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCorrect())
                {
                    return;
                }
                if (saveImageIndex < UCDataLstImage.Count - 1)
                {
                    saveImageIndex++;
                    picShow.Image = UCDataLstImage[saveImageIndex];
                }
                SetButtonStatus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 上一张图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCorrect())
                {
                    return;
                }
                if (saveImageIndex > 0)
                {
                    saveImageIndex--;
                    picShow.Image = UCDataLstImage[saveImageIndex];
                }
                SetButtonStatus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #region 拍照的相关方法
        /// <summary>
        /// 拍照执行
        /// </summary>
        void JTAct()
        {
            try
            {
                JTActFindFrm();//寻找窗体
                JTActFrmMin();//最小化
                Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
                Graphics g = Graphics.FromImage(img);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
                UCScreenBody body = new UCScreenBody();
                body.BackgroundImage = img;
                body.ShowDialog();
                if (body.JQImage != null)
                {
                    picShow.Image = body.JQImage;
                    txtRemark.Text = "截图" + DateTime.Now.ToString("yyyy-MM-dd HH");
                }
            }
            catch
            {
            }
            finally
            {
                JTActFrmRestore();//恢复窗体
            }
        }
        int[] saveFrmWidth = new int[] { 0,0};
        int[] saveFrmHeight = new int[] { 0, 0 };
        Form[] saveFrm = new Form[] { };
        FormBorderStyle[] saveFrmBordStyle = new FormBorderStyle[] { FormBorderStyle.Sizable, FormBorderStyle.Sizable };
        FormWindowState[] saveFrmWinState = new FormWindowState[] { FormWindowState.Normal, FormWindowState.Normal };
        /// <summary>
        /// 获得Frm
        /// </summary>
        void JTActFindFrm()
        {
            if (saveFrm.Length == 0)//如果没有寻找过，寻找窗体
            {
                saveFrm = new Form[2];//设置两个的原因一个是本控件存在的窗体，一个是系统MDI窗体

                //寻找第一个窗体
                bool findFristFrm = false;
                bool findLastFrm = false;

                Control ctl = this;
                while (!findFristFrm)
                {
                    if (ctl.Parent != null)
                    {
                        ctl = ctl.Parent;
                        if (ctl is Form)
                        {
                            findFristFrm = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (findFristFrm)
                {
                    saveFrm[0] = (Form)ctl;
                }

                //寻找MDI窗体
                while (!findLastFrm)
                {
                    if (saveFrm[0].Owner != null)
                    {
                        ctl = saveFrm[0].Owner;
                    }
                    else
                    {
                        ctl = saveFrm[0];
                    }
                    if (((Form)ctl).MdiParent != null)
                    {
                        ctl = ((Form)ctl).MdiParent;
                        findLastFrm = true;
                    }
                    else//如果是null，没找到就空
                    {
                        break;
                    }
                }
                if (findLastFrm)
                {
                    saveFrm[1] = (Form)ctl;
                }
            }
        }
        /// <summary>
        /// 最小化
        /// </summary>
        void JTActFrmMin()
        {
            for (int i = 0; i < 2; i++)
            {
                if (saveFrm[i] != null)
                {
                    saveFrmWidth[i] = saveFrm[i].Width;
                    saveFrmHeight[i] = saveFrm[i].Height;
                    saveFrmBordStyle[i] = saveFrm[i].FormBorderStyle;
                    saveFrmWinState[i] = saveFrm[i].WindowState;

                    saveFrm[i].WindowState = FormWindowState.Normal;
                    saveFrm[i].Width = 0;
                    saveFrm[i].Height = 0;
                    saveFrm[i].FormBorderStyle = FormBorderStyle.None;
                }
            }
        }
        /// <summary>
        /// 恢复
        /// </summary>
        void JTActFrmRestore()
        {
            for (int i = 0; i < 2; i++)
            {
                if (saveFrm[i] != null)
                {

                    saveFrm[i].Width = saveFrmWidth[i];
                    saveFrm[i].Height = saveFrmHeight[i];
                    saveFrm[i].FormBorderStyle = saveFrmBordStyle[i];
                    saveFrm[i].WindowState = saveFrmWinState[i];
                }
            }
        }
        #endregion

        /// <summary>
        /// 拍照/更多操作按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCam_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckImageBrowse())//校验图片浏览
                {
                    return;
                }
               
                switch (btnCam.Text)
                {
                    case "拍照":
                        UCPictureVideoCamerFrm frmpz = new UCPictureVideoCamerFrm();
                        frmpz.ShowDialog();
                        if (frmpz.pzflag)
                        {
                            picShow.Image = UCTemplatePic.ZipImage(Image.FromFile(frmpz.pzfileName));
                            txtRemark.Text = "拍照" + DateTime.Now.ToString("yyyy-MM-dd HH");
                        }
                        break;
                    case "截图":
                        JTAct();
                        //Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
                        //Graphics g = Graphics.FromImage(img);
                        //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
                        //UCScreenBody body = new UCScreenBody();
                        //body.BackgroundImage = img;
                        //body.ShowDialog();
                        //if (body.JQImage != null)
                        //{
                        //    picShow.Image = body.JQImage;
                        //    txtRemark.Text = "截图" + DateTime.Now.ToString("yyyy-MM-dd HH");
                        //}
                        break;
                }

                ImageBrowseSave();//图片浏览保存
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region 更多按钮事件
        private void cmiMoreOPCam_Click(object sender, EventArgs e)
        {
            btnCam.Text = "拍照";
        }

        private void cmiMoreOPDrap_Click(object sender, EventArgs e)
        {
            btnCam.Text = "截图";
        }


        #endregion





    }
}
