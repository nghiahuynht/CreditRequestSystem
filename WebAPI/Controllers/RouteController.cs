using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.IService;
using DAL.ModelAPI.Route;
using DAL.Models;
using DAL.Models.SaleTeam;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private IRouteService routeService;
        private IVisitService visitService;
        private ISaleTeamService saleTeamService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RouteController(IRouteService routeService, IVisitService visitService, ISaleTeamService saleTeamService, IHostingEnvironment hostingEnvironment)
        {
            this.routeService = routeService;
            this.visitService = visitService;
            this.saleTeamService = saleTeamService;
            this._hostingEnvironment = hostingEnvironment;
        }



        [HttpGet]
        public List<SaleTeam> GetAllSaleTeam()
        {
            var res = saleTeamService.GetAllSaleTeam();
            return res;
        }


        [HttpGet]
        public List<SaleMemberTreeModel> GetMemberInTeam(string teamCode)
        {
            var res = saleTeamService.GetListMemberInSaleTeam(teamCode);
            return res;
        }


        [HttpGet]
        public List<ComboBoxModel> GetListSalerByRole(string roleCode,string userName)
        {
            var res = routeService.ListSalerByRole(roleCode, userName);
            return res;
        }

        [HttpGet]
        public List<ComboBoxModel> GetListRouteByUser(string userName)
        {
            var lstRoute = new List<ComboBoxModel>();
            var res = routeService.ListRouteByUser(userName);
            if (res.Any())
            {
                lstRoute = res.Select(x => new ComboBoxModel { Value = x.RouteCode, Text = x.RouteName }).ToList();
            }
            return lstRoute;
        }

        [HttpPost]
        public DataTableResultModel<ApiRouteMatrixItemModel> SearchMatrixForVist([FromBody] ApiRouteMatrixFilterModel filter)
        {

            var log = new StringBuilder();
            log.AppendLine($"RequestURL: / Route/SearchMatrixForVist");
            log.AppendLine($"Input: {JsonConvert.SerializeObject(filter)}");
            string projectRootPath = _hostingEnvironment.ContentRootPath;
            string pathLog = Path.Combine(projectRootPath, "Logs");
            WriteLog.writeToLogFile(log.ToString(), pathLog);


            var res = routeService.SearhMatrixPageForMobile(filter);
            return res;
        }

        [HttpPost]
        public SaveResultModel<object> Checkin([FromBody] VisitResult visit)
        {

            var log = new StringBuilder();
            log.AppendLine($"RequestURL: / Route/Checkin");
            log.AppendLine($"Input: {JsonConvert.SerializeObject(visit)}");
            string projectRootPath = _hostingEnvironment.ContentRootPath;
            string pathLog = Path.Combine(projectRootPath, "Logs");
            WriteLog.writeToLogFile(log.ToString(), pathLog);

            var res = visitService.VisitAction(visit, "Checkin");
            if (!res.IsSuccess)
            {
                log.Append(res.ErrorMessage);
                WriteLog.writeToLogFile(log.ToString(), pathLog);
            }
            return res;
        }

        [HttpPost]
        public SaveResultModel<object> CheckOut([FromBody] VisitResult visit)
        {
            var log = new StringBuilder();
            log.AppendLine($"RequestURL: / Route/Checkout");
            log.AppendLine($"Input: {JsonConvert.SerializeObject(visit)}");
            string projectRootPath = _hostingEnvironment.ContentRootPath;
            string pathLog = Path.Combine(projectRootPath, "Logs");
            WriteLog.writeToLogFile(log.ToString(), pathLog);

            var res = visitService.VisitAction(visit, "Checkout");
            if (!res.IsSuccess)
            {
                log.Append(res.ErrorMessage);
                WriteLog.writeToLogFile(log.ToString(), pathLog);
            }
            return res;

        }

        [HttpPost]
        public SaveResultModel<object> SaveImageCheckin([FromBody] VisitResult visit)
        {
            var res = visitService.SaveImageCheckin(visit.Id.Value,visit.image);
            return res;

        }

        [HttpPost]
        public SaveResultModel<object> SaveVisitNote([FromBody] VisitResult visit)
        {
            var res = visitService.SaveVisitNote(visit.Id.Value, visit.note);
            return res;

        }



    }
}