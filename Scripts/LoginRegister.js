

function Authenticate() {
    var empObj = {
        UserName: $('#UserName').val(),
        Password: $('#Password').val()
    };
    $.ajax({
        url: "/Login/Authenticate",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            window.location.href = '/Dashboard/Index?id=' + result[0].id;
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function AddUserDetails() {    
    var empObj = {
        
        profilename: $('#profilename').val(),
        UserName: $('#UserName').val(),
        Password: $('#password').val()
    };
    $.ajax({
        url: "/Login/Register",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result.responseText);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}