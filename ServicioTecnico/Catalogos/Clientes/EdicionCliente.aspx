<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EdicionCliente.aspx.cs" Inherits="ServicioTecnico.Catalogos.Clientes.EdicionCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Modificando el cliente <asp:Label ID="Id" runat="server"></asp:Label></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=txtNombre.ClientID %>">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre completo" MaxLength="50"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtNombre" ID="RFV1" runat="server" CssClass="text-danger" ErrorMessage="Nombre es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtApPaterno.ClientID %>">Apellido Paterno</label>
                    <asp:TextBox ID="txtApPaterno" runat="server" CssClass="form-control" placeholder="Apellido Paterno" MaxLength="50"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtApPaterno" ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Apellido paterno es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtApMaterno.ClientID %>">Apellido Materno</label>
                    <asp:TextBox ID="txtApMaterno" runat="server" CssClass="form-control" placeholder="Apellido Materno" MaxLength="50"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtApMaterno" ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Apellido materno es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtEmail.ClientID %>">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo electrónico" MaxLength="100"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Email es obligatorio">
                            </asp:RequiredFieldValidator>
                            <div style="position: absolute; top: 0; left: 0;">
                                <asp:RegularExpressionValidator runat="server" ErrorMessage="El correo debe contener @" ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="text-danger"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtTelefono.ClientID%>">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" placeholder="" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" ErrorMessage="Teléfono de chofer requerido"></asp:RequiredFieldValidator>
                    <%-- Acá colocaremos una máscara --%>
                    <ajaxToolkit:MaskedEditExtender ID="MEEtxtTelefono" TargetControlID="txtTelefono" Mask="(999) 999-9999" ClearMaskOnLostFocus="false" runat="server" />
                </div>
            </div>
            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button OnClick="btnGuardar_Click" ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
