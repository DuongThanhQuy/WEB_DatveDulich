#pragma checksum "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec5067f5d70037d6d33df4b8603fc232ce4c0b88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__ListTourPartialView), @"mvc.1.0.view", @"/Views/Home/_ListTourPartialView.cshtml")]
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
#line 1 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\_ViewImports.cshtml"
using TravelFinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\_ViewImports.cshtml"
using TravelFinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec5067f5d70037d6d33df4b8603fc232ce4c0b88", @"/Views/Home/_ListTourPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"986866c9d2d367a4af49535aee794987dd2aaa3b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home__ListTourPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DboTour>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/customerassets/images/tour-1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid equal-height"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("tour-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
 if (Model != null && Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"owl-carousel owl-theme owl-custom-arrow\" id=\"owl-tour-offers\">\r\n    \r\n");
#nullable restore
#line 7 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
         foreach (var item in Model)
        {
            string url = $"/{item.Alias}-{item.TourId}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"item\">\r\n            <div class=\"main-block tour-block\">\r\n                <div class=\"main-img\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 410, "\"", 421, 1);
#nullable restore
#line 13 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
WriteAttributeValue("", 417, url, 417, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec5067f5d70037d6d33df4b8603fc232ce4c0b885528", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </a>\r\n                </div><!-- end offer-img -->\r\n\r\n                <div class=\"offer-price-2\">\r\n                    <ul class=\"list-unstyled\">\r\n                            <li class=\"price\"style=\"text-align:center;\">");
#nullable restore
#line 20 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                                                                   Write(item.Price.Value.ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ<a");
            BeginWriteAttribute("href", " href=\"", 825, "\"", 836, 1);
#nullable restore
#line 20 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
WriteAttributeValue("", 832, url, 832, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"arrow\"></span></a></li>\r\n                    </ul>\r\n                </div><!-- end offer-price-2 -->\r\n\r\n                <div class=\"main-info tour-info\">\r\n                    <div class=\"main-title tour-title\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1089, "\"", 1100, 1);
#nullable restore
#line 26 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
WriteAttributeValue("", 1096, url, 1096, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 26 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                                  Write(item.TourName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        <p>");
#nullable restore
#line 27 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <div class=\"rating\">\r\n");
#nullable restore
#line 29 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                             if (item.Price >= 3500000)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
");
#nullable restore
#line 36 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                            }
                            else 

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                                  if (item.Price < 3500000 && item.Price >= 1000000)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star lightgrey""></i></span>
");
#nullable restore
#line 44 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                            }
                            else 

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                                  if (item.Price < 1000000)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star orange""></i></span>
                                <span><i class=""fa fa-star lightgrey""></i></span>
                                <span><i class=""fa fa-star lightgrey""></i></span>
");
#nullable restore
#line 52 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div><!-- end tour-title -->\r\n                </div><!-- end tour-info -->\r\n            </div>\r\n            </div>\r\n            <!-- end tour-block -->\r\n");
#nullable restore
#line 59 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    \r\n\r\n    <!-- end item -->\r\n    </div>\r\n");
#nullable restore
#line 65 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Views\Home\_ListTourPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DboTour>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
