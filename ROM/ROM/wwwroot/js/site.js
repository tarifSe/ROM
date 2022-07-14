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
    var date = $('#date').val();

    $.ajax({
        url: "/Report/OrderDetails",
        type: "POST",
        data: { memberId: memberId, date: date },
        success: (data) => {
            var sl = 1;
            var totalPrice = 0.00;
            var grandTotal = 0.00;

            $('#tBody').empty();
            $('#price').empty();

            $.each(data, (key, item) => {
                totalPrice = item.food.unitPrice * item.quantity;
                var tr = "<tr><td>" + (sl++) + "</td> <td>" + item.food.name + "</td> <td>" + item.food.unitPrice + "</td> <td>" + item.quantity + "</td> <td>" + totalPrice + "</td></tr>";
                $('#tBody').append(tr);

                grandTotal += totalPrice;
                $('#price').text('Intotal Amount: ' + grandTotal + 'Tk');
            });
        },
        error: (respons) => {

        }
    });
});

//post saved msg remove
$('#divRemove').fadeOut(8000);