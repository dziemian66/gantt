using System.Threading.Tasks;
using Gantt.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Gantt.Pages.Gantt.GanttComponents
{
    public partial class TaskComponent
    {
        [Parameter]
        public TaskItem Task { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JS.InvokeVoidAsync("enableTaskDrag", Task.Ref);
            }
        }

        void StartDrag(TaskItem task, MouseEventArgs e) { }
    }
}
