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