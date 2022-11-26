var tbl = document.getElementById("tblMain");
if (tbl != null) {
    for (var i = 0; i < tbl.rows.length; i++) {
        for (var j = 0; j < tbl.rows[i].cells.length; j++)
            tbl.rows[i].cells[j].onclick = function () { getval(this); };
    }
}

function getval(cel) {
    alert(cel.innerHTML);
}