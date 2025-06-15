let currentTask = null;
let startX = 0;
console.log("🔥 gantt.js LOADED 🔥");
window.setupGanttDrag = () => {
    document.addEventListener('mousemove', e => {
        if (currentTask) {
            const dx = e.clientX - startX;
            const newLeft = currentTask._startPx + dx;
            currentTask.style.left = `${newLeft}px`;
            console.log(`🟢 przesuwam: ${newLeft}px`);
        }
    });

    document.addEventListener('mouseup', () => {
        console.log("mouseup!");
        if (currentTask) {
            currentTask._startPx = parseInt(currentTask.style.left);
            currentTask = null;
        }
    });
};

window.enableTaskDrag = (element) => {
    element.addEventListener('mousedown', e => {
        console.log("mousedown!");
        currentTask = element;
        startX = e.clientX;
        element._startPx = parseInt(element.style.left);
    });
};