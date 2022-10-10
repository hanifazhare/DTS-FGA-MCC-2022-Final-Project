$(document).ready(function () {
    $('.input-daterange').datepicker({
        format: 'dd-mm-yyyy',
        autoclose: true,
        calendarWeeks: true,
        clearBtn: true,
        disableTouchKeyboard: true
    });
});

var myLink = document.querySelectorAll('a[href="#"]');
myLink.forEach(function (link) {
    link.addEventListener('click', function (e) {
        e.preventDefault();
    });
});