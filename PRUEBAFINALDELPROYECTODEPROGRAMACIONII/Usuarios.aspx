<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PRUEBAFINALDELPROYECTODEPROGRAMACIONII.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contanie text-center"> 
    <h1>Usuarios</h1>
   </div>
   <br />
   <br />
   <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
   CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
   RowStyle-CssClass="rows" AllowPaging="True" />
   <br />
   <br />
   <br />
   <div>
       <div class="mb-3">
           <label for="exampleInputEmail1" class="form-label">UsuarioID</label>
           <asp:TextBox ID="tUsuarioID" class="form-control" runat="server"></asp:TextBox>
       </div> 
       <div class="mb-3">
           <label for="exampleInputEmail1" class="form-label">Nombre</label>
           <asp:TextBox ID="tNombre" class="form-control" runat="server"></asp:TextBox>
       </div>
       <div class="mb-3">
           <label for="exampleInputEmail1" class="form-label">Correo Electronico</label>
           <asp:TextBox ID="tCorreoElectronico" class="form-control" runat="server"></asp:TextBox>
       </div>
       <div class="mb-3">
           <label for="exampleInputEmail1" class="form-label">Telefono</label>
           <asp:TextBox ID="tTelefono" class="form-control" runat="server"></asp:TextBox>
       </div>
       </div>
       <div>
       <div class="container text-center">
       </div>
           <asp:Button ID="Button4" class="btn btn-dark" runat="server" Text="Agregar" OnClick="Button4_Click" />
           <asp:Button ID="Button3" class="btn btn-dark" runat="server" Text="Borrar" OnClick="Button3_Click" />
           <asp:Button ID="Button1" runat="server" class="btn btn-dark" Text="Actualizar" OnClick="Button1_Click" />
           <asp:Button ID="Button2" runat="server" class="btn btn-dark" Text="Consultar" OnClick="Button2_Click" />
           <asp:Button ID="Button5" runat="server" class="btn btn-dark" Text="Mostrar todo" OnClick="Button5_Click" />
       </div>
</asp:Content>
