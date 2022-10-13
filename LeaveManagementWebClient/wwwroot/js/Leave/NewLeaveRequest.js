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

$("#endDate").on('change keyup paste', function () {
    var start = $('#startDate').datepicker('getDate');
    var end = $('#endDate').datepicker('getDate');

    console.log(start);
    console.log(end);

    if (start < end) {
        var days = (end - start) / 1000 / 60 / 60 / 24;

        var Weeks = Math.round(days) / 7;

        var totalWeekends = Math.round(Weeks) * 2;

        var puredays = Math.round(days) - totalWeekends;

        //$('#days').text(Math.round(puredays) + "Working Days");
        console.log(Math.round(puredays) + 1);
        $("#requestedDays")[0].value = Math.round(puredays) + 1;
    }
});