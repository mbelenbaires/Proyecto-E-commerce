<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPC_BAIRES.Detalle" %>
<!DOCTYPE html>
 <meta name="viewport" content="width=device-width, initial-scale=1">
  <link href="Shop2.css" rel="stylesheet">
    <style>


* {box-sizing: border-box}
body {font-family: Verdana, sans-serif; margin:0; padding-top: 56px;}
.mySlides {display:none }
img {vertical-align: middle;}

.lala{
    position:relative;
    left:60%;
    top:-35%;
}

/* Slideshow container */
.slideshow-container {
  top:17%;
  max-width: 600px;
  position: relative;
  margin-left:auto;
  margin-right:auto;
}

/* Next & previous buttons */
.prev, .next {
  cursor: pointer;
  position: absolute;
  top: 50%;
  width: auto;
  padding: 16px;
  margin-top: -22px;
  color: white;
  font-weight: bold;
  font-size: 18px;
  transition: 0.6s ease;
  border-radius: 0 3px 3px 0;
  user-select: none;
}

/* Position the "next button" to the right */
.next {
  right: 0;
  border-radius: 3px 0 0 3px;
}

/* On hover, add a black background color with a little bit see-through */
.prev:hover, .next:hover {
  background-color: rgba(0,0,0,0.8);
}

/* Caption text */
.text {
  color: #f2f2f2;
  font-size: 15px;
  padding: 8px 12px;
  position: absolute;
  bottom: 8px;
  width: 100%;
  text-align: center;
}

/* Number text (1/3 etc) */
.numbertext {
  color: #f2f2f2;
  font-size: 12px;
  padding: 8px 12px;
  position: absolute;
  top: 0;
}

/* The dots/bullets/indicators */
.dot {
  cursor: pointer;
  height: 15px;
  width: 15px;
  margin: 0 2px;
  background-color: #bbb;
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active, .dot:hover {
  background-color: #717171;
}

/* Fading animation */
.fade {
  -webkit-animation-name:fade;
  -webkit-animation-duration: 5s;
  animation-name:fade;
  animation-duration: 5s;
}

@-webkit-keyframes fade {
  from {opacity: 1} 
  to {opacity: 1}
}

@keyframes fade {
  from {opacity: 1} 
  to {opacity: 1}
}

/* On smaller screens, decrease text size */
@media only screen and (max-width: 300px) {
  .prev, .next,.text {font-size: 11px}
}
</style>
<head>
    <title>SHOP</title>
    <script src="detalle.js"></script>       
</head>


<body onload="currentSlide(1);">

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
            <h1 class="my-4">Shop</h1>
            <a href="/Tops" class="list-group-item">Tops</a>
            <a href="/Fyv.aspx" class="list-group-item">Faldas y Vestidos</a>
          <a href="/Pantalones.aspx" class="list-group-item">Pantalones</a>
          <a href="/Accesorios" class="list-group-item">Accesorios</a>
                      <a href="/Calzado" class="list-group-item">Calzado</a>



        </div>
      </div>
      <!-- /.col-lg-3 -->

        
  <!-- /.container -->

<div class="colu">
           <!-- Product Page Section Begin -->

<!-- Slideshow container -->
<div class="slideshow-container">

  <!-- Full-width images with number and caption text -->
  <div class="mySlides">
    <div class="numbertext">1 / 3</div>
    <img src="<%=prod.Imagen%>" style="max-width:50%">
  </div>

  <div class="mySlides">
    <div class="numbertext">2 / 3</div>
    <img src="https://colorlib.com/preview/theme/violet/img/product/product-1.jpg" style="max-width:50%">
  </div>

  <div class="mySlides">
    <div class="numbertext">3 / 3</div>
    <img src="https://colorlib.com/preview/theme/violet/img/product/product-1.jpg" style="max-width:50%">
  </div>

                               <!-- The dots/circles -->
<div style="text-align:left">
  <span class="dot" onclick="currentSlide(1)"></span>
  <span class="dot" onclick="currentSlide(2)"></span>
  <span class="dot" onclick="currentSlide(3)"></span>
</div>

</div>

                       <div class="lala">
                        <h2><%= prod.Nombre%></h2>
                        <div class="pc-meta">
                            <h5><%= "$" + prod.Precio%></h5>
                        </div>
                        <p><%= prod.Descripcion %></p>
                        <ul class="tags">
                            <li><p> <%="Talle" + prod.Tamaño %></p></li>
                            <li><p><span>Categoría:</span> <%= prod.Categoria %></p></li>
                        </ul>
                                            <% if(cliente != null) { %>
                <a class="nav-link" href="/Shop.aspx?add=<%= prod.Id %>">Agregar al carrito</a>
                   <% }
         else { %>
              <a class="nav-link" href="/Registro">Inicie sesión para comprar</a>
             <% } %>


                    </div>




   </div>             
                

                

                </div>
                
      </div>
    <!-- /.row -->

    </body>
      <footer class="py-5 bg-dark">
    <div class="container">
      <p class="m-0 text-center text-white">BELUSHOP &copy; 2019</p>
    </div> </footer>



