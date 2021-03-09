<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="TPC_BAIRES.Buscador" %>

<link rel="stylesheet" type="text/css"href="Shop.css" >


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">



    <head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>SHOP</title>

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
            <a class="nav-link" href="/Default">Home
              <span class="sr-only">(current)</span>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="/About">About</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="/Galeria">Galería</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="https://www.instagram.com/beluenlinea">Contacto</a>
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
            <h1 class="my-4">Shop</h1>
            <a href="/Tops" class="list-group-item">Tops</a>
            <a href="/Fyv.aspx" class="list-group-item">Faldas y Vestidos</a>
          <a href="/Pantalones.aspx" class="list-group-item">Pantalones</a>
          <a href="/Accesorios" class="list-group-item">Accesorios</a>
                      <a href="/Calzado" class="list-group-item">Calzado</a>




        </div>
                      <form id="Form1" runat="server">
                          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                          <asp:Button ID="Button1" runat="server" Text="Buscar"/>

                </form>
      </div>
      <!-- /.col-lg-3 -->

      <div class="col-lg-9">

        <div id="carouselExampleIndicators" class="carousel slide my-4" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          </ol>
          <div class="carousel-inner" role="listbox">
            <div class="carousel-item">
              <img class="d-block img-fluid" src="http://placehold.it/900x350" alt="Second slide">
            </div>
            <div class="carousel-item">
              <img class="d-block img-fluid" src="http://placehold.it/900x350" alt="Third slide">
            </div>
          </div>
          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div>

    <style>
        .card:hover {
            box-shadow: 1px 8px 20px grey;
            -webkit-transition: box-shadow .12s ease-in;
        }
    </style>

    <div class="card-columns" style="margin-left: 25px; margin-right: 25px;">
        <p></p>
        <p></p>
        <p></p>        
        <% foreach (var item in productosfiltrados)
            { %>
        <div class="card text-white bg-dark">
            <img id="Imagen" class="card-img-top" alt="..." src="<%=item.Imagen%>" />
            <div class="card-body">
                <h5 class="card-title"><%= item.Nombre%></h5>
                <p class="card-text"><%="$" + item.Precio %></p>
                <p class="card-text"><%= item.Descripcion %></p>
                <p class="card-text"><%= item.Tamaño %></p>
            </div>
             <% if(cliente != null) { %>
                <a class="nav-link" href="/Buscador.aspx?add=<%= item.Id %>">Agregar al carrito</a>
                   <% }
         else { %>
              <a class="nav-link" href="/Registro">Inicie sesión para comprar</a>
             <% } %>
        </div>
        <% } %>
    </div>
        <!-- /.row -->

      </div>
      <!-- /.col-lg-9 -->

    </div>
    <!-- /.row -->

  </div>
  <!-- /.container -->

  <!-- Footer 
  <footer class="py-5 bg-dark">
    <div class="container">
      <p class="m-0 text-center text-white">Copyright &copy; Your Website 2019</p>
    </div>
    <!-- /.container 
  </footer> -->

  <!-- Bootstrap core JavaScript -->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

</body>

 

</html>