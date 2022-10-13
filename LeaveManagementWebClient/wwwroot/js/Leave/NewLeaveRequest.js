$(document).ready(function(){
    $('.input-daterange').datepicker({
        format: 'dd-mm-yyyy',
        autoclose: true,
        calendarWeeks : true,
        clearBtn: true,
        disableTouchKeyboard: true,
        daysOfWeekDisabled: '0,6'
    });
});

var myLink = document.querySelectorAll('a[href="#"]');
myLink.forEach(function(link){
    link.addEventListener('click', function(e) {
        e.preventDefault();
    });
});

//const startDate = document.querySelector('#startDate').value;
//const endDate = $("#endDate").val();

//console.log(startDate);
//console.log(endDate);

function getBusinessDateCount(startDate, endDate) {
    var elapsed, daysBeforeFirstSaturday, daysAfterLastSunday;
    var ifThen = function (a, b, c) {
        return a == b ? c : a;
    };

    elapsed = endDate - startDate;
    elapsed /= 86400000;

    daysBeforeFirstSunday = (7 - startDate.getDay()) % 7;
    daysAfterLastSunday = endDate.getDay();

    elapsed -= (daysBeforeFirstSunday + daysAfterLastSunday);
    elapsed = (elapsed / 7) * 5;
    elapsed += ifThen(daysBeforeFirstSunday - 1, -1, 0) + ifThen(daysAfterLastSunday, 6, 5);

    return Math.ceil(elapsed);
}

let startDate;
let endDate;

$("#endDate").on('change keyup paste', function () {
    startDate = $('#startDate').datepicker('getDate');
    endDate = $('#endDate').datepicker('getDate');

    console.log(startDate);
    console.log(endDate);

    if (startDate < endDate) {
        var days = (endDate - startDate) / 1000 / 60 / 60 / 24;

        var Weeks = Math.round(days) / 7;

        var totalWeekends = Math.round(Weeks) * 2;

        var puredays = Math.round(days) - totalWeekends;

        //$('#days').text(Math.round(puredays) + "Working Days");
        console.log(Math.round(puredays) + 1);
        $("#requestedDays")[0].value = Math.round(puredays) + 1;
    }
});

const userId = parseInt($("#sessionUserId").val());

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