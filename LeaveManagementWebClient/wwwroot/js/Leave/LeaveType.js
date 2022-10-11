$(document).ready(function () {
    $('#leaveTypeTable').DataTable({

        ajax: {
            url: "https://localhost:44371/api/LeaveType/",
            dataType: "JSON"
        },
        columns: [
            {
                data: "name"
            },
            {
                data: 'id',
                render: function (data, type, meta) {

                    let editBtn = `<button type="button" onclick="GetById(${data})" class="btn btn-default btn-sm" data-toggle="modal" data-target="#editFormModal">Edit</button>`;
                    let detailsBtn = `<a href='/LeaveType/details/${data}' class="btn btn-default btn-sm">Details</a>`;
                    let deleteBtn = `<a href='/LeaveType/delete/${data}' class="btn btn-default btn-sm">Delete</a>`;
                    return `${editBtn} | ${detailsBtn} | ${deleteBtn}`;
                }
            }
        ]
    });
});

const userId = '@Session["UserId"]';

function Insert(event) {
    event.preventDefault();
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.id = 0;
    obj.name = $("#name").val();
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        contentType: "application/json",
        url: "https://localhost:44371/api/LeaveType/",
        type: "POST",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Data berhasil ditambah!");
        $('#leaveTypeTable').DataTable().ajax.reload();

    }).fail((error) => {
        alert("Data gagal ditambahkan");
        console.log(error);
    })
};

function GetById(data) {
    $.ajax({
        url: `https://localhost:44371/api/LeaveType/${data}`,
        type: "GET",
    })
        .done((result) => {
            //ngebuat kolom buat id tapi invisible
            $("#name")[0].value = result.data.name;
        })
        .fail((error) => {
            console.log(error);
        });
}

function Update() {
    event.preventDefault();
    var obj = new Object();
    obj.name = $("#name").val();

    $.ajax({
        contentType: "application/json",
        url: `https://localhost:44371/api/LeaveType/${obj.id}`,
        type: "PUT",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Data berhasil diubah!");
        $('#leaveTypeTable').DataTable().ajax.reload();

    }).fail((error) => {
        alert("Data gagal diubah!");
        console.log(error);
    })
}