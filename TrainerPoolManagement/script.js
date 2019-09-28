function validate() {
    var firstName = document.getElementById('txtfirstname').value;
    if (firstName == "") {
        alert("firstName is required");
        document.getElementById("txtfirstname").style.borderColor = "#FF0000";
        return false;
    }
    var lastName = document.getElementById('txtlastname').value;
    if (lastName == "") {
        alert("lastName is required");
        document.getElementById("txtlastname").style.borderColor = "#FF0000";
        return false;
    }
    var age = document.getElementById('txtage').value;
    if (age == "") {
        alert("age is required");
        document.getElementById("txtage").style.borderColor = "#FF0000";
        return false;
    }
    var gender1 = document.getElementById("radiogender");

    var gender2 = document.getElementById("radiosgender");
    if (gender1.checked == false && gender2.checked == false) {
        alert("gender is required");
        document.getElementById("radiogender").style.borderColor = "#FF0000";
        document.getElementById("radiosgender").style.borderColor = "#FF0000";
        return false;
    }
    var contact = document.getElementById('txtcontact').value;
    if (contact == "") {
        alert("Number is required");
        document.getElementById("txtcontact").style.borderColor = "#FF0000";
        return false;
    }
    var userId = document.getElementById('txtuserid').value;
    if (userId == "") {
        alert("userId is required");
        document.getElementById("txtuserid").style.borderColor = "#FF0000";
        return false;
    }

    var usertype = document.getElementById('usertype').value;
    if (usertype == "Usertype") {
        alert("usertype is required");
        document.getElementById("usertype").style.borderColor = "#FF0000";
        return false;
    }
    var emailid = document.getElementById('emailid').value;
    if (emailid == "") {
        alert("Email is required");
        document.getElementById("emailid").style.borderColor = "#FF0000";
        return false;
    }
    var password = document.getElementById('txtpassword').value;
    if (password == "") {
        alert("password is required");
        document.getElementById("txtpassword").style.borderColor = "#FF0000";
        return false;
    }
    var confirmpassword = document.getElementById('confirm').value;
    if (confirmpassword == "") {
        alert("password is required");
        document.getElementById("confirm").style.borderColor = "#FF0000";
        return false;
    }
    if (password != confirmpassword) {
        alert("password should match");
        document.getElementById("confirm").style.borderColor = "#FF0000";
        return false;
    }
    return true;
}



function availability() {
    var radioAvailable = document.getElementById("available");
    var radioBusy = document.getElementById("busy");
    var startDate = document.getElementById('txtStartDate').value
    var endDate = document.getElementById('txtEndDate').value;

    if (startDate == "") {
        alert("Enter Start Date");
        return false;
    }
    else if (endDate == "") {
        alert("Enter End Date");
        return false;
    }
    else if (radioAvailable.checked == false && radioBusy.checked == false) {
        alert("Enter availability");
        return false;
    }
    return true;

}
function validateEdit() {
    var firstName = document.getElementById('TextBox1').value;
    if (firstName == "") {
        alert("firstName is required");
        document.getElementById("TextBox1").style.borderColor = "#FF0000";
        return false;
    }
    var lastName = document.getElementById('TextBox2').value;
    if (lastName == "") {
        alert("lastName is required");
        document.getElementById("TextBox2").style.borderColor = "#FF0000";
        return false;
    }
    var age = document.getElementById('TextBox4').value;
    if (age == "") {
        alert("age is required");
        document.getElementById("TextBox4").style.borderColor = "#FF0000";
        return false;
    }
    

    var gender = document.getElementById('TextBox3').value;
    if (gender == "") {
        alert("Gender is required");
        document.getElementById("TextBox3").style.borderColor = "#FF0000";
        return false;
    }
    var contact = document.getElementById('TextBox5').value;
    if (contact == "") {
        alert("Number is required");
        document.getElementById("TextBox5").style.borderColor = "#FF0000";
        return false;
    }
   
    var emailid = document.getElementById('TextBox6').value;
    if (emailid == "") {
        alert("Email is required");
        document.getElementById("TextBox6").style.borderColor = "#FF0000";
        return false;
    }
    
    
    
    return true;
}

//function newRequest() {
//    var java = document.getElementById("RadioButtonList1");
//    //var dotnet = document.getElementById("radioDotnet");
//    //var mainFrame = document.getElementById("radioMainFrame");
//    //var python = document.getElementById("radioPython");

//    //&& dotnet.checked == false && mainFrame.checked == false && python.checked == false
   
//}

function newrequest()
{
    var radiButtonList = document.getElementById('RadioButtonList1');

    var rb = document.getElementById('RadioButtonList1');
    var radio = rb.getElementsByTagName("input");
    var isChecked = false;
    for (var i = 0; i < radio.length; i++) {
        if (radio[i].checked) {
            isChecked = true;
            break;
        }
    }
    


   
    

    var startDate = document.getElementById('dateStart').value
    var endDate = document.getElementById('dateEnd').value;
    var venue = document.getElementById('txtVenue').value;
    //if (radiButtonList.checked == false) {
    //    alert("Enter Skill");
    //    return false;
    //}
    if (!isChecked) {
        alert("Please select an option!");
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

