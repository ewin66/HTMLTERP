using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using HttSoft.Framework;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 文件上传控件
    /// </summary>
    public partial class UCFileUpLoad : UCFabBase
    {
        public UCFileUpLoad()
        {
            InitializeComponent();
        }


        #region 属性
        /// <summary>
        /// 窗体ID
        /// </summary>
        private int m_UCWinListID = 0;
        /// <summary>
        /// 窗体ID
        /// </summary>
        public int UCWinListID
        {
            get
            {
                return m_UCWinListID;
            }
            set
            {
                m_UCWinListID = value;
            }
        }


        /// <summary>
        /// 窗体ID(替代窗体ID ,便于后续一个数据会要求再多个窗体内显示)
        /// </summary>
        private int[] m_UCReplaceWinListID = new int[] { };
        /// <summary>
        /// 窗体ID
        /// </summary>
        public int[] UCReplaceWinListID
        {
            get
            {
                return m_UCReplaceWinListID;
            }
            set
            {
                m_UCReplaceWinListID = value;
            }
        }


        /// <summary>
        /// 窗体大类
        /// </summary>
        private int m_UCHeadType = 0;
        /// <summary>
        /// 窗体大类
        /// </summary>
        public int UCHeadType
        {
            get
            {
                return m_UCHeadType;
            }
            set
            {
                m_UCHeadType = value;
            }
        }

        /// <summary>
        /// 窗体小类
        /// </summary>
        private int m_UCSubType = 0;
        /// <summary>
        /// 窗体小类
        /// </summary>
        public int UCSubType
        {
            get
            {
                return m_UCSubType;
            }
            set
            {
                m_UCSubType = value;
            }
        }

        /// <summary>
        /// 窗体数据ID
        /// </summary>
        private int m_UCHTDateID = 0;
        /// <summary>
        /// 窗体数据ID
        /// </summary>
        public int UCHTDateID
        {
            get
            {
                return m_UCHTDateID;
            }
            set
            {
                m_UCHTDateID = value;
            }
        }


        /// <summary>
        /// 窗体数据Seq
        /// </summary>
        private int m_UCHTDateSeq = 0;
        /// <summary>
        /// 窗体数据Seq
        /// </summary>
        public int UCHTDateSeq
        {
            get
            {
                return m_UCHTDateSeq;
            }
            set
            {
                m_UCHTDateSeq = value;
            }
        }

        /// <summary>
        /// 参数一
        /// </summary>
        private string m_UCFileProt1 = "";
        /// <summary>
        /// 参数一 (存放窗体标题)
        /// </summary>
        public string UCFileProt1
        {
            get
            {
                return m_UCFileProt1;
            }
            set
            {
                m_UCFileProt1 = value;
            }
        }


        /// <summary>
        /// 参数二
        /// </summary>
        private string m_UCFileProt2 = "";
        /// <summary>
        /// 参数二 (存放窗体单号)
        /// </summary>
        public string UCFileProt2
        {
            get
            {
                return m_UCFileProt2;
            }
            set
            {
                m_UCFileProt2 = value;
            }
        }

        /// <summary>
        /// 上传人
        /// </summary>
        private string m_UCUploadOPID = "";
        /// <summary>
        /// 上传人
        /// </summary>
        public string UCUploadOPID
        {
            get
            {
                return m_UCUploadOPID;
            }
            set
            {
                m_UCUploadOPID = value;
            }
        }

        /// <summary>
        /// 上传人
        /// </summary>
        private string m_UCUploadOPName = "";
        /// <summary>
        /// 上传人
        /// </summary>
        public string UCUploadOPName
        {
            get
            {
                return m_UCUploadOPName;
            }
            set
            {
                m_UCUploadOPName = value;
            }
        }
        /// <summary>
        /// 上传人登陆ID
        /// </summary>
        private int m_UCLoginLogID = 0;
        /// <summary>
        /// 上传人登陆ID
        /// </summary>
        public int UCLoginLogID
        {
            get
            {
                return m_UCLoginLogID;
            }
            set
            {
                m_UCLoginLogID = value;
            }
        }


        /// <summary>
        /// 管理员标志
        /// </summary>
        private bool m_UCMangerFlag = false;
        /// <summary>
        /// 管理员标志
        /// </summary>
        public bool UCMangerFlag
        {
            get
            {
                return m_UCMangerFlag;
            }
            set
            {
                m_UCMangerFlag = value;
            }
        }

        #endregion

        #region 外部调用方法
        public void UCAct()
        {
            if (UCWinListID == 0 || UCHTDateID == 0)
            {
                this.ShowMessage("数据传入错误，不允许进行任何操作");
                btnDeleteFlie.Enabled = false;
                btnFileAdd.Enabled = false;
                btnFileUpdate.Enabled = false;
                btnLoadFile.Enabled = false;
                btnOpenFile.Enabled = false;
                return;
            }
            BindGrid();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 绑定数据明细
        /// </summary>
        public void BindGrid()
        {
            string conditonstr = string.Empty;
            conditonstr += " AND WinListID=" + UCWinListID;
            conditonstr += " AND HeadType=" + UCHeadType;
            conditonstr += " AND SubType=" + UCSubType;
            conditonstr += " AND HTDataID=" + UCHTDateID;

            string filedNameStr = string.Empty;
            filedNameStr = "ID,FileTitle,FileName,FileSize,UploadTime,UploadOPName,UploadOPID,FileExe,Remark";

            WinListAttachFileRule rule = new WinListAttachFileRule();
            DataTable dt = rule.RShow(conditonstr + " ORDER BY ID", filedNameStr);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// 文件删除校验
        /// </summary>
        /// <returns></returns>
        bool CheckCorrectDelete()
        {
            bool tempDeleteNoLimite = SysConvert.ToBoolean(UCFileUPParamSet.GetIntValueByID(7203));//文件管理的文件删除权限不做限制
            int tempDeleteHours = UCFileUPParamSet.GetIntValueByID(7204);//文件管理的文件删除限制在多少小时内，除非是管理员
            if (tempDeleteHours == 0)
            {
                tempDeleteHours = 24;//默认24小时
            }

            if (!tempDeleteNoLimite)//限制本人或管理员
            {
                if (!UCMangerFlag)//如果不是管理员
                {
                    if (SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UploadOPID")) != UCUploadOPID)
                    {
                        this.ShowMessage("上传人不是本人，不允许删除");
                        return false;
                    }
                }
            }

            if (tempDeleteHours > 0)//校验删除时效性
            {
                DateTime uploadTime = SysConvert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UploadTime"));
                TimeSpan ts = UCFileUPParamSet.ServerTime - uploadTime;
                if (ts.TotalHours > tempDeleteHours)
                {
                    this.ShowMessage("超过时效性("+tempDeleteHours+"小时)，不允许删除");
                    return false;
                }
            }
            return true;

        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 文件添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileAdd_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog2.Filter = "所有文件(*)|*";
                openFileDialog2.ShowDialog();
                if (openFileDialog2.FileName != string.Empty)
                {
                    string filenamerount = openFileDialog2.FileName;
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(filenamerount);
                    string fileExec = System.IO.Path.GetExtension(filenamerount);
                    decimal fileSize = WinListAttachFileRule.FileSize(filenamerount);
                    fileSize = SysConvert.ToDecimal(fileSize / 1024, 2);
                    int SysFileSize = 10 * 1024;//10M限制
                    if (fileSize > SysFileSize)
                    {
                        ShowMessage("文件上传大小不能超过" + SysFileSize + "KB");
                        return;
                    }
                    byte[] p_File = WinListAttachFileRule.ConvertToBinaryByPath(filenamerount);
                    WinListAttachFileRule rule = new WinListAttachFileRule();
                    rule.RAdd(p_File, UCWinListID, UCHeadType, UCSubType, UCHTDateID, UCHTDateSeq, fileName, "", fileExec, "", UCFileProt1, UCFileProt2, fileSize, UCUploadOPID, UCUploadOPName, UCLoginLogID);
                    BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 文件修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileUpdate_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 文件删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFlie_Click(object sender, EventArgs e)
        {
            try
            {
               

               
                if (saveFileID == 0)
                {
                    this.ShowMessage("没有文件");
                    return;
                }

                if (!CheckCorrectDelete())
                {
                    return;
                }
                if (DialogResult.Yes != ShowConfirmMessage("删除为不可恢复操作，确认删除"))
                {
                    return;
                }

                WinListAttachFileRule.DeleteFile(saveFileID);
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileID == 0)
                {
                    this.ShowMessage("没有文件");
                    return;
                }

                this.saveFileDialog2.Filter = "保存文件(*" + saveFileExe + ")|*" + saveFileExe;
                this.saveFileDialog2.FileName = saveFileName;
                if (this.saveFileDialog2.ShowDialog() == DialogResult.Cancel) return;
                System.IO.File.WriteAllBytes(saveFileDialog2.FileName, WinListAttachFileRule.ReadFileContext(saveFileID));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }

        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            FileStream fStream = null;
            try
            {

                string TemplateFileRoute = Application.StartupPath;//模板文件路径
                
                if (saveFileID == 0)
                {
                    this.ShowMessage("没有文件");
                    return;
                }

                string name = saveFileName + saveFileExe;
                byte[] file = null;
                if (Directory.Exists(TemplateFileRoute + "/Temp") == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(TemplateFileRoute + "/Temp");
                }
                string filePath = TemplateFileRoute + "\\Temp\\" + name;//文件路径
                string sql = " SELECT FileContext FROM Data_WinListAttachFile WHERE ID = " + saveFileID;
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count > 0)
                {
                    file = (byte[])dt.Rows[0]["FileContext"];
                }

                fStream = File.Create(filePath, file.Length);
                fStream.Write(file, 0, file.Length);//二进制转换成文件
                fStream.Close();
                System.Diagnostics.Process.Start(filePath);


            }
            catch //(Exception ex)
            {
            }
            finally
            {
                fStream.Close();
            }
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFileUpLoad_Load(object sender, EventArgs e)
        {
            try
            {
                IniUCPicture();

                new HttSoft.FrameFunc.ProUI().ProcUI(this);
                gridView1.RowCellStyle += new RowCellStyleEventHandler(_HTDataDts_RowCellStyle);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        #region 其它事件
        int saveFileID = 0;
        string saveFileName = string.Empty;
        string saveFileExe = string.Empty;
        /// <summary>
        /// 换行改变事件
        /// </summary>
        /// <param name="sender"></param>
        private void gridViewRowChanged3(object sender)
        {
            try
            {
                ColumnView view = sender as ColumnView;

                saveFileID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
                saveFileName = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "FileName"));
                saveFileExe = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "FileExe"));
                string tempExe = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "FileExe")).ToLower();
                
                if (tempExe == ".jpg" || tempExe == ".gif" || tempExe == ".bmp")//如果是图片
                {
                    bool autoshowPic = SysConvert.ToBoolean(UCFileUPParamSet.GetIntValueByID(7206));
                    if (autoshowPic)//自动显示图片
                    {
                        groupControlBRight.Visible = true;
                        PictureSet(saveFileID);
                    }
                    else
                    {
                        groupControlBRight.Visible = false;
                    }
                }
                else
                {
                    groupControlBRight.Visible = false;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            gridViewRowChanged3(sender);
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            gridViewRowChanged3(sender);
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            gridViewRowChanged3(sender);
        }

        /// <summary>
        /// 图片设置
        /// </summary>
        void PictureSet(int p_FileID)
        {
            if (groupControlBRight.Visible)//图片父控件可见
            {
                ucPictureView1.UCDataID = p_FileID;
                ucPictureView1.UCAct();
            }
        }

        /// <summary>
        /// 初始化图片控件
        /// </summary>
        void IniUCPicture()
        {
            ucPictureView1.UCReadOnly = true;
            ucPictureView1.UCInputPictureMultiFlag = false;//单图模式
            ucPictureView1.UCInputMainType = 1;//数据库模式
            ucPictureView1.UCInputDBSaveType = 1;//同一数据只有Update  

            ucPictureView1.UCDBMainIDFieldName = "";
            ucPictureView1.UCDBRemarkFieldName = "";
            ucPictureView1.UCDBTableName = "Data_WinListAttachFile";
            ucPictureView1.UCDBPicFieldName = "FileContext";
            ucPictureView1.UCDBSmallPicFieldName = "";
            ucPictureView1.UCDataID = 0;
            ucPictureView1.UCAct();
        }
        #endregion


        #region 数据表格样式
        /// <summary>
        /// 设置GridView不同行的颜色不同
        /// 虚方法的目的是便于界面重写单独的颜色变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void _HTDataDts_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.RowHandle % 2 == 0)
                    {
                        e.Appearance.BackColor = Color.AliceBlue;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
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
