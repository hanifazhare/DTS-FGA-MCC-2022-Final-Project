const userId = parseInt($("#sessionUserId").val());

$.ajax({
    url: 'https://localhost:44371/api/Employee/' + userId
}).done((result) => {
    test = "";
    test += `<div class="form-group">
                <label name="Fullname" class="control-label">Fullname</label>
                <input name="Fullname" class="form-control" id="fullName" disabled value="${result.data.firstName} ${result.data.lastName}"/>
            </div>
            <div class="form-group">
                <label name="Gender" class="control-label">Gender</label>
                <input name="Gender" class="form-control" id="gender" disabled value="${result.data.genderType.name}"/>
            </div>
            <div class="form-group">
                <label name="Email" class="control-label">Email</label>
                <input name="Email" class="form-control" id="email" disabled value="${result.data.email}"/>
            </div>
            <div class="form-group">
                <label name="phoneNumber" class="control-label">Phone Number</label>
                <input name="phoneNumber" class="form-control" id="phoneNumber" disabled value="${result.data.phoneNumber}"/>
            </div>
            <div class="form-group">
                <label name="Department" class="control-label">Department</label>
                <input name="Department" class="form-control" id="department" disabled value="${result.data.departmentType.name}"/>
            </div>
            <div class="text-center">
                <a class="btn btn-primary btn-user btn-block" href="https://localhost:44323/Dashboard/Account/ChangePass">Change Password</a>
            </div>`;
    $("#formAccount").html(test);
    console.log(result);
}).fail((error) => {
    console.log(error);
}); 

//$.ajax({
//    url: "/mywebservice.asmx",
//    dataType: "json",
//    success: function (data) {
//        var sessionId = data.sessionId; // This would be determined by your server-side implementation
//        // do something with the sessionId...
//        console.log(sessionId);
//    }
//});