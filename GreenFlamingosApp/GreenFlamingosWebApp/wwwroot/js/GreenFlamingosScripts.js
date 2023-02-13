
function GetDynamicTextbox1(value) {
    return '<div><input type="text" name="Ingredients"/><input type="text" name="IngredientCapacity" style="width:28%" /><input type="button" style="width:8.5%; background-color:red; height:38px; border: 1px solid #ced4da; border-radius: 0.25rem;" onclick="RemoveTextBox1(this)" value="-" /></div>';
}

function GetDynamicTextbox(value) {
    return '<div><input type="text" style="width:90%" name="Preparations"/><input type="button" style="width:8.5%; background-color:red; height:38px; border: 1px solid #ced4da; border-radius: 0.25rem;" onclick="RemoveTextBox2(this)" value="-" /></div>';
}
function GetDynamicTextbox8(value) {
    return '<div><input type="text" style="width:90%" name="Ingredients"/><input type="button" style="width:8%; background-color:red; height:38px; border: 1px solid #ced4da; border-radius: 0.25rem;" onclick="RemoveTextBox8(this)" value="-" /></div>';
}

function GetDynamicTextbox6(value) {
    return '<div><input type="text" style="width:90%" name="IngredientsToAdd" /><input type="button" style="width:8%; background-color:red; height:38px; border: 1px solid #ced4da; border-radius: 0.25rem;" onclick="RemoveTextBox6(this)" value="-" /></div>';
}
function AddTextBox1() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox1("");
    document.getElementById("divCont1").appendChild(div);
}
function AddTextBox() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox("");
    document.getElementById("divCont2").appendChild(div);
}

function AddTextBox8() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox8("");
    document.getElementById("divCont8").appendChild(div);
}

function AddTextBox6() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox6("");
    document.getElementById("divCont6").appendChild(div);
}

Element.prototype.remove = function () {
    this.parentElement.removeChild(this);
}
NodeList.prototype.remove = HTMLCollection.prototype.remove = function () {
    for (var i = this.length - 1; i >= 0; i--) {
        if (this[i] && this[i].parentElement) {
            this[i].parentElement.removeChild(this[i]);
        }
    }
}
function RemoveTextBox1(div) {
    document.getElementById("divCont1").removeChild(div.parentNode.parentNode);
}
function RemoveTextBox(div) {
    document.getElementById("divCont").remove();
}
function RemoveTextBox2(div) {
    document.getElementById("divCont2").removeChild(div.parentNode.parentNode);
}
function RemoveTextBox3(div) {
    document.getElementById("divCont3").remove();
}
function RemoveTextBox6(div) {
    document.getElementById("divCont6").removeChild(div.parentNode.parentNode);
}
function RemoveTextBox8(div) {
    document.getElementById("divCont8").removeChild(div.parentNode.parentNode);
}

function CRateOut(rating) {
    for (var i = 1; i <= rating; i++) {
        $("#span" + i).attr('class', 'glyphicon glyphicon-star-empty')
    }
}
function CRateOver(rating) {
    for (var i = 1; i <= rating; i++) {
        $("#span" + i).attr('class', 'glyphicon glyphicon-star')
    }

}
function CRateClick(rating) {
    $("#lblRating").val(rating);

    for (var i = 1; i <= rating; i++) {
        $("#span" + i).attr('class', 'glyphicon glyphicon-star')
    }
    for (var i = rating + 1; i <= 5; i++) {
        $("#span" + i).attr('class', 'glyphicon glyphicon-star-empty')
    }
    $('#Rating').submit();
}
function CRateSelected() {
    var rating = $("#lblRating").val();
    for (var i = 0; i <= rating; i++) {
        $("#span" + i).attr('class', 'glyphicon glyphicon-star')
    }
}
