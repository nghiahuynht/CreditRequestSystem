using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.IService;
using DAL.Models;
using DAL.Models.Category;
using DAL.Models.ProjectFinancialSummar;
using DAL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using WebApp.ExcelHelper;
using WebApp.ImportHelper;

namespace WebApp.Controllers
{
    public class CategoryController : AppBaseController
    {
        private ICategoryService categoryService;
        private IConfiguration config;
        public CategoryController(ICategoryService categoryService, IConfiguration config)
        {
            this.categoryService = categoryService;
            this.config = config;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveCategory([FromBody] Category category)
        {
            var res = new SaveResultModel<object>();
            if (category.Id == 0)
            {
                res = categoryService.CreateCategory(category,AuthenInfo().UserName);
            }
            else
            {
                res = categoryService.UpdateCategory(category, AuthenInfo().UserName);
            }
            return Json(res);
        }
        [HttpGet]
        public PartialViewResult _PartialCategorySearch(string keyword)
        {
            var res = categoryService.SearchCategory(keyword);
            return PartialView(res);
        }
        [HttpGet]
        public PartialViewResult _PartialCategoryDetail(int? categoryId)
        {
            var viewModel = new CategoryDetailViewModel();
            if(categoryId.HasValue)
            {
                viewModel.Category = categoryService.GetCategoryById(categoryId.Value);
            }
            else
            {
                viewModel.Category = new Category();
            }
            viewModel.ListParent = categoryService.LstAllCategoies();
            return PartialView(viewModel);
        }


        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            var res = categoryService.DeleteCategory(id, AuthenInfo().UserName);
            return Json(res);
        }

        #region DM Nhóm hoạt động

        public IActionResult NhomHoatDong()
        {
            ViewBag.Permissions = HttpContext.Session.GetString("Permission");
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryActiveGroupViewModel> GetDataActiveGroup(CategoryFilterModel filter)
        {
            var res = categoryService.GetActiveGroupByFilter(filter,false);
            return res;
        }
        public IActionResult _AddNhomHoatDong(int id = 0)
        {
            var viewModel = new CategoryActiveGroupViewModel();

            if (id > 0)
            {
                viewModel=categoryService.GetActiveGroupById(id);
                
            }
            else
            {
                viewModel.Id = 0;
            }
            return View(viewModel);


        }


        [HttpPost]
        public async Task<JsonResult> CreateActiveGroup([FromBody] CategoryActiveGroupViewModel model)
        {
            var res = new SaveResultModel<object>();

            res =await categoryService.CreateActiveGroup(model, User.Identity.Name);
            if(res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã nhóm hoạt động đã tồn tại!";

            }    
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeleteActiveGroup( int Id)
        {
            try
            {
                var rs = await categoryService.DeleteActiveGroup(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại.Đã phát sinh hồ sơ thanh toán",
                    projectId = Id
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
        public JsonResult GetActiveGroupAllocationByProductId(int Id)
        {
            try
            {

                var rs = categoryService.LstCategoryActiveGroupAllocationByProductId(Id);
                return Json(new
                {
                    isSuccess = true,
                    data = rs

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


        [HttpPost]
        public IActionResult ReadFileImportActiveGroup(IFormFile file)
        {
            // Get all DM Trung Tam
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<CategoryActiveGroupViewModel> lstProject = new List<CategoryActiveGroupViewModel>();
            if (file == null || file.Length == 0)
                return BadRequest("File không hợp lệ");
            string[] permittedExtensions = { ".xlsx", ".xls" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return BadRequest("File không hợp lệ");
            }
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    int rows = worksheet.Dimension.Rows;
                    int columns = worksheet.Dimension.Columns;
                    // Check number rows
                    if (rows > 201)
                    {
                        return BadRequest("File vượt quá số dòng tối đa (200 dòng)");
                    }
                    int indexHaveData = 1;
                    for (int row = 2; row <= rows; row++)
                    {

                        if (columns > 0 && row > 1)
                        {
                            object tenNhomHoatDong = worksheet.Cells[row, 1].Value;

                            


                            if (string.IsNullOrEmpty(tenNhomHoatDong?.ToString()))
                            {
                                return BadRequest("Tên nhóm hoạt động không được bỏ trống");
                            }



                            CategoryActiveGroupViewModel item = new CategoryActiveGroupViewModel
                            {

                               Code = "",
                               Name = tenNhomHoatDong.ToString()

                            };
                            lstProject.Add(item);
                        }
                    }
                }
            }
            return Json(new
            {
                data = lstProject,
                Status = "Success"
            });

        }

        [HttpPost]
        public async Task<IActionResult> ImportActiveGroup([FromBody] List<CategoryActiveGroupViewModel> data)
        {

            try
            {
                List<ResImportActiveGroupModel> resImport = new List<ResImportActiveGroupModel>();
                foreach (var item in data)
                {
                    var res = await categoryService.CreateActiveGroup(item, AuthenInfo().UserName);
                    string ms = "Thành công";
                    if (res.LongValReturn < 0)
                    {
                        if (res.LongValReturn == -409)
                        {
                            ms = "Mã dự án đã tồn tại";
                        }
                        else
                        {
                            ms = "Thất bại";

                        }
                    };

                    resImport.Add(new ResImportActiveGroupModel()
                    {
                        item = item,
                        message = ms
                    });
                }
                return Json(new
                {
                    data = resImport,
                    Status = "Thành công"

                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    message = ex.Message,
                    Status = "Thất bại",

                });
            }


        }


        [HttpGet]
        public FileContentResult ExportNhomHoatDong(string filfer)
        {

            var filterModel = !string.IsNullOrEmpty(filfer) ? JsonConvert.DeserializeObject<CategoryFilterModel>(filfer) : new CategoryFilterModel();
            filterModel.start = 0;
            filterModel.start = 10000;
            var res = categoryService.GetActiveGroupByFilter(filterModel,true);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            Color colFromHex = ColorTranslator.FromHtml("#3377ff");
            Color colFromHexTextHeader = ColorTranslator.FromHtml("#ffffff");

            workSheet.Cells["A1"].Value = "Mã nhóm hoạt động";
            workSheet.Cells["B1"].Value = "Tên nhóm hoạt động";
            workSheet.Cells["C1"].Value = "Ghi chú";


            workSheet.Cells[1, 1, 1, 3].Style.Font.Bold = true;
            int rowData = 2;

            if (res.data.Any())
            {
                foreach (var item in res.data)
                {
                    workSheet.Cells["A" + rowData].Value = item.Code;
                    workSheet.Cells["B" + rowData].Value = item.Name;
                    workSheet.Cells["C" + rowData].Value = item.Notes;
                    rowData++;
                }
            }

            //Format table
            ExcelRange range = workSheet.Cells[1, 1, rowData - 1, workSheet.Dimension.End.Column];
            ExcelTable tab = workSheet.Tables.Add(range, "Table1");
            tab.TableStyle = OfficeOpenXml.Table.TableStyles.Medium2;
            //FreezePanes
            //workSheet.View.FreezePanes(1,13);

            workSheet.Column(1).Width = 10;
            workSheet.Column(2).Width = 30;
            workSheet.Column(3).Width = 30;

            return File(excel.GetAsByteArray(), ExcelExportHelper.ExcelContentType, "DanhSach-NhomHoatDong.xlsx");
        }




        #endregion

        #region DM  mục chi

        public IActionResult MucChi()
        {
            ViewBag.Permissions = HttpContext.Session.GetString("Permission");
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryExpenseTableViewModel> GetDataExpense(CategoryFilterModel filter)
        {
            var res = categoryService.GetExpenseByFilter(filter,false);
            return res;
        }


        [HttpGet]
        public FileContentResult ExportMucChi(string filfer)
        {

            var filterModel = !string.IsNullOrEmpty(filfer) ? JsonConvert.DeserializeObject<CategoryFilterModel>(filfer) : new CategoryFilterModel();
            filterModel.start = 0;
            filterModel.start = 10000;
            var res = categoryService.GetExpenseByFilter(filterModel, true);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            Color colFromHex = ColorTranslator.FromHtml("#3377ff");
            Color colFromHexTextHeader = ColorTranslator.FromHtml("#ffffff");

            workSheet.Cells["A1"].Value = "Tên nhóm hoạt động";
            workSheet.Cells["B1"].Value = "Mã mục chi";
            workSheet.Cells["C1"].Value = "Tên mục chi";
            workSheet.Cells["D1"].Value = "Tiểu mục";
            workSheet.Cells["E1"].Value = "Ghi chú";

            workSheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;
            int rowData = 2;

            if (res.data.Any())
            {
                foreach (var item in res.data)
                {
                    workSheet.Cells["A" + rowData].Value = item.ActiveGroupName;
                    workSheet.Cells["B" + rowData].Value = item.Code;
                    workSheet.Cells["C" + rowData].Value = item.Name;
                    workSheet.Cells["D" + rowData].Value = item.TieuMuc;
                    workSheet.Cells["E" + rowData].Value = item.Notes;
                    rowData++;
                }
            }

            //Format table
            ExcelRange range = workSheet.Cells[1, 1, rowData - 1, workSheet.Dimension.End.Column];
            ExcelTable tab = workSheet.Tables.Add(range, "Table1");
            tab.TableStyle = OfficeOpenXml.Table.TableStyles.Medium2;
            //FreezePanes
            //workSheet.View.FreezePanes(1,13);

            workSheet.Column(1).Width = 10;
            workSheet.Column(2).Width = 30;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 20;

            return File(excel.GetAsByteArray(), ExcelExportHelper.ExcelContentType, "DanhSach-MucChi.xlsx");
        }


        [HttpGet]
        public FileContentResult ExportMucChiTemplateForImport()
        {

            
            CategoryFilterModel filter = new CategoryFilterModel();
            filter.start = 0;
            filter.start = 10000;

            var res = categoryService.GetActiveGroupByFilter(filter, true);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage excel = new ExcelPackage();

            // Sheet 1

            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            Color colFromHex = ColorTranslator.FromHtml("#3377ff");
            Color colFromHexTextHeader = ColorTranslator.FromHtml("#ffffff");

            workSheet.Cells["A1"].Value = "Mã nhóm";
            workSheet.Cells["B1"].Value = "Mã mục chi";
            workSheet.Cells["C1"].Value = "Tên mục chi";
            workSheet.Cells["D1"].Value = "Tiểu mục";
            workSheet.Cells["E1"].Value = "Ghi chú";

            workSheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;
            
          
           
            //FreezePanes
            //workSheet.View.FreezePanes(1,13);

            workSheet.Column(1).Width = 10;
            workSheet.Column(2).Width = 30;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 20;



            // sheet2

            var workSheet2 = excel.Workbook.Worksheets.Add("NhomHoatDong");
            colFromHex = ColorTranslator.FromHtml("#3377ff");
            colFromHexTextHeader = ColorTranslator.FromHtml("#ffffff");

            workSheet2.Cells["A1"].Value = "Mã nhóm";
            workSheet2.Cells["B1"].Value = "Tên nhóm";

            workSheet2.Cells[1, 1, 1, 4].Style.Font.Bold = true;
            int rowData = 2;

            if (res.data.Any())
            {
                foreach (var item in res.data)
                {
                    workSheet2.Cells["A" + rowData].Value = item.Code;
                    workSheet2.Cells["B" + rowData].Value = item.Name;
                    rowData++;
                }
            }

            //Format table
            ExcelRange range = workSheet2.Cells[1, 1, rowData - 1, workSheet2.Dimension.End.Column];
            ExcelTable tab = workSheet2.Tables.Add(range, "Table1");
            tab.TableStyle = TableStyles.Medium2;


            workSheet2.Column(1).Width = 15;
            workSheet2.Column(2).Width = 30;


            return File(excel.GetAsByteArray(), ExcelExportHelper.ExcelContentType, "TemplateImportExpense.xlsx");
        }






        public IActionResult _AddMucChi(int id = 0)
        {
            var viewModel = new CategoryExpenseViewModel();
            var lstNhomHoatDong = categoryService.LstAllCategoryActiveGroup();
            if (id > 0)
            {
                viewModel = categoryService.GetExpenseById(id);

            }
            else
            {
                viewModel.Id = 0;
            }
            ViewBag.LstActiveGroup = lstNhomHoatDong;
            return View(viewModel);


        }


        [HttpPost]
        public JsonResult CreateExpense([FromBody] CategoryExpenseViewModel model)
        {
            var res = new SaveResultModel<object>();

            res = categoryService.CreateExpense(model, User.Identity.Name);
            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã mục chi đã tồn tại!";

            }
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeleteExpense(int Id)
        {
            try
            {
                var rs = await categoryService.DeleteExpense(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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

        public JsonResult GetExpenseByActiveGroup(int Id)
        {

            try
            {
                var rs = categoryService.GetExpenseByActiveGroup(Id);
                return Json(new
                {
                    isSuccess = true,
                    data = rs

                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    isSuccess = false,
                    message = ex.Message

                });
            }
            
        }

        //[HttpPost]
        //public IActionResult DowloadTemplateImportExpense()
        //{
        //    // Path to the template Excel file
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //    string templateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template", "TemplateImportExpense.xlsx");

        //    var lstDataActiveGroup = categoryService.LstAllCategoryActiveGroup();
        //    // Load the template Excel file
        //    using (var package = new ExcelPackage(new FileInfo(templateFilePath)))
        //    {

        //        // Access the second sheet (Sheet2)
        //        var worksheet = package.Workbook.Worksheets[1];  // Worksheet index starts at 0, so index 1 is the second sheet

        //        // Starting row and column
        //        int startRow = 3;
        //        int startColumn = 1;  // Column B

        //        // Insert data into the sheet starting at the specified row and column
        //        for (int i = 0; i < lstDataActiveGroup.Count; i++)
        //        {
        //            worksheet.Cells[startRow, 1].Value = lstDataActiveGroup[i].Code;
        //            worksheet.Cells[startRow, 2].Value = lstDataActiveGroup[i].Code+"_"+lstDataActiveGroup[i].Name;
        //            startRow++;
        //        }

        //        // Save the modified Excel file to a memory stream
        //        var memoryStream = new MemoryStream();
        //        package.SaveAs(memoryStream);
        //        memoryStream.Position = 0; // Reset the stream position to the beginning

        //        // Return the file as a download
        //        var fileName = "TemplateImportExpense.xlsx";
        //        return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        //    }
        //}

        [HttpPost]
        public IActionResult ReadFileImportExpense(IFormFile file)
        {
            // Get all DM Trung Tam
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var lstNhomHoatDong = categoryService.LstAllCategoryActiveGroup();
            List<CategoryExpenseViewImportModel> lstProject = new List<CategoryExpenseViewImportModel>();
            if (file == null || file.Length == 0)
                return BadRequest("File không hợp lệ");
            string[] permittedExtensions = { ".xlsx", ".xls" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return BadRequest("File không hợp lệ");
            }
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    int rows = worksheet.Dimension.Rows;
                    int columns = worksheet.Dimension.Columns;
                    // Check number rows
                    if (rows > 201)
                    {
                        return BadRequest("File vượt quá số dòng tối đa (200 dòng)");
                    }
                    int indexHaveData = 2;
                    for (int row = 2; row <= rows; row++)
                    {

                        if (columns > 0 && row > 2)
                        {
                            object nhomHoatDong = worksheet.Cells[row, 1].Value;
                            object maMucChi = worksheet.Cells[row, 2].Value;
                            object tenMucChi= worksheet.Cells[row, 3].Value;
                            object tieumuc = worksheet.Cells[row, 4].Value;
                            object ghiChu= worksheet.Cells[row, 5].Value;



                            if (string.IsNullOrEmpty(nhomHoatDong?.ToString()))
                            {
                                return BadRequest("Mã nhóm hoạt động không được bỏ trống");
                            }  
                            if (string.IsNullOrEmpty(tenMucChi?.ToString()))
                            {
                                return BadRequest("Tên mục chi không được bỏ trống");
                            }

                            // check mã nhóm hoạt động có tòn tại trong hệ thống
                            string[] ttNhomHD = nhomHoatDong?.ToString().Split('_');
                            var dataNhomHD = lstNhomHoatDong.FirstOrDefault(x => x.Code == ttNhomHD[0]);
                            if (dataNhomHD == null )
                            {
                                return BadRequest("Nhóm hoạt động không có trong hệ thống.Hàng " + row);
                            }

                            CategoryExpenseViewImportModel item = new CategoryExpenseViewImportModel
                            {

                                Code = maMucChi?.ToString(),
                                Name = tenMucChi?.ToString(),
                                Notes=ghiChu?.ToString() == null?"": ghiChu?.ToString(),
                                ActiveGroupId= dataNhomHD.Id,
                                ActiveGroupName= dataNhomHD.Name,
                                TieuMuc = tieumuc?.ToString()

                            };
                            lstProject.Add(item);


                            /*a Nghi them insert vao DB chổ này luôn*/
                            CategoryExpenseViewModel expenseModel = new CategoryExpenseViewModel
                            {
                                Code = maMucChi?.ToString(),
                                Name = tenMucChi?.ToString(),
                                Notes = ghiChu?.ToString() == null ? "" : ghiChu?.ToString(),
                                ActiveGroupId = dataNhomHD.Id,
                                TieuMuc = tieumuc?.ToString()
                            };

                            categoryService.CreateExpense(expenseModel, AuthenInfo().UserName);

                            /*end a Nghi them insert vao DB chổ này luôn*/
                        }
                    }
                }
            }
            return Json(new
            {
                data = lstProject,
                Status = "Success"
            });

        }
        #endregion

        #region DM Thong Tin Thanh Toan

        public IActionResult ThongTinHoSoThanhToan()
        {
            ViewBag.Permissions = HttpContext.Session.GetString("Permission");
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryPaymentProfileViewModel> GetDataPaymentProfile(CategoryFilterModel filter)
        {
            var res = categoryService.GetPaymentProfileByFilter(filter);
            return res;
        }

        public IActionResult _AddThongTinHoSoThanhToan(int id = 0)
        {
            var viewModel = new CategoryPaymentProfileAddViewModel();
            if (id > 0)
            {
                viewModel.data = categoryService.GetPaymentProfileById(id);
                viewModel.detail = categoryService.GetPaymentProfileDetailByPaymentProfileId(id);

            }
            else
            {
                viewModel.data= new CategoryPaymentProfileViewModel();
                viewModel.detail= new List<CategoryPaymentProfileDetailViewModel>();
                viewModel.data.Id = 0;
            }

            return View(viewModel);


        }

        [HttpGet]
        public IActionResult _AddThongTinThanhToanMucChi(int id = 0)
        {
            var viewModel = new PaymentProfileModel();

            if (id > 0)
            {
                var lstHoSoThanhToan = categoryService.GetPaymentProfileByExpense(id);
                var mucChi = categoryService.GetExpenseById(id);
                viewModel.TTHoSoThanhToan = lstHoSoThanhToan;
                viewModel.MucChi = mucChi;
                viewModel.LstPaymentProfile = categoryService.LstAllCategoryPaymentProfile();
            }
            else
            {
                viewModel.TTHoSoThanhToan = new List<CategoryPaymentProfileViewModel>();
                viewModel.MucChi = new CategoryExpenseViewModel();
                viewModel.LstPaymentProfile = categoryService.LstAllCategoryPaymentProfile();
            }
            return View(viewModel);


        }

        [HttpPost]
        public async Task<JsonResult> CreatePaymentInfo ([FromBody] CategoryPaymentInfoModel model)
        {
            var res = new SaveResultModel<object>();

            res = categoryService.CreatePaymentProfile(model, User.Identity.Name);

            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã hồ sơ đã tồn tại!";

            }
            else
            {
                // save table detail
                foreach(var dt in model.detail)
                {
                    dt.PaymentProfileId = (int)res.LongValReturn;
                   var resDetail = await categoryService.CreatePaymentProfileDetail(dt, User.Identity.Name);
                }    
            }    
            return Json(res);
        }


       

        public JsonResult ImportPaymenProfileInfo(IFormFile postedFile)
        {
            string rootFolder = config["General:RootFolder"];
            var dataImport = new PaymentInfoProfileImportHelper(rootFolder);
            if (dataImport.Parse(postedFile))
            {
                var test = dataImport.list;
                foreach (var item in dataImport.list)
                {
                    categoryService.CreatePaymentProfile(item, User.Identity.Name);
                }
            }


            return Json(true);
        }



        [HttpGet]
        public JsonResult GetPaymentInfoByExpense(int Id)
        {
            try
            {

                var rs =  categoryService.GetPaymentProfileByExpense(Id);
                return Json(new
                {
                    isSuccess = true,
                    data= rs
                    
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
        public async Task<JsonResult> DeletePaymentProfile(int Id)
        {
            try
            {
                var rs = await categoryService.DeletePaymentProfile(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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
        public async Task<JsonResult> DeletePaymentProfileDetail(int Id)
        {
            try
            {
                var rs = await categoryService.DeletePaymentProfileDetail(Id);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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

        [HttpPost]
        public async Task<JsonResult> CreateExpensePaymentInfo([FromBody] ExpensePaymentInfoModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreateExpensePaymentInfo(model, User.Identity.Name);

            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã hồ sơ đã tồn tại!";

            }
            
            
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeleteExpensePaymentProfile(int Id)
        {
            try
            {
                var rs = await categoryService.DeleteExpensePaymentProfile(Id);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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

       
        #endregion

        #region DM Bo Phan
        public IActionResult BoPhan()
        {
            ViewBag.Permissions = HttpContext.Session.GetString("Permission");
            return View();
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<CategoryDepartmentViewModel> GetDataDepartment(CategoryFilterModel filter)
        {
            var res = categoryService.GetDepartmentByFilter(filter);
            return res;
        }

        public IActionResult _AddBoPhan(int id = 0)
        {
            var viewModel = new CategoryDepartmentViewModel();
            if (id > 0)
            {
                viewModel = categoryService.GetDepartmentById(id);

            }
            else
            {
                viewModel.Id = 0;
            }

            return View(viewModel);


        }

        [HttpPost]
        public async Task<JsonResult> CreateDepartment([FromBody] CategoryDepartmentViewModel model)
        {
            var res = new SaveResultModel<object>();

            res = await categoryService.CreateDepartment(model, User.Identity.Name);
            if (res.LongValReturn == -409)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Mã bộ phận đã tồn tại!";

            }
            return Json(res);
        }

        [HttpGet]
        public async Task<JsonResult> DeleteDepartment(int Id)
        {
            try
            {
                var rs = await categoryService.DeleteDepartment(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs == true ? "Xóa thành công." : "Xóa thất bại",
                    projectId = Id
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
        #endregion








    }
}