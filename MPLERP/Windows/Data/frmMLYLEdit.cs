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
using DevExpress.XtraEditors.Controls;

using HttSoft.WinUIBase;
namespace MLTERP
{
    /// <summary>
    /// 功能：原料管理
    /// 作者：王焕梅
    /// 日期：2012-04-24
    /// 操作：新增
    /// </summary>
    
    
    
    public partial class frmMLYLEdit : frmAPBaseUISinEdit
    {
        public frmMLYLEdit()
        {
            InitializeComponent();
        }
     

        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
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
           
            MLYLRule rule = new MLYLRule();
            MLYL entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
           
            MLYLRule rule = new MLYLRule();
            MLYL entity = EntityGet();
            rule.RUpdate(entity);
            
            
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            MLYL entity = new MLYL();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            txtSort.Text = entity.Sort.ToString(); 
  			txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpUseableFlag.EditValue = entity.UseableFlag;
            

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            MLYLRule rule = new MLYLRule();
            MLYL entity = EntityGet();
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
            this.HTDataTableName = "Data_MLYL";
            //
            
            
        }

        public override void IniInsertSet()
        {
            drpUseableFlag.EditValue = 1;
            DataTable dt = SysUtils.Fill("select max(Sort)+1 from Data_MLYL");
            txtSort.Text = dt.Rows[0][0].ToString();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private MLYL EntityGet()
        {
            MLYL entity = new MLYL();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Sort = SysConvert.ToInt32(txtSort.Text.Trim()); 
  			entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim();
            entity.UseableFlag = SysConvert.ToInt32(drpUseableFlag.EditValue); 
  			
            return entity;
        }

       
        #endregion

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtRemark_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}