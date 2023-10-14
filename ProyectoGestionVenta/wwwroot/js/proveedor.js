function soloLetras(event) {
    var charCode = event.which || event.keyCode;


    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 32) {
        return true;
    } else {
        return false;
    }
}
function rncCarateres(event) {
    $('#inputText').on('input', function () {
        var inputValue = $(this).val();

        // Limita la longitud a 11 caracteres
        if (inputValue.length > 11) {
            $(this).val(inputValue.substring(0, 11));
        }

        // Limita la cantidad de guiones a 3
        var hyphenCount = (inputValue.match(/-/g) || []).length;
        if (hyphenCount > 3) {
            var newValue = inputValue.replace(/-/g, '').substring(0, 11 - (hyphenCount - 3));
            $(this).val(newValue.replace(/(.{4})/g, '$1-'));
        }
    });
}
function contactoCarateres(event) {
    var inputValue = $(this).val();

    if (inputValue.length > 10) {
        $(this).val(inputValue.substring(0, 11));
    }
}