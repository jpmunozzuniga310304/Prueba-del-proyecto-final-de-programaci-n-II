<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Iniciar sesion.aspx.cs" Inherits="PRUEBAFINALDELPROYECTODEPROGRAMACIONII.Iniciar_sesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet" />

<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />

<link rel="stylesheet" href="CSS/style.css" />
</head>
<body class="img js-fullheight" style="background-image: url(imagenes/Tecnologia.jpg);">
<section class="ftco-section">
	<div class="container">
	   <div class="row justify-content-center">
		   <div class="col-md-6 text-center mb-5">
			   <h2 class="heading-section">Iniciar sesion</h2>
		   </div>
	   </div>
	   <div class="row justify-content-center">
		   <div class="col-md-6 col-lg-4">
			   <div class="login-wrap p-0">
	      	       <h3 class="mb-4 text-center">¿Acaso tienes una cuenta?</h3>
	      	       <form action="#" class="signin-form" id="form1" runat="server">
	      		       <div class="form-group">
                             <asp:TextBox ID="tcorreo" placeholder="Ingrese el correo electronico" class="form-control" runat="server"></asp:TextBox>
	      		       </div>
                       <div class="form-group">
                           <asp:TextBox ID="tclave" class="form-control" TextMode="Password" placeholder="Ingrese la contraseña" runat="server"></asp:TextBox>
                           <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
                       </div>
                       <div class="form-group">
                          <asp:Button ID="Button1" class="form-control btn btn-primary submit px-3" runat="server" Text="Button" OnClick="Button1_Click" />			
					   </div>
                    </form>
                    <p class="w-100 text-center"></p>
			    </div>
                </div>
			</div>
		</div>
</section>
</body>
<script src="js/jquery.min.js"></script>
<script src="js/popper.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/main.js"></script>
</html>
