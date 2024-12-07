using DAL.IService;
using DAL.Models;
using DAL.Models.Category;
using DAL.Models.ProjectFinancialDetail;
using DAL.Models.ProjectFinancialSummar;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var res = _projectFinancialDetailService.GetDataProjectFinancialDetailPaging(filter);
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
                var lstProject = await _projectFinancialSummarService.LstAllProjectFinancialSummar();
                var dataDetail = await _projectFinancialDetailService.GetProjectFinancialDetailById(Id);
                var dm_NhomHoatDong = _categoryService.LstAllCategoryActiveGroup();
                var dm_MucChi = _categoryService.LstAllCategoryExpense();
                var hsThanhToan = await _projectFinancialDetailService.GetAllProfieForProjectId(Id);
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
                var lstProject = await _projectFinancialSummarService.LstAllProjectFinancialSummar();
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
                var dm_HSThanhToan = _categoryService.LstAllCategoryPaymentProfile(dataDetail.ActivityGroupId);
                var hsThanhToan = await _projectFinancialDetailService.GetAllProfieForProjectId(Id);
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
