#pragma checksum "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboRoles\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e646371753416ca821f2a2d48895e8462f764b7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminDboRoles_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminDboRoles/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e646371753416ca821f2a2d48895e8462f764b7a", @"/Areas/Admin/Views/AdminDboRoles/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"986866c9d2d367a4af49535aee794987dd2aaa3b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_AdminDboRoles_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TravelFinalProject.Models.DboRole>
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
#line 3 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboRoles\Details.cshtml"
  
	ViewData["Title"] = "Access Information";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n\t<div class=\"card-header d-block\">\r\n\t\t<h5 class=\"card-title\">Access Information</h5>\r\n\t\t<h1>");
#nullable restore
#line 11 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboRoles\Details.cshtml"
       Write(Model.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
	</div>
	<div class=""card-body"">
		<!-- Default accordion -->

		<div class=""accordion accordion-primary"" id=""accordion-one"">
		
			<div class=""accordion-item"">
				<div class=""accordion-header collapsed rounded-lg"" id=""headingTwo"" data-bs-toggle=""collapse"" data-bs-target=""#collapseTwo"" aria-controls=""collapseTwo"" role=""button"" aria-expanded=""true"">
					<span class=""accordion-header-text"">Job Description Of: ");
#nullable restore
#line 20 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboRoles\Details.cshtml"
                                                                       Write(Model.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t<span class=\"accordion-header-indicator\"></span>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div id=\"collapseTwo\" class=\"collapse\" aria-labelledby=\"headingTwo\" data-bs-parent=\"#accordion-one\">\r\n\t\t\t\t\t<div class=\"accordion-body-text\">");
#nullable restore
#line 24 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboRoles\Details.cshtml"
                                                Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\r\n\t\t</div>\r\n\t</div>\r\n\t<div class=\"h5 card-header d-block\">\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e646371753416ca821f2a2d48895e8462f764b7a6043", async() => {
                WriteLiteral(" Edit |");
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
#line 31 "D:\hk2 năm 3\.NET\TravelFinalProject\TravelFinalProject\Areas\Admin\Views\AdminDboRoles\Details.cshtml"
                               WriteLiteral(Model.RoleId);

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
            WriteLiteral("\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e646371753416ca821f2a2d48895e8462f764b7a8217", async() => {
                WriteLiteral(" Back to List");
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
            WriteLiteral("\r\n\t</div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TravelFinalProject.Models.DboRole> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
