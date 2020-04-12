$(document).ready(function () {
    onLoad();
});
var onLoad = function () {
    $.ajax({
        url: "/Product/GetProducts",
        type: "GET",
        success: function (response) {
            $("#divLoadItems").html(response);
            $("#GetProducts").DataTable();
        }
    });
}
var OpenModal = function () {
    $("#ProModal").modal(
        {
            backdrop: 'static',
            keyboard: false
        });
}
var SaveProduct = function () {
    var valid = true;
    var Name = $("#Name").val();
    var Description = $("#Description").val();
    var CategoryId = $("#CatId option:selected").val();
    var Price = $("#Price").val();

    if (Name == "") {
        $('#Name').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#Name').css("border", "1px solid #ccc");
    }
    if (Price == "") {
        $('#Price').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#Price').css("border", "1px solid #ccc");
    } if (CategoryId == "") {
        $('#CatId').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#CatId').css("border", "1px solid #ccc");
    }
    if (valid) {
        $.ajax({
            url: "/Product/Create",
            type: "POST",
            data: { Name: Name, Description: Description, CategoryId: CategoryId, Price: Price },
            success: function (response) {
                $("#ProModal").modal('hide');
                onLoad();
            }
        });
    }
}
var EdProducts = function (Id, Name, Description, Price, CategoryId) {
    $("#ProEditModal").modal({
        backdrop: 'static',
        keyboard: false
    });
    var ProId = $("#hiddenId").val(Id);
    var EditName = $("#Names").val(Name);
    var EditDescription = $("#Descriptions").val(Description);
    var EditPrice = $("#Prices").val(Price);
    var cate = $("#CatIds").val(CategoryId);
    var EditCategoryid = $("#CatIds").trigger('change');

}
var EditProduct = function () {
    var valid = true;
    var Id = $("#hiddenId").val();
    var EditName = $("#Names").val();
    var EditDescription = $("#Descriptions").val();
    var EditPrice = $("#Prices").val();
    var EditCategoryId = $("#CatIds option:selected").val();

    if (EditName == "") {
        $('#Names').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#Names').css("border", "1px solid #ccc");
    }
    if (EditPrice == "") {
        $('#Prices').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#Prices').css("border", "1px solid #ccc");
    } if (EditCategoryId == "") {
        $('#CatIds').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#CatIds').css("border", "1px solid #ccc");
    }
    if (valid) {
        $.ajax({
            url: "/Product/Edit",
            type: "POST",
            data: { Id: Id, EditName: EditName, EditDescription: EditDescription, EditPrice: EditPrice, EditCategoryId: EditCategoryId},
            success: function (response) {
                $("#ProEditModal").modal('hide');
                onLoad();
            }
        });
    }
}

$("#SeatchIt").click(function () {
    var good = $("#SearchTxt").val();
    $.ajax({
        url: "/Product/GetProducts",
        date: { good: good },
        async: false,
        success: function (response) {
            alert("ok");
        }
    })
});