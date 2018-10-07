using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：图片查看控件
    /// 作者：陈加海、朱小涛
    /// 日期：2014-4-2
    /// </summary>
    public partial class UCPictureView : UCFabBase
    {
        public UCPictureView()
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
        private string m_UCDBMainIDFieldName = "";

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
               
                return m_UCDataLstImage;
            }
            set
            {
                m_UCDataLstImage = value;
                if (saveActFlag)
                {
                    LoadImage();
                }
            }
        }


     

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

        //执行过初始化了
        bool saveActFlag = false;//
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

       

        #endregion

        #region 初始化方法
        /// <summary>
        /// 初始化UI
        /// </summary>
        public void UCAct()
        {
            try
            {
                IniUIInputMulti();
                LoadImage();
                saveActFlag = true;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
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
                }

            }
        }
        #endregion

       


        #region 按钮事件

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
        #endregion

        #region 其它事件
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (picShow.Image != null)
                {
                    cmiDownload.Enabled = true;
                }
                else
                {
                    cmiDownload.Enabled = false;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void cmiDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (picShow.Image != null)
                {
                    saveFileDialog1.FileName = "pic.jpg";
                    saveFileDialog1.Title = "图片下载";
                    if (saveFileDialog1.FileName != string.Empty && saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string outpath = saveFileDialog1.FileName;
                        System.IO.FileStream fs = new System.IO.FileStream(outpath, System.IO.FileMode.Create);
                        byte[] imageByte = UCTemplatePic.ImageToByte(picShow.Image);
                        for (int i = 0; i < imageByte.Length; i++)
                        {
                            fs.WriteByte(imageByte[i]);
                        }
                        fs.Close();
                        ShowInfoMessage("文件下载成功");
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

      


    }
}
