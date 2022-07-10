﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Administration/Suffering/getall"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="btn-group w-75">

                                <a href="/Administration/Suffering/Edit?id=${data}"
                                   class="btn btn-primary mx-2"> 
							    <i class="bi bi-pencil-square"></i>Edit</a>

                                <a href="/Administration/Suffering/Delete?id=${data}"
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