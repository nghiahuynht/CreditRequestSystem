#pragma checksum "F:\Projects\OnSVN\IchiWeb\WebApp\Views\Distributor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38a0297bbf09737e7fd13850b00dd5baed882f4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Distributor_Index), @"mvc.1.0.view", @"/Views/Distributor/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Distributor/Index.cshtml", typeof(AspNetCore.Views_Distributor_Index))]
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
#line 7 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\Distributor\Index.cshtml"
using DAL.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38a0297bbf09737e7fd13850b00dd5baed882f4e", @"/Views/Distributor/Index.cshtml")]
    public class Views_Distributor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/css/fixedColumns.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-fixedcolumns/js/dataTables.fixedColumns.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\Distributor\Index.cshtml"
  
    ViewData["Title"] = "Danh sách nhóm bán hàng";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(108, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(147, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(155, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "38a0297bbf09737e7fd13850b00dd5baed882f4e5700", async() => {
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
                BeginContext(242, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(248, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "38a0297bbf09737e7fd13850b00dd5baed882f4e7032", async() => {
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
                BeginContext(346, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(353, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(512, 17, false);
#line 18 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\Distributor\Index.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(530, 275, true);
            WriteLiteral(@"</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                   
                    <li class=""breadcrumb-item""><a href=""#"">Trang chủ</a></li>
                    <li class=""breadcrumb-item active"">");
            EndContext();
            BeginContext(807, 17, false);
#line 24 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\Distributor\Index.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(825, 1676, true);
            WriteLiteral(@"</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
    <section class=""content"">
        <div class=""card"">
            <div class=""card-header"">
                <div class=""row"">

                    <div class=""col-sm-10"">
                        <label>Tìm theo mã/khách hàng</label>
                        <input type=""text"" class=""form-control"" id=""txtkeyword"" />
                    </div>
                    <div class=""col-sm-2"">
                        <input type=""button"" value=""Tìm"" class=""btn btn-default btn-filter"" id=""btn-search"" />
                    </div>
                </div>
            </div>
            <div class=""card-body "">
                <div class=""text-right"">
                    <a class=""btn btn-sm btn-primary"" href=""/distributor/distributorDetail""><i class=""fa fa-plus-circle""></i>&nbsp;Tạo mới</a>
                    <button class=""btn btn-sm btn-success""><i class=""fa fa-download""></i>&nbsp;Export excel</butt");
            WriteLiteral(@"on>
                    <button class=""btn btn-sm btn-success""><i class=""fa fa-upload""></i>&nbsp;Import excel</button>
                </div>
                <table class=""table table-bordered table-hover dataTable"" id=""table-distributor"" width=""100%"">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Mã nhóm BH</th>
                            <th>Tên nhóm BH</th>
                            <th></th>
                        </tr>
                    </thead>
                </table>

            </div>
        </div>
    </section>
</section>


");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2518, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2524, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38a0297bbf09737e7fd13850b00dd5baed882f4e11564", async() => {
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
                BeginContext(2587, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2593, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38a0297bbf09737e7fd13850b00dd5baed882f4e12820", async() => {
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
                BeginContext(2669, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2675, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38a0297bbf09737e7fd13850b00dd5baed882f4e14076", async() => {
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
                BeginContext(2762, 2515, true);
                WriteLiteral(@"


    <script>
        debugger
        var tableId = ""#table-distributor"";
        var ajaxURL = ""/Distributor/SearchDistributor"";
        var columnData = [
            { ""data"": ""id"", visible: false },
            { ""data"": ""code"" },
            { ""data"": ""name"" },
            {
                ""data"": ""id"", ""render"": function (data, type, row, meta) {
                    return RenderTableAction(data);
                }
            },


        ];
        $(document).ready(function () {

            SearchDistributor();
            $(""#btn-search"").click(function () {
                SearchDistributor();
            });
        });
        function RenderTableAction(distributorId ) {
            var html = ""<div class='div-table-action'>"" +
                ""<i class='fa fa-edit' onclick='GotoDistributorDetail("" + distributorId + "")'></i>&nbsp;"" +
                ""<i class='fa fa-trash' onclick='DeleteDistributor("" + distributorId + "")'></i>"" +
                        ""</div>");
                WriteLiteral(@""";
            return html;
        }
        function GotoDistributorDetail(distributorId) {
            location.href = ""/Distributor/DistributorDetail/"" + distributorId;
        }
        function SearchDistributor() {

            var dataSearch = {
                CustomerTypeId: $(""#ddl-customertype"").val(),
                ProvinceCode: $(""#ddl-province"").val(),
                Keyword: $(""#txtkeyword"").val()
            };
            GenrateDataTableSearch(tableId, ajaxURL, columnData, dataSearch);

        }

        function DeleteDistributor(distributorId) {
            bootbox.confirm(""Bạn có chắc muốn xóa nhà cung cấp này?"", function (confi) {
                    if (confi)
                    {
                        $.ajax({
                            type: ""POST"",
                            contentType: 'application/json; charset=utf-8',
                            url: ""/Distributor/DeleteDistributor/"" + distributorId,
                            dataType: 'json',");
                WriteLiteral(@"
                            success: function (res) {
                                if (res.isSuccess === true) {
                                    SearchDistributor();
                                } else {
                                    bootbox.alert(AlertFail(res.errorMessage));
                                }

                            }
                        });
                    }
             });
        }

    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
