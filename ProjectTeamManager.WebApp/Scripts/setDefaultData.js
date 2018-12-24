$(document).ready(function () {
    $("#create").click(function () {
        var d = new Date();
        var date = d.getDate();
        var month = d.getMonth();
        var year = d.getFullYear();
        var hour = d.getHours();
        var minutes = d.getMinutes();
        var second = d.getSeconds();

        function pad(n) {
            return n < 10 ? '0' + n : n;
        }
        //Get time default of C#
        var getDateTime = year + "-" + pad(month + 1) + "-" + pad(date)
            + " " + pad(hour) + ":" + pad(minutes) + ":" + pad(second);

        //$(".IsDeleted").val(1);
        $("#InsAt").val(getDateTime.toString());
        $(".InsBy").val("Admin");
        $(".UpdBy").val("Admin");
        $("#UpdAt").val(getDateTime.toString());
    });
    $("#save").click(function () {
        var d = new Date();
        var date = d.getDate();
        var month = d.getMonth();
        var year = d.getFullYear();
        var hour = d.getHours();
        var minutes = d.getMinutes();
        var second = d.getSeconds();

        function pad(n) {
            return n < 10 ? '0' + n : n;
        }
        //Get time default of C#
        var getDateTime = year + "-" + pad(month + 1) + "-" + pad(date)
            + " " + pad(hour) + ":" + pad(minutes) + ":" + pad(second);
        $("#UpdAt").val(getDateTime.toString());
    });
});