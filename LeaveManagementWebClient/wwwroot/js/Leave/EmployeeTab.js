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
                    let detailsBtn = `<button type="button" onclick="GetByIdDetail(${data})" class="btn btn-default btn-sm" data-toggle="modal" data-target="#detailFormModal">Details</button>`;
                    let deleteBtn = `<button type="button" onclick="GetByIdDelete(${data})" class="btn btn-default btn-sm" data-toggle="modal" data-target="#deleteModal">Delete</button>`;
                    return `${editBtn} | ${detailsBtn} | ${deleteBtn}`;
                }
            }
        ]
    });

});

const userId = parseInt($("#sessionUserId").val());
const departmentId = parseInt($("#sessionDepartmentId").val());

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
    obj.departmentTypeId = departmentId;
    obj.managerId = userId;
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
            test = "";
            test += `<div asp-validation-summary="ModelOnly" class="text-danger"></div>
                            <div class="form-group" hidden>
                                <label asp-for="id" class="control-label">Id</label>
                                <input asp-for="id" class="form-control" id="idEmp" name="idEmp" disabled value="${result.data.id}"/>
                                <span asp-validation-for="id" class="text-danger"></span>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label asp-for="firstname" class="control-label">First Name</label>
                                    <input asp-for="firstname" class="form-control" id="firstName" value="${result.data.firstName}"/>
                                    <span asp-validation-for="firstname" class="text-danger"></span>
                                </div>
                                <div class="col-sm-6">
                                    <label asp-for="lasttname" class="control-label">Last Name</label>
                                    <input asp-for="lasttname" class="form-control" id="lastName" value="${result.data.lastName}"/>
                                    <span asp-validation-for="lasttname" class="text-danger"></span>
                                </div>
                            </div>
                            <div class="form-group" hidden>
                                <label asp-for="genderTypeId" class="control-label">Gender</label>
                                <input asp-for="genderTypeId" class="form-control" id="genderId" value="${result.data.genderTypeId}"/>
                                <span asp-validation-for="email" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <label asp-for="email" class="control-label">Email</label>
                                <input asp-for="email" class="form-control" id="emailEmp" type="email" value="${result.data.email}"/>
                                <span asp-validation-for="email" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <label asp-for="phoneNumber" class="control-label">Phone Number</label>
                                <input asp-for="phoneNumber" class="form-control" id="phoneNumberEmp" value="${result.data.phoneNumber}"/>
                                <span asp-validation-for="phoneNumber" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <input type="submit" value="Edit" class="btn btn-primary" onclick="Update()" data-dismiss="modal" />
                            </div>`;
            $("#formEdit").html(test);
            //$("#genderTypeId")[0].value = result.data.genderTypeId;
            //$("#departmentId")[0].value = result.data.departmentTypeId;
            //selectElementDepartment('departmentId', result.data.departmentTypeId);
            //selectElementGender('genderTypeId', result.data.genderTypeId);
            console.log(result);
            console.log(userId);
            console.log(departmentId);
        })
        .fail((error) => {
            console.log(error);
        });
}

function selectElementDepartment(id, valueToSelect) {
    let element = document.getElementById(id);
    element.value = valueToSelect;
}

function selectElementGender(id, valueToSelect) {
    let element = document.getElementById(id);
    element.value = valueToSelect;
}

function GetByIdDetail(data) {
    $.ajax({
        url: `https://localhost:44371/api/Employee/${data}`,
        type: "GET",
    })
        .done((result) => {
            test = "";
            test += `<div asp-validation-summary="ModelOnly" class="text-danger"></div>
                            <div class="form-group" hidden>
                                <label asp-for="id" class="control-label">Id</label>
                                <input asp-for="id" class="form-control" id="id" name="id" disabled value="${result.data.id}" disabled/>
                                <span asp-validation-for="id" class="text-danger"></span>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label asp-for="firstname" class="control-label">First Name</label>
                                    <input asp-for="firstname" class="form-control" id="firstname" value="${result.data.firstName}" disabled/>
                                    <span asp-validation-for="firstname" class="text-danger"></span>
                                </div>
                                <div class="col-sm-6">
                                    <label asp-for="lasttname" class="control-label">Last Name</label>
                                    <input asp-for="lasttname" class="form-control" id="lastname" value="${result.data.lastName}" disabled/>
                                    <span asp-validation-for="lasttname" class="text-danger"></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label asp-for="genderTypeId" class="control-label">Gender</label>
                                <input asp-for="genderTypeId" class="form-control" id="genderTypeId" value="${result.data.genderType.name}" disabled/>
                                <span asp-validation-for="email" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <label asp-for="email" class="control-label">Email</label>
                                <input asp-for="email" class="form-control" id="email" type="email" value="${result.data.email}" disabled/>
                                <span asp-validation-for="email" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <label asp-for="phoneNumber" class="control-label">Phone Number</label>
                                <input asp-for="phoneNumber" class="form-control" id="phoneNumber" value="${result.data.phoneNumber}" disabled/>
                                <span asp-validation-for="phoneNumber" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <label asp-for="departmentId" class="control-label">Department</label>
                                <input asp-for="departmentId" class="form-control" id="departmentId" value="${result.data.departmentType.name}" disabled/>
                                <span asp-validation-for="departmentId" class="text-danger"></span>
                            </div>
                            <div class="form-group">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>`;
            $("#formDetail").html(test);
            //$("#genderTypeId")[0].value = result.data.genderTypeId;
            //$("#departmentId")[0].value = result.data.departmentTypeId;
            //selectElementDepartment('departmentId', result.data.departmentTypeId);
            //selectElementGender('genderTypeId', result.data.genderTypeId);
            console.log(result);
        })
        .fail((error) => {
            console.log(error);
        });
}

function Update() {
    event.preventDefault();
    var obj = new Object();
    obj.id = parseInt($("#idEmp").val());
    obj.firstName = $("#firstName").val();
    obj.lastName = $("#lastName").val();
    obj.genderTypeId = parseInt($("#genderId").val());
    obj.email = $("#emailEmp").val();
    obj.phoneNumber = $("#phoneNumberEmp").val();
    obj.departmentTypeId = departmentId;
    obj.managerId = userId;

    $.ajax({
        contentType: "application/json",
        url: `https://localhost:44371/api/Employee/edit`,
        type: "PUT",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Data berhasil diubah!");
        $('#employeeTable').DataTable().ajax.reload();

    }).fail((error) => {
        alert("Data gagal diubah!");
        console.log(error);
        console.log(parseInt($("#idEmp").val()));
    })
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
                                <button class="btn btn-secondary" type="button" onclick="Delete(${data})" data-dismiss="modal" >Delete</button>
                            </div>
                    </div>`;
            $("#formDelete").html(test);
            console.log(result);
        })
        .fail((error) => {
            console.log(error);
        });
}

function Delete(id) {
    $.ajax({
        url: 'https://localhost:44371/api/Employee/delete/' + id,
        type: 'DELETE',
    }).done((result) => {
        console.log(result);
        alert("Data berhasil diubah!");
        $('#employeeTable').DataTable().ajax.reload();
    }).fail((error) => {
        console.log(error);
    })
}