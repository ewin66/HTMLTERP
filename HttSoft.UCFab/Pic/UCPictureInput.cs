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
    /// ���ܣ�ͼƬ�༭�ؼ�
    /// ���ߣ��¼Ӻ�����С��
    /// ���ڣ�2014-4-2
    /// </summary>
    public partial class UCPictureInput : UCFabBase
    {
        public UCPictureInput()
        {
            InitializeComponent();
        }




        #region ����


        #region ������������
        int m_UCInputMainType = 1;
        /// <summary>
        /// �ؼ�����������
        /// 1:���������ݿ����ģʽ
        /// 2:������ͼƬģʽ�������ݿ⽻���ɵ��ô�ִ��
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
        /// �ؼ�¼���Ƕ�ͼģʽ/��ͼģʽ
        /// ����ǵ�ͼģʽ��󲿷ְ�ť����
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
        /// �ؼ����ݴ洢����
        /// 1:�洢��ͬһ���ݱ���
        /// 2:�洢�ڶ�����������ݱ���
        /// </summary>
        int m_UCInputDBSaveTypee = 1;
        /// <summary>
        /// �ؼ����ݴ洢����
        /// 1:�洢��ͬһ���ݱ���;      ͬһ���ݿ�ԭ���ϴ洢һ��ͼƬ����������ŵķ������ؼ�����
        /// 2:�洢�ڶ�����������ݱ���
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
        /// �ؼ�ֻ��״̬
        /// �����true����ʾ���ɱ༭
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

        #region ���������������ݿ����
        /// <summary>
        /// ͼƬ���ݿ���������
        /// 1/2/3:��һ���ڶ����������ݿ�
        /// </summary>
        private int m_UCDBConnIndex = 1;
        /// <summary>
        ///  ͼƬ���ݿ���������
        /// 1/2/3:��һ���ڶ����������ݿ�
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
        /// ͼƬ�������
        /// </summary>
        private string m_UCDBTableName = "";

        /// <summary>
        /// ͼƬ�������
        /// </summary>
        public string UCDBTableName
        {
            get { return m_UCDBTableName; }
            set { m_UCDBTableName = value; }
        }

        /// <summary>
        /// ͼƬ�����ֶ���
        /// </summary>
        private string m_UCDBPicFieldName = "";
        /// <summary>
        /// ͼƬ�����ֶ���
        /// </summary>
        public string UCDBPicFieldName
        {
            get { return m_UCDBPicFieldName; }
            set { m_UCDBPicFieldName = value; }
        }

        /// <summary>
        /// СͼƬ�����ֶ���
        /// </summary>
        private string m_UCDBSmallPicFieldName = "";
        /// <summary>
        /// СͼƬ�����ֶ���
        /// </summary>
        public string UCDBSmallPicFieldName
        {
            get { return m_UCDBSmallPicFieldName; }
            set { m_UCDBSmallPicFieldName = value; }
        }

        /// <summary>
        /// ͼƬ�����ֶ���
        /// </summary>
        private string m_UCDBRemarkFieldName = "";
        /// <summary>
        /// ͼƬ�����ֶ���
        /// </summary>
        public string UCDBRemarkFieldName
        {
            get { return m_UCDBRemarkFieldName; }
            set { m_UCDBRemarkFieldName = value; }
        }

        /// <summary>
        /// ͼƬ����ֶ�
        /// ��洢�����ؼ������ֶ�
        /// </summary>
        private string m_UCDBStyleNoFieldName = "";

        /// <summary>
        /// ͼƬ����ֶ�
        /// ��洢�����ؼ������ֶ�
        /// </summary>
        public string UCDBStyleNoFieldName
        {
            get { return m_UCDBStyleNoFieldName; }
            set { m_UCDBStyleNoFieldName = value; }
        }

        /// <summary>
        /// ����ID�ֶ���,����ͬһ���ݿ���ʹ��
        /// </summary>
        private string m_UCDBMainIDFieldName = "MainID";

        /// <summary>
        /// ����ID�ֶ���,����ͬһ���ݿ���ʹ��
        /// </summary>
        public string UCDBMainIDFieldName
        {
            get { return m_UCDBMainIDFieldName; }
            set { m_UCDBMainIDFieldName = value; }
        }
        #endregion

        #region ����UI����

        /// <summary>
        /// �ؼ���ʾ����
        /// </summary>
        private string m_UCUITitle = "ͼƬ����";
        /// <summary>
        /// �ؼ���ʾ����
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
        /// �ؼ�����ɫ
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
        /// ͼƬѹ������
        /// </summary>
        int m_UCUIPicWidth = 500;
        /// <summary>
        /// ͼƬѹ������
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
        /// ͼƬѹ����߶�
        /// </summary>
        int m_UCUIPicHeight = 50;
        /// <summary>
        /// ͼƬѹ����߶�
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
        /// Сͼѹ������
        /// </summary>
        int m_UCUISmallPicWidth = 50;
        /// <summary>
        /// Сͼѹ������
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
        /// Сͼѹ����߶�
        /// </summary>
        int m_UCUISmallPicHeight = 50;
        /// <summary>
        /// Сͼѹ����߶�
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

        #region ��������
        /// <summary>
        /// ��������ID
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
        /// �������� ͼƬ��� �������ؼ�����ֵ
        /// </summary>
        private string m_UCDataStyleNo = "";

        /// <summary>
        /// �������� ͼƬ��� �������ؼ�����ֵ
        /// </summary>
        public string UCDataStyleNo
        {
            get { return m_UCDataStyleNo; }
            set { m_UCDataStyleNo = value; }
        }


        /// <summary>
        /// ��ͼͼƬ
        /// </summary>
        List<Image> m_UCDataLstImage = new List<Image>();//
        /// <summary>
        ///��ͼͼƬ
        /// </summary>
        public List<Image> UCDataLstImage
        {
            get
            {
                try
                {
                    if (UCInputMainType == 2)//ͼƬֱ�Ӳ���ģʽ
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
        ///// ��ͼͼƬ����
        ///// </summary>
        //List<byte[]> m_UCDataLstImageData = new List<byte[]>();//
        ///// <summary>
        /////��ͼͼƬ����
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
        ///Сͼ����
        /// </summary>
        List<Image> m_UCDataLstSmallImage = new List<Image>();//
        /// <summary>
        ///Сͼ����
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
        ///// СͼͼƬ����
        ///// </summary>
        //List<byte[]> m_UCDataLstSmallImageData = new List<byte[]>();//
        ///// <summary>
        ///// СͼͼƬ����
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

        #region ȫ�ֱ���
        /// <summary>
        /// �����ID����
        /// </summary>
        List<int> saveIDs = new List<int>();
        /// <summary>
        /// ͼƬ����
        /// </summary>
        int saveImageIndex = -1;
        #endregion


        #region �Զ��巽��

        /// <summary>
        /// У������¼���Ƿ���Ϲ���
        /// </summary>
        /// <returns></returns>
        bool CheckCorrect()
        {
            if (UCDBTableName == string.Empty)
            {
                MessageBox.Show("��ʼ������û��ͼƬ����");
                return false;
            }
            if (UCDBPicFieldName == string.Empty)
            {
                MessageBox.Show("��ʼ������û��ͼƬ�ֶ�");
                return false;
            }

            return true;
        }
        /// <summary>
        /// ���ð�ť״̬
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
        /// ����ͼƬ
        /// </summary>
        /// <returns>����ID</returns>
        int  InsertImage()
        {
            int outI = 0;
            if (UCInputMainType == 1)//���ݿ⽻��ģʽ
            {
                string sql = "";
                switch (UCInputDBSaveType)
                {
                    case 1://�洢��ͬһ�ű���,����ʹ��Update����
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
                    case 2://�洢�ڶ��������ݱ���

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
            else if (UCInputMainType == 2)//����ͼƬ����ģʽ
            {
                //���������
                m_UCDataLstImage.Add(UCTemplatePic.ZoomImage(picShow.Image, UCUIPicWidth, UCUIPicHeight));

                m_UCDataLstSmallImage.Add(UCTemplatePic.ZoomImage(picShow.Image, UCUISmallPicWidth, UCUISmallPicHeight));
            }

            return outI;
        }
        /// <summary>
        /// �޸�ͼƬ
        /// </summary>
        void UpdateImage()
        {
            if (UCInputMainType == 1)//���ݿ⽻��ģʽ
            {
                string sql = "";

                switch (UCInputDBSaveType)
                {
                    case 1://�洢��ͬһ�ű���
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
                    case 2://�洢�ڶ��������ݱ���
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
            else if (UCInputMainType == 2)//����ͼƬ����ģʽ
            {
                //���������
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
        /// ִ��SQL���
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
        /// ��ѯ���
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
        /// ����ͼƬ
        /// </summary>
        void LoadImage()
        {

           
            if (UCInputMainType == 1)//���ݿ⽻��ģʽ
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
                    case 1://�洢��ͬһ�ű���

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
                    case 2://�洢�ڶ��������ݱ���
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
            else if (UCInputMainType == 2)//����ͼƬ����ģʽ
            {
                picShow.Image = null;
                //���������
                if (m_UCDataLstImage.Count > 0)
                {
                    saveImageIndex = 0;
                    picShow.Image = m_UCDataLstImage[saveImageIndex];
                }
            }

            SetButtonStatus();
        }

        /// <summary>
        /// ɾ��ͼƬ
        /// </summary>
        bool DeleteImage(int p_DelIndex)
        {
            bool outb = false;

            if (UCInputMainType == 1)//���ݿ⽻��ģʽ
            {
                if (saveIDs.Count > p_DelIndex)
                {
                    string sql = string.Empty;
                    switch (UCInputDBSaveType)
                    {
                        case 1://�洢��ͬһ�ű���
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
                        case 2://�洢�ڶ��������ݱ���
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
            else if (UCInputMainType == 2)//����ͼƬ����ģʽ
            {
                //���������
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
        /// ����һ��Ĭ�ϼ�¼
        /// һ������ͼƬȡ��Ĭ��ͼƬ��
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

        #region ��ʼ������
        /// <summary>
        /// ��ʼ��UI
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
        /// ֻ����������
        /// </summary>
        void IniUIReadOnly()
        {
            btnBrowse.Enabled = !UCReadOnly;
            btnInsert.Enabled = !UCReadOnly;
            btnUpdate.Enabled = !UCReadOnly;
            btnDelete.Enabled = !UCReadOnly;
        }

        /// <summary>
        /// ¼�뵥ͼ/��ͼģʽ
        /// </summary>
        void IniUIInputMulti()
        {
           
            if (UCInputMainType == 1)//¼������ݿ⽻��ģʽ
            {
                if (UCInputPictureMultiFlag)//��ͼģʽ
                {
                }
                else//��ͼģʽ
                {
                    groupTopRight.Visible = false;
                    btnInsert.Visible = false;
                    btnUpdate.Text = "����";
                    btnCam.Visible = true;
                }

            }
            else if (UCInputMainType == 2)//¼��ͼƬģʽ
            {
                if (UCInputPictureMultiFlag)//��ͼģʽ
                {
                }
                else//��ͼģʽ
                {
                    groupTopRight.Visible = false;
                    btnInsert.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Text = "���";
                    btnCam.Visible = true;
                }

            }
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// �ؼ������¼�
        /// �ò���
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


        #region ��ť�¼�

        /// <summary>
        /// ͼƬ���У��
        /// </summary>
        /// <returns></returns>
        bool CheckImageBrowse()
        {
            if (UCInputMainType == 1)//���ݿ����ģʽ
            {
                if (!CheckCorrect())
                {
                    return false;
                }
                if (UCDataID == 0)
                {
                    MessageBox.Show("���ȱ��浥������");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ͼƬ�������
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
        /// ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                if (!CheckImageBrowse())//У��ͼƬ���
                {
                    return;
                }
               

                openFileDialog.Filter = "JPG�ļ�(*.jpg)|*.jpg|GIF�ļ�(*.gif)|*.gif|BMP�ļ�(*.bmp)|*.bmp|ȫ���ļ�(*.*)|*.*";
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filenamerount = openFileDialog.FileName;
                    Image img = Image.FromFile(filenamerount);
                    FileInfo myFile = new FileInfo(filenamerount);
                    txtRemark.Text = myFile.Name.Split(new char[] { '.' }).Length > 0 ? myFile.Name.Split(new char[] { '.' })[0] : myFile.Name;
                    txtRemark.Tag = "";
                    picShow.Image = img;

                    ImageBrowseSave();//ͼƬ�������
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (UCInputMainType == 1)//���ݿ⽻��ģʽ
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    if (UCDataID == 0)
                    {
                        MessageBox.Show("���ȱ��浥������");
                        return;
                    }
                }
                else if (UCInputMainType == 2)//����ͼƬ����ģʽ
                {
                }
                //��������
                int insertID = InsertImage();

                saveIDs.Add(insertID);

                if (UCInputMainType == 1)//���ݿ⽻��ģʽ
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
        /// �޸�ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UCInputMainType == 1)//���ݿ⽻��ģʽ
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                }
                UpdateImage();

                if (UCInputMainType == 1)//���ݿ⽻��ģʽ
                {
                    //�����޸�
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
        /// ɾ��ͼƬ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (UCInputMainType == 1)//���ݿ⽻��ģʽ
                {
                    if (!CheckCorrect())
                    {
                        return;
                    }
                    if (UCDataID == 0)
                    {
                        MessageBox.Show("���ȱ��浥������");
                        return;
                    }
                }

                if (saveImageIndex >= 0)//��ͼƬ����
                {

                    if (DialogResult.Yes != MessageBox.Show("�Ƿ�ɾ����ͼƬ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }

                    if (DeleteImage(saveImageIndex))//ɾ��ͼƬ����ɹ������¼���
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
        /// ��ʾͼƬ
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
        /// ��һ��ͼƬ
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
        /// ��һ��ͼƬ
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

        #region ���յ���ط���
        /// <summary>
        /// ����ִ��
        /// </summary>
        void JTAct()
        {
            try
            {
                JTActFindFrm();//Ѱ�Ҵ���
                JTActFrmMin();//��С��
                Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
                Graphics g = Graphics.FromImage(img);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
                UCScreenBody body = new UCScreenBody();
                body.BackgroundImage = img;
                body.ShowDialog();
                if (body.JQImage != null)
                {
                    picShow.Image = body.JQImage;
                    txtRemark.Text = "��ͼ" + DateTime.Now.ToString("yyyy-MM-dd HH");
                }
            }
            catch
            {
            }
            finally
            {
                JTActFrmRestore();//�ָ�����
            }
        }
        int[] saveFrmWidth = new int[] { 0,0};
        int[] saveFrmHeight = new int[] { 0, 0 };
        Form[] saveFrm = new Form[] { };
        FormBorderStyle[] saveFrmBordStyle = new FormBorderStyle[] { FormBorderStyle.Sizable, FormBorderStyle.Sizable };
        FormWindowState[] saveFrmWinState = new FormWindowState[] { FormWindowState.Normal, FormWindowState.Normal };
        /// <summary>
        /// ���Frm
        /// </summary>
        void JTActFindFrm()
        {
            if (saveFrm.Length == 0)//���û��Ѱ�ҹ���Ѱ�Ҵ���
            {
                saveFrm = new Form[2];//����������ԭ��һ���Ǳ��ؼ����ڵĴ��壬һ����ϵͳMDI����

                //Ѱ�ҵ�һ������
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

                //Ѱ��MDI����
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
                    else//�����null��û�ҵ��Ϳ�
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
        /// ��С��
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
        /// �ָ�
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
        /// ����/���������ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCam_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckImageBrowse())//У��ͼƬ���
                {
                    return;
                }
               
                switch (btnCam.Text)
                {
                    case "����":
                        UCPictureVideoCamerFrm frmpz = new UCPictureVideoCamerFrm();
                        frmpz.ShowDialog();
                        if (frmpz.pzflag)
                        {
                            picShow.Image = UCTemplatePic.ZipImage(Image.FromFile(frmpz.pzfileName));
                            txtRemark.Text = "����" + DateTime.Now.ToString("yyyy-MM-dd HH");
                        }
                        break;
                    case "��ͼ":
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
                        //    txtRemark.Text = "��ͼ" + DateTime.Now.ToString("yyyy-MM-dd HH");
                        //}
                        break;
                }

                ImageBrowseSave();//ͼƬ�������
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region ���ఴť�¼�
        private void cmiMoreOPCam_Click(object sender, EventArgs e)
        {
            btnCam.Text = "����";
        }

        private void cmiMoreOPDrap_Click(object sender, EventArgs e)
        {
            btnCam.Text = "��ͼ";
        }


        #endregion





    }
}
