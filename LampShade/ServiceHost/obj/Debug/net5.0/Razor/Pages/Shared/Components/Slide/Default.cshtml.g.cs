#pragma checksum "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1164aaef9f820cb028d29cd8e0caf425f3325d7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.Slide.Pages_Shared_Components_Slide_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/Slide/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.Slide
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
#line 1 "E:\Shoping\LampShade\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1164aaef9f820cb028d29cd8e0caf425f3325d7a", @"/Pages/Shared/Components/Slide/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_Slide_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_LampShadeQuery.Contract.Slide.SlideQueryModel>>
    {
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
            WriteLiteral(@"<div class=""hero-slider-area section-space"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">

                <div class=""hero-slider-wrapper"">
                    <div class=""ht-slick-slider"" data-slick-setting='{
                        ""slidesToShow"": 1,
                        ""slidesToScroll"": 1,
                        ""arrows"": true,
                        ""dots"": true,
                        ""autoplay"": true,
                        ""autoplaySpeed"": 5000,
                        ""speed"": 1000,
                        ""fade"": true,
                        ""infinite"": true,
                        ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                        ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                    }' data-slick-responsive='[
                        {""breakpoint"":1501, ""settings"": {""slidesToShow"": 1} },
                        {""breakpoint""");
            WriteLiteral(@":1199, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":991, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":767, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":575, ""settings"": {""slidesToShow"": 1, ""arrows"": false} },
                        {""breakpoint"":479, ""settings"": {""slidesToShow"": 1, ""arrows"": false} }
                    ]'>
");
#nullable restore
#line 28 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                         foreach (var slide in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"single-slider-item\">\r\n                                <div class=\"hero-slider-item-wrapper \">\r\n                                    <div class=\"container\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1164aaef9f820cb028d29cd8e0caf425f3325d7a5212", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1884, "~/ProductPicture/", 1884, 17, true);
#nullable restore
#line 33 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
AddHtmlAttributeValue("", 1901, slide.Picture, 1901, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 33 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
AddHtmlAttributeValue("", 1922, slide.PictureAlt, 1922, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 33 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
AddHtmlAttributeValue("", 1948, slide.PictureTitle, 1948, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        <div class=""row"">
                                            <div class=""col-lg-12"">
                                                <div class=""hero-slider-content hero-slider-content--left-space"">
                                                    <p class=""slider-title slider-title--big-light"">");
#nullable restore
#line 37 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                                                                                               Write(slide.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                    <p class=\"slider-title slider-title--big-bold\">");
#nullable restore
#line 38 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                                                                                              Write(slide.Heading);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                    <p class=\"slider-title slider-title--small\">\r\n\r\n                                                        ");
#nullable restore
#line 41 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                                                   Write(slide.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </p>\r\n                                                    <a class=\"hero-slider-button\"");
            BeginWriteAttribute("href", " href=\"", 2760, "\"", 2778, 1);
#nullable restore
#line 43 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
WriteAttributeValue("", 2767, slide.Link, 2767, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        ");
#nullable restore
#line 44 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                                                   Write(slide.BtnText);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<i class=""ion-ios-plus-empty""></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
");
#nullable restore
#line 52 "E:\Shoping\LampShade\ServiceHost\Pages\Shared\Components\Slide\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                      \r\n\r\n\r\n                    </div>\r\n                </div>\r\n\r\n                \r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_LampShadeQuery.Contract.Slide.SlideQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
