using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface IAttachFileService
    {
        Task<List<AttactFileModel>> GetAttachmentByObjectId(long objectId, string objectType);
        Task<SaveResultModel<object>> SaveAttachment(AttactFileModel obj);
        Task DeleteAttactment(long attachId);
        Task<AttactFileModel> GetAttachmentById(long id);
        Task UpdateObjectId(long objectId,string fileAttachIdStr);
        Task<List<AttactFileModel>> GetAllAttachmentByObjectId(int id);
    }
}
