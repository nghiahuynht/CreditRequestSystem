#pragma checksum "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34e984acd7730cb29111e0b296c3cb7a3984ac24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TranFin__PartialThuByContract), @"mvc.1.0.view", @"/Views/TranFin/_PartialThuByContract.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TranFin/_PartialThuByContract.cshtml", typeof(AspNetCore.Views_TranFin__PartialThuByContract))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34e984acd7730cb29111e0b296c3cb7a3984ac24", @"/Views/TranFin/_PartialThuByContract.cshtml")]
    public class Views_TranFin__PartialThuByContract : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DAL.Entities.TransactionFin>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 518, true);
            WriteLiteral(@"<br />
<h5>Danh sách các khoản thu</h5>
<table class=""table table-bordered dataTable"">
    <thead>
        <tr>
            <th>#</th>
            <th>Danh mục thu</th>
            <th>Ngày thu</th>
            <th>Số tiền</th>
            <th>Phương thức</th>
            <th>Người thực hiện</th>
            <th>Số hoá đơn</th>
            <th>Ngày hoá đơn</th>
            <th>Người nhận</th>
            <th>Ghi chú</th>
            <th width=""40px""></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 21 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
          
            var lstThu = Model.Where(x => x.TranType == "thu").ToList();
            decimal tongThu = 0;
            if (lstThu.Any())
            {
                int sttThu = 1;

                foreach (var itemThu in lstThu)
                {
                    tongThu += itemThu.Amount.HasValue ? itemThu.Amount.Value : 0;

#line default
#line hidden
            BeginContext(913, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(945, 6, false);
#line 32 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(sttThu);

#line default
#line hidden
            EndContext();
            BeginContext(952, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(977, 20, false);
#line 33 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(998, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1023, 88, false);
#line 34 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.TranDate.HasValue ? itemThu.TranDate.Value.ToString("dd/MM/yyyy") : string.Empty);

#line default
#line hidden
            EndContext();
            BeginContext(1112, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1137, 70, false);
#line 35 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.Amount.HasValue ? itemThu.Amount.Value.ToString("#,##0") : "0");

#line default
#line hidden
            EndContext();
            BeginContext(1208, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1233, 14, false);
#line 36 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.Method);

#line default
#line hidden
            EndContext();
            BeginContext(1248, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1273, 16, false);
#line 37 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.ActionBy);

#line default
#line hidden
            EndContext();
            BeginContext(1290, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1315, 17, false);
#line 38 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.InvoiceNo);

#line default
#line hidden
            EndContext();
            BeginContext(1333, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1358, 94, false);
#line 39 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.InvoiceDate.HasValue ? itemThu.InvoiceDate.Value.ToString("dd/MM/yyyy") : string.Empty);

#line default
#line hidden
            EndContext();
            BeginContext(1453, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1478, 16, false);
#line 40 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.Receiver);

#line default
#line hidden
            EndContext();
            BeginContext(1495, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1520, 12, false);
#line 41 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            Write(itemThu.Note);

#line default
#line hidden
            EndContext();
            BeginContext(1533, 47, true);
            WriteLiteral("</td>\r\n            <td><span class=\"fa fa-edit\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1580, "\"", 1623, 3);
            WriteAttributeValue("", 1590, "OpenModalThuChi(", 1590, 16, true);
#line 42 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
WriteAttributeValue("", 1606, itemThu.Id, 1606, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 1619, ",\'\')", 1619, 4, true);
            EndWriteAttribute();
            BeginContext(1624, 40, true);
            WriteLiteral("></span>&nbsp; <span class=\"fa fa-trash\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1664, "\"", 1701, 3);
            WriteAttributeValue("", 1674, "DeleteThuChi(", 1674, 13, true);
#line 42 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
WriteAttributeValue("", 1687, itemThu.Id, 1687, 13, false);

#line default
#line hidden
            WriteAttributeValue("", 1700, ")", 1700, 1, true);
            EndWriteAttribute();
            BeginContext(1702, 30, true);
            WriteLiteral("></span></td>\r\n        </tr>\r\n");
            EndContext();
#line 44 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
                    sttThu++;
                }

#line default
#line hidden
            BeginContext(1782, 172, true);
            WriteLiteral("                <tr>\r\n                    <td colspan=\"7\" class=\"text-right\"><strong>Tổng thu</strong></td>\r\n                    <td colspan=\"4\" class=\"text-right\"><strong>");
            EndContext();
            BeginContext(1956, 25, false);
#line 48 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
                                                           Write(tongThu.ToString("#,##0"));

#line default
#line hidden
            EndContext();
            BeginContext(1982, 39, true);
            WriteLiteral("</strong></td>\r\n                </tr>\r\n");
            EndContext();
#line 50 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"

            }
            else
            {

#line default
#line hidden
            BeginContext(2071, 119, true);
            WriteLiteral("                <tr>\r\n                    <td colspan=\"11\"><span>Chưa có khoản thu</span></td>\r\n                </tr>\r\n");
            EndContext();
#line 57 "F:\Projects\OnSVN\IchiWeb\WebApp\Views\TranFin\_PartialThuByContract.cshtml"
            }
        

#line default
#line hidden
            BeginContext(2216, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DAL.Entities.TransactionFin>> Html { get; private set; }
    }
}
#pragma warning restore 1591
