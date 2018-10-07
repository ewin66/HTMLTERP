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
    /// ���ܣ�ͼƬ�鿴�ؼ�
    /// ���ߣ��¼Ӻ�����С��
    /// ���ڣ�2014-4-2
    /// </summary>
    public partial class UCPictureView : UCFabBase
    {
        public UCPictureView()
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
        private string m_UCDBMainIDFieldName = "";

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

        //ִ�й���ʼ����
        bool saveActFlag = false;//
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

       

        #endregion

        #region ��ʼ������
        /// <summary>
        /// ��ʼ��UI
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
                }

            }
        }
        #endregion

       


        #region ��ť�¼�

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
        #endregion

        #region �����¼�
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
                    saveFileDialog1.Title = "ͼƬ����";
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
                        ShowInfoMessage("�ļ����سɹ�");
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
