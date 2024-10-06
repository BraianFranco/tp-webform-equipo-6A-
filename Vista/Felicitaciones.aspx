<%@ Page Title="Felicitaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Felicitaciones.aspx.cs" Inherits="Vista.Felicitaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">
        <div class="alert alert-success" role="alert" style="width: 100%; max-width: 600px;">
            <h1 class="alert-heading text-center">¡Felicitaciones!</h1>
            <p class="text-center">Ya estás participando por el producto que elegiste.</p>
            <hr>
            <p class="mb-0 text-center">Cuando desees, puedes volver al inicio.</p>
            <div class="text-center">
                <a href="default.aspx" class="btn btn-primary mt-3">Volver al Home</a>
            </div>
        </div>
    </div>

</asp:Content>