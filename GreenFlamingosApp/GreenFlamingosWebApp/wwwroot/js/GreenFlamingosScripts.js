
function GetDynamicTextbox1(value) {
    return '<div><input type="text" name="Ingredients"/><input type="text" name="IngredientCapacity" style="width:27%" /><input type="button" style="width:8%; background-color:red; height:38px; border: 1px solid #ced4da; border-radius: 0.25rem;" onclick="RemoveTextBox1(this)" value="-" /></div>';
}
function AddTextBox1() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox1("");
    document.getElementById("divCont1").appendChild(div);
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
