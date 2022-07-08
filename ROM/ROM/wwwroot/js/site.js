// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Populate TextBoxes on DropDownList change
$('#member').change(function () {
    var memberId = $('#member').val();

    $.ajax({
        url: "/OrderDetails/GetMember",
        type: "POST",
        data: { memberId: memberId },
        success: function (member) {
            $('#name').val(member.name);
            $('#email').val(member.email);
            $('#contact').val(member.phone);
            $('#type').val(member.category.name);
        },
        error: function (response) {

        }
    });
});