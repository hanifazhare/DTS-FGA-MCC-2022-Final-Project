let startDate;
let endDate;

const userId = parseInt($("#sessionUserId").val());
var nowDate = new Date();
var today = new Date(nowDate.getFullYear(), nowDate.getMonth(), nowDate.getDate(), 0, 0, 0, 0);

$(document).ready(function () {
    $('.input-daterange').datepicker({
        format: 'dd-mm-yyyy',
        autoclose: true,
        calendarWeeks : true,
        clearBtn: true,
        disableTouchKeyboard: true,
        daysOfWeekDisabled: '0,6',
        startDate: today
    });
});

var myLink = document.querySelectorAll('a[href="#"]');
myLink.forEach(function(link){
    link.addEventListener('click', function(e) {
        e.preventDefault();
    });
});

$("#endDate").on('change keyup paste', function () {
    startDate = $('#startDate').datepicker('getDate');
    endDate = $('#endDate').datepicker('getDate');

    console.log(startDate);
    console.log(endDate);

    if (startDate < endDate || startDate == endDate) {
        var days = (endDate - startDate) / 1000 / 60 / 60 / 24;

        var Weeks = Math.round(days) / 7;

        var totalWeekends = Math.round(Weeks) * 2;

        var puredays = Math.round(days) - totalWeekends;

        //$('#days').text(Math.round(puredays) + "Working Days");
        console.log(Math.round(puredays) + 1);
        $("#requestedDays")[0].value = Math.round(puredays) + 1;
    }
});

function Insert(event) {
    event.preventDefault();

    console.log(startDate);
    console.log(endDate);

    const cvStartDate = new Date(startDate);
    const cvEndDate = new Date(endDate);

    // Add a day
    cvStartDate.setDate(cvStartDate.getDate() + 1);
    cvEndDate.setDate(cvEndDate.getDate() + 1);

    console.log(cvStartDate);
    console.log(cvEndDate);

    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.id = 0;
    obj.leaveTypeId = parseInt($("#leaveType").val());
    obj.userId = parseInt(userId);
    obj.requestedDays = parseInt($("#requestedDays").val());
    obj.startDate = cvStartDate;
    obj.endDate = cvEndDate;
    obj.reason = $("#reason").val();
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        contentType: "application/json",
        url: "https://localhost:44371/api/LeaveRequest/create",
        type: "POST",
        data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //buat alert pemberitahuan jika success
        Swal.fire(
            'Success!',
            'Data has been added',
            'success'
        )
    }).fail((error) => {
        Swal.fire(
            'Failed!',
            'Data has not been added',
            'error'
        )
        console.log(error);
    })
};

$.ajax({
    url: 'https://localhost:44371/api/Employee/' + userId
}).done((result) => {
    console.log(result);
    getLeaveTypeByGender(result.data.genderTypeId);
}).fail((error) => {
    console.log(error);
}); 

function getLeaveTypeByGender(id) {
    $.ajax({
        url: 'https://localhost:44371/api/LeaveType/get-by-gender/' + id
    }).done((result) => {
        console.log(result);
        test = "";
        $.each(result.data, function (key, val) {
            test += `<option value="${val.id}">${val.name}</option>`;
        })
        console.log(test);
        $("#leaveType").html(test);
    }).fail((error) => {
        console.log(error);
    });
}