var dataTable;
$(document).ready(function ()
{
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/company/getall' },
        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'address', "width": "35%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'state', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                        <a href="/admin/company/upsert?id=${data}" class="btn btn-warning mx-2">Sửa</a>
                        <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger">Xóa</a>
                    </div >`
                },
                "width": "20%"
            }
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Xóa công ty này?',
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