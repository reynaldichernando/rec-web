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
            url: Address + "/Schedule/GetScheduleByID",
            data: { ScheduleID: ID },
            success: function (Data) {
                let JSONData = Data.Data;
                $("#txtScheduleID").val(JSONData.ScheduleID);
                $("#txtPlace").val(JSONData.Place);
                $("#txtTopic").val(JSONData.Topic);
                $("#txtDesc").val(JSONData.Description);
                $('#txtStartTime').setNow();
                $('#txtEndTime').setNow();
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
       
    });


});


function LoadResult(Data) {
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
    console.log("shit");
}

function CleanForm() {
    $("#txtSchedule").val("");
    $("#txtPlace").val("");
    $("#txtTopic").val("");
    $("#txtDesc").val("");
    $('#txtStartTime').setNow();
    $('#txtEndTime').setNow();
    $('#MessageContainer').hide();
    $('#Message').text("");
}


$.fn.setNow = function (onlyBlank) {
    var now = new Date($.now())
        , year
        , month
        , date
        , hours
        , minutes
        , seconds
        , formattedDateTime
        ;

    year = now.getFullYear();
    month = now.getMonth().toString().length === 1 ? '0' + (now.getMonth() + 1).toString() : now.getMonth() + 1;
    date = now.getDate().toString().length === 1 ? '0' + (now.getDate()).toString() : now.getDate();
    hours = now.getHours().toString().length === 1 ? '0' + now.getHours().toString() : now.getHours();
    minutes = now.getMinutes().toString().length === 1 ? '0' + now.getMinutes().toString() : now.getMinutes();
    seconds = now.getSeconds().toString().length === 1 ? '0' + now.getSeconds().toString() : now.getSeconds();

    //formattedDateTime = year + '-' + month + '-' + date + 'T' + hours + ':' + minutes + ':' + seconds;
    formattedDateTime = year + '-' + month + '-' + date + 'T' + hours + ':' + minutes;

    if (onlyBlank === true && $(this).val()) {
        return this;
    }

    $(this).val(formattedDateTime);

    return this;
}

function Delete(ID) {
    let ConfirmDelete = confirm("Are you sure want to delete this record?");
    if (ConfirmDelete == true) {
        $.ajax({
            type: "POST",
            url: Address + "/Schedule/DeleteSchedule",
            data: { ScheduleID: ID },
            success: function (Data) {
                LoadResult(Data);
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
    }
}
