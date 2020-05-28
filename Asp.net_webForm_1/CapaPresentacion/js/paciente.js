var tabla, data;
function addRowDT(data) {

    tabla = $("#tbl_pacientes").DataTable();

    tabla.fnClearTable();

    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].IdPaciente,
            data[i].Nombres,
            (data[i].ApPaterno + "" + data[i].ApMaterno),
            ((data[i].sexo == 'M') ? "Masculino" : "Femenino"),
            data[i].Edad,
            data[i].Direccion,
            //((data[i].Estado == true) ? "Activo" : "Inactivo")
            '<button value="Actualizar" title="Actualizar" class="btn btn-primary btn-edit" data-target="#imodal" data-toggle="modal"><i class="fa fa-check-square-o" aria-hidden="true"></i></button>&nbsp;' +
            '<button value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete" ><i class="fa fa-minus-square-o" aria-hidden="true"></i></button>'
        ]);
    }
}



function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "GestionarPaciente.aspx/ListarPacientes",
        data: {},
        contentType: 'application/json; charset-utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            //console.log(data);
            addRowDT(data.d);
        }
    });
}
//evento click para actualizar registros
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault(); //permite no realizar un postman
    //console.log("Click en el boton actuyalizar");
    //console.log($(this).parent().parent().children().first().text()); //nos trae un ID
    var row = $(this).parent().parent()[0];
    data = tabla.fnGetData(row);
    fillModalData();
});

//cargar datos en el modal
function fillModalData() {
    $("#txtFullName").val(data[1] + "" + data[1]);
    $("#txtModalDireccion").val(data[5]);
}

$("#btnactualizar").click(function (e) {
    e.preventDefault();
    updateDataAjax();
});


function updateDataAjax() {
    var obj = JSON.stringify({ id: JSON.stringify(data[0]), direccion: $("#txtModalDireccion").val() });
    $.ajax({
        type: "POST",
        url: "GestionarPaciente.aspx/ActualizarDatosPaciente",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset-utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            //console.log(response);
            if (response.d) {
                alert("Registro actualizado de manera correcto");
                $('#imodal').modal('hide');
                sendDataAjax();
            } else {
                alert("Registro actualizado de manera correcto");
            }
        }
    });
}

//evento click para eliminar registros
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault(); //permite no realizar un postman
    //primer método: eliminar la fila del datatable
    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);
    //var objeto = tabla.fnDeleteRow(data);
    //segundo método: enviar el código del paciente al servidor y eliminar
    //paso 1 : enviamos el Id por medio del ajax
    deleteDataAjax(dataRow[0]) //posicion 0 tiene el ID
    //paso 2: renderizar el datatable
    sendDataAjax();
});

function deleteDataAjax(data) {
    var obj = JSON.stringify({ id: JSON.stringify(data) });; //enviarlo como cadena
    $.ajax({
        type: "POST",
        url: "GestionarPaciente.aspx/EliminarDatosPaciente",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset-utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            //console.log(response);
            if (response.d) {
                alert("Registro eliminado de manera correcta.");
                
            } else {
                alert("No se pudo eliminar el registro.");
            }
        }
    });
}


sendDataAjax();
//llamando a la funcion de ajax al carga el documento
