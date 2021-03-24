#pragma checksum "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd8bb217b5fec50d1ef518f5f1a6243e76df31bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Document_IndexForManager), @"mvc.1.0.view", @"/Views/Document/IndexForManager.cshtml")]
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
#line 1 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml"
using WebEnterprise.ViewModels.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd8bb217b5fec50d1ef518f5f1a6243e76df31bf", @"/Views/Document/IndexForManager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"971fac6c2fb05e6fc4bea01183680b4562f21c6d", @"/Views/_ViewImports.cshtml")]
    public class Views_Document_IndexForManager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebEnterprise.ViewModels.Catalog.Document.DocumentsVm>
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
#nullable restore
#line 3 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml"
  
    ViewData["Title"] = "User Document";
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
        <!-- sidebar start -->
        <div class=""col l-3 m-0 c-0"" style=""margin: 0;"">
            <div class=""sidebar"">
                <h4>Faculties</h4>
                <ul>
                    <li id=""1"" class=""category-sidebar"" data-id=""data-all"">All</li>
                    <li id=""2"" class=""category-sidebar"" data-id=""data-design"">Design</li>
                    <li id=""3"" class=""category-sidebar"" data-id=""data-it"">Information Technology</li>
                    <li id=""4"" class=""category-sidebar"" data-id=""data-business"">Business</li>
                    <li id=""5"" class=""category-sidebar"" data-id=""data-tourism"">Tourism</li>
                </ul>
            </div>
        </div>
        <!-- sidebar end -->
        <!-- content container start-->
        <div class=""col l-9 m-12 c-12"">
            <div class=""content-container-box"">
                <div class=""header-box-content"">
                    <div class=""nameFaculty"">
         ");
            WriteLiteral(@"               <span> Selecting:</span> <span id=""selectCate""></span>
                    </div>
                </div>
                <div class=""mobile-sidebar"">
                    <ul class=""mSidebar-list"">
                        <li id=""1"" class=""mSidebar-item"" data-id=""data-all"">All</li>
                        <li id=""2"" class=""mSidebar-item"" data-id=""data-design"">Design</li>
                        <li id=""3"" class=""mSidebar-item"" data-id=""data-it"">Information Technology</li>
                        <li id=""4"" class=""mSidebar-item"" data-id=""data-business"">Business</li>
                        <li id=""5"" class=""mSidebar-item"" data-id=""data-tourism"">Tourism</li>
                    </ul>
                </div>
                <!-- data container start-->
                <div class=""content-container-data"" id=""data-all"">
                    <div class=""row"">

                        <div class=""col l-4 c-12 m-4"">
                            <div class=""dataBox"">
                      ");
            WriteLiteral("          <h4>Number of articles</h4>\r\n\r\n                                <span>");
#nullable restore
#line 55 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml"
                                 Write(Html.DisplayFor(modelItem => Model.ViewCount));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                        </div>
                        <div class=""col l-4 c-12 m-4"">
                            <div class=""dataBox"">
                                <h4>Articles approved</h4>

                                <span>");
#nullable restore
#line 62 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml"
                                 Write(Html.DisplayFor(modelItem => Model.TotalTrue));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                        </div>
                        <div class=""col l-4 c-12 m-4"">
                            <div class=""dataBox"">
                                <h4>Articles waiting</h4>

                                <span>");
#nullable restore
#line 69 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml"
                                 Write(Html.DisplayFor(modelItem => Model.TotalFalse));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <fieldset style=""margin-left:12px"" class=""col l-5 c-12"">
                            <legend>Download documents (.zip)</legend>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd8bb217b5fec50d1ef518f5f1a6243e76df31bf8685", async() => {
                WriteLiteral(@"
                                <input type=""text"" data-toggle=""datepicker"" data-date-format=""yyyy.mm""
                                       placeholder=""Pick month"">
                                <button type=""submit"">Download</button>
                            ");
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
            WriteLiteral(@"
                        </fieldset>
                    </div>
                    <!-- table list students -->
                    <div class=""row"">
                        <div class=""col l-12"">
                            <h1 style=""text-align: center;"">List students</h1>
                            <table class=""table"">
                                <thead>
                                    <tr>
                                        <th>Number of document</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <tr>
                                        <td>");
#nullable restore
#line 96 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml"
                                       Write(Html.DisplayFor(modelItem => Model.ViewCount));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class=""content-container-data"" id=""data-design"">
                    <div class=""row"">
                        <div class=""col l-4 c-12 m-4"">
                            <div class=""dataBox"" style=""background-color: aquamarine;"">
                                <h4>Number of articles</h4>
                                <span>11</span>
                            </div>
                        </div>
                        <div class=""col l-4 c-12 m-4"">
                            <div class=""dataBox"">
                                <h4>Articles approved</h4>
                                <span>12</span>
                            </div>
                        </div>
                        <div class=""col l-4 c-12 m-4"">
                            <div clas");
            WriteLiteral(@"s=""dataBox"">
                                <h4>Articles waiting</h4>
                                <span>15</span>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <fieldset style=""margin-left:12px"" class=""col l-5 c-12"">
                            <legend>Download documents (.zip)</legend>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd8bb217b5fec50d1ef518f5f1a6243e76df31bf12993", async() => {
                WriteLiteral(@"
                                <input type=""text"" data-toggle=""datepicker"" data-date-format=""yyyy.mm""
                                       placeholder=""Pick month"">
                                <button type=""submit"">Download</button>
                            ");
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
            WriteLiteral("\r\n                        </fieldset>\r\n                    </div>\r\n\r\n                    <!-- data container end -->\r\n                </div>\r\n            </div>\r\n            <!-- content container end-->\r\n        </div>\r\n        ");
#nullable restore
#line 140 "C:\Users\DELL\WebEnterprise\WebEnterprise\Views\Document\IndexForManager.cshtml"
   Write(await Component.InvokeAsync("Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebEnterprise.ViewModels.Catalog.Document.DocumentsVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
