#pragma checksum "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ea1b368063669a0f8e23e2f30a102c9e1926abd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ListMenuNavigationByRole_LeftMenuNavigation), @"mvc.1.0.view", @"/Views/Shared/Components/ListMenuNavigationByRole/LeftMenuNavigation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/ListMenuNavigationByRole/LeftMenuNavigation.cshtml", typeof(AspNetCore.Views_Shared_Components_ListMenuNavigationByRole_LeftMenuNavigation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ea1b368063669a0f8e23e2f30a102c9e1926abd", @"/Views/Shared/Components/ListMenuNavigationByRole/LeftMenuNavigation.cshtml")]
    public class Views_Shared_Components_ListMenuNavigationByRole_LeftMenuNavigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DAL.Entities.Menu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 238, true);
            WriteLiteral("\r\n<ul class=\"nav nav-pills nav-sidebar flex-column\" data-widget=\"treeview\" role=\"menu\" data-accordion=\"false\">\r\n    <!-- Add icons to the links using the .nav-icon class\r\n         with font-awesome or any other icon font library -->\r\n\r\n\r\n");
            EndContext();
#line 8 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
      
        if (Model.Any())
        {
            foreach (var menuParent in Model.Where(x => x.Parent == 0).OrderBy(x => x.Priority))
            {
                var lstChild = Model.Where(x => x.Parent == menuParent.Id).OrderBy(x => x.Priority);


#line default
#line hidden
            BeginContext(532, 61, true);
            WriteLiteral("                <li class=\"nav-item\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 593, "\"", 617, 1);
#line 16 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
WriteAttributeValue("", 600, menuParent.URL, 600, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(618, 46, true);
            WriteLiteral(" class=\"nav-link\">\r\n                        <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 664, "\"", 703, 2);
            WriteAttributeValue("", 672, "nav-icon", 672, 8, true);
#line 17 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
WriteAttributeValue(" ", 680, menuParent.MenuIcon, 681, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(704, 65, true);
            WriteLiteral("></i> \r\n                        <p>\r\n                            ");
            EndContext();
            BeginContext(771, 15, false);
#line 19 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                        Write(menuParent.Name);

#line default
#line hidden
            EndContext();
            BeginContext(787, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 20 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                              
                                if (lstChild.Any())
                                {

#line default
#line hidden
            BeginContext(909, 77, true);
            WriteLiteral("                                    <i class=\"right fas fa-angle-left\"></i>\r\n");
            EndContext();
#line 24 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(1052, 56, true);
            WriteLiteral("                        </p>\r\n                    </a>\r\n");
            EndContext();
#line 28 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                      
                        
                        if (lstChild.Any())
                        {

#line default
#line hidden
            BeginContext(1230, 61, true);
            WriteLiteral("                            <ul class=\"nav nav-treeview\">\r\n\r\n");
            EndContext();
#line 34 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                                  
                                    foreach (var menuChild in lstChild)
                                    {

#line default
#line hidden
            BeginContext(1439, 63, true);
            WriteLiteral("                                        <li class=\"nav-item\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1502, "\"", 1525, 1);
#line 37 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
WriteAttributeValue("", 1509, menuChild.URL, 1509, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1526, 70, true);
            WriteLiteral(" class=\"nav-link\"><i class=\"far fa-circle nav-icon child-icon\"></i><p>");
            EndContext();
            BeginContext(1598, 14, false);
#line 37 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                                                                                                                                                         Write(menuChild.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1613, 15, true);
            WriteLiteral("</p></a></li>\r\n");
            EndContext();
#line 38 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                                    }
                                

#line default
#line hidden
            BeginContext(1702, 37, true);
            WriteLiteral("\r\n                            </ul>\r\n");
            EndContext();
#line 42 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
                         }



                    

#line default
#line hidden
            BeginContext(1796, 24, true);
            WriteLiteral("                 </li>\r\n");
            EndContext();
#line 48 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\Components\ListMenuNavigationByRole\LeftMenuNavigation.cshtml"
            }
         }
    

#line default
#line hidden
            BeginContext(1854, 23, true);
            WriteLiteral("\r\n\r\n\r\n    \r\n\r\n</ul>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DAL.Entities.Menu>> Html { get; private set; }
    }
}
#pragma warning restore 1591