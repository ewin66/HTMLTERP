using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 功能：客户管理明细
    /// 作者：章文强
    /// 日期：2012-04-18
    /// 操作：新增
    /// </summary>
    public partial class frmAuthGrpEEdit : frmAPBaseUIFormEdit
    {
        public frmAuthGrpEEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
       

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            //设置物品信息
            AuthGrp entity = new AuthGrp();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code;
            txtRemark.Text = entity.Remark;
            txtName.Text = entity.Name;
            drpIsDefaultFlag.EditValue = entity.IsDefaultFlag;

            //绑定明细信息
            SetTreelListValue();
            

        }

        /// <summary>
        /// 绑定客户联系人
        /// </summary>
        private void BindGrid()
        {
            //VendorContactRule rule = new VendorContactRule();
            //DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            //gridView1.GridControl.DataSource = dt;
            //gridView1.GridControl.Show();
        }

      
       



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            if (txtID.Text.Trim() == "1")
            {
                throw new Exception("ID为1的权限不允许编辑");
            }
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity =EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {

            this.ToolBarItemAdd(28, "btnSaveAuth", "保存权限群", false, btnSaveAuth_Click);
            this.ToolBarItemAdd(28, "btnSelectAll", "全选", false, btnSelectAll_Click);
            this.ToolBarItemAdd(28, "btnSelectOpp", "反选", false, btnSelectOpp_Click);

            ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//绑定列				
            ProcessTreeList.SetTreeColumnUI(treeList1);//设置列UI
            this.HTDataTableName = "Data_AuthGrp";
            //this.HTDataDts = treeList1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] {  };
            this.HTSubmitFlagFieldName = "";
            this.HTDelFlagFieldName = "";
            SetTabIndex(0, groupControlMainten);

            BindTreeList();

        }

        /// <summary>
        /// 新增初始化
        /// </summary>
        public override void IniInsertSet()
        {
          
        }


        /// <summary>
        /// 编辑单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }
        #endregion

        #region 新增修改删除
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim() == "1")
            {
                this.ShowMessage("ID为1的权限不允许编辑");
                return false;
            }
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("请输入ID");
                txtID.Focus();
                return false;
            }

            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("请输入编码");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtName.Focus();
                return false;
            }
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();

            rule.RAdd(entity);
            return entity.ID;
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();


            rule.RUpdate(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        private AuthGrp EntityGet()
        {
            AuthGrp entity = new AuthGrp();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.ID = SysConvert.ToInt32(txtID.Text.Trim());
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.IsDefaultFlag = SysConvert.ToInt32(drpIsDefaultFlag.EditValue);
            entity.Remark = txtRemark.Text.Trim();
            return entity;

        }

        


        
        #endregion

        #region 附加按钮事件
        /// <summary>
        /// 保存权限群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnSaveAuth_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTFormStatus == FormStatus.查询)
                {
                    SetTreeListDefault(treeList1.Nodes);
                    AuthGrpRule rule = new AuthGrpRule();
                    AuthGrpWinList[] entity = this.GetEntityWinList();
                    AuthGrpWinListSub[] entitysub = this.GetEntityWinListSub();

                    rule.RSave(entity, entitysub, txtID.Text.Trim());
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTFormStatus == FormStatus.查询)
                {
                    for (int i = 0; i < treeList1.Nodes.Count; i++)
                    {
                        treeList1.Nodes[i].Tag = CheckState.Checked;
                        SetCheckedChildNodes(treeList1.Nodes[i], CheckState.Checked);
                    }
                    treeList1.Refresh();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnSelectOpp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.新增))
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                if (HTFormStatus == FormStatus.查询)
                {
                    SetCheckStatusOpp(treeList1.Nodes);
                    treeList1.Refresh();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region treelist相关方法
        /// <summary>
        /// 设置默认的值
        /// </summary>
        /// <param name="nodes"></param>
        private void SetTreeListDefault(TreeListNodes nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Tag = GetCheckState(nodes[i].Tag);
                SetTreeListDefault(nodes[i].Nodes);
            }
        }
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private AuthGrpWinList[] GetEntityWinList()
        {
            ArrayList al = new ArrayList();
            this.GetEntityWinList(al, treeList1.Nodes);
            AuthGrpWinList[] entity = new AuthGrpWinList[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                entity[i] = (AuthGrpWinList)al[i];
            }
            return entity;
        }

        /// <summary>
        /// 获得ArrayList
        /// </summary>
        /// <param name="p_Al">ArrayList</param>
        /// <param name="p_Nodes">节点数组</param>
        /// <returns></returns>
        private void GetEntityWinList(ArrayList p_Al, TreeListNodes p_Nodes)
        {
            for (int i = 0; i < p_Nodes.Count; i++)
            {
                //if (SysConvert.ToString(p_Nodes[i].GetValue("MenuID")) == "6027")
                //{
                //    string tempstr = string.Empty;
                //}
                if (((CheckState)p_Nodes[i].Tag == CheckState.Checked || (CheckState)p_Nodes[i].Tag == CheckState.Indeterminate))
                {
                    if (SysConvert.ToString(p_Nodes[i].GetValue("MenuID")) != string.Empty && SysConvert.ToInt32(p_Nodes[i].GetValue("ID")) != 0)//有菜单且ID不为0 && SysConvert.ToInt32(p_Nodes[i].GetValue("ParentID")) != 0 
                    {
                        AuthGrpWinList entity = new AuthGrpWinList();
                        entity.AuthGrpID = SysConvert.ToInt32(txtID.Text.Trim());
                        entity.WinListID = SysConvert.ToInt32(p_Nodes[i].GetValue("ID"));
                        entity.HeadTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("HeadTypeID"));
                        entity.SubTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("SubTypeID"));
                        p_Al.Add(entity);
                    }
                }

                GetEntityWinList(p_Al, p_Nodes[i].Nodes);
            }
        }

        /// <summary>
        /// 获得ArrayList
        /// </summary>
        /// <param name="p_Al">ArrayList</param>
        /// <param name="p_Nodes">节点数组</param>
        /// <returns></returns>
        private void GetEntityWinListSub(ArrayList p_Al, TreeListNodes p_Nodes)
        {
            for (int i = 0; i < p_Nodes.Count; i++)
            {
                if (((CheckState)p_Nodes[i].Tag == CheckState.Checked || (CheckState)p_Nodes[i].Tag == CheckState.Indeterminate))
                {
                    if (SysConvert.ToString(p_Nodes[i].GetValue("MenuID")) == string.Empty)//无菜单ID
                    {
                        AuthGrpWinListSub entity = new AuthGrpWinListSub();
                        entity.AuthGrpID = SysConvert.ToInt32(txtID.Text.Trim());
                        entity.WinListSubID = SysConvert.ToInt32(p_Nodes[i].GetValue("ID"));
                        entity.HeadTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("HeadTypeID"));
                        entity.SubTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("SubTypeID"));
                        p_Al.Add(entity);
                    }
                }

                GetEntityWinListSub(p_Al, p_Nodes[i].Nodes);
            }
        }



        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private AuthGrpWinListSub[] GetEntityWinListSub()
        {
            ArrayList al = new ArrayList();
            this.GetEntityWinListSub(al, treeList1.Nodes);
            AuthGrpWinListSub[] entity = new AuthGrpWinListSub[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                entity[i] = (AuthGrpWinListSub)al[i];
            }
            return entity;
        }

        DataTable dtRight = new DataTable();
        /// <summary>
        /// 绑定TreeList
        /// </summary>
        private void BindTreeList()
        {
            treeList1.Nodes.Clear();
            DataTable dt = GetTreeListTable();
            ProcessTreeList.BindTreeList(dt, treeList1, "MenuID", "ParentID", 0, true);
        }

        /// <summary>
        /// 取得TreeList数据源
        /// </summary>
        /// <returns></returns>
        private DataTable GetTreeListTable()
        {
            string sql = "SELECT MenuID,ID,ParentID,Name,MenuName,HeadTypeID,SubTypeID,Remark FROM UV1_Sys_WindowMenu_Right WHERE HttFlag=0 AND ShowFlag=1";
            sql += " AND SystemTypeID=" + (int)FParamConfig.SystemApType;
            sql += " ORDER BY Sort";
            DataTable dtwinlist = SysUtils.Fill(sql);

            sql = "SELECT ID,Code,Name,WinListID,0 AS ParentID,Remark FROM Enum_WinListSub";
            DataTable dtwinlistsub = SysUtils.Fill(sql);

            int wincount = dtwinlist.Rows.Count;
            for (int i = 0; i < dtwinlistsub.Rows.Count; i++)
            {
                string nowid = dtwinlistsub.Rows[i]["WinListID"].ToString();//遍历的winlistID
                ArrayList al = new ArrayList();//已经包含在菜单里面的窗体数组
                for (int j = 0; j < wincount; j++)//循环遍历窗体
                {
                    if (dtwinlist.Rows[j]["ID"].ToString() == nowid)
                    {
                        al.Add(new string[3] { dtwinlist.Rows[j]["MenuID"].ToString(), dtwinlist.Rows[j]["HeadTypeID"].ToString(), dtwinlist.Rows[j]["SubTypeID"].ToString() });//存放MenuID,HeadTypeID,SubTypeID
                    }
                }

                for (int j = 0; j < al.Count; j++)//循环遍历已经存在的的窗体菜单
                {
                    string[] tempa = (string[])al[j];
                    DataRow dr = dtwinlist.NewRow();
                    dr["ID"] = dtwinlistsub.Rows[i]["ID"].ToString();
                    dr["Name"] = dtwinlistsub.Rows[i]["Name"];
                    dr["MenuName"] = dtwinlistsub.Rows[i]["Name"];
                    dr["ParentID"] = SysConvert.ToInt32(tempa[0]);
                    dr["HeadTypeID"] = SysConvert.ToInt32(tempa[1]);
                    dr["SubTypeID"] = SysConvert.ToInt32(tempa[2]);
                    dr["Remark"] = dtwinlistsub.Rows[i]["Remark"];

                    dtwinlist.Rows.Add(dr);
                }
            }

            return dtwinlist;
        }

        /// <summary>
        /// 设置Treelist值
        /// </summary>
        void SetTreelListValue()
        {
            string sql = "SELECT AuthGrpID,WinListID ID,HeadTypeID,SubTypeID FROM Data_AuthGrpWinList WHERE AuthGrpID=" + SysString.ToDBString(txtID.Text.Trim());
            sql += " UNION SELECT AuthGrpID,WinListSubID ID,HeadTypeID,SubTypeID FROM Data_AuthGrpWinListSub WHERE AuthGrpID=" + SysString.ToDBString(txtID.Text.Trim());
            dtRight = SysUtils.Fill(sql);
            SetCheckBoxState(treeList1.Nodes, false);
            treeList1.Refresh();
        }

        /// <summary>
        /// 检验是否存在
        /// </summary>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        private bool CheckIDExist(int p_ID, int p_HeadTypeID, int p_SubTypeID, bool p_SubFlag)
        {
            for (int i = 0; i < dtRight.Rows.Count; i++)
            {
                if (SysConvert.ToInt32(dtRight.Rows[i]["ID"].ToString()) == p_ID && SysConvert.ToInt32(dtRight.Rows[i]["HeadTypeID"].ToString()) == p_HeadTypeID
                    && SysConvert.ToInt32(dtRight.Rows[i]["SubTypeID"].ToString()) == p_SubTypeID)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 设置treeList1的选中状态
        /// </summary>
        /// <param name="p_TreeListNodes"></param>
        private void SetCheckBoxState(TreeListNodes nodes, bool p_SubFlag)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Nodes.Count != 0)
                {
                    SetCheckBoxState(nodes[i].Nodes, true);
                }
                else
                {
                    SetCheckBoxState(nodes[i], p_SubFlag);
                }
            }
        }
        private void SetCheckBoxState(TreeListNode node, bool p_SubFlag)
        {
            if (CheckIDExist(SysConvert.ToInt32(node.GetValue("ID")), SysConvert.ToInt32(node.GetValue("HeadTypeID")), SysConvert.ToInt32(node.GetValue("SubTypeID")), p_SubFlag))
            {
                node.Tag = CheckState.Checked;
                SetCheckedChildNodes(node, CheckState.Checked);
                SetCheckedParentNodes(node, CheckState.Checked);
            }
            else
            {
                node.Tag = CheckState.Unchecked;
                SetCheckedChildNodes(node, CheckState.Unchecked);
                SetCheckedParentNodes(node, CheckState.Unchecked);
            }
        }
        private void SetCheckBoxState(TreeListNode node, CheckState check)
        {
            node.Tag = check;
            SetCheckedChildNodes(node, check);
            SetCheckedParentNodes(node, check);
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="nodes"></param>
        private void SetCheckStatusOpp(TreeListNodes nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Nodes.Count != 0)
                {
                    SetCheckStatusOpp(nodes[i].Nodes);
                }
                else
                {
                    CheckState check = (CheckState)nodes[i].Tag;
                    if (check == CheckState.Unchecked)
                    {
                        check = CheckState.Checked;
                    }
                    else
                    {
                        check = CheckState.Unchecked;
                    }
                    SetCheckBoxState(nodes[i], check);
                }
            }
        }
        private void SetCheckedNode(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            CheckState check = GetCheckState(node.Tag);
            if (check == CheckState.Indeterminate || check == CheckState.Unchecked) check = CheckState.Checked;
            else check = CheckState.Unchecked;
            treeList1.BeginUpdate();
            node.Tag = check;
            SetCheckedChildNodes(node, check);
            SetCheckedParentNodes(node, check);
            treeList1.EndUpdate();
        }

        private CheckState GetCheckState(object obj)
        {
            if (obj != null) return (CheckState)obj;
            return CheckState.Unchecked;
        }

        private void SetCheckedChildNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Tag = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void SetCheckedParentNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    if (!check.Equals(node.ParentNode.Nodes[i].Tag))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.Tag = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
        #endregion


        #region treelist事件
        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            CheckState check = GetCheckState(e.Node.Tag);
            if (check == CheckState.Unchecked)
                e.NodeImageIndex = 0;
            else if (check == CheckState.Checked)
                e.NodeImageIndex = 1;
            else e.NodeImageIndex = 2;
        }

        private void treeList1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
                SetCheckedNode(treeList1.FocusedNode);
        }

        private void treeList1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DevExpress.XtraTreeList.TreeListHitInfo hInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
                if (hInfo.HitInfoType == HitInfoType.StateImage)
                    SetCheckedNode(hInfo.Node);
            }
        }
        #endregion






    }
}