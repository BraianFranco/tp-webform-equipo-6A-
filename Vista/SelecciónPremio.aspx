<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelecciónPremio.aspx.cs" Inherits="Vista.SelecciónPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 class="text-center">Elegí tu premio</h1>
    <table class="card bg-dark card-body my-5 align-items-center" style="height:auto"> 
        <tr>
            <td>
                <div class="card " style="margin-right:20px ; width: 18rem";>
                    <img src="https://gorilagames.com/img/Public/1019-producto-teclado-hyperx-origins-60-aqua-1-9668.jpg" class="card-img-top" alt="ImagenProducto">
                    <div class="card-body">
                        <h5 class="card-title">Titulo/Enlazar con la bsase de datos</h5>
                        <p class="card-text">Descripcion/Enlazar con la base de datos.</p>
                        <asp:Button ID="btnSeleccionar1" CssClass="btn btn-primary" runat="server" Text="Seleccionar!" />
                    </div>
                </div>
            </td>
            <td>
                <div class="card" style=" margin-right:20px ; width: 18rem;">
                    <img src="https://fullh4rd.com.ar/img/productos/14/mouse-logitech-g203-gaming-lightsync-black-910005793-0.jpg" class="card-img-top" alt="ImagenProducto">
                    <div class="card-body">
                        <h5 class="card-title">Titulo/Enlazar con la bsase de datos</h5>
                        <p class="card-text">Descripcion/Enlazar con la base de datos.</p>
                        <asp:Button ID="btnSeleccionar2" CssClass="btn btn-primary" runat="server" Text="Seleccionar!" />
                    </div>
                </div>
            </td>
            <td>
                <div class="card" style="margin-right:20px ; width: 18rem;">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRh0lhHnlUohByU9vb_Uq-MKmwjORg1RcGA_w&s" class="card-img-top" alt="ImagenProducto">
                    <div class="card-body">
                        <h5 class="card-title">Titulo/Enlazar con la bsase de datos</h5>
                        <p class="card-text">Descripcion/Enlazar con la base de datos.</p>
                        <asp:Button ID="btnSeleccionar3" CssClass="btn btn-primary" runat="server" Text="Seleccionar!" />
                    </div>
                </div>
            </td>
        </tr>

    </table>





</asp:Content>
