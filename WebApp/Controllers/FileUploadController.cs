using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using NPOI.HPSF;

namespace WebApp.Controllers
{
    public class FileUploadController : AppBaseController
    {
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

                    // Trả về kết quả JSON
                    return Json(new
                    {
                        success = true,
                        message = "Tải lên thành công.",
                        filePath = $"/{currentDateFolder}/{fileName}" // Đường dẫn tương đối
                    });
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
    }
}
