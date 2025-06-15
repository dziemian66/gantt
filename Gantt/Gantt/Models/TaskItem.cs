using Microsoft.AspNetCore.Components;

namespace Gantt.Models
{
    public class TaskItem
    {
        public string Name { get; set; } = "";
        public int ColumnStart { get; set; }
        public int ColumnSpan { get; set; }
        public ElementReference Ref;

        public int StartPx(int columnWidth) => ColumnStart * columnWidth;

        public int WidthPx(int columnWidth) => ColumnSpan * columnWidth;
    }
}
