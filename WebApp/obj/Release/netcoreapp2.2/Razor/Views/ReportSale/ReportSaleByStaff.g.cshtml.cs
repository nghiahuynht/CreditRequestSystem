#pragma checksum "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a67b3410a4b8e241f006218c8a82adfd984af03c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReportSale_ReportSaleByStaff), @"mvc.1.0.view", @"/Views/ReportSale/ReportSaleByStaff.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ReportSale/ReportSaleByStaff.cshtml", typeof(AspNetCore.Views_ReportSale_ReportSaleByStaff))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 7 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
using DAL;

#line default
#line hidden
#line 8 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
using DAL.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a67b3410a4b8e241f006218c8a82adfd984af03c", @"/Views/ReportSale/ReportSaleByStaff.cshtml")]
    public class Views_ReportSale_ReportSaleByStaff : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.ReportSale.ReportSaleByStaffFilter>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datepicker/datepicker3.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datepicker/bootstrap-datepicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
  
    ViewData["Title"] = "Báo cáo bán hàng theo nhân viên";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(168, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(217, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(223, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a67b3410a4b8e241f006218c8a82adfd984af03c6624", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(292, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(298, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a67b3410a4b8e241f006218c8a82adfd984af03c7956", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(385, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(391, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a67b3410a4b8e241f006218c8a82adfd984af03c9288", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(489, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(496, 159, true);
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(657, 17, false);
#line 20 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(675, 254, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\"><a href=\"#\">Trang chủ</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
            EndContext();
            BeginContext(931, 17, false);
#line 25 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(949, 453, true);
            WriteLiteral(@"</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""row"">
                <div class=""col-sm-2"">
                    <label>Nhóm bán hàng</label>
                    <select class=""form-control"" id=""ddl-saleteam"">
                        <option value=""All"">Tất cả</option>
");
            EndContext();
#line 39 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
                          

                            var lstTeam = (List<DAL.Entities.SaleTeam>)ViewBag.SaleTeams;

                            foreach (var team in lstTeam)
                            {

#line default
#line hidden
            BeginContext(1615, 39, true);
            WriteLiteral("                                <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1654, "\"", 1674, 1);
#line 45 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
WriteAttributeValue("", 1662, team.Code, 1662, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1675, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1678, 9, false);
#line 45 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
                                                         Write(team.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1688, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 46 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(1757, 515, true);
            WriteLiteral(@"                    </select>
                </div>
                <div class=""col-sm-2"">
                    <label>Nhân viên</label>
                    <select class=""form-control"" id=""ddl-staff"">
                        <option value=""All"">Tất cả</option>
                    </select>
                </div>
                <div class=""col-sm-2"">
                    <label>Từ ngày</label>
                    <div class=""input-group date"">
                        <input type=""text"" id=""FromDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2272, "\"", 2297, 1);
#line 59 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
WriteAttributeValue("", 2280, Model.FromDate, 2280, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2298, 383, true);
            WriteLiteral(@" class=""form-control"">
                        <span class=""input-group-addon group-date-icon""><i class=""far fa-calendar-alt""></i></span>
                    </div>
                </div>
                <div class=""col-sm-2"">
                    <label>Đến ngày</label>
                    <div class=""input-group date"">
                        <input type=""text"" id=""ToDate""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2681, "\"", 2704, 1);
#line 66 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\ReportSale\ReportSaleByStaff.cshtml"
WriteAttributeValue("", 2689, Model.ToDate, 2689, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2705, 1362, true);
            WriteLiteral(@" class=""form-control"">
                        <span class=""input-group-addon group-date-icon""><i class=""far fa-calendar-alt""></i></span>
                    </div>
                </div>



                <div class=""col-sm-1"">
                    <button class=""btn btn-primary btn-filter"" id=""btn-search""><i class=""fa fa-search""></i></button>
                </div>
                <div class=""col-sm-3"">
                    <div class=""text-right"">
                        <button class=""btn btn-sm btn-success btn-filter""><i class=""fa fa-download""></i>&nbsp;Export</button>
                        <button class=""btn btn-sm btn-success btn-filter""><i class=""fa fa-upload""></i>&nbsp;Import</button>
                    </div>
                </div>
            </div>

        </div>
        <div class=""card-body"">

            <table class=""table table-bordered table-hover dataTable"" id=""table-report"" width=""100%"">
                <thead>
                    <tr>
                        <th");
            WriteLiteral(@">Mã NV</th>
                        <th>Tên NV</th>
                        <th>SDT</th>
                        <th>Email</th>
                        <th>SL đơn</th>
                        <th>Tổng doanh số</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</section>

");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4084, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4090, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a67b3410a4b8e241f006218c8a82adfd984af03c17210", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4158, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4164, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a67b3410a4b8e241f006218c8a82adfd984af03c18466", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4227, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4233, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a67b3410a4b8e241f006218c8a82adfd984af03c19722", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4309, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4315, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a67b3410a4b8e241f006218c8a82adfd984af03c20978", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4402, 2308, true);
                WriteLiteral(@"

    <script>
        var tableId = ""#table-report"";
        var ajaxURL = ""/ReportSale/GetReporSaleByStaff"";
        var columnData = [
            { ""data"": ""staffCode"" },
            { ""data"": ""staffName"" },
            { ""data"": ""sdt"" },
            { ""data"": ""email"" },
            {
                ""data"": ""slOrder"", ""render"": function (data, type, row, meta) {
                    return RenderNumerFormat(data);
                }
            },
            {
                ""data"": ""totalSale"", ""render"": function (data, type, row, meta) {
                    return RenderNumerFormat(data);
                }
            },
            
        ];




        $(document).ready(function () {

            GetReport();
            $(""#btn-search"").click(function () {
                GetReport();
            });

            $("".date"").datepicker({
                format: ""dd/mm/yyyy""
            }).on('changeDate', function (e) {
                $(this).datepicker('hide');");
                WriteLiteral(@"
            });


            $(""#ddl-saleteam"").change(function () {
                LoadStaffByTeam();
            });

        })

        function GetReport() {
            var searchModel = {
                TeamCode: $(""#ddl-saleteam"").val(),
                StaffCode: $(""#ddl-staff"").val(),
                FromDate: ConverFormatDate($(""#FromDate"").val()),
                ToDate: ConverFormatDate($(""#ToDate"").val()),
            };

            GenrateDataTableSearch(tableId, ajaxURL, columnData, searchModel);



        }


        function LoadStaffByTeam() {
            let teamCode = $(""#ddl-saleteam"").val();
            $.ajax({
                type: ""GET"",
                contentType: 'application/json; charset=utf-8',
                url: ""/SaleTeam/GetListMemberInTeam?teamCode="" + teamCode,
                success: function (result) {
                    let htmlOption = ""<option>All</option>"";
                    $.each(result, function (key, obj) {
          ");
                WriteLiteral(@"              htmlOption = htmlOption + ""<option value='"" + obj.userName + ""'>"" + obj.fullName + ""</option>""
                    });
                    $(""#ddl-staff"").html(htmlOption);
                }
            });
        }




    </script>
");
                EndContext();
            }
            );
            BeginContext(6713, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.ReportSale.ReportSaleByStaffFilter> Html { get; private set; }
    }
}
#pragma warning restore 1591
