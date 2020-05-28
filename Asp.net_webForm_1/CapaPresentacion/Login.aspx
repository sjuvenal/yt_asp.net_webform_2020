<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>

<html class="bg-black" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso al sistema de CLinica</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css"  rel="stylesheet" type="text/css" />
    <link href="css/AdminLTE.css"   rel="stylesheet" type="text/css" />
</head>
<body class="bg-black">
    <div class="form-box" id="login-box">
        <div class="header">Login</div>
    <form id="form1" runat="server">
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" OnAuthenticate="LoginUser_Aunthenticate" Width="100%">
            <LayoutTemplate>
                 <div class="body bg-gray">
                <div class="form-group">
                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Ingrese Usuario"></asp:TextBox>
                </div>
                 <div class="form-group">
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Ingrese password"></asp:TextBox>
                </div>
            </div>
            <div class="footer">
                <%--<asp:Button ID="btnIngresar" runat="server" Text="Iniciar Sesión" CssClass="btn bg-olive btn-block" OnClick="btnIngresar_Click" />--%>
                <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Inicar Sesión" CssClass="btn bg-olive btn-block" />
            </div>
            </LayoutTemplate>
        </asp:Login>
    </form>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
