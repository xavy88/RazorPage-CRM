var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("SEO")) {
        loadList("SEO");
    }
    else {
        if (url.includes("PPC")) {
            loadList("PPC");
        }
        else {
            if (url.includes("APP")) {
                loadList("APP");
            }
            else {
                if (url.includes("WEB")) {
                    loadList("WEB");
                }
                else {
                    if (url.includes("SALES")) {
                        loadList("SALES");
                    }
                    else {
                        if (url.includes("SM")) {
                            loadList("SM");
                        }
                        else {
                            if (url.includes("SALES")) {
                                loadList("SALES");
                            }
                            else {
                                loadList("");
                            }
                        }
                    }
                }
            }
        }
    }
});

function loadList(param) {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/taskassignmentlist?deptName=" + param,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "account.name", "width": "15%" },
            { "data": "task.name", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "dueDate", "width": "15%" },
            { "data": "completed", "width": "2%" },
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