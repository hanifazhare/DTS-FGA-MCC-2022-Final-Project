const userId = '@Session["UserId"]';
var sessionValue = '<%=Session("UserId")%>'

$.ajax({
    url: 'https://localhost:44371/api/Employee/${sessionValue}'
}).done((result) => {
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