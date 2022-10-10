$(document).ready(function () {
    $('#employeeTable').DataTable({

        ajax: {
            url: "https://localhost:44371/api/Employee/",
            dataType: "JSON"
        },
        columns: [
            {
                data: "firstName",
                render: function (data, type, row) {

                    return data+' '+ row.lastName;
                },
                targets : 0
            },
            {
                data: 'genderType',
                render: function (data, type, row) {
                    return data.name;
                }
            },
            {
                data: "email"
            },
            {
                data: "phoneNumber"
            },
            {
                data: "departmentType",
                render: function (data, type, row) {
                    return data.name;
                }
            },
            {
                data: 'id',
                render: function (data, type, meta) {

                    let editBtn = `<button type="button" onclick="GetById(${data})" class="btn btn-default btn-sm" data-toggle="modal" data-target="#editFormModal">Edit</button>`;
                    let detailsBtn = `<a href='/products/details/${data}' class="btn btn-default btn-sm">Details</a>`;
                    let deleteBtn = `<a href='/products/delete/${data}' class="btn btn-default btn-sm">Delete</a>`;
                    return `${editBtn} | ${detailsBtn} | ${deleteBtn}`;
                }
            }
        ]
    });
});

function Insert(event) {
    event.preventDefault();
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.id = 0;
    obj.name = $("#productName").val();
    obj.stock = parseInt($("#productStock").val());
    obj.price = parseInt($("#productPrice").val());
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        contentType: "application/json",
        url: "https://localhost:44371/api/Employee/",
        type: "POST",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Karyawan berhasil ditambah!");
        $('#productsTable').DataTable().ajax.reload();

    }).fail((error) => {
        console.log(error);
    })
};