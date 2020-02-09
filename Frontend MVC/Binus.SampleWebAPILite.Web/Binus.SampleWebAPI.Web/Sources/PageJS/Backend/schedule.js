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
                //$('#txtStartTime').setNow();
                //$('#txtEndTime').setNow();
                $('#txtStartTime').val(JSONData.StartTime);
                $('#txtEndTime').val(JSONData.EndTime);
            },
            error: function (Data) {
                alert("Error : " + Data);
            }
        });
       
    });
    $('#insertModal').on('show.bs.modal', function (event) {
        console.log("insert");
        CleanForm();
    });

    $('#submit-schedule').on('click', function (event) {
        let isValid = true;
        let startTime = $('#itxtStartTime').val();
        let endTime = $('#itxtEndTime').val();
        if (Date.parse(startTime) >= Date.parse(endTime)) {
            $('#i-invalid-date').show();
            isValid = false;
        }
        if (isValid) {
            $(this).submit();
        } else {
            event.preventDefault();
        }
        
    });
    $('#update-schedule').on('click', function (event) {
        let isValid = true;
        let startTime = $('#txtStartTime').val();
        let endTime = $('#txtEndTime').val();
        if (Date.parse(startTime) >= Date.parse(endTime)) {
            $('#invalid-date').show();
            isValid = false;
        }
        if (isValid) {
            $(this).submit();
        } else {
            event.preventDefault();
        }

    });
  
});
function LoadResult(Data) {
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);
        window.location = Value.URL;
    }
    else {
        $('#MessageContainer').show();
        $('#Message').text(Value.Message);

    }
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

    $("#itxtSchedule").val("");
    $("#itxtPlace").val("");
    $("#itxtTopic").val("");
    $("#itxtDesc").val("");
    //$('#itxtStartTime').setNow();
    //$('#itxtEndTime').setNow();

    $('#i-invalid-date').hide();
    $('#invalid-date').hide();
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

