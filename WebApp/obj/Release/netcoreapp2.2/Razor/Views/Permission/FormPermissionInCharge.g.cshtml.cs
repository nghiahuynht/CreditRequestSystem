#pragma checksum "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68290a54d058148354fff34ce4338b5aa1118886"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Permission_FormPermissionInCharge), @"mvc.1.0.view", @"/Views/Permission/FormPermissionInCharge.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Permission/FormPermissionInCharge.cshtml", typeof(AspNetCore.Views_Permission_FormPermissionInCharge))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68290a54d058148354fff34ce4338b5aa1118886", @"/Views/Permission/FormPermissionInCharge.cshtml")]
    public class Views_Permission_FormPermissionInCharge : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.Permission.PermissionInChargeModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(56, 229, true);
            WriteLiteral("<div class=\"modal-content\">\r\n    <div class=\"modal-header p-2\">\r\n        <h5 class=\"modal-title\">Phân quyền nhân viên phụ trách</h5>\r\n\r\n    </div>\r\n    <div class=\"content-body\">\r\n\r\n        <input hidden id=\"PermissionInChargeId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 285, "\"", 307, 1);
#line 10 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
WriteAttributeValue("", 293, Model.data.Id, 293, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(308, 40, true);
            WriteLiteral(" />\r\n        <input hidden id=\"UserName\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 348, "\"", 373, 1);
#line 11 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
WriteAttributeValue("", 356, ViewBag.UserName, 356, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(374, 38, true);
            WriteLiteral(" />\r\n        <input hidden id=\"UserId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 412, "\"", 435, 1);
#line 12 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
WriteAttributeValue("", 420, ViewBag.UserId, 420, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(436, 725, true);
            WriteLiteral(@" />
        <div class=""modal-body p-3"">
            <form id=""frmCreatePermissionInCharge"">

                <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"">
                    <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-3 mb-0 text-blue"">Thông tin phân quyên nhân viên phụ trách</legend>

                    <div class=""row"">
                        <div class=""col-md-6"">
                            <label class=""col-md-6 control-label"">Dự án <span class=""text-red"">*</span></label>
                            <div class=""col-md-6"">

                                <select class=""form-control"" id=""a_du_an"" name=""du_an"" >
                                    <option></option>
");
            EndContext();
#line 26 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
                                     foreach (var hd in Model.LstProject)
                                    {

#line default
#line hidden
            BeginContext(1275, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1322, "\"", 1336, 1);
#line 28 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
WriteAttributeValue("", 1330, hd.Id, 1330, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1337, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1339, 7, false);
#line 28 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
                                                          Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1346, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 29 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"

                                    }

#line default
#line hidden
            BeginContext(1398, 818, true);
            WriteLiteral(@"                                </select>
                            </div>
                        </div>
                       

                    </div>
                   
                </fieldset>
                <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"">
                    <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-3 mb-0 text-blue"">Thông tin các dự án/hoạt động phụ trách </legend>

                    <table class=""table table-bordered"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Dự án</th>
                                <th></th>

                            </tr>
                        </thead>
                        <tbody id=""table_thong_tin_nhan_vien_phu_trach"">
");
            EndContext();
#line 51 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
                             foreach (var item in Model.lstPermissionProject)
                            {

#line default
#line hidden
            BeginContext(2326, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2447, 16, false);
#line 55 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
                                   Write(item.ProjectName);

#line default
#line hidden
            EndContext();
            BeginContext(2463, 183, true);
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td style=\"text-align:center;\">\r\n\r\n                                        <span class=\"fa fa-trash\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2646, "\"", 2693, 3);
            WriteAttributeValue("", 2656, "RemovePermissionProjectById(", 2656, 28, true);
#line 60 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
WriteAttributeValue("", 2684, item.Id, 2684, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 2692, ")", 2692, 1, true);
            EndWriteAttribute();
            BeginContext(2694, 92, true);
            WriteLiteral("></span>\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 63 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Permission\FormPermissionInCharge.cshtml"
                            }

#line default
#line hidden
            BeginContext(2817, 636, true);
            WriteLiteral(@"                        </tbody>
                    </table>
                </fieldset>
            </form>
        </div>
    </div>
    <div class=""modal-footer p-0"">
        <button type=""button"" class=""btn btn-primary btn-footer"" id=""btnLuuTaoDot"" onclick=""CreatePermissionInCharge();""><i class=""fas fa-save me-1""></i>&nbsp;Lưu</button>
        <button type=""button"" class=""btn btn-secondary btn-footer"" onclick=""closeModal_PermissionInCharge();"" data-bs-dismiss=""modal""><i class=""fas fa-times me-1""></i>&nbsp;Đóng</button>
    </div>
</div>
<script>

    $(document).ready(function () {
        
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.Permission.PermissionInChargeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591