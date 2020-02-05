$(document).ready(function () {
    $('#form-upload-assignment').submit(function (e) {
        var file = $('#assignment-file')[0].files[0];
        let fileName = file.name;
        var formData = new FormData();
        formData.append('file', file);
        formData.append('path', "./Assignment/" + $('#txtTitle').val() + "/");

        $('#txtAssignmentFilePath').val(fileName);
        $.ajax({
            url: Address + '/Assignment/Upload',
            type: 'POST',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            //success: function (data) {
            //    //alert(data);
            //},
            //error: function (data) {
            //    console.log("Error: " + data)
            //},
            xhr: function () {
                var myXhr = $.ajaxSettings.xhr();
                if (myXhr.upload) {
                    myXhr.upload.addEventListener('progress', function (e) {
                        if (e.lengthComputable) {
                            $('progress').attr({
                                value: e.loaded,
                                max: e.total,
                            });
                        }
                    }, false);
                }
                return myXhr;
            }
        });
    });

    $('#form-upload-answer').submit(function (e) {
            var file = $('#answer-file')[0].files[0];
            let fileName = file.name;
            var formData = new FormData();
            formData.append('file', file);
            formData.append('path', "./Answer/" + $('#assignment-name').val() + "/" + $('#userid').val() + "/");

            $('#txtAnswerFilePath').val(fileName);
            $.ajax({
                url: Address + '/Assignment/Upload',
                type: 'POST',
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                error: function (data) {
                    console.log("Error: " + data)
                },
                xhr: function () {
                    var myXhr = $.ajaxSettings.xhr();
                    if (myXhr.upload) {
                        myXhr.upload.addEventListener('progress', function (e) {
                            if (e.lengthComputable) {
                                $('progress').attr({
                                    value: e.loaded,
                                    max: e.total,
                                });
                            }
                        }, false);
                    }
                    return myXhr;
                }
            });
        });

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
                    $('#txtDateDue').setNow();
                    $("#txtAssignmentFilePath").val(JSONData.AssignmentFilepath);
                },
                error: function (Data) {
                    alert("Error : " + Data);
                }
            });
        }
    });

    $('#uploadAnswer').on('show.bs.modal', function (event) {
        let modal = $(this);
        let button = $(event.relatedTarget);
        let title = button.data('title');
        let id = button.data('id');
        modal.find('.modal-title').text(title);
        modal.find('#assignment-name').val(title);
        modal.find('#assignment-id').val(id);
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

function CleanForm() {
    $("#txtAssignmentID").val("")
    $("#txtTitle").val("")
    $("#txtDesc").val("");
    $('#txtDateDue').setNow();
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

function Download(fileName) {
    $.ajax({
        type: "GET",
        url: Address + "/Assignment/DownloadFile",
        data: { fileName: fileName },
        success: function (Data) {
        },
        error: function (Data) {
            alert("Error : " + Data);
        }
    });
}