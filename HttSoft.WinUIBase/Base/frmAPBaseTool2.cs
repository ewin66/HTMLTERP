using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using HttSoft.Framework;

namespace HttSoft.FrameFunc
{
    /// <summary>
    /// 基本工具按钮页面
    /// </summary>
    public partial class frmAPBaseTool2 : frmBaseHotKey
    {
        /// <summary>
        /// 
        /// </summary>
        public frmAPBaseTool2()
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
        private int _HTRightFormID = 0;

        /// <summary>
        /// 权限继承窗体ID
        /// </summary>
        public int HTRightFormID
        {

            get
            {

                return _HTRightFormID;

            }

            set
            {

                _HTRightFormID = value;

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
            ToolBarItemAdd(-1, p_ImageIndex, p_Name, p_Caption, p_BeginGroup,p_ClickEvent);
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
        public void ToolBarItemAdd(int p_PosIndex, int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent)
        {
            ProcessToolBar.ToolBarItemAdd(p_PosIndex, _BaseToolBar, p_ImageIndex, p_Name, p_Caption, p_BeginGroup,p_ClickEvent);          
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
            ToolBarItemAdd(-1, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent, p_Shortcut);
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
        public void ToolBarItemAdd(int p_PosIndex, int p_ImageIndex, string p_Name, string p_Caption, bool p_BeginGroup, System.EventHandler p_ClickEvent, DevComponents.DotNetBar.eShortcut p_Shortcut)
        {
            ProcessToolBar.ToolBarItemAdd(p_PosIndex, _BaseToolBar, p_ImageIndex, p_Name, p_Caption, p_BeginGroup, p_ClickEvent, p_Shortcut);
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
        public virtual void btnBrowse_Click(object sender, EventArgs e)
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
                if (!FCommon.RightCheck(this.FormID, this._HTRightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
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
                throw new Exception(E.Message);
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
                if (!FCommon.RightCheck(this.FormID, this._HTRightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
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
                throw new Exception(E.Message);
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
                if (!FCommon.RightCheck(this.FormID, this._HTRightFormID, this.FormListAID, this.FormListBID, RightSub.审核1))
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
                throw new Exception(E.Message);
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
                if (!FCommon.RightCheck(this.FormID, this._HTRightFormID, this.FormListAID, this.FormListBID, RightSub.审核1))
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
                throw new Exception(E.Message);
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
                if (!FCommon.RightCheck(this.FormID, this._HTRightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
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
                throw new Exception(E.Message);
            }
        }

        /// <summary>
        /// 恢复单据
        /// </summary>
        public virtual void btnFormRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this._HTRightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
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
                throw new Exception(E.Message);
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


      

      

        #endregion

        #region 其它调用虚方法定义
        /// <summary>
        ///  虚方法：初始化控件
        /// </summary>
        public virtual void ToolIniCreateBar()
        {
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
        #endregion



        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBaseTool_Load(object sender, EventArgs e)
        {
            try
            {
                _BaseToolBar = barTool;
                if (FormID != 0)
                {
                    ToolIniCreateBar();
                    
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }


        #endregion

        #region 提交、撤销提交、审核、审核拒绝
        /// <summary>
        /// 提交、撤销提交、审核、审核拒绝、校验
        /// </summary>
        /// <returns></returns>
        private bool HTSubmitCheck(FormStatus p_OPStatus)
        {
            string sql = "SELECT SubmitFlag,DelFlag FROM " + _HTDataTableName + " WHERE ID=" + SysString.ToDBString(_HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            int tempSubmitFlag = SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"]);
            int tempDelFlag = SysConvert.ToInt32(dt.Rows[0]["DelFlag"]);
            if (dt.Rows.Count != 0)
            {
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
                                if (tempSubmitFlag != (int)ConfirmFlag.已提交)
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

            string sql = "UPDATE " + p_TableName + " SET SubmitFlag=" + SysString.ToDBString(status) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
            SysUtils.ExecuteNonQuery(sql);
        }



        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDValue">ID值</param>
        private static void HTSubmitCancel(string p_TableName, string p_IDValue)
        {
            HTSubmitCancel(p_TableName, "ID",  p_IDValue);
        }

       
        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_IDValue">ID值</param>
        private static void HTSubmitCancel(string p_TableName, string p_IDField, string p_IDValue)
        {

            int status = (int)ConfirmFlag.未提交;//状态修改为未提交
            string sql = "UPDATE " + p_TableName + " SET SubmitFlag=" + SysString.ToDBString(status) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
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
            string sql = "UPDATE " + p_TableName + " SET SubmitFlag=" + SysString.ToDBString(status) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
            SysUtils.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 审核拒绝
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDValue">ID值</param>
        private static void HTAuditCancel(string p_TableName, string p_IDValue)
        {
            HTAuditCancel(p_TableName, "ID", p_IDValue);
        }

        /// <summary>
        /// 审核拒绝
        /// </summary>
        /// <param name="p_TableName">表名</param>
        /// <param name="p_IDField">ID字段名</param>
        /// <param name="p_IDValue">ID值</param>
        private static void HTAuditCancel(string p_TableName, string p_IDField, string p_IDValue)
        {
            int status = (int)ConfirmFlag.审核拒绝;//状态修改为审核拒绝
            string sql = "UPDATE " + p_TableName + " SET SubmitFlag=" + SysString.ToDBString(status) + "  WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);
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
            string sql = "SELECT SubmitFlag,DelFlag FROM " + _HTDataTableName + " WHERE ID=" + SysString.ToDBString(_HTDataID);
            DataTable dt = SysUtils.Fill(sql);
            int tempSubmitFlag = SysConvert.ToInt32(dt.Rows[0]["SubmitFlag"]);
            int tempDelFlag = SysConvert.ToInt32(dt.Rows[0]["DelFlag"]);
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
        private static void HTFormDel(string p_TableName, string p_IDField, string p_IDValue)
        {
            string sql = "UPDATE " + p_TableName + " SET DelFlag=1 WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);//删除标志修改为删除
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
        private static void HTFormRes(string p_TableName, string p_IDField, string p_IDValue)
        {
            string sql = "UPDATE " + p_TableName + " SET DelFlag=0 WHERE " + p_IDField + "=" + SysString.ToDBString(p_IDValue);//删除标志修改为正常
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
            LabelItem li= this.ToolBarLItemGet(-1, ToolButtonName.lblFormStatus.ToString());
            li.Text = HTSubmitFlagTextGet();
        }
        #endregion

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {

            this.Text = DateTime.Now.ToString();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

            this.Text = DateTime.Now.ToString()+"tt";
        }

    }
}