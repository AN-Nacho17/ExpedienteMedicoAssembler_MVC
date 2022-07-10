var dataTable;

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
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="btn-group w-75">

                                <a href="/Medical/Suffering/Edit?id=${data}"
                                   class="btn btn-primary mx-2"> 
							    <i class="bi bi-pencil-square"></i>Edit</a>

                                <a href="/Medical/Suffering/Delete?id=${data}"
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