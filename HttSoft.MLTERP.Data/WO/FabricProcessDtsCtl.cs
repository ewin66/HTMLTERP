using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;

namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// Ŀ�ģ�WO_FabricProcessDtsʵ�������
	/// ����:zhp
	/// ��������:2016/9/22
	/// </summary>
	public sealed class FabricProcessDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// ���캯��
        /// </summary>
        public FabricProcessDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// ���캯��
        /// </summary>
        public FabricProcessDtsCtl(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		
		/// <summary>
        /// ����
        /// </summary>
        /// <param name="p_Entity">ʵ����</param>
        /// <returns>����Ӱ��ļ�¼����</returns>
        public override int AddNew(BaseEntity p_Entity)
        {
            try
            {
                FabricProcessDts MasterEntity=(FabricProcessDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_FabricProcessDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("MWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				MasterField.Append("MWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				MasterField.Append("WeightUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("SingPrice"+","); 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SingPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Amount"+","); 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedDate"+","); 
  				if(MasterEntity.ReceivedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReceivedQty"+","); 
  				if(MasterEntity.ReceivedQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReceivedQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalRecQty"+","); 
  				if(MasterEntity.TotalRecQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalRecQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RemainQty"+","); 
  				if(MasterEntity.RemainQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RemainQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("RemainRate"+","); 
  				if(MasterEntity.RemainRate!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.RemainRate)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsReqDate"+","); 
  				if(MasterEntity.DtsReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DtsReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("OrderPreStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderPreStatusID)+","); 
  				MasterField.Append("OrderStatusID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderStatusID)+","); 
  				MasterField.Append("DtsSO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				MasterField.Append("DVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				MasterField.Append("NLQty"+","); 
  				if(MasterEntity.NLQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NLQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("NLFormDate"+","); 
  				if(MasterEntity.NLFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NLFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InQty"+","); 
  				if(MasterEntity.InQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InFormDate"+","); 
  				if(MasterEntity.InFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OutQty"+","); 
  				if(MasterEntity.OutQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OutQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OutFormDate"+","); 
  				if(MasterEntity.OutFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OutFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PieceQty"+","); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("GreyFabItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GreyFabItemCode)+","); 
  				MasterField.Append("CalNum"+","); 
  				if(MasterEntity.CalNum!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CalNum)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CalUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CalUnit)+","); 
  				MasterField.Append("DtsRemark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsRemark)+","); 
  				MasterField.Append("DesignNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DesignNo)+","); 
  				MasterField.Append("EditionOK"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.EditionOK)+","); 
  				MasterField.Append("FreeStr1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				MasterField.Append("FreeStr2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				MasterField.Append("FreeStr3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				MasterField.Append("FreeStr4"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				MasterField.Append("FreeStr5"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				MasterField.Append("SL"+","); 
  				if(MasterEntity.SL!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SL)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PBWeight"+","); 
  				if(MasterEntity.PBWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PBWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				MasterField.Append("CPItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				MasterField.Append("CPItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				MasterField.Append("CPItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CPItemModel)+","); 
  				MasterField.Append("Machine"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Machine)+","); 
  				MasterField.Append("Needle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+","); 
  				MasterField.Append("DtsAfterFinish"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsAfterFinish)+","); 
  				MasterField.Append("DtsPackMethod"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsPackMethod)+","); 
  				MasterField.Append("AddFee"+","); 
  				if(MasterEntity.AddFee!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee2"+","); 
  				if(MasterEntity.AddFee2!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee2)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee3"+","); 
  				if(MasterEntity.AddFee3!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee3)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee4"+","); 
  				if(MasterEntity.AddFee4!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee4)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AddFee5"+","); 
  				if(MasterEntity.AddFee5!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.AddFee5)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PUnit)+","); 
  				MasterField.Append("StyleNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("HandleStatus"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HandleStatus)+","); 
  				MasterField.Append("HandleStatusDate"+","); 
  				if(MasterEntity.HandleStatusDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.HandleStatusDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("AllMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AllMWidth)+","); 
  				MasterField.Append("OrderQty"+","); 
  				if(MasterEntity.OrderQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OrderQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OrderUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderUnit)+","); 
  				MasterField.Append("BCPItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemCode)+","); 
  				MasterField.Append("BCPItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemStd)+","); 
  				MasterField.Append("BCPItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemName)+","); 
  				MasterField.Append("BCPItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPItemModel)+","); 
  				MasterField.Append("PieceWeight"+","); 
  				if(MasterEntity.PieceWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("BCPColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPColorNum)+","); 
  				MasterField.Append("BCPColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPColorName)+","); 
  				MasterField.Append("BCPMWidth"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPMWidth)+","); 
  				MasterField.Append("BCPMWeight"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BCPMWeight)+","); 
  				MasterField.Append("BoxQty"+","); 
  				if(MasterEntity.BoxQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.BoxQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SetQty"+","); 
  				if(MasterEntity.SetQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SetQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DozensQty"+","); 
  				if(MasterEntity.DozensQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DozensQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("LoadFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.LoadFormNo)+","); 
  				MasterField.Append("VOrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VOrderFormNo)+","); 
  				MasterField.Append("CPInQty"+","); 
  				if(MasterEntity.CPInQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CPInQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CPInDate"+")"); 
  				if(MasterEntity.CPInDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CPInDate.ToString("yyyy-MM-dd HH:mm:ss"))+")"); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null)"); 
  				} 
  
 
                
                

                //ִ��
                int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
               throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBInsert),E);
            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="p_Entity">ʵ����</param>
        /// <returns>����Ӱ��ļ�¼����</returns>
        public override int Update(BaseEntity p_Entity)
        {
            try
            {
                FabricProcessDts MasterEntity=(FabricProcessDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //������������
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_FabricProcessDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				UpdateBuilder.Append(" WeightUnit="+SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.SingPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice="+SysString.ToDBString(MasterEntity.SingPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SingPrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedDate="+SysString.ToDBString(MasterEntity.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReceivedQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedQty="+SysString.ToDBString(MasterEntity.ReceivedQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReceivedQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalRecQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecQty="+SysString.ToDBString(MasterEntity.TotalRecQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalRecQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.RemainQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RemainQty="+SysString.ToDBString(MasterEntity.RemainQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RemainQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.RemainRate!=0) 
  				{ 
  			 		UpdateBuilder.Append(" RemainRate="+SysString.ToDBString(MasterEntity.RemainRate)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" RemainRate=null,");  
  				} 
  
  				 
  				if(MasterEntity.DtsReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" DtsReqDate="+SysString.ToDBString(MasterEntity.DtsReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DtsReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" OrderPreStatusID="+SysString.ToDBString(MasterEntity.OrderPreStatusID)+","); 
  				UpdateBuilder.Append(" OrderStatusID="+SysString.ToDBString(MasterEntity.OrderStatusID)+","); 
  				UpdateBuilder.Append(" DtsSO="+SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				UpdateBuilder.Append(" DVendorID="+SysString.ToDBString(MasterEntity.DVendorID)+","); 
  				 
  				if(MasterEntity.NLQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NLQty="+SysString.ToDBString(MasterEntity.NLQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NLQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.NLFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" NLFormDate="+SysString.ToDBString(MasterEntity.NLFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NLFormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.InQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InQty="+SysString.ToDBString(MasterEntity.InQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.InFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" InFormDate="+SysString.ToDBString(MasterEntity.InFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InFormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.OutQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OutQty="+SysString.ToDBString(MasterEntity.OutQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OutQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.OutFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" OutFormDate="+SysString.ToDBString(MasterEntity.OutFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OutFormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" GreyFabItemCode="+SysString.ToDBString(MasterEntity.GreyFabItemCode)+","); 
  				 
  				if(MasterEntity.CalNum!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CalNum="+SysString.ToDBString(MasterEntity.CalNum)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CalNum=null,");  
  				} 
  
  				UpdateBuilder.Append(" CalUnit="+SysString.ToDBString(MasterEntity.CalUnit)+","); 
  				UpdateBuilder.Append(" DtsRemark="+SysString.ToDBString(MasterEntity.DtsRemark)+","); 
  				UpdateBuilder.Append(" DesignNo="+SysString.ToDBString(MasterEntity.DesignNo)+","); 
  				UpdateBuilder.Append(" EditionOK="+SysString.ToDBString(MasterEntity.EditionOK)+","); 
  				UpdateBuilder.Append(" FreeStr1="+SysString.ToDBString(MasterEntity.FreeStr1)+","); 
  				UpdateBuilder.Append(" FreeStr2="+SysString.ToDBString(MasterEntity.FreeStr2)+","); 
  				UpdateBuilder.Append(" FreeStr3="+SysString.ToDBString(MasterEntity.FreeStr3)+","); 
  				UpdateBuilder.Append(" FreeStr4="+SysString.ToDBString(MasterEntity.FreeStr4)+","); 
  				UpdateBuilder.Append(" FreeStr5="+SysString.ToDBString(MasterEntity.FreeStr5)+","); 
  				 
  				if(MasterEntity.SL!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SL="+SysString.ToDBString(MasterEntity.SL)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SL=null,");  
  				} 
  
  				 
  				if(MasterEntity.PBWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PBWeight="+SysString.ToDBString(MasterEntity.PBWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PBWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" CPItemCode="+SysString.ToDBString(MasterEntity.CPItemCode)+","); 
  				UpdateBuilder.Append(" CPItemName="+SysString.ToDBString(MasterEntity.CPItemName)+","); 
  				UpdateBuilder.Append(" CPItemStd="+SysString.ToDBString(MasterEntity.CPItemStd)+","); 
  				UpdateBuilder.Append(" CPItemModel="+SysString.ToDBString(MasterEntity.CPItemModel)+","); 
  				UpdateBuilder.Append(" Machine="+SysString.ToDBString(MasterEntity.Machine)+","); 
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)+","); 
  				UpdateBuilder.Append(" DtsAfterFinish="+SysString.ToDBString(MasterEntity.DtsAfterFinish)+","); 
  				UpdateBuilder.Append(" DtsPackMethod="+SysString.ToDBString(MasterEntity.DtsPackMethod)+","); 
  				 
  				if(MasterEntity.AddFee!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee="+SysString.ToDBString(MasterEntity.AddFee)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee2!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee2="+SysString.ToDBString(MasterEntity.AddFee2)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee2=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee3!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee3="+SysString.ToDBString(MasterEntity.AddFee3)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee3=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee4!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee4="+SysString.ToDBString(MasterEntity.AddFee4)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee4=null,");  
  				} 
  
  				 
  				if(MasterEntity.AddFee5!=0) 
  				{ 
  			 		UpdateBuilder.Append(" AddFee5="+SysString.ToDBString(MasterEntity.AddFee5)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" AddFee5=null,");  
  				} 
  
  				UpdateBuilder.Append(" PUnit="+SysString.ToDBString(MasterEntity.PUnit)+","); 
  				UpdateBuilder.Append(" StyleNo="+SysString.ToDBString(MasterEntity.StyleNo)+","); 
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" HandleStatus="+SysString.ToDBString(MasterEntity.HandleStatus)+","); 
  				 
  				if(MasterEntity.HandleStatusDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" HandleStatusDate="+SysString.ToDBString(MasterEntity.HandleStatusDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" HandleStatusDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" AllMWidth="+SysString.ToDBString(MasterEntity.AllMWidth)+","); 
  				 
  				if(MasterEntity.OrderQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OrderQty="+SysString.ToDBString(MasterEntity.OrderQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OrderQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" OrderUnit="+SysString.ToDBString(MasterEntity.OrderUnit)+","); 
  				UpdateBuilder.Append(" BCPItemCode="+SysString.ToDBString(MasterEntity.BCPItemCode)+","); 
  				UpdateBuilder.Append(" BCPItemStd="+SysString.ToDBString(MasterEntity.BCPItemStd)+","); 
  				UpdateBuilder.Append(" BCPItemName="+SysString.ToDBString(MasterEntity.BCPItemName)+","); 
  				UpdateBuilder.Append(" BCPItemModel="+SysString.ToDBString(MasterEntity.BCPItemModel)+","); 
  				 
  				if(MasterEntity.PieceWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceWeight="+SysString.ToDBString(MasterEntity.PieceWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" BCPColorNum="+SysString.ToDBString(MasterEntity.BCPColorNum)+","); 
  				UpdateBuilder.Append(" BCPColorName="+SysString.ToDBString(MasterEntity.BCPColorName)+","); 
  				UpdateBuilder.Append(" BCPMWidth="+SysString.ToDBString(MasterEntity.BCPMWidth)+","); 
  				UpdateBuilder.Append(" BCPMWeight="+SysString.ToDBString(MasterEntity.BCPMWeight)+","); 
  				 
  				if(MasterEntity.BoxQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" BoxQty="+SysString.ToDBString(MasterEntity.BoxQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" BoxQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.SetQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SetQty="+SysString.ToDBString(MasterEntity.SetQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SetQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.DozensQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DozensQty="+SysString.ToDBString(MasterEntity.DozensQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DozensQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" LoadFormNo="+SysString.ToDBString(MasterEntity.LoadFormNo)+","); 
  				UpdateBuilder.Append(" VOrderFormNo="+SysString.ToDBString(MasterEntity.VOrderFormNo)+","); 
  				 
  				if(MasterEntity.CPInQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" CPInQty="+SysString.ToDBString(MasterEntity.CPInQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPInQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.CPInDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CPInDate="+SysString.ToDBString(MasterEntity.CPInDate.ToString("yyyy-MM-dd HH:mm:ss"))); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CPInDate=null");  
  				} 
  
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                

               //ִ��
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBUpdate),E);
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="p_Entity">ʵ����</param>
        /// <returns>����Ӱ��ļ�¼����</returns>
        public override int Delete(BaseEntity p_Entity)
        {
            try
            {
                FabricProcessDts MasterEntity=(FabricProcessDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //ɾ����������
                string Sql="";
                Sql="DELETE FROM WO_FabricProcessDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
                //ִ��
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(Sql);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(Sql);
				}

                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBDelete),E);
            }
        }
	}
}
