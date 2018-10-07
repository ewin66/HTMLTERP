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
using DevExpress.XtraGrid.Views.Base;



namespace MLTERP
{
    public partial class frmSetStructure : BaseForm
    {
        public frmSetStructure()
        {
            InitializeComponent();
        }

        

        private int m_ParentID;
        public int ParentID
        {
            get
            {
                return m_ParentID;
            }
            set
            {
                m_ParentID = value;
            }
        }

        private int m_StructureID;
        public int StructureID
        {
            get
            {
                return m_StructureID;
            }
            set
            {
                m_StructureID = value;
            }
        }

        private int m_StructureTypeID=1;//1.设置顶结构  2.设置子结构  3.更新结构
        public int StructureTypeID
        {
            get
            {
                return m_StructureTypeID;
            }
            set
            {
                m_StructureTypeID = value;
            }
        }



       
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {

                switch (m_StructureTypeID)
                {
                    case 1:
                        this.Text = "设置顶结构";
                        break;
                    case 2:
                        this.Text = "设置子结构";
                        break;
                    case 3:
                        this.Text = "更新结构";
                        Structure entity = new Structure();
                        entity.ID = m_StructureID;
                        entity.SelectByID();
                        txtCode.Text = entity.Code;
                        txtName.Text = entity.Name;
                        m_ParentID = entity.ParentID;
                        break;
                }
               
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

       
      
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim() == "")
                {
                    this.ShowMessage("请输入编码");
                    txtCode.Focus();
                    return;
                }

                if (txtName.Text.Trim() == "")
                {
                    this.ShowMessage("请输入名称");
                    txtName.Focus();
                    return;
                }
                StructureRule rule = new StructureRule();
                Structure entity = new Structure();
                if (m_StructureID > 0)
                {
                    entity.ID = m_StructureID;
                    entity.SelectByID();
                }
                entity.Code = txtCode.Text.Trim();
                entity.Name = txtName.Text.Trim();
                switch (m_StructureTypeID)
                {
                    case 1:
                        rule.RAdd(entity);
                        StructureID = entity.ID;
                        break;
                    case 2:
                        entity.ParentID = m_ParentID;
                        rule.RAdd(entity);
                        StructureID = entity.ID;
                        break;
                    case 3:
                        rule.RUpdate(entity);
                        break;
                }
                this.ShowInfoMessage("设置成功！");
                this.Close();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        


    }

}