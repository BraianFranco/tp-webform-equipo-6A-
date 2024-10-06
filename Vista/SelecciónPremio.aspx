<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelecciónPremio.aspx.cs" Inherits="Vista.SelecciónPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center">Elegí tu premio</h1>

    <div class="row row-cols-3 row-cols-md-3 g-1" style="text-align: center; margin-left: 140px">
        <asp:Repeater runat="server" ID="repetidor" OnItemDataBound="ItemBound">
            <ItemTemplate>
                <div class="card text-bg-dark" style="margin-right: 35px; width: 20rem">
                    <div id="carousel<%# Eval("Id") %>" class="carousel carousel-dark slide" data-bs-ride="carousel">
                    

                        <div class="carousel-inner">
                            <asp:Repeater runat="server" ID="repetidorImagenes">
                                <ItemTemplate>
                                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                        <asp:Image runat="server" ImageUrl='<%# Container.DataItem %>' class="d-block w-100" style="height: 400px" alt="Imagen de un Articulo" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        

                    
                        <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>
                    

                 
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <asp:Button ID="btnSeleccionar" OnClick="btnSeleccionar_Click" CssClass="btn btn-primary" runat="server" Text="Seleccionar!" CommandArgument='<%# Eval("Id") %>' CommandName="IdArticulo" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>