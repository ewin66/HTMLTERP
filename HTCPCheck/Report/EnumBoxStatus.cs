using System;
using System.Collections.Generic;
using System.Text;

namespace HttSoft.HTERP.Sys
{
    public enum EnumBoxStatus
    {

        δ���=1,
        ���=2,
        ����=3,
    }



    ///// <summary>
    ///// �ֿ��������
    ///// </summary>
    public enum WHCalMethodFieldName
    {
        WHID = 1,
        SectionID = 2,
        SBitID = 3,
        ItemCode = 4,
        ColorNum = 5,
        ColorName = 6,
        JarNum = 7,
        VendorID = 8,
        MWidth = 9,
        MWeight = 10,
        GoodsCode = 11,
        GoodsLevel = 12,
        Batch = 13,
        VendorBatch = 14,
        Unit = 15,
        // Batch = 19,
        FabricTypeCode = 20,
        FabricType = 21,
        WHTypeID = 22,
        SizeName = 23,


    }


    /// <summary>
    /// �������ݷ�������
    /// </summary>
    public enum EnumFillDataType
    {
        �ɹ����Ƶ���׼����� = 1,

        ���۶����Ƶ���׼������������� = 10,

        �ɹ�����׼����� = 100,   //ֻ�����ڳ�Ʒ���ϲɹ�
        //����ɴ�߲ɹ������=101,
        ���۳����׼����� = 102,

        ���۳�����������۶������� = 110,
        //��������׼����� = 105,
        //�������۳����׼����� = 107,

        //Ⱦ���ӹ������׼�����=108,
        //Ⱦ���ӹ�����׼�����=109,

        //ӡ���ӹ������׼����� = 110,
        //ӡ���ӹ�����׼����� = 111,

        //֯��ӹ������׼�����=112,
        //֯��ӹ�����׼�����=113,



        //��Ʒ�·���ͳһ200����
        �ɹ�������׼����� = 201,


        �ӹ�������׼����� = 210,
        //�ӹ��������׼�����=211,
    }


    /// <summary>
    /// ���˱�־
    /// </summary>
    public enum EnumDZFlag
    {
        ������ = 0,
        ������ = 1,
        ���ʸ� = 2,
    }

}
