#pragma checksum "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d905e4da81931139fde913d612a77877b0ddfa92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_FormViewDetailProjectDetail), @"mvc.1.0.view", @"/Views/Project/FormViewDetailProjectDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Project/FormViewDetailProjectDetail.cshtml", typeof(AspNetCore.Views_Project_FormViewDetailProjectDetail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d905e4da81931139fde913d612a77877b0ddfa92", @"/Views/Project/FormViewDetailProjectDetail.cshtml")]
    public class Views_Project_FormViewDetailProjectDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.ProjectFinancialDetail.ProjectFinancialDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(78, 368, true);
            WriteLiteral(@"<div class=""modal-content"">
    <div class=""modal-header p-2"">
        <h5 class=""modal-title"" id=""promotion-title"">Thông tin hạng mục phân bổ chi tiết</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
            <span aria-hidden=""true"">×</span>
        </button>
    </div>
    <div class=""modal-body"">
        <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 446, "\"", 468, 1);
#line 12 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 454, Model.data.Id, 454, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(469, 713, true);
            WriteLiteral(@" hidden id=""PaymentProFileForProjectDetailId"" />
        <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"">
            <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-2 mb-0 text-blue"">Thông tin hạng mục phân bổ</legend>
            <form id=""frmCreateProjectDetail"">
                <div class=""form-group"">
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Nhóm hoạt động <span class=""text-red"">*</span></label>
                        <div class=""col-md-3"">
                            <select class=""form-control"" id=""a_nhom_hoat_dong"" name=""nhom_hoat_dong"" readonly disabled>
                                <option></option>
");
            EndContext();
#line 22 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                                 foreach (var hd in Model.DM_NhomHoatDong)
                                {
                                    if (hd.Id == Model.data.ActivityGroupId)
                                    {

#line default
#line hidden
            BeginContext(1410, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1457, "\"", 1471, 1);
#line 26 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 1465, hd.Id, 1465, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1472, 10, true);
            WriteLiteral(" selected>");
            EndContext();
            BeginContext(1483, 7, false);
#line 26 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                                                                   Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1490, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 27 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(1621, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1668, "\"", 1682, 1);
#line 30 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 1676, hd.Id, 1676, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1683, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1685, 7, false);
#line 30 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                                                          Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1692, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 31 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                                    }

                                }

#line default
#line hidden
            BeginContext(1779, 329, true);
            WriteLiteral(@"                            </select>
                        </div>

                        <label class=""col-md-3 control-label"">Mục chi <span class=""text-red"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""a_muc_chi"" name=""muc_chi""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2108, "\"", 2137, 1);
#line 39 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 2116, Model.data.ExpenseId, 2116, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2138, 374, true);
            WriteLiteral(@" readonly />
                        </div>
                    </div>
                    <br />
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Tiêu chuẩn</label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""a_tieu_chuan"" name=""tieu_chuan""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2512, "\"", 2540, 1);
#line 46 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 2520, Model.data.Standard, 2520, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2541, 275, true);
            WriteLiteral(@" readonly />
                        </div>

                        <label class=""col-md-3 control-label"">Số lượng</label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""a_so_luong"" name=""so_luong""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2816, "\"", 2844, 1);
#line 51 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 2824, Model.data.Quantity, 2824, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2845, 365, true);
            WriteLiteral(@" readonly />
                        </div>
                    </div>
                    <br />
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Đơn giá</label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""a_don_gia"" name=""don_gia""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3210, "\"", 3235, 1);
#line 58 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 3218, Model.data.Price, 3218, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3236, 313, true);
            WriteLiteral(@" readonly />
                        </div>

                        <label class=""col-md-3 control-label"">Thành tiền <span class=""text-red"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""a_thanh_tien"" name=""thanh_tien""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3549, "\"", 3580, 1);
#line 63 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 3557, Model.data.TotalAmount, 3557, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3581, 372, true);
            WriteLiteral(@" readonly />
                        </div>
                    </div>
                    <br />
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Ghi chú</label>
                        <div class=""col-md-9"">
                            <textarea class=""form-control"" rows=""3"" id=""a_ghi_chu_tt_chi_tiet"" readonly>");
            EndContext();
            BeginContext(3954, 16, false);
#line 70 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                                                                                                   Write(Model.data.Notes);

#line default
#line hidden
            EndContext();
            BeginContext(3970, 745, true);
            WriteLiteral(@"</textarea>
                        </div>


                    </div>
                </div>
            </form>
        </fieldset>

        <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"">
            <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-2 mb-0 text-blue"">Thông tin hồ sơ thanh toán</legend>
            <table class=""table table-bordered"" width=""100%"">
                <thead>
                    <tr>
                        <th>Mã hồ sơ</th>
                        <th>Tên hồ sơ</th>
                        <th>Ghi chú</th>
                        <th width=""60px""></th>
                    </tr>
                </thead>
                <tbody id=""table_thong_tin_hs_thanh_toan"">
");
            EndContext();
#line 91 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                     if (Model.HSThanhToan.Count() == 0)
                    {
                        foreach (var hs in Model.DM_HSThanhToan)
                        {

#line default
#line hidden
            BeginContext(4889, 162, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <input name=\"ma_hs_thanh_toan\" id=\"a_ma_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5051, "\"", 5078, 1);
#line 97 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 5059, hs.PaymentInfoCode, 5059, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5079, 195, true);
            WriteLiteral(" class=\"form-control\" />\r\n                                </td>\r\n                                <td>\r\n                                    <input name=\"ten_hs_thanh_toan\" id=\"a_ten_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5274, "\"", 5301, 1);
#line 100 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 5282, hs.PaymentInfoName, 5282, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5302, 203, true);
            WriteLiteral(" class=\"form-control\" />\r\n                                </td>\r\n                                <td>\r\n                                    <input name=\"ghi_chu_hs_thanh_toan\" id=\"a_ghi_chu_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5505, "\"", 5522, 1);
#line 103 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 5513, hs.Notes, 5513, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5523, 191, true);
            WriteLiteral(" class=\"form-control\" />\r\n                                </td>\r\n                                <td style=\"text-align:center;\">\r\n                                    <span class=\"fa fa-check\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 5714, "\"", 5743, 3);
            WriteAttributeValue("", 5724, "SaveProfile(", 5724, 12, true);
#line 106 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 5736, hs.Id, 5736, 6, false);

#line default
#line hidden
            WriteAttributeValue("", 5742, ")", 5742, 1, true);
            EndWriteAttribute();
            BeginContext(5744, 78, true);
            WriteLiteral("></span> &nbsp;\r\n                                    <span class=\"fa fa-trash\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 5822, "\"", 5860, 3);
            WriteAttributeValue("", 5832, "RemovePaymentProfile(", 5832, 21, true);
#line 107 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 5853, hs.Id, 5853, 6, false);

#line default
#line hidden
            WriteAttributeValue("", 5859, ")", 5859, 1, true);
            EndWriteAttribute();
            BeginContext(5861, 84, true);
            WriteLiteral("></span>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 110 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                        }
                    }
                    else
                    {
                        foreach (var hs in Model.HSThanhToan)
                        {

#line default
#line hidden
            BeginContext(6134, 162, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <input name=\"ma_hs_thanh_toan\" id=\"a_ma_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6296, "\"", 6323, 1);
#line 118 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 6304, hs.PaymentInfoCode, 6304, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6324, 203, true);
            WriteLiteral(" class=\"form-control\" readonly/>\r\n                                </td>\r\n                                <td>\r\n                                    <input name=\"ten_hs_thanh_toan\" id=\"a_ten_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6527, "\"", 6554, 1);
#line 121 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 6535, hs.PaymentInfoName, 6535, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6555, 211, true);
            WriteLiteral(" class=\"form-control\" readonly/>\r\n                                </td>\r\n                                <td>\r\n                                    <input name=\"ghi_chu_hs_thanh_toan\" id=\"a_ghi_chu_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6766, "\"", 6783, 1);
#line 124 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 6774, hs.Notes, 6774, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6784, 149, true);
            WriteLiteral(" class=\"form-control\" readonly/>\r\n                                </td>\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6933, "\"", 6951, 1);
#line 127 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 6940, hs.URLPath, 6940, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6952, 85, true);
            WriteLiteral(" name=\"tep_dinh_kem_hs_thanh_toan\" id=\"a_tep_dinh_kem_hs_thanh_toan\" target=\"_blank\">");
            EndContext();
            BeginContext(7038, 11, false);
#line 127 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                                                                                                                                         Write(hs.FileName);

#line default
#line hidden
            EndContext();
            BeginContext(7049, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
            BeginContext(7176, 74, true);
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 131 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
                        }
                    }

#line default
#line hidden
            BeginContext(7300, 172, true);
            WriteLiteral("\r\n                </tbody>\r\n                </table>\r\n        </fieldset>\r\n\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n       \r\n        <input hidden id=\"ProjectDetailId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 7472, "\"", 7494, 1);
#line 141 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 7480, Model.data.Id, 7480, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7495, 47, true);
            WriteLiteral(" />\r\n        <input hidden id=\"ActivityGroupId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 7542, "\"", 7577, 1);
#line 142 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormViewDetailProjectDetail.cshtml"
WriteAttributeValue("", 7550, Model.data.ActivityGroupId, 7550, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7578, 29, true);
            WriteLiteral(" />\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.ProjectFinancialDetail.ProjectFinancialDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591