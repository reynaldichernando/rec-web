$(document).ready(function () {
    $('#MessageContainer').hide();
    $('#insertModal').on('show.bs.modal', function (event) {
        CleanForm();
        let modal = $(this);
        let button = $(event.relatedTarget)
        let type = button.data('type');
        let ID = button.data('id');
        if (type != 'edit') modal.find('.modal-title').text("Insert Assignment");
        else {
            $.ajax({
                type: "POST",
                url: Address + "/Assignment/GetAssignment",
                data: { AssignmentID: ID },
                success: function (Data) {
                    let JSONData = Data.Data;
                    //console.log(JSONData);
                    $("#txtAssignmentID").val(JSONData.AssignmentID);
                    $("#txtTitle").val(JSONData.Title);
                    $("#txtDesc").val(JSONData.Description);
                    //$("#txtDateDue").val(new Date(parseFloat((JSONData.DateDue).substr(6, 13))).toISOString().substr(0, 19));
                    $("#txtAssignmentFilePath").val(JSONData.AssignmentFilepath);
                },
                error: function (Data) {
                    alert("Error : " + Data);
                }
            });
        }
    });
});

function LoadResult(Data) {
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
        window.location = Value.URL

        //setTimeout(function () {
        //    window.location = Value.URL;
        //}, 2000)
    }
    else {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
    }
}

function CleanForm() {
    $("#txtAssignmentID").val("")
    $("#txtTitle").val("")
    $("#txtDesc").val("");
    $("#txtDateDue").val("");
    $("#txtAssignmentFilePath").val("");
    $('#MessageContainer').hide();
    $('#Message').text("");
}

function Delete(ID) {
    let ConfirmDelete = confirm("Are you sure want to delete this record?");
    if (ConfirmDelete == true) {
        $.ajax({
            type: "POST",
            url: Address + "/Assignment/Delete",
            data: { AssignmentID: ID },
            success: function (Data) {
                LoadResult(Data);
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
    }
}