$(document).ready(function () {

	$("[data-mask]").inputmask();

	initDataTable();

	var glv_tabla;

	function initDataTable() {

		glv_tabla = $("#tbl_horarios").DataTable({
			"aaSorting": [[0, 'desc']],
			"bSort": true,
			"aoColumns": [
				{ "bSortable": false },
				{ "bSortable": false },
				null,
				null
			]
		});

	}

    // agregar un horario
    $("#btnAgregarDetalle").on("click", function (event) {
        event.preventDefault();
        //obtener los valores de los campos

		var IdProducto = $("#ddlProducto option:selected").val();
		var Producto = $("#ddlProducto option:selected").text();
		var Precio = $("#txtPrecio").val();


		if (Precio == "" || Precio == 0) {
			//alertify.warning('Debe Ingresar Cantidad Mínima.');
			alert('Debe Ingresar Precio.');
			return;
		}	

		var objetoDetalle = {
			"IdProducto": IdProducto,
			"Producto": Producto,
			"Precio": Precio
		};

		addRow(objetoDetalle)

    });

	function addRow(obj) {

		var valida_codIdProducto = false;

		//Validando El codigo de articulo / linea / Tipo Unidad  Existente
		$("#tbl_horarios tr").find('td:eq(0)').each(function () {

			var trDelResultado = $(this).parent();
			var codigoArtLin = trDelResultado.find('td:eq(0)').html();
			if (codigoArtLin == obj.IdProducto) {
				valida_codIdProducto = true;
			}
		});

		if (valida_codIdProducto == true) {	//Nuevo
			alert('Datos existen, no se puede asignar');
			return;
		}	

		glv_tabla.fnAddData(
			[obj.IdProducto,
				obj.Producto,
				obj.Precio,
				'<button type="button" title="Eliminar" value="X" class="btn btn-danger btn-delete"></button>'
			]
		);
	}


	// evento click para boton eliminar
	$(document).on('click', '.btn-delete', function (e) {
		e.preventDefault();

		var table = $('#MiTablaDetalle').DataTable();

		table
			.row($(this).parents('tr'))
			.remove()
			.draw();

	});


	$("#btnGuardar").click(function (e) {

		e.preventDefault();

		//var table = $('#MiTablaDetalle').DataTable();
		var heads = [];
		var rows = [];
		var postdata;

		//Obtener los registros de la tabla

		$("#tbl_horarios thead").find("th").each(function () {
			heads.push($(this).text().trim());
		});
		debugger;
		$("#tbl_horarios tbody tr").each(function () {
			cur = {};
			$(this).find("td").each(function (i, v) {
				var cab = "";

				switch (i) {
					case 0:
						cab = "idProducto";
						break;
					case 1:
						cab = "Producto";
						break;
					case 2:
						cab = "Precio";
						break;
				}

				//cur[heads[i]] = $(this).text().trim();
				cur[cab] = $(this).text().trim();
			});
			rows.push(cur);
			cur = {};
		});
		postdata = JSON.stringify(rows);

		var obj = JSON.stringify({
			idCliente: $("#ddlCliente option:selected").val(),
			Fecha: $("#txtFechaAtencion").val(),
			Detalle: postdata
		});

		//Limpiar registros
		rows = "";
		postdata = rows;

		$.ajax({
			type: "POST",
			url: "GestionarFactura.aspx/InsertarFactura",
			data: obj,
			dataType: "json",
			contentType: 'application/json; charset=utf-8',
			error: function (xhr, ajaxOptions, thrownError) {
				console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
			},
			success: function (response) {
				if (response.d) {
					
					alert("Registro actualizado de manera correcta.");
					
				} else {
					alert("No se pudo actualizar el registro.");
				}
			}
		});
	});


			//var str = JSON.stringify({

		//	data: [
		//		{
		//			id: "ajson1",
		//			parent: "#",
		//			text: "Simple"
		//		},
		//		{
		//			id: "ajson2",
		//			parent: "#",
		//			text: "Root"
		//		}
		//	]
		//});

});