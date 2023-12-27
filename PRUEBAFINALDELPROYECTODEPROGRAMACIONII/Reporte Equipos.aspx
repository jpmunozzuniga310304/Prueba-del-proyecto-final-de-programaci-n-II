<%@ Page Title="" Language="C#" MasterPageFile="~/menu3.Master" AutoEventWireup="true" CodeBehind="Reporte Equipos.aspx.cs" Inherits="PRUEBAFINALDELPROYECTODEPROGRAMACIONII.Reporte_Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <h1>REPORTE EQUIPOS</h1>
</div>
<br />
<br />
<asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
RowStyle-CssClass="rows" AllowPaging="True" />
<br />
<br />
<br />
<div class="container text-center">
    <div class="mb-3">
       <label for="exampleInputEmail1" class="form-label">Reporte Equipos</label>
       <asp:TextBox ID="tReporteequipos" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <div class="container text-center">
            <asp:Button ID="Button1" runat="server" class="btn btn-dark" Text="Consultar" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" class="btn btn-dark" Text="Mostrar todo" OnClick="Button2_Click" />
        </div>
    </div>
    </div>
</asp:Content>
