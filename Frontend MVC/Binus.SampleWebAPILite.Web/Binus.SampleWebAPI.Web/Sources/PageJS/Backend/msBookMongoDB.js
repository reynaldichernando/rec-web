
$(document).ready(function () {
    $('#MessageContainer').hide();
    $('#myModal').on('show.bs.modal', function (event) {
        CleanForm();
        var button = $(event.relatedTarget);
        var ID = button.data('id');
        var Type = button.data('type');
        var modal = $(this);
        var formData = "IDEncrypt=" + ID;
        $("#hdID").val("");
        $("#hdType").val("I");
        modal.find('.modal-title').text(Type + " Book Data");
        if (Type == "Edit")
        {
            $("#hdID").val(ID);
            $("#hdType").val("U");
            $.ajax({
                type: "POST",
                url: Address + "/msBookMongoDB/" + Type,
                data: formData,
                success: function (Data) {
                    $('#MessageContainer').hide();
                    var JSONData = Data;
                    
                    if (Data != "") {
                       
                            $("#txtISBN").val(JSONData[0].ISBN);
                            $("#txtBookName").val(JSONData[0].BookName);
                            $("#txtAuthor").val(JSONData[0].Author);
                            $("#txtPublisher").val(JSONData[0].Publisher);
                       
                    }
                    else {
                        $('#MessageContainer').show();
                        $('#Message').text("Invalid request");
                    }
                },
                error: function (data) {
                    $('#MessageContainer').show();
                    $('#Message').text("Invalid request");
                }
            });
        }
        

    });
});

function CleanForm()
{
    $("#hdID").val("");
    $("#hdType").val("");
    $("#txtISBN").val("");
    $("#txtBookName").val("");
    $("#txtAuthor").val("");
    $("#txtPublisher").val("");
    $('#MessageContainer').hide();
    $('#Message').text("");
}

function Delete(ID)
{
    var ConfirmDelete = confirm("Are you sure want to delete this record?");
    if (ConfirmDelete == true)
    {
        $.ajax({
            type: "POST",
            url: Address + "/msBookMongoDB/Manipulation",
            data: "BookMongoDB.IDEncrypt=" + ID + "&BookMongoDB.Stsrc=D",
            success: function (Data) {
                LoadResult(Data);
            },
            error: function (Data) {
                alert("Error : "+Data);
            }
        });
    }
}

function LoadResult(Data)
{
    var Value = JSON.parse(JSON.stringify(Data));
    //console.log(Value);
    if (Value.Result == "Success") {
        window.location = Value.URL;
    }
    if (Value.Result == "Fail") {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
    }
}
