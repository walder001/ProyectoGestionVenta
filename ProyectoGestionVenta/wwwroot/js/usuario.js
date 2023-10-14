function soloLetras(event) {
    var charCode = event.which || event.keyCode;


    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 32) {
        return true;
    } else {
        return false;
    }
}
function validarNumerosYGuiones(input) {
    // Obtenemos el valor actual del input
    var valor = input.value;
    // Reemplazamos todo lo que no sea número o guión por una cadena vacía
    var valorValidado = valor.replace(/[^0-11-]/g, '');
    // Limitamos la longitud a 9 caracteres
    valorValidado = valorValidado.slice(0, 11);
    // Si el valor ha cambiado, actualizamos el contenido del input
    if (valor !== valorValidado) {
        input.value = valorValidado;
    }
}