// (function () {
//     let startY = 0;
//     let currentY = 0;
//     let pulling = false;
//     let refreshing = false;

//     const threshold = 90;

//     const indicator = document.createElement("div");
//     indicator.id = "pull-refresh-indicator";

//     indicator.innerHTML = `
//         <div class="pull-refresh-spinner"></div>
//         <span class="pull-refresh-text">Pull to refresh</span>
//     `;

//     document.body.appendChild(indicator);

//     const text = indicator.querySelector(".pull-refresh-text");

//     document.addEventListener("touchstart", function (event) {
//         if (refreshing || window.scrollY > 0) {
//             return;
//         }

//         startY = event.touches[0].clientY;
//         currentY = startY;
//         pulling = true;

//     }, { passive: true });


//     document.addEventListener("touchmove", function (event) {
//         if (!pulling || refreshing) {
//             return;
//         }

//         currentY = event.touches[0].clientY;

//         const distance = currentY - startY;

//         if (distance <= 0) {
//             return;
//         }

//         const pullDistance = Math.min(distance * 0.5, 120);

//         indicator.style.transform =
//             `translateY(${pullDistance}px)`;

//         indicator.style.opacity =
//             Math.min(pullDistance / threshold, 1);

//         if (pullDistance >= threshold) {
//             text.textContent = "Release to refresh";
//             indicator.classList.add("ready");
//         } else {
//             text.textContent = "Pull to refresh";
//             indicator.classList.remove("ready");
//         }

//     }, { passive: true });


//     document.addEventListener("touchend", function () {
//         if (!pulling || refreshing) {
//             return;
//         }

//         pulling = false;

//         const distance = currentY - startY;
//         const pullDistance = Math.min(distance * 0.5, 120);

//         if (pullDistance >= threshold) {

//             refreshing = true;

//             indicator.classList.add("refreshing");
//             text.textContent = "Refreshing...";

//             indicator.style.transform =
//                 "translateY(70px)";

//             setTimeout(function () {
//                 window.location.reload();
//             }, 500);

//         } else {

//             indicator.style.transform =
//                 "translateY(0)";

//             indicator.style.opacity = "0";

//             indicator.classList.remove("ready");

//         }

//     }, { passive: true });


//     document.addEventListener("touchcancel", function () {
//         pulling = false;

//         indicator.style.transform =
//             "translateY(0)";

//         indicator.style.opacity = "0";

//         indicator.classList.remove("ready");

//     }, { passive: true });

// })();