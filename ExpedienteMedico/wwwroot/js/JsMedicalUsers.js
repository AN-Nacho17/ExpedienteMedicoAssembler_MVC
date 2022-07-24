var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Administration/User/getall"
        },
        "columns": [
            { "data": "userId", "width": "15%" },
            { "data": "completeName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="btn-group w-75">

                                <a href="/Administration/User/Edit?id=${data}"
                                   class="btn btn-primary mx-2"> 
							    <i class="bi bi-pencil-square"></i>Edit</a>

                                <a href="/Administration/User/Attend?id=${data}"
                                   class="btn btn-primary mx-2">
							    <i class="bi bi-clipboard2-pulse"></i></i>Attend</a>

                            </div
                            `;
                },
                "width": "15%"
            }
        ]
    });
}