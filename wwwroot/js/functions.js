console.log("Script loaded");

window.addKeyListener = function (dotNetHelper) {
    console.log("addKeyListener called");
    document.addEventListener('keydown', function (event) {
        console.log("Key pressed: " + event.key);
        dotNetHelper.invokeMethodAsync('OnKeyPress', event.key).then(function () {
            console.log("OnKeyPress invoked");
        }).catch(function (error) {
            console.error("Error invoking OnKeyPress:", error);
        });
    });
};