var isListHidden = false;
var lastSelRec = "";

var layout = function() {
    var hh = window.innerHeight;
    if (!hh) {
        hh = document.documentElement.clientHeight;
    }
    if (isListHidden) {
        hh = (hh - 40) + "px";
        document.getElementById("detail").style.height = hh;
    } else {
        hh = (hh - 40) / 2;
        hh = hh + "px";
        document.getElementById("list").style.height = hh;
        document.getElementById("detail").style.height = hh;
    }
}
window.onresize = function() {
    layout();
}
window.onload = function() {
    layout();
}
var toggleList = function() {
    if (isListHidden) {
        document.getElementById("list").style.display = "";
        isListHidden = false;
    } else {
        document.getElementById("list").style.display = "none";
        isListHidden = true;
    }
    layout();
    return false;
}
var selRec = function(id) {
    document.getElementById("detail").src = "detail.aspx?id=" + id;
    lastSelRec = id;
    return false;
}

var addNew = function() {
    document.getElementById("detail").src = "edit.aspx";
    return false;
}

var searchKey = function () {
    var key = document.getElementById("search").value;
    document.getElementById("list").src = "list.aspx?key=" + key;
    return false;
}
var SelectNav_onChange = function () {
    var nav = document.getElementById("SelectNav").value;
    window.location.href = nav;
}