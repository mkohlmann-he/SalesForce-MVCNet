$(document).ready(function () {
    $("#DivChildName").show();
    $("#DivChildAge").hide();
});


$(document).ready(function () {
    $("#ButtonChildName").click(function () {
        $("#DivChildName").slideToggle();
        $("#DivChildAge").slideToggle();
    });
});


