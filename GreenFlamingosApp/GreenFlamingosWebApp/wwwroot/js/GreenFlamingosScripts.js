function GetDynamicTextbox(value) {
    return '<div><input type="text" name="Preparation"/> <input type="button" style="width:10%; background-color:red; height:38px; margin-left:0px; border: 1px solid #ced4da; border-radius: 0.25rem;" onclick="RemoveTextBox(this)" value="-" /></div>';
}
function AddTextBox() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox("");
    document.getElementById("divCont").appendChild(div);
}
function RemoveTextBox(div) {
    document.getElementById("divCont").removeChild(div.parentNode.parentNode);
}

function GetDynamicTextbox1(value) {
    return '<div><input type="text" name="Ingredients"/> <input type="button" style="width:10%; background-color:red; height:38px; margin-left:0px; border: 1px solid #ced4da; border-radius: 0.25rem;" onclick="RemoveTextBox1(this)" value="-" /></div>';
}
function AddTextBox1() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox1("");
    document.getElementById("divCont1").appendChild(div);
}
function RemoveTextBox1(div) {
    document.getElementById("divCont1").removeChild(div.parentNode.parentNode);
}
// Rating Initialization
$(document).ready(function () {
    $('#rateMe2').mdbRate();
});