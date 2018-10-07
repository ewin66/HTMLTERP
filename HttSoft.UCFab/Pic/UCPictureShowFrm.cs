using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;


namespace HttSoft.UCFab
{
    public partial class UCPictureShowFrm : Form
    {
        #region ȫ�ֱ���


        //private string m_HTDataID = string.Empty;
        //public string HTDataID
        //{
        //    get
        //    {
        //        return m_HTDataID;
        //    }
        //    set
        //    {
        //        m_HTDataID = value;
        //    }
        //}

        //private int m_PicIndex =0;
        //public int PicIndex
        //{
        //    get
        //    {
        //        return m_PicIndex;
        //    }
        //    set
        //    {
        //        m_PicIndex = value;
        //    }
        //}
        public Image img;

        #endregion



        #region ��������
        #region ��ʾ��Ϣ

        /// <summary>
        /// ��ʾ������ʾ��Ϣ
        /// </summary>
        /// <param name="p_Message">������Ϣ����</param>
        public void ShowMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// ��ʾ��ʾ��Ϣ
        /// </summary>
        /// <param name="p_Message">��ʾ��Ϣ����</param>
        public void ShowInfoMessage(string p_Message)
        {
            MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ��ʾȷ����Ϣ
        /// </summary>
        /// <param name="p_Message">ѯ����Ϣ</param>
        /// <returns></returns>
        public DialogResult ShowConfirmMessage(string p_Message)
        {
            return MessageBox.Show(p_Message, "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #endregion

        public UCPictureShowFrm()
        {
            InitializeComponent();
        }
        #region �����¼�
        private void frmStylePic_Load(object sender, EventArgs e)
        {
            try
            {
                BindPic();
            }
            catch (Exception E)
            {
                //this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ��ʾͼƬ
        /// </summary>
        /// <param name="p_Pic"></param>
        /// <param name="p_PictureTypeID"></param>
        private void BindPic()
        {
            picSample.Image = img;
        }

        #endregion


        #region �����¼�

        private void cmiDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image != null)
                {
                    saveFileDialog1.FileName = "pic.jpg";
                    saveFileDialog1.Title = "ͼƬ����";
                    if (saveFileDialog1.FileName != string.Empty && saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string outpath = saveFileDialog1.FileName;
                        System.IO.FileStream fs = new System.IO.FileStream(outpath, System.IO.FileMode.Create);
                        byte[] imageByte = UCTemplatePic.ImageToByte(picSample.Image);
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
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (picSample.Image != null)
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
        #endregion

        #region ͼƬ�����¼�

        Image saveStandImage = null;
        int saveZoomNum = 0;

        /// <summary>
        /// ͼƬ�Ŵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicBigger_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = picSample.Image;
                }
                if (saveZoomNum < 30)//���Ŵ�4��,�����£���ֹ���
                {
                    saveZoomNum++;
                }
                picSample.Image = UCTemplatePic.ZoomImage(saveStandImage, saveZoomNum * 0.1m + 1m);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ͼƬ��С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicSmaller_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = picSample.Image;
                }

                decimal zoonNum = saveZoomNum * 0.1m + 1m;
                if (zoonNum <= 0)
                {
                    return;
                }
                else
                {
                    saveZoomNum--;
                }
                picSample.Image = UCTemplatePic.ZoomImage(saveStandImage, zoonNum);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ԭʼͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicYuan_Click(object sender, EventArgs e)
        {
            try
            {
                if (picSample.Image == null)
                {
                    return;
                }
                if (saveStandImage == null)
                {
                    saveStandImage = picSample.Image;                    
                }
                saveZoomNum = 0;
                picSample.Image = saveStandImage;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}