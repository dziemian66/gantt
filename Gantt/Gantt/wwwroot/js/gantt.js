let currentTask = null;
let startX = 0;
let columnWidth = 50;

window.setColumnWidth = (w) => {
    columnWidth = w;
};

console.log("🔥 gantt.js LOADED 🔥");
window.setupGanttDrag = () => {
    document.addEventListener('mousemove', e => {
        if (currentTask) {
            const dx = e.clientX - startX;
            const newLeft = currentTask._startPx + dx;
            const snapped = Math.round(newLeft / columnWidth) * columnWidth;
            currentTask.style.left = `${snapped}px`;
            console.log(`🟢 przesuwam: ${snapped}px`);
        }
    });

    document.addEventListener('mouseup', () => {
        console.log("mouseup!");
        if (currentTask) {
            const px = parseInt(currentTask.style.left);
            const column = Math.round(px / columnWidth);
            if (currentTask._helper) {
                currentTask._helper.invokeMethodAsync('OnDragEnd', column);
            }
            currentTask._startPx = px;
            currentTask = null;
        }
    });
};

window.enableTaskDrag = (element, dotnetHelper) => {
    element.addEventListener('mousedown', e => {
        console.log("mousedown!");
        currentTask = element;
        startX = e.clientX;
        element._startPx = parseInt(element.style.left);
        element._helper = dotnetHelper;
    });
};
