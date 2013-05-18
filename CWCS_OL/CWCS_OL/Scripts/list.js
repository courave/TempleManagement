var isListHidden = false;
var isPrintHidden = false;
var lastSelRec = "";

var layout = function() {
    var hh = window.innerHeight;
    if (!hh) {
        hh = document.documentElement.clientHeight;
    }
    if (isListHidden) {
        hh = (hh - 40) + "px";
        document.getElementById("detail").style.height = hh;
        document.getElementById("print").style.height = hh;
    } else {
        hh = (hh - 40) / 2;
        hh = hh + "px";
        document.getElementById("list").style.height = hh;
        document.getElementById("detail").style.height = hh;
        document.getElementById("print").style.height = hh;
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
var togglePrint = function() {
    if (isPrintHidden) {
        if (lastSelRec != "") {
            document.getElementById("print").src = "print.aspx?id=" + lastSelRec;
            lastSelRec = "";
        }
        document.getElementById("detail").style.width = "50%";
        document.getElementById("print").style.display = "";
        isPrintHidden = false;
    } else {
        document.getElementById("detail").style.width = "100%";
        document.getElementById("print").style.display = "none";
        isPrintHidden = true;
    }
    return false;
}

var selRec = function(id) {
    document.getElementById("detail").src = "detail.aspx?id=" + id;
    if (!isPrintHidden) {
        document.getElementById("print").src = "print.aspx?id=" + id;
    } else {
        lastSelRec = id;
    }
    return false;
}

var printAll = function() {
    document.getElementById("print").src = "print.aspx?printall=";
    if (isPrintHidden) {
        lastSelRec = "";
        togglePrint();
    }
    return false;
}

var printCurrent = function () {
    document.getElementById("print").src = "print.aspx?printcur=";
    if (isPrintHidden) {
        lastSelRec = "";
        togglePrint();
    }
    return false;
}

var addNew = function() {
    document.getElementById("detail").src = "edit.aspx";
    document.getElementById("print").src = "about:blank";
    return false;
}
var addNewRec = function (fahui) {
    document.getElementById("detail").src = "edit.aspx?fahui="+fahui;
    document.getElementById("print").src = "about:blank";
    return false;
}
var searchKey = function () {
    var key = document.getElementById("search").value;
    document.getElementById("list").src = "list.aspx?key=" + key;
    return false;
}

var printPage = function () {
    var fromPage = document.getElementById("printFrom").value;
    var toPage = document.getElementById("printTo").value;
    if (fromPage == "" || toPage == "") {
        return printAll();
    }
    document.getElementById("print").src = "print.aspx?fromPage=" + fromPage + "&toPage=" + toPage;
    return false;
}

var SelectNav_onChange = function () {
    var nav = document.getElementById("SelectNav").value;
    window.location.href = nav;
}