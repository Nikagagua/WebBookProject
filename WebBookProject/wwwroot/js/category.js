$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/admin/category/GetAll'},
        "columns": [
            { data: 'id', width: '25%' },
            { data: 'name', width: '25%' },
            { data: 'displayOrder', width: '25%' },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                <a href="category/edit?id=${data}" class="btn btn-warning">
                                    <i class="fas fa-edit"></i> Edit
                                </a>
                                &nbsp;
                                <a href="category/delete?id=${data}" class="btn btn-danger">
                                    <i class="fas fa-trash-alt"></i> Delete
                                </a>
                            </div>`
                },
                width: '25%' },
        ],
        "order": [[2, 'asc']]
    });
}