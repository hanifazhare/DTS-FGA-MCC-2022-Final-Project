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
                    let detailsBtn = `<button type="button" onclick="GetByIdDetail(${data})" class="btn btn-default btn-sm" data-toggle="modal" data-target="#detailsModal">Detail</button>`;
                    let deleteBtn = `<button type="button" onclick="GetByIdDelete(${data})" class="btn btn-default btn-sm" data-toggle="modal" data-target="#deleteModal">Delete</button>`;
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
    obj.name = $("#name").val();
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        contentType: "application/json",
        url: "https://localhost:44371/api/LeaveType/create",
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
            //$("#id")[0].value = result.data.id;
            //$("#name")[0].value = result.data.name;

            test = "";
            test += `<div asp-validation-summary="ModelOnly" class="text-danger"></div>
                            <div class="form-group" >
                                <label asp-for="id" class="control-label">Id</label>
                                <input asp-for="id" class="form-control" id="id" value="${result.data.id}" disabled/>
                                <span asp-validation-for="id" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <label asp-for="name" class="control-label">Leave Type</label>
                                <input asp-for="name" class="form-control" id="nameIn" value="${result.data.name}"/>
                                <span asp-validation-for="name" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <input type="submit" value="Edit" class="btn btn-primary" data-dismiss="modal" onclick="Update()" />
                            </div>`;
            $("#formEdit").html(test);
            console.log(result);
        })
        .fail((error) => {
            console.log(error);
        });
}

function Update() {
    event.preventDefault();
    var obj = new Object();
    obj.id = parseInt($("#id").val());
    obj.name = String($("#nameIn").val());
     
    console.log(obj);
    console.log($("#nameIn").val());

    $.ajax({
        contentType: "application/json",
        url: `https://localhost:44371/api/LeaveType/edit`,
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

function Delete(id) {
    $.ajax({
        url: 'https://localhost:44371/api/LeaveType/delete/'+id,
        type: 'DELETE',
    }).done((result) => {
        console.log(result);
        alert("Data berhasil diubah!");
        $('#leaveTypeTable').DataTable().ajax.reload();
    }).fail((error) => {
        console.log(error);
    })
}

function GetByIdDetail(data) {
    $.ajax({
        url: `https://localhost:44371/api/LeaveType/${data}`,
        type: "GET",
    })
        .done((result) => {
            //ngebuat kolom buat id tapi invisible
            //$("#id")[0].value = result.data.id;
            //$("#name")[0].value = result.data.name;

            test = "";
            test += `<div asp-validation-summary="ModelOnly" class="text-danger"></div>
                            <div class="form-group">
                                <label asp-for="id" class="control-label">Id</label>
                                <input asp-for="id" class="form-control" id="id" value="${result.data.id}" disabled/>
                                <span asp-validation-for="id" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <label asp-for="name" class="control-label">Leave Type</label>
                                <input asp-for="name" class="form-control" id="name" value="${result.data.name}" disabled/>
                                <span asp-validation-for="name" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>`;
            $("#formDetail").html(test);
            console.log(result);
        })
        .fail((error) => {
            console.log(error);
        });
}

function GetByIdDelete(data) {
    $.ajax({
        url: `https://localhost:44371/api/LeaveType/${data}`,
        type: "GET",
    })
        .done((result) => {
            //ngebuat kolom buat id tapi invisible
            //$("#id")[0].value = result.data.id;
            //$("#name")[0].value = result.data.name;

            test = "";
            test += `<div asp-validation-summary="ModelOnly" class="text-danger"></div>
                        <div class="form-group" hidden>
                            <label asp-for="id" class="control-label">Id</label>
                            <input asp-for="id" class="form-control" value="${result.data.id}" id="id" name="id" />
                            <span asp-validation-for="id" class="text-danger"></span>
                        </div>
                    <div class="form-group">
                        <div class="modal-body">Apa Anda yakin akan menghapus data ini?</div>
                            <div class="modal-footer">
                                <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                                <button class="btn btn-secondary" type="button" onclick="Delete(${result.data.id})" data-dismiss="modal" >Delete</button>
                            </div>
                    </div>`;
            $("#formDelete").html(test);
            console.log(result);
        })
        .fail((error) => {
            console.log(error);
        });
}