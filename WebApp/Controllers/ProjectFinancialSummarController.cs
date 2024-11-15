using DAL.IService;
using DAL.Models.ProjectFinancialSummar;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ProjectFinancialSummarController : AppBaseController
    {
        private IProjectFinancialSummarService _projectFinancialSummarService;
        public ProjectFinancialSummarController(IProjectFinancialSummarService projectFinancialSummarService)
        {
            _projectFinancialSummarService = projectFinancialSummarService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectFinancialSummar([FromBody] ProjectFinancialSummarModel data)
        {

            var res = await _projectFinancialSummarService.CreateProjectFinancialSummar(data, AuthenInfo().UserName);


            return Json(res);
            
        }
    }
}
