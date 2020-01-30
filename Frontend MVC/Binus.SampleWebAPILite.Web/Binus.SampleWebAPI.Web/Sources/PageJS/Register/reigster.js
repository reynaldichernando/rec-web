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

function Loader()
{
    $("#divMessage").text("");
   
    $('#btnLogin').attr('disabled', 'disabled');
    $('#btnLoginDB').attr('disabled', 'disabled');
}