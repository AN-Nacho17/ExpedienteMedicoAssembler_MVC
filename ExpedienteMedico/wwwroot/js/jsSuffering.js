﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblDataSuf').DataTable({
        "ajax": {
            "url": "/Medical/Suffering/getall"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "isSuspended", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="btn-group w-75">

                                <a href="/Medical/Suffering/Edit?id=${data}"
                                   class="btn btn-primary mx-2"> 
							    <i class="bi bi-pencil-square"></i>Edit</a>

                                <a href="/Medical/Suffering/Suspend?id=${data}"
                                   class="btn btn-primary mx-2">
							    <i class="bi bi-pencil-square"></i>Suspend or activate</a>

                                <a onClick=Delete('/Medical/Suffering/Delete/${data}')
                                   class="btn btn-primary mx-2">
							    <i class="bi bi-pencil-square"></i>Delete</a>
                            </div>
                            `;
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(_url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: _url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
