#pragma checksum "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cce899b6d495178094c46acdde0211f0fa4b671f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CreditRequest__PartialCreditItemDetail), @"mvc.1.0.view", @"/Views/CreditRequest/_PartialCreditItemDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CreditRequest/_PartialCreditItemDetail.cshtml", typeof(AspNetCore.Views_CreditRequest__PartialCreditItemDetail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cce899b6d495178094c46acdde0211f0fa4b671f", @"/Views/CreditRequest/_PartialCreditItemDetail.cshtml")]
    public class Views_CreditRequest__PartialCreditItemDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.CreditRequest.CreditRequestItemModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(59, 25, false);
#line 3 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
            EndContext();
            BeginContext(84, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(87, 38, false);
#line 4 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml"
Write(Html.HiddenFor(x => x.CreditRequestId));

#line default
#line hidden
            EndContext();
            BeginContext(125, 161, true);
            WriteLiteral("\r\n<div class=\"form-group\">\r\n\r\n    <div class=\"row\">\r\n        <label class=\"col-md-3 control-label\">Nội dung</label>\r\n        <div class=\"col-md-3\">\r\n            ");
            EndContext();
            BeginContext(287, 61, false);
#line 10 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml"
       Write(Html.TextBoxFor(x => x.Name, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(348, 131, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <label class=\"col-md-3 control-label\">Đơn vị tính</label>\r\n        <div class=\"col-md-3\">\r\n            ");
            EndContext();
            BeginContext(480, 61, false);
#line 15 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml"
       Write(Html.TextBoxFor(x => x.Unit, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(541, 173, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <label class=\"col-md-3 control-label\">Số lượng</label>\r\n        <div class=\"col-md-3\">\r\n            ");
            EndContext();
            BeginContext(715, 63, false);
#line 22 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml"
       Write(Html.TextBoxFor(x => x.Quanti, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(778, 125, true);
            WriteLiteral("\r\n        </div>\r\n        <label class=\"col-md-3 control-label\">Đơn giá</label>\r\n        <div class=\"col-md-3\">\r\n            ");
            EndContext();
            BeginContext(904, 62, false);
#line 26 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml"
       Write(Html.TextBoxFor(x => x.Price, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(966, 174, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <br />\r\n    <div class=\"row\">\r\n        <label class=\"col-md-3 control-label\">Ghi chú</label>\r\n        <div class=\"col-md-9\">\r\n            ");
            EndContext();
            BeginContext(1141, 61, false);
#line 34 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\CreditRequest\_PartialCreditItemDetail.cshtml"
       Write(Html.TextBoxFor(x => x.Note, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1202, 54, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n</div>\r\n<br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.CreditRequest.CreditRequestItemModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
