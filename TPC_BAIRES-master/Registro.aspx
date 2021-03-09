<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPC_BAIRES.Registro" %>
<!DOCTYPE html>

<head>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="Shop2.css"/>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <title>Registro</title>
    <script src="/Scripts/jquery-3.3.1.js"></script>
    <script>

        function validar() {
            var d = document.getElementById("<%=TboxDNI.ClientID %>").value;
            var nom = document.getElementById("<%=TboxNombre.ClientID %>").value;
            var ap = document.getElementById("<%=TboxApellido.ClientID %>").value;
            var ma = document.getElementById("<%=TboxEmail.ClientID %>").value;
            var con = document.getElementById("<%=TboxContraseña.ClientID %>").value;
            var dire = document.getElementById("<%=TboxDireccion.ClientID %>").value;
            var ciu = document.getElementById("<%=TboxCiudad.ClientID %>").value;
            var cepe = document.getElementById("<%=TboxCP.ClientID %>").value;
            var tyc = $("#<%=CboxTerminos.ClientID %>").is(":checked");

            if (d === "" || nom === "" || ap === "" || ma === "" || con === "" || dire === "" || ciu === "" || cepe === "") {
                alert("Completá los campos.");
                return false;
            }
            else {
                if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(ma)) {
                    if (tyc) {
                        return true;
                    }
                    else { alert("Aceptá los términos y condiciones para continuar."); return false; }
                
                }
                else {
                    alert("Ingresá un mail válido.");
                    return false;
                }

                }
        }
    </script>

     <script src="/Scripts/bootstrap.js"></script>
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

        <h4 style="color:hotpink;">Si ya tenés usuario hacé click <a href="/InicioSesion">aquí</a> para iniciar sesión.</h4><br/>

        <div class="form-row">


            <h2>Ingresá tus datos para registrarte:</h2>
            <div class="form-group col-md-4"></div>
            <div class="form-group col-md-4"></div>
            <div class="form-group col-md-4"></div>
            <div class="form-group col-md-4"></div>
            <div class="form-group col-md-4"></div>
        </div>


        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label Text="DNI" ID="LblDNI" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox ID="TboxDNI" runat="server" MaxLength="8" ClientIDMode="Static" Style="margin-top: 10px;" placeholder="Ingresa tu número de DNI" CssClass="form-control" />
            </div>
                        <div class="form-group col-md-3">
                <asp:Label Text="Nombre" ID="LblNombre" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" MaxLength="100" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxNombre" placeholder="Ingresá tu nombre" CssClass="form-control" />
            </div>
            <div class="form-group col-md-3">
                <asp:Label Text="Apellido" ID="LblApellido" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" MaxLength="100" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxApellido" placeholder="Ingresá tu apellido" CssClass="form-control" />
            </div>
        </div>


        <div class="form-row " style="margin-top: 10px;">



            <div class="form-group col-md-4">
                <asp:Label Text="Email" ID="LblEmail" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <div class="input-group" style="margin-top: 10px;">
                    <div class="input-group-prepend">
                        <div class="input-group-text">@</div>
                    </div>
                    <asp:TextBox runat="server" MaxLength="100" ClientIDMode="Static" placeholder="ejemplo@gmail.com" ID="TboxEmail" CssClass="form-control " />
                    <p id="MensajeErrorEmail"></p>
                </div>
            </div>
                        <div class="form-group col-md-4">
                <asp:Label Text="Contraseña" ID="Label1" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <div class="input-group" style="margin-top: 10px;">
                    <div class="input-group-prepend">
                    </div>
                    <asp:TextBox runat="server" MinLength="6" MaxLength="15" ClientIDMode="Static" placeholder="Ingresá tu contraseña" ID="TboxContraseña" CssClass="form-control " TextMode="Password" />
                    <p id="MensajeContraseña"></p>
                </div>
            </div>
        </div>



        <div class="form-row" style="margin-top: 10px;">
            <div class="form-group col-md-5">
                <asp:Label Text="Dirección" ID="LblDireccion" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" MaxLength="40" Style="margin-top: 10px;" ID="TboxDireccion" ClientIDMode="Static" placeholder="Ingresá tu dirección" CssClass="form-control " />
                <p id="MensajeErrorDireccion"></p>
            </div>
            <div class="form-group col-md-">
                <asp:Label Text="Ciudad" ID="LblCiudad" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox runat="server" MaxLength="100" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxCiudad" placeholder="Ingrese su ciudad" CssClass="form-control" />
                <p id="MensajeErrorCiudad"></p>
            </div>
            <div class="form-group col-md-3">
                <asp:Label Text="CP" ID="LblCP" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox runat="server" MaxLength="8" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxCP" placeholder="XXXX" CssClass="form-control" />
                <p id="MensajeErrorCP"></p>
            </div>
        </div>


        <div style="margin-top: 10px; padding-right: 0px;">
<asp:CheckBox ID="CboxTerminos" runat="server" Text="  Acepto los términos y condiciones" ClientIDMode="Static"/>
            <p id="MensajeErrorCBOX"></p>
        </div>


        <div>
            <asp:Button ID="BtnRegistro" runat="server" Text="Registrarme " OnClientClick="return validar()" onclick="BtnRegistro_click"/>
        </div>

    </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</body>
