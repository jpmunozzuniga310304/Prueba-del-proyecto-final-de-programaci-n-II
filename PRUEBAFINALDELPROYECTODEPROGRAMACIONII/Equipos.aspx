﻿<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="PRUEBAFINALDELPROYECTODEPROGRAMACIONII.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="contanie text-center"> 
    <h1>Equipos</h1>
</div>
 <div>
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
             <label for="exampleInputEmail1" class="form-label">EquipoID</label>
             <asp:TextBox ID="tEquipoID" class="form-control" runat="server"></asp:TextBox>
         </div>
         <div class="mb-3">
             <label for="exampleInputEmail1" class="form-label">Tipo Equipo</label>
             <asp:TextBox ID="tTipoEquipo" class="form-control" runat="server"></asp:TextBox>
         </div>
         <div class="mb-3">
              <label for="exampleInputEmail1" class="form-label">Modelo</label>
              <asp:TextBox ID="tModelo" class="form-control" runat="server"></asp:TextBox>
         </div>
          <div class="mb-3">
              <label for="exampleInputEmail1" class="form-label">UsuarioID</label>
              <asp:TextBox ID="tUsuarioID" class="form-control" runat="server"></asp:TextBox>
         </div>
         </div>
             <asp:Button ID="Button4" class="btn btn-dark" runat="server" Text="Agregar" OnClick="Button4_Click" />
             <asp:Button ID="Button3" class="btn btn-dark" runat="server" Text="Borrar" OnClick="Button3_Click" />
             <asp:Button ID="Button1" runat="server" class="btn btn-dark" Text="Modificar" OnClick="Button1_Click" />
             <asp:Button ID="Button2" runat="server" class="btn btn-dark" Text="Consultar" OnClick="Button2_Click" />
             <asp:Button ID="Button5" runat="server" class="btn btn-dark" Text="Mostrar todo" OnClick="Button5_Click" />
         </div>
</asp:Content>
