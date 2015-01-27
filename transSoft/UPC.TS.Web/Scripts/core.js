function errorAjax() {
    alert("Se producjo un error inesperado mantengase en contacto con el administrador del Sistema");
}

function TrimString(x) {
    return x.replace(/^\s+|\s+$/gm, '');
}


$('.upctbgrid').DataTable({
    "language": {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        }
    }                                              
});

$.fn.datepicker.defaults.language = "es";
$.fn.datepicker.defaults.format = "dd/mm/yyyy";


function showNotifyByData(data) {
    //var stack_bar_top = { "dir1": "down", "dir2": "right", "push": "top", "spacing1": 0, "spacing2": 0 };
    new PNotify({
        title: data.Title,
        text: data.Message,
        type: data.TypeResponse 
    });
}

function showNotify(title, message, typeMessage) {
    //var stack_bar_top = { "dir1": "down", "dir2": "right", "push": "top", "spacing1": 0, "spacing2": 0 };
    new PNotify({
        title: title,
        text: message,
        type: typeMessage
    });
}

/*Extensiones*/
$.fn.updateValidation = function () {
    var form = this.closest("form").removeData("validator").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(form);
    return this;
};

$.fn.cleanValidation = function () {
    $(this).find(".field-validation-error").each(function () {
        $(this).removeClass("field-validation-error").addClass("field-validation-valid");
    });
    $(this).find(".input-validation-error").each(function () {
        $(this).removeClass("input-validation-error").addClass("valid");
    });
    $(this).find(".validation-summary-errors").each(function () {
        $(this).find("ul").empty();
        $(this).removeClass("validation-summary-errors").addClass("validation-summary-valid");
    });
    $(this).updateValidation();
};

//$.validator.methods.number = function (value, element) {
//    //return !isNaN($.parseFloat(value));
//    return this.optional(element) || /^-?(?:d+|d{1,3}(?:[s.,]d{3})+)(?:[.,]d+)?$/.test(value);
//}