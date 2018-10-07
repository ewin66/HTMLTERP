using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using HttSoft.MLTERP.Sys;
namespace MLTERP
{
    /// <summary>
    /// 绑定多选通用类
    /// </summary>
    public partial class PopContainerUtil : BaseForm
    {
        public delegate void BindCheckListPopCallBack(CheckedListBoxControl p_DrpID);

        public PopContainerUtil()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 用于处理BindCheckListPopCallBack
        /// </summary>
        /// <param name="p_popContainerEdit"></param>
        /// <param name="p_CallBackHandler"></param>
        public PopContainerUtil(PopupContainerEdit p_popContainerEdit, BindCheckListPopCallBack p_CallBackHandler)
        {
            InitializeComponent();
            m_popContainerEdit = p_popContainerEdit;
            ChkPopList.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(ChkPopList_ItemCheck);
            p_CallBackHandler(ChkPopList);//绑定数据源
            p_popContainerEdit.Properties.PopupControl = PopContainer;

        }
        /// <summary>
        /// 处理文本框（不直接用MenoEdit而使用这种方式主要是为了节约界面空间)
        /// </summary>
        /// <param name="p_popContainerEdit"></param>
        public PopContainerUtil(PopupContainerEdit p_popContainerEdit)
        {
            InitializeComponent();
            m_popContainerEdit2 = p_popContainerEdit;
            m_popContainerEdit2.MouseClick += new MouseEventHandler(
                delegate(object sender,  MouseEventArgs e)
                {
                    memoEdit1.Text = m_popContainerEdit2.Text;
                }
                );
            p_popContainerEdit.Properties.PopupControl = popMenoEidt;
            popMenoEidt.Width = m_popContainerEdit2.Width;

        }
        RepositoryItemPopupContainerEdit _RepositoryItemPopupContainerEdit;
        GridView _view;
        string tempDisplayMember = "";
        string tempEditValue = "";
        string _DisplayMemberFieldName = "";
        string _EditValueFielName = "";
        /// <summary>
        /// 用于处理列表里的多选
        /// </summary>
        /// <param name="p_popContainerEdit"></param>
        /// <param name="p_CallBackHandler"></param>
        public PopContainerUtil(RepositoryItemPopupContainerEdit p_popContainerEdit, GridView p_view, string p_DisplayMemberFieldName, string p_EditValueFielName, BindCheckListPopCallBack p_CallBackHandler)
        {
            InitCLS(p_popContainerEdit, p_view, p_DisplayMemberFieldName, p_EditValueFielName, p_CallBackHandler);
        }
        /// <summary>
        /// 用于处理列表里的多选
        /// </summary>
        /// <param name="p_popContainerEdit"></param>
        /// <param name="p_CallBackHandler"></param>
        public PopContainerUtil(RepositoryItemPopupContainerEdit p_popContainerEdit, GridView p_view, string p_DisplayMemberFieldName, BindCheckListPopCallBack p_CallBackHandler)
        {
            InitCLS(p_popContainerEdit, p_view, p_DisplayMemberFieldName, "", p_CallBackHandler);
        }
        /// <summary>
        /// 初始化列表里的多选
        /// </summary>
        /// <param name="p_popContainerEdit"></param>
        /// <param name="p_view"></param>
        /// <param name="p_DisplayMemberFieldName"></param>
        /// <param name="p_EditValueFielName"></param>
        /// <param name="p_CallBackHandler"></param>
        void InitCLS(RepositoryItemPopupContainerEdit p_popContainerEdit, GridView p_view, string p_DisplayMemberFieldName, string p_EditValueFielName, BindCheckListPopCallBack p_CallBackHandler)
        {
            InitializeComponent();
            _RepositoryItemPopupContainerEdit = p_popContainerEdit;
            _view = p_view;
            _DisplayMemberFieldName = p_DisplayMemberFieldName;
            _EditValueFielName = p_EditValueFielName;
            _view.FocusedRowChanged += _view_FocusedRowChanged;
            //2011-11-29新增
            _RepositoryItemPopupContainerEdit.Leave += new EventHandler(_RepositoryItemPopupContainerEditLeave);
            ChkPopList.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(ChkPopGridList_ItemCheck);
            p_CallBackHandler(ChkPopList);//绑定数据源
            _RepositoryItemPopupContainerEdit.PopupControl = PopContainer;
            PopContainer.Height = 200;
        }
        #region 自定义方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkPopList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                string tempstr = "";
                for (int i = 0; i < m_chkPopList.ItemCount; i++)
                {
                    if (m_chkPopList.GetItemCheckState(i) == CheckState.Checked)
                    {
                        if (tempstr != string.Empty)
                        {
                            tempstr += ",";
                        }
                        tempstr += m_chkPopList.GetItemText(i).ToString();
                    }
                }
                m_popContainerEdit.EditValue = tempstr;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkPopGridList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                tempDisplayMember = "";
                tempEditValue = "";
                for (int i = 0; i < m_chkPopList.ItemCount; i++)
                {
                    if (m_chkPopList.GetItemCheckState(i) == CheckState.Checked)
                    {
                        if (tempDisplayMember != string.Empty)
                        {
                            tempDisplayMember += ",";
                        }
                        if (tempEditValue != string.Empty)
                        {
                            tempEditValue += ",";
                        }
                        tempDisplayMember += m_chkPopList.GetItemText(i).ToString();
                        tempEditValue += m_chkPopList.GetItemValue(i).ToString();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 清空
        /// </summary>
        private void ClearProList()
        {
            try
            {
                for (int i = 0; i < m_chkPopList.ItemCount; i++)
                {
                    if (m_chkPopList.GetItemCheckState(i) == CheckState.Checked)
                    {
                        m_chkPopList.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                ChkPopGridList_ItemCheck(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }
        private void _RepositoryItemPopupContainerEditLeave(object sender, EventArgs e)
        {
            try
            {
                try//值不一定非要有
                {
                    if (tempEditValue != "")
                    {
                        _view.SetRowCellValue(_view.FocusedRowHandle, _EditValueFielName, tempEditValue);
                    }
                }
                catch
                {

                }
                if (tempDisplayMember != "")
                {
                    _view.SetRowCellValue(_view.FocusedRowHandle, _DisplayMemberFieldName, tempDisplayMember);
                }
                ClearProList();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// 换行时给
        /// </summary>
        /// <param name="sendre"></param>
        /// <param name="e"></param>
        private void _view_FocusedRowChanged(object sendre, FocusedRowChangedEventArgs e)
        {
            try
            {
                try//值不一定非要有
                {
                    if (tempEditValue != "")
                    {
                        _view.SetRowCellValue(e.PrevFocusedRowHandle, _EditValueFielName, tempEditValue);
                    }
                }
                catch
                {

                }
                if (tempDisplayMember != "")
                {
                    _view.SetRowCellValue(e.PrevFocusedRowHandle, _DisplayMemberFieldName, tempDisplayMember);
                }
                ClearProList();
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }
        #endregion
        #region 属性
        private PopupContainerEdit m_popContainerEdit;
        
        public PopupContainerControl PopContainer
        {
            get
            {
                return m_popContainer;
            }
        }
        public CheckedListBoxControl ChkPopList
        {
            get
            {
                return m_chkPopList;
            }
        }
        #endregion

        #region 处理文本框
        private PopupContainerEdit m_popContainerEdit2;

        
        #endregion
        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                m_popContainerEdit2.Text = memoEdit1.Text;  
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
    }
}