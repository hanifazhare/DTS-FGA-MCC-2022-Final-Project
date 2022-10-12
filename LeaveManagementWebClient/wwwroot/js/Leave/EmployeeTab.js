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
                    let detailsBtn = `<button type="button" onclick="GetById(${data})" class="btn btn-default btn-sm" data-toggle="modal" data-target="#editFormModal">Details</button>`;
                    let deleteBtn = `<a href='/Employee/delete/${data}' class="btn btn-default btn-sm">Delete</a>`;
                    return `${editBtn} | ${detailsBtn} | ${deleteBtn}`;
                }
            }
        ]
    });
});

const userId = '@Session["UserId"]';
const managerId = '@Session["ManagerId"]';

function Insert(event) {
    event.preventDefault();
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.id = 0;
    obj.firstName = $("#firstname").val();
    obj.lastName = $("#lastname").val();
    obj.genderTypeId = parseInt($("#genderTypeId").val());
    obj.email = $("#email").val();
    obj.phoneNumber = $("#phoneNumber").val();
    obj.departmentTypeId = 2;
    obj.managerId = 2;
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        contentType: "application/json",
        url: "https://localhost:44371/api/Employee/create",
        type: "POST",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Karyawan berhasil ditambah!");
        $('#employeeTable').DataTable().ajax.reload();

    }).fail((error) => {
        alert("Data gagal ditambahkan");
        console.log(error);
    })
};

function GetById(data) {
    $.ajax({
        url: `https://localhost:44371/api/Employee/${data}`,
        type: "GET",
    })
        .done((result) => {
            console.log(result);
            //ngebuat kolom buat id tapi invisible
            $("#firstname")[0].value = result.data.firstName;
            $("#lastname")[0].value = result.data.lastName;
            $("#genderTypeId")[0].value = result.data.genderTypeId;
            $("#email")[0].value = result.data.email;
            $("#phoneNumber")[0].value = result.data.phoneNumber;
            $("#departmentId")[0].value = result.data.departmentTypeId;
            console.log(result);
        })
        .fail((error) => {
            console.log(error);
        });
}

function Update() {
    event.preventDefault();
    var obj = new Object();
    obj.firstName = $("#firstname").val();
    obj.lastName = $("#lastname").val();
    obj.genderTypeId = parseInt($("#genderTypeId").val());
    obj.email = $("#email").val();
    obj.phoneNumber = $("#phoneNumber").val();
    obj.departmentId = managerId;
    obj.managerId = userId;

    $.ajax({
        contentType: "application/json",
        url: `https://localhost:44371/api/Employee/${obj.id}`,
        type: "PUT",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Data berhasil diubah!");
        $('#employeeTable').DataTable().ajax.reload();

    }).fail((error) => {
        alert("Data gagal diubah!");
        console.log(error);
    })
}