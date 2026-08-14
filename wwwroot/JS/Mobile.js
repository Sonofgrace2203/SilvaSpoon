(function () {
    let startY = 0;
    let pulling = false;

    document.addEventListener("touchstart", function (event) {
        if (window.scrollY === 0) {
            startY = event.touches[0].clientY;
            pulling = true;
        }
    }, { passive: true });

    document.addEventListener("touchmove", function (event) {
        if (!pulling) return;

        const currentY = event.touches[0].clientY;
        const distance = currentY - startY;

        if (window.scrollY === 0 && distance > 80) {
            pulling = false;
            window.location.reload();
        }
    }, { passive: true });

    document.addEventListener("touchend", function () {
        pulling = false;
    }, { passive: true });
})();