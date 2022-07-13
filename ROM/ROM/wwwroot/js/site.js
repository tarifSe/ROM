// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Populate TextBoxes on DropDownList change
$('#member').change(function () {
    var memberId = $('#member').val();

    $.ajax({
        url: "/OrderDetails/GetMemberDetails",
        type: "POST",
        data: { memberId: memberId },
        success: function (member) {
            $('#name').val(member.name);
            $('#email').val(member.email);
            $('#contact').val(member.phone);
            $('#memberType').val(member.category.name);
        },
        error: function (response) {

        }
    });
});

$('#food').change(() => {
    var foodID = $('#food').val();

    $.ajax({
        url: "/OrderDetails/GetFoodDetails",
        type: "POST",
        data: { foodId: foodID },
        success: (food) => {
            $('#price').val(food.unitPrice);
        },
        error: function (response) {

        }
    });
});

$('#btnClick').click(function () {
    var memberId = $('#member').val();

    $.ajax({
        url: "/Report/OrderDetails",
        type: "POST",
        data: { memberId: memberId },
        success: (data) => {
            var sl = 1;
            var sum = 0;
            $('#tBody').empty();
            $('#price').empty();

            $.each(data, (key, item) => {
                var tr = "<tr><td>" + (sl++) + "</td> <td>" + item.food.name + "</td> <td>" + item.quantity + "</td> <td>" + item.food.unitPrice + "</td></tr>";
                $('#tBody').append(tr);

                sum += item.food.unitPrice;
                $('#price').text('Total Amount: ' + sum + 'Tk');
            });
        },
        error: (respons) => {

        }
    });
});