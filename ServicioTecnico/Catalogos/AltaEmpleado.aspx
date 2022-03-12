<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaEmpleado.aspx.cs" Inherits="ServicioTecnico.Catalogos.AltaEmpleado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Alta de empleado</h3>
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
                    <label for="<%=fechaNacimiento.ClientID%>">Fecha Nacimiento</label>
                    <input id="fechaNacimiento" name="fechaNacimiento" type="text" class="form-control" runat="server" />
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
                <div class="form-group">
                    <label for="<%=DDLEstado.ClientID %>">Estado</label>
                    <asp:DropDownList ID="DDLEstado" CssClass="form-control" runat="server"></asp:DropDownList>

                    <asp:RequiredFieldValidator ControlToValidate="DDLEstado" ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ErrorMessage="Selecciona el Estado">
                    </asp:RequiredFieldValidator>


                </div>
                <div class="form-group">
                    <label for="<%=txtCiudad.ClientID %>">Ciudad</label>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Ciudad" MaxLength="50"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtCiudad" ID="RequiredFieldValidator6" runat="server" CssClass="text-danger" ErrorMessage="Ciudad es obligatoria">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtCalle.ClientID %>">Calle</label>
                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Calle" MaxLength="100"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtCalle" ID="RequiredFieldValidator7" runat="server" CssClass="text-danger" ErrorMessage="Calle es obligatoria">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtNumero.ClientID %>">Número</label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" placeholder="Número" MaxLength="10"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtNumero" ID="RequiredFieldValidator8" runat="server" CssClass="text-danger" ErrorMessage="Número es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtCP.ClientID %>">Código Postal</label>
                    <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" placeholder="Código Postal" MaxLength="10"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0;">
                            <asp:RequiredFieldValidator ControlToValidate="txtCP" ID="RequiredFieldValidator9" runat="server" CssClass="text-danger" ErrorMessage="Código Postal es obligatorio">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=DDLTipoEmpleado.ClientID %>">Tipo de Empleado</label>
                    <asp:DropDownList ID="DDLTipoEmpleado" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="DDLTipoEmpleado" ID="RequiredFieldValidator11" runat="server" CssClass="text-danger" ErrorMessage="Selecciona un tipo de empleado">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button OnClick="btnGuardar_Click" ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" />
                </div>
            </div>
        </div>
    </div>

    <script>
        //datetimepicker
        $(document).ready(function () {
            $.datetimepicker.setLocale('es');
            $("#<%=fechaNacimiento.ClientID%>").datetimepicker({ format: 'd/m/Y' });
        });
    </script>

</asp:Content>
