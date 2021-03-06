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
#line 2 "C:\Users\User\RiderProjects\Assignment1\Assignment1\Pages\ViewAdults.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\RiderProjects\Assignment1\Assignment1\Pages\ViewAdults.razor"
using Assignment1.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/ViewAdults")]
    public partial class ViewAdults : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 94 "C:\Users\User\RiderProjects\Assignment1\Assignment1\Pages\ViewAdults.razor"
       
    private string? filterByName = null;
    private string? filterByAge = null;
    private string? filterBySex = null;
    private IList<Adult> Adults = new List<Adult>();
    private IList<Adult> filtredAdults = new List<Adult>();


    protected override async Task OnInitializedAsync() 
    {
        if (IAdult != null )
        {
            try
            {
                Adults = await IAdult.GetAdultAsync();
                filtredAdults = Adults;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
            
        }
        else
        {
            Console.WriteLine("null");
        }
    }


    private void ExecuteFilter()
    {
        if (filtredAdults.Any())
        {
            Console.WriteLine(filterByName);
            Console.WriteLine(filterBySex);
            filtredAdults = Adults.Where(f => (filterByName != null && f.FirstName.Contains(filterByName) || filterByName == null) && (f.Sex.Equals(filterBySex) || filterBySex == null) && (filterByAge != null && f.Age.ToString().Contains(filterByAge) || filterByAge == null)).ToList();
        }

        else
        {
            filtredAdults = Adults;
        }
    }

    private void FilterByName(ChangeEventArgs changeEventArgs)
    {
        filterByName = null;
        filterByName = changeEventArgs.Value?.ToString();
        ExecuteFilter();
    }

    private void FilterByAge(ChangeEventArgs changeEventArgs)
    {
        filterByAge = null;
        try
        {
            filterByAge = changeEventArgs.Value?.ToString();
        }
        catch (Exception e)
        {
        }
        ExecuteFilter();
    }

    private void FilterBySex(ChangeEventArgs changeEventArgs)
    {
        filterBySex = null;
        filterBySex = changeEventArgs.Value?.ToString();
        if (filterBySex.Equals("Both"))
        {
            filterBySex = null;
        }
        ExecuteFilter();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAdult IAdult { get; set; }
    }
}
#pragma warning restore 1591
