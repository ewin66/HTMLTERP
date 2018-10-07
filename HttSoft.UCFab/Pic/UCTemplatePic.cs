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

        private static string TemplateFileRoute = Application.StartupPath + @"\Templete\";//模板文件路径
        private static string TempFileRoute = Application.StartupPath + @"\Temp\";//导出临时文件路径

        #region 导出文件名称

        /// <summary>
        /// 获得导出文件名称
        /// </summary>
        /// <param name="p_FilePre">文件前缀</param>
        /// <returns>文件名称(含路径)</returns>
        public static string GetTempFileName(string p_FilePre, string p_Exe)
        {
            string outstr = string.Empty;
            const int sindex = 10, eindex = 30, mindex = 21;//sindex=10,eindex=15,mindex=12;
            SysFile.CreateDDirectory(TempFileRoute);//没有找到则创建临时文件夹路径
            string FileName = string.Empty, DleteFileName = string.Empty;
            int i = 0;
            for (i = sindex; i < eindex; i++)
            {
                FileName = TempFileRoute + p_FilePre + i.ToString() + "." + p_Exe;
                if (!SysFile.CheckFileExit(FileName))//找到则跳出
                {
                    break;
                }
            }
            if (i == mindex)//如果到了中间线，删除中间线后面的文件
            {
                for (int j = mindex + 1; j < eindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + "." + p_Exe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            if (i == eindex)//如果到了末尾，删除中间线前面的文件
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

        #region 保存文件
        public static string SaveImage(byte[] p_ImgData, string p_Exe)
        {
            string outstr = string.Empty;

            string filename = GetTempFileName("pic", p_Exe);//临时文件
            if (filename == "")
            {
                SysFile.WriteFrameworkLog("导出临时图片生成失败，请重新导出");
                return outstr;
            }
            try
            {
                if (p_ImgData.Length != 0)//有图片内容
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

        #region 压缩图片
        /// <summary>
        /// 压缩图片
        /// </summary>
        public static Image ZipImage(Image p_Img)
        {
            Image img = p_Img;
            Bitmap bmp = new Bitmap(p_Img);
            string fn = UCTemplatePic.GetTempFileName("SP", "1");
            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);
            Image tempimg = Image.FromFile(fn);
            if (((byte[])ImageToByte(p_Img)).Length >= ((byte[])ImageToByte(tempimg)).Length)//确定变小了才替换
            {
                img = tempimg;
            }
            return img;
        }

        /// <summary>
        /// 图片压缩至固定尺寸
        /// </summary>
        /// <param name="p_Image">图片</param>
        /// <param name="p_MaxWidth">最大宽</param>
        /// <param name="p_MaxHeight">最大高</param>
        /// <returns>压缩后图片</returns>
        public static Image ZoomImage(Image p_Image, int p_MaxWidth, int p_MaxHeight)
        {
            decimal blw = SysConvert.ToDecimal(p_MaxWidth) / SysConvert.ToDecimal(p_Image.Width);
            decimal blh = SysConvert.ToDecimal(p_MaxHeight) / SysConvert.ToDecimal(p_Image.Height);

            decimal bl = 0m;//比例
            if (blw <= blh)
            {
                bl = blw;
            }
            else
            {
                bl = blh;
            }
            if (bl > 1m)//如果比例大于1，最大为1，不准放大图片
            {
                bl = 1;
            }

            if (bl == 1 || bl == 0)//如果为1或0不压缩，直接返回
            {
                return p_Image;
            }
            return ZoomImage(p_Image, bl);
        }

        /// <summary>
        /// 图片缩放缩小
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
        /// 缩放图片缩小  
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

        #region 图片字节相互转换
        public static byte[] ImageToByte(Image img)
        {
            byte[] byt = null;
            ImageConverter imgCvt = new ImageConverter();
            object obj = imgCvt.ConvertTo(img, typeof(byte[]));
            byt = (byte[])obj;
            return byt;
        }

        //ByteToImage(byte[] byt),先用DataReader在數據庫中讀取byte[]
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
