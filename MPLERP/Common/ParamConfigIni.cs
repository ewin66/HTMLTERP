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
    /// ϵͳ��Ʒ������ʼ��
    /// </summary>
    public class ParamConfigIni
    {
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public static void PIni()
        {
            ParamSetRule psrule = new ParamSetRule();
            //ParamConfig.WHIDRightFlag= SysConvert.ToBoolean( psrule.RShowIntByID((int)ParamSetEnum.�ֿ⿪�����Ȩ��У��));


            //ParamConfig.WHMLMDCheckQtyFlag = SysConvert.ToBoolean(psrule.RShowIntByID((int)ParamSetEnum.���ϲֿⵥ����֤�뵥�͵�����ϸ����һ����));
        }
    }
}
