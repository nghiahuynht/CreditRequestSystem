using DAL.IService;
using DAL.Models;
using DAL.Models.Category;
using DAL.Models.ProjectFinancialDetail;
using DAL.Models.ProjectFinancialSummar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ProjectController : AppBaseController
    {
        private IProjectFinancialSummarService _projectFinancialSummarService;
        private IProjectFinancialDetailService _projectFinancialDetailService;
        private IAttachFileService _attachFileService;
        private ICategoryService _categoryService;
        public ProjectController(IProjectFinancialSummarService projectFinancialSummarService, IProjectFinancialDetailService projectFinancialDetailService, IAttachFileService attachFileService, ICategoryService categoryService)
        {
            _projectFinancialSummarService = projectFinancialSummarService;
            _projectFinancialDetailService = projectFinancialDetailService;
            _attachFileService = attachFileService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }



        #region project

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<ProjectFinancialSummarGridModel> SearchProjectFinancialSummar(ProjectFinancialSummarFilterModel filter)
        {
            var res = _projectFinancialSummarService.SearchProjectFinancialSummar(filter);
            return res;
        }

        [HttpGet]
        public async Task<IActionResult> FormCreateProject(int Id=0)
        {
            ProjectFinancialSummarGridModel model = new ProjectFinancialSummarGridModel();
            if (Id == 0)
            {
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = AuthenInfo().UserName;
                model.TimeStart = DateTime.Now.Date;
                model.TimeEnd = DateTime.Now.Date;
                return View(model);
            }
            else
            {
                model = await _projectFinancialSummarService.GetProjectById(Id);
                ViewBag.DataFileAttach = await _attachFileService.GetAllAttachmentByObjectId(Id);
                return View(model);
            }
          

        }
        public async Task<IActionResult> ProjectDetail(int Id)
        {
            ProjectFinancialSummarViewModel data = new ProjectFinancialSummarViewModel();
            var projectInfo = await _projectFinancialSummarService.GetProjectById(Id);
            var dataDetail =  await _projectFinancialDetailService.GetAllProjectDetailByProjectId(Id);
            var dataFileAttach = await _attachFileService.GetAllAttachmentByObjectId(Id);
            var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
            data.DM_NhomHoatDong = dm_NhomHoatDong;
            data.ListProjectDetail = dataDetail;
            data.ListFileAttach = dataFileAttach;
            data.ProjectInfo = projectInfo;
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectFinancialSummar([FromBody] ProjectFinancialSummarModel data)
        {

            try
            {
                var res = await _projectFinancialSummarService.CreateProjectFinancialSummar(data, AuthenInfo().UserName);

                if (res.IsSuccess == true && res.LongValReturn > 0)
                {
                    // Update objectId file attach
                    if (data.FileAttach != null && data.FileAttach.Count() > 0)
                    {
                        string fileAttachIds = string.Join(",", data.FileAttach);
                        await _attachFileService.UpdateObjectId(res.LongValReturn, fileAttachIds);
                    }

                    return Json(new
                    {
                        success = true,
                        message = "Tạo dữ liệu thành công",
                        projectId = res.LongValReturn

                    });
                }
                else
                {
                    if(res.LongValReturn == -409)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Mã dự án đã có trong hệ thống",
                        });
                    }  
                    else
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Tạo dữ liệu thất bại",

                        });
                    }    
                    
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message,

                });
            }


        }

        [HttpGet]
        public async Task<IActionResult> DeleteProject(int Id)
        {
            try
            {
                var rs = await _projectFinancialSummarService.DeleteProjectFinancialSummar(Id, AuthenInfo().UserName);
                return Json(new
                {
                    success = rs,
                    message = rs== true?"Xóa thành công.": "Xóa thất bại.Đã phát sinh hồ sơ thanh toán",
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

        public async Task<JsonResult> GetProjectOverviewById(int Id)
        {

            try
            {
                var rs = await _projectFinancialSummarService.GetProjectOverviewById(Id);
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
        public async Task<JsonResult> CheckCodeUnique(string prefix,string code)
        {

            try
            {
                var rs = await _projectFinancialSummarService.CheckCodeUnique(prefix,code);
                if(rs.LongValReturn == 200)
                {
                    return Json(new
                    {
                        isSuccess = true,
                        data = rs.LongValReturn

                    });
                }   
                else
                {
                    return Json(new
                    {
                        isSuccess = false,
                        data = rs.LongValReturn

                    });
                }    
                
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

        [HttpPost]
        public IActionResult ReadFileImport(IFormFile file)
        {
            // Get all DM Trung Tam
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<ProjectFinancialSummarModel> lstProject = new List<ProjectFinancialSummarModel>();
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
                            object tenDA = worksheet.Cells[row, 1].Value;

                            object canCuPhapLy = worksheet.Cells[row, 2].Value;

                            object thoiGianBatDau = worksheet.Cells[row, 3].Value;

                            object thoiGianKetThuc = worksheet.Cells[row, 4].Value;

                            object tongHanMuc = worksheet.Cells[row, 5].Value;
                            object ghiChu = worksheet.Cells[row, 6].Value;


                            if (string.IsNullOrEmpty(tenDA?.ToString()))
                            {
                                return BadRequest("Tên dự án không được bỏ trống");
                            }
                            if (string.IsNullOrEmpty(canCuPhapLy?.ToString()))
                            {
                                return BadRequest("Căn cứ pháp lý không được bỏ trống");
                            }
                          
                            DateTime parsedBatDau= new DateTime();
                            bool isValidateNgayBatDau = true;
                            string[] formats = { "MM/dd/yyyy", "M/d/yyyy h:mm:ss tt", "dd/MM/yyyy", "d/M/yyyy", "dd/MM/yyyy h:mm:ss tt" };
                            if (string.IsNullOrWhiteSpace(thoiGianBatDau?.ToString()) || !DateTime.TryParseExact(thoiGianBatDau?.ToString(), formats, null, System.Globalization.DateTimeStyles.None, out parsedBatDau))
                            {

                                isValidateNgayBatDau = false;
                            }
                            if (isValidateNgayBatDau == false)
                            {
                                return BadRequest("Ngày bắt đầu không hợp lệ");
                            }

                            DateTime parsedKetThuc= new DateTime();
                            bool isValidateNgayKetThuc = true;
                           
                            if (string.IsNullOrWhiteSpace(thoiGianKetThuc?.ToString()) || !DateTime.TryParseExact(thoiGianKetThuc?.ToString(), formats, null, System.Globalization.DateTimeStyles.None, out parsedKetThuc))
                            {

                                isValidateNgayKetThuc = false;
                            }
                            if (isValidateNgayKetThuc == false)
                            {
                                return BadRequest("Ngày kết thúc không hợp lệ");
                            }
                            if (string.IsNullOrEmpty(tongHanMuc?.ToString()))
                            {
                                return BadRequest("Tổng hạn mức không được bỏ trống");
                            }
                            decimal parsedTongHanMuc;
                            try
                            {
                                parsedTongHanMuc = decimal.Parse(tongHanMuc.ToString());
                            }
                            catch(Exception ex)
                            {
                                return BadRequest("Tổng hạn mức không hợp lệ");
                            }

                            ProjectFinancialSummarModel item = new ProjectFinancialSummarModel
                            {

                                ProjectName = tenDA.ToString(),
                                LegalBasis = canCuPhapLy.ToString(),
                                TimeStart = parsedBatDau,
                                TimeEnd=parsedKetThuc,
                                TotalAmount= parsedTongHanMuc,
                                Notes= ghiChu != null?ghiChu?.ToString():""

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
        public async Task<IActionResult> ImportProjectFinancialSummar([FromBody] List<ProjectFinancialSummarModel> data)
        {

            try
            {
                List<ResImportProjectFinancialSummarModel> resImport = new List<ResImportProjectFinancialSummarModel>();
                foreach(var item in data)
                {
                    var res = await _projectFinancialSummarService.CreateProjectFinancialSummar(item, AuthenInfo().UserName);
                    string ms = "Thành công";
                    if(res.LongValReturn <0)
                    {
                        if(res.LongValReturn == -409)
                        {
                            ms = "Mã dự án đã tồn tại";
                        }
                        else
                        {
                            ms = "Thất bại";

                        }    
                    };
                    
                    resImport.Add(new ResImportProjectFinancialSummarModel()
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
        #endregion

        #region project detail

        public async Task<IActionResult> ProjectDetailIndex()
        {
            ProjectFinancialDetailParamModel paramModel = new ProjectFinancialDetailParamModel();
            var lstProject = await  _projectFinancialSummarService.LstAllProjectFinancialSummar();
            var lstActiveGroup = _categoryService.LstAllCategoryActiveGroup();
            var lstExpense = _categoryService.LstAllCategoryExpense();
            paramModel.LstProject = lstProject;
            paramModel.LstActiveGroup = lstActiveGroup;
            paramModel.LstExpense = lstExpense;
            return View(paramModel);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public DataTableResultModel<ProjectFinancialDetailTableModel> GetDataProjectDetail(ProjectFinancialDetailFilterModel filter)
        {
            var res = _projectFinancialDetailService.GetDataProjectFinancialDetailPaging(filter,AuthenInfo().UserId);
            return res;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectFinancialDetail([FromBody] ProjectFinancialDetailAddModel data)
        {

            try
            {
                var res = await _projectFinancialDetailService.CreateProjectFinancialDetail(data, AuthenInfo().UserName);

                if (res.IsSuccess == true && res.LongValReturn > 0)
                {
                    if(data.PaymentInfo!= null && data.PaymentInfo.Count()>0)
                    {
                        foreach(var item in data.PaymentInfo)
                        {
                            item.ProjectDetailId = (int)res.LongValReturn;
                            item.ExpenseId=data.ExpenseId;
                            item.ProjectId=data.ProjectId;
                             await _projectFinancialDetailService.CreateProfileForProjectDetail(item, AuthenInfo().UserName);
                        }
                    }
                    return Json(new
                    {
                        success = true,
                        message = "Tạo dữ liệu thành công",
                        projectDetailId = res.LongValReturn

                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Tạo dữ liệu thất bại",

                    });
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message,

                });
            }


        }

        [HttpGet]
        public async Task<IActionResult> FormCreateProjectDetail(int Id)
        {
            if(Id>0)
            {
                ProjectFinancialDetailViewModel data = new ProjectFinancialDetailViewModel();
                var lstProject = await _projectFinancialSummarService.LstAllProjectFinancialSummarByPermission(AuthenInfo().UserId);
                var dataDetail = await _projectFinancialDetailService.GetProjectFinancialDetailById(Id);
                var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
                var dm_MucChi = _categoryService.LstAllCategoryExpense();
                var hsThanhToan = await _projectFinancialDetailService.GetAllProfieForProjectId(dataDetail.ProjectId, dataDetail.ActivityGroupId, dataDetail.ExpenseId);
                data.DM_NhomHoatDong = dm_NhomHoatDong;
                data.data = dataDetail;
                data.LstProject = lstProject;
                data.DM_MucChi = dm_MucChi;
                data.DM_HSThanhToan = hsThanhToan;
                return View(data);
            }   
            else
            {
                ProjectFinancialDetailViewModel data = new ProjectFinancialDetailViewModel();
                var lstProject = await _projectFinancialSummarService.LstAllProjectFinancialSummarByPermission(AuthenInfo().UserId);
                var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
                var dm_MucChi = _categoryService.LstAllCategoryExpense();
                data.LstProject = lstProject;
                data.DM_NhomHoatDong = dm_NhomHoatDong;
                data.DM_MucChi = dm_MucChi;
                data.data = new ProjectFinancialDetailModel();
                return View(data);
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProjectDetail(int Id)
        {
            var res = await _projectFinancialDetailService.DeleteProjectFinancialDetail(Id, AuthenInfo().UserName);
            if(res == true)
            {
                return Json(new
                {
                    success = true,
                    message = "Xóa thành công",

                });
            }   
            else
            {
                return Json(new
                {
                    success = false,
                    message = "Xóa thất bại",

                });
            }    
        }

        [HttpGet]
        public async Task<IActionResult> FormViewDetailProjectDetail(int Id)
        {
            if (Id > 0)
            {
                ProjectFinancialDetailViewModel data = new ProjectFinancialDetailViewModel();
                var dataDetail = await _projectFinancialDetailService.GetProjectFinancialDetailById(Id);
                var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
                var hsThanhToan = await _projectFinancialDetailService.GetAllProfieForProjectId(dataDetail.ProjectId, dataDetail.ActivityGroupId, dataDetail.ExpenseId);
                data.DM_NhomHoatDong = dm_NhomHoatDong;
                data.DM_HSThanhToan = new List<PaymentInfoProjectDetailModel>();
                data.HSThanhToan = hsThanhToan;
                data.data = dataDetail;
                return View(data);
            }
            else
            {
                ProjectFinancialDetailViewModel data = new ProjectFinancialDetailViewModel();
                var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
                data.DM_NhomHoatDong = dm_NhomHoatDong;
                data.data = new ProjectFinancialDetailModel();
                data.DM_HSThanhToan = new List<PaymentInfoProjectDetailModel>();
                return View(data);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProfileForProjectDetail([FromBody] PaymentInfoProjectDetailModel data)
        {

            try
            {
                var res = await _projectFinancialDetailService.CreateProfileForProjectDetail(data, AuthenInfo().UserName);

                if (res.IsSuccess == true && res.LongValReturn > 0)
                {

                    return Json(new
                    {
                        success = true,
                        message = "Tạo dữ liệu thành công",
                        projectDetailId = res.LongValReturn

                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Tạo dữ liệu thất bại",

                    });
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message,

                });
            }


        }

        [HttpGet]
        public async Task<IActionResult> DeletePaymentProfileOfProjectDetail(int ProjectDetailId, long ProfileId)
        {
            var res = await _projectFinancialDetailService.DeletePaymentProfileOfProjectDetail(ProjectDetailId, ProfileId, AuthenInfo().UserName);
            if (res == true)
            {
                return Json(new
                {
                    success = true,
                    message = "Xóa thành công",

                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "Xóa thất bại",

                });
            }
        }

        #endregion


    }
}
