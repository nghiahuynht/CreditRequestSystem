using DAL.IService;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class AttachFileService: BaseService, IAttachFileService
    {
        private EntityDataContext dtx;
        public AttachFileService(EntityDataContext dtx)
        {
            this.dtx = dtx;
        }

        public async Task<List<AttactFileModel>> GetAttachmentByObjectId(long objectId,string objectType)
        {
            List<AttactFileModel> rs = new List<AttactFileModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@ObjectId", objectId),
                    new SqlParameter("@ObjectType", objectType)
                };
                ValidNullValue(param);
                rs = await dtx.AttactFileModel.FromSql(@"EXEC sp_GetAttachmentByObjectId @ObjectId,@ObjectType", param).ToListAsync();
                return rs;
            }
            catch (Exception ex)
            {
                return rs;
            }
        }


        public async Task<AttactFileModel> GetAttachmentById(long id)
        {
            AttactFileModel rs = new AttactFileModel();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", id),
                };
                ValidNullValue(param);
                rs = await dtx.AttactFileModel.FromSql(@"EXEC sp_GetAttachmentById @Id", param).FirstOrDefaultAsync();
                return rs;
            }
            catch (Exception ex)
            {
                return rs;
            }
        }




        public async Task<SaveResultModel<object>> SaveAttachment(AttactFileModel obj)
        {
            var res = new SaveResultModel<object>();
            res.Data = null;
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@ObjectType", obj.ObjectType),
                    new SqlParameter("@FileName", obj.FileName),
                    new SqlParameter("@FilePath", obj.FilePath),
                    new SqlParameter("@URLPath", obj.URLPath),
                    new SqlParameter("@Size", obj.Size),
                    new SqlParameter("@CreatedBy", obj.CreatedBy),
                    new SqlParameter { ParameterName = "@NewId", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Output }

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_InsertUpdateAttactFile @ObjectType,@FileName,@FilePath,@URLPath,@Size,@CreatedBy,@NewId OUT", param);
                res.LongValReturn = Convert.ToInt64(param[param.Length - 1].Value);

            }
            catch (Exception ex)
            {
                res.ErrorMessage = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task DeleteAttactment(long attachId)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", attachId),

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_DeleteAttachFile @Id", param);

            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdateObjectId(long objectId, string fileAttachIdStr)
        {
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@ObjectId", objectId),
                    new SqlParameter("@FileAttachIdStr", fileAttachIdStr),

                };
                ValidNullValue(param);
                await dtx.Database.ExecuteSqlCommandAsync(@"EXEC sp_UpdateObjectIdFileAttach @ObjectId,@FileAttachIdStr", param);

            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<AttactFileModel>> GetAllAttachmentByObjectId(int id)
        {
            List<AttactFileModel> rs = new List<AttactFileModel>();
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@Id", id),
                };
                ValidNullValue(param);
                rs =  await dtx.AttactFileModel.FromSql(@"EXEC sp_GetFileAttachByObjectId @Id", param).ToListAsync();
                return rs;
            }
            catch (Exception ex)
            {
                return rs;
            }
        }
    }
}
