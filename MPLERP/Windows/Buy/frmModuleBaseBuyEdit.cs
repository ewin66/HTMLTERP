using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.MLTERP.Sys;
using HttSoft.MLTERP.DataCtl;
using HttSoft.Framework;
using HttSoft.FrameFunc;
using HttSoft.WinUIBase;

namespace MLTERP
{

    /// <summary>
    /// 采购单据编辑页面 --模块基类
    /// 陈加海
    /// 2014-5-22
    /// 目的，把所有相关可抽取出来的功能进行抽离处理，便于后续改进统一进行
    /// </summary>
    public partial class frmModuleBaseBuyEdit : frmAPBaseUIFormEdit
    {
        public frmModuleBaseBuyEdit()
        {
            InitializeComponent();
        }
    }
}