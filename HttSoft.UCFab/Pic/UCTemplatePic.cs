using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.Framework;
using System.Drawing;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    class UCTemplatePic
    {

        private static string TemplateFileRoute = Application.StartupPath + @"\Templete\";//ģ���ļ�·��
        private static string TempFileRoute = Application.StartupPath + @"\Temp\";//������ʱ�ļ�·��

        #region �����ļ�����

        /// <summary>
        /// ��õ����ļ�����
        /// </summary>
        /// <param name="p_FilePre">�ļ�ǰ׺</param>
        /// <returns>�ļ�����(��·��)</returns>
        public static string GetTempFileName(string p_FilePre, string p_Exe)
        {
            string outstr = string.Empty;
            const int sindex = 10, eindex = 30, mindex = 21;//sindex=10,eindex=15,mindex=12;
            SysFile.CreateDDirectory(TempFileRoute);//û���ҵ��򴴽���ʱ�ļ���·��
            string FileName = string.Empty, DleteFileName = string.Empty;
            int i = 0;
            for (i = sindex; i < eindex; i++)
            {
                FileName = TempFileRoute + p_FilePre + i.ToString() + "." + p_Exe;
                if (!SysFile.CheckFileExit(FileName))//�ҵ�������
                {
                    break;
                }
            }
            if (i == mindex)//��������м��ߣ�ɾ���м��ߺ�����ļ�
            {
                for (int j = mindex + 1; j < eindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + "." + p_Exe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            if (i == eindex)//�������ĩβ��ɾ���м���ǰ����ļ�
            {
                for (int j = sindex; j <= mindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + "." + p_Exe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            outstr = FileName;
            return outstr;

        }

        #endregion

        #region �����ļ�
        public static string SaveImage(byte[] p_ImgData, string p_Exe)
        {
            string outstr = string.Empty;

            string filename = GetTempFileName("pic", p_Exe);//��ʱ�ļ�
            if (filename == "")
            {
                SysFile.WriteFrameworkLog("������ʱͼƬ����ʧ�ܣ������µ���");
                return outstr;
            }
            try
            {
                if (p_ImgData.Length != 0)//��ͼƬ����
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(p_ImgData);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    image.Save(filename);
                }
            }
            catch
            {
                return outstr;
            }
            return filename;
        }
        #endregion

        #region ѹ��ͼƬ
        /// <summary>
        /// ѹ��ͼƬ
        /// </summary>
        public static Image ZipImage(Image p_Img)
        {
            Image img = p_Img;
            Bitmap bmp = new Bitmap(p_Img);
            string fn = UCTemplatePic.GetTempFileName("SP", "1");
            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);
            Image tempimg = Image.FromFile(fn);
            if (((byte[])ImageToByte(p_Img)).Length >= ((byte[])ImageToByte(tempimg)).Length)//ȷ����С�˲��滻
            {
                img = tempimg;
            }
            return img;
        }

        /// <summary>
        /// ͼƬѹ�����̶��ߴ�
        /// </summary>
        /// <param name="p_Image">ͼƬ</param>
        /// <param name="p_MaxWidth">����</param>
        /// <param name="p_MaxHeight">����</param>
        /// <returns>ѹ����ͼƬ</returns>
        public static Image ZoomImage(Image p_Image, int p_MaxWidth, int p_MaxHeight)
        {
            decimal blw = SysConvert.ToDecimal(p_MaxWidth) / SysConvert.ToDecimal(p_Image.Width);
            decimal blh = SysConvert.ToDecimal(p_MaxHeight) / SysConvert.ToDecimal(p_Image.Height);

            decimal bl = 0m;//����
            if (blw <= blh)
            {
                bl = blw;
            }
            else
            {
                bl = blh;
            }
            if (bl > 1m)//�����������1�����Ϊ1����׼�Ŵ�ͼƬ
            {
                bl = 1;
            }

            if (bl == 1 || bl == 0)//���Ϊ1��0��ѹ����ֱ�ӷ���
            {
                return p_Image;
            }
            return ZoomImage(p_Image, bl);
        }

        /// <summary>
        /// ͼƬ������С
        /// </summary>
        /// <param name="p_Img"></param>
        /// <param name="p_Bigger"></param>
        /// <returns></returns>
        public static Image ZoomImage(Image p_Img, decimal bl)
        {
            Image img = ZoomPic(new Bitmap(p_Img), bl);
            return img;
        }

        /// <summary>  
        /// ����ͼƬ��С  
        /// </summary>  
        private static Bitmap ZoomPic(Bitmap objPic, decimal bl)
        {

            System.Drawing.Bitmap objNewPic;
            try
            {
                int wi = Convert.ToInt32(Decimal.Round(objPic.Width * bl, 0));
                int he = Convert.ToInt32(Decimal.Round(objPic.Height * bl, 0));
                objNewPic = new System.Drawing.Bitmap(objPic, wi, he);

            }
            catch (Exception exp) { throw exp; }
            finally
            {
                objPic = null;
            }
            return objNewPic;
        }
        #endregion

        #region ͼƬ�ֽ��໥ת��
        public static byte[] ImageToByte(Image img)
        {
            byte[] byt = null;
            ImageConverter imgCvt = new ImageConverter();
            object obj = imgCvt.ConvertTo(img, typeof(byte[]));
            byt = (byte[])obj;
            return byt;
        }

        //ByteToImage(byte[] byt),����DataReader�ڔ��������xȡbyte[]
        public static Image ByteToImage(byte[] bytImage)
        {
            Image img = null;
            if (bytImage == null || bytImage.Length < 100)
            {
                return img;
            }
            else
            {
                ImageConverter imgCvt = new ImageConverter();

                object obj = imgCvt.ConvertFrom(bytImage);
                img = (Image)obj;
                return img;
            }
        }
        #endregion
    }
}
