using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using HttSoft.FrameFunc;

namespace HttSoft.WinUIBase
{
   


    /// <summary>
    ///  GridView编辑状态下初始化控制 数据编辑表格右键处理
    /// </summary>
    public class GridViewOPCMenuProc
    {
        GridView _Grid;
        frmAPBaseTool _ToolForm;

        int _CopyRowIndex = -1;
        ContextMenuStrip _cmenu;

        #region 构造函数及初始化
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_ToolForm"></param>
        /// <param name="p_Grid"></param>
        public GridViewOPCMenuProc(frmAPBaseTool p_ToolForm, GridView p_Grid)
        {
            GridViewOPCMenuProcIni(p_ToolForm, p_Grid, false);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_ToolForm"></param>
        /// <param name="p_Grid"></param>
        /// <param name="p_AdvanceFlag">进阶按钮</param>
        public GridViewOPCMenuProc(frmAPBaseTool p_ToolForm, GridView p_Grid, bool p_AdvanceFlag)
        {
            GridViewOPCMenuProcIni(p_ToolForm, p_Grid, p_AdvanceFlag);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="p_ToolForm"></param>
        /// <param name="p_Grid"></param>
        private void GridViewOPCMenuProcIni(frmAPBaseTool p_ToolForm, GridView p_Grid,bool p_AdvanceFlag)
        {
            _Grid = p_Grid;
            _ToolForm = p_ToolForm;

            ToolStripMenuItem cmenuItemCopy = CreateOneCMenu("Copy", "复制", cMenuItemCopy_Click);
            ToolStripMenuItem cmenuItemPaste = CreateOneCMenu("Paste", "粘贴", cMenuItemPast_Click);

            ToolStripMenuItem cmenuItemAddRow = CreateOneCMenu("AddRow", "增行", cMenuItemAddRow_Click);
            ToolStripMenuItem cmenuItemDelRow = CreateOneCMenu("DelRow", "删行", cMenuItemDelRow_Click);
            ToolStripMenuItem cmenuItemMoveUp = CreateOneCMenu("MoveUp", "上移", cMenuItemMoveUp_Click);
            ToolStripMenuItem cmenuItemMoveDown = CreateOneCMenu("MoveDown", "下移", cMenuItemMoveDown_Click);


            _cmenu = new ContextMenuStrip();//this.components
            if (p_Grid.GridControl.ContextMenuStrip != null)//如果已经有右键，在之前的右键上附加
            {
                _cmenu = p_Grid.GridControl.ContextMenuStrip;

                _cmenu.Items.Add(CreateOneCMenu("Spilit", "-", null));
                _cmenu.Items.Add(cmenuItemCopy);
                _cmenu.Items.Add(cmenuItemPaste);
            }
            else
            {
                _cmenu.Name = "cmenu";
                _cmenu.Size = new System.Drawing.Size(153, 48);
                p_Grid.GridControl.ContextMenuStrip = _cmenu;
            }


            _cmenu.Items.Add(cmenuItemCopy);
            _cmenu.Items.Add(cmenuItemPaste);
            if (p_AdvanceFlag)
            {
                _cmenu.Items.Add(CreateOneCMenu("Spilit2", "-", null));

                _cmenu.Items.Add(cmenuItemAddRow);
                _cmenu.Items.Add(cmenuItemDelRow);
                _cmenu.Items.Add(cmenuItemMoveUp);
                _cmenu.Items.Add(cmenuItemMoveDown);
            }
            _cmenu.Opening += new System.ComponentModel.CancelEventHandler(cMenu_Opening);//打开事件绑定            
        }

        #endregion

        #region 自定义方法及事件

        #region 进阶按钮事件

        /// <summary>
        /// 增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.查询)
                {
                    MessageBox.Show("编辑状态下才可增行");
                    return;
                }

                if (_Grid.GridControl.DataSource != null)
                {

                    WCommon.DataTableAddRow((DataTable)_Grid.GridControl.DataSource, _Grid.FocusedRowHandle);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        /// <summary>
        /// 删行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.查询)
                {
                    MessageBox.Show("编辑状态下才可删行");
                    return;
                }

                if (_Grid.GridControl.DataSource != null)
                {
                    if (DialogResult.Yes != _ToolForm.ShowConfirmMessage("确实要删除该行"))
                    {
                        return;
                    }
                    WCommon.DelDtRow((DataTable)_Grid.GridControl.DataSource, _Grid.FocusedRowHandle);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.查询)
                {
                    MessageBox.Show("编辑状态下才可上移");
                    return;
                }
                if (_Grid.GridControl.DataSource != null)
                {
                    WCommon.DataTableUpRow((DataTable)_Grid.GridControl.DataSource, _Grid.FocusedRowHandle);
                    if (_Grid.FocusedRowHandle > 0)
                    {
                        _Grid.FocusedRowHandle = _Grid.FocusedRowHandle - 1;
                    }
                }
               
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.查询)
                {
                    MessageBox.Show("编辑状态下才可下移");
                    return;
                }

                if (_Grid.GridControl.DataSource != null)
                {
                    if (_Grid.GridControl.DataSource != null)
                    {
                        WCommon.DataTableDownRow((DataTable)_Grid.GridControl.DataSource, _Grid.FocusedRowHandle);
                        if (_Grid.FocusedRowHandle + 1 < _Grid.RowCount)
                        {
                            _Grid.FocusedRowHandle = _Grid.FocusedRowHandle + 1;
                        }
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        #endregion

        /// <summary>
        /// 主菜单打开中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                SetCMenuEnable(new string[] { "Copy", "Paste", "AddRow", "DelRow", "MoveUp", "MoveDown" }, false);//默认不能操作
                if (_ToolForm.HTFormStatus == FormStatus.查询)//查询状态
                {
                }
                else//编辑状态
                {
                    SetCMenuEnable(new string[] { "Copy", "Paste", "AddRow", "DelRow", "MoveUp", "MoveDown" }, true);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }


        /// <summary>
        /// 设置右键菜单
        /// </summary>
        /// <param name="p_NameA"></param>
        /// <param name="p_Flag"></param>
        void SetCMenuEnable(string[] p_NameA, bool p_Flag)
        {
            for (int i = 0; i < p_NameA.Length; i++)
            {
                ToolStripMenuItem item = FindOneCMenu(p_NameA[i]);
                if (item != null)
                {
                    item.Enabled = p_Flag;
                }
            }
        }
        /// <summary>
        /// 寻找一个右键菜单
        /// </summary>
        /// <param name="p_Name"></param>
        /// <returns></returns>
        ToolStripMenuItem FindOneCMenu(string p_Name)
        {
            ToolStripMenuItem outmenuitem=new ToolStripMenuItem();
            for (int i = 0; i < _cmenu.Items.Count; i++)
            {
                if (_cmenu.Items[i].Name == p_Name || _cmenu.Items[i].Name == "cmenuItem" + p_Name)
                {
                    outmenuitem = (ToolStripMenuItem)_cmenu.Items[i];
                    break;
                }
            }
            return outmenuitem;
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.查询)
                {
                    MessageBox.Show("编辑状态下才可复制");
                    return;
                }

                if (_Grid.GridControl.DataSource != null)
                {
                    _CopyRowIndex = _Grid.FocusedRowHandle;
                    ((ToolStripMenuItem)sender).Text = "复制 行" + (_CopyRowIndex + 1);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemPast_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.查询)
                {
                    MessageBox.Show("编辑状态下才可粘贴");
                    return;
                }
                if (_Grid.GridControl.DataSource != null)
                {
                    int curRowIndex=_Grid.FocusedRowHandle;
                    if (_CopyRowIndex >= 0 && curRowIndex >= 0 && _CopyRowIndex != curRowIndex)
                    {
                        DataTable dtSource = (DataTable)_Grid.GridControl.DataSource;
                        if (_CopyRowIndex < dtSource.Rows.Count && curRowIndex < dtSource.Rows.Count)//防止重新绑定数据溢出
                        {
                            for (int i = 0; i < dtSource.Columns.Count; i++)
                            {
                                if (dtSource.Columns[i].ColumnName != "ID")//ID值不复制
                                {
                                    dtSource.Rows[curRowIndex][i] = dtSource.Rows[_CopyRowIndex][i];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }



        /// <summary>
        /// 创建一个菜单按钮项
        /// </summary>
        /// <param name="p_Name"></param>
        /// <param name="p_Caption"></param>
        /// <param name="p_ClickEvent"></param>
        /// <returns></returns>
        ToolStripMenuItem CreateOneCMenu(string p_Name,string p_Caption,EventHandler p_ClickEvent)
        {
            ToolStripMenuItem cmenuItem = new ToolStripMenuItem();
            cmenuItem.Name = "cmenuItem" + p_Name;
            cmenuItem.Size = new System.Drawing.Size(152, 22);
            cmenuItem.Text = p_Caption;
            if (p_ClickEvent != null)
            {
                cmenuItem.Click += new System.EventHandler(p_ClickEvent);
            }
            return cmenuItem;
        }


        #endregion

    }
}
