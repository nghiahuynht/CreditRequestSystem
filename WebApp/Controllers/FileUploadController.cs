using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using NPOI.HPSF;
using DAL.Models;
using DAL.IService;
using Microsoft.Extensions.Configuration;

namespace WebApp.Controllers
{
    public class FileUploadController : AppBaseController
    {
        private IAttachFileService attachFileService;
        private IConfiguration config;
        public  FileUploadController( IAttachFileService attachFileService, ICommonService commonService, IConfiguration config)
        {
            this.attachFileService = attachFileService;
            this.config = config;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    // Đường dẫn tới thư mục wwwroot
                    string rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                    // Tạo thư mục con theo ngày hiện tại (11162024)
                    string currentDateFolder = DateTime.Now.ToString("MMddyyyy");
                    string uploadsFolder = Path.Combine(rootFolder, currentDateFolder);
                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Lấy tên file
                    string fileName = Path.GetFileName(file.FileName);

                    // Đường dẫn đầy đủ để lưu file
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    // Lưu file vào đường dẫn
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    // save db

                    long fileSizeInBytes = file.Length;
                    int fileSizeInKB = (int)(fileSizeInBytes / 1024.0);
                    var fName = file.FileName;
                    string domain = config["General:Domain"];
                    string urlPath = $"{domain}/{currentDateFolder}/{fName}";
                    var attachFile = new AttactFileModel
                    {
                        Id = 0,
                        ObjectType = "UploadFile",
                        FileName = fName,
                        FilePath = filePath,
                        URLPath = urlPath,
                        Size= fileSizeInKB,
                        CreatedBy = AuthenInfo().UserName
                    };
                    var rs = await attachFileService.SaveAttachment(attachFile);
                    if(rs.IsSuccess == true && rs.LongValReturn >0)
                    {
                        return Json(new
                        {
                            success = true,
                            message = "Tải lên thành công.",
                            filePath = $"/{currentDateFolder}/{fileName}" ,
                            fileName = fName,
                            fileNameAttactId= rs.LongValReturn
                        });
                    }    
                    else
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Lưu file thất bại",
                           
                        });
                    }    

                    
                }

                return Json(new
                {
                    success = false,
                    message = "Không có file nào được chọn.",
                  
                });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new
                {
                    success = false,
                    message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }

        [HttpGet]
        public IActionResult DeleteFile(long Id)
        {
            try
            {
                var rs =  attachFileService.DeleteAttactment(Id);
                return Json(new
                {
                    success = true,
                    message = "Tải lên thành công.",
                    fileNameAttactId = Id
                });

            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new
                {
                    success = false,
                    message = $"Đã xảy ra lỗi: {ex.Message}"
                });
            }
        }
    }
}
