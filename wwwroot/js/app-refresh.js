window.silvaSpoonRefreshDotNet = null;

window.silvaSpoonCanRefresh = true;

window.silvaSpoonSetRefreshReference = function (dotNetReference) {
    window.silvaSpoonRefreshDotNet = dotNetReference;
};

window.silvaSpoonRefresh = function () {

    if (window.silvaSpoonRefreshDotNet) {

        return window.silvaSpoonRefreshDotNet.invokeMethodAsync(
            "RefreshCurrentPage"
        );
    }

    return Promise.resolve();
};


/*
 * Track the actual scrolling container.
 */
window.silvaSpoonSetupScrollTracking = function () {

    const adminContainer =
        document.getElementById("admin-scroll-container");

    if (adminContainer) {

        window.silvaSpoonCanRefresh =
            adminContainer.scrollTop <= 0;

        adminContainer.addEventListener(
            "scroll",
            function () {

                window.silvaSpoonCanRefresh =
                    adminContainer.scrollTop <= 0;

            },
            { passive: true }
        );

        return;
    }

    /*
     * Customer/public pages.
     */
    window.silvaSpoonCanRefresh =
        window.scrollY <= 0;

    window.addEventListener(
        "scroll",
        function () {

            window.silvaSpoonCanRefresh =
                window.scrollY <= 0;

        },
        { passive: true }
    );
};