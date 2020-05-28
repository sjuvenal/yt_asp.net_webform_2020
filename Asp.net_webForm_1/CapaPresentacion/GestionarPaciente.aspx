<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarPaciente.aspx.cs" Inherits="CapaPresentacion.frmGestionarPaciente" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align:center">REGISTRO DE PACIENTES</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>DOCUMENTO DE IDENTIDAD</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtNroDocumento" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>NOMBRES</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtNombres" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>APELLIDO PATERNO</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtPaterno" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>APELLIDO MATERNO</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtMaterno" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>SEXO</label>
                        </div>
                         <div class="form-group">
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>EDAD</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtEdad" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>TELEFONO</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtTelefono" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>DIRECCIÓN</label>
                        </div>
                         <div class="form-group">
                            <asp:TextBox ID="txtDireccion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
        <div align="center">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" Width="200px" OnClick="btnRegistrar_Click"/>
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
                            <div class="col-xs-12">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">lista de pacientes</h3>
                </div>
                <div class="box-body table-responsive">
                    <table id="tbl_pacientes" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>Código</th>
                                <th>Nombres</th>
                                <th>Apellidos</th>
                                <th>Sexo</th>
                                <th>Edad</th>
                                <th>Dirección</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody id="tbl_body_table">

                        </tbody>
                    </table>
                </div>
            </div>
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
       <script src="js/paciente.js" type="text/javascript">

       </script>
</asp:Content>