#pragma checksum "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "092fc5847709c394239c760806f79c1abb7dabc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminDboTours_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminDboTours/Details.cshtml")]
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
#line 1 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\_ViewImports.cshtml"
using TravelFinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\_ViewImports.cshtml"
using TravelFinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"092fc5847709c394239c760806f79c1abb7dabc3", @"/Areas/Admin/Views/AdminDboTours/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"986866c9d2d367a4af49535aee794987dd2aaa3b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_AdminDboTours_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TravelFinalProject.Models.DboTour>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>DboTour</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TourName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.TourName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ShortDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.ShortDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Picture));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Picture));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Video));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Video));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BestSellers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.BestSellers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeFlag));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.HomeFlag));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 81 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 87 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 93 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 96 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 99 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Alias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 102 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Alias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 105 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MetaDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 108 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.MetaDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 111 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MetaKey));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 114 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.MetaKey));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 117 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitslnStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 120 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitslnStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 123 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Seats));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 126 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Seats));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 129 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 132 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 135 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 138 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 141 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CatTour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 144 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
       Write(Html.DisplayFor(model => model.CatTour.CatTourId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "092fc5847709c394239c760806f79c1abb7dabc319527", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 149 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboTours\Details.cshtml"
                           WriteLiteral(Model.TourId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "092fc5847709c394239c760806f79c1abb7dabc321698", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TravelFinalProject.Models.DboTour> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
