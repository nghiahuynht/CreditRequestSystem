#pragma checksum "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a184f2b9c618c4f47b2b4a1108c71f7b33a75b37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category__AddMucChi), @"mvc.1.0.view", @"/Views/Category/_AddMucChi.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Category/_AddMucChi.cshtml", typeof(AspNetCore.Views_Category__AddMucChi))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a184f2b9c618c4f47b2b4a1108c71f7b33a75b37", @"/Views/Category/_AddMucChi.cshtml")]
    public class Views_Category__AddMucChi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.Category.CategoryExpenseViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(55, 65, true);
            WriteLiteral("<div class=\"modal-content\">\r\n    <div class=\"modal-header p-2\">\r\n");
            EndContext();
#line 5 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
         if (Model.Id == 0)
        {

#line default
#line hidden
            BeginContext(160, 55, true);
            WriteLiteral("            <h5 class=\"modal-title\">Thêm mục chi</h5>\r\n");
            EndContext();
#line 8 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(251, 60, true);
            WriteLiteral("            <h5 class=\"modal-title\">Chỉnh sửa mục chi</h5>\r\n");
            EndContext();
#line 12 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
        }

#line default
#line hidden
            BeginContext(322, 173, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"content-body\">\r\n        <div class=\"modal-body p-3\">\r\n            <form id=\"frmCreateExpense\">\r\n                <input id=\"a_expense_id\" hidden");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 495, "\"", 512, 1);
#line 18 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
WriteAttributeValue("", 503, Model.Id, 503, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(513, 571, true);
            WriteLiteral(@" />
                <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"">
                    <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-3 mb-0 text-blue"">Thông tin mục chi</legend>

                    <div class=""row"">
                        <div class=""col-md-6"">
                            <label class=""form-label"">Nhóm hoạt động: <span class=""text-red"">*</span></label>
                            <select class=""form-control"" id=""a_nhom_hoat_dong"" name=""nhom_hoat_dong"">
                                <option value=""""></option>
");
            EndContext();
#line 27 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
                                  
                                    foreach (var item in ViewBag.LstActiveGroup)
                                    {
                                        string selected = item.Id == Model.ActiveGroupId ? "selected='selected'" : "";

#line default
#line hidden
            BeginContext(1361, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1408, "\"", 1424, 1);
#line 31 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
WriteAttributeValue("", 1416, item.Id, 1416, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1425, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1428, 8, false);
#line 31 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
                                                             Write(selected);

#line default
#line hidden
            EndContext();
            BeginContext(1437, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1439, 9, false);
#line 31 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
                                                                        Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1448, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 32 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
                                    }
                                

#line default
#line hidden
            BeginContext(1533, 317, true);
            WriteLiteral(@"                            </select>
                        </div>
                        <div class=""col-md-6"">
                            <label class=""form-label"">Mã mục chi: <span class=""text-red"">*</span></label>
                            <input type=""text"" class=""form-control"" id=""a_code"" name=""code""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1850, "\"", 1869, 1);
#line 38 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
WriteAttributeValue("", 1858, Model.Code, 1858, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1870, 390, true);
            WriteLiteral(@" />
                        </div>
                       


                    </div>
                    <div class=""row"">
                        <div class=""col-md-6 "">
                            <label class=""form-label col-auto"">Tên mục chi: <span class=""text-red"">*</span></label>
                            <input type=""text"" class=""form-control"" id=""a_name"" name=""name""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2260, "\"", 2279, 1);
#line 47 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
WriteAttributeValue("", 2268, Model.Name, 2268, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2280, 246, true);
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"col-md-6\">\r\n                            <label class=\"form-label\">Ghi chú:</label>\r\n                            <textarea class=\"form-control\" id=\"a_ghi_chu\" name=\"ghi_chu\">");
            EndContext();
            BeginContext(2527, 11, false);
#line 51 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Category\_AddMucChi.cshtml"
                                                                                    Write(Model.Notes);

#line default
#line hidden
            EndContext();
            BeginContext(2538, 971, true);
            WriteLiteral(@"</textarea>
                        </div>



                    </div>
                </fieldset>

            </form>
        </div>
    </div>
    <div class=""modal-footer p-0"">
        <button type=""button"" class=""btn btn-primary btn-footer"" id=""btnLuuTaoDot"" onclick=""CreateExpense();""><i class=""fas fa-save me-1""></i>&nbsp;Lưu</button>
        <button type=""button"" class=""btn btn-secondary btn-footer"" onclick=""closeModal_Expense();"" data-bs-dismiss=""modal""><i class=""fas fa-times me-1""></i>&nbsp;Đóng</button>
    </div>
</div>

<script>
    $(document).ready(function () {
        if ($(""#a_expense_id"").val() == ""0"") {
            var projectCode = generateCode(""MC"");
            if (projectCode != """") {
                $('#a_code').val(projectCode);
                // $('#a_code').prop('readonly', true);
            }

        }
        else {
            // $('#a_code').prop('readonly', true);
        }
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.Category.CategoryExpenseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591