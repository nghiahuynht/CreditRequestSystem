#pragma checksum "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01b8fd703663e8943467b2b2a504268d3644306e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_FormCreateProjectDetail), @"mvc.1.0.view", @"/Views/Project/FormCreateProjectDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Project/FormCreateProjectDetail.cshtml", typeof(AspNetCore.Views_Project_FormCreateProjectDetail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01b8fd703663e8943467b2b2a504268d3644306e", @"/Views/Project/FormCreateProjectDetail.cshtml")]
    public class Views_Project_FormCreateProjectDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.ProjectFinancialDetail.ProjectFinancialDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(78, 1006, true);
            WriteLiteral(@"<div class=""modal-content"">
    <div class=""modal-header p-2"">
        <h5 class=""modal-title"" id=""promotion-title"">Thông tin hạng mục phân bổ chi tiết</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
            <span aria-hidden=""true"">×</span>
        </button>
    </div>
    <div class=""modal-body"">

        <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"">
            <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-2 mb-0 text-blue"">Thông tin hạng mục phân bổ</legend>
            <form id=""frmCreateProjectDetail"">
                <div class=""form-group"">
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Dự án <span class=""text-red"">*</span></label>
                        <div class=""col-md-3"">

                            <select class=""form-control"" id=""a_du_an"" name=""du_an"" onchange=""handleDuAnChange()"">
                                <option></option>
");
            EndContext();
#line 23 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                 foreach (var hd in Model.LstProject)
                                {
                                    if (hd.Id == Model.data.ProjectId)
                                    {

#line default
#line hidden
            BeginContext(1301, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1348, "\"", 1362, 1);
#line 27 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 1356, hd.Id, 1356, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1363, 10, true);
            WriteLiteral(" selected>");
            EndContext();
            BeginContext(1374, 7, false);
#line 27 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                                   Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1381, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 28 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(1512, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1559, "\"", 1573, 1);
#line 31 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 1567, hd.Id, 1567, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1574, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1576, 7, false);
#line 31 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                          Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1583, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 32 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                    }

                                }

#line default
#line hidden
            BeginContext(1670, 431, true);
            WriteLiteral(@"                            </select>
                        </div>

                        <label class=""col-md-3 control-label"">Nhóm hoạt động <span class=""text-red"">*</span></label>
                        <div class=""col-md-3"">
                            <select class=""form-control"" id=""a_nhom_hoat_dong"" name=""nhom_hoat_dong"" onchange=""handleNhomHoatDongChange()"">
                                <option></option>
");
            EndContext();
#line 42 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                 foreach (var hd in Model.DM_NhomHoatDong)
                                {
                                    if (hd.Id == Model.data.ActivityGroupId)
                                    {

#line default
#line hidden
            BeginContext(2329, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2376, "\"", 2390, 1);
#line 46 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 2384, hd.Id, 2384, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2391, 10, true);
            WriteLiteral(" selected>");
            EndContext();
            BeginContext(2402, 7, false);
#line 46 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                                   Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2409, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 47 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(2540, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2587, "\"", 2601, 1);
#line 50 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 2595, hd.Id, 2595, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2602, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2604, 7, false);
#line 50 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                          Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2611, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 51 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                    }

                                }

#line default
#line hidden
            BeginContext(2698, 501, true);
            WriteLiteral(@"                            </select>
                        </div>


                    </div>
                    <br />
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Mục chi <span class=""text-red"">*</span></label>
                        <div class=""col-md-3"">
                            <select class=""form-control"" id=""a_muc_chi"" name=""muc_chi"" onchange=""handleMucChiChange()"">
                                <option></option>
");
            EndContext();
#line 65 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                 foreach (var hd in Model.DM_MucChi)
                                {
                                    if (hd.Id == Model.data.ExpenseId)
                                    {

#line default
#line hidden
            BeginContext(3415, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3462, "\"", 3476, 1);
#line 69 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 3470, hd.Id, 3470, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3477, 10, true);
            WriteLiteral(" selected>");
            EndContext();
            BeginContext(3488, 7, false);
#line 69 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                                   Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3495, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 70 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(3626, 47, true);
            WriteLiteral("                                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3673, "\"", 3687, 1);
#line 73 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 3681, hd.Id, 3681, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3688, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3690, 7, false);
#line 73 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                          Write(hd.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3697, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 74 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                    }

                                }

#line default
#line hidden
            BeginContext(3784, 308, true);
            WriteLiteral(@"                            </select>
                        </div>


                        <label class=""col-md-3 control-label"">Tiêu chuẩn</label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""a_tieu_chuan"" name=""tieu_chuan""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4092, "\"", 4120, 1);
#line 83 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 4100, Model.data.Standard, 4100, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4121, 396, true);
            WriteLiteral(@" />
                        </div>


                    </div>
                    <br />
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Số lượng</label>
                        <div class=""col-md-3"">
                            <input type=""text"" onchange=""changeSoLuongDonGia()"" class=""form-control"" id=""a_so_luong"" name=""so_luong""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4517, "\"", 4545, 1);
#line 92 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 4525, Model.data.Quantity, 4525, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4546, 306, true);
            WriteLiteral(@" autocomplete=""off"" />
                        </div>

                        <label class=""col-md-3 control-label"">Đơn giá</label>
                        <div class=""col-md-3"">
                            <input type=""text"" onblur=""formatDonGia()"" class=""form-control"" id=""a_don_gia"" name=""don_gia""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4852, "\"", 4877, 1);
#line 97 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 4860, Model.data.Price, 4860, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4878, 100, true);
            WriteLiteral(" autocomplete=\"off\" />\r\n                            <input type=\"hidden\" id=\"a_don_gia_khong_format\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4978, "\"", 5003, 1);
#line 98 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 4986, Model.data.Price, 4986, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5004, 428, true);
            WriteLiteral(@" />
                        </div>


                    </div>
                    <br />
                    <div class=""row"">
                        <label class=""col-md-3 control-label"">Thành tiền <span class=""text-red"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""text"" onblur=""formatThanhTien()"" class=""form-control"" id=""a_thanh_tien"" name=""thanh_tien""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5432, "\"", 5463, 1);
#line 107 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 5440, Model.data.TotalAmount, 5440, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5464, 103, true);
            WriteLiteral(" autocomplete=\"off\" />\r\n                            <input type=\"hidden\" id=\"a_thanh_tien_khong_format\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 5567, "\"", 5592, 1);
#line 108 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 5575, Model.data.Price, 5575, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5593, 261, true);
            WriteLiteral(@" />
                        </div>

                        <label class=""col-md-3 control-label"">Ghi chú</label>
                        <div class=""col-md-3"">
                            <textarea class=""form-control"" rows=""3"" id=""a_ghi_chu_tt_chi_tiet"">");
            EndContext();
            BeginContext(5855, 16, false);
#line 113 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                                                          Write(Model.data.Notes);

#line default
#line hidden
            EndContext();
            BeginContext(5871, 2418, true);
            WriteLiteral(@"</textarea>
                        </div>


                    </div>
                </div>
            </form>
        </fieldset>

        <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"" style=""display:none"" id=""region_thong_tin_du_an"">
            <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-2 mb-0 text-blue"">Thông tin chương trình/dự án/dịch vụ</legend>
            <div class=""row"">
                <label class=""col-md-3 control-label"">Mã dự án</label>
                <div class=""col-md-3"">
                    <input class=""form-control"" id=""a_ma_du_an"" value="""" readonly />
                </div>

                <label class=""col-md-3 control-label"">Tên dự án</label>
                <div class=""col-md-3"">
                    <input class=""form-control"" id=""a_ten_du_an"" value="""" readonly />
                </div>
            </div>
            <br />
            <div class=""row"">
                <label class=""col-md-3 control-label"">Tổng hạn mức</label>");
            WriteLiteral(@"
                <div class=""col-md-3"">
                    <input class=""form-control"" id=""a_tong_han_muc"" value="""" readonly />
                    <input hidden id=""a_tong_han_muc_khong_format"" value="""" readonly />
                </div>

                <label class=""col-md-3 control-label"">Tổng số tiền đã phân bổ</label>
                <div class=""col-md-3"">
                    <input class=""form-control"" id=""a_so_tien_da_phan_bo"" value="""" readonly />
                    <input hidden id=""a_so_tien_da_phan_bo_khong_format"" value="""" readonly />
                </div>
            </div>
        </fieldset>

        <fieldset class=""border rounded-1 pb-3 pe-3 ps-3 mb-3"">
            <legend class=""float-none w-auto px-3 text-uppercase fw-bold fs-2 mb-0 text-blue"">Thông tin hồ sơ thanh toán</legend>
            <table class=""table table-bordered"" width=""100%"">
                <thead>
                    <tr>
                        <th>Mã hồ sơ</th>
                        <th>Tên hồ sơ</");
            WriteLiteral(@"th>
                        <th>Ghi chú</th>
                        <th>Tệp đính kèm</th>
                        <th width=""60px""><button onclick=""AddFormPaymentProfile()"" class=""btn btn-sm btn-warning""><i class=""fa fa-plus-circle""></i></button></th>
                    </tr>
                </thead>
                <tbody id=""table_thong_tin_hs_thanh_toan"">
");
            EndContext();
#line 164 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                     if (Model.DM_HSThanhToan != null && Model.DM_HSThanhToan.Count() > 0)
                    {
                        foreach (var hd in Model.DM_HSThanhToan)
                        {

#line default
#line hidden
            BeginContext(8497, 162, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <input name=\"ma_hs_thanh_toan\" id=\"a_ma_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 8659, "\"", 8686, 1);
#line 170 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 8667, hd.PaymentInfoCode, 8667, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8687, 204, true);
            WriteLiteral(" class=\"form-control\" readonly />\r\n                                </td>\r\n                                <td>\r\n                                    <input name=\"ten_hs_thanh_toan\" id=\"a_ten_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 8891, "\"", 8918, 1);
#line 173 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 8899, hd.PaymentInfoName, 8899, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8919, 212, true);
            WriteLiteral(" class=\"form-control\" readonly />\r\n                                </td>\r\n                                <td>\r\n                                    <input name=\"ghi_chu_hs_thanh_toan\" id=\"a_ghi_chu_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 9131, "\"", 9148, 1);
#line 176 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 9139, hd.Notes, 9139, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(9149, 150, true);
            WriteLiteral(" class=\"form-control\" readonly />\r\n                                </td>\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 9299, "\"", 9317, 1);
#line 179 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 9306, hd.URLPath, 9306, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(9318, 85, true);
            WriteLiteral(" name=\"tep_dinh_kem_hs_thanh_toan\" id=\"a_tep_dinh_kem_hs_thanh_toan\" target=\"_blank\">");
            EndContext();
            BeginContext(9404, 11, false);
#line 179 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                                                                                                                                         Write(hd.FileName);

#line default
#line hidden
            EndContext();
            BeginContext(9415, 96, true);
            WriteLiteral("</a>\r\n                                    <input type=\"hidden\" name=\"tep_dinh_kem_hs_thanh_toan\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 9511, "\"", 9533, 1);
#line 180 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 9519, hd.FileAttach, 9519, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(9534, 170, true);
            WriteLiteral(" />\r\n                                </td>\r\n                                <td style=\"text-align:center;\">\r\n                                    <span class=\"fa fa-trash\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 9704, "\"", 9750, 3);
            WriteAttributeValue("", 9714, "RemovePaymentProfile(", 9714, 21, true);
#line 183 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 9735, hd.FileAttach, 9735, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 9749, ")", 9749, 1, true);
            EndWriteAttribute();
            BeginContext(9751, 84, true);
            WriteLiteral("></span>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 186 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                        }
                    }

#line default
#line hidden
            BeginContext(9885, 263, true);
            WriteLiteral(@"
                </tbody>
            </table>
        </fieldset>



    </div>
    <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-warning"" onclick=""CreateProjectDetail()"">Lưu</button>
        <input hidden id=""ProjectDetailId""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 10148, "\"", 10170, 1);
#line 198 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 10156, Model.data.Id, 10156, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(10171, 59, true);
            WriteLiteral(" />\r\n        <input hidden id=\"so_tien_truoc_khi_chinh_sua\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 10230, "\"", 10261, 1);
#line 199 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
WriteAttributeValue("", 10238, Model.data.TotalAmount, 10238, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(10262, 240, true);
            WriteLiteral(" />\r\n    </div>\r\n   \r\n</div>\r\n<script>\r\n    $(document).ready(function () {\r\n        formatThanhTien();\r\n        formatDonGia();\r\n        if ($(\'#ProjectDetailId\').val() != \"0\") {\r\n            handleDuAnChange();\r\n\r\n            var items = ");
            EndContext();
            BeginContext(10503, 46, false);
#line 210 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\FormCreateProjectDetail.cshtml"
                   Write(Html.Raw(Json.Serialize(Model.DM_HSThanhToan)));

#line default
#line hidden
            EndContext();
            BeginContext(10549, 879, true);
            WriteLiteral(@";
            if (items != null) {
                arrPaymentProfile = [];
                items.forEach(function (item) {
                    var dataPost = {
                        Id: item.id,
                        ProjectDetailId: item.projectDetailId,
                        ActiveGroupId: item.activeGroupId,
                        ProfileId: item.profileId,
                        PaymentInfoCode: item.paymentInfoCode.trim(),
                        PaymentInfoName: item.paymentInfoName.trim(),
                        Notes: item.notes ? item.notes.trim() : """",
                        FileAttach: item.fileAttach != null ? item.fileAttach : 0,
                        IsUpdate: true
                    };
                    arrPaymentProfile.push(dataPost);
                });
            }
        }
       
        
    });
</script>
");
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