$(document).ready(function () {
    function hideErrorMessages() {

        $('#error-confirm-password').hide();
    }

    $('#btnLoginDBReg').on('click', function (event) {
        $('#btnLoginDBReg').attr('disabled', true);
        console.log("test");
        hideErrorMessages();

        let isValid = true;
        const password = $('#inputPasswordReg').val();
        const confirmpassword = $('#inputConfirmPasswordReg').val();
        if (confirmpassword != password) {
            $('#error-confirm-password-reg').show();
            isValid = false;
        }

        if (isValid) {  
            $(this).submit();
        } else {
            event.preventDefault();
        }
    })

    $('#btn-forgot').on('click', function (event) {
        $('#btn-forgot').attr('disabled', true);
        $.ajax({
            method: "GET",
            url: Address + "/Password/SendAsync?Email=" + $('#input-email-forgot').val(),
            success: function (data) {
                $('#forgot-message').text("Success sent request!");

                setTimeout(function () {
                    $('#btn-forgot').removeAttr('disabled');
                    window.location = Address;
                }, 1000)
            },
            error: function (data) {
                console.log(data)
            }
        })
    })
});

function LoadResult(Data)
{
    const Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success")
    {
        $("#divMessage").text(Value.Message);
        window.location = Value.URL;
    }
    else
    {
        $('#btnLogin').removeAttr('disabled');
        $('#btnLoginDB').removeAttr('disabled');
        $("#divMessage").text(Value.Message);
    }
}

function LoadResultReg(Data) {
    $('#regMessage').text('');
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#regMessage').text(Value.Message);

        setTimeout(function () {
            $('#btnLoginDBReg').removeAttr('disabled');
            window.location = Value.URL;
        }, 1000)
    }
    else {
        $('#regMessage').text(Value.Message);
        $('#btnLoginDBReg').removeAttr('disabled');
    }
}

function LoadResultForgot(Data) {
    $('#forgot-message').text('');
    var Value = JSON.parse(JSON.stringify(Data));

    if (Value.Status == "Success") {
        $('#forgot-message').text(Value.Message);

        setTimeout(function () {
            $('#btn-forgot').removeAttr('disabled');
            window.location = Value.URL;
        }, 1000)
    }
    else {
        $('#forgot-message').text(Value.Message);
        $('#btn-forgot').removeAttr('disabled');
    }
}

function Loader() {
    $("#divMessage").text("");

    $('#btnLogin').attr('disabled', 'disabled');
    $('#btnLoginDB').attr('disabled', 'disabled');


}