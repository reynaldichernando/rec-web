$(document).ready(function () {
    $('#MessageContainer').hide();
    $('#updateModal').on('show.bs.modal', function (event) {
        CleanForm();
        let modal = $(this);
        let button = $(event.relatedTarget)
        let ID = button.data('id');
        console.log(ID);
        $.ajax({
            type: "POST",
            url: Address + "/Thread/GetOneThread",
            data: { ThreadID: ID },
            success: function (Data) {
                let JSONData = Data.Data;
                $("#txtThreadID").val(JSONData.ThreadID);
                $("#txtUserID").val(JSONData.UserID);
                $("#txtTitle").val(JSONData.Title);
                $("#txtContent").val(JSONData.Content);
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
    });
});


function LoadResult(Data) {
    debugger;
    console.log("not even here");
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
        window.location = Value.URL;
        console.log("maybe?");
    }
    else {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
        console.log("nope?");

    }
    console.log("....");
}

function CleanForm() {
    $("#txtThreadID").val("");
    $("#txtUserID").val("");
    $("#txtTitle").val("");
    $("#txtContent").val("");
    $('#MessageContainer').hide();
    $('#Message').text("");
}

function Delete(ID) {
    let ConfirmDelete = confirm("Are you sure want to delete this thread?");
    if (ConfirmDelete == true) {
        $.ajax({
            type: "POST",
            url: Address + "/Thread/DeleteThread",
            data: { ThreadID: ID },
            success: function (Data) {
                LoadResult(Data);
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
    }
}