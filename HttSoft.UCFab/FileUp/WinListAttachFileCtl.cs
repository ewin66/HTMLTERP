using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
	/// <summary>
	/// 目的：Data_WinListAttachFile实体控制类
	/// 作者:陈加海
	/// 创建日期:2014/4/23
	/// </summary>
	public sealed class WinListAttachFileCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public WinListAttachFileCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public WinListAttachFileCtl(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		
		/// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int AddNew(BaseEntity p_Entity)
        {
            try
            {
                WinListAttachFile MasterEntity=(WinListAttachFile)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_WinListAttachFile(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("WinListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WinListID)+","); 
  				MasterField.Append("HeadType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadType)+","); 
  				MasterField.Append("SubType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubType)+","); 
  				MasterField.Append("HTDataID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTDataID)+","); 
  				MasterField.Append("HTDataSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HTDataSeq)+","); 
  				MasterField.Append("FileProt1"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileProt1)+","); 
  				MasterField.Append("FileProt2"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileProt2)+","); 
  				MasterField.Append("FileProt3"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileProt3)+","); 
  				MasterField.Append("FileTitle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileTitle)+","); 
  				MasterField.Append("FileName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileName)+","); 
  				MasterField.Append("FileContext"+","); 
  				MasterValue.Append(@"@FileContext"+","); 
  				MasterField.Append("FileSize"+","); 
  				if(MasterEntity.FileSize!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FileSize)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UploadTime"+","); 
  				if(MasterEntity.UploadTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.UploadTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("UploadOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UploadOPID)+","); 
  				MasterField.Append("UploadOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UploadOPName)+","); 
  				MasterField.Append("UploadLoginLogID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.UploadLoginLogID)+","); 
  				MasterField.Append("FileTypeName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileTypeName)+","); 
  				MasterField.Append("FileExe"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FileExe)+","); 
  				MasterField.Append("Remark"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+")"); 
 
                
                 
  				object[,] obja= new object[2,1]; 
  				obja[0,0]="@FileContext"; 
  				obja[1,0]=MasterEntity.FileContext;

                //执行
                int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(),obja);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString(),obja);
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
               throw new BaseException(FrameWorkMessage.GetAlertMessage(10020),E);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Update(BaseEntity p_Entity)
        {
            try
            {
                WinListAttachFile MasterEntity=(WinListAttachFile)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_WinListAttachFile SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" WinListID="+SysString.ToDBString(MasterEntity.WinListID)+","); 
  				UpdateBuilder.Append(" HeadType="+SysString.ToDBString(MasterEntity.HeadType)+","); 
  				UpdateBuilder.Append(" SubType="+SysString.ToDBString(MasterEntity.SubType)+","); 
  				UpdateBuilder.Append(" HTDataID="+SysString.ToDBString(MasterEntity.HTDataID)+","); 
  				UpdateBuilder.Append(" HTDataSeq="+SysString.ToDBString(MasterEntity.HTDataSeq)+","); 
  				UpdateBuilder.Append(" FileProt1="+SysString.ToDBString(MasterEntity.FileProt1)+","); 
  				UpdateBuilder.Append(" FileProt2="+SysString.ToDBString(MasterEntity.FileProt2)+","); 
  				UpdateBuilder.Append(" FileProt3="+SysString.ToDBString(MasterEntity.FileProt3)+","); 
  				UpdateBuilder.Append(" FileTitle="+SysString.ToDBString(MasterEntity.FileTitle)+","); 
  				UpdateBuilder.Append(" FileName="+SysString.ToDBString(MasterEntity.FileName)+","); 
  				UpdateBuilder.Append(" FileContext=@FileContext"+","); 
  				 
  				if(MasterEntity.FileSize!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FileSize="+SysString.ToDBString(MasterEntity.FileSize)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FileSize=null,");  
  				} 
  
  				 
  				if(MasterEntity.UploadTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" UploadTime="+SysString.ToDBString(MasterEntity.UploadTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" UploadTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" UploadOPID="+SysString.ToDBString(MasterEntity.UploadOPID)+","); 
  				UpdateBuilder.Append(" UploadOPName="+SysString.ToDBString(MasterEntity.UploadOPName)+","); 
  				UpdateBuilder.Append(" UploadLoginLogID="+SysString.ToDBString(MasterEntity.UploadLoginLogID)+","); 
  				UpdateBuilder.Append(" FileTypeName="+SysString.ToDBString(MasterEntity.FileTypeName)+","); 
  				UpdateBuilder.Append(" FileExe="+SysString.ToDBString(MasterEntity.FileExe)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)); 
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                 
  				object[,] obja= new object[2,1]; 
  				obja[0,0]="@FileContext"; 
  				obja[1,0]=MasterEntity.FileContext;

               //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString(),obja);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString(),obja);
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage(10021), E);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Delete(BaseEntity p_Entity)
        {
            try
            {
                WinListAttachFile MasterEntity=(WinListAttachFile)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_WinListAttachFile WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
                //执行
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
                throw new BaseException(FrameWorkMessage.GetAlertMessage(10022), E);
            }
        }
	}
}
