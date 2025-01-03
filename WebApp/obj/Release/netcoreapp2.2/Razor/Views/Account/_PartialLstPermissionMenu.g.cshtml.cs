#pragma checksum "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98f35014c97937ca04e3a33aac1d64923591e87f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account__PartialLstPermissionMenu), @"mvc.1.0.view", @"/Views/Account/_PartialLstPermissionMenu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/_PartialLstPermissionMenu.cshtml", typeof(AspNetCore.Views_Account__PartialLstPermissionMenu))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98f35014c97937ca04e3a33aac1d64923591e87f", @"/Views/Account/_PartialLstPermissionMenu.cshtml")]
    public class Views_Account__PartialLstPermissionMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Models.PermissionMenu.PermisionRoleMenuViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 218, true);
            WriteLiteral("<table class=\"table table-bordered dataTable\">\r\n    <thead>\r\n        <tr>\r\n            <th width=\"50\">#</th>\r\n            <th>Chức năng</th>\r\n            <th width=\"50\"></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 11 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
          
            int noParent = 0;
            foreach (var menu in Model.LstMenu.Where(x => x.Parent == 0))
            {
                noParent++;
                

#line default
#line hidden
            BeginContext(459, 68, true);
            WriteLiteral("                <tr class=\"bg-gray-light\">\r\n                    <td>");
            EndContext();
            BeginContext(529, 8, false);
#line 18 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
                    Write(noParent);

#line default
#line hidden
            EndContext();
            BeginContext(538, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(571, 9, false);
#line 19 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
                    Write(menu.Name);

#line default
#line hidden
            EndContext();
            BeginContext(581, 79, true);
            WriteLiteral("</td>\r\n                    <td class=\"dt-center\"></td>\r\n                </tr>\r\n");
            EndContext();
#line 22 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"

                int noChild = 0;

                foreach (var child in Model.LstMenu.Where(x => x.Parent == menu.Id))
                {
                    noChild++;
                    string noChildText = noParent + "." + noChild;
                    string checkedTextChild = Model.LstMenuRole.Any(x => x.MenuId == child.Id) ? "checked='checked'" : string.Empty;

#line default
#line hidden
            BeginContext(1037, 72, true);
            WriteLiteral("                    <tr>\r\n                        <td class=\"dt-center\">");
            EndContext();
            BeginContext(1111, 11, false);
#line 31 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
                                          Write(noChildText);

#line default
#line hidden
            EndContext();
            BeginContext(1123, 71, true);
            WriteLiteral("</td>\r\n                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            EndContext();
            BeginContext(1196, 10, false);
#line 32 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
                                                            Write(child.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1207, 59, true);
            WriteLiteral("</td>\r\n                        <td class=\"dt-center\"><input");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1266, "\"", 1309, 3);
            WriteAttributeValue("", 1276, "UpdatePermissionMenu(", 1276, 21, true);
#line 33 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
WriteAttributeValue("", 1297, child.Id, 1297, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 1308, ")", 1308, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1310, "\"", 1335, 2);
            WriteAttributeValue("", 1318, "child_", 1318, 6, true);
#line 33 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
WriteAttributeValue("", 1324, child.Id, 1324, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1336, 17, true);
            WriteLiteral(" type=\"checkbox\" ");
            EndContext();
            BeginContext(1355, 16, false);
#line 33 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
                                                                                                                                       Write(checkedTextChild);

#line default
#line hidden
            EndContext();
            BeginContext(1372, 37, true);
            WriteLiteral(" /></td>\r\n                    </tr>\r\n");
            EndContext();
#line 35 "D:\Projects\OnGit\CreditRequestSystem\WebApp\Views\Account\_PartialLstPermissionMenu.cshtml"
                }
            }
        

#line default
#line hidden
            BeginContext(1454, 31, true);
            WriteLiteral("    </tbody>\r\n       \r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Models.PermissionMenu.PermisionRoleMenuViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
