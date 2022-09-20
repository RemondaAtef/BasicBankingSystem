$("#btnSearch").click(function () {
    if (!$("#customerEmail").is(":visible")) {
        var html = '';
        html += '<div class="row control-group">';
        html += '<div class="form-group col-xs-12  controls">';
        html += ' <input type="text" class="form-control input" placeholder="Customer Email Address" readonly id="customerEmail">';
        html += '</div>';
        html += '</div>';



        $('#success').append(html);


    }
    var ReciverAccountNumber = $("#ReciverAccountNumber").val();
    $.ajax({
        url: "/customer/SearchCustomerByAccountNumber",
        data: { ReciverAccountNumber: ReciverAccountNumber },
        success: function (res) {
            var customerEmail = res.email;
            var customerName = res.name;

            $("#customerEmail").val(customerEmail);
            if (!$("#customerName").is(":visible")) {
                if (customerEmail != "Customer not found") {
                    var html = '';
                    html += '<div class="row control-group">';
                    html += '<div class="form-group col-xs-12  controls">';
                    html += ' <input type="text" class="form-control input" placeholder="customer Name" id="customerName"  readonly>';
                    html += '</div>';
                    html += '</div>';

                    html += '<div class="row control-group">';
                    html += '<div class="form-group col-xs-12  controls">';
                    html += ' <input type="number" start="1000" step="1000" class="form-control " placeholder="Ammount of money" name="AmountOfMoney" required>';
                    html += '</div>';
                    html += '</div>';

                    html += '<div class="row control-group">';
                    html += '<div class="form-group col-xs-12 text-right">';
                    html += '<button type="submit" class="btn btn-white btn-lg">Send Money</button>';
                    html += '</div>';
                    html += '</div>';
                    $('#data').append(html);
                    $("#customerName").val(customerName);
                }
            } else
                $("#data").empty();


        }
    });
}); 