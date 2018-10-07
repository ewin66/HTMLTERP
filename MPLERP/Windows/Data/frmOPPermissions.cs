using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Base;

namespace MLTERP
{
    /// <summary>
    /// 功能：员工权限
    /// </summary>
    public partial class frmOPPermissions : frmAPBaseUIRpt
    {
        public frmOPPermissions()
        {
            InitializeComponent();
        }

        #region 全局变量
        int saveOPID = 0;
        string OPID = string.Empty;
        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            //if (!Common.CheckLookUpEditBlank(drpQCompanyTypeID))
            //{
            //    tempStr += " AND CompanyTypeID = " + SysString.ToDBString(drpQCompanyTypeID.EditValue.ToString());
            //}
            if (txtQOPID.Text.Trim() != "")
            {
                tempStr += " ANd OPID LIKE " + SysString.ToDBString("%" + txtQOPID.Text.Trim() + "%");
            }
            if (txtQOPName.Text.Trim() != "")
            {
                tempStr += " ANd OPName LIKE " + SysString.ToDBString("%" + txtQOPName.Text.Trim() + "%");
            }
            tempStr += " AND UseableFlag=1";
            tempStr += " AND isnull(DefaultFlag,0)=0";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            OPRule rule = new OPRule();
            gridView1.GridControl.DataSource = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// 绑定TreeList
        /// </summary>
        private void BindTreeList()
        {
            //treeList1.Nodes.Clear();
            DataTable dt = GetTreeListTable();
            ProcessTreeList.BindTreeList(dt, treeList1, "MenuID", "ParentID", 0, false);
        }

        /// <summary>
        /// 绑定TreeList
        /// </summary>
        private void BindTreeListAll()
        {
            DataTable dt = GetTreeListTable();
            ProcessTreeList.BindTreeList(dt, treeList2, "MenuID", "ParentID", 0, true);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            OPRule rule = new OPRule();
            OP entity = EntityGet();
            rule.RDelete(entity);
        }

        ///// <summary>
        ///// 新增
        ///// </summary>
        //public override int EntityAdd()
        //{










        //    return saveOPID;
        //}

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_OP";
            this.HTDataList = gridView1;
            
            ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//绑定列				
            ProcessTreeList.SetTreeColumnUI(treeList1);//设置列UI
           

            ProcessTreeList.BindTreeColumn(treeList2, this.FormID);//绑定列				
            ProcessTreeList.SetTreeColumnUI(treeList2);//设置列UI

            //Common.BindCompanyType(drpQCompanyTypeID, true);

            //this.doStatus = 1;//新增数据

            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//绑定GridView1事件
            gridViewBindEventA1(gridView1);


            string sql = "SELECT ID,Name FROM Enum_SaleGroup";
            chkListGroup.DataSource = SysUtils.Fill(sql);
            chkListGroup.DisplayMember = "Name";
            chkListGroup.ValueMember = "ID";
            chkListGroup.Show();


            sql = "SELECT WHID,WHNM FROM WH_WH";
            chkListWH.DataSource = SysUtils.Fill(sql);
            chkListWH.DisplayMember = "WHNM";
            chkListWH.ValueMember = "WHID";
            chkListWH.Show();



            sql = "SELECT ID,Name FROM Data_AuthGrp";
            chkListAuthGrp.DataSource = SysUtils.Fill(sql);
            chkListAuthGrp.DisplayMember = "Name";
            chkListAuthGrp.ValueMember = "ID";
            chkListAuthGrp.Show();


            sql = "SELECT ID,Name FROM Data_Dep";
            chkListDep.DataSource = SysUtils.Fill(sql);
            chkListDep.DisplayMember = "Name";
            chkListDep.ValueMember = "ID";
            chkListDep.Show();



            BindTreeList();
            BindTreeListAll();

            treeListColumnName.OptionsColumn.AllowEdit = false;//窗体权限
            treeListColumn4.OptionsColumn.AllowEdit = false;//窗体已具有权限

            btnQuery_Click(null, null);
        }

        /// <summary>
        /// 重新设置实体1
        /// </summary>
        public override void gridViewRowChanged1(object sender)
        {
            ColumnView view = sender as ColumnView;
            saveOPID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ID"]));
            OPID = SysConvert.ToString(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["OPID"]));

            treeList1.Refresh();
            string sql = "SELECT WinListID ID,HeadTypeID,SubTypeID FROM Data_OPWinList WHERE OPID=" + SysString.ToDBString(OPID);
            sql += " UNION SELECT WinListSubID ID,HeadTypeID,SubTypeID FROM Data_OPWinListSub WHERE OPID=" + SysString.ToDBString(OPID);
            dtRight = SysUtils.Fill(sql);

            SetCheckBoxState(treeList1.Nodes, false);
            treeList1.Refresh();

            sql = "SELECT WinListID ID,HeadTypeID,SubTypeID FROM Data_OPWinList WHERE OPID=" + SysString.ToDBString(OPID);
            sql += " UNION SELECT WinListSubID ID,HeadTypeID,SubTypeID FROM Data_OPWinListSub WHERE OPID=" + SysString.ToDBString(OPID);
            sql += " UNION SELECT WinListID ID,HeadTypeID,SubTypeID FROM Data_AuthGrpWinList WHERE AuthGrpID IN(SELECT AuthGrpID FROM Data_OPAuthGrp WHERE OPID=" + SysString.ToDBString(OPID) + ")";
            sql += " UNION SELECT WinListSubID ID,HeadTypeID,SubTypeID FROM Data_AuthGrpWinListSub WHERE AuthGrpID IN(SELECT AuthGrpID FROM Data_OPAuthGrp WHERE OPID=" + SysString.ToDBString(OPID) + ")";
            dtRight = SysUtils.Fill(sql);
            SetCheckBoxState(treeList2.Nodes, false);
            treeList2.Refresh();


            SetListGroup();
            SetListWH();

            SetListDep();

            SetListAuthGrp();
            //BindTreeList();
            //BindTreeListAll();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OP EntityGet()
        {
            OP entity = new OP();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region 业务组
        /// <summary>
        /// 获得仓库ArrayList
        /// </summary>
        /// <returns></returns>
        private ArrayList GetGroup()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < chkListGroup.ItemCount; i++)
            {
                if (chkListGroup.GetItemCheckState(i) == CheckState.Checked)
                {
                    al.Add(chkListGroup.GetItemValue(i).ToString());
                }
            }
            return al;
        }

        /// <summary>
        /// 设置权限选择
        /// </summary>
        private void SetListGroup()
        {
            for (int i = 0; i < chkListGroup.ItemCount; i++)
            {
                chkListGroup.SetItemCheckState(i, CheckState.Unchecked);
            }
            string sql = "SELECT SaleGroupID FROM Data_OPSaleGroup WHERE OPID=" + SysString.ToDBString(OPID);
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < chkListGroup.ItemCount; i++)
                {
                    if (dr["SaleGroupID"].ToString() == chkListGroup.GetItemValue(i).ToString())
                    {
                        chkListGroup.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }
        #endregion

        #region 仓库
        /// <summary>
        /// 获得仓库ArrayList
        /// </summary>
        /// <returns></returns>
        private ArrayList GetWH()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < chkListWH.ItemCount; i++)
            {
                if (chkListWH.GetItemCheckState(i) == CheckState.Checked)
                {
                    al.Add(chkListWH.GetItemValue(i).ToString());
                }
            }
            return al;
        }

        /// <summary>
        /// 设置权限选择
        /// </summary>
        private void SetListWH()
        {
            for (int i = 0; i < chkListWH.ItemCount; i++)
            {
                chkListWH.SetItemCheckState(i, CheckState.Unchecked);
            }
            string sql = "SELECT WHID FROM Data_OPWH WHERE OPID=" + SysString.ToDBString(OPID);
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < chkListWH.ItemCount; i++)
                {
                    if (dr["WHID"].ToString() == chkListWH.GetItemValue(i).ToString())
                    {
                        chkListWH.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }
        #endregion

        #region 树形相关

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
        private OPWinList[] GetEntityOPWinList()
        {
            ArrayList al = new ArrayList();
            this.GetEntityOPWinList(al, treeList1.Nodes);
            OPWinList[] entity = new OPWinList[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                entity[i] = (OPWinList)al[i];
            }
            return entity;
        }
        /// <summary>
        /// 获得ArrayList
        /// </summary>
        /// <param name="p_Al">ArrayList</param>
        /// <param name="p_Nodes">节点数组</param>
        /// <returns></returns>
        private void GetEntityOPWinList(ArrayList p_Al, TreeListNodes p_Nodes)
        {
            for (int i = 0; i < p_Nodes.Count; i++)
            {
                if (((CheckState)p_Nodes[i].Tag == CheckState.Checked || (CheckState)p_Nodes[i].Tag == CheckState.Indeterminate))
                {
                    if (SysConvert.ToString(p_Nodes[i].GetValue("MenuID")) != string.Empty && SysConvert.ToString(p_Nodes[i].GetValue("ParentID")) != "0")//有菜单且ParentID不为0
                    {
                        OPWinList entity = new OPWinList();
                        entity.OPID = OPID;
                        entity.WinListID = SysConvert.ToInt32(p_Nodes[i].GetValue("ID"));
                        entity.HeadTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("HeadTypeID"));
                        entity.SubTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("SubTypeID"));
                        if (entity.WinListID != 0)//必须有值
                        {
                            p_Al.Add(entity);
                        }
                    }
                }

                GetEntityOPWinList(p_Al, p_Nodes[i].Nodes);
            }
        }
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private OPWinListSub[] GetEntityOPWinListSub()
        {
            ArrayList al = new ArrayList();
            this.GetEntityOPWinListSub(al, treeList1.Nodes);
            OPWinListSub[] entity = new OPWinListSub[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                entity[i] = (OPWinListSub)al[i];
            }
            return entity;
        }
        /// <summary>
        /// 获得ArrayList
        /// </summary>
        /// <param name="p_Al">ArrayList</param>
        /// <param name="p_Nodes">节点数组</param>
        /// <returns></returns>
        private void GetEntityOPWinListSub(ArrayList p_Al, TreeListNodes p_Nodes)
        {
            for (int i = 0; i < p_Nodes.Count; i++)
            {
                if (((CheckState)p_Nodes[i].Tag == CheckState.Checked || (CheckState)p_Nodes[i].Tag == CheckState.Indeterminate))
                {
                    if (SysConvert.ToString(p_Nodes[i].GetValue("MenuID")) == string.Empty)//无菜单ID
                    {
                        OPWinListSub entity = new OPWinListSub();
                        entity.OPID = OPID;
                        entity.WinListSubID = SysConvert.ToInt32(p_Nodes[i].GetValue("ID"));
                        entity.HeadTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("HeadTypeID"));
                        entity.SubTypeID = SysConvert.ToInt32(p_Nodes[i].GetValue("SubTypeID"));
                        p_Al.Add(entity);
                    }
                }

                GetEntityOPWinListSub(p_Al, p_Nodes[i].Nodes);
            }
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

            for (int i = 0; i < dtwinlist.Rows.Count; i++)
            {
                if (dtwinlist.Rows[i]["MenuName"].ToString() != string.Empty)
                {
                    dtwinlist.Rows[i]["Name"] = dtwinlist.Rows[i]["MenuName"];
                }
            }


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


        #region treelist事件

        /// <summary>
        /// 空格键设置状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Space)
                    SetCheckedNode(treeList1.FocusedNode);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 鼠标左键设置状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    DevExpress.XtraTreeList.TreeListHitInfo hInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
                    if (hInfo.HitInfoType == HitInfoType.StateImage)
                        SetCheckedNode(hInfo.Node);
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 设置图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            try
            {
                CheckState check = GetCheckState(e.Node.Tag);
                if (check == CheckState.Unchecked)
                    e.NodeImageIndex = 0;
                else if (check == CheckState.Checked)
                    e.NodeImageIndex = 1;
                else e.NodeImageIndex = 2;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion


        #region treelist1处理

        DataTable dtRight = new DataTable();

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

        /// <summary>
        /// 设置treeList1的选中状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckBoxState(TreeListNode node, CheckState check)
        {
            node.Tag = check;
            SetCheckedChildNodes(node, check);
            SetCheckedParentNodes(node, check);
        }
        /// <summary>
        /// 设置接点状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="p_SubFlag"></param>
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
        /// <summary>
        /// 设置接点状态
        /// </summary>
        /// <param name="node"></param>
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
        /// <summary>
        /// 获得接点状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private CheckState GetCheckState(object obj)
        {
            if (obj != null) return (CheckState)obj;
            return CheckState.Unchecked;
        }

        /// <summary>
        /// 设置子接点状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedChildNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Tag = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 设置父接点状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
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



        #endregion

        #region 保存权限组
        /// <summary>
        /// 保存权限群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAuthGrp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))//权限管理
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                OPAuthGrpRule ruleAuthGrp = new OPAuthGrpRule();
                ruleAuthGrp.RSaveAuthGrp(this.GetAuthGrp(), OPID);
                FCommon.AddDBLog(this.Text, "保存业务组别", "ID:" + OPID, "");

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 获得权限ArrayList
        /// </summary>
        /// <returns></returns>
        private ArrayList GetAuthGrp()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < chkListAuthGrp.ItemCount; i++)
            {
                if (chkListAuthGrp.GetItemCheckState(i) == CheckState.Checked)
                {
                    al.Add(chkListAuthGrp.GetItemValue(i).ToString());
                }
            }
            return al;
        }

        /// <summary>
        /// 设置权限选择
        /// </summary>
        private void SetListAuthGrp()
        {
            for (int i = 0; i < chkListAuthGrp.ItemCount; i++)
            {
                chkListAuthGrp.SetItemCheckState(i, CheckState.Unchecked);
            }
            string sql = "SELECT AuthGrpID FROM Data_OPAuthGrp WHERE OPID=" + SysString.ToDBString(OPID);
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < chkListAuthGrp.ItemCount; i++)
                {
                    if (dr["AuthGrpID"].ToString() == chkListAuthGrp.GetItemValue(i).ToString())
                    {
                        chkListAuthGrp.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }
        #endregion

        #region 保存窗体权限
        /// <summary>
        /// 保存窗体权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveWinList_Click(object sender, EventArgs e)
        {

            try
            {
                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))//权限管理
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }
                SetTreeListDefault(treeList1.Nodes);
                OPWinListRule rule = new OPWinListRule();
                OPWinList[] entity = this.GetEntityOPWinList();
                OPWinListSub[] entitysub = this.GetEntityOPWinListSub();

                rule.RSave(entity, entitysub, OPID);
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
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < treeList1.Nodes.Count; i++)
                {
                    treeList1.Nodes[i].Tag = CheckState.Checked;
                    SetCheckedChildNodes(treeList1.Nodes[i], CheckState.Checked);
                }
                treeList1.Refresh();
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
        private void btnSelectOpp_Click(object sender, EventArgs e)
        {
            try
            {
                SetCheckStatusOpp(treeList1.Nodes);
                treeList1.Refresh();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
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
        #endregion

        #region 保存仓库
        /// <summary>
        /// 保存仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveWH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))//权限管理
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                OPWHRule ruleWH = new OPWHRule();
                ruleWH.RSaveWH(this.GetWH(), OPID);

                FCommon.AddDBLog(this.Text, "保存仓库权限", "ID:" + OPID, "");
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 保存业务组
        /// <summary>
        /// 保存业务组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))//权限管理
            {
                this.ShowMessage("你没有此操作权限");
                return;
            }

            OPSaleGroupRule ruleGroup = new OPSaleGroupRule();
            ruleGroup.RSaveGroup(this.GetGroup(), OPID);
            FCommon.AddDBLog(this.Text, "保存业务组别", "ID:" + OPID, "");
        }
        #endregion

        #region 保存岗位
        /// <summary>
        /// 保存岗位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveDep_Click(object sender, EventArgs e)
        {

            if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))//权限管理
            {
                this.ShowMessage("你没有此操作权限");
                return;
            }

            OPDepRule ruleDep = new OPDepRule();
            ruleDep.RSaveDep(this.GetDep(), OPID);
            FCommon.AddDBLog(this.Text, "保存岗位", "ID:" + OPID, "");
        }
        /// <summary>
        /// 获得仓库ArrayList
        /// </summary>
        /// <returns></returns>
        private ArrayList GetDep()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < chkListDep.ItemCount; i++)
            {
                if (chkListDep.GetItemCheckState(i) == CheckState.Checked)
                {
                    al.Add(chkListDep.GetItemValue(i).ToString());
                }
            }
            return al;
        }

        /// <summary>
        /// 设置权限选择
        /// </summary>
        private void SetListDep()
        {
            for (int i = 0; i < chkListDep.ItemCount; i++)
            {
                chkListDep.SetItemCheckState(i, CheckState.Unchecked);
            }
            string sql = "SELECT DepID FROM Data_OPDep WHERE OPID=" + SysString.ToDBString(OPID);
            DataTable dt = SysUtils.Fill(sql);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < chkListDep.ItemCount; i++)
                {
                    if (dr["DepID"].ToString() == chkListDep.GetItemValue(i).ToString())
                    {
                        chkListDep.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FCommon.RightCheck(this.FormID, this.FormListAID, this.FormListBID, RightSub.新增))//权限管理
                {
                    this.ShowMessage("你没有此操作权限");
                    return;
                }

                if (DialogResult.Yes != ShowConfirmMessage("批量保存将覆盖所有用户的权限设置！"))
                {
                    return;
                }

                SetTreeListDefault(treeList1.Nodes);
                OPWinListRule rule = new OPWinListRule();
                OPWinList[] entity = this.GetEntityOPWinList();
                OPWinListSub[] entitysub = this.GetEntityOPWinListSub();

                rule.RAllSave(entity, entitysub);
            }
            catch
            {
 
            }
        }

        private void txtQOPID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtQOPName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


    }
}