var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/order",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "7%" },
            { "data": "reference", "width": "20%" },
            { "data": "startDate", "width": "20%" },
            { "data": "endDate", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Sale/Order/detail?id=${data}" class="btn btn-primary btn-sm text-white" title="Detail" style="cussor:pointer; width:50px;">
                                    <i class="fas fa-eye"></i>
                                </a>
                                <a href="/Sale/order/upsert?id=${data}" class="btn btn-success btn-sm text-white" title="Edit" style="cussor:pointer; width:50px;">
                                    <i class="far fa-edit"></i>
                                </a>
                                <a class="btn btn-danger btn-sm text-white" title="Delete" style="cursor:pointer; width:50px;" onclick=Delete('/api/order/'+${data})>
                                    <i class="far fa-trash-alt"></i>
                                </a>
                    </div>`;
                }, "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order": [[3, "asc"]]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}