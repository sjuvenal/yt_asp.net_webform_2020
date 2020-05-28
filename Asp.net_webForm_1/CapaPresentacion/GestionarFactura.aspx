<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarFactura.aspx.cs" Inherits="CapaPresentacion.GestionarFactura" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1 style="text-align:center">REGISTRO FACTURAS</h1>
    </section>
    <section class="content">

                <div align="right">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" Width="200px" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" Width="200px"/>
                </td>
            </tr>
        </table>
        </div> 
        <br />
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>CLIENTE</label>
                        </div>
                         <div class="form-group">
                             <asp:DropDownList ID="ddlCliente" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>FECHA</label>
                        </div>
                         <div class="form-group">
                            
                             <asp:TextBox ID="txtFechaAtencion" runat="server" CssClass="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask=""></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    <div class="row">
            <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>PRODUCTO</label>
                        </div>
                         <div class="form-group">
                            <asp:DropDownList ID="ddlProducto" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>PRECIO</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtPrecio" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
            </div>
        <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>MANTENIMIENTO</label>
                        </div>
                         <div class="form-group">
                             <asp:Button ID="btnAgregarDetalle" runat="server" CssClass="btn btn-primary" Text="AGREGAR" Width="200px" />
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>

        <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Detalle Factura<</h3>
                    </div>
                    <div class="box-body table table-responsive">
                        <table id="tbl_horarios" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>IdProducto</th>
                                    <th>PRODUCTO</th>
                                    <th>PRECIO</th> <!-- contenedor del id -->  
                                    <th>BOTON</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">

                            </tbody>
                        </table>

                    </div>
                </div>
    </section>

    <div class="modal fade" id="imodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Actualziar registros</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>NOMBRE Y APELLIDOS</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtFullName" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>DIRECCIÓN</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtModalDireccion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                  <div class="modal-footer">
                      <button type="button" class="btn btn-primary" id="btnactualizar">Actualizar</button>
                  </div>
            </div>
        </div>
    </div>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
    <script src="js/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="js/plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <script src="js/plugins/moment/moment.min.js"></script>

    <script src="js/factura.js"></script>


</asp:Content>
