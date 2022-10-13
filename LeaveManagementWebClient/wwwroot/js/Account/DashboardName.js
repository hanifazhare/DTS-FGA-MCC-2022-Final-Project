const userIdDash = parseInt($("#sessionUserId").val());

$.ajax({
    url: 'https://localhost:44371/api/Employee/' + userIdDash
}).done((result) => {
    $("#dashboardName")[0].innerHTML = result.data.firstName + " " + result.data.lastName;
    console.log(result);
}).fail((error) => {
    console.log(error);
}); 

function selectElementGender(id, valueToSelect) {
    let element = document.getElementById(id);
    element.value = valueToSelect;
}