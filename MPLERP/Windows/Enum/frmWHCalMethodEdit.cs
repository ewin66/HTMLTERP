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
    public partial class frmWHCalMethodEdit : frmAPBaseUISinEdit
    {
        public frmWHCalMethodEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            
            WHCalMethodRule rule = new WHCalMethodRule();
            WHCalMethod entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            WHCalMethodRule rule = new WHCalMethodRule();
            WHCalMethod entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            WHCalMethod entity = new WHCalMethod();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString(); 
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtFieldName.Text = entity.FieldName.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WHCalMethodRule rule = new WHCalMethodRule();
            WHCalMethod entity = EntityGet();
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
            this.HTDataTableName = "Enum_WHCalMethod";
            //
        }
        public override void IniInsertSet()
        {

            string sql = "SELECT MAX(Code) FROM Enum_WHCalMethod";
            DataTable dt = SysUtils.Fill(sql);
            string maxVendor = string.Empty;
            if (dt.Rows.Count != 0)
            {
                maxVendor = dt.Rows[0][0].ToString();
            }
            int max = 0;
            max = SysConvert.ToInt32(maxVendor);
            max++;
            txtCode.Text = max.ToString();


        

        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private WHCalMethod EntityGet()
        {
            WHCalMethod entity = new WHCalMethod();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.FieldName = txtFieldName.Text.Trim(); 
  			
            return entity;
        }
        #endregion
    }
}