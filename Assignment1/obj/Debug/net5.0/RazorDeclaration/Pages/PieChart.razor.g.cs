// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Assignment1.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Assignment1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using Assignment1.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Common.Axes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Common.Axes.Ticks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Common.Handlers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Common.Time;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Util;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\User\RiderProjects\Assignment1\Assignment1\_Imports.razor"
using ChartJs.Blazor.Interop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\RiderProjects\Assignment1\Assignment1\Pages\PieChart.razor"
using ChartJs.Blazor.PieChart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\RiderProjects\Assignment1\Assignment1\Pages\PieChart.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\RiderProjects\Assignment1\Assignment1\Pages\PieChart.razor"
           [Authorize(Policy = "Admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/PieChart")]
    public partial class PieChart : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "C:\Users\User\RiderProjects\Assignment1\Assignment1\Pages\PieChart.razor"
       
    private PieConfig pieConfig;
    private List<Adult> Adults = new List<Adult>();
    private int semiMedium = 0;
    private int medium = 0;
    private int semiOld = 0;
    private int old = 0;

    protected override void OnInitialized()
    {
        ConfigurePieChart();
    }

    private void ConfigurePieChart()
    {
        pieConfig = new PieConfig();

        pieConfig.Options = new PieOptions()
        {
            Responsive = true,
            Title = new OptionsTitle
            {
                Display = true,
                Text = "Pie Chart"
            }
        };

        foreach (var adults in FileContext.Adults)
        {
            Adults.Add(adults);
           
             if (adults.Age > 18 && adults.Age < 27)
            {
                semiMedium++;
            }
            else if (adults.Age > 27 && adults.Age < 35)
            {
                medium++;
            }
            else if (adults.Age > 35 && adults.Age < 50)
            {
                semiOld++;
            }
            else
            {
                old++;
            }
        }

        foreach (var age in new[] { "Between 18-27 ", "Between 27-35 ", "Between 35-50 ", "50+ "})
        {
            pieConfig.Data.Labels.Add(age);
        }
        var dataset = new PieDataset<int>(new[] { semiMedium, medium, semiOld, old})
        {
            BackgroundColor = new[]
            {
                ColorUtil.ColorHexString(255, 0, 0),
                ColorUtil.ColorHexString(0, 255, 0),
                ColorUtil.ColorHexString(0, 0, 255),
                ColorUtil.ColorHexString(100, 150, 8),
               
            }
        };
        pieConfig.Data.Datasets.Add(dataset);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FileContext FileContext { get; set; }
    }
}
#pragma warning restore 1591
