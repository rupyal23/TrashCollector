$("input[type='radio']").change(function () {
    if ($(this).val() == "yes") {
        $("#txt").show();
    } else {
        $("#txt").hide();
    }
});