#pragma checksum "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56c30fddfca8de4450cdf1efd7b42878fe4297a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Document_IndexForCoordinator), @"mvc.1.0.view", @"/Views/Document/IndexForCoordinator.cshtml")]
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
#nullable restore
#line 1 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\_ViewImports.cshtml"
using WebEnterprise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\_ViewImports.cshtml"
using WebEnterprise.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
using WebEnterprise.ViewModels.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56c30fddfca8de4450cdf1efd7b42878fe4297a7", @"/Views/Document/IndexForCoordinator.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"971fac6c2fb05e6fc4bea01183680b4562f21c6d", @"/Views/_ViewImports.cshtml")]
    public class Views_Document_IndexForCoordinator : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResult<WebEnterprise.ViewModels.Catalog.Document.DocumentsVm>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
  
    ViewData["Title"] = "List User Document";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        setTimeout(function () {\r\n            $(\'#msgAlert\').fadeOut(\'slow\');\r\n        }, 2000);\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"<div class=""grid wide"">
    <div class=""row"">
        <!-- content container start-->
        <div class=""col l-12 m-12 c-12"">
            <div class=""content-container-box"">
                <div class=""header-box-content"">
                    <div class=""nameFaculty"">
                        <span>IT</span>
                    </div>
                </div>
                <!-- data container start-->
                <div class=""row"">
                    <div class=""col l-4 c-12 m-4"">
                        <div class=""dataBox"">
                            <h4>Number of articles </h4>
                            <span>10</span>
                        </div>
                    </div>
                    <div class=""col l-4 c-12 m-4"">
                        <div class=""dataBox"">
                            <h4>Articles approved </h4>
                            <span>12</span>
                        </div>
                    </div>
                    <div class=""col l-4 c-12 m-4"">");
            WriteLiteral(@"
                        <div class=""dataBox"">
                            <h4>Articles waiting</h4>
                            <span>15</span>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col l-12 c-12 m-12"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56c30fddfca8de4450cdf1efd7b42878fe4297a76159", async() => {
                WriteLiteral(@"
                            <div class=""coor-list-docx"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th>Title</th>
                                            <th>Author</th>
                                            <th>Date</th>
                                            <th>Status</th>
                                            <th>Handle</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 61 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
                                         foreach (var item in Model.Items)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 64 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Caption));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 65 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 66 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.CreateOn));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 67 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                                <td>
                                                    <div class=""handle-coor"">
                                                        <a href=""/"">View</a>
                                                        <a href=""/"">Edit</a>
                                                        <input type=""checkbox"">
                                                    </div>
                                                </td>
                                            </tr>
");
#nullable restore
#line 76 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n                            <button type=\"submit\" class=\"btn-select-docx\">Save</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            ");
#nullable restore
#line 85 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForCoordinator.cshtml"
       Write(await Component.InvokeAsync("Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <!-- content container end-->\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResult<WebEnterprise.ViewModels.Catalog.Document.DocumentsVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
