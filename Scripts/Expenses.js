
function AddExpenses() {
    alert($('#txtAmount').val());
    var empObj = {
        Amount: $('#txtAmount').val(),
        Expense_Type_ID: $('#Expense_Expense_Type_ID').val(),
        Description: $('#Description').val(),
        CreatedBy: $('#User_id').val()
        
    };
    $.ajax({
        url: "/Expense/AddExpenses",
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