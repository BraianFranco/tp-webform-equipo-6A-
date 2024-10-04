<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelecciónPremio.aspx.cs" Inherits="Vista.SelecciónPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-center">Elegí tu premio</h1>


    <div class="row row-cols-3 row-cols-md-3 g-1" style="text-align: center; margin-left: 140px">
        <%  
            foreach (Modelo.Articulo art in ListaPremios)
            {
                List<string> imagenes = Controlador.ControladorImagen.getListImagenUrlsByArticuloId(art.Id);
                // le da un id diferente cada carousel 
                string carouselId = "carousel" + art.Id;
                Session.Add("codArticulo", art.Id);

        %>



        <div class="card text-bg-dark" style="margin-right: 35px; width: 20rem">



            <div id="<%= carouselId %>" class="carousel carousel-dark slide">

                <div class="carousel-inner">
                    <%  
                       
                    // dependiendo de cuantas url estén en la lista crea sus respectivos divs
                        for (int i = 0; i < imagenes.Count; i++)
                        {
                            string activo = (i == 0) ? "active" : "";
                    %>
                    <div class="carousel-item <%= activo %>">
                        <img style="height: 400px" src="<%= imagenes[i] %>" class="d-block w-100" alt="Imagen de <%= art.Nombre %>">
                    </div>
                    <%  
                        }
                    %>
                </div>



                <button class="carousel-control-prev" type="button" data-bs-target="#<%= carouselId %>" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Anterior</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#<%= carouselId %>" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Siguiente</span>
                </button>

            </div>



            <div class="card-body">
                <h5 class="card-title"><%= art.Nombre %> </h5>
                <p class="card-text"><%= art.Descripcion %></p>
                <asp:Button ID="btnSeleccionar" OnClick="btnSeleccionar_Click" CssClass="btn btn-primary" runat="server" Text="Seleccionar!" CommandArgument="<%= art.Id %>" />
            </div>
        </div>

        <%  
            }
        %>
    </div>


</asp:Content>
