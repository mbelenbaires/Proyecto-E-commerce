<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="TPC_BAIRES.Shop" %>
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
            <a class="nav-link" href="/Shop">Home
              <span class="sr-only">(current)</span>
            </a>
          </li>
           
        <% if(cliente != null) { %>
               <li class="nav-item"> <a class="nav-link" href="/Registro?logOut=true"> <%=cliente.Nombre + " " + cliente.Apellido + ": Cerrar Sesión"%></a> </li>
               <li class="nav-item">
                <a href="Carrito.aspx"> <img src="https://www.searchpng.com/wp-content/uploads/2019/02/Shopping-Cart-PNG.png" width="30"></a>
              </li>
                   <% }
         else { %>
             <li class="nav-item"> <a class="nav-link" href="/Registro">Registrarse</a> </li>
              <li class="nav-item"> <a class="nav-link" href="/InicioSesion">Iniciar Sesión</a> </li>

             <% } %>
            
        </ul>
      </div>
    </div>
  </nav>

  <!-- Page Content -->
  <div class="container">

    <div class="row">

      <div class="col-lg-3">

      
        <div class="list-group">
            <a href="Shop.aspx"><h1 class="my-4">Shop</h1></a>
            <a href="/Tops" class="list-group-item">Tops</a>
            <a href="/Fyv.aspx" class="list-group-item">Faldas y Vestidos</a>
          <a href="/Pantalones.aspx" class="list-group-item">Pantalones</a>
          <a href="/Accesorios" class="list-group-item">Accesorios</a>
                      <a href="/Calzado" class="list-group-item">Calzado</a>



        </div>
                <form id="Form1" runat="server">
                      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                      <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click"/>
                </form>
      </div>
      <!-- /.col-lg-3 -->

      <div class="col-lg-9">

        <div id="carouselExampleIndicators" class="carousel slide my-4" data-ride="carousel">
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
        <% foreach (var item in productos)
            { %>
       
        <div class="card text-white bg-dark">
           <a href="/Detalle.aspx?ver=<%= item.Id %>"> <img id="Imagen" class="card-img-top" alt="..." src="<%=item.Imagen%>" /> </a>
            <div class="card-body">
                <h5 class="card-title"><%= item.Nombre%></h5>
                <p class="card-text"><%="$" + item.Precio %></p>
                <p class="card-text"><%= item.Descripcion %></p>
                <p class="card-text"><%= item.Tamaño %></p>
            </div>
                    <% if (cliente != null)  {
                            if (carrito != null) {
                                if (BuscarEnCarrito(item.Id,carrito.productos) == true )
                                 { %><a> El producto ya está en el carrito</a> <%  }
                                    else
                                    { %>
                                     <a class="nav-link" href="/Carrito.aspx?add=<%= item.Id %>">Agregar al carrito</a><%               
                                    }
                                                 }
                            else
                                 { %>
                <a class="nav-link" href="/Carrito.aspx?add=<%= item.Id %>">Agregar al carrito</a>
                              <% }
                                            }

                         else
                                 { %>
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

      <footer class="py-5 bg-dark">
    <div class="container">
      <p class="m-0 text-center text-white">BELUSHOP &copy; 2019</p>
    </div> </footer>

</body>

 

</html>
