using Microsoft.AspNetCore.Components;

namespace Gantt.Models
{
    public class TaskItem
    {
        public string Name { get; set; } = "";
        public int StartPx { get; set; }
        public int WidthPx { get; set; }
        public ElementReference Ref;
    }
}
