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
    /// ���ܣ��ͻ�������ϸ
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmAuthGrpEEdit : frmAPBaseUIFormEdit
    {
        public frmAuthGrpEEdit()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]     
       

        /// <summary>
        /// ����
        /// </summary>
        public override void EntitySet()
        {
            //������Ʒ��Ϣ
            AuthGrp entity = new AuthGrp();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtID.Text = entity.ID.ToString();
            txtCode.Text = entity.Code;
            txtRemark.Text = entity.Remark;
            txtName.Text = entity.Name;
            drpIsDefaultFlag.EditValue = entity.IsDefaultFlag;

            //����ϸ��Ϣ
            SetTreelListValue();
            

        }

        /// <summary>
        /// �󶨿ͻ���ϵ��
        /// </summary>
        private void BindGrid()
        {
            //VendorContactRule rule = new VendorContactRule();
            //DataTable dt = rule.RShow(" AND MainID=" + HTDataID + " ORDER BY Seq", ProcessGrid.GetQueryField(gridView1));

            //gridView1.GridControl.DataSource = dt;
            //gridView1.GridControl.Show();
        }

      
       



        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            if (txtID.Text.Trim() == "1")
            {
                throw new Exception("IDΪ1��Ȩ�޲�����༭");
            }
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity =EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// �ؼ�״̬��������
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {

            this.ToolBarItemAdd(28, "btnSaveAuth", "����Ȩ��Ⱥ", false, btnSaveAuth_Click);
            this.ToolBarItemAdd(28, "btnSelectAll", "ȫѡ", false, btnSelectAll_Click);
            this.ToolBarItemAdd(28, "btnSelectOpp", "��ѡ", false, btnSelectOpp_Click);

            ProcessTreeList.BindTreeColumn(treeList1, this.FormID);//����				
            ProcessTreeList.SetTreeColumnUI(treeList1);//������UI
            this.HTDataTableName = "Data_AuthGrp";
            //this.HTDataDts = treeList1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] {  };
            this.HTSubmitFlagFieldName = "";
            this.HTDelFlagFieldName = "";
            SetTabIndex(0, groupControlMainten);

            BindTreeList();

        }

        /// <summary>
        /// ������ʼ��
        /// </summary>
        public override void IniInsertSet()
        {
          
        }


        /// <summary>
        /// �༭���ݳ�ʼ���ؼ�����(��Щֵ��Ҫ���õ��趨һ��)
        /// </summary>
        public override void IniUpdateSet()
        {
            txtID.Properties.ReadOnly = true;
        }
        #endregion

        #region �����޸�ɾ��
        /// <summary>
        /// ����У��
        /// </summary>
        public override bool CheckCorrect()
        {
            if (txtID.Text.Trim() == "1")
            {
                this.ShowMessage("IDΪ1��Ȩ�޲�����༭");
                return false;
            }
            if (txtID.Text.Trim() == "")
            {
                this.ShowMessage("������ID");
                txtID.Focus();
                return false;
            }

            if (txtCode.Text.Trim() == "")
            {
                this.ShowMessage("���������");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("����������");
                txtName.Focus();
                return false;
            }
            return true;
        }


        /// <summary>
        /// ����
        /// </summary>
        public override int EntityAdd()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();

            rule.RAdd(entity);
            return entity.ID;
            
        }

        /// <summary>
        /// �޸�
        /// </summary>
        public override void EntityUpdate()
        {
            AuthGrpRule rule = new AuthGrpRule();
            AuthGrp entity = EntityGet();


            rule.RUpdate(entity);
        }

        /// <summary>
        /// ��ȡʵ��
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

        #region ���Ӱ�ť�¼�
        /// <summary>
        /// ����Ȩ��Ⱥ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnSaveAuth_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTFormStatus == FormStatus.��ѯ)
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
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTFormStatus == FormStatus.��ѯ)
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
        /// ��ѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void btnSelectOpp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.����))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                if (HTFormStatus == FormStatus.��ѯ)
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

        #region treelist��ط���
        /// <summary>
        /// ����Ĭ�ϵ�ֵ
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
        /// ���ʵ��
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
        /// ���ArrayList
        /// </summary>
        /// <param name="p_Al">ArrayList</param>
        /// <param name="p_Nodes">�ڵ�����</param>
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
                    if (SysConvert.ToString(p_Nodes[i].GetValue("MenuID")) != string.Empty && SysConvert.ToInt32(p_Nodes[i].GetValue("ID")) != 0)//�в˵���ID��Ϊ0 && SysConvert.ToInt32(p_Nodes[i].GetValue("ParentID")) != 0 
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
        /// ���ArrayList
        /// </summary>
        /// <param name="p_Al">ArrayList</param>
        /// <param name="p_Nodes">�ڵ�����</param>
        /// <returns></returns>
        private void GetEntityWinListSub(ArrayList p_Al, TreeListNodes p_Nodes)
        {
            for (int i = 0; i < p_Nodes.Count; i++)
            {
                if (((CheckState)p_Nodes[i].Tag == CheckState.Checked || (CheckState)p_Nodes[i].Tag == CheckState.Indeterminate))
                {
                    if (SysConvert.ToString(p_Nodes[i].GetValue("MenuID")) == string.Empty)//�޲˵�ID
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
        /// ���ʵ��
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
        /// ��TreeList
        /// </summary>
        private void BindTreeList()
        {
            treeList1.Nodes.Clear();
            DataTable dt = GetTreeListTable();
            ProcessTreeList.BindTreeList(dt, treeList1, "MenuID", "ParentID", 0, true);
        }

        /// <summary>
        /// ȡ��TreeList����Դ
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
                string nowid = dtwinlistsub.Rows[i]["WinListID"].ToString();//������winlistID
                ArrayList al = new ArrayList();//�Ѿ������ڲ˵�����Ĵ�������
                for (int j = 0; j < wincount; j++)//ѭ����������
                {
                    if (dtwinlist.Rows[j]["ID"].ToString() == nowid)
                    {
                        al.Add(new string[3] { dtwinlist.Rows[j]["MenuID"].ToString(), dtwinlist.Rows[j]["HeadTypeID"].ToString(), dtwinlist.Rows[j]["SubTypeID"].ToString() });//���MenuID,HeadTypeID,SubTypeID
                    }
                }

                for (int j = 0; j < al.Count; j++)//ѭ�������Ѿ����ڵĵĴ���˵�
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
        /// ����Treelistֵ
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
        /// �����Ƿ����
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
        /// ����treeList1��ѡ��״̬
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
        /// ��ѡ
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


        #region treelist�¼�
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