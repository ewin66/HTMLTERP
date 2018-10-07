using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;

namespace MLTERP
{

    /// <summary>
    /// 系统产品参数初始化
    /// </summary>
    public class ParamConfigIni
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void PIni()
        {
            ParamSetRule psrule = new ParamSetRule();
            //ParamConfig.WHIDRightFlag= SysConvert.ToBoolean( psrule.RShowIntByID((int)ParamSetEnum.仓库开启库别权限校验));


            //ParamConfig.WHMLMDCheckQtyFlag = SysConvert.ToBoolean(psrule.RShowIntByID((int)ParamSetEnum.面料仓库单据验证码单和单据明细数量一致性));
        }
    }
}
