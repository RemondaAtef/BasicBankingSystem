$(document).ready(function () {
    $('#CustomerList').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            url: '/api/custmoerList',
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": true,
            "searchable": false
        }],
        "columns": [
            {
                "name": "AccountNumber",
                "data": "accountNumber",
                "autowidth": true
            },
            {
                "name": "Name",
                "data": "name",
                "autowidth": true
            },
            {
                "render": function (data, type, row) {
                    return '<img src=' +row.image + '}>' 
                },
                "orderable": false
            },
            {
                "name": "Email",
                "data": "email",
                "autowidth": true
            },
            {
                "name": "Balance",
                "data": "balance",
                "autowidth": true
            },
            {
                "render": function (data, type, row) {
                    return '<a href=customer/details?Id=' + row.id + ' class="btn btn-primary"  > Details </a>'
                },
                "orderable": false
            },

        ]



    });
});    