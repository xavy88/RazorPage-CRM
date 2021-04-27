var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/taskassignment",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "account.name", "width": "20%" },
            { "data": "task.name", "width": "20%" },
            { "data": "applicationUser.email", "width": "20%" },
            { "data": "dueDate","width": "15%" },
            {
                /*
                "data": { id: "id", completed: "completed" },
                "render": function (data) {
                    //var today = new Date().getTime();
                    var status =  data.completed;
                    if (status == false) {
                         //The task is Currently pending
                        return ` <div class="text-center">
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=CompletedPending('${data.id}')>
                                  <i class="far fa-square"></i> 
                                </a></div>`;
                    }
                    else {
                        return ` <div class="text-center">
                                <a class="btn btn-success text-white" style="cursor:pointer; width:100px;" onclick=CompletedPending('${data.id}')>
                                   <i class="far fa-check-square"></i>
                                </a></div>`;
                    }
                   
                }, "width": "30%"*/
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/TaskAssignment/detail?id=${data}" class="btn btn-primary btn-sm text-white" title="Detail" style="cussor:pointer; width:45px;">
                                    <i class="fas fa-eye"></i><!-- Detail-->
                                </a>
                                <a href="/TaskAssignment/upsert?id=${data}" class="btn btn-success btn-sm text-white" title="Edit" style="cussor:pointer; width:45px;">
                                    <i class="far fa-edit"></i><!-- Edit-->
                                </a>
                                <a class="btn btn-danger btn-sm text-white" title="Delete" style="cursor:pointer; width:45px;" onclick=Delete('/api/taskassignment/'+${data})>
                                    <i class="far fa-trash-alt"></i> <!--Delete-->
                                </a>
                    </div>`;
                }, "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order": [[4, "asc"]]
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