var telItems = new Listas();
var emailItems = new Listas();
var dirItems = new Listas();

function MostrarTelefonos(editar) {
    $('#telItems').html('');
    if (telItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar)
            $table.append('<thead><tr><th>Telefonos</th><th>Tipo</th><th>Principal</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Telefonos</th><th>Tipo</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < telItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(telItems.Item(i).NumeroTelefonico));
            $row.append($('<td/>').html(telItems.Item(i).Tipo));
            $row.append($('<td/>').html(telItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarTel(" + i + ");'> <span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#telItems').html($table);
    }
}


function addTel_Click() {
    var isValidItem = true;
    if ($('#Telefono').val().trim() == '') {
        isValidItem = false;
        $('#Telefono').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Telefono').siblings('span.error').css('visibility', 'hidden');
    }

    if ($('#Tipo').val().trim() == '') {
        isValidItem = false;
        $('#Tipo').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Tipo').siblings('span.error').css('visibility', 'hidden');
    }

    if (isValidItem) {
        var vPrincipal;
        if ($('#TelPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
            vPrincipal = false;

        telItems.Agregar({
            TelefonoId: 0,
            NumeroTelefonico: $('#Telefono').val().trim(),
            Tipo: $('#Tipo').val().trim(),
            Principal: vPrincipal
        });

        $('#Telefono').val('').focus();
        $('#Tipo').val('');
        $('#TelPrincipal').attr('checked', false);
    }
    MostrarTelefonos(true);
}
function EliminarTel(indice) {
    telItems.Eliminar(indice);
    MostrarTelefonos(true);
    return false;
}

//Email
function addEmail_Click() {
    var isValidItem = true;
    if ($('#EmailDireccion').val().trim() == '') {
        isValidItem = false;
        $('#EmailDireccion').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#EmailDireccion').siblings('span.error').css('visibility', 'hidden');
    }

    if (isValidItem) {
        var vPrincipal;
        if ($('#EmailPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
            vPrincipal = false;

        emailItems.Agregar({
            EmailId: 0,
            Direccion: $('#EmailDireccion').val().trim(),
            Principal: vPrincipal
        });

        $('#EmailDireccion').val('').focus();
        $('#EmailPrincipal').attr('checked', false);
    }
    MostrarEmail(true);
}

function MostrarEmail(editar) {
    $('#emailItems').html('');
    if (emailItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar)
            $table.append('<thead><tr><th>Direccion</th><th>Principal</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Direccion</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < emailItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(emailItems.Item(i).Direccion));
            $row.append($('<td/>').html(emailItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarEmail(" + i + ");'> <span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#emailItems').html($table);
    }
}

function EliminarEmail(indice) {
    telItems.Eliminar(indice);
    MostrarEmail(true);
    return false;
}

//Direcciones

function addDir_Click() {

    var isValidItem = true;
    if ($('#DirCalle').val().trim() == '') {
        isValidItem = false;
        $('#DirCalle').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#DirCalle').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#DirNumExterior').val().trim() == '') {
        isValidItem = false;
        $('#DirNumExterior').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#DirNumExterior').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#DirNumInterior').val().trim() == '') {
        isValidItem = false;
        $('#DirNumInterior').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#DirNumInterior').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#DirColonia').val().trim() == '') {
        isValidItem = false;
        $('#DirColonia').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#DirColonia').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#DirMunicipio').val().trim() == '') {
        isValidItem = false;
        $('#DirMunicipio').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#DirMunicipio').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#DirEstado').val().trim() == '') {
        isValidItem = false;
        $('#DirEstado').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#DirEstado').siblings('span.error').css('visibility', 'hidden');
    }

    if (isValidItem) {
        var vPrincipal;
        if ($('#DirPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
            vPrincipal = false;

        dirItems.Agregar({
            DireccionId: 0,
            Calle: $('#DirCalle').val().trim(),
            NumExterior: $('#DirNumExterior').val().trim(),
            NumInterior: $('#DirNumInterior').val().trim(),
            Colonia: $('#DirColonia').val().trim(),
            Municipio: $('#DirMunicipio').val().trim(),
            Estado: $('#DirEstado').val().trim(),
            Principal: vPrincipal
        });

        $('#DirCalle').val('').focus();
        $('#DirNumExterior').val('');
        $('#DirNumInterior').val('');
        $('#DirColonia').val('');
        $('#DirMunicipio').val('');
        $('#DirEstado').val('');
        $('#DirPrincipal').attr('checked', false);
    }
    MostrarDir(true);
}

function MostrarDir(editar) {
    $('#emailItems').html('');
    if (dirItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar)
            $table.append('<thead><tr><th>Calle</th><th>NumExterior</th><th>NumInterior</th><th>Colonia</th><th>Municipio</th><th>Estado</th><th>Principal</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Calle</th><th>NumExterior</th><th>NumInterior</th><th>Colonia</th><th>Municipio</th><th>Estado</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < dirItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(dirItems.Item(i).Calle));
            $row.append($('<td/>').html(dirItems.Item(i).NumExterior));
            $row.append($('<td/>').html(dirItems.Item(i).NumInterior));
            $row.append($('<td/>').html(dirItems.Item(i).Colonia));
            $row.append($('<td/>').html(dirItems.Item(i).Municipio));
            $row.append($('<td/>').html(dirItems.Item(i).Estado));

            $row.append($('<td/>').html(dirItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarDir(" + i + ");'> <span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#dirItems').html($table);
    }
}

function EliminarDir(indice) {
    telItems.Eliminar(indice);
    MostrarDir(true);
    return false;
}

//boton guardar cliente
function crear_Click() {
 

    
    var isAllValid = true;

    if ($('#Nombre').val().trim() == '') {
        $('#Nombre').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#Nombre').siblings('span.error').css('visibility', 'hidden');
    }


    if ($('#TipoClienteId').val().trim() == '') {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        var data = {
            ClienteId: 0,
            Nombre: $('#Nombre').val().trim(),
            RFC: $('#RFC').val().trim(),
            TipoPersonSat: $('#TipoPersonSat').val().trim(),
            TipoClienteId: $('#TipoClienteId').val().trim(),
            Telefonos: telItems.lista,
            Correos: emailItems.lista,
            Direcciones: dirItems.lista
        }

        var token = $('[name=__RequestVerificationToken]').val();

        $.ajax({
            url: '/Clientes/Create',
            type: "POST",
            data: { __RequestVerificationToken: token, cliente: data },
            success: function (d) {
                if (d == true) {
                    window.location.href = "/Clientes/Index";
                } else {
                    alert('Hubo un error al momento de guardar');
                }
            },
            error: function () {
                alert('Error, vuelva a intentarlo');
            }

        });
    }
    
}

//boton actualizar cliente
function modificar_Click() {

    var isAllValid = true;

    if ($('#Nombre').val().trim() == '') {
        $('#Nombre').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#Nombre').siblings('span.error').css('visibility', 'hidden');
    }


    if ($('#TipoClienteId').val().trim() == '') {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        var data = {
            ClienteId: $('#ClienteId').val().trim(),
            Nombre: $('#Nombre').val().trim(),
            RFC: $('#RFC').val().trim(),
            TipoPersonSat: $('#TipoPersonSat').val().trim(),
            TipoClienteId: $('#TipoClienteId').val().trim(),
            Telefonos: telItems.lista,
            Correos: emailItems.lista,
            Direcciones: dirItems.lista
        }

        var idCliente = $('#ClienteId').val().trim();
        var token = $('[name=__RequestVerificationToken]').val();
        var url = '/Clientes/Edit/' + idCliente;

        $.ajax({
            url: url,
            type: "POST",
            data: { __RequestVerificationToken: token, cliente: data },
            success: function (d) {
                if (d == true) {
                    window.location.href = "/Clientes/Index";
                } else {
                    alert('Hubo un error al momento de guardar');
                }
            },
            error: function () {
                alert('Error, vuelva a intentarlo');
            }

        });
    }

}