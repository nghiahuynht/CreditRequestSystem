#pragma checksum "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d516210702f4981a166f7882b7c1087fd0fa1be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Permission_PermisonCreateRequest), @"mvc.1.0.view", @"/Views/Permission/PermisonCreateRequest.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Permission/PermisonCreateRequest.cshtml", typeof(AspNetCore.Views_Permission_PermisonCreateRequest))]
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
#line 1 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
using System.Security.Claims;

#line default
#line hidden
#line 2 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
using WebApp.ExcelHelper;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d516210702f4981a166f7882b7c1087fd0fa1be", @"/Views/Permission/PermisonCreateRequest.cshtml")]
    public class Views_Permission_PermisonCreateRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.UserInfo.UserParViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/mdb-treeview/forms-free.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/mdb-treeview/scrolling-navbar.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/mdb-treeview/treeview.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/mdb-treeview/wow.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
  
    ViewData["Title"] = "Danh sách phân quyền nhân viên tạo yêu cầu thanh toán";
    Layout = "~/Views/Shared/_Layout.cshtml";
   // string Permission = User.Claims.FirstOrDefault(x => x.Type == "Permission").Value;
    bool isAdd = AuthHelper.GetPermissionHelper(ViewBag.Permissions).Contains(PermissionHelper.PhanQuyenNhanVienYeuCauTT.Add);


#line default
#line hidden
            DefineSection("styles", async() => {
                BeginContext(476, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(484, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d516210702f4981a166f7882b7c1087fd0fa1be7971", async() => {
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
                BeginContext(571, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(577, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d516210702f4981a166f7882b7c1087fd0fa1be9303", async() => {
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
                BeginContext(675, 564, true);
                WriteLiteral(@"
    <style>
        .div-member {
            margin-left: 20px;
        }

            .div-member .nav .nav-link {
                margin: 4px 0 !important;
            }

        .card .nav.flex-column > li {
            border-bottom: 0px;
        }

        .span-team-name {
            font-weight: bold
        }

        .i-edit-saleteam {
            color: #555;
        }

        .i-delete-saleteam {
            color: #ff0000;
        }

        .typeahead {
            width: 100% !important;
        }
    </style>
");
                EndContext();
            }
            );
            BeginContext(1242, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(1401, 17, false);
#line 49 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(1419, 254, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\"><a href=\"#\">Trang chủ</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
            EndContext();
            BeginContext(1675, 17, false);
#line 54 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(1693, 563, true);
            WriteLiteral(@"</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">

    <div class=""row"">

        <div class=""col-sm-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <div class=""row"">

                        <div class=""col-sm-3"">
                            <label>Phòng ban</label>
                            <select class=""form-control"" id=""ddl-role"">
                                <option value=""all"">Tất cả</option>
");
            EndContext();
#line 73 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
                                  
                                    foreach (var opt in Model.LstDepartment)
                                    {

#line default
#line hidden
            BeginContext(2409, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2456, "\"", 2471, 1);
#line 76 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
WriteAttributeValue("", 2464, opt.Id, 2464, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2472, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2474, 8, false);
#line 76 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
                                                           Write(opt.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2482, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 77 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
                                    }
                                

#line default
#line hidden
            BeginContext(2567, 1743, true);
            WriteLiteral(@"                            </select>
                        </div>
                        <div class=""col-sm-3"">
                            <label>Tìm theo SĐT/tên/email</label>
                            <input type=""text"" class=""form-control"" id=""txtkeyword"" />
                        </div>

                        <div class=""col-sm-3"">
                            <button onclick=""SearchPermissionCreateRequest()"" class=""btn btn-filter btn-sm btn-primary""><i class=""fa fa-search""></i>&nbsp;Tìm kiếm</button>

                        </div>

                    </div>
                </div>

                <div class=""card-body "">
                    <table class=""table table-bordered table-hover dataTable"" id=""table-permission-create-request"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th width=""200px"">Tên đầy đủ</th>
                                <th>SDT</th>
        ");
            WriteLiteral(@"                        <th>Email</th>
                                <th width=""150px"">Chức danh</th>
                                <th width=""100px"">Hoạt động</th>
                                <th></th>
                            </tr>
                        </thead>
                    </table>

                </div>
            </div>
        </div>

    </div>


</section>


<!--modal add-->
<div class=""modal modal-blur fade"" id=""modal_permission_create_request"" data-bs-backdrop=""static"" data-bs-focus=""false"" data-bs-keyboard=""false"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-xl"" id=""dailog_permission_create_request"">

    </div>
</div>





");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4327, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4333, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be16631", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4396, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4402, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be17887", async() => {
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
                BeginContext(4478, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4484, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be19143", async() => {
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
                BeginContext(4571, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(4579, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be20403", async() => {
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
                BeginContext(4639, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4645, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be21659", async() => {
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
                BeginContext(4711, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4717, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be22915", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4775, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4781, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be24171", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4834, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4840, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d516210702f4981a166f7882b7c1087fd0fa1be25427", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4887, 56, true);
                WriteLiteral("\r\n    <script>\r\n        debugger\r\n        const isAdd = ");
                EndContext();
                BeginContext(4944, 26, false);
#line 142 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Permission\PermisonCreateRequest.cshtml"
                 Write(isAdd.ToString().ToLower());

#line default
#line hidden
                EndContext();
                BeginContext(4970, 9270, true);
                WriteLiteral(@";
        var tableId = ""#table-permission-create-request"";
        var ajaxURL = ""/Account/SearchUserInfo"";
        var columnData = [
            { ""data"": ""id"", visible: false },
            { ""data"": ""fullName"" },
            {
                ""data"": ""phone"", ""render"": function (data, type, row, meta) {
                    if (data == ""NULL"" || data == null) {
                        return """"
                    }
                    else {
                        return data
                    }

                }
            },
            { ""data"": ""email"" },
            { ""data"": ""title"" },

            {
                ""data"": ""isActive"", ""render"": function (data, type, row, meta) {
                    if (data == ""Yes"") {
                        return ""<i class='text-success' >Hoạt động</i>""
                    }
                    else {
                        return ""<i class='text-danger' >Ngưng hoạt động</i>""
                    }
                }
           ");
                WriteLiteral(@" },
            {
                ""data"": ""id"", ""render"": function (data, type, row, meta) {
                    return RenderTableAction(row.id, row.fullName);
                }
            },


        ];

        var arrPaymentProfile = [];


        $(document).ready(function () {

            SearchPermissionCreateRequest();


        });
        function RenderTableAction(id, fullname) {
            let html = `<div class='div-table-action'>`;

            // Check if add action should be added
            if (isAdd) {
                html += `<i class='fa fa-key' onclick='showModalPermissionCreateRequest(""${id}"", ""${fullname}"")' title='phân quyền'></i>&nbsp`;
            }

            html += `</div>`;
            return html;
           

        }

        function SearchPermissionCreateRequest() {

            var dataSearch = {
                RoleCode: 'all',
                Keyword: $(""#txtkeyword"").val()

            };
            GenrateDataTableSearch(");
                WriteLiteral(@"tableId, ajaxURL, columnData, dataSearch);

        }

        function showModalPermissionCreateRequest(id, fullName) {
            $.ajax({
                url: `/Permission/FormPermissionCreateRequest?id=${encodeURIComponent(id)}&fullName=${fullName}`,
                type: 'GET',
                success: function (response) {
                    $('#dailog_permission_create_request').html(response);

                    // Hiển thị modal
                    $(""#modal_permission_create_request"").modal(""show"")
                },
                error: function (xhr, status, error) {
                    console.error(""Có lỗi khi tải nội dung modal: "", error);
                    alert(""Lỗi tải modal, vui lòng thử lại sau."");
                }
            });
        }

        function CreatePermissionCreateRequest() {

            var isValidateDetail = validatePermissionCreateRequest();
            if (isValidateDetail == true) {

                var dataPost = {
                ");
                WriteLiteral(@"    Id: parseInt($(""#PermissionInChargeId"").val()),
                    ProjectId: parseInt($(""#a_du_an"").val()),
                    ProjectName: $(""#a_du_an option:selected"").text(),
                    ActiveGroupId: parseInt($(""#a_nhom_hoat_dong"").val()),
                    ActiveGroupName: $(""#a_nhom_hoat_dong option:selected"").text(),
                    UserId: parseInt($('#UserId').val()),
                    UserName: $(""#UserName"").val()
                };
                // Gửi yêu cầu AJAX
                console.log(""dataPost"", dataPost);
                $.ajax({
                    url: '/Permission/CreatePermissionCreateRequest',
                    type: 'POST',
                    data: JSON.stringify(dataPost),
                    contentType: 'application/json',
                    success: function (response) {

                        if (response.isSuccess) {

                            toastr.success('Phân quyền nhân viên phụ trách thành công!', 'Thành công', { posi");
                WriteLiteral(@"tionClass: ""toast-top-center"" });
                            var html = `<tr>
                                            <td>
                                                ${dataPost.ProjectName}
                                            </td>
                                            <td>
                                                ${dataPost.ActiveGroupName}
                                            </td>
                                            <td style=""text-align:center;"">

                                                <span class=""fa fa-trash"" onclick=""RemovePermissionCreateRequestById(${response.longValReturn})""></span>
                                            </td>
                                         </tr>`
                            $('#table_thong_tin_nhan_vien_phu_trach').append(html);


                        } else {
                            toastr.error('Có lỗi khi phân quyền nhân viên phụ trách. Vui lòng thử lại!', 'Lỗi', { positionClass: ""toast");
                WriteLiteral(@"-top-center"" });
                        }
                    },
                    error: function (xhr, status, error) {
                        // Xử lý khi có lỗi xảy ra trong quá trình gọi AJAX
                        alert('Có lỗi khi gửi yêu cầu!');
                    }
                });
            }
        }

        function validatePermissionCreateRequest() {
            var resultValid = $(""#frmCreatePermissionCreateRequest"").validate({
                rules: {
                    ""du_an"": {
                        required: true,
                    },
                    ""nhom_hoat_dong"": {
                        required: true,
                    }

                },
                messages: {
                    ""du_an"": ""Nguồn thu không được bỏ trống!"",
                    ""nhom_hoat_dong"": ""Nhóm hoạt động không được bỏ trống!""
                },

            }).form();

            return resultValid;

        }

        function closeModal_Permissi");
                WriteLiteral(@"onCreateRequest() {

            $(""#modal_permission_create_request"").modal(""hide"")

        }



        function RemovePermissionCreateRequestById(Id) {
            const userId = $('#a_userId').val();
            Swal.fire({
                title: 'Bạn có chắc chắn?',
                text: ""Bạn sẽ không thể hoàn tác hành động này!"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Xóa',
                cancelButtonText: 'Hủy'
            }).then((result) => {
                if (result.isConfirmed) {
                    // call ajax delete
                    $.ajax({
                        url: '/Permission/DeletePermissionProjectById',
                        type: 'GET',
                        data: {
                            Id: Id
                        },
                        success: function (response) {
        ");
                WriteLiteral(@"                    if (response.success) {

                                toastr.success('Xóa phân quyền thành công!', 'Thành công', { positionClass: ""toast-top-center"" });
                                $(""#modal_permission_create_request"").modal(""hide"")
                            }
                            else {
                                console.error(response);
                                toastr.error('Có lỗi xảy ra khi xóa phân quyền !', 'Lỗi', { positionClass: ""toast-top-center"" });
                            }
                        },
                        error: function (xhr, status, error) {
                            console.error(""Có lỗi khi tải nội dung modal: "", error);
                            alert(""Lỗi tải modal, vui lòng thử lại sau."");
                        }
                    });

                }
            });
        }

        function handelchangeProject() {
            // Get selected menu
            const duanElement = document");
                WriteLiteral(@".getElementById('a_du_an');
            const duanId = duanElement.value;

            $.ajax({
                url: '/category/GetActiveGroupAllocationByProductId/',
                data: {
                   Id: duanId,
                   
                },
                type: 'GET',
                success: function (response) {
                    
                    if (response.isSuccess == true && response.data.length > 0) {
                        var htmlbody = ""<option></option>"";
                        response.data.forEach((item) => {
                            htmlbody += `<option value=""${item.id}"">${item.name}</option>`
                        })
                        $('#a_nhom_hoat_dong').html(htmlbody);
                    }
                },
                error: function (xhr, status, error) {
                    console.error(""Có lỗi khi tải nội dung modal: "", error);
                    alert(""Lỗi tải modal, vui lòng thử lại sau."");
                }
   ");
                WriteLiteral("         });\r\n        }\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(14243, 4, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.UserInfo.UserParViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
