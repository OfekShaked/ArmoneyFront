#pragma checksum "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d53c9a14d3e93c6e903a077a14104d872c307ff9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__cartItem), @"mvc.1.0.view", @"/Views/Shared/_cartItem.cshtml")]
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
#line 1 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\_ViewImports.cshtml"
using BuyMeProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\_ViewImports.cshtml"
using BuyMeProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\_ViewImports.cshtml"
using BuyMeProject.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\_ViewImports.cshtml"
using BuyMeProject.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d53c9a14d3e93c6e903a077a14104d872c307ff9", @"/Views/Shared/_cartItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07bf3fe3c4af9c79e3e25400a694cc2ea27de7b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__cartItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/cartItem.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProductToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
  
    var username = Context.Request.Cookies["userName"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d53c9a14d3e93c6e903a077a14104d872c307ff95820", async() => {
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
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <div class=\"card-img-actions\">\r\n            <div class=\"w3-display-container mySlides w3-animate-opacity\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 318, "\"", 361, 2);
            WriteAttributeValue("", 324, "data:image/png;base64,", 324, 22, true);
#nullable restore
#line 10 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
WriteAttributeValue("", 346, Model.Picture1, 346, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-item-width\">\r\n            </div>\r\n            <div class=\"w3-display-container mySlides w3-animate-opacity\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 504, "\"", 547, 2);
            WriteAttributeValue("", 510, "data:image/png;base64,", 510, 22, true);
#nullable restore
#line 13 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
WriteAttributeValue("", 532, Model.Picture2, 532, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-item-width\">\r\n            </div>\r\n            <div class=\"w3-display-container mySlides w3-animate-opacity\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 690, "\"", 733, 2);
            WriteAttributeValue("", 696, "data:image/png;base64,", 696, 22, true);
#nullable restore
#line 16 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
WriteAttributeValue("", 718, Model.Picture3, 718, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""img-item-width"">
            </div>
            <button class=""w3-button w3-light-grey noselection w3-display-left minusBtn"">&#10094;</button>
            <button class=""w3-button w3-light-grey noselection w3-display-right plusBtn"">&#10095;</button>
            <span class=""img-counter""></span>
        </div>
    </div>
</div>
<div class=""card-body bg-light text-center"">
    <div class=""mb-2"">
        <h6 class=""font-weight-semibold mb-2""> <a href=""#"" class=""text-default mb-2"" data-abc=""true"">");
#nullable restore
#line 26 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
                                                                                                Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </h6> <a href=\"#\" class=\"text-muted\" data-abc=\"true\">");
#nullable restore
#line 26 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
                                                                                                                                                                      Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </div>\r\n    <h3 class=\"mb-0 font-weight-semibold\">$");
#nullable restore
#line 28 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
                                      Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d53c9a14d3e93c6e903a077a14104d872c307ff910348", async() => {
                WriteLiteral("\r\n        <div class=\"mb-4\"><button type=\"submit\" class=\"btn bg-info\" ><i class=\"fas fa-info mr-2\"></i>More details</button> </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
                                                                        WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d53c9a14d3e93c6e903a077a14104d872c307ff913176", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"username\"");
                BeginWriteAttribute("value", " value=\"", 1793, "\"", 1810, 1);
#nullable restore
#line 33 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
WriteAttributeValue("", 1801, username, 1801, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 1861, "\"", 1878, 1);
#nullable restore
#line 34 "C:\Users\msvs\Downloads\asp\BuyMeProject\Views\Shared\_cartItem.cshtml"
WriteAttributeValue("", 1869, Model.Id, 1869, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <button type=\"submit\" class=\"btn bg-cart\"><i class=\"fa fa-cart-plus mr-2\"></i> Add to cart</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
