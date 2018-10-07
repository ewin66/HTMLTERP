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
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmCLSListEdit : frmAPBaseUISinEdit
    {
        public frmCLSListEdit()
        {
            InitializeComponent();
        }
        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtCLSA.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入大类");
            //    txtCLSA.Focus();
            //    return false;
            //}
            //if (txtCLSB.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入小类");
            //    txtCLSB.Focus();
            //    return false;
            //}            
            if (txtCLSDESC.Text.Trim() == "")
            {
                this.ShowMessage("请输入描述");
                txtCLSDESC.Focus();
                return false;
            }
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            CLSListRule rule = new CLSListRule();
            CLSList entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            CLSListRule rule = new CLSListRule();
            CLSList entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            CLSList entity = new CLSList();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCLSA.Text = entity.CLSA.ToString();
            txtCLSB.Text = entity.CLSB.ToString();
            txtCLSDESC.Text = entity.CLSDESC.ToString();         
            if (!findFlag)//处理默认值
            {
            }
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            CLSListRule rule = new CLSListRule();
            CLSList entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_CLSList";
            //Common.BindCLSList(drpCLSList, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private CLSList EntityGet()
        {
            CLSList entity = new CLSList();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.CLSA = txtCLSA.Text.Trim();
            entity.CLSB = txtCLSB.Text.Trim();
            entity.CLSDESC = txtCLSDESC.Text.Trim();

            return entity;
        }
        #endregion
    }
}