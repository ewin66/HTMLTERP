using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace HttSoft.WinUIBase
{
    /// <summary>
    /// 基本工具按钮页面
    /// </summary>
    public partial class frmAPBaseTool : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public frmAPBaseTool()
        {
            InitializeComponent();
        }

        #region 数据属性
        /// <summary>
        /// 恒泰数据ID
        /// </summary>
        private int _HTDataID = 0;
        /// <summary>
        /// 恒泰数据ID
        /// </summary>
        public int HTDataID
        {
            get
            {
                return _HTDataID;
            }
            set
            {
                _HTDataID = value;
            }
        }

        /// <summary>
        /// 恒泰数据单号
        /// </summary>
        private string _HTDataFormNo = string.Empty;
        /// <summary>
        /// 恒泰数据单号
        /// </summary>
        public string HTDataFormNo
        {
            get
            {
                return _HTDataFormNo;
            }
            set
            {
                _HTDataFormNo = value;
            }
        }

        /// <summary>
        /// 恒泰数据单据确认状态ID
        /// </summary>
        private int _HTDataSubmitFlag = 0;
        /// <summary>
        /// 恒泰数据单据确认状态ID
        /// </summary>
        public int HTDataSubmitFlag
        {
            get
            {
                return _HTDataSubmitFlag;
            }
            set
            {
                _HTDataSubmitFlag = value;
            }
        }

        /// <summary>
        /// 恒泰数据单据删除标志
        /// </summary>
        private int _HTDataDelFlag = 0;
        /// <summary>
        /// 恒泰数据单据删除标志
        /// </summary>
        public int HTDataDelFlag
        {
            get
            {
                return _HTDataDelFlag;
            }
            set
            {
                _HTDataDelFlag = value;
            }
        }

        /// <summary>
        /// 恒泰数据表名
        /// </summary>
        private string _HTDataTableName = string.Empty;
        /// <summary>
        /// 恒泰数据表名
        /// </summary>
        public string HTDataTableName
        {
            get
            {
                return _HTDataTableName;
            }
            set
            {
                if (this.FormID != 0)
                {
                    _HTDataTableName = value;
                }
            }
        }

        /// <summary>
        /// 恒泰单据操作状态
        /// </summary>
        private FormStatus _HTFormStatus = FormStatus.查询;
        /// <summary>
        /// 恒泰单据操作状态
        /// </summary>
        public FormStatus HTFormStatus
        {
            get
            {
                return _HTFormStatus;
            }
            set
            {
                _HTFormStatus = value;
            }
        }



        ///// <summary>
        ///// 权限继承窗体小类ID
        ///// </summary>
        //private int _HTRightFormListBID = 0;

        ///// <summary>
        ///// 权限继承窗体小类ID
        ///// </summary>
        //public int HTRightFormListBID
        //{
        //    get
        //    {

        //        return _HTRightFormListBID;
        //    }
        //    set
        //    {
        //        _HTRightFormListBID = value;
        //    }
        //}



        private DevComponents.DotNetBar.Bar _BaseToolBar;
        /// <summary>
        /// ToolBar
        /// </summary>
        public DevComponents.DotNetBar.Bar BaseToolBar
        {
            get
            {
                return _BaseToolBar;
            }
            set
            {
                _BaseToolBar = value;
            }
        }

        /// <summary>
        /// 恒泰删除标志字段名
        /// </summary>
        private string _HTDelFlagFieldName = "DelFlag";
        /// <summary>
        /// 恒泰删除标志字段名
        /// </summary>
        public string HTDelFlagFieldName
        {
            get
            {
                return _HTDelFlagFieldName;
            }
            set
            {
                if (this.FormID != 0)
                {
                    _HTDelFlagFieldName = value;
                }
            }
        }


        /// <summary>
        /// 恒泰提交标志字段名
        /// </summary>
        private string _HTSubmitFlagFieldName = "SubmitFlag";
        /// <summary>
        /// 恒泰提交标志字段名
        /// </summary>
        public string HTSubmitFlagFieldName
        {
            get
            {
                return _HTSubmitFlagFieldName;
            }
            set
            {
                if (this.FormID != 0)
                {
                    _HTSubmitFlagFieldName = value;
                }
            }
        }
        /// <summary>
        /// 恒泰审核日期字段名
        /// </summary>
        private string _HTAuditDateFieldName = "AuditTime";
        /// <summary>
        /// 恒泰审核日期字段名
        /// </summary>
        public string HTAuditDateFieldName
        {
            get
            {
                return _HTAuditDateFieldName;
            }
            set
            {
                if (this.FormID != 0)
                {
                    _HTAuditDateFieldName = value;
                }
            }
        }
        #endregion
    

        #region Bar按钮操作方法
        public DevComponents.DotNetBar.ButtonItem ToolBarItemGet(int p_Index, string p_Name)
        {
            return ProcessToolBar.ToolBarItemGet(_BaseToolBar, p_Index, p_Name);
        }
        /// <summary>
        /// Bar按钮属性修改
        /// </summary>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_Index">按钮序号</param>
        /// <param name="p_Name">按钮名称</param>
        /// <param name="p_Caption">按钮文字</param>
        /// <param name="p_Visible">可见</param>
        /// <param name="p_ImageIndex">图片序号</param>
        public void ToolBarItemSet(int p_Index, string p_Name, string p_Caption, bool p_Visible, int p_ImageIndex)
        {
            ProcessToolBar.ToolBarItemSet(_BaseToolBar, p_Index, p_Name, p_Caption, p_Visible, p_ImageIndex);
        }


        /// <summary>
        /// 增加一个按钮
        /// </summary>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_ImageIndex">图片序号</param>
        /// <param name="p_Name">按钮名称</param>
        /// <param name="p_Caption">按钮文字</param>
        /// <param name="p_ImageIndex">图片序号</param>
        public void ToolBarItemAdd(int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent)
        {
            ToolBarItemAdd(_BaseToolBar, -1, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent, eItemAlignment.Near);
        }

        /// <summary>
        /// 增加一个按钮
        /// </summary>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_ImageIndex">图片序号</param>
        /// <param name="p_Name">按钮名称</param>
        /// <param name="p_Caption">按钮文字</param>
        /// <param name="p_ImageIndex">图片序号</param>
        public void ToolBarItemAdd2(int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent)
        {
            ToolBarItemAdd(_BaseToolBar, -1, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent, eItemAlignment.Far);
        }



        /// <summary>
        /// 增加一个按钮
        /// </summary>
        /// <param name="p_PosIndex">增加位置：注意调用时必须在Form_Load中使用，否则装载出来显示有问题</param>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_Index">按钮序号</param>
        /// <param name="p_Name">按钮名称</param>
        /// <param name="p_Caption">按钮文字</param>
        /// <param name="p_ImageIndex">图片序号</param>
        public void ToolBarItemAdd(Bar p_Bar, int p_PosIndex, int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent, eItemAlignment p_ItemAlign)
        {
            ProcessToolBar.ToolBarItemAdd(p_PosIndex, p_Bar, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent, p_ItemAlign);          
        }


        /// <summary>
        /// 增加一个按钮(快捷方式)
        /// </summary>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_ImageIndex">图片序号</param>
        /// <param name="p_Name">按钮名称</param>
        /// <param name="p_Caption">按钮文字</param>
        /// <param name="p_ImageIndex">图片序号</param>
        public void ToolBarItemAdd(int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent, DevComponents.DotNetBar.eShortcut p_Shortcut)
        {
            ToolBarItemAdd(_BaseToolBar, -1, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent,eItemAlignment.Near, p_Shortcut);
        }

        /// <summary>
        /// 增加一个按钮(快捷方式)
        /// </summary>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_ImageIndex">图片序号</param>
        /// <param name="p_Name">按钮名称</param>
        /// <param name="p_Caption">按钮文字</param>
        /// <param name="p_ImageIndex">图片序号</param>
        public void ToolBarItemAdd2(int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent, DevComponents.DotNetBar.eShortcut p_Shortcut)
        {
            ToolBarItemAdd(_BaseToolBar, -1, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent, eItemAlignment.Far, p_Shortcut);
        }

        /// <summary>
        /// 增加一个按钮(快捷方式)
        /// </summary>
        /// <param name="p_PosIndex">增加位置：注意调用时必须在Form_Load中使用，否则装载出来显示有问题</param>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_Index">按钮序号</param>
        /// <param name="p_Name">按钮名称</param>
        /// <param name="p_Caption">按钮文字</param>
        /// <param name="p_ImageIndex">图片序号</param>
        public void ToolBarItemAdd(Bar p_Bar, int p_PosIndex, int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent,eItemAlignment p_ItemAlign, DevComponents.DotNetBar.eShortcut p_Shortcut)
        {
            ProcessToolBar.ToolBarItemAdd(p_PosIndex, p_Bar, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent, p_ItemAlign, p_Shortcut);
        }
        #endregion

        #region Bar Combox操作方法
        public DevComponents.DotNetBar.ComboBoxItem ToolBarCItemGet(int p_Index, string p_Name)
        {
            return ProcessToolBar.ToolBarCItemGet(_BaseToolBar, p_Index, p_Name);
        }


        /// <summary>
        /// 增加一个Combox
        /// </summary>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_Name">按钮名称</param>
        public void ToolBarCItemAdd( string p_Name, int p_Width)
        {
            ToolBarCItemAdd(-1,p_Name, p_Width);
        }

        /// <summary>
        /// 增加一个Combox
        /// </summary>
        /// <param name="p_PosIndex">增加位置：注意调用时必须在Form_Load中使用，否则装载出来显示有问题</param>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_Name">按钮名称</param>
        public void ToolBarCItemAdd(int p_PosIndex,  string p_Name, int p_Width)
        {
            if (p_PosIndex != -1)
            {
                ProcessToolBar.ToolBarCItemAdd(p_PosIndex,_BaseToolBar,p_Name, p_Width);
            }
            else
            {
                ProcessToolBar.ToolBarCItemAdd(_BaseToolBar, p_Name, p_Width);
            }
        }
        #endregion

        #region Bar Label操作方法
        public DevComponents.DotNetBar.LabelItem ToolBarLItemGet(int p_Index, string p_Name)
        {
            return ProcessToolBar.ToolBarLItemGet(_BaseToolBar, p_Index, p_Name);
        }


        /// <summary>
        /// 增加一个Combox
        /// </summary>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_Name">按钮名称</param>
        public void ToolBarLItemAdd(string p_Name, System.Drawing.Color p_Color)
        {
            ToolBarLItemAdd(-1, p_Name, p_Color);
        }

        /// <summary>
        /// 增加一个Combox
        /// </summary>
        /// <param name="p_PosIndex">增加位置：注意调用时必须在Form_Load中使用，否则装载出来显示有问题</param>
        /// <param name="_BaseToolBar">Bar</param>
        /// <param name="p_Name">按钮名称</param>
        public void ToolBarLItemAdd(int p_PosIndex, string p_Name, System.Drawing.Color p_Color)
        {
            if (p_PosIndex != -1)
            {
                ProcessToolBar.ToolBarLItemAdd(p_PosIndex, _BaseToolBar, p_Name, p_Color);
            }
            else
            {
                ProcessToolBar.ToolBarLItemAdd(_BaseToolBar, p_Name, p_Color);
            }
        }
        #endregion

        #region 调用按钮事件虚方法定义
        public virtual void btnQuery_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 更多查询
        /// </summary>
        public virtual void btnQueryAdvance_Click(object sender, EventArgs e)
        {
        }

        public virtual void btnBrowse_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 新增已存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnInsertExist_Click(object sender, EventArgs e)
        {
        }

        public virtual void btnInsert_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnUpdate_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnDelete_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnSave_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnCancel_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID,this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (_HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.提交))
                {
                    return;
                }

                HTSubmit(_HTDataTableName, _HTDataID.ToString());

                FCommon.AddDBLog(this.Text, FormStatus.提交.ToString(), "ID:" + _HTDataID, "");
                this.SetPosStatus(_HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 撤销提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnSubmitCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.提交2))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (_HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.撤消提交))
                {
                    return;
                }

                HTSubmitCancel(_HTDataTableName, _HTDataID.ToString());

                FCommon.AddDBLog(this.Text, FormStatus.撤消提交.ToString(), "ID:" + _HTDataID, "");
                this.SetPosStatus(_HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (_HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.审核通过))
                {
                    return;
                }

                HTAudit(_HTDataTableName, _HTDataID.ToString());

                FCommon.AddDBLog(this.Text, FormStatus.审核通过.ToString(), "ID:" + _HTDataID, "");
                this.SetPosStatus(_HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 审核拒绝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnAuditCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.审核1))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (_HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }
                if (!HTSubmitCheck(FormStatus.审核拒绝))
                {
                    return;
                }

                HTAuditCancel(_HTDataTableName, _HTDataID.ToString());

                FCommon.AddDBLog(this.Text, FormStatus.审核拒绝.ToString(), "ID:" + _HTDataID, "");
                this.SetPosStatus(_HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 取消单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnFormCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                if (DialogResult.Yes != this.ShowConfirmMessage("确定取消单据"))
                {
                    return;
                }

                if (!HTFormDelCheck(1))
                {
                    return;
                }

                HTFormDel(_HTDataTableName, _HTDataID.ToString());

                FCommon.AddDBLog(this.Text, "取消单据", "ID:" + HTDataID.ToString(), "");

                HTDataID = 0;
                SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 恢复单据
        /// </summary>
        public virtual void btnFormRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTDataID == 0)
                {
                    this.ShowMessage("请选择要操作的记录");
                    return;
                }

                if (DialogResult.Yes != this.ShowConfirmMessage("确定恢复单据"))
                {
                    return;
                }

                if (!HTFormDelCheck(0))
                {
                    return;
                }

                HTFormRes(_HTDataTableName, _HTDataID.ToString());
                FCommon.AddDBLog(this.Text, "恢复单据", "ID:" + HTDataID.ToString(), "");
                SetPosStatus(HTDataID);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        public virtual void btnFirst_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnPre_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnNext_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnLast_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnAddRow_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnDelRow_Click(object sender, EventArgs e)
        {
        }

        public virtual void btnMoveUp_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnMoveDown_Click(object sender, EventArgs e)
        {
        }

        public virtual void btnPreview_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnPrint_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnDesign_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnToExcel_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnLoad_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 文件管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                frmWinListAttachFile frm = new frmWinListAttachFile();
                frm.ImportForm = this;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.IniRefreshData();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ShowInfoMessage("帮助内容未定义");//+_BaseToolBar2.Height.ToString()
                frmAPBaseHelp frm = new frmAPBaseHelp();
                frm.HelpWinListID = this.FormID;
                frm.HelpHeadTypeID = this.FormListAID;
                frm.HelpSubTypeID = this.FormListBID;
                frm.HelpFormCaption = this.Text;
                frm.ShowDialog();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
      

      

        #endregion

        #region 自定义方法

        /// <summary>
        /// 转向目标页
        /// </summary>
        public void NavigateWinOth(string p_FormClassName, string p_ParentID, FormStatus p_MFormStatus)
        {
            NavigateWinOth(p_FormClassName, 0, 0, p_ParentID, p_MFormStatus);
        }
        
        /// <summary>
        /// 转向目标页
        /// </summary>
        public void NavigateWinOth(string p_FormClassName, int p_HeadTypeID, int p_SubTypeID, string p_ParentID, FormStatus p_MFormStatus)
        {
            NavigateWinOth(null, p_FormClassName, p_HeadTypeID, p_SubTypeID, p_ParentID, p_MFormStatus);
        }
        /// <summary>
        /// 转向目标页
        /// </summary>
        public void NavigateWinOth(ArrayList p_SourceObject, string p_FormClassName, int p_HeadTypeID, int p_SubTypeID, string p_ParentID, FormStatus p_MFormStatus)
        {
            string tempFormName = p_FormClassName;
            if (p_FormClassName.Length > 4)//编辑页面调用父页面
            {
                if (p_FormClassName.Substring(p_FormClassName.Length - 4) == "Edit")
                {
                    tempFormName = p_FormClassName.Substring(0, p_FormClassName.Length - 4);
                }
            }
            string sql = "SELECT SubmitFlag,AuditFlag  FROM Sys_WindowMenu A,Enum_WinList B WHERE A.WinListID=B.ID AND B.ClassName =" + SysString.ToDBString(tempFormName);
            sql += " AND HeadTypeID=" + SysString.ToDBString(p_HeadTypeID);
            sql += " AND SubTypeID=" + SysString.ToDBString(p_SubTypeID);
            DataTable dt = SysUtils.Fill(sql);
            bool tempSubmitFlag = false;
            bool tempAuditFlag = false;
            if (dt.Rows.Count != 0)
            {
                if (SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"]) == 1)
                {
                    tempSubmitFlag = true;
                }
                if (SysConvert.ToInt32(dt.Rows[0]["AuditFlag"]) == 1)
                {
                    tempAuditFlag = true;
                }
            }

            MDIForm.ContextMenuOpenForm(p_SourceObject, p_FormClassName, p_HeadTypeID, p_SubTypeID, tempSubmitFlag, tempAuditFlag, p_ParentID, p_MFormStatus);
        }

        /// <summary>
        /// 获得窗体标题名称
        /// </summary>
        /// <param name="p_FormClassName">类名</param>
        /// <returns>标题</returns>
        public string HTGetFormCaption(string p_FormClassName)
        {
            string outstr = string.Empty;
            string sql = "SELECT B.Name FormName,A.Name MenuName  FROM Sys_WindowMenu A,Enum_WinList B WHERE A.WinListID=B.ID AND B.ClassName =" + SysString.ToDBString(p_FormClassName);
            sql += " AND HeadTypeID=" + SysString.ToDBString(this.FormListAID);
            sql += " AND SubTypeID=" + SysString.ToDBString(this.FormListBID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["MenuName"].ToString() != string.Empty)
                {
                    outstr = dt.Rows[0]["MenuName"].ToString();
                }
                else
                {
                    outstr = dt.Rows[0]["FormName"].ToString();
                }
            }
            return outstr;
        }
        #endregion

        #region 其它调用虚方法定义
        /// <summary>
        /// 初始化刷新数据(窗体加载时或用户刷新按钮时调用)
        /// </summary>
        public virtual void IniRefreshData()
        {
        }

        /// <summary>
        ///  虚方法：初始化控件
        /// </summary>
        public virtual void ToolIniCreateBar()
        {
        }

        /// <summary>
        ///  虚方法：初始化控件(解决后续加载按钮跑到最后面)
        /// </summary>
        public virtual void ToolIniCreateBar2()
        {
            this.ToolBarItemAdd2(35, ToolButtonName.btnHelp.ToString(), "帮助", false, btnHelp_Click, eShortcut.F11);
        }

        /// <summary>
        /// 设置单据翻页
        /// </summary>
        /// <param name="p_IDValue"></param>
        public virtual void SetPosStatus(int p_IDValue)
        {
        }

        /// <summary>
        /// 设置Tab键顺序，可以重写不调用
        /// </summary>
        public virtual void ProcSortTabIndex()
        {
            //ProcessCtl.ProcSortTabIndex(this);
        }



        /// <summary>
        /// 设置文件按钮的文件数
        /// </summary>
        public virtual void FileSetButtonFileNumber()
        {
            if (SysConvert.ToBoolean(WinUIParamSet.GetIntValueByID(7205)))//文件在按钮显示单据有几个文件
            {
                int num=HttSoft.UCFab.UCFileUPParamSet.GetFileNumber(this.FormID, this.FormListAID, this.FormListBID, this.HTDataID);
                string btnName = "文件";
                if (num != 0)
                {
                    btnName += "("+num+")";
                }
                ProcessToolBar.ToolBarItemGet(barTool, -1, "btnFile").Text = btnName;
                if (num != 0)
                {
                    ProcessToolBar.ToolBarItemGet(barTool, -1, "btnFile").ForeColor = Color.Red;
                }
                else
                {
                    ProcessToolBar.ToolBarItemGet(barTool, -1, "btnFile").ForeColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// 数据删除时执行文件删除
        /// </summary>
        public virtual void FileDeleteDataFile()
        {
            HttSoft.UCFab.UCFileUPParamSet.DeleteFileByDataID(this.FormID, this.FormListAID, this.FormListBID, this.HTDataID);
        }
        #endregion


        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAPBaseTool_Load(object sender, EventArgs e)
        {
            try
            {
                if (FormID != 0)
                {
                    _BaseToolBar = barTool;
                    ToolIniCreateBar();
                    
                }
                //this.SizeChanged += new EventHandler(Form_SizeChanged);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }



        private void Form_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.ControlBox = false;
                }
                else
                {
                    this.ControlBox = true;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region 提交、撤销提交、审核、审核拒绝
        /// <summary>
        /// 提交、撤销提交、审核、审核拒绝、修改、删除校验
        /// </summary>
        /// <returns></returns>
        protected bool HTSubmitCheck(FormStatus p_OPStatus)
        {
            if (_HTSubmitFlagFieldName == "" || _HTDelFlagFieldName=="")//如果没有提交字段，则自动判定为允许操作
            {
                return true;
            }
            string sql = "SELECT " + _HTSubmitFlagFieldName + "," + _HTDelFlagFieldName + " FROM " + _HTDataTableName + " WHERE ID=" + SysString.ToDBString(_HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count != 0)
            {
                int tempSubmitFlag = SysConvert.ToInt32(dt.Rows[0][_HTSubmitFlagFieldName]);
                int tempDelFlag = SysConvert.ToInt32(dt.Rows[0][_HTDelFlagFieldName]);
                if (tempDelFlag != 1)
                {
                    switch (p_OPStatus)
                    {
                        case FormStatus.提交:
                            if (tempSubmitFlag != (int)ConfirmFlag.未提交)
                            {
                                this.ShowMessage("不能操作,当前单据状态不是未提交");
                                return false;
                            }
                            break;
                        case FormStatus.撤消提交:
                            if (this.AuditFlag)//需要审核
                            {
                                if (!(tempSubmitFlag == (int)ConfirmFlag.已提交 || tempSubmitFlag == (int)ConfirmFlag.审核拒绝))
                                {
                                    this.ShowMessage("不能操作,当前单据状态不是已提交");
                                    return false;
                                }
                            }
                            else//不需要审核
                            {
                                if (tempSubmitFlag != (int)ConfirmFlag.审核通过)
                                {
                                    this.ShowMessage("不能操作,当前单据状态不是已提交");
                                    return false;
                                }
                            }
                            break;
                        case FormStatus.审核通过:
                            if (!(tempSubmitFlag == (int)ConfirmFlag.已提交 || tempSubmitFlag == (int)ConfirmFlag.审核拒绝))
                            {
                                this.ShowMessage("不能操作,当前单据状态不是已提交或审核拒绝");
                                return false;
                            }
                            break;
                        case FormStatus.审核拒绝:
                            if (!(tempSubmitFlag == (int)ConfirmFlag.已提交 || tempSubmitFlag == (int)ConfirmFlag.审核通过))
                            {
                                this.ShowMessage("不能操作,当前单据状态不是已提交或审核通过");
                                return false;
                            }
                            break;
                        case FormStatus.修改:
                            if (this.AuditFlag || this.SubmitFlag)//需要审核或者提交
                            {
                                if (tempSubmitFlag == (int)ConfirmFlag.已提交 || tempSubmitFlag == (int)ConfirmFlag.审核通过)
                                {
                                    this.ShowMessage("不能操作,当前单据状态处于提交或者审核状态");
                                    return false;
                                }
                            }
                            break;
                        case FormStatus.删除:
                            if (this.AuditFlag || this.SubmitFlag)//需要审核或者提交
                            {
                                if (tempSubmitFlag == (int)ConfirmFlag.已提交 || tempSubmitFlag == (int)ConfirmFlag.审核通过)
                                {
                                    this.ShowMessage("不能操作,当前单据状态处于提交或者审核状态");
                                    return false;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    this.ShowMessage("不能操作,当前单据已取消");
                    return false;
                }
            }
            else
            {
                this.ShowMessage("不能操作,没有找到单据");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTSubmit(string p_TableName, string p_IDValue)
        {
            HTSubmit(p_TableName, "ID",  p_IDValue);
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTSubmit(string p_TableName, string p_IDField, string p_IDValue)
        {
            int status = -1;
            if (this.AuditFlag)//需要审核
            {
                status = (int)ConfirmFlag.已提交;//状态修改为提交
            }
            else//不需要审核
            {
                status = (int)ConfirmFlag.审核通过;//状态修改为审核通过
            }

            string sql = "UPDATE " + p_TableName + " SET " + _HTSubmitFlagFieldName + "=" + SysString.ToDBString(status) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
            SysUtils.ExecuteNonQuery(sql);
        }



        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTSubmitCancel(string p_TableName, string p_IDValue)
        {
            HTSubmitCancel(p_TableName, "ID",  p_IDValue);
        }

       
        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTSubmitCancel(string p_TableName, string p_IDField, string p_IDValue)
        {

            int status = (int)ConfirmFlag.未提交;//状态修改为未提交
            string sql = "UPDATE " + p_TableName + " SET " + _HTSubmitFlagFieldName + "=" + SysString.ToDBString(status) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
            SysUtils.ExecuteNonQuery(sql);
        }


        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTAudit(string p_TableName, string p_IDValue)
        {
            HTAudit(p_TableName, "ID", p_IDValue);
        }


        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTAudit(string p_TableName, string p_IDField, string p_IDValue)
        {
            int status = (int)ConfirmFlag.审核通过;//状态修改为审核通过
            string sql = "UPDATE " + p_TableName + " SET " + _HTSubmitFlagFieldName + "=" + SysString.ToDBString(status);
            sql += "," + _HTAuditDateFieldName + "=" + SysString.ToDBString(DateTime.Now) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
            SysUtils.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 审核拒绝
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTAuditCancel(string p_TableName, string p_IDValue)
        {
            HTAuditCancel(p_TableName, "ID", p_IDValue);
        }

        /// <summary>
        /// 审核拒绝
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_IDValue">ID值</param>
        private void HTAuditCancel(string p_TableName, string p_IDField, string p_IDValue)
        {
            int status = (int)ConfirmFlag.审核拒绝;//状态修改为审核拒绝
            string sql = "UPDATE " + p_TableName + " SET " + _HTSubmitFlagFieldName + "=" + SysString.ToDBString(status) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
            SysUtils.ExecuteNonQuery(sql);
        }
        #endregion

        
        #region 单据取消、单据恢复

        /// <summary>
        /// 取消单据、恢复单据、校验
        /// </summary>
        /// <param name="p_OPType">0/1:恢复/删除</param>
        /// <returns></returns>
        private bool HTFormDelCheck(int p_OPType)
        {
            string sql = "SELECT " + _HTSubmitFlagFieldName + "," + _HTDelFlagFieldName + " FROM " + _HTDataTableName + " WHERE ID=" + SysString.ToDBString(_HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            int tempSubmitFlag = SysConvert.ToInt32(dt.Rows[0][_HTSubmitFlagFieldName]);
            int tempDelFlag = SysConvert.ToInt32(dt.Rows[0][_HTDelFlagFieldName]);
            if (dt.Rows.Count != 0)
            {
                if (p_OPType == 1)//取消
                {
                    if (tempDelFlag == 1)//数据已取消
                    {
                        this.ShowMessage("不能操作,当前单据已取消");
                        return false;
                    }
                    else//数据未取消
                    {
                        if (tempSubmitFlag == (int)ConfirmFlag.已提交 || tempSubmitFlag == (int)ConfirmFlag.审核通过)
                        {
                            this.ShowMessage("不能操作,当前单据已提交或者已审核通过");
                            return false;
                        }
                    }
                }
                else//恢复
                {
                    if (tempDelFlag == 0)//数据已恢复
                    {
                        this.ShowMessage("不能操作,当前单据已恢复");
                        return false;
                    }
                }
            }
            else
            {
                this.ShowMessage("不能操作,没有找到单据");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 撤消
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_ID">ID值</param>
        private void HTFormDel(string p_TableName, string p_IDValue)
        {
            HTFormDel(p_TableName, "ID", p_IDValue);
        }

        /// <summary>
        /// 撤消
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_ID">ID值</param>
        private void HTFormDel(string p_TableName, string p_IDField, string p_IDValue)
        {
            string sql = "UPDATE " + p_TableName + " SET " + _HTDelFlagFieldName + "=1 WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);//删除标志修改为删除
            SysUtils.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_ID">ID值</param>
        private void HTFormRes(string p_TableName, string p_IDValue)
        {
            HTFormRes(p_TableName, "ID", p_IDValue);
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_ID">ID值</param>
        private void HTFormRes(string p_TableName, string p_IDField, string p_IDValue)
        {
            string sql = "UPDATE " + p_TableName + " SET " + _HTDelFlagFieldName + "=0 WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);//删除标志修改为正常
            SysUtils.ExecuteNonQuery(sql);
        }
        #endregion


        #region 表单数据通用方法
        /// <summary>
        /// 获取新增单据时Submit状态
        /// </summary>
        /// <returns></returns>
        public int HTSubmitFlagInsertGet()
        {
            if (AuditFlag)//需要审核
            {
                return (int)ConfirmFlag.未提交;
            }
            else//不需要审核
            {
                if (SubmitFlag)//需要提交
                {
                    return (int)ConfirmFlag.未提交;
                }
                else//不需要提交
                {
                    return (int)ConfirmFlag.审核通过;
                }
            }
        }

        /// <summary>
        /// 获取更新单据时Submit状态
        /// </summary>
        /// <returns></returns>
        public int HTSubmitFlagUpdateGet()
        {
            if (_HTDataSubmitFlag==(int)ConfirmFlag.审核拒绝)//需要审核
            {
                return (int)ConfirmFlag.未提交;
            }
            return _HTDataSubmitFlag;
        }

        /// <summary>
        /// 获取更新单据时Submit状态文字描述
        /// </summary>
        /// <returns></returns>
        private string HTSubmitFlagTextGet()
        {
            string outstr = string.Empty;
            switch (HTDataSubmitFlag)
            {
                case (int)ConfirmFlag.未提交:
                    if (this.SubmitFlag)
                    {
                        outstr = "未提交";
                    }
                    else
                    {
                        outstr = "已提交";
                    }
                    break;
                case (int)ConfirmFlag.已提交:
                    outstr = "已提交";
                    break;
                case (int)ConfirmFlag.审核通过:
                    if (AuditFlag)
                    {
                        outstr = "审核通过";
                    }
                    else
                    {
                        outstr = "已提交";
                    }
                    break;
                case (int)ConfirmFlag.审核拒绝:
                    outstr = "审核拒绝";
                    break;
            }
            return outstr;

        }
        /// <summary>
        /// 获取更新单据时Submit状态文字描述并设置Label
        /// </summary>
        /// <returns></returns>
        public void HTSubmitFlagTextGetSet()
        {
            if (this.SubmitFlag || this.AuditFlag)
            {
                LabelItem li = this.ToolBarLItemGet(-1, ToolButtonName.lblFormStatus.ToString());
                li.Text = HTSubmitFlagTextGet();
            }
        }
        #endregion

        #region 通用方法访问
        /// <summary>
        /// 绑定检索条件方法
        /// </summary>
        /// <param name="qryContainer"></param>
        /// <param name="qryConMethod"></param>
        /// <param name="qryMethod"></param>
        /// <param name="p_Frm"></param>
        /// <param name="p_QryStrongType">强制检索方法</param>
        public void BindQryMethod(Control qryContainer,UIMethodQryData qryConMethod,UIMethodQryData qryMethod,BaseForm p_Frm,int p_QryStrongType)
        {
            if (qryContainer != null)//默认回车检索
            {
                int opType = -1;
                if (p_QryStrongType != 0)
                {
                    opType = p_QryStrongType;
                }
                else
                {
                    opType = WinUIParamSet.GetIntValueByID(8010);//统业务数据默认检索方式0/1/2/3:未设置/回车检索/值改变检索/不检索',
                    if (opType == 0)
                    {
                        opType = 1;
                    }
                }
               
                new WUICtrlQry(qryContainer, qryConMethod, qryMethod, opType, p_Frm);
            }
        }


        /// <summary>
        /// 校验数据明细
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <param name="p_FieldCaption"></param>
        /// <returns></returns>
        public bool CheckCorrectDts(GridView p_GridView, string[] p_FieldStr)
        {
            bool finvalue = false;
            string tempstr = "";

            for (int i = 0; i < p_GridView.RowCount; i++)
            {
                finvalue = false;
                for (int j = 0; j < p_GridView.Columns.Count; j++)
                {
                    if (!p_GridView.Columns[j].Visible)//如果不可见则跳过
                    {
                        continue;
                    }
                    tempstr = SysConvert.ToString(p_GridView.GetRowCellValue(i, p_GridView.Columns[j]));
                    if (tempstr != "" && tempstr != "0")//找到一列有值
                    {
                        finvalue = true;
                        break;
                    }
                }
                if (finvalue)//开始检查是否录入正确的数据
                {
                    for (int fi = 0; fi < p_FieldStr.Length; fi++)
                    {
                        if (SysConvert.ToString(p_GridView.GetRowCellValue(i, p_GridView.Columns[p_FieldStr[fi]])) == "" && p_GridView.Columns[p_FieldStr[fi]].Visible)
                        {
                            ShowMessage("请输入" + p_GridView.Columns[p_FieldStr[fi]].Caption + " 行：" + (i + 1).ToString());
                            return false;
                        }
                    }

                }

            }
            return true;
        }

        /// <summary>
        /// 获得数据明细完整记录数
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <returns></returns>
        public int GetDataCompleteNum(GridView p_GridView, string[] p_FieldStr)
        {
            int outint = 0;
            for (int i = 0; i < p_GridView.RowCount; i++)
            {
                if (CheckDataCompleteDts(p_GridView, p_FieldStr, i))
                {
                    outint++;
                }
            }

            return outint;
        }


        /// <summary>
        /// 校验数据明细是否完整
        /// </summary>
        /// <param name="p_FieldStr"></param>
        /// <param name="p_RowI"></param>
        /// <returns></returns>
        public bool CheckDataCompleteDts(GridView p_GridView, string[] p_FieldStr, int p_RowI)
        {
            for (int fi = 0; fi < p_FieldStr.Length; fi++)
            {
                if (SysConvert.ToString(p_GridView.GetRowCellValue(p_RowI, p_GridView.Columns[p_FieldStr[fi]])) == "" && p_GridView.Columns[p_FieldStr[fi]].Visible)
                {
                    return false;
                }
            }
            return true;
        }


       
        /// <summary>
        /// 设置TabIndex
        /// </summary>
        /// <param name="p_TopIndex">顶部索引；设置时*1000000</param>
        /// <param name="p_Ctl">设置GroupControl内的Index</param>
        public void SetTabIndex(int p_TopIndex, DevExpress.XtraEditors.GroupControl p_Ctl)
        {
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            System.Collections.ArrayList al2 = new System.Collections.ArrayList();
            foreach (Control ctl in p_Ctl.Controls)//遍历每个控件，需要设置TabIndex的处理
            {
                if (!ctl.Visible)//控件不可见
                {
                    continue;
                }
                if ( ctl is DevExpress.XtraEditors.TextEdit || ctl is DevExpress.XtraEditors.DateEdit
                    || ctl is DevExpress.XtraEditors.LookUpEdit || ctl is DevExpress.XtraEditors.ComboBoxEdit
                    || ctl is DevExpress.XtraEditors.CheckEdit || ctl is DevExpress.XtraEditors.SimpleButton
                    || ctl is DevExpress.XtraEditors.MemoEdit
                    || ctl is DevExpress.XtraGrid.GridControl)//如果是适合的控件的话
                {
                    System.Collections.ArrayList tempA = new System.Collections.ArrayList();//0,1,2,3:控件，行号，X坐标,行号Y坐标值[为了便于获得行号]
                    tempA.Add(ctl);
                    tempA.Add(0);
                    tempA.Add(ctl.Location.X);
                    tempA.Add(ctl.Location.Y);
                    al.Add(tempA);
                }
            }

            #region 处理行序号 BEGIN
            System.Collections.ArrayList alRowCount = new System.Collections.ArrayList();//行序号及行坐标值,内容int数组[0,1]:行序号，行Y坐标值
            bool findRowFlag = false;
            for (int i = 0; i < al.Count; i++)
            {
                findRowFlag = false;
                System.Collections.ArrayList tempA=(System.Collections.ArrayList)al[i];

                int ctlY = ((Control)tempA[0]).Location.Y;//控件Y坐标

                for (int j = 0; j < alRowCount.Count; j++)//行号ArrayList
                {
                    int tempY = ((int[])alRowCount[j])[1];//行号Y坐标值
                    if (tempY - 5 <= ctlY && ctlY <= tempY + 5)//找到行值
                    {
                        findRowFlag = true;
                        tempA[3] = tempY;
                        break;
                    }
                }
                if (!findRowFlag)//没有找到行值
                {
                    alRowCount.Add(new int[] { 0, ctlY });
                }
            }


            //整理处理行序号BEGIN
            int rowInex = 0;//行号
            for (int i = 0; i < alRowCount.Count; i++)
            {
                rowInex = 0;//行号 整理
                int tempY = ((int[])alRowCount[i])[1];//行号Y坐标值
                for (int j = 0; j < alRowCount.Count; j++)//遍历下一行
                {
                    if (i == j)//两列相等
                    {
                        continue;
                    }
                    int tempY2 = ((int[])alRowCount[j])[1];//行号Y坐标值

                    if (tempY > tempY2)//比循环的大+1;
                    {
                        rowInex++;
                    }
                }
                ((int[])alRowCount[i])[0] = rowInex;
                //SysFile.WriteFrameworkLog("行" + rowInex.ToString() + "  Y值" + tempY.ToString());
            }
            //整理处理行序号END
            #endregion 处理行序号 END

            #region 处理控件行号 BEGIN
            for (int i = 0; i < al.Count; i++)
            {
                System.Collections.ArrayList tempA = (System.Collections.ArrayList)al[i];

                for (int j = 0; j < alRowCount.Count; j++)//行号ArrayList
                {
                    int tempY = ((int[])alRowCount[j])[1];//行号Y坐标值
                    if (tempY == (int)tempA[3])//找到行值
                    {
                        tempA[1] = ((int[])alRowCount[j])[0];//赋值行号
                        break;
                    }
                }
            }
            #endregion 处理控件行号 END

            #region 设置TabIndex
            for (int i = 0; i < al.Count; i++)
            {
                System.Collections.ArrayList tempA = (System.Collections.ArrayList)al[i];

                ((Control)tempA[0]).TabIndex = p_TopIndex * 1000000 + ((int)tempA[1]) * 10000 + (int)tempA[2];
            }
            #endregion
        }

        #endregion


        #region 右键处理相关
        /// <summary>
        /// 增加右键
        /// </summary>
        /// <param name="p_Menu">菜单</param>
        /// <param name="p_Caption">标题</param>
        /// <param name="p_Eve">事件</param>
        public void HTAPAddContextMenu(System.Windows.Forms.ContextMenuStrip p_Menu, string p_Caption, System.EventHandler p_Eve)
        {
            System.Windows.Forms.ToolStripMenuItem tempcMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            tempcMenuItemView.Text = p_Caption;
            tempcMenuItemView.Name = "cmenu" + p_Menu.Items.Count.ToString();
            tempcMenuItemView.Click += new System.EventHandler(p_Eve);
            p_Menu.Items.Add(tempcMenuItemView);

            if (p_Caption == "拷贝")//拷贝增加快捷建
            {
                tempcMenuItemView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            }
        }
        #endregion

        #region 部门权限校验

        string outstr = string.Empty;

        /// <summary>
        /// 部门权限校验---只能查看自己部门以及子部门的业务单据
        /// </summary>
        /// <param name="p_FieldName">校验的字段名</param>
        /// <returns></returns>
        public virtual string GetDepartmentCondition(string p_FieldName)
        {
            try
            {
                string DepartmentQueryCondition = string.Empty;//返回权限的校验条件

                string Department = string.Empty;//登陆账号所属部门
                string QDepartment = string.Empty;//登陆账号所属部门及其子部门
                if (FParamConfig.HTDBToolFlag || FParamConfig.LoginHTFlag)//系统账号则查询全部
                {
                    return DepartmentQueryCondition;
                }
                if (p_FieldName == "")
                {
                    return DepartmentQueryCondition;
                }
                string sql = "Select Department From Data_OP Where OPID=" + SysString.ToDBString(FParamConfig.LoginID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    Department = SysConvert.ToString(dt.Rows[0]["Department"]);//得到登陆账号所属部门
                }
                outstr = string.Empty;
                QDepartment = GetStr(Department);//得到登陆账号所属部门及其子部门

                DepartmentQueryCondition = " AND " + p_FieldName + " IN (Select OPID From Data_OP Where Department IN ('" + QDepartment + "'))";//得到返回权限的校验条件


                return DepartmentQueryCondition;

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
                return "";
            }
        }


        /// <summary>
        /// 递归树节点
        /// </summary>
        /// <param name="DepartmentID"></param>
        private string GetStr(string DepartmentID)
        {

            string strDepartmentID = "";
            if (outstr == "")
            {
                outstr += DepartmentID;
            }
            string sqlstr = " SELECT DepartmentID FROM Enum_ZZGXDts WHERE TopDepartmentID In( '" + DepartmentID + "')";
            //string sqlstr = " SELECT DepartmentID FROM Enum_ZZGXDts WHERE TopDepartmentID =";
            //sqlstr += "(SELECT Department FROM Data_OP WHERE OPID=" + SysString.ToDBString(SysConvert.ToString(FParamConfig.LoginID)) + ")";
            //sqlstr += "  AND MainID=" + HTDataID;
            DataTable dt = SysUtils.Fill(sqlstr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (strDepartmentID != "")
                    {
                        strDepartmentID += "','";
                    }
                    strDepartmentID += dt.Rows[i]["DepartmentID"].ToString();
                }
                if (strDepartmentID != "")
                {
                    if (outstr != "")
                    {
                        outstr += "','";
                    }
                    outstr += strDepartmentID;
                    GetStr(strDepartmentID);//递归循环
                }
            }
            return outstr;
        }

        #endregion


        #region 根据（制单人/或指定的人员）查询过滤单据

        /// <summary>
        /// 根据（制单人/或指定的人员）查询过滤单据
        /// </summary>
        /// <param name="p_FieldName">校验的字段名</param>
        /// <returns></returns>
        public virtual string GetOPIDCondition(string p_FieldName_OPID, string p_FieldName_Department)
        {
            string sqlWhere = "";
            try
            {
                if (FParamConfig.HTDBToolFlag || FParamConfig.LoginHTFlag)//系统账号则查询全部
                {
                    return sqlWhere;
                }
                string sql = " SELECT Code FROM Enum_Department WHERE ZRR=" + SysString.ToDBString(FParamConfig.LoginID);
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    string strDepartmentID = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (strDepartmentID != "")
                        {
                            strDepartmentID += "','";
                        }
                        strDepartmentID += dt.Rows[i]["Code"].ToString();
                        outstr = strDepartmentID;
                    }
                    GetStr(strDepartmentID);
                    sqlWhere += " AND (" + p_FieldName_Department + " IN " + "( '" + outstr + "')";
                    sqlWhere += " OR ISNULL(" + p_FieldName_Department + ",'') = ''";
                    sqlWhere += " OR " + p_FieldName_OPID + " = " + SysString.ToDBString(FParamConfig.LoginID)+")";
                    return sqlWhere;
                }
                else
                {
                    sqlWhere = " AND " + p_FieldName_OPID + " = " + SysString.ToDBString(FParamConfig.LoginID);
                    return sqlWhere;
                }

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
                sqlWhere = " AND " + p_FieldName_OPID + " = " + SysString.ToDBString(FParamConfig.LoginID);
                return sqlWhere;
            }
        }
        #endregion
    }
}