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
                "name": "Name",
                "data": "name",
                "autowidth": true
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
                    return '<a href=customer/details=' + row.id + ' class="btn btn-primary"  > Details </a>'
                },
                "orderable": false
            },

        ]



    });
});    