$(document).ready(function () {
    //$('#submit-thread').click(function (event) {
    //    $(event.target).attr("disabled", true);
    //})

    $('#MessageContainer').hide();
    $('#updateModal').on('show.bs.modal', function (event) {
        CleanForm();
        let modal = $(this);
        let button = $(event.relatedTarget)
        let ID = button.data('id');
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
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
        $('#submit-thread').removeAttr("disabled");
        window.location = Value.URL;
    }
    else {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
        $('#submit-thread').removeAttr("disabled");

    }
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