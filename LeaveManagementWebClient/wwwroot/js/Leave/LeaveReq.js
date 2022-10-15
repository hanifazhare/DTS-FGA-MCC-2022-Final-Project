﻿$(document).ready(function () {

    $('#leaveTable').DataTable({

        ajax: {
            url: "https://localhost:44371/api/LeaveRequest/get-by-manager/" + userId + "/" + departmentId,
            dataType: "JSON"
        },
        columns: [
            {
                data: 'user',
                render: function (data, type, row) {
                    return data.employee.firstName + ' ' + data.employee.lastName;
                }
            },
            {
                data: 'leaveType',
                render: function (data, type, row) {
                    return data.name;
                }
            },
            {
                data: "startDate",
                render: function (data, type, row) {
                    const date = new Date(data);
                    const formatDate = date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear();
                    return formatDate;
                }
            },
            {
                data: "endDate",
                render: function (data, type, row) {
                    const date = new Date(data);
                    const formatDate = date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear();
                    return formatDate;
                }
            },
            {
                data: "requestedDays"
            },
            {
                data: "reason"
            },
            {
                data: 'leaveStatusType',
                render: function (data, type, row) {
                    let statusReq = '';
                    if (data.name == "Pending") {
                        statusReq = '<button type="button" class="btn btn-outline-primary btn-sm" disabled>' + data.name + '</button>';
                    } else if (data.name == "Rejected") {
                        statusReq = '<button type="button" class="btn btn-outline-danger btn-sm" disabled>' + data.name + '</button>';
                    } else {
                        statusReq = '<button type="button" class="btn btn-outline-success btn-sm" disabled>' + data.name + '</button>';
                    }
                    return `${statusReq}`;
                }
            },
            {
                data: "note",
                render: function (data, type, meta) {
                    let content = '';
                    if (data == null) {
                        content = '<p>-</p>';
                    } else {
                        content = data;
                    }
                    return content;
                }
            },
            {
                data: 'leaveStatusType',
                render: function (data, type, row) {
                    let statusReq = '';
                    if (data.name == "Pending") {
                        statusReq = `<button type="button" class="btn btn-primary btn-sm" onclick="GetDataApprove(${row.id})" >Approve</button>`;
                    } else {
                        statusReq = '<button type="button" class="btn btn-light btn-sm" disabled>None</button>';
                    }
                    return `${statusReq}`;
                }
            }
        ]
    });

});

const userId = parseInt($("#sessionUserId").val());
const departmentId = parseInt($("#sessionDepartmentId").val());


function ApproveFunction(result) {
    Swal.fire({
        title: 'Approve leave request',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Yes',
        denyButtonText: `No`,
    }).then((answer) => {
        /* Read more about isConfirmed, isDenied below */
        if (answer.isConfirmed) {
            var obj = new Object();
            console.log(result);//sesuaikan sendiri nama objectnya dan beserta isinya
            //ini ngambil value dari tiap inputan di form nya
            obj.id = result.data.id;
            obj.leaveTypeId = result.data.leaveTypeId;
            obj.statusTypeId = 2;
            obj.userId = result.data.userId;
            obj.employeeId = result.data.employeeId;
            obj.requestedDays = result.data.requestedDays;
            obj.startDate = result.data.startDate;
            obj.endDate = result.data.endDate;
            obj.reason = result.data.reason;
            
            ApproveFunction2(obj);
        } else if (answer.isDenied) {
            var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
            //ini ngambil value dari tiap inputan di form nya
            obj.id = result.data.id;
            obj.leaveTypeId = result.data.leaveTypeId;
            obj.statusTypeId = 3;
            obj.userId = result.data.userId;
            obj.employeeId = result.data.employeeId;
            obj.requestedDays = result.data.requestedDays;
            obj.startDate = result.data.startDate;
            obj.endDate = result.data.endDate;
            obj.reason = result.data.reason;
            ApproveFunction2(obj);
        }
    })
}

function GetDataApprove(id) {
    $.ajax({
        url: 'https://localhost:44371/api/LeaveRequest/' + id,
        type: 'GET',
    }).done((result) => {
        console.log(result);
        ApproveFunction(result);
    }).fail((error) => {
        Swal.fire(
            'Failed!',
            'Something went wrong',
            'error'
        )
        console.log(error);
    })
}

function ApproveFunction2(obj) {
    var objek = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    objek.id = parseInt(obj.id);
    objek.leaveTypeId = parseInt(obj.leaveTypeId);
    objek.leaveStatusTypeId = parseInt(obj.statusTypeId);
    objek.userId = parseInt(obj.userId);
    objek.employeeId = parseInt(obj.employeeId);
    objek.requestedDays = parseInt(obj.requestedDays);
    objek.startDate = obj.startDate;
    objek.endDate = obj.endDate;
    objek.reason = obj.reason;
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    Swal.fire({
        title: 'Note',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Ok',
        showLoaderOnConfirm: true,
        preConfirm: (login) => {
            objek.note = login;
            console.log(objek);
            $.ajax({
                contentType: "application/json",
                url: `https://localhost:44371/api/LeaveRequest/edit`,
                type: "PUT",
                data: JSON.stringify(objek) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
            }).done((result) => {
                //buat alert pemberitahuan jika success
                Swal.fire(
                    'Success!',
                    'Data has been changed',
                    'success'
                )
                $('#leaveTable').DataTable().ajax.reload();

            }).fail((error) => {
                Swal.fire(
                    'Failed!',
                    'Data has not been changed',
                    'error'
                )
                console.log(error);
            })

        }
    }
    )

}