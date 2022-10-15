const userId = parseInt($("#sessionUserId").val());
const departmentId = parseInt($("#sessionDepartmentId").val());

$(document).ready(function () {

    $('#employeeTable').DataTable({

        ajax: {
            url: "https://localhost:44371/api/LeaveRequest/get-by-employee/" + userId,
            dataType: "JSON"
        },
        columns: [
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
                render: function (data, type, meta) {
                    let statusReq = '';
                    if (data.name == "Pending") {
                        statusReq = '<button type="button" class="btn btn-outline-primary btn-sm" disabled>' + data.name +'</button>';
                    } else if (data.name == "Rejected") {
                        statusReq = '<button type="button" class="btn btn-outline-danger btn-sm" disabled>' + data.name +'</button>';
                    } else {
                        statusReq = '<button type="button" class="btn btn-outline-success btn-sm" disabled>' + data.name +'</button>';
                    }
                    return statusReq  ;
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
            }
        ]
    });

});