#pragma checksum "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93e066f4d22541c39f823f767e0f1730af18010e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_Index), @"mvc.1.0.view", @"/Views/Project/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Project/Index.cshtml", typeof(AspNetCore.Views_Project_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93e066f4d22541c39f823f767e0f1730af18010e", @"/Views/Project/Index.cshtml")]
    public class Views_Project_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatable/jquery.datatable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\Index.cshtml"
  
    ViewData["Title"] = "Danh sách chương trình/dự án/dịch vụ";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(139, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(147, 87, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "93e066f4d22541c39f823f767e0f1730af18010e4744", async() => {
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
                BeginContext(234, 566, true);
                WriteLiteral(@"

    <style>
        .div-member {
            margin-left: 20px;
        }

            .div-member .nav .nav-link {
                margin: 4px 0 !important;
            }

        .card .nav.flex-column > li {
            border-bottom: 0px;
        }

        .span-team-name {
            font-weight: bold
        }

        .i-edit-saleteam {
            color: #555;
        }

        .i-delete-saleteam {
            color: #ff0000;
        }

        .typeahead {
            width: 100% !important;
        }
    </style>
");
                EndContext();
            }
            );
            BeginContext(803, 157, true);
            WriteLiteral("<section class=\"content-header\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-sm-6\">\r\n                <h1>");
            EndContext();
            BeginContext(962, 17, false);
#line 45 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\Index.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(980, 254, true);
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <ol class=\"breadcrumb float-sm-right\">\r\n                    <li class=\"breadcrumb-item\"><a href=\"#\">Trang chủ</a></li>\r\n                    <li class=\"breadcrumb-item active\">");
            EndContext();
            BeginContext(1236, 17, false);
#line 50 "F:\Projects\OnGIT\CreditRequestSystem\WebApp\Views\Project\Index.cshtml"
                                                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(1254, 2550, true);
            WriteLiteral(@"</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">

    <div class=""row"">

        <div class=""col-sm-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <div class=""row"">
                        <div class=""col-sm-3"">
                            <label>Mã dự án</label>
                            <input type=""text"" class=""form-control"" id=""txtMaDuAn"" />
                        </div>
                        <div class=""col-sm-3"">
                            <label>Tên dự án</label>
                            <input type=""text"" class=""form-control"" id=""txtTenDuAn"" />
                        </div>
                        <div class=""col-sm-3"">
                            <button id=""btn-search"" onclick=""SearchProjectFinancialSummar()"" class=""btn btn-filter btn-sm btn-primary""><i class=""fa fa-search""></i>&nbsp;Tìm kiếm</button>
                            <");
            WriteLiteral(@"button id=""btn-createNV"" class=""btn btn-filter btn-sm btn-success"" onclick=""showModalCreateNV(0)""><i class=""fa fa-plus-circle""></i>&nbsp;Thêm mới</button>
                        </div>

                    </div>
                </div>

                <div class=""card-body "">
                    <table class=""table table-bordered table-hover dataTable"" id=""table-project"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th width=""100px"">Mã dự án </th>
                                <th width=""200px"">Tên dự án</th>
                                <th width=""200px"">Căn cứ pháp lý</th>
                                <th width=""140px"">Thời gian thực hiện</th=""150px"">
                                <th width=""120px"">Tổng hạn mức</th>
                                <th width=""120px"">Đã sử dụng</th>
                                <th width=""100px"">Ghi chú</th>
                           ");
            WriteLiteral(@"     <th width=""100px""></th>
                            </tr>
                        </thead>
                    </table>

                </div>
            </div>
        </div>

    </div>


</section>


<!--modal add-->
<div class=""modal modal-blur fade"" id=""modal_add_project"" data-bs-backdrop=""static"" data-bs-focus=""false"" data-bs-keyboard=""false"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-xl"" id=""form_add_project"">

    </div>
</div>




");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3821, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3827, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93e066f4d22541c39f823f767e0f1730af18010e10789", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3890, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3896, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93e066f4d22541c39f823f767e0f1730af18010e12045", async() => {
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
                BeginContext(3943, 15182, true);
                WriteLiteral(@"
    <!-- Thêm jQuery Validate -->
    <script src=""https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/jquery.validate.min.js""></script>
    <script>
        var tableId = ""#table-project"";
        var ajaxURL = ""/Project/SearchProjectFinancialSummar"";

        var columnData = [
            { ""data"": ""id"", visible: false },
            { ""data"": ""projectCode"" },
            { ""data"": ""projectName"" },
            { ""data"": ""legalBasis"" },
            {
                ""data"": ""timeStart"", ""render"": function (data, type, row, meta) {
                    if (data != null && row.timeEnd != null) {

                         return moment(data).format('DD/MM/YYYY') + '<br>' + moment(row.timeEnd).format('DD/MM/YYYY');;
                    }
                    else {
                        return """";
                    }
                }
            },
            {
                ""data"": ""totalAmount"", ""render"": function (data, type, row, meta) {
                    return Rend");
                WriteLiteral(@"erNumerFormat(data);
                }
            },
            {
                ""data"": ""id"", ""render"": function (data, type, row, meta) {
                    return ""0"";
                }
            },
            { ""data"": ""notes"" },

            {
                ""data"": ""id"", ""render"": function (data, type, row, meta) {
                    return RenderTableAction(data);
                }
            },


        ];

        var arrMembers = [];
        var listFileAttact = [];

        $(document).ready(function () {

            SearchProjectFinancialSummar();

            // Khi người dùng chọn file
            $('#fileInputProject').on('change', function () {
                const file = this.files[0]; // Lấy file được chọn
                if (file) {
                    // Upload file
                    const fileData = new FormData();
                    fileData.append('file', this.files[0]);

                    $.ajax({
                        url: '/FileU");
                WriteLiteral(@"pload/UploadFile', // Đường dẫn đến API xử lý file
                        type: 'POST',
                        data: fileData,
                        contentType: false,
                        processData: false,
                        success: function (response) {
                            if (response.success == true && response.fileNameAttactId > 0) {
                                const html = `
                                                <tr>
                                                    <td width=""40px"" style=""text-align:center;"">
                                                        <a  target=""_blank"">
                                                            <span class=""fa fa-download""></span>
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <a href=""${response.filePath}"" target=""_b");
                WriteLiteral(@"lank"">${response.fileName}</a>
                                                    </td>
                                                     <td width=""40px"" style=""text-align:center;color:crimson;"">
                                                        <span class=""fa fa-trash delete-file""
                                                              data-id=""${response.fileNameAttactId}""
                                                              style=""cursor:pointer;""
                                                              onclick=""RemoveFile(${response.fileNameAttactId})""></span>
                                                    </td>
                                                </tr>
                                            `;

                                $('#table_Attact_File').append(html)
                            }
                            listFileAttact.push(response.fileNameAttactId)
                            toastr.success('Tải file thành công!', 'Thành");
                WriteLiteral(@" công', { positionClass: ""toast-top-center"" });
                        },
                        error: function () {
                            toastr.error('Có lỗi khi tải file!', 'Lỗi', { positionClass: ""toast-top-center"" });
                        }
                    });
                }
            });
        });
        function RenderTableAction(id) {
            var html = `
                    <div class='div-table-action'>
                        <span class=""fa fa-eye"" onclick=""GotoProjectDetail(${id})""></span>&nbsp;
                        <i class='fa fa-edit' onclick='showModalCreateNV(${id})' title='sửa'></i>&nbsp;
                        <i class='fa fa-trash' onclick='DeleteProject(${id})' title='xóa'></i>&nbsp;
                    </div>`;
            return html;
        }
        function GotoProjectDetail(id) {
            location.href = ""/project/ProjectDetail/"" + id;
        }
        function SearchProjectFinancialSummar() {

            var dataSearch =");
                WriteLiteral(@" {
                ProjectCode: $(""#txtMaDuAn"").val(),
                ProjectName: $(""#txtTenDuAn"").val()
            };
            GenrateDataTableSearch(tableId, ajaxURL, columnData, dataSearch);



        }

        function showModalCreateNV(id) {
            $.ajax({
                url: '/Project/FormCreateProject', // Đảm bảo đường dẫn này đúng với action của bạn
                type: 'GET',
                data: {
                    Id:id
                },
                success: function (response) {
                    // Chèn HTML trả về vào phần tử có id ""dailog_nv""
                    $('#form_add_project').html(response);

                    // Hiển thị modal
                    $(""#modal_add_project"").modal(""show"")
                },
                error: function (xhr, status, error) {
                    console.error(""Có lỗi khi tải nội dung modal: "", error);
                    alert(""Lỗi tải modal, vui lòng thử lại sau."");
                }
            }");
                WriteLiteral(@");
        }

        //---------------CREATE PROJECT------------------//

        function RemoveFile(fileId) {
            Swal.fire({
                title: 'Bạn có chắc chắn?',
                text: ""Bạn sẽ không thể hoàn tác hành động này!"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Xóa',
                cancelButtonText: 'Hủy'
            }).then((result) => {
                if (result.isConfirmed) {
                    // call ajax delete
                    $.ajax({
                        url: '/FileUpload/DeleteFile',
                        type: 'GET',
                        data: {
                            Id: fileId
                        },
                        success: function (response) {
                            if (response.success) {
                                $(`span[data-id=""${fileId}""]`).c");
                WriteLiteral(@"losest('tr').remove();
                                listFileAttact = listFileAttact.filter(x =>x != fileId);
                                toastr.success('Xóa file thành công!', 'Thành công', { positionClass: ""toast-top-center"" });
                            }
                            else {
                                toastr.error('Có lỗi xảy ra khi xóa file !', 'Lỗi', { positionClass: ""toast-top-center"" });
                            }
                        },
                        error: function (xhr, status, error) {
                            console.error(""Có lỗi khi tải nội dung modal: "", error);
                            alert(""Lỗi tải modal, vui lòng thử lại sau."");
                        }
                    });

                }
            });
        }

        function CreateProject() {

            var isValidate = validateData();

            if (isValidate == true) {
                if (listFileAttact == null || listFileAttact.length == 0) {
  ");
                WriteLiteral(@"                  toastr.error(""Chưa đính kèm file căn cứ pháp lý"", 'Lỗi', { positionClass: ""toast-top-center"" });
                    return;
                }
                var dataPost = {
                    Id: $(""#ProjectFinancialSummarId"").val(),
                    ProjectCode: $(""#a_ma_du_an"").val(),
                    ProjectName: $(""#a_ten_du_an"").val(),
                    LegalBasis: $(""#a_can_cu_phap_ly"").val(),
                    TimeStart: $(""#a_thoi_gian_bat_dau"").val() ,
                    TimeEnd: $(""#a_thoi_gian_ket_thuc"").val() ,
                    TotalAmount: $(""#a_tong_han_muc_khong_format"").val(),
                    StatusText: """",
                    Notes: $(""#a_ghi_chu"").val(),
                    FileAttach: listFileAttact
                };
                // Gửi yêu cầu AJAX
                $.ajax({
                    url: '/Project/CreateProjectFinancialSummar',
                    type: 'POST',
                    data: JSON.stringify(dataPost),
   ");
                WriteLiteral(@"                 contentType: 'application/json',
                    success: function (response) {
                        if (response.success) {
                            toastr.success('Dự án đã được tạo thành công!', 'Thành công', { positionClass: ""toast-top-center"" });
                            //$(""#projectId"").val(response.projectId);
                            //document.getElementById(""regon_hang_muc_phan_bo"").style.display = ""block"";
                            // Hiển thị modal
                            $(""#modal_add_project"").modal(""hide"")
                            SearchProjectFinancialSummar()

                        } else {
                            toastr.error(response.message, 'Lỗi', { positionClass: ""toast-top-center"" });
                        }
                    },
                    error: function (xhr, status, error) {
                        // Xử lý khi có lỗi xảy ra trong quá trình gọi AJAX
                        alert('Có lỗi khi gửi yêu cầu!');
                WriteLiteral(@"
                    }
                });
            }
        }

        function UploadFileProject() {
            $('#fileInputProject').click();
        }

        function validateData() {
            var resultValid = $(""#frmCreateProject"").validate({
                rules: {
                    ""ten_du_an"": {
                        required: true,
                    },
                    ""ma_du_an"": {
                        required: true,
                    },
                    ""can_cu_phap_ly"": {
                        required: true,
                    },
                    ""thoi_gian_bat_dau"": {
                        required: true,
                    },
                    ""thoi_gian_ket_thuc"": {
                        required: true,
                    },
                    ""tong_han_muc"": {
                        required: true
                    },

                },
                messages: {
                    ""ten_du_an"": ""Tên chương tr");
                WriteLiteral(@"ình/dự án/dịch vụ không được để trống!"",
                    ""ma_du_an"": ""Mã chương trình/dự án/dịch vụ không được để trống!"",
                    ""can_cu_phap_ly"": ""Căn cứ pháp lý không được để trống!"",
                    ""thoi_gian_bat_dau"": ""Thời gian thực hiện không được để trống!"",
                    ""thoi_gian_ket_thuc"": ""Thời gian thực hiện không được để trống!"",
                    ""tong_han_muc"": {
                        required: ""Tổng tiền không được để trống!""
                    }
                },

            }).form();

            return resultValid;
        }

        function showhideSoTienDaSuDung() {
            var ishow = document.getElementById(""a_luy_ke"").getAttribute(""data-value"");
            var iconElement = document.getElementById(""icon_show_hide"");
            if (ishow == ""show"") {
                document.getElementById('a_luy_ke').type = 'password';
                document.getElementById(""a_luy_ke"").setAttribute('data-value', 'hide');
               ");
                WriteLiteral(@" iconElement.classList.remove('fa-eye');
                iconElement.classList.add('fa-eye-slash');
            } else {
                document.getElementById('a_luy_ke').type = 'text';
                document.getElementById(""a_luy_ke"").setAttribute('data-value', 'show');
                iconElement.classList.remove('fa-eye-slash');
                iconElement.classList.add('fa-eye');
            }
        }

        function DeleteProject(id) {
            Swal.fire({
                title: 'Bạn có chắc chắn?',
                text: ""Bạn sẽ không thể hoàn tác hành động này!"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Xóa',
                cancelButtonText: 'Hủy'
            }).then((result) => {
                if (result.isConfirmed) {
                    // call ajax delete
                    $.ajax({
                       ");
                WriteLiteral(@" url: '/project/DeleteProject',
                        type: 'GET',
                        data: {
                            Id: id
                        },
                        success: function (response) {
                            if (response.success) {

                                toastr.success('Dự án đã được xóa thành công!', 'Thành công', { positionClass: ""toast-top-center"" });
                                SearchProjectFinancialSummar();
                            }
                            else {
                                console.error(response);
                                toastr.error('Xóa thất bại.Đã phát sinh hồ sơ thanh toán!', 'Lỗi', { positionClass: ""toast-top-center"" });
                            }
                        },
                        error: function (xhr, status, error) {
                            console.error(""Có lỗi khi tải nội dung modal: "", error);
                            alert(""Lỗi tải modal, vui lòng thử lại sau.");
                WriteLiteral(@""");
                        }
                    });

                }
            });

        }

        function formatTotalAmount() {
            var inputElement = document.getElementById('a_tong_han_muc');
            var value = inputElement.value.trim();
            if (value && !isNaN(value) || value == ""0"") {
                var rawValue = parseFloat(value);
                document.getElementById('a_tong_han_muc_khong_format').value = rawValue;

                var formattedValue = rawValue.toLocaleString('de-DE');
                inputElement.value = formattedValue;
            } else {
                // If invalid, clear both fields
                inputElement.value = '';
                document.getElementById('a_tong_han_muc_khong_format').value = '';
            }
        }

    </script>
");
                EndContext();
            }
            );
            BeginContext(19128, 4, true);
            WriteLiteral("\r\n\r\n");
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