var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/account",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "website", "width": "35%" },        
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/account/detail?id=${data}" class="btn btn-primary btn-sm text-white" title="Detail" style="cussor:pointer; width:45px;">
                                    <i class="fas fa-eye"></i>
                                </a>
                                
                                <a href="/Admin/account/upsert?id=${data}" class="btn btn-success text-white" style="cussor:pointer; width:45px;">
                                    <i class="far fa-edit"></i>
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:45px;" onclick=Delete('/api/account/'+${data})>
                                    <i class="far fa-trash-alt"></i>
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