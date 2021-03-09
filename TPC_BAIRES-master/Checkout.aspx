<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TPC_BAIRES.Checkout" %>

<link rel="stylesheet" type="text/css"href="Shop.css" >


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">



    <head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>BELUSHOP - Checkout</title>

  <!-- Bootstrap core CSS -->
  <link href="Shop2.css" rel="stylesheet">


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
           <li class="nav-item">
        <% if (cliente != null)
            { %>
                <a class="nav-link" href="/Registro?logOut=true"> <%=cliente.Nombre + " " + cliente.Apellido + ": Cerrar Sesión"%></a>
              <% } %>
            </li>
        </ul>
      </div>
    </div>
  </nav>

  <!-- Page Content -->
  <div class="container">

    <div class="row">

      <div class="col-lg-3">

      
        <div class="list-group">
            <h1 class="my-4">Checkout</h1>
        </div>
      </div>
      <!-- /.col-lg-3 -->

      <div class="col-lg-9">

        <div id="carouselExampleIndicators" class="carousel slide my-4" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
          </ol>
        </div>

    <style>
        .card:hover {
            box-shadow: 1px 8px 20px grey;
            -webkit-transition: box-shadow .12s ease-in;
        }
    </style>

                        <div class="card text-white bg-dark">
                  <div class="card-header">
                      <p class="titulin"> Tus datos:</p>
                  </div>                  
                  <div class="card-body">                        
                        <p> Nombre: <%=cliente.Nombre%></p>
                        <p> Apellido: <%=cliente.Apellido%></p>
                        <p> Email de contacto: <%=cliente.Email%></p>
                        <p> Dirección de envío: <%=cliente.Direccion + ", " + cliente.Ciudad + " " + cliente.CP %></p>
                  </div>
              </div>

          <div>
              <div class="card text-white bg-dark">
             <div class="card-header"> <p class="titulin"> Estás comprando: </p> </div>
                   <% if (carrito != null && carrito.productos.Any())
                       { %>
                        
                  <% foreach (var item in carrito.productos)
                      { %>
                        <div class="card text-white bg-dark">
                           <div class="card-body">
                                <h5 class="card-title"><%= item.Nombre%></h5>
                                <p class="card-text"><%="$" + item.Precio %></p> 
                               <p class="card-text"><%=item.Tamaño %></p>
                               <p class="card-text"><%=item.Descripcion %></p>
                               <img id="Imagen" class="card-img" alt="..." src="<%=item.Imagen%>" />

                           
                        </div>
                            </div>
                   
                     <% } %>
              <div>
                   <div class="card-footer">
                                <p class="titulin">Total : $ <%=TotalCarrito %> </p>
              </div>
                <% }
                    else
                    { %><a class="nav-link" href="/Shop">El carrito está vacío.</a><% }
                      %>
                  </div>
          </div>

                




<form runat="server">
<asp:Button ID="Comprar" runat="server" Text="Confirmar compra" OnClick="Compra"/>
    </form>
        <!-- /.row -->

      </div>
      <!-- /.col-lg-9 -->

    </div>
    <!-- /.row -->

  </div>
  <!-- /.container -->

<footer class="py-5 bg-dark">
    <div class="container">
      <p class="m-0 text-center text-white">BELUSHOP &copy; 2019</p>
    </div>

  </footer>
</body>
</html>
