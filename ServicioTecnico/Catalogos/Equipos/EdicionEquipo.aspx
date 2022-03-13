<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EdicionEquipo.aspx.cs" Inherits="ServicioTecnico.Catalogos.Equipos.EdicionEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Modificando equipo </h3>
                <asp:Label ID="Id" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=DDLMarca.ClientID %>">Marca</label>
                    <asp:DropDownList ID="DDLMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="DDLMarca" ID="RequiredFieldValidator10" runat="server" CssClass="text-danger" ErrorMessage="Selecciona la marca">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="<%=txtColor.ClientID %>">Color</label>
                    <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" placeholder="Marca del equipo" MaxLength="50"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtColor" ID="RFV1" runat="server" CssClass="text-danger" ErrorMessage="Color es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtDesc.ClientID %>">Descripción</label>
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" placeholder="Marca del equipo" MaxLength="50"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtColor" ID="RequiredFieldValidator12" runat="server" CssClass="text-danger" ErrorMessage="Color es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtEspec.ClientID %>">Especificaciones</label>
                    <asp:TextBox ID="txtEspec" runat="server" CssClass="form-control" placeholder="Especificaciones" MaxLength="200"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtEspec" ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Especificaciones es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtSerie.ClientID %>">Número de Serie</label>
                    <asp:TextBox ID="txtSerie" runat="server" CssClass="form-control" placeholder="Número de serie" MaxLength="50"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtSerie" ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Número de serie es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=subeImagen.ClientID%>">Seleccionar foto</label>
                    <div class="row">
                        <div class="col-md-3">
                            <input type="file" id="subeImagen" class="btn btn-file" runat="server" />
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="btnSubeImagen" CssClass="btn btn-primary" runat="server" Text="Subir" OnClick="btnSubeImagen_Click" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label>Foto</label>
                    <asp:Image ID="imgFotoEquipo" Width="150" Height="100" runat="server" />
                    <label id="urlFoto" runat="server"></label>
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
