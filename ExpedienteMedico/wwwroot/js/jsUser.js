var dataTable;

var lockButton = `<a onClick=Banned('/Administration/User/Banned/${data}') class="btn btn-danger mx - 2">< i class="bi bi-lock" ></i > Lock</a >`;
var unlockButton = `<a onClick=Banned('/Administration/User/Banned/${data}') class="btn btn-danger mx - 2">< i class="bi bi-lock" ></i > Unlock</a >`;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Administration/User/getall"},
        "columns": [
            { "data": "userId", "width": "15%" },
            { "data": "completeName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    var string = '';
                    if (data.LockoutEnabled) {
                        string = lockButton;
                    } else {
                        string = unlockButton;
                    }
                    return `
                            <div class="btn-group w-75">

                                <a href="/Administration/User/Edit?id=${data}"
                                   class="btn btn-primary mx-2"> 
							    <i class="bi bi-pencil-square"></i>Edit</a>
                            </div>
                            `;
                },
                "width": "15%"
            }
        ]
    });
}

function Banned(_url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, banned it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: _url,
                type: "POST",
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
