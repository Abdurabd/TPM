
function newrequest() {
    var radiButtonList = document.getElementById('RadioButtonList1');
    var startDate = document.getElementById('dateStart').value
    var endDate = document.getElementById('dateEnd').value;
    var venue = document.getElementById('txtVenue').value;
    if (radiButtonList.checked == false) {
        alert("Enter Skill");
        return false;
    }
     else if (startDate == "") {
        alert("Enter Start Date");
        return false;
    }
    else if (endDate == "") {
        alert("Enter End Date");
        return false;
    }
    else if (venue == "") {
        alert("Enter Venue");
        return false;
    }
    return true;
}