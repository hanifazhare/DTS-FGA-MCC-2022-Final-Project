$(document).ready(function () {

    $('#employeeTable').DataTable({

        ajax: {
            url: "https://localhost:44371/api/LeaveRequest/get-by-manager/" + userId + "/" + departmentId,
            dataType: "JSON"
        },
        columns: [
            {
                data: "firstName",
                render: function (data, type, row) {

                    return data + ' ' + row.lastName;
                },
                targets: 0
            },
            {
                data: 'leaveType',
                render: function (data, type, row) {
                    return data.name;
                }
            },
            {
                data: "startDate"
            },
            {
                data: "endDate"
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
                    if (data == "Pending") {
                        statusReq = `<button type="button" onclick="GetDataApprove(${row.id})" class="btn btn-primary btn-sm" >Pending</button>`;
                    } else if (data == "Rejected") {
                        statusReq = '<span class="badge rounded-pill bg-danger">' + data + '</span>';
                    } else {
                        statusReq = '<span class="badge rounded-pill bg-succes">' + data + '</span>';
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
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
            //ini ngambil value dari tiap inputan di form nya
            obj.id = result.data.id;
            obj.leaveTypeId = result.data.leaveTypeId;
            obj.statusTypeId = 2;
            obj.userId = result.data.userId;
            obj.requestDays = result.data.userId;
            obj.startDate = result.data.startDate;
            obj.endDate = result.data.endDate;
            obj.reason = result.data.reason;
            ApproveFunction(obj);
        } else if (result.isDenied) {
            var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
            //ini ngambil value dari tiap inputan di form nya
            obj.id = result.data.id;
            obj.leaveTypeId = result.data.leaveTypeId;
            obj.statusTypeId = 2;
            obj.userId = result.data.userId;
            obj.requestDays = result.data.userId;
            obj.startDate = result.data.startDate;
            obj.endDate = result.data.endDate;
            obj.reason = result.data.reason;
            ApproveFunction(obj);
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
            'Data has not been deleted',
            'error'
        )
        console.log(error);
    })
}

function ApproveFunction2(obj) {
    var objek = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    objek.id = obj.id;
    objek.leaveTypeId = obj.leaveTypeId;
    objek.statuTypeId = obj.statusTypeId;
    objek.userId = obj.data.userId;
    objek.requestedDays = obj.requestedDays;
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
                $('#leaveTypeTable').DataTable().ajax.reload();

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