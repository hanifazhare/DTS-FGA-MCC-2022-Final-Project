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
                    if (data.name == "Pending") {
                        statusReq = '<span class="badge rounded-pill bg-primary">' + data.name + '</span>';
                    } else if (data.name == "Rejected") {
                        statusReq = '<span class="badge rounded-pill bg-danger">' + data.name + '</span>';
                    } else {
                        statusReq = '<span class="badge rounded-pill bg-succes">' + data.name + '</span>';
                    }
                    return statusReq  ;
                }
            },
            {
                data: "note"
            }
        ]
    });

});