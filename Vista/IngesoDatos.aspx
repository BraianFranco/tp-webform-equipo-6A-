<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngesoDatos.aspx.cs" Inherits="Vista.IngesoDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Ingresá tus datos</h1>

    <div class="card text-white bg-dark align-items-center card-body my-5">
        <div class="col-md-3">
            <label for="txtDni" class="form-label">DNI</label>
            <asp:TextBox ID="txtDni" type="text" CssClass="form-control" runat="server" placeholder="12345678900..."></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" type="text" CssClass="form-control" runat="server" placeholder="Jorge"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" type="text" CssClass="form-control" runat="server" placeholder="Romero"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label for="txtDireccion" class="form-label">Dirección</label>
            <asp:TextBox ID="txtDireccion" type="text" CssClass="form-control" runat="server" placeholder="Mi Dirección"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label for="txtEmail" class="form-label">Email</label>
            <div class="input-group">
                <div class="input-group-text">@</div>
                <asp:TextBox ID="txtEmail" type="email" CssClass="form-control" runat="server" placeholder="JorgeRomero@gmail.com"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <label for="txtCiudad" class="form-label">Ciudad</label>
            <asp:TextBox ID="txtCiudad" type="text" CssClass="form-control" runat="server" placeholder="CalleFalsa 123"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label for="txtCP" class="form-label">CP</label>
            <asp:TextBox ID="txtCP" type="text" CssClass="form-control" runat="server" placeholder="XXXX"></asp:TextBox>
        </div>
        <div class="col-md-3">
            ---------------------------------------------
        </div>
        <div class="col-md-3">
            <asp:CheckBox ID="cbTerminos" runat="server" />
            Acepto los términos y condiciones
        </div>
        <div class="col-md-3">
            ---------------------------------------------
        </div>
        <div class="col-3">
            <asp:Button ID="btnParticipar" CssClass="btn btn-primary center" OnClick="btnParticipar_Click" runat="server" Text="Participar!" />
        </div>
    </div>

</asp:Content>
