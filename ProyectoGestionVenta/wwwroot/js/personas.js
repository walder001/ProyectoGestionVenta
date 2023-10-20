function soloLetras(event) {
    var charCode = event.which || event.keyCode;


    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 32) {
        return true;
    } else {
        return false;
    }
}