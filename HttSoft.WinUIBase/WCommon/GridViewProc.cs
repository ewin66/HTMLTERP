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
    ///  GridView�༭״̬�³�ʼ������ ���ݱ༭����Ҽ�����
    /// </summary>
    public class GridViewOPCMenuProc
    {
        GridView _Grid;
        frmAPBaseTool _ToolForm;

        int _CopyRowIndex = -1;
        ContextMenuStrip _cmenu;

        #region ���캯������ʼ��
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="p_ToolForm"></param>
        /// <param name="p_Grid"></param>
        public GridViewOPCMenuProc(frmAPBaseTool p_ToolForm, GridView p_Grid)
        {
            GridViewOPCMenuProcIni(p_ToolForm, p_Grid, false);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="p_ToolForm"></param>
        /// <param name="p_Grid"></param>
        /// <param name="p_AdvanceFlag">���װ�ť</param>
        public GridViewOPCMenuProc(frmAPBaseTool p_ToolForm, GridView p_Grid, bool p_AdvanceFlag)
        {
            GridViewOPCMenuProcIni(p_ToolForm, p_Grid, p_AdvanceFlag);
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="p_ToolForm"></param>
        /// <param name="p_Grid"></param>
        private void GridViewOPCMenuProcIni(frmAPBaseTool p_ToolForm, GridView p_Grid,bool p_AdvanceFlag)
        {
            _Grid = p_Grid;
            _ToolForm = p_ToolForm;

            ToolStripMenuItem cmenuItemCopy = CreateOneCMenu("Copy", "����", cMenuItemCopy_Click);
            ToolStripMenuItem cmenuItemPaste = CreateOneCMenu("Paste", "ճ��", cMenuItemPast_Click);

            ToolStripMenuItem cmenuItemAddRow = CreateOneCMenu("AddRow", "����", cMenuItemAddRow_Click);
            ToolStripMenuItem cmenuItemDelRow = CreateOneCMenu("DelRow", "ɾ��", cMenuItemDelRow_Click);
            ToolStripMenuItem cmenuItemMoveUp = CreateOneCMenu("MoveUp", "����", cMenuItemMoveUp_Click);
            ToolStripMenuItem cmenuItemMoveDown = CreateOneCMenu("MoveDown", "����", cMenuItemMoveDown_Click);


            _cmenu = new ContextMenuStrip();//this.components
            if (p_Grid.GridControl.ContextMenuStrip != null)//����Ѿ����Ҽ�����֮ǰ���Ҽ��ϸ���
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
            _cmenu.Opening += new System.ComponentModel.CancelEventHandler(cMenu_Opening);//���¼���            
        }

        #endregion

        #region �Զ��巽�����¼�

        #region ���װ�ť�¼�

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.��ѯ)
                {
                    MessageBox.Show("�༭״̬�²ſ�����");
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
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.��ѯ)
                {
                    MessageBox.Show("�༭״̬�²ſ�ɾ��");
                    return;
                }

                if (_Grid.GridControl.DataSource != null)
                {
                    if (DialogResult.Yes != _ToolForm.ShowConfirmMessage("ȷʵҪɾ������"))
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.��ѯ)
                {
                    MessageBox.Show("�༭״̬�²ſ�����");
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.��ѯ)
                {
                    MessageBox.Show("�༭״̬�²ſ�����");
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
        /// ���˵�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                SetCMenuEnable(new string[] { "Copy", "Paste", "AddRow", "DelRow", "MoveUp", "MoveDown" }, false);//Ĭ�ϲ��ܲ���
                if (_ToolForm.HTFormStatus == FormStatus.��ѯ)//��ѯ״̬
                {
                }
                else//�༭״̬
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
        /// �����Ҽ��˵�
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
        /// Ѱ��һ���Ҽ��˵�
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.��ѯ)
                {
                    MessageBox.Show("�༭״̬�²ſɸ���");
                    return;
                }

                if (_Grid.GridControl.DataSource != null)
                {
                    _CopyRowIndex = _Grid.FocusedRowHandle;
                    ((ToolStripMenuItem)sender).Text = "���� ��" + (_CopyRowIndex + 1);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        /// <summary>
        /// ճ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuItemPast_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ToolForm.HTFormStatus == FormStatus.��ѯ)
                {
                    MessageBox.Show("�༭״̬�²ſ�ճ��");
                    return;
                }
                if (_Grid.GridControl.DataSource != null)
                {
                    int curRowIndex=_Grid.FocusedRowHandle;
                    if (_CopyRowIndex >= 0 && curRowIndex >= 0 && _CopyRowIndex != curRowIndex)
                    {
                        DataTable dtSource = (DataTable)_Grid.GridControl.DataSource;
                        if (_CopyRowIndex < dtSource.Rows.Count && curRowIndex < dtSource.Rows.Count)//��ֹ���°��������
                        {
                            for (int i = 0; i < dtSource.Columns.Count; i++)
                            {
                                if (dtSource.Columns[i].ColumnName != "ID")//IDֵ������
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
        /// ����һ���˵���ť��
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
