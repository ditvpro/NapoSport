var dataTable;
$(document).ready(function ()
{
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "15%" },
            { data: 'company.name', "width": "25%" },
            { data: 'role', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                        <a href="/admin/user/upsert?id=${data}" class="btn btn-warning mx-2">Sửa</a>
                    </div >`
                },
                "width": "20%"
            }
        ]
    });
}