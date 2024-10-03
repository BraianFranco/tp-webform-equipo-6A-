
// Función para mostrar el toast
function mostrarToast(mensaje) {
  
    document.querySelector("#miToast .toast-body").textContent = mensaje;

    var toastElement = document.getElementById("miToast");
    var toast = new bootstrap.Toast(toastElement);
    toast.show();
}
