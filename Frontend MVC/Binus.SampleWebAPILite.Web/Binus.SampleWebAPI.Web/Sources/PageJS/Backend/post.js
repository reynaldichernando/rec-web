$(document).ready(function () {
    $('#MessageContainer2').hide();
    $(document).on('show.bs.modal', '#update-modal', function (event) {
        CleanForm();
        let modal = $(this);
        let button = $(event.relatedTarget)
        let ID = button.data('id');
        console.log(ID);
        $.ajax({
            type: "POST",
            url: Address + "/Post/GetPostByID",
            data: { PostID: ID },
            success: function (Data) {
                let JSONData = Data.Data;
                $("#txtPostID").val(JSONData.PostID);
                $("#txtThreadID2").val(JSONData.ThreadID);
                $("#txtUserID2").val(JSONData.UserID);
                $("#txtContent2").val(JSONData.Content);
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
    });
});


function LoadResult(Data) {
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#MessageContainer2').show();
        $('#Message2').text(Value.Message);
        window.location = Value.URL;
    }
    else {
        $('#MessageContainer2').show();
        $('#Message2').text(Value.Message);

    }
}

function CleanForm() {
    $("#txtPostID").val("");
    $("#txtThreadID2").val("");
    $("#txtUserID2").val("");
    $("#txtContent2").val("");
    $('#MessageContainer2').hide();
    $('#Message2').text("");
}

function DeletePost(ID) {
    let ConfirmDelete = confirm("Are you sure want to delete this reply?");
    if (ConfirmDelete == true) {
        $.ajax({
            type: "POST",
            url: Address + "/Post/DeletePost",
            data: { PostID: ID },
            success: function (Data) {
                LoadResult(Data);
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
    }
}