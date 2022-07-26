var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblDataSpe').DataTable({
        "ajax": {
            "url": "/Administration/Specialty/getall"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="btn-group w-55">

                                <a href="/Administration/Specialty/Edit?id=${data}"
                                   class="btn btn-primary mx-4"> 
							    <i class="bi bi-pencil-circle"></i>Edit</a>

                                <a href="/Administration/Specialty/Delete?id=${data}"
                                   class="btn btn-primary mx-4">
							    <i class="bi bi-pencil-square"></i>Delete</a>
                            </div>
                            `;
                },
                "width": "15%"
            }
        ]
    });
}