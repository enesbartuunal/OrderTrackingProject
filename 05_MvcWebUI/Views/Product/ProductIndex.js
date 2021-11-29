$(function () {
    $(".kamil").click(function () {
        var cId = $(this).attr("categoryId");
        var rId = $(this).attr("resId");
        $.ajax({
            type: "Get",
            dataType: "Json",
            url: "/Product/Index",
            data: { restaurantId: rId, category: cId }
        })
    });
});