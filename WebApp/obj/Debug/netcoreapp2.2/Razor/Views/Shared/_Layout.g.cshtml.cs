#pragma checksum "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e6ec72eb131f2bc7db09b8e6639b836f40d987c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Layout.cshtml", typeof(AspNetCore.Views_Shared__Layout))]
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
#line 1 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e6ec72eb131f2bc7db09b8e6639b836f40d987c", @"/Views/Shared/_Layout.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/fontawesome-free/css/all.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/adminlte.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/bootstrap/js/bootstrap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/adminlte.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/bootbox/bootbox.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/bootstrap3-typehead/bootstrap3-typeahead.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app-script/helper.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition sidebar-mini skin-yellow text-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
   
    string roleCode = string.Empty;
    string fullName = string.Empty;

#line default
#line hidden
            BeginContext(113, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(138, 1330, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c7449", async() => {
                BeginContext(144, 302, true);
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>ICHI SKILL</title>

    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback"">
    <!-- Font Awesome -->

    ");
                EndContext();
                BeginContext(446, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c8141", async() => {
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
                BeginContext(517, 137, true);
                WriteLiteral("\r\n    <!-- Ionicons -->\r\n    <link rel=\"stylesheet\" href=\"https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">\r\n\r\n\r\n    ");
                EndContext();
                BeginContext(654, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c9618", async() => {
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
                BeginContext(706, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(712, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c10950", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(763, 653, true);
                WriteLiteral(@"
    <style>
        .child-icon{
            font-size:10pt !important;
            margin-left:10px;
        }
        .dataTables_processing {
            background: #ffc107;
        }
        #popup-overlay {
            position: fixed;
            background-color: rgba(0, 0, 0, 0.685);
            width: 100%;
            height: 95vh;
            top: 0;
            left: 0;
            z-index: 9998;
            display: block;
            overflow-y: hidden;
            overflow-x: hidden;
            display: none;
        }

        #content-wating {
            margin-top: 20%;
        }
    </style>
    ");
                EndContext();
                BeginContext(1417, 40, false);
#line 49 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
Write(RenderSection("styles", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(1457, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1468, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1470, 5037, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c14099", async() => {
                BeginContext(1533, 670, true);
                WriteLiteral(@"
    <div class=""wrapper"">
        <!-- Navbar -->
        <nav class=""main-header navbar navbar-expand navbar-yellow"">
            <!-- Left navbar links -->
            <ul class=""navbar-nav"">
                <li class=""nav-item d-none d-sm-inline-block"">
                    <a href=""#"" class=""nav-link text-dark"">HỆ THỐNG QUẢN LÝ NGHIỆP VỤ DỰ TOÁN/THANH TOÁN</a>
                </li>
            </ul>
            <!-- SEARCH FORM -->
           
            <!-- Right navbar links -->
            <ul class=""navbar-nav ml-auto"">
              
                <!-- Notifications Dropdown Menu -->
                <li class=""nav-item dropdown"">

");
                EndContext();
#line 70 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
                      

                        if (User.Identity.IsAuthenticated)
                        {
                            roleCode = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                            fullName = User.Claims.FirstOrDefault(x => x.Type == "FullName").Value;

                        }
                    

#line default
#line hidden
                BeginContext(2575, 143, true);
                WriteLiteral("\r\n                    <a class=\"nav-link text-dark\" data-toggle=\"dropdown\" href=\"#\">\r\n                        <i class=\"far fa-user\"></i>&nbsp;");
                EndContext();
                BeginContext(2720, 8, false);
#line 81 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
                                                     Write(fullName);

#line default
#line hidden
                EndContext();
                BeginContext(2729, 307, true);
                WriteLiteral(@"
                    </a>
                    <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right text-dark"">
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <i class=""fas fa-user mr-2""></i> ");
                EndContext();
                BeginContext(3038, 18, false);
#line 86 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
                                                         Write(User.Identity.Name);

#line default
#line hidden
                EndContext();
                BeginContext(3057, 216, true);
                WriteLiteral("\r\n                        </a>\r\n                        <div class=\"dropdown-divider\"></div>\r\n                        <a href=\"#\" class=\"dropdown-item\">\r\n                            <i class=\"fas fa-users mr-2\"></i> ");
                EndContext();
                BeginContext(3275, 8, false);
#line 90 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
                                                          Write(roleCode);

#line default
#line hidden
                EndContext();
                BeginContext(3284, 120, true);
                WriteLiteral("\r\n                        </a>\r\n                        <div class=\"dropdown-divider\"></div>\r\n                        <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3404, "\"", 3456, 2);
                WriteAttributeValue("", 3411, "/account/ChangePassword/", 3411, 24, true);
#line 93 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3435, User.Identity.Name, 3435, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3457, 1248, true);
                WriteLiteral(@" class=""dropdown-item"">
                            <i class=""fas fa-lock mr-2""></i>Đổi mật khẩu
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""/account/logout"" class=""dropdown-item"">
                            <i class=""fa fa-level-down""></i>Đăng xuất hệ thống
                        </a>

                    </div>
                </li>

                <li class=""nav-item"" style=""display:none;"">
                    <a class=""nav-link"" data-widget=""control-sidebar"" data-slide=""true"" href=""#"" role=""button"">
                        <i class=""fas fa-th-large""></i>
                    </a>

                </li>

            </ul>
        </nav>
        <!-- /.navbar -->
        <!-- Main Sidebar Container -->
        <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
            <!-- Brand Logo -->
            <a href=""https://ichi.gamanjsc.com/home/index"" class=""brand-link"" style=""background:#e08e0b");
                WriteLiteral(";\">\r\n                <span style=\"font-weight:bold;\">CDC</span>\r\n            </a>\r\n            <!-- Sidebar -->\r\n            <div class=\"sidebar \">\r\n                <!-- Sidebar Menu -->\r\n                <nav class=\"mt-2\">\r\n");
                EndContext();
#line 124 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
                      
                        if (User.Identity.IsAuthenticated)
                        {
                            

#line default
#line hidden
                BeginContext(4846, 84, false);
#line 127 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
                        Write(await Component.InvokeAsync("ListMenuNavigationByRole", new { roleCode = roleCode }));

#line default
#line hidden
                EndContext();
#line 127 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
                                                                                                                   
                        }
                    

#line default
#line hidden
                BeginContext(4983, 245, true);
                WriteLiteral("\r\n                </nav>\r\n                <!-- /.sidebar-menu -->\r\n            </div>\r\n            <!-- /.sidebar -->\r\n        </aside>\r\n        <!-- Content Wrapper. Contains page content -->\r\n        <div class=\"content-wrapper\">\r\n            ");
                EndContext();
                BeginContext(5229, 12, false);
#line 138 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(5241, 847, true);
                WriteLiteral(@"
            <!-- Content Header (Page header) -->
            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->
        <!-- /.control-sidebar -->
    </div>
    <!-- ./wrapper -->

    <footer class=""main-footer"">
        <div class=""float-right d-none d-sm-block"">
            <b>Phiên bản</b> 3.1.0
        </div>
        <strong></strong>.
    </footer>
    <!-- Control Sidebar -->
    <aside class=""control-sidebar control-sidebar-dark"">
        <!-- Control sidebar content goes here -->
    </aside>
    <div id=""popup-overlay"">
        <div class=""text-center"" id=""content-wating"">
            <div class=""spinner-border text-warning"" role=""status"" style=""width: 3rem; height: 3rem;"">
                <span class=""sr-only"">Loading...</span>
            </div>
        </div>
    </div>

    ");
                EndContext();
                BeginContext(6088, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c22047", async() => {
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
                BeginContext(6138, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6144, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c23303", async() => {
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
                BeginContext(6203, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(6211, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c24563", async() => {
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
                BeginContext(6251, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6257, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c25819", async() => {
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
                BeginContext(6313, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6319, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c27075", async() => {
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
                BeginContext(6396, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6402, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e6ec72eb131f2bc7db09b8e6639b836f40d987c28331", async() => {
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
                BeginContext(6448, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(6457, 41, false);
#line 173 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(6498, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6507, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591