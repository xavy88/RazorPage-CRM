var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/department",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "description", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/department/detail?id=${data}" class="btn btn-primary btn-sm text-white" title="Detail" style="cussor:pointer; width:50px;">
                                    <i class="fas fa-eye"></i><!-- Detail-->
                                </a>
                                <a href="/Admin/department/upsert?id=${data}" class="btn btn-success btn-sm text-white" title="Edit" style="cussor:pointer; width:50px;">
                                    <i class="far fa-edit"></i><!-- Edit-->
                                </a>
                                <a class="btn btn-danger btn-sm text-white" title="Delete" style="cursor:pointer; width:50px;" onclick=Delete('/api/department/'+${data})>
                                    <i class="far fa-trash-alt"></i> <!--Delete-->
                                </a>
                    </div>`;
                }, "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
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