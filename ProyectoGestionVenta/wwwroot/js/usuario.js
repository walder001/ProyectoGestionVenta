function soloLetras(event) {
    var charCode = event.which || event.keyCode;


    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 32) {
        return true;
    } else {
        return false;
    }
}
function validarEntrada(input) {
    var valor = input.value;
    // Elimina cualquier car�cter que no sea un n�mero (0-9) ni gui�n (-)
    valor = valor.replace(/[^\d-]/g, '');
    // Asegura que no haya m�s de 9 caracteres
    if (valor.length > 9) {
        valor = valor.slice(0, 9);
    }
    input.value = valor;
}
}
