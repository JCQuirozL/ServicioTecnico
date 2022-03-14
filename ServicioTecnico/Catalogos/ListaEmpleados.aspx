<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEmpleados.aspx.cs" Inherits="ServicioTecnico.Catalogos.ListaEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <h3>Lista de empleados</h3>
                 <%if (GVEmpleados.Rows.Count== 0)
                    {  %>
                        <h4>No hay registros ingresados aún</h4><hr /> <br />
                        <a href="AltaEmpleado.aspx"><h4>Clic aquí</h4></a><h4>para empezar</h4>

                <%} %>
                <asp:GridView ID="GVEmpleados" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" OnRowEditing="GVEmpleados_RowEditing" OnRowCancelingEdit="GVEmpleados_RowCancelingEdit" OnRowUpdating="GVEmpleados_RowUpdating" OnRowDeleting="GVEmpleados_RowDeleting" DataKeyNames="Id" OnRowCommand="GVEmpleados_RowCommand">
                    <columns>
                        <%--<asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" ControlStyle-CssClass="btn btn-success" ControlStyle-Width="100px" ItemStyle-Width="100px" />--%>

                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                            <itemstyle width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Nombre" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido Paterno" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="ApPaterno" />
                        <asp:BoundField HeaderText="Apellido Materno" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="ApMaterno" />
                        <asp:BoundField HeaderText="Email" ControlStyle-Width="100px" ItemStyle-Width="100px" DataField="Email" />
                        <asp:BoundField HeaderText="Teléfono" ControlStyle-Width="100px" ItemStyle-Width="100px" DataField="Telefono" />
                        <asp:TemplateField HeaderText="Estado">
                            <controlstyle width="100px" />
                            <itemstyle width="100px" />
                            <itemtemplate>
                                <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("Estado") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:DropDownList ID="DDLEstado" CssClass="form-control" runat="server"></asp:DropDownList>
                            </edititemtemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ciudad" ItemStyle-Width="100px" ControlStyle-Width="100px" DataField="Ciudad" />
                        <asp:BoundField HeaderText="Calle" ItemStyle-Width="100px" ControlStyle-Width="100px" DataField="Calle" />
                        <asp:BoundField HeaderText="Número" ItemStyle-Width="100px" DataField="Numero" ControlStyle-Width="60px" />
                        <asp:BoundField HeaderText="Código Postal" ItemStyle-Width="80px" ControlStyle-Width="80px" DataField="CP" />
                        <asp:TemplateField HeaderText="Tipo Empleado">
                            <controlstyle width="100px" />
                            <itemstyle width="100px" />
                            <itemtemplate>
                                <asp:Label ID="lblTipoEmpleado" runat="server" Text='<%#Eval("TipoEmpleado") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:DropDownList ID="DDLTipoEmpleado" CssClass="form-control" runat="server"></asp:DropDownList>
                            </edititemtemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ControlStyle-Width="80px" ItemStyle-Width="80px" />
                        <asp:CommandField ShowEditButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-info" ControlStyle-Width="70px" ItemStyle-Width="70px" />
                        <asp:ButtonField Text="Seleccionar" CommandName="Select" ButtonType="Button" ControlStyle-CssClass="btn btn-info" />
                    </columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
