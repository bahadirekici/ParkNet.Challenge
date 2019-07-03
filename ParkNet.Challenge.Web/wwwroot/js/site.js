
$(document).ready(function () {

    var table = $('#tblWords').DataTable({
        data: result.Result,
        select: true,
        "searching": true,
        "paging": true,
        "processing": false,
        "pageLength": 20,
        "bLengthChange": false,
        "bInfo": false,
        "bAutoWidth": false,
        "bFilter": false,
        dom: 't',
        columns: [
            
            {
                'title': 'Kelime',
                'data': 'Kelime',
            },
            {
                'title': 'Sayı',
                'data': 'Sayı',
            },
        ],
        "initComplete": function (settings, json) {


        },

        "drawCallback": function () {
          

        },
        "createdRow": function (row, data, dataIndex) {
        }
    });
});