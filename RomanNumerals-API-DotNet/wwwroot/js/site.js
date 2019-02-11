// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$("#convertButton").click(function () {
    var input = $("#convertInput").val();
    $.ajax(
        {
            url: "api/ConvertToNumeral?number=" + input,
            success: function (result) {
                $("#convertResult").text(result);
            },
            error: function (result) {
                $("#convertResult").text("An error occured");
            }
        });
});

$("#getPreviousButton").click(function () {
    $.ajax(
        {
            url: "api/RecentConversions",
            success: function (result) {
                var list = $("#recentResults");
                list.empty();
                result.forEach(function (element) {
                    $("<li/>")
                        .text(JSON.stringify(element))
                        .appendTo(list);
                });

            },
            error: function (error) {
                var list = $("#recentResults");
                list.empty();   
                $("<li/>")
                    .text("An error occured")
                    .appendTo(list);
            }
        });
});

$("#getTopTenButton").click(function () {
    $.ajax(
        {
            url: "api/TopConversions",
            success: function (result) {
                var list = $("#topTenResults");
                list.empty();
                result.forEach(function (element) {
                    $("<li/>")
                        .text(JSON.stringify(element))
                        .appendTo(list);
                });
            },
            error: function (error) {
                var list = $("#topTenResults");
                $("<li/>")
                    .text("An error occured")
                    .appendTo(list);
            }
        });
});