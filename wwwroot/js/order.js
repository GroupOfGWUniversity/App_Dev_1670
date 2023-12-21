var dataTable;
$(document).ready(function () {
    loadDataTable();
}

function loadDataTable() {
        dataTable = $('#tblData').DataTable({
            "ajax": { url: '/seller/order/getall },
            "columns": [
                { data: 'id', "width": "5%" },
                { data: 'name', "width": "25%" },
                { data: 'phoneNumber', "width": "20%" },
                { data: 'applicationUser.email', "width": "20%" },
                { data: 'status', "width": "10%" },
                { data: 'total', "width": "10%" },
                {
                    data: 'id',
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                     <a href="/seller/order/details?orderId=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i></a>               
                    
                    </div>`
                    },
                    "width": "10%"
                }
            ]
        });
    }