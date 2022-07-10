var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblDataMed').DataTable({
        "ajax": {
            "url": "/Medical/Medicine/getall"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="btn-group w-75">

                                <a href="/Medical/Medicine/Edit?id=${data}"
                                   class="btn btn-primary mx-2"> 
							    <i class="bi bi-pencil-square"></i>Edit</a>

                                <a href="/Medical/Medicine/Delete?id=${data}"
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