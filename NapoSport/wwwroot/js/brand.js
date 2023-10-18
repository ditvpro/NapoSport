var dataTable;
$(document).ready(function ()
{
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/brand/getall' },
        "columns": [
            { "data": 'name', "width": "20%" },
            { "data": 'description', "width": "40%" },
            { "data": 'website', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                        <a href="/admin/brand/upsert?id=${data}" class="btn btn-warning mx-2">Sửa</a>
                        <a onClick=Delete('/admin/brand/delete/${data}') class="btn btn-danger">Xóa</a>
                    </div >`
                },
                "width": "20%"
            }
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Xóa thương hiệu này?',
        text: "Sau khi xóa sẽ không thể phục hồi!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#ff2d2d',
        cancelButtonColor: '#adaead',
        confirmButtonText: 'Xóa vĩnh viễn'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Xóa thành công!',
                /*'Your file has been deleted.',*/
            ),
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    success: function (data) {
                        dataTable.ajax.reload();
                    }
                })
        }
    })
}