$(document).ready(function () {
    alert('Hola');
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5190/ClientePrestamo/GetAll',
        success: function (result) {
       
            $("#tblPrestamo tbody").empty();

            $.each(result.objects, function (i, prestamo) {
                var filas =
                    '<tr>'
                    + '<td class="d-none" id="tdIdPrestamo">' + prestamo.idPrestamo + '</td>'
                    + '<td class="d-none" id="tdIdMedio">' + prestamo.medio.idMedio + '</td>'
                    + '<td style="text-align:center;" id="tdTitulo">' + prestamo.titulo + '</td>'
                    + '<td style="text-align:center;" id="tdFechaPrestamo">' + prestamo.fechaPrestamo + '</td>'
                    + '<td style="text-align:center;" id="tdFechaEntrega">' + prestamo.fechaEntrega + '</td>'
                    + '<td style="text-align:center;" id="tdEstatus">' + prestamo.estatus + '</td>'
                    + '<td style="text-align:center;" id="tdIdUsuario">' + prestamo.usuario.id + '</td>'
                    + '</tr>'
                $("#tblPrestamo").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta');
        },
    });
}