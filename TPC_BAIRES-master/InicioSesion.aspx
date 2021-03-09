<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="TPC_BAIRES.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
                 <script src="validacion.js"></script>
    <title>Inicio de sesión</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Shop2.css"/>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>
<body>

      <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
    <div class="container">
      <a class="navbar-brand" href="#"></a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item active">
            <a class="nav-link" href="/Shop">Home              
              <span class="sr-only">(current)</span>
            </a>
          </li>
            <li class="nav-item"> <a class="nav-link" href="/Registro">Registrarse</a> </li>
        </ul>
      </div>
    </div>
  </nav>

    <form id="form1" runat="server">
        <div>



    <style>
        .Error {
            border: solid 2px #ff0000;
        }
    </style>

    <div class="p-3 mb-2 bg-dark text-white">

    </div>
    <hr />

    <div class="container">

        <div class="form-row">
            <div class="form-group col-md-4">
                <h2>Ingresá tus datos para iniciar sesión</h2>
            </div>
        </div>


        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label Text="Email" ID="LblEmail" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <div class="input-group" style="margin-top: 10px;">
                    <div class="input-group-prepend">
                        <div class="input-group-text">@</div>
                    </div>
                    <asp:TextBox runat="server" onkeyup="validarEmail()" onfocus="Seleccionar(this.id)" MaxLength="33" ClientIDMode="Static" placeholder="example@gmail.com" ID="TboxEmail" CssClass="form-control " />
                    <p id="MensajeErrorEmail"></p>
                </div>
            </div>
        </div>


        <div class="form-row " style="margin-top: 10px;">
            <div class="form-group col-md-4">
                <asp:Label Text="Contraseña" ID="Label1" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <div class="input-group" style="margin-top: 10px;">
                    <div class="input-group-prepend">
                    </div>
                    <asp:TextBox runat="server" onkeyup="validarContraseña()" onfocus="Seleccionar(this.id)" MinLength="6" MaxLength="33" ClientIDMode="Static" placeholder="Mínimo 6 caracteres" ID="TboxContraseña" CssClass="form-control " TextMode="Password" />
                    <p id="MensajeContraseña"></p>
                </div>
            </div>
        </div>

        <div>
            <asp:Button ID="BtnSesion" runat="server" Text="Iniciar Sesión" onclick="BtnSesion_click"/>
        </div>
<asp:Panel ID="Panel1" Visible="false" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Datos incorrectos!" backcolor="Red"></asp:Label>
</asp:Panel>
        <div id="oculto" style="visibility:hidden">
Este texto se verá cuando yo quiera
</div>


    </div>
        </div>
    </form>
</body>
</html>