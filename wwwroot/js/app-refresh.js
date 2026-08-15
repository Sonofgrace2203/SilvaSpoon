window.silvaSpoonRefreshDotNet = null;

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
 * Tell Android whether the page is currently at the top.
 */
window.silvaSpoonCanPullToRefresh = function () {

    const scrollableElements = document.querySelectorAll(
        '*'
    );

    for (const element of scrollableElements) {

        const style = window.getComputedStyle(element);

        const isScrollable =
            (style.overflowY === 'auto' ||
             style.overflowY === 'scroll');

        if (isScrollable &&
            element.scrollHeight > element.clientHeight &&
            element.scrollTop > 0) {

            return false;
        }
    }

    return window.scrollY <= 0;
};