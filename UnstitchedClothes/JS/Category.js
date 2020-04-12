$(document).ready(function () {
    onLoad();
});
var onLoad = function () {
    $.ajax({
        url: "/Category/GetCategories",
        type: "GET",
        success: function (response) {
            $("#divLoadItems").html(response);
            $("#GetCategories").DataTable();
        }
    });
}
var OpenModal = function () {
    $("#CatModal").modal(
        {
            backdrop: 'static',
            keyboard: false
        });
}
var SaveCategory = function () {
    var valid = true;
    var Name = $("#Name").val();
    var Description = $("#Description").val();
    if (Name == "") {
        $('#Name').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#Name').css("border", "1px solid #ccc");
    }
    if (valid) {
        $.ajax({
            url: "/Category/Create",
            type: "POST",
            data: { Name: Name, Description: Description },
            success: function (response) {
                $("#CatModal").modal('hide');
                onLoad();
            }
        });
    }
}
var EditCateory = function (Id, Name, Description) {
    $("#CatEditModal").modal({
        backdrop: 'static',
        keyboard: false
    });
    var CatId = $("#hiddenId").val(Id);
    var EditName = $("#Names").val(Name);
    var EditDescription = $("#Descriptions").val(Description);
}
var EditCategory = function () {
    var valid = true;
    var Id = $("#hiddenId").val();
    var EditName = $("#Names").val();
    var EditDescription = $("#Descriptions").val();
    if (EditName == "") {
        $('#Names').css("border", "1px solid red");
        valid = false;
    }
    else {
        $('#Names').css("border", "1px solid #ccc");
    }
    if (valid) {
        $.ajax({
            url: "/Category/Edit",
            type: "POST",
            data: { Id: Id, EditName: EditName, EditDescription: EditDescription },
            success: function (response) {
                $("#CatEditModal").modal('hide');
                onLoad();
            }
        });
    }
}
