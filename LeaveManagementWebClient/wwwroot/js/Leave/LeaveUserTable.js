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
                render: function (data, type, meta) {

                    let statusReq = '';
                    if (data == "Pending") {
                        statusReq += '<span class="badge rounded-pill bg-primary">' + data + '</span>';
                    } else if (data == "Rejected") {
                        statusReq = '<span class="badge rounded-pill bg-danger">' + data + '</span>';
                    } else {
                        statusReq = '<span class="badge rounded-pill bg-succes">' + data + '</span>';
                    }
                    return statusReq;
                }
            },
            {
                data: "note"
            }
        ]
    });

});