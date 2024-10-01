<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container text-center my-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card text-white bg-dark mb-3">
                        <div class="card-header py-3">Probá Suerte</div>
                        <div class="card-body my-5">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="mb-3">
                                        <label for="txtVoucherCode" class="form-label my-3 ">Ingresá el Código de tu Voucher!</label>
                                        <asp:TextBox runat="server" class="form-control w-50 mx-auto my-3" ID="txtVoucherCode" placeholder="X-X-X-X-X-X-X-X" ></asp:TextBox>
                                    </div>
                                    <asp:Button runat="server" ID="btnEnviar" type="submit" class="btn btn-primary my-3" Text="Siguiente" OnClick="btnEnviar_Click"></asp:Button>
                                    <asp:Label runat="server" ID="lblMensaje" CssClass="label-error my-3" Visible="false"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
