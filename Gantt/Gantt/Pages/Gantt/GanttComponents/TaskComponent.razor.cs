using System;
using System.Threading.Tasks;
using Gantt.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Gantt.Pages.Gantt.GanttComponents
{
    public partial class TaskComponent : IDisposable
    {
        [Parameter]
        public TaskItem Task { get; set; }
        [Parameter]
        public int ColumnWidth { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }

        DotNetObjectReference<TaskComponent>? objRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                objRef = DotNetObjectReference.Create(this);
                await JS.InvokeVoidAsync("enableTaskDrag", Task.Ref, objRef);
            }
        }

        [JSInvokable]
        public void OnDragEnd(int newColumnStart)
        {
            Task.ColumnStart = newColumnStart;
            StateHasChanged();
        }

        public void Dispose()
        {
            objRef?.Dispose();
        }
    }
}
