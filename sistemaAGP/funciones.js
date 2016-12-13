function solonumeros(e) {

    var key;

    if (window.event) {
        key = e.keyCode;
    }
    else if (e.which) {
        key = e.which;
    }

    if (key == 8 | key == 127 | key == 27 | key == 26)
    { return true }

    if (key < 48 || key > 57) {
        return false;
    }

    return true;
}

function valida_rut(t_rut, t_dv) {
    rut = document.getElementById(t_rut).value;
    document.getElementById(t_dv).value = dv(rut);
}
function dv(T) {
    var M = 0, S = 1; for (; T; T = Math.floor(T / 10))
        S = (S + T % 10 * (9 - M++ % 6)) % 11; return S ? S - 1 : 'k';
}

function checkDate(sender, args) {
    if (sender._selectedDate > new Date()) {
        alert("No se puede seleccionar una fecha posterior al día de hoy");
        sender._selectedDate = new Date();
        sender._textbox.set_Value(sender._selectedDate.format(sender._format))
    }
}